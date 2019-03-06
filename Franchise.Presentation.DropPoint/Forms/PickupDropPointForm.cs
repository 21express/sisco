using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Franchise.Presentation.Common;
using Franchise.Presentation.Common.Forms;
using Franchise.Presentation.DropPoint.Popup;
using SISCO.App.Administration;
using SISCO.App.Franchise;
using SISCO.App.MasterData;
using SISCO.App.Operation;
using SISCO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Franchise.Presentation.DropPoint.Forms
{
    public partial class PickupDropPointForm : BaseCrudForm<FranchiseDropPointModel, FranchiseDropPointDataManager>//BaseToolbarForm//
    {
        public PickupDropPointForm()
        {
            InitializeComponent();
            form = this;
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            btnAdd.Click += Pickup;
            ShipmentView.CustomColumnDisplayText += NumberGrid;

            EnableBtnSearch = true;
            SearchPopup = new DropPointPickupPopup();
        }

        private void Pickup(object sender, EventArgs e)
        {
            var model = new ShipmentNumberAllocationDataManager().GetFirst<ShipmentAllocationModel>(
                WhereTerm.Default(Convert.ToInt64(tbxPod.Text), "shipment_code_start", EnumSqlOperator.LesThanEqual),
                WhereTerm.Default(Convert.ToInt64(tbxPod.Text), "shipment_code_end", EnumSqlOperator.GreatThanEqual),
                WhereTerm.Default(0, "drop_point_id", EnumSqlOperator.GreatThan)
            );

            if (model != null)
            {
                var shipmentDp = new FranchiseDropPointDetailDataManager().PickupDropPoint(tbxPod.Text);
                if (shipmentDp == null)
                {
                    using (var dialog = new AcceptanceDropPointForm
                        {
                            StartPosition = FormStartPosition.CenterScreen,
                            NoResi = tbxPod.Text,
                            ShowInTaskbar = false
                        })
                    {
                        dialog.ShowDialog();

                        if (!string.IsNullOrEmpty(dialog.NoResi))
                        {
                            shipmentDp = new FranchiseDropPointDetailDataManager().PickupDropPoint(dialog.NoResi);
                        }
                        else
                        {
                            tbxPod.Clear();
                            tbxPod.Focus();
                            return;
                        }
                    }
                }

                var exists = new FranchiseDropPointDetailDataManager().ShipmentPickedup(tbxPod.Text);
                if (exists != null)
                {
                    MessageBox.Show("No resi sudah di pickup.");
                    tbxPod.Clear();
                    tbxPod.Focus();
                    return;
                }

                var data = GridShipment.DataSource as List<FranchiseDropPointPickup>;
                if (data != null)
                {
                    if (data.Count > 0)
                    {
                        var existsdata = data.Where(p => p.ShipmentCode == tbxPod.Text).FirstOrDefault();
                        if (existsdata != null)
                        {
                            tbxPod.Clear();
                            tbxPod.Focus();
                            return;
                        }
                    }
                }
                else data = new List<FranchiseDropPointPickup>();

                data.Add(shipmentDp);

                GridShipment.DataSource = data;
                ShipmentView.RefreshData();

                tbxPod.Clear();
                tbxPod.Focus();
            }
            else
            {
                MessageBox.Show("Nomor resi tidak dikenali.");
                tbxPod.Clear();
                tbxPod.Focus();
            }
        }

        protected override bool ValidateForm()
        {
            if (tbxDate.Value == null)
            {
                tbxDate.Focus();
                return false;
            }

            if (ShipmentView.RowCount == 0)
            {
                tbxPod.Focus();
                return false;
            }

            return true;
        }

        protected override void PopulateForm(FranchiseDropPointModel model)
        {
            ClearForm();
            
            tbxDate.DateTime = model.PickupDate;
            tbxSearch_Code.Text = model.Code;
            var data = new FranchiseDropPointDetailDataManager().GetPickupDropPoint(model.Id);
            GridShipment.DataSource = data;
            ShipmentView.RefreshData();
        }

        protected override FranchiseDropPointModel PopulateModel(FranchiseDropPointModel model)
        {
            model.PickupDate = tbxDate.DateTime;
            if (model.Id == 0)
            {
                model.Code = new FranchiseDropPointDataManager().GenerateCode(DateTime.Now);
            }

            return model;
        }

        protected override FranchiseDropPointModel Find(string searchTerm)
        {
            return DataManager.GetFirst<FranchiseDropPointModel>(WhereTerm.Default(searchTerm, "code"));
        }

        public override void New()
        {
            base.New();

            ClearForm();
            EnabledForm(true);

            GridShipment.DataSource = null;
            ShipmentView.RefreshData();

            rbData_Save.Enabled = true;
            tbxDate.DateTime = DateTime.Now;
            tbxDate.Focus();
        }

        protected override void SaveDetail(bool isUpdate = false)
        {
            var currnModel = CurrentModel as FranchiseDropPointModel;
            var details = GridShipment.DataSource as List<FranchiseDropPointPickup>;
            var manager = new FranchiseDropPointDetailDataManager();
            var smanager = new ShipmentDataManager();

            foreach (FranchiseDropPointPickup detail in details)
            {
                var pickupDetail = new FranchiseDropPointDetailModel();
                var shipment = new ShipmentModel();
                var status = new ShipmentStatusModel();

                pickupDetail.Rowstatus = true;
                pickupDetail.Rowversion = DateTime.Now;
                pickupDetail.FranchiseDropPointId = CurrentModel.Id;
                pickupDetail.ShipmentId = detail.Id;
                pickupDetail.Createdby = BaseControl.UserLogin;
                pickupDetail.Createddate = DateTime.Now;

                manager.Save<FranchiseDropPointDetailModel>(pickupDetail);
                shipment = smanager.GetFirst<ShipmentModel>(WhereTerm.Default(detail.Id, "id"));
                if (shipment != null)
                {
                    shipment.PODStatus = (int)EnumPodStatus.None;
                    shipment.FranchiseId = BaseControl.FranchiseId;
                    shipment.TrackingStatusId = (int)EnumTrackingStatus.AgentPickup;
                    shipment.ModifiedPc = Environment.MachineName;
                    shipment.Modifiedby = BaseControl.UserLogin;
                    shipment.Modifieddate = DateTime.Now;

                    smanager.Update<ShipmentModel>(shipment);

                    new FranchiseCommissionDataManager().CalculateCommission(shipment, BaseControl.FranchiseId, BaseControl.UserLogin);

                    var statusCurr = new ShipmentStatusDataManager().GetFirst<ShipmentStatusModel>(new IListParameter[]
                        {
                            WhereTerm.Default(detail.Id, "shipment_id"),
                            WhereTerm.Default((int) EnumTrackingStatus.AgentPickup, "tracking_status_id")
                        }
                    );

                    if (statusCurr == null)
                    {
                        status.Rowstatus = true;
                        status.Rowversion = DateTime.Now;
                        status.DateProcess = DateTime.Now;
                        status.ShipmentId = detail.Id;
                        status.TrackingStatusId = (int)EnumTrackingStatus.AgentPickup;
                        status.PositionStatusId = BaseControl.BranchId;
                        status.PositionStatus = EnumPositionStatus.Agent.ToString();
                        status.BranchId = BaseControl.BranchId;
                        status.StatusBy = BaseControl.UserLogin;
                        status.Reference = currnModel.Code;
                        status.Createdby = BaseControl.UserLogin;
                        status.Createddate = DateTime.Now;

                        new ShipmentStatusDataManager().Save<ShipmentStatusModel>(status);
                    }
                }
            }
        }

        protected override void AfterSave()
        {
            base.AfterSave();
            tbxSearch_Code.Text = ((FranchiseDropPointModel)CurrentModel).Code;
            PerformFind();
        }

        protected override void RefreshToolbarState()
        {
            base.RefreshToolbarState();

            var model = CurrentModel as FranchiseDropPointModel;
            if (model == null) return;
            if (model.Id > 0)
            {
                EnabledForm(false);
                rbData_Save.Enabled = false;
                rbData_Delete.Enabled = false;
            }
        }
    }
}