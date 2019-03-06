using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Helpers;
using Devenlab.Common.Interfaces;
using Devenlab.Common.WinControl.MessageBox;
using DevExpress.Data;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using SISCO.App.MasterData;
using SISCO.App.Operation;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Properties;
using SISCO.Presentation.CustomerService.Forms;
using SISCO.Presentation.MasterData.Popup;
using SISCO.Presentation.Operation.Popup;
using SISCO.Presentation.Operation.Reports;

namespace SISCO.Presentation.Operation.Forms
{
    public partial class OutboundDaratForm : BaseCrudForm<WaybillModel, WaybillDataManager>
    {
        public OutboundDaratFilterPopup Fpe = new OutboundDaratFilterPopup();
        private string ConsolidationCode { get; set; }
        private List<int> DeletedRows { get; set; }

        public OutboundDaratForm()
        {
            InitializeComponent();

            form = this;
            Load += OutboundDaratLoad;

            tbxBarcode.Leave += CheckConsolidation;

            btnAdd.Click += (sender, args) => AddRow();
            btnDelete.ButtonClick += DeleteRow;

            tbxGw.Leave += Calculate;
            tbxBarcode.KeyDown += AutocompleteCode;
            tbxCw.KeyPress += DisableDotComma;

            //Shown += (sender, args) => Top();
            WaybillDetailView.CustomColumnDisplayText += NumberGrid;
            WaybillDetailView.DoubleClick += (sender, args) =>
            {
                var rows = WaybillDetailView.GetSelectedRows();
                if (rows.Count() > 0)
                {
                    if (WaybillDetailView.GetRowCellValue(rows[0], "CustomerName").ToString().Contains("TRANSIT"))
                        return;

                    var tid = (int)WaybillDetailView.GetRowCellValue(rows[0], "CustomerId");
                    var tname = WaybillDetailView.GetRowCellValue(rows[0], "CustomerName").ToString();

                    if (tid == 0 && tname == "CONSOL")
                    {
                        var code = WaybillDetailView.GetRowCellValue(rows[0], "ShipmentCode").ToString();
                        var consolidation = new ConsolidationDataManager().GetFirst<ConsolidationModel>(WhereTerm.Default(code, "code", EnumSqlOperator.Equals));
                        if (consolidation != null) OpenRelatedForm(WaybillDetailView, new ConsolidationForm(), "ShipmentCode");
                        else OpenRelatedForm(WaybillDetailView, new ManifestForm(), "ManifestCode");
                    }
                    else OpenRelatedForm(WaybillDetailView, new TrackingViewForm(), "ShipmentCode");
                }
            };

            FormTrackingStatus = EnumTrackingStatus.Waybilled;
            DataManager.DefaultParameters = new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals) };

            tsBaseBtn_Print.Click += Print;
            tsBaseBtn_PrintPreview.Click += PrintPreview;
            btnPrint.Click += PrintDotMetrix;

            cbxCategory.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbxCategory.DataSource = new List<Combo> {new Combo{Text = ""}, new Combo{Text = "Kereta"}, new Combo{Text = "Mobil"}};
            cbxCategory.DisplayMember = "Text";
            cbxCategory.ValueMember = "Text";
            tbxBarcode.KeyUp += AutocompleteCode;

            cbxCategory.SelectedValueChanged += (sender, args) => tbxBarcode.Focus();

