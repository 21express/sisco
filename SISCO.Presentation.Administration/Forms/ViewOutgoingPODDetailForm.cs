using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.XtraPrinting.Native;
using SISCO.App.MasterData;
using SISCO.App.Operation;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Properties;
using SISCO.Presentation.MasterData.Annotations;
using SISCO.Presentation.MasterData.Popup;

namespace SISCO.Presentation.Administration.Forms
{
    // ReSharper disable once InconsistentNaming
    public partial class ViewOutgoingPODDetailForm : BaseCrudForm<ShipmentModel, ShipmentDataManager>//BaseToolbarForm//
    {
        protected BindingList<ShipmentStatusDataRow> Statuses { get; set; }
        public BranchDataManager BranchDataManager { get; set; }
        public TrackingStatusDataManager TrackingStatusDataManager { get; set; }

        protected class ShipmentStatusDataRow : ShipmentStatusModel, INotifyPropertyChanged
        {
            public BranchDataManager BranchDataManager { get; set; }
            public TrackingStatusDataManager TrackingStatusDataManager { get; set; }

            private string _position;
            public string Position
            {
                get
                {
                    if (string.IsNullOrEmpty(_position))
                    {
                        if (PositionStatus != null && PositionStatus.ToLower().Equals("branch"))
                        {
                            var model =
                                BranchDataManager.GetFirst<BranchModel>(WhereTerm.Default(PositionStatusId, "id"));
                            _position = string.Format("{0}", model.Name);
                        }
                        else
                        {
                            _position = PositionStatus;
                        }
                    }

                    return _position;
                }
                set { _position = value; }
            }

            private string _trackingtatus;
            public new string TrackingStatus
            {
                get
                {
                    if (string.IsNullOrEmpty(_trackingtatus) && TrackingStatusId != 0)
                    {
                        var model = TrackingStatusDataManager.GetFirst<TrackingStatusModel>(WhereTerm.Default(TrackingStatusId, "id"));
                        _trackingtatus = string.Format("{0}", model.Code);
                    }

                    return _trackingtatus;
                }
                set { _trackingtatus = value; }
            }

            public DateTime StatusDate { get { return DateProcess; } }
            public string StatusTime { get { return DateProcess.ToString("HH:mm"); } }

            public event PropertyChangedEventHandler PropertyChanged;

            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }

            internal void NotifyUpdate(string propertyName)
            {
                OnPropertyChanged(propertyName);

                switch (propertyName)
                {
                    case "ShipmentStatusId":
                        TrackingStatus = null;
                        NotifyUpdate("TrackingStatus");
                        break;
                }
            }
        }

        public ViewOutgoingPODDetailForm()
        {
            InitializeComponent();
            form = this;
        }

        protected override bool ValidateForm()
        {
            return true;
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            tsBaseBtn_New.Enabled = false;
            NavigationMenu.NewStrip.Enabled = false;

            lkpBranch.LookupPopup = new BranchPopup();
            lkpBranch.AutoCompleteDataManager = new BranchDataManager();
            lkpBranch.AutoCompleteDisplayFormater = model => ((BranchModel)model).Code;
            lkpBranch.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "code", EnumSqlOperator.BeginWith),
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            BranchDataManager = new BranchDataManager();
            TrackingStatusDataManager = new TrackingStatusDataManager();
            Statuses = new BindingList<ShipmentStatusDataRow>();

            btnAddStatus.Click += (o, args) => btnAddStatus_Click();
            cmbShipmentStatus.SelectedIndexChanged += (o, args) =>
            {
                cmbMissDeliveryReason.Enabled = cmbShipmentStatus.Text.ToLower().Equals("miss-delivery");
            };

            grid.DataSource = Statuses;

            cmbShipmentStatus.DataSource = new TrackingStatusDataManager().Get<TrackingStatusModel>();
            cmbShipmentStatus.DisplayMember = "Code";
            cmbShipmentStatus.ValueMember = "Id";

            cmbMissDeliveryReason.DataSource = new MissDeliveryReasonDataManager().Get<MissDeliveryReasonModel>();
            cmbMissDeliveryReason.DisplayMember = "Code";
            cmbMissDeliveryReason.ValueMember = "Id";

