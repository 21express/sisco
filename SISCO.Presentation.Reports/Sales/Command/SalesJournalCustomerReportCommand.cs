﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;
using SISCO.Presentation.Reports.Sales.Forms;
using SISCO.Repositories;

namespace SISCO.Presentation.Reports.Sales.Command
{
    public class SalesJournalCustomerReportCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var now = DateTime.Now;
            var form = new ReportGenericFilterForm<ReportSalesJournal>
            {
                MdiParent = parent,
                Text = @"Sales Journal (Customer)",
                Report = new SalesJournalCustomerReport(),
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
                        "Customer", new ReportParameter
                        {
                            Label = "Customer",
                            Control = new dLookup
                            {
                                LookupPopup = new CustomerPopup(),
                                AutoCompleteDataManager = new CustomerDataManager(),
                                AutoCompleteDisplayFormater = row => string.Format("{0} - {1}", ((CustomerModel)row).Code, ((CustomerModel)row).Name),
                                AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("(code = @0 or name.StartsWith(@0)) AND branch_id = @1", s, BaseControl.BranchId)
                            },
                        }
                    }
                },
                DataSourceFunc = parameters =>
                {
                    using (var repo = new ShipmentRepository())
                    {
                        return repo.ReportSalesJournal<ReportSalesJournal>(
                            BaseControl.BranchId,
                            parameters["FromDate"].Value as DateTime?, parameters["ToDate"].Value as DateTime?,
                            null, null,
                            null, null,
                            parameters["Customer"].Value as int?, null,
                            null, null,
                            null, null);
                    }
                }
            };

            BaseControl.OpenForm(form, GetType());
        }
    }
}