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
using SISCO.Presentation.Reports.Cost.Forms;
using SISCO.Repositories;
using SISCO.Presentation.MasterData.Popup;

namespace SISCO.Presentation.Reports.Cost.Command
{
    public class CostJournalReportCommand : IMenuInvoker
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

            var lkpdivision = new dLookup
            {
                LookupPopup = new DivisionPopup(),
                AutoCompleteDataManager = new DivisionDataManager(),
                AutoCompleteDisplayFormater = row => ((DivisionModel)row).Name,
                AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("name.StartsWith(@0)", s)
            };

            lkpdivision.EditValueChanged += (s, args) =>
            {
                if (lkpdivision.Value != null)
                    checkBox.DataSource = new CostTypeDataManager().Get<CostTypeModel>(WhereTerm.Default((int)lkpdivision.Value, "division_id"));
                else checkBox.DataSource = new CostTypeDataManager().Get<CostTypeModel>();

                checkBox.DisplayMember = "Name";
                checkBox.ValueMember = "Id";
            };
            
            var form = new ReportGenericFilterForm<object>
            {
                MdiParent = parent,
                Text = @"Cost Journal - Type",
                Report = new CostJournalReport(),
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
                        "Division", new ReportParameter
                        {
                            Label = "Division",
                            Control = lkpdivision,
                        }
                    },
                    {
                        "CostTypes", new ReportParameter
                        {
                            Label = "Cost Type",
                            Control = checkBox
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
                    using (var repo = new CostDetailRepository())
                    {
                        var from = (DateTime)parameters["From"].Value;
                        var to = (DateTime)parameters["To"].Value;

                        int[] costTypes = (from object l in parameters["CostTypes"].CheckedItems select ((CostTypeModel)l).Id).ToArray();
                        return repo.GetCostDetailReport(from, to, costTypes, BaseControl.BranchId);
                    }
                }
            };

            BaseControl.OpenForm(form, GetType());
        }
    }
}