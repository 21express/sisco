using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;
using SISCO.Presentation.Reports.Finance.Forms;
using SISCO.Repositories;
using SISCO.App.Billing;
using SISCO.App.Finance;

namespace SISCO.Presentation.Reports.Finance.Command
{
    public class PaymentInOutstandingCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var now = DateTime.Now;
            var form = new ReportGenericFilterForm<object>
            {
                MdiParent = parent,
                Text = @"Finance - Outstanding Payment In",
                Report = new PaymentInOutstandingReport(),
                Parameters = new Dictionary<string, ReportParameter>
                {
                    {
                        "FromDate", new ReportParameter
                        {
                            Label = "From Date",
                            Control = new dCalendar(),
                            DefaultValue = new DateTime(now.Year, now.Month, 1)
                        }
                    },
                    {
                        "ToDate", new ReportParameter
                        {
                            Label = "To Date",
                            Control = new dCalendar(),
                            DefaultValue = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month))
                        }
                    },
                    {
                        "Customer", new ReportParameter
                        {
                            Label = "Customer",
                            Control = new dLookup
                            {
                                LookupPopup = new CustomerPopup(),
                                AutoCompleteDataManager = new CustomerDataManager(),
                                AutoCompleteDisplayFormater =
                                    row => string.Format("{0} {1}", ((CustomerModel) row).Code, ((CustomerModel) row).Name),
                                AutoCompleteWhereExpression =
                                    (s, p) => p.SetWhereExpression("(code.StartsWith(@0) OR name.StartsWith(@0)) and branch_id = @1", s, BaseControl.BranchId)
                            }
                        }
                    },
                    {
                        "PaymentTypeId", new ReportParameter
                        {
                            Label = "Payment Type",
                            Control = new dLookup
                            {
                                LookupPopup = new PaymentTypePopup(),
                                AutoCompleteDataManager = new PaymentTypeDataManager(),
                                AutoCompleteDisplayFormater = row => string.Format("{0}", ((PaymentTypeModel)row).Name),
                                AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("name.StartsWith(@0)", s)
                            },
                        }
                    }
                },
                DataSourceFunc = parameters =>
                {
                    var dateNull = new DateTime(1900, 1, 1, 0, 0, 0);
                    var param = new List<WhereTerm>();
                    var from = (DateTime)parameters["FromDate"].Value;
                    var to = (DateTime)parameters["ToDate"].Value;

                    var paramo = new List<WhereTerm>();

                    paramo.Add(WhereTerm.Default(new DateTime(from.Year, from.Month, from.Day, 0, 0, 0, 0), "vdate", EnumSqlOperator.GreatThanEqual));
                    paramo.Add(WhereTerm.Default(new DateTime(to.Year, to.Month, to.Day, 23, 59, 59, 59), "vdate", EnumSqlOperator.LesThanEqual));
                    paramo.Add(WhereTerm.Default(true, "printed"));
                    paramo.Add(WhereTerm.Default(false, "cancelled"));

                    if ((int?)parameters["Customer"].Value > 0) paramo.Add(WhereTerm.Default((int)parameters["Customer"].Value, "company_id", EnumSqlOperator.Equals));
                    if ((int?)parameters["PaymentTypeId"].Value > 0) paramo.Add(WhereTerm.Default((int)parameters["PaymentTypeId"].Value, "sales_invoice_type_id", EnumSqlOperator.Equals));

                    var invoices = new SalesInvoiceDataManager().Get<SalesInvoiceModel>(paramo.ToArray());
                    var ds = new List<PaymentInDetailModel>();
                    var _detailDm = new PaymentInDetailDataManager();
                    var salesRepo = new SalesInvoiceTypeDataManager();

                    foreach (SalesInvoiceModel invoice in invoices)
                    {
                        var payment = _detailDm.GetPaymentInvoice(invoice.Id);
                        var balance = invoice.Total - payment;

                        if (balance > 0)
                        {
                            var saleType = salesRepo.GetFirst<SalesInvoiceTypeModel>(WhereTerm.Default(invoice.SalesInvoiceTypeId, "id", EnumSqlOperator.Equals));
                            ds.Add(new PaymentInDetailModel
                            {
                                CompanyId = invoice.CompanyId,
                                CompanyName = invoice.CompanyName,
                                InvoiceCode = invoice.Code,
                                InvoiceDate = invoice.Vdate,
                                InvoiceTotal = invoice.Total,
                                InvoiceBalance = balance,
                                Payment = payment,
                                InvoiceType = saleType != null ? saleType.Name : "",
                                InvoiceRefNumber = invoice.RefNumber,
                                StateChange2 = EnumStateChange.Idle.ToString()
                            });
                        }
                    }

                    return ds;
                }
            };

            BaseControl.OpenForm(form, GetType());
        }
    }
}