using System;
using System.Collections.Generic;
using System.Net.Configuration;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.Patterns;
using DevExpress.XtraEditors;
using Corporate.Presentation.Common.Component;
using Corporate.Presentation.Common.Properties;
using ComboBox = System.Windows.Forms.ComboBox;

namespace Corporate.Presentation.Common.Forms
{
    public abstract class BaseSearchCode<TModel, TManager> : BaseSearchPopup
        where TModel: class, IBaseModel, new ()
        where TManager : BaseDataManager, new ()
    {
        protected abstract void BeforeFilter();
        protected IEnumerable<TModel> CurrentFilter { get; set; }
        public string SortColumn { get; set; }
        public string SortDirection { get; set; }
        public bool ByPaging { get; set; }

        protected BaseSearchCode()
        {
            DataManager = new TManager();

            btnFilter.Click += Filter;
            GridSearch.EmbeddedNavigator.ButtonClick += NavigatorClick;

            SortColumn = "date_process";
            SortDirection = "DESC";

            ByPaging = true;
        }

        private void SelectGridRow(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) SelectRow(sender, e);
        }

        public void SearchCodeLoad(object sender, EventArgs e)
        {
            CurrentIndexPage = 0;
            PageLimit = 10;

            PagingForm = new Paging
            {
                Direction = SortDirection,
                SortColumn = SortColumn
            };

            CurrentFilter = GotoFirstPage<TModel>(sender, e);
            GridSearch.DataSource = CurrentFilter;
            SearchView.RefreshData();

            NavigatorPagingState = PagingState;

            MainContainer.Panel1.KeyPress += (o, args) =>
            {
                if (args.KeyChar == 13) Filter(o, args);
            };
        }

        protected virtual void Filter(object sender, EventArgs e)
        {
            AutoCompleteWheretermFormater = null;

            BeforeFilter();
            if (AutoCompleteWheretermFormater != null)
            {
                if (tbxCode.Text != "")
                {
                    var param = AutoCompleteWheretermFormater;
                    Array.Resize(ref param, param.Length + 1);
                    param[param.Length - 1] = WhereTerm.Default(tbxCode.Text, CodeColumn, EnumSqlOperator.Like);

                    AutoCompleteWheretermFormater = param;
                }
            }
            else
            {
                if (tbxCode.Text != "")
                {
                    AutoCompleteWheretermFormater = new IListParameter[] { WhereTerm.Default(tbxCode.Text, CodeColumn, EnumSqlOperator.Like) };
                }
            }

            var paramEmpty = true;
            foreach (Control o in MainContainer.Panel1.Controls)
            {
                if (o is TextBox)
                {
                    if (o.Text != "")
                    {
                        paramEmpty = false;
                        break;
                    }
                }

                if (o is dTextBox)
                {
                    if (o.Text != "")
                    {
                        paramEmpty = false;
                        break;
                    }
                }

                if (o is dTextBoxNumber)
                {
                    if (o.Text != "")
                    {
                        paramEmpty = false;
                        break;
                    }
                }

                if (o is dCalendar)
                {
                    if (((dCalendar)o).EditValue != null)
                    {
                        paramEmpty = false;
                        o.Focus();
                        break;
                    }
                }

                if (o is dLookupC)
                {
                    if (((dLookupC) o).Value != null)
                    {
                        paramEmpty = false;
                        break;
                    }
                }

                if (o is ComboBox)
                {
                    if (((ComboBox) o).SelectedValue != null)
                    {
                        paramEmpty = false;
                        break;
                    }
                }
            }

            if (paramEmpty)
            {
                MessageBox.Show(@"Masukkan parameter pencarian", Resources.title_information, MessageBoxButtons.OK);
                return;
            }

            if (ByPaging)
            {
                PageLimit = 10;
                PagingForm = new Paging
                {
                    Direction = SortDirection,
                    SortColumn = SortColumn
                };

                CurrentFilter = GotoFirstPage<TModel>(sender, e);
            }
            else
            {
                CurrentFilter = DataManager.Get<TModel>(AutoCompleteWheretermFormater);
            }

            GridSearch.DataSource = CurrentFilter;
            SearchView.RefreshData();

            NavigatorPagingState = PagingState;
            GridSearch.Focus();
        }

        protected override void Clear(object sender, EventArgs e)
        {
            base.Clear(sender, e);

            //var data = GotoFirstPage<TModel>(sender, e);
            GridSearch.DataSource = null;

            //NavigatorPagingState = PagingState;
            NavigatorPagingState = null;
        }

        protected void NavigatorClick(object sender, NavigatorButtonClickEventArgs e)
        {
            IEnumerable<TModel> model;
            switch (e.Button.ImageIndex)
            {
                case 0:
                    model = GotoFirstPage<TModel>(sender, e);
                    GridSearch.DataSource = model;
                    break;
                case 2:
                    model = GotoPreviousPage<TModel>(sender, e);
                    GridSearch.DataSource = model;
                    break;
                case 3:
                    model = GotoNextPage<TModel>(sender, e);
                    GridSearch.DataSource = model;
                    break;
                case 5:
                    model = GotoLastPage<TModel>(sender, e);
                    GridSearch.DataSource = model;
                    break;
            }

            NavigatorPagingState = PagingState;
        }
    }
}
