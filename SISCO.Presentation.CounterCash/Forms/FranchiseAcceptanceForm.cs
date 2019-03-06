using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.WinControl.MessageBox;
using SISCO.App.Franchise;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Properties;
using SISCO.Presentation.CustomerService.Forms;
using SISCO.Presentation.CounterCash.Popup;

namespace SISCO.Presentation.CounterCash.Forms
{
    public partial class FranchiseAcceptanceForm : BaseCrudForm<FranchiseAcceptanceModel, FranchiseAcceptanceDataManager>//BaseToolbarForm//
    {
        private string Code { get; set; }
        private AcceptanceFilterPopup Fpe = new AcceptanceFilterPopup();
        private bool FocusBarcode { get; set; }
        private int FranchisePickupId { get; set; }
        private int FranchiseId { get; set; }

        public FranchiseAcceptanceForm()
        {
            InitializeComponent();

            form = this;
            Load += AcceptanceLoad;
            btnAdd.Click += (sender, e) => AddRow();
            tbxPickup.Leave += GetPickup;

            AcceptanceView.CustomColumnDisplayText += NumberGrid;
            AcceptanceListView.CustomColumnDisplayText += NumberGrid;

            tsBaseBtn_Delete.Visible = false;
            tsBaseBtn_Print.Visible = false;
            tsBaseBtn_PrintPreview.Visible = false;

            FormTrackingStatus = EnumTrackingStatus.Acceptance;
            GridAcceptanceList.DoubleClick += (sender, args) => OpenRelatedForm(AcceptanceListView, new TrackingViewForm(), "ShipmentCode");
            DataManager.DefaultParameters = new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals) };

            tbxPod.KeyDown += (sender, args) =>
            {
                FocusBarcode = false;
                if (args.KeyCode == Keys.Enter)
                {
                    FocusBarcode = true;
                }
            };

