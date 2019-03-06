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
    public class SalesJournalDestinationReportCommand : IMenuInvoker
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
                Text = @"Sales Journal (Destination)",
                Report = new SalesJournalDestinationReport(),
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
                        "DestinationCityFrom", new ReportParameter
                        {
                            Label = "City From",
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
                        "DestinationCityTo", new ReportParameter
                        {
                            Label = "City To",
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
                        return repo.ReportSalesJournal<ReportSalesJournal>(
                            BaseControl.BranchId,
                            parameters["FromDate"].Value as DateTime?, parameters["ToDate"].Value as DateTime?,
                            null, null,
                            null, null,
                            null, null,
                            parameters["DestinationCityFrom"].Value as int?, parameters["DestinationCityTo"].Value as int?,
                            null, null);
                    }
                }
            };

            BaseControl.OpenForm(form, GetType());
        }
    }
}