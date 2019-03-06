using System;
using System.Deployment.Application;
using System.Drawing;
using System.IO;
using Devenlab.Common;
using DevExpress.XtraReports.UI;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common.Reports;

namespace SISCO.Presentation.Operation.Reports
{
    public partial class PodCabangPrint : XtraReport//InkJetPrintOut<ShipmentModel.ShipmentReportRow>//
    {
        public PodCabangPrint()
        {
            InitializeComponent();

            try
            {
                var companyLogo = "company_logo.jpg";
                string userCompanyLogo = "";

                if (ApplicationDeployment.IsNetworkDeployed)
                {
                    userCompanyLogo = Path.Combine(ApplicationDeployment.CurrentDeployment.DataDirectory, companyLogo);

                    if (!File.Exists(userCompanyLogo))
                    {
                        File.Copy(companyLogo, userCompanyLogo);
                    }
                }
                else
                {
                    userCompanyLogo = companyLogo;
                }

                var image = Image.FromFile(userCompanyLogo);
                xrPictureBoxLogo1.Image = image;
                xrPictureBoxLogo2.Image = image;
                xrPictureBoxLogo3.Image = image;
            }
            catch
            {
                throw new Exception(@"File logo perusahaan untuk POD tidak ditemukan. Simpan file logo pada folder aplikasi dengan nama ""company_logo.jpg""");
            }
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var packageTypeId = GetCurrentColumnValue<int>("PackageTypeId");
            using (var dm = new PackageTypeDataManager())
            {
                var packageType = dm.GetFirst<PackageTypeModel>(WhereTerm.Default(packageTypeId, "id"));
                if (packageType != null)
                {
                    xrLabel117.Text = packageType.Name;
                    xrLabel118.Text = packageType.Name;
                }
            }
        }

        private void xrLabel54_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var paymentMethod = GetCurrentColumnValue<string>("PaymentMethod");
            if (paymentMethod == "CREDIT") ((XRLabel)sender).Text = string.Empty;
        }

        private void xrLabel112_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var paymentMethod = GetCurrentColumnValue<string>("PaymentMethod");
            if (paymentMethod == "CREDIT") ((XRLabel)sender).Text = string.Empty;
        }

        private void xrLabel155_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var paymentMethod = GetCurrentColumnValue<string>("PaymentMethod");
            if (paymentMethod == "CREDIT") ((XRLabel)sender).Text = string.Empty;
        }
    }
}
