using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using SISCO.App.Finance;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Reports.Finance.Forms;

namespace SISCO.Presentation.Reports.Finance.Command
{
    public class PaymentOutJournalCommand : IMenuInvoker
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
                Text = @"Finance - Payment Out Journal",
                Report = new PaymentOutJournalReport(),
                Parameters = new Dictionary<string, ReportParameter>
                {
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
                        "Type", new ReportParameter
                        {
                            Label = "Payment Type",
                            Control = new CheckedListBox
                            {
                                DataSource = new PaymentTypeDataManager().Get<PaymentTypeModel>(),
                                DisplayMember = "Name",
                                ValueMember = "Id",
                                Width = 240
                            }
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
                    var dateNull = new DateTime(1900, 1, 1, 0, 0, 0);
                    var param = new List<WhereTerm>();
                    var from = (DateTime)parameters["FromDate"].Value;
                    var to = (DateTime)parameters["ToDate"].Value;

                    param.Add(WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals));

                    if (from > dateNull)
                    {
                        var fdate = new DateTime(from.Year, from.Month, from.Day, 0, 0, 0);
                        param.Add(WhereTerm.Default(fdate, "date_process", EnumSqlOperator.GreatThanEqual));
                    }

                    if (to > dateNull)
                    {
                        var tdate = new DateTime(to.Year, to.Month, to.Day, 0, 0, 0);
                        param.Add(WhereTerm.Default(tdate, "date_process", EnumSqlOperator.LesThanEqual));
                    }

                    var ds = new List<PaymentInJournal>();

                    // ReSharper disable once CoVariantArrayConversion
                    var paymentrc = new PaymentRcDataManager().Get<PaymentRcModel>(param.ToArray());
                    // ReSharper disable PossibleMultipleEnumeration
                    if (paymentrc != null && paymentrc.Any())
                    {
                        ds.AddRange(paymentrc.Select(obj => new PaymentInJournal
                        {
                            Code = obj.Code,
                            PaymentTypeId = obj.PaymentTypeId != null ? (int) obj.PaymentTypeId : 0,
                            PaymentType = obj.PaymentType,
                            DateProcces = obj.DateProcess,
                            Description = obj.Description,
                            Company = obj.CompanyName,
                            Total = obj.Total
                        }));
                    }

                    // ReSharper disable once CoVariantArrayConversion
                    var paymentmc = new PaymentMcDataManager().Get<PaymentMcModel>(param.ToArray());
                    if (paymentmc != null && paymentmc.Any())
                    {
                        ds.AddRange(paymentmc.Select(obj => new PaymentInJournal
                        {
                            Code = obj.Code,
                            PaymentTypeId = obj.PaymentTypeId,
                            PaymentType = obj.PaymentType,
                            DateProcces = obj.DateProcess,
                            Description = obj.Description,
                            Company = obj.Marketing,
                            Total = obj.Total
                        }));
                    }

                    // ReSharper disable once CoVariantArrayConversion
                    var cost = new CostDataManager().Get<CostModel>(param.ToArray());
                    if (cost != null && cost.Any())
                    {
                        ds.AddRange(cost.Select(obj => new PaymentInJournal
                        {
                            Code = obj.Code,
                            PaymentTypeId = obj.PaymentTypeId != null ? (int)obj.PaymentTypeId : 0,
                            PaymentType = obj.PaymentType,
                            DateProcces = obj.DateProcess,
                            Description = obj.Description,
                            Company = "",
                            Total = obj.Total
                        }));
                    }

                    // ReSharper disable once CoVariantArrayConversion
                    var outcollect = new PaymentOutCollectInDataManager().Get<PaymentOutCollectInModel>(param.ToArray());
                    if (outcollect != null && outcollect.Any())
                    {
                        ds.AddRange(outcollect.Select(obj => new PaymentInJournal
                        {
                            Code = obj.Code,
                            PaymentTypeId = obj.PaymentTypeId,
                            PaymentType = obj.PaymentType,
                            DateProcces = obj.DateProcess,
                            Description = obj.Description,
                            Company = "",
                            Total = obj.Total
                        }));
                    }

                    // ReSharper disable once CoVariantArrayConversion
                    var delivery = new PaymentDeliveryDataManager().Get<PaymentDeliveryModel>(param.ToArray());
                    if (delivery != null && delivery.Any())
                    {
                        ds.AddRange(delivery.Select(obj => new PaymentInJournal
                        {
                            Code = obj.Code,
                            PaymentTypeId = obj.PaymentTypeId,
                            PaymentType = obj.PaymentType,
                            DateProcces = obj.DateProcess,
                            Description = obj.Description,
                            Company = "",
                            Total = obj.Total
                        }));
                    }

                    var typeid = (from object l in parameters["Type"].CheckedItems select ((PaymentTypeModel)l).Id).ToList();
                    return typeid.Count > 0 ? ds.OrderBy(c => c.DateProcces).Where(x => typeid.Contains(x.PaymentTypeId)) : ds.OrderBy(c => c.DateProcces);
                }
            };

            BaseControl.OpenForm(form, GetType());
        }
    }
}