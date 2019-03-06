using System;
using System.Collections.Generic;
using System.Linq;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using SISCO.App.Administration;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;

namespace SISCO.Presentation.Administration.Forms.Popup
{
    public partial class PodInPopup : BaseSearchCode<PodInModel.PodInLookupDataRow, PodInDataManager>//BaseSearchPopup//
    {
        public PodInPopup()
        {
            InitializeComponent();


            var clCode = new GridColumn
            {
                Name = "clCode",
                Caption = @"Code",
                FieldName = "Code",
                VisibleIndex = 0,
                Width = 75
            };

            var clArchive = new GridColumn
            {
                Name = "clArcive",
                Caption = "Archive",
                FieldName = "ArchiveLocation",
                VisibleIndex = 1,
                Width = 75
            };

            var clStt = new GridColumn
            {
                Name = "clStt",
                Caption = @"STT",
                FieldName = "ShipmentCode",
                VisibleIndex = 2
            };

            var clDate = new GridColumn
            {
                Name = "clDate",
                Caption = @"Date",
                FieldName = "Vdate",
                VisibleIndex = 3,
                Width = 60
            };

            clDate.DisplayFormat.FormatString = "dd-MM-yyyy";
            clDate.DisplayFormat.FormatType = FormatType.DateTime;

            CodeColumn = "Code";
            SortColumn = "Code";
            SortDirection = "ASC";

            SearchView.Columns.AddRange(new[] { clCode, clArchive, clStt, clDate });
            SearchView.GridControl = GridSearch;
            Load += OnLoad;
            DataManager.DefaultParameters = new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals) };
        }

        private void OnLoad(object sender, EventArgs e)
        {
        }

        protected override void BeforeFilter()
        {
            var p = new List<IListParameter>();

            p.Add(WhereTerm.Default(BaseControl.BranchId, "branch_id"));

            if (!string.IsNullOrEmpty(tbxCode.Text)) p.Add(WhereTerm.Default(tbxCode.Text, "code", EnumSqlOperator.Like));
            if (!string.IsNullOrEmpty(txtShipmentNumber.Text)) p.Add(WhereTerm.Default(txtShipmentNumber.Text, "shipment_code"));

            if (txtDateFrom.DateTime != DateTime.MinValue) p.Add(WhereTerm.Default(txtDateFrom.DateTime, "vdate", EnumSqlOperator.GreatThanEqual));
            if (txtDateTo.DateTime != DateTime.MinValue) p.Add(WhereTerm.Default(txtDateTo.DateTime, "vdate", EnumSqlOperator.LesThanEqual));

            // ReSharper disable once CoVariantArrayConversion
            if (p.Any()) AutoCompleteWheretermFormater = p.ToArray();
        }

        protected override IEnumerable<T> GetFromDataManager<T>(Paging paging, out int count, IListParameter[] parameters)
        {
            return ((PodInDataManager)DataManager).GetJoinShipment(paging, out count, parameters).Cast<T>();
        }
    }
}
