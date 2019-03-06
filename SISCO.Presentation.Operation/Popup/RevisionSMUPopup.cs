using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.WinControl.MessageBox;
using DevExpress.XtraEditors.Controls;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common.Properties;
using SISCO.Presentation.MasterData.Popup;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Data;
using SISCO.Presentation.Common;
using SISCO.App.Operation;
using SISCO.Presentation.Common.Forms;

namespace SISCO.Presentation.Operation.Popup
{
    public partial class RevisionSMUPopup : BaseForm
    {
        public bool Success { get; set; }
        public AirwaybillModel smu { get; set; }
        public List<AirwaybillDetailModel> smuDetails { get; set; }
        private List<int> DeletedRows { get; set; }

        public RevisionSMUPopup()
        {
            InitializeComponent();

            Load += RevisionSMUPopup_Load;
            Shown += RevisionSMUPopup_Shown;
        }

        void RevisionSMUPopup_Load(object sender, EventArgs e)
        {
            Success = false;
            btnDelete.ButtonClick += DeleteRow;
            btnSave.Click += btnSave_Click;
            FormTrackingStatus = EnumTrackingStatus.WaybilledRevised;

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

            tbxAirline.Leave += (s, args) => FlightDataSource();
            tbxOrigin.Leave += (s, args) => FlightDataSource();
            tbxDestination.Leave += (s, args) =>
            {
                if (tbxDestination.Value != null)
                {
                    FlightDataSource();
                }
            };

            tbxEstDate.Leave += (s, args) => FlightDataSource();

            OutboundBandaraView.CustomColumnDisplayText += NumberGrid;
        }

