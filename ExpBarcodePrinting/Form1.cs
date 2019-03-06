using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraReports.UserDesigner;

namespace ExpBarcodePrinting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var a = new FormReportPreview();
                var b = new XtraReportTabular();
                //b.DataSource = ReportDataSource.GetDataSource();
                //b.bindingSource1.Clear();
                var v = new ReportLayout("XtraReportTabular.repx");
                if (v.HasLayout)
                    b.LoadLayout(v.LayoutPath);

                var c = new ReportDataSource {ListReportModels = ReportDataSource.GetDataSource()};
                b.bindingSource1.DataSource = c;
                a.documentViewer1.DocumentSource = b;
                a.Show();
            }
            catch (Exception err)
            {
                throw;
            }
        }

        private void buttonReportDesignerRuntime_Click(object sender, EventArgs e)
        {
            var xr = new XRDesignForm();
            var b = new XtraReportTabular();
            var v = new ReportLayout("XtraReportTabular.repx");
            if (v.HasLayout)
                b.LoadLayout(v.LayoutPath);
            xr.OpenReport(b);
            xr.Show(this);
        }
    }
}
