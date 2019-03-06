using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using SISCO.App.Finance;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISCO.Presentation.Finance.Popup
{
    public partial class SendInvoiceFilterPopup : BaseSearchCode<OtherInvoiceSendModel, OtherInvoiceSendDataManager>//BaseSearchPopup//
    {
        public SendInvoiceFilterPopup()
        {
            InitializeComponent();
            CodeColumn = "Id";

            form = this;
            var clDate = new GridColumn
            {
                Name = "clDate",
                Caption = @"Date",
                FieldName = "DateProcess",
                VisibleIndex = 0,
                Width = 60
            };

            clDate.DisplayFormat.FormatString = "dd-MM-yyyy";
            clDate.DisplayFormat.FormatType = FormatType.DateTime;

            var clCode = new GridColumn
            {
                Name = "clCode",
                Caption = @"Nomor Surat",
                FieldName = "LetterNo",
                VisibleIndex = 1,
                Width = 75
            };

            var clRefNumber = new GridColumn
            {
                Name = "clRefNumber",
                Caption = @"Ref Number",
                FieldName = "RefNumber",
                VisibleIndex = 2
            };

            SearchView.Columns.AddRange(new[] { clDate, clCode, clRefNumber });
            SearchView.GridControl = GridSearch;

            DataManager.DefaultParameters = new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals) };
        }

        private bool ParamEmpty { get; set; }

        protected override void Filter(object sender, EventArgs e)
        {
            var detail = new OtherInvoiceSendDetailDataManager().Filter(tbxCode.Text, tbxRefNumber.Text, tbxFrom.DateTime, tbxTo.DateTime);
            GridSearch.DataSource = detail;
            SearchView.RefreshData();
        }

        protected override void BeforeFilter()
        {
            throw new NotImplementedException();
        }
    }
}