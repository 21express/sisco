using System;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using DevExpress.XtraEditors;
using BaseControl = SISCO.Presentation.Common.BaseControl;

namespace SISCO.Modal
{
    // ReSharper disable once InconsistentNaming
    public partial class UserPreferencesForm : Form
    {
        public UserPreferencesForm()
        {
            InitializeComponent();

            Load += UserPreferenceLoad;
            Shown += UserPreferenceShown;
        }

        private void UserPreferenceLoad(object sender, EventArgs e)
        {
            btnCancel.Click += (senderx, args) => Close();
            btnOk.Click += (senderx, args) => WriteXml();

            tbxDotMetrix.ButtonClick += (o, args) => OpenPrintDialog(tbxDotMetrix);
            tbxInkJet.ButtonClick += (o, args) => OpenPrintDialog(tbxInkJet);
            tbxBarcode.ButtonClick += (o, args) => OpenPrintDialog(tbxBarcode);
            tbxRangkap4.ButtonClick += (o, args) => OpenPrintDialog(tbxRangkap4);

            txtDesktopBackground.ButtonClick += (senderx, args) =>
            {
                using (var dialog = new OpenFileDialog())
                {
                    dialog.Filter = @"Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        txtDesktopBackground.Text = dialog.FileName;
                    }
                }
            };
        }

        private void UserPreferenceShown(object sender, EventArgs e)
        {
            using (XmlReader reader = XmlReader.Create(BaseControl.ConnAppsLocation))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "PrinterSetting")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "DotMetrix")
                            {
                                tbxDotMetrix.Text = reader.ReadString();
                                reader.Read();
                            }

                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "BarCodePrinter")
                            {
                                tbxBarcode.Text = reader.ReadString();
                                reader.Read();
                            }

                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "InkJet")
                            {
                                tbxInkJet.Text = reader.ReadString();
                                reader.Read();
                            }
                        }
                    }

                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "BackgroundPath")
                    {
                        txtDesktopBackground.Text = reader.ReadString();
                    }
                }

                reader.Close();
            }

            using (XmlReader reader = XmlReader.Create(BaseControl.PrinterConfigLocation))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "PrinterSetting")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "DotMetrix")
                            {
                                tbxRangkap4.Text = reader.ReadString();
                                reader.Read();
                            }
                        }
                    }
                }

                reader.Close();
            }
        }

        private void OpenPrintDialog(ButtonEdit obj)
        {
            var printdialog = new PrintDialog();
            if (obj.Text != "") printdialog.PrinterSettings.PrinterName = obj.Text;
            printdialog.ShowNetwork = true;
            printdialog.ShowDialog();

            obj.Text = printdialog.PrinterSettings.PrinterName;
        }

        private void WriteXml()
        {
            var doc = new XmlDocument();
            doc.Load(BaseControl.ConnAppsLocation);

            XmlNodeList nodes = doc.SelectNodes("/Data/PrinterSetting/DotMetrix");
            if (nodes != null)
                foreach (XmlElement x in nodes)
                {
                    x.InnerText = tbxDotMetrix.Text;
                }

            nodes = doc.SelectNodes("/Data/PrinterSetting/BarCodePrinter");
            if (nodes != null)
                foreach (XmlElement x in nodes)
                {
                    x.InnerText = tbxBarcode.Text;
                }

            nodes = doc.SelectNodes("/Data/PrinterSetting/InkJet");
            if (nodes != null)
                foreach (XmlElement x in nodes)
                {
                    x.InnerText = tbxInkJet.Text;
                }

            nodes = doc.SelectNodes("/Data/BackgroundPath");
            if (nodes != null)
                foreach (XmlElement x in nodes)
                {
                    x.InnerText = txtDesktopBackground.Text;
                    BaseControl.BackgroundImagePath = txtDesktopBackground.Text;
                }

            using (var xtw = new XmlTextWriter(BaseControl.ConnAppsLocation, Encoding.UTF8))
            {
                doc.WriteContentTo(xtw);
            }

            BaseControl.PrinterSetting = new BaseControl.PrinterSettings
            {
                DotMatrix = tbxDotMetrix.Text,
                Barcode = tbxBarcode.Text,
                InkJet = tbxInkJet.Text
            };

            if (BaseControl.BackgroundImagePath != "")
            {
                ((MainForm) MdiParent).DesktopBackgroundImagePath = txtDesktopBackground.Text;
                ((MainForm) MdiParent).DrawBackground();
            }

            doc = new XmlDocument();
            doc.Load(BaseControl.PrinterConfigLocation);

            nodes = doc.SelectNodes("/Data/PrinterSetting/DotMetrix");
            if (nodes != null)
                foreach (XmlElement x in nodes)
                {
                    x.InnerText = tbxRangkap4.Text;
                }

            using (var xtw2 = new XmlTextWriter(BaseControl.PrinterConfigLocation, Encoding.UTF8))
            {
                doc.WriteContentTo(xtw2);
            }

            BaseControl.PrinterRangkapSetting = new BaseControl.PrinterSettings
            {
                DotMatrix = tbxRangkap4.Text
            };

            Close();
        }
    }
}