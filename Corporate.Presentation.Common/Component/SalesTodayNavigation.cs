using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Corporate.Presentation.Common.Interfaces;
using DevExpress.XtraGrid.Views.Grid;
using SISCO.Models;

namespace Corporate.Presentation.Common.Component
{
    public partial class SalesTodayNavigation : UserControl
    {
        private BindingList<FranchiseCommissionModel> _commissions;
        public Type CallingCommand { get; set; }

        public SalesTodayNavigation()
        {
            InitializeComponent();
            
            //SalesGrid.DoubleClick += (sender, args) => OpenRelatedForm(SalesView, new counter());
        }

        protected void OpenRelatedForm(GridView grid, IChildForm relatedForm, string code = "Code")
        {
            var rows = grid.GetSelectedRows();

            if (rows.Count() > 0)
            {
                BaseControl.OpenRelatedForm(relatedForm, grid.GetRowCellValue(rows[0], code).ToString(), CallingCommand);
            }
        }

        public void Init()
        {
            _commissions = new BindingList<FranchiseCommissionModel>();
            SalesGrid.DataSource = _commissions;
        }

        public void Reset()
        {
            _commissions.RaiseListChangedEvents = false;
            _commissions.Clear();
        }

        public void RefreshSales()
        {
            if (string.IsNullOrEmpty(BaseControl.UserLogin)) return;

            _commissions.RaiseListChangedEvents = false;
            _commissions.Clear();

            //new FranchiseCommissionDataManager().
            //        GetActiveCommission(BaseControl.FranchiseId)
            //        .ForEach(r => _commissions.Add(r));

            _commissions.RaiseListChangedEvents = true;
            _commissions.ResetBindings();
        }

        public void SetTimer(bool enabled)
        {
            timer1.Enabled = enabled;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(BaseControl.UserLogin)) RefreshSales();
        }
    }
}
