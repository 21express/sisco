using System;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Interfaces;

namespace SISCO.Presentation.MasterData.Popup
{
    public partial class BranchPopup : BaseForm, IPopup
    {
        public BranchPopup()
        {
            InitializeComponent();

            Load += LoadGrid;
            btnClear.Click += Clear;
            btnView.Click += FilterData;

            BranchView.RowClick += SelectRow;
            BtnSelect.Click += SelectValue;
        }

        private void LoadGrid(object sender, EventArgs e)
        {
            BranchGrid.DataSource = new BranchDataManager().Get<BranchModel>();
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

        public string SelectedText { get; set; }

        public void SelectRow(object sender, EventArgs e)
        {
            BtnSelect.PerformClick();
        }

        public void SelectValue(object sender, EventArgs e)
        {
            int[] rows = BranchView.GetSelectedRows();

            SelectedValue = Convert.ToInt32(BranchView.GetRowCellValue(rows[0], "Id"));
            SelectedText = BranchView.GetRowCellValue(rows[0], "Name").ToString();

            Hide();
        }
    }
}
