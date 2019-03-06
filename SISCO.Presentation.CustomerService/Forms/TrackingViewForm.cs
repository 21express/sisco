using System;
using System.ComponentModel;
using System.Linq;
using Devenlab.Common;
using DevExpress.Utils;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraPrinting.Native;
using SISCO.App.MasterData;
using SISCO.App.Operation;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.ComponentRepositories;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.CustomerService.Popup;
using SISCO.Presentation.MasterData.Annotations;
using System.Windows.Forms;
using SISCO.App.Franchise;
using DevExpress.Data;

namespace SISCO.Presentation.CustomerService.Forms
{
    public partial class TrackingViewForm : BaseCrudForm<ShipmentModel, ShipmentDataManager>//BaseToolbarForm//
    {
        protected BindingList<ShipmentStatusDataRow> Statuses { get; set; }
        public BranchDataManager BranchDataManager { get; set; }
        public TrackingStatusDataManager TrackingStatusDataManager { get; set; }
        public MissDeliveryReasonDataManager MissDeliveryReasonDataManager { get; set; }
        public EmployeeDataManager EmployeeDataManager { get; set; }

        protected class ShipmentStatusDataRow : ShipmentStatusModel, INotifyPropertyChanged
        {
            public BranchDataManager BranchDataManager { get; set; }
            public TrackingStatusDataManager TrackingStatusDataManager { get; set; }
            public MissDeliveryReasonDataManager MissDeliveryReasonDataManager { get; set; }
            public EmployeeDataManager EmployeeDataManager { get; set; }

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

            private string _employee;
            public string Employee
            {
                get
                {
                    if (string.IsNullOrEmpty(_employee))
                    {
                        if (EmployeeId != null)
                        {
                            var model =
                                EmployeeDataManager.GetFirst<EmployeeModel>(WhereTerm.Default((int)EmployeeId, "id"));
                            _employee = string.Format("{0}", model.Code);
                        }
                    }

                    return _employee;
                }
                set { _employee = value; }
            }

