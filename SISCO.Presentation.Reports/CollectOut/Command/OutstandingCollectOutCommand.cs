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
using SISCO.Presentation.Reports.CollectOut.Forms;
using SISCO.Repositories;

namespace SISCO.Presentation.Reports.CollectOut.Command
{
    public class OutstandingCollectOutCommand : IMenuInvoker
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
                Text = @"Outstanding Collect Out - Branch",
                Report = new OutstandingCollectOutBrReport(),
                Parameters = new Dictionary<string, ReportParameter>
                {
                    {
                        "AsOfDate", new ReportParameter
                        {
                            Label = "As of Date",
                            Control = new dCalendar(),
                            DefaultValue = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59 ,59)
                        }
                    },
                    {
                        "Branch", new ReportParameter
                        {
                            Label = "Dari Cabang",
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
                    using (var repo = new PaymentInCollectOutDetailRepository())
                    {
                        var param = new List<WhereTerm>();
                        var asOfDate = (DateTime)parameters["AsOfDate"].Value;

                        var collect = new PaymentMethodDataManager().GetFirst<PaymentMethodModel>(WhereTerm.Default("COLLECT", "name", EnumSqlOperator.Equals));
                        param.Add(WhereTerm.Default(collect.Id, "payment_method_id", EnumSqlOperator.Equals));

                        param.Add(WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals));

                        var branchid = (from object l in parameters["Branch"].CheckedItems select ((BranchModel)l).Id).ToList();

                        // ReSharper disable once CoVariantArrayConversion
                        var shipment = new ShipmentDataManager().Get<ShipmentModel>(param.ToArray());
                        if (branchid.Count > 0) shipment = shipment.Where(s => s.DestBranchId != null && branchid.Contains((int)s.DestBranchId)).ToList();

                        return repo.CollectOutReport(shipment, asOfDate).Where(s => s.Balance != 0);
                    }
                }
            };

            BaseControl.OpenForm(form, GetType());
        }
    }
}