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
    public class CorporatePickupRepository : SISCOBaseRepository, IExtendedQueryableRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "CorporatePickup";
        public CorporatePickupRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public CorporatePickupRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as CorporatePickupModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTocorporate_pickup(entity);
			Entities.SaveChanges();

            businessModel.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as CorporatePickupModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.corporate_pickup where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as CorporatePickupModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.corporate_pickup select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }

        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.corporate_pickup where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
            Entities.SaveChanges();
        }

        public override void Delete(int id)
        {
            var query = (from d in Entities.corporate_pickup where d.id == id select d).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            Entities.DeleteObject(query);
            Entities.SaveChanges();
        }

        private static corporate_pickup PopulateModelToNewEntity(CorporatePickupModel model)
        {
            return new corporate_pickup
            {
                id = model.Id,
                rowstatus = model.Rowstatus,
                rowversion = model.Rowversion,
                code = model.Code,
                date_process = model.DateProcess,
                corporate_id = model.CorporateId,
                ttl_pod = model.TtlPod,
                ttl_gross_weight = model.TtlGrossWeight,
                ttl_chargeable = model.TtlChargeable,
                ttl_sales = model.TtlSales,
                ttl_ppn = model.TtlPpn,
                ttl_commission = model.TtlCommission,
                ttl_pph_23 = model.TtlPph23,
                ttl_net_commission = model.TtlNetCommission,
                balance = model.Balance,
                messenger_id = model.MessengerId,
                is_print = model.IsPrint,
                createddate = model.Createddate,
                createdby = model.Createdby,
                createdpc = model.CreatedPc,
                modifieddate = model.Modifieddate,
                modifiedby = model.Modifiedby,
                modifiedpc = model.ModifiedPc
            };
        }

        private static void PopulateModelToNewEntity(corporate_pickup query, CorporatePickupModel model)
        {
            query.id = model.Id;
            query.rowstatus = model.Rowstatus;
            query.rowversion = model.Rowversion;
            query.code = model.Code;
            query.date_process = model.DateProcess;
            query.corporate_id = model.CorporateId;
            query.ttl_pod = model.TtlPod;
            query.ttl_gross_weight = model.TtlGrossWeight;
            query.ttl_chargeable = model.TtlChargeable;
            query.ttl_sales = model.TtlSales;
            query.ttl_ppn = model.TtlPpn;
            query.ttl_commission = model.TtlCommission;
            query.ttl_pph_23 = model.TtlPph23;
            query.ttl_net_commission = model.TtlNetCommission;
            query.balance = model.Balance;
            query.messenger_id = model.MessengerId;
            query.is_print = model.IsPrint;
            query.createddate = model.Createddate;
            query.createdby = model.Createdby;
            query.createdpc = model.CreatedPc;
            query.modifieddate = model.Modifieddate;
            query.modifiedby = model.Modifiedby;
            query.modifiedpc = model.ModifiedPc;
        }

        private static CorporatePickupModel PopulateEntityToNewModel(corporate_pickup item)
        {
            return new CorporatePickupModel
            {
                Id = item.id,
                Rowstatus = item.rowstatus,
                Rowversion = item.rowversion,
                Code = item.code,
                DateProcess = item.date_process,
                CorporateId = item.corporate_id,
                TtlPod = item.ttl_pod,
                TtlGrossWeight = item.ttl_gross_weight,
                TtlChargeable = item.ttl_chargeable,
                TtlSales = item.ttl_sales,
                TtlPpn = item.ttl_ppn,
                TtlCommission = item.ttl_commission,
                TtlPph23 = item.ttl_pph_23,
                TtlNetCommission = item.ttl_net_commission,
                Balance = item.balance,
                MessengerId = item.messenger_id,
                IsPrint = item.is_print,
                Createddate = item.createddate,
                Createdby = item.createdby,
                CreatedPc = item.createdpc,
                Modifieddate = item.modifieddate,
                Modifiedby = item.modifiedby,
                ModifiedPc = item.modifiedpc
            };
        }

        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.corporate_pickup select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public override T GetSingle<T>(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.corporate_pickup select a).Where(whereterm, ListValue.ToArray()).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
            return result.FirstOrDefault();
        }

        public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.corporate_pickup select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.corporate_pickup select a).Where(whereterm, ListValue.ToArray());
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in Entities.corporate_pickup select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.corporate_pickup select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public string GenerateCode(DateTime date)
        {
            var pattern = string.Format("{0}{1}{2}{3}###", "CPU", date.ToString("yy"), date.ToString("MM"), date.ToString("dd"));

            return GenerateCode("corporate-pickup", pattern);
        }
    }
}
