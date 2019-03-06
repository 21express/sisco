using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;
using SISCO.Presentation.Reports.CustomerService.Forms;
using SISCO.Repositories;

namespace SISCO.Presentation.Reports.CustomerService.Command
{
    public class ComplaintReportCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var now = DateTime.Now;

            var form = new ReportGenericFilterForm<ComplaintReport.ComplaintSummary>
            {
                MdiParent = parent,
                Text = @"Complaint Report",
                Report = new ComplaintReport(),
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
                        "OriginCityId", new ReportParameter
                        {
                            Label = "Origin City",
                            Control = new dLookup
                            {
                                LookupPopup = new CityPopup(),
                                AutoCompleteDataManager = new CityDataManager(),
                                AutoCompleteDisplayFormater = row => string.Format("{0}", ((CityModel)row).Name),
                                AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("name.StartsWith(@0)", s)
                            }
                        }
                    },
                    {
                        "DestinationCityId", new ReportParameter
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
                    using (var repo = new ComplaintRepository())
                    {
                        return repo.GetComplaintSummary<ComplaintReport.ComplaintSummary>(
                            parameters["FromDate"].Value as DateTime?,
                            parameters["ToDate"].Value as DateTime?,
                            parameters["BranchId"].Value as int?,
                            parameters["OriginCityId"].Value as int?,
                            parameters["DestinationCityId"].Value as int?);
                    }
                }
            };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
