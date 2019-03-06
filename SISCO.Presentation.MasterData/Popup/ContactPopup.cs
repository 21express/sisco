using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.App.Marketing;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Interfaces;
using SISCO.Presentation.MasterData.Annotations;

namespace SISCO.Presentation.MasterData.Popup
{
    public partial class ContactPopup : BaseForm, IPopup
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

        public List<IListParameter> Parameters { get; set; }

        public ContactPopup()
        {
            InitializeComponent();

            Parameters = new List<IListParameter>();

            EmployeeDataManager = new EmployeeDataManager();
            BranchDataManager = new BranchDataManager();

            Load += LoadGrid;
        }

        private void LoadGrid(object sender, EventArgs e)
        {
            lkpBranch.LookupPopup = new BranchPopup();
            lkpBranch.AutoCompleteDataManager = new BranchDataManager();
            lkpBranch.AutoCompleteDisplayFormater = model => ((BranchModel)model).Code + " - " + ((BranchModel)model).Name;
            lkpBranch.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("code = @0 OR name.StartsWith(@0)", s);


            lkpMarketing.LookupPopup = new EmployeePopup(EmployeeModel.EmployeeType.Marketing);
            lkpMarketing.AutoCompleteDataManager = new EmployeeDataManager();
            lkpMarketing.AutoCompleteDisplayFormater = model => ((EmployeeModel)model).Code + " - " + ((EmployeeModel)model).Name;
            lkpMarketing.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND as_marketing", s);

            ContactGrid.DataSource = new ContactDataManager().Get<ContactModel>(Parameters.ToArray()).Select(row =>
            {
                var derived = ConvertModel<ContactModel, ContactDataRow>(row);

                derived.BranchDataManager = BranchDataManager;
                derived.EmployeeDataManager = EmployeeDataManager;

                return derived;
            });

            btnClear.Click += Clear;
            btnView.Click += FilterData;

            ContactView.RowClick += SelectRow;
            BtnSelect.Click += SelectValue;

            ContactView.KeyPress += (s, args) =>
            {
                if (args.KeyChar == 13)
                {
                    SelectRow(s, args);
                }
            };
            Shown += (s, args) =>
            {
                // ReSharper disable once ConvertToLambdaExpression
                lkpBranch.Focus();
            };
            btnView.PreviewKeyDown += (s, args) =>
            {
                if (args.KeyCode == Keys.Enter)
                {
                    ContactGrid.Focus();
                }
            };
        }

        protected void Clear(object sender, EventArgs e)
        {
            lkpBranch.Text = string.Empty;
            lkpMarketing.Text = string.Empty;
            txtCompanyName.Text = string.Empty;
            txtContactName.Text = string.Empty;

            FilterData(sender, e);
        }

        protected void FilterData(object sender, EventArgs e)
        {
            Parameters.Clear();

            if (lkpBranch.Value != null) Parameters.Add(WhereTerm.Default((int)lkpBranch.Value, "branch_id"));
            if (lkpMarketing.Value != null) Parameters.Add(WhereTerm.Default((int)lkpMarketing.Value, "marketing_id"));
            if (!string.IsNullOrEmpty(txtCompanyName.Text)) Parameters.Add(WhereTerm.Default(txtCompanyName.Text, "company_name", EnumSqlOperator.Like));
            if (!string.IsNullOrEmpty(txtContactName.Text)) Parameters.Add(WhereTerm.Default(txtContactName.Text, "contact_name", EnumSqlOperator.Like));

            LoadGrid(sender, e);
        }

        public int SelectedValue { get; set; }
        public string SelectedCode { get; set; }

        public string SelectedText { get; set; }

        public void SelectRow(object sender, EventArgs e)
        {
            BtnSelect.PerformClick();
        }

        public void SelectValue(object sender, EventArgs e)
        {
            int[] rows = ContactView.GetSelectedRows();

            SelectedValue = Convert.ToInt32(ContactView.GetRowCellValue(rows[0], "Id"));
            SelectedCode = ContactView.GetRowCellValue(rows[0], "CompanyName").ToString();
            SelectedText = ContactView.GetRowCellValue(rows[0], "CompanyName").ToString();

            Hide();
        }
    }
}
