

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
    public class TariffInternationalRepository : SISCOBaseRepository
    {
        private const string OBJECT_NAME = "TariffInternational";
        public TariffInternationalRepository()
        {
            ObjectName = OBJECT_NAME;
        }
        
        public TariffInternationalRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as TariffInternationalModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTotariff_international(entity);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as TariffInternationalModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.tariff_international where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as TariffInternationalModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.tariff_international select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.tariff_international where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.tariff_international where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}
        
        private static tariff_international PopulateModelToNewEntity(TariffInternationalModel model)
		{
			return new tariff_international
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				pricing_plan_id = model.PricingPlanId,
                package_type_id = model.PackageTypeId,
                tariff = model.Tariff,
                handling_fee = model.HandlingFee,
				min_weight = model.MinWeight,
				other_fee = model.OtherFee,
				other_kg = model.OtherKg,
				currency_id = model.CurrencyId,
				from_weight = model.FromWeight,
				to_weight = model.ToWeight,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}
        
        private static void PopulateModelToNewEntity(tariff_international query, TariffInternationalModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
			query.pricing_plan_id = model.PricingPlanId;
            query.package_type_id = model.PackageTypeId;
            query.tariff = model.Tariff;
            query.handling_fee = model.HandlingFee;
			query.min_weight = model.MinWeight;
			query.other_fee = model.OtherFee;
			query.other_kg = model.OtherKg;
			query.currency_id = model.CurrencyId;
			query.from_weight = model.FromWeight;
			query.to_weight = model.ToWeight;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}
        
        private static TariffInternationalModel PopulateEntityToNewModel(tariff_international item)
		{
			return new TariffInternationalModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				PricingPlanId = item.pricing_plan_id,
                PackageTypeId = item.package_type_id,
                Tariff = item.tariff,
                HandlingFee = item.handling_fee,
				MinWeight = item.min_weight,
				OtherFee = item.other_fee,
				OtherKg = item.other_kg,
				CurrencyId = item.currency_id,
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
			var query = (from a in Entities.tariff_international select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.tariff_international select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.tariff_international select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			var tquery = (from a in Entities.tariff_international select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).Cast<TariffInternationalModel>().ToList();
		}

        public TariffInternationalModel GetTariff(int pricingPlanId, int packageTypeId, decimal weight)
        {
            var whereterm = GetQueryParameterLinq();
            var query = (from a in Entities.tariff_international
                         where a.pricing_plan_id == pricingPlanId && a.package_type_id == packageTypeId &&
                             (a.from_weight == null || a.from_weight == 0 || a.from_weight < weight) &&
                             (a.to_weight == null || a.to_weight == 0 || a.to_weight >= weight)
                         select a)
                .Where(whereterm, ListValue.ToArray())
                .Take(1).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);

            var tariff = query.Select(PopulateEntityToNewModel).FirstOrDefault();

            if (tariff != null && tariff.OtherKg != null && tariff.OtherFee != null && tariff.OtherKg > 0 && tariff.OtherFee > 0)
            {
                var multiplier = Math.Ceiling((weight - Convert.ToDecimal(tariff.FromWeight))/Convert.ToDecimal(tariff.OtherKg));

                if (multiplier > 0)
                {
                    tariff.Tariff += multiplier * Convert.ToDecimal(tariff.OtherFee);
                }
            }

            return tariff;
        }
        
        public void Save<T>(PricingPlanModel parent, IList<T> models)
        {
            using (var scope = new TransactionScope())
            {
                Entities.ExecuteStoreCommand("DELETE FROM tariff_international WHERE pricing_plan_id = {0}", parent.Id);

                for (var i = 0; i < models.Count(); i++)
                {
                    var model = models[i] as TariffInternationalModel;
                    if (model == null)
                        throw new ModelNullException();

                    model.PricingPlanId = parent.Id;

                    var entity = PopulateModelToNewEntity(model);
                    Entities.AddTotariff_international(entity);
                }

                Entities.SaveChanges();

                scope.Complete();
            }
        }
    }
}


