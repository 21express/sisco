using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.App.Finance;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;

namespace SISCO.Presentation.Finance.Forms
{
    public partial class TitipInvoiceListForm : BaseForm
    {
        public TitipInvoiceListForm()
        {
            InitializeComponent();

            form = this;
            Load += TitipInvoiceListLoad;
            btnExcel.Click += (sender, args) => ExportExcel(GridTitipInvoice);
            
            TitipInvoiceView.CustomColumnDisplayText += NumberGrid;

            btnView.Click += (sender, args) => LoadGrid();
        }

        private void LoadGrid()
        {
            var param = new List<WhereTerm>();
            param.Add(WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals));
            
            var dateNull = new DateTime(1900, 1, 1, 0, 0, 0);
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            if (tbxFrom.Value > dateNull)
            {
                var fdate = new DateTime(tbxFrom.Value.Year, tbxFrom.Value.Month, tbxFrom.Value.Day, 0, 0, 0);
                param.Add(WhereTerm.Default(fdate, "date_process", EnumSqlOperator.GreatThanEqual));
            }

            if (tbxTo.Value > dateNull)
            {
                var ldate = new DateTime(tbxTo.Value.Year, tbxTo.Value.Month, tbxTo.Value.Day, 23, 59, 59);
                param.Add(WhereTerm.Default(ldate, "date_process", EnumSqlOperator.LesThanEqual));
            }

            if (tbxOrigin.Value != null)
            {
                param.Add(WhereTerm.Default((int)tbxOrigin.Value, "owner_branch_id", EnumSqlOperator.Equals));
            }

            if (tbxCustomer.Value != null)
            {
                param.Add(WhereTerm.Default((int)tbxCustomer.Value, "customer_id", EnumSqlOperator.Equals));
            }

            IListParameter[] p = null;
            if (param.Any())
            {
                // ReSharper disable once CoVariantArrayConversion
                p = param.ToArray();
            }

            var titip = new OtherInvoiceDataManager().Get<OtherInvoiceModel>(p);
            GridTitipInvoice.DataSource = titip;
            TitipInvoiceView.RefreshData();

            var total = titip.Sum(x => x.Total);
            var payOut = titip.Sum(x => x.OutTotalPayment);

            tbxOutstanding.SetValue(total - payOut);
        }

        private void TitipInvoiceListLoad(object sender, EventArgs e)
        {
            ClearForm();

            var now = DateTime.Now;
            tbxFrom.Text = (new DateTime(now.Year, now.Month, 1, 0, 0, 0)).ToString(CultureInfo.InvariantCulture);
            tbxTo.Text = (new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month), 23, 59, 59)).ToString(CultureInfo.InvariantCulture);

            tbxOrigin.LookupPopup = new BranchPopup();
            tbxOrigin.AutoCompleteDataManager = new BranchDataManager();
            tbxOrigin.AutoCompleteDisplayFormater = model => ((BranchModel)model).Code + " - " + ((BranchModel)model).Name;
            tbxOrigin.AutoCompleteWhereExpression +=
                (s, param) => param.SetWhereExpression("code = @0 or name.StartsWith(@0)", s);

            tbxCustomer.LookupPopup =
                    new CustomerPopup(new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals) });
            tbxCustomer.AutoCompleteDataManager = new CustomerDataManager();
            tbxCustomer.AutoCompleteDisplayFormater =
                model => ((CustomerModel)model).Code + " - " + ((CustomerModel)model).Name;
            tbxCustomer.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND branch_id = @1", s,
                    BaseControl.BranchId);
        }
    }
}