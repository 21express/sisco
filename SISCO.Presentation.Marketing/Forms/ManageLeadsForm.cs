using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting.Native;
using SISCO.App.Marketing;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Interfaces;
using SISCO.Presentation.MasterData.Annotations;
using SISCO.Presentation.MasterData.Popup;
using BaseControl = SISCO.Presentation.Common.BaseControl;

namespace SISCO.Presentation.Marketing.Forms
{
    public partial class ManageLeadsForm : BaseMasterForm<SalesLeadModel, ManageLeadsForm.SalesLeadDataRow, SalesLeadDataManager>, IGridChildForm
    {
        public class SalesLeadDataRow : SalesLeadModel, INotifyPropertyChanged
        {
            public EmployeeDataManager EmployeeDataManager { get; set; }
            public ContactDataManager ContactDataManager { get; set; }
            public CustomerDataManager CustomerDataManager { get; set; }
            public SalesLeadStatusDataManager SalesLeadStatusDataManager { get; set; }

            private string _marketing;
            public string Marketing
            {
                get
                {
                    if (string.IsNullOrEmpty(_marketing) && MarketingId != 0)
                    {
                        var model = EmployeeDataManager.GetFirst<EmployeeModel>(WhereTerm.Default(MarketingId, "id"));
                        _marketing = model != null ? string.Format("{0} - {1}", model.Code, model.Name) : "";
                    }
                    return _marketing;
                }
                set { _marketing = value; }
            }

            private string _lastLeadStatus;
            public string LastLeadStatus
            {
                get
                {
                    if (string.IsNullOrEmpty(_lastLeadStatus) && LastLeadStatusId != 0)
                    {
                        var model = SalesLeadStatusDataManager.GetFirst<SalesLeadStatusModel>(WhereTerm.Default(LastLeadStatusId, "id"));
                        _lastLeadStatus = model != null ? string.Format("{0}", model.Name) : "";
                    }
                    return _lastLeadStatus;
                }
                set { _lastLeadStatus = value; }
            }

            private string _company;
            public string Company
            {
                get
                {
                    if (string.IsNullOrEmpty(_company) && ContactId != null && ContactId != 0)
                    {
                        var model = ContactDataManager.GetFirst<ContactModel>(WhereTerm.Default((int) ContactId, "id"));
                        _company = model != null ? string.Format("{0}", model.CompanyName) : "";
                    }
                    else if (string.IsNullOrEmpty(_company) && CustomerId != null && CustomerId != 0)
                    {
                        var model = CustomerDataManager.GetFirst<CustomerModel>(WhereTerm.Default((int)CustomerId, "id"));
                        _company = model != null ? string.Format("{0}", model.Name) : "";
                    }
                    return _company;
                }
                set { _company = value; }
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
                    case "LastLeadStatusId":
                        LastLeadStatus = null;
                        NotifyUpdate("LastLeadStatus");
                        break;
                    case "MarketingId":
                        Marketing = null;
                        NotifyUpdate("Marketing");
                        break;
                    case "CustomerId":
                        Company = null;
                        NotifyUpdate("Company");
                        break;
                    case "ContactId":
                        Company = null;
                        NotifyUpdate("Company");
                        break;
                }
            }
        }

        public class SalesLeadFollowUpDataRow : SalesLeadFollowUpModel, INotifyPropertyChanged
        {
            public EmployeeDataManager EmployeeDataManager { get; set; }

            public bool Temporary { get; set; }
            
