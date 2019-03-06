using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting.Native;
using SISCO.Presentation.Common.Interfaces;
using SISCO.Presentation.Common.Properties;

namespace SISCO.Presentation.Common.Forms
{
    public abstract class BaseMasterForm<TModel, TDataManager> : BaseMasterForm<TModel, TModel, TDataManager>
        where TModel : class, IBaseModel, new()
        where TDataManager : BaseDataManager, new()
    {
        
    }

    public abstract class BaseMasterForm<TModel, TGridModel, TDataManager> : BasePage, IChildForm
        where TModel : class, IBaseModel, new()
        where TGridModel : TModel
        where TDataManager : BaseDataManager, new()
    {
        public enum GridLoadDirection
        {
            Current = -1,
            First = 0,
            Previous = 2,
            Next = 3,
            Last = 5
        }

        protected abstract bool ValidateForm();
        protected abstract void PopulateForm(TModel model);
        protected abstract TModel PopulateModel(TModel model);
        protected abstract IListParameter[] Filter();

        public EnumStateChange StateChange { get; set; }
        
        protected Control CtlPanelDetail = new Control();
        protected Control CtlNewButton = new Control();
        protected Control CtlSaveButton = new Control();
        protected Control CtlSearchButton = new Control();
        protected Control CtlSearchPanel = new Control();
        protected Control CtlClearButton = new Control();
        protected Control CtlDeleteButton = new Control();
        protected GridControl CtlGridControl = new GridControl();
        protected GridView CtlGridView = new GridView();


        public bool ValidateOnSearch { get; set; }
        protected bool _isPopulatingForm { get; set; }

        public Func<IBaseModel, IBaseModel> MainModelTransformFunc { get; set; }

        protected BindingList<TGridModel> DataSource; 
        
        protected BaseMasterForm()
        {
            ValidateOnSearch = true;

            DataManager = new TDataManager();

            MainModelTransformFunc = model => model;
            PageLimit = 20;

            DataSource = new BindingList<TGridModel>();

            Load += (sender, args) =>
            {
                LoadForm(sender, args);

                CtlPanelDetail.Enabled = false;
                CtlSaveButton.Enabled = false;
                CtlDeleteButton.Enabled = false;

                if (!AllowView && !AllowViewAll)
                {
                    CtlSearchButton.Enabled = false;
                }

                if (!AllowCreate)
                {
                    CtlNewButton.Enabled = false;
                }

                if (!AllowEdit)
                {
                    CtlSaveButton.Enabled = false;
                }

                if (!AllowDelete)
                {
                    CtlDeleteButton.Enabled = false;
                }
            };

            Activated += ActiveForm;
            Deactivate += InactiveForm;

            Closed += (sender, args) => CloseForm();
        }

        public virtual void Init()
        {
            NavigationMenu.NewStrip.Enabled = false;
            NavigationMenu.SaveStrip.Enabled = false;
            NavigationMenu.DeleteStrip.Enabled = false;
            NavigationMenu.TopStrip.Enabled = false;
            NavigationMenu.PreviousStrip.Enabled = false;
            NavigationMenu.NextStrip.Enabled = false;
            NavigationMenu.BottomStrip.Enabled = false;
            NavigationMenu.FindStrip.Enabled = false;
            NavigationMenu.RefreshStrip.Enabled = false;

            CtlGridControl.DataSource = DataSource;

            CtlGridControl.Click += SelectRow;
            CtlGridControl.EmbeddedNavigator.ButtonClick += NavigatorClick;
            CtlSearchButton.Click += CtlSearchButtonOnClick;

            CtlNewButton.Click += (s, args) => New();
            CtlSaveButton.Click += (s, args) => Save();
            CtlDeleteButton.Click += (s, args) => Delete();
        }

        private void CtlSearchButtonOnClick(object sender, EventArgs eventArgs)
        {
            if (ValidateOnSearch && !ValidateForm()) return;

            AutoCompleteWheretermFormater = Filter();

            //form.Enabled = false;
            UseWaitCursor = true;

            var model = LoadGrid(GridLoadDirection.First);

            //form.Enabled = true;
            UseWaitCursor = false;

            SetDataSource(model);
            NavigatorPagingState = PagingState;
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            CurrentIndexPage = 0;

            StateChange = EnumStateChange.Idle;

            //((Button)CtlSearchButton).PerformClick();
        }

        public virtual void SelectRow(object sender, EventArgs e)
        {
            int[] rows = CtlGridView.GetSelectedRows();

            if (rows.Length > 0)
            {
                var row = CtlGridView.GetRow(rows[0]);
                CurrentModel = row as TModel;
                
                CtlPanelDetail.Enabled = true;
                CtlSaveButton.Enabled = true;
                CtlDeleteButton.Enabled = true;

                _isPopulatingForm = true;

                PopulateForm(CurrentModel as TModel);

                _isPopulatingForm = false;

                CtlPanelDetail.Focus();
            }
        }

        public string NavigatorPagingState
        {
            set
            {
                if (CtlGridControl.EmbeddedNavigator.Buttons.CustomButtons.Count == 0) return;

                CtlGridControl.EmbeddedNavigator.Enabled = true;
                CtlGridControl.EmbeddedNavigator.TextStringFormat = value;
                if (CurrentIndexPage == 1)
                {
                    CtlGridControl.EmbeddedNavigator.Buttons.CustomButtons[0].Enabled = false;
                    CtlGridControl.EmbeddedNavigator.Buttons.CustomButtons[1].Enabled = false;
                    CtlGridControl.EmbeddedNavigator.Buttons.CustomButtons[2].Enabled = true;
                    CtlGridControl.EmbeddedNavigator.Buttons.CustomButtons[3].Enabled = true;
                }

                if (CurrentIndexPage > 1)
                {
                    CtlGridControl.EmbeddedNavigator.Buttons.CustomButtons[0].Enabled = true;
                    CtlGridControl.EmbeddedNavigator.Buttons.CustomButtons[1].Enabled = true;
                    CtlGridControl.EmbeddedNavigator.Buttons.CustomButtons[2].Enabled = true;
                    CtlGridControl.EmbeddedNavigator.Buttons.CustomButtons[3].Enabled = true;
                }

                if (CurrentIndexPage == TotalPage)
                {
                    CtlGridControl.EmbeddedNavigator.Buttons.CustomButtons[0].Enabled = true;
                    CtlGridControl.EmbeddedNavigator.Buttons.CustomButtons[1].Enabled = true;
                    CtlGridControl.EmbeddedNavigator.Buttons.CustomButtons[2].Enabled = false;
                    CtlGridControl.EmbeddedNavigator.Buttons.CustomButtons[3].Enabled = false;
                }

                if (TotalPage == 0 || TotalPage == 1)
                {
                    CtlGridControl.EmbeddedNavigator.Buttons.CustomButtons[0].Enabled = false;
                    CtlGridControl.EmbeddedNavigator.Buttons.CustomButtons[1].Enabled = false;
                    CtlGridControl.EmbeddedNavigator.Buttons.CustomButtons[2].Enabled = false;
                    CtlGridControl.EmbeddedNavigator.Buttons.CustomButtons[3].Enabled = false;
                }
            }
        }

        protected void NavigatorClick(object sender, NavigatorButtonClickEventArgs e)
        {
            var model = LoadGrid((GridLoadDirection) e.Button.ImageIndex);

            SetDataSource(model);

            NavigatorPagingState = PagingState;
        }

        //protected async Task<IEnumerable<T>> LoadGrid(GridLoadDirection direction)
        protected IEnumerable<TModel> LoadGrid(GridLoadDirection direction)
        {
            switch (direction)
            {
                case GridLoadDirection.First:
                    CurrentIndexPage = 1;
                    break;
                case GridLoadDirection.Previous:
                    CurrentIndexPage--;
                    break;
                case GridLoadDirection.Next:
                    CurrentIndexPage++;
                    break;
                case GridLoadDirection.Last:
                    CurrentIndexPage = TotalPage;
                    break;
                case GridLoadDirection.Current:
                    //nothing;
                    break;
            }

            //return await TaskEx.Run(() => BindListDataSource<T>());
            return BindListDataSource<TModel>();
        }

        public virtual new void ActiveForm(object sender, EventArgs e)
        {
            BaseControl.ChildForm = this;
        }

        public virtual void InactiveForm(object sender, EventArgs e)
        {
            BaseControl.ChildForm = null;
        }

        public void CloseForm()
        {
            DataManager.Dispose();
            form.Dispose();
        }

        public virtual void New()
        {
            StateChange = EnumStateChange.Insert;
            
            if (Dirty)
            {
                DialogResult result = (MessageBox.Show(
                   Resources.alert_before_create
                   , Resources.title_save_changes
                   , MessageBoxButtons.YesNoCancel
                   , MessageBoxIcon.Question));

                switch (result)
                {
                    case DialogResult.Yes:
                        Save();
                        break;
                }
            }

            _ClearForm(CtlPanelDetail);
            CtlPanelDetail.Enabled = true;
            CtlSaveButton.Enabled = true;
            CtlDeleteButton.Enabled = false;

            CtlPanelDetail.Focus();

            CurrentModel = new TModel();
            EnabledForm(true);

            BeforeNew();
        }

        public virtual void Save()
        {
            if (!ValidateForm())
            {
                MessageBox.Show(
                    Resources.alert_empty_field
                    , Resources.title_save_changes
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Information);

                return;
            }

            if (!ValidateFormWithAlert())
            {
                return;
            }

            CurrentModel = PopulateModel(CurrentModel as TModel);

            _saveAsync();
        }

        //private async void _saveAsync()
        private void _saveAsync()
        {
            Enabled = false;

            //await _save();
            _save();

            var lastSelectedRow = CtlGridView.FocusedRowHandle;

            SetDataSource(BindListDataSource<TModel>());

            CtlGridView.FocusedRowHandle = lastSelectedRow;

            AfterSave();

            StateChange = EnumStateChange.Update;

            Enabled = true;
            BringToFront();
        }

        //private Task _save()
        private void _save()
        {
            //return TaskEx.Run(() =>
            //{
                using (var scope = new System.Transactions.TransactionScope())
                {
                    if (CurrentModel.Id == 0)
                    {
                        CurrentModel.Rowstatus = true;
                        CurrentModel.Rowversion = DateTime.Now;
                        CurrentModel.Createddate = DateTime.Now;
                        CurrentModel.Createdby = BaseControl.UserLogin;

                        ((TDataManager)DataManager).Save<TModel>(CurrentModel);

                        SaveDetail();
                    }
                    else
                    {
                        ((TDataManager)DataManager).Update<TModel>(CurrentModel);
                        CurrentModel.Rowversion = DateTime.Now;
                        CurrentModel.Modifieddate = DateTime.Now;
                        CurrentModel.Modifiedby = BaseControl.UserLogin;

                        SaveDetail(true);
                    }

                    scope.Complete();
                }
            //});
        }

        protected virtual void SaveDetail(bool isUpdate = false)
        {
            //
        }

        public virtual void Delete()
        {
            var dialogResult = MessageBox.Show(Resources.delete_confirm_msg, Resources.delete_confirm,
                MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                ((TDataManager)DataManager).DeActive(CurrentModel.Id, BaseControl.UserLogin, DateTime.Now);
            }

            SetDataSource(BindListDataSource<TModel>());

            _ClearForm(CtlPanelDetail);
            CtlPanelDetail.Enabled = false;
            CtlSaveButton.Enabled = false;
            CtlDeleteButton.Enabled = false;
        }

        // ReSharper disable once CSharpWarnings::CS0108
        public new void Top()
        {
            throw new NotImplementedException();
        }

        public void Previous()
        {
            throw new NotImplementedException();
        }

        public void Next()
        {
            throw new NotImplementedException();
        }

        // ReSharper disable once CSharpWarnings::CS0108
        public new void Bottom()
        {
            throw new NotImplementedException();
        }

        public void OpenData(string codeText)
        {
            throw new NotImplementedException();
        }

        public void Find()
        {
            throw new NotImplementedException();
        }

        protected virtual void RefreshToolbarState()
        {
            if (TotalPage > 0)
            {
                CtlDeleteButton.Enabled = true;
                CtlSaveButton.Enabled = true;

                StateChange = EnumStateChange.Update;
            }
            else
            {
                StateChange = EnumStateChange.Idle;
            }
        }

        protected virtual void AfterSave()
        {
            AutoClosingMessageBox.Show(Resources.save_success, Resources.save_confirmation);
        }

        protected virtual void BeforeNew()
        {
            //
        }

        protected virtual void SetDataSource(IEnumerable<TModel> data)
        {
            CtlGridView.ShowLoadingPanel();

            DataSource.RaiseListChangedEvents = false;
            DataSource.Clear();

            data.ForEach(row => DataSource.Add((TGridModel)MainModelTransformFunc(row)));

            AfterGridLoad();

            DataSource.RaiseListChangedEvents = true;
            DataSource.ResetBindings();

            CtlGridView.HideLoadingPanel();
        }

        protected virtual void AfterGridLoad()
        {
            //
        }

        protected virtual bool ValidateFormWithAlert()
        {
            return true;
        }

        public virtual void SetNoPod(string code)
        {

        }
    }
}