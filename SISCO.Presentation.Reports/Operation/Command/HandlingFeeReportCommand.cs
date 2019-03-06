using System;
using System.Collections.Generic;
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
    public class HandlingFeeReportCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var now = DateTime.Now;

            var form = new ReportGenericFilterForm<ShipmentModel>
            {
                MdiParent = parent,
                Text = @"Handling Fee Report",
                Report = new HandlingFeeReport(),
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
                        return repo.GetHandlingFeeReport<ShipmentModel>(
                            BaseControl.BranchId,
                            parameters["FromDate"].Value as DateTime?,
                            parameters["ToDate"].Value as DateTime?,
                            parameters["OriginCityId"].Value as int?,
                            parameters["DestCityId"].Value as int?);
                    }
                },
                OnLoad = (report, parameters) =>
                {
                    // ReSharper disable once ConvertToLambdaExpression
                    ((HandlingFeeReport)report).SetDetailVisibility((bool) parameters["ShowDetail"].Value);
                },
            };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