        private AirwaybillModel currentModel { get; set; }
        void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
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
                    WhereTerm.Default(DestBranchId, "dest_branch_id"),
                    WhereTerm.Default((int)tbxAirline.Value, "airline_id")
                });

                if (exists.Count() > 0)
                {
                    MessageForm.Warning(this, "Info", "Nomor AWB sudah digunakan silakan cek kembali.");
                    tbxAwb.Focus();
                    return;
                }

                currentModel = PopulateModel(new AirwaybillModel());
                using (var scope = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.Required, new TimeSpan(0, 10, 0)))
                {
                    currentModel.Rowstatus = true;
                    currentModel.Rowversion = DateTime.Now;
                    currentModel.Createddate = DateTime.Now;
                    currentModel.Createdby = BaseControl.UserLogin;

                    new AirwaybillDataManager().Save<AirwaybillModel>(currentModel);

                    smu.IsCancelled = true;
                    smu.RevisedToId = currentModel.Id;
                    smu.ReasonToRevision = tbxReason.Text;
                    smu.Rowversion = DateTime.Now;
                    smu.Modifieddate = DateTime.Now;
                    smu.Modifiedby = BaseControl.UserLogin;

                    new AirwaybillDataManager().Update<AirwaybillModel>(smu);

                    SaveDetail();
                    scope.Complete();

                    Success = true;
                }

                Close();
            }
        }

        private void SaveDetail()
        {
            var awb = currentModel;
            if (awb != null)
            {
                var airline =
                    new AirlineDataManager().GetFirst<AirlineModel>(WhereTerm.Default(awb.AirlineId, "id",
                        EnumSqlOperator.Equals));

                var totalPiece = (short)0;
                decimal totalGw = 0;
                decimal totalCw = 0;
                var dimension = new List<string>();
                for (int i = 0; i < OutboundBandaraView.RowCount; i++)
                {
                    int rowHandle = OutboundBandaraView.GetVisibleRowHandle(i);
                    if (OutboundBandaraView.IsDataRow(rowHandle))
                    {
                        var detail = new AirwaybillDetailModel();
                        detail.Rowstatus = true;
                        detail.Rowversion = DateTime.Now;
                        detail.DateProcess = DateTime.Now;
                        detail.AirwaybillId = currentModel.Id;
                        detail.AirwaybillCode = currentModel.Code;
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
                            : (int?)null;

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
                            : (int?)null;
                        detail.PackageTypeId =
                            OutboundBandaraView.GetRowCellValue(rowHandle,
                                OutboundBandaraView.Columns["PackageTypeId"]) != null
                                ? (int)
                                    OutboundBandaraView.GetRowCellValue(rowHandle,
                                        OutboundBandaraView.Columns["PackageTypeId"])
                                : (int?)null;
                        detail.PaymentMethodId = OutboundBandaraView.GetRowCellValue(rowHandle,
                            OutboundBandaraView.Columns["PaymentMethodId"]) != null
                            ? (int)
                                OutboundBandaraView.GetRowCellValue(rowHandle,
                                    OutboundBandaraView.Columns["PaymentMethodId"])
                            : (int?)null;
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

                        new AirwaybillDetailDataManager().Save<AirwaybillDetailModel>(detail);

                        if (detail.ShipmentId == 0)
                        {
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
                                                WhereTerm.Default(currentModel.DestBranchId, "id",
                                                EnumSqlOperator.Equals));

                                        var al =
                                            new AirlineDataManager().GetFirst<AirlineModel>(
                                                WhereTerm.Default(currentModel.AirlineId, "id",
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
                                    PodStatusModel.ShipmentId = (int)obj.ShipmentId;
                                    PodStatusModel.PositionStatusId = BaseControl.BranchId;
                                    PodStatusModel.PositionStatus = EnumPositionStatus.Branch.ToString();
                                    PodStatusModel.Reference = detail.AirwaybillCode;

                                    var br =
                                new BranchDataManager().GetFirst<BranchModel>(
                                    WhereTerm.Default(currentModel.DestBranchId, "id",
                                        EnumSqlOperator.Equals));

                                    var al =
                                        new AirlineDataManager().GetFirst<AirlineModel>(
                                            WhereTerm.Default(currentModel.AirlineId, "id",
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
                                WhereTerm.Default(currentModel.DestBranchId, "id",
                                    EnumSqlOperator.Equals));

                                var al =
                                    new AirlineDataManager().GetFirst<AirlineModel>(
                                        WhereTerm.Default(currentModel.AirlineId, "id",
                                            EnumSqlOperator.Equals));
                                PodStatusModel.StatusBy = string.Format("{0} ({1})", al.Code, br.Code);
                                PodStatusModel.StatusNote = string.Format("{0} koli {1} kg",
                                    detail.TtlPiece.ToString("#0"),
                                    detail.TtlGrossWeight.ToString("#0.0"));

                                ShipmentStatusUpdate();
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
                                    OutboundBandaraView.Columns["TtlChargeableWeight"]) != 0) totalPiece++;
                        totalGw +=
                            (decimal)
                                OutboundBandaraView.GetRowCellValue(rowHandle,
                                    OutboundBandaraView.Columns["TtlGrossWeight"]);
                        totalCw +=
                            (decimal)
                                OutboundBandaraView.GetRowCellValue(rowHandle,
                                    OutboundBandaraView.Columns["TtlChargeableWeight"]);
                    }
                }

                var airwaybill =
                    new AirwaybillDataManager().GetFirst<AirwaybillModel>(WhereTerm.Default(currentModel.Id, "id",
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
                                    WhereTerm.Default((int) EnumTrackingStatus.Waybilled, "tracking_status_id",
                                        EnumSqlOperator.Equals),
                                    WhereTerm.Default(smu.Code, "reference", EnumSqlOperator.Equals),
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
                                    WhereTerm.Default((int) EnumTrackingStatus.Waybilled, "tracking_status_id",
                                        EnumSqlOperator.Equals),
                                    WhereTerm.Default(smu.Code, "reference", EnumSqlOperator.Equals),
                                    WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals)
                                });

                                if (shipmentStatus != null)
                                {
                                    new ShipmentStatusDataManager().DeActive(shipmentStatus.Id, BaseControl.UserLogin,
                                        DateTime.Now);
                                }
                            }
                        }
                    }
                }
            }
        }

        private AirwaybillModel PopulateModel(AirwaybillModel model)
        {
            model.DateProcess = tbxDate.Value;
            model.BranchId = BaseControl.BranchId;
            model.Code = tbxAwb.Text;
            if (tbxAirline.Value != null)
                model.AirlineId = (int)tbxAirline.Value;
            if (tbxOrigin.Value != null)
                model.AirportId = (int)tbxOrigin.Value;
            if (tbxDestination.Value != null)
                model.DestAirportId = (int)tbxDestination.Value;
            model.EstDepDate = tbxEstDate.Value;
            model.FlightId = (int?)cbxFlight.SelectedValue;

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
                    new FlightDataManager().GetFirst<FlightModel>(WhereTerm.Default((int)cbxFlight.SelectedValue, "id",
                        EnumSqlOperator.Equals));
                model.EstDepTime = flight.EstDepartureTime;
                model.FlightId = (int?)cbxFlight.SelectedValue;
            }
            else
            {
                model.EstDepTime = string.Empty;
                model.FlightId = 0;
            }

            model.StatusId = (int)EnumTrackingStatus.Waybilled;

            if (model.Id == 0) model.CreatedPc = Environment.MachineName;
            else model.ModifiedPc = Environment.MachineName;

            return model;
        }

        void RevisionSMUPopup_Shown(object sender, EventArgs e)
        {
            DeletedRows = new List<int>();
            tbxAirwaybil.Enabled = false;

            tbxAirwaybil.Text = smu.Code;
            lblDate.Text = smu.DateProcess.ToString("dd MM yyyy");
            if (smu.AirlineId > 0)
            {
                var airline = new AirlineDataManager().GetFirst<AirlineModel>(WhereTerm.Default(smu.AirlineId, "id"));
                if (airline != null) lblAirline.Text = airline.Name;
            }

            if (smu.AirportId > 0)
            {
                var airport = new AirportDataManager().GetFirst<AirportModel>(WhereTerm.Default(smu.AirportId, "id"));
                if (airport != null) lblOrigin.Text = airport.Name;
            }

            if (smu.DestAirportId > 0)
            {
                var destAirport = new AirportDataManager().GetFirst<AirportModel>(WhereTerm.Default(smu.DestAirportId, "id"));
                if (destAirport != null) lblDest.Text = destAirport.Name;
            }

            tbxOrigin.DefaultValue = new IListParameter[] { WhereTerm.Default(smu.AirportId, "id", EnumSqlOperator.Equals) };
            tbxDestination.DefaultValue = new IListParameter[] { WhereTerm.Default(smu.DestAirportId, "id", EnumSqlOperator.Equals) };

            GridOutboundBandara.DataSource = smuDetails;
            OutboundBandaraView.RefreshData();
            tbxDimension.Text = smu.Dimension;

            tbxReason.Focus();
            tbxDate.DateTime = DateTime.Now;
        }

        private void DeleteRow(object sender, ButtonPressedEventArgs e)
        {
            var dialog = MessageForm.Ask(this, Resources.delete_confirm, Resources.delete_confirm_msg);
            if (dialog == DialogResult.Yes)
            {
                var rowHandle = OutboundBandaraView.FocusedRowHandle;
                if (OutboundBandaraView.GetRowCellValue(rowHandle, OutboundBandaraView.Columns["Id"]) != null) DeletedRows.Add((int)OutboundBandaraView.GetRowCellValue(rowHandle, OutboundBandaraView.Columns["Id"]));
                OutboundBandaraView.DeleteSelectedRows();
            }
        }

        private void FlightDataSource()
        {
            if (tbxAirline.Value != null && tbxOrigin.Value != null && tbxDestination.Value != null)
            {
                var day = (int)tbxEstDate.Value.DayOfWeek;
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

        private bool ValidateForm()
        {
            if (tbxReason.Text == "")
            {
                tbxReason.Focus();
                return false;
            }

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

            return true;
        }

        private int ValidRowCount { get; set; }
        private List<String> Dimension { get; set; }
        private void OutboundBandaraView_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
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
    }

    public class Combo
    {
        public Int32 Id { get; set; }
        public String Text { get; set; }
    }
}
