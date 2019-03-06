using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;
using SISCO.Presentation.Reports.Finance.Forms;
using SISCO.Repositories;
using System;
using System.Collections.Generic;

namespace SISCO.Presentation.Reports.Finance.Command
{
    public class PettyCashCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(System.Windows.Forms.Form parent)
        {
            var now = DateTime.Now;
            var form = new ReportGenericFilterForm<object>
            {
                MdiParent = parent,
                Text = @"Finance - Petty Cash",
                Report = new PettyCashReport(),
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
                        "Employee", new ReportParameter
                        {
                            Label = "Employee",
                            Control = new dLookup
                            {
                                LookupPopup = new EmployeePopup(),
                                AutoCompleteDataManager = new EmployeeDataManager(),
                                AutoCompleteDisplayFormater =
                                    row => string.Format("{0} {1}", ((EmployeeModel) row).Code, ((EmployeeModel) row).Name),
                                AutoCompleteWhereExpression =
                                    (s, p) => p.SetWhereExpression("(code = @0 or name.StartsWith(@0)) and branch_id = @1", s, BaseControl.BranchId)
                            }
                        }
                    },
                },
                DataSourceFunc = parameters =>
                {
                    var dateNull = new DateTime(1900, 1, 1, 0, 0, 0);
                    var from = (DateTime)parameters["FromDate"].Value;
                    var to = (DateTime)parameters["ToDate"].Value;
                    var employee = (int?)parameters["Employee"].Value;

                    return new PettyCashRepository().GetEmployeeTransactional(BaseControl.BranchId, from, to, employee);
                }
            };

            BaseControl.OpenForm(form, GetType());
        }
    }
}
