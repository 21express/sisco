

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
    public class DeliveryTariffRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "DeliveryTariff";
        public DeliveryTariffRepository()
        {
            ObjectName = OBJECT_NAME;
        }
        
        public DeliveryTariffRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as DeliveryTariffModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTodelivery_tariff(entity);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as DeliveryTariffModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.delivery_tariff where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as DeliveryTariffModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.delivery_tariff select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.delivery_tariff where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.delivery_tariff where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}
        
        private static delivery_tariff PopulateModelToNewEntity(DeliveryTariffModel model)
		{
			return new delivery_tariff
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				dest_city_id = model.DestCityId,
				package_type_id = model.PackageTypeId,
				tariff = model.Tariff,
                weight_from = model.WeightFrom,
                weight_to = model.WeightTo,
                min_weight = model.MinWeight,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}
        
        private static void PopulateModelToNewEntity(delivery_tariff query, DeliveryTariffModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
            query.dest_city_id = model.DestCityId;
            query.package_type_id = model.PackageTypeId;
			query.tariff = model.Tariff;
            query.weight_from = model.WeightFrom;
            query.weight_from = model.WeightTo;
            query.min_weight = model.MinWeight;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}
        
        private static DeliveryTariffModel PopulateEntityToNewModel(delivery_tariff item)
		{
			return new DeliveryTariffModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				DestCityId = item.dest_city_id,
				PackageTypeId = item.package_type_id,
				Tariff = item.tariff,
                WeightFrom = item.weight_from,
                WeightTo = item.weight_to,
                MinWeight = item.min_weight,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby,
                
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.delivery_tariff select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.delivery_tariff select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.delivery_tariff select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			var tquery = (from a in Entities.delivery_tariff select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public void Save<T>(PackageTypeModel parent, IList<T> models)
        {
            using (var scope = new TransactionScope())
            {
                Entities.ExecuteStoreCommand("DELETE FROM delivery_tariff WHERE package_type_id = {0}", parent.Id);

                for (var i = 0; i < models.Count(); i++)
                {
                    var model = models[i] as DeliveryTariffModel;
                    if (model == null)
                        throw new ModelNullException();

                    model.PackageTypeId = parent.Id;

                    var entity = PopulateModelToNewEntity(model);
                    Entities.AddTodelivery_tariff(entity);
                }

                Entities.SaveChanges();

                scope.Complete();
            }
        }

        public DeliveryTariffModel GetByPackageTypeAndWeight(int packageTypeId, int destCityId, decimal chargeableWeight)
        {
            var q = (from o in Entities.delivery_tariff
                where o.package_type_id == packageTypeId
                      && o.dest_city_id == destCityId
                      && o.weight_from <= chargeableWeight && o.weight_to > chargeableWeight
                      && o.rowstatus
                select o).FirstOrDefault();

            if (q != null)
            {
                return PopulateEntityToNewModel(q);
            }

            return null;
        }
    }
}


