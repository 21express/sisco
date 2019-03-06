using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using SISCO.App.Administration;
using SISCO.App.MasterData;
using SISCO.App.Operation;
using SISCO.Models;
using SISCO.Presentation.Administration.Forms.Popup;
using SISCO.Presentation.Administration.Reports;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Interfaces;
using SISCO.Presentation.Common.Properties;
using SISCO.Presentation.MasterData.Annotations;
using SISCO.Presentation.MasterData.Popup;
using BaseControl = SISCO.Presentation.Common.BaseControl;

namespace SISCO.Presentation.Administration.Forms
{
    public partial class ManageOutgoingPodForm : BaseCrudForm<PodOutModel, PodOutDataManager>, IGridChildForm//BaseToolbarForm//
    {
        protected BindingList<PodOutShipmentDataRow> Shipments { get; set; }
        public BranchDataManager BranchDataManager { get; set; }
        public ShipmentDataManager ShipmentDataManager { get; set; }

        public class PodOutShipmentDataRow : PodOutShipmentModel, INotifyPropertyChanged
        {
            public BranchDataManager BranchDataManager { get; set; }
            public ShipmentDataManager ShipmentDataManager { get; set; }

            private string _branch;
            public string Branch
            {
                get
                {
                    if (string.IsNullOrEmpty(_branch) && BranchId != 0)
                    {
                        var model = BranchDataManager.GetFirst<BranchModel>(WhereTerm.Default(BranchId, "id"));
                        _branch = (model != null) ? string.Format("{0}", model.Code) : "";
                    }

                    return _branch;
                }
                set { _branch = value; }
            }

            private string _status;
            public string Status
            {
                get
                {
                    if (string.IsNullOrEmpty(_status) && ShipmentId != 0)
                    {
                        var model = ShipmentDataManager.GetFinalTrackingStatusOfShipment(ShipmentId);
                        _status = (model != null) ? string.Format("{0}", model.Code) : "";
                    }

                    return _status;
                }
            }

