using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Devenlab.Common;
using Franchise.Presentation.Common;
using Franchise.Presentation.Common.Component;
using Franchise.Presentation.Common.Forms;
using Franchise.Presentation.Reports.Forms;
using SISCO.App.Franchise;

namespace Franchise.Presentation.Reports.Command
{
    public class PaymentCommand : IMenuInvoker
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
                Text = @"Status Pembayaran",
                Report = new PaymentReport(),
                Parameters = new Dictionary<string, ReportParameter>
                {
                    {
                        "FromDate", new ReportParameter
                        {
                            Label = "Tgl Dari",
                            Control = new dCalendar(),
                            DefaultValue = new DateTime(now.Year, now.Month, now.Day)
                        }
                    },
                    {
                        "ToDate", new ReportParameter
                        {
                            Label = "Tgl Sampai",
                            Control = new dCalendar(),
                            DefaultValue = new DateTime(now.Year, now.Month, now.Day)
                        }
                    }
                },
                DataSourceFunc = parameters =>
                {
                    var dateNull = new DateTime(1900, 1, 1, 0, 0, 0);
                    var param = new List<WhereTerm>();
                    var from = (DateTime)parameters["FromDate"].Value;
                    var to = (DateTime)parameters["ToDate"].Value;

                    param.Add(WhereTerm.Default(BaseControl.BranchId, "s.branch_id", EnumSqlOperator.Equals));
                    param.Add(WhereTerm.Default(BaseControl.CityId, "s.city_id", EnumSqlOperator.Equals));
                    param.Add(WhereTerm.Default(BaseControl.FranchiseId, "s.franchise_id", EnumSqlOperator.Equals));

                    if (from > dateNull)
                    {
                        var fdate = new DateTime(from.Year, from.Month, from.Day, 0, 0, 0);
                        param.Add(WhereTerm.Default(fdate, "s.date_process", EnumSqlOperator.GreatThanEqual));
                    }

                    if (to > dateNull)
                    {
                        var tdate = new DateTime(to.Year, to.Month, to.Day, 23, 59, 59);
                        param.Add(WhereTerm.Default(tdate, "s.date_process", EnumSqlOperator.LesThanEqual));
                    }

                    // ReSharper disable once CoVariantArrayConversion
                    var ds = new FranchisePickupDataManager().ReportPayment(param.ToArray());
                    return ds.OrderBy(c => c.DateProcess);
                }
            };

            BaseControl.OpenForm(form, GetType());
        }
    }
}
