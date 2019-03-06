

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
using System.Transactions;
using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using SISCO.Models;
using SISCO.Repositories.Context;

namespace SISCO.Repositories
{
    public class PodCustomerShipmentRepository : SISCOBaseRepository
    {
        private const string OBJECT_NAME = "PodCustomerShipment";
        public PodCustomerShipmentRepository()
        {
            ObjectName = OBJECT_NAME;
        }
        
        public PodCustomerShipmentRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as PodCustomerShipmentModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTopod_customer_shipment(entity);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as PodCustomerShipmentModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.pod_customer_shipment where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as PodCustomerShipmentModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.pod_customer_shipment select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.pod_customer_shipment where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.pod_customer_shipment where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}
        
        private static pod_customer_shipment PopulateModelToNewEntity(PodCustomerShipmentModel model)
		{
			return new pod_customer_shipment
			{
				id = model.Id,
				pod_customer_id = model.PodCustomerId,
				shipment_id = model.ShipmentId,
				shipment_date = model.ShipmentDate,
				shipment_code = model.ShipmentCode,
				branch_id = model.BranchId,
				shipper_name = model.ShipperName,
				received_cust_by = model.ReceivedCustBy,
				received_cust_date = model.ReceivedCustDate,
				received_cust_time = model.ReceivedCustTime,
				sent = model.Sent,
				received = model.Received,
                returned = model.Returned,
                note = model.Note,
                surat_jalan = model.SuratJalan,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}
        
        private static void PopulateModelToNewEntity(pod_customer_shipment query, PodCustomerShipmentModel model)
		{
			query.id = model.Id;
			query.pod_customer_id = model.PodCustomerId;
			query.shipment_id = model.ShipmentId;
			query.shipment_date = model.ShipmentDate;
			query.shipment_code = model.ShipmentCode;
			query.branch_id = model.BranchId;
			query.shipper_name = model.ShipperName;
			query.received_cust_by = model.ReceivedCustBy;
			query.received_cust_date = model.ReceivedCustDate;
			query.received_cust_time = model.ReceivedCustTime;
			query.sent = model.Sent;
			query.received = model.Received;
            query.returned = model.Returned;
            query.note = model.Note;
            query.surat_jalan = model.SuratJalan;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}
        
        private static PodCustomerShipmentModel PopulateEntityToNewModel(pod_customer_shipment item)
		{
			return new PodCustomerShipmentModel
			{
				Id = item.id,
				PodCustomerId = item.pod_customer_id,
				ShipmentId = item.shipment_id,
				ShipmentDate = item.shipment_date,
				ShipmentCode = item.shipment_code,
				BranchId = item.branch_id,
				ShipperName = item.shipper_name,
				ReceivedCustBy = item.received_cust_by,
				ReceivedCustDate = item.received_cust_date,
				ReceivedCustTime = item.received_cust_time,
				Sent = item.sent,
				Received = item.received,
                Returned = item.returned,
                Note = item.note,
                SuratJalan = item.surat_jalan,
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
			var query = (from a in Entities.pod_customer_shipment select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.pod_customer_shipment select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.pod_customer_shipment select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			var tquery = (from a in Entities.pod_customer_shipment select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).Cast<PodCustomerShipmentModel>().ToList();
		}

        public void Save<T>(int p, IList<T> models)
        {
            var shipmentIds = new List<int>(new[] { 0 });

            using (var scope = new TransactionScope())
            {
                Entities.ExecuteStoreCommand("DELETE FROM pod_customer_shipment WHERE pod_customer_id = {0}", p);

                for (var i = 0; i < models.Count(); i++)
                {
                    var model = models[i] as PodCustomerShipmentModel;
                    if (model == null)
                        throw new ModelNullException();

                    model.PodCustomerId = p;

                    var entity = PopulateModelToNewEntity(model);
                    Entities.AddTopod_customer_shipment(entity);

                    shipmentIds.Add(model.ShipmentId);
                }

                Entities.ExecuteStoreCommand(string.Format("UPDATE shipment SET pod_returned = 1 WHERE id IN ({0})",
                    string.Join(",", shipmentIds)));

                Entities.SaveChanges();

                scope.Complete();
            }
        }
    }
}


