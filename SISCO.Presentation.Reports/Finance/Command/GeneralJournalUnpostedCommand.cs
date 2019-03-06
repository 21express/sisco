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
using SISCO.Presentation.Reports.Finance.Forms;
using SISCO.Repositories;

namespace SISCO.Presentation.Reports.Finance.Command
{
    public class GeneralJournalUnpostedCommand : IMenuInvoker
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
                Text = @"Finance - Buku Bank Belum Posting",
                Report = new GeneralJournalUnpostedReport(),
                Parameters = new Dictionary<string, ReportParameter>
                {
                    {
                        "BankAccount", new ReportParameter
                        {
                            Label = "Rekening",
                            Control = new dLookup
                            {
                                LookupPopup = new BankAccountPopup(),
                                AutoCompleteDataManager = new BankAccountDataManager(),
                                AutoCompleteDisplayFormater =
                                    row => string.Format("{0} {1}", ((BankAccountModel) row).AccountNo, ((BankAccountModel) row).BankName),
                                AutoCompleteWhereExpression =
                                    (s, p) => p.SetWhereExpression("account_no.StartsWith(@0) and branch_id = @1", s, BaseControl.BranchId)
                            }
                        }
                    },
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
                    var dateNull = new DateTime(1900, 1, 1, 0, 0, 0);
                    var from = (DateTime)parameters["FromDate"].Value;
                    var to = (DateTime)parameters["ToDate"].Value;
                    var account = (int?)parameters["BankAccount"].Value;

                    DateTime? fdate = null;
                    DateTime? tdate = null;

                    if (from > dateNull)
                    {
                        fdate = new DateTime(from.Year, from.Month, from.Day, 0, 0, 0);
                    }

                    if (to > dateNull)
                    {
                        tdate = new DateTime(to.Year, to.Month, to.Day, 23, 59, 59);
                    }

                    return new TransactionalAccountRepository().JournalUnpostedReport((int)account, fdate, tdate);
                }
            };

            BaseControl.OpenForm(form, GetType());
        }
    }
}