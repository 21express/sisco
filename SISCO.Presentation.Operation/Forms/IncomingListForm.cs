using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Devenlab.Common;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.CustomerService.Forms;
using SISCO.Presentation.MasterData.Popup;
using SISCO.Presentation.Operation.Reports;
using System.Linq;

namespace SISCO.Presentation.Operation.Forms
{
    public partial class IncomingListForm : BaseForm
    {
        public IncomingListForm()
        {
            InitializeComponent();

            form = this;
            Load += IncomingListLoad;
            btnView.Click += (sender, args) => LoadGrid();
            btnExcel.Click += (sender, args) => ExportExcel(GridIncoming);

            IncomingView.RowCellStyle += ChangeColor;
            IncomingView.CustomColumnDisplayText += NumberGrid;
            IncomingView.DoubleClick += (sender, args) => OpenRelatedForm(IncomingView, new TrackingViewForm());

            btnPrint.Click += Print;
            cbxStatus.SelectedValueChanged += (sender, args) => btnView.Focus();
        }

        private void ChangeColor(object sender, RowCellStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var view = sender as GridView;

                if (view != null && (!(bool)view.GetRowCellValue(e.RowHandle, view.Columns["Inbound"])))
                {
                    //e.Appearance.BackColor = Color.DodgerBlue;
                    //e.Appearance.BackColor2 = Color.SeaShell;
                    e.Appearance.ForeColor = Color.Red;
                }

                if (view != null && (view.GetRowCellValue(e.RowHandle, view.Columns["TrackingStatus"]).ToString().ToLower() == EnumTrackingStatus.Loss.ToString().ToLower() ||
                                     view.GetRowCellValue(e.RowHandle, view.Columns["TrackingStatus"]).ToString().ToLower() == EnumTrackingStatus.Received.ToString().ToLower()))
                {
                    //e.Appearance.BackColor = Color.Salmon;
                    //e.Appearance.BackColor2 = Color.SeaShell;
                    e.Appearance.ForeColor = Color.Blue;
                }
            }
        }

        private void IncomingListLoad(object sender, EventArgs e)
        {
            _ClearForm(pnlTop);

            tbxBranch.LookupPopup = new BranchPopup();
            tbxBranch.AutoCompleteDataManager = new BranchDataManager();
            tbxBranch.AutoCompleteDisplayFormater = model => ((BranchModel)model).Code + " - " + ((BranchModel)model).Name;
            tbxBranch.AutoCompleteWhereExpression +=
                (s, param) => param.SetWhereExpression("code = @0 or name.StartsWith(@0)", s);

            var now = DateTime.Now;
            tbxFrom.Text = now.ToString();
            tbxTo.Text = now.ToString();

            var ds = new List<Combo2>
            {
                new Combo2 { Id = 0, Text = "Semua" },
                new Combo2 { Id = (int)EnumTrackingStatus.Received, Text = EnumTrackingStatus.Received.ToString() },
                new Combo2 { Id = (int)EnumTrackingStatus.Returned, Text = EnumTrackingStatus.Returned.ToString() },
                new Combo2 { Id = (int)EnumTrackingStatus.Loss, Text = EnumTrackingStatus.Loss.ToString() },
                new Combo2 { Id = 1000, Text = "Not Available" },
            };

            cbxStatus.DataSource = ds;
            cbxStatus.ValueMember = "Id";
            cbxStatus.DisplayMember = "Text";
        }

        private void LoadGrid()
        {
            if (tbxTo.Value.Subtract(tbxFrom.Value).Days > 31)
            {
                MessageBox.Show(@"Tidak bisa lebih dari 31 hari");
                return;
            }
            var param = new List<WhereTerm>();
            var param2 = new List<WhereTerm>();
            param.Add(WhereTerm.Default(BaseControl.BranchId, "dest_branch_id", EnumSqlOperator.Equals));
            param2.Add(WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals));
            //param.Add(WhereTerm.Default((int) EnumTrackingStatus.Arrival, "tracking_status_id", EnumSqlOperator.Equals));
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse

            var dateNull = new DateTime(1900, 1, 1, 0, 0, 0);
            if (tbxFrom.DateTime > dateNull)
            {
                var fdate = new DateTime(tbxFrom.DateTime.Year, tbxFrom.DateTime.Month, tbxFrom.DateTime.Day, 0, 0, 0);
                param.Add(WhereTerm.Default(fdate, "date_process", EnumSqlOperator.GreatThanEqual));
                param2.Add(WhereTerm.Default(fdate, "date_process", EnumSqlOperator.GreatThanEqual));
            }

            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            if (tbxTo.DateTime > dateNull)
            {
                var ldate = new DateTime(tbxTo.DateTime.Year, tbxTo.DateTime.Month, tbxTo.DateTime.Day, 23, 59, 59);
                param.Add(WhereTerm.Default(ldate, "date_process", EnumSqlOperator.LesThanEqual));
                param2.Add(WhereTerm.Default(ldate, "date_process", EnumSqlOperator.LesThanEqual));
            }

