using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Devenlab.Common;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class ManageRouteForm : BaseCrudForm<BranchModel, BranchDataManager>, IGridChildForm//BaseToolbarForm//
    {
        protected BindingList<RouteModel> Routes { get; set; }

        public ManageRouteForm()
        {
            InitializeComponent();

            form = this;
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            EnableBtnSearch = true;
            SearchPopup = new BranchPopup();

            Routes = new BindingList<RouteModel>();

            tsBaseBtn_New.Enabled = false;
            tsBaseBtn_Delete.Enabled = false;

            grid.DataSource = Routes;
            grid.EmbeddedNavigator.ButtonClick += NavigatorClick;

            lookupRepoBranch.LookupPopup = new BranchPopup();
            lookupRepoBranch.AutoCompleteDataManager = new BranchDataManager();
            lookupRepoBranch.AutoCompleteDisplayFormater = model => ((BranchModel)model).Code + " - " + ((BranchModel)model).Name;
            lookupRepoBranch.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("code = @0 OR name.StartsWith(@0)", s);
            lookupRepoBranch.Leave += (o, args) =>
            {
                //if (!gridView.UpdateCurrentRow())
                //{
                //    (o as dLookup).ClearOnLeave = false;
                //    (o as dLookup).Value = null;
                //    (o as dLookup).DisplayString = string.Empty;
                //    (o as dLookup).Text = string.Empty;
                //}

                var view = grid.FocusedView as GridView;
                if (view != null)
                {
                    var origin = (int)view.GetRowCellValue(view.FocusedRowHandle, view.Columns["BranchOrigId"]);
                    var dest = (int)view.GetRowCellValue(view.FocusedRowHandle, view.Columns["BranchDestId"]);

                    if (dest == 0) return;

                    var routegrid = Routes.ToList();
                    if (routegrid.Count == 0) return;
                    var items = routegrid.Where(x => x.BranchOrigId == origin && x.BranchDestId == dest);

                    foreach (var routeModel in from routeModel in items
                        let focusedRow = view.GetFocusedRow()
                        where !routeModel.Equals(focusedRow)
                        where routeModel.BranchOrigId == origin && routeModel.BranchDestId == dest
                        select routeModel)
                    {
                        MessageBox.Show(@"Origin branch dan Destination branch sudah terdaftar");
                        view.SetRowCellValue(view.FocusedRowHandle, view.Columns["BranchDestId"], 0);
                    }

                }
            };

            grid.EmbeddedNavigator.Buttons.Remove.Visible = true;

            gridColumn1.OptionsColumn.AllowEdit = false;

            gridView.RowCellDefaultAlignment += (o, args) =>
            {
                if (args.Column.ColumnEdit is LookupRepo)
                {
                    args.HorzAlignment = HorzAlignment.Near;
                }
            };

            gridView.ValidateRow += (o, args) =>
            {
                var row = (RouteModel)args.Row;

                var dups = from r in Routes.Select((value, index) => new { value, index })
                           where r.value.BranchOrigId == row.BranchOrigId
                                 && r.value.BranchDestId == row.BranchDestId
                                 && r.index != gridView.GetDataSourceRowIndex(args.RowHandle)
                           select r;

                if (dups.Any())
                {
                    args.Valid = false;
                    args.ErrorText = @"Rute untuk asal dan tujuan yang sama sudah terdaftar";
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

            tsBaseTxt_Code.Text = BaseControl.BranchCode;
            PerformFind();
        }

        protected override bool ValidateForm()
        {
            return true;
        }

        protected override bool ValidateFormWithAlert()
        {
            if (Routes.Any(row => row.BranchOrigId == 0))
            {
                MessageBox.Show(@"Origin column is mandatory");
                return false;
            }

            if (Routes.Any(row => row.BranchDestId == 0))
            {
                MessageBox.Show(@"Destination column is mandatory");
                return false;
            }

            if (Routes.Any(row => row.BranchDestId == 0))
            {
                MessageBox.Show(@"Destination Branch column is mandatory");
                return false;
            }

            return true;
        }

        protected override void PopulateForm(BranchModel model)
        {
            tsBaseTxt_Code.Text = model.Code;
            txtBranchName.Text = model.Name;

            Routes.RaiseListChangedEvents = false;
            Routes.Clear();

            new RouteDataManager().
                Get<RouteModel>(WhereTerm.Default(model.Id, "branch_orig_id")).ForEach(row => Routes.Add(row));

            Routes.RaiseListChangedEvents = true;
            Routes.ResetBindings();

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

            Routes.ForEach(row =>
            {
                row.Createdby = BaseControl.UserLogin;
                row.Createddate = DateTime.Now;
                row.Rowstatus = true;
                row.Rowversion = DateTime.Now;
            });

            new RouteDataManager().Save(CurrentModel as BranchModel, Routes);
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
                gridView.FocusedColumn = gridColumn2;

                gridView.SetRowCellValue(gridView.FocusedRowHandle, "BranchOrigId", ((BranchModel)CurrentModel).Id);

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
