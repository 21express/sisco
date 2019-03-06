using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Helpers;
using Devenlab.Common.Interfaces;
using Devenlab.Common.WinControl.MessageBox;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using SISCO.App.MasterData;
using SISCO.App.Operation;
using SISCO.Models;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Properties;
using SISCO.Presentation.CustomerService.Forms;
using SISCO.Presentation.MasterData.Popup;
using SISCO.Presentation.Operation.Popup;
using SISCO.Presentation.Operation.Reports;
using BaseControl = SISCO.Presentation.Common.BaseControl;

namespace SISCO.Presentation.Operation.Forms
{
    public partial class ManifestForm : BaseCrudForm<ManifestModel, ManifestDataManager>//BaseToolbarForm//
    {
        private string Code { get; set; }
        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        // ReSharper disable once InconsistentNaming
        private ManifestFilterPopup Fpe = new ManifestFilterPopup();
        private List<int> DeletedRows { get; set; }

        public ManifestForm()
        {
            InitializeComponent();
            
            form = this;
            Load += ManifestLoad;
            btnTambah.Click += (sender, e) => AddRow();
            btnExcel.Click += (sender, args) => ExportExcel(GridManifest);

            btnRowDelete.ButtonClick += DeleteRow;
            btnGenerate.Click += GenerateConsol;
            ManifestView.CustomColumnDisplayText += NumberGrid;
            GridManifest.DoubleClick += (sender, args) => OpenRelatedForm(ManifestView, new TrackingViewForm(), "ShipmentCode");
            SearchPopup = Fpe;

            FormTrackingStatus = EnumTrackingStatus.Manifested;
            DataManager.DefaultParameters = new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals) };

            btnPrint.Click += Print;
            tsBaseBtn_Print.Click += Print2;
            tsBaseBtn_PrintPreview.Click += PrintPreview;

            btnPrintBarcode.Click += Print_Barcode;
            btnUpdate.Click += Update;
            
