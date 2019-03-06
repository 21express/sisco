using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.Data;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPrinting.Native;
using SISCO.App.MasterData;
using SISCO.App.Operation;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Interfaces;
using SISCO.Presentation.CustomerService.Popup;
using SISCO.Presentation.MasterData.Popup;
using System.Collections.Generic;

namespace SISCO.Presentation.CustomerService.Forms
{
    public partial class TrackingByShipmentForm : BaseCrudForm<ShipmentModel, ShipmentDataManager>, IGridChildForm//BaseToolbarForm//
    {
        protected BindingList<ShipmentStatusDataRow> Statuses { get; set; }
        public BranchDataManager BranchDataManager { get; set; }
        public TrackingStatusDataManager TrackingStatusDataManager { get; set; }
        protected List<int> DeletedStatus;

        protected class ShipmentStatusDataRow : ShipmentStatusModel
        {
            public BranchDataManager BranchDataManager { get; set; }

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

            public DateTime StatusDate { get { return DateProcess; } }
            public string StatusTime { get { return DateProcess.ToString("HH:mm"); } }
            public new string TrackingStatus { get; set; }
            public new bool IsFinalStatus { get; set; }
            public bool NewRow { get; set; }
        }

        public TrackingByShipmentForm()
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

            lkpBranch.LookupPopup = new BranchPopup();
            lkpBranch.AutoCompleteDataManager = new BranchDataManager();
            lkpBranch.AutoCompleteDisplayFormater = model => ((BranchModel)model).Code + " - " + ((BranchModel)model).Name;
            lkpBranch.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("code = @0 OR name.StartsWith(@0)", s);
            lkpBranch.DefaultValue = new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "id") };
            lkpBranch.FieldLabel = "Branch";
            lkpBranch.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            txtDateAdd.FieldLabel = "Branch";
            txtDateAdd.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            txtTimeAdd.FieldLabel = "Time";
            txtTimeAdd.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };
            
            BranchDataManager = new BranchDataManager();
            TrackingStatusDataManager = new TrackingStatusDataManager();
            Statuses = new BindingList<ShipmentStatusDataRow>();

            btnAddStatus.Click += (o, args) => btnAddStatus_Click();
            cmbShipmentStatus.SelectedIndexChanged += (o, args) =>
            {
                txtMissDeliveryReason.Enabled = cmbShipmentStatus.Text.ToLower().Equals("miss-delivery");
                if (!cmbShipmentStatus.Text.ToLower().Equals("miss-delivery"))
                {
                    txtMissDeliveryReason.Clear();
                }
            };

            var focus = false;

            btnAddStatus.PreviewKeyDown += (ond, args) =>
            {
                base.OnPreviewKeyDown(args);

                if (args.KeyCode == Keys.Up)
                    txtNote.Focus();
                if (args.KeyCode == Keys.Down)
                {
                    focus = true;
                }
            };

            cmbShipmentStatus.GotFocus += (o, args) =>
            {
                if (focus) tsBaseTxt_Code.Focus();
                focus = false;
            };

            gridView.CustomRowFilter += (o, args) =>
            {
                if (!Statuses[args.ListSourceRow].IsFinalStatus)
                {
                    args.Visible = false;
                    args.Handled = true;
                }
            };

            tsBaseTxt_Code.KeyDown += SearchBarcodeCursor;
            grid.DataSource = Statuses;

            gridView.SortInfo.ClearAndAddRange(new[] { 
                  new GridColumnSortInfo(gridView.Columns["StatusDate"], ColumnSortOrder.Descending),
                  new GridColumnSortInfo(gridView.Columns["StatusTime"], ColumnSortOrder.Descending)
            });

            using (var trackingStatusDm = new TrackingStatusDataManager())
            {
                var trackingStatuses =
                    trackingStatusDm.Get<TrackingStatusModel>(new IListParameter[]
                    {
                        WhereTerm.Default(true, "is_final_status"),
                        WhereTerm.Default(12, "id", EnumSqlOperator.NotEqual)
                    }).ToList();

                trackingStatuses.Insert(0, new TrackingStatusModel
                {
                    Id = 0,
                    Code = ""
                });

                cmbShipmentStatus.DataSource = trackingStatuses;
            }
            cmbShipmentStatus.ValueMember = "Id";
            cmbShipmentStatus.DisplayMember = "Code";

            txtDateAdd.DateTime = DateTime.Now;
            txtTimeAdd.Time = DateTime.Now;

            txtMissDeliveryReason.Enabled = false;
        }

        private void SearchBarcodeCursor(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                case Keys.Up:
                    btnAddStatus.Focus();
                    break;
                case Keys.Left:
                case Keys.Down:
                    cmbShipmentStatus.Focus();
                    break;
            }
        }

        private void btnAddStatus_Click()
        {
            if (lkpBranch.Value == null)
            {
                lkpBranch.Focus();
                MessageBox.Show(@"Please choose a base branch!");
                return;
            }
            if ((int)cmbShipmentStatus.SelectedValue == 0)
            {
                cmbShipmentStatus.Focus();
                MessageBox.Show(@"Harus pilih status POD!");
                return;
            }
            if (cmbShipmentStatus.Text.ToUpper().Equals("RECEIVED") && Statuses.Any(r => r.TrackingStatus.ToUpper().Equals("RECEIVED")))
            {
                cmbShipmentStatus.Focus();
                MessageBox.Show(@"Tidak bisa ada status RECEIVED lebih dari sekali!");
                return;
            }
            if (string.IsNullOrEmpty(txtDateAdd.Text))
            {
                txtDateAdd.Focus();
                MessageBox.Show(@"Tanggal harus diisi!");
                return;
            }
            if (txtDateAdd.DateTime.Date < ((ShipmentModel)CurrentModel).DateProcess.Date)
            {
                txtDateAdd.Focus();
                MessageBox.Show(@"Tanggal status harus sama atau lebih besar dari tanggal CN!");
                return;
            }
            if (cmbShipmentStatus.Text.ToUpper().Equals("RECEIVED") && string.IsNullOrEmpty(txtBy.Text))
            {
                txtBy.Focus();
                MessageBox.Show(@"Nama penerima harus diisi!");
                return;
            }

            Statuses.Add(new ShipmentStatusDataRow
            {
                BranchDataManager = BranchDataManager,
                TrackingStatus = cmbShipmentStatus.Text,
                IsFinalStatus = true,

                Id = 0,
                ShipmentId = CurrentModel.Id,
                DateProcess = DateTime.Parse(txtDateAdd.DateTime.ToString("yyyy-MM-dd") + " " + txtTimeAdd.Text),
                TrackingStatusId = (int)cmbShipmentStatus.SelectedValue,
                MissDeliveryReason = txtMissDeliveryReason.Text,
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
                NewRow = true
            });

            gridView.RefreshData();

            txtDateAdd.DateTime = DateTime.Now;
            txtTimeAdd.Time = DateTime.Now;

            if (((ShipmentModel)CurrentModel).TrackingStatusId != (int)EnumTrackingStatus.Received)
            {
                ((ShipmentModel)CurrentModel).TrackingStatusId = (int)cmbShipmentStatus.SelectedValue;
                ((ShipmentModel)CurrentModel).TrackingStatus = cmbShipmentStatus.Text;
            }

            Save();

            tsBaseTxt_Code.SelectAll();
            tsBaseTxt_Code.Focus();
        }

        protected override void PopulateForm(ShipmentModel model)
        {
            txtDate.Text = model.DateProcess.ToString("dd-MM-yyyy");
            txtShipmentNo.Text = model.Code;
            txtOrigin.Text = model.CityName;
            txtDestination.Text = model.DestCity;

            DeletedStatus = new List<int>();

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

            txtShipperName.Text = model.ShipperName;
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

            _SetControlEnableState(pnlShipmentInformation,false);
            _SetControlEnableState(pnlShipperInformation, false);
            _SetControlEnableState(pnlConsigneeInformation, false);
            _SetControlEnableState(pnlOtherInformation, false);

            txtMissDeliveryReason.Enabled = cmbShipmentStatus.Text.ToLower().Equals("miss-delivery");

            Statuses.RaiseListChangedEvents = false;

            Statuses.Clear();

            new ShipmentStatusDataManager().
                Get<ShipmentStatusModel>(WhereTerm.Default(model.Id, "shipment_id")).
                Select(row => new ShipmentStatusDataRow
                {
                    BranchDataManager = BranchDataManager,

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
                .ForEach(row =>
                {
                    var r = TrackingStatusDataManager.GetFirst<TrackingStatusModel>(WhereTerm.Default(row.TrackingStatusId, "id"));

                    row.IsFinalStatus = r.IsFinalStatus;
                    row.TrackingStatus = string.Format("{0}", r.Code);
                    row.NewRow = false;

                    Statuses.Add(row);
                });

            Statuses.RaiseListChangedEvents = true;
            Statuses.ResetBindings();

            //txtDateAdd.DateTime = DateTime.Now;
            //txtTimeAdd.Text = DateTime.Now.ToString("HH:mm");

            tsBaseTxt_Code.Text = model.Code;
            cmbShipmentStatus.Focus();
        }

        protected override ShipmentModel PopulateModel(ShipmentModel model)
        {
            return model;
        }

        protected override ShipmentModel Find(string searchTerm)
        {
            return DataManager.GetFirst<ShipmentModel>(WhereTerm.Default(searchTerm, "Code"));
        }

        protected override void SaveDetail(bool isUpdate = false)
        {
            new ShipmentStatusDataManager().Save(CurrentModel.Id, Statuses.Where(r => r.NewRow).ToList());

            if (DeletedStatus.Count > 0)
            {
                foreach (int id in DeletedStatus)
                {
                    new ShipmentStatusDataManager().DeActive(id, BaseControl.UserLogin, DateTime.Now);
                }
            }
        }

        protected override void AfterSave()
        {
            _ClearForm(pnlConsigneeInformation);
            _ClearForm(pnlOtherInformation);
            _ClearForm(pnlShipmentInformation);
            _ClearForm(pnlShipperInformation);

            Statuses.RaiseListChangedEvents = false;
            Statuses.Clear();
            Statuses.RaiseListChangedEvents = true;
            Statuses.ResetBindings();

            tsBaseTxt_Code.Focus();
        }

        protected override void RefreshToolbarState()
        {
            base.RefreshToolbarState();

            NavigationMenu.NewStrip.Enabled = false;
            NavigationMenu.DeleteStrip.Enabled = false;
            tsBaseBtn_New.Enabled = false;
            tsBaseBtn_Delete.Enabled = false;
        }

        public void DetailNew()
        {
            cmbShipmentStatus.Focus();
        }

        public void DetailDelete()
        {
            if (gridView.FocusedRowHandle < 0)
            {
                MessageBox.Show(@"No detail item selected", @"Delete Detail Item", MessageBoxButtons.OK);
                return;
            }

            int item = Convert.ToInt32(gridView.GetRowCellValue(gridView.FocusedRowHandle, gridView.Columns["Id"]));
            if (item > 0) DeletedStatus.Add(item);

            gridView.DeleteSelectedRows();
        }
    }
}