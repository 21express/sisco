using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using SISCO.App.MasterData;
using SISCO.App.Operation;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Properties;
using SISCO.Presentation.CustomerService.Forms;
using SISCO.Presentation.MasterData.Popup;
using SISCO.Presentation.Operation.Reports;
using DevExpress.XtraReports.Parameters;

namespace SISCO.Presentation.Operation.Forms
{
    public partial class DeliveryResultForm : BaseForm
    {
        private XtraReport Report { get; set; }
        public DeliveryResultForm()
        {
            InitializeComponent();

            form = this;
            Load += DeliveryResultLoad;
            btnFilter.Click += (sender, args) => LoadGrid();
            btnUpdate.Click += Update;
            btnSave.Click += Save;
            DeliveryResultView.RowStyle += ChangeColor;
            DeliveryResultView.CustomColumnDisplayText += NumberGrid;
            GridDeliveryResult.DoubleClick += (sender, args) => OpenRelatedForm(DeliveryResultView, new TrackingViewForm(), "ShipmentCode");

            Report = new DeliveryResultReport();
            btnPrintPreview.Click += (sender, args) =>
            {
                using (var printTool = new ReportPrintTool(Report))
                {
                    DataSourceReport();
                    printTool.ShowPreviewDialog();
                }
            };

            btnPrint.Click += (sender, args) =>
            {
                using (var printTool = new ReportPrintTool(Report))
                {
                    DataSourceReport();
                    printTool.PrintDialog();
                }
            };
        }

        private void DataSourceReport()
        {
            Report.DataSource = new object[0];

            LoadGrid();
            var dataSource = GridDeliveryResult.DataSource as List<DeliveryOrderDetailModel>;

            if (dataSource != null)
            {
                Report.DataSource = dataSource;
            }

            Report.RequestParameters = false;
            Report.Parameters.Add(new Parameter
            {
                Name = "DateProcess",
                Value = tbxDate.Value,
                Visible = false
            });
            Report.CreateDocument();
        }

        private void Save(object sender, EventArgs e)
        {
            var repos = new DeliveryOrderDetailDataManager();
            for (int i = 0; i < DeliveryResultView.DataRowCount; i++)
            {
                if (DeliveryResultView.GetRowCellValue(i, "StateChange2").ToString() == EnumStateChange.Update.ToString())
                {
                    var id = (int) DeliveryResultView.GetRowCellValue(i, DeliveryResultView.Columns["Id"]);
                    var orderDetail = new DeliveryOrderDetailDataManager().GetFirst<DeliveryOrderDetailModel>(WhereTerm.Default(id, "id", EnumSqlOperator.Equals));

                    if (orderDetail != null)
                    {
                        orderDetail.ReceivedDate = (DateTime) DeliveryResultView.GetRowCellValue(i, DeliveryResultView.Columns["ReceivedDate"]);
                        orderDetail.ReceivedBy = DeliveryResultView.GetRowCellValue(i, DeliveryResultView.Columns["ReceivedBy"]).ToString();
                        orderDetail.ReceivedNote = DeliveryResultView.GetRowCellValue(i, DeliveryResultView.Columns["ReceivedNote"]).ToString();
                        if (DeliveryResultView.GetRowCellValue(i, DeliveryResultView.Columns["ReceivedUpdate"]) != null)
                            orderDetail.ReceivedUpdate = (DateTime) DeliveryResultView.GetRowCellValue(i, DeliveryResultView.Columns["ReceivedUpdate"]);
                        orderDetail.Received = (bool)DeliveryResultView.GetRowCellValue(i, DeliveryResultView.Columns["Received"]);
                        orderDetail.Modifiedby = BaseControl.UserLogin;
                        orderDetail.Modifieddate = DateTime.Now;

                        repos.Update<DeliveryOrderDetailModel>(orderDetail);

                        InsertTracking = true;
                        PodStatusModel.ShipmentId = orderDetail.ShipmentId;
                        PodStatusModel.StatusBy = orderDetail.Received ? orderDetail.ReceivedBy : BaseControl.UserLogin;
                        if (orderDetail.Received)
                        {
                            PodStatusModel.StatusNote = orderDetail.ReceivedNote;
                            PodStatusModel.MissDeliveryReason = string.Empty;
                        }
                        else
                        {
                            PodStatusModel.MissDeliveryReason = orderDetail.ReceivedNote;
                            PodStatusModel.StatusNote = string.Empty;
                        }
                        PodStatusModel.PositionStatusId = BaseControl.BranchId;
                        PodStatusModel.PositionStatus = EnumPositionStatus.Branch.ToString();

                        PodStatusModel.TrackingStatusId = orderDetail.Received
                            ? (int) EnumTrackingStatus.Received
                            : (int) EnumTrackingStatus.MissDelivery;

                        FormTrackingStatus = orderDetail.Received
                            ? EnumTrackingStatus.Received
                            : EnumTrackingStatus.MissDelivery;
                        ShipmentStatusUpdate();

                        var s = new ShipmentDataManager().GetFirst<ShipmentModel>(WhereTerm.Default(orderDetail.ShipmentId, "id", EnumSqlOperator.Equals));
                        if (s != null)
                        {
                            s.TrackingStatusId = PodStatusModel.TrackingStatusId;
                            s.Modifiedby = BaseControl.UserLogin;
                            s.Modifieddate = DateTime.Now;

                            new ShipmentDataManager().Update<ShipmentModel>(s);
                        }
                    }
                }
            }

            MessageBox.Show(Resources.save_success, Resources.save_confirmation, MessageBoxButtons.OK);
            LoadGrid();
        }

