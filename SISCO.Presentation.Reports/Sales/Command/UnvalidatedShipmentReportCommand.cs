using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;
using SISCO.Presentation.Reports.Sales.Forms;
using SISCO.Repositories;
using Devenlab.Common.Interfaces;
using Devenlab.Common;

namespace SISCO.Presentation.Reports.Sales.Command
{
    public class UnvalidatedShipmentReportCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var now = DateTime.Now;
            var form = new ReportGenericFilterForm<ReportSalesJournal>
            {
                MdiParent = parent,
                Text = @"Unvalidated Shipment",
                Report = new UnvalidatedShipmentReport(),
                Parameters = new Dictionary<string, ReportParameter>{
                    {
                        "FromDate", new ReportParameter
                        {
                            Label = "From Date",
                            Control = new dCalendar
                            {
                                ValidationRules = new[] {new ComponentValidationRule(EnumComponentValidationRule.Mandatory), }
                            },
                            DefaultValue = new DateTime(now.Year, now.Month, now.Day)
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
                            DefaultValue = new DateTime(now.Year, now.Month, now.Day)
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
                                AutoCompleteDisplayFormater = row => string.Format("{0} - {1}", ((CustomerModel)row).Code, ((CustomerModel)row).Name),
                                AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("(code = @0 or name.StartsWith(@0)) AND branch_id = @1", s, BaseControl.BranchId)
                            },
                        }
                    },
                    {
                        "PaymentMethod", new ReportParameter
                        {
                            Label = "Payment Method",
                            Control = new dLookup
                            {
                                LookupPopup = new PaymentMethodPopup(new IListParameter[] { WhereTerm.Default("CASH", "name", EnumSqlOperator.NotEqual) }),
                                AutoCompleteDataManager = new PaymentMethodDataManager(),
                                AutoCompleteDisplayFormater = model => ((PaymentMethodModel)model).Name,
                                AutoCompleteWheretermFormater = s => new IListParameter[]
                                {
                                    WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith),
                                    WhereTerm.Default("CASH", "name", EnumSqlOperator.NotEqual)
                                }
                            },
                        }
                    }
                },
                DataSourceFunc = parameters =>
                {
                    using (var repo = new ShipmentRepository())
                    {
                        var dateNull = new DateTime(1900, 1, 1, 0, 0, 0);
                        var param = new List<WhereTerm>();
                        var from = (DateTime)parameters["FromDate"].Value;
                        var to = (DateTime)parameters["ToDate"].Value;

                        param.Add(WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals));

                        if (from > dateNull)
                        {
                            from = new DateTime(from.Year, from.Month, from.Day, 0, 0, 0);
                        }

                        if (to > dateNull)
                        {
                            to = new DateTime(to.Year, to.Month, to.Day, 23, 59, 59);
                        }

                        return repo.GetUnvalidatedShipmentReport<ReportSalesJournal>(BaseControl.BranchId, from, to, parameters["Customer"].Value as int?, parameters["PaymentMethod"].Value as int?);
                    }
                }
            };

            BaseControl.OpenForm(form, GetType());
        }
    }
}