using SISCO.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Dynamic;
using SISCO.Repositories.Context;
using SISCO.Models;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using Devenlab.Common;
using MySql.Data.MySqlClient;

namespace SISCO.Repositories
{
    public class PodHandoverRepository : SISCOBaseRepository, IExtendedQueryableRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "Pod Handover";
        public PodHandoverRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public PodHandoverRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
            var model = businessModel as PodHandoverModel;
            if (model == null)
                throw new ModelNullException();
            var entity = PopulateModelToNewEntity(model);
            Entities.AddTopod_handover(entity);
            Entities.SaveChanges();

            model.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
            var model = businessModel as PodHandoverModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.pod_handover where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as PodHandoverModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.pod_handover select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.pod_handover where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.pod_handover where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}

        private static pod_handover PopulateModelToNewEntity(PodHandoverModel model)
		{
            return new pod_handover
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
                date_process = model.DateProcess,
                branch_id = model.BranchId,
                object_id = model.ObjectId,
                description = model.Description,
                printed = model.Printed,
                received_by = model.ReceivedBy,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}

        private static void PopulateModelToNewEntity(pod_handover query, PodHandoverModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
            query.date_process = model.DateProcess;
            query.branch_id = model.BranchId;
            query.object_id = model.ObjectId;
            query.description = model.Description;
            query.printed = model.Printed;
            query.received_by = model.ReceivedBy;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}

        private static PodHandoverModel PopulateEntityToNewModel(pod_handover item)
		{
            return new PodHandoverModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
                DateProcess = item.date_process,
                BranchId = item.branch_id,
                ObjectId = item.object_id,
                Description = item.description,
                Printed = item.printed,
                ReceivedBy = item.received_by,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby,
                
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.pod_handover select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.pod_handover select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.pod_handover select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.pod_handover select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in Entities.pod_handover select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.pod_handover select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public List<T> Search<T> (Paging paging, out int totalCount, int? id = null, DateTime? dateFrom = null, DateTime? dateTo = null, string pod = null)
        {
            var whereList = new List<string>();
            var paramList = new List<MySqlParameter>();

            var sql = @"SELECT
	                        p.id Id,
                            p.date_process DateProcess,
                            s.code Code
                        FROM pod_handover p
                        INNER JOIN pod_handover_detail pd ON p.id = pd.pod_handover_id AND pd.rowstatus = 1
                        INNER JOIN shipment s ON pd.shipment_id = s.id
                        WHERE {0}";

            whereList.Add("p.rowstatus = 1");
            if (id != null)
            {
                whereList.Add("p.id = @id");
                paramList.Add(new MySqlParameter("id", id));
            }

            if (dateFrom != null)
            {
                whereList.Add("p.date_process > @dateFrom");
                paramList.Add(new MySqlParameter("dateFrom", dateFrom));
            }

            if (dateTo != null)
            {
                whereList.Add("p.date_process < @dateTo");
                paramList.Add(new MySqlParameter("dateTo", dateTo));
            }

            if (!string.IsNullOrEmpty(pod))
            {
                whereList.Add("s.code = @pod");
                paramList.Add(new MySqlParameter("pod", pod));
            }

            sql = string.Format(sql, string.Join(" AND ", whereList));
            var result = Entities.ExecuteStoreQuery<T>(sql, paramList.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            totalCount = Entities.ExecuteStoreQuery<T>(sql, paramList.ToArray()).Count();
            return result;
        }
    }
}