using System;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Interfaces;

namespace SISCO.Presentation.MasterData.Popup
{
    public partial class CountryPopup : BaseForm, IPopup
    {
        public CountryPopup()
        {
            InitializeComponent();

            Load += LoadGrid;
            btnClear.Click += Clear;
            btnView.Click += FilterData;

            CountryView.RowClick += SelectRow;
            BtnSelect.Click += SelectValue;
        }

        private void LoadGrid(object sender, EventArgs e)
        {
            CountryGrid.DataSource = new CountryDataManager().Get<CountryModel>();
        }

        protected void Clear(object sender, EventArgs e)
        {
            tbxCode.Text = string.Empty;
            tbxName.Text = string.Empty;
        }

        protected void FilterData(object sender, EventArgs e)
        {
            
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
            int[] rows = CountryView.GetSelectedRows();

            SelectedValue = Convert.ToInt32(CountryView.GetRowCellValue(rows[0], "Id"));
            SelectedCode = CountryView.GetRowCellValue(rows[0], "Code").ToString();
            SelectedText = CountryView.GetRowCellValue(rows[0], "Name").ToString();

            Hide();
        }
    }
}