        private void ChangeColor(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var view = sender as GridView;

                if (view != null && ((int)view.GetRowCellValue(e.RowHandle, view.Columns["ServiceTypeId"]) == 7 || (int)view.GetRowCellValue(e.RowHandle, view.Columns["ServiceTypeId"]) == 9))
                {
                    //e.Appearance.BackColor = Color.Salmon;
                    //e.Appearance.BackColor2 = Color.SeaShell;
                    e.Appearance.ForeColor = Color.Red;
                }

                if (view != null && (int)view.GetRowCellValue(e.RowHandle, view.Columns["ServiceTypeId"]) == 8)
                {
                    //e.Appearance.BackColor = Color.MediumSlateBlue;
                    //e.Appearance.BackColor2 = Color.SeaShell;
                    e.Appearance.ForeColor = Color.Blue;
                }
            }
        }

        private void Update(object sender, EventArgs e)
        {
            if (tbxDate.Text == "")
            {
                tbxDate.Focus();
                return;
            }

            if (tbxBarcode.Text == "")
            {
                tbxBarcode.Focus();
                return;
            }

            // ReSharper disable once RedundantAssignment
            var ordDetail = new List<DeliveryOrderDetailModel>();
            if (DeliveryResultView.RowCount > 0)
            {
                ordDetail = GridDeliveryResult.DataSource as List<DeliveryOrderDetailModel>;
                // ReSharper disable once AssignNullToNotNullAttribute
                var ins = ordDetail.FirstOrDefault(b => b.ShipmentCode == tbxBarcode.Text);
                if (ins == null)
                {
                    ins = ordDetail.FirstOrDefault(b => b.Fulfilment == tbxBarcode.Text);
                }

                var status = new ShipmentStatusDataManager().GetFirst<ShipmentStatusModel>(new IListParameter[]
                    {
                        WhereTerm.Default("shipment_id")
                    });

                if (ins != null)
                {
                    for (int i = 0; i < DeliveryResultView.DataRowCount; i++)
                    {
                        object b = DeliveryResultView.GetRowCellValue(i, "ShipmentCode");
                        object f = DeliveryResultView.GetRowCellValue(i, "Fulfilment");
                        if ((b != null && b.Equals(tbxBarcode.Text)) || (f != null && f.Equals(tbxBarcode.Text)))
                        {
                            var id = (int)DeliveryResultView.GetRowCellValue(i, DeliveryResultView.Columns["Id"]);
                            var orderDetail = new DeliveryOrderDetailDataManager().GetFirst<DeliveryOrderDetailModel>(WhereTerm.Default(id, "id", EnumSqlOperator.Equals));

                            var shipmentStatus = new ShipmentStatusDataManager().GetFirst<ShipmentStatusModel>(new IListParameter[]
                                {
                                    WhereTerm.Default(orderDetail.ShipmentId, "shipment_id", EnumSqlOperator.Equals),
                                    WhereTerm.Default((int)EnumTrackingStatus.Received, "tracking_status_id", EnumSqlOperator.Equals)
                                });

                            if (shipmentStatus != null)
                            {
                                MessageBox.Show(string.Format("Shipment sudah diterima oleh {0}", shipmentStatus.StatusBy));
                            }
                            else
                            {
                                DeliveryResultView.FocusedRowHandle = i;
                                DeliveryResultView.SetRowCellValue(i, DeliveryResultView.Columns["StateChange2"], EnumStateChange.Update);

                                if (Convert.ToBoolean(DeliveryResultView.GetRowCellValue(i, DeliveryResultView.Columns["Received"])))
                                    DeliveryResultView.SetRowCellValue(i, DeliveryResultView.Columns["ReceivedUpdate"], tbxDate.Value);
                                else
                                    DeliveryResultView.SetRowCellValue(i, DeliveryResultView.Columns["ReceivedDate"], tbxDate.Value);

                                DeliveryResultView.SetRowCellValue(i, DeliveryResultView.Columns["ReceivedBy"], tbxReciever.Text);
                                DeliveryResultView.SetRowCellValue(i, DeliveryResultView.Columns["ReceivedNote"], tbxNote.Text);

                                var received = tbxReciever.Text != "";
                                DeliveryResultView.SetRowCellValue(i, DeliveryResultView.Columns["Received"], received);
                            }
                        }
                    }
                }

                DeliveryResultView.RefreshData();

                tbxBarcode.Text = "";
                tbxReciever.Text = "";
                tbxNote.Text = "";
                tbxBarcode.Focus();
            }
            else
            {
                MessageBox.Show(Resources.empty_cn, Resources.information,
                        MessageBoxButtons.OK);
            }
        }

