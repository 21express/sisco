

/* 
*  SOLUTION 	: WaterManagementSolution
*  PROJECT		: Pdam.Common
*  TYPE 		: Generated - Data Access Repository
*  CREATED BY	: K
*  CREATED DATE	: Wednesday, May 21, 2014
*/

using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Linq.Dynamic;
using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using SISCO.Models;
using SISCO.Repositories.Context;

namespace SISCO.Repositories
{
    public class PodCustomerRepository : SISCOBaseRepository
    {
        private const string OBJECT_NAME = "PodCustomer";
        public PodCustomerRepository()
        {
            ObjectName = OBJECT_NAME;
        }
        
        public PodCustomerRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as PodCustomerModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTopod_customer(entity);
            Entities.SaveChanges();

            businessModel.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as PodCustomerModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.pod_customer where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as PodCustomerModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.pod_customer select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.pod_customer where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.pod_customer where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}
        
        private static pod_customer PopulateModelToNewEntity(PodCustomerModel model)
		{
			return new pod_customer
			{
				id = model.Id,
				vdate = model.Vdate,
				vtime = model.Vtime,
				code = model.Code,
				branch_id = model.BranchId,
				dest_branch_id = model.DestBranchId,
				archive_location = model.ArchiveLocation,
				customer_id = model.CustomerId,
				customer_name = model.CustomerName,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}
        
        private static void PopulateModelToNewEntity(pod_customer query, PodCustomerModel model)
		{
			query.id = model.Id;
			query.vdate = model.Vdate;
			query.vtime = model.Vtime;
			query.code = model.Code;
			query.branch_id = model.BranchId;
			query.dest_branch_id = model.DestBranchId;
			query.archive_location = model.ArchiveLocation;
			query.customer_id = model.CustomerId;
			query.customer_name = model.CustomerName;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}
        
        private static PodCustomerModel PopulateEntityToNewModel(pod_customer item)
		{
			return new PodCustomerModel
			{
				Id = item.id,
				Vdate = item.vdate,
				Vtime = item.vtime,
				Code = item.code,
				BranchId = item.branch_id,
				DestBranchId = item.dest_branch_id,
				ArchiveLocation = item.archive_location,
				CustomerId = item.customer_id,
				CustomerName = item.customer_name,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby,
                
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.pod_customer select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.pod_customer select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.pod_customer select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			var tquery = (from a in Entities.pod_customer select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).Cast<PodCustomerModel>().ToList();
		}

        public string GenerateCode(PodCustomerModel model)
        {
            var branchPrefix = (from a in Entities.branches
                                where a.id == model.BranchId
                                select a.code).FirstOrDefault();

            var now = DateTime.Now;
            var pattern = string.Format("PDC-{0}-{1:0000}-{2:00}-#####", branchPrefix, now.Year, now.Month);

            return GenerateCode("pod_customer", pattern);
        }

        public IEnumerable<PodCustomerModel.PodCustomerLookupDataRow> GetJoinShipment(Paging paging, out int totalCount, IListParameter[] parameter)
        {
            var q = from a in Entities.pod_customer
                    join b in Entities.pod_customer_shipment on a.id equals b.pod_customer_id
                    select new
                    {
                        a.archive_location,
                        a.branch_id,
                        a.code,
                        a.createdby,
                        a.createddate,
                        a.customer_id,
                        a.customer_name,
                        a.dest_branch_id,
                        a.id,
                        a.modifiedby,
                        a.modifieddate,
                        a.rowstatus,
                        a.rowversion,
                        b.shipment_code,
                        a.vdate,
                        a.vtime
                    };

            var whereterm = GetQueryParameterLinq(parameter);
            var query = q.Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = q.Where(whereterm, ListValue.ToArray());
            totalCount = tquery.Count();
            return query.ToList().Select(a => new PodCustomerModel.PodCustomerLookupDataRow
            {
                ArchiveLocation = a.archive_location,
                BranchId = a.branch_id,
                Code = a.code,
                Createdby = a.createdby,
                Createddate = a.createddate,
                CustomerId = a.customer_id,
                CustomerName = a.customer_name,
                DestBranchId = a.dest_branch_id,
                Id = a.id,
                Modifiedby = a.modifiedby,
                Modifieddate = a.modifieddate,
                Rowstatus = a.rowstatus,
                Rowversion = a.rowversion,
                ShipmentCode = a.shipment_code,
                Vdate = a.vdate,
                Vtime = a.vtime
            });
        }
    }
}


