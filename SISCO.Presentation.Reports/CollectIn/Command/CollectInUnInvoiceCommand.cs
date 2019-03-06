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
using SISCO.Presentation.Reports.CollectIn.Forms;
using SISCO.Repositories;

namespace SISCO.Presentation.Reports.CollectIn.Command
{
    public class CollectInUnInvoiceCommand : IMenuInvoker
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
                Text = @"Collect In - Un Invoiced (Customer)",
                Report = new CollectInUnInvoiceReport(),
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
                        "CustomerFrom", new ReportParameter
                        {
                            Label = "Customer From",
                            Control = new dLookup
                            {
                                LookupPopup = new CustomerPopup(),
                                AutoCompleteDataManager = new CustomerDataManager(),
                                AutoCompleteDisplayFormater = row => string.Format("{0} {1}", ((CustomerModel)row).Code, ((CustomerModel)row).Name),
                                AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("(code.StartsWith(@0) OR name.StartsWith(@0)) AND branch_id = @1", s, BaseControl.BranchId)
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
                                AutoCompleteDisplayFormater = row => string.Format("{0} {1}", ((CustomerModel)row).Code, ((CustomerModel)row).Name),
                                AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("(code.StartsWith(@0) OR name.StartsWith(@0)) AND branch_id = @1", s, BaseControl.BranchId)
                            }
                        }
                    }
                },
                DataSourceFunc = parameters =>
                {
                    using (var repo = new PaymentInCollectInDetailRepository())
                    {
                        var dateNull = new DateTime(1900, 1, 1, 0, 0, 0);
                        var param = new List<WhereTerm>();
                        var from = (DateTime)parameters["FromDate"].Value;
                        var to = (DateTime)parameters["ToDate"].Value;

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

                        // ReSharper disable once CoVariantArrayConversion
                        IListParameter[] p = param.ToArray();

                        var master = new PaymentInCollectInRepository().Get<PaymentInCollectInModel>(p);

                        param = new List<WhereTerm>();
                        var cfrom = parameters["CustomerFrom"].Control.Text;
                        var cto = parameters["CustomerTo"].Control.Text;

                        if (cfrom != "")
                        {
                            param.Add(WhereTerm.Default(cfrom, "collect_customer_name", EnumSqlOperator.GreatThanEqual));
                        }

                        if (cto != "")
                        {
                            param.Add(WhereTerm.Default(cto, "collect_customer_name", EnumSqlOperator.LesThanEqual));
                        }

                        param.Add(WhereTerm.Default("CREDIT", "collect_payment_method", EnumSqlOperator.Equals));
                        return repo.ReportUnInvoice(master, new[] {WhereTerm.Default("CREDIT", "collect_payment_method", EnumSqlOperator.Equals)});
                    }
                }
            };

            BaseControl.OpenForm(form, GetType());
        }
    }
}