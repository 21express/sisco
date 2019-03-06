using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using SISCO.App.Finance;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;
using SISCO.Presentation.Reports.MarketingCommission.Forms;

namespace SISCO.Presentation.Reports.MarketingCommission.Command
{
    // ReSharper disable once InconsistentNaming
    public class MCJournalCommand : IMenuInvoker
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
                Text = @"Marketing Commission - Journal (Marketing)",
                Report = new MCJournalReport(),
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
                        "MarketingFrom", new ReportParameter
                        {
                            Label = "Marketing From",
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
                        "MarketingTo", new ReportParameter
                        {
                            Label = "Marketing To",
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
                        "Summary", new ReportParameter
                        {
                            Label = "Summary",
                            Control = new CheckBox()
                        }
                    }
                },
                DataSourceFunc = parameters =>
                {
                    var dateNull = new DateTime(1900, 1, 1, 0, 0, 0);
                    var param = new List<WhereTerm>();
                    var from = (DateTime)parameters["FromDate"].Value;
                    var to = (DateTime)parameters["ToDate"].Value;
                    var marketingFrom = (int?)parameters["MarketingFrom"].Value;
                    var marketingTo = (int?)parameters["MarketingTo"].Value;

                    param.Add(WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals));

                    if (from > dateNull)
                    {
                        var fdate = new DateTime(from.Year, from.Month, from.Day, 0, 0, 0);
                        param.Add(WhereTerm.Default(fdate, "date_process", EnumSqlOperator.GreatThanEqual));
                    }

                    if (to > dateNull)
                    {
                        var tdate = new DateTime(to.Year, to.Month, to.Day, 0, 0, 0);
                        param.Add(WhereTerm.Default(tdate, "date_process", EnumSqlOperator.LesThanEqual));
                    }

                    if (marketingFrom != null)
                    {
                        param.Add(WhereTerm.Default((int)marketingFrom, "marketing_id", EnumSqlOperator.GreatThanEqual));
                    }

                    if (marketingTo != null)
                    {
                        param.Add(WhereTerm.Default((int)marketingTo, "marketing_id", EnumSqlOperator.LesThanEqual));
                    }

                    // ReSharper disable once CoVariantArrayConversion
                    var ds = new PaymentInDataManager().Get<PaymentInModel>(param.ToArray());

                    return ds.OrderBy(c => c.DateProcess);
                }
            };

            BaseControl.OpenForm(form, GetType());
        }
    }
}