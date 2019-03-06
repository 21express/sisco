using SISCO.Models;
using SISCO.Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Dynamic;
using Devenlab.Common.Fault;
using Devenlab.Common;
using MySql.Data.MySqlClient;

namespace SISCO.Repositories
{
    public class BookingPodDetailRepository : SISCOBaseRepository
    {
        private const string OBJECT_NAME = "Booking POD Detail";

        public BookingPodDetailRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public BookingPodDetailRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }

        public override void Save<T>(T businessModel)
        {
            var model = businessModel as BookingPodDetailModel;
            if (model == null)
                throw new ModelNullException();
            var entity = PopulateModelToNewEntity(model);
            Entities.AddTobooking_pod_detail(entity);
            Entities.SaveChanges();

            model.Id = entity.id;
        }

        public override void Update<T>(T businessModel)
        {
            var model = businessModel as BookingPodDetailModel;
            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.booking_pod_detail where d.id == model.Id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void Update<T>(T businessModel, params Devenlab.Common.Interfaces.IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as BookingPodDetailModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.booking_pod_detail select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.booking_pod_detail where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
            Entities.SaveChanges();
        }

        public override void Delete(int id)
        {
            var query = (from d in Entities.booking_pod_detail where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            Entities.DeleteObject(query);
            Entities.SaveChanges();
        }

        private static booking_pod_detail PopulateModelToNewEntity(BookingPodDetailModel model)
        {
            return new booking_pod_detail
            {
                id = model.Id,
                rowstatus = model.Rowstatus,
                rowversion = model.Rowversion,
                booking_pod_id = model.BookingPodId,
                booking_no = model.BookingNo,
                shipment_code = model.ShipmentCode,
                is_pod_exists = model.IsPodExists,
                reason_lost = model.ReasonLost,
                createddate = model.Createddate,
                createdby = model.Createdby,
                modifieddate = model.Modifieddate,
                modifiedby = model.Modifiedby,
            };
        }

        private static void PopulateModelToNewEntity(booking_pod_detail query, BookingPodDetailModel model)
        {
            query.id = model.Id;
            query.rowstatus = model.Rowstatus;
            query.rowversion = model.Rowversion;
            query.booking_pod_id = model.BookingPodId;
            query.booking_no = model.BookingNo;
            query.shipment_code = model.ShipmentCode;
            query.is_pod_exists = model.IsPodExists;
            query.reason_lost = model.ReasonLost;
            query.createddate = model.Createddate;
            query.createdby = model.Createdby;
            query.modifieddate = model.Modifieddate;
            query.modifiedby = model.Modifiedby;
        }

        private static BookingPodDetailModel PopulateEntityToNewModel(booking_pod_detail item)
        {
            return new BookingPodDetailModel
            {
                Id = item.id,
                Rowstatus = item.rowstatus,
                Rowversion = item.rowversion,
                BookingPodId = item.booking_pod_id,
                BookingNo = item.booking_no,
                ShipmentCode = item.shipment_code,
                IsPodExists = item.is_pod_exists,
                ReasonLost = item.reason_lost,
                Createddate = item.createddate,
                Createdby = item.createdby,
                Modifieddate = item.modifieddate,
                Modifiedby = item.modifiedby
            };
        }

        public override IEnumerable<T> Get<T>(params Devenlab.Common.Interfaces.IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.booking_pod_detail select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public override T GetSingle<T>(params Devenlab.Common.Interfaces.IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.booking_pod_detail select a).Where(whereterm, ListValue.ToArray()).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
            return result.FirstOrDefault();
        }

        public override IEnumerable<T> Get<T>(Devenlab.Common.Paging paging, out int totalCount, params Devenlab.Common.Interfaces.IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.booking_pod_detail select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.booking_pod_detail select a).Where(whereterm, ListValue.ToArray());
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in Entities.booking_pod_detail select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.booking_pod_detail select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public List<BookingPodDetailModel> BookingAudit(List<string> bookingNumbers)
        {
            var sql = @"SELECT
	                        s.code ShipmentCode,
	                        se.fulfilment BookingNo,
                            'true' IsPodExists,
                            '' ReasonLost,
                            'Insert' StateChange2
                        FROM shipment s
                        INNER JOIN shipment_expand se ON s.id = se.shipment_id
                        WHERE {0}";

            var whereList = new List<string>();
            whereList.Add("s.rowstatus = 1");
            whereList.Add(string.Format("se.fulfilment IN ('{0}')", string.Join("', '", bookingNumbers)));

            sql = string.Format(sql, string.Join(" AND ", whereList));
            return Entities.ExecuteStoreQuery<BookingPodDetailModel>(sql).ToList();
        }
    }
}