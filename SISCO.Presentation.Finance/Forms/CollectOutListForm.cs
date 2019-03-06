using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Properties;
using SISCO.Presentation.CustomerService.Forms;
using SISCO.Presentation.MasterData.Popup;
using DevExpress.XtraReports.Parameters;
using SISCO.Presentation.Finance.Report;
using DevExpress.XtraReports.UI;

namespace SISCO.Presentation.Finance.Forms
{
    public partial class CollectOutListForm : BaseForm
    {
        public CollectOutListForm()
        {
            InitializeComponent();

            form = this;
            Load += CollectOutListLoad;
            CollectOutView.CustomColumnDisplayText += NumberGrid;
            GridCollectOut.DoubleClick += (sender, args) => OpenRelatedForm(CollectOutView, new TrackingViewForm());
            btnView.Click += (sender, args) => LoadGrid();

            Shown += (sender, args) => LoadGrid();
            btnExcel.Click += (sender, args) => ExportExcel(GridCollectOut);
            btnPrint.Click += Print;
        }

        private void Print(object sender, EventArgs e)
        {
            var print = new CollectInListPrint();
            using (var printTool = new ReportPrintTool(print))
            {
                print.DataSource = GridCollectOut.DataSource;

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
                    Value = tbxBranch.Value != null ? tbxBranch.Text : "<Not Available>",
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

        private void LoadGrid()
        {
            var param = new List<WhereTerm>();
            param.Add(WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals));

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

            if (tbxBranch.Value != null)
            {
                param.Add(WhereTerm.Default((int)tbxBranch.Value, "dest_branch_id", EnumSqlOperator.Equals));
            }

            IListParameter[] p = null;
            if (param.Any())
            {
                // ReSharper disable once CoVariantArrayConversion
                p = param.ToArray();
            }

            //var detail = new ShipmentDataManager().CollectOutList(p);
            var detail = new ShipmentDataManager().ShipmentList(p);

            GridCollectOut.DataSource = detail;
            CollectOutView.RefreshData();
        }

        private void CollectOutListLoad(object sender, EventArgs e)
        {
            ClearForm();

            tbxBranch.LookupPopup = new BranchPopup();
            tbxBranch.AutoCompleteDataManager = new BranchDataManager();
            tbxBranch.AutoCompleteDisplayFormater = model => ((BranchModel)model).Code + " - " + ((BranchModel)model).Name;
            tbxBranch.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("code = @0 OR name.StartsWith(@0)", s);

            // ReSharper disable SpecifyACultureInStringConversionExplicitly
            tbxFrom.Text = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0).ToString();
            tbxTo.Text = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1).ToString();
            // ReSharper restore SpecifyACultureInStringConversionExplicitly
        }
    }
}
