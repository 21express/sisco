using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
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
    public partial class ManageAirlineTariffForm : BaseCrudForm<AirlineModel, AirlineDataManager>, IGridChildForm//BaseToolbarForm//
    {
        protected BindingList<AirlineTariffModel> Tariffs { get; set; }

        public ManageAirlineTariffForm()
        {
            InitializeComponent();

            form = this;
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            EnableBtnSearch = true;
            SearchPopup = new AirlinePopup();

            Tariffs = new BindingList<AirlineTariffModel>();

            NavigationMenu.DeleteStrip.Enabled = false;
            NavigationMenu.NewStrip.Enabled = false;

            tsBaseBtn_New.Enabled = false;
            tsBaseBtn_Delete.Enabled = false;

            grid.DataSource = Tariffs;
            grid.EmbeddedNavigator.ButtonClick += NavigatorClick;

            lookupRepoAirport.LookupPopup = new AirportPopup();
            lookupRepoAirport.AutoCompleteDataManager = new AirportDataManager();
            lookupRepoAirport.AutoCompleteDisplayFormater = model => ((AirportModel)model).Code + " - " + ((AirportModel)model).Name;
            lookupRepoAirport.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("code = @0 OR name.StartsWith(@0)", s);

            OriginAirportCode.ColumnEdit = lookupRepoAirport;
            DestinationAirportCode.ColumnEdit = lookupRepoAirport;

            gridView.RowCellDefaultAlignment += (o, args) =>
            {
                if (args.Column.ColumnEdit is LookupRepo)
                {
                    args.HorzAlignment = HorzAlignment.Near;
                }
            };

            gridView.ValidateRow += (o, args) =>
            {
                var row = (AirlineTariffModel)args.Row;

                if (row.AirlineOrigId == 0 || row.AirlineDestId == 0)
                {
                    args.Valid = false;
                    args.ErrorText = @"Kota asal dan kota tujuan harus diisi";
                    return;
                }

                var dups = from r in Tariffs.Select((value, index) => new { value, index })
                           where r.value.AirlineOrigId == row.AirlineOrigId
                                 && r.value.AirlineDestId == row.AirlineDestId
                                 && r.value.ServiceTypeId == row.ServiceTypeId
                                 && r.index != gridView.GetDataSourceRowIndex(args.RowHandle)
                           select r;

                if (dups.Any())
                {
                    args.Valid = false;
                    args.ErrorText = @"Tariff untuk asal dan tujuan yang sama sudah terdaftar";
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

        protected override bool ValidateFormWithAlert()
        {
            if (Tariffs.Any(row => row.AirlineOrigId == 0))
            {
                MessageBox.Show(@"Origin Airport column is mandatory");
                return false;
            }

            if (Tariffs.Any(row => row.AirlineDestId == 0))
            {
                MessageBox.Show(@"Destination Airport column is mandatory");
                return false;
            }

            if (!gridView.PostEditor() || !gridView.UpdateCurrentRow()) return false;

            return true;
        }

        protected override void PopulateForm(AirlineModel model)
        {
            tsBaseTxt_Code.Text = model.Code;
            txtAirlineName.Text = model.Name;

            Tariffs.RaiseListChangedEvents = false;
            Tariffs.Clear();

            new AirlineTariffDataManager().
                Get<AirlineTariffModel>(WhereTerm.Default(model.Id, "airline_id")).ForEach(row => Tariffs.Add(row));

            Tariffs.RaiseListChangedEvents = true;
            Tariffs.ResetBindings();

            txtAirlineName.Enabled = false;
        }

        protected override AirlineModel PopulateModel(AirlineModel model)
        {
            gridView.PostEditor();

            return model;
        }

        protected override AirlineModel Find(string searchTerm)
        {
            return DataManager.GetFirst<AirlineModel>(WhereTerm.Default(searchTerm, "Code"));
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

            new AirlineTariffDataManager().Save(CurrentModel as AirlineModel, Tariffs);
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
