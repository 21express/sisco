using System;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using Devenlab.Common.WinControl.MessageBox;
using SISCO.Presentation.Common.Interfaces;
using SISCO.Presentation.Common.Properties;

namespace SISCO.Presentation.Common.Forms
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

            Load += (sender, args) =>
            {
                EnabledForm(false);
                ActiveControl = tsBaseTxt_Code.Control;

                LoadForm(sender, args);
                tsBaseBtn_Info.Enabled = false;

                RefreshToolbarState();
            };

            Activated += ActiveForm;
            Deactivate += InactiveForm;

            Closed += (sender, args) => CloseForm();

            tsBaseBtn_First.Enabled = true;
            tsBaseBtn_First.Click += (sender, args) => Top();

            tsBaseBtn_Previous.Click += (sender, args) => Previous();

            tsBaseBtn_Next.Click += (sender, args) => Next();

            tsBaseBtn_Last.Enabled = true;
            tsBaseBtn_Last.Click += (sender, args) => Bottom();


            tsBaseBtn_New.Click += (sender, args) => New();
            tsBaseBtn_Save.Click += (sender, args) => Save();
            tsBaseBtn_Delete.Click += (sender, args) => Delete();

            tsBaseBtn_Search.Enabled = false;
            tsBaseTxt_Code.KeyPress += (sender, args) =>
            {
                if (args.KeyChar != 13) return;
                var paramparam = DataManager.DefaultParameters;
                DataManager = new T2();
                DataManager.DefaultParameters = paramparam;

                PerformFind();

                //foreach (Control ctr in form.Controls)
                //{
                //    if (ctr is Panel)
                //    {
                //        foreach (Control ctlr in ctr.Controls)
                //        {
                //            if (ctlr.TabIndex == 1 && (ctlr is dTextBox || ctlr is dCalendar || ctlr is dLookup))
                //            {
                //                ctlr.Focus();
                //                break;
                //            }
                //        }
                //    }
                //    else
                //    {
                //        if (ctr.TabIndex == 1 && (ctr is dTextBox || ctr is dCalendar || ctr is dLookup))
                //        {
                //            ctr.Focus();
                //            break;
                //        }
                //    }
                //}
            };

            tsBaseBtn_Search.Click += (sender, args) => Find();
            tsBaseBtn_Refresh.Click += (sender, args) => PerformFind();

            tsBaseBtn_Info.Click += (sender, args) => Info();

            StateChange = EnumStateChange.Idle;
            CrudState = EnumStateChange.Idle;
        }

        protected void PerformFind()
        {
            if (!AllowView && !AllowViewAll)
            {
                MessageBox.Show(@"Anda tidak memiliki akses untuk melihat data pada form ini");
                return;
            }

            form.SelectNextControl(form, true, true, true, true);
            
            var found = Find(tsBaseTxt_Code.Text);

            if (found == null)
            {
                //tsBaseTxt_Code.Text = LastSearchCode;
                tsBaseTxt_Code.SelectAll();
                tsBaseTxt_Code.Focus();

                MessageForm.Warning(this, "Warning", Resources.no_found_data);
                return;
            }

            CurrentModel = found;

            CurrentIndexPage = 1;
            TotalPage = 1;

            EnabledForm(true);
            _PopulateForm(CurrentModel as T);
            StateChange = EnumStateChange.Select;

            RefreshToolbarState();

            tsBaseBtn_First.Enabled = true;
            tsBaseBtn_Last.Enabled = true;
        }

        public EnumStateChange StateChange { get; set; }
        public virtual new void ActiveForm(object sender, EventArgs e)
        {
            Buttons();
            NavigationMenu.CloseStrip.Enabled = true;
            BaseControl.ChildForm = this;

            if (form is IGridChildForm)
            {
                if (NavigationMenu.DetailNewStrip != null) NavigationMenu.DetailNewStrip.Visible = true;
                if (NavigationMenu.DetailDeleteStrip != null) NavigationMenu.DetailDeleteStrip.Visible = true;
                if (NavigationMenu.DetailSeparator1 != null) NavigationMenu.DetailSeparator1.Visible = true;
            }
            else
            {
                if (NavigationMenu.DetailNewStrip != null) NavigationMenu.DetailNewStrip.Visible = false;
                if (NavigationMenu.DetailDeleteStrip != null) NavigationMenu.DetailDeleteStrip.Visible = false;
                if (NavigationMenu.DetailSeparator1 != null) NavigationMenu.DetailSeparator1.Visible = false;
            }
        }

        public virtual void InactiveForm(object sender, EventArgs e)
        {
            BaseControl.ChildForm = null;
            NavigationMenu.CloseStrip.Enabled = false;
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
                var resultBtn = MessageForm.Ask(this, Resources.information, Resources.dirty_form);
                if (resultBtn == DialogResult.No) return;
                //if (CurrentModel != null && CurrentModel.Id > 0) Save();
            }

            StateChange = EnumStateChange.Insert;
            CrudState = EnumStateChange.Insert;

            tsBaseBtn_Save.Enabled = true;
            tsBaseBtn_Delete.Enabled = false;
            tsBaseTxt_Code.Text = "";

            //kalau dipanggil di masing-masing form aja ok kan?
            //ClearForm();

            CurrentModel = new T();
            EnabledForm(true);

            RefreshToolbarState();

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

            using (var scope = new System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.Required, new TimeSpan(0, 10, 0)))
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
            Buttons();

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
            tsBaseTxt_Code.Text = codeText;

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
            tsBaseTxt_Code.Text = SearchPopup.SelectedCode;


            PerformFind();

            //tsBaseBtn_First.Enabled = true;
            //tsBaseBtn_Last.Enabled = true;
        }

        protected virtual void RefreshToolbarState()
        {
            LastSearchCode = tsBaseTxt_Code.Text;

            if (CurrentModel != null && CurrentModel.Id > 0 && StateChange == EnumStateChange.Update) return;
            if (StateChange == EnumStateChange.Idle)
            {
                tsBaseBtn_First.Enabled = true;
                tsBaseBtn_Previous.Enabled = false;
                tsBaseBtn_Next.Enabled = false;
                tsBaseBtn_Last.Enabled = true;
            }
            else
            {
                tsBaseBtn_First.Enabled = CurrentIndexPage > 1 || TotalPage == 1 && StateChange == EnumStateChange.Insert || TotalPage == 0;
                tsBaseBtn_Previous.Enabled = CurrentIndexPage > 1;
                tsBaseBtn_Next.Enabled = CurrentIndexPage < TotalPage;
                tsBaseBtn_Last.Enabled = CurrentIndexPage < TotalPage;
            }

            if (TotalPage > 0)
            {
                if (StateChange != EnumStateChange.Insert)
                {
                    StateChange = EnumStateChange.Update;
                }

                tsBaseBtn_Delete.Enabled = StateChange != EnumStateChange.Insert;
                tsBaseBtn_Save.Enabled = (StateChange == EnumStateChange.Insert || StateChange == EnumStateChange.Update);
                tsBaseBtn_Refresh.Enabled = tsBaseBtn_Save.Enabled;
                tsBaseBtn_Info.Enabled = tsBaseBtn_Save.Enabled;
            }
            else
            {
                if (StateChange != EnumStateChange.Insert)
                {
                    StateChange = EnumStateChange.Idle;
                }
            }

            Buttons();

            if (!AllowView && !AllowViewAll)
            {
                tsBaseBtn_First.Visible = false;
                tsBaseBtn_Previous.Visible = false;
                tsBaseBtn_Next.Visible = false;
                tsBaseBtn_Last.Visible = false;
                tsBaseBtn_Refresh.Visible = false;
            }

            if (!AllowCreate)
            {
                tsBaseBtn_New.Visible = false;
                tsBase_Separator1.Visible = false;
            }

            if (!AllowEdit)
            {
                tsBaseBtn_Save.Visible = false;
            }

            if (AllowCreate || AllowEdit)
            {
                tsBaseBtn_Save.Visible = true;
            }

            if (!AllowDelete)
            {
                tsBaseBtn_Delete.Visible = false;
            }

            if (!AllowEdit && !AllowDelete)
            {
                tsBase_Separator2.Visible = false;
            }

            if (!AllowPrint)
            {
                tsBaseBtn_Print.Visible = false;
                tsBaseBtn_PrintPreview.Visible = false;
                tsBase_Separator4.Visible = false;
            }
        }

        protected virtual void AfterSave()
        {
            AutoClosingMessageBox.Show(Resources.save_success, Resources.save_confirmation);
            tsBaseTxt_Code.Focus();

            tsBaseBtn_Refresh.Enabled = true;
            tsBaseBtn_Delete.Enabled = true;
            tsBaseBtn_Info.Enabled = true;
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

        public virtual void SetNoPod(string code)
        {
            
        }
    }
}