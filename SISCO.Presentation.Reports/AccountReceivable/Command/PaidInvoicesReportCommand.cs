using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraPrinting.Native;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;
using SISCO.Presentation.Reports.AccountReceivable.Forms;
using SISCO.Repositories;

namespace SISCO.Presentation.Reports.AccountReceivable.Command
{
    public class PaidInvoicesReportCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var now = DateTime.Now;
            var form = new ReportGenericFilterForm<PaidPaymentReportModel>
            {
                MdiParent = parent,
                Text = @"Paid Invoices Report",
                Report = new PaidInvoicesReport(),
                Parameters = new Dictionary<string, ReportParameter>{
                    {
                        "FromDate", new ReportParameter
                        {
                            Label = "From Date",
                            Control = new dCalendar
                            {
                                ValidationRules = new[] {new ComponentValidationRule(EnumComponentValidationRule.Mandatory), }
                            },
                            DefaultValue = new DateTime(now.Year, now.Month, 1)
                        }
                    },
                    {
                        "ToDate", new ReportParameter
                        {
                            Label = "To Date",
                            Control = new dCalendar
                            {
                                ValidationRules = new[] {new ComponentValidationRule(EnumComponentValidationRule.Mandatory), }
                            },
                            DefaultValue = now
                        }
                    },
                    {
                        "AsOfDate", new ReportParameter
                        {
                            Label = "As Of Date",
                            Control = new dCalendar
                            {
                                ValidationRules = new[] {new ComponentValidationRule(EnumComponentValidationRule.Mandatory), }
                            },
                            DefaultValue = now
                        }
                    },
                    {
                        "CustomerIdFrom", new ReportParameter
                        {
                            Label = "Customer From",
                            Control = new dLookup
                            {
                                LookupPopup = new CustomerPopup(),
                                AutoCompleteDataManager = new CustomerDataManager(),
                                AutoCompleteDisplayFormater = row => string.Format("{0} - {1}", ((CustomerModel)row).Code, ((CustomerModel)row).Name),
                                AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("(code = @0 or name.StartsWith(@0)) and branch_id = @1", s, BaseControl.BranchId)
                            },
                        }
                    },
                    {
                        "CustomerIdTo", new ReportParameter
                        {
                            Label = "Customer To",
                            Control = new dLookup
                            {
                                LookupPopup = new CustomerPopup(),
                                AutoCompleteDataManager = new CustomerDataManager(),
                                AutoCompleteDisplayFormater = row => string.Format("{0} - {1}", ((CustomerModel)row).Code, ((CustomerModel)row).Name),
                                AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("(code = @0 or name.StartsWith(@0)) and branch_id = @1", s, BaseControl.BranchId)
                            },
                        }
                    },
                    {
                        "ShowDetail", new ReportParameter
                        {
                            Label = "Detail",
                            Control = new CheckBox(),
                        }
                    }
                },
                DataSourceFunc = parameters =>
                {
                    using (var repo = new SalesInvoiceRepository())
                    {
                        var from = (DateTime) parameters["FromDate"].Value;
                        var to = (DateTime)parameters["ToDate"].Value;
                        var asof = (DateTime)parameters["AsOfDate"].Value;

                        var list = repo.GetReport<PaidPaymentReportModel>(
                            BaseControl.BranchId,
                            new DateTime(from.Year, from.Month, from.Day, 0, 0, 0) as DateTime?,
                            new DateTime(to.Year, to.Month, to.Day, 23, 59, 59) as DateTime?,
                            new DateTime(asof.Year, asof.Month, asof.Day, 23, 59, 59) as DateTime?,
                            null,
                            null,
                            parameters["CustomerIdFrom"].Value as int?,
                            parameters["CustomerIdTo"].Value as int?,
                            "paid"
                            );

                        return list;
                    }
                },
                OnLoad = (report, parameters) =>
                {
                    // ReSharper disable once ConvertToLambdaExpression
                    ((PaidInvoicesReport)report).SetDetailVisibility((bool) parameters["ShowDetail"].Value);
                },
            };

            BaseControl.OpenForm(form, GetType());
        }
    }
}