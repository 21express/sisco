using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using SISCO.Models;
using SISCO.Repositories.Context;

namespace SISCO.Repositories
{
    public class ShipmentAllocationRepository : SISCOBaseRepository
    {
        private const string OBJECT_NAME = "ShipmentAllocation";
        public ShipmentAllocationRepository()
        {
            ObjectName = OBJECT_NAME;
        }
        
        public ShipmentAllocationRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as ShipmentAllocationModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddToshipment_allocation(entity);
			Entities.SaveChanges();

            businessModel.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as ShipmentAllocationModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.shipment_allocation where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as ShipmentAllocationModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.shipment_allocation select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.shipment_allocation where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.shipment_allocation where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}
        
        private static shipment_allocation PopulateModelToNewEntity(ShipmentAllocationModel model)
		{
			return new shipment_allocation
			{
				id = model.Id,
				alloc_date = model.AllocDate,
				branch_id = model.BranchId,
				customer_id = model.CustomerId,
                franchise_id = model.FranchiseId,
                drop_point_id = model.DropPointId,
				customer_name = model.CustomerName,
				customer_address = model.CustomerAddress,
				shipment_code_start = model.ShipmentCodeStart,
				shipment_code_end = model.ShipmentCodeEnd,
				shipment_code_count = model.ShipmentCodeCount,
				shipment_code_used = model.ShipmentCodeUsed,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}
        
        private static void PopulateModelToNewEntity(shipment_allocation query, ShipmentAllocationModel model)
		{
			query.id = model.Id;
			query.alloc_date = model.AllocDate;
			query.branch_id = model.BranchId;
			query.customer_id = model.CustomerId;
            query.franchise_id = model.FranchiseId;
            query.drop_point_id = model.DropPointId;
			query.customer_name = model.CustomerName;
			query.customer_address = model.CustomerAddress;
			query.shipment_code_start = model.ShipmentCodeStart;
			query.shipment_code_end = model.ShipmentCodeEnd;
			query.shipment_code_count = model.ShipmentCodeCount;
			query.shipment_code_used = model.ShipmentCodeUsed;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}
        
        private static ShipmentAllocationModel PopulateEntityToNewModel(shipment_allocation item)
		{
			return new ShipmentAllocationModel
			{
				Id = item.id,
				AllocDate = item.alloc_date,
				BranchId = item.branch_id,
				CustomerId = item.customer_id,
                FranchiseId = item.franchise_id,
                DropPointId = item.drop_point_id,
				CustomerName = item.customer_name,
				CustomerAddress = item.customer_address,
				ShipmentCodeStart = item.shipment_code_start,
				ShipmentCodeEnd = item.shipment_code_end,
				ShipmentCodeCount = item.shipment_code_count,
				ShipmentCodeUsed = item.shipment_code_used,
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
			var query = (from a in Entities.shipment_allocation select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.shipment_allocation select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.shipment_allocation select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			var tquery = (from a in Entities.shipment_allocation select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public int GetAllocationUsedCount(ShipmentAllocationModel p)
        {
            var start = p.ShipmentCodeStart.ToString();
            var end = p.ShipmentCodeEnd.ToString();

            var q = (from a in Entities.shipments
                     where a.code.CompareTo(start) >= 0 && a.code.CompareTo(end) <= 0
                    && a.rowstatus
                    select a).Count();
            return q;
        }

        public bool CheckIsUsed(int currentId, Int64 start, Int64 end)
        {
            var q = from a in Entities.shipment_allocation
                    where (
                        (start >= a.shipment_code_start && start <= a.shipment_code_end)
                        || (end >= a.shipment_code_start && end <= a.shipment_code_end)
                        || (start <= a.shipment_code_start && end >= a.shipment_code_end)
                    )
                    && a.rowstatus
                    && a.id != currentId
                    select a.shipment_code_used;
            return q.Any();
        }
    }
}