            private string _marketing;
            public string Marketing
            {
                get
                {
                    if (string.IsNullOrEmpty(_marketing) && EmployeeId != 0)
                    {
                        var model = EmployeeDataManager.GetFirst<EmployeeModel>(WhereTerm.Default(EmployeeId, "id"));
                        _marketing = model != null ? string.Format("{0} - {1}", model.Code, model.Name) : "";
                    }
                    return _marketing;
                }
                set { _marketing = value; }
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
                    case "EmployeeId":
                        Marketing = null;
                        NotifyUpdate("Marketing");
                        break;
                }
            }
        }

        public EmployeeDataManager EmployeeDataManager { get; set; }
        public BranchDataManager BranchDataManager { get; set; }
        public SalesLeadStatusDataManager SalesLeadStatusDataManager { get; set; }
        public ContactDataManager ContactDataManager { get; set; }
        public CustomerDataManager CustomerDataManager { get; set; }

        public BindingList<SalesLeadFollowUpDataRow> FollowUps;

        public ManageLeadsForm()
        {
            InitializeComponent();
            form = this;

            BranchDataManager = new BranchDataManager();
            EmployeeDataManager = new EmployeeDataManager();
            SalesLeadStatusDataManager = new SalesLeadStatusDataManager();
            ContactDataManager = new ContactDataManager();
            CustomerDataManager = new CustomerDataManager();

            MainModelTransformFunc = model =>
            {
                var row = ConvertModel<SalesLeadModel, SalesLeadDataRow>(model);

                row.EmployeeDataManager = EmployeeDataManager;
                row.SalesLeadStatusDataManager = SalesLeadStatusDataManager;

                row.ContactDataManager = ContactDataManager;
                row.CustomerDataManager = CustomerDataManager;

                return row;
            };

            
            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            Init();
        }

        public override void Init()
        {
            CtlClearButton = null;
            //CtlDeleteButton = btnDelete;
            CtlGridControl = grid;
            CtlGridView = gridView;
            CtlNewButton = btnNewLead;
            CtlPanelDetail = grpDetail;
            CtlSaveButton = btnSave;
            CtlSearchButton = btnSearch;

            base.Init();
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            ValidateOnSearch = false;

            lkpFilterCustomer.LookupPopup = new CustomerPopup(WhereTerm.Default(BaseControl.BranchId, "branch_id"));
            lkpFilterCustomer.AutoCompleteDataManager = new CustomerDataManager();
            lkpFilterCustomer.AutoCompleteDisplayFormater = model => ((CustomerModel)model).Code + " - " + ((CustomerModel)model).Name;
            lkpFilterCustomer.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND branch_id = @1", s, BaseControl.BranchId);

            lkpFilterContact.LookupPopup = new ContactPopup();
            lkpFilterContact.AutoCompleteDataManager = new ContactDataManager();
            lkpFilterContact.AutoCompleteDisplayFormater = model => ((ContactModel)model).CompanyName;
            lkpFilterContact.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "company_name", EnumSqlOperator.BeginWith),
                WhereTerm.Default(BaseControl.BranchId, "branch_id")
            };

            lkpFilterMarketing.LookupPopup = new EmployeePopup(EmployeeModel.EmployeeType.Marketing, WhereTerm.Default(BaseControl.BranchId, "branch_id"));
            lkpFilterMarketing.AutoCompleteDataManager = new EmployeeDataManager();
            lkpFilterMarketing.AutoCompleteDisplayFormater = model => ((EmployeeModel)model).Code + " - " + ((EmployeeModel)model).Name;
            lkpFilterMarketing.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND as_marketing AND branch_id = @1", s, BaseControl.BranchId);

            lkpCustomer.LookupPopup = new CustomerPopup(WhereTerm.Default(BaseControl.BranchId, "branch_id"));
            lkpCustomer.AutoCompleteDataManager = new CustomerDataManager();
            lkpCustomer.AutoCompleteDisplayFormater = model => ((CustomerModel)model).Code + " - " + ((CustomerModel)model).Name;
            lkpCustomer.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND branch_id = @1", s, BaseControl.BranchId);

            lkpContact.LookupPopup = new ContactPopup();
            lkpContact.AutoCompleteDataManager = new ContactDataManager();
            lkpContact.AutoCompleteDisplayFormater = model => ((ContactModel)model).CompanyName;
            lkpContact.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "company_name", EnumSqlOperator.BeginWith),
                WhereTerm.Default(BaseControl.BranchId, "branch_id")
            };

            lkpMarketing.LookupPopup = new EmployeePopup(EmployeeModel.EmployeeType.Marketing, WhereTerm.Default(BaseControl.BranchId, "branch_id"));
            lkpMarketing.AutoCompleteDataManager = new EmployeeDataManager();
            lkpMarketing.AutoCompleteDisplayFormater = model => ((EmployeeModel)model).Code + " - " + ((EmployeeModel)model).Name;
            lkpMarketing.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND as_marketing AND branch_id = @1", s, BaseControl.BranchId);

            gridFollowUp.EmbeddedNavigator.ButtonClick += (o, args) =>
            {
                args.Handled = true;

                switch (args.Button.ButtonType)
                {
                    case NavigatorButtonType.Remove:
                        DetailDelete();
                        break;
                    case NavigatorButtonType.Append:
                        DetailNew();
                        break;
                    default:
                        args.Handled = false;
                        break;
                }
            };

            gridView.FocusRectStyle = DrawFocusRectStyle.RowFocus;
            gridView.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView.Appearance.FocusedCell.Options.UseForeColor = false;
            gridView.OptionsNavigation.UseTabKey = false;
            gridView.OptionsBehavior.FocusLeaveOnTab = true;

            gridView.RowCellStyle += (o, args) =>
            {
                if (args.RowHandle < 0) return;

                if (((int)gridView.GetRowCellValue(args.RowHandle, "LastLeadStatusId")) == 1)
                {
                    args.Appearance.ForeColor = Color.Red;
                }
            };

            gridFollowUpView.ShowingEditor += (o, args) =>
            {
                if (FollowUps[gridFollowUpView.FocusedRowHandle].Temporary == false)
                {
                    args.Cancel = true;
                    MessageBox.Show(@"Already saved follow up records cannot be edited");
                }
            };

            gridFollowUpView.ValidateRow += (s, args) =>
            {
                args.Valid = true;

                if (((SalesLeadFollowUpModel)args.Row).Note == string.Empty)
                {
                    args.Valid = false;
                    args.ErrorText = "Please enter some note for the follow up";
                }
            };

            lkpCustomer.TextChanged += (o, args) =>
            {
                if (_isPopulatingForm) return;

                using (var customerDataManager = new CustomerDataManager())
                {
                    var customer = customerDataManager.GetFirst<CustomerModel>(WhereTerm.Default(lkpCustomer.Value ?? 0, "id"));
                    if (customer != null)
                    {
                        txtContactEmail.Text = customer.Email;
                        txtContactPerson.Text = customer.Contact;
                        txtContactPhone.Text = customer.Phone;
                    }
                }
            };

            rdoIsContact.Click += RdoIsContactOnClick;
            rdoIsRegisteredCustomer.Click += RdoIsContactOnClick;

            lookUpFollowUpStatusRepo.TextEditStyle = TextEditStyles.DisableTextEditor;
            lookUpFollowUpStatusRepo.DataSource = SalesLeadStatusDataManager.Get<SalesLeadStatusModel>();
            lookUpFollowUpStatusRepo.DisplayMember = "Name";
            lookUpFollowUpStatusRepo.ValueMember = "Id";
            lookUpFollowUpStatusRepo.Columns.Add(new LookUpColumnInfo("Name"));

            txtLeadDate.FieldLabel = "Lead Date";
            txtLeadDate.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            lkpCustomer.FieldLabel = "Customer";
            lkpCustomer.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            lkpContact.FieldLabel = "Contact";
            lkpContact.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            lkpMarketing.FieldLabel = "Marketing";
            lkpMarketing.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            txtNote.FieldLabel = "Note";
            txtNote.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            FollowUps = new BindingList<SalesLeadFollowUpDataRow>();
            gridFollowUp.DataSource = FollowUps;
        }

        private void RdoIsContactOnClick(object sender, EventArgs eventArgs)
        {
            lkpCustomer.Enabled = rdoIsRegisteredCustomer.Checked;
            lkpContact.Enabled = rdoIsContact.Checked;
        }

        protected override bool ValidateForm()
        {
            return true;
        }

        protected override bool ValidateFormWithAlert()
        {
            if (txtLeadDate.Text == string.Empty)
            {
                MessageBox.Show(@"Please enter the date");
                return false;
            }

            if (lkpMarketing.Value == null)
            {
                MessageBox.Show(@"Please enter the responsible marketing for this contact");
                return false;
            }

            if (rdoIsRegisteredCustomer.Checked && lkpCustomer.Value == null)
            {
                MessageBox.Show(@"Please select a customer for this sales lead");
                return false;
            }
            if (rdoIsContact.Checked && lkpContact.Value == null)
            {
                MessageBox.Show(@"Please select a contact for this sales lead");
                return false;
            }

            if (txtNote.Text == string.Empty)
            {
                MessageBox.Show(@"Please enter note for this lead");
                return false;
            }

            return true;
        }

        protected override void PopulateForm(SalesLeadModel model)
        {
            txtId.Text = model.Id.ToString(CultureInfo.InvariantCulture);
            txtLeadDate.DateTime = model.Vdate;
            lkpMarketing.DefaultValue = new IListParameter[] { WhereTerm.Default(model.MarketingId, "id") };

            if (lkpCustomer.Value != null)
            {
                rdoIsRegisteredCustomer.Checked = true;
                rdoIsRegisteredCustomer.PerformClick();
            }
            else
            {
                rdoIsContact.Checked = true;
                rdoIsContact.PerformClick();
            }

            lkpCustomer.DefaultValue = new IListParameter[] { WhereTerm.Default(model.CustomerId ?? 0, "id") };
            lkpContact.DefaultValue = new IListParameter[] { WhereTerm.Default(model.ContactId ?? 0, "id") };

            txtContactPerson.Text = model.ContactName;
            txtContactPhone.Text = model.ContactPhone;
            txtContactEmail.Text = model.ContactEmail;

            txtNote.Text = model.Note;

            _fillChildGridAsync(model.Id);

            txtId.Enabled = false;
        }

        //private async void _fillChildGridAsync(int id)
        private void _fillChildGridAsync(int id)
        {
            gridFollowUpView.ShowLoadingPanel();

            FollowUps.RaiseListChangedEvents = false;
            FollowUps.Clear();

            var model = _fillChildGrid(WhereTerm.Default(id, "sales_lead_id"));

            model.Select(row => new SalesLeadFollowUpDataRow
                {
                    EmployeeDataManager = EmployeeDataManager,

                    Id = row.Id,
                    SalesLeadId = row.SalesLeadId,
                    Vdate = row.Vdate,
                    EmployeeId = row.EmployeeId,
                    Note = row.Note,
                    LeadStatusId = row.LeadStatusId,
                    Rowstatus = row.Rowstatus,
                    Rowversion = row.Rowversion,
                    Createddate = row.Createddate,
                    Createdby = row.Createdby,
                    Modifieddate = row.Modifieddate,
                    Modifiedby = row.Modifiedby,
                })
                .ForEach(row => FollowUps.Add(row));

            FollowUps.RaiseListChangedEvents = true;
            FollowUps.ResetBindings();

            gridFollowUpView.HideLoadingPanel();
        }

        //private Task<IEnumerable<SalesLeadFollowUpModel>> _fillChildGrid(params IListParameter[] parameters)
        private IEnumerable<SalesLeadFollowUpModel> _fillChildGrid(params IListParameter[] parameters)
        {
            //return TaskEx.Run(() => new SalesLeadFollowUpDataManager().Get<SalesLeadFollowUpModel>(parameters));
            return new SalesLeadFollowUpDataManager().Get<SalesLeadFollowUpModel>(parameters);
        }

        protected override SalesLeadModel PopulateModel(SalesLeadModel model)
        {
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                model.Id = Convert.ToInt16(txtId.Text);
            }

            model.Vdate = txtLeadDate.DateTime;
            model.MarketingId = lkpMarketing.Value ?? 0;

            if (rdoIsRegisteredCustomer.Checked)
            {
                model.CustomerId = lkpCustomer.Value ?? 0;
                model.ContactId = null;
            }
            else
            {
                model.CustomerId = null;
                model.ContactId = lkpContact.Value ?? 0;
            }

            model.ContactName = txtContactPerson.Text;
            model.ContactPhone = txtContactPerson.Text;
            model.ContactEmail = txtContactPerson.Text;

            model.Note = txtNote.Text;

            if (FollowUps.Count > 0)
            {
                var last = FollowUps.Last();

                model.LastFollowUpDate = last.Vdate;
                model.LastLeadStatusId = last.LeadStatusId;
                model.FollowUpsCount = FollowUps.Count;
            }
            else
            {
                model.LastLeadStatusId = 1;
            }

            return model;
        }

        protected override void SaveDetail(bool isUpdate = false)
        {
            base.SaveDetail(isUpdate);

            new SalesLeadFollowUpDataManager().Save(CurrentModel as SalesLeadModel, FollowUps);
        }

        protected override IListParameter[] Filter()
        {
            var p = new List<IListParameter>();

            if (lkpFilterCustomer.Value != null) p.Add(WhereTerm.Default((int)lkpFilterCustomer.Value, "customer_id"));
            if (lkpFilterContact.Value != null) p.Add(WhereTerm.Default((int)lkpFilterContact.Value, "contact_id"));
            if (lkpFilterMarketing.Value != null) p.Add(WhereTerm.Default((int)lkpFilterMarketing.Value, "marketing_id"));

            if (txtFilterLeadDate.Text != string.Empty && txtFilterLeadDate.DateTime != DateTime.MinValue) p.Add(WhereTerm.Default(txtFilterLeadDate.DateTime, "vdate"));
            if (txtFilterLastFollowUp.Text != string.Empty && txtFilterLastFollowUp.DateTime != DateTime.MinValue) p.Add(WhereTerm.Default(txtFilterLastFollowUp.DateTime, "last_follow_up_date"));

            return p.ToArray();
        }

        protected override void BeforeNew()
        {
            base.BeforeNew();

            txtLeadDate.DateTime = DateTime.Now;

            lkpMarketing.DefaultValue = new IListParameter[] { WhereTerm.Default(BaseControl.UserId ?? 0, "id") };

            PageLimit = 20;

            txtId.Enabled = false;
            rdoIsContact.Checked = true;
            rdoIsContact.PerformClick();
        }

        public void DetailNew()
        {
            FollowUps.Add(new SalesLeadFollowUpDataRow
            {
                EmployeeDataManager = EmployeeDataManager,
                Temporary = true,
                LeadStatusId = 1,

                Vdate = DateTime.Now,
                EmployeeId = BaseControl.EmployeeId,

                Rowstatus = true,
                Rowversion = DateTime.Now,
                Createddate = DateTime.Now,
                Createdby = BaseControl.UserLogin,
            });

            gridFollowUpView.FocusedRowHandle = FollowUps.Count - 1;
            gridFollowUpView.ShowEditForm();
        }

        public void DetailDelete()
        {
            if (gridFollowUpView.FocusedRowHandle < 0)
            {
                MessageBox.Show(@"No detail item selected", @"Delete Detail Item", MessageBoxButtons.OK);
                return;
            }

            if (FollowUps[gridFollowUpView.FocusedRowHandle].Temporary == false)
            {
                MessageBox.Show(@"Already saved follow up records cannot be deleted");
                return;
            }

            FollowUps.RemoveAt(gridFollowUpView.FocusedRowHandle);
        }

        protected override void AfterSave()
        {
            base.AfterSave();

            FollowUps.ForEach(row => row.Temporary = false);
        }
    }
}
