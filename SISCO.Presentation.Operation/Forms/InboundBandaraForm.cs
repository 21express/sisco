using System;
using System.Collections.Generic;
using System.Linq;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using SISCO.App.MasterData;
using SISCO.App.Operation;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.CustomerService.Forms;
using SISCO.Presentation.Operation.Popup;

namespace SISCO.Presentation.Operation.Forms
{
    public partial class InboundBandaraForm : BaseCrudForm<AirwaybillModel, AirwaybillDataManager>//BaseToolbarForm//
    {
        public InboundBandaraForm()
        {
            InitializeComponent();

            form = this;
            DataManager = new AirwaybillDataManager();
            Load += InboundBandaraLoad;
            btnExcel.Click += (sender, args) => ExportExcel(GridAirwaybillDetail);
            AirwaybillDetailView.CustomColumnDisplayText += NumberGrid;
            AirwaybillDetailView.DoubleClick += (sender, args) =>
            {
                var rows = AirwaybillDetailView.GetSelectedRows();
                if (rows.Count() > 0)
                {
                    if (AirwaybillDetailView.GetRowCellValue(rows[0], "CustomerName").ToString().Contains("TRANSIT"))
                        return;

                    if (!AirwaybillDetailView.GetRowCellValue(rows[0], "CustomerName").ToString().Equals("CONSOL"))
                        OpenRelatedForm(AirwaybillDetailView, new TrackingViewForm(), "ShipmentCode");
                }
            };

            AirwaybillDetailView.CustomSummaryCalculate += PieceCalculate;

            //Shown += (sender, args) => Top();

            FormTrackingStatus = EnumTrackingStatus.Arrival;
            DataManager.DefaultParameters = new IListParameter[] { WhereTerm.Default(true, "act_confirmed"), WhereTerm.Default(BaseControl.BranchId, "dest_branch_id", EnumSqlOperator.Equals) };
        }

        private int ValidRowCount { get; set; }
        private void PieceCalculate(object sender, CustomSummaryEventArgs e)
        {
            var item = e.Item as GridColumnSummaryItem;
            var view = sender as GridView;

            if (item != null && item.FieldName == "TtlPiece")
            {
                if (e.SummaryProcess == CustomSummaryProcess.Start) ValidRowCount = 0;
                if (e.SummaryProcess == CustomSummaryProcess.Calculate)
                {
                    if (view != null &&
                            Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, "TtlChargeableWeight")) > 0)
                        ValidRowCount++;
                }

