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
    public class MonthlyServiceSalesChartReportCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var now = DateTime.Now;

            var form = new ReportGenericFilterForm<MonthlyServiceSalesChartReport.MonthlyServiceTonnageChartReportDataRow>
            {
                MdiParent = parent,
                Text = @"Monthly Service Sales Chart Report",
                Report = new MonthlyServiceSalesChartReport(),
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
                                ValidationRules = new[] {new ComponentValidationRule(EnumComponentValidationRule.Mandatory)},
                                Enabled = false
                            },
                            DefaultValue = BaseControl.BranchId
                        }
                    },
                    {
                        "ShowDaily", new ReportParameter
                        {
                            Label = "Daily",
                            Control = new CheckBox(),
                        }
                    },
                    {
                        "ShowCost", new ReportParameter
                        {
                            Label = "Show Cost",
                            Control = new CheckBox(),
                        }
                    },
                    {
                        "ShowLabel", new ReportParameter
                        {
                            Label = "Show Label",
                            Control = new CheckBox(),
                        }
                    }
                },
                DataSourceFunc = parameters =>
                {
                    using (var repo = new ShipmentRepository())
                    {
                        if (parameters["ShowDaily"].Value != null && (bool)parameters["ShowDaily"].Value == true)
                        {
                            return repo.GetDailyServiceTypeSummary<MonthlyServiceSalesChartReport.MonthlyServiceTonnageChartReportDataRow>(
                                (int)parameters["BranchId"].Value,
                                parameters["FromDate"].Value as DateTime?,
                                parameters["ToDate"].Value as DateTime?);
                        }
                        else
                        {
                            return repo.GetMonthlyServiceTypeSummary<MonthlyServiceSalesChartReport.MonthlyServiceTonnageChartReportDataRow>(
                                (int)parameters["BranchId"].Value,
                                parameters["FromDate"].Value as DateTime?,
                                parameters["ToDate"].Value as DateTime?);
                        }
                    }
                },
                OnLoad = (report, parameters) =>
                {
                    // ReSharper disable once ConvertToLambdaExpression
                    ((MonthlyServiceSalesChartReport)report).SetLabelVisibility((bool)parameters["ShowLabel"].Value);

                    if ((bool)parameters["ShowCost"].Value)
                    {
                        using (var repo = new CostRepository())
                        {
                            object ds;
                            if (parameters["ShowDaily"].Value != null && (bool)parameters["ShowDaily"].Value == true)
                            {
                                ds = repo.GetDailyCostSummary<MonthlyServiceSalesChartReport.CostDataRow>(
                                    (int)parameters["BranchId"].Value,
                                    parameters["FromDate"].Value as DateTime?,
                                    parameters["ToDate"].Value as DateTime?);
                            }
                            else
                            {
                                ds = repo.GetMonthlyCostSummary<MonthlyServiceSalesChartReport.CostDataRow>(
                                    (int)parameters["BranchId"].Value,
                                    parameters["FromDate"].Value as DateTime?,
                                    parameters["ToDate"].Value as DateTime?);
                            }

                            ((MonthlyServiceSalesChartReport)report).SetCostDataSource(ds);
                        }
                    }
                }
            };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
