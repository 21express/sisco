using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.XtraGrid.Views.Base;
using SISCO.App.MasterData;
using SISCO.App.Operation;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Properties;
using SISCO.Presentation.MasterData.Popup;

namespace SISCO.Presentation.Operation.Forms
{
    public partial class OnboardReportForm : BaseForm
    {
        public OnboardReportForm()
        {
            InitializeComponent();

            form = this;
            DataManager = new AirwaybillDataManager();
            Load += OnboardLoad;
            btnFilter.Click += (sender, args) => LoadGrid();
            OnboardView.CellValueChanged += Changed;
            btnSave.Click += Save;
            Shown += (sender, args) =>
            {
                NavigationMenu.NewStrip.Enabled = false;
                NavigationMenu.SaveStrip.Enabled = true;
                NavigationMenu.TopStrip.Enabled = false;
                NavigationMenu.PreviousStrip.Enabled = false;
                NavigationMenu.NewStrip.Enabled = false;
                NavigationMenu.BottomStrip.Enabled = false;
                NavigationMenu.FindStrip.Enabled = false;
                NavigationMenu.RefreshStrip.Enabled = false;
            };

            OnboardView.CustomColumnDisplayText += NumberGrid;
            OnboardView.DoubleClick += (sender, args) => OpenRelatedForm(OnboardView, new OutboundBandaraForm(), "Id");
            FormTrackingStatus = EnumTrackingStatus.Onboard;
            DataManager.DefaultParameters = new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals) };
        }

        public OnboardReportForm(DateTime date, string awbNo)
        {
            InitializeComponent();

            form = this;
            DataManager = new AirwaybillDataManager();
            Load += OnboardLoad;
            btnFilter.Click += (sender, args) => LoadGrid();
            OnboardView.CellValueChanged += Changed;
            btnSave.Click += Save;
            Shown += (sender, args) =>
            {
                NavigationMenu.NewStrip.Enabled = false;
                NavigationMenu.SaveStrip.Enabled = true;
                NavigationMenu.TopStrip.Enabled = false;
                NavigationMenu.PreviousStrip.Enabled = false;
                NavigationMenu.NewStrip.Enabled = false;
                NavigationMenu.BottomStrip.Enabled = false;
                NavigationMenu.FindStrip.Enabled = false;
                NavigationMenu.RefreshStrip.Enabled = false;
            };

            OnboardView.CustomColumnDisplayText += NumberGrid;
            OnboardView.DoubleClick += (sender, args) => OpenRelatedForm(OnboardView, new OutboundBandaraForm(), "Id");
            FormTrackingStatus = EnumTrackingStatus.Onboard;
            DataManager.DefaultParameters = new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals) };

            Shown += (sender, args) => OpenAwb(date, awbNo);
        }

        private void OpenAwb(DateTime date, string awbNo)
        {
            tbxDate.Text = date.ToString();
            tbxAwb.Text = awbNo;

            LoadGrid();
        }

        public void Save(object sender, EventArgs e)
        {
            if (OnboardView.RowCount > 0)
            {
                for (int i = 0; i < OnboardView.RowCount; i++)
                {
                    if (OnboardView.GetRowCellValue(i, "StateChange2").ToString() == EnumStateChange.Update.ToString())
                    {
                        var param = new IListParameter[]
                        {
                            WhereTerm.Default(Convert.ToInt32(OnboardView.GetRowCellValue(i, "Id")), "id", EnumSqlOperator.Equals)
                        };

                        var airwaybill = DataManager.GetFirst<AirwaybillModel>(param);

                        airwaybill.ActFlight = OnboardView.GetRowCellValue(i, "ActFlight") != null ? OnboardView.GetRowCellValue(i, "ActFlight").ToString() : string.Empty;
                        airwaybill.ActDepDate = OnboardView.GetRowCellValue(i, "ActDepDate") != null ? (DateTime) OnboardView.GetRowCellValue(i, "ActDepDate") : (DateTime?) null;
                        airwaybill.ActDepTime = OnboardView.GetRowCellValue(i, "ActDepTime") != null && !string.IsNullOrEmpty(OnboardView.GetRowCellValue(i, "ActDepTime").ToString()) ? Convert.ToDateTime(OnboardView.GetRowCellValue(i, "ActDepTime")).ToString("HH:mm") : string.Empty;
                        airwaybill.ActNote = OnboardView.GetRowCellValue(i, "ActNote") != null ? OnboardView.GetRowCellValue(i, "ActNote").ToString() : string.Empty;
                        airwaybill.GwSmu = OnboardView.GetRowCellValue(i, "GwSmu") != null ? (decimal) OnboardView.GetRowCellValue(i, "GwSmu") : (decimal?) null;
                        airwaybill.DiffSmu = OnboardView.GetRowCellValue(i, "DiffSmu") != null ? (decimal)OnboardView.GetRowCellValue(i, "DiffSmu") : (decimal?)null;

                        airwaybill.ActSame = (bool) OnboardView.GetRowCellValue(i, "ActSame");
                        airwaybill.ActConfirmed = Convert.ToBoolean(OnboardView.GetRowCellValue(i, "ActConfirmed"));
                        airwaybill.ActUpdated = DateTime.Now;
                        airwaybill.ActUsername = BaseControl.UserLogin;
                        airwaybill.StatusId = (int)EnumTrackingStatus.Onboard;
                        airwaybill.Modifiedby = BaseControl.UserLogin;
                        airwaybill.Modifieddate = DateTime.Now;

                        new AirwaybillDataManager().Update<PickupOrderModel>(airwaybill);

                        var airwaybillDetail = new AirwaybillDetailDataManager().Get<AirwaybillDetailModel>(WhereTerm.Default(airwaybill.Id, "airwaybill_id", EnumSqlOperator.Equals));
                        // ReSharper disable once PossibleMultipleEnumeration
                        var airwaybillDetailModels = airwaybillDetail as IList<AirwaybillDetailModel> ?? airwaybillDetail.ToList();
                        if (airwaybillDetailModels.Any())
                        {
                            foreach (AirwaybillDetailModel detail in airwaybillDetailModels)
                            {
                                if (detail.ShipmentId == 0)
                                {
                                    var manifestDetails =
                                        new ManifestDetailDataManager().Get<ManifestDetailModel>(
                                            WhereTerm.Default(detail.ShipmentCode, "consol_code", EnumSqlOperator.Equals));

                                    // ReSharper disable once PossibleMultipleEnumeration
                                    var manifestDetailModels = manifestDetails as ManifestDetailModel[] ??
                                                               manifestDetails.ToArray();
                                    if (manifestDetailModels.Any())
                                    {
                                        foreach (ManifestDetailModel detailModel in manifestDetailModels)
                                        {
                                            // ReSharper disable once PossibleInvalidOperationException
                                            var shipment =
                                                new ShipmentDataManager().GetFirst<ShipmentModel>(
                                                    WhereTerm.Default((int) detailModel.ShipmentId, "id", EnumSqlOperator.Equals));

                                            if (shipment.TrackingStatusId != (int)EnumTrackingStatus.Received && shipment.TrackingStatusId != (int)EnumTrackingStatus.Claimed && shipment.TrackingStatusId != (int)EnumTrackingStatus.Gudang)
                                            {
                                                shipment.TrackingStatusId = (int)EnumTrackingStatus.Onboard;
                                                shipment.Modifiedby = BaseControl.UserLogin;
                                                shipment.Modifieddate = DateTime.Now;

                                                new ShipmentDataManager().Update<ShipmentModel>(shipment);
                                            }

                                            var checkStatus = new ShipmentStatusDataManager().GetFirst<ShipmentStatusModel>(new IListParameter[]
                                            {
                                                WhereTerm.Default((int) detailModel.ShipmentId, "shipment_id", EnumSqlOperator.Equals),
                                                WhereTerm.Default((int) EnumTrackingStatus.Onboard, "tracking_status_id", EnumSqlOperator.Equals)
                                            });
                                            
                                            if (checkStatus != null && !airwaybill.ActConfirmed)
                                            {
                                                new ShipmentStatusDataManager().DeActive(checkStatus.Id, BaseControl.UserLogin, DateTime.Now);
                                            }

                                            if (checkStatus == null && airwaybill.ActConfirmed)
                                            {
                                                InsertTracking = true;
                                                PodStatusModel.TrackingStatusId = (int) EnumTrackingStatus.Onboard;
                                                PodStatusModel.ShipmentId = (int)detailModel.ShipmentId;
                                                PodStatusModel.PositionStatusId = BaseControl.BranchId;
                                                PodStatusModel.PositionStatus = EnumPositionStatus.Branch.ToString();
                                                PodStatusModel.StatusBy = airwaybill.ActFlight;
                                                PodStatusModel.StatusNote = string.Format("{0} KG SMU", airwaybill.GwSmu);
                                                PodStatusModel.Reference = airwaybill.Code;

                                                ShipmentStatusUpdate();
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    var shipment =
                                        new ShipmentDataManager().GetFirst<ShipmentModel>(
                                            WhereTerm.Default(detail.ShipmentId, "id", EnumSqlOperator.Equals));

                                    if (shipment.TrackingStatusId != (int)EnumTrackingStatus.Received && shipment.TrackingStatusId != (int)EnumTrackingStatus.Claimed && shipment.TrackingStatusId != (int)EnumTrackingStatus.Gudang)
                                    {
                                        shipment.TrackingStatusId = (int)EnumTrackingStatus.Onboard;
                                        shipment.Modifiedby = BaseControl.UserLogin;
                                        shipment.Modifieddate = DateTime.Now;

                                        new ShipmentDataManager().Update<ShipmentModel>(shipment);
                                    }

                                    var checkStatus = new ShipmentStatusDataManager().GetFirst<ShipmentStatusModel>(new IListParameter[]
                                            {
                                                WhereTerm.Default(detail.ShipmentId, "shipment_id", EnumSqlOperator.Equals),
                                                WhereTerm.Default((int) EnumTrackingStatus.Onboard, "tracking_status_id", EnumSqlOperator.Equals)
                                            });

                                    if (checkStatus != null && !airwaybill.ActConfirmed)
                                    {
                                        new ShipmentStatusDataManager().DeActive(checkStatus.Id, BaseControl.UserLogin, DateTime.Now);
                                    }

                                    if (checkStatus == null && airwaybill.ActConfirmed)
                                    {
                                        InsertTracking = true;
                                        PodStatusModel.TrackingStatusId = (int)EnumTrackingStatus.Onboard;
                                        PodStatusModel.ShipmentId = detail.ShipmentId;
                                        PodStatusModel.PositionStatusId = BaseControl.BranchId;
                                        PodStatusModel.PositionStatus = EnumPositionStatus.Branch.ToString();
                                        PodStatusModel.StatusBy = airwaybill.ActFlight;
                                        PodStatusModel.StatusNote = string.Format("{0} KG SMU", airwaybill.GwSmu);
                                        PodStatusModel.Reference = airwaybill.Code;

                                        ShipmentStatusUpdate();
                                    }
                                }
                            }
                        }
                    }
                }

                MessageBox.Show(Resources.save_success, Resources.save_confirmation, MessageBoxButtons.OK);
            }

            LoadGrid();
        }

        private void Changed(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.Name != "clState")
            {
                OnboardView.SetRowCellValue(e.RowHandle, OnboardView.Columns["StateChange2"], EnumStateChange.Update);
            }

            if (e.Column.Name == "clSame")
            {
                if ((bool) OnboardView.GetRowCellValue(e.RowHandle, OnboardView.Columns["ActSame"]))
                {
                    var actFlight = OnboardView.GetRowCellValue(e.RowHandle, OnboardView.Columns["Flight"]) != null ? OnboardView.GetRowCellValue(e.RowHandle, OnboardView.Columns["Flight"]).ToString() : string.Empty;
                    var actEdd = OnboardView.GetRowCellValue(e.RowHandle, OnboardView.Columns["EstDepDate"]) != null ? (DateTime) OnboardView.GetRowCellValue(e.RowHandle, OnboardView.Columns["EstDepDate"]) : (DateTime?) null;
                    var actEtd = OnboardView.GetRowCellValue(e.RowHandle, OnboardView.Columns["EstDepTime"]) != null ? OnboardView.GetRowCellValue(e.RowHandle, OnboardView.Columns["EstDepTime"]).ToString() : string.Empty;

                    OnboardView.SetRowCellValue(e.RowHandle, OnboardView.Columns["ActFlight"], actFlight);
                    OnboardView.SetRowCellValue(e.RowHandle, OnboardView.Columns["ActDepDate"], actEdd);
                    OnboardView.SetRowCellValue(e.RowHandle, OnboardView.Columns["ActDepTime"], actEtd);
                }
            }

            if (e.Column.Name == "clKiloSmu")
            {
                var gw = OnboardView.GetRowCellValue(e.RowHandle, OnboardView.Columns["TtlGrossWeight"]) != null ? (decimal) OnboardView.GetRowCellValue(e.RowHandle, OnboardView.Columns["TtlGrossWeight"]) : 0;
                var smu = OnboardView.GetRowCellValue(e.RowHandle, OnboardView.Columns["GwSmu"]) != null ? (decimal) OnboardView.GetRowCellValue(e.RowHandle, OnboardView.Columns["GwSmu"]) : 0;

                OnboardView.SetRowCellValue(e.RowHandle, OnboardView.Columns["DiffSmu"], gw - smu);
            }
        }

        private void OnboardLoad(object sender, EventArgs e)
        {
            ClearForm();

            tbxAirline.LookupPopup = new AirlinePopup();
            tbxAirline.AutoCompleteDataManager = new AirlineDataManager();
            tbxAirline.AutoCompleteText = model => ((EmployeeModel)model).Name;
            tbxAirline.AutoCompleteDisplayFormater = model => ((AirlineModel)model).Code + " - " + ((AirlineModel)model).Name;
            tbxAirline.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("code = @0 OR name.StartsWith(@0)", s);

            tbxDestination.LookupPopup = new AirportPopup();
            tbxDestination.AutoCompleteDataManager = new AirportDataManager();
            tbxDestination.AutoCompleteDisplayFormater = model => ((AirportModel)model).Code + " - " + ((AirportModel)model).Name;
            tbxDestination.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("code = @0 OR name.StartsWith(@0)", s);

            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            tbxDate.Text = DateTime.Now.ToString();
            tbxDate.Focus();
        }

        private void LoadGrid()
        {
            var param = new List<WhereTerm>();

            var fdate = new DateTime(tbxDate.Value.Year, tbxDate.Value.Month, tbxDate.Value.Day, 0, 0, 0);
            param.Add(WhereTerm.Default(fdate, "date_process", EnumSqlOperator.GreatThanEqual));

            var ldate = new DateTime(tbxDate.Value.Year, tbxDate.Value.Month, tbxDate.Value.Day, 23, 59, 59);
            param.Add(WhereTerm.Default(ldate, "date_process", EnumSqlOperator.LesThanEqual));
            param.Add(WhereTerm.Default(false, "is_cancelled"));

            if (tbxAwb.Text != "")
            {
                param.Add(WhereTerm.Default(tbxAwb.Text, "code", EnumSqlOperator.Equals));
            }

            if (tbxAirline.Value != null)
            {
                param.Add(WhereTerm.Default((int) tbxAirline.Value, "airline_id", EnumSqlOperator.Equals));
            }

            if (tbxDestination.Value != null)
            {
                param.Add(WhereTerm.Default((int)tbxDestination.Value, "dest_airport_id", EnumSqlOperator.Equals));
            }

            // ReSharper disable once CoVariantArrayConversion
            var airwaybill = DataManager.Get<AirwaybillModel>(param.ToArray());

            GridOnboard.DataSource = airwaybill;
        }
    }
}