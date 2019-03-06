using System;
using System.ComponentModel;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraPrinting.Native;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.ComponentRepositories;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Interfaces;
using SISCO.Presentation.MasterData.Popup;
using BaseControl = SISCO.Presentation.Common.BaseControl;

namespace SISCO.Presentation.MasterData.Forms
{
    public partial class ManagePublishedInternationalTariffForm : BaseCrudForm<PricingPlanModel, PricingPlanDataManager>, IGridChildForm//BaseToolbarForm//
    {
        protected BindingList<TariffInternationalModel> Tariffs { get; set; }
        protected PackageTypeDataManager PackageTypeDataManager { get; set; }
        protected CurrencyDataManager CurrencyDataManager { get; set; }

        public ManagePublishedInternationalTariffForm()
        {
            InitializeComponent();

            form = this;
        }

        protected override void BindDataSource<T>()
        {
            CurrentModel = LoadModel<T>(WhereTerm.Default("DOMESTIK", "code", EnumSqlOperator.NotEqual));
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            Tariffs = new BindingList<TariffInternationalModel>();
            PackageTypeDataManager = new PackageTypeDataManager();
            CurrencyDataManager = new CurrencyDataManager();

            NavigationMenu.DeleteStrip.Enabled = false;
            NavigationMenu.NewStrip.Enabled = false;

            tsBaseBtn_New.Enabled = false;
            tsBaseBtn_Delete.Enabled = false;

            grid.DataSource = Tariffs;
            grid.EmbeddedNavigator.ButtonClick += NavigatorClick;

            lookupRepoPackageType.LookupPopup = new PackageTypePopup();
            lookupRepoPackageType.AutoCompleteDataManager = new PackageTypeDataManager();
            lookupRepoPackageType.AutoCompleteDisplayFormater = model => ((PackageTypeModel)model).Name;
            lookupRepoPackageType.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            lookupRepoCurrency.LookupPopup = new CurrencyPopup();
            lookupRepoCurrency.AutoCompleteDataManager = new CurrencyDataManager();
            lookupRepoCurrency.AutoCompleteDisplayFormater = model => ((CurrencyModel)model).Code;
            lookupRepoCurrency.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("code.StartsWith(@0)", s);

            gridColumn2.ColumnEdit = new TextEditRepo();
            ((TextEditRepo)gridColumn2.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            ((TextEditRepo)gridColumn2.RealColumnEdit).Mask.EditMask = @"###,###,##0.0";
            ((TextEditRepo)gridColumn2.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;

            gridColumn3.ColumnEdit = new TextEditRepo();
            ((TextEditRepo)gridColumn3.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            ((TextEditRepo)gridColumn3.RealColumnEdit).Mask.EditMask = @"###,###,##0.0";
            ((TextEditRepo)gridColumn3.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;

            gridColumn4.ColumnEdit = new TextEditRepo();
            ((TextEditRepo)gridColumn4.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            ((TextEditRepo)gridColumn4.RealColumnEdit).Mask.EditMask = @"###,###,##0.00";
            ((TextEditRepo)gridColumn4.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;

            gridColumn5.ColumnEdit = new TextEditRepo();
            ((TextEditRepo)gridColumn5.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            ((TextEditRepo)gridColumn5.RealColumnEdit).Mask.EditMask = @"###,###,##0.0";
            ((TextEditRepo)gridColumn5.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;

            gridColumn6.ColumnEdit = new TextEditRepo();
            ((TextEditRepo)gridColumn6.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            ((TextEditRepo)gridColumn6.RealColumnEdit).Mask.EditMask = @"###,###,##0.00";
            ((TextEditRepo)gridColumn6.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;


            gridView.RowCellDefaultAlignment += (o, args) =>
            {
                if (args.Column.ColumnEdit is LookupRepo)
                {
                    args.HorzAlignment = HorzAlignment.Near;
                }
            };
        }

        protected override bool ValidateForm()
        {
            return true;
        }

        protected override void PopulateForm(PricingPlanModel model)
        {
            tsBaseTxt_Code.Text = model.Zone;
            txtZoneName.Text = model.Zone;

            Tariffs.RaiseListChangedEvents = false;
            Tariffs.Clear();

            new TariffInternationalDataManager().
                Get<TariffInternationalModel>(WhereTerm.Default(model.Id, "pricing_plan_id")).ForEach(row => Tariffs.Add(row));

            Tariffs.RaiseListChangedEvents = true;
            Tariffs.ResetBindings();

            txtZoneName.Enabled = false;
        }

        protected override PricingPlanModel PopulateModel(PricingPlanModel model)
        {
            gridView.PostEditor();

            return model;
        }

        protected override PricingPlanModel Find(string searchTerm)
        {
            return DataManager.GetFirst<PricingPlanModel>(WhereTerm.Default(searchTerm, "zone"));
        }

        protected override void SaveDetail(bool isUpdate = false)
        {
            base.SaveDetail(isUpdate);

            Tariffs.ForEach(row =>
            {
                row.Createdby = BaseControl.UserLogin;
                row.Createddate = DateTime.Now;
                row.Rowstatus = true;
                row.Rowversion = DateTime.Now;
            });

            new TariffInternationalDataManager().Save(CurrentModel as PricingPlanModel, Tariffs);
        }

        protected void NavigatorClick(object sender, NavigatorButtonClickEventArgs args)
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
        }

        public void DetailNew()
        {
            if (CurrentModel != null && CurrentModel.Id > 0 && gridView.UpdateCurrentRow())
            {
                gridView.ApplyFindFilter("");

                gridView.AddNewRow();
                grid.Focus();
            }
        }

        public void DetailDelete()
        {
            if (gridView.FocusedRowHandle < 0)
            {
                gridView.CancelUpdateCurrentRow();
            }
            else
            {
                gridView.DeleteSelectedRows();
            }
        }

        protected override void RefreshToolbarState()
        {
            base.RefreshToolbarState();

            NavigationMenu.NewStrip.Enabled = false;
            NavigationMenu.DeleteStrip.Enabled = false;

            tsBaseBtn_New.Enabled = false;
            tsBaseBtn_Delete.Enabled = false;
        }
    }
}
