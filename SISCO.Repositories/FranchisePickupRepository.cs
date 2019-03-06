using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using SISCO.Models;
using SISCO.Repositories.Context;
using SISCO.Repositories.Interfaces;
using System.Data.Objects;

namespace SISCO.Repositories
{
    public class FranchisePickupRepository : SISCOBaseRepository, IExtendedQueryableRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "FranchisePickup";
        public FranchisePickupRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public FranchisePickupRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as FranchisePickupModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTofranchise_pickup(entity);
			Entities.SaveChanges();

            businessModel.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as FranchisePickupModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.franchise_pickup where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as FranchisePickupModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.franchise_pickup select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.franchise_pickup where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
            Entities.SaveChanges();
        }

        public override void Delete(int id)
        {
            var query = (from d in Entities.franchise_pickup where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            Entities.DeleteObject(query);
            Entities.SaveChanges();
        }

        private static franchise_pickup PopulateModelToNewEntity(FranchisePickupModel model)
        {
            return new franchise_pickup
            {
                id = model.Id,
                rowstatus = model.Rowstatus,
                rowversion = model.Rowversion,
                code = model.Code,
                date_process = model.DateProcess,
                franchise_id = model.FranchiseId,
                ttl_pod = model.TtlPod,
                ttl_gross_weight = model.TtlGrossWeight,
                ttl_chargeable = model.TtlChargeable,
                ttl_sales = model.TtlSales,
                ttl_ppn = model.TtlPpn,
                ttl_commission = model.TtlCommission,
                ttl_pph_23 = model.TtlPph23,
                ttl_net_commission = model.TtlNetCommission,
                balance = model.Balance,
                payment_type_agent = model.PaymentTypeAgent,
                messenger_id = model.MessengerId,
                is_print = model.IsPrint,
                createddate = model.Createddate,
                createdby = model.Createdby,
                createdpc = model.CreatedPc,
                modifieddate = model.Modifieddate,
                modifiedby = model.Modifiedby,
                modifiedpc = model.ModifiedPc
            };
        }

        private static void PopulateModelToNewEntity(franchise_pickup query, FranchisePickupModel model)
        {
            query.id = model.Id;
            query.rowstatus = model.Rowstatus;
            query.rowversion = model.Rowversion;
            query.code = model.Code;
            query.date_process = model.DateProcess;
            query.franchise_id = model.FranchiseId;
            query.ttl_pod = model.TtlPod;
            query.ttl_gross_weight = model.TtlGrossWeight;
            query.ttl_chargeable = model.TtlChargeable;
            query.ttl_sales = model.TtlSales;
            query.ttl_ppn = model.TtlPpn;
            query.ttl_commission = model.TtlCommission;
            query.ttl_pph_23 = model.TtlPph23;
            query.ttl_net_commission = model.TtlNetCommission;
            query.balance = model.Balance;
            query.payment_type_agent = model.PaymentTypeAgent;
            query.messenger_id = model.MessengerId;
            query.is_print = model.IsPrint;
            query.createddate = model.Createddate;
            query.createdby = model.Createdby;
            query.createdpc = model.CreatedPc;
            query.modifieddate = model.Modifieddate;
            query.modifiedby = model.Modifiedby;
            query.modifiedpc = model.ModifiedPc;
        }

        private static FranchisePickupModel PopulateEntityToNewModel(franchise_pickup item)
        {
            return new FranchisePickupModel
            {
                Id = item.id,
                Rowstatus = item.rowstatus,
                Rowversion = item.rowversion,
                Code = item.code,
                DateProcess = item.date_process,
                FranchiseId = item.franchise_id,
                TtlPod = item.ttl_pod,
                TtlGrossWeight = item.ttl_gross_weight,
                TtlChargeable = item.ttl_chargeable,
                TtlSales = item.ttl_sales,
                TtlPpn = item.ttl_ppn,
                TtlCommission = item.ttl_commission,
                TtlPph23 = item.ttl_pph_23,
                TtlNetCommission = item.ttl_net_commission,
                Balance = item.balance,
                PaymentTypeAgent = item.payment_type_agent,
                MessengerId = item.messenger_id,
                IsPrint = item.is_print,
                Createddate = item.createddate,
                Createdby = item.createdby,
                CreatedPc = item.createdpc,
                Modifieddate = item.modifieddate,
                Modifiedby = item.modifiedby,
                ModifiedPc = item.modifiedpc
            };
        }

        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.franchise_pickup select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public override T GetSingle<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.franchise_pickup select a).Where(whereterm, ListValue.ToArray()).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
            return result.FirstOrDefault();
        }

        public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.franchise_pickup select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.franchise_pickup select a).Where(whereterm, ListValue.ToArray());
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in Entities.franchise_pickup select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.franchise_pickup select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public string GenerateCode(DateTime date)
        {
            var pattern = string.Format("{0}{1}{2}{3}###", "FPU", date.ToString("yy"), date.ToString("MM"), date.ToString("dd"));

            return GenerateCode("franchise-pickup", pattern);
        }

        public string GenerateCode_2(DateTime date)
        {
            var pattern = string.Format("{0}{1}{2}{3}###", "FPU", date.ToString("yy"), date.ToString("MM"), date.ToString("dd"));

            return GenerateCode_2("franchise-pickup", pattern);
        }

        public List<FranchisePayment> ReportPayment(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);

            if (ListValue.Count > 0)
            {
                for (var i = 0; i < ListValue.Count; i++)
                {
                    whereterm = whereterm.Replace(string.Format("@{0}", i), "?");
                }
            }

            var sql = string.Format(@"
                SELECT
	                fp.date_process DateProcess,
	                fp.code PickedUpCode,
	                IF (fp.payment_type_agent = 0, 'Cash', 'Bank Transfer') PaymentType,
	                s.code ShipmentCode,
	                fc.total_sales TotalSales,
	                fc.total_net_commission TotalNetCommission,
	                fc.debs Debs,
	                IF (s.paid = 1, 'Paid', 'Unpaid') PodStatus
                FROM franchise_pickup fp
                INNER JOIN franchise_pickup_detail fpd ON fp.id = fpd.franchise_pickup_id AND fpd.rowstatus = 1
                INNER JOIN franchise_commission fc ON fpd.shipment_id = fc.shipment_id AND fc.rowstatus = 1
                INNER JOIN shipment s ON fc.shipment_id = s.id AND s.rowstatus = 1
                WHERE s.voided = 0 AND s.pod_status <> 0 AND {0}
                ORDER BY fp.createddate
            ", whereterm.Replace("rowstatus", "fp.rowstatus"));
            var result = Entities.ExecuteStoreQuery<FranchisePayment>(sql, ListValue.ToArray()).ToList();
            return result;
        }
    }
}
