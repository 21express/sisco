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
    public class FranchiseInvoiceListRepository : SISCOBaseRepository, IExtendedQueryableRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "Franchise Invoice List";
        public FranchiseInvoiceListRepository()
        {
            ObjectName = OBJECT_NAME;
        }

        public FranchiseInvoiceListRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as FranchiseInvoiceListModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTofranchise_invoice_list(entity);
			Entities.SaveChanges();

            businessModel.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
            var model = businessModel as FranchiseInvoiceListModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.franchise_invoice_list where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as FranchiseInvoiceListModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.franchise_invoice_list select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.franchise_invoice_list where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
            var query = (from d in Entities.franchise_invoice_list where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}

        private static franchise_invoice_list PopulateModelToNewEntity(FranchiseInvoiceListModel model)
		{
			return new franchise_invoice_list
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
                franchise_invoice_id = model.FranchiseInvoiceId,
                shipment_id = model.ShipmentId,
                shipment_date = model.ShipmentDate,
                shipment_code = model.ShipmentCode,
                destination_city_id = model.DestCityId,
                total_piece = model.TotalPieces,
                total_cw = model.TotalCw,
                service_type_id = model.ServiceTypeId,
                insurance_fee = model.InsuranceFee,
                other_fee = model.OtherFee,
                total_sales = model.TotalSales,
                ppn = model.Ppn,
                commission = model.Commission,
                pph23 = model.Pph23,
                net_commission = model.NetCommission,
                total_invoice = model.TotalInvoice
			};
		}
        
        private static void PopulateModelToNewEntity(franchise_invoice_list query, FranchiseInvoiceListModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
            query.franchise_invoice_id = model.FranchiseInvoiceId;
            query.shipment_id = model.ShipmentId;
            query.shipment_code = model.ShipmentCode;
            query.shipment_date = model.ShipmentDate;
            query.destination_city_id = model.DestCityId;
            query.total_piece = model.TotalPieces;
            query.total_cw = model.TotalCw;
            query.service_type_id = model.ServiceTypeId;
            query.insurance_fee = model.InsuranceFee;
            query.other_fee = model.OtherFee;
            query.total_sales = model.TotalSales;
            query.ppn = model.Ppn;
            query.commission = model.Commission;
            query.pph23 = model.Pph23;
            query.net_commission = model.NetCommission;
            query.total_invoice = model.TotalInvoice;
		}

        private static FranchiseInvoiceListModel PopulateEntityToNewModel(franchise_invoice_list item)
		{
			return new FranchiseInvoiceListModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
                FranchiseInvoiceId = item.franchise_invoice_id,
                ShipmentId = item.shipment_id,
                ShipmentDate = item.shipment_date,
                ShipmentCode = item.shipment_code,
                DestCityId = item.destination_city_id,
                TotalPieces = item.total_piece,
                TotalCw = item.total_cw,
                ServiceTypeId = item.service_type_id,
                InsuranceFee = item.insurance_fee,
                OtherFee = item.other_fee,
                TotalSales = item.total_sales,
                Ppn = item.ppn,
                Commission = item.commission,
                Pph23 = item.pph23,
                NetCommission = item.net_commission,
                TotalInvoice = item.total_invoice,
                StateChange = EnumStateChange.Select
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.franchise_invoice_list select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);

            var result = (from item in query
                          join s in Entities.shipments on item.shipment_id equals s.id
                          join sv in Entities.service_type on item.service_type_id equals sv.id
                          select new FranchiseInvoiceListModel
                          {
                              Id = item.id,
                              Rowstatus = item.rowstatus,
                              Rowversion = item.rowversion,
                              FranchiseInvoiceId = item.franchise_invoice_id,
                              ShipmentId = item.shipment_id,
                              ShipmentDate = item.shipment_date,
                              ShipmentCode = item.shipment_code,
                              DestCityId = item.destination_city_id,
                              DestCity = s.dest_city,
                              TotalPieces = item.total_piece,
                              TotalCw = item.total_cw,
                              ServiceTypeId = item.service_type_id,
                              ServiceType = sv.name,
                              InsuranceFee = item.insurance_fee,
                              OtherFee = item.other_fee,
                              TotalSales = item.total_sales,
                              Ppn = item.ppn,
                              Commission = item.commission,
                              Pph23 = item.pph23,
                              NetCommission = item.net_commission,
                              TotalInvoice = item.total_invoice,
                              StateChange = EnumStateChange.Select
                          }).ToList();
			return (IEnumerable<T>) result;
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.franchise_invoice_list select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.franchise_invoice_list select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.franchise_invoice_list select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<T> Get<T>(Paging paging, out int totalCount, string expression, object[] parameters)
        {
            expression = GetQueryParameterLinqRaw(expression, ref parameters);
            var query = (from a in Entities.franchise_invoice_list select a).Where(expression, parameters).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.franchise_invoice_list select a).Where(expression, parameters);
            totalCount = tquery.Count();
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public void CancellationInvoice(string[] shipmentid, string modifiedBy)
        {
            var sql = string.Format("UPDATE shipment SET invoiced = 0, invoice_id = null, invoice_ref = '', ref_number = '', modifiedby = '{0}', modifieddate = NOW() WHERE id in({1})", modifiedBy, string.Join(", ", shipmentid));
            Entities.ExecuteStoreCommand(sql);
        }

        public void PaidShipmentStatus(string[] shipmentid, short statusPaid, string modifiedBy)
        {
            var sql = string.Format("UPDATE shipment SET paid = {0}, modifiedby = '{1}', modifieddate = NOW() WHERE id in({2})", statusPaid, modifiedBy, string.Join(", ", shipmentid));
            Entities.ExecuteStoreCommand(sql);
        }
    }
}


