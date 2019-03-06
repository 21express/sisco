using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.WinControl.MessageBox;
using DevExpress.XtraGrid.Views.Grid;
using SISCO.App.MasterData;
using SISCO.App.Operation;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Properties;
using SISCO.Presentation.CustomerService.Forms;
using SISCO.Presentation.Operation.Popup;

namespace SISCO.Presentation.Operation.Forms
{
    public partial class InboundForm : BaseCrudForm<InboundModel, InboundDataManager>//BaseToolbarForm//
    {
        private string Code { get; set; }
        private InboundFilterPopup Fpe = new InboundFilterPopup();
        private List<int> DeletedRows { get; set; }
        private bool FocusBarcode { get; set; }

        public InboundForm()
        {
            InitializeComponent();

            form = this;
            Load += InboundLoad;
            InboundView.RowStyle += ChangeColor;
            btnTambah.Click += (sender, e) => AddRow();

            FormTrackingStatus = EnumTrackingStatus.Incoming;
            InboundView.CustomColumnDisplayText += NumberGrid;
            InboundListView.CustomColumnDisplayText += NumberGrid;
            GridInboundList.DoubleClick += (sender, args) => OpenRelatedForm(InboundListView, new TrackingViewForm(), "ShipmentCode");
            DataManager.DefaultParameters = new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals) };

            tbxCn.KeyDown += (sender, args) =>
            {
                FocusBarcode = false;
                if (args.KeyCode == Keys.Enter)
                {
                    FocusBarcode = true;
                }
            };

