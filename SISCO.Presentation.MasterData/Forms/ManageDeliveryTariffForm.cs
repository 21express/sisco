using System;
using System.ComponentModel;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraGrid.Columns;
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
    public partial class ManageDeliveryTariffForm : BaseCrudForm<PackageTypeModel, PackageTypeDataManager>, IGridChildForm//BaseToolbarForm//
    {
        protected BindingList<DeliveryTariffModel> Tariffs { get; set; }
        protected CityDataManager CityDataManager { get; set; }

        public ManageDeliveryTariffForm()
        {
            InitializeComponent();

            form = this;
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            Tariffs = new BindingList<DeliveryTariffModel>();
            CityDataManager = new CityDataManager();

            NavigationMenu.DeleteStrip.Enabled = false;
            NavigationMenu.NewStrip.Enabled = false;

            tsBaseBtn_New.Enabled = false;
            tsBaseBtn_Delete.Enabled = false;

            btnAddToAll.Enabled = false;
            btnExport.Enabled = false;
            btnImport.Enabled = false;
            txtAddToAll.EditMask = @"###,###,##0";

            grid.DataSource = Tariffs;
            grid.EmbeddedNavigator.ButtonClick += NavigatorClick;

            lookupRepoCity.LookupPopup = new CityPopup();
            lookupRepoCity.AutoCompleteDataManager = new CityDataManager();
            lookupRepoCity.AutoCompleteDisplayFormater = model => ((CityModel)model).Name;
            lookupRepoCity.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("name.StartsWith(@0)", s);

            gridColumn2.ColumnEdit = new TextEditRepo();
            ((TextEditRepo)gridColumn2.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            ((TextEditRepo)gridColumn2.RealColumnEdit).Mask.EditMask = @"###,###,##0";
            ((TextEditRepo)gridColumn2.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;
            gridColumn3.ColumnEdit = new TextEditRepo();
            ((TextEditRepo)gridColumn3.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            ((TextEditRepo)gridColumn3.RealColumnEdit).Mask.EditMask = @"###,###,##0";
            ((TextEditRepo)gridColumn3.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;
            gridColumn4.ColumnEdit = new TextEditRepo();
            ((TextEditRepo)gridColumn4.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            ((TextEditRepo)gridColumn4.RealColumnEdit).Mask.EditMask = @"###,###,##0";
            ((TextEditRepo)gridColumn4.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;
            gridColumn5.ColumnEdit = new TextEditRepo();
            ((TextEditRepo)gridColumn5.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            ((TextEditRepo)gridColumn5.RealColumnEdit).Mask.EditMask = @"###,###,##0";
            ((TextEditRepo)gridColumn5.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;


            gridView.SortInfo.ClearAndAddRange(new[] { 
                  new GridColumnSortInfo(gridView.Columns["DestCityId"], ColumnSortOrder.Ascending)
            });

            gridView.OptionsFind.FindFilterColumns = "DestCityId";

            gridView.RowCellDefaultAlignment += (o, args) =>
            {
                if (args.Column.ColumnEdit is LookupRepo)
                {
                    args.HorzAlignment = HorzAlignment.Near;
                }
            };

            btnAddToAll.Click += (o, args) =>
            {
                for (var i = 0; i < Tariffs.Count; i++)
                {
                    if (gridView.GetRowCellDisplayText(i, "DestCityId").ToLower().Contains(gridView.FindFilterText.ToLower()))
                    {
                        var newTariff = (decimal)gridView.GetRowCellValue(i, "Tariff") + txtAddToAll.Value;
                        gridView.SetRowCellValue(i, "Tariff", newTariff);
                    }
                }
            };

            btnExport.Click +=
                (o, args) => ExportGridToExcel(gridView, string.Format("MasterData_DeliveryTariff_{0}", txtPackageType.Text));
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
                                    var city = CityDataManager.GetFirst<CityModel>(WhereTerm.Default(reader["Destination"].ToString(), "name"));

                                    if (city == null)
                                    {
                                        MessageBox.Show(string.Format("Kota {0} pada baris {1} tidak dikenal. Import data dibatalkan.", reader["Destination"].ToString(), i));
                                        
                                        PerformFind();

                                        break;
                                    }

                                    Tariffs.Add(new DeliveryTariffModel
                                    {
                                        PackageTypeId = CurrentModel.Id,
                                        DestCityId = city.Id,
                                        Tariff = Convert.ToDecimal(reader["Tariff"]),
                                        MinWeight = Convert.ToDecimal(reader["Min Weight"]),
                                        WeightFrom = Convert.ToDecimal(reader["Weight From"]),
                                        WeightTo = Convert.ToDecimal(reader["Weight To"]),
		                                Createddate = DateTime.Now, 
		                                Createdby = BaseControl.UserLogin, 
                                        Rowstatus = true,
                                        Rowversion = DateTime.Now,
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

            Bottom();
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

        protected override void PopulateForm(PackageTypeModel model)
        {
            tsBaseTxt_Code.Text = model.Name;
            txtPackageType.Text = model.Name;

            Tariffs.RaiseListChangedEvents = false;
            Tariffs.Clear();

            new DeliveryTariffDataManager().
                Get<DeliveryTariffModel>(WhereTerm.Default(model.Id, "package_type_id")).ForEach(row => Tariffs.Add(row));

            Tariffs.RaiseListChangedEvents = true;
            Tariffs.ResetBindings();

            txtPackageType.Enabled = false;
            btnAddToAll.Enabled = true;
            btnExport.Enabled = true;
            btnImport.Enabled = true;
        }

        protected override PackageTypeModel PopulateModel(PackageTypeModel model)
        {
            gridView.PostEditor();

            return model;
        }

        protected override PackageTypeModel Find(string searchTerm)
        {
            return DataManager.GetFirst<PackageTypeModel>(WhereTerm.Default(searchTerm, "Name"));
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

            new DeliveryTariffDataManager().Save(CurrentModel as PackageTypeModel, Tariffs);
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
