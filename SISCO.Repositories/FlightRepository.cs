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
    public class FlightRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "Flight";
        public FlightRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public FlightRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }

        public override void Save<T>(T businessModel)
        {
            var model = businessModel as FlightModel;
            if (model == null)
                throw new ModelNullException();
            var entity = PopulateModelToNewEntity(model);
            Entities.AddToflights(entity);
            Entities.SaveChanges();
        }

        public override void Update<T>(T businessModel)
        {
            var model = businessModel as FlightModel;
            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.flights where d.id == model.Id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as FlightModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.flights select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.flights where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
            Entities.SaveChanges();
        }

        public override void Delete(int id)
        {
            var query = (from d in Entities.airlines where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            Entities.DeleteObject(query);
            Entities.SaveChanges();
        }

        private static flight PopulateModelToNewEntity(FlightModel model)
        {
            return new flight
            {
                id = model.Id,
                rowstatus = model.Rowstatus,
                rowversion = model.Rowversion,
                airline_id = model.AirlineId,
                flight_number = model.FlightNumber,
                origin_airport_id = model.OriginAirportId,
                destination_airport_id = model.DestAirportId,
                estimated_departure_time = model.EstDepartureTime,
                estimated_arrival_time = model.EstArrivalTime,
                weekday = model.WeekDay,
                createddate = model.Createddate,
                createdby = model.Createdby,
                modifieddate = model.Modifieddate,
                modifiedby = model.Modifiedby,
            };
        }

        private static void PopulateModelToNewEntity(flight query, FlightModel model)
        {
            query.id = model.Id;
            query.rowstatus = model.Rowstatus;
            query.rowversion = model.Rowversion;
            query.airline_id = model.AirlineId;
            query.flight_number = model.FlightNumber;
            query.origin_airport_id = model.OriginAirportId;
            query.destination_airport_id = model.DestAirportId;
            query.estimated_departure_time = model.EstDepartureTime;
            query.estimated_arrival_time = model.EstArrivalTime;
            query.weekday = model.WeekDay;
            query.createddate = model.Createddate;
            query.createdby = model.Createdby;
            query.modifieddate = model.Modifieddate;
            query.modifiedby = model.Modifiedby;
        }

        private static FlightModel PopulateEntityToNewModel(flight item)
        {
            return new FlightModel
            {
                Id = item.id,
                Rowstatus = item.rowstatus,
                Rowversion = item.rowversion,
                AirlineId = item.airline_id,
                FlightNumber = item.flight_number,
                OriginAirportId = item.origin_airport_id,
                DestAirportId = item.destination_airport_id,
                EstDepartureTime = item.estimated_departure_time,
                EstArrivalTime = item.estimated_arrival_time,
                WeekDay = item.weekday,
                Createddate = item.createddate,
                Createdby = item.createdby,
                Modifieddate = item.modifieddate,
                Modifiedby = item.modifiedby,

            };
        }

        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.flights select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public override T GetSingle<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.flights select a).Where(whereterm, ListValue.ToArray()).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
            return result.FirstOrDefault();
        }

        public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.flights select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.flights select a).Where(whereterm, ListValue.ToArray());
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public void Save<T>(AirlineModel parent, IList<T> models)
        {
            using (var scope = new TransactionScope())
            {
                Entities.ExecuteStoreCommand("DELETE FROM flight WHERE airline_id = {0}", parent.Id);

                for (var i = 0; i < models.Count(); i++)
                {
                    var model = models[i] as FlightModel;
                    if (model == null)
                        throw new ModelNullException();

                    model.AirlineId = parent.Id;

                    var entity = PopulateModelToNewEntity(model);
                    Entities.AddToflights(entity);
                }

                Entities.SaveChanges();

                scope.Complete();
            }
        }
    }
}