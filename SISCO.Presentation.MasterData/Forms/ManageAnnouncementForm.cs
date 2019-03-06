using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Annotations;
using SISCO.Presentation.MasterData.Popup;

namespace SISCO.Presentation.MasterData.Forms
{
    public partial class ManageAnnouncementForm : BaseMasterForm<RunningTextModel, ManageAnnouncementForm.AnnouncementDataRow, RunningTextDataManager>
    {
        public class AnnouncementDataRow : RunningTextModel, INotifyPropertyChanged
        {
            public string FromTime
            {
                get
                {
                    return string.Format("{0:00}:{1:00}", FromHour, FromMinute);
                }
            }
            public string ToTime
            {
                get
                {
                    return string.Format("{0:00}:{1:00}", ToHour, ToMinute);
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
            }
        }

        public ManageAnnouncementForm()
        {
            InitializeComponent();
            form = this;

            DataManager.DefaultParameters = new IListParameter[]
            {
                WhereTerm.Default(0,"announcement_type", EnumSqlOperator.Equals)
            };

            MainModelTransformFunc = model =>
            {
                var row = ConvertModel<RunningTextModel, AnnouncementDataRow>(model);

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
            CtlNewButton = btnNew;
            CtlPanelDetail = grpDetail;
            CtlSaveButton = btnSave;

            base.Init();
        }
        
        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            lkpUser.LookupPopup = new UserPopup();
            lkpUser.AutoCompleteDataManager = new UsersDataManager();
            lkpUser.AutoCompleteDisplayFormater = model => ((UsersModel)model).Username;
            lkpUser.AutoCompleteWheretermFormater = s => new IListParameter[] {WhereTerm.Default(s, "username", EnumSqlOperator.BeginWith)};

            lkpUserRole.LookupPopup = new UserRolePopup();
            lkpUserRole.AutoCompleteDataManager = new UserRoleDataManager();
            lkpUserRole.AutoCompleteDisplayFormater = model => ((UserRolesModel)model).Role;
            lkpUserRole.AutoCompleteWheretermFormater = s => new IListParameter[] { WhereTerm.Default(s, "role", EnumSqlOperator.BeginWith) };

            txtNote.FieldLabel = "Note";
            txtNote.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            txtStartTime.FormatDateTime = "HH:mm";
            txtEndTime.FormatDateTime = "HH:mm";

            PageLimit = 99999;

            form.Enabled = false;
            UseWaitCursor = true;

            var fleets = LoadGrid(GridLoadDirection.First);

            form.Enabled = true;
            UseWaitCursor = false;

            SetDataSource(fleets);
            NavigatorPagingState = PagingState;
        }

        protected override bool ValidateForm()
        {
            return true;
        }

        protected override bool ValidateFormWithAlert()
        {
            var errors = ComponentValidationHelper.Validate(txtNote);

            if (errors.Count > 0)
            {
                MessageBox.Show(string.Join("\n", errors));
                return false;
            }

            return true;
        }

        protected override void PopulateForm(RunningTextModel model)
        {
            if (model.FromDate != null)
            {
                var fromDateTime = new DateTime(model.FromDate.Value.Year, model.FromDate.Value.Month,
                    model.FromDate.Value.Day, model.FromHour, model.FromMinute, 0);

                txtStartDate.DateTime = fromDateTime;
                txtStartTime.Text = fromDateTime.ToString("HH:mm");
            }

            if (model.ToDate != null)
            {
                var toDateTime = new DateTime(model.ToDate.Value.Year, model.ToDate.Value.Month,
                    model.ToDate.Value.Day, model.ToHour, model.ToMinute, 0);

                txtEndDate.DateTime = toDateTime;
                txtEndTime.Text = toDateTime.ToString("HH:mm");
            }

            txtNote.Text = model.Name;

            if (model.UserId != null)
            {
                lkpUser.DefaultValue = new IListParameter[] {WhereTerm.Default((int) model.UserId, "id")};
            }
            else
            {
                lkpUser.DefaultValue = new IListParameter[] {};
            }

            if (model.RoleId != null)
            {
                lkpUserRole.DefaultValue = new IListParameter[] { WhereTerm.Default((int) model.RoleId, "id") };
            }
            else
            {
                lkpUserRole.DefaultValue = new IListParameter[] { };
            }

            btnDelete.Enabled = true;
        }

        protected override RunningTextModel PopulateModel(RunningTextModel model)
        {
            if (txtStartDate.Text != string.Empty)
            {
                model.FromDate = txtStartDate.DateTime;
                model.FromHour = Convert.ToSByte(txtStartTime.Value.ToString("HH"));
                model.FromMinute = Convert.ToSByte(txtStartTime.Value.ToString("mm"));
            }

            if (txtEndDate.Text != string.Empty)
            {
                model.ToDate = txtEndDate.DateTime;
                model.ToHour = Convert.ToSByte(txtEndTime.Value.ToString("HH"));
                model.ToMinute = Convert.ToSByte(txtStartTime.Value.ToString("mm"));
            }

            model.Name = txtNote.Text;

            model.UserId = lkpUser.Value;
            model.RoleId = lkpUserRole.Value;

            return model;
        }

        protected override IListParameter[] Filter()
        {
            var p = new List<IListParameter>();

            //if (lkpBaseBranch.Value != null) p.Add(WhereTerm.Default((int)lkpBaseBranch.Value, "branch_id"));
    
            return p.ToArray();
        }

        protected override void BeforeNew()
        {
            base.BeforeNew();

            txtStartDate.Focus();

            btnDelete.Enabled = false;

            PageLimit = 99999;
        }
    }
}