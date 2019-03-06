using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using SISCO.Models;
using SISCO.Models.TransferObject;
using SISCO.Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Dynamic;
using Devenlab.Common;

namespace SISCO.Repositories.LocalStorage
{
    public class CountryObject : SISCOBaseRepository
    {
        private const string OBJECT_NAME = "Country";
        public CountryObject()
        {
            ObjectName = OBJECT_NAME;
        }

        public CountryObject(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as CountryData;
			if (model == null)
				throw new ModelNullException();

            CountryDataObject.CountriesObject.Add(model);
		}

        public void Save(List<CountryData> cities)
        {
            CountryDataObject.CountriesObject = cities;
        }
        
        public override void Update<T>(T businessModel)
		{
            throw new NotImplementedException();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            throw new NotImplementedException();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            throw new NotImplementedException();
        }
        
        public override void Delete(int id)
		{
            throw new NotImplementedException();
		}
        
        private static city PopulateModelToNewEntity(CountryModel model)
		{
            throw new NotImplementedException();
		}

        private static void PopulateModelToNewEntity(city query, CountryModel model)
		{
            throw new NotImplementedException();
		}

        private static CountryModel PopulateEntityToNewModel(CountryData item)
		{
            return new CountryModel
			{
				Id = item.Id,
				Name = item.Name,
                PricingPlanId = item.PricingPlanId
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in CountryDataObject.CountriesObject select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in CountryDataObject.CountriesObject select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in CountryDataObject.CountriesObject select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var tquery = (from a in CountryDataObject.CountriesObject select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in CountryDataObject.CountriesObject select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in CountryDataObject.CountriesObject select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }
    }

    public class CountryDataObject
    {
        public CountryDataObject()
        {
            if (CountryDataObject.CountriesObject == null) CountriesObject = new List<CountryData>();
        }

        public static List<CountryData> CountriesObject { get; set; }
    }
}
