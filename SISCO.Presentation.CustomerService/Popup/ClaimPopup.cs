using SISCO.App.CustomerService;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Interfaces;
using SISCO.Presentation.Common.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISCO.Presentation.CustomerService.Popup
{
    public partial class ClaimPopup : BaseForm, IPopup
    {
        public ClaimPopup()
        {
            InitializeComponent();

            btnFilter.Click += btnFilter_Click;
            btnDownload.ButtonClick += btnDownload_ButtonClick;
            ClaimView.CustomColumnDisplayText += NumberGrid;

            btnSelect.Click += SelectRow;
        }

        void btnDownload_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var rows = ClaimView.GetSelectedRows();
            if (rows.Count() > 0)
            {
                if (!string.IsNullOrEmpty(ClaimView.GetRowCellValue(rows[0], "DocName").ToString()))
                {
                    string url = string.Format("{0}api/v1/claimed-doc?filename={1}", BaseControl.SiscoBaseAddressApi, ClaimView.GetRowCellValue(rows[0], "DocName").ToString());
                    System.Diagnostics.Process.Start(url);
                }
            }
        }

        void btnFilter_Click(object sender, EventArgs e)
        {
            GridClaim.DataSource = new ClaimedDataManager().GetPaymentBalanceClaim(BaseControl.BranchId, tbxCustomer.Text, tbxLetterNo.Text);
            ClaimView.RefreshData();
        }

        public int SelectedValue { get; set; }
        public string SelectedCode { get; set; }
        public string SelectedText { get; set; }

        public void SelectRow(object sender, EventArgs e)
        {
            var rows = ClaimView.GetSelectedRows();

            if (rows.Count() > 0)
            {
                SelectedValue = Convert.ToInt32(ClaimView.GetRowCellValue(rows[0], "Id"));
                SelectedCode = ClaimView.GetRowCellValue(rows[0], "LetterNo").ToString();
                SelectedText = ClaimView.GetRowCellValue(rows[0], "CustomerName").ToString();

                Hide();
            }
            else MessageBox.Show(Resources.alert_choose_data, Resources.information);
        }
    }
}
