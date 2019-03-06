using System;
using System.Collections.Generic;
using System.Linq;
using SISCO.App.Marketing;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using System.Windows.Forms;
using SISCO.Presentation.MasterData.Popup;
using SISCO.Presentation.Reports.Operation.Forms;
using SISCO.Repositories;

namespace SISCO.Presentation.Reports.Operation.Command
{
    public class ResponseTimeReportCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var now = DateTime.Now;

            var form = new ReportGenericFilterForm<ResponseTimeReport.ResponseTimeReportDataRow>
            {
                MdiParent = parent,
                Text = @"Response Time Report",
                Report = new ResponseTimeReport(),
                Parameters = new Dictionary<string, ReportParameter>{
                    {
                        "FromDate", new ReportParameter
                        {
                            Label = "From Date",
                            Control = new dCalendar(),
                            DefaultValue = now.AddDays(-7)
                        }
                    },
                    {
                        "ToDate", new ReportParameter
                        {
                            Label = "To Date",
                            Control = new dCalendar(),
                            DefaultValue = now
                        }
                    },
                    {
                        "EmployeeId", new ReportParameter
                        {
                            Label = "Employee",
                            Control = new dLookup
                            {
                                LookupPopup = new EmployeePopup(),
                                AutoCompleteDataManager = new EmployeeDataManager(),
                                AutoCompleteDisplayFormater = row => string.Format("{0} - {1}", ((EmployeeModel)row).Code, ((EmployeeModel)row).Name),
                                AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("(code = @0 or name.StartsWith(@0)) AND branch_id = @1", s, BaseControl.BranchId)
                            }
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
                    using (var repo = new ShipmentRepository())
                    {
                        if (((DateTime)parameters["ToDate"].Value).Subtract((DateTime)parameters["FromDate"].Value).Days >
                        7)
                        {
                            MessageBox.Show(@"Tidak bisa lebih dari 7 hari");
                            return null;
                        }
                        else
                        {
                            return repo.GetResponseTimeSummary<ResponseTimeReport.ResponseTimeReportDataRow>(
                            BaseControl.BranchId,
                            parameters["FromDate"].Value as DateTime?,
                            parameters["ToDate"].Value as DateTime?,
                            parameters["EmployeeId"].Value as int?);
                        }
                    }
                },
                OnLoad = (report, parameters) =>
                {
                    // ReSharper disable once ConvertToLambdaExpression
                    ((ResponseTimeReport)report).SetDetailVisibility((bool)parameters["ShowDetail"].Value);
                },
            };

            BaseControl.OpenForm(form, GetType());
        }
    }
}
