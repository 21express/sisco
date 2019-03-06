using System;
using System.Collections.Generic;
using System.Linq.Dynamic;
using System.Windows.Forms;
using Devenlab.Common;
using DevExpress.XtraReports.UI;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Operation.Reports;

namespace SISCO.Presentation.Operation.Forms
{
    public partial class OnboardReportViewForm : BaseForm
    {
        public OnboardReportViewForm()
        {
            InitializeComponent();

            form = this;
            DataManager = new AirwaybillDataManager();
            Load += OnboardViewLoad;
            OnboardView.CustomColumnDisplayText += NumberGrid;
            OnboardView.DoubleClick += (sender, args) =>
            {
                var rows = OnboardView.GetSelectedRows();

                if (rows.Count() > 0)
                {
                    var date = (DateTime) OnboardView.GetRowCellValue(rows[0], "DateProcess");
                    var code = OnboardView.GetRowCellValue(rows[0], "Code").ToString();
                    var x = new OnboardReportForm(date, code);

                    FormCollection fc = Application.OpenForms;
            
                    foreach (Form frm in fc)
                    {
                        if (frm.Name == "MainForm")
                        {
                            x.MdiParent = frm;
                            break;
                        }
                    }

                    x.Show();
                }
            };
            tbxDate.TextChanged += (sender, args) => LoadGrid();
            btnExcel.Click += (sender, args) => ExportExcel(GridOnboard);

            btnPrintPreview.Click += PrintPreview;
            btnPrint.Click += Print;
        }

        private void Print(object sender, EventArgs e)
        {
            var print = new OnboardPrint();
            using (var printTool = new ReportPrintTool(print))
            {
                var param = new List<WhereTerm>();

                var fdate = new DateTime(tbxDate.Value.Year, tbxDate.Value.Month, tbxDate.Value.Day, 0, 0, 0);
                param.Add(WhereTerm.Default(fdate, "date_process", EnumSqlOperator.GreatThanEqual));

                var ldate = new DateTime(tbxDate.Value.Year, tbxDate.Value.Month, tbxDate.Value.Day, 23, 59, 59);
                param.Add(WhereTerm.Default(ldate, "date_process", EnumSqlOperator.LesThanEqual));

                // ReSharper disable once CoVariantArrayConversion
                print.DataSource = DataManager.Get<AirwaybillModel>(param.ToArray());

                print.CreateDocument();
                printTool.Print();
            }
        }

        private void PrintPreview(object sender, EventArgs e)
        {
            var print = new OnboardPrint();
            using (var printTool = new ReportPrintTool(print))
            {
                var param = new List<WhereTerm>();

                var fdate = new DateTime(tbxDate.Value.Year, tbxDate.Value.Month, tbxDate.Value.Day, 0, 0, 0);
                param.Add(WhereTerm.Default(fdate, "date_process", EnumSqlOperator.GreatThanEqual));

                var ldate = new DateTime(tbxDate.Value.Year, tbxDate.Value.Month, tbxDate.Value.Day, 23, 59, 59);
                param.Add(WhereTerm.Default(ldate, "date_process", EnumSqlOperator.LesThanEqual));

                // ReSharper disable once CoVariantArrayConversion
                print.DataSource = DataManager.Get<AirwaybillModel>(param.ToArray());

                print.CreateDocument();
                printTool.ShowPreviewDialog();
            }
        }

        private void OnboardViewLoad(object sender, EventArgs e)
        {
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxDate.Text = DateTime.Now.ToString();
        }

        private void LoadGrid()
        {
            var param = new List<WhereTerm>();

            param.Add(WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals));
            var fdate = new DateTime(tbxDate.Value.Year, tbxDate.Value.Month, tbxDate.Value.Day, 0, 0, 0);
            param.Add(WhereTerm.Default(fdate, "date_process", EnumSqlOperator.GreatThanEqual));

            var ldate = new DateTime(tbxDate.Value.Year, tbxDate.Value.Month, tbxDate.Value.Day, 23, 59, 59);
            param.Add(WhereTerm.Default(ldate, "date_process", EnumSqlOperator.LesThanEqual));


            // ReSharper disable once CoVariantArrayConversion
            var airwaybill = DataManager.Get<AirwaybillModel>(param.ToArray());

            if (airwaybill.Any())
            {
                btnPrint.Enabled = true;
                btnPrintPreview.Enabled = true;
            }
            else
            {
                btnPrint.Enabled = false;
                btnPrintPreview.Enabled = false;
            }

            GridOnboard.DataSource = airwaybill;
        }
    }
}
