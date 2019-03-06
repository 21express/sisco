using Devenlab.Common;
using SISCO.App.Finance;
using SISCO.App.Franchise;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.CustomerService.Forms;
using SISCO.Presentation.Franchise.Popup;
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
    public partial class FranchiseOutstandingShipmentForm : BaseForm
    {
        public FranchiseOutstandingShipmentForm()
        {
            InitializeComponent();
            form = this;

            Load += OutstandingShipmentLoad;
        }

        private void OutstandingShipmentLoad(object sender, EventArgs e)
        {
            OutstandingView.CustomColumnDisplayText += NumberGrid;
            GridOutstanding.DoubleClick += (s, a) => OpenRelatedForm(OutstandingView, new TrackingViewForm());

            lkpFranchise.LookupPopup = new FranchisePopup();
            lkpFranchise.AutoCompleteDataManager = new FranchiseDataManager();
            lkpFranchise.AutoCompleteDisplayFormater = row => string.Format("{0} - {1}", ((FranchiseModel)row).Code, ((FranchiseModel)row).Name);
            if (BaseControl.BranchId != 24)
                lkpFranchise.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("(code.Equals(@0) OR name.StartsWith(@0)) AND branch_id = @1", s, BaseControl.BranchId);
            else lkpFranchise.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("code.Equals(@0) OR name.StartsWith(@0)", s);

            btnLoad.Click += LoadGrid;
            btnExport.Click += (s, a) =>
            {
                ExportExcel(GridOutstanding);
            };
        }

        private void LoadGrid(object sender, EventArgs e)
        {
            var payment = new PaymentMethodDataManager().GetFirst<PaymentMethodModel>(WhereTerm.Default("CASH", "name", EnumSqlOperator.Equals));
            var outstandings = new FranchisePaymentInDataManager().GetOutstandingPayment(lkpFranchise.Value, BaseControl.BranchId, payment.Id);
            GridOutstanding.DataSource = outstandings;
            OutstandingView.RefreshData();
        }
    }
}
