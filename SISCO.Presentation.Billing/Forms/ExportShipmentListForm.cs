using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Senders;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Annotations;
using SISCO.Repositories.Context;

namespace SISCO.Presentation.Billing.Forms
{
    public partial class ExportShipmentListForm : BaseMasterForm<ShipmentModel, ShipmentDataManager>
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
                new ShipmentStatusFilter {Text = "BELUM TERIMA", Column = "pod_returned", Value = 0},
                new ShipmentStatusFilter {Text = "SUDAH KIRIM CUSTOMER", Column = "pod_received", Value = 1},
                new ShipmentStatusFilter {Text = "BELUM KIRIM CUSTOMER", Column = "pod_received", Value = 0},
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
                        _packageType = string.Format("{0}", model.Name);
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

        public ExportShipmentListForm()
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

                return row;
            };

            PageLimit = 99999;

            Init();


            btnSaveToExcel.Click += (sender, args) =>
            {
                try
                {
                    if (txtInvoiceNumber.Text == string.Empty && txtReceiptNumber.Text == string.Empty)
                    {
                        if (txtDateFrom.DateTime == DateTime.MinValue)
                        {
                            txtDateFrom.Focus();
                            throw new Exception("Please enter the range date!");
                        }

                        if (txtDateTo.DateTime == DateTime.MinValue)
                        {
                            txtDateTo.Focus();
                            throw new Exception("Please enter the range date!");
                        }
                    }

                    string paymentType = dcmbPayment.GetItemText(dcmbPayment.SelectedItem);
                    DateTime? shipmentFromDate = null;
                    DateTime? shipmentToDate = null;
                    DateTime? invoiceFromDate = null;
                    DateTime? invoiceToDate = null;

                    shipmentFromDate = txtDateFrom.Value;
                    shipmentToDate = txtDateTo.Value;
                    
                    string invoiceNumber = txtInvoiceNumber.Text;
                    string receiptNumber = txtReceiptNumber.Text;

                    gridExport.DataSource = new ShipmentDataManager().ShipmentExportExcel(shipmentFromDate, shipmentToDate, invoiceFromDate, invoiceToDate,
                        paymentType, invoiceNumber, receiptNumber);
                    ExportGridToExcel(gridViewExport, "Billing_ExportedShipmentList");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            };

            btnSearch.Click += (sender, args) =>
            {
                try
                {
                    //grid.DataSource = new ShipmentDataManager().ShipmentListExport(Filter());
                    if (txtInvoiceNumber.Text == string.Empty && txtReceiptNumber.Text == string.Empty)
                    {
                        if (txtDateFrom.DateTime == DateTime.MinValue)
                        {
                            txtDateFrom.Focus();
                            throw new Exception("Please enter the range date!");
                        }

                        if (txtDateTo.DateTime == DateTime.MinValue)
                        {
                            txtDateTo.Focus();
                            throw new Exception("Please enter the range date!");
                        }
                    }

                    string paymentType = dcmbPayment.GetItemText(dcmbPayment.SelectedItem);
                    DateTime? shipmentFromDate = null;
                    DateTime? shipmentToDate = null;
                    DateTime? invoiceFromDate = null;
                    DateTime? invoiceToDate = null;

                    shipmentFromDate = txtDateFrom.Value;
                    shipmentToDate = txtDateTo.Value;

                    string invoiceNumber = txtInvoiceNumber.Text;
                    string receiptNumber = txtReceiptNumber.Text;

                    grid.DataSource = new ShipmentDataManager().ShipmentExportExcel(shipmentFromDate, shipmentToDate, invoiceFromDate, invoiceToDate,
                        paymentType, invoiceNumber, receiptNumber);
                    CtlGridControl = grid;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            };
        }

        public override void SelectRow(object sender, EventArgs e)
        {
            int[] rows = CtlGridView.GetSelectedRows();

            if (rows.Length > 0)
            {
                var id = CtlGridView.GetRowCellValue(rows[0], "Id");
                // TODO: open customer service tracking view form
            }
        }

        public override void Init()
        {
            CtlClearButton = null;
            CtlGridControl = grid;
            CtlGridView = gridView;
            //CtlSearchButton = btnSearch;

            base.Init();
        }

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);

            var now = DateTime.Now;
            txtDateFrom.DateTime = new DateTime(now.Year, now.Month, 1);
            txtDateTo.DateTime = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month));

            grid.DoubleClick += (o, args) =>
            {
                var rows = gridView.GetSelectedRows();

                if (rows.Count() > 0)
                {
                    BaseControl.OpenRelatedForm(new ValidateShipmentOrderForm(), gridView.GetRowCellValue(rows[0], "Code").ToString(), CallingCommand);
                }
            };

            txtDateFrom.FieldLabel = "Date From";
            //txtDateFrom.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            txtDateTo.FieldLabel = "Date To";
            //txtDateTo.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            using (var paymentMethodDataManager = new PaymentMethodDataManager())
            {
                dcmbPayment.DataSource = paymentMethodDataManager.Get<PaymentMethodModel>();
            }
            dcmbPayment.DisplayMember = "Name";
            dcmbPayment.ValueMember = "Id";
            dcmbPayment.FieldLabel = "Payment Method";
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

            if (txtInvoiceNumber.Text == string.Empty && txtReceiptNumber.Text == string.Empty)
            {
                if (txtDateFrom.DateTime == DateTime.MinValue)
                {
                    txtDateFrom.Focus();
                    throw new Exception("Please enter the range date!");
                }

                if (txtDateTo.DateTime == DateTime.MinValue)
                {
                    txtDateTo.Focus();
                    throw new Exception("Please enter the range date!");
                }
            }

            string paymentType = dcmbPayment.GetItemText(dcmbPayment.SelectedItem);

            if (paymentType == "CASH" || string.IsNullOrEmpty(paymentType))
            {
                if (txtDateFrom.DateTime != DateTime.MinValue)
                {
                    DateTime fromDateSearch = Convert.ToDateTime(txtDateFrom.DateTime.ToString("yyyy-MM-dd") + " " + "00:00:01");
                    p.Add(WhereTerm.Default(fromDateSearch, "date_process", EnumSqlOperator.GreatThanEqual));
                }
                if (txtDateTo.DateTime != DateTime.MinValue)
                {
                    DateTime toDateSearch = Convert.ToDateTime(txtDateTo.DateTime.ToString("yyyy-MM-dd") + " " + "23:59:59");
                    p.Add(WhereTerm.Default(toDateSearch, "date_process", EnumSqlOperator.LesThanEqual));
                }

                if (txtInvoiceNumber.Text != "") p.Add(WhereTerm.Default(txtInvoiceNumber.Text, "invoice_ref"));
                if (txtReceiptNumber.Text != "") p.Add(WhereTerm.Default(txtReceiptNumber.Text, "payment_receipt_number"));
                if (dcmbPayment.SelectedValue != null) p.Add(WhereTerm.Default((int)dcmbPayment.SelectedValue, "payment_method_id"));
            }
            else
            {
                if (txtDateFrom.DateTime != DateTime.MinValue)
                {
                    DateTime fromDateSearch = Convert.ToDateTime(txtDateFrom.DateTime.ToString("yyyy-MM-dd") + " " + "00:00:01");
                    p.Add(WhereTerm.Default(fromDateSearch, "createddate", EnumSqlOperator.GreatThanEqual, "sales_invoice_list"));
                }
                if (txtDateTo.DateTime != DateTime.MinValue)
                {
                    DateTime toDateSearch = Convert.ToDateTime(txtDateTo.DateTime.ToString("yyyy-MM-dd") + " " + "23:59:59");
                    p.Add(WhereTerm.Default(toDateSearch, "createddate", EnumSqlOperator.LesThanEqual, "sales_invoice_list"));
                }

                if (txtInvoiceNumber.Text != "") p.Add(WhereTerm.Default(txtInvoiceNumber.Text, "invoice_ref"));
                if (txtReceiptNumber.Text != "") p.Add(WhereTerm.Default(txtReceiptNumber.Text, "payment_receipt_number"));
                if (dcmbPayment.SelectedValue != null) p.Add(WhereTerm.Default((int)dcmbPayment.SelectedValue, "payment_method_id"));
            }

            return p.ToArray();
        }

        public static new TDerived ConvertModel<TBase, TDerived>(IBaseModel source)
            where TBase : IBaseModel
            where TDerived : TBase
        {
            var derivedType = typeof(TDerived);
            var instance = Activator.CreateInstance(derivedType);

            PropertyInfo[] properties = typeof(TBase).GetProperties();
            foreach (var property in properties)
            {
                property.SetValue(instance, property.GetValue(source, null), null);
            }

            return (TDerived)instance;
        }
    }
}
