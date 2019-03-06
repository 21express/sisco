using System;
using Devenlab.Common;
using SISCO.App.MasterData;
using SISCO.Models;
using Corporate.Presentation.Common.Forms;
using Corporate.Presentation.Common.Interfaces;

namespace Corporate.Presentation.MasterData.Popup
{
    public partial class ServiceTypePopup : BaseForm, IPopup
    {
        public string Expression { get; set; }
        public object[] ExpressionParameters { get; set; }

        public ServiceTypePopup()
        {
            InitializeComponent();

            Load += LoadGrid;
            btnClear.Click += Clear;
            btnView.Click += FilterData;

            ServiceTypeView.RowClick += SelectRow;
            BtnSelect.Click += SelectValue;
        }

        public ServiceTypePopup(string expression, params object[] parameters)
        {
            InitializeComponent();

            Load += LoadGrid;
            btnClear.Click += Clear;
            btnView.Click += FilterData;

            ServiceTypeView.RowClick += SelectRow;
            BtnSelect.Click += SelectValue;

            Expression = expression;
            ExpressionParameters = parameters;
        }

        private void LoadGrid(object sender, EventArgs e)
        {
            if (Expression != null && ExpressionParameters != null)
            {
                int totalCount;
                ServiceTypeGrid.DataSource =
                    new ServiceTypeDataManager().Get<ServiceTypeModel>(new Paging {Limit = 99999, Start = 0},
                        out totalCount, Expression, ExpressionParameters);
            }
            else
            {
                ServiceTypeGrid.DataSource = new ServiceTypeDataManager().Get<ServiceTypeModel>();
            }
        }

        protected void Clear(object sender, EventArgs e)
        {
            tbxCode.Text = string.Empty;
            tbxName.Text = string.Empty;
        }

        protected void FilterData(object sender, EventArgs e)
        {
            
        }

        public int SelectedValue { get; set; }
        public string SelectedCode { get; set; }
        public string SelectedText { get; set; }

        public void SelectRow(object sender, EventArgs e)
        {
            BtnSelect.PerformClick();
        }

        public void SelectValue(object sender, EventArgs e)
        {
            int[] rows = ServiceTypeView.GetSelectedRows();

            SelectedValue = Convert.ToInt32(ServiceTypeView.GetRowCellValue(rows[0], "Id"));
            SelectedCode = ServiceTypeView.GetRowCellValue(rows[0], "Name").ToString();
            SelectedText = ServiceTypeView.GetRowCellValue(rows[0], "Name").ToString();

            Hide();
        }
    }
}
