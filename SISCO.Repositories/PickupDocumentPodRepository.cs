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

namespace SISCO.Repositories
{
    public class PickupDocumentPodRepository : SISCOBaseRepository, IExtendedQueryableRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "Pickup Document POD";
        public PickupDocumentPodRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public PickupDocumentPodRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as PickupDocumentPodModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTopickup_document_pod(entity);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel)
		{
            var model = businessModel as PickupDocumentPodModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.pickup_document_pod where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as PickupDocumentPodModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.pickup_document_pod select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.pickup_document_pod where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
            var query = (from d in Entities.pickup_document_pod where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}

        private static pickup_document_pod PopulateModelToNewEntity(PickupDocumentPodModel model)
		{
			return new pickup_document_pod
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
                date_process = model.DateProcess,
				pickup_document_id = model.PickupDocumentId,
                shipment_code = model.ShipmentCode,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}

        private static void PopulateModelToNewEntity(pickup_document_pod query, PickupDocumentPodModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
            query.date_process = model.DateProcess;
            query.pickup_document_id = model.PickupDocumentId;
            query.shipment_code = model.ShipmentCode;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}

        private static PickupDocumentPodModel PopulateEntityToNewModel(pickup_document_pod item)
		{
            return new PickupDocumentPodModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
                DateProcess = item.date_process,
				PickupDocumentId = item.pickup_document_id,
                ShipmentCode = item.shipment_code,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby,
                StateChange2 = EnumStateChange.Idle.ToString()
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.pickup_document_pod select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.pickup_document_pod select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.pickup_document_pod select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.pickup_document_pod select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in Entities.pickup_document_pod select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.pickup_document_pod select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public IEnumerable<PickupDocumentAndPod> FilterDocumentPickup(IEnumerable<PickupDocumentModel> master,
            params IListParameter[] parameter)
        {
            if (parameter.Count() == 0)
            {
                var obj = (from m in master
                           join c1 in Entities.customers on m.CustomerShipperId equals c1.id
                           join c2 in Entities.customers on m.CustomerConsigneeId equals c2.id
                           join e in Entities.employees on m.MessengerId equals e.id
                           select new PickupDocumentAndPod
                           {
                               DateProcess = m.DateProcess,
                               Code = m.Code,
                               CustomerShipper = c1.name,
                               CustomerConsignee = c2.name,
                               MessengerName = e.name,
                               ShipmentCode = string.Empty
                           }).ToList<PickupDocumentAndPod>();

                return obj;
            }
            else
            {
                var whereterm = GetQueryParameterLinq(parameter);
                var query = (from a in Entities.pickup_document_pod select a).Where(whereterm, ListValue.ToArray()).ToList();

                var obj = (from a in query
                           join m in master on a.pickup_document_id equals m.Id
                           join c1 in Entities.customers on m.CustomerShipperId equals c1.id
                           join c2 in Entities.customers on m.CustomerConsigneeId equals c2.id
                           join e in Entities.employees on m.MessengerId equals e.id
                           select new PickupDocumentAndPod
                           {
                               DateProcess = m.DateProcess,
                               Code = m.Code,
                               CustomerShipper = c1.name,
                               CustomerConsignee = c2.name,
                               MessengerName = e.name,
                               ShipmentCode = a.shipment_code
                           }).ToList<PickupDocumentAndPod>();

                return obj;
            }
        }
    }
}


