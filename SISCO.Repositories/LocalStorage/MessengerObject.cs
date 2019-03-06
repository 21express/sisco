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
    public class MessengerObject : SISCOBaseRepository
    {
        private const string OBJECT_NAME = "Messenger";
        public MessengerObject()
        {
            ObjectName = OBJECT_NAME;
        }

        public MessengerObject(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
            var model = businessModel as MessengerData;
			if (model == null)
				throw new ModelNullException();

            MessengerDataObject.MessengersObject.Add(model);
		}

        public void Save(List<MessengerData> messengers)
        {
            ResetAll();
            MessengerDataObject.MessengersObject = messengers;
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

        public void ResetAll()
        {
            MessengerDataObject.MessengersObject = new List<MessengerData>();
        }
        
        private static city PopulateModelToNewEntity(CityModel model)
		{
            throw new NotImplementedException();
		}
        
        private static void PopulateModelToNewEntity(city query, CityModel model)
		{
            throw new NotImplementedException();
		}

        private static EmployeeModel PopulateEntityToNewModel(MessengerData item)
		{
            return new EmployeeModel
			{
				Id = item.Id,
                Code = item.Code,
				Name = item.Name,
                AsMessenger = item.AsMessenger,
                BranchId = item.BranchId
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in MessengerDataObject.MessengersObject select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in MessengerDataObject.MessengersObject select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in MessengerDataObject.MessengersObject select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var tquery = (from a in MessengerDataObject.MessengersObject select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            expression = expression.Replace("rowstatus", "Rowstatus");
            var query = (from a in MessengerDataObject.MessengersObject select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in MessengerDataObject.MessengersObject select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }
    }
    
    public class MessengerDataObject
    {
        public MessengerDataObject()
        {
            if (MessengerDataObject.MessengersObject == null) MessengersObject = new List<MessengerData>();
        }

        public static List<MessengerData> MessengersObject { get; set; }
    }
}
