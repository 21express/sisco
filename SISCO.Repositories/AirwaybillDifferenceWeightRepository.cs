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
using MySql.Data.MySqlClient;

namespace SISCO.Repositories
{
    public class AirwaybillDifferenceWeightRepository : SISCOBaseRepository, IExtendedQueryableRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "AirwaybillDifferenceWeight";
        public AirwaybillDifferenceWeightRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public AirwaybillDifferenceWeightRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
            var model = businessModel as AirwaybillDifferenceWeightModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddToairwaybill_difference_weight(entity);
			Entities.SaveChanges();

            businessModel.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
            var model = businessModel as AirwaybillDifferenceWeightModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.airwaybill_difference_weight where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as AirwaybillDifferenceWeightModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.airwaybill_difference_weight select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.airwaybill_difference_weight where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.airwaybill_difference_weight where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}

        private static airwaybill_difference_weight PopulateModelToNewEntity(AirwaybillDifferenceWeightModel model)
		{
			return new airwaybill_difference_weight
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				date_process = model.DateProcess,
                branch_id = model.BranchId,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}

        private static void PopulateModelToNewEntity(airwaybill_difference_weight query, AirwaybillDifferenceWeightModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
            query.date_process = model.DateProcess;
            query.branch_id = model.BranchId;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}

        private static AirwaybillDifferenceWeightModel PopulateEntityToNewModel(airwaybill_difference_weight item)
		{
            return new AirwaybillDifferenceWeightModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				DateProcess = item.date_process,
                BranchId = item.branch_id,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.airwaybill_difference_weight select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.airwaybill_difference_weight select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.airwaybill_difference_weight select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.airwaybill_difference_weight select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in Entities.airwaybill_difference_weight select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.airwaybill_difference_weight select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public List<DifferenceWeightSearchModel> Search(int branchId, string consolCode = null, string shipmentCode = null)
        {
            var sql = @"SELECT
	                        adw.id Id,
                            adw.date_process DateProcess,
                            c.code ConsolidationCode,
                            s.code ShipmentCode
                        FROM airwaybill_difference_weight_detail adwd
                        INNER JOIN airwaybill_difference_weight adw ON adwd.airwaybill_difference_weight_id = adw.id AND adw.rowstatus = 1
                        INNER JOIN consolidation c ON adwd.consolidation_id = c.id
                        INNER JOIN shipment s ON adwd.shipment_id = s.id
                        WHERE {0};";

            var param = new List<string>();
            var sqlparam = new List<MySqlParameter>();
    
            param.Add("adwd.rowstatus = 1");
            param.Add("adw.branch_id = @branchId");
            sqlparam.Add(new MySqlParameter("branchId", branchId));
            
            if(!string.IsNullOrEmpty(consolCode))
            {
                param.Add("c.code = @consolCode");
                sqlparam.Add(new MySqlParameter("consolCode", consolCode));
            }

            if (!string.IsNullOrEmpty(shipmentCode))
            {
                param.Add("s.code = @shipmentCode");
                sqlparam.Add(new MySqlParameter("shipmentCode", shipmentCode));
            }

            sql = string.Format(sql, string.Join(" AND ", param));
            return Entities.ExecuteStoreQuery<DifferenceWeightSearchModel>(sql, param.ToArray()).ToList();
        }
    }
}