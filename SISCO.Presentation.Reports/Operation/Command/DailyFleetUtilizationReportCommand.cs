using System;
using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using System.Windows.Forms;
using SISCO.Presentation.MasterData.Popup;
using SISCO.Presentation.Reports.Administration.Forms;
using SISCO.Presentation.Reports.Operation.Forms;
using SISCO.Repositories;

namespace SISCO.Presentation.Reports.Operation.Command
{
    public class DailyFleetUtilizationReportCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var now = DateTime.Now;

            var form = new ReportGenericFilterForm<DailyFleetUtilizationReport.DailyFleetUtilizationReportDataRow>
            {
                MdiParent = parent,
                Text = @"Fleet Utilization Report (Daily)",
                Report = new DailyFleetUtilizationReport(),
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
                        "BranchId", new ReportParameter
                        {
                            Label = "Branch",
                            Control = new dLookup
                            {
                                LookupPopup = new BranchPopup(),
                                AutoCompleteDataManager = new BranchDataManager(),
                                AutoCompleteDisplayFormater = row => string.Format("{0} - {1}", ((BranchModel)row).Code, ((BranchModel)row).Name),
                                AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("code.Equals(@0) or name.StartsWith(@0)", s),
                                ValidationRules = new[] {new ComponentValidationRule(EnumComponentValidationRule.Mandatory)}
                            },
                            DefaultValue = BaseControl.BranchId
                        }
                    },
                    {
                        "FleetId", new ReportParameter
                        {
                            Label = "Fleet",
                            Control = new dLookup
                            {
                                LookupPopup = new FleetPopup(),
                                AutoCompleteDataManager = new FleetDataManager(),
                                AutoCompleteDisplayFormater = row => string.Format("{0}", ((FleetModel)row).PlateNumber),
                                AutoCompleteWheretermFormater = s => new IListParameter[] {WhereTerm.Default(s, "plate_number", EnumSqlOperator.BeginWith)}
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
                        return repo.GetFleetUtilizationReport<DailyFleetUtilizationReport.DailyFleetUtilizationReportDataRow>(
                            (int) parameters["BranchId"].Value,
                            parameters["FromDate"].Value as DateTime?,
                            parameters["ToDate"].Value as DateTime?,
                            parameters["FleetId"].Value as int?);
                    }
                },
                OnLoad = (report, parameters) =>
                {
                    // ReSharper disable once ConvertToLambdaExpression
                    ((DailyFleetUtilizationReport)report).SetDetailVisibility((bool)parameters["ShowDetail"].Value);
                },
            };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
