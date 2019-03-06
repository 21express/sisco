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
    public class PaymentOutDetailJournalCommand : IMenuInvoker
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
                Text = @"Finance - Payment Out Detail Journal",
                Report = new PaymentOutDetailJournalReport(),
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
                        "Type", new ReportParameter
                        {
                            Label = "Payment Type",
                            Control = new CheckedListBox
                            {
                                DataSource = new PaymentTypeDataManager().Get<PaymentTypeModel>(),
                                DisplayMember = "Name",
                                ValueMember = "Id",
                                Width = 240
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

                    var ds = new List<PaymentInJournal>();
                    // ReSharper disable once CoVariantArrayConversion
                    var paymentrc = new PaymentRcRepository().DetailJournal(param.ToArray());
                    ds.AddRange(paymentrc.ToList());
                    // ReSharper restore PossibleMultipleEnumeration

                    // ReSharper disable once CoVariantArrayConversion
                    var paymentmc = new PaymentMcRepository().DetailJournal(param.ToArray());
                    ds.AddRange(paymentmc.ToList());
                    // ReSharper restore PossibleMultipleEnumeration

                    // ReSharper disable once CoVariantArrayConversion
                    var cost = new CostRepository().DetailJournals(param.ToArray());
                    ds.AddRange(cost.ToList());

                    param[0] = WhereTerm.Default(BaseControl.BranchId, "owner_branch_id", EnumSqlOperator.Equals);
                    // ReSharper disable once CoVariantArrayConversion
                    var outcollect = new PaymentOutCollectInRepository().DetailJournals(param.ToArray());
                    ds.AddRange(outcollect.ToList());

                    // ReSharper disable once CoVariantArrayConversion
                    var delivery = new PaymentDeliveryRepository().DetailJournals(param.ToArray());
                    ds.AddRange(delivery.ToList());

                    var typeid = (from object l in parameters["Type"].CheckedItems select ((PaymentTypeModel)l).Id).ToList();
                    return typeid.Count > 0 ? ds.OrderBy(c => c.DateProcces).Where(x => typeid.Contains(x.PaymentTypeId)) : ds.OrderBy(c => c.DateProcces);
                }
            };

            BaseControl.OpenForm(form, GetType());
        }
    }
}