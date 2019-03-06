using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;
using SISCO.Presentation.Reports.Finance.Forms;
using SISCO.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SISCO.Presentation.Reports.Finance.Command
{
    public class ClaimCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(System.Windows.Forms.Form parent)
        {
            var now = DateTime.Now;
            var form = new ReportGenericFilterForm<object>
            {
                MdiParent = parent,
                Text = @"Finance - Petty Cash",
                Report = new SISCO.Presentation.Reports.Finance.Forms.ClaimReport(),
                Parameters = new Dictionary<string, ReportParameter>
                {
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
                        "CustomerBranch", new ReportParameter
                        {
                            Label = "Customer Cabang",
                            Control = new dLookup
                            {
                                LookupPopup = new BranchPopup(),
                                AutoCompleteDataManager = new BranchDataManager(),
                                AutoCompleteDisplayFormater =
                                    row => string.Format("{0} {1}", ((BranchModel) row).Code, ((BranchModel) row).Name),
                                AutoCompleteWhereExpression =
                                    (s, p) => p.SetWhereExpression("(code = @0 or name.StartsWith(@0))", s)
                            }
                        }
                    },
                },
                DataSourceFunc = parameters =>
                {
                    var dateNull = new DateTime(1900, 1, 1, 0, 0, 0);
                    var from = (DateTime)parameters["FromDate"].Value;
                    var to = (DateTime)parameters["ToDate"].Value;
                    var customerBranch = (int?)parameters["CustomerBranch"].Value;

                    return new ClaimedRepository().GetClaimReport(BaseControl.BranchId, from, to, customerBranch);
                }
            };

            BaseControl.OpenForm(form, GetType());
        }
    }
}
