using Devenlab.Common;
using Devenlab.Common.Interfaces;
using SISCO.App.Billing;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.MasterData.Popup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISCO.Presentation.Billing.Popup
{
    public partial class SelectShipmentPopup : Form
    {
        private List<SalesInvoiceRevised> InvoiceRevisions { get; set; }
        private string _cancellationInvoice { get; set; }
        private int? _idExistsInvoice { get; set; }

        public SelectShipmentPopup(string _currentInvoice, List<SalesInvoiceRevised> _invoiceRevisions, int? idExistsInvoice = null)
        {
            InitializeComponent();

            lkpCustomer.LookupPopup = new CustomerPopup(WhereTerm.Default(BaseControl.BranchId, "branch_id"));
            lkpCustomer.AutoCompleteDataManager = new CustomerDataManager();
            lkpCustomer.AutoCompleteDisplayFormater = model => ((CustomerModel)model).Code + " - " + ((CustomerModel)model).Name;
            lkpCustomer.AutoCompleteWhereExpression = (s, p) => p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) and branch_id = @1", s, BaseControl.BranchId);

            lkpDestinationCity.LookupPopup = new CityPopup();
            lkpDestinationCity.AutoCompleteDataManager = new CityDataManager();
            lkpDestinationCity.AutoCompleteDisplayFormater = model => ((CityModel)model).Name;
            lkpDestinationCity.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            lkpPackageType.LookupPopup = new PackageTypePopup();
            lkpPackageType.AutoCompleteDataManager = new PackageTypeDataManager();
            lkpPackageType.AutoCompleteDisplayFormater = model => ((PackageTypeModel)model).Name;
            lkpPackageType.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            lkpPaymentMethod.LookupPopup = new PaymentMethodPopup();
            lkpPaymentMethod.AutoCompleteDataManager = new PaymentMethodDataManager();
            lkpPaymentMethod.AutoCompleteDisplayFormater = model => ((PaymentMethodModel)model).Name;
            lkpPaymentMethod.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            InvoiceRevisions = new List<SalesInvoiceRevised>();
            _cancellationInvoice = _currentInvoice;
            InvoiceRevisions = _invoiceRevisions;
            _idExistsInvoice = idExistsInvoice;

            Load += SelectShipmentForInvoiceForm_Load;
        }

        void SelectShipmentForInvoiceForm_Load(object sender, EventArgs e)
        {
            Shipments = new BindingList<ShipmentModel>();

            lkpCustomer.DefaultValue = new IListParameter[] { WhereTerm.Default(FilterCustomerId, "id") };
            grid.DataSource = Shipments;

            Shipments.ListChanged += (o, args) =>
            {
                txtTotalRecords.Text = Shipments.Count.ToString(CultureInfo.InvariantCulture);
            };
        }

        public DateTime FilterDateFrom
        {
            set { txtDateFrom.DateTime = value; }
            get { return txtDateFrom.DateTime; }
        }
        public DateTime FilterDateTo
        {
            set { txtDateTo.DateTime = value; }
            get { return txtDateTo.DateTime; }
        }
        public int? FilterDestCityId
        {
            set
            {
                if (value != null && value != 0)
                {
                    lkpDestinationCity.DefaultValue = new IListParameter[] { WhereTerm.Default((int)value, "id") };
                }
            }
            get { return lkpDestinationCity.Value; }
        }
        public string FilterDestCityName
        {
            get { return lkpDestinationCity.Value != null ? lkpDestinationCity.Text : string.Empty; }
        }
        public int? FilterPackageTypeId
        {
            set
            {
                if (value != null && value != 0)
                {
                    lkpPackageType.DefaultValue = new IListParameter[] { WhereTerm.Default((int)value, "id") };
                }
            }
            get { return lkpPackageType.Value; }
        }
        public int? FilterPaymentMethodId
        {
            set
            {
                if (value != null && value != 0)
                {
                    lkpPaymentMethod.DefaultValue = new IListParameter[] { WhereTerm.Default((int)value, "id") };
                }
            }
            get { return lkpPaymentMethod.Value; }
        }
        public string FilterPeriod
        {
            set { txtPeriod.Text = value; }
            get { return txtPeriod.Text; }
        }
        public int FilterIsPersonal { get; set; }
        public int FilterCustomerId { get; set; }
        public int[] FilterExcludeShipmentIds { get; set; }

        public BindingList<ShipmentModel> Shipments;

        public IEnumerable<ShipmentModel> SelectedShipmentList
        {
            get
            {
                var selectedRows = gridView.GetSelectedRows();
                var shipments = Shipments.Where((row, i) => Array.Exists(selectedRows, x => x == i)).ToList();

                if (_idExistsInvoice != null)
                {
                    var exSalesList = new ShipmentDataManager().Get<ShipmentModel>(WhereTerm.Default((int)_idExistsInvoice, "invoice_id"));
                    if (exSalesList.Count() > 0)
                    {
                        exSalesList.ToList().ForEach(row =>
                        {
                            row.StateChange = EnumStateChange.Idle;
                            shipments.Add(row);
                        });
                    }

                    var lastShipments = shipments.OrderBy(p => p.DateProcess.Date).ThenBy(p => p.Code).ToList();
                    shipments.Clear();
                    lastShipments.ForEach(row => shipments.Add(row));

                    txtTotalRecords.Text = shipments.Count.ToString("#,0");
                }

                return shipments;
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            Shipments.RaiseListChangedEvents = false;
            Shipments.Clear();

            var whereClauses = new List<IListParameter>();

            if (txtDateFrom.DateTime != DateTime.MinValue)
            {
                whereClauses.Add(WhereTerm.Default(txtDateFrom.DateTime.Date, "date_process", EnumSqlOperator.GreatThanEqual));
            }
            if (txtDateTo.DateTime != DateTime.MinValue)
            {
                whereClauses.Add(WhereTerm.Default(txtDateTo.DateTime.Date.AddDays(1), "date_process", EnumSqlOperator.LesThanEqual));
            }
            if (lkpDestinationCity.Value != null)
            {
                whereClauses.Add(WhereTerm.Default((int)lkpDestinationCity.Value, "dest_city_id"));
            }
            if (lkpPackageType.Value != null)
            {
                whereClauses.Add(WhereTerm.Default((int)lkpPackageType.Value, "package_type_id"));
            }
            if (lkpPaymentMethod.Value != null)
            {
                whereClauses.Add(WhereTerm.Default((int)lkpPaymentMethod.Value, "payment_method_id"));
            }

            whereClauses.Add(WhereTerm.Default(FilterIsPersonal == 1, "personal"));
            whereClauses.Add(WhereTerm.Default(true, "posted"));
            whereClauses.Add(WhereTerm.Default(0, "invoiced"));
            whereClauses.Add(WhereTerm.Default(false, "voided"));

            new ShipmentDataManager()
                .GetGetCreditCollectOnlyExclude<ShipmentModel>((int)lkpCustomer.Value, whereClauses.ToArray(), FilterExcludeShipmentIds)
                .OrderBy(r => r.DateProcess.Date).ThenBy(r => r.Code).ToList()
                .ForEach(row =>
                {
                    row.StateChange = EnumStateChange.Insert;
                    Shipments.Add(row);
                });

            var salesInvoice = new SalesInvoiceDataManager().GetFirst<SalesInvoiceModel>(WhereTerm.Default(_cancellationInvoice, "ref_number"));
            if (salesInvoice == null)
            {
                MessageBox.Show(string.Format("Nomor kwitansi {0} yang akan di cancel tidak dikenali.", _cancellationInvoice));
                return;
            }

            var salesList = new ShipmentDataManager().Get<ShipmentModel>(WhereTerm.Default(salesInvoice.Id, "invoice_id"));
            if (salesList.Count() > 0)
            {
                salesList.ToList().ForEach(row =>
                {
                    row.StateChange = EnumStateChange.Insert;
                    Shipments.Add(row);
                });
            }

            var invoiceList = new List<SalesInvoiceListModel>();
            foreach (var r in InvoiceRevisions)
            {
                invoiceList.AddRange(r.SalesInvoiceList);
            }

            if (invoiceList.Count > 0)
            {
                var shipments = Shipments.ToList().Where(p => !invoiceList.Select(d => d.ShipmentCode).ToList().Contains(p.Code)).ToList();
                Shipments.Clear();
                shipments.ForEach(row => Shipments.Add(row));
            }

            var lastShipments = Shipments.OrderBy(p => p.DateProcess.Date).ThenBy(p => p.Code).ToList();
            Shipments.Clear();
            lastShipments.ForEach(row => Shipments.Add(row));

            txtTotalRecords.Text = Shipments.Count.ToString("#,0");

            Shipments.RaiseListChangedEvents = true;
            Shipments.ResetBindings();

            gridView.SelectAll();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Shipments.Clear();
            Close();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            gridView.SelectAll();
        }

        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            gridView.ClearSelection();
        }
    }
}