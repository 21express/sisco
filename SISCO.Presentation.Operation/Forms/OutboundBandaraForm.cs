using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.WinControl.MessageBox;
using DevExpress.Data;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
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
using System.Text.RegularExpressions;

namespace SISCO.Presentation.Operation.Forms
{
    public partial class OutboundBandaraForm : BaseCrudForm<AirwaybillModel, AirwaybillDataManager>//BaseToolbarForm//
    {
        public OutboundBandaraFilterPopup Fpe = new OutboundBandaraFilterPopup();
        private string ConsolidationCode { get; set; }
        private int AirportBranch { get; set; }
        private List<int> DeletedRows { get; set; }

        public OutboundBandaraForm()
        {
            InitializeComponent();

            form = this;
            Load += OutboundBandaraLoad;
            tbxBarcode.Leave += CheckConsolidation;
            tbxGw.Leave += Calculate;
            btnAdd.Click += (sender, args) => AddRow();

            tbxAirline.Leave += (sender, args) => FlightDataSource();
            tbxOrigin.Leave += (sender, args) => FlightDataSource();
            tbxDestination.Leave += (sender, args) =>
            {
                if (tbxDestination.Value != null)
                {
                    var airport =
                        new AirportDataManager().GetFirst<AirportModel>(WhereTerm.Default((int) tbxDestination.Value,
                            "id", EnumSqlOperator.Equals));
                    var city =
                        new CityDataManager().GetFirst<CityModel>(WhereTerm.Default(airport.CityId, "id",
                            EnumSqlOperator.Equals));
                    AirportBranch = city.BranchId;
                    FlightDataSource();
                }
            };

            tbxEstDate.Leave += (sender, args) => FlightDataSource();
            //Shown += (sender, args) => Top();

            btnDelete1.ButtonClick += DeleteRow;
            OutboundBandaraView.CustomColumnDisplayText += NumberGrid;
            OutboundBandaraView.DoubleClick += (sender, args) =>
            {
                var rows = OutboundBandaraView.GetSelectedRows();
                if (rows.Count() > 0)
                {
                    if (OutboundBandaraView.GetRowCellValue(rows[0], "CustomerName").ToString().Contains("TRANSIT"))
                        return;

                    object customerId = OutboundBandaraView.GetRowCellValue(rows[0], "CustomerId");
                    var tid = 0;
                    var tname = string.Empty;
                    if (customerId != null)
                    {
                        tid = (int)OutboundBandaraView.GetRowCellValue(rows[0], "CustomerId");
                        tname = OutboundBandaraView.GetRowCellValue(rows[0], "CustomerName").ToString();
                    }

                    if (tid == 0 && tname == "CONSOL")
                    {
                        var code = OutboundBandaraView.GetRowCellValue(rows[0], "ShipmentCode").ToString();
                        var consolidation = new ConsolidationDataManager().GetFirst<ConsolidationModel>(WhereTerm.Default(code, "code", EnumSqlOperator.Equals));
                        if (consolidation != null) OpenRelatedForm(OutboundBandaraView, new ConsolidationForm(), "ShipmentCode");
                        else OpenRelatedForm(OutboundBandaraView, new ManifestForm(), "ManifestCode");
                    }
                    else OpenRelatedForm(OutboundBandaraView, new TrackingViewForm(), "ShipmentCode");
                }
            };

            tbxBarcode.KeyDown += AutocompleteCode;
            tbxCw.KeyPress += DisableDotComma;

            FormTrackingStatus = EnumTrackingStatus.Waybilled;
            DataManager.DefaultParameters = new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals) };

            tsBaseBtn_Print.Click += Print;
            tsBaseBtn_PrintPreview.Click += PrintPreview;

            cbxFlight.KeyPress += (sender, args) =>
            {
                if (args.KeyChar == 13) tbxBarcode.Focus();
            };
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

        private void PrintPreview(object sender, EventArgs e)
        {
            var print = new AirwaybillPrint();
            using (var printTool = new ReportPrintTool(print))
            {
                print.DataSource = new AirwaybillDataManager().Print(CurrentModel.Id);
                print.CreateDocument();
                printTool.PrintingSystem.StartPrint += (o, args) =>
                {
                    args.PrintDocument.PrinterSettings.PrinterName = BaseControl.PrinterSetting.InkJet;
                };
                printTool.ShowPreviewDialog();
            }
        }

