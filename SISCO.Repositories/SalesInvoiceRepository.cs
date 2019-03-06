using System;
using System.Collections.Generic;
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
    public class SalesInvoiceRepository : SISCOBaseRepository
    {
        private const string OBJECT_NAME = "SalesInvoice";
        public SalesInvoiceRepository()
        {
            ObjectName = OBJECT_NAME;
        }
        
        public SalesInvoiceRepository(SISCODBEntities entity)
        {
            ObjectName = OBJECT_NAME;
            Entities = entity;
        }
                
        public override void Save<T>(T businessModel)
		{
			var model = businessModel as SalesInvoiceModel;
			if (model == null)
				throw new ModelNullException();
			var entity = PopulateModelToNewEntity(model);
			Entities.AddTosales_invoice(entity);
			Entities.SaveChanges();

            businessModel.Id = entity.id;
		}
        
        public override void Update<T>(T businessModel)
		{
			var model = businessModel as SalesInvoiceModel;
			if (model == null)
				throw new ModelNullException(MessageModelNull);
			var query = (from d in Entities.sales_invoice where d.id == model.Id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			PopulateModelToNewEntity(query, model);
			Entities.SaveChanges();
		}
        
        public override void Update<T>(T businessModel, params IListParameter[] parameter)
        {
            var whereterm = GetQueryParameterLinq(parameter);
            var model = businessModel as SalesInvoiceModel;

            if (model == null)
                throw new ModelNullException(MessageModelNull);
            var query = (from d in Entities.sales_invoice select d).Where(whereterm, ListValue.ToArray()).FirstOrDefault();
            if (query == null)
                throw new ModelNullException(MessageEntityNotFound);
            PopulateModelToNewEntity(query, model);
            Entities.SaveChanges();
        }
        
        public override void DeActive(int id, string userName, DateTime deleteDate)
        {
            var query = (from d in Entities.sales_invoice where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
            query.rowstatus = false;
            query.modifiedby = userName;
            query.modifieddate = deleteDate;
			Entities.SaveChanges();
        }
        
        public override void Delete(int id)
		{
			var query = (from d in Entities.sales_invoice where d.id == id select d).FirstOrDefault();
			if (query == null)
				throw new ModelNullException(MessageEntityNotFound);
			Entities.DeleteObject(query);
			Entities.SaveChanges();
		}
        
        private static sales_invoice PopulateModelToNewEntity(SalesInvoiceModel model)
		{
			return new sales_invoice
			{
				id = model.Id,
				vdate = model.Vdate,
				code = model.Code,
				ref_number = model.RefNumber,
				branch_id = model.BranchId,
				employee_id = model.EmployeeId,
				credit = model.Credit,
				due_date = model.DueDate,
				sales_invoice_type_id = model.SalesInvoiceTypeId,
				period = model.Period,
				date_from = model.DateFrom,
				date_to = model.DateTo,
				filter_dest_city_id = model.FilterDestCityId,
				filter_package_type_id = model.FilterPackageTypeId,
				filter_payment_method_id = model.FilterPaymentMethodId,
				filter_sales_invoice_type_id = model.FilterSalesInvoiceTypeId,
				company_id = model.CompanyId,
				company_name = model.CompanyName,
				company_invoiced_to = model.CompanyInvoicedTo,
				discount = model.Discount,
				currency_id = model.CurrencyId,
				currency_rate = model.CurrencyRate,
				total_piece = model.TotalPiece,
				total_gross_weight = model.TotalGrossWeight,
				total_chargeable_weight = model.TotalChargeableWeight,
				total_sales = model.TotalSales,
				total_cost = model.TotalCost,
				total = model.Total,
				cost_materai = model.CostMaterai,
				wh_weight = model.WhWeight,
				wh_kg = model.WhKg,
				wh_kg_total = model.WhKgTotal,
				wh_admin = model.WhAdmin,
				wh_total = model.WhTotal,
				total_service_tariff1 = model.TotalServiceTariff1,
				total_service_tariff2 = model.TotalServiceTariff2,
				total_service_tariff3 = model.TotalServiceTariff3,
				total_record = model.TotalRecord,
				total_discount = model.TotalDiscount,
				total_packing = model.TotalPacking,
				total_other = model.TotalOther,
				printed = model.Printed,
				cancelled = model.Cancelled,
                invoice_revised = model.InvoiceRevised,
                invoice_revision_of = model.InvoiceRevisionOf,
				paid = model.Paid,
				total_payment = model.TotalPayment,
				rc_percent = model.RcPercent,
				rc_percent_total = model.RcPercentTotal,
				rc_kg = model.RcKg,
                rc_kg_total = model.RcKgTotal,
                rc_fixed = model.RcFixed,
                rc_total = model.RcTotal,
                ra_chargeable_weight = model.RaChargeableWeight,
                ra_fee = model.RaFee,
                ra_total = model.RaTotal,
				paid_rc = model.PaidRc,
				total_payment_rc = model.TotalPaymentRc,
                description = model.Description,
                description1 = model.Description1,
                description2 = model.Description2,
                description3 = model.Description3,
                tax_type_id = model.TaxTypeId,
                tax_invoice_id = model.TaxInvoiceId,
                req_tax_invoice = model.ReqTaxInvoice,
                tax_rate = model.TaxRate,
                tax_total = model.TaxTotal,
                tax_invoice = model.TaxInvoice,
				rowstatus = model.Rowstatus,
				rowversion = model.Rowversion,
				createddate = model.Createddate,
				createdby = model.Createdby,
				modifieddate = model.Modifieddate,
				modifiedby = model.Modifiedby,
			};
		}
        
        private static void PopulateModelToNewEntity(sales_invoice query, SalesInvoiceModel model)
		{
			query.id = model.Id;
			query.vdate = model.Vdate;
			query.code = model.Code;
			query.ref_number = model.RefNumber;
			query.branch_id = model.BranchId;
			query.employee_id = model.EmployeeId;
			query.credit = model.Credit;
			query.due_date = model.DueDate;
			query.sales_invoice_type_id = model.SalesInvoiceTypeId;
			query.period = model.Period;
			query.date_from = model.DateFrom;
			query.date_to = model.DateTo;
			query.filter_dest_city_id = model.FilterDestCityId;
			query.filter_package_type_id = model.FilterPackageTypeId;
			query.filter_payment_method_id = model.FilterPaymentMethodId;
			query.filter_sales_invoice_type_id = model.FilterSalesInvoiceTypeId;
			query.company_id = model.CompanyId;
			query.company_name = model.CompanyName;
			query.company_invoiced_to = model.CompanyInvoicedTo;
			query.discount = model.Discount;
			query.currency_id = model.CurrencyId;
			query.currency_rate = model.CurrencyRate;
			query.total_piece = model.TotalPiece;
			query.total_gross_weight = model.TotalGrossWeight;
			query.total_chargeable_weight = model.TotalChargeableWeight;
			query.total_sales = model.TotalSales;
			query.total_cost = model.TotalCost;
			query.total = model.Total;
			query.cost_materai = model.CostMaterai;
			query.wh_weight = model.WhWeight;
			query.wh_kg = model.WhKg;
			query.wh_kg_total = model.WhKgTotal;
			query.wh_admin = model.WhAdmin;
			query.wh_total = model.WhTotal;
			query.total_service_tariff1 = model.TotalServiceTariff1;
			query.total_service_tariff2 = model.TotalServiceTariff2;
			query.total_service_tariff3 = model.TotalServiceTariff3;
			query.total_record = model.TotalRecord;
			query.total_discount = model.TotalDiscount;
			query.total_packing = model.TotalPacking;
			query.total_other = model.TotalOther;
			query.printed = model.Printed;
			query.cancelled = model.Cancelled;
            query.invoice_revised = model.InvoiceRevised;
            query.invoice_revision_of = model.InvoiceRevisionOf;
			query.paid = model.Paid;
			query.total_payment = model.TotalPayment;
			query.rc_percent = model.RcPercent;
			query.rc_percent_total = model.RcPercentTotal;
			query.rc_kg = model.RcKg;
            query.rc_kg_total = model.RcKgTotal;
            query.rc_fixed = model.RcFixed;
            query.rc_total = model.RcTotal;
            query.ra_chargeable_weight = model.RaChargeableWeight;
            query.ra_fee = model.RaFee;
            query.ra_total = model.RaTotal;
			query.paid_rc = model.PaidRc;
			query.total_payment_rc = model.TotalPaymentRc;
			query.description = model.Description;
			query.description1 = model.Description1;
			query.description2 = model.Description2;
			query.description3 = model.Description3;
            query.tax_type_id = model.TaxTypeId;
            query.req_tax_invoice = model.ReqTaxInvoice;
            query.tax_invoice_id = model.TaxInvoiceId;
            query.tax_rate = model.TaxRate;
            query.tax_total = model.TaxTotal;
            query.tax_invoice = model.TaxInvoice;
			query.rowstatus = model.Rowstatus;
			query.rowversion = model.Rowversion;
			query.createddate = model.Createddate;
			query.createdby = model.Createdby;
			query.modifieddate = model.Modifieddate;
			query.modifiedby = model.Modifiedby;
		}
        
        private static SalesInvoiceModel PopulateEntityToNewModel(sales_invoice item)
		{
			return new SalesInvoiceModel
			{
				Id = item.id,
				Vdate = item.vdate,
				Code = item.code,
				RefNumber = item.ref_number,
				BranchId = item.branch_id,
				EmployeeId = item.employee_id,
				Credit = item.credit,
				DueDate = item.due_date,
				SalesInvoiceTypeId = item.sales_invoice_type_id,
				Period = item.period,
				DateFrom = item.date_from,
				DateTo = item.date_to,
				FilterDestCityId = item.filter_dest_city_id,
				FilterPackageTypeId = item.filter_package_type_id,
				FilterPaymentMethodId = item.filter_payment_method_id,
				FilterSalesInvoiceTypeId = item.filter_sales_invoice_type_id,
				CompanyId = item.company_id,
				CompanyName = item.company_name,
				CompanyInvoicedTo = item.company_invoiced_to,
				Discount = item.discount,
				CurrencyId = item.currency_id,
				CurrencyRate = item.currency_rate,
				TotalPiece = item.total_piece,
				TotalGrossWeight = item.total_gross_weight,
				TotalChargeableWeight = item.total_chargeable_weight,
				TotalSales = item.total_sales,
				TotalCost = item.total_cost,
				Total = item.total,
				CostMaterai = item.cost_materai,
				WhWeight = item.wh_weight,
				WhKg = item.wh_kg,
				WhKgTotal = item.wh_kg_total,
				WhAdmin = item.wh_admin,
				WhTotal = item.wh_total,
				TotalServiceTariff1 = item.total_service_tariff1,
				TotalServiceTariff2 = item.total_service_tariff2,
				TotalServiceTariff3 = item.total_service_tariff3,
				TotalRecord = item.total_record,
				TotalDiscount = item.total_discount,
				TotalPacking = item.total_packing,
				TotalOther = item.total_other,
				Printed = item.printed,
				Cancelled = item.cancelled,
                InvoiceRevised = item.invoice_revised,
                InvoiceRevisionOf = item.invoice_revision_of,
				Paid = item.paid,
				TotalPayment = item.total_payment,
				RcPercent = item.rc_percent,
				RcPercentTotal = item.rc_percent_total,
				RcKg = item.rc_kg,
                RcKgTotal = item.rc_kg_total,
                RcFixed = item.rc_fixed,
                RcTotal = item.rc_total,
                RaChargeableWeight = item.ra_chargeable_weight,
                RaFee = item.ra_fee,
                RaTotal = item.ra_total,
				PaidRc = item.paid_rc,
				TotalPaymentRc = item.total_payment_rc,
                Description = item.description,
                Description1 = item.description1,
                Description2 = item.description2,
                Description3 = item.description3,
                TaxTypeId = item.tax_type_id,
                ReqTaxInvoice = item.req_tax_invoice,
                TaxInvoiceId = item.tax_invoice_id,
                TaxRate = item.tax_rate,
                TaxTotal = item.tax_total,
                TaxInvoice = item.tax_invoice,
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
			var query = (from a in Entities.sales_invoice select a).Where(whereterm, ListValue.ToArray()).AsQueryable();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).ToList();
		}

		public override T GetSingle<T>(params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.sales_invoice select a).Where(whereterm, ListValue.ToArray()).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
            var result = (IEnumerable<T>)query.Select(PopulateEntityToNewModel).ToList();
		    return result.FirstOrDefault();
		}

		public override IEnumerable<T> Get<T>(Paging paging, out int totalCount, params IListParameter[] parameter)
		{
			var whereterm = GetQueryParameterLinq(parameter);
			var query = (from a in Entities.sales_invoice select a).Where(whereterm, ListValue.ToArray()).OrderBy(paging.SortColumn + " " + paging.Direction).Skip(paging.Start).Take(paging.Limit).ToList();
			if (query == null)
				throw new Exception(MessageEntityNotFound);
			var tquery = (from a in Entities.sales_invoice select a).Where(whereterm, ListValue.ToArray());
			totalCount = tquery.Count();
			return (IEnumerable<T>) query.Select(PopulateEntityToNewModel).Cast<SalesInvoiceModel>().ToList();
		}

        public List<ReportInvoice> ReportInvoiceGlobal(string period, string invoice, int branchId, int customerId, bool outstanding)
        {
            if (!string.IsNullOrEmpty(invoice))
            {
                if (invoice.Length == 1) invoice = string.Format("{0} ", invoice);
            }

            var sql = @"SELECT
                            s.ref_number InvoiceNo,
                            s.company_invoiced_to CustomerName,
                            s.total TotalInvoice,
                            DATE_FORMAT(CONCAT(s.period, '01'),'%M') Period,
                            IF(LEFT(s.ref_number, 2) = 'AD', 'DARAT', 
		                        IF(LEFT(s.ref_number, 2) = 'AP', 'PAJAK', 
			                        IF(s.total_service_tariff3 > 0, 'INTERNATIONAL', 'INVOICE')
		                        )
	                        ) InvoiceType,
                            s.cancelled Cancelled,
                            s.invoice_revised InvoiceRevised,
                            pd.payment Payment,
                            p.date_process DatePaid,
                            p.adjustment Adjustment,
                            pt.name PaymentType,
                            IF (o.id IS NULL, 0, 1) OtherInvoice
                        FROM sales_invoice s
                        LEFT JOIN payment_in_detail pd ON pd.invoice_id = s.id AND pd.rowstatus = 1
                        LEFT JOIN payment_in p ON pd.payment_in_id = p.id AND p.rowstatus = 1
                        LEFT JOIN payment_type pt ON p.payment_type_id = pt.id
                        LEFT JOIN other_invoice o ON s.ref_number = o.ref_number
                        WHERE s.rowstatus = 1 AND s.branch_id = " +  branchId +
                            @" AND s.period = '" + period + "'" 
                            + (!string.IsNullOrEmpty(invoice) ? " AND s.ref_number LIKE '" + invoice + "%'" : "")
                            + (customerId > 0 ? " AND s.company_id = " + customerId : "") 
                            + (outstanding ? " AND (pd.payment IS NULL OR pd.payment = 0 OR pd.payment <> s.total) AND s.total > 0" : string.Empty)
                            + " ORDER BY InvoiceType, InvoiceNo;";

            var result = Entities.ExecuteStoreQuery<ReportInvoice>(sql);
            return result.ToList();
        }

        public string GenerateCode(SalesInvoiceModel model)
        {
            var branchPrefix = (from a in Entities.branches
                                where a.id == model.BranchId
                                select a.code).FirstOrDefault();

            var now = DateTime.Now;
            var pattern = string.Format("INV-{0}-{1:0000}-{2:00}-#####", branchPrefix, now.Year, now.Month);

            return GenerateCode("sales_invoice", pattern);
        }

        public IEnumerable<T> GetReport<T>(
            int branchId,
            DateTime? fromDate, DateTime? toDate,
            DateTime? asOfDate,
            DateTime? fromDueDate, DateTime? toDueDate,
            int? customerIdFrom, int? customerIdTo,
            string type)
        {
            var parameters = new List<MySqlParameter>();
            var whereClauses = new List<string>();

            whereClauses.Add("si.rowstatus = @rowstatus");
            parameters.Add(new MySqlParameter("rowstatus", 1));

            whereClauses.Add("si.branch_id = @branchId");
            parameters.Add(new MySqlParameter("branchId", branchId));

            if (fromDate != null && fromDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(si.vdate) >= DATE(@dateFrom)");
                parameters.Add(new MySqlParameter("dateFrom", fromDate));
            }

            if (toDate != null && toDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(si.vdate) <= DATE(@toDate)");
                parameters.Add(new MySqlParameter("toDate", toDate));
            }

            parameters.Add(new MySqlParameter("asOfDate", asOfDate));

            if (fromDueDate != null && fromDueDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(si.due_date) >= DATE(@fromDueDate)");
                parameters.Add(new MySqlParameter("fromDueDate", fromDueDate));
            }

            if (toDueDate != null && toDueDate != DateTime.MinValue)
            {
                whereClauses.Add("DATE(si.due_date) <= DATE(@toDueDate)");
                parameters.Add(new MySqlParameter("toDueDate", toDueDate));
            }

            if (customerIdFrom != null && customerIdFrom != 0)
            {
                whereClauses.Add("si.company_id >= @customerIdFrom");
                parameters.Add(new MySqlParameter("customerIdFrom", customerIdFrom));
            }

            if (customerIdTo != null && customerIdTo != 0)
            {
                whereClauses.Add("si.company_id <= @customerIdTo");
                parameters.Add(new MySqlParameter("customerIdTo", customerIdTo));
            }

            string sql = "SELECT *" + (type == "paid" ? ", Total - TotalPayment AS Outstanding" : "") + @" FROM (SELECT
                            si.id AS Id,
                            si.vdate AS Vdate,
                            si.code AS Code,
                            si.ref_number AS RefNumber,
                            si.due_date AS DueDate,
                            si.company_invoiced_to AS CompanyInvoicedTo,
                            si.company_id AS CompanyId,
                            si.company_name AS CompanyName,
                            si.total AS Total,
                            pi.code AS PaymentCode,
                            pi.date_process AS PaymentDate,
                            pi.description AS PaymentDescription,
                            pid.payment AS PaymentAmount,
                            IFNULL((SELECT SUM(pid2.payment) FROM payment_in_detail pid2 WHERE pid2.invoice_id = si.id AND pid2.rowstatus = 1 AND DATE(pid2.date_process) <= DATE(@asOfDate)), 0) AS TotalPayment
                        FROM sales_invoice si
                        LEFT JOIN payment_in_detail pid ON pid.invoice_id = si.id AND pid.rowstatus = 1 AND DATE(pid.date_process) <= DATE(@asOfDate)
                        LEFT JOIN payment_in pi ON pi.id = pid.payment_in_id AND pi.rowstatus = 1
                        WHERE " + string.Join(" AND ", whereClauses) + ") c";

            switch (type)
            {
                case "paid":
                    sql += " WHERE c.TotalPayment >= c.Total";
                    break;
                case "due":
                    sql += " WHERE c.TotalPayment < c.Total";
                    break;
                case "overdue":
                    sql += " WHERE c.TotalPayment < c.Total AND DATE(c.DueDate) < DATE(NOW())";
                    break;
                case "outstanding":
                    sql += " WHERE c.TotalPayment < c.Total";
                    break;
                default:
                    ;// nothing
                    break;
            }

            return Entities.ExecuteStoreQuery<T>(sql, parameters.ToArray()).ToList();
        }

        public List<InvoiceTax> GetTaxInvoice(string year, string month = null, int? branchId = null, bool? isprinted = null, int? taxInvoiceId = null)
        {
            var sql = @"SELECT
	                        s.id Id,
                            s.vdate DateProcess,
                            s.ref_number RefNumber,
                            s.code Code,
                            s.branch_id BranchId,
                            b.code BranchCode,
                            s.due_date DueDate,
                            s.company_invoiced_to CompanyInvoicedTo,
                            s.total Total,
                            s.tax_total TaxTotal,
                            s.period Period,
                            s.tax_invoice TaxInvoice,
                            s.printed Printed,
                            ti.name TaxInvoiceName,
                            s.invoice_revision_of InvoiceRevisionOf
                        FROM sales_invoice s
                        INNER JOIN branch b ON s.branch_id = b.id
                        INNER JOIN tax_invoice ti ON s.tax_invoice_id = ti.id
                        WHERE {0} ORDER BY s.vdate ASC";

            var whereList = new List<string>();
            var sqlParam = new List<MySqlParameter>();

            whereList.Add("s.rowstatus = 1");
            whereList.Add("s.cancelled = 0");
            whereList.Add("s.req_tax_invoice = 1");
            if (isprinted != null)
                whereList.Add(string.Format("s.printed = {0}", Convert.ToInt16(isprinted)));
            if (taxInvoiceId != null) whereList.Add(string.Format("s.tax_invoice_id = {0}", taxInvoiceId));

            whereList.Add("s.period LIKE @period");
            sqlParam.Add(new MySqlParameter("period", string.Format("{0}{1}%", year, month)));

            if (branchId != null)
            {
                whereList.Add("s.branch_id LIKE @branchId");
                sqlParam.Add(new MySqlParameter("branchId", branchId));
            }

            sql = string.Format(sql, string.Join(" AND ", whereList));
            return Entities.ExecuteStoreQuery<InvoiceTax>(sql, sqlParam.ToArray()).ToList();
        }

        public List<InvoiceDistributionInternalModel> GetInvoiceDistribution(int branchId, DateTime? invoiceFrom = null, DateTime? invoiceTo = null,
            DateTime? sendFrom = null, DateTime? sendTo = null)
        {
            var sql = @"SELECT 
	                        si.ref_number RefNumber,
                            si.vdate DateProcess,
                            si.due_date DueDate,
                            si.company_invoiced_to CustomerName,
                            si.period Period,
                            si.cancelled Cancelled,
                            IF (itfd.id IS NOT NULL AND itf.id IS NOT NULL, true, false) IsBillingDeliver,
                            IF (itfd.id IS NOT NULL AND itf.id IS NOT NULL, itf.date_process, null) BillingDeliverDate,
                            IF (siad.id IS NOT NULL AND sia.id IS NOT NULL, true, false) IsFinanceAcceptance,
                            IF (siad.id IS NOT NULL AND sia.id IS NOT NULL, sia.date_process, null) FinanceAcceptanceDate,
                            IF (siad.id IS NOT NULL AND sia.id IS NOT NULL, e.name, null) CollectorName,
                            IF (idrd.id IS NOT NULL AND idr.id IS NOT NULL, true, false) IsReceipt,
                            IF (idrd.id IS NOT NULL AND idr.id IS NOT NULL, e2.name, null) ReportCollectorName,
                            IF (idrd.id IS NOT NULL AND idr.id IS NOT NULL, idr.date_process, null) ReceiptDate,
                            IF (idrd.id IS NOT NULL AND idr.id IS NOT NULL, idrd.receipt_name, null) ReceiptName,
                            IF (idrd.id IS NOT NULL AND idr.id IS NOT NULL, pt.name, null) PaymentType,
                            IF (itd.id IS NOT NULL AND it.id IS NOT NULL, true, false) IsDeliverTransfer,
                            IF (itd.id IS NOT NULL AND it.id IS NOT NULL, it.date_process, null) DeliverTransferDate,
                            IF (itad.id IS NOT NULL AND ita.id IS NOT NULL, true, false) IsTransferAccepted,
                            IF (itad.id IS NOT NULL AND ita.id IS NOT NULL, ita.date_process, null) TransferAcceptedDate
                        FROM sales_invoice si 
                        LEFT JOIN invoice_to_finance_detail itfd ON si.id = itfd.sales_invoice_id AND itfd.rowstatus = 1
                        LEFT JOIN invoice_to_finance itf ON itfd.invoice_to_finance_id = itf.id AND itf.rowstatus = 1
                        LEFT JOIN sales_invoice_acceptance_detail siad ON si.id = siad.sales_invoice_id AND siad.rowstatus = 1
                        LEFT JOIN sales_invoice_acceptance sia ON siad.sales_invoice_acceptance_id = sia.id AND sia.rowstatus = 1
                        LEFT JOIN employee e ON siad.collector_id = e.id
                        LEFT JOIN invoice_distribution_result_detail idrd ON si.id = idrd.sales_invoice_id AND idrd.rowstatus = 1
                        LEFT JOIN invoice_distribution_result idr ON idrd.invoice_distribution_result_id = idr.id AND idr.rowstatus = 1
                        LEFT JOIN employee e2 ON idrd.collector_id = e2.id
                        LEFT JOIN payment_type pt ON idrd.payment_type_id = pt.id
                        LEFT JOIN invoice_transfer_detail itd ON si.id = itd.sales_invoice_id AND itd.rowstatus = 1
                        LEFT JOIN invoice_transfer it ON itd.invoice_transfer_id = it.id AND it.rowstatus = 1
                        LEFT JOIN invoice_transfer_acceptance_detail itad ON si.id = itad.sales_invoice_id AND itad.rowstatus = 1
                        LEFT JOIN invoice_transfer_acceptance ita ON itad.invoice_transfer_acceptance_id = ita.id AND ita.rowstatus = 1
                        WHERE {0};";

            List<string> param = new List<string>();
            List<MySqlParameter> sqlparam = new List<MySqlParameter>();

            param.Add("si.rowstatus = 1");

            param.Add("si.branch_id = @branchId");
            sqlparam.Add(new MySqlParameter("branchId", branchId));

            if (invoiceFrom > DateTime.MinValue)
            {
                param.Add("si.vdate >= @invoiceFrom");
                sqlparam.Add(new MySqlParameter("invoiceFrom", ((DateTime)invoiceFrom).ToString("yyyy-MM-dd 00:00:00")));
            }

            if (invoiceTo > DateTime.MinValue)
            {
                param.Add("si.vdate <= @invoiceTo");
                sqlparam.Add(new MySqlParameter("invoiceTo", ((DateTime)invoiceTo).ToString("yyyy-MM-dd 23:59:59")));
            }

            if (sendFrom > DateTime.MinValue)
            {
                param.Add("itf.date_process >= @sendFrom");
                sqlparam.Add(new MySqlParameter("sendFrom", ((DateTime)sendFrom).ToString("yyyy-MM-dd 00:00:00")));
            }

            if (sendTo > DateTime.MinValue)
            {
                param.Add("itf.date_process <= @sendTo");
                sqlparam.Add(new MySqlParameter("sendTo", ((DateTime)sendTo).ToString("yyyy-MM-dd 23:59:59")));
            }

            sql = string.Format(sql, string.Join(" AND ", param));
            return Entities.ExecuteStoreQuery<InvoiceDistributionInternalModel>(sql, sqlparam.ToArray()).ToList();
        }

        public List<PrintInvoiceModel> GetInvoiceToPrint(int branchId, string year, string month, int taxInvoiceId)
        {
            var sql = @"SELECT
                            id Id,
                            code Code,
	                        vdate DateProcess,
	                        ref_number RefNumber,
                            company_invoiced_to CustomerName,
                            period Period,
                            due_date DueDate,
                            total Total,
                            printed Printed,
                            tax_invoice TaxInvoice,
                            false PrintDetail,
                            false PrintInvoice,
                            false PrintDelivery,
                            false PrintFaktur
                        FROM sales_invoice
                        WHERE rowstatus = 1 AND cancelled = 0 AND branch_id = @branchId AND period = @period AND tax_invoice_id = @taxInvoiceId;";

            var sqlparam = new List<MySqlParameter>();
            sqlparam.Add(new MySqlParameter("branchId", branchId));
            sqlparam.Add(new MySqlParameter("period", string.Format("{0}{1}", year, month)));
            sqlparam.Add(new MySqlParameter("taxInvoiceId", taxInvoiceId));

            return Entities.ExecuteStoreQuery<PrintInvoiceModel>(sql, sqlparam.ToArray()).ToList();
        }
    }
}