            btnAdd.GotFocus += (sender, args) =>
            {
                if (FocusBarcode)
                {
                    FocusBarcode = false;
                    AddRow();
                }
            };
        }

        private void AddRow()
        {
            if (tbxPickup.Text == string.Empty) tbxPickup.Focus();
            if (tbxPod.Text == string.Empty) tbxPod.Focus();
            if (AcceptanceListView.RowCount == 0) tbxPickup.Focus();

            var shipment = new ShipmentDataManager().GetFirst<ShipmentModel>(WhereTerm.Default(tbxPod.Text, "code", EnumSqlOperator.Equals));
            if (shipment == null) MessageForm.Info(this, Resources.information, "No POD tidak dikenali.");
            else
            {
                var accepted = new FranchiseAcceptanceDetailDataManager().GetFirst<FranchiseAcceptanceDetailModel>(WhereTerm.Default(shipment.Id, "shipment_id", EnumSqlOperator.Equals));
                if (accepted != null) MessageForm.Info(this, Resources.information, "No POD sudah di proses acceptance.");
                else
                {
                    var ds = GridAcceptanceList.DataSource as List<FranchisePickupDetailModel>;
                    if (ds != null)
                    {
                        var newAcceptance = ds.Where(a => a.ShipmentId == shipment.Id).Select(a => new FranchiseAcceptanceDetailModel
                        {
                            ShipmentId = shipment.Id,
                            ShipmentCode = shipment.Code,
                            ShipmentDate = shipment.DateProcess,
                            ServiceTypeId = shipment.ServiceTypeId,
                            PackageTypeId = shipment.PackageTypeId,
                            PaymentMethodId = shipment.PaymentMethodId,
                            TtlPiece = shipment.TtlPiece,
                            TtlChargeableWeight = shipment.TtlChargeableWeight,
                            TtlGrossWeight = shipment.TtlGrossWeight
                        }).FirstOrDefault();

                        var accept = GridAcceptance.DataSource as List<FranchiseAcceptanceDetailModel>;
                        if (accept == null) accept = new List<FranchiseAcceptanceDetailModel>();

                        var exists = accept.Where(a => a.ShipmentId == shipment.Id);
                        if (!exists.Any())
                        {
                            accept.Add(newAcceptance);

                            GridAcceptance.DataSource = accept;
                            AcceptanceView.RefreshData();

                            var shipcode = accept.Select(x => x.ShipmentCode);
                            var newInbound = ds.Where(y => !shipcode.Contains(y.ShipmentCode)).ToList();

                            GridAcceptanceList.DataSource = newInbound;
                            AcceptanceListView.RefreshData();
                        }
                    }
                }
            }

            tbxPod.Clear();
            tbxPod.Focus();
        }

        private void GetPickup(object sender, EventArgs e)
        {
            if (tbxPickup.Enabled && tbxPickup.Text != string.Empty)
            {
                var pickup = new FranchisePickupDataManager().GetFirst<FranchisePickupModel>(WhereTerm.Default(tbxPickup.Text, "code", EnumSqlOperator.Equals));
                if (pickup != null)
                {
                    var details = new FranchisePickupDetailDataManager().GetPickupAcceptance(WhereTerm.Default(pickup.Id, "franchise_pickup_id", EnumSqlOperator.Equals));
                    if (details.Count == 0)
                    {
                        MessageForm.Info(this, Resources.information, "Tidak ada data POD pada No Pickup tersebut.");
                        tbxPickup.Clear();
                        tbxPickup.Focus();
                    }

                    FranchisePickupId = pickup.Id;

                    var accept = GridAcceptance.DataSource as List<FranchiseAcceptanceDetailModel>;
                    if (accept != null)
                    {
                        var shipcode = accept.Select(x => x.ShipmentCode);
                        details = details.Where(y => !shipcode.Contains(y.ShipmentCode)).ToList();
                    }

                    GridAcceptanceList.DataSource = details;
                    AcceptanceListView.RefreshData();

                    FranchiseId = pickup.FranchiseId;
                    var franchise =
                        new FranchiseDataManager().GetFirst<FranchiseModel>(WhereTerm.Default(pickup.FranchiseId,
                            "id", EnumSqlOperator.Equals));
                    if (franchise != null) lblFranchise.Text = string.Format("{0} {1}", franchise.Code, franchise.Name);
                }
                else
                {
                    MessageForm.Info(this, Resources.information, "No Pickup tidak dikenali.");
                    tbxPickup.Focus();
                }
            }
        }

        private void AcceptanceLoad(object sender, EventArgs e)
        {
            EnableBtnSearch = true;
            SearchPopup = new AcceptanceFilterPopup();

            Fpe.DefaultParam = new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals) };
        }

        public override void New()
        {
            base.New();

            ClearForm();
            EnabledForm(true);
            ToolbarCode = string.Empty;

            StateChange = EnumStateChange.Insert;
            GridAcceptance.DataSource = null;
            AcceptanceView.RefreshData();

            GridAcceptanceList.DataSource = null;
            AcceptanceListView.RefreshData();

            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxDate.Text = DateTime.Now.ToString();
            tbxPickup.Focus();

            tbxDate.Enabled = false;
            tbxDate.Properties.Buttons[0].Enabled = false;
        }

        public override void Save()
        {
            if (AcceptanceView.RowCount == 0)
            {
                MessageBox.Show(
                   Resources.stt_detail_empty
                   , Resources.title_save_changes
                   , MessageBoxButtons.OK
                   , MessageBoxIcon.Information);

                return;
            }

            if (CurrentModel.Id == 0)
            {
                if (tbxDate.Text != "")
                    Code = GetCode("acceptance", tbxDate.Value);
            }
            else
            {
                var acceptance = new FranchiseAcceptanceDataManager().GetFirst<FranchiseAcceptanceModel>(WhereTerm.Default(CurrentModel.Id, "id", EnumSqlOperator.Equals));
                Code = acceptance.Code;
            }

            base.Save();
        }

        protected override void SaveDetail(bool isUpdate = false)
        {
            Enabled = false;
            var acceptance = new FranchiseAcceptanceDataManager().GetFirst<FranchiseAcceptanceModel>(WhereTerm.Default(CurrentModel.Id, "id", EnumSqlOperator.Equals));
            Code = acceptance.Code;

            StateChange = EnumStateChange.Select;
            short totalPiece = 0;
            decimal totalGw = 0;
            decimal totalCw = 0;
            for (int i = 0; i < AcceptanceView.RowCount; i++)
            {
                int rowHandle = AcceptanceView.GetVisibleRowHandle(i);
                if (AcceptanceView.IsDataRow(rowHandle))
                {
                    var detail = new FranchiseAcceptanceDetailModel();
                    detail.Rowstatus = true;
                    detail.Rowversion = DateTime.Now;
                    detail.FranchiseAcceptanceId = acceptance.Id;

                    if (AcceptanceView.GetRowCellValue(rowHandle, AcceptanceView.Columns["ShipmentId"]) != null)
                        detail.ShipmentId =
                            (int)AcceptanceView.GetRowCellValue(rowHandle, AcceptanceView.Columns["ShipmentId"]);

                    if (AcceptanceView.GetRowCellValue(rowHandle, AcceptanceView.Columns["ShipmentDate"]) != null)
                        detail.ShipmentDate =
                            (DateTime)
                                AcceptanceView.GetRowCellValue(rowHandle, AcceptanceView.Columns["ShipmentDate"]);

                    detail.ShipmentCode =
                        AcceptanceView.GetRowCellValue(rowHandle, AcceptanceView.Columns["ShipmentCode"])
                            .ToString();

                    detail.ServiceTypeId =
                        AcceptanceView.GetRowCellValue(rowHandle, AcceptanceView.Columns["ServiceTypeId"]) != null ?
                        (int)AcceptanceView.GetRowCellValue(rowHandle, AcceptanceView.Columns["ServiceTypeId"]) : 0;
                    detail.PackageTypeId =
                        AcceptanceView.GetRowCellValue(rowHandle, AcceptanceView.Columns["PackageTypeId"]) != null ?
                        (int)
                        AcceptanceView.GetRowCellValue(rowHandle, AcceptanceView.Columns["PackageTypeId"]) : 0;
                    detail.PaymentMethodId =
                        AcceptanceView.GetRowCellValue(rowHandle, AcceptanceView.Columns["PaymentMethodId"]) != null ?
                        (int)
                        AcceptanceView.GetRowCellValue(rowHandle, AcceptanceView.Columns["PaymentMethodId"]) : 0;
                    detail.TtlPiece =
                        (short)AcceptanceView.GetRowCellValue(rowHandle, AcceptanceView.Columns["TtlPiece"]);
                    detail.TtlGrossWeight =
                        (decimal)
                            AcceptanceView.GetRowCellValue(rowHandle, AcceptanceView.Columns["TtlGrossWeight"]);
                    detail.TtlChargeableWeight =
                        (decimal)
                            AcceptanceView.GetRowCellValue(rowHandle,
                                AcceptanceView.Columns["TtlChargeableWeight"]);
                    detail.Createddate = DateTime.Now;
                    detail.Createdby = BaseControl.UserLogin;

                    new FranchiseAcceptanceDetailDataManager().Save<FranchiseAcceptanceDetailModel>(detail);

                    if (detail.ShipmentId != null)
                    {
                        var ship =
                            new ShipmentDataManager().GetFirst<ShipmentModel>(
                                WhereTerm.Default((int)detail.ShipmentId, "id", EnumSqlOperator.Equals));
                        if (ship != null)
                        {
                            ship.TrackingStatusId = (int)EnumTrackingStatus.Acceptance;
                            ship.Modifiedby = BaseControl.UserLogin;
                            ship.Modifieddate = DateTime.Now;
                            new ShipmentDataManager().Update<ShipmentModel>(ship);

                            InsertTracking = true;
                            PodStatusModel.ShipmentId = ship.Id;
                            PodStatusModel.PositionStatusId = BaseControl.BranchId;
                            PodStatusModel.PositionStatus = EnumPositionStatus.Branch.ToString();
                            PodStatusModel.Reference = Code;
                            PodStatusModel.StatusBy = BaseControl.BranchCode;

                            ShipmentStatusUpdate();
                        }
                    }

                    totalPiece +=
                        (short)AcceptanceView.GetRowCellValue(rowHandle, AcceptanceView.Columns["TtlPiece"]);
                    totalGw +=
                        (decimal)
                            AcceptanceView.GetRowCellValue(rowHandle, AcceptanceView.Columns["TtlGrossWeight"]);
                    totalCw +=
                        (decimal)
                            AcceptanceView.GetRowCellValue(rowHandle, AcceptanceView.Columns["TtlChargeableWeight"]);
                }
            }

            acceptance.TtlPiece = totalPiece;
            acceptance.TtlGrossWeight = totalGw;
            acceptance.TtlChargeableWeight = totalCw;

            new FranchiseAcceptanceDataManager().Update<FranchiseAcceptanceModel>(acceptance);

            var checklistDm = new FranchiseAcceptanceChecklistDataManager();
            FranchiseAcceptanceChecklistModel checklistmodel;

            for (int i = 0; i < AcceptanceListView.RowCount; i++)
            {
                checklistmodel = new FranchiseAcceptanceChecklistModel
                {
                    Rowstatus = true,
                    Rowversion = DateTime.Now,
                    FranchiseAcceptanceId = CurrentModel.Id,
                    ShipmentId = (int)AcceptanceListView.GetRowCellValue(i, AcceptanceListView.Columns["ShipmentId"]),
                    ShipmentDate = (DateTime)AcceptanceListView.GetRowCellValue(i, AcceptanceListView.Columns["ShipmentDate"]),
                    ShipmentCode = AcceptanceListView.GetRowCellValue(i, AcceptanceListView.Columns["ShipmentCode"]).ToString(),
                    ServiceTypeId = AcceptanceListView.GetRowCellValue(i, AcceptanceListView.Columns["ServiceTypeId"]) != null ? (int)AcceptanceListView.GetRowCellValue(i, AcceptanceListView.Columns["ServiceTypeId"]) : (int?)null,
                    PackageTypeId = AcceptanceListView.GetRowCellValue(i, AcceptanceListView.Columns["PackageTypeId"]) != null ? (int)AcceptanceListView.GetRowCellValue(i, AcceptanceListView.Columns["PackageTypeId"]) : (int?)null,
                    PaymentMethodId = AcceptanceListView.GetRowCellValue(i, AcceptanceListView.Columns["PaymentMethodId"]) != null ? (int)AcceptanceListView.GetRowCellValue(i, AcceptanceListView.Columns["PaymentMethodId"]) : (int?)null,
                    TtlPiece = AcceptanceListView.GetRowCellValue(i, AcceptanceListView.Columns["TtlPiece"]) != null ? (short)AcceptanceListView.GetRowCellValue(i, AcceptanceListView.Columns["TtlPiece"]) : (short?)null,
                    TtlGrossWeight = AcceptanceListView.GetRowCellValue(i, AcceptanceListView.Columns["TtlGrossWeight"]) != null ? (decimal)AcceptanceListView.GetRowCellValue(i, AcceptanceListView.Columns["TtlGrossWeight"]) : (decimal?)null,
                    TtlChargeableWeight = AcceptanceListView.GetRowCellValue(i, AcceptanceListView.Columns["TtlChargeableWeight"]) != null ? (decimal)AcceptanceListView.GetRowCellValue(i, AcceptanceListView.Columns["TtlChargeableWeight"]) : (decimal?)null,
                    Createdby = BaseControl.UserLogin,
                    Createddate = DateTime.Now
                };

                checklistDm.Save<InboundChecklistModel>(checklistmodel);
            }


            Enabled = true;

            ToolbarCode = acceptance.Code;
        }

        protected override void AfterSave()
        {
            OpenData(ToolbarCode);
        }

        protected override bool ValidateForm()
        {
            return true;
        }

        protected override void PopulateForm(FranchiseAcceptanceModel model)
        {
            ClearForm();
            EnabledForm(false);
            tsBaseBtn_New.Enabled = true;
            tsBaseBtn_Save.Enabled = false;

            if (model == null) return;

            ToolbarCode = model.Code;
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxDate.Text = model.DateProcess.ToString();
            tbxPickup.Text = model.FranchisePickupCode;
            FranchiseId = model.FranchiseId;
            FranchisePickupId = model.FranchisePickupId;

            var franchise =
                new FranchiseDataManager().GetFirst<FranchiseModel>(WhereTerm.Default(model.FranchiseId,
                    "id", EnumSqlOperator.Equals));
            if (franchise != null) lblFranchise.Text = string.Format("{0} {1}", franchise.Code, franchise.Name);

            var details =
                new FranchiseAcceptanceDetailDataManager().Get<FranchiseAcceptanceDetailModel>(WhereTerm.Default(model.Id,
                    "franchise_acceptance_id", EnumSqlOperator.Equals));

            GridAcceptance.DataSource = details;

            var checklistDetail = new FranchiseAcceptanceChecklistDataManager().Get<FranchiseAcceptanceChecklistModel>(WhereTerm.Default(model.Id,
                    "franchise_acceptance_id", EnumSqlOperator.Equals));
            GridAcceptanceList.DataSource = checklistDetail;

            tsBaseTxt_Code.Focus();

            tbxDate.Enabled = false;
            tbxDate.Properties.Buttons[0].Enabled = false;
        }

        protected override FranchiseAcceptanceModel PopulateModel(FranchiseAcceptanceModel model)
        {
            model.DateProcess = tbxDate.Value;
            model.Code = Code;
            model.FranchisePickupCode = tbxPickup.Text;
            model.FranchiseId = FranchiseId;
            model.BranchId = BaseControl.BranchId;
            model.FranchisePickupId = FranchisePickupId;

            if (model.Id == 0) model.CreatedPc = Environment.MachineName;
            else model.ModifiedPc = Environment.MachineName;

            return model;
        }

        protected override FranchiseAcceptanceModel Find(string searchTerm)
        {
            if (!string.IsNullOrEmpty(searchTerm)) tsBaseTxt_Code.Text = searchTerm;
            var param = new IListParameter[]
                {
                    WhereTerm.Default(tsBaseTxt_Code.Text, "code", EnumSqlOperator.Equals)
                };
            var obj = DataManager.GetFirst<FranchiseAcceptanceModel>(param);
            PopulateForm(obj);

            return obj;
        }

        public override void Info()
        {
            var model = CurrentModel as FranchiseAcceptanceModel;
            if (model != null)
            {
                info.CreatedPc = model.CreatedPc;
                info.ModifiedPc = model.ModifiedPc;
            }

            base.Info();
        }
    }
}
