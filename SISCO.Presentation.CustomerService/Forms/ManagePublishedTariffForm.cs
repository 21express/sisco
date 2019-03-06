using System;
using System.ComponentModel;
using System.Windows.Forms;
using Devenlab.Common.Interfaces;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting.Native;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.ComponentRepositories;
using SISCO.Presentation.Common.Forms;
using SISCO.App.MasterData;
using Devenlab.Common;
using SISCO.Presentation.Common.Interfaces;
using SISCO.Presentation.MasterData.Popup;
using BaseControl = SISCO.Presentation.Common.BaseControl;

namespace SISCO.Presentation.CustomerService.Forms
{
    public partial class ManagePublishedTariffForm : BaseCrudForm<CityModel, CityDataManager>, IGridChildForm//BaseToolbarForm//
    {
        protected BindingList<TariffModel> Tariffs { get; set; }
        protected ServiceTypeDataManager ServiceTypeDataManager { get; set; }
        protected CityDataManager CityDataManager { get; set; }
        protected CountryDataManager CountryDataManager { get; set; }

        public ManagePublishedTariffForm()
        {
            InitializeComponent();

            form = this;
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            EnableBtnSearch = true;
            SearchPopup = new CityPopup();

            Tariffs = new BindingList<TariffModel>();
            ServiceTypeDataManager = new ServiceTypeDataManager();
            CityDataManager = new CityDataManager();

            NavigationMenu.DeleteStrip.Enabled = false;
            NavigationMenu.NewStrip.Enabled = false;

            tsBaseBtn_New.Enabled = false;
            tsBaseBtn_Delete.Enabled = false;

            grid.EmbeddedNavigator.Buttons.Append.Visible = false;
            grid.EmbeddedNavigator.Buttons.Remove.Visible = false;
            grid.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            grid.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            grid.EmbeddedNavigator.Buttons.Edit.Visible = false;

            btnExport.Enabled = false;

            grid.DataSource = Tariffs;
            grid.EmbeddedNavigator.ButtonClick += NavigatorClick;

            lookupRepoCity.LookupPopup = new CityPopup();
            lookupRepoCity.AutoCompleteDataManager = new CityDataManager();
            lookupRepoCity.AutoCompleteDisplayFormater = model => ((CityModel)model).Name;
            lookupRepoCity.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("name.StartsWith(@0)", s);

            lookupRepoServiceType.LookupPopup = new ServiceTypePopup();
            lookupRepoServiceType.AutoCompleteDataManager = new ServiceTypeDataManager();
            lookupRepoServiceType.AutoCompleteDisplayFormater = model => ((ServiceTypeModel)model).Name;
            lookupRepoServiceType.AutoCompleteWheretermFormater = s => new IListParameter[] {WhereTerm.Default(s, "name")};

            gridView.RowCellDefaultAlignment += (o, args) =>
            {
                if (args.Column.ColumnEdit is LookupRepo)
                {
                    args.HorzAlignment = HorzAlignment.Near;
                }
            };

            gridView.OptionsBehavior.Editable = false;

            btnExport.Click +=
                (o, args) => ExportGridToExcel(gridView, string.Format("MasterData_PublishedTariff_{0}", txtOriginCity.Text));

            tsBaseTxt_Code.Text = BaseControl.CityName;
            PerformFind();
        }

        protected override bool ValidateForm()
        {
            return true;
        }

        protected override void PopulateForm(CityModel model)
        {
            tsBaseTxt_Code.Text = model.Name;
            txtOriginCity.Text = model.Name;

            Tariffs.RaiseListChangedEvents = false;
            Tariffs.Clear();

            new TariffDataManager().
                Get<TariffModel>(WhereTerm.Default(model.Id, "city_orig_id")).ForEach(row => Tariffs.Add(row));

            Tariffs.RaiseListChangedEvents = true;
            Tariffs.ResetBindings();

            txtOriginCity.Enabled = false;
            btnExport.Enabled = true;
        }

        protected override CityModel PopulateModel(CityModel model)
        {
            gridView.PostEditor();

            return model;
        }

        protected override CityModel Find(string searchTerm)
        {
            return DataManager.GetFirst<CityModel>(WhereTerm.Default(searchTerm, "name"));
        }

        protected override void SaveDetail(bool isUpdate = false)
        {
            base.SaveDetail(isUpdate);

            Tariffs.ForEach(row =>
            {
                row.Createdby = BaseControl.UserLogin;
                row.Createddate = DateTime.Now;
                row.CurrencyId = 1;
            });

            new TariffDataManager().Save(CurrentModel as CityModel, Tariffs);
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
            if (CurrentModel != null && CurrentModel.Id > 0)
            {
                Tariffs.Add(new TariffModel
                {
                    Rowstatus = true,
                    Rowversion = DateTime.Now,
                });
            }
        }

        public void DetailDelete()
        {
            if (gridView.FocusedRowHandle < 0)
            {
                MessageBox.Show(@"No detail item selected", @"Delete Detail Item", MessageBoxButtons.OK);
                return;
            }

            Tariffs.RemoveAt(gridView.FocusedRowHandle);
        }

        protected override void AfterSave()
        {
            base.AfterSave();

            NavigationMenu.NewStrip.Enabled = false;
            NavigationMenu.DeleteStrip.Enabled = false;

            tsBaseBtn_New.Enabled = false;
            tsBaseBtn_Delete.Enabled = false;
        }

        protected override void RefreshToolbarState()
        {
            base.RefreshToolbarState();

            tsBaseBtn_Delete.Enabled = false;
            tsBaseBtn_Save.Enabled = false;
            tsBaseBtn_New.Enabled = false;

            NavigationMenu.DeleteStrip.Enabled = false;
            NavigationMenu.SaveStrip.Enabled = false;
            NavigationMenu.NewStrip.Enabled = false;
        }
    }
}