            WaybillDetailView.CustomSummaryCalculate += PieceCount;
        }

        private void CheckConsolidation(object sender, EventArgs e)
        {
            tbxGw.SetValue((decimal)0);
            tbxCw.SetValue((decimal)0);

            if (tbxBarcode.Text.StartsWith("CON-"))
            {
                var consolidation = new ConsolidationDataManager().GetFirst<ConsolidationModel>(WhereTerm.Default(tbxBarcode.Text, "code"));
                if (consolidation != null)
                {
                    tbxGw.SetValue(consolidation.TtlGrossWeight);
                    tbxCw.SetValue(consolidation.TtlChargeableWeight);
                }
            }
        }

        private int ValidRowCount { get; set; }
        private List<String> Dimension { get; set; }
        private void PieceCount(object sender, CustomSummaryEventArgs e)
        {
            var item = e.Item as GridColumnSummaryItem;
            var view = sender as GridView;

            if (item != null && item.FieldName == "TtlPiece")
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start)
                {
                    ValidRowCount = 0;
                    Dimension = new List<string>();
                }

                if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    if (view != null)
                    {
                        Dimension.Add(((int)Math.Ceiling((decimal)view.GetRowCellValue(e.RowHandle, "TtlChargeableWeight"))).ToString(CultureInfo.InvariantCulture));
                        if (Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, "TtlChargeableWeight")) > 0)
                            ValidRowCount++;
                    }
                }

                if (e.SummaryProcess == CustomSummaryProcess.Finalize)
                {
                    e.TotalValue = ValidRowCount;
                    tbxDimension.Text = string.Join(", ", Dimension.ToArray());
                }
            }
        }

        private string HeaderDotMetrix(int hal)
        {
            string print = File.ReadAllText(@"WaybillPrint.txt");
            print = print.Replace("{WAYBILLCODE}", ((WaybillModel)CurrentModel).Code);
            print = print.Replace("{TANGGAL}", ((WaybillModel)CurrentModel).DateProcess.ToString("d-M-yyyy HH:mm"));
            print = print.Replace("{ORIGIN}", ((WaybillModel)CurrentModel).BranchName);
            print = print.Replace("{DEST}", ((WaybillModel)CurrentModel).DestBranchName);
            print = print.Replace("{CARRIER}", ((WaybillModel)CurrentModel).EstCarrier);
            print = print.Replace("{DRIVER}", ((WaybillModel)CurrentModel).EmployeeName);
            print = print.Replace("{HAL}", hal.ToString("#"));

            return print;
        }

        private void PrintDotMetrix(object sender, EventArgs e)
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
                var dataSource = new WaybillDetailDataManager().Get<WaybillDetailModel>(WhereTerm.Default(CurrentModel.Id,
                    "waybill_id", EnumSqlOperator.Equals));
                var waybillDetailModels = dataSource as WaybillDetailModel[] ?? dataSource.ToArray();
                for (var i = 0; i < waybillDetailModels.Count(); i++)
                {
                    table += string.Format("{0} ", no.ToString("#").PadLeft(patterns[0].Length, ' '));
                    table += string.Format("{0} ", waybillDetailModels[i].ShipmentCode != null ? waybillDetailModels[i].ShipmentCode.PadRight(patterns[1].Length, ' ').Substring(0, patterns[1].Length) : " ".PadRight(patterns[1].Length, ' '));
                    table += string.Format("{0} ", waybillDetailModels[i].TtlPiece.ToString("#0").PadRight(patterns[3].Length, ' ').Substring(0, patterns[2].Length));
                    table += string.Format("{0} ", waybillDetailModels[i].ShipperName != null ? waybillDetailModels[i].ShipperName.PadRight(patterns[3].Length, ' ').Substring(0, patterns[3].Length) : " ".PadRight(patterns[3].Length, ' '));
                    table += string.Format("{0} ", waybillDetailModels[i].DestCity != null ? waybillDetailModels[i].DestCity.PadRight(patterns[4].Length, ' ').Substring(0, patterns[4].Length) : " ".PadRight(patterns[4].Length, ' '));
                    table += string.Format("{0} ", waybillDetailModels[i].TtlPiece.ToString("#0").PadRight(patterns[5].Length, ' ').Substring(0, patterns[5].Length));
                    table += string.Format("{0} ", waybillDetailModels[i].TtlGrossWeight.ToString("#0").PadRight(patterns[6].Length, ' ').Substring(0, patterns[6].Length));
                    table += string.Format("{0} ", string.Empty);
                    table += "\r\n";

                    no++;
                    row++;

                    grandPcs += waybillDetailModels[0].TtlPiece;
                    grandGw += waybillDetailModels[0].TtlGrossWeight;
                    if (row == 40)
                    {
                        print = print.Replace(result, table);

                        var regPcs = new Regex(@"<(.+?)>");
                        var gPcs = regPcs.Match(print).Groups[0].Value;
                        var regGw = new Regex(@"{(.+?)}");
                        var gGw = regGw.Match(print).Groups[0].Value;

                        print = print.Replace(gPcs, grandPcs.ToString("#").PadLeft(gPcs.Length, ' '));
                        print = print.Replace(gGw, grandGw.ToString("#").PadLeft(gGw.Length, ' '));

                        var regDriver = new Regex(@"\$(.+?)\$");
                        var gDriver = regDriver.Match(print).Groups[0].Value;

                        if (gDriver.Length > ((WaybillModel) CurrentModel).EmployeeName.Length)
                        {
                            var ls = ((WaybillModel)CurrentModel).EmployeeName.Length;
                            var s1 = gDriver.Length - ls;
                            var l1 = s1/2;
                            var r1 = l1 + (s1%2);

                            var str = ((WaybillModel)CurrentModel).EmployeeName.PadLeft(l1 + ls, ' ');
                            str = str.PadRight(r1 + str.Length, ' ');
                            print = print.Replace(gDriver, str);
                        }
                        else
                        {
                            print = print.Replace(gDriver, ((WaybillModel)CurrentModel).EmployeeName.Substring(0, gDriver.Length));
                        }

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

                        print += string.Format("{0}", (char)12);
                        print += HeaderDotMetrix(hal);
                    }
                }

                print += string.Format("{0}", (char)12);
                print = print.Replace(result, table);
                var rPcs = new Regex(@"\<(.+?)\>");
                var grnPcs = rPcs.Match(print).Groups[0].Value;
                var rGw = new Regex(@"\{(.+?)\}");
                var grdGw = rGw.Match(print).Groups[0].Value;

                print = print.Replace(grnPcs, grandPcs.ToString("#").PadLeft(grnPcs.Length, ' '));
                print = print.Replace(grdGw, grandGw.ToString("#").PadLeft(grdGw.Length, ' '));
            }

            var rDriver = new Regex(@"\$(.+?)\$");
            var gdriver = rDriver.Match(print).Groups[0].Value;

            if (gdriver.Length > ((WaybillModel)CurrentModel).EmployeeName.Length)
            {
                var ls = ((WaybillModel)CurrentModel).EmployeeName.Length;
                var s1 = gdriver.Length - ls;
                var l1 = s1 / 2;
                var r1 = l1 + (s1 % 2);

                var str = ((WaybillModel) CurrentModel).EmployeeName.PadLeft(l1 + ls, ' ');
                str = str.PadRight(r1 + str.Length, ' ');
                print = print.Replace(gdriver, str);
            }
            else
            {
                print = print.Replace(gdriver, ((WaybillModel)CurrentModel).EmployeeName.Substring(0, gdriver.Length));
            }

            if (BaseControl.UserId != null)
            {
                var user = new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default((int)BaseControl.UserId, "user_id", EnumSqlOperator.Equals));
                print = print.Replace("{PRINTED}",
                    string.Format("{0} ({1}) {2}", user.Name, user.Code, DateTime.Now.ToString("d-M-yyyy HH:mm")));
            }

            var printDialog = new PrintDialog();
            printDialog.PrinterSettings = new PrinterSettings();
            printDialog.PrinterSettings.PrinterName = BaseControl.PrinterSetting.DotMatrix;

            RawPrinterHelper.SendStringToPrinter(printDialog.PrinterSettings.PrinterName, print);
        }

        private void PrintPreview(object sender, EventArgs e)
        {
            var print = new WaybillPrint();
            using (var printTool = new ReportPrintTool(print))
            {
                print.DataSource = new WaybillDetailDataManager().Get<WaybillDetailModel>(WhereTerm.Default(CurrentModel.Id, "waybill_id", EnumSqlOperator.Equals));

                print.RequestParameters = false;
                print.Parameters.Add(new Parameter
                {
                    Name = "WaybillCode",
                    Value = ((WaybillModel)CurrentModel).Code,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Tanggal",
                    Value = ((WaybillModel)CurrentModel).DateProcess,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Origin",
                    Value = ((WaybillModel)CurrentModel).BranchName,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Dest",
                    Value = ((WaybillModel)CurrentModel).DestBranchName,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Carrier",
                    Value = ((WaybillModel)CurrentModel).EstCarrier,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Driver",
                    Value = ((WaybillModel)CurrentModel).EmployeeName,
                    Visible = false
                });

                if (BaseControl.UserId != null)
                {
                    var user = new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default((int)BaseControl.UserId, "user_id", EnumSqlOperator.Equals));
                    print.Parameters.Add(new Parameter
                    {
                        Name = "Printed",
                        Value = string.Format("{0} ({1}) {2}", user.Name, user.Code, DateTime.Now.ToString("d-M-yyyy HH:mm")),
                        Visible = false
                    });
                }

                print.CreateDocument();
                printTool.PrintingSystem.StartPrint += (o, args) =>
                {
                    args.PrintDocument.PrinterSettings.PrinterName = BaseControl.PrinterSetting.DotMatrix;
                };

                printTool.ShowPreviewDialog();
            }
        }

        private void Print(object sender, EventArgs e)
        {
            var print = new WaybillPrint();
            using (var printTool = new ReportPrintTool(print))
            {
                print.DataSource = new WaybillDetailDataManager().Get<WaybillDetailModel>(WhereTerm.Default(CurrentModel.Id, "waybill_id", EnumSqlOperator.Equals));

                print.RequestParameters = false;
                print.Parameters.Add(new Parameter
                {
                    Name = "WaybillCode",
                    Value = ((WaybillModel)CurrentModel).Code,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Tanggal",
                    Value = ((WaybillModel)CurrentModel).DateProcess,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Origin",
                    Value = ((WaybillModel)CurrentModel).BranchName,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Dest",
                    Value = ((WaybillModel)CurrentModel).DestBranchName,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Carrier",
                    Value = ((WaybillModel)CurrentModel).EstCarrier,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Driver",
                    Value = ((WaybillModel)CurrentModel).EmployeeName,
                    Visible = false
                });

                if (BaseControl.UserId != null)
                {
                    var user = new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default((int)BaseControl.UserId, "user_id", EnumSqlOperator.Equals));
                    print.Parameters.Add(new Parameter
                    {
                        Name = "Printed",
                        Value = string.Format("{0} ({1}) {2}", user.Name, user.Code, DateTime.Now.ToString("d-M-yyyy HH:mm")),
                        Visible = false
                    });
                }

                print.CreateDocument();
                printTool.PrintingSystem.StartPrint += (o, args) =>
                {
                    args.PrintDocument.PrinterSettings.PrinterName = BaseControl.PrinterSetting.DotMatrix;
                };
                printTool.Print();
            }
        }

        private void DisableDotComma(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar == 44 || e.KeyChar == 46) e.Handled = true;
        }

        private void Calculate(object sender, EventArgs e)
        {
            base.OnLeave(e);
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxCw.SetValue(tbxGw.Value.ToString());
        }

        private void AutocompleteCode(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                    if (tbxBarcode.SelectionLength > 0) return;
                if (tbxBarcode.TextLength >= 4)
                {
                    var shipment = new ShipmentDataManager().Get<ShipmentModel>(new IListParameter[]
                    {
                        WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals),
                        WhereTerm.Default(tbxBarcode.Text, "code", EnumSqlOperator.EndWith),
                        WhereTerm.Default(DateTime.Now.AddDays(-3), "date_process", EnumSqlOperator.GreatThanEqual)
                    });

                    var enumerable = shipment as ShipmentModel[] ?? shipment.ToArray();
                    if (shipment != null && !enumerable.Any())
                    {
                        var manifest = new ManifestDetailDataManager().Get<ManifestDetailModel>(new IListParameter[]
                        {
                            WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals),
                            WhereTerm.Default(tbxBarcode.Text, "consol_code", EnumSqlOperator.EndWith),
                            WhereTerm.Default(DateTime.Now.AddDays(-3), "date_process", EnumSqlOperator.GreatThanEqual)
                        });

                        if (manifest != null)
                        {
                            var manifestDetailModels = manifest as ManifestDetailModel[] ?? manifest.ToArray();
                            if (manifestDetailModels.Count() == 1)
                            {
                                var man = manifestDetailModels.First();
                                var end = tbxBarcode.TextLength;
                                tbxBarcode.Text = man.ConsolCode;
                                end = tbxBarcode.TextLength - end;
                                if (end > tbxBarcode.TextLength) end = end - 1;
                                if (end == 0) end = tbxBarcode.TextLength;
                                tbxBarcode.SelectionStart = 0;
                                tbxBarcode.SelectionLength = end;
                            }
                            else
                            {
                                var ms = (from obj in manifestDetailModels
                                    let m =
                                        new ManifestDataManager().GetFirst<ManifestModel>(
                                            WhereTerm.Default(obj.ManifestId, "id", EnumSqlOperator.Equals))
                                    let b =
                                        new BranchDataManager().GetFirst<BranchModel>(WhereTerm.Default(m.DestBranchId,
                                            "id", EnumSqlOperator.Equals))
                                    select new BarcodeList
                                    {
                                        Code = obj.ConsolCode,
                                        DateProcess = obj.DateProcess,
                                        DestBranch = b.Name
                                    }).ToList();
                                if (ms.Any())
                                {
                                    var x = ms.GroupBy(p => p.Code).Select(p => p.First()).ToList();

                                    if (x.Count == 1)
                                    {
                                        var man = x.First();
                                        var end = tbxBarcode.TextLength;
                                        tbxBarcode.Text = man.Code;
                                        end = tbxBarcode.TextLength - end;
                                        if (end > tbxBarcode.TextLength) end = end - 1;
                                        if (end == 0) end = tbxBarcode.TextLength;
                                        tbxBarcode.SelectionStart = 0;
                                        tbxBarcode.SelectionLength = end;
                                    }
                                    else
                                    {
                                        var dialogLookup = new BarcodeLookup(x);
                                        dialogLookup.ShowDialog();

                                        tbxBarcode.Text = dialogLookup.SelectedBarcode;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        var shipmentModels = shipment as ShipmentModel[] ?? enumerable.ToArray();
                        if (shipmentModels.Count() == 1)
                        {
                            var shi = shipmentModels.First();
                            var end = tbxBarcode.TextLength;
                            tbxBarcode.Text = shi.Code;
                            end = tbxBarcode.TextLength - end;
                            if (end > tbxBarcode.TextLength) end = end - 1;
                            if (end == 0) end = tbxBarcode.TextLength;
                            tbxBarcode.SelectionStart = 0;
                            tbxBarcode.SelectionLength = end;
                        }
                        else
                        {
                            var ds = (from obj in shipmentModels
                                let destBranchId = obj.DestBranchId
                                where destBranchId != null
                                let b =
                                    new BranchDataManager().GetFirst<BranchModel>(WhereTerm.Default((int) destBranchId,
                                        "id", EnumSqlOperator.Equals))
                                select new BarcodeList
                                {
                                    Code = obj.Code,
                                    DateProcess = obj.DateProcess,
                                    DestBranch = b.Name
                                }).ToList();

                            if (ds.Any())
                            {
                                var dialogLookup = new BarcodeLookup(ds);
                                dialogLookup.ShowDialog();

                                tbxBarcode.Text = dialogLookup.SelectedBarcode;
                            }
                        }
                    }
                }
            }

            base.OnKeyDown(e);
        }

        private void OutboundDaratLoad(object sender, EventArgs e)
        {
            EnableBtnSearch = true;
            SearchPopup = Fpe;

            EnableBtnPrint = false;
            EnableBtnPrintPreview = false;

            EnableBtnPrint = false;
            EnableBtnPrintPreview = false;

            Fpe.DefaultParam = new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals) };

            tbxBranch.LookupPopup = new BranchPopup();
            tbxBranch.AutoCompleteDataManager = new BranchDataManager();
            tbxBranch.AutoCompleteText = model => ((BranchModel)model).Name;
            tbxBranch.AutoCompleteDisplayFormater = model => ((BranchModel)model).Code + " - " + ((BranchModel)model).Name;
            tbxBranch.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("code = @0 OR name.StartsWith(@0)", s);

            tbxCw.EditMask = "#,#0.0";
            tbxGw.EditMask = "#,#0.0";
        }

        private void AddRow()
        {
            if (tbxBarcode.Text == string.Empty)
            {
                tbxBarcode.Focus();
                return;
            }

            if (tbxBarcode.Text.Contains("TRANSIT"))
            {
                var s = new ShipmentModel
                {
                    Id = 0,
                    DateProcess = DateTime.Now,
                    Code = tbxBarcode.Text,
                    DestCityId = 0,
                    DestCity = @"TRANSIT",
                    CustomerName = @"TRANSIT",
                    ShipperName = @"TRANSIT",
                    ConsigneeName = @"TRANSIT",
                    ServiceTypeId = 0,
                    PackageTypeId = 0,
                    PaymentMethodId = 0,
                    TtlPiece = 1,
                    TtlGrossWeight = tbxGw.Value,
                    TtlChargeableWeight = tbxCw.Value
                };

                Detail(s, new ManifestDetailModel());

                tbxBarcode.Text = string.Empty;
                tbxGw.Text = @"0";
                tbxCw.Text = @"0";
                tbxBarcode.Focus();
                return;
            }

            // ReSharper disable once RedundantAssignment
            var code = tbxBarcode.Text;
            var shipment = new ShipmentDataManager().GetFirst<ShipmentModel>(WhereTerm.Default(tbxBarcode.Text, "code", EnumSqlOperator.Equals));
            if (shipment == null)
            {
                ConsolidationCode = tbxBarcode.Text.Substring(tbxBarcode.TextLength - 3);
                code = tbxBarcode.Text.Substring(0, tbxBarcode.TextLength - 3);
                shipment = new ShipmentDataManager().GetFirst<ShipmentModel>(WhereTerm.Default(code, "code", EnumSqlOperator.Equals));

                if (shipment == null)
                {
                    ConsolidationCode = string.Empty;
                    var manifestdetail = new ManifestDetailDataManager().GetFirst<ManifestDetailModel>(WhereTerm.Default(tbxBarcode.Text, "consol_code", EnumSqlOperator.Equals));
                    if (manifestdetail != null)
                    {
                        var manifest = new ManifestDataManager().GetFirst<ManifestModel>(WhereTerm.Default(manifestdetail.ManifestId, "id", EnumSqlOperator.Equals));
                        if (manifest != null)
                        {
                            var bnc =
                                new BranchDataManager().GetFirst<BranchModel>(WhereTerm.Default(manifest.DestBranchId,
                                    "id", EnumSqlOperator.Equals));
                            var s = new ShipmentModel
                            {
                                Id = 0,
                                DateProcess = manifest.DateProcess,
                                Code = manifestdetail.ConsolCode,
                                DestBranchId = manifest.DestBranchId,
                                DestCityId = 0,
                                DestCity = bnc != null ? bnc.Code : "",
                                CustomerId = 0,
                                CustomerName = @"CONSOL",
                                ShipperName = @"CONSOL",
                                ConsigneeName = @"CONSOL",
                                ServiceTypeId = manifestdetail.ServiceTypeId != null ? (int)manifestdetail.ServiceTypeId : 0,
                                PackageTypeId = (manifestdetail.PaymentMethodId ?? 0),
                                PaymentMethodId = manifestdetail.PaymentMethodId != null ? (int)manifestdetail.PaymentMethodId : 0,
                                TtlPiece = 1,
                                TtlGrossWeight = tbxGw.Value,
                                TtlChargeableWeight = tbxCw.Value
                            };

                            Detail(s, manifestdetail);
                        }
                    }
                    else
                    {
                        var consolidation = new ConsolidationDataManager().GetFirst<ConsolidationModel>(WhereTerm.Default(tbxBarcode.Text, "code"));
                        if (consolidation != null)
                        {
                            var consolDetails = new ConsolidationDetailDataManager().Get<ConsolidationDetailModel>(WhereTerm.Default(consolidation.Id, "consolidation_id"));
                            if (consolDetails.Count() > 0)
                            {
                                var shipments = consolDetails.Select(p => p.ShipmentCode).Distinct().ToList();
                                var manifests = new ManifestDetailDataManager().IsManifested(shipments);

                                if (manifests.Count == 0) AutoClosingMessageBox.Show(Resources.empty_cn, Resources.information);
                                else
                                {
                                    foreach (var s in shipments)
                                    {
                                        if (manifests.Where(p => p.ShipmentCode == s).ToList().Count == 0)
                                        {
                                            AutoClosingMessageBox.Show(string.Format("POD {0} belum di manifest", s), Resources.information);
                                            tbxBarcode.Text = string.Empty;
                                            tbxGw.Text = @"0";
                                            tbxCw.Text = @"0";
                                            tbxBarcode.Focus();
                                            return;
                                        }
                                    }

                                    var rec = manifests.First();
                                    var bnc = new BranchDataManager().GetFirst<BranchModel>(WhereTerm.Default(rec.DestBranchId, "id", EnumSqlOperator.Equals));

                                    var data = new ShipmentModel
                                    {
                                        Id = 0,
                                        DateProcess = rec.DateProcess,
                                        Code = tbxBarcode.Text,
                                        DestBranchId = rec.DestBranchId,
                                        DestCityId = 0,
                                        DestCity = bnc != null ? bnc.Code : "",
                                        CustomerId = 0,
                                        CustomerName = @"CONSOL",
                                        ShipperName = @"CONSOL",
                                        ConsigneeName = @"CONSOL",
                                        ServiceTypeId = rec.ServiceTypeId != null ? (int)rec.ServiceTypeId : 0,
                                        PackageTypeId = (rec.PackageTypeId ?? 0),
                                        PaymentMethodId = rec.PaymentMethodId != null ? (int)rec.PaymentMethodId : 0,
                                        TtlPiece = 1,
                                        TtlGrossWeight = tbxGw.Value,
                                        TtlChargeableWeight = tbxCw.Value
                                    };

                                    Detail(data, new ManifestDetailModel());
                                }
                            }
                        }
                        //MessageBox.Show(Resources.empty_cn, Resources.information, MessageBoxButtons.OK);
                        /*
                         original
                        AutoClosingMessageBox.Show(Resources.empty_cn);
                         */
                    }
                }
            }

            if (shipment != null)
            {
                var manifested =
                    new ManifestDetailDataManager().GetFirst<ManifestDetailModel>(WhereTerm.Default(shipment.Id,
                        "shipment_id", EnumSqlOperator.Equals));

                if (manifested != null)
                {
                    shipment.TtlGrossWeight = tbxGw.Value;
                    shipment.TtlChargeableWeight = tbxCw.Value;
                    Detail(shipment, null);
                }
                else
                {
                    AutoClosingMessageBox.Show(@"POD belum di manifest");
                }
            }

            tbxBarcode.Text = string.Empty;
            tbxGw.Text = @"0";
            tbxCw.Text = @"0";
            tbxBarcode.Focus();
        }

        private void DeleteRow(object sender, ButtonPressedEventArgs e)
        {
            var dialog = MessageForm.Ask(form, Resources.delete_confirm, Resources.delete_confirm_msg);
            if (dialog == DialogResult.Yes)
            {
                var rowHandle = WaybillDetailView.FocusedRowHandle;
                if (WaybillDetailView.GetRowCellValue(rowHandle, WaybillDetailView.Columns["Id"]) != null) DeletedRows.Add((int)WaybillDetailView.GetRowCellValue(rowHandle, WaybillDetailView.Columns["Id"]));
                WaybillDetailView.DeleteSelectedRows();
            }
        }

        private bool CheckRoute(int destBranchId)
        {
            var route = new RouteDataManager().GetFirst<RouteModel>(new IListParameter[]
                    {
                        WhereTerm.Default(BaseControl.BranchId, "branch_orig_id", EnumSqlOperator.Equals),
                        // ReSharper disable once PossibleInvalidOperationException
                        WhereTerm.Default(destBranchId, "branch_dest_id", EnumSqlOperator.Equals)
                    });

            if (route != null)
            {
                if (tbxBranch.Value != null)
                {
                    if (route.BranchTransitId != tbxBranch.Value) return false;
                }
            }
            else return false;

            return true;
        }

        private void Detail(ShipmentModel shipment, ManifestDetailModel manifestDetail)
        {
            var cons = GridWaybillDetail.DataSource as List<WaybillDetailModel>;

            if (!shipment.Code.Contains("TRANSIT"))
            {
                if (cons != null)
                {
                    if (shipment.Id > 0)
                    {
                        var s = cons.Where(p => p.ShipmentCode == shipment.Code).ToList();
                        if (s.Count() == shipment.TtlPiece) return;
                    }
                    else
                    {
                        var s = cons.FirstOrDefault(b => b.ShipmentCode == shipment.Code);
                        if (s != null) return;
                    }
                }
                else cons = new List<WaybillDetailModel>();

                if (!CheckRoute((int)shipment.DestBranchId))
                {
                    if (shipment.DestBranchId == null) return;
                    if (shipment.BranchId == (int)tbxBranch.Value && shipment.DestBranchId == BaseControl.BranchId)
                    {
                        var status = new ShipmentStatusDataManager().GetFirst<ShipmentStatusModel>(new IListParameter[]
                        {
                            WhereTerm.Default(shipment.Id, "shipment_id"),
                            WhereTerm.Default((int) EnumTrackingStatus.Returned, "tracking_status_id")
                        });

                        if (status == null)
                        {
                            MessageForm.Warning(form, "POD Retur", "Untuk POD retur, mohon info ke Customer Service untuk update POD sebagai RETURN agar bisa dilakukan waybill ke Cabang pengirim.");
                            tbxBarcode.Focus();
                            tbxBarcode.Clear();
                            return;
                        }
                    }
                    else
                    {
                        MessageForm.Info(form, Resources.information,
                            string.Format(Resources.check_destination, shipment.Code));
                        return;
                    }
                }

                var airwaybilldetail =
                    new WaybillDetailDataManager().Get<WaybillDetailModel>(WhereTerm.Default(shipment.Code,
                        "shipment_code", EnumSqlOperator.Equals))
                        .Where(
                            p =>
                                p.OrigBranchIdAirwaybill == BaseControl.BranchId &&
                                p.DestBranchIdAirwaybill == tbxBranch.Value)
                        .ToList();
                if (shipment.Id > 0)
                {
                    if (shipment.TtlPiece == airwaybilldetail.Count())
                    {
                        MessageForm.Info(form, Resources.information, @"POD sudah di outbound bandara");
                        return;
                    }
                }
            }

            var detail = new WaybillDetailModel
            {
                DateProcess = DateTime.Now,
                ShipmentId = shipment.Id,
                ShipmentDate = shipment.DateProcess,
                ShipmentCode = shipment.Code,
                ConsolidationCode = ConsolidationCode,
                ConsolCode = manifestDetail != null ? manifestDetail.ConsolCode : null,
                BranchId = shipment.BranchId,
                DestCityId = shipment.DestCityId,
                DestCity = shipment.DestCity,
                CustomerId = shipment.CustomerId,
                CustomerName = shipment.CustomerName,
                ShipperName = shipment.ShipperName,
                ConsigneeName = shipment.ConsigneeName,
                ServiceTypeId = shipment.ServiceTypeId,
                PackageTypeId = shipment.PaymentMethodId,
                PaymentMethodId = shipment.PaymentMethodId,
                TtlPiece = 1,
                TtlGrossWeight = shipment.TtlGrossWeight,
                TtlChargeableWeight = shipment.TtlChargeableWeight,
                ManifestId = manifestDetail != null ? manifestDetail.ManifestId : 0,
                ManifestCode = manifestDetail != null ? manifestDetail.ManifestCode : null,
                StateChange2 = EnumStateChange.Insert.ToString()
            };

            if (cons == null)
            {
                cons = new List<WaybillDetailModel>();   
            }

            cons.Add(detail);
            GridWaybillDetail.DataSource = cons;

            WaybillDetailView.RefreshData();
            WaybillDetailView.FocusedRowHandle = WaybillDetailView.RowCount - 1;
        }

        public override void New()
        {
            base.New();

            ClearForm();
            DeletedRows = new List<int>();

            ToolbarCode = string.Empty;

            GridWaybillDetail.DataSource = null;
            WaybillDetailView.RefreshData();

            tbxDate.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            tbxNo.Focus();
        }

        public override void Save()
        {
            if (WaybillDetailView.RowCount == 0)
            {
                MessageBox.Show(
                   Resources.stt_detail_empty
                   , Resources.title_save_changes
                   , MessageBoxButtons.OK
                   , MessageBoxIcon.Information);

                return;
            }

            base.Save();
        }

        protected override void SaveDetail(bool isUpdate = false)
        {
            Enabled = false;
            var model = CurrentModel as WaybillModel;

            var totalPiece = 0;
            decimal totalGw = 0;
            decimal totalCw = 0;
            var dimension = new List<string>();

            var dataGrid = GridWaybillDetail.DataSource as List<WaybillDetailModel>;
            for (int i = 0; i < WaybillDetailView.RowCount; i++)
            {
                int rowHandle = WaybillDetailView.GetVisibleRowHandle(i);
                if (WaybillDetailView.IsDataRow(rowHandle))
                {
                    var state = WaybillDetailView.GetRowCellValue(rowHandle, WaybillDetailView.Columns["StateChange2"]);
                    if (state.ToString().Equals(EnumStateChange.Insert.ToString()))
                    {
                        var detail = new WaybillDetailModel();
                        detail.Rowstatus = true;
                        detail.Rowversion = DateTime.Now;
                        detail.WaybillId = CurrentModel.Id;
                        detail.DateProcess = DateTime.Now;
                        detail.WaybillCode = model.Code;
                        detail.ShipmentId =
                            (int)WaybillDetailView.GetRowCellValue(rowHandle, WaybillDetailView.Columns["ShipmentId"]);
                        detail.ShipmentDate =
                            (DateTime)
                                WaybillDetailView.GetRowCellValue(rowHandle, WaybillDetailView.Columns["ShipmentDate"]);
                        detail.ShipmentCode = WaybillDetailView.GetRowCellValue(rowHandle, WaybillDetailView.Columns["ShipmentCode"])
                                .ToString();

                        if (WaybillDetailView.GetRowCellValue(rowHandle, WaybillDetailView.Columns["ConsolCode"]) != null)
                            detail.ConsolCode =
                                WaybillDetailView.GetRowCellValue(rowHandle, WaybillDetailView.Columns["ConsolCode"])
                                    .ToString();

                        if (WaybillDetailView.GetRowCellValue(rowHandle,
                                WaybillDetailView.Columns["ConsolidationCode"]) != null)
                            detail.ConsolidationCode =
                                WaybillDetailView.GetRowCellValue(rowHandle,
                                    WaybillDetailView.Columns["ConsolidationCode"])
                                    .ToString();

                        detail.BranchId =
                            (int)WaybillDetailView.GetRowCellValue(rowHandle, WaybillDetailView.Columns["BranchId"]);
                        detail.DestCityId =
                            (int)WaybillDetailView.GetRowCellValue(rowHandle, WaybillDetailView.Columns["DestCityId"]);
                        detail.CustomerId =
                             WaybillDetailView.GetRowCellValue(rowHandle,
                            WaybillDetailView.Columns["CustomerId"]) != null
                            ? (int)
                                WaybillDetailView.GetRowCellValue(rowHandle,
                                    WaybillDetailView.Columns["CustomerId"])
                            : (int?)null;
                        detail.CustomerName =
                            WaybillDetailView.GetRowCellValue(rowHandle, WaybillDetailView.Columns["CustomerName"]) != null ?
                            WaybillDetailView.GetRowCellValue(rowHandle, WaybillDetailView.Columns["CustomerName"])
                            .ToString() : "";
                        detail.ShipperName =
                            WaybillDetailView.GetRowCellValue(rowHandle, WaybillDetailView.Columns["ShipperName"]) != null ?
                            WaybillDetailView.GetRowCellValue(rowHandle, WaybillDetailView.Columns["ShipperName"])
                            .ToString() : "";
                        detail.ConsigneeName =
                            WaybillDetailView.GetRowCellValue(rowHandle, WaybillDetailView.Columns["ConsigneeName"]) != null ?
                            WaybillDetailView.GetRowCellValue(rowHandle, WaybillDetailView.Columns["ConsigneeName"])
                            .ToString() : "";
                        detail.ServiceTypeId = WaybillDetailView.GetRowCellValue(rowHandle,
                            WaybillDetailView.Columns["ServiceTypeId"]) != null
                            ? (int)
                                WaybillDetailView.GetRowCellValue(rowHandle,
                                    WaybillDetailView.Columns["ServiceTypeId"])
                            : (int?)null;
                        detail.PackageTypeId =
                            WaybillDetailView.GetRowCellValue(rowHandle,
                                WaybillDetailView.Columns["PackageTypeId"]) != null
                                ? (int)
                                    WaybillDetailView.GetRowCellValue(rowHandle,
                                        WaybillDetailView.Columns["PackageTypeId"])
                                : (int?)null;
                        detail.PaymentMethodId = WaybillDetailView.GetRowCellValue(rowHandle,
                            WaybillDetailView.Columns["PaymentMethodId"]) != null
                            ? (int)
                                WaybillDetailView.GetRowCellValue(rowHandle,
                                    WaybillDetailView.Columns["PaymentMethodId"])
                            : (int?)null;
                        detail.TtlPiece =
                            (short)WaybillDetailView.GetRowCellValue(rowHandle, WaybillDetailView.Columns["TtlPiece"]);
                        detail.TtlGrossWeight =
                            (decimal)
                                WaybillDetailView.GetRowCellValue(rowHandle, WaybillDetailView.Columns["TtlGrossWeight"]);
                        detail.TtlChargeableWeight =
                            (decimal)
                                WaybillDetailView.GetRowCellValue(rowHandle,
                                    WaybillDetailView.Columns["TtlChargeableWeight"]);
                        detail.ManifestId =
                            (int)
                                WaybillDetailView.GetRowCellValue(rowHandle,
                                    WaybillDetailView.Columns["ManifestId"]);
                        if (
                            WaybillDetailView.GetRowCellValue(rowHandle,
                                WaybillDetailView.Columns["ManifestCode"]) != null)
                            detail.ManifestCode =
                                WaybillDetailView.GetRowCellValue(rowHandle,
                                    WaybillDetailView.Columns["ManifestCode"]).ToString();
                        
                        detail.Createddate = DateTime.Now;
                        detail.Createdby = BaseControl.UserLogin;

                        new WaybillDetailDataManager().Save<WaybillDetailModel>(detail);

                        if (detail.ShipmentId == 0)
                        {
                            var cekkonsole = detail.ShipmentCode.ToString().Substring(0, 3);
                            if (cekkonsole == "CON")
                            {
                                var kodekonsol = new ConsolidationDataManager().GetFirst<ConsolidationModel>(
                                                WhereTerm.Default(detail.ShipmentCode, "code", EnumSqlOperator.Equals));
                                if (kodekonsol != null)
                                {
                                    var detailkodekonsol = new ConsolidationDetailDataManager().Get<ConsolidationDetailModel>(
                                        WhereTerm.Default(kodekonsol.Id, "consolidation_id", EnumSqlOperator.Equals));
                                    foreach (var item in detailkodekonsol)
                                    {
                                        // ReSharper disable once PossibleInvalidOperationException
                                        PodStatusModel.ShipmentId = (int)item.ShipmentId;
                                        PodStatusModel.PositionStatusId = BaseControl.BranchId;
                                        PodStatusModel.PositionStatus = EnumPositionStatus.Branch.ToString();
                                        PodStatusModel.Reference = model.Code;

                                        var br =
                                        new BranchDataManager().GetFirst<BranchModel>(
                                            WhereTerm.Default(((WaybillModel)CurrentModel).DestBranchId, "id",
                                                EnumSqlOperator.Equals));

                                        var filterGrid = dataGrid.Where(x => x.ShipmentCode == detail.ShipmentCode).ToList();
                                        var tPcs = filterGrid.Sum(y => y.TtlPiece);
                                        var tGw = filterGrid.Sum(w => w.TtlGrossWeight);
                                        PodStatusModel.StatusBy = string.Format("{0} ({1})", ((WaybillModel)CurrentModel).EstCarrier, br.Code);
                                        PodStatusModel.StatusNote = string.Format("{0} koli {1} kg",
                                            tPcs,
                                            tGw);

                                        ShipmentStatusUpdate();
                                    }
                                }
                            }
                            else
                            {
                                var manifestDetail =
                                    new ManifestDetailDataManager().Get<ManifestDetailModel>(
                                        WhereTerm.Default(detail.ShipmentCode, "consol_code", EnumSqlOperator.Equals));
                                foreach (ManifestDetailModel obj in manifestDetail)
                                {
                                    InsertTracking = true;
                                    // ReSharper disable once PossibleInvalidOperationException
                                    PodStatusModel.ShipmentId = (int)obj.ShipmentId;
                                    PodStatusModel.PositionStatusId = BaseControl.BranchId;
                                    PodStatusModel.PositionStatus = EnumPositionStatus.Branch.ToString();
                                    PodStatusModel.Reference = model.Code;

                                    var br =
                                    new BranchDataManager().GetFirst<BranchModel>(
                                        WhereTerm.Default(((WaybillModel)CurrentModel).DestBranchId, "id",
                                            EnumSqlOperator.Equals));

                                    var filterGrid = dataGrid.Where(x => x.ShipmentCode == detail.ShipmentCode).ToList();
                                    var tPcs = filterGrid.Sum(y => y.TtlPiece);
                                    var tGw = filterGrid.Sum(w => w.TtlGrossWeight);
                                    PodStatusModel.StatusBy = string.Format("{0} ({1})", ((WaybillModel)CurrentModel).EstCarrier, br.Code);
                                    PodStatusModel.StatusNote = string.Format("{0} koli {1} kg",
                                        tPcs,
                                        tGw);

                                    ShipmentStatusUpdate();
                                }
                            }
                        }
                        else
                        {
                            var ship =
                                new ShipmentDataManager().GetFirst<ShipmentModel>(WhereTerm.Default(detail.ShipmentId,
                                    "id", EnumSqlOperator.Equals));
                            if (ship != null)
                            {
                                if (ship.TrackingStatusId != (int)EnumTrackingStatus.Received && ship.TrackingStatusId != (int)EnumTrackingStatus.Claimed && ship.TrackingStatusId != (int)EnumTrackingStatus.Gudang)
                                {
                                    ship.TrackingStatusId = (int)EnumTrackingStatus.Waybilled;
                                    ship.Modifiedby = BaseControl.UserLogin;
                                    ship.Modifieddate = DateTime.Now;
                                    new ShipmentDataManager().Update<ShipmentModel>(ship);
                                }

                                InsertTracking = true;
                                PodStatusModel.ShipmentId = ship.Id;
                                PodStatusModel.PositionStatusId = BaseControl.BranchId;
                                PodStatusModel.PositionStatus = EnumPositionStatus.Branch.ToString();
                                PodStatusModel.Reference = model.Code;

                                var br =
                                new BranchDataManager().GetFirst<BranchModel>(
                                    WhereTerm.Default(((WaybillModel)CurrentModel).DestBranchId, "id",
                                        EnumSqlOperator.Equals));

                                PodStatusModel.StatusBy = string.Format("{0} ({1})", ((WaybillModel)CurrentModel).EstCarrier, br.Code);
                                PodStatusModel.StatusNote = string.Format("{0} koli {1} kg",
                                    detail.TtlPiece,
                                    detail.TtlGrossWeight);

                                ShipmentStatusUpdate();
                            }
                        }
                    }

                    var temp =
                        WaybillDetailView.GetRowCellValue(rowHandle,
                            WaybillDetailView.Columns["TtlChargeableWeight"]).ToString();
                    dimension.Add(((int)Math.Ceiling(Convert.ToDecimal(temp))).ToString("#0"));
                    
                    totalPiece +=
                        (short)WaybillDetailView.GetRowCellValue(rowHandle, WaybillDetailView.Columns["TtlPiece"]);
                    totalGw +=
                        (decimal)
                            WaybillDetailView.GetRowCellValue(rowHandle, WaybillDetailView.Columns["TtlGrossWeight"]);
                    totalCw +=
                        (decimal)
                            WaybillDetailView.GetRowCellValue(rowHandle, WaybillDetailView.Columns["TtlChargeableWeight"]);
                }
            }

            var waybill = new WaybillDataManager().GetFirst<WaybillModel>(WhereTerm.Default(CurrentModel.Id, "id",
                EnumSqlOperator.Equals));
            waybill.TtlPiece = totalPiece;
            waybill.TtlGrossWeight = totalGw;
            waybill.TtlChargeableWeight = totalCw;
            waybill.Dimension = string.Join(", ", dimension.ToArray());

            new WaybillDataManager().Update<WaybillModel>(waybill);

            foreach (int o in DeletedRows)
            {
                var data = new WaybillDetailDataManager().GetFirst<WaybillDetailModel>(WhereTerm.Default(o, "id", EnumSqlOperator.Equals));
                if (data != null)
                {
                    if (data.ShipmentId == 0 && !data.ShipmentCode.Contains("TRANSIT"))
                    {
                        var manifestDetail =
                            new ManifestDetailDataManager().Get<ManifestDetailModel>(
                                WhereTerm.Default(data.ShipmentCode, "consol_code", EnumSqlOperator.Equals));
                        foreach (ManifestDetailModel obj in manifestDetail)
                        {
                            var shipmentStatus =
                                new ShipmentStatusDataManager().GetFirst<ShipmentStatusModel>(new IListParameter[]
                                {
                                    WhereTerm.Default((int) obj.ShipmentId, "shipment_id", EnumSqlOperator.Equals),
                                    WhereTerm.Default((int) EnumTrackingStatus.Waybilled, "tracking_status_id",
                                        EnumSqlOperator.Equals),
                                    WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals)
                                });

                            if (shipmentStatus != null)
                            {
                                new ShipmentStatusDataManager().DeActive(shipmentStatus.Id, BaseControl.UserLogin,
                                    DateTime.Now);
                            }
                        }
                    }
                    else
                    {
                        if (data.ShipmentId > 0)
                        {
                            var shipmentStatus =
                                new ShipmentStatusDataManager().GetFirst<ShipmentStatusModel>(new IListParameter[]
                            {
                                WhereTerm.Default(data.ShipmentId, "shipment_id", EnumSqlOperator.Equals),
                                WhereTerm.Default((int) EnumTrackingStatus.Waybilled, "tracking_status_id",
                                    EnumSqlOperator.Equals),
                                WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals)
                            });

                            if (shipmentStatus != null)
                            {
                                new ShipmentStatusDataManager().DeActive(shipmentStatus.Id, BaseControl.UserLogin,
                                    DateTime.Now);
                            }
                        }
                    }

                    new WaybillDetailDataManager().DeActive(o, BaseControl.UserLogin, DateTime.Now);
                }
            }

            Enabled = true;
            ToolbarCode = waybill.Code;
        }

        protected override void AfterSave()
        {
            OpenData(ToolbarCode);
        }

        public override void AfterDelete()
        {
            var detail = new WaybillDetailDataManager().Get<WaybillDetailModel>(WhereTerm.Default(CurrentModel.Id, "waybill_id", EnumSqlOperator.Equals));
            if (detail != null)
            {
                var repo = new WaybillDetailDataManager();
                var shipRepo = new ShipmentStatusDataManager();
                foreach (WaybillDetailModel obj in detail)
                {
                    repo.DeActive(obj.Id, BaseControl.UserLogin, DateTime.Now);
                    var shipmentStatus = shipRepo.GetFirst<ShipmentStatusModel>(new IListParameter[]
                        {
                            WhereTerm.Default(obj.ShipmentId, "shipment_id", EnumSqlOperator.Equals),
                            WhereTerm.Default((int) EnumTrackingStatus.Waybilled, "tracking_status_id", EnumSqlOperator.Equals)
                        });
                    if (shipmentStatus != null)
                    {
                        shipRepo.DeActive(shipmentStatus.Id, BaseControl.UserLogin, DateTime.Now);
                    }
                }
            }

            base.AfterDelete();
        }

        protected override bool ValidateForm()
        {
            if (tbxDate.Text != "" && tbxNo.Text != "" && tbxBranch.Value != null)
                return true;

            if (tbxDate.Text == "")
            {
                tbxDate.Focus();
                return false;
            }

            if (tbxNo.Text == "")
            {
                tbxNo.Focus();
                return false;
            }

            if (tbxBranch.Value == null)
            {
                tbxBranch.Focus();
                return false;
            }

            return false;
        }

        protected override void PopulateForm(WaybillModel model)
        {
            ClearForm();
            if (model == null) return;

            EnableBtnPrint = true;
            EnableBtnPrintPreview = true;
            DeletedRows = new List<int>();

            EnableBtnPrint = true;
            EnableBtnPrintPreview = true;

            ToolbarCode = model.Code;
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxDate.Text = model.DateProcess.ToString();
            tbxNo.Text = model.Code;
            tbxBranch.DefaultValue = new IListParameter[] { WhereTerm.Default(model.DestBranchId, "id", EnumSqlOperator.Equals) };
            tbxPengangkut.Text = model.EstCarrier;
            tbxDriver.Text = model.EmployeeName;
            tbxDimension.Text = model.Dimension;
            cbxCategory.SelectedValue = model.ActCategory ?? "";

            var details =
                new WaybillDetailDataManager().Get<WaybillDetailModel>(WhereTerm.Default(model.Id,
                    "waybill_id", EnumSqlOperator.Equals));

            GridWaybillDetail.DataSource = details;
            //ConsolidationView.RefreshData();
        }

        protected override WaybillModel PopulateModel(WaybillModel model)
        {
            model.DateProcess = tbxDate.Value;
            model.Code = tbxNo.Text;
            
            model.BranchId = BaseControl.BranchId;
            if (tbxBranch.Value != null) model.DestBranchId = (int) tbxBranch.Value;
            model.EstCarrier = tbxPengangkut.Text;
            model.EmployeeName = tbxDriver.Text;
            model.Departed = true;
            model.StatusId = (int) EnumTrackingStatus.Waybilled;
            model.ActCategory = cbxCategory.SelectedValue.ToString();

            if (model.Id == 0) model.CreatedPc = Environment.MachineName;
            else model.ModifiedPc = Environment.MachineName;

            return model;
        }

        protected override WaybillModel Find(string searchTerm)
        {
            if (!string.IsNullOrEmpty(searchTerm)) tsBaseTxt_Code.Text = searchTerm;
            var param = new IListParameter[]
                {
                    WhereTerm.Default(tsBaseTxt_Code.Text, "code", EnumSqlOperator.Equals)
                };
            var obj = DataManager.GetFirst<WaybillModel>(param);
            PopulateForm(obj);

            return obj;
        }

        public override void Info()
        {
            var model = CurrentModel as WaybillModel;

            if (model != null)
            {
                info.CreatedPc = model.CreatedPc;
                info.ModifiedPc = model.ModifiedPc;
            }

            base.Info();
        }
    }

    public class Combo
    {
        public String Text { get; set; }
    }
}