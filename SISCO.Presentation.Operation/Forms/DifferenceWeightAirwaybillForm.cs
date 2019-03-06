using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.CustomerService.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using Devenlab.Common;

namespace SISCO.Presentation.Operation.Forms
{
    public partial class DifferenceWeightAirwaybillForm : BaseForm
    {
        public DifferenceWeightAirwaybillForm()
        {
            InitializeComponent();
            form = this;

            Load += DifferentWeightAirwaybillForm_Load;
            AirwaybillView.DoubleClick += (s, a) => OpenRelatedForm(AirwaybillView, new TrackingViewForm(), "ShipmentCode");
        }

        void DifferentWeightAirwaybillForm_Load(object sender, EventArgs e)
        {
            tbxFrom.DateTime = DateTime.Now.AddDays(-1);
            tbxTo.DateTime = DateTime.Now;

            btnFilter.Click += btnFilter_Click;
            btnExcel.Click += (a, s) => ExportExcel(GridAirwaybill);
            btnSave.Click += btnSave_Click;

            tbxFrom.Focus();
            btnSave.Enabled = false;

            AirwaybillView.CellValueChanged += AirwaybillView_CellValueChanged;
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            if (AirwaybillView.RowCount > 0)
            {
                var data = GridAirwaybill.DataSource as List<AirwaybillHeavyDifference>;
                var diffs = data.Where(p => p.Diff != null).ToList();
                if (diffs.Count() > 0)
                {
                    foreach (var d in diffs)
                    {
                        if (d.ShipmentId != null)
                        {
                            var se = new ShipmentExpandDataManager().GetFirst<ShipmentExpandModel>(WhereTerm.Default((int)d.ShipmentId, "shipment_id"));
                            if (se != null)
                            {
                                se.DiffCw = d.Diff;
                                new ShipmentExpandDataManager().Update<ShipmentExpandModel>(se);
                            }
                        }
                    }

                    MessageBox.Show("Sudah tersimpan.");
                    btnFilter.PerformClick();
                }
                else MessageBox.Show("Tidak ada selisih kilo yang diupdate.");
            }
        }

        void AirwaybillView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var rowhandle = e.RowHandle;
            var shipmentId = (int) AirwaybillView.GetRowCellValue(rowhandle, AirwaybillView.Columns["ShipmentId"]);
            var diff = (decimal?) AirwaybillView.GetRowCellValue(rowhandle, AirwaybillView.Columns["Diff"]);

            var data = GridAirwaybill.DataSource as List<AirwaybillHeavyDifference>;
            foreach (var d in data)
                if (d.ShipmentId == shipmentId)
                    d.Diff = diff;

            GridAirwaybill.DataSource = data;
            AirwaybillView.RefreshData();
            AirwaybillView.FocusedRowHandle = rowhandle;
        }

        void btnFilter_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            GridAirwaybill.DataSource = new AirwaybillDataManager().GetAirwaybillReportWeight(BaseControl.BranchId, tbxFrom.DateTime, tbxTo.DateTime);
            AirwaybillView.RefreshData();

            if (AirwaybillView.RowCount > 0) btnSave.Enabled = true;
        }
    }
}