using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using SISCO.Models;
using SISCO.Repositories.Context;
using SISCO.Models.TransferObject;

namespace SISCO.Repositories.LocalStorage
{
    public class PaymentMethodObject : SISCOBaseRepository
    {
        private const string OBJECT_NAME = "PaymentMethod";
        public PaymentMethodObject()
        {
            ObjectName = OBJECT_NAME;
        }

        public PaymentMethodObject(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as PaymentMethodData;
			if (model == null)
				throw new ModelNullException();

            PaymentMethodDataObject.PaymentMethodsObject.Add(model);
		}

        public void Save(List<PaymentMethodData> payments)
        {
            PaymentMethodDataObject.PaymentMethodsObject = payments;
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
        
        private static payment_method PopulateModelToNewEntity(PaymentMethodModel model)
		{
            throw new NotImplementedException();
		}
        
        private static void PopulateModelToNewEntity(payment_method query, PaymentMethodModel model)
		{
            throw new NotImplementedException();
		}
        
        private static PaymentMethodModel PopulateEntityToNewModel(PaymentMethodData item)
		{
			return new PaymentMethodModel
			{
				Id = item.Id,
				Rowstatus = item.Rowstatus,
				Name = item.Name
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in PaymentMethodDataObject.PaymentMethodsObject select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in PaymentMethodDataObject.PaymentMethodsObject select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in PaymentMethodDataObject.PaymentMethodsObject select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var tquery = (from a in PaymentMethodDataObject.PaymentMethodsObject select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).Cast<PaymentMethodModel>().ToList();
		}

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in PaymentMethodDataObject.PaymentMethodsObject select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in PaymentMethodDataObject.PaymentMethodsObject select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }
    }

    public class PaymentMethodDataObject
    {
        public PaymentMethodDataObject()
        {
            if (PaymentMethodDataObject.PaymentMethodsObject == null) PaymentMethodsObject = new List<PaymentMethodData>();
        }

        public static List<PaymentMethodData> PaymentMethodsObject { get; set; }
    }
}


