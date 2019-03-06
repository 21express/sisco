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
    public class PaidMCCommand : IMenuInvoker
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
                Text = @"Marketing Commission - Paid MC",
                Report = new PaidMCReport(),
                Parameters = new Dictionary<string, ReportParameter>
                {
                    {
                        "FromDate", new ReportParameter
                        {
                            Label = "From Date",
                            Control = new dCalendar(),
                            DefaultValue = new DateTime(now.Year, 1, 1)
                        }
                    },
                    {
                        "ToDate", new ReportParameter
                        {
                            Label = "To Date",
                            Control = new dCalendar(),
                            DefaultValue = new DateTime(now.Year, now.Month, now.Day, 0, 0 ,0 ,0)
                        }
                    },
                    {
                        "AsOfDate", new ReportParameter
                        {
                            Label = "As Of Date",
                            Control = new dCalendar(),
                            DefaultValue = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59, 59)
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
                    var from = (DateTime)parameters["FromDate"].Value;
                    var to = (DateTime)parameters["ToDate"].Value;
                    var asofDate = (DateTime)parameters["AsOfDate"].Value;
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
                        var tdate = new DateTime(to.Year, to.Month, to.Day, 23, 59, 59);
                        param.Add(WhereTerm.Default(tdate, "date_process", EnumSqlOperator.LesThanEqual));
                    }

                    /*if (customerFrom != null)
                    {
                        var customer =
                            new CustomerDataManager().GetFirst<CustomerModel>(WhereTerm.Default((int)customerFrom, "id",
                                EnumSqlOperator.Equals));

                        if (customer != null)
                            param.Add(WhereTerm.Default(customer.Name, "customer_name", EnumSqlOperator.GreatThanEqual));
                    }

                    if (customerTo != null)
                    {
                        var customer = new CustomerDataManager().GetFirst<CustomerModel>(WhereTerm.Default((int)customerTo, "id",
                                EnumSqlOperator.Equals));

                        if (customer != null)
                            param.Add(WhereTerm.Default(customer.Name, "customer_name", EnumSqlOperator.LesThanEqual));
                    }*/

                    // ReSharper disable once CoVariantArrayConversion
                    var ds = new PaymentInRepository().PaidMc(param.ToArray(), asofDate);

                    return ds.OrderBy(c => c.DateProcess);
                }
            };

            BaseControl.OpenForm(form, GetType());
        }
    }
}