        private void DeliveryResultLoad(object sender, EventArgs e)
        {
            ClearForm();

            tbxDate.Text = DateTime.Now.ToString();

            tbxCourier.LookupPopup = new MessengerPopup();
            tbxCourier.AutoCompleteDataManager = new EmployeeDataManager();
            tbxCourier.AutoCompleteDisplayFormater = model => ((EmployeeModel)model).Code + " - " + ((EmployeeModel)model).Name;
            tbxCourier.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND as_messenger AND branch_id = @1", s, BaseControl.BranchId);

            LoadGrid();
        }

        private void LoadGrid()
        {
            GridDeliveryResult.DataSource = null;
            var dateNull = new DateTime(1900, 1, 1, 0, 0, 0);
            if (tbxDate.Value > dateNull)
            {
                var param = new List<WhereTerm>();
                param.Add(WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals));
                var fdate = new DateTime(tbxDate.Value.Year, tbxDate.Value.Month, tbxDate.Value.Day, 0, 0, 0);
                var tdate = new DateTime(tbxDate.Value.Year, tbxDate.Value.Month, tbxDate.Value.Day, 23, 59, 59);
                param.Add(WhereTerm.Default(fdate, "date_process", EnumSqlOperator.GreatThanEqual));
                param.Add(WhereTerm.Default(tdate, "date_process", EnumSqlOperator.LesThanEqual));

                if (tbxCourier.Value != null)
                {
                    param.Add(WhereTerm.Default((int) tbxCourier.Value, "messenger_id", EnumSqlOperator.Equals));
                }

                // ReSharper disable once CoVariantArrayConversion
                IListParameter[] parameters = param.ToArray();
                var orderDetail = new DeliveryOrderDetailDataManager().DeliveryResult(parameters);

                GridDeliveryResult.DataSource = orderDetail;
                DeliveryResultView.RefreshData();
            }
            else
            {
                GridDeliveryResult.DataSource = null;
                DeliveryResultView.RefreshData();
            }
        }
    }
}