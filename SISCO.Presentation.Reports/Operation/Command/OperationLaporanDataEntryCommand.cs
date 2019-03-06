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
using SISCO.Presentation.Reports.Operation.Forms;
using SISCO.Repositories;

namespace SISCO.Presentation.Reports.Operation.Command
{
    public class OperationLaporanDataEntryCommand : IMenuInvoker
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
                Text = @"Laporan Data Entry",
                Report = new LaporanDataEntryReport(),
                Parameters = new Dictionary<string, ReportParameter>{
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
                        "EmployeeFrom", new ReportParameter
                        {
                            Label = "Employee From",
                            Control = new dLookup
                            {
                                LookupPopup = new EmployeePopup(),
                                AutoCompleteDataManager = new EmployeeDataManager(),
                                AutoCompleteDisplayFormater = row => string.Format("{0} {1}", ((EmployeeModel)row).Code, ((EmployeeModel)row).Name),
                                AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("(code.StartsWith(@0) OR name.StartsWith(@0)) AND branch_id = @1", s, BaseControl.BranchId)
                            }
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
                                AutoCompleteDisplayFormater = row => string.Format("{0} {1}", ((EmployeeModel)row).Code, ((EmployeeModel)row).Name),
                                AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("(code.StartsWith(@0) OR name.StartsWith(@0)) AND branch_id = @1", s, BaseControl.BranchId)
                            }
                        }
                    },
                    {
                        "Summary", new ReportParameter
                        {
                            Label = "Detail",
                            Control = new CheckBox()
                        }
                    }
                },
                DataSourceFunc = parameters =>
                {
                    using (var repo = new ShipmentRepository())
                    {
                        var dateNull = new DateTime(1900, 1, 1, 0, 0, 0);
                        var from = (DateTime)parameters["FromDate"].Value;
                        var to = (DateTime)parameters["ToDate"].Value;
                        var employeFrom = parameters["EmployeeFrom"].Value != null ? (int)parameters["EmployeeFrom"].Value : 0;
                        var employeTo = parameters["EmployeeTo"].Value != null ? (int)parameters["EmployeeTo"].Value : 0;

                        DateTime? fdate = null;
                        DateTime? tdate = null;
                        string eFrom = string.Empty;
                        string eTo = string.Empty;

                        if (from > dateNull)
                        {
                            fdate = new DateTime(from.Year, from.Month, from.Day, 0, 0, 0);
                        }

                        if (to > dateNull)
                        {
                            tdate = new DateTime(to.Year, to.Month, to.Day, 23, 59, 59);
                        }

                        if (employeFrom > 0)
                        {
                            eFrom = new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default(employeFrom, "id", EnumSqlOperator.Equals)).Code;
                        }

                        if (employeTo > 0)
                        {
                            eTo = new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default(employeTo, "id", EnumSqlOperator.Equals)).Code;
                        }

                        return repo.DataEntryReport(BaseControl.BranchId, fdate, tdate, eFrom, eTo);
                    }
                }
            };

            BaseControl.OpenForm(form, GetType());
        }
    }
}