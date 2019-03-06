using System;
using System.Linq.Dynamic;
using System.Windows.Forms;
using Devenlab.Common;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Properties;

namespace SISCO.Presentation.MasterData.Forms
{
    public partial class ManageDivisionForm : BaseForm
    {
        public ManageDivisionForm()
        {
            InitializeComponent();

            form = this;
            Load += DivisionLoad;

            DataManager = new DivisionDataManager();
            CurrentModel = new DivisionModel();

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
                    ((DivisionDataManager)DataManager).DeActive(CurrentModel.Id, BaseControl.UserLogin, DateTime.Now);

                    btnSave.Enabled = false;
                    btnDelete.Enabled = false;
                    CurrentModel = new DivisionModel();
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

            if (CurrentModel.Id > 0)
            {
                var model = DataManager.GetFirst<DivisionModel>(WhereTerm.Default(CurrentModel.Id, "id", EnumSqlOperator.Equals));
                model.Name = tbxName.Text;
                model.Modifiedby = BaseControl.UserLogin;
                model.Modifieddate = DateTime.Now;

                ((DivisionDataManager)DataManager).Update<DivisionModel>(model);
            }
            else
            {
                var model = new DivisionModel();
                model.Rowstatus = true;
                model.Rowversion = DateTime.Now;
                model.Name = tbxName.Text;
                model.Createdby = BaseControl.UserLogin;
                model.Createddate = DateTime.Now;

                ((DivisionDataManager)DataManager).Save<DivisionModel>(model);
            }

            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            tbxName.Clear();
            tbxName.Focus();

            LoadGrid();
        }

        private void New(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnDelete.Enabled = false;

            tbxName.Clear();
            tbxName.Focus();
            CurrentModel = new DivisionModel();
        }

        private void ShowData(object sender, EventArgs e)
        {
            var rows = DivisionView.GetSelectedRows();

            if (rows.Count() > 0)
            {
                CurrentModel = new DivisionModel();
                CurrentModel.Id = Convert.ToInt32(DivisionView.GetRowCellValue(rows[0], "Id"));
                tbxName.Text = DivisionView.GetRowCellValue(rows[0], "Name").ToString();

                tbxName.Focus();
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void DivisionLoad(object sender, EventArgs e)
        {
            ClearForm();

            btnNew.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;

            LoadGrid();
        }

        private void LoadGrid()
        {
            var costtype = DataManager.Get<DivisionModel>();
            GridDivision.DataSource = costtype;
            DivisionView.RefreshData();
        }
    }
}
