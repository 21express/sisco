using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;
using SISCO.Presentation.Reports.Cost.Forms;
using SISCO.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISCO.Presentation.Reports.Cost.Command
{
    public class CostPivotCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var now = DateTime.Now;
            var checkBox = new CheckedListBox
            {
                DataSource = new CostTypeDataManager().Get<CostTypeModel>(),
                DisplayMember = "Name",
                ValueMember = "Id",
                Width = 240
            };

            var form = new ReportGenericFilterForm<object>
            {
                MdiParent = parent,
                Text = @"Cost Pivot",
                Report = new CostPivotReport(),
                Parameters = new Dictionary<string, ReportParameter>
                {
                    {
                        "From", new ReportParameter
                        {
                            Label = "From Date",
                            Control = new dCalendar(),
                            DefaultValue = new DateTime(now.Year, now.Month, 1, 0, 0, 0, 0)
                        }
                    },
                    {
                        "To", new ReportParameter
                        {
                            Label = "To Date",
                            Control = new dCalendar(),
                            DefaultValue = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59, 59)
                        }
                    },
                    {
                        "Branch", new ReportParameter
                        {
                            Label = "Branch",
                            Control = new dLookup
                            {
                                LookupPopup = new BranchPopup(),
                                AutoCompleteDataManager = new BranchDataManager(),
                                AutoCompleteDisplayFormater = row => ((BranchModel)row).Name,
                                AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("code.StartsWith(@a) || name.StartsWith(@0)", s)
                            }
                        }
                    },
                    {
                        "CostTypes", new ReportParameter
                        {
                            Label = "Cost Type",
                            Control = checkBox
                        }
                    }
                },
                DataSourceFunc = parameters =>
                {
                    using (var repo = new CostDetailRepository())
                    {
                        var from = (DateTime)parameters["From"].Value;
                        var to = (DateTime)parameters["To"].Value;
                        var branch = (int?) parameters["Branch"].Value;

                        int[] costTypes = (from object l in parameters["CostTypes"].CheckedItems select ((CostTypeModel)l).Id).ToArray();
                        return repo.GetCostPivotSource(from, to, costTypes, branch);
                    }
                }
            };

            form.TextMode = DevExpress.XtraPrinting.TextExportMode.Value;
            BaseControl.OpenForm(form, GetType());
        }
    }
}
