using SISCO.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Dynamic;
using SISCO.Repositories.Context;
using SISCO.Models;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using Devenlab.Common;
using MySql.Data.MySqlClient;

namespace SISCO.Repositories
{
    public class PodHandoverDetailRepository : SISCOBaseRepository, IExtendedQueryableRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "Pod Handover Detail";
        public PodHandoverDetailRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public PodHandoverDetailRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as PodHandoverDetailModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTopod_handover_detail(entity);
			Entities.SaveChanges();

            model.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
            var model = businessModel as PodHandoverDetailModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.pod_handover_detail where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as PodHandoverDetailModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.pod_handover_detail select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.pod_handover_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.pod_handover_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}

        private static pod_handover_detail PopulateModelToNewEntity(PodHandoverDetailModel model)
		{
            return new pod_handover_detail
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
                pod_handover_id = model.PodHandoverId,
                shipment_id = model.ShipmentId,
                cek = model.Cek,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}

        private static void PopulateModelToNewEntity(pod_handover_detail query, PodHandoverDetailModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
            query.pod_handover_id = model.PodHandoverId;
            query.shipment_id = model.ShipmentId;
            query.cek = model.Cek;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}

        private static PodHandoverDetailModel PopulateEntityToNewModel(pod_handover_detail item)
		{
            return new PodHandoverDetailModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
                PodHandoverId = item.pod_handover_id,
                ShipmentId = item.shipment_id,
                Cek = item.cek,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby,
                
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.pod_handover_detail select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.pod_handover_detail select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.pod_handover_detail select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.pod_handover_detail select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in Entities.pod_handover_detail select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.pod_handover_detail select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public List<PodHandoverRowDetail> GetPodHandovers(int handoverId)
        {
            var sql = @"SELECT
	                        s.code Code,
	                        s.date_process DateProcess,
	                        s.city_name CityName,
	                        s.dest_city DestCityName,
	                        CONCAT(c.code, ' ', c.name) CustomerName,
                            s.shipper_name ShipperName,
                            s.shipper_address ShipperAddress,
                            s.consignee_name ConsigneeName,
                            s.consignee_address ConsigneeAddress,
                            s.ttl_piece TtlPiece,
                            s.ttl_gross_weight TtlGrossWeight,
                            s.ttl_chargeable_weight TtlChargeableWeight,
                            s.id Id,
                            pd.cek Cek
                        FROM pod_handover_detail pd
                        INNER JOIN pod_handover p ON pd.pod_handover_id = p.id AND p.rowstatus = 1
                        INNER JOIN shipment s ON pd.shipment_id = s.id
                        Left JOIN customer c ON s.customer_id = c.id
                        WHERE pd.rowstatus = 1 AND pd.pod_handover_id = @handoverId";

            var listParam = new List<MySqlParameter>();
            listParam.Add(new MySqlParameter("handoverId", handoverId));

            var result = Entities.ExecuteStoreQuery<PodHandoverRowDetail>(sql, listParam.ToArray()).ToList();
            return result;
        }
    }
}