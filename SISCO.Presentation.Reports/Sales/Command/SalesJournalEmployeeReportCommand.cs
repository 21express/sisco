using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;
using SISCO.Presentation.Reports.Sales.Forms;
using SISCO.Repositories;

namespace SISCO.Presentation.Reports.Sales.Command
{
    public class SalesJournalEmployeeReportCommand : IMenuInvoker
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
                Text = @"Sales Journal (Employee)",
                Report = new SalesJournalEmployeeReport(),
                Parameters = new Dictionary<string, ReportParameter>{
                    {
                        "FromDate", new ReportParameter
                        {
                            Label = "From Date",
                            Control = new dCalendar
                            {
                                ValidationRules = new[] {new ComponentValidationRule(EnumComponentValidationRule.Mandatory), }
                            },
                            DefaultValue = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0)
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
                            DefaultValue = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59)
                        }
                    },
                    {
                        "EmployeeFrom", new ReportParameter
                        {
                            Label = "Employee From",
                            Control = new dLookup
                            {
                                LookupPopup = new EmployeePopup(),
                                AutoCompleteDataManager = new EmployeeDataManager(),
                                AutoCompleteDisplayFormater = row => string.Format("{0} - {1}", ((EmployeeModel)row).Code, ((EmployeeModel)row).Name),
                                //AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("(code = @0 or name.StartsWith(@0)) AND branch_id = @1", s, BaseControl.BranchId),
                                DefaultValue = new IListParameter[] { WhereTerm.Default(BaseControl.EmployeeId, "id", EnumSqlOperator.Equals) },
                                Value = BaseControl.EmployeeId,
                                Enabled = BaseControl.UserRole == "ADMIN"
                            },
                        }
                    },
                    {
                        "EmployeeTo", new ReportParameter
                        {
                            Label = "Employee To",
                            Control = new dLookup
                            {
                                LookupPopup = new EmployeePopup(),
                                AutoCompleteDataManager = new EmployeeDataManager(),
                                AutoCompleteDisplayFormater = row => string.Format("{0} - {1}", ((EmployeeModel)row).Code, ((EmployeeModel)row).Name),
                                //AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("(code = @0 or name.StartsWith(@0)) AND branch_id = @1", s, BaseControl.BranchId),
                                DefaultValue = new IListParameter[] { WhereTerm.Default(BaseControl.EmployeeId, "id", EnumSqlOperator.Equals) },
                                Value = BaseControl.EmployeeId,
                                Enabled = BaseControl.UserRole == "ADMIN"
                            },
                        }
                    },
                    {
                        "PaymentMethodId", new ReportParameter
                        {
                            Label = "Payment Method",
                            Control = new dLookup
                            {
                                LookupPopup = new PaymentMethodPopup(),
                                AutoCompleteDataManager = new PaymentMethodDataManager(),
                                AutoCompleteDisplayFormater = row => string.Format("{0}", ((PaymentMethodModel)row).Name),
                                AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("name.StartsWith(@0)", s),
                                ValidationRules = new[] {new ComponentValidationRule(EnumComponentValidationRule.Mandatory), }
                            },
                        }
                    }
                },
                DataSourceFunc = parameters =>
                {
                    using (var repo = new ShipmentRepository())
                    {
                        return repo.ReportSalesJournal<ReportSalesJournal>(
                            BaseControl.BranchId,
                            parameters["FromDate"].Value as DateTime?,
                            parameters["ToDate"].Value as DateTime?,
                            null, null,
                            null, null,
                            null, null,
                            null, null,
                            null, null,
                            (parameters["EmployeeFrom"].Control.Text == string.Empty ? null : parameters["EmployeeFrom"].Value) as int?,
                            (parameters["EmployeeTo"].Control.Text == string.Empty ? null : parameters["EmployeeTo"].Value) as int?,
                            parameters["PaymentMethodId"].Value as int?
                            );
                    }
                }
            };

            BaseControl.OpenForm(form, GetType());
        }
    }
}