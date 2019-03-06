using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Administration.Reports;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.CustomerService.Forms;
using SISCO.Presentation.MasterData.Annotations;
using SISCO.Presentation.MasterData.Popup;

namespace SISCO.Presentation.Administration.Forms
{
    public partial class ViewShipmentListForm : BaseMasterForm<ShipmentModel, ViewShipmentListForm.ShipmentDataRow, ShipmentDataManager>//BaseForm//
    {
        public class ShipmentStatusFilter
        {
            public string Text { get; set; }
            public string Column { get; set; }
            public int Value { get; set; }

            public static ShipmentStatusFilter[] Options = 
            {
                new ShipmentStatusFilter {Text = "SEMUA", Column = null, Value = 0},
                new ShipmentStatusFilter {Text = "SUDAH KIRIM", Column = "pod_sent", Value = 1},
                new ShipmentStatusFilter {Text = "BELUM KIRIM", Column = "pod_sent", Value = 0},
                new ShipmentStatusFilter {Text = "SUDAH TERIMA", Column = "pod_received", Value = 1},
                new ShipmentStatusFilter {Text = "BELUM TERIMA", Column = "pod_received", Value = 0},
                new ShipmentStatusFilter {Text = "SUDAH KIRIM CUSTOMER", Column = "pod_returned", Value = 1},
                new ShipmentStatusFilter {Text = "BELUM KIRIM CUSTOMER", Column = "pod_returned", Value = 0},
                new ShipmentStatusFilter {Text = "SUDAH INVOICED", Column = "invoiced", Value = 1},
                new ShipmentStatusFilter {Text = "BELUM INVOICED", Column = "invoiced", Value = 0}
            };
        }

        public class ShipmentDataRow : ShipmentModel, INotifyPropertyChanged
        {
            public PaymentMethodDataManager PaymentMethodDataManager { get; set; }
            public PackageTypeDataManager PackageTypeDataManager { get; set; }

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

            public bool PodSentStatus
            {
                get { return PodSent == 1; }
            }

            public bool PodReceivedStatus
            {
                get { return PodReceived == 1; }
            }

            public bool PodReturnedStatus
            {
                get { return PodReturned == 1; }
            }

            public bool InvoicedStatus
            {
                get { return Invoiced == 1; }
            }
            public int? ProcessTime
            {
                get
                {
                    return PodReceived == 0 ? DateTime.Now.Subtract(DateProcess).Days : (int?)null;
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
                        base.PackageType = null;
                        NotifyUpdate("PackageType");
                        break;
                }
            }
        }

        public PaymentMethodDataManager PaymentMethodDataManager { get; set; }
        public PackageTypeDataManager PackageTypeDataManager { get; set; }

        public ViewShipmentListForm()
        {
            InitializeComponent();
            form = this;

            PaymentMethodDataManager = new PaymentMethodDataManager();
            PackageTypeDataManager = new PackageTypeDataManager();

            MainModelTransformFunc = model =>
            {
                var row = ConvertModel<ShipmentModel, ShipmentDataRow>(model);

                row.PaymentMethodDataManager = PaymentMethodDataManager;
                row.PackageTypeDataManager = PackageTypeDataManager;

                txtTotalPiece.Text = (Decimal.Parse(txtTotalPiece.Text) + row.TtlPiece).ToString(CultureInfo.InvariantCulture);
                txtTotalGrossWeight.Text = (Decimal.Parse(txtTotalGrossWeight.Text) + row.TtlGrossWeight).ToString(CultureInfo.InvariantCulture);
                txtTotalChargeableWeight.Text = (Decimal.Parse(txtTotalChargeableWeight.Text) + row.TtlChargeableWeight).ToString(CultureInfo.InvariantCulture);

                return row;
            };

            txtTotalChargeableWeight.Enabled = false;
            txtTotalGrossWeight.Enabled = false;
            txtTotalPiece.Enabled = false;

            PageLimit = 99999;

            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            Init();

            btnSaveToExcel.Click += (sender, args) => ExportGridToExcel(gridView, "Admin_ShipmentList");
            btnPrint.Click += BtnPrintOnClick;

            DataManager.DefaultParameters = new IListParameter[] {WhereTerm.Default(BaseControl.BranchId, "branch_id")};
        }

        public override void SelectRow(object sender, EventArgs e)
        {
            //
        }

        public override void Init()
        {
            CtlClearButton = null;
            CtlGridControl = grid;
            CtlGridView = gridView;
            CtlSearchButton = btnSearch;

            base.Init();
        }

