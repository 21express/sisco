using System;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using Devenlab.Common.WinControl.MessageBox;
using DevExpress.XtraBars;
using Franchise.Presentation.Common.Interfaces;
using Franchise.Presentation.Common.Properties;
using IPopup = Franchise.Presentation.Common.Interfaces.IPopup;

namespace Franchise.Presentation.Common.Forms
{
    public abstract class BaseCrudForm<T, T2> : BaseToolbarForm, IChildForm
        where T : class, IBaseModel, new()
        where T2 : BaseDataManager, new()
    {
        protected abstract bool ValidateForm();
        protected abstract void PopulateForm(T model);
        protected abstract T PopulateModel(T model);
        protected abstract T Find(string searchTerm);
        protected int Id { get; set; }
        protected string LastSearchCode { get; set; }

        protected bool _isPopulatingForm = false;
        
        protected IPopup SearchPopup { get; set; }
        // ReSharper disable once InconsistentNaming
        protected InfoPopup info = new InfoPopup();

        protected BaseCrudForm()
        {
            DataManager = new T2();

            StateChange = EnumStateChange.Idle;
            CrudState = EnumStateChange.Idle;

            Load += (sender, args) =>
            {
                EnabledForm(false);
                
                LoadForm(sender, args);
                rbLayout_Info.Enabled = false;

                RefreshToolbarState();
            };

            Activated += ActiveForm;
            Deactivate += InactiveForm;

            Closed += (sender, args) => CloseForm();

            rbNavigation_First.Enabled = true;
            rbNavigation_First.ItemClick += (sender, args) => Top();

            rbNavigation_Previous.ItemClick += (sender, args) => Previous();

            rbNavigation_Next.ItemClick += (sender, args) => Next();

            rbNavigation_Last.Enabled = true;
            rbNavigation_Last.ItemClick += (sender, args) => Bottom();

            rbData_New.ItemClick += (sender, args) => New();
            rbData_Save.ItemClick += (sender, args) => Save();
            rbData_Delete.ItemClick += (sender, args) => Delete();

            rbPage_Refresh.Enabled = false;
            tbxSearch_Code.KeyPress += (sender, args) =>
            {
                if (args.KeyChar != 13) return;
                var paramparam = DataManager.DefaultParameters;
                DataManager = new T2();
                DataManager.DefaultParameters = paramparam;

                PerformFind();
            };

            rbPage_Search.ItemClick += (sender, args) => Find();
            rbPage_Refresh.ItemClick += (sender, args) => PerformFind();

            rbLayout_Info.ItemClick += (sender, args) => Info();
        }

        protected void PerformFind()
        {
            if (!AllowView && !AllowViewAll)
            {
                MessageBox.Show(@"Anda tidak memiliki akses untuk melihat data pada form ini");
                return;
            }

            form.SelectNextControl(form, true, true, true, true);
            var found = Find(tbxSearch_Code.Text);

            if (found == null)
            {
                //tsBaseTxt_Code.Text = LastSearchCode;
                tbxSearch_Code.SelectAll();
                tbxSearch_Code.Focus();

                MessageForm.Warning(this, "Warning", Resources.no_found_data);
                EnabledForm(false);
                ClearForm();
                return;
            }

            CurrentModel = found;

            CurrentIndexPage = 1;
            TotalPage = 1;

            EnabledForm(true);
            _PopulateForm(CurrentModel as T);
            StateChange = EnumStateChange.Select;

            RefreshToolbarState();

            rbNavigation_First.Enabled = true;
            rbNavigation_Last.Enabled = true;
        }

        public EnumStateChange StateChange { get; set; }
        public virtual new void ActiveForm(object sender, EventArgs e)
        {
            BaseControl.ChildForm = this;
        }

        public virtual void InactiveForm(object sender, EventArgs e)
        {
            BaseControl.ChildForm = null;
        }

        public virtual void Info()
        {
            info.CreatedDate = CurrentModel.Createddate;
            info.CreatedBy = CurrentModel.Createdby;
            info.ModifiedDate = CurrentModel.Modifieddate;
            info.ModifiedBy = CurrentModel.Modifiedby;

            info.ShowDialog();
        }

        public void CloseForm()
        {
            DataManager.Dispose();

            //form.Close();
            form.Dispose();
            if (SearchPopup != null) ((Form)SearchPopup).Dispose();
        }

        public virtual void New()
        {
            if (Dirty)
            {
                var resultBtn = MessageForm.Ask(this, Resources.title_information, Resources.dirty_form);
                if (resultBtn == DialogResult.No) return;
                //if (CurrentModel != null && CurrentModel.Id > 0) Save();
            }

            StateChange = EnumStateChange.Insert;
            CrudState = EnumStateChange.Insert;

            rbData_New.Enabled = true;
            rbData_Save.Enabled = true;
            rbData_Delete.Enabled = false;
            tbxSearch_Code.Clear();

            RefreshToolbarState();

            //kalau dipanggil di masing-masing form aja ok kan?
            //ClearForm();

            CurrentModel = new T();
            EnabledForm(true);

            BeforeNew();
        }

        public virtual void Save()
        {
            if (!ValidateForm())
            {
                MessageBox.Show(Resources.alert_empty_field, @"Warning");
                return;
            }

            if (!ValidateFormWithAlert())
            {
                return;
            }

            CurrentModel = PopulateModel(CurrentModel as T);

            using (var scope = new System.Transactions.TransactionScope())
            {
                if (CurrentModel.Id == 0)
                {
                    InsertTracking = true;
                    CurrentModel.Rowstatus = true;
                    CurrentModel.Rowversion = DateTime.Now;
                    CurrentModel.Createddate = DateTime.Now;
                    CurrentModel.Createdby = BaseControl.UserLogin;

                    ((T2)DataManager).Save<T>(CurrentModel);

                    SaveDetail();
                }
                else
                {
                    InsertTracking = false;
                    CurrentModel.Rowversion = DateTime.Now;
                    CurrentModel.Modifieddate = DateTime.Now;
                    CurrentModel.Modifiedby = BaseControl.UserLogin;
                    ((T2)DataManager).Update<T>(CurrentModel);

                    SaveDetail(true);
                }

                scope.Complete();
            }

            TotalPage = 1;
            StateChange = EnumStateChange.Update;
            CrudState = EnumStateChange.Update;

            RefreshToolbarState();

            Dirty = false;
            AfterSave();

            form.Activate();
        }

        protected virtual void SaveDetail(bool isUpdate = false)
        {
            //
        }

        public virtual void Delete()
        {
            var dialog = MessageForm.Ask(form, Resources.delete_confirm, Resources.delete_confirm_msg);
            if (dialog == DialogResult.Yes)
            {
                ((T2)DataManager).DeActive(CurrentModel.Id, BaseControl.UserLogin, DateTime.Now);
                AfterDelete();
            }
        }

        public virtual void AfterDelete()
        {
            Previous();
        }

        public virtual new void Top()
        {
            CurrentIndexPage = 1;
            BindDataSource<IBaseModel>();
            SetPagingState();

            if (CurrentModel == null)
            {
                MessageForm.Warning(this, "Warning", Resources.no_found_data);
                FirstState();
                EnabledForm(false);
                ClearForm();
                return;
            }

            EnabledForm(true);
            _PopulateForm(CurrentModel as T);
            StateChange = EnumStateChange.Select;
            CrudState = EnumStateChange.Update;

            RefreshToolbarState();
        }

        public virtual void Previous()
        {
            CurrentIndexPage--;
            BindDataSource<IBaseModel>();
            SetPagingState();

            if (CurrentModel == null)
            {
                MessageForm.Warning(this, "Warning", Resources.no_found_data);
                EnabledForm(false);
                FirstState();
                return;
            }

            EnabledForm(true);
            _PopulateForm(CurrentModel as T);

            StateChange = EnumStateChange.Select;
            CrudState = EnumStateChange.Select;

            RefreshToolbarState();
        }

        public virtual void Next()
        {
            CurrentIndexPage++;
            BindDataSource<IBaseModel>();
            SetPagingState();

            if (CurrentModel == null)
            {
                MessageForm.Warning(this, "Warning", Resources.no_found_data);
                EnabledForm(false);
                ClearForm();
                FirstState();
                return;
            }

            EnabledForm(true);
            _PopulateForm(CurrentModel as T);

            StateChange = EnumStateChange.Select;
            CrudState = EnumStateChange.Select;

            RefreshToolbarState();
        }

        public new void Bottom()
        {
            if (TotalPage <= 1)
            {
                CurrentIndexPage = 1;
                BindDataSource<IBaseModel>();
                SetPagingState();
            }

            CurrentIndexPage = TotalPage;
            BindDataSource<IBaseModel>();
            SetPagingState();

            if (CurrentModel == null)
            {
                MessageForm.Warning(this, "Warning", Resources.no_found_data);
                EnabledForm(false);
                ClearForm();
                return;
            }

            EnabledForm(true);
            _PopulateForm(CurrentModel as T);

            StateChange = EnumStateChange.Select;
            CrudState = EnumStateChange.Select;

            RefreshToolbarState();
        }

        public void OpenData(string codeText)
        {
            tbxSearch_Code.Text = codeText;

            PerformFind();
        }

        public void Find()
        {
            if (SearchPopup == null) return;

            if (SearchPopup is Form)
            {
                ((Form)SearchPopup).ShowDialog();
            }

            if (SearchPopup.SelectedText == "") return;
            tbxSearch_Code.Text = SearchPopup.SelectedCode;


            PerformFind();

            //tsBaseBtn_First.Enabled = true;
            //tsBaseBtn_Last.Enabled = true;
        }

        protected virtual void RefreshToolbarState()
        {
            LastSearchCode = tbxSearch_Code.Text;

            if (CurrentModel != null && CurrentModel.Id > 0 && StateChange == EnumStateChange.Update) return;
            if (StateChange == EnumStateChange.Idle)
            {
                rbNavigation_First.Enabled = true;
                rbNavigation_Previous.Enabled = false;
                rbNavigation_Next.Enabled = false;
                rbNavigation_Last.Enabled = true;

                rbData_Save.Enabled = false;
                rbData_Delete.Enabled = false;
                rbLayout_Print.Enabled = false;
                rbLayout_PrintPreview.Enabled = false;
                rbLayout_Info.Enabled = false;
            }
            else
            {
                rbNavigation_First.Enabled = CurrentIndexPage > 1 || TotalPage == 1 && StateChange == EnumStateChange.Insert || TotalPage == 0;
                rbNavigation_Previous.Enabled = CurrentIndexPage > 1;
                rbNavigation_Next.Enabled = CurrentIndexPage < TotalPage;
                rbNavigation_Last.Enabled = CurrentIndexPage < TotalPage;
            }

            if (TotalPage > 0)
            {
                if (StateChange != EnumStateChange.Insert)
                {
                    StateChange = EnumStateChange.Update;
                }

                rbData_Delete.Enabled = StateChange != EnumStateChange.Insert;
                rbData_Save.Enabled = (StateChange == EnumStateChange.Insert || StateChange == EnumStateChange.Update);
                rbPage_Refresh.Enabled = rbData_Save.Enabled;
                rbLayout_Info.Enabled = rbData_Save.Enabled;

                rbLayout_Print.Enabled = true;
                rbLayout_PrintPreview.Enabled = true;
            }
            else
            {
                if (StateChange != EnumStateChange.Insert)
                {
                    StateChange = EnumStateChange.Idle;
                }
            }

            if (!AllowView && !AllowViewAll)
            {
                rbNavigation_First.Visibility = BarItemVisibility.Never;
                rbNavigation_Previous.Visibility = BarItemVisibility.Never; ;
                rbNavigation_Next.Visibility = BarItemVisibility.Never; ;
                rbNavigation_Last.Visibility = BarItemVisibility.Never; ;
                rbPage_Refresh.Visibility = BarItemVisibility.Never; ;
            }

            if (!AllowCreate)
            {
                rbData_New.Visibility = BarItemVisibility.Never; ;
            }

            if (!AllowEdit)
            {
                rbData_Save.Visibility = BarItemVisibility.Never; ;
            }

            if (!AllowDelete)
            {
                rbData_Delete.Visibility = BarItemVisibility.Never; ;
            }

            if (!AllowCreate && !AllowEdit && !AllowDelete) rbData.Visible = false;

            if (!AllowPrint)
            {
                rbLayout_Print.Visibility = BarItemVisibility.Never; ;
                rbLayout_PrintPreview.Visibility = BarItemVisibility.Never; ;
            }
        }

        protected virtual void AfterSave()
        {
            AutoClosingMessageBox.Show(Resources.save_success, Resources.save_confirmation);
            tbxSearch_Code.Focus();

            rbPage_Refresh.Enabled = true;
            rbData_Delete.Enabled = true;
            rbLayout_Info.Enabled = true;
        }

        protected virtual void BeforeNew()
        {
            //
        }

        protected virtual bool ValidateFormWithAlert()
        {
            return true;
        }

        void _PopulateForm(T model)
        {
            _isPopulatingForm = true;

            PopulateForm(model);

            _isPopulatingForm = false;
        }
    }
}