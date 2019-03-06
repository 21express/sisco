using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.WinControl.MessageBox;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class ConsolidationForm : BaseCrudForm<ConsolidationModel, ConsolidationDataManager>//BaseToolbarForm//
    {
        private string Code { get; set; }
        private string PriorityService { get; set; }
        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        // ReSharper disable once InconsistentNaming
        private ConsolidationFilterPopup Fpe = new ConsolidationFilterPopup();
        private List<int> DeletedRows { get; set; }

        public ConsolidationForm()
        {
            InitializeComponent();
            form = this;

            Load += ConsolidationLoad;
            btnAdd.Click += (sender, e) => AddRow();

            ConsolidationView.DataSourceChanged += (sender, args) =>
            {
                PriorityService = "";
            };

            FormTrackingStatus = EnumTrackingStatus.Consolidation;

            btnDelete.ButtonClick += DeleteRow;
            ConsolidationView.CustomColumnDisplayText += NumberGrid;
            GridConsolidation.DoubleClick += (sender, args) => OpenRelatedForm(ConsolidationView, new TrackingViewForm(), "ShipmentCode");

            DataManager.DefaultParameters = new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals) };
            SearchPopup = Fpe;

            btnPrint.Click += Print;

            ConsolidationView.RowStyle += ChangeColor;
            tbxBarcode.KeyDown += (sender, args) =>
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

        private void Printkitir(object sender, EventArgs e)
        {
            
        }

        private void ChangeColor(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var view = sender as GridView;

                if (view == null) return;

                //e.Appearance.ForeColor = Color.Black;
                e.Appearance.BackColor = Color.Transparent;
                e.Appearance.ForeColor = Color.Black;
                if ((string)view.GetRowCellValue(e.RowHandle, view.Columns["ServiceType"]) == "SDS")
                {
                    PriorityService = "SDS";
                    //e.Appearance.BackColor = Color.Red;
                    //e.Appearance.BackColor2 = Color.Transparent;
                    e.Appearance.ForeColor = Color.Red;
                }
                else if ((string)view.GetRowCellValue(e.RowHandle, view.Columns["ServiceType"]) == "ONS")
                {
                    if (PriorityService == "SDS")
                    {
                    }
                    else
                    {
                        PriorityService = "ONS";
                    }

                    //e.Appearance.BackColor = Color.Orange;
                    //e.Appearance.BackColor2 = Color.Transparent;
                    e.Appearance.ForeColor = Color.DarkOrange;
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
                if (route.BranchTransitId != tbxBranch.Value) return false;
            }
            else return false;

            return true;
        }

        private void DeleteRow(object sender, ButtonPressedEventArgs e)
        {
            var dialog = MessageForm.Ask(form, Resources.delete_confirm, Resources.delete_confirm_msg);
            if (dialog == DialogResult.Yes)
            {
                var rowHandle = ConsolidationView.FocusedRowHandle;
                if (ConsolidationView.GetRowCellValue(rowHandle, ConsolidationView.Columns["Id"]) != null) DeletedRows.Add((int)ConsolidationView.GetRowCellValue(rowHandle, ConsolidationView.Columns["Id"]));
                ConsolidationView.DeleteSelectedRows();
            }
        }

        private void AddRow()
        {
            if (tbxBarcode.Text == string.Empty) return;

            // ReSharper disable once NotAccessedVariable
            var urut = "001";
            var code = tbxBarcode.Text;
            var shipment = new ShipmentDataManager().GetFirst<ShipmentModel>(WhereTerm.Default(tbxBarcode.Text, "code", EnumSqlOperator.Equals));
            if (shipment == null)
            {
                urut = tbxBarcode.Text.Substring(tbxBarcode.TextLength - 3);
                code = tbxBarcode.Text.Substring(0, tbxBarcode.TextLength - 3);
                shipment = new ShipmentDataManager().GetFirst<ShipmentModel>(WhereTerm.Default(code, "code", EnumSqlOperator.Equals));

                if (shipment == null)
                {
                    //AutoClosingMessageBox.Show(@"POD tidak diketahui", Resources.information);
                    MessageBox.Show("POD tidak diketahui");
                    tbxBarcode.Clear();
                    tbxBarcode.Focus();
                    return;
                }
                if (shipment.TtlPiece < Convert.ToInt16(urut))
                {
                    tbxBarcode.Clear();
                    tbxBarcode.Focus();
                    return;
                }
            }

            /*var manifested = new ManifestDetailDataManager().Get<ManifestDetailModel>(WhereTerm.Default(shipment.Code, "shipment_code", EnumSqlOperator.Equals)).FirstOrDefault(p => p.OrigBranchId == BaseControl.BranchId);
            if (manifested != null)
            {
                AutoClosingMessageBox.Show(Resources.information, string.Format(Resources.registered_manifest, tbxBarcode.Text));
                tbxBarcode.Focus();
                tbxBarcode.Clear();
                return;
            }*/

            if (shipment.DestBranchId != null && !CheckRoute((int) shipment.DestBranchId))
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
                        MessageForm.Warning(form, "POD Retur", "Untuk POD retur, mohon info ke Customer Service untuk update POD sebagai RETURN agar bisa dilakukan consolidation ke tujuan Cabang pengirim.");
                        tbxBarcode.Focus();
                        tbxBarcode.Clear();
                        return;
                    }
                }
                else
                {
                    //AutoClosingMessageBox.Show(string.Format(Resources.check_destination, tbxBarcode.Text), Resources.information);
                    MessageBox.Show(string.Format(Resources.check_destination, tbxBarcode.Text));
                    tbxBarcode.Focus();
                    tbxBarcode.Text = "";
                    return;
                }
            }

            var payment = new PaymentMethodDataManager().GetFirst<PaymentMethodModel>(WhereTerm.Default(shipment.PaymentMethodId, "id", EnumSqlOperator.Equals));
            var service = new ServiceTypeDataManager().GetFirst<ServiceTypeModel>(WhereTerm.Default(shipment.ServiceTypeId, "id", EnumSqlOperator.Equals));
            var package = new ServiceTypeDataManager().GetFirst<ServiceTypeModel>(WhereTerm.Default(shipment.PackageTypeId, "id", EnumSqlOperator.Equals));

            var s = new ConsolidationDetailDataManager().Get<ConsolidationDetailModel>(
                new IListParameter[]
                {
                    WhereTerm.Default(code, "shipment_code", EnumSqlOperator.Equals),
                    WhereTerm.Default(urut, "consolidation_code", EnumSqlOperator.Equals)
                }
            ).FirstOrDefault();
            if (s != null)
            {
                //AutoClosingMessageBox.Show(string.Format(Resources.registered_consolidation, code), Resources.information);
                MessageBox.Show(string.Format(Resources.registered_consolidation, code));
                tbxBarcode.Focus();
                tbxBarcode.Clear();
                return;
            }

            var cons = new List<ConsolidationDetailModel>();
            if (ConsolidationView.RowCount > 0)
            {
                cons = GridConsolidation.DataSource as List<ConsolidationDetailModel>;

                if (string.IsNullOrEmpty(urut))
                {
                    if (cons != null) s = cons.FirstOrDefault(b => b.ShipmentCode == tbxBarcode.Text);
                    if (s != null) {
                        tbxBarcode.Focus();
                        tbxBarcode.Clear();
                        return; 
                    }
                }
                else
                {
                    if (cons != null)
                        s = cons.FirstOrDefault(b => b.ShipmentCode == code && b.ConsolidationCode == urut);
                    if (s != null)
                    {
                        tbxBarcode.Focus();
                        tbxBarcode.Clear();
                        return;
                    }
                }
            }

            var detail = new ConsolidationDetailModel
            {
                ConsolidationCode = urut,
                DateProcess = DateTime.Now,
                CustomerName = shipment.CustomerName,
                Consignee = shipment.ConsigneeName,
                DestCity = shipment.DestCity,
                PaymentMethod = payment.Name,
                ServiceType = service.Name,
                PackageType = package.Name,
                NatureGoods = shipment.NatureOfGoods,
                ShipmentId = shipment.Id,
                ShipmentDate = shipment.DateProcess,
                ShipmentCode = shipment.Code,
                BranchId = BaseControl.BranchId,
                DestCityId = shipment.DestCityId,
                ServiceTypeId = shipment.ServiceTypeId,
                PackageTypeId = shipment.PackageTypeId,
                PaymentMethodId = shipment.PaymentMethodId,
                TtlPiece = string.IsNullOrEmpty(urut) ? shipment.TtlPiece : (short)1,
                TtlGrossWeight = 0,//shipment.TtlGrossWeight,
                TtlChargeableWeight = 0,//shipment.TtlChargeableWeight,
                StateChange2 = EnumStateChange.Insert.ToString()
            };

            if (cons != null)
            {
                cons.Add(detail);
                GridConsolidation.DataSource = cons;
                ConsolidationView.RefreshData();
                ConsolidationView.FocusedRowHandle = ConsolidationView.RowCount - 1;
            }

            _ClearForm(pnlRight);

            tbxBarcode.Focus();
        }

        private void ConsolidationLoad(object sender, EventArgs e)
        {
            EnableBtnSearch = true;
            btnPrint.Enabled = false;

            tbxBranch.LookupPopup = new BranchPopup();
            tbxBranch.AutoCompleteDataManager = new BranchDataManager();
            tbxBranch.AutoCompleteDisplayFormater = model => ((BranchModel)model).Code + " " + ((BranchModel)model).Name;
            tbxBranch.AutoCompleteWhereExpression +=
                (s, param) => param.SetWhereExpression("code = @0 or name.StartsWith(@0)", s);

            tbxDate.Enabled = false;
            tbxDate.Properties.Buttons[0].Enabled = false;

            Fpe.DefaultParam = new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals) };
        }

        public override void AfterDelete()
        {
            var code = tsBaseTxt_Code.Text;
            var repo = new ConsolidationDetailDataManager();
            var detail = repo.Get<ConsolidationDetailModel>(WhereTerm.Default(CurrentModel.Id, "consolidation_id", EnumSqlOperator.Equals));

            if (detail != null)
            {
                var conRepo = new ConsolidationDataManager().GetFirst<ConsolidationModel>(new IListParameter[]
                    {
                        WhereTerm.Default(CurrentModel.Id, "id", EnumSqlOperator.Equals)
                    });

                var shipRepo = new ShipmentStatusDataManager();
                foreach (ConsolidationDetailModel obj in detail)
                {
                    repo.DeActive(obj.Id, BaseControl.UserLogin, DateTime.Now);
                    var shipmentStatus = shipRepo.GetFirst<ShipmentStatusModel>(new IListParameter[]
                        {
                            WhereTerm.Default(obj.ShipmentId, "shipment_id", EnumSqlOperator.Equals),
                            WhereTerm.Default((int) EnumTrackingStatus.Consolidation, "tracking_status_id", EnumSqlOperator.Equals),
                            WhereTerm.Default(code, "reference", EnumSqlOperator.Equals)
                        });
                    if (shipmentStatus != null)
                    {
                        shipRepo.DeActive(shipmentStatus.Id, BaseControl.UserLogin, DateTime.Now);
                    }
                }
                    
                    //
                
            }

            base.AfterDelete();
        }

        public override void New()
        {
            base.New();

            ClearForm();
            PriorityService = "";
            DeletedRows = new List<int>();
            ToolbarCode = string.Empty;
            StateChange = EnumStateChange.Insert;
            GridConsolidation.DataSource = null;
            ConsolidationView.RefreshData();

            btnPrint.Enabled = false;

            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxDate.Text = DateTime.Now.ToString();
            tbxBranch.Focus();
        }

        public override void Save()
        {
            if (ConsolidationView.RowCount == 0)
            {
                MessageForm.Info(form, Resources.title_save_changes, Resources.alert_empty_field);
                return;
            }

            if (CurrentModel.Id == 0)
            {
                if (tbxDate.Text != "")
                    Code = GetCode("consolidation", tbxDate.Value);
            }
            else
            {
                var consol = new ConsolidationDataManager().GetFirst<ConsolidationModel>(WhereTerm.Default(CurrentModel.Id, "id", EnumSqlOperator.Equals));
                Code = consol.Code;
            }

            base.Save();
        }

        protected override void SaveDetail(bool isUpdate = false)
        {
            Enabled = false;
            var consolidation = new ConsolidationDataManager().GetFirst<ConsolidationModel>(WhereTerm.Default(CurrentModel.Id, "id", EnumSqlOperator.Equals));
            Code = consolidation.Code;

            var totalPiece = 0;
            // ReSharper disable once NotAccessedVariable
            decimal totalGw = 0;
            // ReSharper disable once NotAccessedVariable
            decimal totalCw = 0;
            for (int i = 0; i < ConsolidationView.RowCount; i++)
            {
                int rowHandle = ConsolidationView.GetVisibleRowHandle(i);
                if (ConsolidationView.IsDataRow(rowHandle))
                {
                    var state = ConsolidationView.GetRowCellValue(rowHandle,
                        ConsolidationView.Columns["StateChange2"]);
                    if (state.ToString().Equals(EnumStateChange.Insert.ToString()))
                    {
                        var detail = new ConsolidationDetailModel();
                        detail.Rowstatus = true;
                        detail.Rowversion = DateTime.Now;
                        detail.ConsolidationId = CurrentModel.Id;
                        detail.DateProcess =
                            (DateTime)
                                ConsolidationView.GetRowCellValue(rowHandle,
                                    ConsolidationView.Columns["DateProcess"]);
                        detail.ConsolidationCode =
                                ConsolidationView.GetRowCellValue(rowHandle, ConsolidationView.Columns["ConsolidationCode"]).ToString();
                        detail.ShipmentId =
                            (int)
                                ConsolidationView.GetRowCellValue(rowHandle, ConsolidationView.Columns["ShipmentId"]);
                        detail.CustomerName =
                            ConsolidationView.GetRowCellValue(rowHandle, ConsolidationView.Columns["CustomerName"]) != null ?ConsolidationView.GetRowCellValue(rowHandle, ConsolidationView.Columns["CustomerName"]).ToString() : "";
                        detail.Consignee =
                            ConsolidationView.GetRowCellValue(rowHandle, ConsolidationView.Columns["Consignee"]) != null ? ConsolidationView.GetRowCellValue(rowHandle, ConsolidationView.Columns["Consignee"]).ToString() : "";
                        detail.DestCity =
                            ConsolidationView.GetRowCellValue(rowHandle, ConsolidationView.Columns["DestCity"])
                                .ToString();
                        detail.PaymentMethod =
                            ConsolidationView.GetRowCellValue(rowHandle, ConsolidationView.Columns["PaymentMethod"])
                                .ToString();
                        detail.ServiceType =
                            ConsolidationView.GetRowCellValue(rowHandle, ConsolidationView.Columns["ServiceType"])
                                .ToString();

                        if (ConsolidationView.GetRowCellValue(rowHandle, ConsolidationView.Columns["NatureGoods"]) != null)
                            detail.NatureGoods =
                                ConsolidationView.GetRowCellValue(rowHandle, ConsolidationView.Columns["NatureGoods"])
                                    .ToString();

                        detail.ShipmentDate =
                            (DateTime)
                                ConsolidationView.GetRowCellValue(rowHandle,
                                    ConsolidationView.Columns["ShipmentDate"]);
                        detail.ShipmentCode =
                            ConsolidationView.GetRowCellValue(rowHandle, ConsolidationView.Columns["ShipmentCode"])
                                .ToString();
                        detail.BranchId = BaseControl.BranchId;
                        detail.DestCityId =
                            (int)
                                ConsolidationView.GetRowCellValue(rowHandle, ConsolidationView.Columns["DestCityId"]);
                        detail.ServiceTypeId =
                            (int)
                                ConsolidationView.GetRowCellValue(rowHandle,
                                    ConsolidationView.Columns["ServiceTypeId"]);
                        detail.PackageTypeId =
                            (int)
                                ConsolidationView.GetRowCellValue(rowHandle,
                                    ConsolidationView.Columns["PackageTypeId"]);
                        detail.PaymentMethodId =
                            (int)
                                ConsolidationView.GetRowCellValue(rowHandle,
                                    ConsolidationView.Columns["PaymentMethodId"]);
                        detail.TtlPiece =
                            (short)
                                ConsolidationView.GetRowCellValue(rowHandle, ConsolidationView.Columns["TtlPiece"]);

                        detail.TtlGrossWeight =
                            (decimal)
                                ConsolidationView.GetRowCellValue(rowHandle,
                                    ConsolidationView.Columns["TtlGrossWeight"]);
                        detail.TtlChargeableWeight =
                            (decimal)
                                ConsolidationView.GetRowCellValue(rowHandle,
                                    ConsolidationView.Columns["TtlChargeableWeight"]);
                        detail.Createddate = DateTime.Now;
                        detail.Createdby = BaseControl.UserLogin;

                        new ConsolidationDetailDataManager().Save<ConsolidationDetailModel>(detail);
                    
                        //status update consolidation
                        var ship =
                            new ShipmentDataManager().GetFirst<ShipmentModel>(
                                WhereTerm.Default((int)detail.ShipmentId, "id", EnumSqlOperator.Equals));
                        if (ship != null)
                        {
                            

                            InsertTracking = true;
                            PodStatusModel.ShipmentId = ship.Id;
                            PodStatusModel.Reference = consolidation.Code;
                            PodStatusModel.StatusNote = detail.ConsolidationCode;
                            PodStatusModel.PositionStatusId = BaseControl.BranchId;
                            PodStatusModel.PositionStatus = EnumPositionStatus.Branch.ToString();

                            var br =
                                new BranchDataManager().GetFirst<BranchModel>(
                                    WhereTerm.Default(((ConsolidationModel)CurrentModel).DestBranchId, "id",
                                        EnumSqlOperator.Equals));
                            PodStatusModel.StatusBy = br.Code;

                            ShipmentStatusUpdate();
                        }
                    // batas
                    }

                    totalPiece +=
                        (short)
                            ConsolidationView.GetRowCellValue(rowHandle, ConsolidationView.Columns["TtlPiece"]);
                    totalGw +=
                        (decimal)
                            ConsolidationView.GetRowCellValue(rowHandle,
                                ConsolidationView.Columns["TtlGrossWeight"]);
                    totalCw +=
                        (decimal)
                            ConsolidationView.GetRowCellValue(rowHandle,
                                ConsolidationView.Columns["TtlChargeableWeight"]);
                }
            }
            
            consolidation.TtlPiece = totalPiece;
            consolidation.TtlChargeableWeight = 0;

            new ConsolidationDataManager().Update<ConsolidationModel>(consolidation);

            foreach (int o in DeletedRows)
            {
                var detailRow = new ConsolidationDetailDataManager().GetFirst<ConsolidationDetailModel>(WhereTerm.Default(o, "id"));
                if (detailRow != null)
                {
                    var statusRow = new ShipmentStatusDataManager().GetFirst<ShipmentStatusModel>(new IListParameter[]
                    {
                        WhereTerm.Default(detailRow.ShipmentId, "shipment_id"),
                        WhereTerm.Default(consolidation.Code, "reference"),
                        WhereTerm.Default((int)EnumTrackingStatus.Consolidation, "tracking_status_id"),
                        WhereTerm.Default(detailRow.ConsolidationCode, "status_note", EnumSqlOperator.Like)
                    });

                    if (statusRow != null)
                    {
                        var notes = statusRow.StatusNote.Split(',').ToList();
                        var newNotes = new List<string>();
                        foreach (var n in notes) if (n != detailRow.ConsolidationCode) newNotes.Add(n);

                        if (newNotes.Count == 0)
                            new ShipmentStatusDataManager().DeActive(statusRow.Id, BaseControl.UserLogin, DateTime.Now);
                        else
                        {
                            statusRow.StatusNote = string.Join(",", newNotes);
                            statusRow.Modifiedby = BaseControl.UserLogin;
                            statusRow.Modifieddate = DateTime.Now;
                            
                            new ShipmentStatusDataManager().Update<ShipmentStatusModel>(statusRow);
                        }
                    }
                }

                new ConsolidationDetailDataManager().DeActive(o, BaseControl.UserLogin, DateTime.Now);
            }

            Enabled = true;
            ToolbarCode = consolidation.Code;
        }

        protected override void AfterSave()
        {
            tsBaseTxt_Code.Focus();

            var paramparam = DataManager.DefaultParameters;
            DataManager = new ConsolidationDataManager();
            DataManager.DefaultParameters = paramparam;

            PerformFind();
        }

        protected override bool ValidateForm()
        {
            if (tbxDate.Text != "" && tbxWeight.Value > 0)
                return true;

            if (tbxWeight.Value < 1)
            {
                tbxWeight.Focus();
                return false;
            }

            return false;
        }

        protected override void PopulateForm(ConsolidationModel model)
        {
            ClearForm();
            GridConsolidation.DataSource = null;
            if (model == null) return;

            DeletedRows = new List<int>();
            tbxDate.Enabled = false;
            tbxDate.Properties.Buttons[0].Enabled = false;

            btnPrint.Enabled = true;

            ToolbarCode = model.Code;
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxDate.Text = model.DateProcess.ToString();
            tbxBranch.DefaultValue = new IListParameter[] { WhereTerm.Default(model.DestBranchId, "id", EnumSqlOperator.Equals) };
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxWeight.SetValue(model.TtlGrossWeight.ToString());

            var details =
                new ConsolidationDetailDataManager().Get<ConsolidationDetailModel>(WhereTerm.Default(model.Id,
                    "consolidation_id", EnumSqlOperator.Equals));

            GridConsolidation.DataSource = details;
            //ConsolidationView.RefreshData();
        }

        protected override ConsolidationModel PopulateModel(ConsolidationModel model)
        {
            model.DateProcess = tbxDate.Value;
            model.Code = Code;
            model.BranchId = BaseControl.BranchId;

            if (tbxBranch.Value != null) model.DestBranchId = (int) tbxBranch.Value;
            model.TtlGrossWeight = tbxWeight.Value;

            if (model.Id == 0) model.CreatedPc = Environment.MachineName;
            else model.ModifiedPc = Environment.MachineName;

            return model;
        }

        protected override ConsolidationModel Find(string searchTerm)
        {
            var param = new IListParameter[]
                {
                    WhereTerm.Default(tsBaseTxt_Code.Text, "code", EnumSqlOperator.Equals)
                };
            var obj = DataManager.GetFirst<ConsolidationModel>(param);
            PopulateForm(obj);

            return obj;
        }

        public override void Info()
        {
            var model = CurrentModel as ConsolidationModel;

            if (model != null)
            {
                info.CreatedPc = model.CreatedPc;
                info.ModifiedPc = model.ModifiedPc;
            }

            base.Info();
        }

        private void Print(object sender, EventArgs e)
        {
            var mdl = CurrentModel as ConsolidationModel;
            var barcode = new List<PrintBarcode>();

            if (mdl != null)
            {
                var orig = new BranchDataManager().GetFirst<BranchModel>(WhereTerm.Default(mdl.BranchId, "id", EnumSqlOperator.Equals));
                var dest = new BranchDataManager().GetFirst<BranchModel>(WhereTerm.Default(mdl.DestBranchId, "id", EnumSqlOperator.Equals));
                barcode.Add(new PrintBarcode
                {
                    DateProcess = mdl.DateProcess,
                    BranchName = orig.Code,
                    DestBranchName = dest.Code,
                    Number = mdl.TtlPiece.ToString("#0"),
                    Code = mdl.Code,
                    Count = 0,
                    //ServiceType = string.Empty,
                    ServiceType = PriorityService,
                    GrossWeight = mdl.TtlGrossWeight
                });

                var a = new ConsolBarcodeCard();
                a.DataSource = barcode;
                a.CreateDocument();

                var printTool = new ReportPrintTool(a);
                printTool.PrintingSystem.StartPrint += (o, args) =>
                {
                    args.PrintDocument.PrinterSettings.PrinterName = BaseControl.PrinterSetting.Barcode;
                };
                printTool.Print();

                var detail = new PrintBarcodeCustomer{
                    DateProcess = mdl.DateProcess,
                    BranchName = orig.Code,
                    DestBranchName = dest.Code,
                    Number = mdl.TtlPiece.ToString("#0"),
                    Code = mdl.Code,
                    Count = 0,
                    ServiceType = PriorityService,
                    GrossWeight = mdl.TtlGrossWeight
                };

                var detailGrid = GridConsolidation.DataSource as List<ConsolidationDetailModel>;
                var customers = detailGrid.GroupBy(p => p.CustomerName).Select(p => p.Key).ToList();
                var pods = detailGrid.GroupBy(p => p.ShipmentCode).Select(p => p.Key.Substring(p.Key.Length - 4)).ToList();

                for(var i = 0; i < customers.Count(); i ++)
                {
                    switch (i)
                    {
                        case 0: detail.Customer1 = customers[i];
                            break;
                        case 1: detail.Customer2 = customers[i];
                            break;
                        case 2: detail.Customer3 = customers[i];
                            break;
                        case 3: detail.Customer4 = customers[i];
                            break;
                        case 4: detail.Customer5 = customers[i];
                            break;
                    }
                }

                detail.Customer6 = string.Join(",", pods);
                var b = new ConsolSMUCard();
                b.DataSource = new List<PrintBarcodeCustomer>{ detail };
                b.CreateDocument();

                printTool = new ReportPrintTool(b);
                printTool.PrintingSystem.StartPrint += (o, args) =>
                {
                    args.PrintDocument.PrinterSettings.PrinterName = BaseControl.PrinterSetting.Barcode;
                };
                printTool.Print();
            }
        }
    }
}