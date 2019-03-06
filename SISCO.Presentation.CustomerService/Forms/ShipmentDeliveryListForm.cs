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
using SISCO.App.Franchise;

namespace SISCO.Presentation.CustomerService.Forms
{
    public partial class ShipmentDeliveryListForm : BaseMasterForm<ShipmentModel, ShipmentDeliveryListForm.ShipmentDataRow, ShipmentDataManager>//BaseForm//
    {
        public class ShipmentDataRow : ShipmentModel, INotifyPropertyChanged
        {
            public PaymentMethodDataManager PaymentMethodDataManager { get; set; }
            public PackageTypeDataManager PackageTypeDataManager { get; set; }
            public ServiceTypeDataManager ServiceTypeDataManager { get; set; }
            public BranchDataManager BranchDataManager { get; set; }

            public DateTime? DeliveryDate { get; set; }
            public string DeliveryDateStr { get; set; }
            public string DeliveryTime { get; set; }
            public string RecipientName { get; set; }
            public string DeliveryNote { get; set; }

            private string _paymentMethod;
            public new string PaymentMethod
            {
                get
                {
                    if (string.IsNullOrEmpty(_paymentMethod) && PaymentMethodId != 0)
                    {
                        var model = PaymentMethodDataManager.GetFirst<PaymentMethodModel>(WhereTerm.Default(PaymentMethodId, "id"));
                        _paymentMethod = string.Format("{0}", model.Name);
                    }
                    return _paymentMethod;
                }
                set { _paymentMethod = value; }
            }
            private string _packageType;
            public new string PackageType
            {
                get
                {
                    if (string.IsNullOrEmpty(_packageType) && PackageTypeId != 0)
                    {
                        var model = PackageTypeDataManager.GetFirst<PackageTypeModel>(WhereTerm.Default(PackageTypeId, "id"));
                        _packageType = model != null ? string.Format("{0}", model.Name) : "";
                    }
                    return _packageType;
                }
                set { _packageType = value; }
            }
            private string _serviceType;
            public new string ServiceType
            {
                get
                {
                    if (string.IsNullOrEmpty(_serviceType) && ServiceTypeId != 0)
                    {
                        var model = ServiceTypeDataManager.GetFirst<ServiceTypeModel>(WhereTerm.Default(ServiceTypeId, "id"));
                        _serviceType = model != null ? string.Format("{0}", model.Name) : "";
                    }
                    return _serviceType;
                }
                set { _serviceType = value; }
            }
            private string _destBranch;
            public string DestBranch
            {
                get
                {
                    if (string.IsNullOrEmpty(_destBranch) && DestBranchId != null)
                    {
                        var model = BranchDataManager.GetFirst<BranchModel>(WhereTerm.Default((int)DestBranchId, "id"));
                        _destBranch = model != null ? string.Format("{0}", model.Code) : "";
                    }
                    return _destBranch;
                }
                set { _destBranch = value; }
            }
            public int? LeadTime
            {
                get
                {
                    if (DeliveryDate == null) return (DateTime.Now.Subtract(DateProcess).Days)*-1;
                    else return (Convert.ToDateTime(DeliveryDate)).Subtract(DateProcess).Days;
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }

            internal void NotifyUpdate(string propertyName)
            {
                OnPropertyChanged(propertyName);

                switch (propertyName)
                {
                    case "PaymentMethodId":
                        PaymentMethod = null;
                        NotifyUpdate("PaymentMethod");
                        break;
                    case "PackageTypeId":
                        PackageType = null;
                        NotifyUpdate("PackageType");
                        break;
                    case "ServiceTypeId":
                        ServiceType = null;
                        NotifyUpdate("ServiceType");
                        break;
                    case "DestBranchId":
                        DestBranch = null;
                        NotifyUpdate("DestBranch");
                        break;
                }
            }
        }

        public PaymentMethodDataManager PaymentMethodDataManager { get; set; }
        public PackageTypeDataManager PackageTypeDataManager { get; set; }
        public ServiceTypeDataManager ServiceTypeDataManager { get; set; }
        public BranchDataManager BranchDataManager { get; set; }

        public ShipmentDeliveryListForm()
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

                row.PaymentMethodDataManager = PaymentMethodDataManager;
                row.PackageTypeDataManager = PackageTypeDataManager;
                row.ServiceTypeDataManager = ServiceTypeDataManager;
                row.BranchDataManager = BranchDataManager;

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
            if (txtDateTo.Value.Subtract(txtDateFrom.Value).Days > 31)
            {
                MessageBox.Show(@"Tidak bisa lebih dari 31 hari");
                return;
            }
            var p = new List<string>();

            p.Add("s.voided = 0");
            p.Add("s.rowstatus = 1");
            p.Add("s.branch_id = " + BaseControl.BranchId);
            if (txtDateFrom.DateTime != DateTime.MinValue) p.Add("s.date_process >= '" + txtDateFrom.Value.ToString("yyyy-MM-dd") + " 00:00:00'");
            if (txtDateTo.DateTime != DateTime.MinValue) p.Add("s.date_process <= '" + txtDateTo.Value.ToString("yyyy-MM-dd") + " 23:59:59'");

            if (lkpCustomer.Value != null) p.Add("s.customer_id = " + lkpCustomer.Value);
            if (lkpDestination.Value != null) p.Add("s.dest_city_id = " + lkpDestination.Value);
            if (lkpDestinationBranch.Value != null) p.Add("s.dest_branch_id = " + lkpDestinationBranch.Value);

