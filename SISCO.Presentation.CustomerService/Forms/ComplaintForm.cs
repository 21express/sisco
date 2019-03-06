using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting.Native;
using SISCO.App.CustomerService;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Annotations;
using SISCO.Presentation.MasterData.Popup;
using BaseControl = SISCO.Presentation.Common.BaseControl;

namespace SISCO.Presentation.CustomerService.Forms
{
    public partial class ComplaintForm : BaseCrudForm<ComplaintModel, ComplaintDataManager>//BaseToolbarForm//
    {
        protected BindingList<ComplaintFollowUpDataRow> FollowUps { get; set; }
        protected BindingList<ComplaintDataRow> Complaints { get; set; }

        public EmployeeDataManager EmployeeDataManager { get; set; }
        public BranchDataManager BranchDataManager { get; set; }
        public TrackingStatusDataManager TrackingStatusDataManager { get; set; }

        protected List<IListParameter> Parameters = new List<IListParameter>();

        protected class ComplaintFollowUpDataRow : ComplaintFollowUpModel, INotifyPropertyChanged
        {
            public EmployeeDataManager EmployeeDataManager { get; set; }

            private string _customerService;
            public string CustomerService
            {
                get
                {
                    if (string.IsNullOrEmpty(_customerService) && EmployeeId != 0)
                    {
                        var model = EmployeeDataManager.GetFirst<EmployeeModel>(WhereTerm.Default(EmployeeId, "user_id"));
                        _customerService = model != null ? string.Format("{0} - {1}", model.Code, model.Name) : "";
                    }
                    return _customerService;
                }
                set { _customerService = value; }
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
                        CustomerService = null;
                        NotifyUpdate("CustomerService");
                        break;
                }
            }
        }

        protected class ComplaintDataRow : ComplaintModel, INotifyPropertyChanged
        {
            public EmployeeDataManager EmployeeDataManager { get; set; }
            public BranchDataManager BranchDataManager { get; set; }

            private string _branch;
            public string Branch
            {
                get
                {
                    if (string.IsNullOrEmpty(_branch) && BranchId != 0)
                    {
                        var model = BranchDataManager.GetFirst<BranchModel>(WhereTerm.Default(BranchId, "id"));
                        _branch = model != null ? string.Format("{0} - {1}", model.Code, model.Name) : "";
                    }
                    return _branch;
                }
                set { _branch = value; }
            }

