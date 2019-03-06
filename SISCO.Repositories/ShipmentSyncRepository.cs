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
    public class ShipmentSyncRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "SyncJson";
        public ShipmentSyncRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public ShipmentSyncRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
        {
            var model = businessModel as ShipmentSyncModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddToshipment_sync(entity);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel)
		{
            var model = businessModel as ShipmentSyncModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.shipment_sync where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as ShipmentSyncModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query =
                (from d in Entities.shipment_sync select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.shipment_sync where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.shipment_sync where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}

        private static shipment_sync PopulateModelToNewEntity(ShipmentSyncModel model)
		{
            return new shipment_sync
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				awb = model.Awb,
                remark = model.Remark,
                cn_name = model.CnName,
                address = model.Address,
                district = model.District,
                city = model.City,
                province = model.Province,
                country = model.Country,
                phone = model.Phone,
                order_id = model.OrderId,
                actweight = model.ActWeight,
                pieces = model.Pieces,
                itemname = model.ItemName,
                goodsval = model.GoodsVal,
                insurance = model.Insurance,
                cod = model.Cod,
                pickupdate = model.PickupDate,
                service = model.Service,
                imported = model.Imported,
                merchant = model.Merchant,
                merchant_address = model.MerchantAddress,
                merchant_district = model.MerchantDistrict,
                merchant_city = model.MerchantCity,
                merchant_province = model.MerchantProvince,
                merchant_country = model.MerchantCountry,
                merchant_phone = model.MerchantPhone,
                merchant_contact = model.MerchantContact,
				createddate = model.Createddate,
				createdby = model.Createdby,
                createdpc = model.CreatedPc,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
                modifiedpc = model.ModifiedPc
			};
		}

        private static void PopulateModelToNewEntity(shipment_sync query, ShipmentSyncModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
            query.awb = model.Awb;
            query.remark = model.Remark;
            query.cn_name = model.CnName;
            query.address = model.Address;
            query.district = model.District;
            query.city = model.City;
            query.province = model.Province;
            query.country = model.Country;
            query.phone = model.Phone;
            query.order_id = model.OrderId;
            query.actweight = model.ActWeight;
            query.pieces = model.Pieces;
            query.itemname = model.ItemName;
            query.goodsval = model.GoodsVal;
            query.insurance = model.Insurance;
            query.cod = model.Cod;
            query.pickupdate = model.PickupDate;
            query.service = model.Service;
            query.imported = model.Imported;
            query.merchant = model.Merchant;
            query.merchant_address = model.MerchantAddress;
            query.merchant_district = model.MerchantDistrict;
            query.merchant_city = model.MerchantCity;
            query.merchant_province = model.MerchantProvince;
            query.merchant_country = model.MerchantCountry;
            query.merchant_phone = model.MerchantPhone;
            query.merchant_contact = model.MerchantContact;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
            query.createdpc = model.CreatedPc;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
            query.modifiedpc = model.ModifiedPc;
		}

        private static ShipmentSyncModel PopulateEntityToNewModel(shipment_sync item)
		{
            return new ShipmentSyncModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				Awb = item.awb,
                Remark = item.remark,
                CnName = item.cn_name,
                Address = item.address,
                District = item.district,
                City = item.city,
                Province = item.province,
                Country = item.country,
                Phone = item.phone,
                OrderId = item.order_id,
                ActWeight = item.actweight,
                Pieces = item.pieces,
                ItemName = item.itemname,
                GoodsVal = item.goodsval,
                Insurance = item.insurance,
                Cod = item.cod,
                PickupDate = item.pickupdate,
                Service = item.service,
                Imported = item.imported,
                Merchant = item.merchant,
                MerchantAddress = item.merchant_address,
                MerchantDistrict = item.merchant_district,
                MerchantCity = item.merchant_city,
                MerchantProvince = item.merchant_province,
                MerchantCountry = item.merchant_country,
                MerchantPhone = item.merchant_phone,
                MerchantContact = item.merchant_contact,
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
			var query = (from a in Entities.shipment_sync select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.shipment_sync select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.shipment_sync select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.shipment_sync select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		}

        public void BulkInsert(string sql)
        {
            Entities.ExecuteStoreCommand(sql);
        }

        public void UpdateShipment(string shipmentCode, string userLogin, string computerName)
        {
            Entities.ExecuteStoreCommand(string.Format("UPDATE shipment_sync SET imported = 1, modifieddate = NOW(), modifiedby = '{0}', modifiedpc = '{1}' WHERE awb = '{2}'", userLogin, computerName, shipmentCode));
        }
    }
}