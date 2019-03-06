using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Reports.CollectIn.Forms;
using SISCO.Repositories;

namespace SISCO.Presentation.Reports.CollectIn.Command
{
    public class CollectInProcessCommand : IMenuInvoker
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
                Text = @"Collect In - In Process (Branch)",
                Report = new CollectInProcessReport(),
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
                    }
                },
                DataSourceFunc = parameters =>
                {
                    using (var repo = new ShipmentRepository())
                    {
                        var dateNull = new DateTime(1900, 1, 1, 0, 0, 0);
                        var param = new List<WhereTerm>();
                        var from = (DateTime)parameters["FromDate"].Value;
                        var to = (DateTime)parameters["ToDate"].Value;

                        param.Add(WhereTerm.Default(BaseControl.BranchId, "dest_branch_id", EnumSqlOperator.Equals));
                        //param.Add(WhereTerm.Default(false, "paid_coll"));

                        var collect = new PaymentMethodDataManager().GetFirst<PaymentMethodModel>(WhereTerm.Default("COLLECT", "name", EnumSqlOperator.Equals));
                        param.Add(WhereTerm.Default(collect.Id, "payment_method_id", EnumSqlOperator.Equals));

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
                        return repo.CollectInList(p).Where(x => string.IsNullOrEmpty(x.CollectPaymentMethod));
                    }
                }
            };

            BaseControl.OpenForm(form, GetType());
        }
    }
}