            if (lkpServiceType.Value != null) p.Add("s.service_type_id = " + lkpServiceType.Value);
            txtTotalPieces.Text = @"0";
            txtTotalChargeableWeight.Text = @"0";

            if (lkpFranchise.Value != null) p.Add( "s.franchise_id = " + (int)lkpFranchise.Value);

            var deliverylist = new ShipmentDataManager().ShipmentDeliveryList(string.Join(" AND ", p.ToArray()));

            if ((int) cmbTrackingStatus.SelectedValue > 0)
            {
                deliverylist = deliverylist.Where(xp => xp.TrackingStatusId == (int) cmbTrackingStatus.SelectedValue).ToList();
            }

            if ((int) cmbTrackingStatus.SelectedValue == -1)
            {
                deliverylist = deliverylist.Where(xp => xp.TrackingStatusId == 0).ToList();
            }

            grid.DataSource = deliverylist;
            txtTotalPieces.Text = deliverylist.Sum(x => x.TtlPiece).ToString("#0");
            txtTotalChargeableWeight.Text = deliverylist.Sum(x => x.TtlChargeableWeight).ToString("#0");
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            lkpCustomer.LookupPopup = new CustomerPopup();
            lkpCustomer.AutoCompleteDataManager = new CustomerDataManager();
            lkpCustomer.AutoCompleteDisplayFormater = model => ((CustomerModel)model).Code + " - " + ((CustomerModel)model).Name;
            lkpCustomer.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("code = @0 OR name.StartsWith(@0)", s);

            lkpDestination.LookupPopup = new CityPopup();
            lkpDestination.AutoCompleteDataManager = new CityDataManager();
            lkpDestination.AutoCompleteDisplayFormater = model => ((CityModel)model).Name;
            lkpDestination.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            lkpDestinationBranch.LookupPopup = new BranchPopup();
            lkpDestinationBranch.AutoCompleteDataManager = new BranchDataManager();
            lkpDestinationBranch.AutoCompleteDisplayFormater = model => ((BranchModel)model).Code + " - " + ((BranchModel)model).Name;
            lkpDestinationBranch.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("code = @0 OR name.StartsWith(@0)", s);

            lkpFranchise.LookupPopup = new FranshicePopup(WhereTerm.Default(BaseControl.BranchId, "branch_id"));
            lkpFranchise.AutoCompleteDataManager = new FranchiseDataManager();
            lkpFranchise.AutoCompleteDisplayFormater = model => ((FranchiseModel)model).Code + " - " + ((FranchiseModel)model).Name;
            lkpFranchise.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("(code = @0 OR name.StartsWith(@0))", s, BaseControl.BranchId);
            
            lkpServiceType.LookupPopup = new ServiceTypePopup();
            lkpServiceType.AutoCompleteDataManager = new ServiceTypeDataManager();
            lkpServiceType.AutoCompleteDisplayFormater = model => ((ServiceTypeModel)model).Name;
            lkpServiceType.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            var now = DateTime.Now;
            txtDateFrom.DateTime = new DateTime(now.Year, now.Month, now.Day);
            txtDateTo.DateTime = new DateTime(now.Year, now.Month, now.Day);

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

            btnSaveToCsv.Click += (s, args) => ExportGridToExcel(gridView, "CustomerService_ShipmentList", true, "csv");
            btnSaveToExcel.Click += (s, args) => ExportGridToExcel(gridView, "CustomerService_ShipmentList");

            txtDateFrom.FieldLabel = "Date From";
            txtDateFrom.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };
            txtDateTo.FieldLabel = "Date To";
            txtDateTo.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            txtTotalPieces.Enabled = false;
            txtTotalChargeableWeight.Enabled = false;
        }

        protected override bool ValidateForm()
        {
            var errors = ComponentValidationHelper.Validate(txtDateFrom, txtDateTo);

            if (errors.Count > 0)
            {
                MessageBox.Show(string.Join("\n", errors));
                return false;
            }

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

            if ((int) cmbTrackingStatus.SelectedValue == -1)
            {
                gridView.ActiveFilterString = "[DeliveryDate] == 'Not Available'";
            }

            if ((int) cmbTrackingStatus.SelectedValue > 0)
            {
                gridView.ActiveFilterString = "[TrackingStatusId] == " + cmbTrackingStatus.SelectedValue;
            }

            gridView.RefreshData();
        }

        protected override IListParameter[] Filter()
        {
            var p = new List<IListParameter>();

            if (txtDateFrom.DateTime != DateTime.MinValue) p.Add(WhereTerm.Default(txtDateFrom.DateTime, "date_process", EnumSqlOperator.GreatThanEqual));
            if (txtDateTo.DateTime != DateTime.MinValue) p.Add(WhereTerm.Default(txtDateTo.DateTime, "date_process", EnumSqlOperator.LesThanEqual));

            if (lkpCustomer.Value != null) p.Add(WhereTerm.Default((int)lkpCustomer.Value, "customer_id"));
            if (lkpDestination.Value != null) p.Add(WhereTerm.Default((int)lkpDestination.Value, "dest_city_id"));
            if (lkpDestinationBranch.Value != null) p.Add(WhereTerm.Default((int)lkpDestinationBranch.Value, "dest_branch_id"));

            if (lkpServiceType.Value != null) p.Add(WhereTerm.Default((int)lkpServiceType.Value, "service_type_id"));

            if (lkpFranchise.Value != null) p.Add(WhereTerm.Default((int)lkpFranchise.Value, "franchise_id"));

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
