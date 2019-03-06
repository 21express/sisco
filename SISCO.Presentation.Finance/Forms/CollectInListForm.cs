using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Properties;
using SISCO.Presentation.CustomerService.Forms;
using SISCO.Presentation.Finance.Report;
using SISCO.Presentation.MasterData.Popup;

namespace SISCO.Presentation.Finance.Forms
{
    public partial class CollectInListForm : BaseForm
    {
        public CollectInListForm()
        {
            InitializeComponent();

            form = this;
            Load += CollectinListLoad;
            CollectInView.CustomColumnDisplayText += NumberGrid;
            GridCollectIn.DoubleClick += (sender, args) => OpenRelatedForm(CollectInView, new TrackingViewForm());

            btnView.Click += (sender, args) => Filter();
            Shown += CollectInShow;
            btnExcel.Click += (sender, args) => ExportExcel(GridCollectIn);

            cbxStatus.SelectedValueChanged += (sender, args) => btnView.Focus();
            btnPrint.Click += Print;
        }

        private void Print(object sender, EventArgs e)
        {
            var print = new CollectInListPrint();
            using (var printTool = new ReportPrintTool(print))
            {
                print.DataSource = GridCollectIn.DataSource;

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
                    Name = "Branch",
                    Value = tbxOrigin.Value != null ? tbxOrigin.Text : "<Not Available>",
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

        private void Filter()
        {
            var param = new List<WhereTerm>();
            param.Add(WhereTerm.Default(BaseControl.BranchId, "dest_branch_id", EnumSqlOperator.Equals));

            var collect = new PaymentMethodDataManager().GetFirst<PaymentMethodModel>(WhereTerm.Default("COLLECT", "name", EnumSqlOperator.Equals));
            param.Add(WhereTerm.Default(collect.Id, "payment_method_id", EnumSqlOperator.Equals));

            if (tbxFrom.Text == "" && tbxTo.Text == "")
            {
                MessageBox.Show(Resources.alert_empty_field, Resources.information, MessageBoxButtons.OK);
                return;
            }

            var fdate = new DateTime(tbxFrom.Value.Year, tbxFrom.Value.Month, tbxFrom.Value.Day, 0, 0, 0);
            param.Add(WhereTerm.Default(fdate, "date_process", EnumSqlOperator.GreatThanEqual));

            var ldate = new DateTime(tbxTo.Value.Year, tbxTo.Value.Month, tbxTo.Value.Day, 23, 59, 59);
            param.Add(WhereTerm.Default(ldate, "date_process", EnumSqlOperator.LesThanEqual));

            if (tbxOrigin.Value != null)
            {
                param.Add(WhereTerm.Default((int) tbxOrigin.Value, "branch_id", EnumSqlOperator.Equals));
            }

            if (cbxStatus.SelectedValue != null)
            {
                switch ((int) cbxStatus.SelectedValue)
                {
                    case 1:
                        param.Add(WhereTerm.Default("CASH", "collect_payment_method", EnumSqlOperator.Equals));
                        break;
                    case 2:
                        param.Add(WhereTerm.Default("CREDIT", "collect_payment_method", EnumSqlOperator.Equals));
                        break;
                    case 3:
                        param.Add(WhereTerm.Default("", "collect_payment_method", EnumSqlOperator.Equals));
                        break;
                }
            }

            IListParameter[] p = null;
            if (param.Any())
            {
                // ReSharper disable once CoVariantArrayConversion
                p = param.ToArray();
            }

            var detail = new ShipmentDataManager().CollectInList(p);

            GridCollectIn.DataSource = detail;
            CollectInView.RefreshData();
        }

        private void CollectInShow(object sender, EventArgs e)
        {
            tbxFrom.Focus();
        }

        private void CollectinListLoad(object sender, EventArgs e)
        {
            ClearForm();

            tbxOrigin.LookupPopup = new BranchPopup();
            tbxOrigin.AutoCompleteDataManager = new BranchDataManager();
            tbxOrigin.AutoCompleteDisplayFormater = model => ((BranchModel)model).Code + " - " + ((BranchModel)model).Name;
            tbxOrigin.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("code = @0 OR name.StartsWith(@0)", s);

            var combo = new List<Combo>();
            combo.Add(new Combo { Value = 0, Text = "Semua" });
            combo.Add(new Combo { Value = 1, Text = "Cash" });
            combo.Add(new Combo { Value = 2, Text = "Credit" });
            combo.Add(new Combo { Value = 3, Text = "Belum" });

            cbxStatus.DataSource = combo;
            cbxStatus.ValueMember = "Value";
            cbxStatus.DisplayMember = "Text";

            // ReSharper disable SpecifyACultureInStringConversionExplicitly
            tbxFrom.Text = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0).ToString();
            tbxTo.Text = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1).ToString();
            // ReSharper restore SpecifyACultureInStringConversionExplicitly
        }

        public class Combo
        {
            public int Value { get; set; }
            public string Text { get; set; }
        }
    }
}
