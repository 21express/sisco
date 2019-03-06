using System;
using System.Windows.Forms;
using System.Xml;
using Corporate.Modal;
using Corporate.Presentation.Common;
using Corporate.Presentation.Common.Properties;
using Corporate.Presentation.Common.ViewModel;
using SISCO.App;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.LocalStorage;
using Newtonsoft.Json;
using System.Collections.Generic;
using SISCO.Models.TransferObject;
using System.Linq;

namespace Corporate
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
            var corporateConfigLocation = BaseControl.CorporateConfigLocation;

            # if (DEBUG)
            var server = "192.168.0.4";
            var server2 = "192.168.0.4";
            var port = "3306";
            var database = "siscodb";
            # else
            var server = "175.103.37.40";
            var server2 = "118.97.113.234";
            var port = "3306";
            var database = "siscodb";
            # endif
            using (XmlReader reader = XmlReader.Create(corporateConfigLocation))
            {
                var dotMetrix = string.Empty;
                var barCode = string.Empty;
                var inkJet = string.Empty;

                var guid = string.Empty;
                
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "Corporate")
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

                    CorporateViewModel corporate = BaseControl.GetProductKey(guid);
                    if (corporate != null)
                    {
                        if (corporate.active_flag != 1)
                        {
                            MessageBox.Show(Resources.inactive_product_key, Resources.title_inactive_product_key);
                            EnterProductKey(sender, e);
                        }
                        else
                        {
                            BaseControl.CorporateId = corporate.id;
                            guid = guid.Replace(corporate.code, "");
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
            var cities = new CityDataManager().Get<CityModel>().ToList();
            if (cities.Count > 0) new CityServices().Save(JsonConvert.DeserializeObject<List<CityData>>(JsonConvert.SerializeObject(cities)));

            var payments = new PaymentMethodDataManager().Get<PaymentMethodModel>().ToList();
            if (payments.Count > 0) new PaymentMethodServices().Save(JsonConvert.DeserializeObject<List<PaymentMethodData>>(JsonConvert.SerializeObject(payments)));

            var packages = new PackageTypeDataManager().Get<PackageTypeModel>().ToList();
            if (packages.Count > 0) new PackageTypeServices().Save(JsonConvert.DeserializeObject<List<PackageTypeData>>(JsonConvert.SerializeObject(packages)));

            var services = new ServiceTypeDataManager().Get<ServiceTypeModel>().ToList();
            if (packages.Count > 0) new ServiceTypeServices().Save(JsonConvert.DeserializeObject<List<ServiceTypeData>>(JsonConvert.SerializeObject(services)));
        }
    }
}
