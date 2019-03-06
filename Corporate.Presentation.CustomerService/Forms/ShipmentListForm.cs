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
using Corporate.Presentation.Common;
using Corporate.Presentation.Common.Forms;
using Corporate.Presentation.MasterData.Popup;
using SISCO.App.MasterData;
using SISCO.Models;

namespace Corporate.Presentation.CustomerService.Forms
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
            btnExcel.Click += (sender, args) =>
            {
                var p = FilterVoid();

                var shipments = new ShipmentDataManager().ShipmentListExport(p);
                GridExport.DataSource = shipments;
                ExportExcel(GridExport);
            };

            GridShipment.DoubleClick += (o, args) =>
            {
                var rows = ShipmentView.GetSelectedRows();

                if (rows.Count() > 0)
                {
                    BaseControl.OpenRelatedForm(new TrackingViewForm(), ShipmentView.GetRowCellValue(rows[0], "Code").ToString(), CallingCommand);
                }
            };

            Shown += ShipmentListShow;
        }

        private void ShipmentListShow(object sender, EventArgs e)
        {
            tbxFrom.Value = DateTime.Now;
            tbxTo.Value = DateTime.Now;
        }

        private void ChangeColor(object sender, RowCellStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var view = sender as GridView;

                e.Appearance.ForeColor = Color.Black;
                if (view != null)
                {
                    if (view.GetRowCellValue(e.RowHandle, view.Columns["PODStatus"]) == null)
                        e.Appearance.ForeColor = Color.Red;
                    else if (view.GetRowCellValue(e.RowHandle, view.Columns["PODStatus"]).Equals(0))
                        e.Appearance.ForeColor = Color.Red;
                }
            }
        }

        private void LoadGrid()
        {
            if (tbxTo.Value.Subtract(tbxFrom.Value).Days > 31)
            {
                MessageBox.Show(@"Tidak bisa lebih dari 31 hari");
                return;
            }

            var p = FilterVoid();

            var shipments = new ShipmentDataManager().ShipmentList(p);
            GridShipment.DataSource = shipments;
            GridExport.DataSource = shipments;
        }

        private IListParameter[] FilterVoid()
        {
            var param = new List<WhereTerm>();
            param.Add(WhereTerm.Default(BaseControl.CorporateId, "customer_id", EnumSqlOperator.Equals));
            param.Add(WhereTerm.Default(cbxVoid.Checked, "voided"));
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse

            var dateNull = new DateTime(1900, 1, 1, 0, 0, 0);
            var fuck1 = tbxFrom.Value;
            if (fuck1 > dateNull)
            {
                var fdate = new DateTime(fuck1.Year, fuck1.Month, fuck1.Day, 0, 0, 0);
                param.Add(WhereTerm.Default(fdate, "date_process", EnumSqlOperator.GreatThanEqual));
            }

            var fuck2 = tbxTo.Value;
            if (fuck2 > dateNull)
            {
                var ldate = new DateTime(fuck2.Year, fuck2.Month, fuck2.Day, 23, 59, 59);
                param.Add(WhereTerm.Default(ldate, "date_process", EnumSqlOperator.LesThanEqual));
            }

            if (tbxDestination.Value != null) param.Add(WhereTerm.Default((int)tbxDestination.Value, "dest_city_id", EnumSqlOperator.Equals));

            IListParameter[] p = null;
            if (param.Any())
            {
                // ReSharper disable once CoVariantArrayConversion
                p = param.ToArray();
            }

            return p;
        }

        private void ShipmentListLoad(object sender, EventArgs e)
        {
            _ClearForm(panel1);

            tbxDestination.LookupPopup = new ConsigneePopup();
            tbxDestination.AutoCompleteDataManager = new CityDataManager();
            tbxDestination.AutoCompleteDisplayFormater = model => ((CityModel)model).Name;
            tbxDestination.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            tbxFrom.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            tbxTo.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            
            btnPrint.Click += Print;
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
                var dataSource = GridShipment.DataSource as List<SISCO.Models.ShipmentModel.ShipmentReportRow>;

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

                        if (BaseControl.UserId > 0)
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

            if (BaseControl.UserId > 0)
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


            customer_name = BaseControl.CorporateName;

            if (tbxDestination.Value != null)
                dest_city =
                    new CityDataManager().GetFirst<CityModel>(WhereTerm.Default((int)tbxDestination.Value, "id",
                        EnumSqlOperator.Equals)).Name;

            from_date = tbxFrom.Value.ToString("dd-MM-yyyy");
            to_date = tbxTo.Value.ToString("dd-MM-yyyy");

            print = print.Replace("{CUSTOMER_NAME}", customer_name);
            print = print.Replace("{DEST_CITY}", dest_city);
            print = print.Replace("{PAYMENT_METHOD}", payment_method);
            print = print.Replace("{FROM_DATE}", from_date);
            print = print.Replace("{TO_DATE}", to_date);
            print = print.Replace("{HAL}", hal.ToString("#").PadLeft(3, ' ') + string.Format("{0}", (char)15));

            return print;
        }
    }
}
