using System;
using System.Windows.Forms;
using SISCO.App;
using SISCO.Modal;
using System.Xml;
using SISCO.Presentation.Common;

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

            using (XmlReader reader = XmlReader.Create(@"connapps.xml"))
            {
                reader.MoveToContent();
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "Server")
                    {
                        server = reader.ReadString();
                    }

                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "Port")
                    {
                        port = reader.ReadString();
                    }

                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "Database")
                    {
                        database = reader.ReadString();
                    }

                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "Username")
                    {
                        uid = reader.ReadString();
                    }

                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "Password")
                    {
                        password = reader.ReadString();
                    }
                }

                reader.Close();
                var dm = new DataManager();
                if (dm.TestConnection(server, port, database, uid, password))
                {
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
        }
    }
}
