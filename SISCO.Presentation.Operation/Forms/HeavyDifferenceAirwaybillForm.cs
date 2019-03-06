using Devenlab.Common;
using SISCO.App.Operation;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;
using SISCO.Presentation.Operation.Popup;
using SISCO.Presentation.Administration.Forms;
using SISCO.App.MasterData;
using Devenlab.Common.Interfaces;

namespace SISCO.Presentation.Operation.Forms
{
    public partial class HeavyDifferenceAirwaybillForm : BaseCrudForm<AirwaybillDifferenceWeightModel, AirwaybillDifferenceWeightDataManager>//BaseToolbarForm//
    {
        FindAirwaybillPopup popup = new FindAirwaybillPopup();
        public HeavyDifferenceAirwaybillForm()
        {
            InitializeComponent();
            form = this;

            Load += HeavyDifferenceAirwaybillForm_Load;
        }

        void HeavyDifferenceAirwaybillForm_Load(object sender, EventArgs e)
        {
            EnableBtnSearch = true;
            SearchPopup = new HeavyDifferenceAirwaybillFilterPopup();

            tbxConsol.Enabled = false;
            btnFind.Enabled = false;
            btnExcel.Enabled = false;

            SmuView.CustomColumnDisplayText += NumberGrid;
            SmuView.RowCellStyle += SmuView_RowCellStyle;

            tbxConsol.KeyDown += tbxConsol_KeyDown;
            btnFind.Click += btnFind_Click;
            btnExcel.Click += btnExcel_Click;

            GridSmu.DoubleClick += GridSmu_DoubleClick;

            DataManager.DefaultParameters = new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "branch_id") };
        }

        void GridSmu_DoubleClick(object sender, EventArgs e)
        {
            if (SmuView.RowCount > 0)
            {
                var rows = SmuView.GetSelectedRows();
                if ((bool)SmuView.GetRowCellValue(rows[0], "IsDiff"))
                    OpenRelatedForm(SmuView, new PODCorrectionForm(), "ShipmentCode");
                else MessageBox.Show("Tidak ada selisih berat");
            }
        }

        void btnExcel_Click(object sender, EventArgs e)
        {
            ExportExcel(GridSmu);
        }

        void SmuView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var view = sender as GridView;
                if (!(bool)view.GetRowCellValue(e.RowHandle, view.Columns["IsDiff"]))
                    e.Appearance.ForeColor = Color.Red;
                else
                    e.Appearance.ForeColor = Color.Black;
            }
        }

        void btnFind_Click(object sender, EventArgs e)
        {
            popup.ShowDialog();
            if (popup.SelectedId.Count > 0)
            {
                foreach (var id in popup.SelectedId)
                {
                    tbxConsol.Text = id.ToString();
                    addRow();
                }
            }
        }

        void addRow()
        {
            if (!string.IsNullOrEmpty(tbxConsol.Text))
            {
                var shipmentIds = new AirwaybillDataManager().GetShipments(Convert.ToInt32(tbxConsol.Text));
                if (shipmentIds.Count > 0)
                {
                    var ids = shipmentIds.Select(p => p.ShipmentId).ToList<int>();
                    var details = GridSmu.DataSource as List<DiffWeightAirwaybillShipmentModel>;

                    if (details.Count > 0)
                    {
                        var temp = ids;
                        ids = new List<int>();
                        foreach (var x in temp)
                        {
                            if (details.Where(p => p.ShipmentId == x).FirstOrDefault() == null) ids.Add(x);
                        }
                    }

                    if (ids.Count > 0)
                    {
                        var shipments = new AirwaybillDifferenceWeightDetailDataManager().AuditSMU(ids);
                        if (shipments.Count() > 0)
                        {
                            details.AddRange(shipments);

                            GridSmu.DataSource = details.OrderBy(p => p.ConsolidationCode).ThenBy(p => p.ShipmentCode).ToList();
                            SmuView.RefreshData();
                        }
                        else MessageBox.Show("Tidak ada nomor POD pada consol tersebut.");
                    }
                }
                else MessageBox.Show(string.Format("ID SMU {0} tidak dikenali", tbxConsol.Text));
            }

            tbxConsol.Clear();
            tbxConsol.Focus();
        }

        void tbxConsol_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) addRow();
        }

        public override void New()
        {
            base.New();

            ClearForm();

            tbxDate.DateTime = DateTime.Now;
            tbxDate.Enabled = false;
            tbxDate.Properties.Buttons[0].Enabled = false;

            GridSmu.DataSource = new List<DiffWeightAirwaybillShipmentModel>();
            SmuView.RefreshData();

            tbxConsol.Enabled = true;
            btnFind.Enabled = true;

            tbxConsol.Focus();
            btnExcel.Enabled = false;
        }

        protected override void SaveDetail(bool isUpdate = false)
        {
            for (int i = 0; i < SmuView.RowCount; i++)
            {
                if (SmuView.GetRowCellValue(i, SmuView.Columns["StateChange"]).ToString() == EnumStateChange.Insert.ToString())
                {
                    var detail = new AirwaybillDifferenceWeightDetailModel();
                    detail.Rowstatus = true;
                    detail.Rowversion = DateTime.Now;
                    detail.AirwaybillDifferenceWeightId = CurrentModel.Id;
                    detail.ShipmentId = (int)SmuView.GetRowCellValue(i, SmuView.Columns["ShipmentId"]);
                    detail.TtlPiecePod = Convert.ToInt16(SmuView.GetRowCellValue(i, SmuView.Columns["TtlPiecePod"]));
                    detail.TtlChargeableWeightPod = (decimal)SmuView.GetRowCellValue(i, SmuView.Columns["TtlChargeableWeightPod"]);
                    detail.ConsolidationId = (int)SmuView.GetRowCellValue(i, SmuView.Columns["ConsolidationId"]);
                    detail.TtlPieceConsol = Convert.ToInt16(SmuView.GetRowCellValue(i, SmuView.Columns["TtlPieceConsol"]));
                    detail.TtlChargeableWeightConsol = (decimal)SmuView.GetRowCellValue(i, SmuView.Columns["TtlChargeableWeightConsol"]);
                    detail.AirwaybillId = (int)SmuView.GetRowCellValue(i, SmuView.Columns["AirwaybillId"]);
                    detail.TtlChargeableWeightAirwaybill = (decimal)SmuView.GetRowCellValue(i, SmuView.Columns["TtlChargeableWeightAirwaybill"]);
                    detail.DiffWeight = (decimal)SmuView.GetRowCellValue(i, SmuView.Columns["DiffWeight"]);
                    detail.IsPacking = (bool)SmuView.GetRowCellValue(i, SmuView.Columns["IsPacking"]);
                    detail.IsDiff = (bool)SmuView.GetRowCellValue(i, SmuView.Columns["IsDiff"]);
                    detail.DiffPercent = (decimal)SmuView.GetRowCellValue(i, SmuView.Columns["DiffPercent"]);
                    detail.Createddate = DateTime.Now;
                    detail.Createdby = BaseControl.UserLogin;

                    new AirwaybillDifferenceWeightDetailDataManager().Save<AirwaybillDifferenceWeightDetailModel>(detail);
                }
            }

            ToolbarCode = CurrentModel.Id.ToString();
        }

        protected override void AfterSave()
        {
            OpenData(ToolbarCode);
        }

        public override void AfterDelete()
        {
            var detail = new AirwaybillDifferenceWeightDetailDataManager().Get<AirwaybillDifferenceWeightDetailModel>(WhereTerm.Default(CurrentModel.Id, "airwaybill_difference_weight_id"));
            foreach (var o in detail) new AirwaybillDifferenceWeightDetailDataManager().DeActive(o.Id, BaseControl.UserLogin, DateTime.Now);

            base.AfterDelete();
        }

        protected override bool ValidateForm()
        {
            if (tbxDate.Text == "")
            {
                tbxDate.Focus();
                return false;
            }

            if (SmuView.RowCount == 0)
            {
                tbxConsol.Focus();
                return false;
            }

            return true;
        }

        protected override void PopulateForm(AirwaybillDifferenceWeightModel model)
        {
            ClearForm();
            tbxConsol.Enabled = false;
            btnFind.Enabled = false;
            btnExcel.Enabled = false;

            if (model == null) return;

            tbxConsol.Enabled = true;
            btnFind.Enabled = true;

            ToolbarCode = model.Id.ToString();
            tbxDate.DateTime = model.DateProcess;
            tbxDate.Enabled = false;
            tbxDate.Properties.Buttons[0].Enabled = false;

            GridSmu.DataSource = new AirwaybillDifferenceWeightDetailDataManager().GetDetails(model.Id);
            SmuView.RefreshData();

            if (SmuView.RowCount > 0) btnExcel.Enabled = true;
        }

        protected override AirwaybillDifferenceWeightModel PopulateModel(AirwaybillDifferenceWeightModel model)
        {
            model.DateProcess = tbxDate.DateTime;
            model.BranchId = BaseControl.BranchId;

            return model;
        }

        protected override AirwaybillDifferenceWeightModel Find(string searchTerm)
        {
            return new AirwaybillDifferenceWeightDataManager().GetFirst<AirwaybillDifferenceWeightModel>(WhereTerm.Default(Convert.ToInt32(searchTerm), "id"));
        }
    }
}