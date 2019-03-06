using System;
using System.Collections.Generic;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using System.Windows.Forms;
using SISCO.Presentation.MasterData.Popup;
using SISCO.Presentation.Reports.CustomerService.Forms;
using SISCO.Repositories;

namespace SISCO.Presentation.Reports.CustomerService.Command
{
    public class ShipmentStatusSummaryReportCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var now = DateTime.Now;

            var form = new ReportGenericFilterForm<ShipmentStatusSummaryReport.ShipmentStatusSummary>
            {
                MdiParent = parent,
                Text = @"Shipment Final Status Summary Report",
                Report = new ShipmentStatusSummaryReport(),
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
                                AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("code = @0 or name.StartsWith(@0)", s)
                            },
                            DefaultValue = BaseControl.BranchId
                        }
                    },
                },
                DataSourceFunc = parameters =>
                {
                    using (var repo = new ShipmentRepository())
                    {
                        return repo.GetShipmentFinalStatusSummary<ShipmentStatusSummaryReport.ShipmentStatusSummary>(
                            parameters["FromDate"].Value as DateTime?,
                            parameters["ToDate"].Value as DateTime?,
                            parameters["BranchId"].Value as int?);
                    }
                }
            };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
