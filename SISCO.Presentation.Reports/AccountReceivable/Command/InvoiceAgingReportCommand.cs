using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.Utils.OAuth;
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
    public class InvoiceAgingReportCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var now = DateTime.Now;
            var form = new ReportGenericFilterForm<SalesInvoiceModel>
            {
                MdiParent = parent,
                Text = @"Aging Report",
                Report = new InvoiceAgingReport(),
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
                        "DueDateBy", new ReportParameter
                        {
                            Label = "Due Date By",
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
                                AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("code = @0 or name.StartsWith(@0)", s)
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
                                AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("code = @0 or name.StartsWith(@0)", s)
                            },
                        }
                    },
                    {
                        "Summary", new ReportParameter
                        {
                            Label = "Summary",
                            Control = new dCheckBox()
                        }
                    }
                },
                DataSourceFunc = parameters =>
                {
                    var whereTerms = new List<IListParameter>();

                    whereTerms.Add(WhereTerm.Default(BaseControl.BranchId, "branch_id"));
                    whereTerms.Add(WhereTerm.Default(false, "paid"));
                    whereTerms.Add(WhereTerm.Default(Convert.ToDateTime(parameters["AsOfDate"].Value).Date, "vdate", EnumSqlOperator.LesThanEqual));
                    whereTerms.Add(WhereTerm.Default(Convert.ToDateTime(parameters["DueDateBy"].Value).Date, "due_date", EnumSqlOperator.LesThanEqual));

                    if (parameters["CustomerIdFrom"].Value != null)
                    {
                        whereTerms.Add(WhereTerm.Default((int) parameters["CustomerIdFrom"].Value, "company_id",
                            EnumSqlOperator.GreatThanEqual));
                    }
                    if (parameters["CustomerIdTo"].Value != null)
                    {
                        whereTerms.Add(WhereTerm.Default((int)parameters["CustomerIdTo"].Value, "company_id",
                            EnumSqlOperator.LesThanEqual));
                    }

                    using (var repo = new SalesInvoiceRepository())
                    {
                        var list = repo.Get<SalesInvoiceModel>(whereTerms.ToArray());

                        return list;
                    }
                },
            };

            BaseControl.OpenForm(form, GetType());
        }
    }
}