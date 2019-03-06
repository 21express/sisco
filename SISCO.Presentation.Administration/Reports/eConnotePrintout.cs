using System;
using System.Deployment.Application;
using System.Drawing;
using System.IO;
using SISCO.Models;
using SISCO.Presentation.Common.Reports;
using DevExpress.XtraReports.UI;
using SISCO.Presentation.Administration.Forms;

namespace SISCO.Administration.Operation.Reports
{
    public partial class EConnotePrintout : InkJetPrintOut<PrintPodModel>//XtraReport//
    {
        public EConnotePrintout()
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
            /*var packageTypeId = GetCurrentColumnValue<int>("PackageTypeId");
            using (var dm = new PackageTypeDataManager())
            {
                var packageType = dm.GetFirst<PackageTypeModel>(WhereTerm.Default(packageTypeId, "id"));
                if (packageType != null)
                {
                    xrLabel117.Text = packageType.Name;
                    xrLabel118.Text = packageType.Name;
                }
            }*/
        }

        private void xrLabel54_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var model = GetCurrentRow() as PrintPodModel;
            if (model.PaymentMethod1 == "CREDIT") ((XRLabel)sender).Text = string.Empty;
        }

        private void xrLabel159_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var model = GetCurrentRow() as PrintPodModel;
            if (model.PaymentMethod2 == "CREDIT") ((XRLabel)sender).Text = string.Empty;
        }

        private void xrLabel111_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var model = GetCurrentRow() as PrintPodModel;
            if (model.PaymentMethod3 == "CREDIT") ((XRLabel)sender).Text = string.Empty;
        }

        private void xrLabel296_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var model = GetCurrentRow() as PrintPodModel;
            if (model.PaymentMethod1 == "CREDIT") ((XRLabel)sender).Text = string.Empty;
        }

        private void xrLabel166_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var model = GetCurrentRow() as PrintPodModel;
            if (model.PaymentMethod2 == "CREDIT") ((XRLabel)sender).Text = string.Empty;
        }

        private void xrLabel303_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var model = GetCurrentRow() as PrintPodModel;
            if (model.PaymentMethod3 == "CREDIT") ((XRLabel)sender).Text = string.Empty;
        }

        private void xrLabel305_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var model = GetCurrentRow() as PrintPodModel;
            if (model.PaymentMethod3 == "CREDIT") ((XRLabel)sender).Text = string.Empty;
        }

        private void xrLabel161_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var model = GetCurrentRow() as PrintPodModel;
            if (model.PaymentMethod2 == "CREDIT") ((XRLabel)sender).Text = string.Empty;
        }

        private void xrLabel298_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var model = GetCurrentRow() as PrintPodModel;
            if (model.PaymentMethod1 == "CREDIT") ((XRLabel)sender).Text = string.Empty;
        }

        private void xrLabel189_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var model = GetCurrentRow() as PrintPodModel;
            if (model.TotalCod1 > 0) e.Cancel = false;
            else e.Cancel = true;
        }

        private void xrLabel188_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var model = GetCurrentRow() as PrintPodModel;
            if (model.TotalCod1 > 0) e.Cancel = false;
            else e.Cancel = true;
        }

        private void xrLabel190_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var model = GetCurrentRow() as PrintPodModel;
            if (model.TotalCod2 > 0) e.Cancel = false;
            else e.Cancel = true;
        }

        private void xrLabel191_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var model = GetCurrentRow() as PrintPodModel;
            if (model.TotalCod2 > 0) e.Cancel = false;
            else e.Cancel = true;
        }

        private void xrLabel192_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var model = GetCurrentRow() as PrintPodModel;
            if (model.TotalCod3 > 0) e.Cancel = false;
            else e.Cancel = true;
        }

        private void xrLabel193_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var model = GetCurrentRow() as PrintPodModel;
            if (model.TotalCod3 > 0) e.Cancel = false;
            else e.Cancel = true;
        }

        private void xrLabel194_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var row = GetCurrentRow() as PrintPodModel;
            if (row.Printed1 > 0) ((XRLabel)sender).Text = string.Format("Copy {0}", row.Printed1.ToString());
            else ((XRLabel)sender).Text = string.Empty;
        }

        private void xrLabel195_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var row = GetCurrentRow() as PrintPodModel;
            if (row.Printed2 > 0) ((XRLabel)sender).Text = string.Format("Copy {0}", row.Printed2.ToString());
            else ((XRLabel)sender).Text = string.Empty;
        }

        private void xrLabel196_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var row = GetCurrentRow() as PrintPodModel;
            if (row.Printed3 > 0) ((XRLabel)sender).Text = string.Format("Copy {0}", row.Printed3.ToString());
            else ((XRLabel)sender).Text = string.Empty;
        }
    }
}