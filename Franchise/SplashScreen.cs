using System;
using System.Deployment.Application;
using System.Windows.Forms;
using System.Xml;
using Franchise.Modal;
using Franchise.Presentation.Common;
using Franchise.Presentation.Common.Properties;
using Franchise.Presentation.Common.ViewModel;
using SISCO.App;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.LocalStorage;
using Newtonsoft.Json;
using System.Linq;
using SISCO.Models.TransferObject;
using System.Collections.Generic;
using SISCO.App.Franchise;

namespace Franchise
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
            Shown += SplashShown;
        }

        private void SplashShown(object sender, EventArgs e)
        {
            var franchiseConfigLocation = BaseControl.FranchiseConfigLocation;

            var guid = string.Empty;

            using (XmlReader reader = XmlReader.Create(franchiseConfigLocation))
            {
                var dotMetrix = string.Empty;
                var barCode = string.Empty;
                var inkJet = string.Empty;

                # if (DEBUG)
                var server = "192.168.4.2";
                var server2 = "192.168.4.2";
                var port = "3306";
                var database = "siscodb";
                guid = "MtWnCZSstNa2ypKsSNDE/ROOP1LveGxbBzGH2EKjaTFNdP2eBd+xoAoAT9y/7VwpT003-JKT";
                # else
                var server = "175.103.37.40";
                var server2 = "118.97.113.234";
                var port = "3306";
                var database = "siscodb";
                
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "Franchise")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "Guid")
                            {
                                guid = reader.ReadString();
                                reader.Read();
                            }
                        }
                    }

                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "PrinterSetting")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();

                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "DotMetrix")
                            {
                                dotMetrix = reader.ReadString();
                                reader.Read();
                            }

                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "BarCodePrinter")
                            {
                                barCode = reader.ReadString();
                                reader.Read();
                            }

                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "InkJet")
                            {
                                inkJet = reader.ReadString();
                                reader.Read();
                            }
                        }
                    }
                }

                reader.Close();
                # endif

                BaseControl.PrinterSetting = new BaseControl.PrinterSettings
                {
                    DotMatrix = dotMetrix,
                    Barcode = barCode,
                    InkJet = inkJet
                };

                var dm = new DataManager();
                if (string.IsNullOrEmpty(guid))
                {
                    EnterProductKey(sender, e);
                }
                else
                {
                    if (string.IsNullOrEmpty(BaseControl.AccessToken)) BaseControl.GetToken();

                    FranchiseViewModel franchise = BaseControl.GetProductKey(guid);
                    if (franchise != null)
                    {
                        if (franchise.active_flag != 1)
                        {
                            MessageBox.Show(Resources.inactive_product_key, Resources.title_inactive_product_key);
                            EnterProductKey(sender, e);
                        }
                        else
                        {
                            BaseControl.FranchiseId = franchise.id;
                            BaseControl.FranchiseName = franchise.code;

                            guid = guid.Replace(franchise.code, "");
                            var decrypt = SymmetricCryptor.Decrypt(guid).Split('|');
                            BaseControl.DatabaseSetting = new BaseControl.DatabaseSettings
                            {
                                Host = server,
                                Port = port,
                                DatabaseName = database,
                                Username = decrypt[0]
                            };

                            var password = decrypt[1];
                            if (dm.TestConnection(BaseControl.DatabaseSetting.Host, BaseControl.DatabaseSetting.Port,
                                BaseControl.DatabaseSetting.DatabaseName, BaseControl.DatabaseSetting.Username, password))
                            {
                                StoreMasterData();
                                Dispose();
                            }
                            else
                            {
                                BaseControl.DatabaseSetting = new BaseControl.DatabaseSettings
                                {
                                    Host = server2,
                                    Port = port,
                                    DatabaseName = database,
                                    Username = decrypt[0]
                                };

                                if (dm.TestConnection(BaseControl.DatabaseSetting.Host, BaseControl.DatabaseSetting.Port,
                                BaseControl.DatabaseSetting.DatabaseName, BaseControl.DatabaseSetting.Username, password))
                                {
                                    StoreMasterData();
                                    Dispose();
                                }
                                else
                                {
                                    Hide();
                                    MessageBox.Show(string.Format("{0} {1}", Resources.application_corrupted,
                                        Resources.contact_it_support), Resources.title_information);
                                    Application.Exit();
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(Resources.invalid_product_key, Resources.title_invalid_product_key);
                        EnterProductKey(sender, e);
                    }
                }
            }
        }

        private void EnterProductKey(object sender, EventArgs e)
        {
            Hide();
            BaseControl.OpenForm(new ProductKeyForm(), true);
            if (BaseControl.ExitApp) Application.Exit();
            else
            {
                Show();
                SplashShown(sender, e);
            }
        }

        public static void StoreMasterData()
        {
            var log = new FranchiseLogModel
            {
                FranchiseId = BaseControl.FranchiseId,
                FranchiseName = BaseControl.FranchiseName,
                AppVersion = ApplicationDeployment.IsNetworkDeployed ? ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString() : "N/A",
                InsertedDate = DateTime.Now
            };
            new FranchiseLogDataManager().Save<FranchiseLogModel>(log);

            var cities = new CityDataManager().Get<CityModel>().ToList();
            if (cities.Count > 0) new CityServices().Save(JsonConvert.DeserializeObject<List<CityData>>(JsonConvert.SerializeObject(cities)));

            var countries = new CountryDataManager().Get<CountryModel>().ToList();
            if (countries.Count > 0) new CountryServices().Save(JsonConvert.DeserializeObject<List<CountryData>>(JsonConvert.SerializeObject(countries)));

            var payments = new PaymentMethodDataManager().Get<PaymentMethodModel>().ToList();
            if (payments.Count > 0) new PaymentMethodServices().Save(JsonConvert.DeserializeObject<List<PaymentMethodData>>(JsonConvert.SerializeObject(payments)));

            var packages = new PackageTypeDataManager().Get<PackageTypeModel>().ToList();
            if (packages.Count > 0) new PackageTypeServices().Save(JsonConvert.DeserializeObject<List<PackageTypeData>>(JsonConvert.SerializeObject(packages)));

            var services = new ServiceTypeDataManager().Get<ServiceTypeModel>().ToList();
            if (packages.Count > 0) new ServiceTypeServices().Save(JsonConvert.DeserializeObject<List<ServiceTypeData>>(JsonConvert.SerializeObject(services)));
        }
    }
}