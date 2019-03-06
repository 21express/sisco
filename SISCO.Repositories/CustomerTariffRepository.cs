

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
    public class CustomerTariffRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "CustomerTariff";
        public CustomerTariffRepository()
        {
            ObjectName = OBJECT_NAME;
        }
        
        public CustomerTariffRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as CustomerTariffModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTocustomer_tariff(entity);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as CustomerTariffModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.customer_tariff where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as CustomerTariffModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.customer_tariff select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.customer_tariff where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.customer_tariff where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}
        
        private static customer_tariff PopulateModelToNewEntity(CustomerTariffModel model)
		{
			return new customer_tariff
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				customer_id = model.CustomerId,
				airline_id = model.AirlineId,
                city_orig_id = model.CityOrigId,
                city_dest_id = model.CityDestId,
				service_type_id = model.ServiceTypeId,
				package_type_id = model.PackageTypeId,
				tariff = model.Tariff,
				handling_fee = model.HandlingFee,
				discount_percent = model.DiscountPercent,
				discount_fixed = model.DiscountFixed,
				min_weight = model.MinWeight,
				ra = model.Ra,
				other_percent = model.OtherPercent,
				other_kg = model.OtherKg,
				currency_id = model.CurrencyId,
				pricing_plan_id = model.PricingPlanId,
				from_weight = model.FromWeight,
				to_weight = model.ToWeight,
                ltime = model.Ltime,
                next_tariff = model.NextTariff,
                fixed_tariff = model.FixedTariff,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}
        
        private static void PopulateModelToNewEntity(customer_tariff query, CustomerTariffModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
			query.customer_id = model.CustomerId;
			query.airline_id = model.AirlineId;
            query.city_orig_id = model.CityOrigId;
            query.city_dest_id = model.CityDestId;
			query.service_type_id = model.ServiceTypeId;
			query.package_type_id = model.PackageTypeId;
			query.tariff = model.Tariff;
			query.handling_fee = model.HandlingFee;
			query.discount_percent = model.DiscountPercent;
			query.discount_fixed = model.DiscountFixed;
			query.min_weight = model.MinWeight;
			query.ra = model.Ra;
			query.other_percent = model.OtherPercent;
			query.other_kg = model.OtherKg;
			query.currency_id = model.CurrencyId;
			query.pricing_plan_id = model.PricingPlanId;
			query.from_weight = model.FromWeight;
			query.to_weight = model.ToWeight;
            query.ltime = model.Ltime;
            query.next_tariff = model.NextTariff;
            query.fixed_tariff = model.FixedTariff;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}
        
        private static CustomerTariffModel PopulateEntityToNewModel(customer_tariff item)
		{
			return new CustomerTariffModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				CustomerId = item.customer_id,
				AirlineId = item.airline_id,
                CityOrigId = item.city_orig_id,
                CityDestId = item.city_dest_id,
				ServiceTypeId = item.service_type_id,
				PackageTypeId = item.package_type_id,
				Tariff = item.tariff,
				HandlingFee = item.handling_fee,
				DiscountPercent = item.discount_percent,
				DiscountFixed = item.discount_fixed,
				MinWeight = item.min_weight,
				Ra = item.ra,
				OtherPercent = item.other_percent,
				OtherKg = item.other_kg,
				CurrencyId = item.currency_id,
				PricingPlanId = item.pricing_plan_id,
				FromWeight = item.from_weight,
				ToWeight = item.to_weight,
                Ltime = item.ltime,
                NextTariff = item.next_tariff,
                FixedTariff = item.fixed_tariff,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby,
                StateChange = EnumStateChange.Idle
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.customer_tariff select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.customer_tariff select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.customer_tariff select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			var tquery = (from a in Entities.customer_tariff select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public CustomerTariffModel GetTariff(int cityOrigId, int cityDestId, int serviceTypeId, int packageTypeId, int customerId, decimal weight)
        {
            var whereterm = GetQueryParameterLinq();
            var query = (from a in Entities.customer_tariff
                             where
                                 a.city_orig_id == cityOrigId &&
                                 a.city_dest_id == cityDestId &&
                                 a.service_type_id == null &&
                                 //a.package_type_id == packageTypeId &&
                                 a.customer_id == customerId &&
                                 (a.from_weight == null || a.from_weight == 0 || a.from_weight <= weight) &&
                                 (a.to_weight == null || a.to_weight == 0 || a.to_weight >= weight)
                             select a)
                .Where(whereterm, ListValue.ToArray())
                .ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);

            var tariffs = query.Select(PopulateEntityToNewModel).ToList();
            if (tariffs.Count == 0)
            {
                query = (from a in Entities.customer_tariff
                         where
                             a.city_orig_id == cityOrigId &&
                             a.city_dest_id == cityDestId &&
                             a.service_type_id == null &&
                             //a.package_type_id == packageTypeId &&
                             a.customer_id == customerId &&
                             a.min_weight >= weight
                         select a)
                .Where(whereterm, ListValue.ToArray())
                .ToList();
                if (query == null)
                    throw new Exception(MessageEntityNotFound);

                tariffs = query.Select(PopulateEntityToNewModel).ToList();

                if (tariffs.Count == 0)
                {
                    query = (from a in Entities.customer_tariff
                             where
                                 a.city_orig_id == cityOrigId &&
                                 a.city_dest_id == cityDestId &&
                                 a.service_type_id == null &&
                                 //a.package_type_id == packageTypeId &&
                                 a.customer_id == customerId &&
                                 weight >= a.to_weight && 
                                (a.next_tariff != null || a.next_tariff > 0)
                             select a)
                .Where(whereterm, ListValue.ToArray())
                .ToList();
                    if (query == null)
                        throw new Exception(MessageEntityNotFound);

                    tariffs = query.Select(PopulateEntityToNewModel).ToList();
                }

                if (tariffs.Count == 0)
                {
                    query = (from a in Entities.customer_tariff
                         where
                             a.city_orig_id == cityOrigId &&
                             a.city_dest_id == cityDestId &&
                             a.service_type_id == null &&
                             //a.package_type_id == packageTypeId &&
                             a.customer_id == customerId &&
                             (a.from_weight == null || a.from_weight == 0 || a.from_weight <= weight) &&
                             (a.to_weight == null || a.to_weight == 0 || a.to_weight >= weight)
                         select a)
                    .Where(whereterm, ListValue.ToArray())
                    .ToList();

                    if (query == null)
                        throw new Exception(MessageEntityNotFound);

                    tariffs = query.Select(PopulateEntityToNewModel).ToList();
                }

                if (tariffs.Count == 0)
                {
                    query = (from a in Entities.customer_tariff
                             where
                                 a.city_orig_id == cityOrigId &&
                                 a.city_dest_id == cityDestId &&
                                 a.service_type_id == serviceTypeId &&
                                 //a.package_type_id == packageTypeId &&
                                 a.customer_id == customerId &&
                                 (a.from_weight == null || a.from_weight == 0 || a.from_weight <= weight) &&
                                 (a.to_weight == null || a.to_weight == 0 || a.to_weight >= weight)
                             select a)
                .Where(whereterm, ListValue.ToArray())
                .ToList();
                    if (query == null)
                        throw new Exception(MessageEntityNotFound);

                    tariffs = query.Select(PopulateEntityToNewModel).ToList();
                }

                if (tariffs.Count == 0)
                {
                    query = (from a in Entities.customer_tariff
                             where
                                 a.city_orig_id == cityOrigId &&
                                 a.city_dest_id == cityDestId &&
                                 a.service_type_id == serviceTypeId &&
                                 //a.package_type_id == packageTypeId &&
                                 a.customer_id == customerId &&
                                 weight >= a.to_weight &&
                                (a.next_tariff != null || a.next_tariff > 0)
                             select a)
                .Where(whereterm, ListValue.ToArray())
                .ToList();
                    if (query == null)
                        throw new Exception(MessageEntityNotFound);

                    tariffs = query.Select(PopulateEntityToNewModel).ToList();
                }

                if (tariffs.Count == 0)
                {
                    query = (from a in Entities.customer_tariff
                             where
                                 a.city_orig_id == cityOrigId &&
                                 a.city_dest_id == cityDestId &&
                                 a.service_type_id == serviceTypeId &&
                                 //a.package_type_id == packageTypeId &&
                                 a.customer_id == customerId &&
                                 a.min_weight >= weight
                             select a)
                    .Where(whereterm, ListValue.ToArray())
                    .ToList();

                    if (query == null)
                        throw new Exception(MessageEntityNotFound);

                    tariffs = query.Select(PopulateEntityToNewModel).ToList();
                }
            }

            if (tariffs.Count > 1)
            {
                var single = tariffs.FirstOrDefault(p => p.ServiceTypeId == serviceTypeId);
                if (single != null) return single;
            }

            return tariffs.FirstOrDefault();
        }

        public void Save<T>(CustomerModel parent, IList<T> models)
        {
            //Entities.ExecuteStoreCommand("DELETE FROM customer_tariff WHERE customer_id = {0}", parent.Id);

            var sql = string.Empty;
            var row = 1;
            for (var i = 0; i < models.Count(); i++)
            {
                var model = models[i] as CustomerTariffModel;
                if (model == null)
                    throw new ModelNullException();
                model.CustomerId = parent.Id;

                //var entity = PopulateModelToNewEntity(model);
                //Entities.AddTocustomer_tariff(entity);

                if (model.StateChange == EnumStateChange.Insert)
                {
                    sql += string.Format(@"INSERT INTO customer_tariff (customer_id, city_orig_id, city_dest_id, service_type_id, tariff, handling_fee, ra, ltime, createddate, createdby, rowstatus, currency_id, rowversion, from_weight, to_weight, next_tariff, fixed_tariff)
                                SELECT {0}, {1}, {2}, {12}, {4}, {5}, {6}, '{7}', NOW(), '{8}', {9}, 1, NOW(), {13}, {14}, {15}, {18} FROM dual
                                WHERE NOT EXISTS(SELECT 1 FROM customer_tariff WHERE customer_id = {0} and city_orig_id = {1} and city_dest_id = {2} and {11} and rowstatus = {9} and {16} and {17});
                                
                                UPDATE customer_tariff SET tariff = {4}, handling_fee = {5}, ra = {6}, min_weight = {10}, ltime = '{7}', from_weight = {13}, to_weight = {14}, fixed_tariff = {18}, modifieddate = now(), modifiedby = '{8}' WHERE customer_id = {0} and city_orig_id = {1} and city_dest_id = {2} and {3} and rowstatus = {9} and {16} and {17};
                                UPDATE customer_tariff SET currency_id = 1  WHERE customer_id = {0} and city_orig_id = {1} and city_dest_id = {2} and {3} and rowstatus = {9} and currency_id is null;",
                                                                                                                                                                                                       model.CustomerId, model.CityOrigId, model.CityDestId, model.ServiceTypeId != null ? string.Format("service_type_id = {0}", model.ServiceTypeId) : "service_type_id = null", model.Tariff, model.HandlingFee, (bool)model.Ra ? 1 : 0, model.Ltime, model.Createdby, 1, model.MinWeight, model.ServiceTypeId != null ? string.Format("service_type_id = {0}", model.ServiceTypeId) : "service_type_id IS NULL", model.ServiceTypeId != null ? string.Format("{0}", model.ServiceTypeId) : "null", model.FromWeight != null ? string.Format("{0}", model.FromWeight) : "null", model.ToWeight != null ? string.Format("{0}", model.ToWeight) : "null", model.NextTariff != null ? string.Format("{0}", model.NextTariff) : "null", model.FromWeight != null ? string.Format("from_weight = {0}", model.FromWeight) : "from_weight IS NULL", model.FromWeight != null ? string.Format("to_weight = {0}", model.ToWeight) : "to_weight IS NULL", model.FixedTariff != null ? string.Format("{0}", model.FixedTariff) : "null");
                }

                if (model.StateChange == EnumStateChange.Update)
                {
                    if (model.Ra == null) model.Ra = false;
                    sql += string.Format(@"UPDATE customer_tariff SET tariff = {0}, handling_fee = {1}, ra = {2}, min_weight = {3}, service_type_id = {4}, modifieddate = now(), ltime = '{5}', from_weight = {8}, to_weight = {9}, next_tariff = {10}, fixed_tariff = {11}, modifiedby = '{6}' WHERE id = {7};
                                           UPDATE customer_tariff SET currency_id = 1 WHERE id = {7};",
                                           model.Tariff, model.HandlingFee, (bool)model.Ra ? 1 : 0, model.MinWeight, model.ServiceTypeId != null ? string.Format("{0}", model.ServiceTypeId) : "null", model.Ltime == null ? string.Empty : model.Ltime, model.Createdby, model.Id, model.FromWeight != null ? string.Format("{0}", model.FromWeight) : "null", model.ToWeight != null ? string.Format("{0}", model.ToWeight) : "null", model.NextTariff != null ? string.Format("{0}", model.NextTariff) : "null", model.FixedTariff != null ? string.Format("{0}", model.FixedTariff) : "null");
                }

                if (row >= 20)
                {
                    Entities.ExecuteStoreCommand(sql);
                    Entities.SaveChanges();
                    row = 1;
                    sql = string.Empty;
                }

                row++;

            }

            if (!string.IsNullOrEmpty(sql))
            {
                Entities.ExecuteStoreCommand(sql);
                Entities.SaveChanges();
            }
        }
    }
}