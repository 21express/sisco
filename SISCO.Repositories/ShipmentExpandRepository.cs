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
    public class ShipmentExpandRepository : SISCOBaseRepository, IExtendedQueryableRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "Shipment Expand";
        public ShipmentExpandRepository()
        {
            ObjectName = OBJECT_NAME;
            _withoutDefault = true;
        }

        public ShipmentExpandRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
            _withoutDefault = true;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as ShipmentExpandModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddToshipment_expand(entity);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel)
		{
            var model = businessModel as ShipmentExpandModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.shipment_expand where d.shipment_id == model.ShipmentId select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as ShipmentExpandModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.shipment_expand select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.shipment_expand where d.shipment_id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}

        public void Printing(int shipmentId)
        {
            var query = (from d in Entities.shipment_expand select d).Where(d => d.shipment_id == shipmentId).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            query.printed++;
            Entities.SaveChanges();
        }
        
        private static shipment_expand PopulateModelToNewEntity(ShipmentExpandModel model)
		{
			return new shipment_expand
			{
				shipment_id = model.ShipmentId,
                volume_l = model.VolumeL,
                volume_w = model.VolumeW,
                volume_h = model.VolumeH,
                use_packing = model.UsePacking,
                iscod = model.IsCod,
                total_cod = model.TotalCod,
                paid_cod = model.PaidCod,
                fulfilment = model.Fulfilment,
                printed = model.Printed,
                drop_point_id = model.DropPointId,
                email_point = model.EmailPoint,
                return_awb = model.ReturnAWB,
                handedover = model.Handedover,
                other_label = model.OtherLabel,
                sprinter_id = model.SprinterId,
                insurance_rate = model.InsuranceRate,
                shipper_email = model.ShipperEmail,
                shipper_phone2 = model.ShipperPhone2,
                diff_cw = model.DiffCw
			};
		}
        
        private static void PopulateModelToNewEntity(shipment_expand query, ShipmentExpandModel model)
		{
            query.shipment_id = model.ShipmentId;
            query.volume_l = model.VolumeL;
            query.volume_w = model.VolumeW;
            query.volume_h = model.VolumeH;
            query.use_packing = model.UsePacking;
            query.iscod = model.IsCod;
            query.total_cod = model.TotalCod;
            query.paid_cod = model.PaidCod;
            query.fulfilment = model.Fulfilment;
            query.printed = model.Printed;
            query.drop_point_id = model.DropPointId;
            query.email_point = model.EmailPoint;
            query.return_awb = model.ReturnAWB;
            query.handedover = model.Handedover;
            query.other_label = model.OtherLabel;
            query.sprinter_id = model.SprinterId;
            query.insurance_rate = model.InsuranceRate;
            query.shipper_email = model.ShipperEmail;
            query.shipper_phone2 = model.ShipperEmail;
            query.diff_cw = model.DiffCw;
		}
        
        private static ShipmentExpandModel PopulateEntityToNewModel(shipment_expand item)
		{
            return new ShipmentExpandModel
			{
				ShipmentId = item.shipment_id,
                VolumeL = item.volume_l,
                VolumeW = item.volume_w,
                VolumeH = item.volume_h,
                UsePacking = item.use_packing,
                IsCod = item.iscod,
                TotalCod = item.total_cod,
                PaidCod = item.paid_cod,
                Fulfilment = item.fulfilment,
                Printed = item.printed,
                DropPointId = item.drop_point_id,
                EmailPoint = item.email_point,
                ReturnAWB = item.return_awb,
                Handedover = item.handedover,
                OtherLabel = item.other_label,
                SprinterId = item.sprinter_id,
                InsuranceRate = item.insurance_rate,
                ShipperEmail = item.shipper_email,
                ShipperPhone2 = item.shipper_phone2,
                DiffCw = item.diff_cw
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.shipment_expand select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.shipment_expand select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.shipment_expand select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.shipment_expand select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in Entities.shipment_expand select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.shipment_expand select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }
    }
}