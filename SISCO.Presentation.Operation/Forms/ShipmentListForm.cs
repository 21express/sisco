using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Helpers;
using Devenlab.Common.Interfaces;
using DevExpress.XtraGrid.Views.Grid;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.CustomerService.Forms;
using SISCO.Presentation.MasterData.Popup;
using BaseControl = SISCO.Presentation.Common.BaseControl;

namespace SISCO.Presentation.Operation.Forms
{
    public partial class ShipmentListForm : BaseForm
    {
        public ShipmentListForm()
        {
            InitializeComponent();

            form = this;
            Load += ShipmentListLoad;
            btnView.Click += (sender, args) => LoadGrid();
            ShipmentView.RowCellStyle += ChangeColor;
            ShipmentView.CustomColumnDisplayText += NumberGrid;
            GridShipment.DoubleClick += (sender, args) => OpenRelatedForm(ShipmentView, new TrackingViewForm());
            btnExcel.Click += (sender, args) =>
            {
                ExportExcel(GridExport);
            };

            Shown += ShipmentListShow;
        }

        private void ChangeColor(object sender, RowCellStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var view = sender as GridView;

                e.Appearance.BackColor = Color.Transparent;
                e.Appearance.ForeColor = Color.Black;
                
                if (view != null && view.GetRowCellValue(e.RowHandle, view.Columns["PaymentMethod"]).Equals("CASH"))
                {
                    e.Appearance.ForeColor = Color.Red;
                }

                if (view != null && view.GetRowCellValue(e.RowHandle, view.Columns["PaymentMethod"]).Equals("COLLECT"))
                {
                    e.Appearance.ForeColor = Color.Green;
                }

                if (view != null && Convert.ToBoolean(view.GetRowCellValue(e.RowHandle, view.Columns["Handover"])))
                {
                    e.Appearance.BackColor = Color.Pink;
                }

                if (view != null && Convert.ToBoolean(view.GetRowCellValue(e.RowHandle, view.Columns["Posted"])))
                {
                    //e.Appearance.BackColor = Color.SeaGreen;
                    //e.Appearance.BackColor2 = Color.SeaShell;
                    e.Appearance.BackColor = Color.Lavender;
                }
            }
        }

        private void ShipmentListShow(object sender, EventArgs e)
        {
            tbxFrom2.Value = DateTime.Now;
            tbxTo2.Value = DateTime.Now;
        }

