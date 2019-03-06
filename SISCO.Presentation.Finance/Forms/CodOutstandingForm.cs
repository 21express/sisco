using SISCO.App.Finance;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.CustomerService.Forms;
using SISCO.Presentation.MasterData.Popup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISCO.Presentation.Finance.Forms
{
    public partial class CodOutstandingForm : BaseForm
    {
        public CodOutstandingForm()
        {
            InitializeComponent();
            form = this;

            Load += CodOutstandingLoad;
        }

        private void CodOutstandingLoad(object sender, EventArgs e)
        {
            OutstandingView.CustomColumnDisplayText += NumberGrid;
            GridOutstanding.DoubleClick += (s, a) => OpenRelatedForm(OutstandingView, new TrackingViewForm());

            lkpBranch.LookupPopup = new BranchPopup();
            lkpBranch.AutoCompleteDataManager = new BranchDataManager();
            lkpBranch.AutoCompleteDisplayFormater = row => string.Format("{0} - {1}", ((BranchModel)row).Code, ((BranchModel)row).Name);
            if (BaseControl.BranchId != 24) lkpBranch.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("(code.Equals(@0) OR name.StartsWith(@0)) AND id = @1", s, BaseControl.BranchId);
            else lkpBranch.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("code.Equals(@0) OR name.StartsWith(@0)", s);

            btnLoad.Click += LoadGrid;
        }

        private void LoadGrid(object sender, EventArgs e)
        {
            var outstandings = new CodPaymentInDataManager().GetOutstandingPayment(BaseControl.BranchId);
            GridOutstanding.DataSource = outstandings;
            OutstandingView.RefreshData();
        }
    }
}