                if (e.SummaryProcess == CustomSummaryProcess.Finalize) e.TotalValue = ValidRowCount;
            }
        }

        private void InboundBandaraLoad(object sender, EventArgs e)
        {
            VisibleBtnNew = false;
            VisibleBtnDelete = false;
            EnableBtnSearch = true;

            tbxArrKoli.IsNumber = true;

            SearchPopup = new InboundBandaraFilterPopup();
        }

        public override void Save()
        {
            base.Save();

            if (StateChange == EnumStateChange.Update)
            {
                Bottom();
                StateChange = EnumStateChange.Select;
            }
        }

        protected override void  SaveDetail(bool isUpdate = false)
        {
            var details = new AirwaybillDetailDataManager().Get<AirwaybillDetailModel>(WhereTerm.Default(CurrentModel.Id, "airwaybill_id", EnumSqlOperator.Equals));
            // ReSharper disable once PossibleMultipleEnumeration
            var airwaybillDetailModels = details as IList<AirwaybillDetailModel> ?? details.ToList();
            if (airwaybillDetailModels.Any())
            {
                var dm = new ShipmentDataManager();
                foreach (AirwaybillDetailModel detail in airwaybillDetailModels)
                {
                    if (detail.ShipmentId == 0)
                    {
                        var manifestDetails =
                            new ManifestDetailDataManager().Get<ManifestDetailModel>(
                                WhereTerm.Default(detail.ShipmentCode, "consol_code", EnumSqlOperator.Equals));

                        // ReSharper disable once PossibleMultipleEnumeration
                        var manifestDetailModels = manifestDetails as ManifestDetailModel[] ??
                                                   manifestDetails.ToArray();
                        if (manifestDetailModels.Any())
                        {
                            foreach (ManifestDetailModel detailModel in manifestDetailModels)
                            {
                                // ReSharper disable once PossibleInvalidOperationException
                                var shipment =
                                    dm.GetFirst<ShipmentModel>(
                                        WhereTerm.Default((int)detailModel.ShipmentId, "id", EnumSqlOperator.Equals));

                                if (shipment.TrackingStatusId != (int)EnumTrackingStatus.Received && shipment.TrackingStatusId != (int)EnumTrackingStatus.Claimed && shipment.TrackingStatusId != (int)EnumTrackingStatus.Gudang)
                                {
                                    shipment.TrackingStatusId = (int)EnumTrackingStatus.Arrival;
                                    shipment.Modifiedby = BaseControl.UserLogin;
                                    shipment.Modifieddate = DateTime.Now;
                                    dm.Update<ShipmentModel>(shipment);
                                }

                                var checkStatus = new ShipmentStatusDataManager().GetFirst<ShipmentStatusModel>(new IListParameter[]
                                            {
                                                WhereTerm.Default((int) detailModel.ShipmentId, "shipment_id", EnumSqlOperator.Equals),
                                                WhereTerm.Default((int) EnumTrackingStatus.Arrival, "tracking_status_id", EnumSqlOperator.Equals)
                                            });

                                if (checkStatus == null)
                                {
                                    InsertTracking = true;
                                    PodStatusModel.ShipmentId = (int)detailModel.ShipmentId;
                                    PodStatusModel.PositionStatusId = BaseControl.BranchId;
                                    PodStatusModel.PositionStatus = EnumPositionStatus.Branch.ToString();

                                    ShipmentStatusUpdate();
                                }
                            }
                        }
                    }
                    else
                    {
                        var shipment =
                            dm.GetFirst<ShipmentModel>(
                                WhereTerm.Default(detail.ShipmentId, "id", EnumSqlOperator.Equals));

                        if (shipment.TrackingStatusId != (int)EnumTrackingStatus.Received && shipment.TrackingStatusId != (int)EnumTrackingStatus.Claimed && shipment.TrackingStatusId != (int)EnumTrackingStatus.Gudang)
                        {
                            shipment.TrackingStatusId = (int)EnumTrackingStatus.Arrival;
                            shipment.Modifiedby = BaseControl.UserLogin;
                            shipment.Modifieddate = DateTime.Now;
                            dm.Update<ShipmentModel>(shipment);
                        }

                        var checkStatus = new ShipmentStatusDataManager().GetFirst<ShipmentStatusModel>(new IListParameter[]
                                            {
                                                WhereTerm.Default(detail.ShipmentId, "shipment_id", EnumSqlOperator.Equals),
                                                WhereTerm.Default((int) EnumTrackingStatus.Arrival, "tracking_status_id", EnumSqlOperator.Equals)
                                            });

                        if (checkStatus == null)
                        {
                            InsertTracking = true;
                            PodStatusModel.ShipmentId = detail.ShipmentId;
                            PodStatusModel.PositionStatusId = BaseControl.BranchId;
                            PodStatusModel.PositionStatus = EnumPositionStatus.Branch.ToString();

                            ShipmentStatusUpdate();
                        }
                    }
                }
            }

            OpenData(ToolbarCode);
        }

        protected override void AfterSave()
        {
            StateChange = EnumStateChange.Select;
            tsBaseTxt_Code.Focus();
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
                            WhereTerm.Default((int) EnumTrackingStatus.Arrival, "tracking_status_id", EnumSqlOperator.Equals)
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
            if (tbxArrDate.Text != "" || tbxArrTime.Text != "" || tbxArrKoli.Value > 0 || tbxArrWeight.Value > 0)
                return true;

            if (tbxArrDate.Text == "")
            {
                tbxArrDate.Focus();
                return false;
            }

            if (tbxArrTime.Text == "")
            {
                tbxArrTime.Focus();
                return false;
            }

            if (tbxArrKoli.Value < 1)
            {
                tbxArrKoli.Focus();
                return false;
            }

            if (tbxArrWeight.Value < 1)
            {
                tbxArrWeight.Focus();
                return false;
            }
                

            return false;
        }

        protected override void PopulateForm(AirwaybillModel model)
        {
            ClearForm();
            if (model == null) return;

            ToolbarCode = model.Code;
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxDate.Text = model.DateProcess.ToString();
            tbxAwb.Text = model.Code;

            var airline = new AirlineDataManager().GetFirst<AirlineModel>(WhereTerm.Default(model.AirlineId, "id", EnumSqlOperator.Equals));
            tbxAirline.Text = airline.Name;

            var origin = new AirportDataManager().GetFirst<AirportModel>(WhereTerm.Default(model.AirportId, "id", EnumSqlOperator.Equals));
            tbxOrigin.Text = origin.Name;

            var dest = new AirportDataManager().GetFirst<AirportModel>(WhereTerm.Default(model.DestAirportId, "id", EnumSqlOperator.Equals));
            tbxDestination.Text = dest.Name;

            tbxArrDate.Text = model.ArrDate.ToString();
            tbxArrTime.Text = model.ArrTime;
            
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxArrKoli.SetValue(model.ArrTtlPiece.ToString());
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxArrWeight.SetValue(model.ArrTtlGrossWeight.ToString());
            tbxDimension.Text = model.Dimension;

            var details =
                new AirwaybillDetailDataManager().Get<AirwaybillDetailModel>(WhereTerm.Default(model.Id,
                    "airwaybill_id", EnumSqlOperator.Equals));

            GridAirwaybillDetail.DataSource = details;
            AirwaybillDetailView.RefreshData();

            tsBaseTxt_Code.Focus();

            tbxDate.Enabled = false;
            tbxDate.Properties.Buttons[0].Enabled = false;
            tbxAwb.ReadOnly = true;
            tbxAirline.ReadOnly = true;
            tbxOrigin.ReadOnly = true;
            tbxDestination.ReadOnly = true;
            tbxDimension.ReadOnly = true;
        }

        protected override AirwaybillModel PopulateModel(AirwaybillModel model)
        {
            model.ArrDate = tbxArrDate.Value;
            model.ArrTime = tbxArrTime.Text;
            model.ArrTtlPiece = (short) tbxArrKoli.Value;
            model.ArrTtlGrossWeight = tbxArrWeight.Value;
            model.ArrUpdated = DateTime.Now;
            model.ArrUsername = BaseControl.UserLogin;
            model.StatusId = (int) EnumTrackingStatus.Arrival;

            return model;
        }

        protected override AirwaybillModel Find(string searchTerm)
        {
            if (!string.IsNullOrEmpty(searchTerm)) tsBaseTxt_Code.Text = searchTerm;
            var param = new IListParameter[]
                {
                    WhereTerm.Default(tsBaseTxt_Code.Text, "code", EnumSqlOperator.Equals)
                };
            var obj = DataManager.GetFirst<AirwaybillModel>(param);
            PopulateForm(obj);

            return obj;
        }

        public override void Info()
        {
            var model = CurrentModel as AirwaybillModel;
            if (model != null)
            {
                info.CreatedPc = model.CreatedPc;
                info.ModifiedPc = model.ModifiedPc;
            }

            base.Info();
        }
    }
}