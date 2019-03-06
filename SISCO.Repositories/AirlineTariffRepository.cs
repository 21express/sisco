

/* 
*  SOLUTION 	: WaterManagementSolution
*  PROJECT		: Pdam.Common
*  TYPE 		: Generated - Data Access Repository
*  CREATED BY	: K
*  CREATED DATE	: Wednesday, May 21, 2014
*/

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
    public class AirlineTariffRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "AirlineTariff";
        public AirlineTariffRepository()
        {
            ObjectName = OBJECT_NAME;
        }
        
        public AirlineTariffRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as AirlineTariffModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddToairline_tariff(entity);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as AirlineTariffModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.airline_tariff where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as AirlineTariffModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.airline_tariff select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.airline_tariff where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.airline_tariff where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}
        
        private static airline_tariff PopulateModelToNewEntity(AirlineTariffModel model)
		{
			return new airline_tariff
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				customer_id = model.CustomerId,
				airline_id = model.AirlineId,
				airline_orig_id = model.AirlineOrigId,
				airline_dest_id = model.AirlineDestId,
				service_type_id = model.ServiceTypeId,
				package_type_id = model.PackageTypeId,
				tariff = model.Tariff,
				handling_fee = model.HandlingFee,
				discount_percent = model.DiscountPercent,
				discount_fixed = model.DiscountFixed,
				min_weight = model.MinWeight,
				other_fee = model.OtherFee,
				other_percent = model.OtherPercent,
				other_kg = model.OtherKg,
				currency_id = model.CurrencyId,
				pricing_plan_id = model.PricingPlanId,
				from_weight = model.FromWeight,
				to_weight = model.ToWeight,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}
        
        private static void PopulateModelToNewEntity(airline_tariff query, AirlineTariffModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
			query.customer_id = model.CustomerId;
			query.airline_id = model.AirlineId;
			query.airline_orig_id = model.AirlineOrigId;
			query.airline_dest_id = model.AirlineDestId;
			query.service_type_id = model.ServiceTypeId;
			query.package_type_id = model.PackageTypeId;
			query.tariff = model.Tariff;
			query.handling_fee = model.HandlingFee;
			query.discount_percent = model.DiscountPercent;
			query.discount_fixed = model.DiscountFixed;
			query.min_weight = model.MinWeight;
			query.other_fee = model.OtherFee;
			query.other_percent = model.OtherPercent;
			query.other_kg = model.OtherKg;
			query.currency_id = model.CurrencyId;
			query.pricing_plan_id = model.PricingPlanId;
			query.from_weight = model.FromWeight;
			query.to_weight = model.ToWeight;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}
        
        private static AirlineTariffModel PopulateEntityToNewModel(airline_tariff item)
		{
			return new AirlineTariffModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				CustomerId = item.customer_id,
				AirlineId = item.airline_id,
				AirlineOrigId = item.airline_orig_id,
				AirlineDestId = item.airline_dest_id,
				ServiceTypeId = item.service_type_id,
				PackageTypeId = item.package_type_id,
				Tariff = item.tariff,
				HandlingFee = item.handling_fee,
				DiscountPercent = item.discount_percent,
				DiscountFixed = item.discount_fixed,
				MinWeight = item.min_weight,
				OtherFee = item.other_fee,
				OtherPercent = item.other_percent,
				OtherKg = item.other_kg,
				CurrencyId = item.currency_id,
				PricingPlanId = item.pricing_plan_id,
				FromWeight = item.from_weight,
				ToWeight = item.to_weight,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby,
                
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.airline_tariff select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.airline_tariff select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.airline_tariff select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			var tquery = (from a in Entities.airline_tariff select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public void Save<T>(int airlineId, IList<T> models)
        {
            Entities.ExecuteStoreCommand("DELETE FROM airline_tariff WHERE airline_id = {0}", airlineId);

            for (var i = 0; i < models.Count(); i++)
            {
                var model = models[i] as AirlineTariffModel;
                if (model == null)
                    throw new ModelNullException();

                var entity = PopulateModelToNewEntity(model);
                Entities.AddToairline_tariff(entity);
            }

            Entities.SaveChanges();
        }

        public void Save<T>(AirlineModel parent, IList<T> models)
        {
            using (var scope = new TransactionScope())
            {
                Entities.ExecuteStoreCommand("DELETE FROM airline_tariff WHERE airline_id = {0}", parent.Id);

                for (var i = 0; i < models.Count(); i++)
                {
                    var model = models[i] as AirlineTariffModel;
                    if (model == null)
                        throw new ModelNullException();

                    model.AirlineId = parent.Id;

                    var entity = PopulateModelToNewEntity(model);
                    Entities.AddToairline_tariff(entity);
                }

                Entities.SaveChanges();

                scope.Complete();
            }
        }
    }
}