            private string _natureOfGoods;
            public string NatureOfGoods
            {
                get
                {
                    if (_natureOfGoods == null && ShipmentId != 0)
                    {
                        var model = ShipmentDataManager.GetFirst<ShipmentModel>(WhereTerm.Default(ShipmentId, "id"));
                        _natureOfGoods = (model != null) ? string.Format("{0}", model.NatureOfGoods) : "";
                    }

                    return _natureOfGoods;
                }
            }

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
                    case "BranchId":
                        Branch = null;
                        NotifyUpdate("Branch");
                        break;
                }
            }
        }

        public ManageOutgoingPodForm()
        {
            InitializeComponent();

            form = this;
        }

        protected override void BindDataSource<T>()
        {
            CurrentModel = LoadModel<T>(WhereTerm.Default(BaseControl.BranchId, "branch_id"));
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);


            EnableBtnSearch = true;

            txtDate.FieldLabel = "Date";
            txtDate.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            lkpBranch.LookupPopup = new BranchPopup();
            lkpBranch.AutoCompleteDataManager = new BranchDataManager();
            lkpBranch.AutoCompleteDisplayFormater = model => ((BranchModel)model).Code + " - " + ((BranchModel)model).Name;
            lkpBranch.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("code = @0 OR name.StartsWith(@0)", s);

            BranchDataManager = new BranchDataManager();
            ShipmentDataManager = new ShipmentDataManager();
            Shipments = new BindingList<PodOutShipmentDataRow>();

            grid.DataSource = Shipments;

            grid.EmbeddedNavigator.ButtonClick += NavigatorClick;
            btnAdd.Click += (o, args) => btnAdd_Click();
            txtAddShipmentNo.KeyDown += (o, args) =>
            {
                if (args.KeyCode == Keys.Enter)
                {
                    args.Handled = true;
                    btnAdd_Click();
                }
            };

            grid.DoubleClick += (o, args) =>
            {
                var rows = gridView.GetSelectedRows();

                if (rows.Count() > 0)
                {
                    BaseControl.OpenRelatedForm(new CustomerService.Forms.TrackingViewForm(), gridView.GetRowCellValue(rows[0], "ShipmentCode").ToString(), CallingCommand);
                }
            };

            lkpBranch.FieldLabel = "Branch";
            lkpBranch.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };


            tsBaseBtn_Print.Click += (o, args) =>
            {
                var printout = new TandaTerimaPodKirimPrintOut
                {
                    DataSource = Shipments,
                    Parameters =
                    {
                        new Parameter
                        {
                            Name = "DateProcess",
                            Value = ((PodOutModel) CurrentModel).Vdate
                        }
                    }
                };
                printout.Print();
            };
            tsBaseBtn_PrintPreview.Click += (o, args) =>
            {
                var printout = new TandaTerimaPodKirimPrintOut
                {
                    DataSource = Shipments,
                    Parameters =
                    {
                        new Parameter
                        {
                            Name = "DateProcess",
                            Value = ((PodOutModel) CurrentModel).Vdate
                        }
                    }
                };
                printout.PrintPreview();
            };

            SearchPopup = new PodOutPopup();
        }

        protected void btnAdd_Click()
        {
            var shipmentModel = new ShipmentDataManager().GetFirst<ShipmentModel>(WhereTerm.Default(txtAddShipmentNo.Text, "Code"));

            if (shipmentModel == null)
            {
                MessageBox.Show(@"Shipment number not found!");
                txtAddShipmentNo.Focus();
                txtAddShipmentNo.SelectAll();
                return;
            }

            //var deliveryOrderModel = new DeliveryOrderDetailDataManager().GetFirst<DeliveryOrderDetailModel>(WhereTerm.Default(shipmentModel.Id, "shipment_id"));

            //if (deliveryOrderModel == null || deliveryOrderModel.ReceivedDate == null)
            //{
            //    MessageBox.Show(@"POD has not yet been received by the consignee!");
            //    txtAddShipmentNo.Focus();
            //    txtAddShipmentNo.SelectAll();
            //    return;
            //}

            //if (shipmentModel.PodSent == 1)
            //{
            //    MessageBox.Show(@"POD has already been sent to origin branch!");
            //    txtAddShipmentNo.Focus();
            //    txtAddShipmentNo.SelectAll();
            //    return;
            //}

            var shipmentStatus = ShipmentDataManager.GetFinalStatusOfShipmentOutgoingPOD(shipmentModel.Id);
            if (shipmentStatus == null)
            {
                MessageBox.Show(@"POD belum punya final status!");
                txtAddShipmentNo.Focus();
                txtAddShipmentNo.SelectAll();
                return;
            }

            if (shipmentModel.BranchId != lkpBranch.Value)
            {
                MessageBox.Show(@"POD bukan untuk cabang yang dipilih!");
                txtAddShipmentNo.Focus();
                txtAddShipmentNo.SelectAll();
                return;
            }

            if (Shipments.Any(r => r.ShipmentCode == shipmentModel.Code))
            {
                MessageBox.Show(@"POD sudah ada dalam daftar di bawah!");
                txtAddShipmentNo.Focus();
                txtAddShipmentNo.SelectAll();
                return;
            }

            Shipments.Add(new PodOutShipmentDataRow
            {
                BranchDataManager = BranchDataManager,
                ShipmentDataManager = ShipmentDataManager,

                PodOutId = CurrentModel.Id,
                ShipmentId = shipmentModel.Id,
                ShipmentDate = shipmentModel.DateProcess,
                ShipmentCode = shipmentModel.Code,
                BranchId = shipmentModel.BranchId,
                ShipperName = shipmentModel.ShipperName,
                ReceivedCustBy = shipmentStatus.StatusBy,
                ReceivedCustDate = shipmentStatus.DateProcess,
                ReceivedCustTime = shipmentStatus.DateProcess.ToString("HH:mm"),
                Sent = 1,
                Received = 0,
                Returned = 0,
                Note = "",

                Rowstatus = true,
                Rowversion = DateTime.Now,
                Createddate = DateTime.Now,
                Createdby = BaseControl.UserLogin,
            });

            txtAddShipmentNo.Text = "";
            txtAddShipmentNo.Focus();

            int value = gridView.RowCount - 1;
            gridView.TopRowIndex = value;
            gridView.FocusedRowHandle = value; 
        }

        protected override bool ValidateForm()
        {
            if (lkpBranch.Value == null)
            {
                MessageBox.Show(@"Please select a branch!");
                return false;
            }

            return true;
        }

        protected override void PopulateForm(PodOutModel model)
        {
            tsBaseTxt_Code.Text = model.Code;
            txtDate.DateTime = model.Vdate;
            lkpBranch.DefaultValue = new IListParameter[] {WhereTerm.Default(model.DestBranchId ?? 0, "id")};
            //txtArchive.Text = model.ArchiveLocation;

            Shipments.RaiseListChangedEvents = false;

            Shipments.Clear();

            new PodOutShipmentDataManager().
                Get<PodOutShipmentModel>(WhereTerm.Default(model.Id, "pod_out_id")).
                Select(row => new PodOutShipmentDataRow
                {
                    BranchDataManager = BranchDataManager,
                    ShipmentDataManager = ShipmentDataManager,

                    Id = row.Id,
                    PodOutId = row.PodOutId,
                    ShipmentId = row.ShipmentId,
                    ShipmentDate = row.ShipmentDate,
                    ShipmentCode = row.ShipmentCode,
                    BranchId = row.BranchId,
                    ShipperName = row.ShipperName,
                    ReceivedCustBy = row.ReceivedCustBy,
                    ReceivedCustDate = row.ReceivedCustDate,
                    ReceivedCustTime = row.ReceivedCustTime,
                    Sent = row.Sent,
                    Received = row.Received,
                    Returned = row.Returned,
                    Note = row.Note,
                    SuratJalan = row.SuratJalan,
                    Rowstatus = row.Rowstatus,
                    Rowversion = row.Rowversion,
                    Createddate = row.Createddate,
                    Createdby = row.Createdby,
                    Modifieddate = row.Modifieddate,
                    Modifiedby = row.Modifiedby,
                })
                .OrderBy(row => row.Createddate)
                .ForEach(row => Shipments.Add(row));

            Shipments.RaiseListChangedEvents = true;
            Shipments.ResetBindings();

            txtDate.Enabled = false;
            lkpBranch.Enabled = false;
        }

        protected override PodOutModel PopulateModel(PodOutModel model)
        {
            model.Vdate = txtDate.DateTime;
            //model.ArchiveLocation = txtArchive.Text;
            model.BranchId = BaseControl.BranchId;
            model.DestBranchId = lkpBranch.Value ?? 0;

            return model;
        }

        protected override PodOutModel Find(string searchTerm)
        {
            return DataManager.GetFirst<PodOutModel>(WhereTerm.Default(searchTerm, "code"), WhereTerm.Default(BaseControl.BranchId, "branch_id"));
        }

        public override void Save()
        {
            gridView.PostEditor();

            if (!ValidateForm())
            {
                MessageBox.Show(
                   Resources.alert_empty_field
                   , Resources.title_save_changes
                   , MessageBoxButtons.OK
                   , MessageBoxIcon.Information);

                return;
            }

            CurrentModel = PopulateModel(CurrentModel as PodOutModel);

            if (CurrentModel.Id == 0)
            {
                ((PodOutModel)CurrentModel).Vtime = DateTime.Now.ToString("HH:mm");
                CurrentModel.Rowstatus = true;
                CurrentModel.Rowversion = DateTime.Now;
                CurrentModel.Createddate = DateTime.Now;
                CurrentModel.Createdby = BaseControl.UserLogin;

                ((PodOutDataManager)DataManager).Save<PodOutModel>(CurrentModel);
            }
            else
            {
                CurrentModel.Modifieddate = DateTime.Now;
                CurrentModel.Modifiedby = BaseControl.UserLogin;

                ((PodOutDataManager)DataManager).Update<PodOutModel>(CurrentModel);
            }

            new PodOutShipmentDataManager().Save(CurrentModel.Id, Shipments);

            txtDate.Enabled = false;
            lkpBranch.Enabled = false;

            tsBaseTxt_Code.Text = ((PodOutModel)CurrentModel).Code;

            TotalPage = 1;
            StateChange = EnumStateChange.Update;

            RefreshToolbarState();

            AfterSave();
            Buttons();
        }

        protected void NavigatorClick(object sender, NavigatorButtonClickEventArgs args)
        {
            args.Handled = true;

            switch (args.Button.ButtonType)
            {
                case NavigatorButtonType.Remove:
                    DetailDelete();
                    break;
                default:
                    args.Handled = false;
                    break;
            }
        }

        public void DetailNew()
        {
            //
        }

        public void DetailDelete()
        {
            if (gridView.FocusedRowHandle < 0)
            {
                MessageBox.Show(@"No detail item selected", @"Delete Detail Item", MessageBoxButtons.OK);
                return;
            }

            Shipments.RemoveAt(gridView.FocusedRowHandle);
        }

        protected override void BeforeNew()
        {
            base.BeforeNew();

            ClearForm();
            Shipments.Clear();

            txtDate.DateTime = DateTime.Now;

            txtDate.Enabled = true;
            lkpBranch.Enabled = true;

            txtDate.Select();
            txtDate.Focus();
        }

        protected override void RefreshToolbarState()
        {
            base.RefreshToolbarState();

            if (TotalPage > 0)
            {
                tsBaseBtn_Print.Enabled = true;
                tsBaseBtn_PrintPreview.Enabled = true;
            }
        }
    }
}