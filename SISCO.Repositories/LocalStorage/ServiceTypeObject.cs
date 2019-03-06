using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using SISCO.Models;
using SISCO.Models.TransferObject;
using SISCO.Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;

namespace SISCO.Repositories.LocalStorage
{
    public class ServiceTypeObject : SISCOBaseRepository
    {
        private const string OBJECT_NAME = "ServiceType";
        public ServiceTypeObject()
        {
            ObjectName = OBJECT_NAME;
        }

        public ServiceTypeObject(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
            var model = businessModel as ServiceTypeData;
			if (model == null)
				throw new ModelNullException();

            ServiceTypeDataObject.ServiceTypesObject.Add(model);
		}

        public void Save(List<ServiceTypeData> services)
        {
            ServiceTypeDataObject.ServiceTypesObject = services;
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
        
        private static city PopulateModelToNewEntity(CityModel model)
		{
            throw new NotImplementedException();
		}
        
        private static void PopulateModelToNewEntity(city query, CityModel model)
		{
            throw new NotImplementedException();
		}

        private static ServiceTypeModel PopulateEntityToNewModel(ServiceTypeData item)
		{
            return new ServiceTypeModel
			{
				Id = item.Id,
				Name = item.Name
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in ServiceTypeDataObject.ServiceTypesObject select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in ServiceTypeDataObject.ServiceTypesObject select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in ServiceTypeDataObject.ServiceTypesObject select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var tquery = (from a in ServiceTypeDataObject.ServiceTypesObject select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in ServiceTypeDataObject.ServiceTypesObject select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in ServiceTypeDataObject.ServiceTypesObject select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }
    }
    
    public class ServiceTypeDataObject
    {
        public ServiceTypeDataObject()
        {
            if (ServiceTypeDataObject.ServiceTypesObject == null) ServiceTypesObject = new List<ServiceTypeData>();
        }

        public static List<ServiceTypeData> ServiceTypesObject { get; set; }
    }
}
