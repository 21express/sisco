using Devenlab.Common.Fault;
using SISCO.Models;
using SISCO.Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Dynamic;
using Devenlab.Common;

namespace SISCO.Repositories
{
    public class BookingPodRepository : SISCOBaseRepository
    {
        private const string OBJECT_NAME = "Booking POD";

        public BookingPodRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public BookingPodRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }

        public override void Save<T>(T businessModel)
        {
            var model = businessModel as BookingPodModel;
            if (model == null)
                throw new ModelNullException();
            var entity = PopulateModelToNewEntity(model);
            Entities.AddTobooking_pod(entity);
            Entities.SaveChanges();

            model.Id = entity.id;
        }

        public override void Update<T>(T businessModel)
        {
            var model = businessModel as BookingPodModel;
            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.booking_pod where d.id == model.Id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void Update<T>(T businessModel, params Devenlab.Common.Interfaces.IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as BookingPodModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.booking_pod select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.booking_pod where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
            Entities.SaveChanges();
        }

        public override void Delete(int id)
        {
            var query = (from d in Entities.booking_pod where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            Entities.DeleteObject(query);
            Entities.SaveChanges();
        }

        private static booking_pod PopulateModelToNewEntity(BookingPodModel model)
        {
            return new booking_pod
            {
                id = model.Id,
                rowstatus = model.Rowstatus,
                rowversion = model.Rowversion,
                code = model.Code,
                sprinter_id = model.SprintId,
                branch_id = model.BranchId,
                booking_count = model.BookingCount,
                booking_start = model.BookingStart,
                booking_end = model.BookingEnd,
                history_ttl_booking = model.HistoryTtlBooking,
                history_ttl_pod = model.HistoryTtlPod,
                print = model.Print,
                createddate = model.Createddate,
                createdby = model.Createdby,
                modifieddate = model.Modifieddate,
                modifiedby = model.Modifiedby,
            };
        }

        private static void PopulateModelToNewEntity(booking_pod query, BookingPodModel model)
        {
            query.id = model.Id;
            query.rowstatus = model.Rowstatus;
            query.rowversion = model.Rowversion;
            query.code = model.Code;
            query.sprinter_id = model.SprintId;
            query.branch_id = model.BranchId;
            query.booking_count = model.BookingCount;
            query.booking_start = model.BookingStart;
            query.booking_end = model.BookingEnd;
            query.history_ttl_booking = model.HistoryTtlBooking;
            query.history_ttl_pod = model.HistoryTtlPod;
            query.print = model.Print;
            query.createddate = model.Createddate;
            query.createdby = model.Createdby;
            query.modifieddate = model.Modifieddate;
            query.modifiedby = model.Modifiedby;
        }

        private static BookingPodModel PopulateEntityToNewModel(booking_pod item)
        {
            return new BookingPodModel
            {
                Id = item.id,
                Rowstatus = item.rowstatus,
                Rowversion = item.rowversion,
                Code = item.code,
                SprintId = item.sprinter_id,
                BranchId = item.branch_id,
                BookingCount = item.booking_count,
                BookingStart = item.booking_start,
                BookingEnd = item.booking_end,
                HistoryTtlBooking = item.history_ttl_booking,
                HistoryTtlPod = item.history_ttl_pod,
                Print = item.print,
                Createddate = item.createddate,
                Createdby = item.createdby,
                Modifieddate = item.modifieddate,
                Modifiedby = item.modifiedby
            };
        }

        public override IEnumerable<T> Get<T>(params Devenlab.Common.Interfaces.IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.booking_pod select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public override T GetSingle<T>(params Devenlab.Common.Interfaces.IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.booking_pod select a).Where(whereterm, ListValue.ToArray()).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
            return result.FirstOrDefault();
        }

        public override IEnumerable<T> Get<T>(Devenlab.Common.Paging paging, out int totalCount, params Devenlab.Common.Interfaces.IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.booking_pod select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.booking_pod select a).Where(whereterm, ListValue.ToArray());
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in Entities.booking_pod select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.booking_pod select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }
    }
}