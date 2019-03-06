using Devenlab.Common.Fault;
using SISCO.Models;
using SISCO.Repositories.Context;
using SISCO.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Dynamic;
using Devenlab.Common.Interfaces;
using Devenlab.Common;
using MySql.Data.MySqlClient;

namespace SISCO.Repositories
{
    public class FranchiseDropPointDetailRepository : SISCOBaseRepository, IExtendedQueryableRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "Franchise Drop Point Detail";
        public FranchiseDropPointDetailRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public FranchiseDropPointDetailRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
            var model = businessModel as FranchiseDropPointDetailModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTofranchise_droppoint_detail(entity);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel)
		{
            var model = businessModel as FranchiseDropPointDetailModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.franchise_droppoint_detail where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as FranchiseDropPointDetailModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.franchise_droppoint_detail select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.franchise_droppoint_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
            var query = (from d in Entities.franchise_droppoint_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}

        private static franchise_droppoint_detail PopulateModelToNewEntity(FranchiseDropPointDetailModel model)
		{
            return new franchise_droppoint_detail
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
                franchise_droppoint_id = model.FranchiseDropPointId,
                shipment_id = model.ShipmentId,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}

        private static void PopulateModelToNewEntity(franchise_droppoint_detail query, FranchiseDropPointDetailModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
            query.franchise_droppoint_id = model.FranchiseDropPointId;
            query.shipment_id = model.ShipmentId;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}

        private static FranchiseDropPointDetailModel PopulateEntityToNewModel(franchise_droppoint_detail item)
		{
            return new FranchiseDropPointDetailModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				FranchiseDropPointId = item.franchise_droppoint_id,
                ShipmentId = item.shipment_id,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.franchise_droppoint_detail select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.franchise_droppoint_detail select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);

            var query = (from fd in Entities.franchise_droppoint
                         join fdd in Entities.franchise_droppoint_detail on fd.id equals fdd.franchise_droppoint_id
                         join s in Entities.shipments on fdd.shipment_id equals s.id
                         join se in Entities.shipment_expand on s.id equals se.shipment_id
                         join dp in Entities.drop_point on se.drop_point_id equals dp.id
                         where s.rowstatus && !s.voided && fdd.rowstatus && dp.rowstatus
                         select new FranchiseDropPointDetailSearch
                         {
                             Id = fdd.id,
                             Rowstatus = fdd.rowstatus,
                             Rowversion = fdd.rowversion,
                             FranchiseDropPointId = fdd.franchise_droppoint_id,
                             ShipmentId = fdd.shipment_id,
                             Createddate = fdd.createddate,
                             Createdby = fdd.createdby,
                             Modifieddate = fdd.modifieddate,
                             Modifiedby = fdd.modifiedby,

                             Code = fd.code,
                             PickupDate = fd.pickup_date,
                             ShipmentCode = s.code,
                             DropPointName = dp.name,
                             FranchiseId = s.franchise_id,
                             BranchId = s.branch_id
                         }).Where(whereterm, ListValue.ToArray());

            if (query == null)
                throw new Exception(MessageEntityNotFound);

            totalCount = query.ToList().Count();

            return (IEnumerable<T>)query.OrderBy("PickupDate " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            
		}

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);

            var query = (from a in Entities.franchise_droppoint_detail select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.franchise_droppoint_detail select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public FranchiseDropPointPickup PickupDropPoint(string shipmentCode)
        {
            var sql = @"SELECT
	                        s.id Id,
	                        s.code ShipmentCode,
                            s.date_process ShipmentDate,
                            CONCAT(dp.code, ' ', dp.name) DropPointName,
                            s.ttl_piece TtlPiece,
                            s.ttl_gross_weight TtlGrossWeight,
                            s.ttl_chargeable_weight TtlChargeable,
                            s.total Total
                        FROM shipment s
                        INNER JOIN shipment_expand se ON s.id = se.shipment_id 
                        INNER JOIN drop_point dp ON se.drop_point_id = dp.id AND dp.rowstatus = 1
                        WHERE {0}";

            var sqlWhere = new List<MySqlParameter>();
            var strWhere = new List<string>();

            strWhere.Add("s.rowstatus = 1");
            strWhere.Add("s.code = @shipmentCode");
            sqlWhere.Add(new MySqlParameter("shipmentCode", shipmentCode));

            sql = string.Format(sql, string.Join(" AND ", strWhere));

            return Entities.ExecuteStoreQuery<FranchiseDropPointPickup>(sql, sqlWhere.ToArray()).FirstOrDefault();
        }

        public List<FranchiseDropPointPickup> GetPickupDropPoint(int franchiseDropPointId)
        {
            var sql = @"SELECT
	                        s.id Id,
	                        s.code ShipmentCode,
                            s.date_process ShipmentDate,
                            CONCAT(dp.code, ' ', dp.name) DropPointName,
                            s.ttl_piece TtlPiece,
                            s.ttl_gross_weight TtlGrossWeight,
                            s.ttl_chargeable_weight TtlChargeable,
                            s.total Total
                        FROM franchise_droppoint fd
                        INNER JOIN franchise_droppoint_detail fdd ON fd.id = fdd.franchise_droppoint_id AND fdd.rowstatus = 1
                        INNER JOIN shipment s ON fdd.shipment_id = s.id AND s.rowstatus = 1
                        INNER JOIN shipment_expand se ON s.id = se.shipment_id 
                        INNER JOIN drop_point dp ON se.drop_point_id = dp.id AND dp.rowstatus = 1
                        WHERE fd.rowstatus = 1 AND fd.id = @franchiseDropPointId;";

            return Entities.ExecuteStoreQuery<FranchiseDropPointPickup>(sql, new MySqlParameter("franchiseDropPointId", franchiseDropPointId)).ToList();
        }

        public FranchiseDropPointPickup ShipmentPickedup(string shipmentCode)
        {
            var sql = @"SELECT
	                        s.id Id,
	                        s.code ShipmentCode,
                            s.date_process ShipmentDate,
                            CONCAT(dp.code, ' ', dp.name) DropPointName,
                            s.ttl_piece TtlPiece,
                            s.ttl_gross_weight TtlGrossWeight,
                            s.ttl_chargeable_weight TtlChargeable,
                            s.total Total
                        FROM franchise_droppoint fd
                        INNER JOIN franchise_droppoint_detail fdd ON fd.id = fdd.franchise_droppoint_id AND fdd.rowstatus = 1
                        INNER JOIN shipment s ON fdd.shipment_id = s.id AND s.rowstatus = 1
                        INNER JOIN shipment_expand se ON s.id = se.shipment_id 
                        INNER JOIN drop_point dp ON se.drop_point_id = dp.id AND dp.rowstatus = 1
                        WHERE fd.rowstatus = 1 AND s.code = @shipmentCode;";

            return Entities.ExecuteStoreQuery<FranchiseDropPointPickup>(sql, new MySqlParameter("shipmentCode", shipmentCode)).FirstOrDefault();
        }
    }
}