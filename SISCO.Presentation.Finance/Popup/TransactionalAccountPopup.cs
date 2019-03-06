using SISCO.App.Finance;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Interfaces;
using SISCO.Presentation.Common.Properties;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using SISCO.Presentation.Common.Component;

namespace SISCO.Presentation.Finance.Popup
{
    public partial class TransactionalAccountPopup : BaseForm, IPopup
    {
        private dLookup _accountLookup { get; set; }
        private bool _isCredit { get; set; }
        public DateTime? paymentDate { get; set; }

        public TransactionalAccountPopup(dLookup accountLookup, bool isCredit)
        {
            InitializeComponent();
            _accountLookup = accountLookup;
            _isCredit = isCredit;

            btnFilter.Click += btnFilter_Click;
            btnSelect.Click += SelectRow;
            btnClose.Click += (s, a) => Hide();
            GridTransactional.DoubleClick += SelectRow;

            Shown += TransactionalAccountPopup_Shown;

            tbxFrom.DateTime = DateTime.Now;
        }

        void TransactionalAccountPopup_Shown(object sender, EventArgs e)
        {
            if (_accountLookup.Value == null)
            {
                MessageBox.Show("Silakan pilih Rekening terlebih dahulu");
                Hide();
            }

            if (paymentDate == null)
            {
                MessageBox.Show("Pilih tanggal terlebih dahulu.");
                Hide();
            }

            tbxFrom.DateTime = (DateTime)paymentDate;
            btnFilter.PerformClick();
            tbxDescription.Focus();
        }

        void btnFilter_Click(object sender, EventArgs e)
        {
            GridTransactional.DataSource = new TransactionalAccountDataManager().SearchPopup(_isCredit, (int)_accountLookup.Value, tbxFrom.DateTime, tbxFrom.DateTime, tbxDescription.Text, tbxAmount.Value);
            TransactionalView.RefreshData();
        }

        public int SelectedValue { get; set; }
        public string SelectedCode { get; set; }
        public string SelectedText { get; set; }

        public void SelectRow(object sender, EventArgs e)
        {
            var rows = TransactionalView.GetSelectedRows();

            if (rows.Count() > 0)
            {
                SelectedValue = Convert.ToInt32(TransactionalView.GetRowCellValue(rows[0], "Id"));
                SelectedCode = TransactionalView.GetRowCellValue(rows[0], "Description").ToString();
                SelectedText = TransactionalView.GetRowCellValue(rows[0], "Total").ToString();

                Hide();
            }
            else MessageBox.Show(Resources.alert_choose_data, Resources.information);
        }
    }
}
