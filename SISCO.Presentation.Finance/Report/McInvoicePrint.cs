using System;
using SISCO.App.MasterData;
using System.Deployment.Application;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Devenlab.Common;
using SISCO.Models;
using SISCO.Presentation.Common.Reports;
using DevExpress.XtraReports.UI;
using SISCO.Presentation.Common;

namespace SISCO.Presentation.Finance.Reports
{
    public partial class McInvoicePrint : XtraReport
    {
        public McInvoicePrint()
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
            }
            catch
            {
                throw new Exception(@"File logo perusahaan untuk POD tidak ditemukan. Simpan file logo pada folder aplikasi dengan nama ""company_logo.jpg""");
            }
        }
    }
}
