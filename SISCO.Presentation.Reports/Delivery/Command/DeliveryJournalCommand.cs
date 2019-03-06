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
using SISCO.Presentation.Reports.Delivery.Forms;
using SISCO.Repositories;

namespace SISCO.Presentation.Reports.Delivery.Command
{
    public class DeliveryJournalCommand : IMenuInvoker
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
                Text = @"Delivery Journal (Branch)",
                Report = new DeliveryJournalReport(),
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
                        "Branch", new ReportParameter
                        {
                            Label = "Dest Branch",
                            Control = new CheckedListBox
                            {
                                DataSource = new BranchDataManager().Get<BranchModel>(),
                                DisplayMember = "Name",
                                ValueMember = "Id",
                                Width = 240
                            }
                        }
                    },
                    {
                        "Summary", new ReportParameter
                        {
                            Label = "Detail",
                            Control = new CheckBox()
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

                        param.Add(WhereTerm.Default(BaseControl.BranchId, "branch_id"));

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

                        var branchid = (from object l in parameters["Branch"].CheckedItems select ((BranchModel)l).Id).ToList();

                        // ReSharper disable once CoVariantArrayConversion
                        IListParameter[] p = param.ToArray();
                        return branchid.Count > 0 ? repo.ReportDeliveryJournalBranch(p).Where(x => branchid.Contains(x.dest_branch_id)) : repo.ReportDeliveryJournalBranch(p);
                    }
                }
            };

            BaseControl.OpenForm(form, GetType());
        }
    }
}