using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Reports.Sales.Forms;
using SISCO.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISCO.Presentation.Reports.Sales.Command
{
    public class MobilePointCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var now = DateTime.Now.AddMonths(-1);
            var form = new ReportGenericFilterForm<ShipmentModel.ShipmentMobile>
            {
                MdiParent = parent,
                Text = @"Sales Invoice",
                Report = new MobilePointReport(),
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
                        return repo.GetMobilePoint(
                            (DateTime)parameters["FromDate"].Value,
                            (DateTime)parameters["ToDate"].Value
                        );
                    }
                }
            };

            BaseControl.OpenForm(form, GetType());
        }
    }
}
