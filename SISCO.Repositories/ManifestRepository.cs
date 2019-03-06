

/* 
*  SOLUTION 	: WaterManagementSolution
*  PROJECT		: Pdam.Common
*  TYPE 		: Generated - Data Access Repository
*  CREATED BY	: K
*  CREATED DATE	: Wednesday, May 21, 2014
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using SISCO.Models;
using SISCO.Repositories.Context;
using MySql.Data.MySqlClient;

namespace SISCO.Repositories
{
    public class ManifestRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "Manifest";
        public ManifestRepository()
        {
            ObjectName = OBJECT_NAME;
        }
        
        public ManifestRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as ManifestModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTomanifests(entity);
            Entities.SaveChanges();

            businessModel.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as ManifestModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.manifests where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as ManifestModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.manifests select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.manifests where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.manifests where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}
        
        private static manifest PopulateModelToNewEntity(ManifestModel model)
		{
			return new manifest
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				date_process = model.DateProcess,
				code = model.Code,
				branch_id = model.BranchId,
				dest_branch_id = model.DestBranchId,
				ttl_piece = model.TtlPiece,
				ttl_gross_weight = model.TtlGrossWeight,
				ttl_chargeable_weight = model.TtlChargeableWeight,
				fleet_id = model.FleetId,
				fleet_number = model.FleetNumber,
				fleet_date = model.FleetDate,
				fleet_time = model.FleetTime,
				flight_id = model.FlightId,
				flight_number = model.FlightNumber,
				flight_date = model.FlightDate,
				flight_time = model.FlightTime,
				printed = model.Printed,
				status_id = model.StatusId,
                shipping_plan_id = model.ShippingPlanId,
				createddate = model.Createddate,
				createdby = model.Createdby,
                createdpc = model.CreatedPc,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
                modifiedpc = model.ModifiedPc
			};
		}
        
        private static void PopulateModelToNewEntity(manifest query, ManifestModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
			query.date_process = model.DateProcess;
			query.code = model.Code;
			query.branch_id = model.BranchId;
			query.dest_branch_id = model.DestBranchId;
			query.ttl_piece = model.TtlPiece;
			query.ttl_gross_weight = model.TtlGrossWeight;
			query.ttl_chargeable_weight = model.TtlChargeableWeight;
			query.fleet_id = model.FleetId;
			query.fleet_number = model.FleetNumber;
			query.fleet_date = model.FleetDate;
			query.fleet_time = model.FleetTime;
			query.flight_id = model.FlightId;
			query.flight_number = model.FlightNumber;
			query.flight_date = model.FlightDate;
			query.flight_time = model.FlightTime;
			query.printed = model.Printed;
			query.status_id = model.StatusId;
            query.shipping_plan_id = model.ShippingPlanId;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
            query.createdpc = model.CreatedPc;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
            query.modifiedpc = model.ModifiedPc;
		}
        
        private static ManifestModel PopulateEntityToNewModel(manifest item)
		{
			return new ManifestModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				DateProcess = item.date_process,
				Code = item.code,
				BranchId = item.branch_id,
				DestBranchId = item.dest_branch_id,
				TtlPiece = item.ttl_piece,
				TtlGrossWeight = item.ttl_gross_weight,
				TtlChargeableWeight = item.ttl_chargeable_weight,
				FleetId = item.fleet_id,
				FleetNumber = item.fleet_number,
				FleetDate = item.fleet_date,
				FleetTime = item.fleet_time,
				FlightId = item.flight_id,
				FlightNumber = item.flight_number,
				FlightDate = item.flight_date,
				FlightTime = item.flight_time,
				Printed = item.printed,
				StatusId = item.status_id,
                ShippingPlanId = item.shipping_plan_id,
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
			var query = (from a in Entities.manifests select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);

            var obj = (from item in query
                join b in Entities.branches on item.branch_id equals b.id
                join d in Entities.branches on item.dest_branch_id equals d.id
                select new ManifestModel
                {
                    Id = item.id,
                    Rowstatus = item.rowstatus,
                    Rowversion = item.rowversion,
                    DateProcess = item.date_process,
                    Code = item.code,
                    BranchId = item.branch_id,
                    BranchName = b.name,
                    DestBranchId = item.dest_branch_id,
                    DestBranch = d.name,
                    TtlPiece = item.ttl_piece,
                    TtlGrossWeight = item.ttl_gross_weight,
                    TtlChargeableWeight = item.ttl_chargeable_weight,
                    FleetId = item.fleet_id,
                    FleetNumber = item.fleet_number,
                    FleetDate = item.fleet_date,
                    FleetTime = item.fleet_time,
                    FlightId = item.flight_id,
                    FlightNumber = item.flight_number,
                    FlightDate = item.flight_date,
                    FlightTime = item.flight_time,
                    Printed = item.printed,
                    StatusId = item.status_id,
                    ShippingPlanId = item.shipping_plan_id,
                    Createddate = item.createddate,
                    Createdby = item.createdby,
                    CreatedPc = item.createdpc,
                    Modifieddate = item.modifieddate,
                    Modifiedby = item.modifiedby,
                    ModifiedPc = item.modifiedpc
                });
			//return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
            return (IEnumerable<T>) obj.ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.manifests select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            //var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
            var obj = (IEnumerable<T>) (from item in query
                       join b in Entities.branches on item.branch_id equals b.id
                       join d in Entities.branches on item.dest_branch_id equals d.id
                       select new ManifestModel
                       {
                           Id = item.id,
                           Rowstatus = item.rowstatus,
                           Rowversion = item.rowversion,
                           DateProcess = item.date_process,
                           Code = item.code,
                           BranchId = item.branch_id,
                           BranchName = b.name,
                           DestBranchId = item.dest_branch_id,
                           DestBranch = d.name,
                           TtlPiece = item.ttl_piece,
                           TtlGrossWeight = item.ttl_gross_weight,
                           TtlChargeableWeight = item.ttl_chargeable_weight,
                           FleetId = item.fleet_id,
                           FleetNumber = item.fleet_number,
                           FleetDate = item.fleet_date,
                           FleetTime = item.fleet_time,
                           FlightId = item.flight_id,
                           FlightNumber = item.flight_number,
                           FlightDate = item.flight_date,
                           FlightTime = item.flight_time,
                           Printed = item.printed,
                           StatusId = item.status_id,
                           ShippingPlanId = item.shipping_plan_id,
                           Createddate = item.createddate,
                           Createdby = item.createdby,
                           CreatedPc = item.createdpc,
                           Modifieddate = item.modifieddate,
                           Modifiedby = item.modifiedby,
                           ModifiedPc = item.modifiedpc
                       });

		    return obj.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.manifests select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			var tquery = (from a in Entities.manifests select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();

			//return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();

            var obj = (from item in query
                       join b in Entities.branches on item.branch_id equals b.id
                       join d in Entities.branches on item.dest_branch_id equals d.id
                       select new ManifestModel
                       {
                           Id = item.id,
                           Rowstatus = item.rowstatus,
                           Rowversion = item.rowversion,
                           DateProcess = item.date_process,
                           Code = item.code,
                           BranchId = item.branch_id,
                           BranchName = b.name,
                           DestBranchId = item.dest_branch_id,
                           DestBranch = d.name,
                           TtlPiece = item.ttl_piece,
                           TtlGrossWeight = item.ttl_gross_weight,
                           TtlChargeableWeight = item.ttl_chargeable_weight,
                           FleetId = item.fleet_id,
                           FleetNumber = item.fleet_number,
                           FleetDate = item.fleet_date,
                           FleetTime = item.fleet_time,
                           FlightId = item.flight_id,
                           FlightNumber = item.flight_number,
                           FlightDate = item.flight_date,
                           FlightTime = item.flight_time,
                           Printed = item.printed,
                           StatusId = item.status_id,
                           ShippingPlanId = item.shipping_plan_id,
                           Createddate = item.createddate,
                           Createdby = item.createdby,
                           CreatedPc = item.createdpc,
                           Modifieddate = item.modifieddate,
                           Modifiedby = item.modifiedby,
                           ModifiedPc = item.modifiedpc
                       });
		    return (IEnumerable<T>) obj.ToList();
		}

        public List<ManifestList> GetManifestList(int branchId, DateTime date, int? destId)
        {
            var sql = @"SELECT
	                        m.code Code,
                            b.name DestBranch,
                            m.ttl_piece TtlPiece,
                            m.ttl_gross_weight TtlGrossWeight,
                            m.ttl_chargeable_weight TtlChargeableWeight,
                            m.printed Printed,
                            IF (m.shipping_plan_id IS NULL, null,
		                        IF (m.shipping_plan_id = 1, 'UDARA',
			                        IF (m.shipping_plan_id = 2, 'DARAT', 'LAUT')
                                )
                            ) ShippingPlan
                        FROM manifest m
                        INNER JOIN branch b ON m.dest_branch_id = b.id 
                        WHERE {0};";

            var sqlparam = new List<string>();
            var mysqlPar = new List<MySqlParameter>();

            sqlparam.Add("m.rowstatus = 1");
            sqlparam.Add("m.branch_id = @branchId");
            mysqlPar.Add(new MySqlParameter("branchId", branchId));
            sqlparam.Add(string.Format("m.date_process >= '{0}'", date.ToString("yyyy-MM-dd 00:00:00")));
            sqlparam.Add(string.Format("m.date_process <= '{0}'", date.ToString("yyyy-MM-dd 23:59:59")));

            if (destId != null)
            {
                sqlparam.Add("m.dest_branch_id = @destId");
                mysqlPar.Add(new MySqlParameter("destId", destId));
            }

            sql = string.Format(sql, string.Join(" AND ", sqlparam));
            return Entities.ExecuteStoreQuery<ManifestList>(sql, mysqlPar.ToArray()).ToList();
        }
    }
}