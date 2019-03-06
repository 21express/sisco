using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Reports.Finance.Forms;
using SISCO.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISCO.Presentation.Reports.Finance.Command
{
    public class CodPaymentCommand : IMenuInvoker
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
                Text = @"Finance - Pengembalian PPh 23",
                Report = new CodReport(),
                Parameters = new Dictionary<string, ReportParameter>
                {
                    {
                        "FromDate", new ReportParameter
                        {
                            Label = "Tgl Pembayaran",
                            Control = new dCalendar(),
                            DefaultValue = new DateTime(now.Year, now.Month, 1)
                        }
                    },
                    {
                        "ToDate", new ReportParameter
                        {
                            Label = "Tgl Pembayaran",
                            Control = new dCalendar(),
                            DefaultValue = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month))
                        }
                    }
                },
                DataSourceFunc = parameters =>
                {
                    var dateNull = new DateTime(1900, 1, 1, 0, 0, 0);
                    var from = (DateTime)parameters["FromDate"].Value;
                    var to = (DateTime)parameters["ToDate"].Value;

                    DateTime fdate = DateTime.Now;
                    DateTime tdate = DateTime.Now;

                    if (from > dateNull)
                    {
                        fdate = new DateTime(from.Year, from.Month, from.Day, 0, 0, 0);
                    }

                    if (to > dateNull)
                    {
                        tdate = new DateTime(to.Year, to.Month, to.Day, 23, 59, 59);
                    }

                    var Cods = new CodPaymentInRepository().GetCodPaymentReport(BaseControl.BranchId, fdate, tdate);
                    return Cods;
                }
            };

            BaseControl.OpenForm(form, GetType());
        }
    }
}
