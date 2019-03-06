using System;
using System.Linq.Dynamic;
using System.Windows.Forms;
using Devenlab.Common;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Properties;
using SISCO.Presentation.MasterData.Popup;
using Devenlab.Common.Interfaces;

namespace SISCO.Presentation.MasterData.Forms
{
    public partial class ManageCostTypeForm : BaseForm
    {
        public ManageCostTypeForm()
        {
            InitializeComponent();

            form = this;
            Load += CostTypeLoad;

            DataManager = new CostTypeDataManager();
            CurrentModel = new CostTypeModel();

            DivisionView.CustomColumnDisplayText += NumberGrid;
            DivisionView.DoubleClick += ShowData;
            btnNew.Click += New;
            btnSave.Click += Save;
            btnDelete.Click += Delete;
        }

        private void Delete(object sender, EventArgs e)
        {
            if (MessageBox.Show(Resources.delete_confirm_msg, Resources.delete_confirm, MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                if (CurrentModel.Id > 0)
                {
                    ((CostTypeDataManager) DataManager).DeActive(CurrentModel.Id, BaseControl.UserLogin, DateTime.Now);

                    btnSave.Enabled = false;
                    btnDelete.Enabled = false;
                    CurrentModel = new CostTypeModel();
                    tbxName.Clear();
                    tbxName.Focus();

                    LoadGrid();
                }
            }
        }

        private void Save(object sender, EventArgs e)
        {
            if (tbxName.Text == "")
            {
                MessageBox.Show(Resources.alert_empty_field, @"Warning");
                return;
            }

            if (lkpDivision.Value == null)
            {
                MessageBox.Show(Resources.alert_empty_field, @"Warning");
                return;
            }

            if (CurrentModel.Id > 0)
            {
                var model = DataManager.GetFirst<CostTypeModel>(WhereTerm.Default(CurrentModel.Id, "id", EnumSqlOperator.Equals));
                model.Name = tbxName.Text;
                model.DivisionId = lkpDivision.Value;
                model.Modifiedby = BaseControl.UserLogin;
                model.Modifieddate = DateTime.Now;

                ((CostTypeDataManager) DataManager).Update<CostTypeModel>(model);
            }
            else
            {
                var model = new CostTypeModel();
                model.Rowstatus = true;
                model.Rowversion = DateTime.Now;
                model.Name = tbxName.Text;
                model.DivisionId = lkpDivision.Value;
                model.Createdby = BaseControl.UserLogin;
                model.Createddate = DateTime.Now;

                ((CostTypeDataManager)DataManager).Save<CostTypeModel>(model);
            }

            btnSave.Enabled = false;
            btnDelete.Enabled = false;

            ClearForm();
            tbxName.Focus();

            LoadGrid();
        }

        private void New(object sender, EventArgs e)
        {
            ClearForm();
            btnSave.Enabled = true;
            btnDelete.Enabled = false;

            tbxName.Focus();
            CurrentModel = new CostTypeModel();
        }

        private void ShowData(object sender, EventArgs e)
        {
            ClearForm();
            var rows = DivisionView.GetSelectedRows();

            if (rows.Count() > 0)
            {
                CurrentModel = new CostTypeModel();
                CurrentModel.Id = Convert.ToInt32(DivisionView.GetRowCellValue(rows[0], "Id"));
                tbxName.Text = DivisionView.GetRowCellValue(rows[0], "Name").ToString();
                var divisionId = (int?) DivisionView.GetRowCellValue(rows[0], "DivisionId");
                if (divisionId != null) lkpDivision.DefaultValue = new IListParameter[] { WhereTerm.Default((int) divisionId, "id") };

                tbxName.Focus();
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void CostTypeLoad(object sender, EventArgs e)
        {
            ClearForm();

            btnNew.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;

            lkpDivision.LookupPopup = new DivisionPopup();
            lkpDivision.AutoCompleteDataManager = new DivisionDataManager();
            lkpDivision.AutoCompleteDisplayFormater = model => ((DivisionModel)model).Name;
            lkpDivision.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("name.StartsWith(@0)", s);

            LoadGrid();
        }

        private void LoadGrid()
        {
            var costtype = DataManager.Get<CostTypeModel>();
            GridDivision.DataSource = costtype;
            DivisionView.RefreshData();
        }
    }
}