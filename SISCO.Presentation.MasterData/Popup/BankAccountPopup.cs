using Devenlab.Common;
using SISCO.App.MasterData;
using SISCO.Models;
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

namespace SISCO.Presentation.MasterData.Popup
{
    public partial class BankAccountPopup : BaseForm, IPopup
    {
        private bool _sharedAccount { get; set; }
        public BankAccountPopup()
        {
            InitializeComponent();

            Load += BankAccountPopup_Load;
            btnSelect.Click += SelectRow;
            BankView.DoubleClick += SelectRow;
            BankView.CustomColumnDisplayText += NumberGrid;

            _sharedAccount = false;
        }

        public BankAccountPopup(bool sharedAccount)
        {
            InitializeComponent();

            Load += BankAccountPopup_Load;
            btnSelect.Click += SelectRow;
            BankView.DoubleClick += SelectRow;
            BankView.CustomColumnDisplayText += NumberGrid;

            _sharedAccount = sharedAccount;
        }

        void BankAccountPopup_Load(object sender, EventArgs e)
        {
            if (!_sharedAccount)
                GridBank.DataSource = new BankAccountDataManager().Get<BankAccountModel>(WhereTerm.Default(BaseControl.BranchId, "branch_id"));
            else
                GridBank.DataSource = new BankAccountDataManager().GetBankShared(BaseControl.BranchId);
            BankView.RefreshData();
        }

        public int SelectedValue { get; set; }
        public string SelectedCode { get; set; }
        public string SelectedText { get; set; }

        public void SelectRow(object sender, EventArgs e)
        {
            var rows = BankView.GetSelectedRows();

            if (rows.Count() > 0)
            {
                SelectedValue = Convert.ToInt32(BankView.GetRowCellValue(rows[0], "Id"));
                SelectedCode = BankView.GetRowCellValue(rows[0], "AccountNo").ToString();
                SelectedText = BankView.GetRowCellValue(rows[0], "AccountNo").ToString();

                Hide();
            }
            else MessageBox.Show(Resources.alert_choose_data, Resources.information);
        }
    }
}
