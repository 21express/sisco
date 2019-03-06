using Devenlab.Common;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.CustomerService.Forms;
using SISCO.Presentation.Finance.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISCO.Presentation.Finance.Forms
{
    public partial class PaymentCounterListForm : BaseForm
    {
        public PaymentCounterListForm()
        {
            InitializeComponent();

            form = this;
            Load += CashLoad;
            CashView.CustomColumnDisplayText += NumberGrid;
            GridCash.DoubleClick += (sender, args) => OpenRelatedForm(CashView, new TrackingViewForm());

            btnView.Click += (sender, args) => Filter();
            Shown += CashShow;
            btnExcel.Click += (sender, args) => ExportExcel(GridCash);

            cbxStatus.SelectedValueChanged += (sender, args) => btnView.Focus();
            btnPrint.Click += Print;
        }

        private void Print(object sender, EventArgs e)
        {
            var print = new CashListPrint();
            using (var printTool = new ReportPrintTool(print))
            {
                print.DataSource = GridCash.DataSource;

                print.RequestParameters = false;
                print.Parameters.Add(new Parameter
                {
                    Name = "From",
                    Value = tbxFrom.Value,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "To",
                    Value = tbxTo.Value,
                    Visible = false
                });

                var branch = new BranchDataManager().GetFirst<BranchModel>(WhereTerm.Default(BaseControl.BranchId, "id"));

                print.Parameters.Add(new Parameter
                {
                    Name = "BranchName",
                    Value = branch.Name,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Status",
                    Value = cbxStatus.SelectedText,
                    Visible = false
                });

                print.CreateDocument();
                printTool.PrintingSystem.StartPrint += (o, args) =>
                {
                    args.PrintDocument.PrinterSettings.PrinterName = BaseControl.PrinterSetting.InkJet;
                };
                printTool.Print();
            }
        }

        private void CashShow(object sender, EventArgs e)
        {
            tbxFrom.Focus();
        }

        private void Filter()
        {
            var data = new ShipmentDataManager().GetCashList(tbxFrom.DateTime, tbxTo.DateTime, BaseControl.BranchId);

            if (data.Count > 0)
            {
                if (cbxStatus.SelectedValue != null)
                {
                    data = data.Where(p => p.SalesType == cbxStatus.SelectedValue.ToString()).ToList();
                }
            }

            GridCash.DataSource = data;
            CashView.RefreshData();
        }

        private void CashLoad(object sender, EventArgs e)
        {
            ClearForm();

            var combo = new List<Combo>();
            combo.Add(new Combo { Value = null, Text = "Semua" });
            combo.Add(new Combo { Value = "Cash Cabang", Text = "Cash Cabang" });
            combo.Add(new Combo { Value = "Franchise", Text = "Franchise" });
            combo.Add(new Combo { Value = "Drop Point", Text = "Drop Point" });

            cbxStatus.DataSource = combo;
            cbxStatus.ValueMember = "Value";
            cbxStatus.DisplayMember = "Text";

            // ReSharper disable SpecifyACultureInStringConversionExplicitly
            tbxFrom.Text = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0).ToString();
            tbxTo.Text = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1).ToString();
        }

        public class Combo
        {
            public string Value { get; set; }
            public string Text { get; set; }
        }
    }
}
