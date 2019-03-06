using System;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Helpers;
using Devenlab.Common.Interfaces;
using DevExpress.Data.Linq;
using SISCO.App.MasterData;
using SISCO.App.Operation;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.CustomerService.Forms;
using SISCO.Presentation.Operation.Popup;

namespace SISCO.Presentation.Operation.Forms
{
    public partial class ManifestInViewForm : BaseCrudForm<ManifestModel, ManifestDataManager>//BaseToolbarForm//
    {
        public ManifestInViewFilterPopup Fpe = new ManifestInViewFilterPopup();
        public ManifestInViewForm()
        {
            InitializeComponent();

            form = this;
            DataManager = new ManifestDataManager();
            Load += ManifestInViewLoad;
            ManifestView.CustomColumnDisplayText += NumberGrid;
            ManifestView.DoubleClick += (sender, args) => OpenRelatedForm(ManifestView, new TrackingViewForm(), "ShipmentCode");

            DataManager.DefaultParameters = new IListParameter[]
            {WhereTerm.Default(BaseControl.BranchId, "dest_branch_id", EnumSqlOperator.Equals)};

            btnPrint.Click += Print;
        }

        private string HeaderDotMetrix(int hal)
        {
            string print = File.ReadAllText(@"ManifestPrint.txt");
            print = print.Replace("{MANIFESTCODE}", ((ManifestModel)CurrentModel).Code);
            print = print.Replace("{TANGGAL}", ((ManifestModel)CurrentModel).DateProcess.ToString("d-M-yyyy HH:mm"));
            print = print.Replace("{ORIGIN}", ((ManifestModel)CurrentModel).BranchName);
            print = print.Replace("{DEST}", ((ManifestModel)CurrentModel).DestBranch);
            print = print.Replace("{HAL}", hal.ToString("#"));

            return print;
        }

        private void Print(object sender, EventArgs e)
        {
            int hal = 1;
            string print = HeaderDotMetrix(hal);

            var reg = new Regex(@"#(.+?)#");
            var result = reg.Match(print).Groups[0].Value;

            if (result != "")
            {
                var table = string.Empty;
                var pattern = result.Replace("#", "");
                var patterns = pattern.Split(' ');

                var no = 1;
                var row = 1;
                var grandPcs = 0;
                decimal grandGw = 0;
                var dataSource = new ManifestDetailDataManager().Get<ManifestDetailModel>(WhereTerm.Default(CurrentModel.Id, "manifest_id", EnumSqlOperator.Equals));
                var manifestDetailModels = dataSource as ManifestDetailModel[] ?? dataSource.ToArray();
                for (var i = 0; i < manifestDetailModels.Count(); i++)
                {
                    table += string.Format("{0} ", no.ToString("#").PadLeft(patterns[0].Length, ' '));
                    table += string.Format("{0} ", manifestDetailModels[i].ShipperName != "" ? manifestDetailModels[i].ShipperName.Substring(0, patterns[1].Length) : "");
                    table += string.Format("{0} ", manifestDetailModels[i].ConsigneeName != "" ? manifestDetailModels[i].ConsigneeName.Substring(0, patterns[2].Length) : "");
                    table += string.Format("{0} ", manifestDetailModels[i].ShipmentCode.PadLeft(patterns[3].Length));
                    table += string.Format("{0} ", manifestDetailModels[i].DestCity != "" ? manifestDetailModels[i].DestCity.Substring(0, patterns[4].Length) : "");
                    table += string.Format("{0} ", manifestDetailModels[i].PaymentMethod != "" ? manifestDetailModels[i].PaymentMethod.Substring(0, patterns[5].Length) : "");
                    table += string.Format("{0} ", manifestDetailModels[i].PackageType != "" ? manifestDetailModels[i].PackageType.Substring(0, patterns[6].Length) : "");
                    table += string.Format("{0} ", manifestDetailModels[i].TtlPiece.ToString("#").PadLeft(patterns[7].Length, ' '));
                    table += string.Format("{0} ", manifestDetailModels[i].TtlGrossWeight.ToString("#").PadLeft(patterns[8].Length, ' '));
                    table += string.Format("{0} ", manifestDetailModels[i].ConsolCode != "" ? manifestDetailModels[i].ConsolCode.Substring(0, patterns[9].Length) : "");
                    table += "\r\n";

                    no++;
                    row++;

                    grandPcs += manifestDetailModels[0].TtlPiece;
                    grandGw += manifestDetailModels[0].TtlGrossWeight;
                    if (row == 61)
                    {
                        print = print.Replace(result, table);

                        var regPcs = new Regex(@"<(.+?)>");
                        var gPcs = regPcs.Match(print).Groups[0].Value;
                        var regGw = new Regex(@"{(.+?)}");
                        var gGw = regGw.Match(print).Groups[0].Value;

                        print = print.Replace(gPcs, grandPcs.ToString("#").PadLeft(gPcs.Length, ' '));
                        print = print.Replace(gGw, grandGw.ToString("#").PadLeft(gGw.Length, ' '));

                        if (BaseControl.UserId != null)
                        {
                            var user = new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default((int)BaseControl.UserId, "user_id", EnumSqlOperator.Equals));
                            print = print.Replace("{PRINTED}",
                                string.Format("{0} ({1}) {2}", user.Name, user.Code, DateTime.Now.ToString("d-M-yyyy HH:mm")));
                        }

                        table = string.Empty;
                        hal++;
                        row = 1;
                        grandPcs = 0;
                        grandGw = 0;

                        print += HeaderDotMetrix(hal);
                    }
                }

                print = print.Replace(result, table);
                var rPcs = new Regex(@"<(.+?)>");
                var grnPcs = rPcs.Match(print).Groups[0].Value;
                var rGw = new Regex(@"{(.+?)}");
                var grdGw = rGw.Match(print).Groups[0].Value;

                print = print.Replace(grnPcs, grandPcs.ToString("#").PadLeft(grnPcs.Length, ' '));
                print = print.Replace(grdGw, grandGw.ToString("#").PadLeft(grdGw.Length, ' '));
            }

