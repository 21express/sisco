using System;
using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using System.Windows.Forms;
using SISCO.Presentation.MasterData.Popup;
using SISCO.Presentation.Reports.CustomerService.Forms;
using SISCO.Repositories;

namespace SISCO.Presentation.Reports.CustomerService.Command
{
    public class UnmanifestReportCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var now = DateTime.Now;

            var form = new ReportGenericFilterForm<UnmanifestReport.UnmanifestDataRow>
            {
                MdiParent = parent,
                Text = @"Unmanifest Report",
                Report = new UnmanifestReport(),
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
                        "PaymentMethodId", new ReportParameter
                        {
                            Label = "Payment Method",
                            Control = new dLookup
                            {
                                LookupPopup = new PaymentMethodPopup(),
                                AutoCompleteDataManager = new PaymentMethodDataManager(),
                                AutoCompleteDisplayFormater = row => string.Format("{0}", ((PaymentMethodModel)row).Name),
                                AutoCompleteWheretermFormater = s => new IListParameter[]
                                {
                                    WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
                                }
                            }
                        }
                    },
                    {
                        "BranchId", new ReportParameter
                        {
                            Label = "Branch",
                            Control = new dLookup
                            {
                                LookupPopup = new BranchPopup(),
                                AutoCompleteDataManager = new BranchDataManager(),
                                AutoCompleteDisplayFormater = row => string.Format("{0} - {1}", ((BranchModel)row).Code, ((BranchModel)row).Name),
                                AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("code = @0 or name.StartsWith(@0)", s)
                            },
                            DefaultValue = BaseControl.BranchId
                        }
                    },
                },
                DataSourceFunc = parameters =>
                {
                    using (var repo = new ShipmentRepository())
                    {
                        return repo.GetUnmanifestList<UnmanifestReport.UnmanifestDataRow>(
                            parameters["FromDate"].Value as DateTime?,
                            parameters["ToDate"].Value as DateTime?,
                            parameters["PaymentMethodId"].Value as int?,
                            parameters["BranchId"].Value as int?);
                    }
                }
            };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
