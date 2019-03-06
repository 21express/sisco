using System.Text;
using Devenlab.Common;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common.Reports;

namespace SISCO.Presentation.Billing.Reports
{
    public class PaymentReceiptCorporatePrintout : DotMatrixRawPrintOut<SalesInvoiceModel.SalesInvoiceReportRow>
    {
        protected override string GetLayoutFile()
        {
            return "PaymentReceiptCorporate.txt";
        }

        protected override void ProcessPrint()
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
                var numberSpelled1 = TruncateString(numberSpelled, 43);
                var numberSpelled2 = (numberSpelled.Length > 43) ? TruncateString(numberSpelled.Substring(43), 43) : "";

                sb.AppendFormat(Layout,
                    "",
                    TruncateString(string.Format("{0}({1})", model.CompanyInvoicedTo, customerCode), 43),
                    numberSpelled1,
                    numberSpelled2,
                    TruncateString(model.Description1, 43),
                    TruncateString(model.Description2, 43),
                    TruncateString(model.Description3, 43),
                    TruncateString(cityName, 20),
                    model.Vdate.ToString("dd-MM-yyyy"),
                    model.Total.ToString("#,0.00")
                    );

                sb.AppendFormat("{0}", (char) 12);
            }

            Write(sb.ToString());
        }
    }
}