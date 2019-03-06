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
using SISCO.Presentation.Reports.CustomerService.Forms;
using SISCO.Repositories;

namespace SISCO.Presentation.Reports.Administration.Command
{
    public class PodAgingReportCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var now = DateTime.Now;

            var form = new ReportGenericFilterForm<PodAgingReport.AgingReportDataRow>
            {
                MdiParent = parent,
                Text = @"POD Aging Report",
                Report = new PodAgingReport(),
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
                                AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("code = @0 or name.StartsWith(@0)", s),
                                Enabled = false
                            },
                            DefaultValue = BaseControl.BranchId
                        }
                    },
                    {
                        "CustomerId", new ReportParameter
                        {
                            Label = "Customer",
                            Control = new dLookup
                            {
                                LookupPopup = new CustomerPopup(),
                                AutoCompleteDataManager = new CustomerDataManager(),
                                AutoCompleteDisplayFormater = row => string.Format("{0} - {1}", ((CustomerModel)row).Code, ((CustomerModel)row).Name),
                                AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("(code = @0 or name.StartsWith(@0)) and branch_id = @1", s, BaseControl.BranchId)
                            }
                        }
                    },
                    {
                        "DestCityId", new ReportParameter
                        {
                            Label = "Destination City",
                            Control = new dLookup
                            {
                                LookupPopup = new CityPopup(),
                                AutoCompleteDataManager = new CityDataManager(),
                                AutoCompleteDisplayFormater = row => string.Format("{0}", ((CityModel)row).Name),
                                AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("name.StartsWith(@0)", s)
                            }
                        }
                    },
                },
                DataSourceFunc = parameters =>
                {
                    using (var repo = new ShipmentRepository())
                    {
                        return repo.GetAgingSummary<PodAgingReport.AgingReportDataRow>(
                            parameters["FromDate"].Value as DateTime?,
                            parameters["ToDate"].Value as DateTime?,
                            parameters["BranchId"].Value as int?,
                            parameters["CustomerId"].Value as int?,
                            parameters["DestCityId"].Value as int?);
                    }
                }
            };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