            private string _customerService;
            public string CustomerService
            {
                get
                {
                    if (string.IsNullOrEmpty(_customerService) && EmployeeId != 0)
                    {
                        var model = EmployeeDataManager.GetFirst<EmployeeModel>(WhereTerm.Default(EmployeeId, "id"));
                        _customerService = model != null ? string.Format("{0} - {1}", model.Code, model.Name) : "";
                    }
                    return _customerService;
                }
                set { _customerService = value; }
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
                        CustomerService = null;
                        NotifyUpdate("CustomerService");
                        break;
                }
            }
        }

        public ComplaintForm()
        {
            InitializeComponent();
            form = this;
        }

        protected override bool ValidateForm()
        {
            if (cmbCategory.SelectedValue == null)
            {
                cmbCategory.Focus();
                return false;
            }

            if (cmbStatus.SelectedValue == null)
            {
                cmbStatus.Focus();
                return false;
            }

            return true;
        }

        protected override bool ValidateFormWithAlert()
        {
            if (string.IsNullOrEmpty(txtContact.Text))
            {
                txtContact.Focus();
                MessageBox.Show(@"Please enter the contact name");
                return false;
            }
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                txtPhone.Focus();
                MessageBox.Show(@"Please enter the contacat phone");
                return false;
            }
            if (string.IsNullOrEmpty(txtNote.Text))
            {
                txtNote.Focus();
                MessageBox.Show(@"Please enter the complaint note");
                return false;
            }

            return true;
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            BranchDataManager = new BranchDataManager();
            EmployeeDataManager = new EmployeeDataManager();
            TrackingStatusDataManager = new TrackingStatusDataManager();

            lkpFilterCustomer.LookupPopup = new CustomerPopup(WhereTerm.Default(BaseControl.BranchId, "branch_id"));
            lkpFilterCustomer.AutoCompleteDataManager = new CustomerDataManager();
            lkpFilterCustomer.AutoCompleteDisplayFormater = model => ((CustomerModel)model).Code + " - " + ((CustomerModel)model).Name;
            lkpFilterCustomer.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND branch_id = @1", s, BaseControl.BranchId);

            lkpFilterBranch.LookupPopup = new BranchPopup();
            lkpFilterBranch.AutoCompleteDataManager = new BranchDataManager();
            lkpFilterBranch.AutoCompleteDisplayFormater = model => ((BranchModel)model).Code + " - " + ((BranchModel)model).Name;
            lkpFilterBranch.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("code = @0 OR name.StartsWith(@0)", s);

            lkpCustomer.LookupPopup = new CustomerPopup(WhereTerm.Default(BaseControl.BranchId, "branch_id"));
            lkpCustomer.AutoCompleteDataManager = new CustomerDataManager();
            lkpCustomer.AutoCompleteDisplayFormater = model => ((CustomerModel)model).Code + " - " + ((CustomerModel)model).Name;
            lkpCustomer.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND branch_id = @1", s, BaseControl.BranchId);

            lkpBranch.LookupPopup = new BranchPopup();
            lkpBranch.AutoCompleteDataManager = new BranchDataManager();
            lkpBranch.AutoCompleteDisplayFormater = model => ((BranchModel)model).Code + " - " + ((BranchModel)model).Name;
            lkpBranch.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("code = @0 OR name.StartsWith(@0)", s);

            Complaints = new BindingList<ComplaintDataRow>();
            FollowUps = new BindingList<ComplaintFollowUpDataRow>();

            grid.DataSource = Complaints;
            gridFollowUp.DataSource = FollowUps;

            gridColumn2.RealColumnEdit.DisplayFormat.FormatType = FormatType.DateTime;
            gridColumn2.RealColumnEdit.DisplayFormat.FormatString = "dd-MM-yyyy";

            using (var complaintCatDm = new ComplaintCategoryDataManager())
            {
                var cats = complaintCatDm.Get<ComplaintCategoryModel>();

                cmbCategory.DataSource = cats;
                cmbCategory.ValueMember = "Id";
                cmbCategory.DisplayMember = "Name";

                var catsCloned = new List<ComplaintCategoryModel>(cats);
                catsCloned.Insert(0, new ComplaintCategoryModel {Id = 0, Name = "All"});

                cmbFilterCategory.DataSource = catsCloned;
                cmbFilterCategory.ValueMember = "Id";
                cmbFilterCategory.DisplayMember = "Name";
            }

            var statuses = new[] { new KeyValuePair<int, string>(-1, "All"), new KeyValuePair<int, string>(0, "Open"), new KeyValuePair<int, string>(1, "Closed") };
            cmbFilterStatus.DataSource = statuses;
            cmbFilterStatus.ValueMember = "Key";
            cmbFilterStatus.DisplayMember = "Value";

            cmbStatus.DataSource = statuses.Skip(1).ToList();
            cmbStatus.ValueMember = "Key";
            cmbStatus.DisplayMember = "Value";

            txtContact.FieldLabel = "Contact";
            txtContact.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            txtPhone.FieldLabel = "Phone";
            txtPhone.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            txtNote.FieldLabel = "Note";
            txtNote.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            btnAdd.Click += btnAdd_Click;
            btnSearch.Click += btnSearch_Click;

            btnSearch.PerformClick();

            btnSaveToExcel.Click += (o, args) => ExportGridToExcel(gridView, "CustomerService_Complaint");
            btnSaveFollowUpsToExcel.Click += (o, args) => ExportGridToExcel(gridFollowUpView, "CustomerService_ComplaintFollowUps");

            groupBox1.Enabled = true;

            _SetControlEnableState(groupBox1, true);

            btnAdd.Enabled = false;
            btnSaveFollowUpsToExcel.Enabled = false;

            grid.Click += (o, args) =>
            {
                int[] rows = gridView.GetSelectedRows();

                if (rows.Length > 0)
                {
                    var row = (ComplaintDataRow)gridView.GetRow(rows[0]);

                    CurrentModel = row;

                    tsBaseTxt_Code.Text = CurrentModel.Id.ToString(CultureInfo.InvariantCulture);

                    PerformFind();
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

                if (((ComplaintModel)gridView.GetRow(args.RowHandle)).Status == 0)
                {
                    args.Appearance.ForeColor = Color.Red;
                }
            };
        }

        void btnSearch_Click(object sender, EventArgs e)
        {
            Parameters.Clear();

            if (lkpFilterCustomer.Value != null) Parameters.Add(WhereTerm.Default((int)lkpFilterCustomer.Value, "customer_id"));
            if (lkpFilterBranch.Value != null) Parameters.Add(WhereTerm.Default((int)lkpFilterBranch.Value, "branch_id"));
            if (txtFilterReference.Text != string.Empty) Parameters.Add(WhereTerm.Default(txtFilterReference.Text, "ref_code"));
            if (txtFilterDate.DateTime != DateTime.MinValue) Parameters.Add(WhereTerm.Default(txtFilterDate.DateTime, "vdate"));
            if (cmbFilterCategory.SelectedValue != null && ((int)cmbFilterCategory.SelectedValue) != 0) Parameters.Add(WhereTerm.Default((int)cmbFilterCategory.SelectedValue, "complaint_category_id"));
            if (((int) cmbFilterStatus.SelectedValue) != -1) Parameters.Add(WhereTerm.Default((int) cmbFilterStatus.SelectedValue, "status"));

            Complaints.RaiseListChangedEvents = false;
            Complaints.Clear();

            new ComplaintDataManager().
                Get<ComplaintModel>(Parameters.ToArray()).
                Select(orig =>
                {
                    var row = ConvertModel<ComplaintModel, ComplaintDataRow>(orig);

                    row.EmployeeDataManager = EmployeeDataManager;
                    row.BranchDataManager = BranchDataManager;

                    return row;
                })
                .ForEach(row => Complaints.Add(row));
            
            Complaints.RaiseListChangedEvents = true;
            Complaints.ResetBindings();
        }

        void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtActionAdd.Text))
            {
                txtActionAdd.Focus();
                MessageBox.Show(@"Please enter your follow up action");
                return;
            }

            FollowUps.Add(new ComplaintFollowUpDataRow
            {
                EmployeeDataManager = EmployeeDataManager,

                ComplaintId = CurrentModel.Id,
                Vdate = DateTime.Now,
                BranchId = lkpBranch.Value ?? 0,
                EmployeeId = BaseControl.UserId ?? 0,
                Note = txtActionAdd.Text,

                Rowstatus = true,
                Rowversion = DateTime.Now,
                Createddate = DateTime.Now,
                Createdby = BaseControl.UserLogin,
            });

            txtActionAdd.Text = "";
            txtActionAdd.Focus();

            Save();
        }

        protected override void PopulateForm(ComplaintModel model)
        {
            lkpCustomer.DefaultValue = new IListParameter[] { WhereTerm.Default(model.CustomerId, "id") };
            lkpBranch.DefaultValue = new IListParameter[] { WhereTerm.Default(model.BranchId, "id") };
            txtReference.Text = model.RefCode;
            txtContact.Text = model.CustomerContact;
            txtPhone.Text = model.CustomerPhone;
            txtNote.Text = model.Note;

            cmbCategory.SelectedValue = model.ComplaintCategoryId;
            cmbStatus.SelectedValue = model.Status;

            FollowUps.RaiseListChangedEvents = false;

            FollowUps.Clear();

            new ComplaintFollowUpDataManager().
                Get<ComplaintFollowUpModel>(WhereTerm.Default(model.Id, "complaint_id")).
                Select(row => new ComplaintFollowUpDataRow
                {
                    EmployeeDataManager = EmployeeDataManager,

                    Id = row.Id,
                    ComplaintId = row.ComplaintId,
                    Vdate = row.Vdate,
                    BranchId = row.BranchId,
                    EmployeeId = row.EmployeeId,
                    Note = row.Note,

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

            btnAdd.Enabled = true;
            btnSaveFollowUpsToExcel.Enabled = true;

            tsBaseTxt_Code.Text = model.Id.ToString(CultureInfo.InvariantCulture);
        }

        protected override ComplaintModel PopulateModel(ComplaintModel model)
        {
            model.CustomerId = lkpCustomer.Value ?? 0;
            model.BranchId = lkpBranch.Value ?? 0;
            model.RefCode = txtReference.Text;

            using (var custDm = new CustomerDataManager())
            {
                var customer = custDm.GetFirst<CustomerModel>(WhereTerm.Default(lkpCustomer.Value ?? 0, "id"));
                if (customer != null)
                {
                    model.CustomerName = customer.Name;
                }
                else
                {
                    model.CustomerName = string.Empty;
                }
            }

            model.CustomerContact = txtContact.Text;
            model.CustomerPhone = txtPhone.Text;
            model.Note = txtNote.Text;

            model.ComplaintCategoryId = (int) cmbCategory.SelectedValue;
            model.Status = (int) cmbStatus.SelectedValue;

            model.ComplaintBranchId = BaseControl.BranchId;
            model.EmployeeId = BaseControl.UserId ?? 0;

            model.Vdate = DateTime.Now;

            model.ShipmentId = null;
            if (!string.IsNullOrEmpty(txtReference.Text))
            {
                using (var dm = new ShipmentDataManager())
                {
                    var shipment =  dm.GetFirst<ShipmentModel>(WhereTerm.Default(txtReference.Text, "code"));

                    if (shipment != null)
                    {
                        model.ShipmentId = shipment.Id;
                    }
                }
            }

            return model;
        }

        protected override ComplaintModel Find(string searchTerm)
        {
            int id;
            try
            {
                id = Convert.ToInt32(searchTerm);
            }
            catch (Exception)
            {
                return null;
            }

            return DataManager.GetFirst<ComplaintModel>(WhereTerm.Default(id, "Id"));
        }

        protected override void SaveDetail(bool isUpdate = false)
        {
            new ComplaintFollowUpDataManager().Save(CurrentModel as ComplaintModel, FollowUps);
        }

        protected override void BeforeNew()
        {
            base.BeforeNew();

            btnAdd.Enabled = true;
            btnSaveFollowUpsToExcel.Enabled = true;

            _ClearForm(groupBox2);

            lkpCustomer.Focus();

            FollowUps.Clear();
        }

        protected override void AfterSave()
        {
            base.AfterSave();

            btnSearch.PerformClick();
        }

        public override void AfterDelete()
        {
            base.AfterDelete();

            btnSearch.PerformClick();
        }
    }
}
