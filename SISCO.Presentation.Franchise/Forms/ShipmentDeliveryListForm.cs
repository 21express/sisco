using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.App.Franchise;
using SISCO.App.MasterData;
using SISCO.App.Operation;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.CustomerService.Forms;
using SISCO.Presentation.Franchise.Popup;
using SISCO.Presentation.MasterData.Popup;

namespace SISCO.Presentation.Franchise.Forms
{
    public partial class ShipmentDeliveryListForm : BasePage
    {
        public ShipmentDeliveryListForm()
        {
            InitializeComponent();

            Load += ShipmentDeliveryLoad;
        }

        private void ShipmentDeliveryLoad(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            tbxFrom.DateTime = new DateTime(now.Year, now.Month, now.Day);
            tbxTo.DateTime = new DateTime(now.Year, now.Month, now.Day);

            tbxFrom.FieldLabel = "Date From";
            tbxFrom.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };
            tbxTo.FieldLabel = "Date To";
            tbxTo.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            txtTotalPieces.Enabled = false;
            txtTotalChargeableWeight.Enabled = false;

            tbxFranchise.LookupPopup = new FranchisePopup();
            tbxFranchise.AutoCompleteDataManager = new FranchiseDataManager();
            tbxFranchise.AutoCompleteDisplayFormater = model => ((FranchiseModel)model).Code + " " + ((FranchiseModel)model).Name;
            tbxFranchise.AutoCompleteWhereExpression +=
                (s, param) => param.SetWhereExpression("code.StartsWith(@0) or name.StartsWith(@0)", s);

            tbxBranch.LookupPopup = new BranchPopup();
            tbxBranch.AutoCompleteDataManager = new BranchDataManager();
            tbxBranch.AutoCompleteDisplayFormater = model => ((BranchModel)model).Code + " " + ((BranchModel)model).Name;
            tbxBranch.AutoCompleteWhereExpression +=
                (s, param) => param.SetWhereExpression("code.StartsWith(@0) or name.StartsWith(@0)", s);

            tbxService.LookupPopup = new ServiceTypePopup();
            tbxService.AutoCompleteDataManager = new ServiceTypeDataManager();
            tbxService.AutoCompleteDisplayFormater = model => ((ServiceTypeModel)model).Name;
            tbxService.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            using (var trackingStatusDm = new TrackingStatusDataManager())
            {
                var trackingStatuses =
                    trackingStatusDm.Get<TrackingStatusModel>(WhereTerm.Default(true, "is_final_status")).ToList();

                trackingStatuses.Insert(0, new TrackingStatusModel
                {
                    Id = -1,
                    Code = "Not Available"
                });

                trackingStatuses.Insert(0, new TrackingStatusModel
                {
                    Id = 0,
                    Code = ""
                });

                cmbTrackingStatus.DataSource = trackingStatuses;
            }
            cmbTrackingStatus.ValueMember = "Id";
            cmbTrackingStatus.DisplayMember = "Code";

            grid.DoubleClick += (o, args) =>
            {
                var rows = gridView.GetSelectedRows();

                if (rows.Count() > 0)
                {
                    BaseControl.OpenRelatedForm(new TrackingViewForm(), gridView.GetRowCellValue(rows[0], "Code").ToString(), CallingCommand);
                }
            };

            gridView.RowCellStyle += (o, args) =>
            {
                if (args.RowHandle < 0) return;

                if ((int)gridView.GetRowCellValue(args.RowHandle, "TrackingStatusId") == (int)EnumTrackingStatus.Loss)
                {
                    args.Appearance.ForeColor = Color.Red;
                }
                else if ((int)gridView.GetRowCellValue(args.RowHandle, "TrackingStatusId") ==
                         (int)EnumTrackingStatus.Returned)
                {
                    args.Appearance.ForeColor = Color.Red;
                }
                else if ((int)gridView.GetRowCellValue(args.RowHandle, "TrackingStatusId") ==
                         (int)EnumTrackingStatus.Received)
                {
                    args.Appearance.ForeColor = Color.Blue;
                }
            };

            btnCsv.Click += (s, args) => ExportGridToExcel(gridView, "Franchise_ShipmentList", true, "csv");
            btnExcel.Click += (s, args) => ExportGridToExcel(gridView, "Franchise_ShipmentList");

            btnView.Click += FilterShipment;
            txtTotalPieces.IsNumber = true;
        }

        private void FilterShipment(object sender, EventArgs e)
        {
            var errors = ComponentValidationHelper.Validate(tbxFrom, tbxTo);

            if (errors.Count > 0)
            {
                MessageBox.Show(string.Join("\n", errors));
                return;
            }

            if (tbxTo.Value.Subtract(tbxFrom.Value).Days > 31)
            {
                MessageBox.Show(@"Tidak bisa lebih dari 31 hari");
                return;
            }
            var p = new List<string>();

            p.Add("s.rowstatus = 1");
            p.Add("s.sales_type_id = " + 5);
            if (tbxFrom.DateTime != DateTime.MinValue) p.Add("s.date_process >= '" + tbxFrom.Value.ToString("yyyy-MM-dd") + " 00:00:00'");
            if (tbxTo.DateTime != DateTime.MinValue) p.Add("s.date_process <= '" + tbxTo.Value.ToString("yyyy-MM-dd") + " 23:59:59'");

            if (tbxFranchise.Value != null) p.Add("s.franchise_id = " + tbxFranchise.Value);
            if (tbxBranch.Value != null) p.Add("s.branch_id = " + tbxBranch.Value);
            if (tbxService.Value != null) p.Add("s.service_type_id = " + tbxService.Value);
            txtTotalPieces.Text = @"0";
            txtTotalChargeableWeight.Text = @"0";

            var deliverylist = new ShipmentDataManager().ShipmentDeliveryList(string.Join(" AND ", p.ToArray()));

            if ((int)cmbTrackingStatus.SelectedValue > 0)
            {
                deliverylist = deliverylist.Where(xp => xp.TrackingStatusId == (int)cmbTrackingStatus.SelectedValue).ToList();
            }

            if ((int)cmbTrackingStatus.SelectedValue == -1)
            {
                deliverylist = deliverylist.Where(xp => xp.TrackingStatusId == 0).ToList();
            }

            grid.DataSource = deliverylist;

            txtTotalPieces.Text = deliverylist.Sum(x => x.TtlPiece).ToString("#0");
            txtTotalChargeableWeight.Text = deliverylist.Sum(x => x.TtlChargeableWeight).ToString("#0");
        }
    }
}
