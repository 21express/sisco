using System;
using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using SISCO.Models;
using SISCO.Repositories;
using SISCO.Repositories.Context;

namespace SISCO.App.Franchise
{
    public class FranchiseCommissionDataManager : BaseDataManager, IExtendedQueryableDataManager
    {
        public FranchiseCommissionDataManager()
        {
            Repository = new FranchiseCommissionRepository();
        }

        public override IEnumerable<T> Get<T>(params IListParameter[] listParameter)
        {
            return Repository.Get<T>(listParameter);
        }

        public override T GetFirst<T>(params IListParameter[] listParameter)
        {
            return Repository.GetSingle<T>(listParameter);
        }

        public override IEnumerable<T> Get<T>(Paging paging, out int count, params IListParameter[] listParameter)
        {
            return Repository.Get<T>(paging, out count, listParameter);
        }

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            return ((FranchiseCommissionRepository)Repository).Get<T>(paging, out totalCount, expression, parameters);
        }

        public List<FranchiseCommissionModel> GetActiveCommission(int franchiseId)
        {
            return new FranchiseCommissionRepository().GetActiveCommission(franchiseId);
        }

        public void CalculateCommission(ShipmentModel shipment, int franchiseId, string user)
        {
            var franchise = new FranchiseDataManager().GetFirst<FranchiseModel>(WhereTerm.Default(franchiseId, "id"));
            if (franchise == null) throw new Exception("Franchise not found.");

            var commission = new FranchiseCommissionModel();

            var service = new ServiceTypeRepository().GetSingle<ServiceTypeModel>(WhereTerm.Default("DARAT", "name", EnumSqlOperator.Equals));
            var serviceTypeid = -1;
            if (service != null) serviceTypeid = service.Id;

            if (shipment.PricingPlanId != 1 || shipment.ServiceTypeId == serviceTypeid) franchise.Commission = 10;

            var serviceSuperEco = new ServiceTypeRepository().GetSingle<ServiceTypeModel>(WhereTerm.Default("SUPER ECONOMI", "name", EnumSqlOperator.Equals));
            if (serviceSuperEco != null)
                if (shipment.ServiceTypeId == serviceSuperEco.Id) franchise.Commission = 15;

            commission.Rowstatus = true;
            commission.FranchiseId = franchiseId;
            commission.ShipmentId = shipment.Id;

            var expand = new ShipmentExpandRepository().GetSingle<ShipmentExpandModel>(WhereTerm.Default(shipment.Id, "shipment_id"));

            if (expand != null && expand.DropPointId != null)
            {
                franchise.Commission = 10;
                commission.TotalSales = shipment.Total;
                commission.PPN = Math.Round(commission.TotalSales / 101, MidpointRounding.AwayFromZero);
                commission.Commission = Math.Round((((franchise.Commission) / 100) * (commission.TotalSales - commission.PPN)), 0, MidpointRounding.AwayFromZero);
            }
            else
            {
                if (shipment.PromoId > 0) franchise.Commission = 10;

                if (shipment.PricingPlanId != 1) commission.TotalSales = shipment.TariffTotal * shipment.CurrencyRate;
                else commission.TotalSales = shipment.TariffTotal;

                commission.PPN = Math.Round(commission.TotalSales / 101, MidpointRounding.AwayFromZero);
                commission.Commission = Math.Round((((franchise.Commission) / 100) * (commission.TotalSales - commission.PPN) - shipment.DiscountTotal), 0, MidpointRounding.AwayFromZero);
            }

            var franchiseType = new FranchiseTypeDataManager().GetFirst<FranchiseTypeModel>(WhereTerm.Default((int)franchise.OrgType, "id", EnumSqlOperator.Equals));
            commission.PPH23 = Math.Round(commission.Commission * (franchiseType.PPh/100), 1, MidpointRounding.AwayFromZero);
            commission.TotalNetCommission = Math.Round(commission.Commission - commission.PPH23, 0, MidpointRounding.AwayFromZero);

            commission.Debs = shipment.Total - commission.TotalNetCommission;

            var listParam = new List<WhereTerm>();
            listParam.Add(WhereTerm.Default(franchiseId, "franchise_id", EnumSqlOperator.Equals));
            listParam.Add(WhereTerm.Default(shipment.Id, "shipment_id", EnumSqlOperator.Equals));

            var commExists = Repository.GetSingle<FranchiseCommissionModel>(listParam.ToArray());
            if (commExists != null)
            {
                commission.Id = commExists.Id;
                commission.Rowversion = DateTime.Now;
                commission.Createdby = commExists.Createdby;
                commission.Createddate = commExists.Createddate;
                commission.Modifiedby = user;
                commission.Modifieddate = DateTime.Now;
                Repository.Update(commission);
            }
            else
            {
                commission.Rowversion = DateTime.Now;
                commission.Createdby = user;
                commission.Createddate = DateTime.Now;
                Repository.Save(commission);
            }
        }

        public List<FranchiseCommissionModel> ReportCommission(params IListParameter[] parameter)
        {
            return new FranchiseCommissionRepository().ReportCommission(parameter);
        }

        public List<FranchiseCommissionModel> ReportPph23(params IListParameter[] parameter)
        {
            return new FranchiseCommissionRepository().ReportPph23(parameter);
        }
    }
}