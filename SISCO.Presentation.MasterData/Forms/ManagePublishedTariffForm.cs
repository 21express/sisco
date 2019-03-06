using System;
using System.ComponentModel;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common.Interfaces;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using System.Data;
using System.Collections.Generic;

namespace SISCO.Presentation.MasterData.Forms
{
    public partial class ManagePublishedTariffForm : BaseCrudForm<CityModel, CityDataManager>, IGridChildForm//BaseToolbarForm//
    {
        protected BindingList<TariffModel> Tariffs { get; set; }
        protected ServiceTypeDataManager ServiceTypeDataManager { get; set; }
        protected CityDataManager CityDataManager { get; set; }
        protected CountryDataManager CountryDataManager { get; set; }
        private List<int> DeletedRows { get; set; }

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

            btnAddToAll.Enabled = false;
            btnExport.Enabled = false;
            btnImport.Enabled = false;
            txtAddToAll.EditMask = "###,###,##0";

            gridColumn4.ColumnEdit = new TextEditRepo();
            ((TextEditRepo)gridColumn4.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            ((TextEditRepo)gridColumn4.RealColumnEdit).Mask.EditMask = @"###,###,##0";
            ((TextEditRepo)gridColumn4.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;

            gridColumn5.ColumnEdit = new TextEditRepo();
            ((TextEditRepo)gridColumn5.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            ((TextEditRepo)gridColumn5.RealColumnEdit).Mask.EditMask = @"###,###,##0";
            ((TextEditRepo)gridColumn5.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;

            grid.DataSource = Tariffs;
            grid.EmbeddedNavigator.ButtonClick += NavigatorClick;

            lookupRepoCity.LookupPopup = new CityPopup();
            lookupRepoCity.AutoCompleteDataManager = new CityDataManager();
            lookupRepoCity.AutoCompleteDisplayFormater = model => ((CityModel)model).Name;
            lookupRepoCity.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("name.StartsWith(@0)", s);

            lookupRepoServiceType.LookupPopup = new ServiceTypePopup();
            lookupRepoServiceType.AutoCompleteDataManager = new ServiceTypeDataManager();
            lookupRepoServiceType.AutoCompleteDisplayFormater = model => ((ServiceTypeModel)model).Name;
            lookupRepoServiceType.AutoCompleteWheretermFormater = s => new IListParameter[] {WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)};

            gridView.SortInfo.ClearAndAddRange(new[] { 
                  new GridColumnSortInfo(gridView.Columns["CityDestId"], ColumnSortOrder.Ascending)
            });
            gridView.OptionsFind.FindFilterColumns = "CityDestId";

            gridView.RowCellDefaultAlignment += (o, args) =>
            {
                if (args.Column.ColumnEdit is LookupRepo)
                {
                    args.HorzAlignment = HorzAlignment.Near;
                }
            };

            lkpFilter.LookupPopup = new CityPopup();
            lkpFilter.AutoCompleteDataManager = new CityDataManager();
            lkpFilter.AutoCompleteDisplayFormater = model => ((CityModel)model).Name;
            lkpFilter.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            gridView.CellValueChanged += Changed;

            btnAddToAll.Click += (o, args) =>
            {
                for(var i = 0; i < Tariffs.Count; i++)
                {
                    if (gridView.GetRowCellDisplayText(i, "CityDestId").ToLower().Contains(gridView.FindFilterText.ToLower()))
                    {
                        var newTariff = (decimal) gridView.GetRowCellValue(i, "Tariff") + txtAddToAll.Value;
                        gridView.SetRowCellValue(i, "Tariff", newTariff);
                        gridView.SetRowCellValue(i, "StateChange", EnumStateChange.Insert);
                    }
                }
            };

            btnExport.Click +=
                (o, args) => ExportGridToExcel(gridView, string.Format("MasterData_PublishedTariff_{0}", txtOriginCity.Text));
            btnImport.Click += (o, args) =>
            {
                using (var dialog = new OpenFileDialog())
                {
                    dialog.InitialDirectory = Directory.GetCurrentDirectory();
                    dialog.Filter = @"Microsoft Excel 2007 files (*.xlsx)|*.xlsx|All files (*.*)|*.*";

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        if (!File.Exists(dialog.FileName)) return;

                        var connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0; data source={0}; Extended Properties=\"Excel 12.0 Xml;HDR=YES\"", dialog.FileName);
                        using (var conn = new OleDbConnection(connectionString))
                        {
                            conn.Open();

                            using (var cmd = new OleDbCommand("SELECT * FROM [Sheet$]", conn))
                            {
                                var reader = cmd.ExecuteReader();

                                Tariffs.RaiseListChangedEvents = false;
                                Tariffs.Clear();
                                var i = 1;

                                while (reader != null && reader.Read())
                                {
                                    var destCity = CityDataManager.GetFirst<CityModel>(WhereTerm.Default(reader["Destination"].ToString(), "name"));
                                    if (destCity == null)
                                    {
                                        MessageBox.Show(string.Format("Destination City {0} in row {1} is not recognized", reader["Destination"].ToString(), i));
                                        Tariffs.Clear();
                                        break;
                                    }

                                    var serviceType = ServiceTypeDataManager.GetFirst<ServiceTypeModel>(WhereTerm.Default(reader["Service"].ToString(), "name"));

                                    if (serviceType == null)
                                    {
                                        MessageBox.Show(string.Format("Service Type {0} in row {1} is not recognized", reader["Service"].ToString(), i));
                                        Tariffs.Clear();
                                        break;
                                    }

                                    Tariffs.Add(new TariffModel
                                    {
                                        CityOrigId = CurrentModel.Id,
                                        CityDestId = destCity.Id, 
                                        ServiceTypeId = serviceType.Id, 
                                        PackageTypeId = 1, 
                                        Tariff = Convert.ToDecimal(reader["Tariff"]), 
                                        HandlingFee = Convert.ToDecimal(reader["Handling Fee"]), 
                                        DiscountPercent = 0, 
                                        DiscountFixed = 0,
                                        MinWeight = string.IsNullOrEmpty(reader["Min Weight"].ToString()) ? 0 : Convert.ToDecimal(reader["Min Weight"]),
                                        Ra = reader["RA"].ToString().Equals("Checked"),
                                        OtherFee = 0, 
                                        OtherPercent = 0, 
                                        OtherKg = 0, 
                                        CurrencyId = 1, 
                                        PricingPlanId = 1, 
                                        FromWeight = 0, 
                                        ToWeight = 0, 
		                                Createddate = DateTime.Now, 
		                                Createdby = BaseControl.UserLogin, 
                                        Rowstatus = true,
                                        Rowversion = DateTime.Now,
                                        StateChange = EnumStateChange.Insert,
                                        LeadTime = reader["Lead Time"].ToString()
                                    });

                                    i++;
                                }

                                Tariffs.RaiseListChangedEvents = true;
                                Tariffs.ResetBindings();
                            }

                            conn.Close();
                        }
                    }
                }
            };

            gridView.ValidateRow += (o, args) =>
            {
                var row = (TariffModel)args.Row;

                if (row == null) return;

                if (row.CityOrigId == 0 || row.CityDestId == 0 || row.ServiceTypeId == 0)
                {
                    args.Valid = false;
                    args.ErrorText = @"Kota asal, kota tujuan, dan service type harus diisi";
                    return;
                }

                var dups = from r in Tariffs.Select((value, index) => new { value, index })
                           where r.value.CityOrigId == row.CityOrigId
                                 && r.value.CityDestId == row.CityDestId
                                 && r.value.ServiceTypeId == row.ServiceTypeId
                                 && r.index != gridView.GetDataSourceRowIndex(args.RowHandle)
                           select r;

                if (dups.Any())
                {
                    args.Valid = false;
                    args.ErrorText = @"Tariff untuk asal, tujuan, dan service type yang sama sudah terdaftar";
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

            tsBaseTxt_Code.Text = BaseControl.CityName;
            PerformFind();

            btnFilter.Click += (o, args) =>
            {
                if (lkpFilter.Value != null)
                {
                    gridView.ActiveFilter.Clear();
                    gridView.ActiveFilter.Add(gridView.Columns["CityDestId"], new ColumnFilterInfo("[CityDestId] = " + (int)lkpFilter.Value, ""));
                }
            };

            btnClear.Click += (o, args) => gridView.ActiveFilter.Clear();
        }

        private void Changed(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Name != "clState")
            {
                if (gridView.GetRowCellValue(e.RowHandle, gridView.Columns["StateChange"]).ToString() ==
                    EnumStateChange.Idle.ToString())
                {
                    gridView.SetRowCellValue(e.RowHandle, gridView.Columns["StateChange"], EnumStateChange.Update);
                }
            }
        }

        protected override bool ValidateForm()
        {
            return true;
        }

        protected override bool ValidateFormWithAlert()
        {
            if (!gridView.PostEditor() || !gridView.UpdateCurrentRow()) return false;

            return true;
        }

        protected override void PopulateForm(CityModel model)
        {
            DeletedRows = new List<int>();
            tsBaseTxt_Code.Text = model.Name;
            txtOriginCity.Text = model.Name;

            Tariffs.RaiseListChangedEvents = false;
            Tariffs.Clear();

            new TariffDataManager().
                Get<TariffModel>(WhereTerm.Default(model.Id, "city_orig_id")).ForEach(row => Tariffs.Add(row));

            Tariffs.RaiseListChangedEvents = true;
            Tariffs.ResetBindings();

            txtOriginCity.Enabled = false;
            btnAddToAll.Enabled = true;
            btnExport.Enabled = true;
            btnImport.Enabled = true;
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
                row.Rowstatus = true;
                row.Rowversion = DateTime.Now;
                row.CurrencyId = 1;
            });

            var tdm = new TariffDataManager();
            tdm.Save(CurrentModel as CityModel, Tariffs.Where(r => r.StateChange != EnumStateChange.Idle).ToList());

            foreach (int o in DeletedRows)
            {
                tdm.DeActive(o, BaseControl.UserLogin, DateTime.Now); 
            }

            DeletedRows = new List<int>();
            OpenData(tsBaseTxt_Code.Text);
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

                gridView.SetRowCellValue(gridView.FocusedRowHandle, "CityOrigId", ((CityModel)CurrentModel).Id);
                gridView.SetRowCellValue(gridView.FocusedRowHandle, "StateChange", EnumStateChange.Insert);
                gridView.SetRowCellValue(gridView.FocusedRowHandle, "Ra", false);
                gridView.SetRowCellValue(gridView.FocusedRowHandle, "LeadTime", string.Empty);

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
                var rowHandle = gridView.FocusedRowHandle;
                if (gridView.GetRowCellValue(rowHandle, gridView.Columns["Id"]) != null) DeletedRows.Add((int)gridView.GetRowCellValue(rowHandle, gridView.Columns["Id"]));
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
