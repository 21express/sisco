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
    public class CityRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "City";
        public CityRepository()
        {
            ObjectName = OBJECT_NAME;
        }
        
        public CityRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as CityModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTocities(entity);
			Entities.SaveChanges();

            businessModel.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as CityModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.cities where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as CityModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.cities select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.cities where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.cities where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}
        
        private static city PopulateModelToNewEntity(CityModel model)
		{
			return new city
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowverstion = model.Rowversion,
				name = model.Name,
				country_id = model.CountryId,
				branch_id = model.BranchId,
				lead_time = model.LeadTime,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
                zipcode = model.ZipCode,
                cod = model.Cod,
                is_out_area = model.IsOutArea
			};
		}
        
        private static void PopulateModelToNewEntity(city query, CityModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowverstion = model.Rowversion;
			query.name = model.Name;
			query.country_id = model.CountryId;
			query.branch_id = model.BranchId;
			query.lead_time = model.LeadTime;
            query.district_id = model.DistrictId;
            query.description1 = model.Description1;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
            query.zipcode = model.ZipCode;
            query.cod = model.Cod;
            query.is_out_area = model.IsOutArea;
		}
        
        private static CityModel PopulateEntityToNewModel(city item)
		{
			return new CityModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowverstion = item.rowverstion,
				Name = item.name,
				CountryId = item.country_id,
				BranchId = item.branch_id,
				LeadTime = item.lead_time,
                DistrictId = item.district_id,
                Description1 = item.description1,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby,
                ZipCode = item.zipcode,
                Cod = item.cod,
                IsOutArea = item.is_out_area
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.cities select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.cities select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.cities select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			var tquery = (from a in Entities.cities select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in Entities.cities select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.cities select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public List<CityModel> GetCityByCountryId(int countryId)
        {
            var cities = (from item in Entities.cities
                          where item.country_id == countryId
                          select new CityModel {
                              Id = item.id,
                              Rowstatus = item.rowstatus,
                              Rowverstion = item.rowverstion,
                              Name = item.name,
                              CountryId = item.country_id,
                              BranchId = item.branch_id,
                              LeadTime = item.lead_time,
                              DistrictId = item.district_id,
                              Description1 = item.name,
                              Createddate = item.createddate,
                              Createdby = item.createdby,
                              Modifieddate = item.modifieddate,
                              Modifiedby = item.modifiedby,
                              ZipCode = item.zipcode,
                              Cod = item.cod,
                              IsOutArea = item.is_out_area
                          });

            return cities.ToList();
        }
    }
}