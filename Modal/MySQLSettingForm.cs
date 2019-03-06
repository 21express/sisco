using System;
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

        public MySQLSettingForm()
        {
            InitializeComponent();

            Load += ReadXml;

            btnTestConnection.Click += TestConnection;
            btnOk.Click += WriteConnection;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            BaseControl.ExitApp = true;
        }

        private void ReadXml(object sender, EventArgs e)
        {
            using (XmlReader reader = XmlReader.Create(@"connapps.xml"))
            {
                reader.MoveToContent();
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "Server")
                    {
                        tbxServer.Text = reader.ReadString();
                    }

                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "Port")
                    {
                        tbxPort.Text = reader.ReadString();
                    }

                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "Database")
                    {
                        tbxDBName.Text = reader.ReadString();
                    }

                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "Username")
                    {
                        tbxUsername.Text = reader.ReadString();
                    }

                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "Password")
                    {
                        tbxPassword.Text = reader.ReadString();
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
            if (dm.TestConnection(tbxServer.Text, tbxPort.Text, tbxDBName.Text, tbxUsername.Text, tbxPassword.Text))
                MessageBox.Show(@"Test Connection Succeeded", @"SISCO Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(@"Unknown database in server " + tbxServer.Text, @"SISCO Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void WriteConnection(object sender, EventArgs e)
        {
            try
            {
                using (var writer = XmlWriter.Create(@"connapps.xml"))
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
                }
            }
            catch
            {
                Dispose();
            }
            
            Dispose();
        }
    }
}
