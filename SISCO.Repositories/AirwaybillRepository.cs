using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using Devenlab.Common;
using Devenlab.Common.Fault;
using Devenlab.Common.Interfaces;
using SISCO.Models;
using SISCO.Repositories.Context;
using MySql.Data.MySqlClient;

namespace SISCO.Repositories
{
    public class AirwaybillRepository : SISCOBaseRepository
    {
        // ReSharper disable once InconsistentNaming
        private const string OBJECT_NAME = "Airwaybill";
        public AirwaybillRepository()
        {
            ObjectName = OBJECT_NAME;
        }
        
        public AirwaybillRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as AirwaybillModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddToairwaybills(entity);
			Entities.SaveChanges();

            businessModel.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as AirwaybillModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.airwaybills where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as AirwaybillModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.airwaybills select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.airwaybills where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.airwaybills where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}
        
        private static airwaybill PopulateModelToNewEntity(AirwaybillModel model)
		{
			return new airwaybill
			{
				id = model.Id,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				date_process = model.DateProcess,
				code = model.Code,
				branch_id = model.BranchId,
				dest_branch_id = model.DestBranchId,
				airline_id = model.AirlineId,
				airport_id = model.AirportId,
				dest_airport_id = model.DestAirportId,
				via_airport_id = model.ViaAirportId,
				type_of_packing = model.TypeOfPacking,
				dimension = model.Dimension,
				package_condition = model.PackageCondition,
				handling_information1 = model.HandlingInformation1,
				handling_information2 = model.HandlingInformation2,
				flight_id = model.FlightId,
				est_dep_date = model.EstDepDate,
				est_dep_time = model.EstDepTime,
				ttl_piece = model.TtlPiece,
				ttl_gross_weight = model.TtlGrossWeight,
				ttl_chargeable_weight = model.TtlChargeableWeight,
                gw_smu = model.GwSmu,
                diff_smu = model.DiffSmu,
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
				act_flight = model.ActFlight,
				act_dep_date = model.ActDepDate,
				act_dep_time = model.ActDepTime,
				act_same = model.ActSame,
				act_note = model.ActNote,
				act_updated = model.ActUpdated,
				act_username = model.ActUsername,
				act_confirmed = model.ActConfirmed,
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
                is_cancelled = model.IsCancelled,
                revised_to_id = model.RevisedToId,
                reason_to_revision = model.ReasonToRevision,
				createddate = model.Createddate,
				createdby = model.Createdby,
                createdpc = model.CreatedPc,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
                modifiedpc = model.ModifiedPc
			};
		}
        
        private static void PopulateModelToNewEntity(airwaybill query, AirwaybillModel model)
		{
			query.id = model.Id;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
			query.date_process = model.DateProcess;
			query.code = model.Code;
			query.branch_id = model.BranchId;
			query.dest_branch_id = model.DestBranchId;
			query.airline_id = model.AirlineId;
			query.airport_id = model.AirportId;
			query.dest_airport_id = model.DestAirportId;
			query.via_airport_id = model.ViaAirportId;
			query.type_of_packing = model.TypeOfPacking;
			query.dimension = model.Dimension;
			query.package_condition = model.PackageCondition;
			query.handling_information1 = model.HandlingInformation1;
			query.handling_information2 = model.HandlingInformation2;
			query.flight_id = model.FlightId;
			query.est_dep_date = model.EstDepDate;
			query.est_dep_time = model.EstDepTime;
			query.ttl_piece = model.TtlPiece;
			query.ttl_gross_weight = model.TtlGrossWeight;
			query.ttl_chargeable_weight = model.TtlChargeableWeight;
            query.gw_smu = model.GwSmu;
            query.diff_smu = model.DiffSmu;
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
			query.act_flight = model.ActFlight;
			query.act_dep_date = model.ActDepDate;
			query.act_dep_time = model.ActDepTime;
			query.act_same = model.ActSame;
			query.act_note = model.ActNote;
			query.act_updated = model.ActUpdated;
			query.act_username = model.ActUsername;
			query.act_confirmed = model.ActConfirmed;
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
            query.is_cancelled = model.IsCancelled;
            query.revised_to_id = model.RevisedToId;
            query.reason_to_revision = model.ReasonToRevision;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
            query.createdpc = model.CreatedPc;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
            query.modifiedpc = model.ModifiedPc;
		}
        
