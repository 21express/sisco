using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common.Forms;
using SISCO.Models.MasterData;
using SISCO.Presentation.Common.Interfaces;

namespace SISCO.Presentation.MasterData.Popup
{
    public partial class TrackingStatusPopup : BaseForm, IPopup
    {
        public TrackingStatusPopup()
        {
            InitializeComponent();

            Load += LoadGrid;
            btnClear.Click += Clear;
            btnView.Click += FilterData;

            TrackingStatusView.RowClick += SelectRow;
            BtnSelect.Click += SelectValue;
        }

        private void LoadGrid(object sender, EventArgs e)
        {
            btnView.PerformClick();
        }

        protected void Clear(object sender, EventArgs e)
        {
            tbxName.Text = string.Empty;
        }

        protected void FilterData(object sender, EventArgs e)
        {
            var parameters = new List<IListParameter>();

            if (!string.IsNullOrEmpty(tbxName.Text)) parameters.Add(WhereTerm.Default(tbxName.Text, "code", EnumSqlOperator.BeginWith));

            TrackingStatusGrid.DataSource = new TrackingStatusDataManager().Get<TrackingStatusModel>(parameters.ToArray());
        }

        public int SelectedValue { get; set; }
        public string SelectedCode { get; set; }

        public string SelectedText { get; set; }

        public void SelectRow(object sender, EventArgs e)
        {
            BtnSelect.PerformClick();
        }

        public void SelectValue(object sender, EventArgs e)
        {
            int[] rows = TrackingStatusView.GetSelectedRows();

            SelectedValue = Convert.ToInt32(TrackingStatusView.GetRowCellValue(rows[0], "Id"));
            SelectedCode = TrackingStatusView.GetRowCellValue(rows[0], "Code").ToString();
            SelectedText = TrackingStatusView.GetRowCellValue(rows[0], "Code").ToString();

            Hide();
        }
    }
}
