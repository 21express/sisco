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
    public class DeliveryOrderReportCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var now = DateTime.Now;

            var form = new ReportGenericFilterForm<DeliveryOrderReport.DeliveryOrderReportDataRow>
            {
                MdiParent = parent,
                Text = @"Delivery Order Report",
                Report = new DeliveryOrderReport(),
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
                            DefaultValue = new DateTime(now.Year, now.Month, now.Day)
                        }
                    },
                    {
                        "BranchId", new ReportParameter
                        {
                            Label = "Branch",
                            Control = new dLookup
                            {
                                LookupPopup = new BranchPopup(),
                                AutoCompleteDataManager = new BranchDataManager(),
                                AutoCompleteDisplayFormater = row => string.Format("{0} - {1}", ((BranchModel)row).Code, ((BranchModel)row).Name),
                                AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("code.Equals(@0) or name.StartsWith(@0)", s),
                                ValidationRules = new[] {new ComponentValidationRule(EnumComponentValidationRule.Mandatory)}
                            },
                            DefaultValue = BaseControl.BranchId
                        }
                    },
                    {
                        "MessengerId", new ReportParameter
                        {
                            Label = "Messenger",
                            Control = new dLookup
                            {
                                LookupPopup = new EmployeePopup(EmployeeModel.EmployeeType.Messenger),
                                AutoCompleteDataManager = new EmployeeDataManager(),
                                AutoCompleteDisplayFormater = row => string.Format("{0} - {1}", ((EmployeeModel)row).Code, ((EmployeeModel)row).Name),
                                AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("(code.Equals(@0) or name.StartsWith(@0)) AND as_messenger = true AND branch_id = @1", s, BaseControl.BranchId)
                            }
                        }
                    },
                    {
                        "VehicleTypeId", new ReportParameter
                        {
                            Label = "Vehicle Type",
                            Control = new dLookup
                            {
                                LookupPopup = new VehiclePopup(),
                                AutoCompleteDataManager = new VehicleTypeDataManager(),
                                AutoCompleteDisplayFormater = row => string.Format("{0}", ((VehicleTypeModel)row).Name),
                                AutoCompleteWheretermFormater = s => new IListParameter[] {WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)}
                            }
                        }
                    },
                    {
                        "FleetId", new ReportParameter
                        {
                            Label = "Plate Number",
                            Control = new dLookup
                            {
                                LookupPopup = new FleetPopup(),
                                AutoCompleteDataManager = new FleetDataManager(),
                                AutoCompleteDisplayFormater = row => string.Format("{0}", ((FleetModel)row).PlateNumber),
                                AutoCompleteWheretermFormater = s => new IListParameter[] {WhereTerm.Default(s, "plate_number", EnumSqlOperator.BeginWith)}
                            }
                        }
                    }
                },
                DataSourceFunc = parameters =>
                {
                    using (var repo = new DeliveryOrderRepository())
                    {
                        return repo.GetDeliveryOrderReport<DeliveryOrderReport.DeliveryOrderReportDataRow>(
                            (int) parameters["BranchId"].Value,
                            parameters["FromDate"].Value as DateTime?,
                            parameters["ToDate"].Value as DateTime?,
                            parameters["MessengerId"].Value as int?,
                            parameters["VehicleTypeId"].Value as int?,
                            parameters["FleetId"].Value as int?);
                    }
                }
            };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