            public int Index { get; set; }

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
                    case "EmployeeId":
                        Employee = null;
                        NotifyUpdate("Employee");
                        break;
                }
            }
        }

        public TrackingViewForm()
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

            EnableBtnSearch = true;
            SearchPopup = new ShipmentPopup();

            BranchDataManager = new BranchDataManager();
            TrackingStatusDataManager = new TrackingStatusDataManager();
            MissDeliveryReasonDataManager = new MissDeliveryReasonDataManager();
            EmployeeDataManager = new EmployeeDataManager();
            Statuses = new BindingList<ShipmentStatusDataRow>();

            grid.DataSource = Statuses;

            btnRefreshStatus.Click += (o, args) =>
            {
                Statuses.RaiseListChangedEvents = false;
                Statuses.Clear();

                new ShipmentStatusDataManager().
                    Get<ShipmentStatusModel>(WhereTerm.Default(CurrentModel.Id, "shipment_id")).
                    Select((row, i) => new ShipmentStatusDataRow
                    {
                        BranchDataManager = BranchDataManager,
                        TrackingStatusDataManager = TrackingStatusDataManager,
                        MissDeliveryReasonDataManager = MissDeliveryReasonDataManager,
                        EmployeeDataManager = EmployeeDataManager,

                        Index = i + 1,
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
                        Reference = row.Reference,
                        Rowstatus = row.Rowstatus,
                        Rowversion = row.Rowversion,
                        Createddate = row.Createddate,
                        Createdby = row.Createdby,
                        Modifieddate = row.Modifieddate,
                        Modifiedby = row.Modifiedby,
                    })
                    .OrderByDescending(r => r.DateProcess)
                    .ForEach(row => Statuses.Add(row));
                Statuses.RaiseListChangedEvents = true;
                Statuses.ResetBindings();
            };

            txtTotalPieces.EditMask = "###,##0";
            txtTotalWeight.EditMask = "###,##0.0";
            txtChargeableWeight.EditMask = "###,##0.0";

            gridColumn2.DisplayFormat.FormatType = FormatType.DateTime;
            gridColumn2.DisplayFormat.FormatString = "dd-MM-yyyy";

            btnSaveToExcel.Click += (o, args) => ExportGridToExcel(gridView, string.Format("CustomerService_TrackingView_{0}", ((ShipmentModel)CurrentModel).Code));
        }

        protected override void PopulateForm(ShipmentModel model)
        {
            ClearForm();
            tsBaseTxt_Code.Text = model.Code;

            if (model.FranchiseId != null)
            {
                var franchise = new FranchiseDataManager().GetFirst<FranchiseModel>(WhereTerm.Default((int)model.FranchiseId, "id"));
                if (franchise != null)
                {
                    tbxAgent.Text = string.Format("{0} - {1}", franchise.Code, franchise.Name);
                }
            }

            txtDate.Text = model.DateProcess.ToString("dd-MM-yyyy");
            txtShipmentNo.Text = model.Code;
            txtOrigin.Text = model.CityName;
            txtDestination.Text = model.DestCity;

            using (var customerDataManager = new CustomerDataManager())
            {
                var i =
                    customerDataManager.GetFirst<CustomerModel>(WhereTerm.Default(model.CustomerId ?? 0, "id",
                        EnumSqlOperator.Equals));
                txtCustomerCode.Text = (i != null) ? i.Code : "";
            }

            txtCustomerName.Text = model.CustomerName;

            txtShipperName.Text = model.ShipperName;
            txtShipperAddress.Text = model.ShipperAddress;
            txtShipperPhone.Text = model.ShipperPhone;

            txtConsigneeName.Text = model.ConsigneeName;
            txtConsigneeAddress.Text = model.ConsigneeAddress;
            txtConsigneePhone.Text = model.ConsigneePhone;

            using (var packageTypeDataManager = new PackageTypeDataManager())
            {
                var i = packageTypeDataManager.GetFirst<PackageTypeModel>(WhereTerm.Default(model.PackageTypeId, "id", EnumSqlOperator.Equals));
                txtPackageType.Text = (i != null) ? i.Name : "";
            }

            using (var serviceTypeDataManager = new ServiceTypeDataManager())
            {
                var i = serviceTypeDataManager.GetFirst<ServiceTypeModel>(WhereTerm.Default(model.ServiceTypeId, "id", EnumSqlOperator.Equals));
                txtServiceType.Text = (i != null) ? i.Name : "";
            }

            using (var paymentMethodDataManager = new PaymentMethodDataManager())
            {
                var i =
                    paymentMethodDataManager.GetFirst<PaymentMethodModel>(WhereTerm.Default(model.PaymentMethodId, "id",
                        EnumSqlOperator.Equals));
                txtPaymentMethod.Text = (i != null) ? i.Name : "";
            }
            txtNatureOfGoods.Text = model.NatureOfGoods;
            txtNote.Text = model.Note;

            txtTotalPieces.Value = model.TtlPiece;
            txtTotalWeight.Value = model.TtlGrossWeight;
            txtChargeableWeight.Value = model.TtlChargeableWeight;
            tbxPacking.Value = model.PackingFee;
            tbxCod.Value = 0;

            var extend = new ShipmentExpandDataManager().GetFirst<ShipmentExpandModel>(WhereTerm.Default(model.Id, "shipment_id"));
            if (extend != null)
            {
                if (extend.TotalCod > 0) tbxCod.Value = extend.TotalCod;
                tbxFulfilment.Text = extend.Fulfilment;
            }

            tbxAgent.Enabled = false;
            txtDate.Enabled = false;
            txtShipmentNo.Enabled = false;
            txtOrigin.Enabled = false;
            txtDestination.Enabled = false;
            tbxFulfilment.Enabled = false;

            txtTotalPieces.Enabled = false;
            txtTotalWeight.Enabled = false;
            txtChargeableWeight.Enabled = false;
            tbxPacking.Enabled = false;
            tbxCod.Enabled = false;

            _SetControlEnableState(pnlShipperInformation, false);
            _SetControlEnableState(pnlConsigneeInformation, false);
            _SetControlEnableState(pnlOtherInformation, false);

            NavigationMenu.NewStrip.Enabled = false;
            NavigationMenu.SaveStrip.Enabled = false;
            NavigationMenu.DeleteStrip.Enabled = false;
            tsBaseBtn_New.Enabled = false;
            tsBaseBtn_Save.Enabled = false;
            tsBaseBtn_Delete.Enabled = false;

            if (model.Voided)
            {
                MessageBox.Show(@"POD sudah di-VOID!");
                EnabledForm(false);
            }

            btnRefreshStatus.PerformClick();

            tsBaseTxt_Code.Focus();
        }

        protected override ShipmentModel PopulateModel(ShipmentModel model)
        {
            throw new NotImplementedException();
        }

        protected override ShipmentModel Find(string searchTerm)
        {
            return DataManager.GetFirst<ShipmentModel>(WhereTerm.Default(searchTerm, "Code"));
        }

        protected override void SaveDetail(bool isUpdate = false)
        {
            new ShipmentStatusDataManager().Save(CurrentModel.Id, Statuses);
        }

        protected override void RefreshToolbarState()
        {
            base.RefreshToolbarState();

            NavigationMenu.NewStrip.Enabled = false;
            NavigationMenu.SaveStrip.Enabled = false;
            NavigationMenu.DeleteStrip.Enabled = false;
            tsBaseBtn_New.Enabled = false;
            tsBaseBtn_Save.Enabled = false;
            tsBaseBtn_Delete.Enabled = false;
        }

        public override void Info()
        {
            var model = CurrentModel as ShipmentModel;

            if (model != null)
            {
                info.CreatedPc = model.CreatedPc;
                info.ModifiedPc = model.ModifiedPc;
            }

            base.Info();
        }
    }
}
