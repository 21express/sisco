using System;
using System.Deployment.Application;
using System.Drawing;
using System.IO;
using Devenlab.Common;
using DevExpress.XtraReports.UI;
using SISCO.App.MasterData;
using SISCO.Models;
using Franchise.Presentation.Common.Reports;

namespace Franchise.Presentation.DropPoint.Print
{
    public partial class EConnotePrintout : InkJetPrintOut<ShipmentModel.ShipmentReportRow>//XtraReport//
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
                xrPictureBoxLogo4.Image = image;
                xrPictureBoxLogo5.Image = image;
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

        private void xrLabel341_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var row = GetCurrentRow() as ShipmentModel.ShipmentReportRow;
            if (row.Printed > 0) ((XRLabel)sender).Text = string.Format("Copy {0}", row.Printed.ToString());
            else ((XRLabel)sender).Text = string.Empty;
        }

        private void xrLabel342_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var row = GetCurrentRow() as ShipmentModel.ShipmentReportRow;
            if (row.Printed > 0) ((XRLabel)sender).Text = string.Format("Copy {0}", row.Printed.ToString());
            else ((XRLabel)sender).Text = string.Empty;
        }

        private void xrLabel343_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var row = GetCurrentRow() as ShipmentModel.ShipmentReportRow;
            if (row.Printed > 0) ((XRLabel)sender).Text = string.Format("Copy {0}", row.Printed.ToString());
            else ((XRLabel)sender).Text = string.Empty;
        }

        private void xrLabel344_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var row = GetCurrentRow() as ShipmentModel.ShipmentReportRow;
            if (row.Printed > 0) ((XRLabel)sender).Text = string.Format("Copy {0}", row.Printed.ToString());
            else ((XRLabel)sender).Text = string.Empty;
        }

        private void xrLabel345_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var row = GetCurrentRow() as ShipmentModel.ShipmentReportRow;
            if (row.Printed > 0) ((XRLabel)sender).Text = string.Format("Copy {0}", row.Printed.ToString());
            else ((XRLabel)sender).Text = string.Empty;
        }
    }
}
