using System.Text;
using System.Text.RegularExpressions;
using Devenlab.Common;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common.Reports;
using System;

namespace SISCO.Presentation.Billing.Reports
{
    public class InvoiceDeliveryPrintOut : DotMatrixPrintOut<SalesInvoiceModel.SalesInvoiceReportRow>
    {
        protected override string GetLayoutFile()
        {
            return "InvoiceDelivery.txt";
        }

        protected override string GetRawText()
        {
            var sb = new StringBuilder();

            foreach (var model in DataSource)
            {
                var cityName = "";
                var customerCode = "";

                using (var branchDm = new BranchDataManager())
                {
                    var branch = branchDm.GetFirst<BranchModel>(WhereTerm.Default(model.BranchId, "id"));

                    if (branch != null)
                    {
                        using (var cityDm = new CityDataManager())
                        {
                            var city = cityDm.GetFirst<CityModel>(WhereTerm.Default(branch.CityId, "id"));

                            if (city != null)
                            {
                                cityName = city.Name;
                            }
                        }
                    }
                }
                using (var customerDm = new CustomerDataManager())
                {
                    var customer = customerDm.GetFirst<CustomerModel>(WhereTerm.Default(model.CompanyId, "id"));

                    if (customer != null)
                    {
                        customerCode = customer.Code;
                    }
                }

                var numberSpelled = (PaymentReceiptPrintout.TerbilangHelper.Spell(model.Total) + " rupiah").ToUpper();
                var numberSpelled1 = TruncateString(numberSpelled, 46);
                var numberSpelled2 = (numberSpelled.Length > 46) ? TruncateString(numberSpelled.Substring(46), 46) : "";

                sb.AppendFormat(Layout,
                    TruncateString(string.Format("{0}({1})", model.CompanyInvoicedTo, customerCode), 46),
                    model.DateFrom.ToString("dd-MM-yyyy"),
                    model.DateTo.ToString("dd-MM-yyyy"),
                    TruncateString(model.RefNumber, 10),
                    model.Total.ToString("#,0.00"),
                    !string.IsNullOrEmpty(model.InvoiceRevisionOf) ? string.Format("REVISI {0}", model.InvoiceRevisionOf) : string.Empty,
                    numberSpelled1,
                    numberSpelled2,
                    TruncateString(cityName, 34),
                    model.Vdate.ToString("dd-MM-yyyy")
                    );
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}