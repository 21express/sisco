using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.App.MasterData;
using SISCO.App.Operation;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.CustomerService.Forms;

namespace SISCO.Presentation.Operation.Forms
{
    public partial class InboundDaratForm : BaseCrudForm<WaybillModel, WaybillDataManager>
    {
        public InboundDaratForm()
        {
            InitializeComponent();

            form = this;
            DataManager = new WaybillDataManager();
            Load += InboundDaratLoad;
            btnExcel.Click += (sender, args) => ExportExcel(GridWaybillDetail);
            //Shown += (sender, args) => Top();
            WaybillDetailView.DoubleClick += (sender, args) => OpenRelatedForm(WaybillDetailView, new TrackingViewForm(), "ShipmentCode");

            FormTrackingStatus = EnumTrackingStatus.Arrival;
            DataManager.DefaultParameters = new IListParameter[]
            {
                //WhereTerm.Default(false, "departed"), 
                WhereTerm.Default(BaseControl.BranchId, "dest_branch_id", EnumSqlOperator.Equals)
            };
        }

        private void InboundDaratLoad(object sender, EventArgs e)
        {
            VisibleBtnNew = false;
            VisibleBtnDelete = true;

            tbxArrKoli.IsNumber = true;
            tbxArrWeight.IsNumber = true;
        }

        protected override void  SaveDetail(bool isUpdate = false)
        {
            var details = new WaybillDetailDataManager().Get<WaybillDetailModel>(WhereTerm.Default(CurrentModel.Id, "waybill_id", EnumSqlOperator.Equals));
            // ReSharper disable once PossibleMultipleEnumeration
            var waybillDetailModels = details as IList<WaybillDetailModel> ?? details.ToList();
            if (waybillDetailModels.Any())
            {
                var dm = new ShipmentDataManager();
                foreach (WaybillDetailModel detail in waybillDetailModels)
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
            var detail = new WaybillDetailDataManager().Get<WaybillDetailModel>(WhereTerm.Default(CurrentModel.Id, "airwaybill_id", EnumSqlOperator.Equals));
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

        protected override void PopulateForm(WaybillModel model)
        {
            ClearForm();
            if (model == null) return;

            tbxDate.Enabled = false;
            tbxDate.Properties.Buttons[0].Enabled = false;
            tbxNo.ReadOnly = true;
            tbxBranch.ReadOnly = true;
            tbxPengangkut.ReadOnly = true;
            tbxDriver.ReadOnly = true;
            dTextBox1.ReadOnly = true;

            ToolbarCode = model.Code;
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxDate.Text = model.DateProcess.ToString();
            tbxNo.Text = model.Code;

            var branch =
                new BranchDataManager().GetFirst<BranchModel>(WhereTerm.Default(model.DestBranchId, "id",
                    EnumSqlOperator.Equals));
            tbxBranch.Text = branch.Code + @" - " + branch.Name;

            tbxPengangkut.Text = model.EstCarrier;
            tbxDriver.Text = model.EmployeeName;

            tbxArrDate.Text = model.ArrDate.ToString();
            tbxArrTime.Text = model.ArrTime;
            dTextBox1.Text = model.ActCategory;

            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxArrKoli.SetValue(model.ArrTtlPiece.ToString());
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxArrWeight.SetValue(model.ArrTtlGrossWeight.ToString());
            tbxDimension.Text = model.Dimension;
            var details =
                new WaybillDetailDataManager().Get<WaybillDetailModel>(WhereTerm.Default(model.Id,
                    "waybill_id", EnumSqlOperator.Equals));

            GridWaybillDetail.DataSource = details;
            WaybillDetailView.RefreshData();

            tsBaseTxt_Code.Focus();
        }

        protected override WaybillModel PopulateModel(WaybillModel model)
        {
            model.ArrDate = tbxArrDate.Value;
            model.ArrTime = tbxArrTime.Text;
            model.ArrTtlPiece = (short)tbxArrKoli.Value;
            model.ArrTtlGrossWeight = tbxArrWeight.Value;
            model.Arrived = true;
            model.Departed = true;
            model.ActConfirmed = true;
            model.ActUsername = BaseControl.UserLogin;
            model.ActUpdated = DateTime.Now;
            model.StatusId = (int) EnumTrackingStatus.Arrival;

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
}