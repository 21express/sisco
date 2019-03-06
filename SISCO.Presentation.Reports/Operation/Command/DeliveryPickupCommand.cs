using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Reports.Operation.Forms;
using SISCO.Repositories;
using SISCO.Presentation.MasterData.Popup;
using SISCO.App.MasterData;
using SISCO.Models;

namespace SISCO.Presentation.Reports.Operation.Command
{
    public class DeliveryPickupCommand : IMenuInvoker
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
                Text = @"Laporan Delivery & Pickup Kurir",
                Report = new DeliveryPickupReport(),
                Parameters = new Dictionary<string, ReportParameter>{
                    {
                        "FromDate", new ReportParameter
                        {
                            Label = "From Date",
                            Control = new dCalendar(),
                            DefaultValue = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0, 0)
                        }
                    },
                    {
                        "ToDate", new ReportParameter
                        {
                            Label = "To Date",
                            Control = new dCalendar(),
                            DefaultValue = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59, 59)
                        }
                    },
                    {
                        "Messenger", new ReportParameter
                        {
                            Label = "Messenger",
                            Control = new dLookup
                            {
                                LookupPopup = new MessengerPopup(),
                                AutoCompleteDataManager = new EmployeeDataManager(),
                                AutoCompleteDisplayFormater = row => ((EmployeeModel)row).Code + " - " + ((EmployeeModel)row).Name,
                                AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND as_messenger AND branch_id = @1", s, BaseControl.BranchId)
                            }
                        }
                    }
                },
                DataSourceFunc = parameters =>
                {
                    using (var repo = new DeliveryOrderRepository())
                    {
                        var from = (DateTime)parameters["FromDate"].Value;
                        var to = (DateTime)parameters["ToDate"].Value;

                        // ReSharper disable once CoVariantArrayConversion
                        return repo.GetDeliveryPickupReport(new DateTime(from.Year, from.Month, from.Day, 0, 0, 0), new DateTime(to.Year, to.Month, to.Day, 23, 59, 59),
                            BaseControl.BranchId, parameters["Messenger"].Value as int?);
                    }
                }
            };

            BaseControl.OpenForm(form, GetType());
        }
    }
}