using System;
using System.Collections.Generic;
using System.Linq;
using SISCO.App.Marketing;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using System.Windows.Forms;
using SISCO.Presentation.MasterData.Popup;
using SISCO.Presentation.Reports.Marketing.Forms;
using SISCO.Repositories;
using Devenlab.Common;
using Devenlab.Common.Interfaces;

namespace SISCO.Presentation.Reports.Marketing.Command
{
    public class LeadsReportCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var now = DateTime.Now;

            List<SalesLeadStatusModel> leadStatuses;

            using (var dm = new SalesLeadStatusDataManager())
            {
                leadStatuses = dm.Get<SalesLeadStatusModel>().ToList();
            }

            leadStatuses.Insert(0, new SalesLeadStatusModel
            {
                Id = -1,
                Name = "All"
            });

            var form = new ReportGenericFilterForm<LeadsReport.LeadsReportDataRow>
            {
                MdiParent = parent,
                Text = @"Leads Report",
                Report = new LeadsReport(),
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
                        "CustomerId", new ReportParameter
                        {
                            Label = "Customer",
                            Control = new dLookup
                            {
                                LookupPopup = new CustomerPopup(),
                                AutoCompleteDataManager = new CustomerDataManager(),
                                AutoCompleteDisplayFormater = row => string.Format("{0} - {1}", ((CustomerModel)row).Code, ((CustomerModel)row).Name),
                                AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("(code = @0 or name.StartsWith(@0)) and branch_id = @1", s, BaseControl.BranchId)
                            }
                        }
                    },
                    {
                        "ContactId", new ReportParameter
                        {
                            Label = "Contact",
                            Control = new dLookup
                            {
                                LookupPopup = new ContactPopup(),
                                AutoCompleteDataManager = new ContactDataManager(),
                                AutoCompleteDisplayFormater = row => string.Format("{0}", ((ContactModel)row).CompanyName),
                                AutoCompleteWheretermFormater = s => new IListParameter[]
                                {
                                    WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith),
                                    WhereTerm.Default(BaseControl.BranchId, "branch_id")
                                }
                            }
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
                                AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("code = @0 or name.StartsWith(@0)", s),
                                Enabled = false
                            },
                            DefaultValue = BaseControl.BranchId
                        }
                    },
                    {
                        "MarketingId", new ReportParameter
                        {
                            Label = "Marketing",
                            Control = new dLookup
                            {
                                LookupPopup = new EmployeePopup(EmployeeModel.EmployeeType.Marketing),
                                AutoCompleteDataManager = new EmployeeDataManager(),
                                AutoCompleteDisplayFormater = row => string.Format("{0} - {1}", ((EmployeeModel)row).Code, ((EmployeeModel)row).Name),
                                AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("code = @0 or name.StartsWith(@0)", s)
                            }
                        }
                    },
                    {
                        "LastLeadStatusId", new ReportParameter
                        {
                            Label = "Last Lead Status",
                            Control = new dComboBox
                            {
                                DataSource = leadStatuses,
                                DisplayMember = "Name",
                                ValueMember = "Id"
                            },
                            DefaultValue = -1
                        }
                    },
                },
                DataSourceFunc = parameters =>
                {
                    using (var repo = new SalesLeadRepository())
                    {
                        return repo.GetLeadsSummary<LeadsReport.LeadsReportDataRow>(
                            parameters["FromDate"].Value as DateTime?,
                            parameters["ToDate"].Value as DateTime?,
                            parameters["CustomerId"].Value as int?,
                            parameters["ContactId"].Value as int?,
                            parameters["BranchId"].Value as int?,
                            parameters["MarketingId"].Value as int?,
                            parameters["LastLeadStatusId"].Value as int?);
                    }
                },
                CustomTabularExportFormat = models => models.Select(row => new
                {
                    LeadNo = row.id,
                    Marketing = row.marketing_name,
                    LeadDate = row.vdate,
                    CustomerOrContact = row.contact_name,
                    Status = row.last_lead_status,
                    FollowUps = row.follow_ups_count,
                    LastFollowUp = row.last_follow_up_date
                })
            };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
