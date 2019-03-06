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
    public class FleetRepository : SISCOBaseRepository
    {
        private const string OBJECT_NAME = "Fleet";
        public FleetRepository()
        {
            ObjectName = OBJECT_NAME;
        }
        
        public FleetRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as FleetModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTofleets(entity);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as FleetModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.fleets where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as FleetModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.fleets select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.fleets where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.fleets where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}
        
        private static fleet PopulateModelToNewEntity(FleetModel model)
		{
			return new fleet
			{
				id = model.Id,
				branch_id = model.BranchId,
				vehicle_type_id = model.VehicleTypeId,
				plate_number = model.PlateNumber,
				brand = model.Brand,
				model = model.Model,
				year = model.Year,
				next_expiration_date = model.NextExpirationDate,
				note = model.Note,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}
        
        private static void PopulateModelToNewEntity(fleet query, FleetModel model)
		{
			query.id = model.Id;
			query.branch_id = model.BranchId;
			query.vehicle_type_id = model.VehicleTypeId;
			query.plate_number = model.PlateNumber;
			query.brand = model.Brand;
			query.model = model.Model;
			query.year = model.Year;
			query.next_expiration_date = model.NextExpirationDate;
			query.note = model.Note;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}
        
        private static FleetModel PopulateEntityToNewModel(fleet item)
		{
			return new FleetModel
			{
				Id = item.id,
				BranchId = item.branch_id,
				VehicleTypeId = item.vehicle_type_id,
				PlateNumber = item.plate_number,
				Brand = item.brand,
				Model = item.model,
				Year = item.year,
				NextExpirationDate = item.next_expiration_date,
				Note = item.note,
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
			var query = (from a in Entities.fleets select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);

            var obj = (from item in query
                join v in Entities.vehicle_type on item.vehicle_type_id equals v.id
                select new FleetModel
                {
                    Id = item.id,
                    BranchId = item.branch_id,
                    VehicleTypeId = item.vehicle_type_id,
                    VehicleType = v.name,
                    PlateNumber = item.plate_number,
                    Brand = item.brand,
                    Model = item.model,
                    Year = item.year,
                    NextExpirationDate = item.next_expiration_date,
                    Note = item.note,
                    Rowstatus = item.rowstatus,
                    Rowversion = item.rowversion,
                    Createddate = item.createddate,
                    Createdby = item.createdby,
                    Modifieddate = item.modifieddate,
                    Modifiedby = item.modifiedby
                }).ToList();
			return (IEnumerable<T>) obj;
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.fleets select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.fleets select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			var tquery = (from a in Entities.fleets select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).Cast<FleetModel>().ToList();
		}        
       
    }
}


