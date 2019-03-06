using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using SISCO.Models;
using SISCO.Repositories.Context;
using SISCO.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Dynamic;
using Devenlab.Common;
using MySql.Data.MySqlClient;

namespace SISCO.Repositories
{
    public class ShipmentInsuranceDetailRepository : SISCOBaseRepository, IExtendedQueryableRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "Shipment Insurance Detail";
        public ShipmentInsuranceDetailRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public ShipmentInsuranceDetailRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as ShipmentInsuranceDetailModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddToshipment_insurance_detail(entity);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel)
		{
            var model = businessModel as ShipmentInsuranceDetailModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.shipment_insurance_detail where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as ShipmentInsuranceDetailModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.shipment_insurance_detail select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.shipment_insurance_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
            var query = (from d in Entities.shipment_insurance_detail where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}

        private static shipment_insurance_detail PopulateModelToNewEntity(ShipmentInsuranceDetailModel model)
		{
            return new shipment_insurance_detail
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				shipment_insurance_id = model.ShipmentInsuranceId,
                insured = model.Insured,
                shipment_id = model.ShipmentId,
                conveyance = model.Conveyance,
                nature_of_goods = model.NatureOfGoods,
                goods_value = model.GoodsValue,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}

        private static void PopulateModelToNewEntity(shipment_insurance_detail query, ShipmentInsuranceDetailModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
			query.shipment_insurance_id = model.ShipmentInsuranceId;
            query.insured = model.Insured;
            query.shipment_id = model.ShipmentId;
            query.conveyance = model.Conveyance;
            query.nature_of_goods = model.NatureOfGoods;
            query.goods_value = model.GoodsValue;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}

        private static ShipmentInsuranceDetailModel PopulateEntityToNewModel(shipment_insurance_detail item)
		{
			return new ShipmentInsuranceDetailModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				ShipmentInsuranceId = item.shipment_insurance_id,
                Insured = item.insured,
                ShipmentId = item.shipment_id,
                Conveyance = item.conveyance,
                NatureOfGoods = item.nature_of_goods,
                GoodsValue = item.goods_value,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.shipment_insurance_detail select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.shipment_insurance_detail select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.shipment_insurance_detail select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.shipment_insurance_detail select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in Entities.shipment_insurance_detail select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.shipment_insurance_detail select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public List<InsuranceDetail> GetInsuranceDetail(int insuranceId)
        {
            var sql = @"SELECT
	                        s.id ShipmentId,
                            s.posted Posted,
                            sid.insured CustomerName,
                            s.date_process DateProcess,
                            s.city_name CityName,
                            s.dest_city DestCity,
                            sid.nature_of_goods NatureOfGoods,
                            sid.conveyance Conveyance,
                            s.code Code,
                            sid.goods_value GoodsValue,
                            se.insurance_rate Rate,
                            s.insurance_fee InsuranceFee,
                            'Idle' StateChange
                        FROM shipment_insurance_detail sid
                        INNER JOIN shipment s ON sid.shipment_id = s.id AND s.rowstatus = 1
                        INNER JOIN shipment_expand se ON se.shipment_id = s.id
                        INNER JOIN shipment_insurance si ON sid.shipment_insurance_id = si.id AND si.rowstatus = 1
                        WHERE sid.rowstatus = 1 AND si.id = @insuranceId";

            return Entities.ExecuteStoreQuery<InsuranceDetail>(sql, new MySqlParameter("insuranceId", insuranceId)).ToList();
        }

        public void SaveInsurance(List<InsuranceDetail> data, int insuranceId, string username, string machineName)
        {
            var sql = string.Empty;
            var row = 1;

            for (var i = 0; i < data.Count(); i++)
            {
                var _data = data[i] as InsuranceDetail;
                if (_data == null)
                    throw new ModelNullException();

                if (_data.StateChange == EnumStateChange.Insert.ToString())
                {
                    sql += @"INSERT INTO shipment_insurance_detail (rowstatus, rowversion, shipment_insurance_id, shipment_id, insured, conveyance, nature_of_goods, goods_value, createddate, createdby)
                        VALUES (1, NOW(), {0}, {1}, '{8}', '{2}', '{3}', {4}, NOW(), '{5}');

                        UPDATE shipment SET posted = 0, goods_value = {4}, nature_of_goods = '{3}', modifiedby = '{5}', modifieddate = NOW(), modifiedpc = '{6}'
                        WHERE id = {1};

                        UPDATE shipment_expand SET insurance_rate = {7} WHERE shipment_id = {1};";

                    sql = string.Format(sql, insuranceId, _data.ShipmentId, _data.Conveyance, _data.NatureOfGoods, _data.GoodsValue, username, machineName, _data.Rate, _data.CustomerName);

                    if (row >= 20)
                    {
                        Entities.ExecuteStoreCommand(sql);
                        Entities.SaveChanges();
                        row = 1;
                        sql = string.Empty;
                    }

                    row++;
                }
            }

            if (!string.IsNullOrEmpty(sql))
            {
                Entities.ExecuteStoreCommand(sql);
                Entities.SaveChanges();
            }
        }

        public void DeleteAll(int insuranceId)
        {
            var sql = "UPDATE shipment_insurance_detail SET rowstatus = 0 WHERE shipment_insurance_id = @insuranceId";
            Entities.ExecuteStoreCommand(sql, new MySqlParameter("insuranceId", insuranceId));
        }
    }
}