        private static AirwaybillModel PopulateEntityToNewModel(airwaybill item)
        {
            return new AirwaybillModel
			{
				Id = item.id,
				Rowstatus = item.rowstatus,
				Rowversion = item.rowversion,
				DateProcess = item.date_process,
				Code = item.code,
				BranchId = item.branch_id,
				DestBranchId = item.dest_branch_id,
				AirlineId = item.airline_id,
				AirportId = item.airport_id,
				DestAirportId = item.dest_airport_id,
				ViaAirportId = item.via_airport_id,
				TypeOfPacking = item.type_of_packing,
				Dimension = item.dimension,
				PackageCondition = item.package_condition,
				HandlingInformation1 = item.handling_information1,
				HandlingInformation2 = item.handling_information2,
				FlightId = item.flight_id,
				EstDepDate = item.est_dep_date,
				EstDepTime = item.est_dep_time,
				TtlPiece = item.ttl_piece,
				TtlGrossWeight = item.ttl_gross_weight,
				TtlChargeableWeight = item.ttl_chargeable_weight,
                GwSmu = item.gw_smu,
                DiffSmu = item.diff_smu,
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
				ActFlight = item.act_flight,
				ActDepDate = item.act_dep_date,
				ActDepTime = item.act_dep_time,
				ActSame = item.act_same,
				ActNote = item.act_note,
				ActUpdated = item.act_updated,
				ActUsername = item.act_username,
				ActConfirmed = item.act_confirmed,
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
                IsCancelled = item.is_cancelled,
                RevisedToId = item.revised_to_id,
                ReasonToRevision = item.reason_to_revision,
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
			var query = (from a in Entities.airwaybills select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);

            var x = EnumStateChange.Select.ToString();
            var obj = (IEnumerable<T>) (from item in query
                                        join a in Entities.airlines on item.airline_id equals a.id
                                        join o in Entities.airports on item.airport_id equals o.id
                                        join d in Entities.airports on item.dest_airport_id equals d.id
                                        join f in Entities.flights on item.flight_id equals f.id into pm
                                        join b in (from b in Entities.branches where b.rowstatus.Equals(true) select b) on item.dest_branch_id equals b.id
                                        from fl in pm.DefaultIfEmpty()
                                        select new AirwaybillModel
			                            {
				                            Id = item.id,
				                            Rowstatus = item.rowstatus,
				                            Rowversion = item.rowversion,
				                            DateProcess = item.date_process,
				                            Code = item.code,
				                            BranchId = item.branch_id,
				                            DestBranchId = item.dest_branch_id,
                                            DestBranchName = b.code,
				                            AirlineId = item.airline_id,
                                            Airline = a.name,
				                            AirportId = item.airport_id,
                                            Airport = o.name,
				                            DestAirportId = item.dest_airport_id,
                                            DestAirport = d.name,
				                            ViaAirportId = item.via_airport_id,
				                            TypeOfPacking = item.type_of_packing,
				                            Dimension = item.dimension,
				                            PackageCondition = item.package_condition,
				                            HandlingInformation1 = item.handling_information1,
				                            HandlingInformation2 = item.handling_information2,
				                            FlightId = item.flight_id,
                                            Flight = fl.flight_number,
				                            EstDepDate = item.est_dep_date,
				                            EstDepTime = item.est_dep_time,
				                            TtlPiece = item.ttl_piece,
				                            TtlGrossWeight = item.ttl_gross_weight,
				                            TtlChargeableWeight = item.ttl_chargeable_weight,
                                            GwSmu = item.gw_smu,
                                            DiffSmu = item.diff_smu,
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
				                            ActFlight = item.act_flight,
				                            ActDepDate = item.act_dep_date,
				                            ActDepTime = item.act_dep_time,
				                            ActSame = item.act_same,
				                            ActNote = item.act_note,
				                            ActUpdated = item.act_updated,
				                            ActUsername = item.act_username,
				                            ActConfirmed = item.act_confirmed,
				                            Arrived = item.arrived,
				                            ArrDate = item.arr_date,
				                            ArrTime = item.arr_time,
				                            ArrTtlPiece = (SByte) item.arr_ttl_piece,
				                            ArrTtlGrossWeight = (Decimal) item.arr_ttl_gross_weight,
				                            ArrBranchId = (int) item.arr_branch_id,
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
                                            IsCancelled = item.is_cancelled,
                                            RevisedToId = item.revised_to_id,
                                            ReasonToRevision = item.reason_to_revision,
				                            Createddate = item.createddate,
				                            Createdby = item.createdby,
                                            CreatedPc = item.createdpc,
				                            Modifieddate = item.modifieddate,
				                            Modifiedby = item.modifiedby,
                                            ModifiedPc = item.modifiedpc,
                                            StateChange2 = x
			                            });
			//return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
            return obj.ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.airwaybills select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.airwaybills select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);

			var tquery = (from a in Entities.airwaybills select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();

            var obj = (from item in query
                                       join a in (from a in Entities.airlines where a.rowstatus.Equals(true) select a) on item.airline_id equals a.id
                                       join o in (from o in Entities.airports where o.rowstatus.Equals(true) select o) on item.airport_id equals o.id
                                       join d in (from d in Entities.airports where d.rowstatus.Equals(true) select d) on item.dest_airport_id equals d.id
                                       select new AirwaybillModel
                                       {
                                           Id = item.id,
                                           Rowstatus = item.rowstatus,
                                           Rowversion = item.rowversion,
                                           DateProcess = item.date_process,
                                           Code = item.code,
                                           BranchId = item.branch_id,
                                           DestBranchId = item.dest_branch_id,
                                           AirlineId = item.airline_id,
                                           Airline = a.name,
                                           AirportId = item.airport_id,
                                           Airport = o.name,
                                           DestAirportId = item.dest_airport_id,
                                           DestAirport = d.name,
                                           ViaAirportId = item.via_airport_id,
                                           TypeOfPacking = item.type_of_packing,
                                           Dimension = item.dimension,
                                           PackageCondition = item.package_condition,
                                           HandlingInformation1 = item.handling_information1,
                                           HandlingInformation2 = item.handling_information2,
                                           FlightId = item.flight_id,
                                           EstDepDate = item.est_dep_date,
                                           EstDepTime = item.est_dep_time,
                                           TtlPiece = item.ttl_piece,
                                           TtlGrossWeight = item.ttl_gross_weight,
                                           TtlChargeableWeight = item.ttl_chargeable_weight,
                                           GwSmu = item.gw_smu,
                                           DiffSmu = item.diff_smu,
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
                                           ActFlight = item.act_flight,
                                           ActDepDate = item.act_dep_date,
                                           ActDepTime = item.act_dep_time,
                                           ActSame = item.act_same,
                                           ActNote = item.act_note,
                                           ActUpdated = item.act_updated,
                                           ActUsername = item.act_username,
                                           ActConfirmed = item.act_confirmed,
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
                                           IsCancelled = item.is_cancelled,
                                           RevisedToId = item.revised_to_id,
                                           ReasonToRevision = item.reason_to_revision,
                                           Createddate = item.createddate,
                                           Createdby = item.createdby,
                                           CreatedPc = item.createdpc,
                                           Modifieddate = item.modifieddate,
                                           Modifiedby = item.modifiedby,
                                           ModifiedPc = item.modifiedpc,
                                           StateChange = EnumStateChange.Select
                                       });
			//return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
            return (IEnumerable<T>)obj.ToList();
		}

        public IEnumerable<AirwaybillModel> ReportAirwaybill(IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var query = (from a in Entities.airwaybills select a).Where(whereterm, ListValue.ToArray());
            if (query == null)
                throw new Exception(MessageEntityNotFound);

            var obj = (from item in query
                join b in Entities.branches on item.dest_branch_id equals b.id
                join f in Entities.flights on item.flight_id equals f.id into fx
                from f in fx.DefaultIfEmpty()
                select new AirwaybillModel
                {
                    DestBranchName = b.code,
                    Code = item.code,
                    DateProcess = item.date_process,
                    TtlPiece = item.ttl_piece,
                    TtlGrossWeight = item.ttl_gross_weight,
                    Dimension = item.dimension,
                    ActFlight = f != null ? f.flight_number : item.act_flight,
                    ActDepDate = item.act_dep_date ?? item.est_dep_date,
                    ActDepTime = item.act_dep_time != "" ? item.act_dep_time : item.est_dep_time
                }).ToList();

            return obj;
        }

        public List<ConsolidationShipmentModel> GetShipments(int smuId)
        {
            var sql = @"SELECT
                            c.id ConsolidationId,
	                        cd.shipment_id ShipmentId
                        FROM airwaybill a
                        INNER JOIN airwaybill_detail ad ON a.id = ad.airwaybill_id AND ad.rowstatus = 1 AND ad.shipment_id = 0
                        INNER JOIN consolidation c ON c.code = ad.shipment_code AND c.rowstatus = 1
                        INNER JOIN consolidation_detail cd ON c.id = cd.consolidation_id AND cd.rowstatus = 1
                        WHERE a.rowstatus = 1 AND a.is_cancelled = 0 AND a.id = @smuId";

            return Entities.ExecuteStoreQuery<ConsolidationShipmentModel>(sql, new MySqlParameter("smuId", smuId)).ToList();
        }

        public List<AuditAirwaybillModel> FindAriwaybillList(int branchId, string awbNo = null, DateTime? dateFrom = null, DateTime? dateTo = null, int? airlineId = null, int? airportId = null, int? destAirportId = null)
        {
            var sql = @"SELECT
	                        a.id Id,
                            a.date_process DateProcess,
	                        a.code Code,
                            al.name Airline,
                            o.name Airport,
                            d.name DestAirport,
                            False 'Select'
                        FROM airwaybill a
                        INNER JOIN airline al ON a.airline_id = al.id
                        INNER JOIN airport o ON a.airport_id = o.id
                        INNER JOIN airport d ON a.dest_airport_id = d.id
                        INNER JOIN airwaybill_detail ad ON ad.airwaybill_id = a.id AND ad.rowstatus = 1
                        LEFT JOIN airwaybill_difference_weight_detail adwd ON adwd.airwaybill_id = a.id AND adwd.rowstatus = 1
                        LEFT JOIN airwaybill_difference_weight adw ON adwd.airwaybill_difference_weight_id = adw.id AND adw.rowstatus = 1
                        WHERE {0}
                        GROUP BY a.id
                        ORDER BY a.date_process
                        LIMIT 1000;";

            var param = new List<string>();
            var sqlParam = new List<MySqlParameter>();

            param.Add("a.rowstatus = 1");
            param.Add("a.is_cancelled = 0");
            param.Add("a.branch_id = @branchId");
            sqlParam.Add(new MySqlParameter("branchId", branchId));

            if (!string.IsNullOrEmpty(awbNo))
            {
                param.Add("a.code = @awbNo");
                sqlParam.Add(new MySqlParameter("awbNo", awbNo));
            }

            if (dateFrom != DateTime.MinValue)
            {
                var date = (DateTime)dateFrom;
                param.Add(string.Format("a.date_process >= '{0}'", date.ToString("yyyy-MM-dd 00:00:00")));
            }

            if (dateTo != DateTime.MinValue)
            {
                var date = (DateTime)dateTo;
                param.Add(string.Format("a.date_process <= '{0}'", date.ToString("yyyy-MM-dd 23:59:59")));
            }

            if (airlineId != null)
            {
                param.Add("a.airline_id = @airlineId");
                sqlParam.Add(new MySqlParameter("airlineId", airlineId));
            }

            if (airportId != null)
            {
                param.Add("a.airport_id = @airportId");
                sqlParam.Add(new MySqlParameter("airportId", airportId));
            }

            if (destAirportId != null)
            {
                param.Add("a.dest_airport_id = @destAirportId");
                sqlParam.Add(new MySqlParameter("destAirportId", destAirportId));
            }

            param.Add("adwd.id IS NULL AND adw.id IS NULL");
            sql = string.Format(sql, string.Join(" AND ", param));

            return Entities.ExecuteStoreQuery<AuditAirwaybillModel>(sql, sqlParam.ToArray()).ToList();
        }

        public List<AirwaybillHeavyDifference> GetAirwaybillReportWeight(int branchId, DateTime dateFrom, DateTime dateTo)
        {
            var sql = @"select
	                        DestBranch,
	                        AirwaybillCode,
	                        ConsolidationCode,
                            ShipmentId,
	                        ShipmentCode,
	                        CustomerName,
	                        TotalConsolidationPieces,
	                        TotalConsolidationWeight,
	                        TotalShipmentPieces,
	                        TotalShipmentWeight,
                            Diff
                        from (
	                        select
		                        b.code DestBranch,
		                        a.code AirwaybillCode,
		                        if (c.id is not null, c.code, md.consol_code) ConsolidationCode,
		                        if (c.id is not null, s.id, if (s2.id is not null, s2.id, s3.id)) ShipmentId,
		                        if (ad.shipment_code LIKE '%TRANSIT%', ad.shipment_code, if (c.id is not null, s.code, if (s2.id is not null, s2.code, s3.code))) ShipmentCode,
		                        if (c.id is not null, s.customer_name, if (s2.id is not null, s2.customer_name, s3.customer_name)) CustomerName,
		                        if (ad.shipment_code like '%TRANSIT%', ad.ttl_piece,
			                        if (c.id is not null, 
				                        (select count(consolidation_id) from consolidation_detail where consolidation_id = c.id and shipment_code = s.code and rowstatus = 1 group by consolidation_id), 
				                        1
			                        ) 
		                        ) TotalConsolidationPieces,
		                        if (ad.shipment_code like '%TRANSIT%', ad.ttl_chargeable_weight,
			                        if (c.id is not null, 
				                        c.ttl_gross_weight, 
				                        m.ttl_chargeable_weight
			                        )
		                        ) TotalConsolidationWeight,
		                        if (c.id is not null, s.ttl_piece, if (s2.id is not null, s2.ttl_piece, s3.ttl_piece)) TotalShipmentPieces,
		                        if (c.id is not null, s.ttl_chargeable_weight, if (s2.id is not null, s2.ttl_chargeable_weight, s3.ttl_chargeable_weight)) TotalShipmentWeight,
                                if (c.id is not null, se.diff_cw, if (s2.id is not null, se2.diff_cw, se3.diff_cw)) Diff
	                        from airwaybill a
	                        inner join branch b on a.dest_branch_id = b.id
	                        inner join airwaybill_detail ad on a.id = ad.airwaybill_id and ad.rowstatus = 1
	                        left join consolidation c on ad.shipment_code = c.code and c.rowstatus = 1
	                        left join consolidation_detail cd on c.id = cd.consolidation_id and cd.rowstatus = 1
	                        left join shipment s on cd.shipment_id = s.id and s.rowstatus = 1
                            left join shipment_expand se on s.id = se.shipment_id
	                        left join shipment s2 on ad.shipment_id = s2.id and s2.rowstatus = 1
                            left join shipment_expand se2 on s2.id = se2.shipment_id
	                        left join manifest_detail md on ad.shipment_code = md.consol_code and md.rowstatus = 1
	                        left join manifest m on m.id = md.manifest_id and m.rowstatus = 1
	                        left join shipment s3 on md.shipment_id = s3.id and s3.rowstatus = 1
                            left join shipment_expand se3 on s3.id = se3.shipment_id
	                        where {0}
	                        having TotalConsolidationPieces > 0
                        ) s
                        group by ConsolidationCode, ShipmentCode;";

            var sqlparam = new List<string>();
            sqlparam.Add("a.rowstatus = 1");
            sqlparam.Add("a.branch_id = @branchId");
            sqlparam.Add(string.Format("a.date_process >= '{0}'", dateFrom.ToString("yyyy-MM-dd 00:00:00")));
            sqlparam.Add(string.Format("a.date_process <= '{0}'", dateTo.ToString("yyyy-MM-dd 23:59:59")));
            sqlparam.Add("a.is_cancelled = 0");

            sql = string.Format(sql, string.Join(" and ", sqlparam));

            return Entities.ExecuteStoreQuery<AirwaybillHeavyDifference>(sql, new MySqlParameter("branchId", branchId)).ToList();
        }
    }
}