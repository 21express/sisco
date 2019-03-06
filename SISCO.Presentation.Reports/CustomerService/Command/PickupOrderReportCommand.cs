using System;
using System.Collections.Generic;
using System.Linq;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.App.CustomerService;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using System.Windows.Forms;
using SISCO.Presentation.MasterData.Popup;
using SISCO.Presentation.Reports.CustomerService.Forms;

namespace SISCO.Presentation.Reports.CustomerService.Command
{
    public class PickupOrderDataRow : PickupOrderModel
    {
        public EmployeeDataManager EmployeeDataManager { get; set; }
        public ServiceTypeDataManager ServiceTypeDataManager { get; set; }
        
        public string StatusName
        {
            get { return PickedUp ? "Picked Up" : "Pending"; }
        }

        public new string ServiceName
        {
            get
            {
                var row = ServiceTypeDataManager.GetFirst<ServiceTypeModel>(WhereTerm.Default(ServiceTypeId, "id"));
                return row != null ? row.Name : "";
            }
        }

        public new string MessengerName
        {
            get
            {
                var row = EmployeeDataManager.GetFirst<EmployeeModel>(WhereTerm.Default(MessengerId, "id"));
                return row != null ? row.Name : "";
            }
        }

        public new string EmployeeName
        {
            get
            {
                var row = EmployeeDataManager.GetFirst<EmployeeModel>(WhereTerm.Default(EmployeeId, "id"));
                return row != null ? row.Name : "";
            }
        }
    }

    public class PickupOrderReportCommand : IMenuInvoker
    {
        public EmployeeDataManager EmployeeDataManager { get; set; }
        public ServiceTypeDataManager ServiceTypeDataManager { get; set; }

        public PickupOrderReportCommand()
        {
            EmployeeDataManager = new EmployeeDataManager();
            ServiceTypeDataManager = new ServiceTypeDataManager();
        }

        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var now = DateTime.Now;

            var form = new ReportGenericFilterForm<PickupOrderDataRow>
            {
                MdiParent = parent,
                Text = @"Pick Up Order Report",
                Report = new PickupOrderReport(),
                Parameters = new Dictionary<string, ReportParameter>{
                    {
                        "FromDate", new ReportParameter
                        {
                            Label = "From Date",
                            Control = new dCalendar(),
                            DefaultValue = new DateTime(now.Year, now.Month, now.Day, 0, 0, 0, 0)
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
                        "Status", new ReportParameter
                        {
                            Label = "Pickup Status",
                            Control = new dComboBox
                            {
                                Items = {"All", "Pending", "Picked Up"}
                            },
                            DefaultValue = "All"
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
                                AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("code = @0 OR name.StartsWith(@0)", s),
                                Enabled = false
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
                                AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND branch_id = @1 AND as_messenger", s, BaseControl.BranchId)
                            }
                        }
                    }
                },
                DataSourceFunc = parameters =>
                {
                    using (var dm = new PickupOrderDataManager())
                    {
                        var clauses = new List<IListParameter>();

                        clauses.Add(WhereTerm.Default((DateTime) parameters["FromDate"].Value, "date_process",
                            EnumSqlOperator.GreatThanEqual));
                        clauses.Add(WhereTerm.Default((DateTime) parameters["ToDate"].Value, "date_process",
                            EnumSqlOperator.LesThanEqual));

                        if (parameters["Status"].Value.ToString().Equals("Picked Up"))
                        {
                            clauses.Add(WhereTerm.Default(true, "picked_up"));
                        }

                        if (parameters["Status"].Value.ToString().Equals("Pending"))
                        {
                            clauses.Add(WhereTerm.Default(true, "confirmed"));
                            clauses.Add(WhereTerm.Default(false, "picked_up"));
                        }

                        if (((int?)parameters["BranchId"].Value) != null)
                        {
                            clauses.Add(WhereTerm.Default((int?)parameters["BranchId"].Value ?? 0, "branch_id"));
                        }

                        if (((int?)parameters["MessengerId"].Value) != null)
                        {
                            clauses.Add(WhereTerm.Default((int?)parameters["MessengerId"].Value ?? 0, "messenger_id"));
                        }

                        return dm.Get<PickupOrderModel>(clauses.ToArray()).Select(row =>
                        {
                            var obj = BaseForm.ConvertModel<PickupOrderModel, PickupOrderDataRow>(row);

                            obj.EmployeeDataManager = EmployeeDataManager;
                            obj.ServiceTypeDataManager = ServiceTypeDataManager;

                            return obj;
                        });
                    }
                },
                CustomTabularExportFormat = models => models.Select(row => new {
                    Messenger = row.MessengerName,
                    OrderDate = row.DateProcess.ToString("dd/MM/yyyy"),
                    OrderTime = row.DateProcess.ToString("hh:mm"),
                    PickupDate = row.PickupDate.ToString("dd/MM/yyyy"),
                    PickupTime = row.PickupDate.ToString("hh:mm"),
                    Customer = row.CustomerName,
                    Address = row.CustomerAddress,
                    row.Id,
                    Service = row.ServiceName,
                    CSO = row.EmployeeName,
                    Note = row.PickupNote,
                    Status = row.StatusName,
                })
            };
            BaseControl.OpenForm(form, GetType());
        }
    }
}