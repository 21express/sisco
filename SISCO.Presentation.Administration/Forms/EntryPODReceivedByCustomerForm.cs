using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraReports.Parameters;
using SISCO.App.Administration;
using SISCO.App.MasterData;
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
    public partial class EntryPODReceivedByCustomerForm : BaseCrudForm<PodCustomerModel, PodCustomerDataManager>, IGridChildForm//BaseToolbarForm//
    {
        protected BindingList<PodCustomerShipmentDataRow> Shipments { get; set; }
        public BranchDataManager BranchDataManager { get; set; }
        public ShipmentDataManager ShipmentDataManager { get; set; }

        public class PodCustomerShipmentDataRow : PodCustomerShipmentModel, INotifyPropertyChanged
        {
            public BranchDataManager BranchDataManager { get; set; }
            public ShipmentDataManager ShipmentDataManager { get; set; }

            private ShipmentModel _shipment;
            public ShipmentModel Shipment
            {
                get
                {
                    if (_shipment == null)
                    {
                        _shipment = ShipmentDataManager.GetFirst<ShipmentModel>(WhereTerm.Default(ShipmentId, "id"));
                    }

                    return _shipment;
                }
            }

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

            public string ConsigneeName
            {
                get { return (Shipment != null) ? Shipment.ConsigneeName : ""; }
            }
            public string DestCity
            {
                get { return Shipment.DestCity; }
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

        public EntryPODReceivedByCustomerForm()
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
            txtDate.ValidationRules = new[] {new ComponentValidationRule(EnumComponentValidationRule.Mandatory)};

            lkpCustomer.LookupPopup = new CustomerPopup(WhereTerm.Default(BaseControl.BranchId, "branch_id"));
            lkpCustomer.AutoCompleteDataManager = new CustomerDataManager();
            lkpCustomer.AutoCompleteDisplayFormater = model =>
            {
                var c = model as CustomerModel;
                return string.Format("{0} - {1}", c.Code, c.Name);
            };
            lkpCustomer.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND branch_id = @1", s, BaseControl.BranchId);
            lkpCustomer.FieldLabel = "Customer";
            lkpCustomer.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            BranchDataManager = new BranchDataManager();
            ShipmentDataManager = new ShipmentDataManager();
            Shipments = new BindingList<PodCustomerShipmentDataRow>();

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

            tsBaseBtn_Print.Click += (o, args) =>
            {
                var printout = new TandaTerimaPodKirimCustomerPrintOut
                {
                    DataSource = Shipments,
                    Parameters =
                    {
                        new Parameter
                        {
                            Name = "DatePrint",
                            Value = DateTime.Now
                        }
                    }
                };

                printout.Parameters.AddRange(GetPrintoutParameters());
                printout.Print();
            };
            tsBaseBtn_PrintPreview.Click += (o, args) =>
            {
                var printout = new TandaTerimaPodKirimCustomerPrintOut
                {
                    DataSource = Shipments,
                    Parameters =
                    {
                        new Parameter
                        {
                            Name = "DatePrint",
                            Value = DateTime.Now
                        }
                    }
                };

                printout.Parameters.AddRange(GetPrintoutParameters());
                printout.PrintPreview();
            };

            SearchPopup = new PodCustomerPopup();
        }

        private Parameter[] GetPrintoutParameters()
        {
            using (var customerDm = new CustomerDataManager())
            {
                var customer =
                    customerDm.GetFirst<CustomerModel>(WhereTerm.Default(((PodCustomerModel) CurrentModel).CustomerId,
                        "id"));
                if (customer != null)
                {
                    return new[]
                    {
                        new Parameter
                        {
                            Name = "DateProcess",
                            Value = ((PodCustomerModel) CurrentModel).Vdate
                        },
                        new Parameter
                        {
                            Name = "Code",
                            Value = ((PodCustomerModel) CurrentModel).Code
                        },
                        new Parameter
                        {
                            Name = "CustomerCode",
                            Value = customer.Code
                        },
                        new Parameter
                        {
                            Name = "CustomerName",
                            Value = ((PodCustomerModel) CurrentModel).CustomerName
                        },
                        new Parameter
                        {
                            Name = "Address",
                            Value = customer.Address
                        },
                        new Parameter
                        {
                            Name = "ContactPerson",
                            Value = customer.Contact
                        }
                    };
                }
            }

            return null;
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

            var shipmentStatus = ShipmentDataManager.GetFinalShipmentStatusOfShipment(shipmentModel.Id);
            if (shipmentStatus == null)
            {
                MessageBox.Show(@"POD belum punya final status!");
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

            var podInShipmentModel = new PodInShipmentDataManager().GetFirst<PodInShipmentModel>(WhereTerm.Default(shipmentModel.Id, "shipment_id"));

            if (shipmentModel.CustomerId != lkpCustomer.Value)
            {
                MessageBox.Show(@"Wrong customer!");
                txtAddShipmentNo.Focus();
                txtAddShipmentNo.SelectAll();
                return;
            }

            Shipments.Add(new PodCustomerShipmentDataRow
            {
                BranchDataManager = BranchDataManager,
                ShipmentDataManager = ShipmentDataManager,

                PodCustomerId = CurrentModel.Id,
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
                SuratJalan = (podInShipmentModel != null && podInShipmentModel.SuratJalan != null ? podInShipmentModel.SuratJalan : ""),

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
            if (lkpCustomer.Value == null)
            {
                MessageBox.Show(@"Please select a customer", @"Warning", MessageBoxButtons.OK);
                return false;
            }

            return true;
        }

        protected override void PopulateForm(PodCustomerModel model)
        {
            tsBaseTxt_Code.Text = model.Code;
            txtDate.DateTime = model.Vdate;
            lkpCustomer.DefaultValue = new IListParameter[] {WhereTerm.Default(model.CustomerId, "id")};

            Shipments.RaiseListChangedEvents = false;

            Shipments.Clear();

            new PodCustomerShipmentDataManager().
                Get<PodCustomerShipmentModel>(WhereTerm.Default(model.Id, "pod_customer_id")).
                Select(row => new PodCustomerShipmentDataRow
                {
                    BranchDataManager = BranchDataManager,
                    ShipmentDataManager = ShipmentDataManager,

                    Id = row.Id,
                    PodCustomerId = row.PodCustomerId,
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
        }

        protected override PodCustomerModel PopulateModel(PodCustomerModel model)
        {
            model.Vdate = txtDate.DateTime;
            //model.ArchiveLocation = txtArchive.Text;
            if (lkpCustomer.Value != null) model.CustomerId = (int)lkpCustomer.Value;
            model.CustomerName = new CustomerDataManager().GetFirst<CustomerModel>(WhereTerm.Default(model.CustomerId, "Id")).Name;

            return model;
        }

        protected override PodCustomerModel Find(string searchTerm)
        {
            return DataManager.GetFirst<PodCustomerModel>(WhereTerm.Default(searchTerm, "code"), WhereTerm.Default(BaseControl.BranchId, "branch_id"));
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

            CurrentModel = PopulateModel(CurrentModel as PodCustomerModel);

            if (CurrentModel.Id == 0)
            {
                ((PodCustomerModel)CurrentModel).Vtime = DateTime.Now.ToString("HH:mm");
                CurrentModel.Rowstatus = true;
                CurrentModel.Rowversion = DateTime.Now;
                CurrentModel.Createddate = DateTime.Now;
                CurrentModel.Createdby = BaseControl.UserLogin;

                ((PodCustomerDataManager)DataManager).Save<PodCustomerModel>(CurrentModel);
            }
            else
            {
                CurrentModel.Modifieddate = DateTime.Now;
                CurrentModel.Modifiedby = BaseControl.UserLogin;

                ((PodCustomerDataManager)DataManager).Update<PodCustomerModel>(CurrentModel);
            }

            new PodCustomerShipmentDataManager().Save(CurrentModel.Id, Shipments);

            tsBaseTxt_Code.Text = ((PodCustomerModel) CurrentModel).Code;

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
            ClearForm();
            Shipments.Clear();
            txtDate.DateTime = DateTime.Now;

            lkpCustomer.Select();
            lkpCustomer.Focus();

            ((PodCustomerModel)CurrentModel).BranchId = BaseControl.BranchId;
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
