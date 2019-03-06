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
using SISCO.Presentation.Reports.Marketing.Forms;
using SISCO.Repositories;

namespace SISCO.Presentation.Reports.Marketing.Command
{
    public class CustomerReportCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var now = DateTime.Now;

            var form = new ReportGenericFilterForm<CustomerReport.CustomerReportDataRow>
            {
                MdiParent = parent,
                Text = @"Customer Sales Report",
                Report = new CustomerReport(),
                Parameters = new Dictionary<string, ReportParameter>{
                    {
                        "CustomerIdFrom", new ReportParameter
                        {
                            Label = "Customer From",
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
                        "CustomerIdTo", new ReportParameter
                        {
                            Label = "Customer To",
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
                        "CustomerIsActive", new ReportParameter
                        {
                            Label = "Customer Active?",
                            Control = new CheckBox(),
                            DefaultValue = true
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
                },
                DataSourceFunc = parameters =>
                {
                    using (var repo = new ShipmentRepository())
                    {
                        return repo.GetCustomerLastOrder<CustomerReport.CustomerReportDataRow>(
                            parameters["CustomerIdFrom"].Value as int?,
                            parameters["CustomerIdTo"].Value as int?,
                            parameters["CustomerIsActive"].Value as bool?,
                            parameters["BranchId"].Value as int?);
                    }
                }
            };
            BaseControl.OpenForm(form, GetType());
        }
    }
}
