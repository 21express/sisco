using System;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using DevExpress.XtraEditors;
using BaseControl = Corporate.Presentation.Common.BaseControl;

namespace Corporate.Modal
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
        }

        private void UserPreferenceShown(object sender, EventArgs e)
        {
            using (XmlReader reader = XmlReader.Create(BaseControl.CorporateConfigLocation))
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
                }

                reader.Close();
            }
        }

        private void OpenPrintDialog(ButtonEdit obj)
        {
            var printdialog = new PrintDialog();
            if (obj.Text != "") printdialog.PrinterSettings.PrinterName = obj.Text;
            printdialog.ShowDialog();

            obj.Text = printdialog.PrinterSettings.PrinterName;
        }

        private void WriteXml()
        {
            var doc = new XmlDocument();
            doc.Load(BaseControl.CorporateConfigLocation);

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

            using (var xtw = new XmlTextWriter(BaseControl.CorporateConfigLocation, Encoding.UTF8))
            {
                doc.WriteContentTo(xtw);
            }

            BaseControl.PrinterSetting = new BaseControl.PrinterSettings
            {
                DotMatrix = tbxDotMetrix.Text,
                Barcode = tbxBarcode.Text,
                InkJet = tbxInkJet.Text
            };

            Close();
        }
    }
}