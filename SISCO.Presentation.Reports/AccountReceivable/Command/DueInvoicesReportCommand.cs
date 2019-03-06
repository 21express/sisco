using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using DevExpress.XtraPrinting.Native;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;
using SISCO.Presentation.Reports.AccountReceivable.Forms;
using SISCO.Presentation.Reports.Sales.Forms;
using SISCO.Repositories;

namespace SISCO.Presentation.Reports.AccountReceivable.Command
{
    public class DueInvoicesReportCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var now = DateTime.Now;
            var form = new ReportGenericFilterForm<SalesInvoicePaymentReportModel>
            {
                MdiParent = parent,
                Text = @"Due Invoices Report",
                Report = new DueInvoicesReport(),
                Parameters = new Dictionary<string, ReportParameter>{
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
                        "FromDueDate", new ReportParameter
                        {
                            Label = "Due Date From",
                            Control = new dCalendar
                            {
                                ValidationRules = new[] {new ComponentValidationRule(EnumComponentValidationRule.Mandatory), }
                            },
                            DefaultValue = new DateTime(now.Year, now.Month, 1)
                        }
                    },
                    {
                        "ToDueDate", new ReportParameter
                        {
                            Label = "Due Date To",
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
                        var list = repo.GetReport<SalesInvoicePaymentReportModel>(
                            BaseControl.BranchId,
                            null,
                            null,
                            parameters["AsOfDate"].Value as DateTime?,
                            parameters["FromDueDate"].Value as DateTime?,
                            parameters["ToDueDate"].Value as DateTime?,
                            parameters["CustomerIdFrom"].Value as int?,
                            parameters["CustomerIdTo"].Value as int?,
                            "due"
                            );

                        return list;
                    }
                },
                OnLoad = (report, parameters) =>
                {
                    // ReSharper disable once ConvertToLambdaExpression
                    ((DueInvoicesReport)report).SetDetailVisibility((bool) parameters["ShowDetail"].Value);
                },
            };

            BaseControl.OpenForm(form, GetType());
        }
    }
}