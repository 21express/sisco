

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
using MySql.Data.MySqlClient;

namespace SISCO.Repositories
{
    public class TariffRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "Tariff";
        public TariffRepository()
        {
            ObjectName = OBJECT_NAME;
        }
        
        public TariffRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as TariffModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTotariffs(entity);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as TariffModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.tariffs where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as TariffModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.tariffs select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.tariffs where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.tariffs where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}
        
        private static tariff PopulateModelToNewEntity(TariffModel model)
		{
			return new tariff
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				airline_id = model.AirlineId,
                city_orig_id = model.CityOrigId,
                city_dest_id = model.CityDestId,
				service_type_id = model.ServiceTypeId,
				package_type_id = model.PackageTypeId,
				tariff_per_kg = model.Tariff,
				handling_fee = model.HandlingFee,
				discount_percent = model.DiscountPercent,
				discount_fixed = model.DiscountFixed,
				min_weight = model.MinWeight,
                ra = model.Ra,
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
                ltime = model.LeadTime
			};
		}
        
        private static void PopulateModelToNewEntity(tariff query, TariffModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
			query.airline_id = model.AirlineId;
            query.city_orig_id = model.CityOrigId;
            query.city_dest_id = model.CityDestId;
			query.service_type_id = model.ServiceTypeId;
			query.package_type_id = model.PackageTypeId;
			query.tariff_per_kg = model.Tariff;
			query.handling_fee = model.HandlingFee;
			query.discount_percent = model.DiscountPercent;
			query.discount_fixed = model.DiscountFixed;
			query.min_weight = model.MinWeight;
            query.ra = model.Ra;
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
            query.ltime = model.LeadTime;
		}
        
        private static TariffModel PopulateEntityToNewModel(tariff item)
		{
			return new TariffModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				AirlineId = item.airline_id,
                CityOrigId = item.city_orig_id,
                CityDestId = item.city_dest_id,
				ServiceTypeId = item.service_type_id,
				PackageTypeId = item.package_type_id,
				Tariff = item.tariff_per_kg,
				HandlingFee = item.handling_fee,
				DiscountPercent = item.discount_percent,
				DiscountFixed = item.discount_fixed,
				MinWeight = item.min_weight,
                Ra = item.ra == null ? false : item.ra,
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
                LeadTime = item.ltime,
                StateChange = EnumStateChange.Idle
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.tariffs select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.tariffs select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.tariffs select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			var tquery = (from a in Entities.tariffs select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public TariffModel GetTariff(int cityOrigId, int cityDestId, int serviceTypeId, int packageTypeId, decimal weight)
        {
            var whereterm = GetQueryParameterLinq();
            var query = (from a in Entities.tariffs
                         where
                             a.city_orig_id == cityOrigId &&
                             a.city_dest_id == cityDestId &&
                             a.service_type_id == serviceTypeId &&
                             //a.package_type_id == packageTypeId &&
                             (a.from_weight == null || a.from_weight == 0 || a.from_weight <= weight) &&
                             (a.to_weight == null || a.to_weight == 0 || a.to_weight >= weight)
                         select a)
                .Where(whereterm, ListValue.ToArray())
                .Take(1).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);

            return query.Select(PopulateEntityToNewModel).FirstOrDefault();
        }

        public void Save<T>(CityModel parent, IList<T> models)
        {
            //Entities.ExecuteStoreCommand("DELETE FROM tariff WHERE city_orig_id = {0}", parent.Id);

            var sql = string.Empty;
            var row = 1;
            for (var i = 0; i < models.Count(); i++)
            {
                var model = models[i] as TariffModel;
                if (model == null)
                    throw new ModelNullException();

                //model.CityOrigId = parent.Id;

                //var entity = PopulateModelToNewEntity(model);
                //Entities.AddTotariffs(entity);

                if (model.StateChange == EnumStateChange.Insert)
                {
                    sql += string.Format(@"INSERT INTO tariff (city_orig_id, city_dest_id, service_type_id, tariff_per_kg, handling_fee, ra, ltime, createddate, createdby, rowstatus, currency_id, rowversion)
                                SELECT {0}, {1}, {2}, {3}, {4}, {5}, '{6}', NOW(), '{7}', {8}, 1, NOW() FROM dual
                                WHERE NOT EXISTS(SELECT 1 FROM tariff WHERE city_orig_id = {0} and city_dest_id = {1} and service_type_id = {2} and rowstatus = {8});
                                
                                UPDATE tariff SET tariff_per_kg = {3}, handling_fee = {4}, ra = {5}, ltime = '{6}', min_weight = {9}, modifieddate = now(), modifiedby = '{7}' WHERE city_orig_id = {0} and city_dest_id = {1} and service_type_id = {2} and rowstatus = {8};
                                UPDATE tariff SET currency_id = 1 WHERE city_orig_id = {0} and city_dest_id = {1} and service_type_id = {2} and rowstatus = {8} and currency_id is null;",
                                model.CityOrigId, model.CityDestId, model.ServiceTypeId, model.Tariff, model.HandlingFee, (bool)model.Ra ? 1 : 0, model.LeadTime, model.Createdby, 1, model.MinWeight);
                }

                if (model.StateChange == EnumStateChange.Update)
                {
                    sql += string.Format(@"UPDATE tariff SET tariff_per_kg = {0}, handling_fee = {1}, ra = {2}, min_weight = {9}, modifieddate = now(), ltime = '{3}', modifiedby = '{4}' WHERE city_orig_id = {5} and city_dest_id = {6} and service_type_id = {7} and rowstatus = {8};
                                            UPDATE tariff SET currency_id = 1 WHERE city_orig_id = {5} and city_dest_id = {6} and service_type_id = {7} and rowstatus = {8} and currency_id is null;",
                        model.Tariff, model.HandlingFee, (bool)model.Ra ? 1 : 0, model.LeadTime, model.Createdby, model.CityOrigId, model.CityDestId, model.ServiceTypeId, 1, model.MinWeight);
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

        public IEnumerable<TariffModel> GetTariffs(string cityOrgName)
        {
            var parameters = new List<MySqlParameter>();
            var whereClauses = new List<string>();
            whereClauses.Add("t.rowstatus = @rowstatus");
            whereClauses.Add("co.name LIKE @citiorgname");
            parameters.Add(new MySqlParameter("rowstatus", 1));
            parameters.Add(new MySqlParameter("citiorgname", "%" + cityOrgName + "%"));

            string sql = @"SELECT co.name 'CityOrigName', cd.name 'CityDestName', st.name 'ServiceTypeName', t.tariff_per_kg 'Tariff', t.handling_fee 'HandlingFee', t.ra 'Ra' FROM tariff t
                            LEFT OUTER JOIN city co on co.id = t.city_orig_id
                            LEFT OUTER JOIN city cd on cd.id = t.city_dest_id
                            LEFT OUTER JOIN service_type st on st.id = t.service_type_id
                            WHERE " + string.Join(" AND ", whereClauses) + @"
                            ORDER BY cd.name";

            return Entities.ExecuteStoreQuery<TariffModel>(sql, parameters.ToArray()).ToList();
        }

        public List<TariffModel> GetTarif(int OrigId, int DestId)
        {
            string sql = @"SELECT st.name 'ServiceTypeName', (t.tariff_per_kg+t.handling_fee) 'Tariff', t.ltime LeadTime FROM tariff t
                            LEFT OUTER JOIN service_type st on st.id = t.service_type_id
                            WHERE t.city_orig_id = ? AND t.city_dest_id = ? AND st.name IN ('ECO','ONS','SDS','DARAT','SUPER ECONOMI')
                            ORDER BY st.name";

            return Entities.ExecuteStoreQuery<TariffModel>(sql, OrigId, DestId).ToList();
        }
    }
}