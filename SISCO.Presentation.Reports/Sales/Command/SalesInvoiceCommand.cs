using System;
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
using System.Linq;

namespace SISCO.Presentation.Reports.Sales.Command
{
    public class SalesInvoiceCommand : IMenuInvoker
    {
        public void open()
        {
            throw new NotImplementedException();
        }

        public void open(Form parent)
        {
            var now = DateTime.Now.AddMonths(-1);
            var form = new ReportGenericFilterForm<ReportInvoice>
            {
                MdiParent = parent,
                Text = @"Sales Invoice",
                Report = new SalesInvoiceReport(),
                Parameters = new Dictionary<string, ReportParameter>{
                    {
                        "Period", new ReportParameter
                        {
                            Label = "Period (YYYYMM)",
                            Control = new dTextBox(),
                            DefaultValue = string.Format("{0}{1}", DateTime.Now.ToString("yyyy"), DateTime.Now.ToString("MM"))
                        }
                    },
                    {
                        "Invoice", new ReportParameter
                        {
                            Label = "Filter Invoice",
                            Control = new dTextBox()
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
                                AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("code = @0 or name.StartsWith(@0)", s)
                            },
                        }
                    },
                    {
                        "Title1", new ReportParameter
                        {
                            Label = "Title 1",
                            Control = new dTextBox{
                                Width = 300
                            },
                            DefaultValue = "LAPORAN INVOICE PT. GLOBALINDO EXPRESS",
                        }
                    },
                    {
                        "Title2", new ReportParameter
                        {
                            Label = "Title 2",
                            Control = new dTextBox{
                                Width = 300
                            },
                            DefaultValue = string.Format("BULAN {0} {1}", DateTime.Now.ToString("MMMM"), DateTime.Now.ToString("yyyy")),
                        }
                    },
                    {
                        "Outstanding", new ReportParameter
                        {
                            Label = "Outstanding",
                            Control = new dCheckBox()
                        }
                    },
                    {
                        "ViewDatePaid", new ReportParameter
                        {
                            Label = "View Tgl Lns",
                            Control = new dCheckBox()
                        }
                    },
                    {
                        "ViewAdjustment", new ReportParameter
                        {
                            Label = "View Disc",
                            Control = new dCheckBox()
                        }
                    },
                    {
                        "ViewPayment", new ReportParameter
                        {
                            Label = "View Pembayaran",
                            Control = new dCheckBox()
                        }
                    },
                    {
                        "ViewPaymentType", new ReportParameter
                        {
                            Label = "View Pay. Type",
                            Control = new dCheckBox()
                        }
                    },
                    {
                        "ViewOther", new ReportParameter
                        {
                            Label = "View Titip Inv",
                            Control = new dCheckBox()
                        }
                    }
                },
                DataSourceFunc = parameters =>
                {
                    using (var repo = new SalesInvoiceRepository())
                    {
                        return repo.ReportInvoiceGlobal(
                            parameters["Period"].Value.ToString(),
                            parameters["Invoice"].Value.ToString(),
                            BaseControl.BranchId,
                            parameters["Customer"].Value != null ? (int)parameters["Customer"].Value : 0,
                            (bool)parameters["Outstanding"].Value);
                    }
                }
            };

            BaseControl.OpenForm(form, GetType());
        }
    }
}