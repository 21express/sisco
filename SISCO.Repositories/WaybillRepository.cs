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
    public class WaybillRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "Waybill";
        public WaybillRepository()
        {
            ObjectName = OBJECT_NAME;
        }
        
        public WaybillRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as WaybillModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTowaybills(entity);
			Entities.SaveChanges();

            businessModel.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as WaybillModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.waybills where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as WaybillModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.waybills select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.waybills where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.waybills where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}
        
        private static waybill PopulateModelToNewEntity(WaybillModel model)
		{
			return new waybill
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				date_process = model.DateProcess,
				code = model.Code,
				branch_id = model.BranchId,
				waybill_type = model.WaybillType,
				dest_branch_id = model.DestBranchId,
				shipper_name = model.ShipperName,
				shipper_address = model.ShipperAddress,
				consignee_name = model.ConsigneeName,
				consignee_address = model.ConsigneeAddress,
				employee_id = model.EmployeeId,
				employee_name = model.EmployeeName,
				type_of_packing = model.TypeOfPacking,
				nature_of_goods = model.NatureOfGoods,
				dimension = model.Dimension,
				package_condition = model.PackageCondition,
				handling_information1 = model.HandlingInformation1,
				handling_information2 = model.HandlingInformation2,
				est_carrier = model.EstCarrier,
				est_carrier_number = model.EstCarrierNumber,
				est_dep_date = model.EstDepDate,
				est_dep_time = model.EstDepTime,
				ttl_piece = model.TtlPiece,
				ttl_gross_weight = model.TtlGrossWeight,
				ttl_chargeable_weight = model.TtlChargeableWeight,
				min_weight = model.MinWeight,
				tariff = model.Tariff,
				tariff_total = model.TariffTotal,
				before_tax_total = model.BeforeTaxTotal,
				vat = model.Vat,
				after_tax_total = model.AfterTaxTotal,
				admin_fee = model.AdminFee,
				admin_fee_via = model.AdminFeeVia,
				sc_fee = model.ScFee,
				sc_fee_min = model.ScFeeMin,
				sc_fee_min_weight = model.ScFeeMinWeight,
				sc_fee_total = model.ScFeeTotal,
				handling_fee = model.HandlingFee,
				handling_fee_total = model.HandlingFeeTotal,
				commission = model.Commission,
				commission_total = model.CommissionTotal,
				so_fee = model.SoFee,
				so_fee_total = model.SoFeeTotal,
				fe_fee = model.FeFee,
				fe_fee_total = model.FeFeeTotal,
				total = model.Total,
				total_waybill = model.TotalWaybill,
				void_fee = model.VoidFee,
				refund_fee = model.RefundFee,
				cancelled = model.Cancelled,
				posted = model.Posted,
				voided = model.Voided,
				refunded = model.Refunded,
				admin_include_tax = model.AdminIncludeTax,
				show_as_agreed = model.ShowAsAgreed,
				departed = model.Departed,
				act_carrier = model.ActCarrier,
				act_carrier_number = model.ActCarrierNumber,
				act_dep_date = model.ActDepDate,
				act_dep_time = model.ActDepTime,
				act_same = model.ActSame,
				act_note = model.ActNote,
				act_updated = model.ActUpdated,
				act_username = model.ActUsername,
				act_confirmed = model.ActConfirmed,
                act_category = model.ActCategory,
				arrived = model.Arrived,
				arr_date = model.ArrDate,
				arr_time = model.ArrTime,
				arr_ttl_piece = model.ArrTtlPiece,
				arr_ttl_gross_weight = model.ArrTtlGrossWeight,
				arr_branch_id = model.ArrBranchId,
				arr_updated = model.ArrUpdated,
				arr_username = model.ArrUsername,
				sales_ref = model.SalesRef,
				waybilled = model.Waybilled,
				total_due = model.TotalDue,
				invoice_ref = model.InvoiceRef,
				invoiced = model.Invoiced,
				total_invoiced = model.TotalInvoiced,
				total_invoiced_ori = model.TotalInvoicedOri,
				paid = model.Paid,
				total_payment = model.TotalPayment,
				port_fee = model.PortFee,
				port_fee_before_tax = model.PortFeeBeforeTax,
				port_fee_vat = model.PortFeeVat,
				port_fee_total = model.PortFeeTotal,
				status_id = model.StatusId,
				createddate = model.Createddate,
				createdby = model.Createdby,
                createdpc = model.CreatedPc,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
                modifiedpc = model.ModifiedPc
			};
		}
        
        private static void PopulateModelToNewEntity(waybill query, WaybillModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
			query.date_process = model.DateProcess;
			query.code = model.Code;
			query.branch_id = model.BranchId;
			query.waybill_type = model.WaybillType;
			query.dest_branch_id = model.DestBranchId;
			query.shipper_name = model.ShipperName;
			query.shipper_address = model.ShipperAddress;
			query.consignee_name = model.ConsigneeName;
			query.consignee_address = model.ConsigneeAddress;
			query.employee_id = model.EmployeeId;
			query.employee_name = model.EmployeeName;
			query.type_of_packing = model.TypeOfPacking;
			query.nature_of_goods = model.NatureOfGoods;
			query.dimension = model.Dimension;
			query.package_condition = model.PackageCondition;
			query.handling_information1 = model.HandlingInformation1;
			query.handling_information2 = model.HandlingInformation2;
			query.est_carrier = model.EstCarrier;
			query.est_carrier_number = model.EstCarrierNumber;
			query.est_dep_date = model.EstDepDate;
			query.est_dep_time = model.EstDepTime;
			query.ttl_piece = model.TtlPiece;
			query.ttl_gross_weight = model.TtlGrossWeight;
			query.ttl_chargeable_weight = model.TtlChargeableWeight;
			query.min_weight = model.MinWeight;
			query.tariff = model.Tariff;
			query.tariff_total = model.TariffTotal;
			query.before_tax_total = model.BeforeTaxTotal;
			query.vat = model.Vat;
			query.after_tax_total = model.AfterTaxTotal;
			query.admin_fee = model.AdminFee;
			query.admin_fee_via = model.AdminFeeVia;
			query.sc_fee = model.ScFee;
			query.sc_fee_min = model.ScFeeMin;
			query.sc_fee_min_weight = model.ScFeeMinWeight;
			query.sc_fee_total = model.ScFeeTotal;
			query.handling_fee = model.HandlingFee;
			query.handling_fee_total = model.HandlingFeeTotal;
			query.commission = model.Commission;
			query.commission_total = model.CommissionTotal;
			query.so_fee = model.SoFee;
			query.so_fee_total = model.SoFeeTotal;
			query.fe_fee = model.FeFee;
			query.fe_fee_total = model.FeFeeTotal;
			query.total = model.Total;
			query.total_waybill = model.TotalWaybill;
			query.void_fee = model.VoidFee;
			query.refund_fee = model.RefundFee;
			query.cancelled = model.Cancelled;
			query.posted = model.Posted;
			query.voided = model.Voided;
			query.refunded = model.Refunded;
			query.admin_include_tax = model.AdminIncludeTax;
			query.show_as_agreed = model.ShowAsAgreed;
			query.departed = model.Departed;
			query.act_carrier = model.ActCarrier;
			query.act_carrier_number = model.ActCarrierNumber;
			query.act_dep_date = model.ActDepDate;
			query.act_dep_time = model.ActDepTime;
			query.act_same = model.ActSame;
			query.act_note = model.ActNote;
			query.act_updated = model.ActUpdated;
			query.act_username = model.ActUsername;
			query.act_confirmed = model.ActConfirmed;
            query.act_category = model.ActCategory;
			query.arrived = model.Arrived;
			query.arr_date = model.ArrDate;
			query.arr_time = model.ArrTime;
			query.arr_ttl_piece = model.ArrTtlPiece;
			query.arr_ttl_gross_weight = model.ArrTtlGrossWeight;
			query.arr_branch_id = model.ArrBranchId;
			query.arr_updated = model.ArrUpdated;
			query.arr_username = model.ArrUsername;
			query.sales_ref = model.SalesRef;
			query.waybilled = model.Waybilled;
			query.total_due = model.TotalDue;
			query.invoice_ref = model.InvoiceRef;
			query.invoiced = model.Invoiced;
			query.total_invoiced = model.TotalInvoiced;
			query.total_invoiced_ori = model.TotalInvoicedOri;
			query.paid = model.Paid;
			query.total_payment = model.TotalPayment;
			query.port_fee = model.PortFee;
			query.port_fee_before_tax = model.PortFeeBeforeTax;
			query.port_fee_vat = model.PortFeeVat;
			query.port_fee_total = model.PortFeeTotal;
			query.status_id = model.StatusId;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
            query.createdpc = model.CreatedPc;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
            query.modifiedpc = model.ModifiedPc;
		}
        
        private static WaybillModel PopulateEntityToNewModel(waybill item)
		{
			return new WaybillModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				DateProcess = item.date_process,
				Code = item.code,
				BranchId = item.branch_id,
				WaybillType = item.waybill_type,
				DestBranchId = item.dest_branch_id,
				ShipperName = item.shipper_name,
				ShipperAddress = item.shipper_address,
				ConsigneeName = item.consignee_name,
				ConsigneeAddress = item.consignee_address,
				EmployeeId = item.employee_id,
				EmployeeName = item.employee_name,
				TypeOfPacking = item.type_of_packing,
				NatureOfGoods = item.nature_of_goods,
				Dimension = item.dimension,
				PackageCondition = item.package_condition,
				HandlingInformation1 = item.handling_information1,
				HandlingInformation2 = item.handling_information2,
				EstCarrier = item.est_carrier,
				EstCarrierNumber = item.est_carrier_number,
				EstDepDate = item.est_dep_date,
				EstDepTime = item.est_dep_time,
				TtlPiece = item.ttl_piece,
				TtlGrossWeight = item.ttl_gross_weight,
				TtlChargeableWeight = item.ttl_chargeable_weight,
				MinWeight = item.min_weight,
				Tariff = item.tariff,
				TariffTotal = item.tariff_total,
				BeforeTaxTotal = item.before_tax_total,
				Vat = item.vat,
				AfterTaxTotal = item.after_tax_total,
				AdminFee = item.admin_fee,
				AdminFeeVia = item.admin_fee_via,
				ScFee = item.sc_fee,
				ScFeeMin = item.sc_fee_min,
				ScFeeMinWeight = item.sc_fee_min_weight,
				ScFeeTotal = item.sc_fee_total,
				HandlingFee = item.handling_fee,
				HandlingFeeTotal = item.handling_fee_total,
				Commission = item.commission,
				CommissionTotal = item.commission_total,
				SoFee = item.so_fee,
				SoFeeTotal = item.so_fee_total,
				FeFee = item.fe_fee,
				FeFeeTotal = item.fe_fee_total,
				Total = item.total,
				TotalWaybill = item.total_waybill,
				VoidFee = item.void_fee,
				RefundFee = item.refund_fee,
				Cancelled = item.cancelled,
				Posted = item.posted,
				Voided = item.voided,
				Refunded = item.refunded,
				AdminIncludeTax = item.admin_include_tax,
				ShowAsAgreed = item.show_as_agreed,
				Departed = item.departed,
				ActCarrier = item.act_carrier,
				ActCarrierNumber = item.act_carrier_number,
				ActDepDate = item.act_dep_date,
				ActDepTime = item.act_dep_time,
				ActSame = item.act_same,
				ActNote = item.act_note,
				ActUpdated = item.act_updated,
				ActUsername = item.act_username,
				ActConfirmed = item.act_confirmed,
                ActCategory = item.act_category,
				Arrived = item.arrived,
				ArrDate = item.arr_date,
				ArrTime = item.arr_time,
				ArrTtlPiece = item.arr_ttl_piece,
				ArrTtlGrossWeight = item.arr_ttl_gross_weight,
				ArrBranchId = item.arr_branch_id,
				ArrUpdated = item.arr_updated,
				ArrUsername = item.arr_username,
				SalesRef = item.sales_ref,
				Waybilled = item.waybilled,
				TotalDue = item.total_due,
				InvoiceRef = item.invoice_ref,
				Invoiced = item.invoiced,
				TotalInvoiced = item.total_invoiced,
				TotalInvoicedOri = item.total_invoiced_ori,
				Paid = item.paid,
				TotalPayment = item.total_payment,
				PortFee = item.port_fee,
				PortFeeBeforeTax = item.port_fee_before_tax,
				PortFeeVat = item.port_fee_vat,
				PortFeeTotal = item.port_fee_total,
				StatusId = item.status_id,
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
			var query = (from a in Entities.waybills select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);

            var obj = (from item in query
                join b in Entities.branches on item.branch_id equals b.id
                select new WaybillModel
                {
                    Id = item.id,
                    Rowstatus = item.rowstatus,
                    Rowversion = item.rowversion,
                    DateProcess = item.date_process,
                    Code = item.code,
                    BranchId = item.branch_id,
                    BranchName = b.name,
                    WaybillType = item.waybill_type,
                    DestBranchId = item.dest_branch_id,
                    ShipperName = item.shipper_name,
                    ShipperAddress = item.shipper_address,
                    ConsigneeName = item.consignee_name,
                    ConsigneeAddress = item.consignee_address,
                    EmployeeId = item.employee_id,
                    EmployeeName = item.employee_name,
                    TypeOfPacking = item.type_of_packing,
                    NatureOfGoods = item.nature_of_goods,
                    Dimension = item.dimension,
                    PackageCondition = item.package_condition,
                    HandlingInformation1 = item.handling_information1,
                    HandlingInformation2 = item.handling_information2,
                    EstCarrier = item.est_carrier,
                    EstCarrierNumber = item.est_carrier_number,
                    EstDepDate = item.est_dep_date,
                    EstDepTime = item.est_dep_time,
                    TtlPiece = item.ttl_piece,
                    TtlGrossWeight = item.ttl_gross_weight,
                    TtlChargeableWeight = item.ttl_chargeable_weight,
                    MinWeight = item.min_weight,
                    Tariff = item.tariff,
                    TariffTotal = item.tariff_total,
                    BeforeTaxTotal = item.before_tax_total,
                    Vat = item.vat,
                    AfterTaxTotal = item.after_tax_total,
                    AdminFee = item.admin_fee,
                    AdminFeeVia = item.admin_fee_via,
                    ScFee = item.sc_fee,
                    ScFeeMin = item.sc_fee_min,
                    ScFeeMinWeight = item.sc_fee_min_weight,
                    ScFeeTotal = item.sc_fee_total,
                    HandlingFee = item.handling_fee,
                    HandlingFeeTotal = item.handling_fee_total,
                    Commission = item.commission,
                    CommissionTotal = item.commission_total,
                    SoFee = item.so_fee,
                    SoFeeTotal = item.so_fee_total,
                    FeFee = item.fe_fee,
                    FeFeeTotal = item.fe_fee_total,
                    Total = item.total,
                    TotalWaybill = item.total_waybill,
                    VoidFee = item.void_fee,
                    RefundFee = item.refund_fee,
                    Cancelled = item.cancelled,
                    Posted = item.posted,
                    Voided = item.voided,
                    Refunded = item.refunded,
                    AdminIncludeTax = item.admin_include_tax,
                    ShowAsAgreed = item.show_as_agreed,
                    Departed = item.departed,
                    ActCarrier = item.act_carrier,
                    ActCarrierNumber = item.act_carrier_number,
                    ActDepDate = item.act_dep_date,
                    ActDepTime = item.act_dep_time,
                    ActSame = item.act_same,
                    ActNote = item.act_note,
                    ActUpdated = item.act_updated,
                    ActUsername = item.act_username,
                    ActConfirmed = item.act_confirmed,
                    ActCategory = item.act_category,
                    Arrived = item.arrived,
                    ArrDate = item.arr_date,
                    ArrTime = item.arr_time,
                    ArrTtlPiece = item.arr_ttl_piece,
                    ArrTtlGrossWeight = item.arr_ttl_gross_weight,
                    ArrBranchId = item.arr_branch_id,
                    ArrUpdated = item.arr_updated,
                    ArrUsername = item.arr_username,
                    SalesRef = item.sales_ref,
                    Waybilled = item.waybilled,
                    TotalDue = item.total_due,
                    InvoiceRef = item.invoice_ref,
                    Invoiced = item.invoiced,
                    TotalInvoiced = item.total_invoiced,
                    TotalInvoicedOri = item.total_invoiced_ori,
                    Paid = item.paid,
                    TotalPayment = item.total_payment,
                    PortFee = item.port_fee,
                    PortFeeBeforeTax = item.port_fee_before_tax,
                    PortFeeVat = item.port_fee_vat,
                    PortFeeTotal = item.port_fee_total,
                    StatusId = item.status_id,
                    Createddate = item.createddate,
                    Createdby = item.createdby,
                    CreatedPc = item.createdpc,
                    Modifieddate = item.modifieddate,
                    Modifiedby = item.modifiedby,
                    ModifiedPc = item.modifiedpc
                });
			return (IEnumerable<T>) obj.ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.waybills select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.waybills select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			var tquery = (from a in Entities.waybills select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			//return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();

		    var obj = (from item in query
                       join b in (from b in Entities.branches where b.rowstatus.Equals(true) select b) on item.branch_id equals b.id
                       join de in (from de in Entities.branches where de.rowstatus.Equals(true) select de) on item.dest_branch_id equals de.id
                       select new WaybillModel
                       {
                           Id = item.id,
                           Rowstatus = item.rowstatus,
                           Rowversion = item.rowversion,
                           DateProcess = item.date_process,
                           Code = item.code,
                           BranchId = item.branch_id,
                           BranchName = b.name,
                           WaybillType = item.waybill_type,
                           DestBranchId = item.dest_branch_id,
                           DestBranchName = de.name,
                           ShipperName = item.shipper_name,
                           ShipperAddress = item.shipper_address,
                           ConsigneeName = item.consignee_name,
                           ConsigneeAddress = item.consignee_address,
                           EmployeeId = item.employee_id,
                           EmployeeName = item.employee_name,
                           TypeOfPacking = item.type_of_packing,
                           NatureOfGoods = item.nature_of_goods,
                           Dimension = item.dimension,
                           PackageCondition = item.package_condition,
                           HandlingInformation1 = item.handling_information1,
                           HandlingInformation2 = item.handling_information2,
                           EstCarrier = item.est_carrier,
                           EstCarrierNumber = item.est_carrier_number,
                           EstDepDate = item.est_dep_date,
                           EstDepTime = item.est_dep_time,
                           TtlPiece = item.ttl_piece,
                           TtlGrossWeight = item.ttl_gross_weight,
                           TtlChargeableWeight = item.ttl_chargeable_weight,
                           MinWeight = item.min_weight,
                           Tariff = item.tariff,
                           TariffTotal = item.tariff_total,
                           BeforeTaxTotal = item.before_tax_total,
                           Vat = item.vat,
                           AfterTaxTotal = item.after_tax_total,
                           AdminFee = item.admin_fee,
                           AdminFeeVia = item.admin_fee_via,
                           ScFee = item.sc_fee,
                           ScFeeMin = item.sc_fee_min,
                           ScFeeMinWeight = item.sc_fee_min_weight,
                           ScFeeTotal = item.sc_fee_total,
                           HandlingFee = item.handling_fee,
                           HandlingFeeTotal = item.handling_fee_total,
                           Commission = item.commission,
                           CommissionTotal = item.commission_total,
                           SoFee = item.so_fee,
                           SoFeeTotal = item.so_fee_total,
                           FeFee = item.fe_fee,
                           FeFeeTotal = item.fe_fee_total,
                           Total = item.total,
                           TotalWaybill = item.total_waybill,
                           VoidFee = item.void_fee,
                           RefundFee = item.refund_fee,
                           Cancelled = item.cancelled,
                           Posted = item.posted,
                           Voided = item.voided,
                           Refunded = item.refunded,
                           AdminIncludeTax = item.admin_include_tax,
                           ShowAsAgreed = item.show_as_agreed,
                           Departed = item.departed,
                           ActCarrier = item.act_carrier,
                           ActCarrierNumber = item.act_carrier_number,
                           ActDepDate = item.act_dep_date,
                           ActDepTime = item.act_dep_time,
                           ActSame = item.act_same,
                           ActNote = item.act_note,
                           ActUpdated = item.act_updated,
                           ActUsername = item.act_username,
                           ActConfirmed = item.act_confirmed,
                           ActCategory = item.act_category,
                           Arrived = item.arrived,
                           ArrDate = item.arr_date,
                           ArrTime = item.arr_time,
                           ArrTtlPiece = item.arr_ttl_piece,
                           ArrTtlGrossWeight = item.arr_ttl_gross_weight,
                           ArrBranchId = item.arr_branch_id,
                           ArrUpdated = item.arr_updated,
                           ArrUsername = item.arr_username,
                           SalesRef = item.sales_ref,
                           Waybilled = item.waybilled,
                           TotalDue = item.total_due,
                           InvoiceRef = item.invoice_ref,
                           Invoiced = item.invoiced,
                           TotalInvoiced = item.total_invoiced,
                           TotalInvoicedOri = item.total_invoiced_ori,
                           Paid = item.paid,
                           TotalPayment = item.total_payment,
                           PortFee = item.port_fee,
                           PortFeeBeforeTax = item.port_fee_before_tax,
                           PortFeeVat = item.port_fee_vat,
                           PortFeeTotal = item.port_fee_total,
                           StatusId = item.status_id,
                           Createddate = item.createddate,
                           Createdby = item.createdby,
                           CreatedPc = item.createdpc,
                           Modifieddate = item.modifieddate,
                           Modifiedby = item.modifiedby,
                           ModifiedPc = item.modifiedpc
                       });
		    return (IEnumerable<T>) obj.ToList();
		}

        public IEnumerable<WaybillModel> ReportWaybill(params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.waybills select a).Where(whereterm, ListValue.ToArray()).ToList();
            if (query == null)
                throw new Exception(MessageEntityNotFound);

            var obj = (from a in query
                join b in Entities.branches on a.dest_branch_id equals b.id
                select new WaybillModel
                {
                    DestBranchName = b.code,
                    DateProcess = a.date_process,
                    Code = a.code,
                    Dimension = a.dimension,
                    ArrTtlPiece = a.ttl_piece,
                    TtlGrossWeight = a.ttl_gross_weight,
                    EstCarrier = a.est_carrier,
                    EmployeeName = a.employee_name
                });
            return obj.ToList();
        }
    }
}