            if (BaseControl.UserId != null)
            {
                var user = new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default((int)BaseControl.UserId, "user_id", EnumSqlOperator.Equals));
                print = print.Replace("{PRINTED}",
                    string.Format("{0} ({1}) {2}", user.Name, user.Code, DateTime.Now.ToString("d-M-yyyy HH:mm")));
            }

            var printDialog = new PrintDialog();
            printDialog.PrinterSettings = new PrinterSettings();
            printDialog.PrinterSettings.PrinterName = @"EPSON LX-300+ /II";

            RawPrinterHelper.SendStringToPrinter(printDialog.PrinterSettings.PrinterName, print);
        }

        private void ManifestInViewLoad(object sender, EventArgs e)
        {
            ClearForm();

            VisibleBtnNew = false;
            VisibleBtnDelete = false;
            VisibleBtnSave = false;

            btnPrint.Enabled = false;

            EnableBtnSearch = true;

            SearchPopup = Fpe;
            Fpe.DefaultParam = new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "dest_branch_id", EnumSqlOperator.Equals) };

            btnExcel.Click += (s, a) => ExportExcel(GridManifest);
        }

        protected override bool ValidateForm()
        {
            throw new NotImplementedException();
        }

        protected override void PopulateForm(ManifestModel model)
        {
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxDate.Text = model.DateProcess.ToString();
            tbxDate.Enabled = false;
            tbxDate.Properties.Buttons[0].Enabled = false;

            tbxFrom.ReadOnly = true;

            var branch = new BranchDataManager().GetFirst<BranchModel>(WhereTerm.Default(model.BranchId, "id", EnumSqlOperator.Equals));
            tbxFrom.Text = branch.Code + @" - " + branch.Name;
            ToolbarCode = model.Code;

            btnPrint.Enabled = true;

            var detail = new ManifestDetailDataManager().Get<ManifestDetailModel>(WhereTerm.Default(model.Id, "manifest_id", EnumSqlOperator.Equals));
            GridManifest.DataSource = detail;
            ManifestView.RefreshData();
        }

        protected override ManifestModel PopulateModel(ManifestModel model)
        {
            throw new NotImplementedException();
        }

        protected override ManifestModel Find(string searchTerm)
        {
            if (!string.IsNullOrEmpty(searchTerm)) tsBaseTxt_Code.Text = searchTerm;
            var param = new IListParameter[]
                {
                    WhereTerm.Default(tsBaseTxt_Code.Text, "code", EnumSqlOperator.Equals)
                };
            var obj = DataManager.GetFirst<ManifestModel>(param);
            PopulateForm(obj);

            return obj;
        }

        protected override void RefreshToolbarState()
        {
            base.RefreshToolbarState();

            EnableBtnRefresh = false;
        }

        public override void Info()
        {
            var model = CurrentModel as ManifestModel;
            Debug.Assert(model != null, "model != null");
            info.CreatedPc = model.CreatedPc;
            info.ModifiedPc = model.ModifiedPc;

            base.Info();
        }
    }
}