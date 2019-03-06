using System;
using System.ComponentModel;
using System.Linq;
using Corporate.Presentation.Common.Forms;
using Corporate.Presentation.DataEntry.Popup;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.Utils;
using DevExpress.XtraBars;
using Corporate.Presentation.Common;
using DevExpress.XtraPrinting.Native;
using SISCO.App.MasterData;
using SISCO.App.Operation;
using SISCO.Models;
using SISCO.Presentation.MasterData.Annotations;

namespace Corporate.Presentation.CustomerService.Forms
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

            DataManager.DefaultParameters = new IListParameter[]
            {
                WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals),
                WhereTerm.Default(1,"sales_type_id", EnumSqlOperator.Equals),
                WhereTerm.Default(BaseControl.CorporateId, "customer_id", EnumSqlOperator.Equals)
            };
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

            gridColumn2.DisplayFormat.FormatType = FormatType.DateTime;
            gridColumn2.DisplayFormat.FormatString = "dd-MM-yyyy";

            btnExport.Click += (o, args) => ExportGridToExcel(gridView, string.Format("CustomerService_TrackingView_{0}", ((ShipmentModel)CurrentModel).Code));

            rbLayout_Print.Visibility = BarItemVisibility.Never;
            rbLayout_PrintPreview.Visibility = BarItemVisibility.Never;
        }

        private void RefreshGrid()
        {
            Statuses.RaiseListChangedEvents = false;
            Statuses.Clear();

            new ShipmentStatusDataManager().
                Get<ShipmentStatusModel>(WhereTerm.Default(CurrentModel.Id, "shipment_id")).
                OrderByDescending(row => row.DateProcess).
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
                    StatusNote = row.StatusNote,
                    Reference = row.Reference,
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
        }

        protected override void PopulateForm(ShipmentModel model)
        {
            tbxSearch_Code.Text = model.Code;

            tbxDate.Text = model.DateProcess.ToString("dd-MM-yyyy");
            tbxOrigin.Text = model.CityName;
            tbxDestination.Text = model.DestCity;

            using (var customerDataManager = new CustomerDataManager())
            {
                var i =
                    customerDataManager.GetFirst<CustomerModel>(WhereTerm.Default(model.CustomerId ?? 0, "id",
                        EnumSqlOperator.Equals));
                tbxCustomerCode.Text = (i != null) ? i.Code : "";
            }

            tbxCustomer.Text = model.CustomerName;

            tbxName.Text = model.ShipperName;
            tbxAddress.Text = model.ShipperAddress;
            tbxPhone.Text = model.ShipperPhone;

            tbxConsigneeName.Text = model.ConsigneeName;
            tbxConsigneeAddress.Text = model.ConsigneeAddress;
            tbxConsigneePhone.Text = model.ConsigneePhone;

            using (var packageTypeDataManager = new PackageTypeDataManager())
            {
                var i = packageTypeDataManager.GetFirst<PackageTypeModel>(WhereTerm.Default(model.PackageTypeId, "id", EnumSqlOperator.Equals));
                tbxPackage.Text = (i != null) ? i.Name : "";
            }

            using (var serviceTypeDataManager = new ServiceTypeDataManager())
            {
                var i = serviceTypeDataManager.GetFirst<ServiceTypeModel>(WhereTerm.Default(model.ServiceTypeId, "id", EnumSqlOperator.Equals));
                tbxService.Text = (i != null) ? i.Name : "";
            }

            using (var paymentMethodDataManager = new PaymentMethodDataManager())
            {
                var i =
                    paymentMethodDataManager.GetFirst<PaymentMethodModel>(WhereTerm.Default(model.PaymentMethodId, "id",
                        EnumSqlOperator.Equals));
                tbxPayment.Text = (i != null) ? i.Name : "";
            }
            tbxNatureOfGood.Text = model.NatureOfGoods;

            tbxTtlPiece.Value = model.TtlPiece;
            tbxTtlWeight.Value = model.TtlGrossWeight;
            tbxTtlChargeable.Value = model.TtlChargeableWeight;

            tbxDate.Enabled = false;
            tbxOrigin.Enabled = false;
            tbxDestination.Enabled = false;

            tbxTtlPiece.Enabled = false;
            tbxTtlWeight.Enabled = false;
            tbxTtlChargeable.Enabled = false;

            _SetControlEnableState(pnlShipperInformation, false);
            _SetControlEnableState(pnlConsigneeInformation, false);
            _SetControlEnableState(pnlOtherInformation, false);

            rbData_New.Enabled = false;
            rbData_Save.Enabled = false;
            rbData_Delete.Enabled = false;

            RefreshGrid();
            tbxSearch_Code.Focus();
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