            if (tbxBranch.Value != null)
            {
                param.Add(WhereTerm.Default((int) tbxBranch.Value, "branch_id", EnumSqlOperator.Equals));
                param2.Add(WhereTerm.Default((int)tbxBranch.Value, "dest_branch_id", EnumSqlOperator.Equals));
            }

            // ReSharper disable once CoVariantArrayConversion
            var shipment = new ShipmentDataManager().IncomingList(param.ToArray(), param2.ToArray());
            if ((int)cbxStatus.SelectedValue > 0)
            {
                if ((int)cbxStatus.SelectedValue == 1000)
                    shipment = shipment.Where(p => p.TrackingStatusId != (int)EnumTrackingStatus.Received && p.TrackingStatusId != (int)EnumTrackingStatus.Loss);
                else
                    shipment = shipment.Where(p => p.TrackingStatusId == (int)cbxStatus.SelectedValue);
            }

            GridIncoming.DataSource = shipment;

            btnPrint.Enabled = true;
            
            IncomingView.RefreshData();
        }

        private void Print(object sender, EventArgs e)
        {
            var print = new IncomingListPrint();
            using (var printTool = new ReportPrintTool(print))
            {
                var param = new List<WhereTerm>();
                var param2 = new List<WhereTerm>();
                param.Add(WhereTerm.Default(BaseControl.BranchId, "dest_branch_id", EnumSqlOperator.Equals));
                param2.Add(WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals));
                param.Add(WhereTerm.Default((int)EnumTrackingStatus.Arrival, "tracking_status_id", EnumSqlOperator.Equals));
                // ReSharper disable once ConditionIsAlwaysTrueOrFalse

                var dateNull = new DateTime(1900, 1, 1, 0, 0, 0);
                if (tbxFrom.DateTime > dateNull)
                {
                    var fdate = new DateTime(tbxFrom.DateTime.Year, tbxFrom.DateTime.Month, tbxFrom.DateTime.Day, 0, 0, 0);
                    param.Add(WhereTerm.Default(fdate, "date_process", EnumSqlOperator.GreatThanEqual));
                    param2.Add(WhereTerm.Default(fdate, "date_process", EnumSqlOperator.GreatThanEqual));
                }

                // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                if (tbxTo.DateTime > dateNull)
                {
                    var ldate = new DateTime(tbxTo.DateTime.Year, tbxTo.DateTime.Month, tbxTo.DateTime.Day, 23, 59, 59);
                    param.Add(WhereTerm.Default(ldate, "date_process", EnumSqlOperator.LesThanEqual));
                    param2.Add(WhereTerm.Default(ldate, "date_process", EnumSqlOperator.LesThanEqual));
                }

                if (tbxBranch.Value != null)
                {
                    param.Add(WhereTerm.Default((int)tbxBranch.Value, "branch_id", EnumSqlOperator.Equals));
                    param2.Add(WhereTerm.Default((int)tbxBranch.Value, "dest_branch_id", EnumSqlOperator.Equals));
                }

                // ReSharper disable once CoVariantArrayConversion
                print.DataSource = new ShipmentDataManager().IncomingList(param.ToArray(), param2.ToArray());

                print.RequestParameters = false;

                print.Parameters.Add(new Parameter
                {
                    Name = "TanggalMulai",
                    Value = tbxFrom.DateTime,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "TanggalSampai",
                    Value = tbxTo.DateTime,
                    Visible = false
                });

                if (tbxBranch.Value != null)
                {
                    var origin =
                        new BranchDataManager().GetFirst<BranchModel>(WhereTerm.Default((int) tbxBranch.Value, "id",
                            EnumSqlOperator.Equals));
                    print.Parameters.Add(new Parameter
                    {
                        Name = "Origin",
                        Value = origin.Code,
                        Visible = false
                    });
                }

                if (BaseControl.UserId != null)
                {
                    var user = new EmployeeDataManager().GetFirst<EmployeeModel>(WhereTerm.Default((int)BaseControl.UserId, "user_id", EnumSqlOperator.Equals));
                    print.Parameters.Add(new Parameter
                    {
                        Name = "Printed",
                        Value = string.Format("{0} ({1}) {2}", user.Name, user.Code, DateTime.Now.ToString("d-M-yyyy HH:mm")),
                        Visible = false
                    });
                }

                print.CreateDocument();
                printTool.ShowPreviewDialog();
            }
        }
    }

    public class Combo2
    {
        public int Id { get; set; }
        public String Text { get; set; }
    }
}
