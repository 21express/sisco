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
using SISCO.Presentation.Reports.TitipInvoice.Forms;
using SISCO.Repositories;

namespace SISCO.Presentation.Reports.TitipInvoice.Command
{
    // ReSharper disable once InconsistentNaming
    public class PaidTitipInvoiceBranchCommand : IMenuInvoker
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
                Text = @"Titip Invoice - Paid Branch",
                Report = new PaidTitipInvoiceBranchReport(),
                Parameters = new Dictionary<string, ReportParameter>
                {
                    {
                        "FromDate", new ReportParameter
                        {
                            Label = "Tgl Titip Invoice Awal",
                            Control = new dCalendar(),
                            DefaultValue = new DateTime(now.Year, 1, 1)
                        }
                    },
                    {
                        "ToDate", new ReportParameter
                        {
                            Label = "Akhir",
                            Control = new dCalendar(),
                            DefaultValue = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month))
                        }
                    },
                    {
                        "AsOfDate", new ReportParameter
                        {
                            Label = "Per Tanggal",
                            Control = new dCalendar(),
                            DefaultValue = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month))
                        }
                    },
                    {
                        "DestBranch", new ReportParameter
                        {
                            Label = "Titip ke Cabang",
                            Control = new dLookup
                            {
                                LookupPopup = new BranchPopup(),
                                AutoCompleteDataManager = new BranchDataManager(),
                                AutoCompleteDisplayFormater =
                                    row => ((BranchModel) row).Name,
                                AutoCompleteWhereExpression =
                                    (s, p) => p.SetWhereExpression("name.StartsWith(@0)", s)
                            }
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
                    var branchFrom = (int?) parameters["DestBranch"].Value;

                    param.Add(WhereTerm.Default(BaseControl.BranchId, "owner_branch_id", EnumSqlOperator.Equals));

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

                    if (branchFrom != null)
                    {
                        param.Add(WhereTerm.Default((int)branchFrom, "branch_id", EnumSqlOperator.Equals));
                    }

                    // ReSharper disable once CoVariantArrayConversion
                    var ds = new OtherInvoiceRepository().PaidReportJournalCustomer(param.ToArray(), asofDate);

                    return ds.OrderBy(c => c.DateProcess);
                }
            };

            BaseControl.OpenForm(form, GetType());
        }
    }
}