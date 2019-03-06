using System;
using System.ComponentModel;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
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
using System.Collections.Generic;

namespace SISCO.Presentation.MasterData.Forms
{
    public partial class ManageCustomerTariffForm : BaseCrudForm<CustomerModel, CustomerDataManager>, IGridChildForm//BaseToolbarForm//
    {
        protected BindingList<CustomerTariffModel> Tariffs { get; set; }
        protected ServiceTypeDataManager ServiceTypeDataManager { get; set; }
        protected CityDataManager CityDataManager { get; set; }
        private List<int> DeletedRows { get; set; }

        public ManageCustomerTariffForm()
        {
            InitializeComponent();

            form = this;
        }

        protected override void BindDataSource<T>()
        {
            CurrentModel = LoadModel<T>(WhereTerm.Default(BaseControl.BranchId, "branch_id"));
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            DeletedRows = new List<int>();

            EnableBtnSearch = true;
            SearchPopup = new CustomerPopup(WhereTerm.Default(BaseControl.BranchId, "branch_id"));

            Tariffs = new BindingList<CustomerTariffModel>();
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

            gridColumn14.ColumnEdit = new TextEditRepo();
            ((TextEditRepo)gridColumn14.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            ((TextEditRepo)gridColumn14.RealColumnEdit).Mask.EditMask = @"###,###,##0";
            ((TextEditRepo)gridColumn14.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;

            gridColumn5.ColumnEdit = new TextEditRepo();
            ((TextEditRepo)gridColumn5.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            ((TextEditRepo)gridColumn5.RealColumnEdit).Mask.EditMask = @"###,###,##0";
            ((TextEditRepo)gridColumn5.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;

            gridColumn13.ColumnEdit = new TextEditRepo();
            ((TextEditRepo)gridColumn13.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            ((TextEditRepo)gridColumn13.RealColumnEdit).Mask.EditMask = @"###,###,##0";
            ((TextEditRepo)gridColumn13.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;

            grid.DataSource = Tariffs;
            grid.EmbeddedNavigator.ButtonClick += NavigatorClick;

            lookupRepoCity.LookupPopup = new CityPopup();
            lookupRepoCity.AutoCompleteDataManager = new CityDataManager();
            lookupRepoCity.AutoCompleteDisplayFormater = model => ((CityModel)model).Name;
            lookupRepoCity.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("name.StartsWith(@0)", s);

            lookupRepoServiceType.LookupPopup = new ServiceTypePopup();
            lookupRepoServiceType.AutoCompleteDataManager = new ServiceTypeDataManager();
            lookupRepoServiceType.AutoCompleteDisplayFormater = model => ((ServiceTypeModel)model).Name;
            lookupRepoServiceType.AutoCompleteWheretermFormater = s => new IListParameter[] { WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith) };

            lkpFilter.LookupPopup = new CityPopup();
            lkpFilter.AutoCompleteDataManager = new CityDataManager();
            lkpFilter.AutoCompleteDisplayFormater = model => ((CityModel)model).Name;
            lkpFilter.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            gridView.SortInfo.ClearAndAddRange(new[] { 
                  new GridColumnSortInfo(gridView.Columns["CityDestId"], ColumnSortOrder.Ascending)
            });
            gridView.OptionsFind.FindFilterColumns = "CityDestId";

            gridView.CellValueChanged += Changed;

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
                    if (gridView.GetRowCellDisplayText(i, "CityDestId").ToLower().Contains(gridView.FindFilterText.ToLower()))
                    {
                        var newTariff = (decimal)gridView.GetRowCellValue(i, "Tariff") + txtAddToAll.Value;
                        gridView.SetRowCellValue(i, "Tariff", newTariff);
                        gridView.SetRowCellValue(i, "StateChange", EnumStateChange.Insert);
                    }
                }
            };

            btnExport.Click +=
                (o, args) => ExportGridToExcel(gridView, string.Format("MasterData_PublishedTariff_{0}", txtCustomerCode.Text));
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
                                    var originCity = CityDataManager.GetFirst<CityModel>(WhereTerm.Default(reader["Origin"].ToString(), "name"));

                                    if (originCity == null)
                                    {
                                        MessageBox.Show(string.Format("Origin City {0} in row {1} is not recognized", reader["Origin"].ToString(), i));
                                        Tariffs.Clear();
                                        break;
                                    }

                                    var destCity = CityDataManager.GetFirst<CityModel>(WhereTerm.Default(reader["Destination"].ToString(), "name"));

                                    if (destCity == null)
                                    {
                                        MessageBox.Show(string.Format("Destination City {0} in row {1} is not recognized", reader["Destination"].ToString(), i));
                                        Tariffs.Clear();
                                        break;
                                    }

                                    var serviceType = ServiceTypeDataManager.GetFirst<ServiceTypeModel>(WhereTerm.Default(reader["Service"].ToString(), "name"));

                                    //if (serviceType == null)
                                    //{
                                    //    MessageBox.Show(string.Format("Service Type {0} in row {1} is not recognized", reader["Service"].ToString(), i));
                                    //    Tariffs.Clear();
                                    //    break;
                                    //}

                                    Tariffs.Add(new CustomerTariffModel
                                    {
                                        CustomerId = CurrentModel.Id,
                                        CityOrigId = originCity.Id,
                                        CityDestId = destCity.Id, 
                                        ServiceTypeId = serviceType != null ? (int?)serviceType.Id : null, 
                                        PackageTypeId = 1,
                                        Tariff = string.IsNullOrEmpty(reader["Tariff PerKg"].ToString()) ? 0 : Convert.ToDecimal(reader["Tariff PerKg"]),
                                        FixedTariff = string.IsNullOrEmpty(reader["Tariff"].ToString()) ? 0 : Convert.ToDecimal(reader["Tariff"]),
                                        HandlingFee = string.IsNullOrEmpty(reader["Handling Fee"].ToString()) ? 0 : Convert.ToDecimal(reader["Handling Fee"]), 
                                        DiscountPercent = 0, 
                                        DiscountFixed = 0,
                                        MinWeight = string.IsNullOrEmpty(reader["Min Weight"].ToString()) ? 0 : Convert.ToDecimal(reader["Min Weight"]),
                                        Ra = reader["RA"].ToString().Equals("Checked"),
                                        OtherPercent = 0, 
                                        OtherKg = 0, 
                                        CurrencyId = 1, 
                                        PricingPlanId = 0,
                                        FromWeight = string.IsNullOrEmpty(reader[9].ToString()) ? 0 : Convert.ToDecimal(reader[9]),
                                        ToWeight = string.IsNullOrEmpty(reader[10].ToString()) ? 0 : Convert.ToDecimal(reader[10]),
                                        NextTariff = string.IsNullOrEmpty(reader[11].ToString()) ? 0 : Convert.ToDecimal(reader[11]), 
		                                Createddate = DateTime.Now, 
		                                Createdby = BaseControl.UserLogin, 
                                        Rowstatus = true,
                                        Rowversion = DateTime.Now,
                                        StateChange = EnumStateChange.Insert,
                                        Ltime = reader["Lead Time"].ToString()
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
                var row = (CustomerTariffModel) args.Row;

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
                                 && r.value.FromWeight == row.FromWeight
                                 && r.value.ToWeight == row.ToWeight
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

            Top();

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

        protected override void PopulateForm(CustomerModel model)
        {
            tsBaseTxt_Code.Text = model.Code;
            txtCustomerCode.Text = model.Code;
            txtCustomerName.Text = model.Name;

            Tariffs.RaiseListChangedEvents = false;
            Tariffs.Clear();

            new CustomerTariffDataManager().
                Get<CustomerTariffModel>(WhereTerm.Default(model.Id, "customer_id")).ForEach(row => Tariffs.Add(row));

            Tariffs.RaiseListChangedEvents = true;
            Tariffs.ResetBindings();

            txtCustomerCode.Enabled = false;
            txtCustomerName.Enabled = false;
            btnAddToAll.Enabled = true;
            btnExport.Enabled = true;
            btnImport.Enabled = true;

            DeletedRows = new List<int>();
        }

        protected override CustomerModel PopulateModel(CustomerModel model)
        {
            gridView.PostEditor();

            return model;
        }

        protected override CustomerModel Find(string searchTerm)
        {
            return DataManager.GetFirst<CustomerModel>(WhereTerm.Default(searchTerm, "code"), WhereTerm.Default(BaseControl.BranchId, "branch_id"));
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

            new CustomerTariffDataManager().Save(CurrentModel as CustomerModel, Tariffs.Where(r => r.StateChange != EnumStateChange.Idle).ToList());

            var cdm = new CustomerTariffDataManager();
            foreach (int o in DeletedRows)
            {
                cdm.DeActive(o, BaseControl.UserLogin, DateTime.Now);
            }

            DeletedRows = new List<int>();
            OpenData(tsBaseTxt_Code.Text);
        }

        protected void NavigatorClick(object sender, NavigatorButtonClickEventArgs args)
        {
            args.Handled = true;

            switch (args.Button.ButtonType)
            {
                case NavigatorButtonType.Append:
                    DetailNew();
                    break;
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
                gridView.FocusedColumn = gridColumn2;

                gridView.SetRowCellValue(gridView.FocusedRowHandle, "CityOrigId", BaseControl.CityId);
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
                if (gridView.GetRowCellValue(rowHandle, gridView.Columns["Id"]) != null) DeletedRows.Add((int)gridView.GetRowCellValue(gridView.FocusedRowHandle, gridView.Columns["Id"]));
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