        private void Print(object sender, EventArgs e)
        {
            var print = new AirwaybillPrint();
            using (var printTool = new ReportPrintTool(print))
            {
                print.DataSource = new AirwaybillDataManager().Print(CurrentModel.Id);
                print.CreateDocument();

                printTool.PrintingSystem.StartPrint += (o, args) =>
                {
                    args.PrintDocument.PrinterSettings.PrinterName = BaseControl.PrinterSetting.InkJet;
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

        private void FlightDataSource()
        {
            if (tbxAirline.Value != null && tbxOrigin.Value != null && tbxDestination.Value != null)
            {
                var day = (int) tbxEstDate.Value.DayOfWeek;
                var param = new IListParameter[]
                {
                    WhereTerm.Default(day, "weekday", EnumSqlOperator.Equals),
                    WhereTerm.Default((int) tbxAirline.Value, "airline_id", EnumSqlOperator.Equals),
                    WhereTerm.Default((int) tbxOrigin.Value, "origin_airport_id", EnumSqlOperator.Equals),
                    WhereTerm.Default((int) tbxDestination.Value, "destination_airport_id", EnumSqlOperator.Equals)
                };

                var flights = new FlightDataManager().Get<FlightModel>(param);
                var ds = new List<Combo>();
                
                // ReSharper disable once RedundantAssignment
                var s = new Combo();
                var flightModel = flights as FlightModel[] ?? flights.ToArray();
                if (flightModel.Any())
                {
                    foreach (FlightModel flight in flightModel)
                    {   
                        s = new Combo
                        {
                            Id = flight.Id,
                            Text = string.Format("{0} - {1}", flight.FlightNumber, flight.EstDepartureTime)
                        };
                        
                        ds.Add(s);
                    }

                    cbxFlight.DataSource = ds;
                    cbxFlight.DisplayMember = "Text";
                    cbxFlight.ValueMember = "Id";
                }
            }
            else
            {
                cbxFlight.DataSource = null;
            }
        }

        private void DeleteRow(object sender, ButtonPressedEventArgs e)
        {
            var model = CurrentModel as AirwaybillModel;
            if (!model.IsCancelled)
            {
                var rowHandle = OutboundBandaraView.FocusedRowHandle;
                if (OutboundBandaraView.GetRowCellValue(rowHandle, OutboundBandaraView.Columns["StateChange2"]).ToString() != EnumStateChange.Select.ToString() || FormTrackingStatus != EnumTrackingStatus.WaybilledRevised)
                {
                    var dialog = MessageForm.Ask(form, Resources.delete_confirm, Resources.delete_confirm_msg);
                    if (dialog == DialogResult.Yes)
                    {
                        if (OutboundBandaraView.GetRowCellValue(rowHandle, OutboundBandaraView.Columns["Id"]) != null) DeletedRows.Add((int)OutboundBandaraView.GetRowCellValue(rowHandle, OutboundBandaraView.Columns["Id"]));
                        OutboundBandaraView.DeleteSelectedRows();
                    }
                }
            }
        }

        private void OutboundBandaraLoad(object sender, EventArgs e)
        {
            ClearForm();
            EnableBtnSearch = true;

            EnableBtnPrint = false;
            EnableBtnPrintPreview = false;

            tbxAirline.LookupPopup = new AirlinePopup();
            tbxAirline.AutoCompleteDataManager = new AirlineDataManager();
            tbxAirline.AutoCompleteText = model => ((AirlineModel)model).Code + " - " + ((AirlineModel)model).Name;
            tbxAirline.AutoCompleteDisplayFormater = model => ((AirlineModel)model).Code + " - " + ((AirlineModel)model).Name;
            tbxAirline.AutoCompleteWhereExpression +=
                (s, param) => param.SetWhereExpression("code = @0 or name.StartsWith(@0)", s);

            tbxOrigin.LookupPopup = new AirportPopup();
            tbxOrigin.AutoCompleteDataManager = new AirportDataManager();
            tbxOrigin.AutoCompleteText = model => ((AirportModel)model).Code + " - " + ((AirportModel)model).Name;
            tbxOrigin.AutoCompleteDisplayFormater = model => ((AirportModel)model).Code + " - " + ((AirportModel)model).Name;
            tbxOrigin.AutoCompleteWhereExpression +=
                (s, param) => param.SetWhereExpression("code = @0 or name.StartsWith(@0)", s);

            tbxDestination.LookupPopup = new AirportPopup();
            tbxDestination.AutoCompleteDataManager = new AirportDataManager();
            tbxDestination.AutoCompleteText = model => ((AirportModel)model).Code + " - " + ((AirportModel)model).Name;
            tbxDestination.AutoCompleteDisplayFormater = model => ((AirportModel)model).Code + " - " + ((AirportModel)model).Name;
            tbxDestination.AutoCompleteWhereExpression +=
                (s, param) => param.SetWhereExpression("code = @0 or name.StartsWith(@0)", s);

            SearchPopup = Fpe;
            Fpe.DefaultParam = new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals) };

            tbxGw.IsNumber = true;
            tbxCw.IsNumber = true;

            btnRevision.Click += btnRevision_Click;
        }

        void btnRevision_Click(object sender, EventArgs e)
        {
            var dialog = MessageForm.Ask(form, "Revisi SMU", "Anda yakin akan merevisi SMU ini?");
            if (dialog == DialogResult.Yes)
            {
                var revisionPopup = new RevisionSMUPopup
                {
                    StartPosition = FormStartPosition.CenterScreen,
                    ShowInTaskbar = false,
                    smu = CurrentModel as AirwaybillModel,
                    smuDetails = GridOutboundBandara.DataSource as List<AirwaybillDetailModel>
                };
                revisionPopup.ShowDialog();

                if (revisionPopup.Success)
                {
                    DataManager = new AirwaybillDataManager();
                    OpenData(ToolbarCode);
                }
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
                if (tbxDestination.Value != null)
                {
                    if (route.BranchTransitId != AirportBranch) return false;
                }
            }
            else return false;

            return true;
        }

        private void Detail(ShipmentModel shipment, ManifestDetailModel manifestDetail)
        {
            var cons = GridOutboundBandara.DataSource as List<AirwaybillDetailModel>;

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
                } else cons = new List<AirwaybillDetailModel>();

                if (shipment.DestBranchId == null) return;

                if (!CheckRoute((int) shipment.DestBranchId))
                {
                    if (shipment.DestBranchId == BaseControl.BranchId)
                    {
                        var airport = new AirportDataManager().GetFirst<AirportModel>(WhereTerm.Default((int)tbxDestination.Value, "id"));
                        if (airport == null) return;
                        var city = new CityDataManager().GetFirst<CityModel>(WhereTerm.Default(airport.CityId, "id"));
                        if (city == null) return;

                        if (shipment.BranchId == city.BranchId)
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
                            //AutoClosingMessageBox.Show(string.Format(Resources.check_destination, shipment.Code));
                            MessageBox.Show(string.Format(Resources.check_destination, shipment.Code));
                            return;
                        }
                    }
                    else
                    {
                        //AutoClosingMessageBox.Show(string.Format(Resources.check_destination, shipment.Code));
                        MessageBox.Show(string.Format(Resources.check_destination, shipment.Code));
                        return;
                    }
                }

