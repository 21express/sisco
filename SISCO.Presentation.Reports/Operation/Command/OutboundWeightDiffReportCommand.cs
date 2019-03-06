using System;
using System.Collections.Generic;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using System.Windows.Forms;
using SISCO.Presentation.MasterData.Popup;
using SISCO.Presentation.Reports.Operation.Forms;
using SISCO.Repositories;

namespace SISCO.Presentation.Reports.Operation.Command
{
    public class OutboundWeightDiffReportCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var now = DateTime.Now;

            var form = new ReportGenericFilterForm<OutboundWeightDiffReport.OutboundWeightDiffReportDataRow>
            {
                MdiParent = parent,
                Text = @"Shipment & Waybill Weight Report",
                Report = new OutboundWeightDiffReport(),
                Parameters = new Dictionary<string, ReportParameter>{
                    {
                        "FromDate", new ReportParameter
                        {
                            Label = "From Date",
                            Control = new dCalendar
                            {
                                ValidationRules = new[] {new ComponentValidationRule(EnumComponentValidationRule.Mandatory)}
                            },
                            DefaultValue = new DateTime(now.Year, now.Month, 1)
                        }
                    },
                    {
                        "ToDate", new ReportParameter
                        {
                            Label = "To Date",
                            Control = new dCalendar
                            {
                                ValidationRules = new[] {new ComponentValidationRule(EnumComponentValidationRule.Mandatory)}
                            },
                            DefaultValue = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month))
                        }
                    },
                    {
                        "OrigBranchId", new ReportParameter
                        {
                            Label = "Origin Branch",
                            Control = new dLookup
                            {
                                LookupPopup = new BranchPopup(),
                                AutoCompleteDataManager = new BranchDataManager(),
                                AutoCompleteDisplayFormater = row => string.Format("{0} - {1}", ((BranchModel)row).Code, ((BranchModel)row).Name),
                                AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("code.Equals(@0) or name.StartsWith(@0)", s)
                            }
                        }
                    },
                    {
                        "DestBranchId", new ReportParameter
                        {
                            Label = "Destination Branch",
                            Control = new dLookup
                            {
                                LookupPopup = new BranchPopup(),
                                AutoCompleteDataManager = new BranchDataManager(),
                                AutoCompleteDisplayFormater = row => string.Format("{0} - {1}", ((BranchModel)row).Code, ((BranchModel)row).Name),
                                AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("code.Equals(@0) or name.StartsWith(@0)", s)
                            }
                        }
                    },
                    {
                        "CustomerId", new ReportParameter
                        {
                            Label = "Customer",
                            Control = new dLookup
                            {
                                LookupPopup = new CustomerPopup(),
                                AutoCompleteDataManager = new CustomerDataManager(),
                                AutoCompleteDisplayFormater = row => string.Format("{0} - {1}", ((CustomerModel)row).Code, ((CustomerModel)row).Name),
                                AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("(code.Equals(@0) or name.StartsWith(@0))", s)
                            }
                        }
                    },
                    {
                        "ShipmentNumber", new ReportParameter
                        {
                            Label = "ShipmentNumber",
                            Control = new dTextBox()
                        }
                    },
                    {
                        "ShipmentStatus", new ReportParameter
                        {
                            Label = "Having Shipment Status",
                            Control = new dComboBox
                            {
                                Items = {"Waybilled OR Airwaybilled", "Waybilled", "Airwaybilled"}
                            },
                            DefaultValue = "Waybilled OR Airwaybilled"
                        }
                    }
                },
                DataSourceFunc = parameters =>
                {
                    using (var repo = new ShipmentRepository())
                    {
                        return repo.GetOutboundWeightDiffReport<OutboundWeightDiffReport.OutboundWeightDiffReportDataRow>(
                            BaseControl.BranchId,
                            parameters["FromDate"].Value as DateTime?,
                            parameters["ToDate"].Value as DateTime?,
                            parameters["OrigBranchId"].Value as int?,
                            parameters["DestBranchId"].Value as int?,
                            parameters["CustomerId"].Value as int?,
                            parameters["ShipmentNumber"].Value as string,
                            parameters["ShipmentStatus"].Value as string);
                    }
                }
            };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
