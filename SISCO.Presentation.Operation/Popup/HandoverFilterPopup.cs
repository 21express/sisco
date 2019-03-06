using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using SISCO.App.Operation;
using SISCO.Models;
using SISCO.Presentation.Common.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISCO.Presentation.Operation.Popup
{
    public partial class HandoverFilterPopup : BaseSearchCode<SearchHandover, PodHandoverDataManager>//BaseSearchPopup//
    {
        public HandoverFilterPopup()
        {
            InitializeComponent();
            form = this;

            CodeColumn = "Id";
            SortColumn = "DateProcess";

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

            var clId = new GridColumn
            {
                Name = "clId",
                Caption = @"Id",
                FieldName = "Id",
                VisibleIndex = 1,
                Width = 20
            };

            var clPod = new GridColumn
            {
                Name = "clPod",
                Caption = @"No. Pod",
                FieldName = "Code",
                VisibleIndex = 2
            };

            SearchView.Columns.AddRange(new[] { clDate, clId, clPod });
            SearchView.GridControl = GridSearch;

            Shown += FormShow;
        }

        private void FormShow(object sender, EventArgs e)
        {
            ClearForm();
        }

        protected override void BeforeFilter()
        {
            var param = new List<WhereTerm>();

            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            var dateNull = new DateTime(1900, 1, 1, 0, 0, 0);
            if (tbxFrom.Value > dateNull)
            {
                var fdate = new DateTime(tbxFrom.Value.Year, tbxFrom.Value.Month, tbxFrom.Value.Day, 0, 0, 0);
            }

            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            if (tbxTo.Value > dateNull)
            {
                var ldate = new DateTime(tbxTo.Value.Year, tbxTo.Value.Month, tbxTo.Value.Day, 23, 59, 59);
            }

            // ReSharper disable once CoVariantArrayConversion
            if (param.Any()) AutoCompleteWheretermFormater = param.ToArray();
        }

        protected override void Filter(object sender, EventArgs e)
        {

            if (ByPaging)
            {
                PageLimit = 10;
                PagingForm = new Paging
                {
                    Direction = SortDirection,
                    SortColumn = SortColumn
                };

                CurrentFilter = GotoFirstPage<SearchHandover>(sender, e);
            }
            else
            {
                CurrentFilter = BindListDataSource<SearchHandover>();
            }

            GridSearch.DataSource = CurrentFilter;
            SearchView.RefreshData();

            NavigatorPagingState = PagingState;
            GridSearch.Focus();
        }

        protected override IEnumerable<T> BindListDataSource<T>()
        {
            if (DataManager == null)
                throw new Exception("Data Manager Is Not Instansiated");

            int count;

            if (CurrentIndexPage == 0)
            {
                CurrentIndexPage = 1;
            }

            var paging = Paging.Instance(CurrentIndexPage - 1, PageLimit);
            if (PagingForm != null)
            {
                paging = new Paging
                {
                    Direction = PagingForm.Direction,
                    Limit = PageLimit,
                    SortColumn = PagingForm.SortColumn,
                    Start = (CurrentIndexPage - 1) * PageLimit
                };
            }

            var model = GetFromDataManager<T>(paging, out count, AutoCompleteWheretermFormater ?? new IListParameter[] { });

            TotalRecord = count;

            // ReSharper disable once PossibleLossOfFraction
            TotalPage = (int)Math.Ceiling(((double)TotalRecord / (PageLimit == 0 ? 1 : PageLimit)));
            return model.ToList();
        }

        protected override IEnumerable<T> GetFromDataManager<T>(Paging paging, out int count, IListParameter[] parameters)
        {
            var dateNull = new DateTime(1900, 1, 1, 0, 0, 0);
            DateTime? fdate = null;
            DateTime? ldate = null;

            if (!string.IsNullOrEmpty(tbxFrom.Text) && tbxFrom.Value > dateNull)
            {
                fdate = new DateTime(tbxFrom.Value.Year, tbxFrom.Value.Month, tbxFrom.Value.Day, 0, 0, 0);
            }

            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            if (!string.IsNullOrEmpty(tbxTo.Text) && tbxTo.Value > dateNull)
            {
                ldate = new DateTime(tbxTo.Value.Year, tbxTo.Value.Month, tbxTo.Value.Day, 23, 59, 59);
            }

            int? id = null;
            return ((PodHandoverDataManager)DataManager).Search<T>(paging, out count, id, fdate, ldate, tbxPod.Text);
        }
    }
}
