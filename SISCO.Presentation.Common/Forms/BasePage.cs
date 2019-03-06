using System;
using System.Collections.Generic;
using System.Linq;
using Devenlab.Common;
using Devenlab.Common.Interfaces;

namespace SISCO.Presentation.Common.Forms
{
    public partial class BasePage : BaseForm
    {
        public IListParameter[] AutoCompleteWheretermFormater { get; set; }

        public string PagingState
        {
            get { return string.Format("Page {0} of {1}", CurrentIndexPage, TotalPage); }
        }

        protected virtual IEnumerable<T> GotoFirstPage<T>(object sender, EventArgs e) where T : IBaseModel
        {
            CurrentIndexPage = 1;
            return BindListDataSource<T>();
        }

        protected virtual IEnumerable<T> GotoPreviousPage<T>(object sender, EventArgs e) where T : IBaseModel
        {
            CurrentIndexPage--;
            return BindListDataSource<T>();
        }

        protected virtual IEnumerable<T> GotoNextPage<T>(object sender, EventArgs e) where T : IBaseModel
        {
            CurrentIndexPage++;
            return BindListDataSource<T>();
        }

        protected virtual IEnumerable<T> GotoLastPage<T>(object sender, EventArgs e) where T : IBaseModel
        {
            CurrentIndexPage = TotalPage;
            return BindListDataSource<T>();
        }

        protected virtual IEnumerable<T> BindListDataSource<T>() where T : IBaseModel
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

        protected virtual IEnumerable<T> GetFromDataManager<T>(Paging paging, out int count, IListParameter[] parameters) where T : IBaseModel
        {
            return DataManager.Get<T>(paging, out count, parameters);
        }
    }
}