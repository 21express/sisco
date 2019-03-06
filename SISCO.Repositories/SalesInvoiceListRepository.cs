

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
    public class SalesInvoiceListRepository : SISCOBaseRepository
    {
        private const string OBJECT_NAME = "SalesInvoiceList";
        public SalesInvoiceListRepository()
        {
            ObjectName = OBJECT_NAME;
        }
        
        public SalesInvoiceListRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as SalesInvoiceListModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTosales_invoice_list(entity);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as SalesInvoiceListModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.sales_invoice_list where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as SalesInvoiceListModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.sales_invoice_list select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.sales_invoice_list where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.sales_invoice_list where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}
        
        private static sales_invoice_list PopulateModelToNewEntity(SalesInvoiceListModel model)
		{
			return new sales_invoice_list
			{
				id = model.Id,
                sales_invoice_id = model.SalesInvoiceId,
                shipment_id = model.ShipmentId,
                shipment_code = model.ShipmentCode,
                shipment_process_date = model.ShipmentProcessDate,
                destination_city = model.DestinationCity,
                total_piece = model.TotalPiece,
                total_chargeable_weight = model.TotalChargeableWeight,
                service_type_id = model.ServiceTypeId,
                service_type = model.ServiceType,
                package_type_id = model.PackageTypeId,
                package_type = model.PackageType,
                pricing_plan_id = model.PricingPlanId,
                need_ra = model.NeedRa,
                tariff_per_kg = model.TariffPerKg,
                handling_fee = model.HandlingFee,
                packing_fee = model.PackingFee,
                total_tariff = model.TotalTariff,
                discount = model.Discount,
                net_tariff = model.NetTariff,
                other_fee = model.OtherFee,
                insurance_fee = model.InsuranceFee,
                grand_total = model.GrandTotal,
                grand_total_in_base_currency = model.GrandTotalInBaseCurrency,
                currency = model.Currency,
                currency_rate = model.CurrencyRate,
                invoiced = model.Invoiced,

				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}
        
        private static void PopulateModelToNewEntity(sales_invoice_list query, SalesInvoiceListModel model)
		{
			query.id = model.Id;
			
            query.sales_invoice_id = model.SalesInvoiceId;
            query.shipment_id = model.ShipmentId;
            query.shipment_code = model.ShipmentCode;
            query.shipment_process_date = model.ShipmentProcessDate;
            query.destination_city = model.DestinationCity;
            query.total_piece = model.TotalPiece;
            query.total_chargeable_weight = model.TotalChargeableWeight;
            query.service_type_id = model.ServiceTypeId;
            query.service_type = model.ServiceType;
            query.package_type_id = model.PackageTypeId;
            query.package_type = model.PackageType;
            query.pricing_plan_id = model.PricingPlanId;
            query.tariff_per_kg = model.TariffPerKg;
            query.handling_fee = model.HandlingFee;
            query.packing_fee = model.PackingFee;
            query.need_ra = model.NeedRa;
            query.total_tariff = model.TotalTariff;
            query.discount = model.Discount;
            query.net_tariff = model.NetTariff;
            query.other_fee = model.OtherFee;
            query.insurance_fee = model.InsuranceFee;
            query.grand_total = model.GrandTotal;
            query.grand_total_in_base_currency = model.GrandTotalInBaseCurrency;
            query.currency = model.Currency;
            query.currency_rate = model.CurrencyRate;
            query.invoiced = model.Invoiced;

			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}
        
        private static SalesInvoiceListModel PopulateEntityToNewModel(sales_invoice_list item)
		{
			return new SalesInvoiceListModel
			{
				Id = item.id,

                SalesInvoiceId = item.sales_invoice_id,
                ShipmentId = item.shipment_id,
                ShipmentCode = item.shipment_code,
                ShipmentProcessDate = item.shipment_process_date,
                DestinationCity = item.destination_city,
                TotalPiece = item.total_piece,
                TotalChargeableWeight = item.total_chargeable_weight,
                ServiceTypeId = item.service_type_id,
                ServiceType = item.service_type,
                PackageTypeId = item.package_type_id,
                PackageType = item.package_type,
                PricingPlanId = item.pricing_plan_id,
                TariffPerKg = item.tariff_per_kg,
                HandlingFee = item.handling_fee,
                PackingFee = item.packing_fee,
                NeedRa = item.need_ra,
                TotalTariff = item.total_tariff,
                Discount = item.discount,
                NetTariff = item.net_tariff,
                OtherFee = item.other_fee,
                InsuranceFee = item.insurance_fee,
                GrandTotal = item.grand_total,
                GrandTotalInBaseCurrency = item.grand_total_in_base_currency,
                Currency = item.currency,
                CurrencyRate = item.currency_rate,
                Invoiced = item.invoiced,

				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				Createddate = item.createddate,
				Createdby = item.createdby,
				Modifieddate = item.modifieddate,
				Modifiedby = item.modifiedby,
                
			};
		}
        
        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.sales_invoice_list select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.sales_invoice_list select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.sales_invoice_list select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			var tquery = (from a in Entities.sales_invoice_list select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).Cast<SalesInvoiceListModel>().ToList();
		}

        public void Save<T>(SalesInvoiceModel parent, IList<T> models)
        {
            var shipmentIds = new List<int>(new[] { 0 });

            //Entities.ExecuteStoreCommand("DELETE FROM sales_invoice_list WHERE sales_invoice_id = {0}", parent.Id);

            var sql = string.Empty;
            var row = 1;
            for (var i = 0; i < models.Count(); i++)
            {
                var model = models[i] as SalesInvoiceListModel;
                if (model == null)
                    throw new ModelNullException();

                model.SalesInvoiceId = parent.Id;

                /*var entity = PopulateModelToNewEntity(model);
                Entities.AddTosales_invoice_list(entity);*/

                sql += string.Format((model.NewRow ? "INSERT INTO " : "UPDATE ") + "sales_invoice_list SET rowversion = now(), sales_invoice_id = {0}, shipment_id = {1}, " +
                        "shipment_code = '{2}', shipment_process_date = '{3}', destination_city = '{4}', total_piece = {5}, "+
                        "total_chargeable_weight = {6}, service_type_id = {7}, service_type = '{8}', package_type_id = {9}, " +
                        "package_type = '{10}', pricing_plan_id = {11}, need_ra = {12}, tariff_per_kg = {13}, handling_fee = {14}, " +
                        "packing_fee = {15}, total_tariff = {16}, discount = {17}, net_tariff = {18}, other_fee = {19}, " +
                        "insurance_fee = {20}, grand_total = {21}, grand_total_in_base_currency = {22}, currency = '{23}', " +
                        "currency_rate = {24}, invoiced = {25}" +
                        (!model.NewRow ? ", modifieddate = '{26}', modifiedby = '{27}' WHERE id = {28};" : ", createddate = '{26}', createdby = '{27}' ;/*{28}*/"),
                        model.SalesInvoiceId, model.ShipmentId, model.ShipmentCode, model.ShipmentProcessDate.ToString("yyyy-MM-dd hh:mm"), 
                        model.DestinationCity, model.TotalPiece, model.TotalChargeableWeight, model.ServiceTypeId, model.ServiceType,
                        model.PackageTypeId, model.PackageType, model.PricingPlanId, model.NeedRa ? 1 : 0, model.TariffPerKg, model.HandlingFee,
                        model.PackingFee, model.TotalTariff, model.Discount, model.NetTariff, model.OtherFee, model.InsuranceFee,
                        model.GrandTotal, model.GrandTotalInBaseCurrency, model.Currency, model.CurrencyRate, model.Invoiced ? 1 :0,
                        model.Createddate.ToString("yyyy-MM-dd hh:mm"), model.Createdby, model.Id);

                shipmentIds.Add(model.ShipmentId);

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

            var q =
                string.Format(
                    "UPDATE shipment SET invoiced = 1, invoice_ref = '{0}', invoice_id = '{1}', payment_receipt_number = '{2}', currency_rate = {3}, total = (tariff_net + packing_fee + other_fee + insurance_fee) * currency_rate WHERE id IN ({4})",
                    parent.Code,
                    parent.Id,
                    parent.RefNumber,
                    parent.CurrencyRate,
                    string.Join(",", shipmentIds)) //,
                //new ObjectParameter("@invoice_ref", parent.Code),
                //new ObjectParameter("@invoice_id", parent.Id),
                //new ObjectParameter("@payment_receipt_number", parent.RefNumber)
                ;

            Entities.ExecuteStoreCommand(q);
            Entities.SaveChanges();
        }

        public void RemoveDetail (int pid)
        {
            var sql = @"update sales_invoice_list set rowstatus = 0 where sales_invoice_id = @pid";
            Entities.ExecuteStoreCommand(sql, new MySqlParameter("pid", pid));
        }

        public void CancelInvoice(List<int> canceledShipmentIds)
        {
            if (canceledShipmentIds.Count == 0) return;
            Entities.ExecuteStoreCommand(string.Format("UPDATE sales_invoice_list SET invoiced = 0 WHERE shipment_id IN ({0}) AND invoiced = 1",
                string.Join(",", canceledShipmentIds)));

            Entities.SaveChanges(); ;
        }

        public void DeleteRows(List<int> deleteShipmentIds, int parentId, string modifiedBy)
        {
            if (deleteShipmentIds.Count == 0) return;
            Entities.ExecuteStoreCommand(string.Format("UPDATE sales_invoice_list SET rowstatus = 0, modifieddate = '{0}', modifiedby = '{1}' WHERE shipment_id IN ({2}) and sales_invoice_id = {3}",
                DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), modifiedBy,
                string.Join(",", deleteShipmentIds), parentId));

            Entities.SaveChanges(); ;
        }

        /*public IEnumerable<SalesInvoiceListModel> GetJoinShipmentAndDelivery(int salesInvoiceId)
        {
            var query = from sil in Entities.sales_invoice_list.Where(sil => sil.sales_invoice_id == salesInvoiceId && sil.rowstatus)
                        from s in Entities.shipments.Where(r => r.id == sil.shipment_id && r.rowstatus).DefaultIfEmpty()
                        //from dol in Entities.delivery_order_detail.Where(r => r.shipment_id == sil.shipment_id && r.received && r.rowstatus).DefaultIfEmpty()
                        from ss in Entities.shipment_status.Where(r => r.shipment_id == sil.shipment_id && r.rowstatus && r.tracking_status_id == 10).DefaultIfEmpty()
                        select new SalesInvoiceListModel
                        {
                            Id = sil.id,

                            SalesInvoiceId = sil.sales_invoice_id,
                            ShipmentId = sil.shipment_id,
                            ShipmentCode = sil.shipment_code,
                            ShipmentProcessDate = sil.shipment_process_date,
                            //DeliveredDate = dol.received_date,
                            //Recipient = dol.received_by,
                            DeliveredDate = ss.dateprocess,
                            Recipient = ss.status_by,
                            ConsigneeName = s.consignee_name,
                            DestinationCity = sil.destination_city,
                            TotalPiece = sil.total_piece,
                            TotalChargeableWeight = sil.total_chargeable_weight,
                            ServiceTypeId = sil.service_type_id,
                            ServiceType = sil.service_type,
                            PackageTypeId = sil.package_type_id,
                            PackageType = sil.package_type,
                            PricingPlanId = sil.pricing_plan_id,
                            TariffPerKg = sil.tariff_per_kg,
                            HandlingFee = sil.handling_fee,
                            PackingFee = sil.packing_fee,
                            NeedRa = sil.need_ra,
                            TotalTariff = sil.total_tariff,
                            Discount = sil.discount,
                            NetTariff = sil.net_tariff,
                            OtherFee = sil.other_fee,
                            InsuranceFee = sil.insurance_fee,
                            GrandTotal = sil.grand_total,
                            GrandTotalInBaseCurrency = sil.grand_total_in_base_currency,
                            Currency = sil.currency,
                            CurrencyRate = sil.currency_rate,
                            Invoiced = sil.invoiced,

                            Createddate  = sil.createddate,
                            Createdby = sil.createdby,
                            Modifiedby = sil.modifiedby,
                            Modifieddate = sil.modifieddate,
                            Rowstatus = sil.rowstatus,
                            Rowversion = sil.rowversion,
                            NewRow = false
                        };

            return query.ToList();
        }*/

        public List<SalesInvoiceListModel> GetJoinShipmentAndDelivery(int salesInvoiceId)
        {
            var sql = @"SELECT
	                        sil.id Id,
	                        sil.sales_invoice_id SalesInvoiceId,
	                        sil.shipment_id ShipmentId,
	                        sil.shipment_code ShipmentCode,
	                        sil.shipment_process_date ShipmentProcessDate,
	                        (select ss.dateprocess from shipment_status ss where ss.shipment_id = sil.shipment_id and ss.rowstatus = 1 and ss.tracking_status_id = 8 order by createddate limit 1) DeliveredDate,
                            (select ss.status_by from shipment_status ss where ss.shipment_id = sil.shipment_id and ss.rowstatus = 1 and ss.tracking_status_id = 10 order by createddate desc limit 1) Recipient,
	                        s.consignee_name ConsigneeName,
	                        sil.destination_city DestinationCity,
	                        sil.total_piece TotalPiece,
	                        sil.total_chargeable_weight TotalChargeableWeight,
	                        sil.service_type_id ServiceTypeId,
	                        sil.service_type ServiceType,
	                        sil.package_type_id PackageTypeId,
	                        sil.package_type PackageType,
	                        sil.pricing_plan_id PricingPlanId,
	                        sil.tariff_per_kg TariffPerKg,
	                        sil.handling_fee HandlingFee,
	                        sil.packing_fee PackingFee,
	                        sil.need_ra NeedRa,
	                        sil.total_tariff TotalTariff,
	                        sil.discount Discount,
	                        sil.net_tariff NetTariff,
                            se.other_label OtherLabel,
	                        sil.other_fee OtherFee,
	                        sil.insurance_fee InsuranceFee,
	                        sil.grand_total GrandTotal,
	                        sil.grand_total_in_base_currency GrandTotalInBaseCurrency,
	                        sil.currency Currency,
	                        sil.currency_rate CurrencyRate,
	                        sil.invoiced Invoiced,
	                        sil.createddate Createddate,
	                        sil.createdby Createdby,
	                        sil.modifiedby Modifiedby,
	                        sil.modifieddate Modifieddate,
	                        sil.rowstatus Rowstatus,
	                        sil.rowversion Rowversion,
	                        0 NewRow,
                            true Scanned
                        FROM sales_invoice_list sil
                        LEFT JOIN shipment s ON s.id = sil.shipment_id AND s.rowstatus = 1
                        LEFT JOIN shipment_expand se ON s.id = se.shipment_id
                        WHERE sil.sales_invoice_id = {0} AND sil.rowstatus = 1";

            sql = string.Format(sql, salesInvoiceId);
            return Entities.ExecuteStoreQuery<SalesInvoiceListModel>(sql).ToList();
        }

        public List<SalesInvoiceListDataRow> GetFuckingShipments(int salesInvoiceId)
        {
            var sql = @"SELECT
	                        sil.id Id,
	                        sil.sales_invoice_id SalesInvoiceId,
	                        sil.shipment_id ShipmentId,
	                        sil.shipment_code ShipmentCode,
	                        sil.shipment_process_date ShipmentProcessDate,
	                        (select ss.dateprocess from shipment_status ss where ss.shipment_id = sil.shipment_id and ss.rowstatus = 1 and ss.tracking_status_id = 8 order by createddate limit 1) DeliveredDate,
                            (select ss.status_by from shipment_status ss where ss.shipment_id = sil.shipment_id and ss.rowstatus = 1 and ss.tracking_status_id = 10 order by createddate desc limit 1) Recipient,
	                        s.consignee_name ConsigneeName,
	                        sil.destination_city DestinationCity,
	                        sil.total_piece TotalPiece,
	                        sil.total_chargeable_weight TotalChargeableWeight,
	                        sil.service_type_id ServiceTypeId,
	                        sil.service_type ServiceType,
	                        sil.package_type_id PackageTypeId,
	                        sil.package_type PackageType,
	                        sil.pricing_plan_id PricingPlanId,
	                        sil.tariff_per_kg TariffPerKg,
	                        sil.handling_fee HandlingFee,
	                        sil.packing_fee PackingFee,
	                        sil.need_ra NeedRa,
	                        sil.total_tariff TotalTariff,
	                        sil.discount Discount,
	                        sil.net_tariff NetTariff,
                            se.other_label OtherLabel,
	                        sil.other_fee OtherFee,
	                        sil.insurance_fee InsuranceFee,
	                        sil.grand_total GrandTotal,
	                        sil.grand_total_in_base_currency GrandTotalInBaseCurrency,
	                        sil.currency Currency,
	                        sil.currency_rate CurrencyRate,
	                        sil.invoiced Invoiced,
	                        sil.createddate Createddate,
	                        sil.createdby Createdby,
	                        sil.modifiedby Modifiedby,
	                        sil.modifieddate Modifieddate,
	                        sil.rowstatus Rowstatus,
	                        sil.rowversion Rowversion,
	                        0 NewRow
                        FROM sales_invoice_list sil
                        LEFT JOIN shipment s ON s.id = sil.shipment_id AND s.rowstatus = 1
                        LEFT JOIN shipment_expand se ON s.id = se.shipment_id
                        WHERE sil.sales_invoice_id = {0} AND sil.rowstatus = 1";

            sql = string.Format(sql, salesInvoiceId);
            return Entities.ExecuteStoreQuery<SalesInvoiceListDataRow>(sql).ToList();
        }
    }
}