        private void ShipmentListLoad(object sender, EventArgs e)
        {
            _ClearForm(pnlTop);

            tbxDestination.LookupPopup = new CityPopup();
            tbxDestination.AutoCompleteDataManager = new CityDataManager();
            tbxDestination.AutoCompleteDisplayFormater = model => ((CityModel)model).Name;
            tbxDestination.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            tbxDestBranch.LookupPopup = new BranchPopup();
            tbxDestBranch.AutoCompleteDataManager = new BranchDataManager();
            tbxDestBranch.AutoCompleteDisplayFormater = model => ((BranchModel)model).Code + " " + ((BranchModel)model).Name;
            tbxDestBranch.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("code = @0 OR name.StartsWith(@0)", s);

            tbxCustomer.LookupPopup = new CustomerPopup(new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals) });
            tbxCustomer.AutoCompleteDataManager = new CustomerDataManager();
            //tbxCustomer.AutoCompleteText = model => ((CustomerModel)model).Name;
            tbxCustomer.AutoCompleteDisplayFormater = model => ((CustomerModel)model).Code + " - " + ((CustomerModel)model).Name;
            tbxCustomer.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("code = @0 OR name.StartsWith(@0) AND branch_id = @1", s, BaseControl.BranchId);

            tbxPayment.LookupPopup = new PaymentMethodPopup();
            tbxPayment.AutoCompleteDataManager = new PaymentMethodDataManager();
            tbxPayment.AutoCompleteDisplayFormater = model => ((PaymentMethodModel)model).Name;
            tbxPayment.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            tbxEmployee.LookupPopup = new EmployeePopup();
            tbxEmployee.AutoCompleteDataManager = new EmployeeDataManager();
            tbxEmployee.AutoCompleteDisplayFormater = model => ((EmployeeModel)model).Code + " - " + ((EmployeeModel)model).Name;
            tbxEmployee.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("code = @0 OR name.StartsWith(@0) AND branch_id = @1", s, BaseControl.BranchId);

            tbxFrom2.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            tbxTo2.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);

            btnPrint.Click += Print;
        }

        private string HeaderDotMetrix(int hal)
        {
            string print = File.ReadAllText(@"ShipmentListPrint.txt");

            // ReSharper disable InconsistentNaming
            var customer_name = "-";
            var dest_city = "-";
            var payment_method = "-";
            var from_date = "-";
            var to_date = "-";
            // ReSharper restore InconsistentNaming

            if (tbxCustomer.Value != null)
                customer_name =
                    new CustomerDataManager().GetFirst<CustomerModel>(WhereTerm.Default((int)tbxCustomer.Value, "id",
                        EnumSqlOperator.Equals)).Name;

            if (tbxDestination.Value != null)
                dest_city =
                    new CityDataManager().GetFirst<CityModel>(WhereTerm.Default((int)tbxDestination.Value, "id",
                        EnumSqlOperator.Equals)).Name;

            if (tbxPayment.Value != null)
                payment_method =
                    new PaymentMethodDataManager().GetFirst<PaymentMethodModel>(WhereTerm.Default((int)tbxPayment.Value, "id",
                        EnumSqlOperator.Equals)).Name;

            from_date = tbxFrom2.Value.ToString("dd-MM-yyyy");
            to_date = tbxTo2.Value.ToString("dd-MM-yyyy");
            
            print = print.Replace("{CUSTOMER_NAME}", customer_name);
            print = print.Replace("{DEST_CITY}", dest_city);
            print = print.Replace("{PAYMENT_METHOD}", payment_method);
            print = print.Replace("{FROM_DATE}", from_date);
            print = print.Replace("{TO_DATE}", to_date);
            print = print.Replace("{HAL}", hal.ToString("#").PadLeft(3, ' ') + string.Format("{0}", (char)15));

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
                decimal grandTtl = 0;
                var dataSource = GridShipment.DataSource as List<ShipmentRowModel>;
                
                for (var i = 0; i < dataSource.Count(); i++)
                {
                    table += string.Format("{0} ", no.ToString("#").PadLeft(patterns[0].Length, ' '));
                    table += string.Format("{0} ", dataSource[i].Code != null ? dataSource[i].Code.PadRight(patterns[1].Length, ' ').Substring(0, patterns[1].Length) : " ".PadRight(patterns[1].Length, ' '));
                    table += string.Format("{0} ", dataSource[i].DateProcess != null ? dataSource[i].DateProcess.ToString("dd-MM-yyyy").PadRight(patterns[2].Length, ' ').Substring(0, patterns[2].Length) : " ".PadRight(patterns[2].Length, ' '));
                    table += string.Format("{0} ", dataSource[i].ShipperName != null ? dataSource[i].ShipperName.PadRight(patterns[3].Length, ' ').Substring(0, patterns[3].Length) : " ".PadRight(patterns[3].Length, ' '));
                    table += string.Format("{0} ", dataSource[i].ConsigneeName != null ? dataSource[i].ConsigneeName.PadRight(patterns[4].Length, ' ').Substring(0, patterns[4].Length) : " ".PadRight(patterns[4].Length, ' '));
                    table += string.Format("{0} ", dataSource[i].DestCity != null ? dataSource[i].DestCity.PadRight(patterns[5].Length, ' ').Substring(0, patterns[5].Length) : " ".PadRight(patterns[5].Length, ' '));
                    table += string.Format("{0} ", dataSource[i].PaymentMethod != null ? dataSource[i].PaymentMethod.PadRight(patterns[6].Length, ' ').Substring(0, patterns[6].Length) : " ".PadRight(patterns[6].Length, ' '));
                    table += string.Format("{0} ", dataSource[i].PackageType != null ? dataSource[i].PackageType.PadRight(patterns[7].Length, ' ').Substring(0, patterns[7].Length) : " ".PadRight(patterns[7].Length, ' '));
                    table += string.Format("{0} ", dataSource[i].TtlPiece.ToString("#0").PadLeft(patterns[8].Length, ' '));
                    table += string.Format("{0} ", dataSource[i].TtlGrossWeight.ToString("#0").PadLeft(patterns[9].Length, ' '));
                    table += string.Format("{0} ", dataSource[i].Total > 0 ? dataSource[i].Total.ToString("#,#0").PadLeft(patterns[10].Length, ' ').Substring(0, patterns[10].Length) : " ".PadRight(patterns[10].Length, ' '));
                    table += "\n";

                    no++;
                    row++;

                    grandPcs += dataSource[i].TtlPiece;
                    grandGw += dataSource[i].TtlGrossWeight;
                    grandTtl += dataSource[i].Total;
                    if (row == 55)
                    {
                        print = print.Replace(result, table);

                        var regPcs = new Regex(@"<(.+?)>");
                        var gPcs = regPcs.Match(print).Groups[0].Value;
                        var regGw = new Regex(@"{(.+?)}");
                        var gGw = regGw.Match(print).Groups[0].Value;
                        var regTtl = new Regex(@"\|(.+?)\|");
                        var gTtl = regTtl.Match(print).Groups[0].Value;

                        print = print.Replace(gPcs, grandPcs.ToString("#0").PadLeft(gPcs.Length, ' '));
                        print = print.Replace(gGw, grandGw.ToString("#0").PadLeft(gGw.Length, ' '));
                        print = print.Replace(gTtl, grandTtl.ToString("#,#0").PadLeft(gTtl.Length, ' '));

                        if (BaseControl.UserId != null)
                        {
                            var user = new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default((int)BaseControl.UserId, "user_id", EnumSqlOperator.Equals));
                            print = print.Replace("{PRINTED}",
                                string.Format("{0} ({1}) {2}", user.Name, user.Code, DateTime.Now.ToString("d-M-yyyy HH:mm")) +
                                string.Format("{0}", (char)18));
                        }

                        table = string.Empty;
                        hal++;
                        row = 1;
                        grandPcs = 0;
                        grandGw = 0;
                        grandTtl = 0;

                        print += string.Format("{0}", (char)12);
                        print += HeaderDotMetrix(hal);
                    }
                }

                print = print.Replace(result, table);
                var rPcs = new Regex(@"<(.+?)>");
                var grnPcs = rPcs.Match(print).Groups[0].Value;
                var rGw = new Regex(@"{(.+?)}");
                var grdGw = rGw.Match(print).Groups[0].Value;
                var rTtl = new Regex(@"\|(.+?)\|");
                var grdTtl = rTtl.Match(print).Groups[0].Value;

                print = print.Replace(grnPcs, grandPcs.ToString("#0").PadLeft(grnPcs.Length, ' '));
                print = print.Replace(grdGw, grandGw.ToString("#0").PadLeft(grdGw.Length, ' '));
                print = print.Replace(grdTtl, grandTtl.ToString("#,#0").PadLeft(grdTtl.Length, ' '));
            }

            if (BaseControl.UserId != null)
            {
                var user = new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default((int)BaseControl.UserId, "user_id", EnumSqlOperator.Equals));
                print = print.Replace("{PRINTED}",
                    string.Format("{0} ({1}) {2}", user.Name, user.Code, DateTime.Now.ToString("d-M-yyyy HH:mm")) +
                    string.Format("{0}", (char)18));
            }

            var printDialog = new PrintDialog();
            printDialog.PrinterSettings = new PrinterSettings();
            printDialog.PrinterSettings.PrinterName = BaseControl.PrinterSetting.DotMatrix;

            RawPrinterHelper.SendStringToPrinter(printDialog.PrinterSettings.PrinterName, print);
        }

        private IListParameter[] FilterVoid()
        {
            var param = new List<WhereTerm>();
            param.Add(WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals));
            param.Add(WhereTerm.Default(chbVoid.Checked, "voided"));
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse

            var dateNull = new DateTime(1900, 1, 1, 0, 0, 0);
            var fuck1 = tbxFrom2.Value;
            if (fuck1 > dateNull)
            {
                var fdate = new DateTime(fuck1.Year, fuck1.Month, fuck1.Day, 0, 0, 0);
                param.Add(WhereTerm.Default(fdate, "date_process", EnumSqlOperator.GreatThanEqual));
            }

            var fuck2 = tbxTo2.Value;
            if (fuck2 > dateNull)
            {
                var ldate = new DateTime(fuck2.Year, fuck2.Month, fuck2.Day, 23, 59, 59);
                param.Add(WhereTerm.Default(ldate, "date_process", EnumSqlOperator.LesThanEqual));
            }

            if (tbxCustomer.Value != null) param.Add(WhereTerm.Default((int)tbxCustomer.Value, "customer_id", EnumSqlOperator.Equals));
            if (tbxDestination.Value != null) param.Add(WhereTerm.Default((int)tbxDestination.Value, "dest_city_id", EnumSqlOperator.Equals));
            if (tbxDestBranch.Value != null) param.Add(WhereTerm.Default((int)tbxDestBranch.Value, "dest_branch_id", EnumSqlOperator.Equals));
            if (tbxPayment.Value != null) param.Add(WhereTerm.Default((int)tbxPayment.Value, "payment_method_id", EnumSqlOperator.Equals));
            if (tbxEmployee.Value != null)
            {
                var empl = new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default((int)tbxEmployee.Value, "id", EnumSqlOperator.Equals));
                param.Add(WhereTerm.Default(empl.Code, "data_entry_employee", EnumSqlOperator.Equals));
            }

            IListParameter[] p = null;
            if (param.Any())
            {
                // ReSharper disable once CoVariantArrayConversion
                p = param.ToArray();
            }

            return p;
        }

        private void LoadGrid()
        {
            if (tbxTo2.Value.Subtract(tbxFrom2.Value).Days > 31)
            {
                MessageBox.Show(@"Tidak bisa lebih dari 31 hari");
                return;
            }

            var p = FilterVoid();

            var shipments = new ShipmentDataManager().ShipmentList(p);
            GridShipment.DataSource = shipments;
            GridExport.DataSource = shipments;
        }

        private void chbVoid_CheckedChanged(object sender, EventArgs e)
        {
            btnView.Focus();
        }
    }
}