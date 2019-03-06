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
using SISCO.Presentation.Reports.CollectIn.Forms;
using SISCO.Repositories;
using BaseControl = SISCO.Presentation.Common.BaseControl;

namespace SISCO.Presentation.Reports.CollectIn.Command
{
    public class OutstandingCollectInCommand: IMenuInvoker
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
                Text = @"Collect In - Outstanding Collect In",
                Report = new OutstandingCollectInReport(),
                Parameters = new Dictionary<string, ReportParameter>{
                    {
                        "AsOfDate", new ReportParameter
                        {
                            Label = "As of Date",
                            Control = new dCalendar(),
                            DefaultValue = new DateTime(now.Year, now.Month, now.Day)
                        }
                    },
                    {
                        "Branch", new ReportParameter
                        {
                            Label = "Branch",
                            Control = new CheckedListBox
                            {
                                DataSource = new BranchDataManager().Get<BranchModel>(),
                                DisplayMember = "Name",
                                ValueMember = "Id",
                                Width = 240
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
                        var asOfDate = (DateTime)parameters["AsOfDate"].Value;

                        param.Add(WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals));

                        if (asOfDate > dateNull)
                        {
                            var tdate = new DateTime(asOfDate.Year, asOfDate.Month, asOfDate.Day, 0, 0, 0);
                            param.Add(WhereTerm.Default(tdate, "date_process", EnumSqlOperator.LesThanEqual));
                        }

                        var master = new PaymentInCollectInRepository().Get<PaymentInCollectInModel>(param.ToArray());

                        param = new List<WhereTerm>();
                        param.Add(WhereTerm.Default("CASH", "collect_payment_method", EnumSqlOperator.Equals));

                        var branchid = (from object l in parameters["Branch"].CheckedItems select ((BranchModel) l).Id).ToList();

                        return branchid.Count == 0 ? repo.OutstandingCollect(master, param.ToArray(), asOfDate, BaseControl.BranchId) : repo.OutstandingCollect(master, param.ToArray(), asOfDate, BaseControl.BranchId).Where(x => branchid.Contains(x.BranchId));
                    }
                }
            };

            BaseControl.OpenForm(form, GetType());
        }
    }
}