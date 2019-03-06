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
    public class ShipmentStatusRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "ShipmentStatus";
        public ShipmentStatusRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public ShipmentStatusRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }

        public override void Save<T>(T businessModel)
        {
            var model = businessModel as ShipmentStatusModel;
            if (model == null)
                throw new ModelNullException();
            var entity = PopulateModelToNewEntity(model);
            Entities.AddToshipment_status(entity);
            Entities.SaveChanges();
        }

        public override void Update<T>(T businessModel)
        {
            var model = businessModel as ShipmentStatusModel;
            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.shipment_status where d.id == model.Id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as ShipmentStatusModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.shipment_status select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.shipment_status where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
            Entities.SaveChanges();
        }

        public override void Delete(int id)
        {
            var query = (from d in Entities.shipment_status where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            Entities.DeleteObject(query);
            Entities.SaveChanges();
        }

        private static shipment_status PopulateModelToNewEntity(ShipmentStatusModel model)
        {
            return new shipment_status
            {
                id = model.Id,
                rowstatus = model.Rowstatus,
                rowversion = model.Rowversion,
                shipment_id = model.ShipmentId,
                dateprocess = model.DateProcess,
                tracking_status_id = model.TrackingStatusId,
                miss_delivery_reason = model.MissDeliveryReason,
                position_status_id = model.PositionStatusId,
                position_status = model.PositionStatus,
                branch_id = model.BranchId,
                status_by = model.StatusBy,
                status_note = model.StatusNote,
                reference = model.Reference,
                employee_id = model.EmployeeId,
                createddate = model.Createddate,
                createdby = model.Createdby,
                modifieddate = model.Modifieddate,
                modifiedby = model.Modifiedby,
            };
        }

        private static void PopulateModelToNewEntity(shipment_status query, ShipmentStatusModel model)
        {
            query.id = model.Id;
            query.rowstatus = model.Rowstatus;
            query.rowversion = model.Rowversion;
            query.shipment_id = model.ShipmentId;
            query.dateprocess = model.DateProcess;
            query.tracking_status_id = model.TrackingStatusId;
            query.miss_delivery_reason = model.MissDeliveryReason;
            query.position_status_id = model.PositionStatusId;
            query.position_status = model.PositionStatus;
            query.branch_id = model.BranchId;
            query.status_by = model.StatusBy;
            query.reference = model.Reference;
            query.employee_id = model.EmployeeId;
            query.status_note = model.StatusNote;
            query.createddate = model.Createddate;
            query.createdby = model.Createdby;
            query.modifieddate = model.Modifieddate;
            query.modifiedby = model.Modifiedby;
        }

        private static ShipmentStatusModel PopulateEntityToNewModel(shipment_status item)
        {
            return new ShipmentStatusModel
            {
                Id = item.id,
                Rowstatus = item.rowstatus,
                Rowversion = item.rowversion,
                ShipmentId = item.shipment_id,
                DateProcess = item.dateprocess,
                TrackingStatusId = item.tracking_status_id,
                MissDeliveryReason = item.miss_delivery_reason,
                PositionStatusId = item.position_status_id,
                PositionStatus = item.position_status,
                BranchId = item.branch_id,
                StatusBy = item.status_by,
                StatusNote = item.status_note,
                Reference = item.reference,
                EmployeeId = item.employee_id,
                Createddate = item.createddate,
                Createdby = item.createdby,
                Modifieddate = item.modifieddate,
                Modifiedby = item.modifiedby
            };
        }

        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.shipment_status select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public override T GetSingle<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.shipment_status select a).Where(whereterm, ListValue.ToArray()).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
            return result.FirstOrDefault();
        }

        public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.shipment_status select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.shipment_status select a).Where(whereterm, ListValue.ToArray());
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public void Save<T>(int p, IList<T> models)
        {
            if (models.Count > 0)
            {
                using (var scope = new TransactionScope())
                {
                    //Entities.ExecuteStoreCommand("DELETE FROM shipment_status WHERE shipment_id = {0}", p);
                    for (var i = 0; i < models.Count(); i++)
                    {
                        var model = models[i] as ShipmentStatusModel;
                        if (model == null)
                            throw new ModelNullException();

                        model.ShipmentId = p;

                        var entity = PopulateModelToNewEntity(model);
                        Entities.AddToshipment_status(entity);
                    }

                    Entities.SaveChanges();
                    scope.Complete();
                }
            }
        }

        public ShipmentStatusModel GetLastStatusByShipment(int shipmentId, List<int> trackingStatuses)
        {
            var tracking = (from s in Entities.shipment_status
                            where s.rowstatus.Equals(true) && s.shipment_id == shipmentId
                            group s by new { s.shipment_id }
                                into g
                                select new
                                {
                                    g.Key.shipment_id,
                                    tracking_status_id = g.Max(x => x.tracking_status_id)
                                }).FirstOrDefault(xx => trackingStatuses.Contains(xx.tracking_status_id));

            if (tracking != null)
            {
                var query = (from item in
                                 (from i in Entities.shipment_status
                                  where
                                      i.rowstatus.Equals(true) && i.shipment_id == shipmentId &&
                                      i.tracking_status_id == tracking.tracking_status_id
                                  select i)
                             join t in Entities.tracking_status on item.tracking_status_id equals t.id
                             select new ShipmentStatusModel
                             {
                                 Id = item.id,
                                 Rowstatus = item.rowstatus,
                                 Rowversion = item.rowversion,
                                 ShipmentId = item.shipment_id,
                                 DateProcess = item.dateprocess,
                                 TrackingStatusId = item.tracking_status_id,
                                 TrackingStatus = t.code,
                                 MissDeliveryReason = item.miss_delivery_reason,
                                 PositionStatusId = item.position_status_id,
                                 PositionStatus = item.position_status,
                                 BranchId = item.branch_id,
                                 StatusBy = item.status_by,
                                 StatusNote = item.status_note,
                                 Reference = item.reference,
                                 EmployeeId = item.employee_id,
                                 Createddate = item.createddate,
                                 Createdby = item.createdby,
                                 Modifieddate = item.modifieddate,
                                 Modifiedby = item.modifiedby
                             });

                return query.FirstOrDefault();
            }
            else return null;
        }

        public List<ShipmentStatusModel> GetTrackingView(int shipmentId)
        {
            var sql = @"SELECT 
	                        ss.id Id,
	                        ss.rowstatus Rowstatus,
	                        ss.rowversion Rowversion,
	                        ss.dateprocess DateProcess,
	                        ss.shipment_id ShipmentId,
	                        ss.tracking_status_id TrackingStatusId,
                            ts.code TrackingStatus,
	                        ss.miss_delivery_reason MissDeliveryReason,
	                        ss.position_status_id PositionStatusId,
	                        ss.position_status PositionStatus,
	                        ss.branch_id BranchId,
	                        ss.status_by StatusBy,
	                        ss.status_note StatusNote,
	                        ss.reference Reference,
	                        ss.employee_id EmployeeId,
	                        ss.createddate Createddate,
	                        ss.createdby Createdby,
	                        ss.modifiedby Modifiedby,
	                        ss.modifieddate Modifieddate
                        FROM siscodb.shipment_status ss
                        INNER JOIN siscodb.tracking_status ts ON ss.tracking_status_id = ts.id
                        WHERE ss.rowstatus = 1 AND ss.shipment_id = {0}";

            sql = string.Format(sql, shipmentId);
            return Entities.ExecuteStoreQuery<ShipmentStatusModel>(sql).ToList();
        }
    }
}