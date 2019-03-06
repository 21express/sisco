using System;
using System.Collections.Generic;
using System.Drawing;
using Devenlab.Common;
using DevExpress.XtraGrid.Views.Grid;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;

namespace SISCO.Presentation.Operation.Forms
{
    public partial class InboundBandaraViewForm : BaseForm
    {
        public InboundBandaraViewForm()
        {
            InitializeComponent();

            form = this;
            DataManager = new AirwaybillDataManager();
            Load += InboundBandaraViewLoad;

            btnView.Click += (sender, args) => LoadGrid();
            
            Shown += (sender, args) =>
            {
                NavigationMenu.NewStrip.Enabled = false;
                NavigationMenu.SaveStrip.Enabled = true;
                NavigationMenu.TopStrip.Enabled = false;
                NavigationMenu.PreviousStrip.Enabled = false;
                NavigationMenu.NewStrip.Enabled = false;
                NavigationMenu.BottomStrip.Enabled = false;
                NavigationMenu.FindStrip.Enabled = false;
                NavigationMenu.RefreshStrip.Enabled = false;
            };

            OnboardView.CustomColumnDisplayText += NumberGrid;
            OnboardView.RowCellStyle += ChangeColor;
            btnExcel.Click += (sender, args) => ExportExcel(GridOnboard);
            GridOnboard.DoubleClick += (sender, args) => OpenRelatedForm(OnboardView, new InboundBandaraForm());
        }

        private void ChangeColor(object sender, RowCellStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var view = sender as GridView;

                if (view != null && (bool)view.GetRowCellValue(e.RowHandle, view.Columns["ActConfirmed"])) e.Appearance.ForeColor = Color.Black;
                else e.Appearance.ForeColor = Color.Red;
            }
        }

        private void InboundBandaraViewLoad(object sender, EventArgs e)
        {
            ClearForm();

            tbxAirline.LookupPopup = new AirlinePopup();
            tbxAirline.AutoCompleteDataManager = new AirlineDataManager();
            tbxAirline.AutoCompleteText = model => ((EmployeeModel)model).Name;
            tbxAirline.AutoCompleteDisplayFormater = model => ((AirlineModel)model).Code + " - " + ((AirlineModel)model).Name;
            tbxAirline.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("code = @0 OR name.StartsWith(@0)", s);

            tbxOrigin.LookupPopup = new AirportPopup();
            tbxOrigin.AutoCompleteDataManager = new AirportDataManager();
            tbxOrigin.AutoCompleteDisplayFormater = model => ((AirportModel)model).Code + " - " + ((AirportModel)model).Name;
            tbxOrigin.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("code = @0 OR name.StartsWith(@0)", s);

            var now = DateTime.Now;
            tbxFrom.Text = new DateTime(now.Year, now.Month, 1).ToString();
            tbxTo.Text = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month)).ToString();
            
            LoadGrid();
        }

        private void LoadGrid()
        {
            var param = new List<WhereTerm>();

            param.Add(WhereTerm.Default(BaseControl.BranchId, "dest_branch_id", EnumSqlOperator.Equals));

            if (tbxFrom.Text == "")
            {
                tbxFrom.Focus();
                return;
            }

            if (tbxTo.Text == "")
            {
                tbxTo.Focus();
                return;
            }

            var fdate = new DateTime(tbxFrom.Value.Year, tbxFrom.Value.Month, tbxFrom.Value.Day, 0, 0, 0);
            param.Add(WhereTerm.Default(fdate, "date_process", EnumSqlOperator.GreatThanEqual));

            var ldate = new DateTime(tbxTo.Value.Year, tbxTo.Value.Month, tbxTo.Value.Day, 23, 59, 59);
            param.Add(WhereTerm.Default(ldate, "date_process", EnumSqlOperator.LesThanEqual));

            if (tbxAirline.Value != null)
            {
                param.Add(WhereTerm.Default((int)tbxAirline.Value, "airline_id", EnumSqlOperator.Equals));
            }

            if (tbxOrigin.Value != null)
            {
                param.Add(WhereTerm.Default((int)tbxOrigin.Value, "airport_id", EnumSqlOperator.Equals));
            }

            // ReSharper disable once CoVariantArrayConversion
            var airwaybill = DataManager.Get<AirwaybillModel>(param.ToArray());

            GridOnboard.DataSource = airwaybill;
        }
    }
}
