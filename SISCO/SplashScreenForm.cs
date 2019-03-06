using System;
using System.Windows.Forms;
using SISCO.App;
using SISCO.Modal;
using System.Xml;
using SISCO.Presentation.Common;
using SISCO.LocalStorage;
using SISCO.App.MasterData;
using SISCO.Models;
using System.Linq;
using SISCO.Models.TransferObject;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SISCO
{
    public partial class SplashScreenForm : Form
    {
        public SplashScreenForm()
        {
            InitializeComponent();
            Shown += LoadSisco;
        }

        protected void LoadSisco(object sender, EventArgs e)
        {
            string server = string.Empty;
            string port = string.Empty;
            string database = string.Empty;
            string uid = string.Empty;
            string password = string.Empty;

            var dotMetrix = string.Empty;
            var barCode = string.Empty;
            var inkJet = string.Empty;

            using (XmlReader reader = XmlReader.Create(BaseControl.ConnAppsLocation))
            {
                //reader.MoveToContent();
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "MySQL")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "Server")
                            {
                                server = reader.ReadString();
                                reader.Read();
                            }

                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "Port")
                            {
                                port = reader.ReadString();
                                reader.Read();
                            }

                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "Database")
                            {
                                database = reader.ReadString();
                                reader.Read();
                            }

                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "Username")
                            {
                                uid = reader.ReadString();
                                reader.Read();
                            }

                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "Password")
                            {
                                password = reader.ReadString();
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

                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "BackgroundPath")
                    {
                        BaseControl.BackgroundImagePath = reader.ReadString();
                    }
                }
                reader.Close();

                # if (DEBUG)
                    dotMetrix = "EPSON LX-310 ESC/P";
                    inkJet = "EPSON44E203 (L365 Series)";
                    barCode = "TSC TTP-244 Pro";
                    server = "192.168.4.2";
                    port = "3306";
                    database = "siscodb";
                    uid = "user21-it";
                    password = "21express*";
                # endif

                BaseControl.PrinterSetting = new BaseControl.PrinterSettings
                {
                    DotMatrix = dotMetrix,
                    Barcode = barCode,
                    InkJet = inkJet
                };

                BaseControl.DatabaseSetting = new BaseControl.DatabaseSettings
                {
                    Host = server,
                    Port = port,
                    DatabaseName = database,
                    Username = uid
                };

                var dm = new DataManager();
                if (dm.TestConnection(server, port, database, uid, password))
                {
                    StoreMasterData();
                    Dispose();
                }
                else
                {
                    Hide();
                    BaseControl.ExitApp = false;
                    BaseControl.OpenForm(new MySQLSettingForm(), true);
                    if (BaseControl.ExitApp) Application.Exit();
                    else
                    {
                        Show();
                        LoadSisco(sender, e);
                    }
                }
            }

            using (XmlReader reader2 = XmlReader.Create(BaseControl.PrinterConfigLocation))
            {
                while (reader2.Read())
                {
                    if (reader2.NodeType == XmlNodeType.Element && reader2.Name == "PrinterSetting")
                    {
                        while (reader2.NodeType != XmlNodeType.EndElement)
                        {
                            reader2.Read();

                            if (reader2.NodeType == XmlNodeType.Element && reader2.Name == "DotMetrix")
                            {
                                dotMetrix = reader2.ReadString();
                                reader2.Read();
                            }
                        }
                    }
                }

                reader2.Close();

                # if (DEBUG)
                    dotMetrix = "EPSON LX-310 ESC/P";
                # endif

                BaseControl.PrinterRangkapSetting = new BaseControl.PrinterSettings
                {
                    DotMatrix = dotMetrix
                };
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