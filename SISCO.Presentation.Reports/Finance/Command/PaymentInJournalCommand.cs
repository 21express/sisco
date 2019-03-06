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
using SISCO.Presentation.Reports.Finance.Forms;

namespace SISCO.Presentation.Reports.Finance.Command
{
    public class PaymentInJournalCommand : IMenuInvoker
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
                Text = @"Finance - Payment In Journal",
                Report = new PaymentInJournalReport(),
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
                        "CustomerFrom", new ReportParameter
                        {
                            Label = "Customer From",
                            Control = new dLookup
                            {
                                LookupPopup = new CustomerPopup(),
                                AutoCompleteDataManager = new CustomerDataManager(),
                                AutoCompleteDisplayFormater =
                                    row => string.Format("{0} {1}", ((CustomerModel) row).Code, ((CustomerModel) row).Name),
                                AutoCompleteWhereExpression =
                                    (s, p) => p.SetWhereExpression("(code.StartsWith(@0) OR name.StartsWith(@0)) AND branch_id = @1", s, BaseControl.BranchId)
                            }
                        }
                    },
                    {
                        "CustomerTo", new ReportParameter
                        {
                            Label = "Customer To",
                            Control = new dLookup
                            {
                                LookupPopup = new CustomerPopup(),
                                AutoCompleteDataManager = new CustomerDataManager(),
                                AutoCompleteDisplayFormater =
                                    row => string.Format("{0} {1}", ((CustomerModel) row).Code, ((CustomerModel) row).Name),
                                AutoCompleteWhereExpression =
                                    (s, p) => p.SetWhereExpression("(code.StartsWith(@0) OR name.StartsWith(@0)) AND branch_id = @1", s, BaseControl.BranchId)
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
                    var CustomerFrom = (int?)parameters["CustomerFrom"].Value;
                    var CustomerTo = (int?)parameters["CustomerTo"].Value;

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

                    if (CustomerFrom != null)
                    {
                        param.Add(WhereTerm.Default((int) CustomerFrom, "customer_id", EnumSqlOperator.GreatThanEqual));
                    }

                    if (CustomerTo != null)
                    {
                        param.Add(WhereTerm.Default((int)CustomerTo, "customer_id", EnumSqlOperator.LesThanEqual));
                    }

                    var ds = new List<PaymentInJournal>();

                    // ReSharper disable once CoVariantArrayConversion
                    var paymentin = new PaymentInDataManager().Get<PaymentInModel>(param.ToArray());
                    // ReSharper disable PossibleMultipleEnumeration
                    if (paymentin != null && paymentin.Any())
                    {
                        ds.AddRange(paymentin.Select(obj => new PaymentInJournal
                        {
                            Code = obj.Code, PaymentType = obj.PaymentType, DateProcces = obj.DateProcess, Description = obj.Description, Company = obj.CustomerName, Total = obj.Total
                        }));
                    }
                    // ReSharper restore PossibleMultipleEnumeration
                    
                    if (param.Count() > 3) param.RemoveAt(3);
                    if (param.Count() > 3) param.RemoveAt(3);

                    // ReSharper disable once CoVariantArrayConversion
                    var paymentcounter = new PaymentInCounterDataManager().Get<PaymentInCounterModel>(param.ToArray());
                    // ReSharper disable PossibleMultipleEnumeration
                    if (paymentcounter != null && paymentcounter.Any())

                    {
                        ds.AddRange(paymentcounter.Select(obj => new PaymentInJournal
                        {
                            Code = obj.Code, PaymentType = "CASH", DateProcces = obj.DateProcess, Description = "COUNTER", Company = "Not Available", Total = obj.Total
                        }));
                    }
                    // ReSharper restore PossibleMultipleEnumeration

                    // ReSharper disable once CoVariantArrayConversion
                    var paymentincollectin = new PaymentInCollectInDataManager().Get<PaymentInCollectInModel>(param.ToArray());
                    // ReSharper disable PossibleMultipleEnumeration
                    if (paymentincollectin != null && paymentincollectin.Any())
                    {
                        ds.AddRange(paymentincollectin.Select(obj => new PaymentInJournal
                        {
                            Code = obj.Code, PaymentType = obj.PaymentType, DateProcces = obj.DateProcess, Description = obj.Description, Company = "Not Available", Total = obj.Total
                        }));
                    }
                    // ReSharper restore PossibleMultipleEnumeration

                    param[0] = WhereTerm.Default(BaseControl.BranchId, "owner_branch_id", EnumSqlOperator.Equals);
                    // ReSharper disable once CoVariantArrayConversion
                    var paymentincollectout = new PaymentInCollectOutDataManager().Get<PaymentInCollectOutModel>(param.ToArray());
                    // ReSharper disable PossibleMultipleEnumeration
                    if (paymentincollectout != null && paymentincollectout.Any())
                    {
                        ds.AddRange(paymentincollectout.Select(obj => new PaymentInJournal
                        {
                            Code = obj.Code,
                            PaymentType = obj.PaymentType,
                            DateProcces = obj.DateProcess,
                            Description = obj.Description,
                            Company = obj.BranchId == 0 ? "Undefined" : new BranchDataManager().GetFirst<BranchModel>(WhereTerm.Default(obj.BranchId, "id", EnumSqlOperator.Equals)).Name, 
                            Total = obj.Total
                        }));   
                    }
                    // ReSharper restore PossibleMultipleEnumeration

                    return ds.OrderBy(c => c.DateProcces);
                }
            };

            BaseControl.OpenForm(form, GetType());
        }
    }
}