            btnTambah.GotFocus += (sender, args) =>
            {
                if (FocusBarcode)
                {
                    FocusBarcode = false;
                    AddRow();
                }
            };
        }

        private void InboundLoad(object sender, EventArgs e)
        {
            EnableBtnSearch = true;
            SearchPopup = new InboundFilterPopup();

            Fpe.DefaultParam = new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals) };
        }

        private void LoadInboundList()
        {
            var ds = GridInboundList.DataSource as List<ManifestDetailModel>;
            var inboundList = new ManifestDetailDataManager().GetInbound(BaseControl.BranchId, tbxCn.Text);

            if (InboundListView.RowCount == 0)
            {
                GridInboundList.DataSource = inboundList;
                InboundListView.RefreshData();
            }
            else
            {
                if (ds != null)
                {
                    var shipcode = ds.Select(x => x.ShipmentCode);
                    var newInbound = inboundList.Where(y => !shipcode.Contains(y.ShipmentCode));

                    var dsInbound = GridInbound.DataSource as List<InboundDetailModel>;
                    var inboundShipcode = dsInbound.Select(x => x.ShipmentCode);
                    newInbound = newInbound.Where(y => !inboundShipcode.Contains(y.ShipmentCode));

                    ds.AddRange(newInbound);
                }
            }
        }

        private void ChangeColor(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var view = sender as GridView;

                if (view == null) return;

                if ((int)view.GetRowCellValue(e.RowHandle, view.Columns["InboundStatusId"]) ==
                        (int)EnumInboundStatus.CNnotEntered)
                {
                    e.Appearance.ForeColor = Color.Red;
                }

                if ((int)view.GetRowCellValue(e.RowHandle, view.Columns["InboundStatusId"]) ==
                    (int)EnumInboundStatus.ManifestWrongDestination)
                {
                    e.Appearance.ForeColor = Color.Blue;
                }

                if ((int)view.GetRowCellValue(e.RowHandle, view.Columns["InboundStatusId"]) ==
                    (int)EnumInboundStatus.NotManifest)
                {
                    e.Appearance.ForeColor = Color.BlueViolet;
                }

                if ((int)view.GetRowCellValue(e.RowHandle, view.Columns["InboundStatusId"]) ==
                    (int)EnumInboundStatus.Return)
                {
                    e.Appearance.ForeColor = Color.Green;
                }

                if ((int)view.GetRowCellValue(e.RowHandle, view.Columns["InboundStatusId"]) ==
                    (int)EnumInboundStatus.Valid)
                {
                    e.Appearance.ForeColor = Color.Black;
                }
            }
        }

        private void Detail(InboundDetailModel detail)
        {
            var cons = new List<InboundDetailModel>();
            
            if (InboundView.RowCount > 0)
            {
                cons = GridInbound.DataSource as List<InboundDetailModel>;
                if (cons != null)
                {
                    var s = cons.FirstOrDefault(b => b.ShipmentCode == detail.ShipmentCode);
                    if (s != null)
                    {
                        MessageForm.Info(form, Resources.information, string.Format(Resources.registered_inbound, detail.ShipmentCode));
                        return;
                    }
                } else cons = new List<InboundDetailModel>();
            }

            cons.Add(detail);
            GridInbound.DataSource = cons;
            InboundView.RefreshData();
            InboundView.FocusedRowHandle = InboundView.RowCount - 1;
            InboundView.SelectRow(InboundView.RowCount-1);

            if (InboundListView.RowCount > 0)
            {
                for (int i = 0; i < InboundListView.DataRowCount; i++)
                {
                    object b = InboundListView.GetRowCellValue(i, "ShipmentCode");
                    if (b != null && b.Equals(detail.ShipmentCode))
                    {
                        InboundListView.FocusedRowHandle = i;
                        //InboundListView.SetRowCellValue(i, InboundView.Columns["StateChange"], EnumStateChange.Delete);
                        if (InboundListView.GetRowCellValue(i, "StateChange2").ToString() !=
                            EnumStateChange.Insert.ToString()) DeletedRows.Add((int)InboundListView.GetRowCellValue(i, InboundView.Columns["Id"]));

                        InboundListView.DeleteSelectedRows();
                        return;
                    }
                }
            }
        }

        private void AddRow()
        {
            if (DateTime.Now.ToString("dd-MM-yyyy") != tbxDate.Value.ToString("dd-MM-yyyy"))
            {
                MessageForm.Info(this, Resources.information, @"Tidak bisa menambah inbound baru di tanggal ini harus melalui proses inbound baru.");
                tbxCn.Clear();
                tbxCn.Focus();
                return;
            }

            if (tbxCn.Text == string.Empty) return;

            LoadInboundList();
            // ReSharper disable once RedundantAssignment
            var inboundDetail = new InboundDetailModel();
            var shipment = new ShipmentDataManager().GetFirst<ShipmentModel>(WhereTerm.Default(tbxCn.Text, "code", EnumSqlOperator.Equals));
            if (shipment == null)
            {
                var manifestdetail =
                    new ManifestDetailDataManager().Get<ManifestDetailModel>(WhereTerm.Default(tbxCn.Text,
                        "consol_code", EnumSqlOperator.Equals));

                var manifestDetailModels = manifestdetail as ManifestDetailModel[] ?? manifestdetail.ToArray();
                if (manifestDetailModels.Any())
                {
                    foreach (ManifestDetailModel obj in manifestDetailModels)
                    {
                        var city =
                            new CityDataManager().GetFirst<CityModel>(WhereTerm.Default(obj.DestCityId, "id",
                                EnumSqlOperator.Equals));

                        var retur = new ShipmentStatusDataManager().GetFirst<ShipmentStatusModel>(new IListParameter[]
                        {
                            WhereTerm.Default((int)obj.ShipmentId, "shipment_id"),
                            WhereTerm.Default((int)EnumTrackingStatus.Returned, "tracking_status_id")
                        });

                        inboundDetail = new InboundDetailModel
                        {
                            ShipmentId = obj.ShipmentId,
                            ShipmentDate = obj.ShipmentDate,
                            ShipmentCode = obj.ShipmentCode,
                            ConsolCode = obj.ConsolCode,
                            BranchId = obj.BranchId,
                            DestCityId = obj.DestCityId,
                            DestCity = city != null ? city.Name : "",
                            CustomerId = obj.CustomerId,
                            CustomerName = obj.CustomerName,
                            ShipperName = obj.ShipperName,
                            ConsigneeName = obj.ConsigneeName,
                            ServiceTypeId = obj.ServiceTypeId,
                            PackageTypeId = obj.PackageTypeId,
                            PaymentMethodId = obj.PaymentMethodId,
                            TtlPiece = obj.TtlPiece,
                            TtlGrossWeight = obj.TtlGrossWeight,
                            TtlChargeableWeight = obj.TtlChargeableWeight,
                            InboundStatusId =
                                retur != null ? (int) EnumInboundStatus.Return :
                                obj.DestBranchId == BaseControl.BranchId
                                    ? (int) EnumInboundStatus.Valid
                                    : (int) EnumInboundStatus.ManifestWrongDestination,
                            ManifestId = obj.ManifestId,
                            ManifestCode = obj.ManifestCode,
                            StateChange2 = EnumStateChange.Insert.ToString()
                        };
                        Detail(inboundDetail);
                    }
                }
                else
                {
                    inboundDetail = new InboundDetailModel
                    {
                        ShipmentCode = tbxCn.Text,
                        InboundStatusId = (int)EnumInboundStatus.CNnotEntered,
                        StateChange2 = EnumStateChange.Insert.ToString()
                    };

                    Detail(inboundDetail);
                }
            }
            else
            {
                var consolDetail =
                        new ManifestDetailDataManager().GetFirst<ManifestDetailModel>(
                            WhereTerm.Default(shipment.Id, "shipment_id", EnumSqlOperator.Equals));

                var city =
                            new CityDataManager().GetFirst<CityModel>(WhereTerm.Default(shipment.DestCityId, "id",
                                EnumSqlOperator.Equals));

                var retur = new ShipmentStatusDataManager().GetFirst<ShipmentStatusModel>(new IListParameter[]
                        {
                            WhereTerm.Default(shipment.Id, "shipment_id"),
                            WhereTerm.Default((int)EnumTrackingStatus.Returned, "tracking_status_id")
                        });
                inboundDetail = new InboundDetailModel
                {
                    ShipmentId = shipment.Id,
                    ShipmentDate = shipment.DateProcess,
                    ShipmentCode = shipment.Code,
                    // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                    ConsolCode = consolDetail == null ? null : consolDetail.ConsolCode,
                    BranchId = shipment.BranchId,
                    DestCityId = shipment.DestCityId,
                    DestCity = city != null ? city.Name : "",
                    CustomerId = shipment.CustomerId,
                    CustomerName = shipment.CustomerName,
                    ShipperName = shipment.ShipperName,
                    ConsigneeName = shipment.ConsigneeName,
                    ServiceTypeId = shipment.ServiceTypeId,
                    PackageTypeId = shipment.PaymentMethodId,
                    PaymentMethodId = shipment.PaymentMethodId,
                    TtlPiece = shipment.TtlPiece,
                    TtlGrossWeight = shipment.TtlGrossWeight,
                    TtlChargeableWeight = shipment.TtlChargeableWeight,
                    ManifestId = consolDetail == null ? 0 : consolDetail.ManifestId,
                    ManifestCode = consolDetail == null ? string.Empty : consolDetail.ManifestCode,
                    StateChange2 = EnumStateChange.Insert.ToString()
                };

                if (consolDetail != null)
                {
                    var manifest =
                        new ManifestDataManager().GetFirst<ManifestModel>(WhereTerm.Default(consolDetail.ManifestId,
                            "id", EnumSqlOperator.Equals));

                    if (retur != null) inboundDetail.InboundStatusId = (int)EnumInboundStatus.Return;
                    else if (manifest.DestBranchId != BaseControl.BranchId)
                        inboundDetail.InboundStatusId = (int) EnumInboundStatus.ManifestWrongDestination;
                    else inboundDetail.InboundStatusId = (int) EnumInboundStatus.Valid;
                }
                else
                {
                    inboundDetail.InboundStatusId = (int)EnumInboundStatus.NotManifest;
                }

                Detail(inboundDetail);
            }

            tbxCn.Text = string.Empty;
            tbxCn.Focus();
        }

        public override void New()
        {
            base.New();

            ClearForm();
            ToolbarCode = string.Empty;
            DeletedRows = new List<int>();

            StateChange = EnumStateChange.Insert;
            GridInbound.DataSource = null;
            InboundView.RefreshData();

            GridInboundList.DataSource = null;
            InboundListView.RefreshData();

            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxDate.Text = DateTime.Now.ToString();
            tbxCn.Focus();

            tbxDate.Enabled = false;
            tbxDate.Properties.Buttons[0].Enabled = false;
        }

        public override void Save()
        {
            if (InboundView.RowCount == 0)
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
                    Code = GetCode("inbound", tbxDate.Value);
            }
            else
            {
                var inbound = new InboundDataManager().GetFirst<InboundModel>(WhereTerm.Default(CurrentModel.Id, "id", EnumSqlOperator.Equals));
                Code = inbound.Code;
            }

            base.Save();
        }

        protected override void SaveDetail(bool isUpdate = false)
        {
            Enabled = false;
            var inbound = new InboundDataManager().GetFirst<InboundModel>(WhereTerm.Default(CurrentModel.Id, "id", EnumSqlOperator.Equals));
            Code = inbound.Code;

            StateChange = EnumStateChange.Select;
            short totalPiece = 0;
            decimal totalGw = 0;
            decimal totalCw = 0;
            for (int i = 0; i < InboundView.RowCount; i++)
            {
                int rowHandle = InboundView.GetVisibleRowHandle(i);
                if (InboundView.IsDataRow(rowHandle))
                {
                    var state = InboundView.GetRowCellValue(rowHandle, InboundView.Columns["StateChange2"]);
                    if (state.ToString().Equals(EnumStateChange.Insert.ToString()))
                    {
                        var detail = new InboundDetailModel();
                        detail.Rowstatus = true;
                        detail.Rowversion = DateTime.Now;
                        detail.InboundId = inbound.Id;
                        detail.InboundCode = inbound.Code;

                        if (InboundView.GetRowCellValue(rowHandle, InboundView.Columns["ShipmentId"]) != null)
                            detail.ShipmentId =
                                (int) InboundView.GetRowCellValue(rowHandle, InboundView.Columns["ShipmentId"]);

                        if (InboundView.GetRowCellValue(rowHandle, InboundView.Columns["ShipmentDate"]) != null)
                            detail.ShipmentDate =
                                (DateTime)
                                    InboundView.GetRowCellValue(rowHandle, InboundView.Columns["ShipmentDate"]);

                        detail.ShipmentCode =
                            InboundView.GetRowCellValue(rowHandle, InboundView.Columns["ShipmentCode"])
                                .ToString();

                        if (InboundView.GetRowCellValue(rowHandle, InboundView.Columns["ConsolCode"]) != null)
                            detail.ConsolCode =
                                InboundView.GetRowCellValue(rowHandle, InboundView.Columns["ConsolCode"])
                                    .ToString();
                        detail.BranchId =
                            (int)InboundView.GetRowCellValue(rowHandle, InboundView.Columns["BranchId"]);
                        detail.DestCityId =
                            (int)InboundView.GetRowCellValue(rowHandle, InboundView.Columns["DestCityId"]);
                        detail.CustomerId =
                            InboundView.GetRowCellValue(rowHandle, InboundView.Columns["CustomerId"]) != null ?
                            (int)InboundView.GetRowCellValue(rowHandle, InboundView.Columns["CustomerId"]) : 0;
                        detail.CustomerName =
                            InboundView.GetRowCellValue(rowHandle, InboundView.Columns["CustomerName"]) != null ?
                            InboundView.GetRowCellValue(rowHandle, InboundView.Columns["CustomerName"])
                            .ToString() : "";
                        detail.ShipperName =
                            InboundView.GetRowCellValue(rowHandle, InboundView.Columns["ShipperName"]) != null ?
                            InboundView.GetRowCellValue(rowHandle, InboundView.Columns["ShipperName"])
                            .ToString() : "";
                        detail.ConsigneeName =
                            InboundView.GetRowCellValue(rowHandle, InboundView.Columns["ConsigneeName"]) != null ?
                            InboundView.GetRowCellValue(rowHandle, InboundView.Columns["ConsigneeName"])
                            .ToString() : "";
                        detail.ServiceTypeId =
                            InboundView.GetRowCellValue(rowHandle, InboundView.Columns["ServiceTypeId"]) != null ?
                            (int)InboundView.GetRowCellValue(rowHandle, InboundView.Columns["ServiceTypeId"]) : 0;
                        detail.PackageTypeId =
                            InboundView.GetRowCellValue(rowHandle, InboundView.Columns["PackageTypeId"]) != null ?
                            (int)
                            InboundView.GetRowCellValue(rowHandle, InboundView.Columns["PackageTypeId"]) : 0;
                        detail.PaymentMethodId =
                            InboundView.GetRowCellValue(rowHandle, InboundView.Columns["PaymentMethodId"]) != null ?
                            (int)
                            InboundView.GetRowCellValue(rowHandle, InboundView.Columns["PaymentMethodId"]) : 0;
                        detail.TtlPiece =
                            (short)InboundView.GetRowCellValue(rowHandle, InboundView.Columns["TtlPiece"]);
                        detail.TtlGrossWeight =
                            (decimal)
                                InboundView.GetRowCellValue(rowHandle, InboundView.Columns["TtlGrossWeight"]);
                        detail.TtlChargeableWeight =
                            (decimal)
                                InboundView.GetRowCellValue(rowHandle,
                                    InboundView.Columns["TtlChargeableWeight"]);
                        detail.ManifestId = (int)
                                InboundView.GetRowCellValue(rowHandle, InboundView.Columns["ManifestId"]);
                        detail.ManifestCode = 
                                InboundView.GetRowCellValue(rowHandle, InboundView.Columns["ManifestCode"]) != null ?
                                InboundView.GetRowCellValue(rowHandle, InboundView.Columns["ManifestCode"]).ToString() : "";
                        detail.InboundStatusId = (int)
                                InboundView.GetRowCellValue(rowHandle, InboundView.Columns["InboundStatusId"]);
                        detail.Createddate = DateTime.Now;
                        detail.Createdby = BaseControl.UserLogin;

                        new InboundDetailDataManager().Save<InboundDetailModel>(detail);

                        if (detail.ShipmentId != null)
                        {
                            var ship =
                                new ShipmentDataManager().GetFirst<ShipmentModel>(
                                    WhereTerm.Default((int)detail.ShipmentId, "id", EnumSqlOperator.Equals));
                            if (ship != null)
                            {
                                ship.Inbound = true;
                                if (ship.TrackingStatusId != (int)EnumTrackingStatus.Received && ship.TrackingStatusId != (int)EnumTrackingStatus.Claimed && ship.TrackingStatusId != (int)EnumTrackingStatus.Gudang) ship.TrackingStatusId = (int)EnumTrackingStatus.Incoming;
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
                    }

                    totalPiece +=
                        (short)InboundView.GetRowCellValue(rowHandle, InboundView.Columns["TtlPiece"]);
                    totalGw +=
                        (decimal)
                            InboundView.GetRowCellValue(rowHandle, InboundView.Columns["TtlGrossWeight"]);
                    totalCw +=
                        (decimal)
                            InboundView.GetRowCellValue(rowHandle, InboundView.Columns["TtlChargeableWeight"]);
                }
            }

            inbound.TtlPiece = totalPiece;
            inbound.TtlGrossWeight = totalGw;
            inbound.TtlChargeableWeight = totalCw;

            new InboundDataManager().Update<InboundModel>(inbound);

            var checklistDm = new InboundChecklistDataManager();
            InboundChecklistModel checklistmodel;

            for (int i = 0; i < InboundListView.RowCount; i++)
            {
                var state = InboundListView.GetRowCellValue(i, InboundListView.Columns["StateChange2"]);
                if (state.ToString().Equals(EnumStateChange.Insert.ToString()))
                {
                    checklistmodel = new InboundChecklistModel
                    {
                        Rowstatus = true,
                        Rowversion = DateTime.Now,
                        InboundId = CurrentModel.Id,
                        ShipmentId = (int)InboundListView.GetRowCellValue(i, InboundListView.Columns["ShipmentId"]),
                        ShipmentDate = (DateTime)InboundListView.GetRowCellValue(i, InboundListView.Columns["ShipmentDate"]),
                        ShipmentCode = InboundListView.GetRowCellValue(i, InboundListView.Columns["ShipmentCode"]).ToString(),
                        ConsolCode = InboundListView.GetRowCellValue(i, InboundListView.Columns["ConsolCode"]) != null ? InboundListView.GetRowCellValue(i, InboundListView.Columns["ConsolCode"]).ToString() : string.Empty,
                        BranchId = InboundListView.GetRowCellValue(i, InboundListView.Columns["BranchId"]) != null ? (int)InboundListView.GetRowCellValue(i, InboundListView.Columns["BranchId"]) : (int?)null,
                        DestCityId = InboundListView.GetRowCellValue(i, InboundListView.Columns["DestCityId"]) != null ? (int)InboundListView.GetRowCellValue(i, InboundListView.Columns["DestCityId"]) : (int?)null,
                        DestCity = InboundListView.GetRowCellValue(i, InboundListView.Columns["DestCity"]) != null ? InboundListView.GetRowCellValue(i, InboundListView.Columns["DestCity"]).ToString() : string.Empty,
                        CustomerId = InboundListView.GetRowCellValue(i, InboundListView.Columns["CustomerId"]) != null ? (int)InboundListView.GetRowCellValue(i, InboundListView.Columns["CustomerId"]) : (int?)null,
                        CustomerName = InboundListView.GetRowCellValue(i, InboundListView.Columns["CustomerName"]) != null ? InboundListView.GetRowCellValue(i, InboundListView.Columns["CustomerName"]).ToString() : string.Empty,
                        ShipperName = InboundListView.GetRowCellValue(i, InboundListView.Columns["ShipperName"]) != null ? InboundListView.GetRowCellValue(i, InboundListView.Columns["ShipperName"]).ToString() : string.Empty,
                        ConsigneeName = InboundListView.GetRowCellValue(i, InboundListView.Columns["ConsigneeName"]) != null ? InboundListView.GetRowCellValue(i, InboundListView.Columns["ConsigneeName"]).ToString() : string.Empty,
                        ServiceTypeId = InboundListView.GetRowCellValue(i, InboundListView.Columns["ServiceTypeId"]) != null ? (int)InboundListView.GetRowCellValue(i, InboundListView.Columns["ServiceTypeId"]) : (int?)null,
                        PackageTypeId = InboundListView.GetRowCellValue(i, InboundListView.Columns["PackageTypeId"]) != null ? (int)InboundListView.GetRowCellValue(i, InboundListView.Columns["PackageTypeId"]) : (int?)null,
                        PaymentMethodId = InboundListView.GetRowCellValue(i, InboundListView.Columns["PaymentMethodId"]) != null ? (int)InboundListView.GetRowCellValue(i, InboundListView.Columns["PaymentMethodId"]) : (int?)null,
                        SalesTypeId = InboundListView.GetRowCellValue(i, InboundListView.Columns["SalesTypeId"]) != null ? (int)InboundListView.GetRowCellValue(i, InboundListView.Columns["SalesTypeId"]) : (int?)null,
                        TtlPiece = InboundListView.GetRowCellValue(i, InboundListView.Columns["TtlPiece"]) != null ? (short)InboundListView.GetRowCellValue(i, InboundListView.Columns["TtlPiece"]) : (short?)null,
                        TtlGrossWeight = InboundListView.GetRowCellValue(i, InboundListView.Columns["TtlGrossWeight"]) != null ? (decimal)InboundListView.GetRowCellValue(i, InboundListView.Columns["TtlGrossWeight"]) : (decimal?)null,
                        TtlChargeableWeight = InboundListView.GetRowCellValue(i, InboundListView.Columns["TtlChargeableWeight"]) != null ? (decimal)InboundListView.GetRowCellValue(i, InboundListView.Columns["TtlChargeableWeight"]) : (decimal?)null,
                        ManifestId = (int)InboundListView.GetRowCellValue(i, InboundListView.Columns["ManifestId"]),
                        ManifestCode = InboundListView.GetRowCellValue(i, InboundListView.Columns["ManifestCode"]).ToString(),
                        Createdby = BaseControl.UserLogin,
                        Createddate = DateTime.Now
                    };

                    checklistDm.Save<InboundChecklistModel>(checklistmodel);
                }
            }

            foreach (int o in DeletedRows)
            {
                checklistDm.DeActive(o, BaseControl.UserLogin, DateTime.Now);
            }

            Enabled = true;
            
            ToolbarCode = inbound.Code;
        }

        protected override void AfterSave()
        {
            OpenData(ToolbarCode);
            tbxCn.Focus();
        }

        public override void AfterDelete()
        {
            var detail = new InboundDetailDataManager().Get<InboundDetailModel>(WhereTerm.Default(CurrentModel.Id, "inbound_id", EnumSqlOperator.Equals));
            if (detail != null)
            {
                var repo = new InboundDetailDataManager();
                var shipRepo = new ShipmentStatusDataManager();
                foreach (InboundDetailModel obj in detail)
                {
                    repo.DeActive(obj.Id, BaseControl.UserLogin, DateTime.Now);
                    if (obj.ShipmentId != null)
                    {
                        var shipmentStatus = shipRepo.GetFirst<ShipmentStatusModel>(new IListParameter[]
                        {
                            WhereTerm.Default((int) obj.ShipmentId, "shipment_id", EnumSqlOperator.Equals),
                            WhereTerm.Default((int) EnumTrackingStatus.Arrival, "tracking_status_id", EnumSqlOperator.Equals)
                        });
                        if (shipmentStatus != null)
                        {
                            shipRepo.DeActive(shipmentStatus.Id, BaseControl.UserLogin, DateTime.Now);
                        }
                    }
                }
            }

            var checklist =
                new InboundChecklistDataManager().Get<InboundChecklistModel>(WhereTerm.Default(CurrentModel.Id,
                    "inbound_id", EnumSqlOperator.Equals));

            var repoChecklist = new InboundChecklistDataManager();
            foreach (InboundChecklistModel obj in checklist)
            {
                repoChecklist.DeActive(obj.Id, BaseControl.UserLogin, DateTime.Now);
            }

            GridInboundList.DataSource = null;
            GridInbound.DataSource = null;

            InboundView.RefreshData();
            InboundListView.RefreshData();

            base.AfterDelete();
        }

        protected override bool ValidateForm()
        {
            if (tbxDate.Text != "")
                return true;

            tbxDate.Focus();

            return false;
        }

        protected override void PopulateForm(InboundModel model)
        {
            ClearForm();
            if (model == null) return;

            DeletedRows = new List<int>();
            ToolbarCode = model.Code;
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxDate.Text = model.DateProcess.ToString();

            var details =
                new InboundDetailDataManager().Get<InboundDetailModel>(WhereTerm.Default(model.Id,
                    "inbound_id", EnumSqlOperator.Equals));

            GridInbound.DataSource = details;

            var checklistDetail = new InboundChecklistDataManager().Get<InboundChecklistModel>(WhereTerm.Default(model.Id,
                    "inbound_id", EnumSqlOperator.Equals));
            GridInboundList.DataSource = checklistDetail;

            tsBaseTxt_Code.Focus();

            tbxDate.Enabled = false;
            tbxDate.Properties.Buttons[0].Enabled = false;
        }

        protected override InboundModel PopulateModel(InboundModel model)
        {
            model.DateProcess = tbxDate.Value;
            model.Code = Code;
            model.BranchId = BaseControl.BranchId;

            if (model.Id == 0) model.CreatedPc = Environment.MachineName;
            else model.ModifiedPc = Environment.MachineName;

            return model;
        }

        protected override InboundModel Find(string searchTerm)
        {
            if (!string.IsNullOrEmpty(searchTerm)) tsBaseTxt_Code.Text = searchTerm;
            var param = new IListParameter[]
                {
                    WhereTerm.Default(tsBaseTxt_Code.Text, "code", EnumSqlOperator.Equals)
                };
            var obj = DataManager.GetFirst<InboundModel>(param);
            PopulateForm(obj);

            return obj;
        }

        public override void Info()
        {
            var model = CurrentModel as InboundModel;
            if (model != null)
            {
                info.CreatedPc = model.CreatedPc;
                info.ModifiedPc = model.ModifiedPc;
            }

            base.Info();
        }
    }
}