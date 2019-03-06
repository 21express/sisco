﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Franchise.Popup;
using SISCO.Presentation.Reports.Forms;
using SISCO.App.Franchise;
using SISCO.Models;

namespace SISCO.Presentation.Franchise.Command
{
    public class FranchiseSalesCommand : IMenuInvoker
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
                Text = @"Penjualan Agent",
                Report = new SalesReport(),
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
                        "Franchise", new ReportParameter
                        {
                            Label = "Franchise",
                            Control = new dLookup
                            {
                                LookupPopup = new FranchisePopup(),
                                AutoCompleteDataManager = new FranchiseDataManager(),
                                AutoCompleteDisplayFormater = row => ((FranchiseModel)row).Code + " " + ((FranchiseModel)row).Name,
                                AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("code.StartsWith(@0) OR name.StartsWith(@0)", s),
                                ValidationRules = new[] {new ComponentValidationRule(EnumComponentValidationRule.Mandatory)},
                                Enabled = true
                            }
                        }
                    },
                    {
                        "Rekap", new ReportParameter
                        {
                            Label = "Rekap",
                            Control = new dCheckBox
                            {
                                Text = ""
                            }
                        }
                    }
                },
                DataSourceFunc = parameters =>
                {
                    var dateNull = new DateTime(1900, 1, 1, 0, 0, 0);
                    var param = new List<WhereTerm>();
                    var from = (DateTime)parameters["FromDate"].Value;
                    var to = (DateTime)parameters["ToDate"].Value;

                    if (from > dateNull)
                    {
                        var fdate = new DateTime(from.Year, from.Month, from.Day, 0, 0, 0);
                        param.Add(WhereTerm.Default(fdate, "s.date_process", EnumSqlOperator.GreatThanEqual));
                    }

                    if (to > dateNull)
                    {
                        var tdate = new DateTime(to.Year, to.Month, to.Day, 23, 59, 59);
                        param.Add(WhereTerm.Default(tdate, "s.date_process", EnumSqlOperator.LesThanEqual));
                    }

                    if (parameters["Franchise"].Value != null)
                    {
                        param.Add(WhereTerm.Default((int)parameters["Franchise"].Value, "s.franchise_id", EnumSqlOperator.Equals));
                    }

                    // ReSharper disable once CoVariantArrayConversion
                    var ds = new FranchiseCommissionDataManager().ReportCommission(param.ToArray());
                    return ds.OrderBy(c => c.DateProcess);
                }
            };

            BaseControl.OpenForm(form, GetType());
        }
    }
}