            tbxCn.KeyDown += (sender, args) =>
            {
                switch (args.KeyCode)
                {
                    case Keys.Enter:
                        if (!args.Shift)
                        {
                            AddRow();
                        }
                        break;
                }
            };
        }

        private void Update(object sender, EventArgs e)
        {
            var details = GridManifest.DataSource as List<ManifestDetailModel>;
            var shipRepo = new ShipmentDataManager();
            var repo = new ManifestDetailDataManager();
            if (details != null)
                foreach (ManifestDetailModel obj in details)
                {
                    if (obj.ShipmentId != null)
                    {
                        var shipment = shipRepo.GetFirst<ShipmentModel>(WhereTerm.Default((int) obj.ShipmentId, "id", EnumSqlOperator.Equals));
                        if (shipment != null)
                        {
                            obj.CustomerId = shipment.CustomerId;
                            obj.CustomerName = shipment.CustomerName;
                            obj.ShipperName = shipment.ShipperName;
                            obj.ConsigneeName = shipment.ConsigneeName;
                            obj.ServiceTypeId = shipment.ServiceTypeId;
                            obj.PackageTypeId = shipment.PackageTypeId;
                            obj.PaymentMethodId = shipment.PaymentMethodId;
                            obj.SalesTypeId = shipment.SalesTypeId;
                            obj.TtlPiece = shipment.TtlPiece;
                            obj.TtlGrossWeight = shipment.TtlGrossWeight;
                            obj.TtlChargeableWeight = shipment.TtlChargeableWeight;

                            repo.Update<ManifestDetailModel>(obj);
                        }
                    }
                }

            GridManifest.DataSource =
                new ManifestDetailDataManager().Get<ManifestDetailModel>(WhereTerm.Default(CurrentModel.Id,
                    "manifest_id", EnumSqlOperator.Equals));
        }

        private void Print_Barcode(object sender, EventArgs e)
        {
            if (tbxConsol.Text != "")
            {
                var barcode = new List<PrintBarcode>();
                if (tbxBranch.Value == null)
                {
                    //MessageBox.Show(@"Cabang tujuan harus diisi",@"Information", MessageBoxButtons.OK);
                    MessageForm.Info(form, Resources.information, @"Cabang tujuan harus diisi");
                    tbxBranch.Focus();
                    return;
                }

                var orig = new BranchDataManager().GetFirst<BranchModel>(WhereTerm.Default(BaseControl.BranchId, "id", EnumSqlOperator.Equals));
                var dest = new BranchDataManager().GetFirst<BranchModel>(WhereTerm.Default((int) tbxBranch.Value, "id", EnumSqlOperator.Equals));
                barcode.Add(new PrintBarcode
                {
                    DateProcess = tbxDate.Value,
                    BranchName = orig.Code,
                    DestBranchName = dest.Code,
                    Number = @"0",
                    Code = tbxConsol.Text,
                    Count = 0,
                    ServiceType = string.Empty,
                    GrossWeight = tbxBerat.Value
                });

                var a = new ManifestConsolBarcodeCard();
                a.DataSource = barcode;
                a.CreateDocument();

                var printTool = new ReportPrintTool(a);
                printTool.PrintingSystem.StartPrint += (o, args) =>
                {
                    args.PrintDocument.PrinterSettings.PrinterName = BaseControl.PrinterSetting.Barcode;
                };
                printTool.Print();
            }
        }

        private void PrintPreview(object sender, EventArgs e)
        {
            var print = new ManifestPrint();
            using (var printTool = new ReportPrintTool(print))
            {
                print.DataSource = new ManifestDetailDataManager().Get<ManifestDetailModel>(WhereTerm.Default(CurrentModel.Id, "manifest_id", EnumSqlOperator.Equals));
                var curmodel = CurrentModel as ManifestModel;
                // ReSharper disable once PossibleNullReferenceException
                curmodel.Printed = true;
                new ManifestDataManager().Update<ManifestModel>(curmodel);

                var via = string.Empty;
                if (curmodel.ShippingPlanId == null) via = "---";
                else
                {
                    switch ((int)curmodel.ShippingPlanId)
                    {
                        case 1: via = "UDARA"; break;
                        case 2: via = "DARAT"; break;
                        case 3: via = "LAUT"; break;
                    }
                }

                print.RequestParameters = false;
                print.Parameters.Add(new Parameter
                {
                    Name = "ManifestCode",
                    Value = ((ManifestModel)CurrentModel).Code,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Tanggal",
                    Value = ((ManifestModel)CurrentModel).DateProcess,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Origin",
                    Value = ((ManifestModel)CurrentModel).BranchName,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Dest",
                    Value = ((ManifestModel)CurrentModel).DestBranch,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Via",
                    Value = via,
                    Visible = false
                });

                if (BaseControl.UserId != null)
                {
                    var user = new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default((int) BaseControl.UserId, "user_id", EnumSqlOperator.Equals));
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
                    args.PrintDocument.PrinterSettings.PrinterName = BaseControl.PrinterSetting.InkJet;
                };

                printTool.ShowPreviewDialog();
            }
        }

        private string HeaderDotMetrix(int hal)
        {
            string print = File.ReadAllText(@"ManifestPrint.txt");
            print = print.Replace("{MANIFESTCODE}", ((ManifestModel)CurrentModel).Code);
            print = print.Replace("{TANGGAL}", ((ManifestModel)CurrentModel).DateProcess.ToString("d-M-yyyy HH:mm"));
            print = print.Replace("{ORIGIN}", ((ManifestModel)CurrentModel).BranchName);
            print = print.Replace("{DEST}", ((ManifestModel)CurrentModel).DestBranch);
            print = print.Replace("{HAL}", hal.ToString("#"));
            var m = CurrentModel as ManifestModel;
            if (m.ShippingPlanId == null) print = print.Replace("{VIA}", "---");
            else
            {
                switch ((int)m.ShippingPlanId)
                {
                    case 1: print = print.Replace("{VIA}", "UDARA"); break;
                    case 2: print = print.Replace("{VIA}", "DARAT"); break;
                    case 3: print = print.Replace("{VIA}", "LAUT"); break;
                }
            }

            return print;
        }

        private void Print(object sender, EventArgs e)
        {
            var curmodel = new ManifestDataManager().GetFirst<ManifestModel>(WhereTerm.Default(CurrentModel.Id, "id", EnumSqlOperator.Equals));
            if (curmodel != null)
            {
                curmodel.Printed = true;
                new ManifestDataManager().Update<ManifestModel>(curmodel);
            }

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
                decimal grandCod = 0;
                var dataSource = new ManifestDetailDataManager().Get<ManifestDetailModel>(WhereTerm.Default(CurrentModel.Id, "manifest_id", EnumSqlOperator.Equals)).OrderBy(x => x.Id).AsEnumerable();
                var manifestDetailModels = dataSource as ManifestDetailModel[] ?? dataSource.ToArray();
                for (var i = 0; i < manifestDetailModels.Count(); i++)
                {
                    table += string.Format("{0} ", no.ToString("#").PadLeft(patterns[0].Length, ' '));
                    table += string.Format("{0} ", manifestDetailModels[i].ShipperName != null ? manifestDetailModels[i].ShipperName.PadRight(patterns[1].Length, ' ').Substring(0, patterns[1].Length) : " ".PadRight(patterns[1].Length, ' '));
                    table += string.Format("{0} ", manifestDetailModels[i].ConsigneeName != null ? manifestDetailModels[i].ConsigneeName.PadRight(patterns[2].Length, ' ').Substring(0, patterns[2].Length) : " ".PadRight(patterns[2].Length, ' '));
                    table += string.Format("{0} ", manifestDetailModels[i].ShipmentCode.PadLeft(patterns[3].Length, ' '));
                    table += string.Format("{0} ", manifestDetailModels[i].DestCity != null ? manifestDetailModels[i].DestCity.PadRight(patterns[4].Length, ' ').Substring(0, patterns[4].Length) : " ".PadRight(patterns[4].Length, ' '));
                    table += string.Format("{0} ", manifestDetailModels[i].PaymentMethod != null ? manifestDetailModels[i].PaymentMethod.PadRight(patterns[5].Length, ' ').Substring(0, patterns[5].Length) : " ".PadRight(patterns[5].Length, ' '));
                    table += string.Format("{0} ", manifestDetailModels[i].PackageType != null ? manifestDetailModels[i].PackageType.PadRight(patterns[6].Length, ' ').Substring(0, patterns[6].Length) : " ".PadRight(patterns[6].Length, ' '));
                    table += string.Format("{0} ", manifestDetailModels[i].TtlPiece.ToString("#").PadLeft(patterns[7].Length, ' '));
                    table += string.Format("{0} ", manifestDetailModels[i].TtlGrossWeight.ToString("#").PadLeft(patterns[8].Length, ' '));
                    table += string.Format("{0} ", manifestDetailModels[i].TotalCod.ToString("#,#0").PadLeft(patterns[9].Length, ' ').Substring(0, patterns[9].Length));
                    table += "\n";
                    
                    no++;
                    row++;

                    grandPcs += manifestDetailModels[i].TtlPiece;
                    grandGw += manifestDetailModels[i].TtlGrossWeight;
                    grandCod += manifestDetailModels[i].TotalCod;
                    if (row == 55)
                    {
                        print = print.Replace(result, table);

                        var regPcs = new Regex(@"<(.+?)>");
                        var gPcs = regPcs.Match(print).Groups[0].Value;
                        var regGw = new Regex(@"{(.+?)}");
                        var gGw = regGw.Match(print).Groups[0].Value;
                        var regCod = new Regex(@"!(.+?)!");
                        var gCod = regCod.Match(print).Groups[0].Value;

                        print = print.Replace(gPcs, grandPcs.ToString("#").PadLeft(gPcs.Length, ' '));
                        print = print.Replace(gGw, grandGw.ToString("#").PadLeft(gGw.Length, ' '));
                        print = print.Replace(gCod, grandCod.ToString("#,#0").PadLeft(gCod.Length, ' '));

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
                        grandCod = 0;

                        print += string.Format("{0}", (char)12);
                        print += HeaderDotMetrix(hal);
                    }
                }

                print = print.Replace(result, table);
                var rPcs = new Regex(@"<(.+?)>");
                var grnPcs = rPcs.Match(print).Groups[0].Value;
                var rGw = new Regex(@"{(.+?)}");
                var grdGw = rGw.Match(print).Groups[0].Value;
                var rCod = new Regex(@"!(.+?)!");
                var grdCod = rCod.Match(print).Groups[0].Value;

                print = print.Replace(grnPcs, grandPcs.ToString("#").PadLeft(grnPcs.Length, ' '));
                print = print.Replace(grdGw, grandGw.ToString("#").PadLeft(grdGw.Length, ' '));
                print = print.Replace(grdCod, grandCod.ToString("#,#0").PadLeft(grdCod.Length, ' '));
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

        private void Print2(object sender, EventArgs e)
        {
            var print = new ManifestPrint();
            using (var printTool = new ReportPrintTool(print))
            {
                print.DataSource = new ManifestDetailDataManager().Get<ManifestDetailModel>(WhereTerm.Default(CurrentModel.Id, "manifest_id", EnumSqlOperator.Equals));
                var curmodel = new ManifestDataManager().GetFirst<ManifestModel>(WhereTerm.Default(CurrentModel.Id, "id", EnumSqlOperator.Equals));

                var via = string.Empty;
                if (curmodel.ShippingPlanId == null) via = "---";
                else
                {
                    switch ((int)curmodel.ShippingPlanId)
                    {
                        case 1: via = "UDARA"; break;
                        case 2: via = "DARAT"; break;
                        case 3: via = "LAUT"; break;
                    }
                }

                if (curmodel != null)
                {
                    curmodel.Printed = true;
                    new ManifestDataManager().Update<ManifestModel>(curmodel);
                }

                print.RequestParameters = false;
                print.Parameters.Add(new Parameter
                {
                    Name = "ManifestCode",
                    Value = ((ManifestModel)CurrentModel).Code,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Tanggal",
                    Value = ((ManifestModel)CurrentModel).DateProcess,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Origin",
                    Value = ((ManifestModel)CurrentModel).BranchName,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Dest",
                    Value = ((ManifestModel)CurrentModel).DestBranch,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Via",
                    Value = via,
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
                    args.PrintDocument.PrinterSettings.PrinterName = BaseControl.PrinterSetting.InkJet;
                };
                printTool.Print();
            }
        }

        private void GenerateConsol(object sender, EventArgs e)
        {
            tbxConsol.Text = GetCode("consol", DateTime.Now);
            tbxBerat.Text = @"0";
            tbxBerat.Focus();
        }

        private void DeleteRow(object sender, ButtonPressedEventArgs e)
        {
            if (!btnTambah.Enabled) return;
            var dialog = MessageForm.Ask(form, Resources.delete_confirm, Resources.delete_confirm_msg);
            if (dialog == DialogResult.Yes)
            {
                var rowHandle = ManifestView.FocusedRowHandle;
                if (ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["Id"]) != null) DeletedRows.Add((int)ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["Id"]));
                ManifestView.DeleteSelectedRows();
            }
        }

        private void Detail(ShipmentModel shipment, string consolidationcode)
        {
            var payment = new PaymentMethodDataManager().GetFirst<PaymentMethodModel>(WhereTerm.Default(shipment.PaymentMethodId, "id", EnumSqlOperator.Equals));
            var service = new ServiceTypeDataManager().GetFirst<ServiceTypeModel>(WhereTerm.Default(shipment.ServiceTypeId, "id", EnumSqlOperator.Equals));
            var package = new PackageDataManager().GetFirst<PackageTypeModel>(WhereTerm.Default(shipment.PackageTypeId, "id", EnumSqlOperator.Equals));

            // ReSharper disable once RedundantAssignment
            var cons = new List<ManifestDetailModel>();

            if (ManifestView.RowCount > 0)
            {
                cons = GridManifest.DataSource as List<ManifestDetailModel>;

                var s = new ManifestDetailDataManager().Get<ManifestDetailModel>(WhereTerm.Default(shipment.Code, "shipment_code", EnumSqlOperator.Equals)).FirstOrDefault(p => p.OrigBranchId == BaseControl.BranchId);
                if (s != null)
                {
                    MessageForm.Info(form, Resources.information, string.Format("{0} sudah di manifest", shipment.Code));
                    return;
                }

                if (cons != null && cons.FirstOrDefault(b => b.ShipmentCode == shipment.Code) != null) return;
            }

            var expand = new ShipmentExpandDataManager().GetFirst<ShipmentExpandModel>(WhereTerm.Default(shipment.Id, "shipment_id"));
            
            var detail = new ManifestDetailModel
            {
                DateProcess = DateTime.Now,
                ConsolidationCode = string.Empty,//consolidationcode,
                ShipmentId = shipment.Id,
                ShipmentDate = shipment.DateProcess,
                ShipmentCode = shipment.Code,
                ConsolCode = consolidationcode != string.Empty ? tbxCn.Text : tbxConsol.Text,
                BranchId = shipment.BranchId,
                DestCityId = shipment.DestCityId,
                DestCity = shipment.DestCityId > 0 ?new CityDataManager().GetFirst<CityModel>(WhereTerm.Default(shipment.DestCityId, "id", EnumSqlOperator.Equals)).Name : "",
                CustomerId = shipment.CustomerId,
                CustomerName = shipment.CustomerName,
                ShipperName = shipment.ShipperName,
                ConsigneeName = shipment.ConsigneeName,
                ServiceTypeId = shipment.ServiceTypeId,
                ServiceType = service.Name,
                PackageTypeId = shipment.PackageTypeId,
                PackageType = package.Name,
                PaymentMethodId = shipment.PaymentMethodId,
                PaymentMethod = payment.Name,
                TtlPiece = shipment.TtlPiece,
                TtlGrossWeight = shipment.TtlGrossWeight,
                TtlChargeableWeight = shipment.TtlChargeableWeight,
                Manifested = true,
                TotalCod = expand != null ? expand.TotalCod : 0,
                StateChange2 = EnumStateChange.Insert.ToString()
            };

            if (cons != null)
            {
                cons.Add(detail);
                GridManifest.DataSource = cons;

                ManifestView.RefreshData();
                ManifestView.FocusedRowHandle = ManifestView.RowCount - 1;
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
                if (route.BranchTransitId != tbxBranch.Value) return false;
            }
            else return false;

            return true;
        }

        private void AddRow()
        {
            if (tbxCn.Text == string.Empty) return;
            if (tbxBranch.Value == null)
            {
                //MessageBox.Show(Resources.alert_empty_field, @"Warning");
                MessageForm.Warning(form, @"Warning", Resources.alert_empty_field);
                tbxBranch.Focus();
                return;
            }

            var shipment = new ShipmentDataManager().GetFirst<ShipmentModel>(WhereTerm.Default(tbxCn.Text, "code", EnumSqlOperator.Equals));
            if (shipment == null)
            {
                var cd = tbxCn.Text.Substring(0, tbxCn.TextLength - 3);
                shipment = new ShipmentDataManager().GetFirst<ShipmentModel>(WhereTerm.Default(cd, "code", EnumSqlOperator.Equals));
            }
            
            if (shipment == null)
            {
                var consolidation =
                    new ConsolidationDataManager().GetFirst<ConsolidationModel>(WhereTerm.Default(tbxCn.Text, "code",
                        EnumSqlOperator.Equals));
                if (consolidation != null)
                {
                    /*if (consolidation.DestBranchId != tbxBranch.Value)
                    {
                        MessageBox.Show(string.Format(Resources.check_destination, tbxCn.Text), Resources.information,
                            MessageBoxButtons.OK);
                        return;
                    }*/

                    if (!CheckRoute(consolidation.DestBranchId))
                    {
                        //MessageBox.Show(string.Format(Resources.check_destination, tbxCn.Text), Resources.information,MessageBoxButtons.OK);
                        MessageForm.Warning(form, Resources.information, string.Format(Resources.check_destination, tbxCn.Text));
                        tbxCn.Focus();
                        tbxCn.Clear();
                        return;
                    }

                    var details =
                        new ConsolidationDetailDataManager().Get<ConsolidationDetailModel>(
                            WhereTerm.Default(consolidation.Id, "consolidation_id", EnumSqlOperator.Equals));
                    
                    // ReSharper disable once NotAccessedVariable
                    var idx = 0;
                    foreach (ConsolidationDetailModel detail in details)
                    {
                        var s =
                            new ShipmentDataManager().GetFirst<ShipmentModel>(WhereTerm.Default(detail.ShipmentId, "id",
                                EnumSqlOperator.Equals));

                        /*s.TtlPiece = detail.TtlPiece;

                        if (idx == 0 && tbxBerat.Value > 0)
                        {
                            s.TtlGrossWeight = (decimal) tbxBerat.Value;
                            s.TtlChargeableWeight = (int) Math.Ceiling(tbxBerat.Value);
                        }
                        else
                        {
                            s.TtlGrossWeight = 0;
                            s.TtlChargeableWeight = 0;
                        }*/

                        Detail(s, detail.ConsolidationCode);

                        idx++;
                    }
                }
                else
                {
                    //MessageBox.Show(Resources.empty_cn, Resources.information, MessageBoxButtons.OK);
                    MessageForm.Warning(form, Resources.information, Resources.empty_cn);
                }
            }
            else
            {
                
                var city = new CityDataManager().GetFirst<CityModel>(WhereTerm.Default(shipment.DestCityId, "id", EnumSqlOperator.Equals));

                if (!CheckRoute(city.BranchId))
                {
                    if (shipment.BranchId == (int)tbxBranch.Value && shipment.DestBranchId == BaseControl.BranchId)
                    {
                        var status = new ShipmentStatusDataManager().GetFirst<ShipmentStatusModel>(new IListParameter[]
                        {
                            WhereTerm.Default(shipment.Id, "shipment_id"),
                            WhereTerm.Default((int) EnumTrackingStatus.Returned, "tracking_status_id")
                        });

                        if (status == null)
                        {
                            MessageForm.Warning(form, "POD Retur", "Untuk POD retur, mohon info ke Customer Service untuk update POD sebagai RETURN agar bisa dilakukan manifest kembali ke Cabang pengirim.");
                            tbxCn.Focus();
                            tbxCn.Clear();
                            return;
                        }
                    }
                    else
                    {
                        MessageForm.Warning(form, Resources.information, string.Format(Resources.check_destination, tbxCn.Text));
                        tbxCn.Focus();
                        tbxCn.Clear();
                        return;
                    }
                }

                Detail(shipment, string.Empty);
            }

            tbxCn.Text = string.Empty;
            tbxCn.Focus();
        }

        private void ManifestLoad(object sender, EventArgs e)
        {
            EnableBtnSearch = true;
            EnableBtnPrint = false;
            EnableBtnPrintPreview = false;

            tbxBranch.LookupPopup = new BranchPopup();
            tbxBranch.AutoCompleteDataManager = new BranchDataManager();
            tbxBranch.AutoCompleteDisplayFormater = model => ((BranchModel)model).Code + " " + ((BranchModel)model).Name;
            tbxBranch.AutoCompleteWhereExpression +=
                (s, param) => param.SetWhereExpression("code = @0 or name.StartsWith(@0)", s);

            Fpe.DefaultParam = new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals) };

            tbxBerat.IsNumber = true;
            btnUpdate.Enabled = false;

            tbxCn.Enter += tbxCn_Enter;

            cmbShipping.DataSource = new List<ShippingPlanningCombo>
                {
                    new ShippingPlanningCombo{Id = 1, Name = "Udara"},
                    new ShippingPlanningCombo{Id = 2, Name = "Darat"},
                    new ShippingPlanningCombo{Id = 3, Name = "Laut"}
                };
            cmbShipping.DisplayMember = "Name";
            cmbShipping.ValueMember = "Id";
            cmbShipping.SelectedIndex = -1;
        }

        void tbxCn_Enter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxConsol.Text))
            {
                if (((List<ManifestDetailModel>)GridManifest.DataSource).Where(p => p.ConsolCode == tbxConsol.Text).FirstOrDefault() == null)
                {
                    if (new ManifestDetailDataManager().IsConsolExists(tbxConsol.Text))
                    {
                        MessageForm.Info(form, "Consol Exists", "Nomor consol sudah digunakan pada manifest lain.");
                        tbxConsol.Focus();
                    }
                }
            }
        }

        public override void New()
        {
            base.New();

            ClearForm();
            ToolbarCode = string.Empty;
            StateChange = EnumStateChange.Insert;
            GridManifest.DataSource = new List<ManifestDetailModel>();
            ManifestView.RefreshData();
            btnUpdate.Enabled = false;

            DeletedRows = new List<int>();
            tbxBranch.Focus();

            tbxDate.Enabled = true;
            tbxDate.Properties.Buttons[0].Enabled = true;
            tbxBranch.Enabled = true;
            tbxBranch.Properties.Buttons[0].Enabled = true;
            btnTambah.Enabled = true;

            tbxConsol.Enabled = true;
            
        }

        public override void Save()
        {
            if (ManifestView.RowCount == 0)
            {
                //MessageBox.Show(Resources.stt_detail_empty, Resources.title_save_changes, MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageForm.Info(form, Resources.title_save_changes, Resources.stt_detail_empty);
                tbxCn.Focus();
                tbxCn.Clear();
                return;
            }

            // ReSharper disable once RedundantAssignment
            var manifest = CurrentModel as ManifestModel;
            /*Debug.Assert(manifest != null, "manifest != null");
            if (manifest.Id > 0 && manifest.StatusId != (int) EnumTrackingStatus.Manifested)
            {
                MessageBox.Show(Resources.status_invalid, Resources.information, MessageBoxButtons.OK);
                return;
            }*/

            if (CurrentModel.Id == 0)
            {
                if (tbxDate.Text != "")
                    Code = GetCode("manifest", tbxDate.Value);
            }
            else
            {
                manifest = new ManifestDataManager().GetFirst<ManifestModel>(WhereTerm.Default(CurrentModel.Id, "id", EnumSqlOperator.Equals));
                Code = manifest.Code;

                if (manifest.Printed)
                {
                    //MessageBox.Show(@"Data manifest sudah dicetak.", @"information", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    MessageForm.Info(form, Resources.information, @"Data manifest sudah di cetak");
                    return;
                }
            }

            base.Save();
        }

        protected override void SaveDetail(bool isUpdate = false)
        {
            form.Enabled = false;
            var manifest = new ManifestDataManager().GetFirst<ManifestModel>(WhereTerm.Default(CurrentModel.Id, "id", EnumSqlOperator.Equals));
            Code = manifest.Code;

            StateChange = EnumStateChange.Select;
            short totalPiece = 0;
            decimal totalGw = 0;
            decimal totalCw = 0;
            for (int i = 0; i < ManifestView.RowCount; i++)
            {
                int rowHandle = ManifestView.GetVisibleRowHandle(i);
                if (ManifestView.IsDataRow(rowHandle))
                {
                    var state = ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["StateChange2"]);
                    if (state.ToString().Equals(EnumStateChange.Insert.ToString()))
                    {
                        var detail = new ManifestDetailModel();
                        detail.Rowstatus = true;
                        detail.Rowversion = DateTime.Now;
                        detail.ManifestId = CurrentModel.Id;
                        detail.DateProcess = DateTime.Now;
                        detail.ManifestCode = Code;

                        /*if (ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["ConsolidationCode"]) != null)
                            detail.ConsolidationCode =
                                ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["ConsolidationCode"])
                                    .ToString();*/

                        detail.ShipmentId =
                            (int)ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["ShipmentId"]);
                        detail.ShipmentDate =
                            (DateTime)
                                ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["ShipmentDate"]);
                        detail.ShipmentCode =
                            ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["ShipmentCode"])
                                .ToString();
                        detail.ConsolCode =
                            ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["ConsolCode"])
                                .ToString();
                        detail.BranchId =
                            (int)ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["BranchId"]);
                        detail.DestCityId =
                            (int)ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["DestCityId"]);

                        if (ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["CustomerId"]) != null)
                            detail.CustomerId =
                                (int)ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["CustomerId"]);

                        if (ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["CustomerName"]) != null)
                            detail.CustomerName =
                                ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["CustomerName"])
                                    .ToString();

                        if (ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["ShipperName"]) != null)
                            detail.ShipperName =
                                ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["ShipperName"])
                                    .ToString();

                        if (ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["ConsigneeName"]) != null)
                            detail.ConsigneeName =
                                ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["ConsigneeName"])
                                    .ToString();

                        detail.ServiceTypeId =
                            (int)ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["ServiceTypeId"]);
                        detail.ServiceType =
                            ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["ServiceType"]).ToString();
                        detail.PackageTypeId =
                            (int)
                                ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["PackageTypeId"]);
                        detail.PackageType =
                            ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["PackageType"]).ToString();
                        detail.PaymentMethodId =
                            (int)
                                ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["PaymentMethodId"]);
                        detail.PaymentMethod =
                            ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["PaymentMethod"])
                                .ToString();
                        detail.TtlPiece =
                            (short)ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["TtlPiece"]);
                        detail.TtlGrossWeight =
                            (decimal)
                                ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["TtlGrossWeight"]);
                        detail.TtlChargeableWeight =
                            (decimal)
                                ManifestView.GetRowCellValue(rowHandle,
                                    ManifestView.Columns["TtlChargeableWeight"]);
                        detail.Manifested = true;
                        detail.TotalCod = (decimal)ManifestView.GetRowCellValue(rowHandle,
                                    ManifestView.Columns["TotalCod"]);
                        detail.Createddate = DateTime.Now;
                        detail.Createdby = BaseControl.UserLogin;

                        new ManifestDetailDataManager().Save<ManifestDetailModel>(detail);

                        var ship =
                            new ShipmentDataManager().GetFirst<ShipmentModel>(
                                WhereTerm.Default((int)detail.ShipmentId, "id", EnumSqlOperator.Equals));
                        if (ship != null)
                        {
                            ship.Manifested = true;
                            if (ship.TrackingStatusId != (int)EnumTrackingStatus.Received && ship.TrackingStatusId != (int)EnumTrackingStatus.Claimed && ship.TrackingStatusId != (int)EnumTrackingStatus.Gudang) ship.TrackingStatusId = (int)EnumTrackingStatus.Manifested;
                            ship.Modifiedby = BaseControl.UserLogin;
                            ship.Modifieddate = DateTime.Now;
                            new ShipmentDataManager().Update<ShipmentModel>(ship);

                            InsertTracking = true;
                            PodStatusModel.ShipmentId = ship.Id;
                            PodStatusModel.Reference = manifest.Code;
                            PodStatusModel.StatusNote = detail.ConsolCode;
                            PodStatusModel.PositionStatusId = BaseControl.BranchId;
                            PodStatusModel.PositionStatus = EnumPositionStatus.Branch.ToString();

                            var br =
                                new BranchDataManager().GetFirst<BranchModel>(
                                    WhereTerm.Default(((ManifestModel) CurrentModel).DestBranchId, "id",
                                        EnumSqlOperator.Equals));
                            PodStatusModel.StatusBy = br.Code;

                            ShipmentStatusUpdate();
                        }

                        if (detail.ConsolCode != "")
                        {
                            var consolidation =
                                new ConsolidationDataManager().GetFirst<ConsolidationModel>(
                                    WhereTerm.Default(detail.ConsolCode, "code", EnumSqlOperator.Equals));
                            if (consolidation != null)
                            {
                                var consodDm = new ConsolidationDetailDataManager();
                                var consod =
                                    consodDm.Get<ConsolidationDetailModel>(WhereTerm.Default((int) detail.ShipmentId,
                                        "shipment_id", EnumSqlOperator.Equals));

                                foreach (ConsolidationDetailModel obbj in consod)
                                {
                                    obbj.ManifestId = detail.ManifestId;
                                    obbj.ManifestCode = detail.ManifestCode;
                                    obbj.Modifiedby = BaseControl.UserLogin;
                                    obbj.Modifieddate = DateTime.Now;

                                    consodDm.Update<ConsolidationDetailModel>(obbj);
                                }
                            }
                        }
                    }

                    if (state.ToString().Equals(EnumStateChange.Delete.ToString()))
                    {
                        if (ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["Id"]) != null)
                        {
                            new ManifestDetailDataManager().DeActive(
                                (int)ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["Id"]),
                                BaseControl.UserLogin, DateTime.Now);

                            var shipment = new ShipmentDataManager().GetFirst<ShipmentModel>(WhereTerm.Default((int)ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["ShipmentId"]), "id", EnumSqlOperator.Equals));

                            var shipmentStatus = new ShipmentStatusDataManager().GetFirst<ShipmentStatusModel>(new IListParameter[]
                            {
                                WhereTerm.Default(shipment.Id, "shipment_id", EnumSqlOperator.Equals),
                                WhereTerm.Default((int) EnumTrackingStatus.Manifested, "tracking_status_id", EnumSqlOperator.Equals)
                            });
                            if (shipmentStatus != null)
                            {
                                new ShipmentStatusDataManager().DeActive(shipmentStatus.Id, BaseControl.UserLogin, DateTime.Now);
                            }
                        }
                    }
                    else
                    {
                        totalPiece +=
                            (short)ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["TtlPiece"]);
                        totalGw +=
                            (decimal)
                                ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["TtlGrossWeight"]);
                        totalCw +=
                            (decimal)
                                ManifestView.GetRowCellValue(rowHandle, ManifestView.Columns["TtlChargeableWeight"]);
                    }
                }
            }

            manifest.TtlPiece = totalPiece;
            manifest.TtlGrossWeight = totalGw;
            manifest.TtlChargeableWeight = totalCw;

            new ManifestDataManager().Update<ManifestModel>(manifest);

            foreach (int o in DeletedRows)
            {
                var data = new ManifestDetailDataManager().GetFirst<ManifestDetailModel>(WhereTerm.Default(o, "id", EnumSqlOperator.Equals));
                if (data != null)
                {
                    if (data.ShipmentId != null && data.ShipmentId > 0)
                    {
                        var shipmentStatus = new ShipmentStatusDataManager().GetFirst<ShipmentStatusModel>(new IListParameter[]
                                {
                                    WhereTerm.Default((int) data.ShipmentId, "shipment_id", EnumSqlOperator.Equals),
                                    WhereTerm.Default((int) EnumTrackingStatus.Manifested, "tracking_status_id", EnumSqlOperator.Equals),
                                    WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals)
                                });
                        if (shipmentStatus != null)
                        {
                            new ShipmentStatusDataManager().DeActive(shipmentStatus.Id, BaseControl.UserLogin, DateTime.Now);
                        }
                    }

                    new ManifestDetailDataManager().DeActive(o, BaseControl.UserLogin, DateTime.Now);
                }
            }

            Enabled = true;
            ToolbarCode = manifest.Code;
        }

        protected override void AfterSave()
        {
            OpenData(ToolbarCode);
            tsBaseTxt_Code.Focus();
        }

        public override void Delete()
        {
            if (((ManifestModel)CurrentModel).Printed)
            {
                //MessageBox.Show(@"Data manifest sudah dicetak.", @"information", MessageBoxButtons.OK,MessageBoxIcon.Information);
                MessageForm.Info(form, Resources.information, @"Data manifest sudah di cetak");
                return;
            }

            base.Delete();
        }

        public override void AfterDelete()
        {
            var detail = new ManifestDetailDataManager().GetDetail(WhereTerm.Default(CurrentModel.Id, "manifest_id", EnumSqlOperator.Equals));
            if (detail != null)
            {
                var repo = new ManifestDetailDataManager();
                var shipRepo = new ShipmentStatusDataManager();
                var shipmentRepo = new ShipmentDataManager();
                foreach (ManifestDetailModel  obj in detail)
                {
                    repo.DeActive(obj.Id, BaseControl.UserLogin, DateTime.Now);
                    if (obj.ShipmentId != null)
                    {
                        var shipmentStatus = shipRepo.GetFirst<ShipmentStatusModel>(new IListParameter[]
                            {
                                WhereTerm.Default((int) obj.ShipmentId, "shipment_id", EnumSqlOperator.Equals),
                                WhereTerm.Default((int) EnumTrackingStatus.Manifested, "tracking_status_id", EnumSqlOperator.Equals)
                            });
                        if (shipmentStatus != null)
                        {
                            shipRepo.DeActive(shipmentStatus.Id, BaseControl.UserLogin, DateTime.Now);
                        }

                        var shipment = shipmentRepo.GetFirst<ShipmentModel>(WhereTerm.Default((int) obj.ShipmentId, "id", EnumSqlOperator.Equals));
                        shipment.ManifestCode = string.Empty;
                        shipment.Manifested = false;
                        shipmentRepo.Update<ShipmentModel>(shipment);
                    }
                }
            }

            base.AfterDelete();
        }

        protected override bool ValidateForm()
        {
            if (tbxDate.Text != "" && tbxBranch.Value > 0)
                return true;

            if (tbxBranch.Value == null)
            {
                tbxBranch.Focus();
                return false;
            }

            return false;
        }

        protected override void PopulateForm(ManifestModel model)
        {
            ClearForm();
            if (model == null) return;

            if (model.Printed)
            {
                btnRowDelete.Enabled = false;
                btnTambah.Enabled = false;
            }
            else
            {
                btnRowDelete.Enabled = true;
                btnTambah.Enabled = true;
            }

            DeletedRows = new List<int>();
            EnableBtnPrint = true;
            EnableBtnPrintPreview = true;

            tbxDate.Enabled = false;
            tbxDate.Properties.Buttons[0].Enabled = false;
            tbxBranch.Enabled = false;
            tbxBranch.Properties.Buttons[0].Enabled = false;

            ToolbarCode = model.Code;
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxDate.Text = model.DateProcess.ToString();
            tbxBranch.DefaultValue = new IListParameter[] { WhereTerm.Default(model.DestBranchId, "id", EnumSqlOperator.Equals) };

            var details =
                new ManifestDetailDataManager().Get<ManifestDetailModel>(WhereTerm.Default(model.Id,
                    "manifest_id", EnumSqlOperator.Equals));

            cmbShipping.SelectedIndex = -1;
            if (model.ShippingPlanId != null) cmbShipping.SelectedValue = (int)model.ShippingPlanId;

            GridManifest.DataSource = details.ToList();
            tsBaseTxt_Code.Focus();
            btnUpdate.Enabled = true;
        }

        protected override ManifestModel PopulateModel(ManifestModel model)
        {
            model.DateProcess = tbxDate.Value;
            model.Code = Code;
            model.BranchId = BaseControl.BranchId;

            if (tbxBranch.Value != null) model.DestBranchId = (int)tbxBranch.Value;
            model.StatusId = (int) EnumTrackingStatus.Manifested;

            if (cmbShipping.SelectedIndex >= 0) model.ShippingPlanId = (int)cmbShipping.SelectedValue;
            else model.ShippingPlanId = null;

            if (model.Id == 0) model.CreatedPc = Environment.MachineName;
            else model.ModifiedPc = Environment.MachineName;

            return model;
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

        public override void Info()
        {
            var model = CurrentModel as ManifestModel;

            if (model != null)
            {
                info.CreatedPc = model.CreatedPc;
                info.ModifiedPc = model.ModifiedPc;
            }

            base.Info();
        }
    }

    public class ShippingPlanningCombo
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}