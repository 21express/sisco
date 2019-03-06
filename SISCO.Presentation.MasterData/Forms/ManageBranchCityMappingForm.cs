using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
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

namespace SISCO.Presentation.MasterData.Forms
{
    public partial class ManageBranchCityMappingForm : BaseCrudForm<BranchModel, BranchDataManager>, IGridChildForm//BaseToolbarForm//
    {
        protected BindingList<BranchCityListModel> Cities { get; set; }

        public ManageBranchCityMappingForm()
        {
            InitializeComponent();

            form = this;
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            Cities = new BindingList<BranchCityListModel>();

            NavigationMenu.NewStrip.Enabled = false;
            NavigationMenu.DeleteStrip.Enabled = false;

            tsBaseBtn_New.Enabled = false;
            tsBaseBtn_Delete.Enabled = false;

            grid.DataSource = Cities;
            grid.EmbeddedNavigator.ButtonClick += NavigatorClick;

            lookupRepoCity.LookupPopup = new CityPopup();
            lookupRepoCity.AutoCompleteDataManager = new CityDataManager();
            lookupRepoCity.AutoCompleteDisplayFormater = model => ((CityModel)model).Name;
            lookupRepoCity.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("name.StartsWith(@0)", s);

            gridView.SortInfo.ClearAndAddRange(new[] { 
                  new GridColumnSortInfo(gridView.Columns["CityId"], ColumnSortOrder.Ascending)
            });

            gridView.RowCellDefaultAlignment += (o, args) =>
            {
                if (args.Column.ColumnEdit is LookupRepo)
                {
                    args.HorzAlignment = HorzAlignment.Near;
                }
            };

            gridView.ValidateRow += (o, args) =>
            {
                var row = (BranchCityListModel)args.Row;

                var dups = from r in Cities.Select((value, index) => new { value, index })
                           where r.value.CityId == row.CityId
                                 && r.index != gridView.GetDataSourceRowIndex(args.RowHandle)
                           select r;

                if (dups.Any())
                {
                    args.Valid = false;
                    args.ErrorText = @"City yang sama sudah terdaftar";
                }
            };

            gridView.InvalidRowException += (o, args) =>
            {
                args.ExceptionMode = ExceptionMode.NoAction;
                MessageBox.Show(args.ErrorText);
            };

            gridView.KeyDown += (o, args) =>
            {
                if (args.KeyCode == Keys.Escape)
                {
                    args.Handled = true;
                }
            };
        }

        protected override bool ValidateForm()
        {
            return true;
        }

        protected override void PopulateForm(BranchModel model)
        {
            tsBaseTxt_Code.Text = model.Code;
            txtBranchName.Text = model.Name;

            Cities.RaiseListChangedEvents = false;
            Cities.Clear();

            new BranchCityListDataManager().
                Get<BranchCityListModel>(WhereTerm.Default(model.Id, "branch_id")).ForEach(row => Cities.Add(row));

            Cities.RaiseListChangedEvents = true;
            Cities.ResetBindings();

            txtBranchName.Enabled = false;
        }

        protected override BranchModel PopulateModel(BranchModel model)
        {
            gridView.PostEditor();

            return model;
        }

        protected override BranchModel Find(string searchTerm)
        {
            return DataManager.GetFirst<BranchModel>(WhereTerm.Default(searchTerm, "Code"));
        }

        protected override void SaveDetail(bool isUpdate = false)
        {
            base.SaveDetail(isUpdate);

            Cities.ForEach(row =>
            {
                row.Createdby = BaseControl.UserLogin;
                row.Createddate = DateTime.Now;
                row.Rowstatus = true;
                row.Rowversion = DateTime.Now;
            });

            new BranchCityListDataManager().Save(CurrentModel as BranchModel, Cities.Where(row => row.CityId != 0).ToList());
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
