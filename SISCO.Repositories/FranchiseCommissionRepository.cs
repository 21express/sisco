using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using SISCO.Models;
using SISCO.Repositories.Context;
using SISCO.Repositories.Interfaces;

namespace SISCO.Repositories
{
    public class FranchiseCommissionRepository : SISCOBaseRepository, IExtendedQueryableRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "FranchiseCommission";
        public FranchiseCommissionRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public FranchiseCommissionRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as FranchiseCommissionModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTofranchise_commission(entity);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel)
		{
            var model = businessModel as FranchiseCommissionModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.franchise_commission where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as FranchiseCommissionModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.franchise_commission select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.franchise_commission where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.franchise_commission where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}

        private static franchise_commission PopulateModelToNewEntity(FranchiseCommissionModel model)
        {
            return new franchise_commission
            {
                id = model.Id,
                rowstatus = model.Rowstatus,
                rowversion = model.Rowversion,
                franchise_id = model.FranchiseId,
                shipment_id = model.ShipmentId,
                total_sales = model.TotalSales,
                ppn_1 = model.PPN,
                commission = model.Commission,
                pph_23 = model.PPH23,
                total_net_commission = model.TotalNetCommission,
                debs = model.Debs,
                createddate = model.Createddate,
                createdby = model.Createdby,
                modifieddate = model.Modifieddate,
                modifiedby = model.Modifiedby,
            };
        }

        private static void PopulateModelToNewEntity(franchise_commission query, FranchiseCommissionModel model)
        {
            query.id = model.Id;
            query.rowstatus = model.Rowstatus;
            query.rowversion = model.Rowversion;
            query.franchise_id = model.FranchiseId;
            query.shipment_id = model.ShipmentId;
            query.total_sales = model.TotalSales;
            query.ppn_1 = model.PPN;
            query.commission = model.Commission;
            query.pph_23 = model.PPH23;
            query.total_net_commission = model.TotalNetCommission;
            query.debs = model.Debs;
            query.createddate = model.Createddate;
            query.createdby = model.Createdby;
            query.modifieddate = model.Modifieddate;
            query.modifiedby = model.Modifiedby;
        }

        private static FranchiseCommissionModel PopulateEntityToNewModel(franchise_commission item)
        {
            return new FranchiseCommissionModel
            {
                Id = item.id,
                Rowstatus = item.rowstatus,
                Rowversion = item.rowversion,
                FranchiseId = item.franchise_id,
                ShipmentId = item.shipment_id,
                TotalSales = item.total_sales,
                PPN = item.ppn_1,
                Commission = item.commission,
                PPH23 = item.pph_23,
                TotalNetCommission = item.total_net_commission,
                Debs = item.debs,
                Createddate = item.createddate,
                Createdby = item.createdby,
                Modifieddate = item.modifieddate,
                Modifiedby = item.modifiedby,

            };
        }

        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.franchise_commission select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public override T GetSingle<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.franchise_commission select a).Where(whereterm, ListValue.ToArray()).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
            return result.FirstOrDefault();
        }

        public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.franchise_commission select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.franchise_commission select a).Where(whereterm, ListValue.ToArray());
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in Entities.franchise_commission select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.franchise_commission select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public List<FranchiseCommissionModel> GetActiveCommission(int franchiseId)
        {
            var sql = @"
                SELECT 
                    f.id Id,
                    f.rowstatus Rowstatus,
                    f.rowversion Rowversion,
                    s.ttl_piece TtlPiece,
                    s.ttl_gross_weight TtlGrossWeight,
                    s.ttl_chargeable_weight TtlChargeableWeight,
                    s.code ShipmentCode,
                    f.franchise_id FranchiseId,
                    f.shipment_id ShipmentId,
                    f.total_sales TotalSales,
                    f.ppn_1 PPN,
                    f.commission Commission,
                    f.pph_23 PPH23,
                    f.total_net_commission TotalNetCommission,
                    f.debs Debs,
                    p.name PackageType,
                    t.name ServiceType,
                    f.createddate Createddate,
                    f.createdby Createdby,
                    f.modifieddate Modifieddate,
                    f.modifiedby Modifiedby,
                    false Checked,
                    1 StateChange
                FROM franchise_commission f
                INNER JOIN shipment s ON f.shipment_id = s.id
                INNER JOIN package_type p ON s.package_type_id = p.id
                INNER JOIN service_type t ON s.service_type_id = t.id
                WHERE s.rowstatus = 1 AND f.rowstatus = 1 AND f.franchise_id = ? AND s.pod_status = 0 AND s.voided = 0
                ORDER BY f.createddate
            ";
            var result = Entities.ExecuteStoreQuery<FranchiseCommissionModel>(sql, franchiseId).ToList();

            return result;
        }

        public List<FranchiseCommissionModel> ReportCommission(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);

            if (ListValue.Count > 0)
            {
                for (var i = 0; i < ListValue.Count; i++)
                {
                    whereterm = whereterm.Replace(string.Format("@{0}",i), "?");
                }
            }

            var sql = string.Format(@"
                SELECT 
                    f.id Id,
                    f.rowstatus Rowstatus,
                    f.rowversion Rowversion,
                    CONCAT(fs.code,' ', fs.name) FranchiseName,
                    s.date_process DateProcess,
                    s.ttl_piece TtlPiece,
                    s.ttl_gross_weight TtlGrossWeight,
                    s.ttl_chargeable_weight TtlChargeableWeight,
                    s.code ShipmentCode,
                    f.franchise_id FranchiseId,
                    f.shipment_id ShipmentId,
                    f.total_sales TotalSales,
                    f.ppn_1 PPN,
                    f.commission Commission,
                    f.pph_23 PPH23,
                    f.total_net_commission TotalNetCommission,
                    f.debs Debs,
                    f.createddate Createddate,
                    f.createdby Createdby,
                    f.modifieddate Modifieddate,
                    f.modifiedby Modifiedby,
                    s.customer_name CustomerName,
                    p.name PackageType,
                    s.insurance_fee InsuranceFee,
                    fs.npwp Npwp,
                    fs.npwp_name NpwpName,
                    s.shipper_name ShipperName,
                    y.name ServiceType,
                    s.other_fee OtherFee,
                    IF (se.drop_point_id IS NULL, 0, 1) IsDropPoint
                FROM franchise_commission f
                INNER JOIN shipment s ON f.shipment_id = s.id
                INNER JOIN package_type p ON s.package_type_id = p.id
                INNER JOIN service_type y ON s.service_type_id = y.id
                INNER JOIN franchise fs ON fs.id = f.franchise_id
                LEFT JOIN shipment_expand se ON s.id = se.shipment_id
                WHERE f.rowstatus = 1 AND s.voided = 0 AND {0}
                ORDER BY f.createddate
            ", whereterm.Replace("rowstatus", "s.rowstatus"));

            sql = sql.Replace(".Equals(?)", " = ?");
            var result = Entities.ExecuteStoreQuery<FranchiseCommissionModel>(sql, ListValue.ToArray()).ToList();
            return result;
        }

        public List<FranchiseCommissionModel> ReportPph23(params IListParameter[] parameter)
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
                    f.id Id,
                    f.rowstatus Rowstatus,
                    f.rowversion Rowversion,
                    s.date_process DateProcess,
                    CONCAT(fc.code, ' ', fc.name) FranchiseName,
                    s.ttl_piece TtlPiece,
                    s.ttl_gross_weight TtlGrossWeight,
                    s.ttl_chargeable_weight TtlChargeableWeight,
                    s.code ShipmentCode,
                    f.franchise_id FranchiseId,
                    f.shipment_id ShipmentId,
                    f.total_sales TotalSales,
                    f.ppn_1 PPN,
                    f.commission Commission,
                    f.pph_23 PPH23,
                    f.total_net_commission TotalNetCommission,
                    f.debs Debs,
                    f.createddate Createddate,
                    f.createdby Createdby,
                    f.modifieddate Modifieddate,
                    f.modifiedby Modifiedby,
                    s.customer_name CustomerName,
                    p.name PackageType,
                    fc.npwp Npwp,
                    fc.npwp_name NpwpName,
                    IF (pi.payment IS NULL, 'UNPAID', 'PAID') StatusPayment
                FROM franchise_commission f
                LEFT JOIN franchise_payment_in_detail pi ON f.shipment_id = pi.invoice_id AND pi.rowstatus = 1
                INNER JOIN franchise fc ON fc.id = f.franchise_id
                INNER JOIN shipment s ON f.shipment_id = s.id
                INNER JOIN package_type p ON s.package_type_id = p.id
                WHERE f.rowstatus = 1 AND s.voided = 0 AND {0}
                ORDER BY f.createddate
            ", whereterm.Replace("rowstatus", "s.rowstatus"));
            var result = Entities.ExecuteStoreQuery<FranchiseCommissionModel>(sql, ListValue.ToArray()).ToList();
            return result;
        }
    }
}