        private void BtnPrintOnClick(object sender, EventArgs eventArgs)
        {
            var printout = new ShipmentListPrintOut
            {
                DataSource = DataSource
            };
            printout.PrintPreview();
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            lkpCustomer.LookupPopup = new CustomerPopup(WhereTerm.Default(BaseControl.BranchId, "branch_id"));
            lkpCustomer.AutoCompleteDataManager = new CustomerDataManager();
            lkpCustomer.AutoCompleteDisplayFormater = model =>
            {
                var c = model as CustomerModel;
                if (c != null) return string.Format("{0} - {1}", c.Code, c.Name);
                return "";
            };
            lkpCustomer.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND branch_id = @1", s, BaseControl.BranchId);

            lkpDestCity.LookupPopup = new CityPopup();
            lkpDestCity.AutoCompleteDataManager = new CityDataManager();
            lkpDestCity.AutoCompleteDisplayFormater = model => ((CityModel)model).Name;
            lkpDestCity.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            lkpDestBranch.LookupPopup = new BranchPopup();
            lkpDestBranch.AutoCompleteDataManager = new BranchDataManager();
            lkpDestBranch.AutoCompleteDisplayFormater = model => ((BranchModel)model).Code + " - " + ((BranchModel)model).Name;
            lkpDestBranch.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("code = @0 OR name.StartsWith(@0)", s);


            lkpPaymentMethod.LookupPopup = new PaymentMethodPopup();
            lkpPaymentMethod.AutoCompleteDataManager = new PaymentMethodDataManager();
            lkpPaymentMethod.AutoCompleteDisplayFormater = model => ((PaymentMethodModel)model).Name;
            lkpPaymentMethod.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            cmbStatus.DataSource = ShipmentStatusFilter.Options;
            cmbStatus.DisplayMember = "Text";
            cmbStatus.ValueMember = "Text";

            var now = DateTime.Now;
            txtDateFrom.DateTime = new DateTime(now.Year, now.Month, 1);
            txtDateTo.DateTime = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month));

            grid.DoubleClick += GridOnDoubleClick;
            grid.KeyPress += (o, args) =>
            {
                if (args.KeyChar == 13)
                {
                    GridOnDoubleClick(o, args);
                }
            };

            txtDateFrom.FieldLabel = "Date From";
            txtDateFrom.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            txtDateTo.FieldLabel = "Date To";
            txtDateTo.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };
        }

        private void GridOnDoubleClick(object sender, EventArgs e)
        {
            var rows = gridView.GetSelectedRows();

            if (rows.Count() > 0)
            {
                BaseControl.OpenRelatedForm(new TrackingViewForm(), gridView.GetRowCellValue(rows[0], "Code").ToString(), CallingCommand);
            }
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

        protected override IListParameter[] Filter()
        {
            var p = new List<IListParameter>();

            if (txtShipmentCode.Text != "")
            {
                p.Add(WhereTerm.Default(txtShipmentCode.Text, "code"));
            }
            else
            {
                if (txtDateFrom.DateTime != DateTime.MinValue)
                    p.Add(WhereTerm.Default(txtDateFrom.DateTime, "date_process", EnumSqlOperator.GreatThanEqual));
                if (txtDateTo.DateTime != DateTime.MinValue)
                    p.Add(WhereTerm.Default(txtDateTo.DateTime.Date.AddDays(1), "date_process",
                        EnumSqlOperator.LesThanEqual));

                if (lkpCustomer.Value != null) p.Add(WhereTerm.Default((int) lkpCustomer.Value, "customer_id"));
                if (lkpDestCity.Value != null) p.Add(WhereTerm.Default((int) lkpDestCity.Value, "dest_city_id"));
                if (lkpDestBranch.Value != null) p.Add(WhereTerm.Default((int) lkpDestBranch.Value, "dest_branch_id"));
                if (lkpPaymentMethod.Value != null)
                    p.Add(WhereTerm.Default((int) lkpPaymentMethod.Value, "payment_method_id"));

                if (cmbStatus.SelectedIndex > 0)
                {
                    var filter = ShipmentStatusFilter.Options[cmbStatus.SelectedIndex];

                    p.Add(WhereTerm.Default(filter.Value, filter.Column));
                }
            }

            txtTotalPiece.Text = @"0";
            txtTotalGrossWeight.Text = @"0";
            txtTotalChargeableWeight.Text = @"0";

            return p.ToArray();
        }

        protected override IEnumerable<T> GetFromDataManager<T>(Paging paging, out int count, IListParameter[] parameters)
        {
            return base.GetFromDataManager<T>(paging, out count, parameters).Cast<ShipmentModel>().OrderBy(r => r.Code).Cast<T>();
        }

        protected override void AfterGridLoad()
        {
            base.AfterGridLoad();

            if (DataSource.Any())
            {
                grid.Focus();
            }
        }
    }
}
