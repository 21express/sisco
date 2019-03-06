using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;
using SISCO.Presentation.Reports.MarketingCommission.Forms;
using SISCO.Repositories;

namespace SISCO.Presentation.Reports.MarketingCommission.Command
{
    // ReSharper disable once InconsistentNaming
    public class OutstandingMCCommand : IMenuInvoker
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
                Text = @"Marketing Commission - Outstanding MC",
                Report = new OutstandingMCReport(),
                Parameters = new Dictionary<string, ReportParameter>
                {
                    {
                        "AsOfDate", new ReportParameter
                        {
                            Label = "As Of Date",
                            Control = new dCalendar(),
                            DefaultValue = new DateTime(now.Year, now.Month, now.Day)
                        }
                    },
                    {
                        "MarketingId", new ReportParameter
                        {
                            Label = "Marketing",
                            Control = new dLookup
                            {
                                LookupPopup = new EmployeePopup(EmployeeModel.EmployeeType.Marketing),
                                AutoCompleteDataManager = new EmployeeDataManager(),
                                AutoCompleteDisplayFormater =
                                    row => ((EmployeeModel) row).Code + " " + ((EmployeeModel) row).Name,
                                AutoCompleteWhereExpression =
                                    (s, p) => p.SetWhereExpression("(code.StartsWith(@0) OR name.StartsWith(@0)) AND as_marketing AND branch_id = @1", s, BaseControl.BranchId)
                            }
                        }
                    },
                    {
                        "Detail", new ReportParameter
                        {
                            Label = "Detail",
                            Control = new CheckBox()
                        }
                    }
                },
                DataSourceFunc = parameters =>
                {
                    var dateNull = new DateTime(1900, 1, 1, 0, 0, 0);
                    var param = new List<WhereTerm>();
                    var asofDate = (DateTime)parameters["AsOfDate"].Value;
                    var marketingId = (int?)parameters["MarketingId"].Value;

                    param.Add(WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals));

                    if (asofDate > dateNull)
                    {
                        var fdate = new DateTime(asofDate.Year, asofDate.Month, asofDate.Day, 23, 59, 59);
                        param.Add(WhereTerm.Default(fdate, "date_process", EnumSqlOperator.LesThanEqual));
                    }

                    if (marketingId != null)
                    {
                        param.Add(WhereTerm.Default((int)marketingId, "marketing_id", EnumSqlOperator.Equals));
                    }

                    // ReSharper disable once CoVariantArrayConversion
                    var ds = new PaymentInRepository().OutstandingMc(param.ToArray(), asofDate);

                    return ds.OrderBy(c => c.DateProcess);
                }
            };

            BaseControl.OpenForm(form, GetType());
        }
    }
}