using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Deployment.Application;
using System.IO;
using System.Xml;
using SISCO.App;
using SISCO.App.MasterData;
using SISCO.Models;
using BarcodeMachine.Popup;
using BarcodeMachine.Class;
using Devenlab.Common;
using BarcodeMachine.Print;
using DevExpress.XtraReports.UI;

namespace BarcodeMachine
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        private Timer _timer { get; set; }
        private Panel _activeContainer { get; set; }
        private Panel _nextContainer { get; set; }
        private bool _start { get; set; }
        private int _x { get; set; }

        private string server { get; set; }
        private string port { get; set; }
        private string database { get; set; }
        private string uid { get; set; }
        private string password { get; set; }
        private string barCode { get; set; }
        private bool _connected { get; set; }

        private string _connAppsLocation = "appconfig.xml";
        public string ConnAppsLocation
        {
            get
            {
                if (!ApplicationDeployment.IsNetworkDeployed)
                {
                    return _connAppsLocation;
                }

                var localConnAppsLocation = Path.Combine(ApplicationDeployment.CurrentDeployment.DataDirectory, _connAppsLocation);

                if (!File.Exists(localConnAppsLocation))
                {
                    File.Copy(_connAppsLocation, localConnAppsLocation);
                }

                return localConnAppsLocation;
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _start = true;
            HidePanel();
            _timer = new Timer
            {
                Enabled = false,
                Interval = 1
            };

            _timer.Tick += _timer_Tick;
            LoadXml();

            #region Printer Event
            tbxPrinter.ButtonClick += tbxPrinter_ButtonClick;
            btnPrintClose.Click += btnPrintClose_Click;
            btnPrintOk.Click += btnPrintOk_Click;
            #endregion

            #region Print Barcode Kurir Event
            tbxPcs.EditMask = "#,##0";
            lkpMessenger.LookupPopup = new MessengerPopup();
            lkpMessenger.AutoCompleteDataManager = new EmployeeDataManager();
            lkpMessenger.AutoCompleteDisplayFormater = model => ((EmployeeModel)model).Code + " - " + ((EmployeeModel)model).Name;
            lkpMessenger.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND as_messenger AND branch_id = @1", s, 24);

            btnPrint.Click += btnPrint_Click;
            btnBarcodeClose.Click += btnBarcodeClose_Click;
            #endregion
        }

        private void LoadXml()
        {
            using (XmlReader reader = XmlReader.Create(ConnAppsLocation))
            {
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

                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "BarCodePrinter")
                            {
                                barCode = reader.ReadString();
                                reader.Read();
                            }
                        }
                    }
                }
                reader.Close();
            }

            # if (DEBUG)
            server = "192.168.4.2";
            port = "3306";
            database = "siscodb";
            uid = "user21-it";
            password = "21express*";
            # endif

            var dm = new DataManager();
            _connected = dm.TestConnection(server, port, database, uid, password);
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            if (_activeContainer == _nextContainer)
            {
                _timer.Enabled = false;
                return;
            }

            if (_start)
            {
                _x = 1;
                _nextContainer.BringToFront();
                _nextContainer.Location = new Point(_nextContainer.Location.X - _nextContainer.Width - 6, _nextContainer.Location.Y);
                _nextContainer.Visible = true;

                _start = false;
            }

            _nextContainer.Location = new Point(_nextContainer.Location.X + _x, _nextContainer.Location.Y);

            _x++;

            if (_nextContainer.Location.X > 6)
            {
                if (_activeContainer != null) _activeContainer.Visible = false;

                _nextContainer.Location = new Point(6, _nextContainer.Location.Y);
                _activeContainer = _nextContainer;
                _activeContainer.Width = pnlMain.Width - 10;

                _start = true;
                _timer.Enabled = false;
            }
        }

        private void HidePanel()
        {
            pnlPrinter.Visible = false;
            pnlPrinter.Location = new Point(pnlMain.Location.X - pnlPrinter.Width, pnlPrinter.Location.Y);
        }

        private void dbStrip_Click(object sender, EventArgs e)
        {
            MessageBox.Show("asdf");
        }

        #region Printer

        void tbxPrinter_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var printdialog = new PrintDialog();
            if (tbxPrinter.Text != "") printdialog.PrinterSettings.PrinterName = tbxPrinter.Text;

            printdialog.ShowNetwork = true;
            printdialog.ShowDialog();

            tbxPrinter.Text = printdialog.PrinterSettings.PrinterName;
        }

        private void navPrinter_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _nextContainer = pnlPrinter;
            _timer.Enabled = true;
        }

        private void pnlPrinter_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlPrinter.Visible)
            {
                tbxPrinter.Text = barCode;
            }
        }

        void btnPrintClose_Click(object sender, EventArgs e)
        {
            pnlPrinter.Hide();
            _activeContainer = null;
        }

        void btnPrintOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxPrinter.Text))
            {
                MessageBox.Show("Silakan pilih printer barcode.");
                tbxPrinter.Focus();
                return;
            }

            var doc = new XmlDocument();
            doc.Load(ConnAppsLocation);

            XmlNodeList nodes = doc.SelectNodes("/Data/PrinterSetting/BarCodePrinter");
            if (nodes != null)
                foreach (XmlElement x in nodes)
                {
                    x.InnerText = tbxPrinter.Text;
                }

            using (var xtw = new XmlTextWriter(ConnAppsLocation, Encoding.UTF8))
            {
                doc.WriteContentTo(xtw);
            }

            MessageBox.Show("Konfigurasi berhasil disimpan.");

            barCode = tbxPrinter.Text;
        }
        #endregion

        #region Print Barcode Kurir
        private void navKurir_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _nextContainer = pnlKurir;
            _timer.Enabled = true;
        }

        private void pnlKurir_VisibleChanged(object sender, EventArgs e)
        {
            lblWarning.Visible = !_connected;
            lkpMessenger.Enabled = _connected;
            lkpMessenger.Properties.Buttons[0].Enabled = _connected;
            btnPrint.Enabled = _connected;
        }

        void btnPrint_Click(object sender, EventArgs e)
        {
            if (lkpMessenger.Value == null || string.IsNullOrEmpty(tbxPcs.Text))
            {
                MessageBox.Show("Silakan pilih kurir dan total koli.");
                lkpMessenger.Focus();

                return;
            }

            var barcode = new List<CourierBarcode>();

            var nums = Convert.ToInt32(tbxPcs.Text);

            var messenger = new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default((int) lkpMessenger.Value, "id"));
            if (messenger == null)
            {
                MessageBox.Show("Kurir tidak dikenali.");
                lkpMessenger.Focus();
                return;
            }

            for (var i = 1; i <= nums; i++ )
            {
                barcode.Add(new CourierBarcode
                {
                    MessengerCode = messenger.Code,
                    MessengerName = messenger.Name,
                    PickupDate = DateTime.Now
                });
            }

            var a = new MessengerBarcodePrint();
            a.DataSource = barcode;
            a.CreateDocument();

            var printTool = new ReportPrintTool(a);
            printTool.PrintingSystem.StartPrint += (o, args) =>
            {
                args.PrintDocument.PrinterSettings.PrinterName = barCode;
            };
            printTool.Print();
        }

        void btnBarcodeClose_Click(object sender, EventArgs e)
        {
            pnlKurir.Hide();
            _activeContainer = null;
        }
        #endregion
    }
}