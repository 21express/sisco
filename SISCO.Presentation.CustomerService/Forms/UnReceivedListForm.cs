using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.Office.Utils;
using DevExpress.XtraPrinting.Native;
using SISCO.App.MasterData;
using SISCO.App.Operation;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Annotations;
using SISCO.Presentation.MasterData.Popup;
using SISCO.LocalStorage;

namespace SISCO.Presentation.CustomerService.Forms
{
    public partial class UnReceivedListForm : BaseMasterForm<ShipmentModel, ShipmentDeliveryListForm.ShipmentDataRow, ShipmentDataManager>//BasePage//
    {
        public class ShipmentDataRow : ShipmentModel
        {
            public string StatusDateStr { get; set; }
            public string StatusTime { get; set; }
            public string RecipientName { get; set; }
            public Int32? StatusId { get; set; }
            public string DestBranch { get; set; }
            public int? LeadTime { get; set; }
        }

        public PaymentMethodDataManager PaymentMethodDataManager { get; set; }
        public PackageTypeDataManager PackageTypeDataManager { get; set; }
        public ServiceTypeDataManager ServiceTypeDataManager { get; set; }
        public BranchDataManager BranchDataManager { get; set; }

        public UnReceivedListForm()
        {
            InitializeComponent();
            form = this;

            PaymentMethodDataManager = new PaymentMethodDataManager();
            PackageTypeDataManager = new PackageTypeDataManager();
            ServiceTypeDataManager = new ServiceTypeDataManager();
            BranchDataManager = new BranchDataManager();

            MainModelTransformFunc = model =>
            {
                var row = ConvertModel<ShipmentModel, ShipmentDataRow>(model);

                txtTotalPieces.Text = (Decimal.Parse(txtTotalPieces.Text) + row.TtlPiece).ToString(CultureInfo.InvariantCulture);
                txtTotalChargeableWeight.Text = (Decimal.Parse(txtTotalChargeableWeight.Text) + row.TtlChargeableWeight).ToString(CultureInfo.InvariantCulture);

                return row;
            };

            PageLimit = 99999;

            Init();
        }

        public override sealed void Init()
        {
            CtlClearButton = null;
            //CtlGridControl = grid;
            CtlGridView = gridView;
            //CtlSearchButton = btnSearch;

            btnSearch.Click += FilterShipment;
            txtTotalPieces.IsNumber = true;

            base.Init();
        }

        private void FilterShipment(object sender, EventArgs e)
        {
            var p = new List<string>();

            if (lkpOrigin.Value != null) p.Add("city_id = " + lkpOrigin.Value);
            if (lkpOriginBranch.Value != null) p.Add("branch_id = " + lkpOriginBranch.Value);
            if (lkpDestination.Value != null) p.Add("dest_city_id = " + lkpDestination.Value);
            if (lkpDestinationBranch.Value != null) p.Add("dest_branch_id = " + lkpDestinationBranch.Value);

            if (lkpServiceType.Value != null) p.Add("service_type_id = " + lkpServiceType.Value);
            txtTotalPieces.Text = @"0";
            txtTotalChargeableWeight.Text = @"0";

            var deliverylist = new ShipmentDataManager().UnreceivedList(string.Join(" AND ", p.ToArray()));

            grid.DataSource = deliverylist;
            txtTotalPieces.Text = deliverylist.Sum(x => x.TtlPiece).ToString("#0");
            txtTotalChargeableWeight.Text = deliverylist.Sum(x => x.TtlChargeableWeight).ToString("#0");
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            lkpOrigin.LookupPopup = new CityPopup();
            lkpOrigin.AutoCompleteDataManager = new CityServices();
            lkpOrigin.AutoCompleteDisplayFormater = model => ((CityModel)model).Name;
            lkpOrigin.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            lkpOriginBranch.LookupPopup = new BranchPopup();
            lkpOriginBranch.AutoCompleteDataManager = new BranchDataManager();
            lkpOriginBranch.AutoCompleteDisplayFormater = model => ((BranchModel)model).Code + " - " + ((BranchModel)model).Name;
            lkpOriginBranch.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("code = @0 OR name.StartsWith(@0)", s);

            lkpDestination.LookupPopup = new CityPopup();
            lkpDestination.AutoCompleteDataManager = new CityServices();
            lkpDestination.AutoCompleteDisplayFormater = model => ((CityModel)model).Name;
            lkpDestination.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            lkpDestinationBranch.LookupPopup = new BranchPopup();
            lkpDestinationBranch.AutoCompleteDataManager = new BranchDataManager();
            lkpDestinationBranch.AutoCompleteDisplayFormater = model => ((BranchModel)model).Code + " - " + ((BranchModel)model).Name;
            lkpDestinationBranch.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("code = @0 OR name.StartsWith(@0)", s);
            
            lkpServiceType.LookupPopup = new ServiceTypePopup();
            lkpServiceType.AutoCompleteDataManager = new ServiceTypeServices();
            lkpServiceType.AutoCompleteDisplayFormater = model => ((ServiceTypeModel)model).Name;
            lkpServiceType.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            grid.DoubleClick += (o, args) =>
            {
                var rows = gridView.GetSelectedRows();

                if (rows.Count() > 0)
                {
                    BaseControl.OpenRelatedForm(new TrackingViewForm(), gridView.GetRowCellValue(rows[0], "Code").ToString(), CallingCommand);
                }
            };

            btnSaveToCsv.Click += (s, args) => ExportGridToExcel(gridView, "UndeliveredList", true, "csv");
            btnSaveToExcel.Click += (s, args) => ExportGridToExcel(gridView, "UndeliveredList");

            txtTotalPieces.Enabled = false;
            txtTotalChargeableWeight.Enabled = false;
        }

