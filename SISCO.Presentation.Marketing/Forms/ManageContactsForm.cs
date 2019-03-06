using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.App.Marketing;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Annotations;
using SISCO.Presentation.MasterData.Popup;
using BaseControl = SISCO.Presentation.Common.BaseControl;

namespace SISCO.Presentation.Marketing.Forms
{
    public partial class ManageContactsForm : BaseMasterForm<ContactModel, ManageContactsForm.ContactDataRow, ContactDataManager>
    {
        public class ContactDataRow : ContactModel, INotifyPropertyChanged
        {
            public EmployeeDataManager EmployeeDataManager { get; set; }
            public BranchDataManager BranchDataManager { get; set; }

            private string _responsibleBranch;
            public string ResponsibleBranch
            {
                get
                {
                    if (string.IsNullOrEmpty(_responsibleBranch) && BranchId != 0)
                    {
                        var model = BranchDataManager.GetFirst<BranchModel>(WhereTerm.Default(BranchId, "id"));
                        _responsibleBranch = string.Format("{0}", model.Code);
                    }
                    return _responsibleBranch;
                }
                set { _responsibleBranch = value; }
            }
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
                        ResponsibleBranch = null;
                        NotifyUpdate("ResponsibleBranch");
                        break;
                    case "MarketingId":
                        Marketing = null;
                        NotifyUpdate("Marketing");
                        break;
                }
            }
        }

        public EmployeeDataManager EmployeeDataManager { get; set; }
        public BranchDataManager BranchDataManager { get; set; }

        public ManageContactsForm()
        {
            InitializeComponent();
            form = this;

            BranchDataManager = new BranchDataManager();
            EmployeeDataManager = new EmployeeDataManager();

            MainModelTransformFunc = model =>
            {
                var row = ConvertModel<ContactModel, ContactDataRow>(model);

                row.BranchDataManager = BranchDataManager;
                row.EmployeeDataManager = EmployeeDataManager;

                return row;
            };

            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            Init();
        }

        public override void Init()
        {
            CtlClearButton = null;
            CtlDeleteButton = btnDelete;
            CtlGridControl = grid;
            CtlGridView = gridView;
            CtlNewButton = btnNewContact;
            CtlPanelDetail = grpDetail;
            CtlSaveButton = btnSave;
            CtlSearchButton = btnSearch;

            base.Init();
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            ValidateOnSearch = false;

            lkpFilterRespBranch.LookupPopup = new BranchPopup();
            lkpFilterRespBranch.AutoCompleteDataManager = new BranchDataManager();
            lkpFilterRespBranch.AutoCompleteDisplayFormater = model => ((BranchModel)model).Code + " - " + ((BranchModel)model).Name;
            lkpFilterRespBranch.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("(code = @0 OR name.StartsWith(@0))", s);
            lkpFilterRespBranch.DefaultValue = new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "id") };
            lkpFilterRespBranch.Enabled = false;

            lkpFilterCustomer.LookupPopup = new CustomerPopup(WhereTerm.Default(BaseControl.BranchId, "branch_id"));
            lkpFilterCustomer.AutoCompleteDataManager = new CustomerDataManager();
            lkpFilterCustomer.AutoCompleteDisplayFormater = model => ((CustomerModel)model).Code + " - " + ((CustomerModel)model).Name;
            lkpFilterCustomer.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND branch_id = @1", s, BaseControl.BranchId);

            lkpFilterMarketing.LookupPopup = new EmployeePopup(EmployeeModel.EmployeeType.Marketing);
            lkpFilterMarketing.AutoCompleteDataManager = new EmployeeDataManager();
            lkpFilterMarketing.AutoCompleteDisplayFormater = model => ((EmployeeModel)model).Code + " - " + ((EmployeeModel)model).Name;
            lkpFilterMarketing.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND as_marketing AND branch_id = @1", s, BaseControl.BranchId);

            lkpCustomer.LookupPopup = new CustomerPopup(WhereTerm.Default(BaseControl.BranchId, "branch_id"));
            lkpCustomer.AutoCompleteDataManager = new CustomerDataManager();
            lkpCustomer.AutoCompleteDisplayFormater = model => ((CustomerModel)model).Code + " - " + ((CustomerModel)model).Name;
            lkpCustomer.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND branch_id = @1", s, BaseControl.BranchId);

            lkpMarketing.LookupPopup = new EmployeePopup(EmployeeModel.EmployeeType.Marketing);
            lkpMarketing.AutoCompleteDataManager = new EmployeeDataManager();
            lkpMarketing.AutoCompleteDisplayFormater = model => ((EmployeeModel)model).Code + " - " + ((EmployeeModel)model).Name;
            lkpMarketing.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND as_marketing AND branch_id = @1", s, BaseControl.BranchId);


            lkpRespBranch.LookupPopup = new BranchPopup();
            lkpRespBranch.AutoCompleteDataManager = new BranchDataManager();
            lkpRespBranch.AutoCompleteDisplayFormater = model => ((BranchModel)model).Code + " - " + ((BranchModel)model).Name;
            lkpRespBranch.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("code = @0 OR name.StartsWith(@0)", s);

            lkpCustomer.TextChanged += (o, args) =>
            {
                btnCopy.Enabled = lkpCustomer.Value == null;
            };

            txtDate.FieldLabel = "Date";
            txtDate.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            txtCompanyName.FieldLabel = "Company Name";
            txtCompanyName.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            txtAddress.FieldLabel = "Company Address";
            txtAddress.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            lkpRespBranch.FieldLabel = "Responsible branch";
            lkpRespBranch.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            lkpMarketing.FieldLabel = "Marketing";
            lkpMarketing.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            txtContactPerson.FieldLabel = "Contact Person";
            txtContactPerson.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            btnCopy.Click += btnCopy_Click;
        }

        void btnCopy_Click(object sender, EventArgs e)
        {
            if (!ValidateFormWithAlert())
            {
                return;
            }

            using (var customerDm = new CustomerDataManager())
            {
                var existing = customerDm.GetFirst<CustomerModel>(WhereTerm.Default(txtCompanyName.Text, "name"));
                if (existing != null)
                {
                    MessageBox.Show(@"Customer dengan nama contact yang sama sudah terdaftar.");
                    return;
                }

                var customerModel = new CustomerModel
                {
                    BranchId = lkpRespBranch.Value ?? 0,
                    Name = txtCompanyName.Text,
                    Address = txtAddress.Text,
                    Phone = txtPhone.Text,
                    Email = txtContactEmail.Text,
                    Contact = txtContactPerson.Text,
                    ContactEmail = txtContactEmail.Text,
                    ContactPhone = txtContactPhone.Text,
                    MarketingEmployeeId = lkpMarketing.Value,
                    PodNeeded = "0",
                    Disabled = "0",
                    Footer1 = string.Empty,
                    StartDate = DateTime.Now,
                    Note = txtNote.Text,
                    Createddate = DateTime.Now,
                    Createdby = BaseControl.UserLogin,
                    Rowstatus = true,
                    Rowversion = DateTime.Now
                };
                customerDm.Save<CustomerModel>(customerModel);

                MessageBox.Show(string.Format(@"The customer record has been added with code {0}", customerModel.Code));

                lkpCustomer.DefaultValue = new IListParameter[] { WhereTerm.Default(customerModel.Id, "id") };
            }

            Save();
        }

        protected override bool ValidateForm()
        {
            return true;
        }

        protected override bool ValidateFormWithAlert()
        {
            if (txtDate.Text == string.Empty)
            {
                MessageBox.Show(@"Please enter the date");
                return false;
            }

            if (txtCompanyName.Text == string.Empty)
            {
                MessageBox.Show(@"Please enter the company name");
                return false;
            }

            if (txtAddress.Text == string.Empty)
            {
                MessageBox.Show(@"Please enter the company address");
                return false;
            }

            if (lkpRespBranch.Value == null)
            {
                MessageBox.Show(@"Please enter the responsible branch for this contact");
                return false;
            }

            if (lkpMarketing.Value == null)
            {
                MessageBox.Show(@"Please enter the responsible marketing for this contact");
                return false;
            }

            return true;
        }

        protected override void PopulateForm(ContactModel currentModel)
        {
            txtDate.DateTime = currentModel.Vdate;
            txtCompanyName.Text = currentModel.CompanyName;
            txtAddress.Text = currentModel.CompanyAddress;
            txtPhone.Text = currentModel.CompanyPhone;

            lkpRespBranch.DefaultValue = new IListParameter[] { WhereTerm.Default(currentModel.BranchId, "id") };
            lkpCustomer.DefaultValue = new IListParameter[] { WhereTerm.Default(currentModel.CustomerId, "id") };
            lkpMarketing.DefaultValue = new IListParameter[] {WhereTerm.Default(currentModel.BranchId, "id")};

            txtContactPerson.Text = currentModel.ContactName;
            txtContactPhone.Text = currentModel.ContactPhone;
            txtContactEmail.Text = currentModel.ContactEmail;
            txtNote.Text = currentModel.Note;

            lkpMarketing.Enabled = false;
            lkpRespBranch.Enabled = false;
            lkpFilterRespBranch.Enabled = false;

            btnDelete.Enabled = true;
            btnCopy.Enabled = true;
        }

        protected override ContactModel PopulateModel(ContactModel model)
        {
            model.Vdate = txtDate.DateTime;
            model.CompanyName =txtCompanyName.Text;
            model.CompanyAddress=txtAddress.Text;
            model.CompanyPhone= txtPhone.Text;

            model.BranchId = lkpRespBranch.Value ?? 0;
            model.CustomerId = lkpCustomer.Value ?? 0;
            model.MarketingId = lkpMarketing.Value ?? 0;

            model.ContactName = txtContactPerson.Text;
            model.ContactPhone = txtContactPhone.Text;
            model.ContactEmail = txtContactEmail.Text;
            model.Note = txtNote.Text;

            return model;
        }

        protected override IListParameter[] Filter()
        {
            var p = new List<IListParameter>();

            if (lkpRespBranch.Value != null) p.Add(WhereTerm.Default((int)lkpRespBranch.Value, "branch_id"));
            if (lkpFilterCustomer.Value != null) p.Add(WhereTerm.Default((int)lkpFilterCustomer.Value, "customer_id"));
            if (lkpFilterMarketing.Value != null) p.Add(WhereTerm.Default((int)lkpFilterMarketing.Value, "marketing_id"));
            if (txtFilterCompanyName.Text != string.Empty) p.Add(WhereTerm.Default(txtFilterCompanyName.Text, "company_name", EnumSqlOperator.Like));
            if (txtFilterContactPerson.Text != string.Empty) p.Add(WhereTerm.Default(txtFilterContactPerson.Text, "contact_name", EnumSqlOperator.Like));
    
            return p.ToArray();
        }

        protected override void BeforeNew()
        {
            base.BeforeNew();

            btnDelete.Enabled = false;
            btnCopy.Enabled = false;

            txtDate.DateTime = DateTime.Now;

            lkpFilterRespBranch.Enabled = false;

            lkpMarketing.DefaultValue = new IListParameter[] { WhereTerm.Default(BaseControl.EmployeeId, "id") };
            lkpMarketing.Enabled = false;

            lkpRespBranch.DefaultValue = new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "id") };
            lkpRespBranch.Enabled = false;

            PageLimit = 20;

            txtCompanyName.Focus();
        }
    }
}
