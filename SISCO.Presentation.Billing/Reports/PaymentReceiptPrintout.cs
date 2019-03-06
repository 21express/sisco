using System.Text;
using System.Text.RegularExpressions;
using Devenlab.Common;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common.Reports;
using SISCO.Presentation.Common;

namespace SISCO.Presentation.Billing.Reports
{
    public class PaymentReceiptPrintout : DotMatrixRawPrintOut<SalesInvoiceModel.SalesInvoiceReportRow>
    {
        public class TerbilangHelper {
            private static readonly string[] Dasar = {"", "satu", "dua", "tiga", "empat", "lima", "enam", "tujuh", "delapan", "sembilan"};
            private static readonly long[] Angka = {
                1000000000,
                1000000,
                1000,
                100,
                10,
                1
            };
            private static readonly string[] Satuan = { "milyar", "juta", "ribu", "ratus", "puluh", "" };

            public static string Spell(decimal n)
	        {
	            var str = "";
		        var i = 0;
		        while(n != 0) {
			        var count = (int)(n/Angka[i]);
			        if(count >= 10)
                        str += Spell(count) + " " + Satuan[i] + " ";
			        else if(count > 0 && count < 10)
    			        str += Dasar[count] + " " + Satuan[i] + " ";

			        n -= Angka[i] * count;
			        i++;
		        }

	            str = Regex.Replace(str, @"satu puluh (\w+)", "$1 belas");
		        str = Regex.Replace(str, "satu (ribu|ratus|puluh|belas)", "se$1");

		        return str.Replace("  ", " ");
	        }
        }

        protected override string GetLayoutFile()
        {
            return "PaymentReceipt.txt";
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

                var numberSpelled = (TerbilangHelper.Spell(model.Total) + " rupiah").ToUpper();
                var numberSpelled1 = TruncateString(numberSpelled, 46);
                var numberSpelled2 = (numberSpelled.Length > 46) ? TruncateString(numberSpelled.Substring(46), 46) : "";

                sb.AppendFormat(Layout,
                    TruncateString(model.RefNumber, 25),
                    TruncateString(string.Format("{0}({1})", model.CompanyInvoicedTo, customerCode), 46),
                    numberSpelled1,
                    numberSpelled2,
                    TruncateString(model.Description1, 46),
                    TruncateString(model.Description2, 46),
                    TruncateString(model.Description3, 46),
                    TruncateString(cityName, 20),
                    model.Vdate.ToString("dd-MM-yyyy"),
                    model.Total.ToString("#,0.00")
                    );

                sb.AppendFormat("{0}", (char)12);
            }

            Write(sb.ToString());
        }
    }
}