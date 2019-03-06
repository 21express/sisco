using System;
using System.Text;
using System.Windows.Forms;
using SISCO.App;
using System.Xml;
using SISCO.Presentation.Common;

namespace SISCO.Modal
{
    // ReSharper disable once InconsistentNaming
    public partial class MySQLSettingForm : Form
    {
        private string _g21Notifikasi;

        private bool IsCloseBtn { get; set; }
        public MySQLSettingForm()
        {
            InitializeComponent();

            tbxDBName.Capslock = false;
            tbxPassword.Capslock = false;
            tbxPort.Capslock = false;
            tbxServer.Capslock = false;
            tbxUsername.Capslock = false;

            Load += ReadXml;

            btnTestConnection.Click += TestConnection;
            btnOk.Click += WriteConnection;
            btnCancel.Click += Cancel;

            IsCloseBtn = false;
        }

        private void Cancel(object sender, EventArgs e)
        {
            IsCloseBtn = true;
            Close();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            if (IsCloseBtn) BaseControl.ExitApp = true;
        }

        private void ReadXml(object sender, EventArgs e)
        {
            using (XmlReader reader = XmlReader.Create(BaseControl.ConnAppsLocation))
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
                                tbxServer.Text = reader.ReadString();
                                reader.Read();
                            }

                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "Port")
                            {
                                tbxPort.Text = reader.ReadString();
                                reader.Read();
                            }

                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "Database")
                            {
                                tbxDBName.Text = reader.ReadString();
                                reader.Read();
                            }

                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "Username")
                            {
                                tbxUsername.Text = reader.ReadString();
                                reader.Read();
                            }

                            if (reader.NodeType == XmlNodeType.Element && reader.Name == "Password")
                            {
                                tbxPassword.Text = reader.ReadString();
                                reader.Read();
                            }
                        }
                    }
                }

                reader.Close();
            }
        }

        private void TestConnection(object sender, EventArgs e)
        {
            _g21Notifikasi = @"G21 Notifikasi";

            if (tbxServer.Text == "")
            {
                MessageBox.Show(@"Masukkan nama server atau IP address mysql.", _g21Notifikasi, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbxPort.Text == "")
            {
                MessageBox.Show(@"Masukkan port mysql.", _g21Notifikasi, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbxDBName.Text == "")
            {
                MessageBox.Show(@"Masukkan nama database.", _g21Notifikasi, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbxUsername.Text == "")
            {
                MessageBox.Show(@"Masukkan username.", _g21Notifikasi, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            var dm = new DataManager();
            try
            {
                if (dm.TestConnection(tbxServer.Text, tbxPort.Text, tbxDBName.Text, tbxUsername.Text, tbxPassword.Text))
                {
                    MessageBox.Show(@"Test Connection Succeeded", @"SISCO Information", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    btnOk.Focus();
                }
                else
                {
                    MessageBox.Show(@"Unknown database in server " + tbxServer.Text, @"SISCO Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbxServer.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"SISCO Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbxServer.Focus();
            }
        }

        private void WriteConnection(object sender, EventArgs e)
        {
            try
            {
                if (tbxServer.Text == "")
                {
                    MessageBox.Show(@"Masukkan nama server atau IP address mysql.", @"G21 Notifikasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (tbxPort.Text == "")
                {
                    MessageBox.Show(@"Masukkan port mysql.", @"G21 Notifikasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (tbxDBName.Text == "")
                {
                    MessageBox.Show(@"Masukkan nama database.", @"G21 Notifikasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (tbxUsername.Text == "")
                {
                    MessageBox.Show(@"Masukkan username.", @"G21 Notifikasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                /*using (var writer = XmlWriter.Create(@"connapps.xml"))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("MySQL");
                    writer.WriteElementString("Server", tbxServer.Text);
                    writer.WriteElementString("Port", tbxPort.Text);
                    writer.WriteElementString("Database", tbxDBName.Text);
                    writer.WriteElementString("Username", tbxUsername.Text);
                    writer.WriteElementString("Password", tbxPassword.Text);
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Flush();
                    writer.Close();

                    IsCloseBtn = false;
                }*/

                var doc = new XmlDocument();
                doc.Load(BaseControl.ConnAppsLocation);

                XmlNodeList nodes = doc.SelectNodes("/Data/MySQL/Server");
                if (nodes != null)
                    foreach (XmlElement x in nodes)
                    {
                        x.InnerText = tbxServer.Text;
                    }

                nodes = doc.SelectNodes("/Data/MySQL/Port");
                if (nodes != null)
                    foreach (XmlElement x in nodes)
                    {
                        x.InnerText = tbxPort.Text;
                    }

                nodes = doc.SelectNodes("/Data/MySQL/Database");
                if (nodes != null)
                    foreach (XmlElement x in nodes)
                    {
                        x.InnerText = tbxDBName.Text;
                    }

                nodes = doc.SelectNodes("/Data/MySQL/Username");
                if (nodes != null)
                    foreach (XmlElement x in nodes)
                    {
                        x.InnerText = tbxUsername.Text;
                    }

                nodes = doc.SelectNodes("/Data/MySQL/Password");
                if (nodes != null)
                    foreach (XmlElement x in nodes)
                    {
                        x.InnerText = tbxPassword.Text;
                    }

                using (var xtw = new XmlTextWriter(BaseControl.ConnAppsLocation, Encoding.UTF8))
                {
                    doc.WriteContentTo(xtw);
                }

                BaseControl.DatabaseSetting = new BaseControl.DatabaseSettings
                {
                    DatabaseName = tbxDBName.Text,
                    Port = tbxPort.Text,
                    Host = tbxServer.Text,
                    Username = tbxUsername.Text,
                };
            }
            catch
            {
                Dispose();
            }

            Dispose();
        }
    }
}
