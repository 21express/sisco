using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Dynamic;
using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using MySql.Data.MySqlClient;
using SISCO.Models;
using SISCO.Repositories.Context;

namespace SISCO.Repositories
{
    public class ShipmentRepository : SISCOBaseRepository
    {
        public enum EnumPaymentMethod
        {
            Cash = 1,
            Collect = 2,
            Credit = 3
        }

        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "Shipment";
        public ShipmentRepository()
        {
            ObjectName = OBJECT_NAME;
        }
        
        public ShipmentRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as ShipmentModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddToshipments(entity);
			Entities.SaveChanges();

            businessModel.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as ShipmentModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.shipments where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as ShipmentModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.shipments select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.shipments where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.shipments where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}
        
        private static shipment PopulateModelToNewEntity(ShipmentModel model)
        {
            if (model.PricingPlanId == null) model.PricingPlanId = 0;
            return new shipment
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				date_process = model.DateProcess,
				code = model.Code,
				branch_id = model.BranchId,
				marketing_id = model.MarketingId,
				messenger_id = model.MessengerId,
				messenger_name = model.MessengerName,
                messenger_id2 = model.MessengerId2,
                messenger_name2 = model.MessengerName2,
				sales_type_id = model.SalesTypeId,
				city_id = model.CityId,
				city_name = model.CityName,
				dest_city_id = model.DestCityId,
				dest_city = model.DestCity,
				dest_country_id = model.DestCountryId,
				dest_country = model.DestCountry,
				dest_branch_id = model.DestBranchId,
				dest_branch_name = model.DestBranchName,
				note = model.Note,
				customer_id = model.CustomerId,
				customer_name = model.CustomerName,
				account_id = model.AccountId,
				ref_number = model.RefNumber,
				ref_code = model.RefCode,
				personal = model.Personal,
				personal_name = model.PersonalName,
				shipper_name = model.ShipperName,
				shipper_address = model.ShipperAddress,
				shipper_postal_code = model.ShipperPostalCode,
				shipper_city = model.ShipperCity,
				shipper_phone = model.ShipperPhone,
				shipper_saved = model.ShipperSaved,
				consignee_name = model.ConsigneeName,
				consignee_address = model.ConsigneeAddress,
				consignee_postal_code = model.ConsigneePostalCode,
				consignee_city = model.ConsigneeCity,
				consignee_phone = model.ConsigneePhone,
				consignee_saved = model.ConsigneeSaved,
				shipping_method_id = model.ShippingMethodId,
				service_type_id = model.ServiceTypeId,
				package_type_id = model.PackageTypeId,
				payment_method_id = model.PaymentMethodId,
				pricing_calc_type = model.PricingCalcType,
				collect_payment_method = model.CollectPaymentMethod,
				collect_customer_id = model.CollectCustomerId,
				collect_customer_name = model.CollectCustomerName,
				paid_coll = model.PaidColl,
				total_payment_coll = model.TotalPaymentColl,
				paid_collect = model.PaidCollect,
				total_payment_collect = model.TotalPaymentCollect,
				nature_of_goods = model.NatureOfGoods,
				dimension = model.Dimension,
				ttl_piece = model.TtlPiece,
				ttl_gross_weight = model.TtlGrossWeight,
				ttl_chargeable_weight = model.TtlChargeableWeight,
				pricing_plan_id = (int) model.PricingPlanId,
				tariff = model.Tariff,
				discount_percent = model.DiscountPercent,
				discount_fixed = model.DiscountFixed,
				discount_total = model.DiscountTotal,
				tariff_net = model.TariffNet,
				tariff_total = model.TariffTotal,
				before_tax_total = model.BeforeTaxTotal,
				vat = model.Vat,
				after_tax_total = model.AfterTaxTotal,
				handling_fee = model.HandlingFee,
				handling_fee_total = model.HandlingFeeTotal,
				surcharge_fee = model.SurchargeFee,
				admin_fee = model.AdminFee,
                packing_fee = model.PackingFee,
                other_fee = model.OtherFee,
                void_fee = model.VoidFee,
                goods_value = model.GoodsValue,
                insurance_fee = model.InsuranceFee,
				protection_type = model.ProtectionType,
				protection_value = model.ProtectionValue,
				protection_fee = model.ProtectionFee,
				extra_weight = model.ExtraWeight,
				extra_charge = model.ExtraCharge,
				extra_charge_total = model.ExtraChargeTotal,
                total = model.Total,
                currency_id = model.CurrencyId,
                currency = model.Currency,
				currency_rate = model.CurrencyRate,
				total_sales = model.TotalSales,
				cancelled = model.Cancelled,
				posted = model.Posted,
				voided = model.Voided,
				total_due = model.TotalDue,
                invoice_ref = model.InvoiceRef,
                invoice_id = model.InvoiceId,
                payment_receipt_number = model.PaymentReceiptNumber,
                invoiced = model.Invoiced,
				total_invoiced = model.TotalInvoiced,
				total_invoiced_ori = model.TotalInvoicedOri,
				paid = model.Paid,
				total_payment = model.TotalPayment,
				delivery_fee_min = model.DeliveryFeeMin,
				delivery_fee = model.DeliveryFee,
				delivery_fee_total = model.DeliveryFeeTotal,
				paid_delivery = model.PaidDelivery,
				total_payment_delivery = model.TotalPaymentDelivery,
				port_fee = model.PortFee,
				port_fee_before_tax = model.PortFeeBeforeTax,
				port_fee_vat = model.PortFeeVat,
				port_fee_total = model.PortFeeTotal,
				manifested = model.Manifested,
				pod_needed = model.PodNeeded,
				pod_sent = model.PodSent,
				pod_received = model.PodReceived,
				pod_returned = model.PodReturned,
				mc_percent = model.McPercent,
				mc_percent_total = model.McPercentTotal,
				mc_kg = model.McKg,
				mc_kg_total = model.McKgTotal,
				mc_total = model.McTotal,
				paid_mc = model.PaidMc,
                total_payment_mc = model.TotalPaymentMc,
                auto_number = model.AutoNumber,
                need_ra = model.NeedRa,
				acceptance_employee = model.AcceptanceEmployee,
				data_entry_employee = model.DataEntryEmployee,
				tracking_status_id = model.TrackingStatusId,
				upload_status = model.UploadStatus,
                franchise_id = model.FranchiseId,
                promo_id = model.PromoId,
                promo_code = model.PromoCode,
                pod_status = model.PODStatus,
				createddate = model.Createddate,
				createdby = model.Createdby,
                createdpc = model.CreatedPc,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
                modifiedpc = model.ModifiedPc
			};
        }

        private static void PopulateModelToNewEntity(shipment query, ShipmentModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
			query.date_process = model.DateProcess;
			query.code = model.Code;
			query.branch_id = model.BranchId;
			query.marketing_id = model.MarketingId;
			query.messenger_id = model.MessengerId;
			query.messenger_name = model.MessengerName;
            query.messenger_id2 = model.MessengerId2;
            query.messenger_name2 = model.MessengerName2;
			query.sales_type_id = model.SalesTypeId;
			query.city_id = model.CityId;
			query.city_name = model.CityName;
			query.dest_city_id = model.DestCityId;
			query.dest_city = model.DestCity;
			query.dest_country_id = model.DestCountryId;
			query.dest_country = model.DestCountry;
			query.dest_branch_id = model.DestBranchId;
			query.dest_branch_name = model.DestBranchName;
			query.note = model.Note;
			query.customer_id = model.CustomerId;
			query.customer_name = model.CustomerName;
			query.account_id = model.AccountId;
			query.ref_number = model.RefNumber;
			query.ref_code = model.RefCode;
			query.personal = model.Personal;
			query.personal_name = model.PersonalName;
			query.shipper_name = model.ShipperName;
			query.shipper_address = model.ShipperAddress;
			query.shipper_postal_code = model.ShipperPostalCode;
			query.shipper_city = model.ShipperCity;
			query.shipper_phone = model.ShipperPhone;
			query.shipper_saved = model.ShipperSaved;
			query.consignee_name = model.ConsigneeName;
			query.consignee_address = model.ConsigneeAddress;
			query.consignee_postal_code = model.ConsigneePostalCode;
			query.consignee_city = model.ConsigneeCity;
			query.consignee_phone = model.ConsigneePhone;
			query.consignee_saved = model.ConsigneeSaved;
			query.shipping_method_id = model.ShippingMethodId;
			query.service_type_id = model.ServiceTypeId;
			query.package_type_id = model.PackageTypeId;
			query.payment_method_id = model.PaymentMethodId;
			query.pricing_calc_type = model.PricingCalcType;
			query.collect_payment_method = model.CollectPaymentMethod;
			query.collect_customer_id = model.CollectCustomerId;
			query.collect_customer_name = model.CollectCustomerName;
			query.paid_coll = model.PaidColl;
			query.total_payment_coll = model.TotalPaymentColl;
			query.paid_collect = model.PaidCollect;
			query.total_payment_collect = model.TotalPaymentCollect;
			query.nature_of_goods = model.NatureOfGoods;
			query.dimension = model.Dimension;
			query.ttl_piece = model.TtlPiece;
			query.ttl_gross_weight = model.TtlGrossWeight;
			query.ttl_chargeable_weight = model.TtlChargeableWeight;
            // ReSharper disable once PossibleInvalidOperationException
            query.pricing_plan_id = (int) model.PricingPlanId;
			query.tariff = model.Tariff;
			query.discount_percent = model.DiscountPercent;
			query.discount_fixed = model.DiscountFixed;
			query.discount_total = model.DiscountTotal;
			query.tariff_net = model.TariffNet;
			query.tariff_total = model.TariffTotal;
			query.before_tax_total = model.BeforeTaxTotal;
			query.vat = model.Vat;
			query.after_tax_total = model.AfterTaxTotal;
			query.handling_fee = model.HandlingFee;
			query.handling_fee_total = model.HandlingFeeTotal;
			query.surcharge_fee = model.SurchargeFee;
			query.admin_fee = model.AdminFee;
            query.packing_fee = model.PackingFee;
            query.other_fee = model.OtherFee;
            query.void_fee = model.VoidFee;
            query.goods_value = model.GoodsValue;
            query.insurance_fee = model.InsuranceFee;
			query.protection_type = model.ProtectionType;
			query.protection_value = model.ProtectionValue;
			query.protection_fee = model.ProtectionFee;
			query.extra_weight = model.ExtraWeight;
			query.extra_charge = model.ExtraCharge;
			query.extra_charge_total = model.ExtraChargeTotal;
            query.total = model.Total;
            query.currency_id = model.CurrencyId;
            query.currency = model.Currency;
			query.currency_rate = model.CurrencyRate;
			query.total_sales = model.TotalSales;
			query.cancelled = model.Cancelled;
			query.posted = model.Posted;
			query.voided = model.Voided;
			query.total_due = model.TotalDue;
            query.invoice_ref = model.InvoiceRef;
            query.invoice_id = model.InvoiceId;
            query.payment_receipt_number = model.PaymentReceiptNumber;
            query.invoiced = model.Invoiced;
			query.total_invoiced = model.TotalInvoiced;
			query.total_invoiced_ori = model.TotalInvoicedOri;
			query.paid = model.Paid;
			query.total_payment = model.TotalPayment;
			query.delivery_fee_min = model.DeliveryFeeMin;
			query.delivery_fee = model.DeliveryFee;
			query.delivery_fee_total = model.DeliveryFeeTotal;
			query.paid_delivery = model.PaidDelivery;
			query.total_payment_delivery = model.TotalPaymentDelivery;
			query.port_fee = model.PortFee;
			query.port_fee_before_tax = model.PortFeeBeforeTax;
			query.port_fee_vat = model.PortFeeVat;
			query.port_fee_total = model.PortFeeTotal;
			query.manifested = model.Manifested;
			query.pod_needed = model.PodNeeded;
			query.pod_sent = model.PodSent;
			query.pod_received = model.PodReceived;
			query.pod_returned = model.PodReturned;
			query.mc_percent = model.McPercent;
			query.mc_percent_total = model.McPercentTotal;
			query.mc_kg = model.McKg;
			query.mc_kg_total = model.McKgTotal;
			query.mc_total = model.McTotal;
			query.paid_mc = model.PaidMc;
            query.total_payment_mc = model.TotalPaymentMc;
            query.auto_number = model.AutoNumber;
            query.need_ra = model.NeedRa;
			query.acceptance_employee = model.AcceptanceEmployee;
			query.data_entry_employee = model.DataEntryEmployee;
			query.tracking_status_id = model.TrackingStatusId;
			query.upload_status = model.UploadStatus;
            query.franchise_id = model.FranchiseId;
            query.promo_id = model.PromoId;
            query.promo_code = model.PromoCode;
            query.pod_status = model.PODStatus;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
            query.createdpc = model.CreatedPc;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
            query.modifiedpc = model.ModifiedPc;
		}
        
        private static ShipmentModel PopulateEntityToNewModel(shipment item)
        {
            var shipment = new ShipmentModel
            {
                Id = item.id,
                Rowstatus = item.rowstatus,
                Rowversion = item.rowversion,
                DateProcess = item.date_process,
                Code = item.code,
                BranchId = item.branch_id
            };

            if (item.marketing_id != null) shipment.MarketingId = (int) item.marketing_id;
            shipment.MessengerId = item.messenger_id;
            shipment.MessengerName = item.messenger_name;
            shipment.MessengerId2 = item.messenger_id2;
            shipment.MessengerName2 = item.messenger_name2;

            if (item.sales_type_id != null) shipment.SalesTypeId = (int) item.sales_type_id;
            shipment.CityId = item.city_id;
            shipment.CityName = item.city_name;
            shipment.DestCityId = item.dest_city_id;
            shipment.DestCity = item.dest_city;
            shipment.DestCountryId = item.dest_country_id;
            shipment.DestCountry = item.dest_country;
            shipment.DestBranchId = item.dest_branch_id;
            shipment.DestBranchName = item.dest_branch_name;
            shipment.Note = item.note;
            shipment.CustomerId = item.customer_id;
            shipment.CustomerName = item.customer_name;

            if (item.account_id != null) shipment.AccountId = (int) item.account_id;
            shipment.RefNumber = item.ref_number;
            shipment.RefCode = item.ref_code;
            shipment.Personal = item.personal;
            shipment.PersonalName = item.personal_name;
            shipment.ShipperName = item.shipper_name;
            shipment.ShipperAddress = item.shipper_address;
            shipment.ShipperPostalCode = item.shipper_postal_code;
            shipment.ShipperCity = item.shipper_city;
            shipment.ShipperPhone = item.shipper_phone;
            shipment.ShipperSaved = item.shipper_saved;
            shipment.ConsigneeName = item.consignee_name;
            shipment.ConsigneeAddress = item.consignee_address;
            shipment.ConsigneePostalCode = item.consignee_postal_code;
            shipment.ConsigneeCity = item.consignee_city;
            shipment.ConsigneePhone = item.consignee_phone;

            if (item.consignee_saved != null) shipment.ConsigneeSaved = (bool) item.consignee_saved;

            if (item.shipping_method_id != null) shipment.ShippingMethodId = (int) item.shipping_method_id;
            shipment.ServiceTypeId = item.service_type_id;
            shipment.PackageTypeId = item.package_type_id;
            shipment.PaymentMethodId = item.payment_method_id;
            shipment.PricingCalcType = item.pricing_calc_type;
            shipment.CollectPaymentMethod = item.collect_payment_method;
            shipment.CollectCustomerId = item.collect_customer_id;
            shipment.CollectCustomerName = item.collect_customer_name;
            shipment.PaidColl = item.paid_coll;
            shipment.TotalPaymentColl = item.total_payment_coll;
            shipment.PaidCollect = item.paid_collect;
            shipment.TotalPaymentCollect = item.total_payment_collect;
            shipment.NatureOfGoods = item.nature_of_goods;
            shipment.Dimension = item.dimension;
            shipment.TtlPiece = item.ttl_piece;
            shipment.TtlGrossWeight = item.ttl_gross_weight;
            shipment.TtlChargeableWeight = item.ttl_chargeable_weight;
            
            shipment.PricingPlanId = item.pricing_plan_id;
            shipment.Tariff = item.tariff;
            shipment.DiscountPercent = item.discount_percent;
            shipment.DiscountTotal = item.discount_total;
            shipment.TariffNet = item.tariff_net;
            shipment.TariffTotal = item.tariff_total;
            shipment.BeforeTaxTotal = item.before_tax_total;
            shipment.Vat = item.vat;
            shipment.AfterTaxTotal = item.after_tax_total;
            shipment.HandlingFee = item.handling_fee;
            shipment.HandlingFeeTotal = item.handling_fee_total;
            shipment.SurchargeFee = item.surcharge_fee;
            shipment.AdminFee = item.admin_fee;
            shipment.PackingFee = item.packing_fee;
            shipment.OtherFee = item.other_fee;
            shipment.VoidFee = item.void_fee;
            shipment.GoodsValue = item.goods_value;
            shipment.InsuranceFee = item.insurance_fee;
            shipment.ProtectionType = item.protection_type;
            shipment.ProtectionValue = item.protection_value;
            shipment.ProtectionFee = item.protection_fee;
            shipment.ExtraWeight = item.extra_weight;
            shipment.ExtraCharge = item.extra_charge;
            shipment.ExtraChargeTotal = item.extra_charge_total;
            shipment.Total = item.total;
            shipment.CurrencyId = item.currency_id;
            shipment.Currency = item.currency;
            shipment.CurrencyRate = item.currency_rate;
            shipment.TotalSales = item.total_sales;
            shipment.Cancelled = item.cancelled;
            shipment.Posted = item.posted;
            shipment.Voided = item.voided;
            shipment.TotalDue = item.total_due;
            shipment.InvoiceRef = item.invoice_ref;
            shipment.InvoiceId = item.invoice_id;
            shipment.PaymentReceiptNumber = item.payment_receipt_number;
            shipment.Invoiced = item.invoiced;
            shipment.TotalInvoiced = item.total_invoiced;
            shipment.TotalInvoicedOri = item.total_invoiced_ori;
            shipment.Paid = item.paid;
            shipment.TotalPayment = item.total_payment;
            shipment.DeliveryFeeMin = item.delivery_fee_min;
            shipment.DeliveryFee = item.delivery_fee;
            shipment.DeliveryFeeTotal = item.delivery_fee_total;
            shipment.PaidDelivery = item.paid_delivery;
            shipment.TotalPaymentDelivery = item.total_payment_delivery;
            shipment.PortFee = item.port_fee;
            shipment.PortFeeBeforeTax = item.port_fee_before_tax;
            shipment.PortFeeVat = item.port_fee_vat;
            shipment.PortFeeTotal = item.port_fee_total;
            shipment.Manifested = item.manifested;
            shipment.PodNeeded = item.pod_needed;
            shipment.PodSent = item.pod_sent;
            shipment.PodReceived = item.pod_received;
            shipment.PodReturned = item.pod_returned;
            shipment.McPercent = item.mc_percent;
            shipment.McPercentTotal = item.mc_percent_total;
            shipment.McKg = item.mc_kg;
            shipment.McKgTotal = item.mc_kg_total;
            shipment.McTotal = item.mc_total;
            shipment.PaidMc = item.paid_mc;
            shipment.TotalPaymentMc = item.total_payment_mc;
            shipment.AutoNumber = item.auto_number;
            shipment.NeedRa = item.need_ra;
            shipment.AcceptanceEmployee = item.acceptance_employee;
            shipment.DataEntryEmployee = item.data_entry_employee;
            // ReSharper disable once PossibleInvalidOperationException
            if (item.tracking_status_id != null) shipment.TrackingStatusId = (int) item.tracking_status_id;
            shipment.FranchiseId = item.franchise_id;
            shipment.PromoId = item.promo_id;
            shipment.PromoCode = item.promo_code;
            shipment.PODStatus = item.pod_status;
            shipment.UploadStatus = item.upload_status;
            shipment.Createddate = item.createddate;
            shipment.Createdby = item.createdby;
            shipment.CreatedPc = item.createdpc;
            shipment.Modifieddate = item.modifieddate;
            shipment.Modifiedby = item.modifiedby;
            shipment.ModifiedPc = item.modifiedpc;

            return shipment;
        }

        public override IEnumerable<T> Get<T>(params IListParameter[] parameter)
		{
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.shipments select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		}

        public IEnumerable<ShipmentModel> CollectOutList(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from model in Entities.shipments select model).Where(whereterm, ListValue.ToArray()).AsQueryable();

            if (query == null)
                throw new Exception(MessageEntityNotFound);

            var qry = (from model in query
                       join c in
                           (from c in Entities.payment_in_collect_out_detail where c.rowstatus.Equals(true) select c) on model.code equals c.invoice_code
                       join h in
                           (from h in Entities.payment_in_collect_out where h.rowstatus.Equals(true) select h) on c.payment_in_collect_out_id equals h.id
                       join p in
                           (from p in Entities.payment_type where p.rowstatus.Equals(true) select p) on h.payment_type_id equals p.id
                       select new
                       {
                           model.id,
                           model.rowstatus,
                           model.rowversion,
                           c.date_process,
                           model.code,
                           model.branch_id,
                           model.marketing_id,
                           model.messenger_id,
                           model.messenger_name,
                           model.messenger_id2,
                           model.messenger_name2,
                           model.sales_type_id,
                           model.city_id,
                           model.city_name,
                           model.dest_city_id,
                           model.dest_city,
                           model.dest_country_id,
                           model.dest_country,
                           model.dest_branch_id,
                           model.dest_branch_name,
                           model.note,
                           model.customer_id,
                           model.customer_name,
                           model.account_id,
                           model.ref_number,
                           model.ref_code,
                           model.personal,
                           model.personal_name,
                           model.shipper_name,
                           model.shipper_address,
                           model.shipper_postal_code,
                           model.shipper_city,
                           model.shipper_phone,
                           model.shipper_saved,
                           model.consignee_name,
                           model.consignee_address,
                           model.consignee_postal_code,
                           model.consignee_city,
                           model.consignee_phone,
                           model.consignee_saved,
                           model.shipping_method_id,
                           model.service_type_id,
                           model.package_type_id,
                           model.payment_method_id,
                           model.pricing_calc_type,
                           collect_payment_method = p.name, //c.collect_payment_method,
                           //collect_customer_id = c.collect_customer_id,
                           //collect_customer_name = c.collect_customer_name,
                           model.paid_coll,
                           model.total_payment_coll,
                           model.paid_collect,
                           model.total_payment_collect,
                           model.nature_of_goods,
                           model.dimension,
                           model.ttl_piece,
                           model.ttl_gross_weight,
                           model.ttl_chargeable_weight,
                           model.pricing_plan_id,
                           model.tariff,
                           model.discount_percent,
                           model.discount_fixed,
                           model.discount_total,
                           model.tariff_net,
                           model.tariff_total,
                           model.before_tax_total,
                           model.vat,
                           model.after_tax_total,
                           model.handling_fee,
                           model.handling_fee_total,
                           model.surcharge_fee,
                           model.admin_fee,
                           model.packing_fee,
                           model.other_fee,
                           model.void_fee,
                           model.goods_value,
                           model.insurance_fee,
                           model.protection_type,
                           model.protection_value,
                           model.protection_fee,
                           model.extra_weight,
                           model.extra_charge,
                           model.extra_charge_total,
                           model.total,
                           model.currency_id,
                           model.currency,
                           model.currency_rate,
                           model.total_sales,
                           model.cancelled,
                           model.posted,
                           model.voided,
                           model.total_due,
                           model.invoice_ref,
                           model.invoice_id,
                           model.payment_receipt_number,
                           model.invoiced,
                           model.total_invoiced,
                           model.total_invoiced_ori,
                           model.paid,
                           model.total_payment,
                           model.delivery_fee_min,
                           model.delivery_fee,
                           model.delivery_fee_total,
                           model.paid_delivery,
                           model.total_payment_delivery,
                           model.port_fee,
                           model.port_fee_before_tax,
                           model.port_fee_vat,
                           model.port_fee_total,
                           model.manifested,
                           model.pod_needed,
                           model.pod_sent,
                           model.pod_received,
                           model.pod_returned,
                           model.mc_percent,
                           model.mc_percent_total,
                           model.mc_kg,
                           model.mc_kg_total,
                           model.mc_total,
                           model.paid_mc,
                           model.total_payment_mc,
                           model.auto_number,
                           model.need_ra,
                           model.acceptance_employee,
                           model.data_entry_employee,
                           model.tracking_status_id,
                           model.upload_status,
                           model.franchise_id,
                           model.promo_id,
                           model.promo_code,
                           model.pod_status,
                           model.createddate,
                           model.createdby,
                           model.createdpc,
                           model.modifieddate,
                           model.modifiedby,
                           model.modifiedpc
                       }).ToList();

            var x = EnumStateChange.Select.ToString();
            var obj = (IEnumerable<ShipmentModel>)(from item in qry
                                                   join e in Entities.payment_method on item.payment_method_id equals e.id
                                                   join f in Entities.package_type on item.package_type_id equals f.id
                                                   join t in Entities.tracking_status on item.tracking_status_id equals t.id into tx
                                                   from t in tx.DefaultIfEmpty()
                                                   join b in Entities.branches on item.branch_id equals b.id
                                                   select new ShipmentModel
                                                   {
                                                       Id = item.id,
                                                       Rowstatus = item.rowstatus,
                                                       Rowversion = item.rowversion,
                                                       DateProcess = item.date_process,
                                                       Code = item.code,
                                                       BranchId = item.branch_id,
                                                       BranchName = b.name,
                                                       MarketingId = (int)item.marketing_id,
                                                       MessengerId = item.messenger_id,
                                                       MessengerName = item.messenger_name,
                                                       MessengerId2 = item.messenger_id2,
                                                       MessengerName2 = item.messenger_name2,
                                                       SalesTypeId = (int)item.sales_type_id,
                                                       CityId = item.city_id,
                                                       CityName = item.city_name,
                                                       DestCityId = item.dest_city_id,
                                                       DestCity = item.dest_city,
                                                       DestCountryId = item.dest_country_id,
                                                       DestCountry = item.dest_country,
                                                       DestBranchId = item.dest_branch_id,
                                                       DestBranchName = item.dest_branch_name,
                                                       Note = item.note,
                                                       CustomerId = item.customer_id,
                                                       CustomerName = item.customer_name,
                                                       AccountId = (int)item.account_id,
                                                       RefNumber = item.ref_number,
                                                       RefCode = item.ref_code,
                                                       Personal = item.personal,
                                                       PersonalName = item.personal_name,
                                                       ShipperName = item.shipper_name,
                                                       ShipperAddress = item.shipper_address,
                                                       ShipperPostalCode = item.shipper_postal_code,
                                                       ShipperCity = item.shipper_city,
                                                       ShipperPhone = item.shipper_phone,
                                                       ShipperSaved = item.shipper_saved,
                                                       ConsigneeName = item.consignee_name,
                                                       ConsigneeAddress = item.consignee_address,
                                                       ConsigneePostalCode = item.consignee_postal_code,
                                                       ConsigneeCity = item.consignee_city,
                                                       ConsigneePhone = item.consignee_phone,
                                                       ConsigneeSaved = (bool)item.consignee_saved,
                                                       ShippingMethodId = (int)item.shipping_method_id,
                                                       ServiceTypeId = item.service_type_id,
                                                       PackageTypeId = item.package_type_id,
                                                       PackageType = f.name,
                                                       PaymentMethodId = item.payment_method_id,
                                                       PaymentMethod = e.name,
                                                       PricingCalcType = item.pricing_calc_type,
                                                       CollectPaymentMethod = item.collect_payment_method,
                                                       //CollectCustomerId = item.collect_customer_id,
                                                       //CollectCustomerName = item.collect_customer_name,
                                                       PaidColl = item.paid_coll,
                                                       TotalPaymentColl = item.total_payment_coll,
                                                       PaidCollect = item.paid_collect,
                                                       TotalPaymentCollect = item.total_payment_collect,
                                                       NatureOfGoods = item.nature_of_goods,
                                                       Dimension = item.dimension,
                                                       TtlPiece = item.ttl_piece,
                                                       TtlGrossWeight = item.ttl_gross_weight,
                                                       TtlChargeableWeight = item.ttl_chargeable_weight,
                                                       PricingPlanId = item.pricing_plan_id,
                                                       Tariff = item.tariff,
                                                       DiscountPercent = item.discount_percent,
                                                       DiscountTotal = item.discount_total,
                                                       TariffNet = item.tariff_net,
                                                       TariffTotal = item.tariff_total,
                                                       BeforeTaxTotal = item.before_tax_total,
                                                       Vat = item.vat,
                                                       AfterTaxTotal = item.after_tax_total,
                                                       HandlingFee = item.handling_fee,
                                                       HandlingFeeTotal = item.handling_fee_total,
                                                       SurchargeFee = item.surcharge_fee,
                                                       AdminFee = item.admin_fee,
                                                       PackingFee = item.packing_fee,
                                                       OtherFee = item.other_fee,
                                                       VoidFee = item.void_fee,
                                                       GoodsValue = item.goods_value,
                                                       InsuranceFee = item.insurance_fee,
                                                       ProtectionType = item.protection_type,
                                                       ProtectionValue = item.protection_value,
                                                       ProtectionFee = item.protection_fee,
                                                       ExtraWeight = item.extra_weight,
                                                       ExtraCharge = item.extra_charge,
                                                       ExtraChargeTotal = item.extra_charge_total,
                                                       Total = item.total,
                                                       CurrencyId = item.currency_id,
                                                       Currency = item.currency,
                                                       CurrencyRate = item.currency_rate,
                                                       TotalSales = item.total_sales,
                                                       Cancelled = item.cancelled,
                                                       Posted = item.posted,
                                                       Voided = item.voided,
                                                       TotalDue = item.total_due,
                                                       InvoiceRef = item.invoice_ref,
                                                       InvoiceId = item.invoice_id,
                                                       PaymentReceiptNumber = item.payment_receipt_number,
                                                       Invoiced = item.invoiced,
                                                       TotalInvoiced = item.total_invoiced,
                                                       TotalInvoicedOri = item.total_invoiced_ori,
                                                       Paid = item.paid,
                                                       TotalPayment = item.total_payment,
                                                       DeliveryFeeMin = item.delivery_fee_min,
                                                       DeliveryFee = item.delivery_fee,
                                                       DeliveryFeeTotal = item.delivery_fee_total,
                                                       PaidDelivery = item.paid_delivery,
                                                       TotalPaymentDelivery = item.total_payment_delivery,
                                                       PortFee = item.port_fee,
                                                       PortFeeBeforeTax = item.port_fee_before_tax,
                                                       PortFeeVat = item.port_fee_vat,
                                                       PortFeeTotal = item.port_fee_total,
                                                       Manifested = item.manifested,
                                                       PodNeeded = item.pod_needed,
                                                       PodSent = item.pod_sent,
                                                       PodReceived = item.pod_received,
                                                       PodReturned = item.pod_returned,
                                                       McPercent = item.mc_percent,
                                                       McPercentTotal = item.mc_percent_total,
                                                       McKg = item.mc_kg,
                                                       McKgTotal = item.mc_kg_total,
                                                       McTotal = item.mc_total,
                                                       PaidMc = item.paid_mc,
                                                       TotalPaymentMc = item.total_payment_mc,
                                                       AutoNumber = item.auto_number,
                                                       NeedRa = item.need_ra,
                                                       AcceptanceEmployee = item.acceptance_employee,
                                                       DataEntryEmployee = item.data_entry_employee,
                                                       TrackingStatusId = item.tracking_status_id != null ? (int)item.tracking_status_id : 0,
                                                       TrackingStatus = t != null ? t.code : "",
                                                       UploadStatus = item.upload_status,
                                                       FranchiseId = item.franchise_id,
                                                       PromoId = item.promo_id,
                                                       PromoCode = item.promo_code,
                                                       PODStatus = item.pod_status,
                                                       Createddate = item.createddate,
                                                       Createdby = item.createdby,
                                                       CreatedPc = item.createdpc,
                                                       Modifieddate = item.modifieddate,
                                                       Modifiedby = item.modifiedby,
                                                       ModifiedPc = item.modifiedpc,
                                                       StateChange2 = x
                                                   }).AsQueryable();

            return obj.ToList();
        }

        public IEnumerable<ShipmentModel> CollectInList(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from model in Entities.shipments select model).Where(whereterm, ListValue.ToArray()).AsQueryable();

            if (query == null)
                throw new Exception(MessageEntityNotFound);

            var qry = (from model in query
                       join c in (
                        from c in Entities.payment_in_collect_in_detail where c.rowstatus.Equals(true) select c
                       ) on model.id equals c.invoice_id into cx
                       from c in cx.DefaultIfEmpty()
                       select new
                       {
                           model.id,
                           model.rowstatus,
                           model.rowversion,
                           model.date_process,
                           model.code,
                           model.branch_id,
                           model.marketing_id,
                           model.messenger_id,
                           model.messenger_name,
                           model.messenger_id2,
                           model.messenger_name2,
                           model.sales_type_id,
                           model.city_id,
                           model.city_name,
                           model.dest_city_id,
                           model.dest_city,
                           model.dest_country_id,
                           model.dest_country,
                           model.dest_branch_id,
                           model.dest_branch_name,
                           model.note,
                           model.customer_id,
                           model.customer_name,
                           model.account_id,
                           model.ref_number,
                           model.ref_code,
                           model.personal,
                           model.personal_name,
                           model.shipper_name,
                           model.shipper_address,
                           model.shipper_postal_code,
                           model.shipper_city,
                           model.shipper_phone,
                           model.shipper_saved,
                           model.consignee_name,
                           model.consignee_address,
                           model.consignee_postal_code,
                           model.consignee_city,
                           model.consignee_phone,
                           model.consignee_saved,
                           model.shipping_method_id,
                           model.service_type_id,
                           model.package_type_id,
                           model.payment_method_id,
                           model.pricing_calc_type,
                           collect_payment_method = c != null ? c.collect_payment_method : null,
                           collect_customer_id = c != null ? c.collect_customer_id : null,
                           collect_customer_name = c != null ? c.collect_customer_name : null,
                           model.paid_coll,
                           model.total_payment_coll,
                           model.paid_collect,
                           model.total_payment_collect,
                           model.nature_of_goods,
                           model.dimension,
                           model.ttl_piece,
                           model.ttl_gross_weight,
                           model.ttl_chargeable_weight,
                           model.pricing_plan_id,
                           model.tariff,
                           model.discount_percent,
                           model.discount_fixed,
                           model.discount_total,
                           model.tariff_net,
                           model.tariff_total,
                           model.before_tax_total,
                           model.vat,
                           model.after_tax_total,
                           model.handling_fee,
                           model.handling_fee_total,
                           model.surcharge_fee,
                           model.admin_fee,
                           model.packing_fee,
                           model.other_fee,
                           model.void_fee,
                           model.goods_value,
                           model.insurance_fee,
                           model.protection_type,
                           model.protection_value,
                           model.protection_fee,
                           model.extra_weight,
                           model.extra_charge,
                           model.extra_charge_total,
                           model.total,
                           model.currency_id,
                           model.currency,
                           model.currency_rate,
                           model.total_sales,
                           model.cancelled,
                           model.posted,
                           model.voided,
                           model.total_due,
                           model.invoice_ref,
                           model.invoice_id,
                           model.payment_receipt_number,
                           model.invoiced,
                           model.total_invoiced,
                           model.total_invoiced_ori,
                           model.paid,
                           model.total_payment,
                           model.delivery_fee_min,
                           model.delivery_fee,
                           model.delivery_fee_total,
                           model.paid_delivery,
                           model.total_payment_delivery,
                           model.port_fee,
                           model.port_fee_before_tax,
                           model.port_fee_vat,
                           model.port_fee_total,
                           model.manifested,
                           model.pod_needed,
                           model.pod_sent,
                           model.pod_received,
                           model.pod_returned,
                           model.mc_percent,
                           model.mc_percent_total,
                           model.mc_kg,
                           model.mc_kg_total,
                           model.mc_total,
                           model.paid_mc,
                           model.total_payment_mc,
                           model.auto_number,
                           model.need_ra,
                           model.acceptance_employee,
                           model.data_entry_employee,
                           model.tracking_status_id,
                           model.upload_status,
                           model.franchise_id,
                           model.promo_id,
                           model.promo_code,
                           model.pod_status,
                           model.createddate,
                           model.createdby,
                           model.createdpc,
                           model.modifieddate,
                           model.modifiedby,
                           model.modifiedpc
                       }).ToList();

            var x = EnumStateChange.Select.ToString();
            var obj = (IEnumerable<ShipmentModel>)(from item in qry
                                                   join e in Entities.payment_method on item.payment_method_id equals e.id
                                                   join f in Entities.package_type on item.package_type_id equals f.id
                                                   join t in Entities.tracking_status on item.tracking_status_id equals t.id into tx
                                                   from t in tx.DefaultIfEmpty()
                                                   join b in Entities.branches on item.branch_id equals b.id
                                       select new ShipmentModel
                                       {
                                           Id = item.id,
                                           Rowstatus = item.rowstatus,
                                           Rowversion = item.rowversion,
                                           DateProcess = item.date_process,
                                           Code = item.code,
                                           BranchId = item.branch_id,
                                           BranchName = b.name,
                                           MarketingId = (int)item.marketing_id,
                                           MessengerId = item.messenger_id,
                                           MessengerName = item.messenger_name,
                                           MessengerId2 = item.messenger_id2,
                                           MessengerName2 = item.messenger_name2,
                                           SalesTypeId = (int)item.sales_type_id,
                                           CityId = item.city_id,
                                           CityName = item.city_name,
                                           DestCityId = item.dest_city_id,
                                           DestCity = item.dest_city,
                                           DestCountryId = item.dest_country_id,
                                           DestCountry = item.dest_country,
                                           DestBranchId = item.dest_branch_id,
                                           DestBranchName = item.dest_branch_name,
                                           Note = item.note,
                                           CustomerId = item.customer_id,
                                           CustomerName = item.customer_name,
                                           AccountId = (int)item.account_id,
                                           RefNumber = item.ref_number,
                                           RefCode = item.ref_code,
                                           Personal = item.personal,
                                           PersonalName = item.personal_name,
                                           ShipperName = item.shipper_name,
                                           ShipperAddress = item.shipper_address,
                                           ShipperPostalCode = item.shipper_postal_code,
                                           ShipperCity = item.shipper_city,
                                           ShipperPhone = item.shipper_phone,
                                           ShipperSaved = item.shipper_saved,
                                           ConsigneeName = item.consignee_name,
                                           ConsigneeAddress = item.consignee_address,
                                           ConsigneePostalCode = item.consignee_postal_code,
                                           ConsigneeCity = item.consignee_city,
                                           ConsigneePhone = item.consignee_phone,
                                           ConsigneeSaved = (bool)item.consignee_saved,
                                           ShippingMethodId = (int)item.shipping_method_id,
                                           ServiceTypeId = item.service_type_id,
                                           PackageTypeId = item.package_type_id,
                                           PackageType = f.name,
                                           PaymentMethodId = item.payment_method_id,
                                           PaymentMethod = e.name,
                                           PricingCalcType = item.pricing_calc_type,
                                           CollectPaymentMethod = item.collect_payment_method,
                                           CollectCustomerId = item.collect_customer_id,
                                           CollectCustomerName = item.collect_customer_name,
                                           PaidColl = item.paid_coll,
                                           TotalPaymentColl = item.total_payment_coll,
                                           PaidCollect = item.paid_collect,
                                           TotalPaymentCollect = item.total_payment_collect,
                                           NatureOfGoods = item.nature_of_goods,
                                           Dimension = item.dimension,
                                           TtlPiece = item.ttl_piece,
                                           TtlGrossWeight = item.ttl_gross_weight,
                                           TtlChargeableWeight = item.ttl_chargeable_weight,
                                           PricingPlanId = item.pricing_plan_id,
                                           Tariff = item.tariff,
                                           DiscountPercent = item.discount_percent,
                                           DiscountTotal = item.discount_total,
                                           TariffNet = item.tariff_net,
                                           TariffTotal = item.tariff_total,
                                           BeforeTaxTotal = item.before_tax_total,
                                           Vat = item.vat,
                                           AfterTaxTotal = item.after_tax_total,
                                           HandlingFee = item.handling_fee,
                                           HandlingFeeTotal = item.handling_fee_total,
                                           SurchargeFee = item.surcharge_fee,
                                           AdminFee = item.admin_fee,
                                           PackingFee = item.packing_fee,
                                           OtherFee = item.other_fee,
                                           VoidFee = item.void_fee,
                                           GoodsValue = item.goods_value,
                                           InsuranceFee = item.insurance_fee,
                                           ProtectionType = item.protection_type,
                                           ProtectionValue = item.protection_value,
                                           ProtectionFee = item.protection_fee,
                                           ExtraWeight = item.extra_weight,
                                           ExtraCharge = item.extra_charge,
                                           ExtraChargeTotal = item.extra_charge_total,
                                           Total = item.total,
                                           CurrencyId = item.currency_id,
                                           Currency = item.currency,
                                           CurrencyRate = item.currency_rate,
                                           TotalSales = item.total_sales,
                                           Cancelled = item.cancelled,
                                           Posted = item.posted,
                                           Voided = item.voided,
                                           TotalDue = item.total_due,
                                           InvoiceRef = item.invoice_ref,
                                           InvoiceId = item.invoice_id,
                                           PaymentReceiptNumber = item.payment_receipt_number,
                                           Invoiced = item.invoiced,
                                           TotalInvoiced = item.total_invoiced,
                                           TotalInvoicedOri = item.total_invoiced_ori,
                                           Paid = item.paid,
                                           TotalPayment = item.total_payment,
                                           DeliveryFeeMin = item.delivery_fee_min,
                                           DeliveryFee = item.delivery_fee,
                                           DeliveryFeeTotal = item.delivery_fee_total,
                                           PaidDelivery = item.paid_delivery,
                                           TotalPaymentDelivery = item.total_payment_delivery,
                                           PortFee = item.port_fee,
                                           PortFeeBeforeTax = item.port_fee_before_tax,
                                           PortFeeVat = item.port_fee_vat,
                                           PortFeeTotal = item.port_fee_total,
                                           Manifested = item.manifested,
                                           PodNeeded = item.pod_needed,
                                           PodSent = item.pod_sent,
                                           PodReceived = item.pod_received,
                                           PodReturned = item.pod_returned,
                                           McPercent = item.mc_percent,
                                           McPercentTotal = item.mc_percent_total,
                                           McKg = item.mc_kg,
                                           McKgTotal = item.mc_kg_total,
                                           McTotal = item.mc_total,
                                           PaidMc = item.paid_mc,
                                           TotalPaymentMc = item.total_payment_mc,
                                           AutoNumber = item.auto_number,
                                           NeedRa = item.need_ra,
                                           AcceptanceEmployee = item.acceptance_employee,
                                           DataEntryEmployee = item.data_entry_employee,
                                           TrackingStatusId = item.tracking_status_id != null ? (int)item.tracking_status_id : 0,
                                           TrackingStatus = t != null ? t.code : "",
                                           UploadStatus = item.upload_status,
                                           FranchiseId = item.franchise_id,
                                           PromoId = item.promo_id,
                                           PromoCode = item.promo_code,
                                           PODStatus = item.pod_status,
                                           Createddate = item.createddate,
                                           Createdby = item.createdby,
                                           CreatedPc = item.createdpc,
                                           Modifieddate = item.modifieddate,
                                           Modifiedby = item.modifiedby,
                                           ModifiedPc = item.modifiedpc,
                                           StateChange2 = x
                                       }).AsQueryable();

            return obj.ToList();
        }

        public IEnumerable<ShipmentModel> GetCollectProcess(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.shipments select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            
            var obj = (from item in query
                       join b in Entities.branches on item.branch_id equals b.id
                       select new ShipmentModel
                        {
                            Id = item.id,
                            Rowstatus = item.rowstatus,
                            Rowversion = item.rowversion,
                            DateProcess = item.date_process,
                            Code = item.code,
                            BranchId = item.branch_id,
                            BranchName = b.name,
                            MarketingId = (int) item.marketing_id,
                            MessengerId = item.messenger_id,
                            MessengerName = item.messenger_name,
                            MessengerId2 = item.messenger_id2,
                            MessengerName2 = item.messenger_name2,
                            SalesTypeId = (int) item.sales_type_id,
                            CityId = item.city_id,
                            CityName = item.city_name,
                            DestCityId = item.dest_city_id,
                            DestCity = item.dest_city,
                            DestCountryId = item.dest_country_id,
                            DestCountry = item.dest_country,
                            DestBranchId = item.dest_branch_id,
                            DestBranchName = item.dest_branch_name,
                            Note = item.note,
                            CustomerId = item.customer_id,
                            CustomerName = item.customer_name,
                            AccountId = (int) item.account_id,
                            RefNumber = item.ref_number,
                            RefCode = item.ref_code,
                            Personal = item.personal,
                            PersonalName = item.personal_name,
                            ShipperName = item.shipper_name,
                            ShipperAddress = item.shipper_address,
                            ShipperPostalCode = item.shipper_postal_code,
                            ShipperCity = item.shipper_city,
                            ShipperPhone = item.shipper_phone,
                            ShipperSaved = item.shipper_saved,
                            ConsigneeName = item.consignee_name,
                            ConsigneeAddress = item.consignee_address,
                            ConsigneePostalCode = item.consignee_postal_code,
                            ConsigneeCity = item.consignee_city,
                            ConsigneePhone = item.consignee_phone,
                            ConsigneeSaved = (bool) item.consignee_saved,
                            ShippingMethodId = (int) item.shipping_method_id,
                            ServiceTypeId = item.service_type_id,
                            PackageTypeId = item.package_type_id,
                            PaymentMethodId = item.payment_method_id,
                            PricingCalcType = item.pricing_calc_type,
                            CollectPaymentMethod = item.collect_payment_method,
                            CollectCustomerId = item.collect_customer_id,
                            CollectCustomerName = item.collect_customer_name,
                            PaidColl = item.paid_coll,
                            TotalPaymentColl = item.total_payment_coll,
                            PaidCollect = item.paid_collect,
                            TotalPaymentCollect = item.total_payment_collect,
                            NatureOfGoods = item.nature_of_goods,
                            Dimension = item.dimension,
                            TtlPiece = item.ttl_piece,
                            TtlGrossWeight = item.ttl_gross_weight,
                            TtlChargeableWeight = item.ttl_chargeable_weight,
                            PricingPlanId = item.pricing_plan_id,
                            Tariff = item.tariff,
                            DiscountPercent = item.discount_percent,
                            DiscountTotal = item.discount_total,
                            TariffNet = item.tariff_net,
                            TariffTotal = item.tariff_total,
                            BeforeTaxTotal = item.before_tax_total,
                            Vat = item.vat,
                            AfterTaxTotal = item.after_tax_total,
                            HandlingFee = item.handling_fee,
                            HandlingFeeTotal = item.handling_fee_total,
                            SurchargeFee = item.surcharge_fee,
                            AdminFee = item.admin_fee,
                            PackingFee = item.packing_fee,
                            OtherFee = item.other_fee,
                            VoidFee = item.void_fee,
                            GoodsValue = item.goods_value,
                            InsuranceFee = item.insurance_fee,
                            ProtectionType = item.protection_type,
                            ProtectionValue = item.protection_value,
                            ProtectionFee = item.protection_fee,
                            ExtraWeight = item.extra_weight,
                            ExtraCharge = item.extra_charge,
                            ExtraChargeTotal = item.extra_charge_total,
                            Total = item.total,
                            CurrencyId = item.currency_id,
                            Currency = item.currency,
                            CurrencyRate = item.currency_rate,
                            TotalSales = item.total_sales,
                            Cancelled = item.cancelled,
                            Posted = item.posted,
                            Voided = item.voided,
                            TotalDue = item.total_due,
                            InvoiceRef = item.invoice_ref,
                            InvoiceId = item.invoice_id,
                            PaymentReceiptNumber = item.payment_receipt_number,
                            Invoiced = item.invoiced,
                            TotalInvoiced = item.total_invoiced,
                            TotalInvoicedOri = item.total_invoiced_ori,
                            Paid = item.paid,
                            TotalPayment = item.total_payment,
                            DeliveryFeeMin = item.delivery_fee_min,
                            DeliveryFee = item.delivery_fee,
                            DeliveryFeeTotal = item.delivery_fee_total,
                            PaidDelivery = item.paid_delivery,
                            TotalPaymentDelivery = item.total_payment_delivery,
                            PortFee = item.port_fee,
                            PortFeeBeforeTax = item.port_fee_before_tax,
                            PortFeeVat = item.port_fee_vat,
                            PortFeeTotal = item.port_fee_total,
                            Manifested = item.manifested,
                            PodNeeded = item.pod_needed,
                            PodSent = item.pod_sent,
                            PodReceived = item.pod_received,
                            PodReturned = item.pod_returned,
                            McPercent = item.mc_percent,
                            McPercentTotal = item.mc_percent_total,
                            McKg = item.mc_kg,
                            McKgTotal = item.mc_kg_total,
                            McTotal = item.mc_total,
                            PaidMc = item.paid_mc,
                            TotalPaymentMc = item.total_payment_mc,
                            AutoNumber = item.auto_number,
                            NeedRa = item.need_ra,
                            AcceptanceEmployee = item.acceptance_employee,
                            DataEntryEmployee = item.data_entry_employee,
                            TrackingStatusId = (int) item.tracking_status_id,
                            UploadStatus = item.upload_status,
                            FranchiseId = item.franchise_id,
                            PromoId = item.promo_id,
                            PromoCode = item.promo_code,
                            PODStatus = item.pod_status,
                            Createddate = item.createddate,
                            Createdby = item.createdby,
                            CreatedPc = item.createdpc,
                            Modifieddate = item.modifieddate,
                            Modifiedby = item.modifiedby,
                            ModifiedPc = item.modifiedpc,
                            StateChange = EnumStateChange.Select
                        }).AsQueryable();

            return obj.ToList();
        }

        public IEnumerable<T> GetGrid<T>(params IListParameter[] parameter) where T : IBaseModel
        {
            string[] trackingStatuses = new TrackingStatusRepository().Get<TrackingStatusModel>(WhereTerm.Default(true, "is_final_status")).Select(s => s.Id.ToString("#")).ToArray();
            var whereterm = GetQueryParameterLinq(parameter);

            var sql = @"SELECT
                            s.*,
                            (SELECT id FROM shipment_status WHERE tracking_status_id IN ({0}) AND rowstatus = 1 AND shipment_id = s.id order by createddate desc limit 1) StatusId
                        FROM shipment s
                        WHERE {2}";

            var query = @"SELECT
                            s.id Id,
	                        s.rowstatus Rowstatus,
	                        s.rowversion Rowversion,
	                        s.date_process DateProcess,
	                        s.code Code,
	                        s.branch_id BranchId,
	                        b.name BranchName,
	                        s.marketing_id MarketingId,
                            s.messenger_id MessengerId,
	                        s.messenger_name MessengerName,
                            s.messenger_id2 MessengerId2,
                            s.messenger_name MessengerName2,
	                        s.sales_type_id SalesTypeId,
	                        s.city_id CityId,
	                        s.city_name CityName,
	                        s.dest_city_id DestCityId,
	                        s.dest_city DestCity,
	                        s.dest_country_id DestCountryId,
	                        s.dest_country DestCountry,
	                        s.dest_branch_id DestBranchId,
	                        s.dest_branch_name DestBranchName,
	                        s.note Note,
	                        s.customer_id CustomerId,
	                        s.customer_name CustomerName,
	                        s.account_id AccountId,
	                        s.ref_number RefNumber,
	                        s.ref_code RefCode,
	                        s.personal Personal,
	                        s.personal_name PersonalName,
	                        s.shipper_name ShipperName,
	                        s.shipper_address ShipperAddress,
	                        s.shipper_postal_code ShipperPostalCode,
	                        s.shipper_city ShipperCity,
	                        s.shipper_phone ShipperPhone,
	                        s.shipper_saved ShipperSaved,
	                        s.consignee_name ConsigneeName,
	                        s.consignee_address ConsigneeAddress,
	                        s.consignee_postal_code ConsigneePostalCode,
	                        s.consignee_city ConsigneeCity,
	                        s.consignee_phone ConsigneePhone,
	                        s.consignee_saved ConsigneeSaved,
	                        s.shipping_method_id ShippingMethodId,
	                        s.service_type_id ServiceTypeId,
	                        s.package_type_id PackageTypeId,
	                        pt.name PackageType,
	                        s.payment_method_id PaymentMethodId,
                            st.name ServiceType,
	                        pm.name PaymentMethod,
	                        s.pricing_calc_type PricingCalcType,
	                        s.collect_payment_method CollectPaymentMethod,
	                        s.collect_customer_id CollectCustomerId,
	                        s.collect_customer_name CollectCustomerName,
	                        s.paid_coll PaidColl,
	                        s.total_payment_coll TotalPaymentColl,
	                        s.paid_collect PaidCollect,
	                        s.total_payment_collect TotalPaymentCollect,
	                        s.nature_of_goods NatureOfGoods,
	                        s.dimension Dimension,
	                        s.ttl_piece TtlPiece,
	                        s.ttl_gross_weight TtlGrossWeight,
	                        s.ttl_chargeable_weight TtlChargeableWeight,
	                        s.pricing_plan_id PricingPlanId,
	                        s.tariff Tariff,
	                        s.discount_percent DiscountPercent,
	                        s.discount_total DiscountTotal,
	                        s.tariff_net TariffNet,
	                        s.tariff_total TariffTotal,
	                        s.before_tax_total BeforeTaxTotal,
	                        s.vat Vat,
	                        s.after_tax_total AfterTaxTotal,
	                        s.handling_fee HandlingFee,
	                        s.handling_fee_total HandlingFeeTotal,
	                        s.surcharge_fee SurchargeFee,
	                        s.admin_fee AdminFee,
 	                        s.packing_fee PackingFee,
	                        s.other_fee OtherFee,
	                        s.void_fee VoidFee,
	                        s.goods_value GoodsValue,
	                        s.insurance_fee InsuranceFee,
	                        s.protection_type ProtectionType,
	                        s.protection_value ProtectionValue,
	                        s.protection_fee ProtectionFee,
	                        s.extra_weight ExtraWeight,
	                        s.extra_charge ExtraCharge,
	                        s.extra_charge_total ExtraChargeTotal,
	                        s.total Total,
	                        s.currency_id CurrencyId,
	                        s.currency Currency,
	                        s.currency_rate CurrencyRate,
	                        s.total_sales TotalSales,
	                        s.cancelled Cancelled,
	                        s.posted Posted,
	                        s.voided Voided,
	                        s.total_due TotalDue,
	                        s.invoice_ref InvoiceRef,
	                        s.invoice_id InvoiceId,
	                        s.payment_receipt_number PaymentReceiptNumber,
	                        s.invoiced Invoiced,
	                        s.total_invoiced TotalInvoiced,
	                        s.total_invoiced_ori TotalInvoicedOri,
	                        s.paid Paid,
	                        s.total_payment TotalPayment,
	                        s.delivery_fee_min DeliveryFeeMin,
	                        s.delivery_fee DeliveryFee,
	                        s.delivery_fee_total DeliveryFeeTotal,
	                        s.paid_delivery PaidDelivery,
	                        s.total_payment_delivery TotalPaymentDelivery,
	                        s.port_fee PortFee,
	                        s.port_fee_before_tax PortFeeBeforeTax,
	                        s.port_fee_vat PortFeeVat,
	                        s.port_fee_total PortFeeTotal,
	                        s.manifested Manifested,
	                        s.pod_needed PodNeeded,
	                        s.pod_sent PodSent,
	                        s.pod_received PodReceived,
	                        s.pod_returned PodReturned,
	                        s.mc_percent McPercent,
	                        s.mc_percent_total McPercentTotal,
	                        s.mc_kg McKg,
	                        s.mc_kg_total McKgTotal,
	                        s.mc_total McTotal,
	                        s.paid_mc PaidMc,
	                        s.total_payment_mc TotalPaymentMc,
	                        s.auto_number AutoNumber,
	                        s.need_ra NeedRa,
	                        s.acceptance_employee AcceptanceEmployee,
	                        s.data_entry_employee DataEntryEmployee,
	                        s.tracking_status_id TrackingStatusId,
	                        ts.code TrackingStatus,
	                        s.upload_status UploadStatus,
	                        s.franchise_id FranchiseId,
	                        s.promo_id PromoId,
	                        s.promo_code PromoCode,
	                        s.pod_status PODStatus,
	                        se.fulfilment Fulfilment,
	                        IF(se.shipment_id IS NULL, 0, IF(se.total_cod > 0, se.total_cod, 0)) TotalCod,
                            se.handedover Handover,
	                        s.createddate Createddate,
	                        s.createdby Createdby,
	                        s.createdpc CreatedPc,
	                        s.modifieddate Modifieddate,
	                        s.modifiedby Modifiedby,
	                        s.modifiedpc ModifiedPc,
                            IF(ISNULL(ss.dateprocess), 0, ss.tracking_status_id) AS TrackingStatusId,
	                        IF(ISNULL(ss.dateprocess), null, ss.dateprocess) AS DeliveryDate,
	                        IF(ISNULL(ss.dateprocess), 'Not Available', DATE_FORMAT(ss.dateprocess,'%d-%m-%Y')) AS DeliveryDateStr,
	                        IF(ISNULL(ss.dateprocess), '', DATE_FORMAT(ss.dateprocess,'%H:%i')) AS DeliveryTime,
	                        IF(ISNULL(ss.dateprocess), '', ss.status_by) AS RecipientName,
	                        IF(ss.miss_delivery_reason = '', ss.status_note, ss.miss_delivery_reason) AS DeliveryNote
                        FROM (" + sql + @") s
                        INNER JOIN siscodb.payment_method pm ON s.payment_method_id = pm.id
                        INNER JOIN siscodb.package_type pt ON s.package_type_id = pt.id
                        INNER JOIN siscodb.service_type st ON s.service_type_id = st.id
                        INNER JOIN siscodb.tracking_status ts ON s.tracking_status_id = ts.id
                        INNER JOIN siscodb.branch b ON s.branch_id = b.id
                        LEFT JOIN siscodb.shipment_expand se ON s.id = se.shipment_id
                        LEFT JOIN shipment_status ss ON StatusId = ss.id
                        ORDER BY DATE_FORMAT(s.date_process,'%d-%m-%Y'), s.code";
            var executeSql = string.Format(query, string.Join(",", trackingStatuses), string.Join(",", trackingStatuses), string.Format("s.{0}", string.Join(" AND s.", ListClause)));

            /*var sql = @"SELECT
	                        s.id Id,
	                        s.rowstatus Rowstatus,
	                        s.rowversion Rowversion,
	                        s.date_process DateProcess,
	                        s.code Code,
	                        s.branch_id BranchId,
	                        b.name BranchName,
	                        s.marketing_id MarketingId,
                            s.messenger_id MessengerId,
	                        s.messenger_name MessengerName,
	                        s.sales_type_id SalesTypeId,
	                        s.city_id CityId,
	                        s.city_name CityName,
	                        s.dest_city_id DestCityId,
	                        s.dest_city DestCity,
	                        s.dest_country_id DestCountryId,
	                        s.dest_country DestCountry,
	                        s.dest_branch_id DestBranchId,
	                        s.dest_branch_name DestBranchName,
	                        s.note Note,
	                        s.customer_id CustomerId,
	                        s.customer_name CustomerName,
	                        s.account_id AccountId,
	                        s.ref_number RefNumber,
	                        s.ref_code RefCode,
	                        s.personal Personal,
	                        s.personal_name PersonalName,
	                        s.shipper_name ShipperName,
	                        s.shipper_address ShipperAddress,
	                        s.shipper_postal_code ShipperPostalCode,
	                        s.shipper_city ShipperCity,
	                        s.shipper_phone ShipperPhone,
	                        s.shipper_saved ShipperSaved,
	                        s.consignee_name ConsigneeName,
	                        s.consignee_address ConsigneeAddress,
	                        s.consignee_postal_code ConsigneePostalCode,
	                        s.consignee_city ConsigneeCity,
	                        s.consignee_phone ConsigneePhone,
	                        s.consignee_saved ConsigneeSaved,
	                        s.shipping_method_id ShippingMethodId,
	                        s.service_type_id ServiceTypeId,
	                        s.package_type_id PackageTypeId,
	                        pt.name PackageType,
	                        s.payment_method_id PaymentMethodId,
	                        pm.name PaymentMethod,
	                        s.pricing_calc_type PricingCalcType,
	                        s.collect_payment_method CollectPaymentMethod,
	                        s.collect_customer_id CollectCustomerId,
	                        s.collect_customer_name CollectCustomerName,
	                        s.paid_coll PaidColl,
	                        s.total_payment_coll TotalPaymentColl,
	                        s.paid_collect PaidCollect,
	                        s.total_payment_collect TotalPaymentCollect,
	                        s.nature_of_goods NatureOfGoods,
	                        s.dimension Dimension,
	                        s.ttl_piece TtlPiece,
	                        s.ttl_gross_weight TtlGrossWeight,
	                        s.ttl_chargeable_weight TtlChargeableWeight,
	                        s.pricing_plan_id PricingPlanId,
	                        s.tariff Tariff,
	                        s.discount_percent DiscountPercent,
	                        s.discount_total DiscountTotal,
	                        s.tariff_net TariffNet,
	                        s.tariff_total TariffTotal,
	                        s.before_tax_total BeforeTaxTotal,
	                        s.vat Vat,
	                        s.after_tax_total AfterTaxTotal,
	                        s.handling_fee HandlingFee,
	                        s.handling_fee_total HandlingFeeTotal,
	                        s.surcharge_fee SurchargeFee,
	                        s.admin_fee AdminFee,
 	                        s.packing_fee PackingFee,
	                        s.other_fee OtherFee,
	                        s.void_fee VoidFee,
	                        s.goods_value GoodsValue,
	                        s.insurance_fee InsuranceFee,
	                        s.protection_type ProtectionType,
	                        s.protection_value ProtectionValue,
	                        s.protection_fee ProtectionFee,
	                        s.extra_weight ExtraWeight,
	                        s.extra_charge ExtraCharge,
	                        s.extra_charge_total ExtraChargeTotal,
	                        s.total Total,
	                        s.currency_id CurrencyId,
	                        s.currency Currency,
	                        s.currency_rate CurrencyRate,
	                        s.total_sales TotalSales,
	                        s.cancelled Cancelled,
	                        s.posted Posted,
	                        s.voided Voided,
	                        s.total_due TotalDue,
	                        s.invoice_ref InvoiceRef,
	                        s.invoice_id InvoiceId,
	                        s.payment_receipt_number PaymentReceiptNumber,
	                        s.invoiced Invoiced,
	                        s.total_invoiced TotalInvoiced,
	                        s.total_invoiced_ori TotalInvoicedOri,
	                        s.paid Paid,
	                        s.total_payment TotalPayment,
	                        s.delivery_fee_min DeliveryFeeMin,
	                        s.delivery_fee DeliveryFee,
	                        s.delivery_fee_total DeliveryFeeTotal,
	                        s.paid_delivery PaidDelivery,
	                        s.total_payment_delivery TotalPaymentDelivery,
	                        s.port_fee PortFee,
	                        s.port_fee_before_tax PortFeeBeforeTax,
	                        s.port_fee_vat PortFeeVat,
	                        s.port_fee_total PortFeeTotal,
	                        s.manifested Manifested,
	                        s.pod_needed PodNeeded,
	                        s.pod_sent PodSent,
	                        s.pod_received PodReceived,
	                        s.pod_returned PodReturned,
	                        s.mc_percent McPercent,
	                        s.mc_percent_total McPercentTotal,
	                        s.mc_kg McKg,
	                        s.mc_kg_total McKgTotal,
	                        s.mc_total McTotal,
	                        s.paid_mc PaidMc,
	                        s.total_payment_mc TotalPaymentMc,
	                        s.auto_number AutoNumber,
	                        s.need_ra NeedRa,
	                        s.acceptance_employee AcceptanceEmployee,
	                        s.data_entry_employee DataEntryEmployee,
	                        s.tracking_status_id TrackingStatusId,
	                        ts.code TrackingStatus,
	                        s.upload_status UploadStatus,
	                        s.franchise_id FranchiseId,
	                        s.promo_id PromoId,
	                        s.promo_code PromoCode,
	                        s.pod_status PODStatus,
	                        se.fulfilment Fulfilment,
	                        IF(se.shipment_id IS NULL, 0, IF(se.total_cod > 0, se.total_cod, 0)) TotalCod,
                            se.handedover Handover,
	                        s.createddate Createddate,
	                        s.createdby Createdby,
	                        s.createdpc CreatedPc,
	                        s.modifieddate Modifieddate,
	                        s.modifiedby Modifiedby,
	                        s.modifiedpc ModifiedPc,
                            MAX(ss.createddate),
                            IF(ISNULL(ss.dateprocess), null, ss.dateprocess) AS DeliveryDate,
	                        IF(ISNULL(ss.dateprocess), 'Not Available', DATE_FORMAT(ss.dateprocess,'%d-%m-%Y')) AS DeliveryDateStr,
	                        IF(ISNULL(ss.dateprocess), '', DATE_FORMAT(ss.dateprocess,'%H:%i')) AS DeliveryTime,
	                        IF(ISNULL(ss.dateprocess), '', ss.status_by) AS RecipientName,
	                        IF(ss.miss_delivery_reason = '', ss.status_note, ss.miss_delivery_reason) AS DeliveryNote
                        FROM siscodb.shipment s
                        INNER JOIN siscodb.payment_method pm ON s.payment_method_id = pm.id
                        INNER JOIN siscodb.package_type pt ON s.package_type_id = pt.id
                        INNER JOIN siscodb.tracking_status ts ON s.tracking_status_id = ts.id
                        INNER JOIN siscodb.branch b ON s.branch_id = b.id
                        LEFT JOIN siscodb.shipment_status ss ON ss.shipment_id = s.id AND ss.rowstatus = 1 AND ss.tracking_status_id IN ({0})
                        LEFT JOIN siscodb.shipment_expand se ON s.id = se.shipment_id
                        WHERE {1}
                        GROUP BY ss.shipment_id
                        ORDER BY s.date_process";

            sql = string.Format(sql, string.Join(",", trackingStatuses), string.Format("s.{0}", string.Join(" AND s.", ListClause)));*/
            return Entities.ExecuteStoreQuery<T>(executeSql).ToList();
        }

        public IEnumerable<SISCO.Models.ShipmentModel.ShipmentReportRow> ShipmentExportExcel(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter.ToArray());
            var query = (from a in Entities.shipments
                         select a).Where(whereterm, ListValue.ToArray()).ToList();

            if (query == null)
                throw new Exception(MessageEntityNotFound);

            var obj = (from item in query
                                                   join e in
                                                       (from e in Entities.payment_method where e.rowstatus.Equals(true) select e) on item.payment_method_id equals e.id
                                                   join f in
                                                       (from f in Entities.package_type where f.rowstatus.Equals(true) select f) on item.package_type_id equals f.id
                                                   join t in
                                                       (from t in Entities.tracking_status where t.rowstatus.Equals(true) select t) on item.tracking_status_id equals t.id
                                                   join b in
                                                       (from b in Entities.branches where b.rowstatus.Equals(true) select b) on item.branch_id equals b.id
                                                   join m in
                                                       (from m in Entities.employees where m.rowstatus.Equals(true) select m) on item.messenger_id equals m.id into mx
                                                   from m in mx.DefaultIfEmpty()
                                                   join c in
                                                       (from c in Entities.customers where c.rowstatus.Equals(true) select c) on item.customer_id equals c.id into xx
                                                   from c in xx.DefaultIfEmpty()
                                                   join s in
                                                       (from s in Entities.service_type where s.rowstatus.Equals(true) select s) on item.service_type_id equals s.id
                                                   join c2 in
                                                       (from c2 in Entities.customers where c2.rowstatus.Equals(true) select c2) on item.collect_customer_id equals c2.id into cx
                                                   from c2 in cx.DefaultIfEmpty()
                                                   join p in
                                                       (from p in Entities.pricing_plan where p.rowstatus.Equals(true) select p) on item.pricing_plan_id equals p.id into px
                                                   from p in px.DefaultIfEmpty()
                                                   join se in Entities.shipment_expand on item.id equals se.shipment_id into sex
                                                   from se in sex.DefaultIfEmpty()
                                                   select new SISCO.Models.ShipmentModel.ShipmentReportRow
                                                   {
                                                       Id = item.id,
                                                       Rowstatus = item.rowstatus,
                                                       Rowversion = item.rowversion,
                                                       DateProcess = item.date_process,
                                                       Code = item.code,
                                                       BranchId = item.branch_id,
                                                       BranchName = b.name,
                                                       // ReSharper disable once PossibleInvalidOperationException
                                                       MarketingId = (int)item.marketing_id,
                                                       MessengerId = item.messenger_id,
                                                       MessengerName = item.messenger_name,
                                                       MessengerId2 = item.messenger_id2,
                                                       MessengerName2 = item.messenger_name2,
                                                       MessengerCode = m != null ? m.code : string.Empty,
                                                       // ReSharper disable once PossibleInvalidOperationException
                                                       SalesTypeId = (int)item.sales_type_id,
                                                       SalesType = item.sales_type_id == 1 ? "Counter Cash" : (item.sales_type_id == 2 ? "City" : (item.sales_type_id == 3 ? "Agent" : "")),
                                                       CityId = item.city_id,
                                                       CityName = item.city_name,
                                                       DestCityId = item.dest_city_id,
                                                       DestCity = item.dest_city,
                                                       DestCountryId = item.dest_country_id,
                                                       DestCountry = item.dest_country,
                                                       DestBranchId = item.dest_branch_id,
                                                       DestBranchName = item.dest_branch_name,
                                                       Note = item.note,
                                                       CustomerId = item.customer_id,
                                                       CustomerName = item.customer_name == null ? string.Empty : item.customer_name,
                                                       CustomerCode = c == null ? string.Empty : c.code,
                                                       // ReSharper disable once PossibleInvalidOperationException
                                                       AccountId = (int)item.account_id,
                                                       RefNumber = item.ref_number,
                                                       RefCode = item.ref_code,
                                                       Personal = item.personal,
                                                       PersonalName = item.personal_name,
                                                       ShipperName = item.shipper_name,
                                                       ShipperAddress = item.shipper_address,
                                                       ShipperPostalCode = item.shipper_postal_code,
                                                       ShipperCity = item.shipper_city,
                                                       ShipperPhone = item.shipper_phone,
                                                       ShipperSaved = item.shipper_saved,
                                                       ConsigneeName = item.consignee_name,
                                                       ConsigneeAddress = item.consignee_address,
                                                       ConsigneePostalCode = item.consignee_postal_code,
                                                       ConsigneeCity = item.consignee_city,
                                                       ConsigneePhone = item.consignee_phone,
                                                       // ReSharper disable once PossibleInvalidOperationException
                                                       ConsigneeSaved = (bool)item.consignee_saved,
                                                       // ReSharper disable once PossibleInvalidOperationException
                                                       ShippingMethodId = (int)item.shipping_method_id,
                                                       ServiceTypeId = item.service_type_id,
                                                       ServiceType = s.name,
                                                       PackageTypeId = item.package_type_id,
                                                       PackageType = f.name,
                                                       PaymentMethodId = item.payment_method_id,
                                                       PaymentMethod = e.name,
                                                       PricingCalcType = item.pricing_calc_type,
                                                       CollectPaymentMethod = item.collect_payment_method,
                                                       CollectCustomerId = item.collect_customer_id,
                                                       CollectCustomerName = item.collect_customer_name,
                                                       CollectCustomerCode = c2 != null ? c2.code : "",
                                                       PaidColl = item.paid_coll,
                                                       TotalPaymentColl = item.total_payment_coll,
                                                       PaidCollect = item.paid_collect,
                                                       TotalPaymentCollect = item.total_payment_collect,
                                                       NatureOfGoods = item.nature_of_goods,
                                                       Dimension = item.dimension,
                                                       TtlPiece = item.ttl_piece,
                                                       TtlGrossWeight = item.ttl_gross_weight,
                                                       TtlChargeableWeight = item.ttl_chargeable_weight,
                                                       // ReSharper disable once PossibleInvalidOperationException
                                                       PricingPlanId = item.pricing_plan_id,
                                                       PricingPlan = p != null ? p.code : "",
                                                       Tariff = item.tariff,
                                                       DiscountPercent = item.discount_percent,
                                                       DiscountTotal = item.discount_total,
                                                       TariffNet = item.tariff_net,
                                                       TariffTotal = item.tariff_total,
                                                       BeforeTaxTotal = item.before_tax_total,
                                                       Vat = item.vat,
                                                       AfterTaxTotal = item.after_tax_total,
                                                       HandlingFee = item.handling_fee,
                                                       HandlingFeeTotal = item.handling_fee_total,
                                                       SurchargeFee = item.surcharge_fee,
                                                       AdminFee = item.admin_fee,
                                                       PackingFee = item.packing_fee,
                                                       OtherFee = item.other_fee,
                                                       VoidFee = item.void_fee,
                                                       GoodsValue = item.goods_value,
                                                       InsuranceFee = item.insurance_fee,
                                                       ProtectionType = item.protection_type,
                                                       ProtectionValue = item.protection_value,
                                                       ProtectionFee = item.protection_fee,
                                                       ExtraWeight = item.extra_weight,
                                                       ExtraCharge = item.extra_charge,
                                                       ExtraChargeTotal = item.extra_charge_total,
                                                       Total = item.total,
                                                       CurrencyId = item.currency_id,
                                                       Currency = item.currency,
                                                       CurrencyRate = item.currency_rate,
                                                       TotalSales = item.total_sales,
                                                       Cancelled = item.cancelled,
                                                       Posted = item.posted,
                                                       Voided = item.voided,
                                                       TotalDue = item.total_due,
                                                       InvoiceRef = item.invoice_ref,
                                                       InvoiceId = item.invoice_id,
                                                       PaymentReceiptNumber = item.payment_receipt_number,
                                                       Invoiced = item.invoiced,
                                                       TotalInvoiced = item.total_invoiced,
                                                       TotalInvoicedOri = item.total_invoiced_ori,
                                                       Paid = item.paid,
                                                       TotalPayment = item.total_payment,
                                                       DeliveryFeeMin = item.delivery_fee_min,
                                                       DeliveryFee = item.delivery_fee,
                                                       DeliveryFeeTotal = item.delivery_fee_total,
                                                       PaidDelivery = item.paid_delivery,
                                                       TotalPaymentDelivery = item.total_payment_delivery,
                                                       PortFee = item.port_fee,
                                                       PortFeeBeforeTax = item.port_fee_before_tax,
                                                       PortFeeVat = item.port_fee_vat,
                                                       PortFeeTotal = item.port_fee_total,
                                                       Manifested = item.manifested,
                                                       PodNeeded = item.pod_needed,
                                                       PodSent = item.pod_sent,
                                                       PodReceived = item.pod_received,
                                                       PodReturned = item.pod_returned,
                                                       McPercent = item.mc_percent,
                                                       McPercentTotal = item.mc_percent_total,
                                                       McKg = item.mc_kg,
                                                       McKgTotal = item.mc_kg_total,
                                                       McTotal = item.mc_total,
                                                       PaidMc = item.paid_mc,
                                                       TotalPaymentMc = item.total_payment_mc,
                                                       AutoNumber = item.auto_number,
                                                       NeedRa = item.need_ra,
                                                       AcceptanceEmployee = item.acceptance_employee,
                                                       DataEntryEmployee = item.data_entry_employee,
                                                       // ReSharper disable once PossibleInvalidOperationException
                                                       TrackingStatusId = (int)item.tracking_status_id,
                                                       TrackingStatus = t.code,
                                                       UploadStatus = item.upload_status,
                                                       FranchiseId = item.franchise_id,
                                                       PromoId = item.promo_id,
                                                       PromoCode = item.promo_code,
                                                       PODStatus = item.pod_status,
                                                       Fulfilment = se != null ? se.fulfilment : string.Empty,
                                                       TotalCod = se != null ? (se.iscod ? se.total_cod : 0) : 0,
                                                       Createddate = item.createddate,
                                                       Createdby = item.createdby,
                                                       CreatedPc = item.createdpc,
                                                       Modifieddate = item.modifieddate,
                                                       Modifiedby = item.modifiedby,
                                                       ModifiedPc = item.modifiedpc,
                                                       StateChange = EnumStateChange.Select
                                                   }).AsQueryable();
            
            return obj.ToList();
        }

        public IEnumerable<ShipmentModel> ShipmentExportExcel(DateTime? fromDate, DateTime? toDate, DateTime? invoiceDateFrom, 
            DateTime? invoiceDateTo, string paymentMethod, string invoiceNumber, string receiptNumber)
        {
            var parameters = new List<MySqlParameter>();
            var whereClauses = new List<string>();

            whereClauses.Add("s.rowstatus = @rowstatus");
            parameters.Add(new MySqlParameter("rowstatus", 1));

            if (fromDate != null && fromDate != DateTime.MinValue)
            {
                whereClauses.Add("s.date_process >= @fromDate");
                parameters.Add(new MySqlParameter("fromDate", ((DateTime)fromDate).ToString("yyyy-MM-dd") + " 00:00:01"));
            }

            if (toDate != null && toDate != DateTime.MinValue)
            {
                whereClauses.Add("s.date_process <= @toDate");
                parameters.Add(new MySqlParameter("toDate", ((DateTime)toDate).ToString("yyyy-MM-dd") + " 23:59:59"));
            }

            if (invoiceDateFrom != null && invoiceDateFrom != DateTime.MinValue)
            {
                whereClauses.Add("si.vdate >= @invFromDate");
                parameters.Add(new MySqlParameter("invFromDate", ((DateTime)invoiceDateFrom).ToString("yyyy-MM-dd")));
            }

            if (invoiceDateTo != null && invoiceDateTo != DateTime.MinValue)
            {
                whereClauses.Add("si.vdate <= @invToDate");
                parameters.Add(new MySqlParameter("invToDate", ((DateTime)invoiceDateTo).ToString("yyyy-MM-dd")));
            }

            if (!string.IsNullOrEmpty(invoiceNumber))
            {
                whereClauses.Add("s.invoice_ref = @invoiceNumber");
                parameters.Add(new MySqlParameter("invoiceNumber", invoiceNumber));
            }

            if (!string.IsNullOrEmpty(receiptNumber))
            {
                whereClauses.Add("s.payment_receipt_number = @receiptNumber");
                parameters.Add(new MySqlParameter("receiptNumber", receiptNumber));
            }

            if (!string.IsNullOrEmpty(paymentMethod))
            {
                whereClauses.Add("pm.name = @paymentMethod");
                parameters.Add(new MySqlParameter("paymentMethod", paymentMethod));
            }

            string sql = @"SELECT s.id Id, s.rowstatus AS RowStatus, s.rowversion AS RowVersion, s.date_process AS DateProcess, s.code AS Code, s.branch_id AS BranchId, 
                            b.name AS BranchName, CAST(IFNULL(s.marketing_id,0) AS UNSIGNED) AS MarketingId, s.messenger_id AS MessengerId,s.messenger_name AS MessengerName, e.name AS MessengerCode, 
                            s.messenger_id2 AS MessengerId2, s.messenger_name2 AS MessengerName2,
                            CAST(IFNULL(s.sales_type_id,0) AS UNSIGNED) AS SalesTypeId, CASE s.sales_type_id WHEN 1 THEN 'Counter Cash' WHEN 2 THEN 'City' WHEN 3 THEN 'Agent' ELSE '' END AS SalesType, 
                            s.city_id AS CityId, s.city_name AS CityName, s.dest_city_id DestCityId,s.dest_city DestCity,s.dest_country_id DestCountryId,s.dest_country DestCountry,
                            s.dest_branch_id DestBranchId,s.dest_branch_name DestBranchName,s.note Note,s.customer_id CustomerId,s.customer_name CustomerName,c.code CustomerCode,
                            CAST(IFNULL(s.account_id,0) AS UNSIGNED) AccountId,s.ref_number RefNumber,s.ref_code RefCode,s.personal Personal,s.personal_name PersonalName,s.shipper_name ShipperName,
                            s.shipper_address ShipperAddress,s.shipper_postal_code ShipperPostalCode,s.shipper_city ShipperCity,s.shipper_phone ShipperPhone,s.shipper_saved ShipperSaved,
                            s.consignee_name ConsigneeName,s.consignee_address ConsigneeAddress,s.consignee_postal_code ConsigneePostalCode,s.consignee_city ConsigneeCity,
                            s.consignee_phone ConsigneePhone,s.consignee_saved ConsigneeSaved, CAST(IFNULL(s.shipping_method_id,0) AS UNSIGNED) ShippingMethodId,s.service_type_id ServiceTypeId,
                            st.name ServiceType,s.package_type_id PackageTypeId,pt.name PackageType,s.payment_method_id PaymentMethodId,pm.name PaymentMethod,
                            s.pricing_calc_type PricingCalcType,s.collect_payment_method CollectPaymentMethod,s.collect_customer_id CollectCustomerId,
                            s.collect_customer_name CollectCustomerName,IFNULL(col.code, '') CollectCustomerCode,s.paid_coll PaidColl,s.total_payment_coll TotalPaymentColl,
                            s.paid_collect PaidCollect,s.total_payment_collect TotalPaymentCollect,s.nature_of_goods NatureOfGoods,s.dimension DIMENSION,s.ttl_piece TtlPiece,
                            s.ttl_gross_weight TtlGrossWeight,s.ttl_chargeable_weight TtlChargeableWeight,s.pricing_plan_id PricingPlanId,IFNULL(pp.code,'') PricingPlan,
                            s.tariff Tariff,s.discount_percent DiscountPercent,s.discount_total DiscountTotal,s.tariff_net TariffNet,s.tariff_total TariffTotal,
                            s.before_tax_total BeforeTaxTotal,s.vat Vat,s.after_tax_total AfterTaxTotal,s.handling_fee HandlingFee,s.handling_fee_total HandlingFeeTotal,
                            s.surcharge_fee SurchargeFee,s.admin_fee AdminFee,s.packing_fee PackingFee,s.other_fee OtherFee,s.void_fee VoidFee,s.goods_value GoodsValue,
                            s.insurance_fee InsuranceFee,s.protection_type ProtectionType,s.protection_value ProtectionValue,s.protection_fee ProtectionFee,
                            s.extra_weight ExtraWeight,s.extra_charge ExtraCharge,s.extra_charge_total ExtraChargeTotal,s.total Total,s.currency_id CurrencyId,
                            s.currency 'Currency',s.currency_rate CurrencyRate,s.total_sales TotalSales,s.cancelled Cancelled,s.posted Posted,s.voided Voided,
                            s.total_due TotalDue,s.invoice_ref InvoiceRef,s.invoice_id InvoiceId,s.payment_receipt_number PaymentReceiptNumber,s.invoiced Invoiced,
                            s.total_invoiced TotalInvoiced,s.total_invoiced_ori TotalInvoicedOri,s.paid Paid,s.total_payment TotalPayment,s.delivery_fee_min DeliveryFeeMin,
                            s.delivery_fee DeliveryFee,s.delivery_fee_total DeliveryFeeTotal,s.paid_delivery PaidDelivery,s.total_payment_delivery TotalPaymentDelivery,
                            s.port_fee PortFee,s.port_fee_before_tax PortFeeBeforeTax,s.port_fee_vat PortFeeVat,s.port_fee_total PortFeeTotal,s.manifested Manifested,
                            s.pod_needed PodNeeded,s.pod_sent PodSent,s.pod_received PodReceived,s.pod_returned PodReturned,s.mc_percent McPercent,s.mc_percent_total McPercentTotal,
                            s.mc_kg McKg,s.mc_kg_total McKgTotal,s.mc_total McTotal,s.paid_mc PaidMc,s.total_payment_mc TotalPaymentMc,s.auto_number AutoNumber,
                            s.need_ra NeedRa,s.acceptance_employee AcceptanceEmployee,s.data_entry_employee DataEntryEmployee, CAST(IFNULL(s.tracking_status_id,0) AS UNSIGNED) TrackingStatusId,
                            ts.code TrackingStatus,s.upload_status UploadStatus, se.fulfilment Fulfilment, se.total_cod TotalCod,s.createddate Createddate,s.createdby Createdby,s.createdpc CreatedPc,s.modifieddate Modifieddate,
                            s.modifiedby Modifiedby,s.modifiedpc ModifiedPc
                            FROM shipment s
                            LEFT JOIN payment_method pm ON pm.id = s.payment_method_id
                            LEFT JOIN package_type pt ON pt.id = s.package_type_id
                            LEFT JOIN tracking_status ts ON ts.id = s.tracking_status_id
                            LEFT JOIN branch b ON b.id = s.branch_id
                            LEFT JOIN employee e ON e.id = s.messenger_id
                            LEFT JOIN customer c ON c.id = s.customer_id
                            LEFT JOIN service_type st ON st.id = s.service_type_id
                            LEFT JOIN customer col ON col.id = s.collect_customer_id
                            LEFT JOIN pricing_plan pp ON pp.id = s.pricing_plan_id
                            LEFT JOIN shipment_expand se ON s.id = se.shipment_id
                            /*LEFT JOIN sales_invoice_list sil ON sil.shipment_id = s.id
                            LEFT JOIN sales_invoice si ON si.id = sil.sales_invoice_id*/
                            WHERE " + string.Join(" AND ", whereClauses);
                                    //+ " LIMIT 99999";

            return Entities.ExecuteStoreQuery<ShipmentModel>(sql, parameters.ToArray()).ToList();
        }

        public IEnumerable<ShipmentModel> GetInbound(params IListParameter[] parameter)
        {
            //var query = IncomingList(parameter).Where(p => p.Inbound == false);
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.shipments select a).Where(whereterm, ListValue.ToArray()).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);

            var obj = (from q in query
                join d in 
                       (from d in Entities.inbound_detail where d.rowstatus.Equals(true) select d)
                       on q.id equals d.shipment_id into id
                from d in id.DefaultIfEmpty()
                select new
                {
                    shipid = q.id,
                    inbound = d == null
                }).ToList();

            var ship = (from item in query
                join o in  
                        (from o in obj where o.inbound.Equals(true) select o)
                        on item.id equals o.shipid
                join m in (from m in Entities.manifest_detail where m.rowstatus.Equals(true) select m)
                    on item.id equals m.shipment_id
                select new ShipmentModel
                {
                    Id = o.shipid,
                    Rowstatus = item.rowstatus,
                    Rowversion = item.rowversion,
                    DateProcess = item.date_process,
                    Code = item.code,
                    BranchId = item.branch_id,
                    // ReSharper disable once PossibleInvalidOperationException
                    MarketingId = (int) item.marketing_id,
                    MessengerId = item.messenger_id,
                    MessengerName = item.messenger_name,
                    MessengerId2 = item.messenger_id2,
                    MessengerName2 = item.messenger_name2,
                    // ReSharper disable once PossibleInvalidOperationException
                    SalesTypeId = (int) item.sales_type_id,
                    CityId = item.city_id,
                    CityName = item.city_name,
                    DestCityId = item.dest_city_id,
                    DestCity = item.dest_city,
                    DestCountryId = item.dest_country_id,
                    DestCountry = item.dest_country,
                    DestBranchId = item.dest_branch_id,
                    DestBranchName = item.dest_branch_name,
                    Note = item.note,
                    CustomerId = item.customer_id,
                    CustomerName = item.customer_name,
                    // ReSharper disable once PossibleInvalidOperationException
                    AccountId = (int) item.account_id,
                    RefNumber = item.ref_number,
                    RefCode = item.ref_code,
                    Personal = item.personal,
                    PersonalName = item.personal_name,
                    ShipperName = item.shipper_name,
                    ShipperAddress = item.shipper_address,
                    ShipperPostalCode = item.shipper_postal_code,
                    ShipperCity = item.shipper_city,
                    ShipperPhone = item.shipper_phone,
                    ShipperSaved = item.shipper_saved,
                    ConsigneeName = item.consignee_name,
                    ConsigneeAddress = item.consignee_address,
                    ConsigneePostalCode = item.consignee_postal_code,
                    ConsigneeCity = item.consignee_city,
                    ConsigneePhone = item.consignee_phone,
                    // ReSharper disable once PossibleInvalidOperationException
                    ConsigneeSaved = (bool) item.consignee_saved,
                    // ReSharper disable once PossibleInvalidOperationException
                    ShippingMethodId = (int) item.shipping_method_id,
                    ServiceTypeId = item.service_type_id,
                    PackageTypeId = item.package_type_id,
                    PaymentMethodId = item.payment_method_id,
                    PricingCalcType = item.pricing_calc_type,
                    CollectPaymentMethod = item.collect_payment_method,
                    CollectCustomerId = item.collect_customer_id,
                    CollectCustomerName = item.collect_customer_name,
                    PaidColl = item.paid_coll,
                    TotalPaymentColl = item.total_payment_coll,
                    PaidCollect = item.paid_collect,
                    TotalPaymentCollect = item.total_payment_collect,
                    NatureOfGoods = item.nature_of_goods,
                    Dimension = item.dimension,
                    TtlPiece = item.ttl_piece,
                    TtlGrossWeight = item.ttl_gross_weight,
                    TtlChargeableWeight = item.ttl_chargeable_weight,
                    // ReSharper disable once PossibleInvalidOperationException
                    PricingPlanId = item.pricing_plan_id,
                    Tariff = item.tariff,
                    DiscountPercent = item.discount_percent,
                    DiscountTotal = item.discount_total,
                    TariffNet = item.tariff_net,
                    TariffTotal = item.tariff_total,
                    BeforeTaxTotal = item.before_tax_total,
                    Vat = item.vat,
                    AfterTaxTotal = item.after_tax_total,
                    HandlingFee = item.handling_fee,
                    HandlingFeeTotal = item.handling_fee_total,
                    SurchargeFee = item.surcharge_fee,
                    AdminFee = item.admin_fee,
                    PackingFee = item.packing_fee,
                    OtherFee = item.other_fee,
                    VoidFee = item.void_fee,
                    GoodsValue = item.goods_value,
                    InsuranceFee = item.insurance_fee,
                    ProtectionType = item.protection_type,
                    ProtectionValue = item.protection_value,
                    ProtectionFee = item.protection_fee,
                    ExtraWeight = item.extra_weight,
                    ExtraCharge = item.extra_charge,
                    ExtraChargeTotal = item.extra_charge_total,
                    Total = item.total,
                    CurrencyId = item.currency_id,
                    Currency = item.currency,
                    CurrencyRate = item.currency_rate,
                    TotalSales = item.total_sales,
                    Cancelled = item.cancelled,
                    Posted = item.posted,
                    Voided = item.voided,
                    TotalDue = item.total_due,
                    InvoiceRef = item.invoice_ref,
                    InvoiceId = item.invoice_id,
                    PaymentReceiptNumber = item.payment_receipt_number,
                    Invoiced = item.invoiced,
                    TotalInvoiced = item.total_invoiced,
                    TotalInvoicedOri = item.total_invoiced_ori,
                    Paid = item.paid,
                    TotalPayment = item.total_payment,
                    DeliveryFeeMin = item.delivery_fee_min,
                    DeliveryFee = item.delivery_fee,
                    DeliveryFeeTotal = item.delivery_fee_total,
                    PaidDelivery = item.paid_delivery,
                    TotalPaymentDelivery = item.total_payment_delivery,
                    PortFee = item.port_fee,
                    PortFeeBeforeTax = item.port_fee_before_tax,
                    PortFeeVat = item.port_fee_vat,
                    PortFeeTotal = item.port_fee_total,
                    Manifested = item.manifested,
                    ManifestCode = m.manifest_code,
                    PodNeeded = item.pod_needed,
                    PodSent = item.pod_sent,
                    PodReceived = item.pod_received,
                    PodReturned = item.pod_returned,
                    McPercent = item.mc_percent,
                    McPercentTotal = item.mc_percent_total,
                    McKg = item.mc_kg,
                    McKgTotal = item.mc_kg_total,
                    McTotal = item.mc_total,
                    PaidMc = item.paid_mc,
                    TotalPaymentMc = item.total_payment_mc,
                    AutoNumber = item.auto_number,
                    NeedRa = item.need_ra,
                    AcceptanceEmployee = item.acceptance_employee,
                    DataEntryEmployee = item.data_entry_employee,
                    // ReSharper disable once PossibleInvalidOperationException
                    TrackingStatusId = (int) item.tracking_status_id,
                    UploadStatus = item.upload_status,
                    FranchiseId = item.franchise_id,
                    PromoId = item.promo_id,
                    PromoCode = item.promo_code,
                    PODStatus = item.pod_status,
                    Createddate = item.createddate,
                    Createdby = item.createdby,
                    CreatedPc = item.createdpc,
                    Modifieddate = item.modifieddate,
                    Modifiedby = item.modifiedby,
                    ModifiedPc = item.modifiedpc,
                    StateChange = EnumStateChange.Select
                }).AsQueryable();

            return ship.ToList();
        }

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.shipments select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
		    IEnumerable<shipment> query;

		    if (paging.Limit == 1)
		    {
                var id = Entities.shipments.Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).Select(r => r.id).FirstOrDefault();
		        if (id > 0) query = (from a in Entities.shipments where a.id == id select a).ToList();
                else query = (from a in Entities.shipments where a.id == -1 select a).ToList();
		    }
			else query = (from a in Entities.shipments select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
				throw new Exception(MessageEntityNotFound);
            totalCount = Entities.shipments.Where(whereterm, ListValue.ToArray()).Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

        public string GenerateCode(ShipmentModel model)
        {
            var branchPrefix = (from a in Entities.branches
                where a.id == model.BranchId
                select a.prefix_code).FirstOrDefault();

            var pattern = string.Format("{0:0000}########", branchPrefix);

            return GenerateCode("shipment", pattern);
        }

        public int GetCount(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            return Entities.shipments.Where(whereterm, ListValue.ToArray()).Count();
        }

        public string GenerateCorporatePODCode(ShipmentModel model)
        {
            var branchPrefix = (from a in Entities.branches
                                where a.id == model.BranchId
                                select a.prefix_code).FirstOrDefault();

            var pattern = string.Format("{0:0000}{1}{2}{3}####", branchPrefix, DateTime.Now.ToString("yy"), DateTime.Now.ToString("MM"), DateTime.Now.ToString("dd"));

            return GenerateCode("corporate-pod", pattern);
        }

        public string GenerateFranchisePODCode(ShipmentModel model)
        {
            var franchiseCode = (from f in Entities.franchises
                                 where f.id == model.FranchiseId
                                 select f.code).FirstOrDefault();

            var pattern = string.Format("{0}{1}{2}{3}######", franchiseCode.Substring(0, 4), DateTime.Now.ToString("yy"), DateTime.Now.ToString("MM"), DateTime.Now.ToString("dd"));

            return GenerateCode("franchise-pod", pattern);
        }

        public string GenerateFranchisePODCode_API(ShipmentModel model)
        {
            var franchiseCode = (from f in Entities.franchises
                                 where f.id == model.FranchiseId
                                 select f.code).FirstOrDefault();

            var pattern = string.Format("{0}{1}{2}{3}######", franchiseCode.Substring(0, 4), DateTime.Now.ToString("yy"), DateTime.Now.ToString("MM"), DateTime.Now.ToString("dd"));

            return GenerateCode_2("franchise-pod", pattern);
        }

        public string GenerateECOPODCode_API(int branchId)
        {
            var branchCode = (from b in Entities.branches
                              where b.id == branchId
                              select b.code).FirstOrDefault();
            
            var pattern = string.Format("ECO{0}######{1}", branchCode, DateTime.Now.ToString("MMyy"));
            return GenerateCode_2("merchant", pattern);
        }

        public IEnumerable<T> GetExclude<T>(IListParameter[] parameter, int[] filterExcludeShipmentIds)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.shipments select a)
                            .Where(whereterm, ListValue.ToArray())
                            .Where(a => a.payment_method_id != (int) EnumPaymentMethod.Cash)
                            .Where(a => !filterExcludeShipmentIds.Contains(a.id))
                            .OrderBy("ID ASC")
                            .ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);

            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public void CancelInvoice(List<int> canceledShipmentIds)
        {
            if (canceledShipmentIds.Count == 0) return;
            var q = string.Format("UPDATE shipment SET invoiced = 0, cancelled = 1, invoice_ref = null, invoice_id = null, payment_receipt_number = null WHERE id IN ({0})",
                string.Join(",", canceledShipmentIds));

            Entities.ExecuteStoreCommand(q);
            Entities.SaveChanges();
        }

        public IEnumerable<string> GetByCodes(IEnumerable<string> codes)
        {
            var whereterm = GetQueryParameterLinq();
            var query = (from a in Entities.shipments select a)
                            .Where(whereterm, ListValue.ToArray())
                            .Where(a => codes.Contains(a.code))
                            .Select(a => a.code)
                            .ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);

            return query.ToList();
        }

        public IEnumerable<ShipmentModel> GetShipmentByCodes(IEnumerable<string> codes)
        {
            var whereterm = GetQueryParameterLinq();
            var query = (from a in Entities.shipments
                         where codes.Contains(a.code)
                         orderby a.code
                         select a)
                            .Where(whereterm, ListValue.ToArray());
            if (query == null)
                throw new Exception(MessageEntityNotFound);

            return query.Select(PopulateEntityToNewModel).ToList();
        }

        public IEnumerable<SISCO.Models.ShipmentRowModel> GetInvoiceShipment(IEnumerable<string> codes)
        {
            string[] trackingStatuses = new TrackingStatusRepository().Get<TrackingStatusModel>(WhereTerm.Default(true, "is_final_status")).Select(s => s.Id.ToString("#")).ToArray();

            var sql = @"SELECT
                            s.*,
                            (SELECT id FROM shipment_status WHERE tracking_status_id IN ({0}) AND rowstatus = 1 AND shipment_id = s.id order by createddate desc limit 1) StatusId
                        FROM shipment s
                        WHERE s.rowstatus = 1 AND s.code IN ('" + string.Join("','", codes) + "')";

            var query = @"SELECT
                            s.id Id,
	                        s.rowstatus Rowstatus,
	                        s.rowversion Rowversion,
	                        s.date_process DateProcess,
	                        s.code Code,
	                        s.branch_id BranchId,
	                        b.name BranchName,
	                        s.marketing_id MarketingId,
                            s.messenger_id MessengerId,
	                        s.messenger_name MessengerName,
                            s.messenger_id2 MessengerId2,
                            s.messenger_name2 MessengerName2,
	                        s.sales_type_id SalesTypeId,
	                        s.city_id CityId,
	                        s.city_name CityName,
	                        s.dest_city_id DestCityId,
	                        s.dest_city DestCity,
	                        s.dest_country_id DestCountryId,
	                        s.dest_country DestCountry,
	                        s.dest_branch_id DestBranchId,
	                        s.dest_branch_name DestBranchName,
	                        s.note Note,
	                        s.customer_id CustomerId,
	                        s.customer_name CustomerName,
	                        s.account_id AccountId,
	                        s.ref_number RefNumber,
	                        s.ref_code RefCode,
	                        s.personal Personal,
	                        s.personal_name PersonalName,
	                        s.shipper_name ShipperName,
	                        s.shipper_address ShipperAddress,
	                        s.shipper_postal_code ShipperPostalCode,
	                        s.shipper_city ShipperCity,
	                        s.shipper_phone ShipperPhone,
	                        s.shipper_saved ShipperSaved,
	                        s.consignee_name ConsigneeName,
	                        s.consignee_address ConsigneeAddress,
	                        s.consignee_postal_code ConsigneePostalCode,
	                        s.consignee_city ConsigneeCity,
	                        s.consignee_phone ConsigneePhone,
	                        s.consignee_saved ConsigneeSaved,
	                        s.shipping_method_id ShippingMethodId,
	                        s.service_type_id ServiceTypeId,
                            st.name ServiceType,
	                        s.package_type_id PackageTypeId,
	                        pt.name PackageType,
	                        s.payment_method_id PaymentMethodId,
	                        pm.name PaymentMethod,
	                        s.pricing_calc_type PricingCalcType,
	                        s.collect_payment_method CollectPaymentMethod,
	                        s.collect_customer_id CollectCustomerId,
	                        s.collect_customer_name CollectCustomerName,
	                        s.paid_coll PaidColl,
	                        s.total_payment_coll TotalPaymentColl,
	                        s.paid_collect PaidCollect,
	                        s.total_payment_collect TotalPaymentCollect,
	                        s.nature_of_goods NatureOfGoods,
	                        s.dimension Dimension,
	                        s.ttl_piece TtlPiece,
	                        s.ttl_gross_weight TtlGrossWeight,
	                        s.ttl_chargeable_weight TtlChargeableWeight,
	                        s.pricing_plan_id PricingPlanId,
	                        s.tariff Tariff,
	                        s.discount_percent DiscountPercent,
	                        s.discount_total DiscountTotal,
	                        s.tariff_net TariffNet,
	                        s.tariff_total TariffTotal,
	                        s.before_tax_total BeforeTaxTotal,
	                        s.vat Vat,
	                        s.after_tax_total AfterTaxTotal,
	                        s.handling_fee HandlingFee,
	                        s.handling_fee_total HandlingFeeTotal,
	                        s.surcharge_fee SurchargeFee,
	                        s.admin_fee AdminFee,
 	                        s.packing_fee PackingFee,
	                        s.other_fee OtherFee,
	                        s.void_fee VoidFee,
	                        s.goods_value GoodsValue,
	                        s.insurance_fee InsuranceFee,
	                        s.protection_type ProtectionType,
	                        s.protection_value ProtectionValue,
	                        s.protection_fee ProtectionFee,
	                        s.extra_weight ExtraWeight,
	                        s.extra_charge ExtraCharge,
	                        s.extra_charge_total ExtraChargeTotal,
	                        s.total Total,
	                        s.currency_id CurrencyId,
	                        s.currency Currency,
	                        s.currency_rate CurrencyRate,
	                        s.total_sales TotalSales,
	                        s.cancelled Cancelled,
	                        s.posted Posted,
	                        s.voided Voided,
	                        s.total_due TotalDue,
	                        s.invoice_ref InvoiceRef,
	                        s.invoice_id InvoiceId,
	                        s.payment_receipt_number PaymentReceiptNumber,
	                        s.invoiced Invoiced,
	                        s.total_invoiced TotalInvoiced,
	                        s.total_invoiced_ori TotalInvoicedOri,
	                        s.paid Paid,
	                        s.total_payment TotalPayment,
	                        s.delivery_fee_min DeliveryFeeMin,
	                        s.delivery_fee DeliveryFee,
	                        s.delivery_fee_total DeliveryFeeTotal,
	                        s.paid_delivery PaidDelivery,
	                        s.total_payment_delivery TotalPaymentDelivery,
	                        s.port_fee PortFee,
	                        s.port_fee_before_tax PortFeeBeforeTax,
	                        s.port_fee_vat PortFeeVat,
	                        s.port_fee_total PortFeeTotal,
	                        s.manifested Manifested,
	                        s.pod_needed PodNeeded,
	                        s.pod_sent PodSent,
	                        s.pod_received PodReceived,
	                        s.pod_returned PodReturned,
	                        s.mc_percent McPercent,
	                        s.mc_percent_total McPercentTotal,
	                        s.mc_kg McKg,
	                        s.mc_kg_total McKgTotal,
	                        s.mc_total McTotal,
	                        s.paid_mc PaidMc,
	                        s.total_payment_mc TotalPaymentMc,
	                        s.auto_number AutoNumber,
	                        s.need_ra NeedRa,
	                        s.acceptance_employee AcceptanceEmployee,
	                        s.data_entry_employee DataEntryEmployee,
	                        s.tracking_status_id TrackingStatusId,
	                        ts.code TrackingStatus,
	                        s.upload_status UploadStatus,
	                        s.franchise_id FranchiseId,
	                        s.promo_id PromoId,
	                        s.promo_code PromoCode,
	                        s.pod_status PODStatus,
	                        se.fulfilment Fulfilment,
	                        IF(se.shipment_id IS NULL, 0, IF(se.total_cod > 0, se.total_cod, 0)) TotalCod,
                            se.handedover Handover,
	                        s.createddate Createddate,
	                        s.createdby Createdby,
	                        s.createdpc CreatedPc,
	                        s.modifieddate Modifieddate,
	                        s.modifiedby Modifiedby,
	                        s.modifiedpc ModifiedPc,
                            IF(ISNULL(ss.dateprocess), 0, ss.tracking_status_id) AS TrackingStatusId,
	                        IF(ISNULL(ss.dateprocess), null, ss.dateprocess) AS DeliveryDate,
	                        IF(ISNULL(ss.dateprocess), 'Not Available', DATE_FORMAT(ss.dateprocess,'%d-%m-%Y')) AS DeliveryDateStr,
	                        IF(ISNULL(ss.dateprocess), '', DATE_FORMAT(ss.dateprocess,'%H:%i')) AS DeliveryTime,
	                        IF(ISNULL(ss.dateprocess), '', ss.status_by) AS RecipientName,
	                        IF(ss.miss_delivery_reason = '', ss.status_note, ss.miss_delivery_reason) AS DeliveryNote
                        FROM (" + sql + @") s
                        INNER JOIN siscodb.payment_method pm ON s.payment_method_id = pm.id
                        INNER JOIN siscodb.service_type st ON s.service_type_id = st.id
                        INNER JOIN siscodb.package_type pt ON s.package_type_id = pt.id
                        INNER JOIN siscodb.tracking_status ts ON s.tracking_status_id = ts.id
                        INNER JOIN siscodb.branch b ON s.branch_id = b.id
                        LEFT JOIN siscodb.shipment_expand se ON s.id = se.shipment_id
                        LEFT JOIN shipment_status ss ON StatusId = ss.id
                        ORDER BY DATE_FORMAT(s.date_process, '%Y-%M-%d') ASC, s.code ASC";
            var executeSql = string.Format(query, string.Join(",", trackingStatuses));
            return Entities.ExecuteStoreQuery<SISCO.Models.ShipmentRowModel>(executeSql).ToList();
        }

        public IEnumerable<ShipmentModel.ShipmentReportRow> IncomingList(IListParameter[] parameter, IListParameter[] parameter2)
        {
            var whereterm = GetQueryParameterLinq(parameter);

            var sql = @"SELECT
	                        s.id Id,
	                        s.rowstatus Rowstatus,
	                        s.rowversion Rowversion,
	                        s.date_process DateProcess,
	                        s.code Code,
	                        s.branch_id BranchId,
	                        s.marketing_id MarketingId,
	                        s.messenger_id MessengerId,
	                        s.messenger_name MessengerName,
                            s.messenger_id2 MessengerId2,
                            s.messenger_name2 MessengerName2,
	                        s.sales_type_id SalesTypeId,
	                        s.city_id CityId,
	                        s.city_name CityName,
	                        s.dest_city_id DestCityId,
	                        s.dest_city DestCity,
	                        s.dest_country_id DestCountryId,
	                        s.dest_country DestCountry,
	                        s.dest_branch_id DestBranchId,
	                        s.dest_branch_name DestBranchName,
	                        s.note Note,
	                        s.customer_id CustomerId,
	                        s.customer_name CustomerName,
	                        s.account_id AccountId,
	                        s.ref_number RefNumber,
	                        s.ref_code RefCode,
	                        s.personal Personal,
	                        s.personal_name PersonalName,
	                        s.shipper_name ShipperName,
	                        s.shipper_address ShipperAddress,
	                        s.shipper_postal_code ShipperPostalCode,
	                        s.shipper_city ShipperCity,
	                        s.shipper_phone ShipperPhone,
	                        s.shipper_saved ShipperSaved,
	                        s.consignee_name ConsigneeName,
	                        s.consignee_address ConsigneeAddress,
	                        s.consignee_postal_code ConsigneePostalCode,
	                        s.consignee_city ConsigneeCity,
	                        s.consignee_phone ConsigneePhone,
	                        s.consignee_saved ConsigneeSaved,
	                        s.shipping_method_id ShippingMethodId,
	                        s.service_type_id ServiceTypeId,
                            st.name ServiceType,
	                        s.package_type_id PackageTypeId,
	                        IF (inbound.shipment_id IS NULL, 0, 1) Inbound,
	                        t.name PackageType,
	                        s.payment_method_id PaymentMethodId,
	                        p.name PaymentMethod,
	                        s.pricing_calc_type PricingCalcType,
	                        s.collect_payment_method CollectPaymentMethod,
	                        s.collect_customer_id CollectCustomerId,
	                        s.collect_customer_name CollectCustomerName,
	                        s.paid_coll PaidColl,
	                        s.total_payment_coll TotalPaymentColl,
	                        s.paid_collect PaidCollect,
	                        s.total_payment_collect TotalPaymentCollect,
	                        s.nature_of_goods NatureOfGoods,
	                        s.dimension Dimension,
	                        s.ttl_piece TtlPiece,
	                        s.ttl_gross_weight TtlGrossWeight,
	                        s.ttl_chargeable_weight TtlChargeableWeight,
	                        s.pricing_plan_id PricingPlanId,
	                        s.tariff Tariff,
	                        s.discount_percent DiscountPercent,
	                        s.discount_total DiscountTotal,
	                        s.tariff_net TariffNet,
	                        s.tariff_total TariffTotal,
	                        s.before_tax_total BeforeTaxTotal,
	                        s.vat Vat,
	                        s.after_tax_total AfterTaxTotal,
	                        s.handling_fee HandlingFee,
	                        s.handling_fee_total HandlingFeeTotal,
	                        s.surcharge_fee SurchargeFee,
	                        s.admin_fee AdminFee,
	                        s.packing_fee PackingFee,
	                        s.other_fee OtherFee,
	                        s.void_fee VoidFee,
	                        s.goods_value GoodsValue,
	                        s.insurance_fee InsuranceFee,
	                        s.protection_type ProtectionType,
	                        s.protection_value ProtectionValue,
	                        s.protection_fee ProtectionFee,
	                        s.extra_weight ExtraWeight,
	                        s.extra_charge ExtraCharge,
	                        s.extra_charge_total ExtraChargeTotal,
	                        s.total Total,
	                        s.currency_id CurrencyId,
	                        s.currency Currency,
	                        s.currency_rate CurrencyRate,
	                        s.total_sales TotalSales,
	                        s.cancelled Cancelled,
	                        s.posted Posted,
	                        s.voided Voided,
	                        s.total_due TotalDue,
	                        s.invoice_ref InvoiceRef,
	                        s.invoice_id InvoiceId,
	                        s.payment_receipt_number PaymentReceiptNumber,
	                        s.invoiced Invoiced,
	                        s.total_invoiced TotalInvoiced,
	                        s.total_invoiced_ori TotalInvoicedOri,
	                        s.paid Paid,
	                        s.total_payment TotalPayment,
	                        s.delivery_fee_min DeliveryFeeMin,
	                        s.delivery_fee DeliveryFee,
	                        s.delivery_fee_total DeliveryFeeTotal,
	                        s.paid_delivery PaidDelivery,
	                        s.total_payment_delivery TotalPaymentDelivery,
	                        s.port_fee PortFee,
	                        s.port_fee_before_tax PortFeeBeforeTax,
	                        s.port_fee_vat PortFeeVat,
	                        s.port_fee_total PortFeeTotal,
	                        s.manifested Manifested,
	                        s.pod_needed PodNeeded,
	                        s.pod_sent PodSent,
	                        s.pod_received PodReceived,
	                        s.pod_returned PodReturned,
	                        s.mc_percent McPercent,
	                        s.mc_percent_total McPercentTotal,
	                        s.mc_kg McKg,
	                        s.mc_kg_total McKgTotal,
	                        s.mc_total McTotal,
	                        s.paid_mc PaidMc,
	                        s.total_payment_mc TotalPaymentMc,
	                        s.auto_number AutoNumber,
	                        s.need_ra NeedRa,
	                        s.acceptance_employee AcceptanceEmployee,
	                        s.data_entry_employee DataEntryEmployee,
	                        IF (s.tracking_status_id IS NULL, 0 , s.tracking_status_id) TrackingStatusId,
	                        IF (ts.id IS NULL, 'Not Available', 
		                        IF (LOWER(ts.code) = LOWER('RECEIVED') OR LOWER(ts.code) = LOWER('LOSS') OR LOWER(ts.code) = LOWER('RETURNED'), ts.code, 
			                        'Not Available'
		                        )
	                        ) TrackingStatus,
	                        s.upload_status UploadStatus,
	                        s.franchise_id FranchiseId,
	                        s.promo_id PromoId,
	                        s.promo_code PromoCode,
	                        s.pod_status PODStatus,
	                        MAX(manifest.dateprocess) ManifestDate,
	                        IF (se.shipment_id IS NULL, 0, se.iscod) IsCod,
	                        IF (se.shipment_id IS NULL, 0, se.total_cod) TotalCod,
	                        s.createddate Createddate,
	                        s.createdby Createdby,
	                        s.createdpc CreatedPc,
	                        s.modifieddate Modifieddate,
	                        s.modifiedby Modifiedby,
	                        s.modifiedpc ModifiedPc
                        FROM shipment s
                        INNER JOIN payment_method p ON s.payment_method_id = p.id
                        INNER JOIN package_type t ON s.package_type_id = t.id
                        INNER JOIN service_type st ON s.service_type_id = st.id
                        LEFT JOIN shipment_expand se ON s.id = se.shipment_id
                        LEFT JOIN tracking_status ts ON s.tracking_status_id = ts.id
                        LEFT JOIN shipment_status inbound ON s.id = inbound.shipment_id AND inbound.rowstatus = 1 AND inbound.tracking_status_id = 7
                        LEFT JOIN shipment_status manifest ON s.id = manifest.shipment_id AND manifest.rowstatus = 1 AND manifest.tracking_status_id = 3
                        WHERE {0}
                        GROUP BY s.code";

            List<string> l = new List<string>();
            for (var i = 0; i < ListClause.Count; i++) l.Add(string.Format("s.{0}", ListClause[i]));
            var whereterm2 = GetQueryParameterLinq(parameter2);
            for (var i = 0; i < ListClause.Count; i++) ListClause[i] = string.Format("s.{0}", ListClause[i]);

            sql = string.Format(sql, string.Join(" AND ", l));

            var result = Entities.ExecuteStoreQuery<ShipmentModel.ShipmentReportRow>(sql).ToList();

            sql = @"SELECT
	                        s.id Id,
	                        s.rowstatus Rowstatus,
	                        s.rowversion Rowversion,
	                        s.date_process DateProcess,
	                        s.code Code,
	                        s.branch_id BranchId,
	                        s.marketing_id MarketingId,
	                        s.messenger_id MessengerId,
	                        s.messenger_name MessengerName,
                            s.messenger_id2 MessengerId2,
                            s.messenger_name2 MessengerName2,
	                        s.sales_type_id SalesTypeId,
	                        s.city_id CityId,
	                        s.city_name CityName,
	                        s.dest_city_id DestCityId,
	                        s.dest_city DestCity,
	                        s.dest_country_id DestCountryId,
	                        s.dest_country DestCountry,
	                        s.dest_branch_id DestBranchId,
	                        s.dest_branch_name DestBranchName,
	                        s.note Note,
	                        s.customer_id CustomerId,
	                        s.customer_name CustomerName,
	                        s.account_id AccountId,
	                        s.ref_number RefNumber,
	                        s.ref_code RefCode,
	                        s.personal Personal,
	                        s.personal_name PersonalName,
	                        s.shipper_name ShipperName,
	                        s.shipper_address ShipperAddress,
	                        s.shipper_postal_code ShipperPostalCode,
	                        s.shipper_city ShipperCity,
	                        s.shipper_phone ShipperPhone,
	                        s.shipper_saved ShipperSaved,
	                        s.consignee_name ConsigneeName,
	                        s.consignee_address ConsigneeAddress,
	                        s.consignee_postal_code ConsigneePostalCode,
	                        s.consignee_city ConsigneeCity,
	                        s.consignee_phone ConsigneePhone,
	                        s.consignee_saved ConsigneeSaved,
	                        s.shipping_method_id ShippingMethodId,
	                        s.service_type_id ServiceTypeId,
                            'RETUR' ServiceType,
	                        s.package_type_id PackageTypeId,
	                        IF (inbound.shipment_id IS NULL, 0, 1) Inbound,
	                        t.name PackageType,
	                        s.payment_method_id PaymentMethodId,
	                        p.name PaymentMethod,
	                        s.pricing_calc_type PricingCalcType,
	                        s.collect_payment_method CollectPaymentMethod,
	                        s.collect_customer_id CollectCustomerId,
	                        s.collect_customer_name CollectCustomerName,
	                        s.paid_coll PaidColl,
	                        s.total_payment_coll TotalPaymentColl,
	                        s.paid_collect PaidCollect,
	                        s.total_payment_collect TotalPaymentCollect,
	                        s.nature_of_goods NatureOfGoods,
	                        s.dimension Dimension,
	                        s.ttl_piece TtlPiece,
	                        s.ttl_gross_weight TtlGrossWeight,
	                        s.ttl_chargeable_weight TtlChargeableWeight,
	                        s.pricing_plan_id PricingPlanId,
	                        s.tariff Tariff,
	                        s.discount_percent DiscountPercent,
	                        s.discount_total DiscountTotal,
	                        s.tariff_net TariffNet,
	                        s.tariff_total TariffTotal,
	                        s.before_tax_total BeforeTaxTotal,
	                        s.vat Vat,
	                        s.after_tax_total AfterTaxTotal,
	                        s.handling_fee HandlingFee,
	                        s.handling_fee_total HandlingFeeTotal,
	                        s.surcharge_fee SurchargeFee,
	                        s.admin_fee AdminFee,
	                        s.packing_fee PackingFee,
	                        s.other_fee OtherFee,
	                        s.void_fee VoidFee,
	                        s.goods_value GoodsValue,
	                        s.insurance_fee InsuranceFee,
	                        s.protection_type ProtectionType,
	                        s.protection_value ProtectionValue,
	                        s.protection_fee ProtectionFee,
	                        s.extra_weight ExtraWeight,
	                        s.extra_charge ExtraCharge,
	                        s.extra_charge_total ExtraChargeTotal,
	                        s.total Total,
	                        s.currency_id CurrencyId,
	                        s.currency Currency,
	                        s.currency_rate CurrencyRate,
	                        s.total_sales TotalSales,
	                        s.cancelled Cancelled,
	                        s.posted Posted,
	                        s.voided Voided,
	                        s.total_due TotalDue,
	                        s.invoice_ref InvoiceRef,
	                        s.invoice_id InvoiceId,
	                        s.payment_receipt_number PaymentReceiptNumber,
	                        s.invoiced Invoiced,
	                        s.total_invoiced TotalInvoiced,
	                        s.total_invoiced_ori TotalInvoicedOri,
	                        s.paid Paid,
	                        s.total_payment TotalPayment,
	                        s.delivery_fee_min DeliveryFeeMin,
	                        s.delivery_fee DeliveryFee,
	                        s.delivery_fee_total DeliveryFeeTotal,
	                        s.paid_delivery PaidDelivery,
	                        s.total_payment_delivery TotalPaymentDelivery,
	                        s.port_fee PortFee,
	                        s.port_fee_before_tax PortFeeBeforeTax,
	                        s.port_fee_vat PortFeeVat,
	                        s.port_fee_total PortFeeTotal,
	                        s.manifested Manifested,
	                        s.pod_needed PodNeeded,
	                        s.pod_sent PodSent,
	                        s.pod_received PodReceived,
	                        s.pod_returned PodReturned,
	                        s.mc_percent McPercent,
	                        s.mc_percent_total McPercentTotal,
	                        s.mc_kg McKg,
	                        s.mc_kg_total McKgTotal,
	                        s.mc_total McTotal,
	                        s.paid_mc PaidMc,
	                        s.total_payment_mc TotalPaymentMc,
	                        s.auto_number AutoNumber,
	                        s.need_ra NeedRa,
	                        s.acceptance_employee AcceptanceEmployee,
	                        s.data_entry_employee DataEntryEmployee,
	                        retur.tracking_status_id TrackingStatusId,
	                        IF (ts.id IS NULL, 'Not Available', 
		                        IF (LOWER(ts.code) = LOWER('RECEIVED') OR LOWER(ts.code) = LOWER('LOSS') OR LOWER(ts.code) = LOWER('RETURNED'), ts.code, 
			                        'Not Available'
		                        )
	                        ) TrackingStatus,
	                        s.upload_status UploadStatus,
	                        s.franchise_id FranchiseId,
	                        s.promo_id PromoId,
	                        s.promo_code PromoCode,
	                        s.pod_status PODStatus,
	                        MAX(manifest.dateprocess) ManifestDate,
	                        IF (se.shipment_id IS NULL, 0, se.iscod) IsCod,
	                        IF (se.shipment_id IS NULL, 0, se.total_cod) TotalCod,
	                        s.createddate Createddate,
	                        s.createdby Createdby,
	                        s.createdpc CreatedPc,
	                        s.modifieddate Modifieddate,
	                        s.modifiedby Modifiedby,
	                        s.modifiedpc ModifiedPc
                        FROM shipment s
                        INNER JOIN payment_method p ON s.payment_method_id = p.id
                        INNER JOIN package_type t ON s.package_type_id = t.id
                        INNER JOIN shipment_status retur ON s.id = retur.shipment_id AND retur.rowstatus = 1 AND retur.tracking_status_id = 12
                        LEFT JOIN shipment_expand se ON s.id = se.shipment_id
                        LEFT JOIN tracking_status ts ON retur.tracking_status_id = ts.id
                        LEFT JOIN shipment_status inbound ON s.id = inbound.shipment_id AND inbound.rowstatus = 1 AND inbound.tracking_status_id = 7
                        LEFT JOIN shipment_status manifest ON s.id = manifest.shipment_id AND manifest.rowstatus = 1 AND manifest.tracking_status_id = 3
                        WHERE {0} AND s.tracking_status_id NOT IN (10, 11)
                        GROUP BY s.code";

            sql = string.Format(sql, string.Join(" AND ", ListClause));
            result.AddRange(Entities.ExecuteStoreQuery<ShipmentModel.ShipmentReportRow>(sql).ToList());
            return result;
        }

        public IEnumerable<ReportDeliveryJournal> ReportDeliveryJournalBranch(IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.shipments select a).Where(whereterm, ListValue.ToArray());
            if (query == null)
                throw new Exception(MessageEntityNotFound);

            var obj = (from a in query
                join b1 in Entities.branches on a.branch_id equals b1.id
                join b2 in Entities.branches on a.dest_branch_id equals b2.id
                select new ReportDeliveryJournal
                {
                    branch_name = b1.name,
                    code = a.code,
                    date_process = a.date_process,
                    dest_branch_name = b2.name,
                    dest_branch_id = b2.id,
                    ttl_piece = a.ttl_piece,
                    ttl_chargeable_weight = a.ttl_chargeable_weight,
                    delivery_fee = a.delivery_fee,
                    delivery_fee_total = a.delivery_fee_total
                });

            return obj.ToList();
        }

        public IEnumerable<ShipmentModel> DataEntryReport(int branchId, DateTime? from, DateTime? to, string employeFrom = null, string employeeTo = null)
        {
            var sql = @"SELECT
	                        s.id Id,
	                        s.rowstatus Rowstatus,
	                        s.rowversion Rowversion,
	                        s.date_process DateProcess,
	                        s.code Code,
	                        s.branch_id BranchId,
	                        b.code BranchName,
	                        s.marketing_id MarketingId,
	                        s.messenger_id MessengerId,
	                        s.messenger_name MessengerName,
                            s.messenger_id2 MessengerId2,
                            s.messenger_name2 MessengerName2,
	                        s.sales_type_id SalesTypeId,
	                        s.city_id CityId,
	                        s.city_name CityName,
	                        s.dest_city_id DestCityId,
	                        s.dest_city DestCity,
	                        s.dest_country_id DestCountryId,
	                        s.dest_country DestCountry,
	                        s.dest_branch_id DestBranchId,
	                        s.dest_branch_name DestBranchName,
	                        s.note Note,
	                        s.customer_id CustomerId,
	                        s.customer_name CustomerName,
	                        s.account_id AccountId,
	                        s.ref_number RefNumber,
	                        s.ref_code RefCode,
	                        s.personal Personal,
	                        s.personal_name PersonalName,
	                        s.shipper_name ShipperName,
	                        s.shipper_address ShipperAddress,
	                        s.shipper_postal_code ShipperPostalCode,
	                        s.shipper_city ShipperCity,
	                        s.shipper_phone ShipperPhone,
	                        s.shipper_saved ShipperSaved,
	                        s.consignee_name ConsigneeName,
	                        s.consignee_address ConsigneeAddress,
	                        s.consignee_postal_code ConsigneePostalCode,
	                        s.consignee_city ConsigneeCity,
	                        s.consignee_phone ConsigneePhone,
	                        s.consignee_saved ConsigneeSaved,
	                        s.shipping_method_id ShippingMethodId,
	                        s.service_type_id ServiceTypeId,
	                        s.package_type_id PackageTypeId,
	                        s.payment_method_id PaymentMethodId,
	                        s.pricing_calc_type PricingCalcType,
	                        s.collect_payment_method CollectPaymentMethod,
	                        s.collect_customer_id CollectCustomerId,
	                        s.collect_customer_name CollectCustomerName,
	                        s.paid_coll PaidColl,
	                        s.total_payment_coll TotalPaymentColl,
	                        s.paid_collect PaidCollect,
	                        s.total_payment_collect TotalPaymentCollect,
	                        s.nature_of_goods NatureOfGoods,
	                        s.dimension Dimension,
	                        s.ttl_piece TtlPiece,
	                        s.ttl_gross_weight TtlGrossWeight,
	                        s.ttl_chargeable_weight TtlChargeableWeight,
	                        s.pricing_plan_id PricingPlanId,
	                        s.tariff Tariff,
	                        s.discount_percent DiscountPercent,
	                        s.discount_total DiscountTotal,
	                        s.tariff_net TariffNet,
	                        s.tariff_total TariffTotal,
	                        s.before_tax_total BeforeTaxTotal,
	                        s.vat Vat,
	                        s.after_tax_total AfterTaxTotal,
	                        s.handling_fee HandlingFee,
	                        s.handling_fee_total HandlingFeeTotal,
	                        s.surcharge_fee SurchargeFee,
	                        s.admin_fee AdminFee,
	                        s.packing_fee PackingFee,
	                        s.other_fee OtherFee,
	                        s.void_fee VoidFee,
	                        s.goods_value GoodsValue,
	                        s.insurance_fee InsuranceFee,
	                        s.protection_type ProtectionType,
	                        s.protection_value ProtectionValue,
	                        s.protection_fee ProtectionFee,
	                        s.extra_weight ExtraWeight,
	                        s.extra_charge ExtraCharge,
	                        s.extra_charge_total ExtraChargeTotal,
	                        s.total Total,
	                        s.currency_id CurrencyId,
	                        s.currency Currency,
	                        s.currency_rate CurrencyRate,
	                        s.total_sales TotalSales,
	                        s.cancelled Cancelled,
	                        s.posted Posted,
	                        s.voided Voided,
	                        s.total_due TotalDue,
	                        s.invoice_ref InvoiceRef,
	                        s.invoice_id InvoiceId,
	                        s.payment_receipt_number PaymentReceiptNumber,
	                        s.invoiced Invoiced,
	                        s.total_invoiced TotalInvoiced,
	                        s.total_invoiced_ori TotalInvoicedOri,
	                        s.paid Paid,
	                        s.total_payment TotalPayment,
	                        s.delivery_fee_min DeliveryFeeMin,
	                        s.delivery_fee DeliveryFee,
	                        s.delivery_fee_total DeliveryFeeTotal,
	                        s.paid_delivery PaidDelivery,
	                        s.total_payment_delivery TotalPaymentDelivery,
	                        s.port_fee PortFee,
	                        s.port_fee_before_tax PortFeeBeforeTax,
	                        s.port_fee_vat PortFeeVat,
	                        s.port_fee_total PortFeeTotal,
	                        s.manifested Manifested,
	                        s.pod_needed PodNeeded,
	                        s.pod_sent PodSent,
	                        s.pod_received PodReceived,
	                        s.pod_returned PodReturned,
	                        s.mc_percent McPercent,
	                        s.mc_percent_total McPercentTotal,
	                        s.mc_kg McKg,
	                        s.mc_kg_total McKgTotal,
	                        s.mc_total McTotal,
	                        s.paid_mc PaidMc,
	                        s.total_payment_mc TotalPaymentMc,
	                        s.auto_number AutoNumber,
	                        s.need_ra NeedRa,
	                        e.name AcceptanceEmployee,
	                        s.data_entry_employee DataEntryEmployee,
	                        s.upload_status UploadStatus,
	                        s.franchise_id FranchiseId,
	                        s.promo_id PromoId,
	                        s.promo_code PromoCode,
	                        s.pod_status PODStatus,
	                        s.createddate Createddate,
	                        s.createdby Createdby,
	                        s.createdpc CreatedPc,
	                        s.modifieddate Modifieddate,
	                        s.modifiedby Modifiedby,
	                        s.modifiedpc ModifiedPc
                        FROM siscodb.shipment s
                        INNER JOIN siscodb.branch b ON s.branch_id = b.id
                        INNER JOIN siscodb.employee e ON s.data_entry_employee = e.code
                        WHERE s.rowstatus = 1 AND s.branch_id = {0}{1}{2}
                        ORDER BY s.data_entry_employee";

            var dateFilter = string.Empty;
            if (from != null) dateFilter += string.Format(" AND s.date_process >= '{0}'", ((DateTime)from).ToString("yyyy-MM-dd HH:mm:ss"));
            if (to != null) dateFilter += string.Format(" AND s.date_process <= '{0}'", ((DateTime)to).ToString("yyyy-MM-dd HH:mm:ss"));

            var employeeFilter = string.Empty;
            if (!string.IsNullOrEmpty(employeFrom)) employeeFilter += string.Format(" AND s.data_entry_employee >= '{0}'", employeFrom);
            if (!string.IsNullOrEmpty(employeeTo)) employeeFilter += string.Format(" AND s.data_entry_employee <= '{0}'", employeeTo);

            sql = string.Format(sql, branchId, dateFilter, employeeFilter);
            return Entities.ExecuteStoreQuery<ShipmentModel>(sql).ToList();
        }

        public IEnumerable<T> GetShipmentFinalStatusSummary<T>(DateTime? fromDate, DateTime? toDate, int? branchId)
        {
            var parameters = new List<MySqlParameter>();
            var whereClauses = new List<string>();

            whereClauses.Add("rowstatus = @rowstatus");
            parameters.Add(new MySqlParameter("rowstatus", 1));

            if (fromDate != null && fromDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(date_process) >= DATE(@dateFrom)");
                parameters.Add(new MySqlParameter("dateFrom", fromDate));
            }

            if (toDate != null && toDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(date_process) <= DATE(@toDate)");
                parameters.Add(new MySqlParameter("toDate", toDate));
            }

            if (branchId != null && branchId != 0)
            {
                whereClauses.Add("branch_id = @branchId");
                parameters.Add(new MySqlParameter("branchId", branchId));
            }

            string sql = @"SELECT s.date_process,
                                b.code as branch_code,
                                b.name as branch_name,
                                s.total_shipments_count,
                                s.in_progress_count,
                                s.received_count,
                                s.loss_count,
                                s.return_count
                        FROM (
                            SELECT DATE(date_process) AS date_process,
                                    branch_id,
                                    COUNT(1) AS total_shipments_count,
                                    SUM(tracking_status_id NOT IN (10, 11, 12)) AS in_progress_count,
                                    SUM(tracking_status_id = 10) AS received_count,
                                    SUM(tracking_status_id = 11) AS loss_count,
                                    SUM(tracking_status_id = 12) AS return_count
                            FROM shipment
                            WHERE " + string.Join(" AND ", whereClauses) + @"
                            GROUP BY DATE(date_process), branch_id
                        ) s
                        JOIN branch b ON b.id = s.branch_id
                        ORDER BY s.date_process ASC";

            // ReSharper disable once CoVariantArrayConversion
            return Entities.ExecuteStoreQuery<T>(sql, parameters.ToArray()).ToList();
        }

        public IEnumerable<T> GetUnmanifestList<T>(DateTime? fromDate, DateTime? toDate, int? paymentMethodId, int? branchId)
        {
            var parameters = new List<MySqlParameter>();
            var whereClauses = new List<string>();

            whereClauses.Add("s.rowstatus = @rowstatus");
            parameters.Add(new MySqlParameter("rowstatus", 1));

            if (fromDate != null && fromDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(s.date_process) >= DATE(@dateFrom)");
                parameters.Add(new MySqlParameter("dateFrom", fromDate));
            }

            if (toDate != null && toDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(s.date_process) <= DATE(@toDate)");
                parameters.Add(new MySqlParameter("toDate", toDate));
            }

            if (paymentMethodId != null && paymentMethodId != 0)
            {
                whereClauses.Add("s.payment_method_id = @paymentMethodId");
                parameters.Add(new MySqlParameter("paymentMethodId", paymentMethodId));
            }

            if (paymentMethodId != null && paymentMethodId != 0)
            {
                whereClauses.Add("s.branch_id = @branchId");
                parameters.Add(new MySqlParameter("branchId", branchId));
            }

            string sql = @"SELECT s.code,
                                s.date_process,
                                s.dest_city,
                                pm.name as payment_method_name,
                                s.ttl_piece,
                                s.ttl_chargeable_weight
                        FROM shipment s
                        LEFT JOIN payment_method pm ON pm.id = s.payment_method_id
                        WHERE " + string.Join(" AND ", whereClauses);

            // ReSharper disable once CoVariantArrayConversion
            return Entities.ExecuteStoreQuery<T>(sql, parameters.ToArray()).ToList();
        }

        public IEnumerable<T> GetAgingSummary<T>(DateTime? fromDate, DateTime? toDate, int? branchId, int? customerId, int? destCityId)
        {
            var parameters = new List<MySqlParameter>();
            var whereClauses = new List<string>();

            whereClauses.Add("s.rowstatus = @rowstatus");
            parameters.Add(new MySqlParameter("rowstatus", 1));

            if (fromDate != null && fromDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(s.date_process) >= DATE(@dateFrom)");
                parameters.Add(new MySqlParameter("dateFrom", fromDate));
            }

            if (toDate != null && toDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(s.date_process) <= DATE(@toDate)");
                parameters.Add(new MySqlParameter("toDate", toDate));
            }

            if (branchId != null && branchId != 0)
            {
                whereClauses.Add("s.branch_id = @branchId");
                parameters.Add(new MySqlParameter("branchId", branchId));
            }

            if (customerId != null && customerId != 0)
            {
                whereClauses.Add("s.customer_id = @customerId");
                parameters.Add(new MySqlParameter("customerId", customerId));
            }

            if (destCityId != null && destCityId != 0)
            {
                whereClauses.Add("s.dest_city_id = @destCityId");
                parameters.Add(new MySqlParameter("destCityId", destCityId));
            }

            string sql = @"SELECT s.code,
                                s.date_process,
                                s.dest_city,
                                b.code as branch_code,
                                s.ttl_piece,
                                s.ttl_chargeable_weight,
                                s.tariff_total,
                                ss1.dateprocess AS delivery_date,
                                IFNULL(DATEDIFF(CURDATE(), ss1.dateprocess), 0) AS age
                        FROM shipment s
                        LEFT JOIN branch b ON b.id = s.branch_id
                        LEFT JOIN shipment_status AS ss1 ON s.id = ss1.shipment_id AND ss1.tracking_status_id = 8 AND ss1.rowstatus = 1
                        LEFT JOIN shipment_status AS ss2 ON s.id = ss2.shipment_id AND ss2.tracking_status_id = 8 AND ss2.rowstatus = 1 AND ss1.id < ss2.id
                        WHERE ss2.id IS NULL
                        AND s.pod_received = 0
                        AND " + string.Join(" AND ", whereClauses);

            // ReSharper disable once CoVariantArrayConversion
            return Entities.ExecuteStoreQuery<T>(sql, parameters.ToArray()).ToList();
        }

        public IEnumerable<T> GetVoidList<T>(DateTime? fromDate, DateTime? toDate, int? branchId, int? customerId, int? destCityId, int? paymentMethodId)
        {
            var parameters = new List<MySqlParameter>();
            var whereClauses = new List<string>();

            whereClauses.Add("s.rowstatus = @rowstatus");
            parameters.Add(new MySqlParameter("rowstatus", 1));

            if (fromDate != null && fromDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(s.date_process) >= DATE(@dateFrom)");
                parameters.Add(new MySqlParameter("dateFrom", fromDate));
            }

            if (toDate != null && toDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(s.date_process) <= DATE(@toDate)");
                parameters.Add(new MySqlParameter("toDate", toDate));
            }

            if (branchId != null && branchId != 0)
            {
                whereClauses.Add("s.branch_id = @branchId");
                parameters.Add(new MySqlParameter("branchId", branchId));
            }

            if (customerId != null && customerId != 0)
            {
                whereClauses.Add("s.customer_id = @customerId");
                parameters.Add(new MySqlParameter("customerId", customerId));
            }

            if (destCityId != null && destCityId != 0)
            {
                whereClauses.Add("s.dest_city_id = @destCityId");
                parameters.Add(new MySqlParameter("destCityId", destCityId));
            }

            if (paymentMethodId != null && paymentMethodId != 0)
            {
                whereClauses.Add("s.payment_method_id = @paymentMethodId");
                parameters.Add(new MySqlParameter("paymentMethodId", paymentMethodId));
            }

            string sql = @"SELECT s.code,
                                s.date_process,
                                s.dest_city,
                                s.customer_name as shipper_name,
                                s.consignee_name,
                                b.code as branch_code,
                                s.ttl_piece,
                                s.ttl_chargeable_weight,
                                s.tariff_total
                        FROM shipment s
                        LEFT JOIN branch b ON b.id = s.branch_id
                        WHERE s.voided = 1
                        AND " + string.Join(" AND ", whereClauses);

            return Entities.ExecuteStoreQuery<T>(sql, parameters.ToArray()).ToList();
        }

        public IEnumerable<T> GetCustomerLastOrder<T>(int? customerIdFrom, int? customerIdTo, bool? customerIsActive, int? branchId)
        {
            var parameters = new List<MySqlParameter>();
            var whereClauses = new List<string>();

            whereClauses.Add("c.rowstatus = @rowstatus");
            parameters.Add(new MySqlParameter("rowstatus", 1));

            if (customerIdFrom != null && customerIdFrom != 0)
            {
                whereClauses.Add("c.id >= @customerIdFrom");
                parameters.Add(new MySqlParameter("customerIdFrom", customerIdFrom));
            }

            if (customerIdTo != null && customerIdTo != 0)
            {
                whereClauses.Add("c.id <= @customerIdTo");
                parameters.Add(new MySqlParameter("customerIdTo", customerIdTo));
            }

            if (customerIsActive != null)
            {
                whereClauses.Add("c.disabled = @disabled");
                parameters.Add(new MySqlParameter("disabled", !customerIsActive));
            }

            if (branchId != null)
            {
                whereClauses.Add("c.branch_id = @branchId");
                parameters.Add(new MySqlParameter("branchId", branchId));
            }

            string sql = @"SELECT c.code,
                                c.name,
                                c.address,
                                b.code as branch_code,
                                c.phone,
                                s.date_process AS last_order
                        FROM customer c
                        LEFT JOIN branch b ON b.id = c.branch_id
                        LEFT JOIN (
                            SELECT customer_id, MAX(date_process) AS date_process
                            FROM shipment s
                            WHERE s.rowstatus = 1
                            GROUP BY customer_id
                        ) s ON s.customer_id = c.id
                        WHERE " + string.Join(" AND ", whereClauses);

            return Entities.ExecuteStoreQuery<T>(sql, parameters.ToArray()).ToList();
        }

        public IEnumerable<T> ReportSalesJournal<T>(
            int? branchId,
            DateTime? fromDate, DateTime? toDate,
            int? destBranchIdFrom, int? destBranchIdTo,
            int? marketingIdFrom, int? marketingIdTo,
            int? customerIdFrom, int? customerIdTo,
            int? destCityIdFrom, int? destCityIdTo,
            int? serviceTypeIdFrom, int? serviceTypeIdTo,
            int? employeeIdFrom = null, int? employeeIdTo = null,
            int? paymentMethodId = null, int? marketingid = null,
            int? customerId = null
            )
        {
            var parameters = new List<MySqlParameter>();
            var whereClauses = new List<string>();

            whereClauses.Add("s.rowstatus = @rowstatus");
            parameters.Add(new MySqlParameter("rowstatus", 1));

            whereClauses.Add("s.branch_id = @branchId");
            parameters.Add(new MySqlParameter("branchId", branchId));

            if (fromDate != null && fromDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(s.date_process) >= DATE(@dateFrom)");
                parameters.Add(new MySqlParameter("dateFrom", fromDate.Value.ToString("yyyy-MM-dd HH:mm:ss")));
            }

            if (toDate != null && toDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(s.date_process) <= DATE(@toDate)");
                parameters.Add(new MySqlParameter("toDate", toDate.Value.ToString("yyyy-MM-dd HH:mm:ss")));
            }

            if (destBranchIdFrom != null && destBranchIdFrom != 0)
            {
                whereClauses.Add("s.dest_branch_id >= @destBranchIdFrom");
                parameters.Add(new MySqlParameter("destBranchIdFrom", destBranchIdFrom));
            }

            if (destBranchIdTo != null && destBranchIdTo != 0)
            {
                whereClauses.Add("s.dest_branch_id <= @destBranchIdTo");
                parameters.Add(new MySqlParameter("destBranchIdTo", destBranchIdTo));
            }

            if (marketingIdFrom != null && marketingIdFrom != 0)
            {
                whereClauses.Add("m.id >= @marketingIdFrom");
                parameters.Add(new MySqlParameter("marketingIdFrom", marketingIdFrom));
            }

            if (marketingIdTo != null && marketingIdTo != 0)
            {
                whereClauses.Add("m.id <= @marketingIdTo");
                parameters.Add(new MySqlParameter("marketingIdTo", marketingIdTo));
            }

            if (customerIdFrom != null && customerIdFrom != 0)
            {
                whereClauses.Add("s.customer_id >= @customerIdFrom");
                parameters.Add(new MySqlParameter("customerIdFrom", customerIdFrom));
            }

            if (customerIdTo != null && customerIdTo != 0)
            {
                whereClauses.Add("s.customer_id <= @customerIdTo");
                parameters.Add(new MySqlParameter("customerIdTo", customerIdTo));
            }

            if (destCityIdFrom != null && destCityIdFrom != 0)
            {
                whereClauses.Add("s.dest_city_id >= @destCityIdFrom");
                parameters.Add(new MySqlParameter("destCityIdFrom", destCityIdFrom));
            }

            if (destCityIdTo != null && destCityIdTo != 0)
            {
                whereClauses.Add("s.dest_city_id <= @destCityIdTo");
                parameters.Add(new MySqlParameter("destCityIdTo", destCityIdTo));
            }

            if (serviceTypeIdFrom != null && serviceTypeIdFrom != 0)
            {
                whereClauses.Add("s.service_type_id >= @serviceTypeIdFrom");
                parameters.Add(new MySqlParameter("serviceTypeIdFrom", serviceTypeIdFrom));
            }

            if (serviceTypeIdTo != null && serviceTypeIdTo != 0)
            {
                whereClauses.Add("s.service_type_id <= @serviceTypeIdTo");
                parameters.Add(new MySqlParameter("serviceTypeIdTo", serviceTypeIdTo));
            }

            if (marketingid != null)
            {
                whereClauses.Add("c.marketing_employee_id = @marketingid");
                parameters.Add(new MySqlParameter("marketingid", marketingid));
            }

            if (customerId != null)
            {
                whereClauses.Add("s.customer_id = @customerId");
                parameters.Add(new MySqlParameter("customerId", customerId));
            }

            bool isEmployeeFromFilled = employeeIdFrom != null && employeeIdFrom != 0;
            bool isEmployeeToFilled = employeeIdTo != null && employeeIdTo != 0;
            if (isEmployeeFromFilled && isEmployeeToFilled)
            {
                if (employeeIdFrom == employeeIdTo)
                {
                    whereClauses.Add("e1.id = @employeeIdFrom");
                    parameters.Add(new MySqlParameter("employeeIdFrom", employeeIdFrom.Value));
                }
                else
                {
                    if (employeeIdFrom != null && employeeIdFrom != 0)
                    {
                        whereClauses.Add("e1.id >= @employeeIdFrom");
                        parameters.Add(new MySqlParameter("employeeIdFrom", employeeIdFrom.Value));
                    }

                    if (employeeIdTo != null && employeeIdTo != 0)
                    {
                        whereClauses.Add("e1.id <= @employeeIdTo");
                        parameters.Add(new MySqlParameter("employeeIdTo", employeeIdTo.Value));
                    }
                }
            }
            else
            {
                if (isEmployeeFromFilled)
                {
                    whereClauses.Add("e1.id = @employeeIdFrom");
                    parameters.Add(new MySqlParameter("employeeIdFrom", employeeIdFrom.Value));
                }
                
                if (isEmployeeToFilled)
                {
                    whereClauses.Add("e1.id = @employeeIdTo");
                    parameters.Add(new MySqlParameter("employeeIdTo", employeeIdTo.Value));
                }
            }

            if (paymentMethodId != null && paymentMethodId != 0)
            {
                whereClauses.Add("s.payment_method_id = @paymentMethodId");
                parameters.Add(new MySqlParameter("paymentMethodId", paymentMethodId));
            }

            whereClauses.Add("s.voided = 0");

            string sql = @"SELECT
                            s.dest_branch_id,
                            b.name as dest_branch_name,
                            c.marketing_employee_id as marketing_id,
                            IFNULL(m.name, 'Unknown') as marketing_name,
                            e1.user_id as employee_id,
                            IFNULL(e1.name, 'Unknown') as employee_name,
                            s.customer_id,
                            IFNULL(s.customer_name, 'OWN SALES') customer_name,
                            s.dest_city_id,
                            s.dest_city,
                            s.service_type_id,
                            st.name as service_type,
                            s.code,
                            DATE(s.date_process) as date_process,
                            ttl_piece,
                            ttl_chargeable_weight,
                            s.discount_total,
                            tariff,
                            tariff_total,
                            tariff_net,
                            IF(se.total_cod IS NULL, 0, se.total_cod) total_cod,
                            s.total
                        FROM shipment s
                        LEFT JOIN branch b ON b.id = s.dest_branch_id
                        LEFT JOIN customer c ON c.id = s.customer_id
                        LEFT JOIN employee e ON e.code = s.data_entry_employee AND e.rowstatus = 1
                        LEFT JOIN users u ON u.username = s.createdby and u.rowstatus = 1
                        LEFT JOIN employee e1 on e1.user_id = u.id
                        LEFT JOIN employee m ON m.id = c.marketing_employee_id
                        LEFT JOIN service_type st ON st.id = s.service_type_id
                        LEFT JOIN shipment_expand se ON s.id = se.shipment_id
                        WHERE " + string.Join(" AND ", whereClauses) + " ORDER BY s.date_process, s.code";

            return Entities.ExecuteStoreQuery<T>(sql, parameters.ToArray()).ToList();
        }

        public IEnumerable<T> ReportSalesJournal<T>(
            int? branchId,
            DateTime? fromDate, DateTime? toDate,
            int? destBranchIdFrom, int? destBranchIdTo,
            int? marketingIdFrom, int? marketingIdTo,
            int? customerIdFrom, int? customerIdTo,
            int? destCityIdFrom, int? destCityIdTo,
            int? serviceTypeIdFrom, int? serviceTypeIdTo,
            string employeeCodeFrom, string employeeCodeTo,
            int? paymentMethodId = null
            )
        {
            var parameters = new List<MySqlParameter>();
            var whereClauses = new List<string>();

            whereClauses.Add("s.rowstatus = @rowstatus");
            parameters.Add(new MySqlParameter("rowstatus", 1));

            whereClauses.Add("s.branch_id = @branchId");
            parameters.Add(new MySqlParameter("branchId", branchId));

            if (fromDate != null && fromDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(s.date_process) >= DATE(@dateFrom)");
                parameters.Add(new MySqlParameter("dateFrom", fromDate));
            }

            if (toDate != null && toDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(s.date_process) <= DATE(@toDate)");
                parameters.Add(new MySqlParameter("toDate", toDate));
            }

            if (destBranchIdFrom != null && destBranchIdFrom != 0)
            {
                whereClauses.Add("s.dest_branch_id >= @destBranchIdFrom");
                parameters.Add(new MySqlParameter("destBranchIdFrom", destBranchIdFrom));
            }

            if (destBranchIdTo != null && destBranchIdTo != 0)
            {
                whereClauses.Add("s.dest_branch_id <= @destBranchIdTo");
                parameters.Add(new MySqlParameter("destBranchIdTo", destBranchIdTo));
            }

            if (marketingIdFrom != null && marketingIdFrom != 0)
            {
                whereClauses.Add("m.id >= @marketingIdFrom");
                parameters.Add(new MySqlParameter("marketingIdFrom", marketingIdFrom));
            }

            if (marketingIdTo != null && marketingIdTo != 0)
            {
                whereClauses.Add("m.id <= @marketingIdTo");
                parameters.Add(new MySqlParameter("marketingIdTo", marketingIdTo));
            }

            if (customerIdFrom != null && customerIdFrom != 0)
            {
                whereClauses.Add("s.customer_id >= @customerIdFrom");
                parameters.Add(new MySqlParameter("customerIdFrom", customerIdFrom));
            }

            if (customerIdTo != null && customerIdTo != 0)
            {
                whereClauses.Add("s.customer_id <= @customerIdTo");
                parameters.Add(new MySqlParameter("customerIdTo", customerIdTo));
            }

            if (destCityIdFrom != null && destCityIdFrom != 0)
            {
                whereClauses.Add("s.dest_city_id >= @destCityIdFrom");
                parameters.Add(new MySqlParameter("destCityIdFrom", destCityIdFrom));
            }

            if (destCityIdTo != null && destCityIdTo != 0)
            {
                whereClauses.Add("s.dest_city_id <= @destCityIdTo");
                parameters.Add(new MySqlParameter("destCityIdTo", destCityIdTo));
            }

            if (serviceTypeIdFrom != null && serviceTypeIdFrom != 0)
            {
                whereClauses.Add("s.service_type_id >= @serviceTypeIdFrom");
                parameters.Add(new MySqlParameter("serviceTypeIdFrom", serviceTypeIdFrom));
            }

            if (serviceTypeIdTo != null && serviceTypeIdTo != 0)
            {
                whereClauses.Add("s.service_type_id <= @serviceTypeIdTo");
                parameters.Add(new MySqlParameter("serviceTypeIdTo", serviceTypeIdTo));
            }

            if (employeeCodeFrom != string.Empty)
            {
                whereClauses.Add("e.code >= @employeeCodeFrom");
                parameters.Add(new MySqlParameter("employeeCodeFrom", employeeCodeFrom));
            }

            if (employeeCodeTo != string.Empty)
            {
                whereClauses.Add("e.code <= @employeeCodeTo");
                parameters.Add(new MySqlParameter("employeeCodeTo", employeeCodeTo));
            }

            if (paymentMethodId != null && paymentMethodId != 0)
            {
                whereClauses.Add("s.payment_method_id = @paymentMethodId");
                parameters.Add(new MySqlParameter("paymentMethodId", paymentMethodId));
            }

            string sql = @"SELECT
                            s.dest_branch_id,
                            b.name as dest_branch_name,
                            c.marketing_employee_id as marketing_id,
                            IFNULL(m.name, 'Unknown') as marketing_name,
                            e.id as employee_id,
                            IFNULL(e.name, 'Unknown') as employee_name,
                            s.customer_id,
                            IFNULL(s.customer_name, 'OWN SALES') customer_name,
                            s.dest_city_id,
                            s.dest_city,
                            s.service_type_id,
                            st.name as service_type,
                            s.code,
                            DATE(s.date_process) as date_process,
                            ttl_piece,
                            ttl_chargeable_weight,
                            tariff,
                            tariff_total,
                            packing_fee
                        FROM shipment s
                        LEFT JOIN branch b ON b.id = s.dest_branch_id
                        LEFT JOIN customer c ON c.id = s.customer_id
                        LEFT JOIN employee e ON e.code = s.data_entry_employee AND e.rowstatus = 1
                        LEFT JOIN employee m ON m.id = c.marketing_employee_id
                        LEFT JOIN service_type st ON st.id = s.service_type_id
                        WHERE " + string.Join(" AND ", whereClauses) + " ORDER BY s.date_process, s.code";

            return Entities.ExecuteStoreQuery<T>(sql, parameters.ToArray()).ToList();
        }

        public IEnumerable<T> GetInprocessSalesCounter<T>(
            int? branchId,
            DateTime? fromDate, DateTime? toDate,
            int? customerIdFrom, int? customerIdTo)
        {
            var parameters = new List<MySqlParameter>();
            var whereClauses = new List<string>();

            whereClauses.Add("s.rowstatus = @rowstatus");
            parameters.Add(new MySqlParameter("rowstatus", 1));

            whereClauses.Add("s.sales_type_id = 1");

            whereClauses.Add("s.branch_id = @branchId");
            parameters.Add(new MySqlParameter("branchId", branchId));

            whereClauses.Add("s.tracking_status_id NOT IN (8, 9, 10, 11, 12)");

            if (fromDate != null && fromDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(s.date_process) >= DATE(@dateFrom)");
                parameters.Add(new MySqlParameter("dateFrom", fromDate));
            }

            if (toDate != null && toDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(s.date_process) <= DATE(@toDate)");
                parameters.Add(new MySqlParameter("toDate", toDate));
            }

            if (customerIdFrom != null && customerIdFrom != 0)
            {
                whereClauses.Add("s.customer_id >= @customerIdFrom");
                parameters.Add(new MySqlParameter("customerIdFrom", customerIdFrom));
            }

            if (customerIdTo != null && customerIdTo != 0)
            {
                whereClauses.Add("s.customer_id <= @customerIdTo");
                parameters.Add(new MySqlParameter("customerIdTo", customerIdTo));
            }

            string sql = @"SELECT
                            s.dest_branch_id,
                            b.name as dest_branch_name,
                            c.marketing_employee_id as marketing_id,
                            IFNULL(m.name, 'Unknown') as marketing_name,
                            s.customer_id,
                            IFNULL(s.customer_name, 'OWN SALES') customer_name,
                            s.dest_city_id,
                            s.dest_city,
                            s.service_type_id,
                            st.name as service_type,
                            s.code,
                            DATE(s.date_process) as date_process,
                            ttl_piece,
                            ttl_chargeable_weight,
                            tariff,
                            tariff_total
                        FROM shipment s
                        LEFT JOIN branch b ON b.id = s.dest_branch_id
                        LEFT JOIN customer c ON c.id = s.customer_id
                        LEFT JOIN employee m ON m.id = c.marketing_employee_id
                        LEFT JOIN service_type st ON st.id = s.service_type_id
                        WHERE " + string.Join(" AND ", whereClauses);

            return Entities.ExecuteStoreQuery<T>(sql, parameters.ToArray()).ToList();
        }

        public IEnumerable<T> GetUninvoicedSalesReport<T>(
            int? branchId,
            DateTime? fromDate, DateTime? toDate,
            int? customerIdFrom, int? customerIdTo)
        {
            return GetUninvoicedCreditSalesReport<T>(branchId, fromDate, toDate, customerIdFrom, customerIdTo);
        }

        public IEnumerable<T> GetUninvoicedCreditSalesReport<T>(
            int? branchId,
            DateTime? fromDate, DateTime? toDate,
            int? customerIdFrom, int? customerIdTo)
        {
            var parameters = new List<MySqlParameter>();
            var whereClauses = new List<string>();

            whereClauses.Add("s.rowstatus = @rowstatus");
            parameters.Add(new MySqlParameter("rowstatus", 1));

            whereClauses.Add("s.branch_id = @branchId");
            parameters.Add(new MySqlParameter("branchId", branchId));

            whereClauses.Add("s.payment_method_id IN (3)");
            whereClauses.Add("s.invoiced = 0");

            if (fromDate != null && fromDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(s.date_process) >= DATE(@dateFrom)");
                parameters.Add(new MySqlParameter("dateFrom", fromDate));
            }

            if (toDate != null && toDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(s.date_process) <= DATE(@toDate)");
                parameters.Add(new MySqlParameter("toDate", toDate));
            }

            if (customerIdFrom != null && customerIdFrom != 0)
            {
                whereClauses.Add("s.customer_id >= @customerIdFrom");
                parameters.Add(new MySqlParameter("customerIdFrom", customerIdFrom));
            }

            if (customerIdTo != null && customerIdTo != 0)
            {
                whereClauses.Add("s.customer_id <= @customerIdTo");
                parameters.Add(new MySqlParameter("customerIdTo", customerIdTo));
            }

            string sql = @"SELECT
                            s.dest_branch_id,
                            b.name as dest_branch_name,
                            c.marketing_employee_id as marketing_id,
                            IFNULL(m.name, 'Unknown') as marketing_name,
                            s.customer_id,
                            c.code as customer_code,
                            IFNULL(s.customer_name, 'OWN SALES') customer_name,
                            s.dest_city_id,
                            s.dest_city,
                            s.service_type_id,
                            st.name as service_type,
                            s.code,
                            DATE(s.date_process) as date_process,
                            ttl_piece,
                            ttl_chargeable_weight,
                            tariff,
                            tariff_total
                        FROM shipment s
                        LEFT JOIN branch b ON b.id = s.dest_branch_id
                        LEFT JOIN customer c ON c.id = s.customer_id
                        LEFT JOIN employee m ON m.id = c.marketing_employee_id
                        LEFT JOIN service_type st ON st.id = s.service_type_id
                        WHERE " + string.Join(" AND ", whereClauses) + " AND s.voided = 0";

            return Entities.ExecuteStoreQuery<T>(sql, parameters.ToArray()).ToList();
        }

        public IEnumerable<T> GetUnvalidatedShipmentReport<T>(
            int branchId,
            DateTime fromDate, DateTime toDate,
            int? customerId, int? paymentId)
        {
            var parameters = new List<MySqlParameter>();
            var whereClauses = new List<string>();

            whereClauses.Add("s.rowstatus = @rowstatus");
            parameters.Add(new MySqlParameter("rowstatus", 1));

            whereClauses.Add("s.branch_id = @branchId");
            parameters.Add(new MySqlParameter("branchId", branchId));

            whereClauses.Add("s.posted = 0");
            whereClauses.Add("s.cancelled = 0");
            whereClauses.Add("s.payment_method_id != 1");

            if (fromDate != null && fromDate != DateTime.MinValue)
            {
                whereClauses.Add("s.date_process >= @dateFrom");
                parameters.Add(new MySqlParameter("dateFrom", fromDate.ToString("yyyy-MM-dd HH:mm:ss")));
            }

            if (toDate != null && toDate != DateTime.MinValue)
            {
                whereClauses.Add("s.date_process <= @toDate");
                parameters.Add(new MySqlParameter("toDate", toDate.ToString("yyyy-MM-dd HH:mm:ss")));
            }

            if (paymentId != null)
            {
                whereClauses.Add("s.payment_method_id = @peymentId");
                parameters.Add(new MySqlParameter("peymentId", paymentId));
            }

            if (customerId != null)
            {
                whereClauses.Add("s.customer_id = @customerId");
                parameters.Add(new MySqlParameter("customerId", customerId));
            }

            string sql = @"SELECT
                            s.dest_branch_id,
                            c1.name as dest_branch_name,
                            s.code,
                            s.customer_id,
                            c.name customer_name,
                            DATE(s.date_process) as date_process,
                            ttl_piece,
                            ttl_chargeable_weight,
                            tariff_total,
                            pt.name as package_type,
                            st.name as payment_method,
                            s.ref_number,
                            s.ttl_gross_weight,
                            s.total
                        FROM shipment s
                        LEFT JOIN branch b ON b.id = s.branch_id
                        LEFT JOIN city c1 ON s.dest_city_id = c1.id
                        LEFT JOIN customer c ON c.id = s.customer_id
                        LEFT JOIN payment_method st ON st.id = s.payment_method_id
                        LEFT JOIN package_type pt ON pt.id = s.package_type_id
                        WHERE " + string.Join(" AND ", whereClauses) + " AND s.voided = 0";

            return Entities.ExecuteStoreQuery<T>(sql, parameters.ToArray()).ToList();
        }

        public IEnumerable<T> GetCreditCollectOnly<T>(int branchId, Paging paging, out int totalCount, params IListParameter[] parameter)
        {
            IEnumerable<shipment> query = null;

            var shipmentCode = parameter.Any(r => r.ColumnName.Equals("code"))
                ? parameter.First(r => r.ColumnName.Equals("code")).Value.ToString()
                : string.Empty;
            var cityId = parameter.Any(r => r.ColumnName.Equals("city_id"))
                ? (int) parameter.First(r => r.ColumnName.Equals("city_id")).Value
                : 0;
            var destCityId = parameter.Any(r => r.ColumnName.Equals("dest_city_id"))
                ? (int) parameter.First(r => r.ColumnName.Equals("dest_city_id")).Value
                : 0;
            var customerId = parameter.Any(r => r.ColumnName.Equals("customer_id"))
                ? (int) parameter.First(r => r.ColumnName.Equals("customer_id")).Value
                : 0;
            var dateFrom = parameter.Any(r => r.ColumnName.Equals("date_process") && r.Operator == EnumSqlOperator.GreatThanEqual)
                ? (DateTime?)parameter.First(r => r.ColumnName.Equals("date_process") && r.Operator == EnumSqlOperator.GreatThanEqual).Value
                : null;
            var dateTo = parameter.Any(r => r.ColumnName.Equals("date_process") && r.Operator == EnumSqlOperator.LesThanEqual)
                ? (DateTime?)parameter.First(r => r.ColumnName.Equals("date_process") && r.Operator == EnumSqlOperator.LesThanEqual).Value
                : null;

            var ids = Entities.ExecuteStoreQuery<int>("SELECT id " +
                                                        "FROM shipment " +
                                                        "WHERE " +
                                                        "(" +
                                                        "  (payment_method_id = 3 AND branch_id = @branchId)" +
                                                        "OR " +
                                                        "  (payment_method_id = 2 AND collect_customer_id != 0 AND dest_branch_id = @branchId AND collect_payment_method = 'CREDIT')" +
                                                        ") " +
                                                        "AND rowstatus = 1 " +
                                                        (!string.IsNullOrEmpty(shipmentCode) ? "AND code = '" + shipmentCode.Replace("'", "''") + "' " : "") +
                                                        (cityId > 0 ? "AND city_id = " + cityId + " " : "") +
                                                        (destCityId > 0 ? "AND dest_city_id = " + destCityId + " " : "") +
                                                        (customerId > 0 ? "AND customer_id = " + customerId + " " : "") +
                                                        (dateFrom != null ? "AND date_process >= '" + ((DateTime)dateFrom).ToString("yyyy-MM-dd 00:00:00") + "' " : "") +
                                                        (dateTo != null ? "AND date_process <= '" + ((DateTime)dateTo).ToString("yyyy-MM-dd 23:59:59") + "' " : "") +
                                                        "ORDER BY " + paging.SortColumn + " " + paging.Direction + " " +
                                                        "LIMIT " + paging.Start + ", " + paging.Limit, new MySqlParameter("branchId", branchId)).ToList();

            query = (from a in Entities.shipments where ids.Contains(a.id) select a).ToList();

            var q = "SELECT COUNT(id) " +
                    "FROM shipment " +
                    "WHERE " +
                    "(" +
                    "  (payment_method_id = 3 AND branch_id = @branchId)" +
                    "OR " +
                    "  (payment_method_id = 2 AND collect_customer_id != 0 AND dest_branch_id = @branchId AND collect_payment_method = 'CREDIT')" +
                    ") " +
                    "AND rowstatus = 1 " +
                    (!string.IsNullOrEmpty(shipmentCode) ? "AND code = '" + shipmentCode.Replace("'", "''") + "' " : "") +
                    (cityId > 0 ? "AND city_id = " + cityId + " " : "") +
                    (destCityId > 0 ? "AND dest_city_id = " + destCityId + " " : "") +
                    (customerId > 0 ? "AND customer_id = " + customerId + " " : "") +
                    (dateFrom != null
                        ? "AND date_process >= '" + ((DateTime) dateFrom).ToString("yyyy-MM-dd 00:00:00") + "' "
                        : "") +
                    (dateTo != null
                        ? "AND date_process <= '" + ((DateTime) dateTo).ToString("yyyy-MM-dd 23:59:59") + "' "
                        : "");
            totalCount = Entities.ExecuteStoreQuery<int>(q, new MySqlParameter("branchId", branchId)).FirstOrDefault();

            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public IEnumerable<T> GetExcludeCreditCollectOnly<T>(int customerId, IListParameter[] parameter, int[] filterExcludeShipmentIds)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.shipments where ((a.payment_method_id == 3 && a.customer_id == customerId) || (a.payment_method_id == 2 && a.collect_customer_id == customerId && a.collect_payment_method.Equals("CREDIT"))) select a)
                            .Where(whereterm, ListValue.ToArray())
                            .Where(a => a.payment_method_id != (int)EnumPaymentMethod.Cash)
                            .Where(a => !filterExcludeShipmentIds.Contains(a.id))
                            .OrderBy("ID ASC")
                            .ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);

            return (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
        }

        public IEnumerable<T> GetHandlingFeeReport<T>(int branchId, DateTime? fromDate, DateTime? toDate, int? origCityId, int? destCityId) where T : IBaseModel
        {
            var parameter = new List<IListParameter>();

            parameter.Add(WhereTerm.Default(branchId, "branch_id"));

            if (fromDate != null && fromDate != DateTime.MinValue)
            {
                parameter.Add(WhereTerm.Default(((DateTime)fromDate).Date, "date_process", EnumSqlOperator.GreatThanEqual));
            }
            if (toDate != null && toDate != DateTime.MinValue)
            {
                parameter.Add(WhereTerm.Default(((DateTime)toDate).Date, "date_process", EnumSqlOperator.LesThanEqual));
            }
            if (origCityId != null && origCityId != 0)
            {
                parameter.Add(WhereTerm.Default((int)origCityId, "orig_city_id"));
            }
            if (destCityId != null && destCityId != 0)
            {
                parameter.Add(WhereTerm.Default((int)destCityId, "dest_city_id"));
            }

            return Get<T>(parameter.ToArray());
        }

        public IEnumerable<T> GetFleetUtilizationReport<T>(int branchId, DateTime? fromDate, DateTime? toDate, int? fleetId)
        {
            var parameters = new List<MySqlParameter>();
            var whereClauses = new List<string>();

            whereClauses.Add("dod.rowstatus = @rowstatus");
            parameters.Add(new MySqlParameter("rowstatus", 1));

            whereClauses.Add("dod.branch_id = @branchId");
            parameters.Add(new MySqlParameter("branchId", branchId));


            if (fromDate != null && fromDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(dod.shipment_date) >= DATE(@dateFrom)");
                parameters.Add(new MySqlParameter("dateFrom", fromDate));
            }

            if (toDate != null && toDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(dod.shipment_date) <= DATE(@toDate)");
                parameters.Add(new MySqlParameter("toDate", toDate));
            }

            if (fleetId != null && fleetId != 0)
            {
                whereClauses.Add("do.fleet_id = @fleetId");
                parameters.Add(new MySqlParameter("fleetId", fleetId));
            }

            string sql = @"SELECT
                              vt.name AS VehicleType,
                              f.brand AS Brand,
                              f.model AS Model,
                              IFNULL(f.plate_number, 'Unknown') AS PlateNumber,
                              DATE(dod.shipment_date) AS DateProcess,
                              SUM(dod.ttl_piece) AS TtlPiece,
                              SUM(dod.ttl_gross_weight) AS TtlGrossWeight,
                              SUM(dod.ttl_chargeable_weight) AS TtlChargeableWeight
                        FROM delivery_order_detail dod
                        LEFT JOIN delivery_order do ON do.id = dod.delivery_order_id
                        LEFT JOIN fleet f ON f.id = do.fleet_id
                        LEFT JOIN vehicle_type vt ON vt.id = f.vehicle_type_id
                        WHERE " + string.Join(" AND ", whereClauses) + @"
                        GROUP BY DATE(dod.shipment_date), f.id";

            return Entities.ExecuteStoreQuery<T>(sql, parameters.ToArray()).ToList();
        }

        public IEnumerable<T> GetFleetUtilizationPerVehicleReport<T>(int branchId, DateTime? fromDate, DateTime? toDate, int? fleetId)
        {
            var parameters = new List<MySqlParameter>();
            var whereClauses = new List<string>();

            whereClauses.Add("dod.rowstatus = @rowstatus");
            parameters.Add(new MySqlParameter("rowstatus", 1));

            whereClauses.Add("dod.branch_id = @branchId");
            parameters.Add(new MySqlParameter("branchId", branchId));


            if (fromDate != null && fromDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(dod.shipment_date) >= DATE(@dateFrom)");
                parameters.Add(new MySqlParameter("dateFrom", fromDate));
            }

            if (toDate != null && toDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(dod.shipment_date) <= DATE(@toDate)");
                parameters.Add(new MySqlParameter("toDate", toDate));
            }

            if (fleetId != null && fleetId != 0)
            {
                whereClauses.Add("do.fleet_id = @fleetId");
                parameters.Add(new MySqlParameter("fleetId", fleetId));
            }

            string sql = @"SELECT
                              vt.name AS VehicleType,
                              f.brand AS Brand,
                              f.model AS Model,
                              f.plate_number AS PlateNumber,
                              dod.shipment_code AS Code,
                              dod.shipment_date AS DateProcess,
                              dod.ttl_piece AS TtlPiece,
                              dod.ttl_gross_weight AS TtlGrossWeight,
                              dod.ttl_chargeable_weight AS TtlChargeableWeight
                        FROM delivery_order_detail dod
                        LEFT JOIN delivery_order do ON do.id = dod.delivery_order_id
                        LEFT JOIN fleet f ON f.id = do.fleet_id
                        LEFT JOIN vehicle_type vt ON vt.id = f.vehicle_type_id
                        WHERE " + string.Join(" AND ", whereClauses);

            return Entities.ExecuteStoreQuery<T>(sql, parameters.ToArray()).ToList();
        }

        public IEnumerable<T> GetOutboundWeightDiffReport<T>(int branchId, DateTime? fromDate, DateTime? toDate, int? origBranchId, int? destBranchId, int? customerId, string shipmentNumber, string shipmentStatus)
        {
            var parameters = new List<MySqlParameter>();
            var whereClauses = new List<string>();

            whereClauses.Add("s.rowstatus = @rowstatus");
            parameters.Add(new MySqlParameter("rowstatus", 1));

            whereClauses.Add("s.branch_id = @branchId");
            parameters.Add(new MySqlParameter("branchId", branchId));


            if (fromDate != null && fromDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(s.date_process) >= DATE(@dateFrom)");
                parameters.Add(new MySqlParameter("dateFrom", fromDate));
            }

            if (toDate != null && toDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(s.date_process) <= DATE(@toDate)");
                parameters.Add(new MySqlParameter("toDate", toDate));
            }

            if (origBranchId != null && origBranchId != 0)
            {
                whereClauses.Add("s.branch_id = @origBranchId");
                parameters.Add(new MySqlParameter("origBranchId", origBranchId));
            }

            if (destBranchId != null && destBranchId != 0)
            {
                whereClauses.Add("s.dest_branch_id = @destBranchId");
                parameters.Add(new MySqlParameter("destBranchId", destBranchId));
            }

            if (customerId != null && customerId != 0)
            {
                whereClauses.Add("s.customer_id = @customerId");
                parameters.Add(new MySqlParameter("customerId", customerId));
            }

            if (!string.IsNullOrEmpty(shipmentNumber))
            {
                whereClauses.Add("s.code = @shipmentNumber");
                parameters.Add(new MySqlParameter("shipmentNumber", shipmentNumber));
            }

            if (!string.IsNullOrEmpty(shipmentStatus))
            {
                if (shipmentStatus == "Airwaybilled")
                {
                    whereClauses.Add("ad1.id IS NOT NULL");
                }
                else if (shipmentStatus == "Waybilled")
                {
                    whereClauses.Add("wd1.id IS NOT NULL");
                }
            }

            string sql = @"SELECT
                            DATE(s.date_process) AS DateProcess,
                            s.code AS Code,
                            b.code AS OrigBranch,
                            db.code AS DestBranch,
                            s.customer_name AS CustomerName,
                            IF(NOT(ISNULL(ad1.id)), 'Airwaybill', IF(NOT(ISNULL(wd1.id)), 'Waybill', null)) AS WaybillType,
                            s.ttl_gross_weight AS TtlGrossWeight,
                            COALESCE(ad1.ttl_gross_weight, wd1.ttl_gross_weight) AS WaybillWeight
                        FROM shipment s
                        LEFT JOIN branch b ON b.id = s.branch_id
                        LEFT JOIN branch db ON db.id = s.dest_branch_id
                        LEFT JOIN airwaybill_detail ad1 ON s.id = ad1.shipment_id AND ad1.rowstatus = 1
                        LEFT JOIN airwaybill_detail ad2 ON s.id = ad2.shipment_id AND ad2.rowstatus = 1 AND ad1.id < ad2.id
                        LEFT JOIN waybill_detail wd1 ON s.id = wd1.shipment_id AND wd1.rowstatus = 1
                        LEFT JOIN waybill_detail wd2 ON s.id = wd2.shipment_id AND wd2.rowstatus = 1 AND wd1.id < wd2.id
                        WHERE ad2.id IS NULL AND wd2.id IS NULL
                        AND (ad1.id IS NOT NULL OR wd1.id IS NOT NULL)
                        AND " + string.Join(" AND ", whereClauses);

            return Entities.ExecuteStoreQuery<T>(sql, parameters.ToArray()).ToList();
        }

        public IEnumerable<T> GetMonthlyServiceTypeSummary<T>(int branchId, DateTime? fromDate, DateTime? toDate)
        {
            var parameters = new List<MySqlParameter>();
            var whereClauses = new List<string>();

            whereClauses.Add("s.rowstatus = @rowstatus");
            parameters.Add(new MySqlParameter("rowstatus", 1));

            whereClauses.Add("s.branch_id = @branchId");
            parameters.Add(new MySqlParameter("branchId", branchId));


            if (fromDate != null && fromDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(s.date_process) >= DATE(@dateFrom)");
                parameters.Add(new MySqlParameter("dateFrom", fromDate));
            }

            if (toDate != null && toDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(s.date_process) <= DATE(@toDate)");
                parameters.Add(new MySqlParameter("toDate", toDate));
            }

            string sql = @"
                        SELECT
                            CONCAT (DisplayDate, ' (', FORMAT(t2.GrandTotal, 0), ')') DisplayDate,
                            DateProcess,
                            TtlChargeableWeight,
                            Total,
                            ServiceType,
                            ServiceTypeId
                        FROM (
                            SELECT
                                DATE_FORMAT(s.date_process, '%b/%Y') AS DisplayDate,
                                CAST(DATE_FORMAT(s.date_process ,'%Y-%m-01') as DATE) AS DateProcess,
                                SUM(s.ttl_chargeable_weight) AS TtlChargeableWeight,
                                SUM(s.Total) AS Total,
                                st.name AS ServiceType,
                                s.service_type_id AS ServiceTypeId,
                                CONCAT(b.code, ' ', b.name) BranchName
                            FROM shipment s
                            INNER JOIN branch b ON s.branch_id = b.id
                            LEFT JOIN service_type st ON st.id = s.service_type_id
                            WHERE " + string.Join(" AND ", whereClauses) + @"
                            GROUP BY DATE_FORMAT(s.date_process, '%b/%Y'), st.name, s.service_type_id
                        )t
                        LEFT JOIN (
                            SELECT SUM(s.total) GrandTotal, DATE_FORMAT(s.date_process, '%b/%Y') AS Date1
                            FROM shipment s WHERE " + string.Join(" AND ", whereClauses) + @"
                            GROUP BY DATE_FORMAT(s.date_process, '%b/%Y')
                        )t2 ON t.DisplayDate = t2.Date1
                        ORDER BY t.DateProcess ASC";

            return Entities.ExecuteStoreQuery<T>(sql, parameters.ToArray()).ToList();
        }

        public IEnumerable<T> GetDailyServiceTypeSummary<T>(int branchId, DateTime? fromDate, DateTime? toDate)
        {
            var parameters = new List<MySqlParameter>();
            var whereClauses = new List<string>();

            whereClauses.Add("s.rowstatus = @rowstatus");
            parameters.Add(new MySqlParameter("rowstatus", 1));

            whereClauses.Add("s.branch_id = @branchId");
            parameters.Add(new MySqlParameter("branchId", branchId));


            if (fromDate != null && fromDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(s.date_process) >= DATE(@dateFrom)");
                parameters.Add(new MySqlParameter("dateFrom", fromDate));
            }

            if (toDate != null && toDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(s.date_process) <= DATE(@toDate)");
                parameters.Add(new MySqlParameter("toDate", toDate));
            }

            string sql = @"
                        SELECT
                            CONCAT (DisplayDate, ' (', FORMAT(t2.GrandTotal, 0), ')') DisplayDate,
                            DateProcess,
                            TtlChargeableWeight,
                            Total,
                            ServiceType,
                            ServiceTypeId
                        FROM (
                            SELECT
                                DATE_FORMAT(s.date_process, '%d/%m/%Y') AS DisplayDate,
                                CAST(s.date_process as DATE) AS DateProcess,
                                SUM(s.ttl_chargeable_weight) AS TtlChargeableWeight,
                                SUM(s.Total) AS Total,
                                st.name AS ServiceType,
                                s.service_type_id AS ServiceTypeId,
                                CONCAT(b.code, ' ', b.name) BranchName
                            FROM shipment s
                            INNER JOIN branch b ON s.branch_id = b.id
                            LEFT JOIN service_type st ON st.id = s.service_type_id
                            WHERE " + string.Join(" AND ", whereClauses) + @"
                            GROUP BY CAST(s.date_process as DATE), st.name, s.service_type_id
                        )t
                        LEFT JOIN (
                            SELECT SUM(s.total) GrandTotal, DATE_FORMAT(s.date_process, '%d/%m/%Y') AS Date1
                            FROM shipment s WHERE " + string.Join(" AND ", whereClauses) + @"
                            GROUP BY CAST(s.date_process as DATE)
                        )t2 ON t.DisplayDate = t2.Date1
                        ORDER BY t.DateProcess ASC";

            return Entities.ExecuteStoreQuery<T>(sql, parameters.ToArray()).ToList();
        }

        public IEnumerable<T> GetResponseTimeSummary<T>(int branchId, DateTime? fromDate, DateTime? toDate, int? employeeId)
        {
            var parameters = new List<MySqlParameter>();
            var whereClauses = new List<string>();

            whereClauses.Add("ss.rowstatus = @rowstatus");
            parameters.Add(new MySqlParameter("rowstatus", 1));

            whereClauses.Add("ss.branch_id = @branchId");
            parameters.Add(new MySqlParameter("branchId", branchId));


            if (fromDate != null && fromDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(ss.dateprocess) >= DATE(@dateFrom)");
                parameters.Add(new MySqlParameter("dateFrom", fromDate));
            }

            if (toDate != null && toDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(ss.dateprocess) <= DATE(@toDate)");
                parameters.Add(new MySqlParameter("toDate", toDate));
            }

            if (employeeId != null && employeeId != 0)
            {
                whereClauses.Add("ss.employee_id = @employeeId");
                parameters.Add(new MySqlParameter("employeeId", employeeId));
            }

            string sql = @"SELECT
                              summary.branch_id AS OrigBranchId,
                              ob.code AS OrigBranchCode,
                              ob.name AS OrigBranch,
                              summary.tracking_status_id AS TrackingStatusId,
                              ts.code AS TrackingStatus,
                              summary.employee_id AS EmployeeId,
                              e.code AS EmployeeCode,
                              IFNULL(e.name, 'Unknown') AS EmployeeName,
                              summary.ResponseTimeSum,
                              summary.ResponseTimeMax,
                              summary.ResponseTimeMin,
                              summary.TransactionsCount
                            FROM (SELECT ss.shipment_id,
                                ss.branch_id,
                                ss.tracking_status_id,
                                ss.employee_id,
                                SEC_TO_TIME(SUM(TIMEDIFF(ss.dateprocess, ss1.dateprocess))) AS ResponseTimeSum,
                                MAX(TIMEDIFF(ss.dateprocess, ss1.dateprocess)) AS ResponseTimeMax,
                                MIN(TIMEDIFF(ss.dateprocess, ss1.dateprocess)) AS ResponseTimeMin,
                                COUNT(*) AS TransactionsCount
                              FROM shipment_status ss
                              LEFT JOIN shipment_status ss1 ON ss1.shipment_id = ss.shipment_id AND ss1.rowstatus = 1 AND ss1.id < ss.id
                              LEFT JOIN shipment_status ss2 ON ss2.shipment_id = ss.shipment_id AND ss2.rowstatus = 1 AND ss2.id < ss1.id
                              WHERE ss2.id IS NULL AND " + string.Join(" AND ", whereClauses) + @"
                              GROUP BY ss.branch_id,
                                       ss.tracking_status_id,
                                       ss.employee_id) summary
                              LEFT JOIN branch ob
                                ON ob.id = summary.branch_id
                              LEFT JOIN tracking_status ts
                                ON ts.id = summary.tracking_status_id
                              LEFT JOIN employee e
                                ON e.id = summary.employee_id";

            return Entities.ExecuteStoreQuery<T>(sql, parameters.ToArray()).ToList();
        }

        public TrackingStatusModel GetFinalTrackingStatusOfShipment(int shipmentId)
        {
            var query = from s in Entities.shipment_status
                        join ts in Entities.tracking_status on s.tracking_status_id equals ts.id
                        where s.shipment_id == shipmentId && ts.is_final_status && ts.rowstatus && s.rowstatus
                        orderby s.dateprocess descending
                        select new TrackingStatusModel
                        {
                            Id = ts.id,
                            Code = ts.code
                        };

            return query.FirstOrDefault();
        }

        public ShipmentStatusModel GetFinalShipmentStatusOfShipment(int shipmentId)
        {
            var sql = @"SELECT
	                        s.id Id,
                            s.branch_id BranchId,
                            s.createdby Createdby,
                            s.createddate Createddate,
                            s.dateprocess DateProcess,
                            s.employee_id EmployeeId,
                            s.miss_delivery_reason MissDeliveryReason,
                            s.modifiedby Modifiedby,
                            s.modifieddate Modifieddate,
                            s.position_status PositionStatus,
                            s.position_status_id PositionStatusId,
                            s.reference Reference,
                            s.rowstatus Rowstatus,
                            s.rowversion Rowversion,
                            s.shipment_id ShipmentId,
                            s.status_by StatusBy,
                            s.status_note StatusNote,
                            s.tracking_status_id TrackingStatusId
                        FROM siscodb.shipment_status s
                        INNER JOIN siscodb.tracking_status ts ON s.tracking_status_id = ts.id AND ts.rowstatus = 1 AND ts.is_final_status = 1
                        WHERE s.rowstatus = 1 AND s.shipment_id = {0}
                        ORDER BY s.dateprocess DESC LIMIT 1;";

            sql = string.Format(sql, shipmentId);
            return Entities.ExecuteStoreQuery<ShipmentStatusModel>(sql).FirstOrDefault();
        }

        public ShipmentStatusModel GetFinalStatusOfShipmentOutgoingPOD(int shipmentId)
        {
            var sql = @"SELECT
	                        s.id Id,
                            s.branch_id BranchId,
                            s.createdby Createdby,
                            s.createddate Createddate,
                            s.dateprocess DateProcess,
                            s.employee_id EmployeeId,
                            s.miss_delivery_reason MissDeliveryReason,
                            s.modifiedby Modifiedby,
                            s.modifieddate Modifieddate,
                            s.position_status PositionStatus,
                            s.position_status_id PositionStatusId,
                            s.reference Reference,
                            s.rowstatus Rowstatus,
                            s.rowversion Rowversion,
                            s.shipment_id ShipmentId,
                            s.status_by StatusBy,
                            s.status_note StatusNote,
                            s.tracking_status_id TrackingStatusId
                        FROM siscodb.shipment_status s
                        INNER JOIN siscodb.tracking_status ts ON s.tracking_status_id = ts.id AND ts.rowstatus = 1 AND ts.is_final_status = 1 AND ts.id IN(10,11,12,19,20)
                        WHERE s.rowstatus = 1 AND s.shipment_id = {0}
                        ORDER BY s.dateprocess DESC LIMIT 1;";

            sql = string.Format(sql, shipmentId);
            return Entities.ExecuteStoreQuery<ShipmentStatusModel>(sql).FirstOrDefault();
        }

        public IEnumerable<ShipmentModel> GetByCustomerOrCustomerCollect(int? customerId, Paging paging, out int count, IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.shipments where (customerId == null || (a.payment_method_id == 3 && a.customer_id == customerId) || (a.payment_method_id == 2 && a.collect_customer_id == customerId && a.collect_payment_method.Equals("CREDIT"))) select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);
            var tquery = (from a in Entities.shipments where (customerId == null || (a.payment_method_id == 3 && a.customer_id == customerId) || (a.payment_method_id == 2 && a.collect_customer_id == customerId && a.collect_payment_method.Equals("CREDIT"))) select a).Where(whereterm, ListValue.ToArray());
            count = tquery.Count();
            return query.Select(PopulateEntityToNewModel).ToList();
        }

        public List<ShipmentRowModel> ShipmentDeliveryList(string where)
        {
            string[] trackingStatuses = new TrackingStatusRepository().Get<TrackingStatusModel>(WhereTerm.Default(true, "is_final_status")).Select(s => s.Id.ToString("#")).ToArray();

            var sql = @"SELECT
                            s.code AS Code,
	                        s.date_process AS DateProcesss,
	                        s.consignee_name AS ConsigneeName,
	                        s.shipper_name AS ShipperName,
	                        pck.`name` AS PackageType,
	                        s.dest_city AS DestCity,
                            s.dest_branch_name AS DestBranch,
	                        srv.`name` AS ServiceType,
	                        s.ttl_piece AS TtlPiece,
	                        s.ttl_chargeable_weight AS TtlChargeableWeight,
                            (SELECT id FROM shipment_status WHERE tracking_status_id IN ({0}) AND rowstatus = 1 AND shipment_id = s.id order by createddate desc limit 1) StatusId
                        FROM shipment s
                        INNER JOIN package_type pck ON s.package_type_id = pck.id
                        INNER JOIN service_type srv ON s.service_type_id = srv.id
                        WHERE {2}";

            var query = @"SELECT
                            Code,
                            DateProcesss AS DateProcess,
                            ConsigneeName,
                            PackageType,
                            DestBranch,
                            DestCity,
                            ServiceType,
                            TtlPiece,
                            TtlChargeableWeight,
                            ShipperName,
                            IF(ISNULL(ss.dateprocess), 0, ss.tracking_status_id) AS TrackingStatusId,
	                        IF(ISNULL(ss.dateprocess), null, ss.dateprocess) AS DeliveryDate,
	                        IF(ISNULL(ss.dateprocess), 'Not Available', DATE_FORMAT(ss.dateprocess,'%d-%m-%Y')) AS DeliveryDateStr,
	                        IF(ISNULL(ss.dateprocess), '', DATE_FORMAT(ss.dateprocess,'%H:%i')) AS DeliveryTime,
	                        IF(ISNULL(ss.dateprocess), '', ss.status_by) AS RecipientName,
	                        IF(ss.miss_delivery_reason = '', ss.status_note, ss.miss_delivery_reason) AS DeliveryNote,
                            IF(ISNULL(ss.dateprocess), datediff(DateProcesss, NOW()), datediff(ss.dateprocess, DateProcesss)) AS LeadTime,
                            ss.createdby Createdby
                          FROM (" + sql + ") tmp " +
                        "LEFT JOIN shipment_status ss ON StatusId = ss.id";
            var executeSql = string.Format(query, string.Join(",", trackingStatuses), string.Join(",", trackingStatuses), where);
            return
                Entities.ExecuteStoreQuery<ShipmentRowModel>(executeSql).ToList();
        }

        public List<ShipmentRowModel> UnreceivedList(string where)
        {
            var sql2 = @"SELECT
                            code Code,
                            date_process DateProcess,
                            shipper_name ShipperName, 
                            package_type PackageType,
                            dest_city DestCity, 
                            dest_branch_name DestBranch,
                            service_type ServiceType, 
                            ttl_piece TtlPiece, 
                            ttl_chargeable_weight TtlChargeableWeight,
                            shipper_name ShipperName,
                            consignee_name ConsigneeName,
                            tracking_status_id TrackingStatusId, 
                            tracking_status TrackingStatus, 
                            DATE_FORMAT(status_date,'%d-%m-%Y') AS StatusDateStr,
                            DATE_FORMAT(status_date,'%H:%i') AS StatusTime,
                            lead_time LeadTime,
                            branch_id BranchId,
                            branch_name BranchName,
                            dest_branch_id DestBranchId,
                            city_id CityId,
                            city_name CityName
                         FROM rp_undelivered_shipment
                         ";

            if (!string.IsNullOrEmpty(where)) sql2 += " WHERE {0}";
            sql2 += " ORDER BY lead_time DESC";

            var executeSql = string.Format(sql2, where);
            return Entities.ExecuteStoreQuery<ShipmentRowModel>(executeSql).ToList();
        }

        public IEnumerable<T> GetMissDeliveryOut<T>(DateTime? fromDate, DateTime? toDate, int? branchId, int? trackingStatusId)
        {
            var parameters = new List<MySqlParameter>();
            var whereClauses = new List<string>();

            whereClauses.Add("s.rowstatus = @rowstatus");
            parameters.Add(new MySqlParameter("rowstatus", 1));

            if (fromDate != null && fromDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(s.date_process) >= DATE(@dateFrom)");
                parameters.Add(new MySqlParameter("dateFrom", fromDate));
            }

            if (toDate != null && toDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(s.date_process) <= DATE(@toDate)");
                parameters.Add(new MySqlParameter("toDate", toDate));
            }

            if (branchId != null && branchId != 0)
            {
                whereClauses.Add("s.branch_id = @branchId");
                parameters.Add(new MySqlParameter("branchId", branchId));
            }

            if (trackingStatusId != null && trackingStatusId != 0)
            {
                whereClauses.Add("ss1.tracking_status_id = @trackingStatusId");
                parameters.Add(new MySqlParameter("trackingStatusId", trackingStatusId));
            }

            string sql = @"SELECT s.code AS Code,
                                s.date_process AS DateProcess,
                                s.city_name AS CityName,
                                b.code as BranchName,
                                s.customer_name AS CustomerName,
                                s.consignee_name AS ConsigneeName,
                                s.ttl_piece AS TtlPiece,
                                s.ttl_gross_weight AS TtlGrossWeight,
                                s.ttl_chargeable_weight AS TtlChargeableWeight,
                                s.nature_of_goods AS NatureOfGoods
                        FROM shipment s
                        LEFT JOIN branch b ON b.id = s.branch_id
                        LEFT JOIN shipment_status AS ss1 ON s.id = ss1.shipment_id" + (trackingStatusId != null ? " AND ss1.tracking_status_id = " + trackingStatusId : "") + @" AND ss1.rowstatus = 1
                        LEFT JOIN shipment_status AS ss2 ON s.id = ss2.shipment_id" + (trackingStatusId != null ? " AND ss2.tracking_status_id = " + trackingStatusId : "") + @" AND ss2.rowstatus = 1 AND ss1.id < ss2.id
                        WHERE ss2.id IS NULL
                        AND " + string.Join(" AND ", whereClauses);

            // ReSharper disable once CoVariantArrayConversion
            return Entities.ExecuteStoreQuery<T>(sql, parameters.ToArray()).ToList();
        }

        public List<ShipmentModel> PaymentShipmentJoinCommission(int branchId, int paymentId)
        {
            var sql = string.Format(@"
                SELECT
	                s.id Id,
	                s.code Code,
                    s.date_process DateProcess,
                    f.debs Total,
                    IF (fp.totalpayment IS NULL, 0, fp.totalpayment) TotalPayment
                FROM shipment s
                INNER JOIN franchise_commission f ON s.id = f.shipment_id AND f.rowstatus = 1
                INNER JOIN franchise se ON se.id = f.franchise_id
                LEFT JOIN (
	                SELECT
		                invoice_id,
                        SUM(payment) totalpayment
                    FROM franchise_payment_in_detail
                    WHERE rowstatus = 1
                    GROUP BY invoice_id
                ) fp ON s.id = fp.invoice_id
                WHERE s.rowstatus = 1 AND s.voided = 0 AND s.sales_type_id = 5 AND s.branch_id = {0} AND se.rowstatus = 1 AND se.payment_method_id = {1}
                HAVING (Total - TotalPayment) > 0
                ", branchId, paymentId);

            return Entities.ExecuteStoreQuery<ShipmentModel>(sql).ToList();
        }

        public List<string> CheckPodNumber(string[] pods)
        {
            var sql = string.Format("SELECT code FROM shipment WHERE rowstatus = 1 AND code IN ('{0}')", string.Join("','", pods));
            var result = Entities.ExecuteStoreQuery<ShipmentCode>(sql).ToList();

            return result.Select(a => a.code).ToList();
        }

        internal class ShipmentCode
        {
            public string code { get; set; }
        }

        public ShipmentModel.ShipmentReportRow GetShipmentDetail(string code)
        {
            var sql = @"SELECT
                            s.id Id,
	                        s.code Code,
                            c.name CityName,
                            d.name DestCity,
                            s.ttl_piece TtlPiece,
                            s.ttl_chargeable_weight TtlChargeableWeight,
                            IF(s.customer_id IS NULL, '', cs.code) CustomerCode,
                            s.ref_number RefNumber,
                            s.shipper_name ShipperName,
                            s.shipper_address ShipperAddress,
                            s.shipper_phone ShipperPhone,
                            s.nature_of_goods NatureOfGoods,
                            s.note Note,
                            s.consignee_name ConsigneeName,
                            s.consignee_address ConsigneeAddress,
                            s.consignee_phone ConsigneePhone,
                            st.name ServiceType,
                            pt.name PackageType,
                            pm.name PaymentMethod,
                            s.messenger_name MessengerName,
                            s.date_process DateProcess,
                            s.tariff_total TariffTotal,
                            s.packing_fee PackingFee,
                            s.discount_total DiscountTotal,
                            s.other_fee OtherFee,
                            s.insurance_fee InsuranceFee,
                            s.total Total,
                            se.total_cod TotalCod,
                            b.header_shipment ShipmentHeader,
                            se.printed Printed,
                            se.volume_l VolumeL,
                            se.volume_w VolumeW,
                            se.volume_h VolumeH,
                            se.fulfilment Fulfilment
                        FROM shipment s
                        INNER JOIN city c ON s.city_id = c.id
                        INNER JOIN city d ON s.dest_city_id = d.id
                        LEFT JOIN customer cs ON s.customer_id = cs.id
                        INNER JOIN service_type st ON s.service_type_id = st.id
                        INNER JOIN package_type pt ON s.package_type_id = pt.id
                        INNER JOIN payment_method pm ON s.payment_method_id = pm.id
                        INNER JOIN branch b ON s.branch_id = b.id
                        LEFT JOIN shipment_expand se ON s.id = se.shipment_id
                        WHERE s.code = '{0}'";

            sql = string.Format(sql, code);
            return Entities.ExecuteStoreQuery<ShipmentModel.ShipmentReportRow>(sql).FirstOrDefault();
        }

        public List<ShipmentModel.ShipmentMobile> GetMobilePoint(DateTime from, DateTime to)
        {
            var filter = string.Format("AND s.date_process >= '{0} 00:00:00' AND s.date_process <= '{1} 23:59:59'", from.ToString("yyyy-MM-dd"), to.ToString("yyyy-MM-dd"));
            var sql = @"SELECT
	                        s.code Code,
                            s.date_process DateProcess,
                            s.total Total,
                            se.email_point EmailPoint
                        FROM shipment s
                        INNER JOIN shipment_expand se ON s.id = se.shipment_id AND se.email_point IS NOT NULL AND se.email_point <> ''
                        WHERE s.rowstatus = 1 {0}";
            sql = string.Format(sql, filter);

            return Entities.ExecuteStoreQuery<ShipmentModel.ShipmentMobile>(sql).ToList();
        }

        public IEnumerable<T> GetBooking<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
        {
            List<string> param = new List<string>();

            param.Add("s.rowstatus = 1");

            if (parameter.Any(r => r.ColumnName.Equals("branch_id")))
                param.Add(string.Format("s.branch_id = {0}", parameter.First(r => r.ColumnName.Equals("branch_id")).Value.ToString()));

            if (parameter.Any(r => r.ColumnName.Equals("sales_type_id")))
                param.Add(string.Format("s.sales_type_id = {0}", parameter.First(r => r.ColumnName.Equals("sales_type_id")).Value.ToString()));

            var sql = @"SELECT
	                        s.id Id,
	                        s.rowstatus Rowstatus,
	                        s.rowversion Rowversion,
	                        s.date_process DateProcess,
	                        s.code Code,
	                        s.city_id CityId,
	                        s.dest_city_id DestCityId,
	                        s.shipper_name ShipperName,
	                        s.shipper_address ShipperAddress,
	                        s.shipper_phone ShipperPhone,
	                        se.shipper_email ShipperEmail,
	                        s.consignee_name ConsigneeName,
	                        s.consignee_address ConsigneeAddress,
	                        s.consignee_phone ConsigneePhone,
	                        s.nature_of_goods NatureOfGoods,
	                        s.note Note,
	                        s.package_type_id PackageTypeId,
	                        s.service_type_id ServiceTypeId,
	                        s.ttl_piece TtlPiece,
	                        s.ttl_gross_weight TtlGrossWeight,
	                        s.ttl_chargeable_weight TtlChargeableWeight,
	                        se.volume_h VolumeH,
	                        se.volume_l VolumeL,
	                        se.volume_w VolumeW,
	                        s.tariff Tariff,
	                        s.handling_fee HandlingFee,
	                        s.tariff_total TariffTotal,
	                        s.tariff_net TariffNet,
	                        s.packing_fee PackingFee,
	                        s.goods_value GoodsValue,
	                        s.insurance_fee InsuranceFee,
	                        s.total Total,
                            s.messenger_id MessengerId,
                            s.messenger_name MessengerName,
                            s.messenger_id2 MessengerId2,
                            s.messenger_name2 MessengerName2,
                            s.city_name CityName
                        FROM shipment_expand se
                        INNER JOIN shipment s ON s.id = se.shipment_id AND {0}
                        WHERE se.sprinter_id > 0
                        ORDER BY s.date_process ASC";

            sql = string.Format(sql, string.Join(" AND ", param.ToArray()));

            totalCount = Entities.ExecuteStoreQuery<ShipmentModel>(sql).ToList().Count;

            sql += string.Format(" LIMIT {0}, {1}", paging.Start, paging.Limit);
            return (IEnumerable<T>)Entities.ExecuteStoreQuery<ShipmentModel>(sql).ToList();
        }

        public List<ShipmentModel.ShipmentPaymentReport> GetCashList(DateTime fromDate, DateTime toDate, int branchId)
        {
            var sql = @"SELECT
	                        s.code Code,
                            IF (se.drop_point_id IS NOT NULL,  'Drop Point', IF(se.sprinter_id IS NOT NULL, 'Sprinter', IF(s.sales_type_id = 3, 'Agent', IF(s.sales_type_id = 5, 'Franchise', 'Cash Cabang')))) SalesType,
	                        s.date_process DateProcess,
                            s.shipper_name ShipperName,
                            s.consignee_name ConsigneeName,
                            s.ttl_piece TtlPiece,
                            s.ttl_gross_weight TtlGrossWeight,
                            s.ttl_chargeable_weight TtlChargeableWeight,
                            s.total Total,
                            s.voided Voided,
                            IF (pd.id IS NOT NULL && pc.id IS NOT NULL, TRUE, FALSE) Paid,
                            IF (pc.id IS NULL, 0, IF (pc.verified = 1, 1, 0)) Verified,
                            IF (pc.id IS NOT NULL, pc.code, null) PaymentCode,
                            IF (pc.id IS NOT NULL, pc.date_process, null) PaymentDate,
                            IF (pc.id IS NOT NULL, pc.description, null) PaymentDescription,
                            pc.verified_date VerifiedDate,
                            pc.verified_by VerifiedBy
                        FROM shipment s
                        LEFT JOIN shipment_expand se ON s.id = se.shipment_id
                        LEFT JOIN payment_in_counter_detail pd ON s.id = pd.invoice_id AND pd.rowstatus = 1
                        LEFT JOIN payment_in_counter pc ON pd.payment_in_counter_id = pc.id AND pc.rowstatus = 1
                        WHERE {0}";

            var listParam = new List<string>();
            var sqlList = new List<MySqlParameter>();

            listParam.Add("s.rowstatus = @rowstatus");
            sqlList.Add(new MySqlParameter("rowstatus", 1));

            listParam.Add("s.date_process >= @fromDate");
            sqlList.Add(new MySqlParameter("fromDate", new DateTime(fromDate.Year, fromDate.Month, fromDate.Day, 0, 0, 0)));

            listParam.Add("s.date_process <= @toDate");
            sqlList.Add(new MySqlParameter("toDate", new DateTime(toDate.Year, toDate.Month, toDate.Day, 23, 59, 59)));

            listParam.Add("s.branch_id = @branchId");
            sqlList.Add(new MySqlParameter("branchId", branchId));

            listParam.Add("s.payment_method_id = @paymentId");
            sqlList.Add(new MySqlParameter("paymentId", 1));

            sql = string.Format(sql, string.Join(" AND ", listParam.ToArray()));
            return Entities.ExecuteStoreQuery<ShipmentModel.ShipmentPaymentReport>(sql, sqlList.ToArray()).ToList();
        }
    }
}