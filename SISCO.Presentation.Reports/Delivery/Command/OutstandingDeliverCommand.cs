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
using SISCO.Presentation.Reports.Delivery.Forms;
using SISCO.Repositories;

namespace SISCO.Presentation.Reports.Delivery.Command
{
    public class OutstandingDeliveryCommand : IMenuInvoker
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
                Text = @"Outstanding Delivery (Branch)",
                Report = new OutstandingDeliveryReport(),
                Parameters = new Dictionary<string, ReportParameter>{
                    {
                        "AsOfDate", new ReportParameter
                        {
                            Label = "As Of Date",
                            Control = new dCalendar(),
                            DefaultValue = DateTime.Now
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
                        "Detail", new ReportParameter
                        {
                            Label = "Detail",
                            Control = new CheckBox()
                        }
                    }
                },
                DataSourceFunc = parameters =>
                {
                    using (var repo = new PaymentDeliveryRepository())
                    {
                        var dateNull = new DateTime(1900, 1, 1, 0, 0, 0);
                        var param = new List<WhereTerm>();
                        var asofDate = (DateTime)parameters["AsOfDate"].Value;

                        param.Add(WhereTerm.Default(BaseControl.BranchId, "branch_id"));

                        var branchids = (from object l in parameters["Branch"].CheckedItems select ((BranchModel)l).Id).ToList();

                        // ReSharper disable once CoVariantArrayConversion
                        IListParameter[] p = param.ToArray();
                        return repo.OutstandingDelivery(p, asofDate, branchids);
                    }
                }
            };

            BaseControl.OpenForm(form, GetType());
        }
    }
}