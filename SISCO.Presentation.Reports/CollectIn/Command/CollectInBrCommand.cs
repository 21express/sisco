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
using SISCO.Presentation.MasterData.Popup;
using SISCO.Presentation.Reports.CollectIn.Forms;
using SISCO.Repositories;
using SISCO.Repositories.Context;

namespace SISCO.Presentation.Reports.CollectIn.Command
{
    public class CollectInBrCommand : IMenuInvoker
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
                Text = @"Collect In - Branch",
                Report = new CollectInBrReport(),
                Parameters = new Dictionary<string, ReportParameter>{
                    {
                        "FromDate", new ReportParameter
                        {
                            Label = "From Date",
                            Control = new dCalendar(),
                            DefaultValue = new DateTime(now.Year, 1, 1, 0, 0, 0, 0)
                        }
                    },
                    {
                        "ToDate", new ReportParameter
                        {
                            Label = "To Date",
                            Control = new dCalendar(),
                            DefaultValue = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59, 59)
                        }
                    },
                    {
                        "AsOfDate", new ReportParameter
                        {
                            Label = "As of Date",
                            Control = new dCalendar(),
                            DefaultValue = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59, 59)
                        }
                    },
                    {
                        "Branch", new ReportParameter
                        {
                            Label = "Origin Branch",
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
                        "Detail", new ReportParameter
                        {
                            Label = "Detail",
                            Control = new CheckBox()
                        }
                    }
                },
                DataSourceFunc = parameters =>
                {
                    using (var repo = new PaymentInCollectInDetailRepository())
                    {
                        var dateNull = new DateTime(1900, 1, 1, 0, 0, 0);
                        var param = new List<WhereTerm>();
                        var from = (DateTime)parameters["FromDate"].Value;
                        var to = (DateTime)parameters["ToDate"].Value;
                        var asOfDate = (DateTime)parameters["AsOfDate"].Value;

                        //param.Add(WhereTerm.Default(BaseControl.BranchId, "dest_branch_id", EnumSqlOperator.Equals));
                        //param.Add(WhereTerm.Default(false, "paid_coll"));

                        var collect = new PaymentMethodDataManager().GetFirst<PaymentMethodModel>(WhereTerm.Default("COLLECT", "name", EnumSqlOperator.Equals));
                        //param.Add(WhereTerm.Default(collect.Id, "payment_method_id", EnumSqlOperator.Equals));

                        if (from > dateNull)
                        {
                            from = new DateTime(from.Year, from.Month, from.Day, 0, 0, 0);
                            //param.Add(WhereTerm.Default(fdate, "date_process", EnumSqlOperator.GreatThanEqual));
                        }

                        if (to > dateNull)
                        {
                            to = new DateTime(to.Year, to.Month, to.Day, 0, 0, 0);
                            //param.Add(WhereTerm.Default(tdate, "date_process", EnumSqlOperator.LesThanEqual));
                        }

                        var branchid = (from object l in parameters["Branch"].CheckedItems select ((BranchModel)l).Id).ToList();

                        // ReSharper disable once CoVariantArrayConversion
                        //IListParameter[] p = param.ToArray();
                        //var shipment = branchid.Count > 0 ? new ShipmentRepository().CollectInList(p).Where(x => branchid.Contains(x.BranchId)) : new ShipmentRepository().CollectInList(p);

                        // ReSharper disable once CoVariantArrayConversion
                        //return repo.ReportCollectInBr(shipment, asOfDate, BaseControl.BranchId);
                        return repo.ReportCollectInBr(from, to, asOfDate, BaseControl.BranchId, collect.Id, branchid);
                    }
                }
            };

            BaseControl.OpenForm(form, GetType());
        }
    }
}