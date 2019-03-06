using System;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Franchise.Presentation.Common;
using Franchise.Presentation.Common.Properties;
using Franchise.Presentation.Common.ViewModel;

namespace Franchise.Modal
{
    public partial class ProductKeyForm : Form
    {
        public ProductKeyForm()
        {
            InitializeComponent();
            Shown += ProductKeyShown;
            btnOk.Click += Ok;
        }

        private void Ok(object sender, EventArgs e)
        {
            if (tbxProductKey.Text == "")
            {
                MessageBox.Show(Resources.alert_empty_product_key, Resources.title_information);
                tbxProductKey.Focus();
                return;
            }

            if (string.IsNullOrEmpty(BaseControl.AccessToken)) BaseControl.GetToken();

            FranchiseViewModel franchise = BaseControl.GetProductKey(tbxProductKey.Text);
            if (franchise != null)
            {
                if (franchise.active_flag != 1)
                {
                    MessageBox.Show(Resources.inactive_product_key, Resources.title_inactive_product_key);
                    tbxProductKey.Focus();
                    return;
                }
            }
            else
            {
                BaseControl.AccessToken = string.Empty;
                MessageBox.Show(Resources.invalid_product_key, Resources.title_invalid_product_key);
                tbxProductKey.Focus();
                return;
            }

            UpdateProductKey();
            BaseControl.ExitApp = false;
            Close();
        }

        private void UpdateProductKey()
        {
            var doc = new XmlDocument();
            doc.Load(BaseControl.FranchiseConfigLocation);

            XmlNodeList nodes = doc.SelectNodes("/Data/Franchise/Guid");
            if (nodes != null)
                foreach (XmlElement x in nodes)
                {
                    x.InnerText = tbxProductKey.Text;
                }

            using (var xtw = new XmlTextWriter(BaseControl.FranchiseConfigLocation, Encoding.UTF8))
            {
                doc.WriteContentTo(xtw);
            }
        }

        private void ProductKeyShown(object sender, EventArgs e)
        {
            BaseControl.ExitApp = true;
            using (XmlReader reader = XmlReader.Create(BaseControl.FranchiseConfigLocation))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "Franchise")
                    {
                        while (reader.NodeType != XmlNodeType.EndElement)
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "Guid")
                            {
                                tbxProductKey.Text = reader.ReadString();
                                reader.Read();
                            }
                        }
                    }
                }

                reader.Close();
            }
        }
    }
}
