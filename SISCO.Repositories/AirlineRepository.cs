using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using SISCO.Models;
using SISCO.Repositories.Context;
using SISCO.Repositories.Interfaces;

namespace SISCO.Repositories
{
    public class AirlineRepository : SISCOBaseRepository, IExtendedQueryableRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "Airline";
        public AirlineRepository()
        {
            ObjectName = OBJECT_NAME;
        }
        
        public AirlineRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as AirlineModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddToairlines(entity);
			Entities.SaveChanges();

            businessModel.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as AirlineModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.airlines where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as AirlineModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.airlines select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.airlines where d.id == id select d).FirstOrDefault();
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
        
        private static airline PopulateModelToNewEntity(AirlineModel model)
		{
			return new airline
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				code = model.Code,
				name = model.Name,
				admin_fee = model.AdminFee,
				admin_fee_via = model.AdminFeeVia,
				void_fee = model.VoidFee,
				refund_fee = model.RefundFee,
				sc_fee = model.ScFee,
				sc_fee_min = model.ScFeeMin,
				sc_fee_min_weight = model.ScFeeMinWeight,
				so_fee = model.SoFee,
				fe_fee = model.FeFee,
				handling_fee = model.HandlingFee,
				min_weight = model.MinWeight,
				admin_include_tax = model.AdminIncludeTax,
				show_as_agreed = model.ShowAsAgreed,
				admin_fee_customer = model.AdminFeeCustomer,
				void_fee_customer = model.VoidFeeCustomer,
				refund_fee_customer = model.RefundFeeCustomer,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}
        
        private static void PopulateModelToNewEntity(airline query, AirlineModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
			query.code = model.Code;
			query.name = model.Name;
			query.admin_fee = model.AdminFee;
			query.admin_fee_via = model.AdminFeeVia;
			query.void_fee = model.VoidFee;
			query.refund_fee = model.RefundFee;
			query.sc_fee = model.ScFee;
			query.sc_fee_min = model.ScFeeMin;
			query.sc_fee_min_weight = model.ScFeeMinWeight;
			query.so_fee = model.SoFee;
			query.fe_fee = model.FeFee;
			query.handling_fee = model.HandlingFee;
			query.min_weight = model.MinWeight;
			query.admin_include_tax = model.AdminIncludeTax;
			query.show_as_agreed = model.ShowAsAgreed;
			query.admin_fee_customer = model.AdminFeeCustomer;
			query.void_fee_customer = model.VoidFeeCustomer;
			query.refund_fee_customer = model.RefundFeeCustomer;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}
        
        private static AirlineModel PopulateEntityToNewModel(airline item)
		{
			return new AirlineModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				Code = item.code,
				Name = item.name,
				AdminFee = item.admin_fee,
				AdminFeeVia = item.admin_fee_via,
				VoidFee = item.void_fee,
				RefundFee = item.refund_fee,
				ScFee = item.sc_fee,
				ScFeeMin = item.sc_fee_min,
				ScFeeMinWeight = item.sc_fee_min_weight,
				SoFee = item.so_fee,
				FeFee = item.fe_fee,
				HandlingFee = item.handling_fee,
				MinWeight = item.min_weight,
				AdminIncludeTax = item.admin_include_tax,
				ShowAsAgreed = item.show_as_agreed,
				AdminFeeCustomer = item.admin_fee_customer,
				VoidFeeCustomer = item.void_fee_customer,
				RefundFeeCustomer = item.refund_fee_customer,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby,
                
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.airlines select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.airlines select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.airlines select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			var tquery = (from a in Entities.airlines select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in Entities.airlines select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.airlines select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }
    }
}