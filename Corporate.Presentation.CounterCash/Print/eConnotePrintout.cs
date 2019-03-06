using System;
using System.Deployment.Application;
using System.Drawing;
using System.IO;
using Corporate.Presentation.Common.Report;
using SISCO.Models;

namespace Corporate.Presentation.CounterCash.Print
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
            catch (Exception e)
            {
                throw new Exception(@"File logo perusahaan untuk POD tidak ditemukan. Simpan file logo pada folder aplikasi dengan nama ""company_logo.jpg""");
            }
        }
    }
}