        protected override bool ValidateForm()
        {
            return true;
        }

        protected override void PopulateForm(ShipmentModel model)
        {
            //;
        }

        protected override ShipmentModel PopulateModel(ShipmentModel model)
        {
            return model;
        }

        protected override void AfterGridLoad()
        {
            base.AfterGridLoad();

            _afterGridLoadAsync();
        }

        //private async void _afterGridLoadAsync()
        private void _afterGridLoadAsync()
        {
            //var associatedDeliveryOrderDetails = await TaskEx.Run(() => new DeliveryOrderDetailDataManager().GetByShipmentIds(DataSource.Select(row => row.Id).ToArray()));
            /*var associatedDeliveryOrderDetails = new DeliveryOrderDetailDataManager().GetByShipmentIds(DataSource.Select(row => row.Id).ToArray());

            DataSource.ForEach(row =>
            {
                var deliveryOrderDetail = associatedDeliveryOrderDetails.FirstOrDefault(r => r.ShipmentId == row.Id);

                if (deliveryOrderDetail != null)
                {
                    row.DeliveryDate = deliveryOrderDetail.ReceivedDate.ToString();

                    if (deliveryOrderDetail.ReceivedDate != null)
                    {
                        row.DeliveryTime = ((DateTime)deliveryOrderDetail.ReceivedDate).ToString("hh:mm");
                    }

                    row.RecipientName = deliveryOrderDetail.ReceivedBy;
                    row.DeliveryNote = deliveryOrderDetail.ReceivedNote;
                }
            });*/

            DataSource.ForEach(row =>
            {
                var trackingStatuses =
                    new TrackingStatusDataManager().Get<TrackingStatusModel>(WhereTerm.Default(true, "is_final_status")).Select(s =>s.Id).ToList();
                //if ((int)cmbTrackingStatus.SelectedValue > 0) trackingStatuses = new List<int>{(int)cmbTrackingStatus.SelectedValue};

                var shipmentStatus = new ShipmentStatusDataManager().GetLastStatusByShipment(row.Id, trackingStatuses);
                if (shipmentStatus == null)
                {
                    row.DeliveryDate = null;
                    row.DeliveryDateStr = "Not Available";
                    row.DeliveryTime = "";
                    row.RecipientName = "";
                    row.DeliveryNote = "";
                }
                else
                {
                    row.DeliveryDate = shipmentStatus.DateProcess;
                    var datestr = shipmentStatus.DateProcess.ToString("dd-MM-yyyy");
                    row.DeliveryDateStr = datestr;
                    row.DeliveryTime = shipmentStatus.DateProcess.ToString("HH:mm");
                    row.RecipientName = string.IsNullOrEmpty(shipmentStatus.MissDeliveryReason) ? shipmentStatus.StatusBy : "";
                    row.DeliveryNote = string.IsNullOrEmpty(shipmentStatus.MissDeliveryReason) ? shipmentStatus.StatusNote : shipmentStatus.MissDeliveryReason;
                }
            });

            gridView.RefreshData();
        }

        protected override IListParameter[] Filter()
        {
            var p = new List<IListParameter>();

            if (lkpOrigin.Value != null) p.Add(WhereTerm.Default((int)lkpOrigin.Value, "city_id"));
            if (lkpOriginBranch.Value != null) p.Add(WhereTerm.Default((int)lkpOriginBranch.Value, "branch_id"));
            if (lkpDestination.Value != null) p.Add(WhereTerm.Default((int)lkpDestination.Value, "dest_city_id"));
            if (lkpDestinationBranch.Value != null) p.Add(WhereTerm.Default((int)lkpDestinationBranch.Value, "dest_branch_id"));

            if (lkpServiceType.Value != null) p.Add(WhereTerm.Default((int)lkpServiceType.Value, "service_type_id"));

            txtTotalPieces.Text = @"0";
            txtTotalChargeableWeight.Text = @"0";

            return p.ToArray();
        }

        protected override IEnumerable<T> GetFromDataManager<T>(Paging paging, out int count, IListParameter[] parameters)
        {
            var list = new List<IListParameter>(parameters);
            list.Add(WhereTerm.Default(BaseControl.BranchId, "branch_id"));

            return base.GetFromDataManager<T>(paging, out count, list.ToArray());
        }
    }
}
