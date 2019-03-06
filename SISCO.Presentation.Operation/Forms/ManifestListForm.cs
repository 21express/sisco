using System;
using System.Collections.Generic;
using System.Linq;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.App.MasterData;
using SISCO.App.Operation;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;

namespace SISCO.Presentation.Operation.Forms
{
    public partial class ManifestListForm : BaseForm
    {
        public ManifestListForm()
        {
            InitializeComponent();

            form = this;
            Load += ManifestListLoad;
            btnView.Click += (sender, args) => LoadGrid();
            GridManifestList.DoubleClick += (sender, args) => OpenRelatedForm(ManifestListView, new ManifestForm());
            ManifestListView.CustomColumnDisplayText += NumberGrid;
        }

        private void ManifestListLoad(object sender, EventArgs e)
        {
            ClearForm();

            tbxDate.Value = DateTime.Now;

            tbxDestination.LookupPopup = new BranchPopup();
            tbxDestination.AutoCompleteDataManager = new BranchDataManager();
            tbxDestination.AutoCompleteDisplayFormater = model => ((BranchModel)model).Name;
            tbxDestination.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            btnExport.Click += (s, a) => ExportExcel(GridManifestList);
        }

        private void LoadGrid()
        {
            if (string.IsNullOrEmpty(tbxDate.Text))
            {
                tbxDate.Focus();
                return;
            }

            var shipments = new ManifestDataManager().GetManifestList(BaseControl.BranchId, tbxDate.Value, tbxDestination.Value);
            GridManifestList.DataSource = shipments;
        }
    }
}