                var airwaybilldetail =
                    new AirwaybillDetailDataManager().Get<AirwaybillDetailModel>(WhereTerm.Default(shipment.Code,
                        "shipment_code", EnumSqlOperator.Equals))
                        .Where(
                            p =>
                                p.OrigBranchIdAirwaybill == BaseControl.BranchId &&
                                p.DestBranchIdAirwaybill == AirportBranch)
                        .ToList();
                if (shipment.Id > 0)
                {
                    if (airwaybilldetail.Count() >= shipment.TtlPiece)
                    {
                        //AutoClosingMessageBox.Show(@"POD sudah di outbound bandara");
                        MessageBox.Show("POD sudah di outbound bandara.");
                        return;
                    }
                }
            }

            var detail = new AirwaybillDetailModel
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
                cons = new List<AirwaybillDetailModel>();
            }

            cons.Add(detail);
            GridOutboundBandara.DataSource = cons;
            OutboundBandaraView.RefreshData();
            OutboundBandaraView.FocusedRowHandle = OutboundBandaraView.RowCount - 1;
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

            //var airport = new AirportDataManager().GetFirst<AirportModel>(WhereTerm.Default((int) tbxDestination.Value, "id", EnumSqlOperator.Equals));
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
                    var manifestdetail = new ManifestDetailDataManager().GetFirst<ManifestDetailModel>(WhereTerm.Default(tbxBarcode.Text,"consol_code", EnumSqlOperator.Equals));
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
                                ServiceTypeId = manifestdetail.ServiceTypeId != null ? (int) manifestdetail.ServiceTypeId : 0,
                                PackageTypeId = (manifestdetail.PackageTypeId ?? 0),
                                PaymentMethodId = manifestdetail.PaymentMethodId != null ? (int) manifestdetail.PaymentMethodId : 0,
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

                                if (manifests.Count == 0) 
                                    //AutoClosingMessageBox.Show(Resources.empty_cn, Resources.information);
                                    MessageBox.Show(Resources.empty_cn);
                                else
                                {
                                    foreach (var s in shipments)
                                    {
                                        if (manifests.Where(p => p.ShipmentCode == s).ToList().Count == 0)
                                        {
                                            //AutoClosingMessageBox.Show(string.Format("POD {0} belum di manifest", s), Resources.information);
                                            MessageBox.Show(string.Format("POD {0} belum di manifest", s));
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
                    }
                }
            }
            
            if (shipment!=null)
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
                    //AutoClosingMessageBox.Show(@"POD belum di manifest", Resources.information);
                    MessageBox.Show("POD belum di manifest");
                }
            }

            tbxBarcode.Text = string.Empty;
            tbxGw.Text = @"0";
            tbxCw.Text = @"0";
            tbxBarcode.Focus();
        }

        public override void New()
        {
            base.New();

            ClearForm();

            EnableBtnPrint = false;
            EnableBtnPrintPreview = false;
            DeletedRows = new List<int>();
            btnAdd.Enabled = true;

            pnlRevision.Visible = false;
            btnRevision.Visible = false;

            ToolbarCode = string.Empty;
            StateChange = EnumStateChange.Insert;
            GridOutboundBandara.DataSource = null;
            OutboundBandaraView.RefreshData();

            tbxOrigin.DefaultValue = new IListParameter[] { WhereTerm.Default(BaseControl.CityId, "city_id", EnumSqlOperator.Equals) };

            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxDate.Text = DateTime.Now.ToString();
            tbxAwb.Focus();
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxEstDate.Text = DateTime.Now.AddDays(1).ToString();

            DataManager = new AirwaybillDataManager();

            FormTrackingStatus = EnumTrackingStatus.Waybilled;
        }

        public override void Save()
        {
            if (OutboundBandaraView.RowCount == 0)
            {
                MessageBox.Show(
                    Resources.stt_detail_empty
                    , Resources.title_save_changes
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Information);

                tbxBarcode.Focus();
                return;
            }

            /*var airwaybill = CurrentModel as AirwaybillModel;
            Debug.Assert(airwaybill != null, "airwaybill != null");
            if (airwaybill.Id > 0 && airwaybill.StatusId != (int)EnumTrackingStatus.Waybilled)
            {
                MessageBox.Show(Resources.status_invalid, Resources.information, MessageBoxButtons.OK);
                return;
            }*/

            if (tbxDestination.Value == null)
            {
                tbxDestination.Focus();
                return;
            }

            if (string.IsNullOrEmpty(tbxAwb.Text))
            {
                tbxAwb.Focus();
                return;
            }

            if (tbxAirline.Value == null)
            {
                tbxAirline.Focus();
                return;
            }

            var DestBranchId = 0;
            var airport = new AirportDataManager().GetFirst<AirportModel>(WhereTerm.Default((int)tbxDestination.Value, "id", EnumSqlOperator.Equals));
            if (airport != null)
            {
                var city = new CityDataManager().GetFirst<CityModel>(WhereTerm.Default(airport.CityId, "id", EnumSqlOperator.Equals));
                if (city != null)
                {
                    DestBranchId = city.BranchId;
                }
            }
            var exists = new AirwaybillDataManager().Get<AirwaybillModel>(new IListParameter[]
            {
                WhereTerm.Default(tbxAwb.Text, "code", EnumSqlOperator.Equals),
                WhereTerm.Default(BaseControl.BranchId, "branch_id"),
                WhereTerm.Default((int)tbxAirline.Value, "airline_id")
            });

            if (exists.Count() > 0)
            {
                if (CurrentModel.Id > 0)
                {
                    if (exists.Where(p => p.Id != CurrentModel.Id).ToList().Count > 0)
                    {
                        MessageForm.Warning(form, "Info", "Nomor AWB sudah digunakan silakan cek kembali.");
                        tbxAwb.Focus();
                        return;
                    }
                }
                else
                {
                    MessageForm.Warning(form, "Info", "Nomor AWB sudah digunakan silakan cek kembali.");
                    tbxAwb.Focus();
                    return;
                }
            }

            if (CurrentModel.Id > 0 && ((AirwaybillModel)CurrentModel).Code != tbxAwb.Text)
            {
                var detail = GridOutboundBandara.DataSource as List<AirwaybillDetailModel>;
                detail.ForEach(p => p.StateChange2 = EnumStateChange.Update.ToString());

                GridOutboundBandara.DataSource = detail;
            }

            base.Save();
        }

        protected override void SaveDetail(bool isUpdate = false)
        {
            Enabled = false;
            StateChange = EnumStateChange.Select;

            var enumTrackingForm = FormTrackingStatus;

            var awb = CurrentModel as AirwaybillModel;
            if (awb != null)
            {
                var airline =
                    new AirlineDataManager().GetFirst<AirlineModel>(WhereTerm.Default(awb.AirlineId, "id",
                        EnumSqlOperator.Equals));

                var totalPiece = (short) 0;
                decimal totalGw = 0;
                decimal totalCw = 0;
                var dimension = new List<string>();
                for (int i = 0; i < OutboundBandaraView.RowCount; i++)
                {
                    int rowHandle = OutboundBandaraView.GetVisibleRowHandle(i);
                    if (OutboundBandaraView.IsDataRow(rowHandle))
                    {
                        if (
                            OutboundBandaraView.GetRowCellValue(rowHandle, OutboundBandaraView.Columns["StateChange2"])
                                .ToString()
                                .Equals(EnumStateChange.Insert.ToString()) ||

                            OutboundBandaraView.GetRowCellValue(rowHandle, OutboundBandaraView.Columns["StateChange2"])
                                .ToString()
                                .Equals(EnumStateChange.Update.ToString()))
                        {
                            // ReSharper disable once UseObjectOrCollectionInitializer
                            var detail = new AirwaybillDetailModel();
                            detail.Rowstatus = true;
                            detail.Rowversion = DateTime.Now;
                            detail.DateProcess = DateTime.Now;
                            detail.AirwaybillId = CurrentModel.Id;
                            detail.AirwaybillCode = ((AirwaybillModel) CurrentModel).Code;
                            detail.ShipmentId =
                                (int)
                                    OutboundBandaraView.GetRowCellValue(rowHandle,
                                        OutboundBandaraView.Columns["ShipmentId"]);
                            detail.ShipmentDate =
                                (DateTime)
                                    OutboundBandaraView.GetRowCellValue(rowHandle,
                                        OutboundBandaraView.Columns["ShipmentDate"]);
                            detail.ShipmentCode =
                                OutboundBandaraView.GetRowCellValue(rowHandle,
                                    OutboundBandaraView.Columns["ShipmentCode"])
                                    .ToString();

                            if (
                                OutboundBandaraView.GetRowCellValue(rowHandle, OutboundBandaraView.Columns["ConsolCode"]) !=
                                null)
                                detail.ConsolCode =
                                    OutboundBandaraView.GetRowCellValue(rowHandle,
                                        OutboundBandaraView.Columns["ConsolCode"])
                                        .ToString();

                            if (OutboundBandaraView.GetRowCellValue(rowHandle,
                                OutboundBandaraView.Columns["ConsolidationCode"]) != null)
                                detail.ConsolidationCode =
                                    OutboundBandaraView.GetRowCellValue(rowHandle,
                                        OutboundBandaraView.Columns["ConsolidationCode"])
                                        .ToString();

                            detail.BranchId =
                                (int)
                                    OutboundBandaraView.GetRowCellValue(rowHandle,
                                        OutboundBandaraView.Columns["BranchId"]);

                            if (OutboundBandaraView.GetRowCellValue(rowHandle, OutboundBandaraView.Columns["DestCityId"]) != null)
                                detail.DestCityId = 
                                    (int)
                                        OutboundBandaraView.GetRowCellValue(rowHandle,
                                            OutboundBandaraView.Columns["DestCityId"]);

                            detail.CustomerId = OutboundBandaraView.GetRowCellValue(rowHandle,
                                OutboundBandaraView.Columns["CustomerId"]) != null
                                ? (int)
                                    OutboundBandaraView.GetRowCellValue(rowHandle,
                                        OutboundBandaraView.Columns["CustomerId"])
                                : (int?) null;

                            detail.CustomerName =
                                OutboundBandaraView.GetRowCellValue(rowHandle,
                                    OutboundBandaraView.Columns["CustomerName"]) != null ?
                                OutboundBandaraView.GetRowCellValue(rowHandle,
                                    OutboundBandaraView.Columns["CustomerName"])
                                    .ToString() : "";
                            detail.ShipperName =
                                OutboundBandaraView.GetRowCellValue(rowHandle,
                                    OutboundBandaraView.Columns["ShipperName"]) != null ?
                                OutboundBandaraView.GetRowCellValue(rowHandle,
                                    OutboundBandaraView.Columns["ShipperName"])
                                    .ToString() : "";
                            detail.ConsigneeName =
                                OutboundBandaraView.GetRowCellValue(rowHandle,
                                    OutboundBandaraView.Columns["ConsigneeName"]) != null ?
                                OutboundBandaraView.GetRowCellValue(rowHandle,
                                    OutboundBandaraView.Columns["ConsigneeName"])
                                    .ToString() : "";
                            detail.ServiceTypeId = OutboundBandaraView.GetRowCellValue(rowHandle,
                                OutboundBandaraView.Columns["ServiceTypeId"]) != null
                                ? (int)
                                    OutboundBandaraView.GetRowCellValue(rowHandle,
                                        OutboundBandaraView.Columns["ServiceTypeId"])
                                : (int?) null;
                            detail.PackageTypeId =
                                OutboundBandaraView.GetRowCellValue(rowHandle,
                                    OutboundBandaraView.Columns["PackageTypeId"]) != null
                                    ? (int)
                                        OutboundBandaraView.GetRowCellValue(rowHandle,
                                            OutboundBandaraView.Columns["PackageTypeId"])
                                    : (int?) null;
                            detail.PaymentMethodId = OutboundBandaraView.GetRowCellValue(rowHandle,
                                OutboundBandaraView.Columns["PaymentMethodId"]) != null
                                ? (int)
                                    OutboundBandaraView.GetRowCellValue(rowHandle,
                                        OutboundBandaraView.Columns["PaymentMethodId"])
                                : (int?) null;
                            detail.TtlPiece =
                                (short)
                                    OutboundBandaraView.GetRowCellValue(rowHandle,
                                        OutboundBandaraView.Columns["TtlPiece"]);
                            detail.TtlGrossWeight =
                                (decimal)
                                    OutboundBandaraView.GetRowCellValue(rowHandle,
                                        OutboundBandaraView.Columns["TtlGrossWeight"]);
                            detail.TtlChargeableWeight =
                                (decimal)
                                    OutboundBandaraView.GetRowCellValue(rowHandle,
                                        OutboundBandaraView.Columns["TtlChargeableWeight"]);
                            detail.ManifestId = (int)
                                OutboundBandaraView.GetRowCellValue(rowHandle, OutboundBandaraView.Columns["ManifestId"]);

                            if (
                                OutboundBandaraView.GetRowCellValue(rowHandle,
                                    OutboundBandaraView.Columns["ManifestCode"]) != null)
                                detail.ManifestCode =
                                    OutboundBandaraView.GetRowCellValue(rowHandle,
                                        OutboundBandaraView.Columns["ManifestCode"]).ToString();

                            detail.Createddate = DateTime.Now;
                            detail.Createdby = BaseControl.UserLogin;

                            if (OutboundBandaraView.GetRowCellValue(rowHandle, OutboundBandaraView.Columns["StateChange2"])
                                .ToString()
                                .Equals(EnumStateChange.Insert.ToString()))
                            {
                                FormTrackingStatus = EnumTrackingStatus.Waybilled;
                                new AirwaybillDetailDataManager().Save<AirwaybillDetailModel>(detail);
                            }
                            else FormTrackingStatus = enumTrackingForm;

                            if (OutboundBandaraView.GetRowCellValue(rowHandle, OutboundBandaraView.Columns["StateChange2"])
                                .ToString()
                                .Equals(EnumStateChange.Update.ToString())) PodStatusModel.TrackingStatusId = (int)FormTrackingStatus;

                            InsertTracking = OutboundBandaraView.GetRowCellValue(rowHandle, OutboundBandaraView.Columns["StateChange2"])
                                .ToString()
                                .Equals(EnumStateChange.Insert.ToString());

                            if (detail.ShipmentId == 0)
                            {
                                //
                                var cekkonsole = detail.ShipmentCode.ToString().Substring(0, 3); 
                                if (cekkonsole == "CON")
                                {
                                    var kodekonsol =
                                        new ConsolidationDataManager().GetFirst<ConsolidationModel>(
                                            WhereTerm.Default(detail.ShipmentCode, "code", EnumSqlOperator.Equals));
                                    if (kodekonsol != null)
                                    {
                                        var detailkodekonsol =
                                            new ConsolidationDetailDataManager().Get<ConsolidationDetailModel>(
                                            WhereTerm.Default(kodekonsol.Id, "consolidation_id", EnumSqlOperator.Equals));
                                        foreach (var item in detailkodekonsol)
                                        {
                                            // ReSharper disable once PossibleInvalidOperationException
                                            PodStatusModel.ShipmentId = (int)item.ShipmentId;
                                            PodStatusModel.PositionStatusId = BaseControl.BranchId;
                                            PodStatusModel.PositionStatus = EnumPositionStatus.Branch.ToString();
                                            PodStatusModel.Reference = detail.AirwaybillCode;

                                            var br =
                                                new BranchDataManager().GetFirst<BranchModel>(
                                                    WhereTerm.Default(((AirwaybillModel)CurrentModel).DestBranchId, "id",
                                                    EnumSqlOperator.Equals));

                                            var al =
                                                new AirlineDataManager().GetFirst<AirlineModel>(
                                                    WhereTerm.Default(((AirwaybillModel)CurrentModel).AirlineId, "id",
                                                        EnumSqlOperator.Equals));
                                            PodStatusModel.StatusBy = string.Format("{0} ({1})", al.Code, br.Code);
                                            PodStatusModel.StatusNote = string.Format("{0} koli {1} kg",
                                                detail.TtlPiece.ToString("#0"),
                                                detail.TtlGrossWeight.ToString("#0.0"));

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
                                        // ReSharper disable once PossibleInvalidOperationException
                                        PodStatusModel.ShipmentId = (int)obj.ShipmentId;
                                        PodStatusModel.PositionStatusId = BaseControl.BranchId;
                                        PodStatusModel.PositionStatus = EnumPositionStatus.Branch.ToString();
                                        PodStatusModel.Reference = detail.AirwaybillCode;

                                        var br =
                                    new BranchDataManager().GetFirst<BranchModel>(
                                        WhereTerm.Default(((AirwaybillModel)CurrentModel).DestBranchId, "id",
                                            EnumSqlOperator.Equals));

                                        var al =
                                            new AirlineDataManager().GetFirst<AirlineModel>(
                                                WhereTerm.Default(((AirwaybillModel)CurrentModel).AirlineId, "id",
                                                    EnumSqlOperator.Equals));
                                        PodStatusModel.StatusBy = string.Format("{0} ({1})", al.Code, br.Code);
                                        PodStatusModel.StatusNote = string.Format("{0} koli {1} kg",
                                            detail.TtlPiece.ToString("#0"),
                                            detail.TtlGrossWeight.ToString("#0.0"));

                                        ShipmentStatusUpdate();
                                    }
                                }
                                /*
                                var manifestDetail =
                                    new ManifestDetailDataManager().Get<ManifestDetailModel>(
                                        WhereTerm.Default(detail.ShipmentCode, "consol_code", EnumSqlOperator.Equals));
                                foreach (ManifestDetailModel obj in manifestDetail)
                                {
                                    // ReSharper disable once PossibleInvalidOperationException
                                    PodStatusModel.ShipmentId = (int) obj.ShipmentId;
                                    PodStatusModel.PositionStatusId = BaseControl.BranchId;
                                    PodStatusModel.PositionStatus = EnumPositionStatus.Branch.ToString();
                                    PodStatusModel.Reference = detail.AirwaybillCode;

                                    var br =
                                new BranchDataManager().GetFirst<BranchModel>(
                                    WhereTerm.Default(((AirwaybillModel)CurrentModel).DestBranchId, "id",
                                        EnumSqlOperator.Equals));

                                    var al =
                                        new AirlineDataManager().GetFirst<AirlineModel>(
                                            WhereTerm.Default(((AirwaybillModel) CurrentModel).AirlineId, "id",
                                                EnumSqlOperator.Equals));
                                    PodStatusModel.StatusBy = string.Format("{0} ({1})", al.Code, br.Code);
                                    PodStatusModel.StatusNote = string.Format("{0} koli, {1} kg",
                                        detail.TtlPiece.ToString("#0"),
                                        detail.TtlGrossWeight.ToString("#0.0"));

                                    ShipmentStatusUpdate();
                                }
                                */
                            }
                            else
                            {
                                var ship =
                                    new ShipmentDataManager().GetFirst<ShipmentModel>(WhereTerm.Default(detail.ShipmentId,
                                        "id", EnumSqlOperator.Equals));
                                if (ship != null)
                                {
                                    if (InsertTracking)
                                    {
                                        if (ship.TrackingStatusId != (int)EnumTrackingStatus.Received && ship.TrackingStatusId != (int)EnumTrackingStatus.Claimed && ship.TrackingStatusId != (int)EnumTrackingStatus.Gudang) ship.TrackingStatusId = (int)EnumTrackingStatus.Waybilled;
                                        ship.AdminFee = airline.AdminFee;
                                        ship.VoidFee = airline.VoidFee;
                                        //var totalfee = ship.AdminFee + ship.VoidFee + ship.TariffTotal + ship.PackingFee;
                                        //ship.Total = totalfee;
                                        ship.Modifiedby = BaseControl.UserLogin;
                                        ship.Modifieddate = DateTime.Now;
                                        new ShipmentDataManager().Update<ShipmentModel>(ship);
                                    }

                                    PodStatusModel.ShipmentId = ship.Id;
                                    PodStatusModel.PositionStatusId = BaseControl.BranchId;
                                    PodStatusModel.PositionStatus = EnumPositionStatus.Branch.ToString();
                                    PodStatusModel.Reference = detail.AirwaybillCode;

                                    var br =
                                new BranchDataManager().GetFirst<BranchModel>(
                                    WhereTerm.Default(((AirwaybillModel)CurrentModel).DestBranchId, "id",
                                        EnumSqlOperator.Equals));

                                    var al =
                                        new AirlineDataManager().GetFirst<AirlineModel>(
                                            WhereTerm.Default(((AirwaybillModel)CurrentModel).AirlineId, "id",
                                                EnumSqlOperator.Equals));
                                    PodStatusModel.StatusBy = string.Format("{0} ({1})", al.Code, br.Code);
                                    PodStatusModel.StatusNote = string.Format("{0} koli {1} kg",
                                        detail.TtlPiece.ToString("#0"),
                                        detail.TtlGrossWeight.ToString("#0.0"));

                                    ShipmentStatusUpdate();
                                }
                            }
                        }

                        var temp =
                            OutboundBandaraView.GetRowCellValue(rowHandle,
                                OutboundBandaraView.Columns["TtlChargeableWeight"]).ToString();
                        if (temp.Contains(",") || temp.Contains(".")) temp = temp.Substring(0, temp.Length - 3);
                        dimension.Add(temp);

                        if (
                            (decimal)
                                OutboundBandaraView.GetRowCellValue(rowHandle,
                                    OutboundBandaraView.Columns["TtlChargeableWeight"]) != 0) totalPiece ++;
                        totalGw +=
                            (decimal)
                                OutboundBandaraView.GetRowCellValue(rowHandle,
                                    OutboundBandaraView.Columns["TtlGrossWeight"]);
                        totalCw +=
                            (decimal)
                                OutboundBandaraView.GetRowCellValue(rowHandle,
                                    OutboundBandaraView.Columns["TtlChargeableWeight"]);

                        FormTrackingStatus = enumTrackingForm;
                    }
                }

                var airwaybill =
                    new AirwaybillDataManager().GetFirst<AirwaybillModel>(WhereTerm.Default(CurrentModel.Id, "id",
                        EnumSqlOperator.Equals));
                airwaybill.TtlPiece = totalPiece;
                airwaybill.TtlGrossWeight = totalGw;
                airwaybill.TtlChargeableWeight = totalCw;
                airwaybill.Dimension = string.Join(", ", dimension.ToArray());

                new AirwaybillDataManager().Update<AirwaybillModel>(airwaybill);
                
                foreach (int o in DeletedRows)
                {
                    var detailExists =
                        new AirwaybillDetailDataManager().GetFirst<AirwaybillDetailModel>(
                            WhereTerm.Default(o, "id", EnumSqlOperator.Equals));
                    if (detailExists != null)
                    {
                        if (detailExists.ShipmentId == 0 && !detailExists.ShipmentCode.Contains("TRANSIT"))
                        {
                            var manifestDetail =
                                    new ManifestDetailDataManager().Get<ManifestDetailModel>(
                                        WhereTerm.Default(detailExists.ShipmentCode, "consol_code", EnumSqlOperator.Equals));
                            foreach (ManifestDetailModel obj in manifestDetail)
                            {
                                var shipmentStatus =
                                new ShipmentStatusDataManager().GetFirst<ShipmentStatusModel>(new IListParameter[]
                                {
                                    WhereTerm.Default((int)obj.ShipmentId, "shipment_id", EnumSqlOperator.Equals),
                                    WhereTerm.Default((int) FormTrackingStatus, "tracking_status_id",
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
                            if (detailExists.ShipmentId > 0)
                            {
                                var shipmentStatus =
                                    new ShipmentStatusDataManager().GetFirst<ShipmentStatusModel>(new IListParameter[]
                                {
                                    WhereTerm.Default(detailExists.ShipmentId, "shipment_id", EnumSqlOperator.Equals),
                                    WhereTerm.Default((int) FormTrackingStatus, "tracking_status_id",
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

                        new AirwaybillDetailDataManager().DeActive(o, BaseControl.UserLogin, DateTime.Now);
                    }
                }

                ToolbarCode = airwaybill.Id.ToString();
            }

            Enabled = true;
        }

        protected override void AfterSave()
        {
            OpenData(ToolbarCode);
        }

        public override void AfterDelete()
        {
            var detail = new AirwaybillDetailDataManager().Get<AirwaybillDetailModel>(WhereTerm.Default(CurrentModel.Id, "airwaybill_id", EnumSqlOperator.Equals));
            if (detail != null)
            {
                var repo = new AirwaybillDetailDataManager();
                var shipRepo = new ShipmentStatusDataManager();
                foreach (AirwaybillDetailModel obj in detail)
                {
                    repo.DeActive(obj.Id, BaseControl.UserLogin, DateTime.Now);
                    var shipmentStatus = shipRepo.GetFirst<ShipmentStatusModel>(new IListParameter[]
                        {
                            WhereTerm.Default(obj.ShipmentId, "shipment_id", EnumSqlOperator.Equals),
                            WhereTerm.Default((int) FormTrackingStatus, "tracking_status_id", EnumSqlOperator.Equals),
                            WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals)
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
            if (tbxDate.Text != "" && tbxAwb.Text != "" && tbxAirline.Text != "" && tbxOrigin.Text != "" &&
                tbxDestination.Text != "")
                return true;

            if (tbxDate.Text == "")
            {
                tbxDate.Focus();
                return false;
            }

            if (tbxAwb.Text == "")
            {
                tbxAwb.Focus();
                return false;
            }

            if (tbxAirline.Text == "")
            {
                tbxAirline.Focus();
                return false;
            }

            if (tbxOrigin.Text == "")
            {
                tbxOrigin.Focus();
                return false;
            }

            if (tbxDestination.Text == "")
            {
                tbxDestination.Focus();
                return false;
            }

            return false;
        }

        protected override void PopulateForm(AirwaybillModel model)
        {
            ClearForm();
            if (model == null) return;

            EnableBtnPrint = true;
            EnableBtnPrintPreview = true;
            btnAdd.Enabled = true;
            DeletedRows = new List<int>();

            ToolbarCode = model.Id.ToString();
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxDate.Text = model.DateProcess.ToString();
            tbxAwb.Text = model.Code;
            tbxAirline.DefaultValue = new IListParameter[] { WhereTerm.Default(model.AirlineId, "id", EnumSqlOperator.Equals) };
            tbxOrigin.DefaultValue = new IListParameter[] { WhereTerm.Default(model.AirportId, "id", EnumSqlOperator.Equals) };
            tbxDestination.DefaultValue = new IListParameter[] { WhereTerm.Default(model.DestAirportId, "id", EnumSqlOperator.Equals) };

            if (tbxDestination.Value != null)
            {
                var airport =
                    new AirportDataManager().GetFirst<AirportModel>(WhereTerm.Default((int)tbxDestination.Value,
                        "id", EnumSqlOperator.Equals));
                var city =
                    new CityDataManager().GetFirst<CityModel>(WhereTerm.Default(airport.CityId, "id",
                        EnumSqlOperator.Equals));
                AirportBranch = city.BranchId;
            }

            tbxEstDate.Text = model.EstDepDate.ToString();

            FlightDataSource();

            cbxFlight.SelectedValue = model.FlightId;
            tbxDimension.Text = model.Dimension;

            var details =
                new AirwaybillDetailDataManager().Get<AirwaybillDetailModel>(WhereTerm.Default(model.Id,
                    "airwaybill_id", EnumSqlOperator.Equals));

            GridOutboundBandara.DataSource = details;
            OutboundBandaraView.RefreshData();

            btnRevision.Visible = !model.IsCancelled;
            pnlRevision.Visible = false;
            if (model.IsCancelled)
            {
                pnlRevision.Visible = true;
                
                if (model.RevisedToId > 0)
                {
                    var smu = new AirwaybillDataManager().GetFirst<AirwaybillModel>(WhereTerm.Default((int)model.RevisedToId, "id"));
                    if (smu != null) lblRevisionNo.Text = smu.Code;
                }

                lblReason.Text = model.ReasonToRevision;
            }

            var revSMU = new AirwaybillDataManager().GetFirst<AirwaybillModel>(WhereTerm.Default(model.Id, "revised_to_id"));
            if (revSMU != null) FormTrackingStatus = EnumTrackingStatus.WaybilledRevised;
            else FormTrackingStatus = EnumTrackingStatus.Waybilled;
        }

        protected override AirwaybillModel PopulateModel(AirwaybillModel model)
        {
            model.DateProcess = tbxDate.Value;
            model.BranchId = BaseControl.BranchId;
            model.Code = tbxAwb.Text;
            if (tbxAirline.Value != null)
                model.AirlineId = (int) tbxAirline.Value;
            if (tbxOrigin.Value != null)
                model.AirportId = (int) tbxOrigin.Value;
            if (tbxDestination.Value != null)
                model.DestAirportId = (int) tbxDestination.Value;
            model.EstDepDate = tbxEstDate.Value;
            model.FlightId = (int?) cbxFlight.SelectedValue;

            var airport = new AirportDataManager().GetFirst<AirportModel>(WhereTerm.Default(model.DestAirportId, "id", EnumSqlOperator.Equals));
            if (airport != null)
            {
                var city = new CityDataManager().GetFirst<CityModel>(WhereTerm.Default(airport.CityId, "id", EnumSqlOperator.Equals));
                if (city != null)
                {
                    model.DestBranchId = city.BranchId;
                }
            }

            if (cbxFlight.SelectedValue != null)
            {
                var flight =
                    new FlightDataManager().GetFirst<FlightModel>(WhereTerm.Default((int) cbxFlight.SelectedValue, "id",
                        EnumSqlOperator.Equals));
                model.EstDepTime = flight.EstDepartureTime;
                model.FlightId = (int?) cbxFlight.SelectedValue;
            }
            else
            {
                model.EstDepTime = string.Empty;
                model.FlightId = 0;
            }

            model.StatusId = (int) EnumTrackingStatus.Waybilled;

            if (model.Id == 0) model.CreatedPc = Environment.MachineName;
            else model.ModifiedPc = Environment.MachineName;

            return model;
        }

        protected override AirwaybillModel Find(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm)) return null;
            if (!Regex.IsMatch(searchTerm, "^[0-9]+$")) return null;

            DataManager = new AirwaybillDataManager();
            if (!string.IsNullOrEmpty(searchTerm)) tsBaseTxt_Code.Text = searchTerm;
            var param = new IListParameter[]
                {
                    WhereTerm.Default(Convert.ToInt32(tsBaseTxt_Code.Text), "id", EnumSqlOperator.Equals)
                };
            var obj = DataManager.GetFirst<AirwaybillModel>(param);
            PopulateForm(obj);

            return obj;
        }

        public class Combo
        {
            public Int32 Id { get; set; }
            public String Text { get; set; }
        }

        public override void Info()
        {
            var model = CurrentModel as AirwaybillModel;
            if (model == null) return;
            info.CreatedPc = model.CreatedPc;
            info.ModifiedPc = model.ModifiedPc;

            base.Info();
        }

        private int ValidRowCount { get; set; }
        private List<String> Dimension { get; set; }
        private void OutboundBandaraView_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e)
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
                        Dimension.Add(Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, "TtlChargeableWeight").ToString()).ToString("#######0"));
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

        protected override void RefreshToolbarState()
        {
            base.RefreshToolbarState();

            var model = CurrentModel as AirwaybillModel;
            if (model != null && model.Id > 0)
            {
                tbxAwb.Enabled = false;
                tbxDate.Enabled = false;
                tbxDate.Properties.Buttons[0].Enabled = false;
                tbxAirline.Enabled = false;
                tbxAirline.Properties.Buttons[0].Enabled = false;
                tbxOrigin.Enabled = false;
                tbxOrigin.Properties.Buttons[0].Enabled = false;
                tbxDestination.Enabled = false;
                tbxDestination.Properties.Buttons[0].Enabled = false;
                tbxEstDate.Enabled = false;
                cbxFlight.Enabled = false;

                if (model.IsCancelled)
                {
                    btnAdd.Enabled = false;
                    tsBaseBtn_Save.Enabled = false;
                    tsBaseBtn_Delete.Enabled = false;
                    NavigationMenu.SaveStrip.Enabled = false;
                    NavigationMenu.DeleteStrip.Enabled = false;
                }
            }
        }
    }
}