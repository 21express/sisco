using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
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
    public class MissedPickupReportCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var now = DateTime.Now;

            var form = new ReportGenericFilterForm<PickupOrderSummary>
            {
                MdiParent = parent,
                Text = @"Missed Pickup Report",
                Report = new MissedPickupReport(),
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
                        "CustomerId", new ReportParameter
                        {
                            Label = "Customer",
                            Control = new dLookup
                            {
                                LookupPopup = new CustomerPopup(),
                                AutoCompleteDataManager = new CustomerDataManager(),
                                AutoCompleteDisplayFormater = row => string.Format("{0} - {1}", ((CustomerModel)row).Code, ((CustomerModel)row).Name),
                                AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("(code = @0 or name.StartsWith(@0)) AND branch_id = @1", s, BaseControl.BranchId)
                            }
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
                        "MessengerId", new ReportParameter
                        {
                            Label = "Messenger",
                            Control = new dLookup
                            {
                                LookupPopup = new EmployeePopup(EmployeeModel.EmployeeType.Messenger),
                                AutoCompleteDataManager = new EmployeeDataManager(),
                                AutoCompleteDisplayFormater = row => string.Format("{0} - {1}", ((EmployeeModel)row).Code, ((EmployeeModel)row).Name),
                                AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("(code = @0 or name.StartsWith(@0)) AND as_messenger AND branch_id = @1", s, BaseControl.BranchId)
                            }
                        }
                    },
                },
                DataSourceFunc = parameters =>
                {
                    using (var repo = new PickupOrderRepository())
                    {
                        return repo.GetMissedPickupList<PickupOrderSummary>(
                            parameters["FromDate"].Value as DateTime?,
                            parameters["ToDate"].Value as DateTime?,
                            parameters["CustomerId"].Value as int?,
                            parameters["BranchId"].Value as int?,
                            parameters["MessengerId"].Value as int?);
                    }
                }
            };
            BaseControl.OpenForm(form, GetType());
        }

        public class PickupOrderSummary
        {
            public DateTime date_process { get; set; }
            public string branch { get; set; }
            public string messenger_code { get; set; }
            public string customer_name { get; set; }
            public int pu_order_count { get; set; }
            public int pu_count { get; set; }
            public int missed_count { get; set; }
            public decimal pickup_percent { get; set; }
            public decimal missed_percent { get; set; }
        }
    }
}
