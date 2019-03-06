

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
using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using SISCO.Models;
using SISCO.Repositories.Context;

namespace SISCO.Repositories
{
    public class BranchDeliveryTariffRepository : SISCOBaseRepository
    {
        private const string OBJECT_NAME = "BranchDeliveryTariff";
        public BranchDeliveryTariffRepository()
        {
            ObjectName = OBJECT_NAME;
        }
        
        public BranchDeliveryTariffRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as BranchDeliveryTariffModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTobranch_delivery_tariff(entity);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as BranchDeliveryTariffModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.branch_delivery_tariff where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as BranchDeliveryTariffModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.branch_delivery_tariff select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.branch_delivery_tariff where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.branch_delivery_tariff where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}
        
        private static branch_delivery_tariff PopulateModelToNewEntity(BranchDeliveryTariffModel model)
		{
			return new branch_delivery_tariff
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				branch_id = model.BranchId,
				airline_id = model.AirlineId,
				branch_orig_id = model.BranchOrigId,
				branch_dest_id = model.BranchDestId,
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
        
        private static void PopulateModelToNewEntity(branch_delivery_tariff query, BranchDeliveryTariffModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
			query.branch_id = model.BranchId;
			query.airline_id = model.AirlineId;
			query.branch_orig_id = model.BranchOrigId;
			query.branch_dest_id = model.BranchDestId;
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
        
        private static BranchDeliveryTariffModel PopulateEntityToNewModel(branch_delivery_tariff item)
		{
			return new BranchDeliveryTariffModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				BranchId = item.branch_id,
				AirlineId = item.airline_id,
				BranchOrigId = item.branch_orig_id,
				BranchDestId = item.branch_dest_id,
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
			var query = (from a in Entities.branch_delivery_tariff select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.branch_delivery_tariff select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.branch_delivery_tariff select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			var tquery = (from a in Entities.branch_delivery_tariff select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}        
       
    }
}