            txtDateAdd.DateTime = DateTime.Now;
            txtTimeAdd.Text = DateTime.Now.ToString("HH:mm");
        }

        private void btnAddStatus_Click()
        {
            if (lkpBranch.Value == null)
            {
                MessageBox.Show(@"Please choose a base branch!");
                return;
            }
            if (cmbMissDeliveryReason.SelectedValue == null)
            {
                MessageBox.Show(@"Please choose a reason for the missed delivery!");
                return;
            }

            Statuses.Add(new ShipmentStatusDataRow
            {
                BranchDataManager = BranchDataManager,
                TrackingStatusDataManager = TrackingStatusDataManager,

                ShipmentId = CurrentModel.Id,
                DateProcess = DateTime.Parse(txtDateAdd.DateTime.ToString("yyyy-MM-dd") + " " + txtTimeAdd.Text),
                TrackingStatusId = (int)cmbShipmentStatus.SelectedValue,
                MissDeliveryReason = "",
                PositionStatus = "BRANCH",
                PositionStatusId = (int) lkpBranch.Value,
                BranchId = BaseControl.BranchId,
                StatusBy = txtBy.Text,
                EmployeeId = BaseControl.EmployeeId,
                StatusNote = txtNote.Text,

                Rowstatus = true,
                Rowversion = DateTime.Now,
                Createddate = DateTime.Now,
                Createdby = BaseControl.UserLogin,
            });

            if (chkPodSent.Checked)
            {
                ((ShipmentModel)CurrentModel).PodSent = 1;
            }

            txtDateAdd.DateTime = DateTime.Now;
            txtTimeAdd.Text = DateTime.Now.ToString("HH:mm");
            cmbShipmentStatus.SelectedIndex = 0;
            cmbMissDeliveryReason.SelectedIndex = 0;
            chkPodSent.Checked = true;
        }

        protected override void PopulateForm(ShipmentModel model)
        {
            txtDate.Text = model.DateProcess.ToString("dd-MM-yyyy");
            txtShipmentNo.Text = model.Code;
            txtOrigin.Text = model.CityName;
            txtDestination.Text = model.DestCity;

            using (var customerDataManager = new CustomerDataManager())
            {
                var i =
                    customerDataManager.GetFirst<CustomerModel>(WhereTerm.Default(model.CustomerId ?? 0, "id",
                        EnumSqlOperator.Equals));
                if (i != null)
                {
                    txtCustomerCode.Text = i.Code;
                }
            }

            txtCustomerName.Text = model.CustomerName;

            txtShipperName.Text = model.ShipperAddress;
            txtShipperAddress.Text = model.ShipperAddress;
            txtShipperPhone.Text = model.ShipperPhone;

            txtConsigneeName.Text = model.ConsigneeName;
            txtConsigneeAddress.Text = model.ConsigneeAddress;
            txtConsigneePhone.Text = model.ConsigneePhone;

            using (var packageTypeDataManager = new PackageTypeDataManager())
            {
                var i = packageTypeDataManager.GetFirst<PackageTypeModel>(WhereTerm.Default(model.PackageTypeId, "id", EnumSqlOperator.Equals));
                if (i != null)
                {
                    txtPackageType.Text = i.Name;
                }
            }

            using (var serviceTypeDataManager = new ServiceTypeDataManager())
            {
                var i = serviceTypeDataManager.GetFirst<ServiceTypeModel>(WhereTerm.Default(model.ServiceTypeId, "id", EnumSqlOperator.Equals));
                if (i != null)
                {
                    txtServiceType.Text = i.Name;
                }
            }

            using (var paymentMethodDataManager = new PaymentMethodDataManager())
            {
                var i = paymentMethodDataManager.GetFirst<PaymentMethodModel>(WhereTerm.Default(model.PaymentMethodId, "id", EnumSqlOperator.Equals));
                if (i != null)
                {
                    txtPaymentMethod.Text = i.Name;
                }
            }

            txtNatureOfGoods.Text = model.NatureOfGoods;

            pnlShipmentInformation.Enabled = false;
            pnlShipperInformation.Enabled = false;
            pnlConsigneeInformation.Enabled = false;
            pnlOtherInformation.Enabled = false;
            cmbMissDeliveryReason.Enabled = false;

            Statuses.RaiseListChangedEvents = false;

            Statuses.Clear();

            new ShipmentStatusDataManager().
                Get<ShipmentStatusModel>(WhereTerm.Default(model.Id, "shipment_id")).
                Select(row => new ShipmentStatusDataRow
                {
                    BranchDataManager = BranchDataManager,
                    TrackingStatusDataManager = TrackingStatusDataManager,

                    Id = row.Id,
                    ShipmentId = row.ShipmentId,
                    DateProcess = row.DateProcess,
                    TrackingStatusId = row.TrackingStatusId,
                    MissDeliveryReason = row.MissDeliveryReason,
                    PositionStatus = row.PositionStatus,
                    PositionStatusId = row.PositionStatusId,
                    BranchId = row.BranchId,
                    StatusBy = row.StatusBy,
                    EmployeeId = BaseControl.EmployeeId,
                    StatusNote = row.StatusNote,

                    Rowstatus = row.Rowstatus,
                    Rowversion = row.Rowversion,
                    Createddate = row.Createddate,
                    Createdby = row.Createdby,
                    Modifieddate = row.Modifieddate,
                    Modifiedby = row.Modifiedby,
                })
                .ForEach(row => Statuses.Add(row));

            Statuses.RaiseListChangedEvents = true;
            Statuses.ResetBindings();

            txtDateAdd.DateTime = DateTime.Now;
            txtTimeAdd.Text = DateTime.Now.ToString("HH:mm");

            tsBaseTxt_Code.Text = model.Code;
        }

        protected override ShipmentModel PopulateModel(ShipmentModel model)
        {
            return model;
        }

        protected override ShipmentModel Find(string searchTerm)
        {
            return DataManager.GetFirst<ShipmentModel>(WhereTerm.Default(searchTerm, "Code"));
        }

        public override void Save()
        {
            if (!ValidateForm())
            {
                MessageBox.Show(
                   Resources.alert_empty_field
                   , Resources.title_save_changes
                   , MessageBoxButtons.OK
                   , MessageBoxIcon.Information);

                return;
            }

            if (CurrentModel.Id != 0)
            {
                ((ShipmentDataManager)DataManager).Update<ShipmentModel>(CurrentModel);
            }

            new ShipmentStatusDataManager().Save(CurrentModel.Id, Statuses);

            RefreshToolbarState();

            AfterSave();
            Buttons();

            StateChange = EnumStateChange.Update;
        }

        protected override void RefreshToolbarState()
        {
            base.RefreshToolbarState();

            NavigationMenu.NewStrip.Enabled = false;
            NavigationMenu.DeleteStrip.Enabled = false;
            tsBaseBtn_New.Enabled = false;
            tsBaseBtn_Delete.Enabled = false;
        }
    }
}
