using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraPrinting.Native;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.ComponentRepositories;
using SISCO.Presentation.Common.Forms;
using SISCO.App.MasterData;
using SISCO.Presentation.Common.Interfaces;
using SISCO.Presentation.MasterData.Popup;
using BaseControl = SISCO.Presentation.Common.BaseControl;

namespace SISCO.Presentation.MasterData.Forms
{
    public partial class ManageFlightScheduleForm : BaseCrudForm<AirlineModel, AirlineDataManager>, IGridChildForm//BaseToolbarForm//
    {
        protected BindingList<FlightModel> Schedules { get; set; }
        protected string[] DayNames { get; set; }

        public ManageFlightScheduleForm()
        {
            InitializeComponent();

            form = this;

            //DayNames = CultureInfo.CurrentCulture.DateTimeFormat.DayNames;

            var culture = new System.Globalization.CultureInfo("id-ID");
            DayNames = culture.DateTimeFormat.DayNames;
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            EnableBtnSearch = true;
            SearchPopup = new AirlinePopup();

            Schedules = new BindingList<FlightModel>();

            NavigationMenu.DeleteStrip.Enabled = false;
            NavigationMenu.NewStrip.Enabled = false;

            tsBaseBtn_New.Enabled = false;
            tsBaseBtn_Delete.Enabled = false;


            grid.DataSource = Schedules;
            grid.EmbeddedNavigator.ButtonClick += NavigatorClick;

            timeEditRepoTime1.Mask.MaskType = MaskType.DateTime;
            timeEditRepoTime1.Mask.EditMask = @"HH:mm";
            timeEditRepoTime1.Mask.UseMaskAsDisplayFormat = true;

            comboBoxRepoWeekday.TextEditStyle = TextEditStyles.Standard;
            comboBoxRepoWeekday.DataSource = DayNames.Select((row, i) => new { Id = i, Day = row });
            comboBoxRepoWeekday.DisplayMember = "Day";
            comboBoxRepoWeekday.ValueMember = "Id";
            comboBoxRepoWeekday.Columns.Add(new LookUpColumnInfo("Day"));

            lookupRepoAirport.LookupPopup = new AirportPopup();
            lookupRepoAirport.AutoCompleteDataManager = new AirportDataManager();
            lookupRepoAirport.AutoCompleteDisplayFormater = model => ((AirportModel)model).Code + " - " + ((AirportModel)model).Name;
            lookupRepoAirport.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("code = @0 OR name.StartsWith(@0)", s);

            gridColumnOriginAirport.ColumnEdit = lookupRepoAirport;
            gridColumn4.ColumnEdit = lookupRepoAirport;
            gridColumn5.ColumnEdit = comboBoxRepoWeekday;
            gridColumn6.ColumnEdit = timeEditRepoTime1;
            gridColumn7.ColumnEdit = timeEditRepoTime1;

            clFlightNumber.ColumnEdit = new TextEditRepo
            {
                CharacterCasing = CharacterCasing.Upper
            };

            gridView.RowCellDefaultAlignment += (o, args) =>
            {
                if (args.Column.ColumnEdit is LookupRepo)
                {
                    args.HorzAlignment = HorzAlignment.Near;
                }
            };

            gridView.ValidateRow += (o, args) =>
            {
                var row = (FlightModel)args.Row;

                var dups = from r in Schedules.Select((value, index) => new {value, index})
                           where r.value.FlightNumber == row.FlightNumber
                                 && r.value.OriginAirportId == row.OriginAirportId
                                 && r.value.DestAirportId == row.DestAirportId
                                 && r.value.WeekDay == row.WeekDay
                                 && r.value.EstArrivalTime == row.EstArrivalTime
                                 && r.value.EstDepartureTime == row.EstDepartureTime
                                 && r.index != gridView.GetDataSourceRowIndex(args.RowHandle)
                           select r;

                if (dups.Any())
                {
                    args.Valid = false;
                    args.ErrorText = @"Flight dengan detail yang sama sudah terdaftar";
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
            if (Schedules.Any(row => row.OriginAirportId == 0))
            {
                MessageBox.Show(@"Origin Airport column is mandatory");
                return false;
            }

            if (Schedules.Any(row => row.DestAirportId == 0))
            {
                MessageBox.Show(@"Destination Airport column is mandatory");
                return false;
            }

            if (Schedules.Any(row => string.IsNullOrEmpty(row.FlightNumber)))
            {
                MessageBox.Show(@"Flight Number column is mandatory");
                return false;
            }

            if (Schedules.Any(row => string.IsNullOrEmpty(row.EstDepartureTime)))
            {
                MessageBox.Show(@"Depart Time column is mandatory");
                return false;
            }

            if (Schedules.Any(row => string.IsNullOrEmpty(row.EstArrivalTime)))
            {
                MessageBox.Show(@"Arrival Time column is mandatory");
                return false;
            }

            if (!gridView.PostEditor() || !gridView.UpdateCurrentRow())
            {
                return false;
            }

            
            return true;
        }

        protected override void PopulateForm(AirlineModel model)
        {
            tsBaseTxt_Code.Text = model.Code;
            txtAirlineName.Text = model.Name;

            Schedules.RaiseListChangedEvents = false;
            Schedules.Clear();

            new FlightDataManager().
                Get<FlightModel>(WhereTerm.Default(model.Id, "airline_id")).ForEach(row => Schedules.Add(row));

            Schedules.RaiseListChangedEvents = true;
            Schedules.ResetBindings();

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

            Schedules.ForEach(row =>
            {
                row.EstDepartureTime = DateTime.Parse(row.EstDepartureTime).ToString("HH:mm");
                row.EstArrivalTime = DateTime.Parse(row.EstArrivalTime).ToString("HH:mm");
                row.Createdby = BaseControl.UserLogin;
                row.Createddate = DateTime.Now;
                row.Rowstatus = true;
                row.Rowversion = DateTime.Now;
            });

            new FlightDataManager().Save(CurrentModel as AirlineModel, Schedules);
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
