using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.XtraGrid.Views.Grid;
using SISCO.App.Billing;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Windows.Forms;

namespace SISCO.Presentation.Billing.Popup
{
    public partial class InvoiceRevisionPopup : BaseForm
    {
        private decimal _fixedMateraiPrice;
        private const int PRICING_PLAN_DOMESTIC = 1;
        private const int SALES_INVOICE_TYPE_CORPORATE = 3;
        private const int SALES_INVOICE_TYPE_PERSONAL = 4;
        private string _cancellationInvoice { get; set; }
        private List<SalesInvoiceRevised> InvoiceRevisions { get; set; }
        private string RefNumber { get; set; }

        public SalesInvoiceRevised NewInvoice { get; set; }
        private int? idExistsInvoice { get; set; }

        public List<ShipmentModel> ShipmentRevisions { get; set; }

        public class SalesInvoiceListDataRow : SalesInvoiceListModel
        {
            public Int32 Index { get; set; }
            public decimal TariffTotalInBaseCurrency
            {
                get { return !string.IsNullOrEmpty(Currency) ? TotalTariff * CurrencyRate : TotalTariff; }
            }
            public bool Revised { get; set; }
        }

        protected ExtendedBindingList<SalesInvoiceListDataRow> Shipments { get; set; }
        protected BindingList<TaxTypeModel> TaxTypes { get; set; }
        protected BindingList<SalesInvoiceCostModel> Costs { get; set; }

        public InvoiceRevisionPopup(string _currentInvoice, string _refNumber, List<SalesInvoiceRevised> _invoiceRevisions)
        {
            InitializeComponent();
            form = this;

            Load += FormLoad;
            Shown += FormShow;

            ShipmentRevisions = new List<ShipmentModel>(); ;
            InvoiceRevisions = new List<SalesInvoiceRevised>();
            _cancellationInvoice = _currentInvoice;
            InvoiceRevisions = _invoiceRevisions;
            //grid.DoubleClick += (sender, args) => OpenRelatedForm(gridView, new ValidateShipmentPopup());
            grid.DoubleClick += ValidatePod;
            RefNumber = _refNumber;
            gridView.RowCellStyle += ChangeColor;
        }

        private void ChangeColor(object sender, RowCellStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var view = sender as GridView;

                e.Appearance.BackColor = Color.Transparent;
                e.Appearance.ForeColor = Color.Black;

                if (view != null && view.GetRowCellValue(e.RowHandle, view.Columns["Revised"]) != null)
                {
                    if (Convert.ToBoolean(view.GetRowCellValue(e.RowHandle, view.Columns["Revised"])))
                        e.Appearance.ForeColor = Color.Red;
                }
            }
        }

        private void ValidatePod(object sender, EventArgs e)
        {
            var rows = gridView.GetSelectedRows();

            if (rows.Count() > 0)
            {
                var scode = gridView.GetRowCellValue(rows[0], "ShipmentCode").ToString();
                var validatePopup = new ValidateShipmentPopup(scode)
                {
                    StartPosition = FormStartPosition.CenterScreen,
                    ShowInTaskbar = false,
                    ReValidateShipment = ShipmentRevisions.FirstOrDefault(p => p.Code == scode)
                };
                
                validatePopup.ShowDialog();

                if (validatePopup.ValidateShipment != null)
                {
                    var sRev = ShipmentRevisions.FirstOrDefault(p => p.Code == validatePopup.ValidateShipment.Code);
                    if (sRev == null) ShipmentRevisions.Add(validatePopup.ValidateShipment);
                    else
                    {
                        ShipmentRevisions.ForEach(p =>
                        {
                            if (p.Code == validatePopup.ValidateShipment.Code)
                            {
                                p = validatePopup.ValidateShipment;
                            }
                        });
                    }

                    var shipmentRow = Shipments.FirstOrDefault(p => p.ShipmentCode == validatePopup.ValidateShipment.Code);

                    if (shipmentRow != null)
                    {
                        var model = validatePopup.ValidateShipment;

                        Shipments[shipmentRow.Index - 1].ShipmentCode = model.Code;
                        Shipments[shipmentRow.Index - 1].ShipmentProcessDate = model.DateProcess;

                        var dest = new CityDataManager().GetFirst<CityModel>(WhereTerm.Default(model.DestCityId, "id"));
                        Shipments[shipmentRow.Index - 1].DestinationCity = dest.Name;
                        Shipments[shipmentRow.Index - 1].TotalPiece = model.TtlPiece;
                        Shipments[shipmentRow.Index - 1].TotalChargeableWeight = model.TtlChargeableWeight;

                        var service = new ServiceDataManager().GetFirst<ServiceTypeModel>(WhereTerm.Default(model.ServiceTypeId, "id"));
                        Shipments[shipmentRow.Index - 1].ServiceType = service.Name;
                        Shipments[shipmentRow.Index - 1].TariffPerKg = model.Tariff;
                        Shipments[shipmentRow.Index - 1].TotalTariff = model.TariffTotal;
                        Shipments[shipmentRow.Index - 1].HandlingFee = model.HandlingFee;
                        Shipments[shipmentRow.Index - 1].PackingFee = model.PackingFee;

                        Shipments[shipmentRow.Index - 1].Discount = model.DiscountTotal;
                        Shipments[shipmentRow.Index - 1].NetTariff = model.TariffNet;
                        Shipments[shipmentRow.Index - 1].OtherFee = model.OtherFee;
                        Shipments[shipmentRow.Index - 1].InsuranceFee = model.InsuranceFee;
                        Shipments[shipmentRow.Index - 1].GrandTotalInBaseCurrency = model.TariffNet + model.PackingFee + model.OtherFee + model.InsuranceFee;
                        Shipments[shipmentRow.Index - 1].GrandTotal = model.Total;
                        Shipments[shipmentRow.Index - 1].Currency = model.Currency;
                        Shipments[shipmentRow.Index - 1].CurrencyRate = model.CurrencyRate;
                        Shipments[shipmentRow.Index - 1].Revised = true;

                        Shipments.RaiseListChangedEvents = true;
                        Shipments.ResetBindings();
                        gridView.RefreshData();

                        RefreshGrandTotals();
                    }
                }
            }
        }

        private void FormShow(object sender, EventArgs e)
        {
            ClearForm();
            txtReceiptNo.Focus();
            txtPeriod.Text = DateTime.Now.ToString("yyyyMM");

            txtTotalDiscountTotal.Value = 0;
            txtRaFeePerPiece.Value = 0;
            txtMateraiFee.Value = _fixedMateraiPrice;

            var now = DateTime.Now;
            txtDate.DateTime = now;
            txtDueDate.DateTime = now;
            txtFilterDateFrom.Text = new DateTime(now.Year, now.Month, 1).ToString("dd/MM/yyyy");
            txtFilterDateTo.Text = new DateTime(now.Year, now.Month, DateTime.DaysInMonth(now.Year, now.Month)).ToString("dd/MM/yyyy");

            txtGrandTotal.Enabled = false;

            txtRaCwTotal.Enabled = false;
            txtTotalRaFee.Enabled = false;
            txtTotalDiscountTotal.Enabled = false;
            txtCurrencyRate.Enabled = false;
            txtBeforeTax.Enabled = false;
            txtTaxTotal.Enabled = false;
            txtGrandTotal.Enabled = false;

            txtPeriod.Enabled = false;
            txtFilterDateFrom.Enabled = false;
            txtFilterDateTo.Enabled = false;
            txtFilterDestinationCity.Enabled = false;

            txtTotalInternational.Enabled = false;
            txtTotalDomestic.Enabled = false;
            txtTotalCityCourier.Enabled = false;
            txtTotalSales.Enabled = false;

            btnAddShipment.Enabled = true;
            btnAddOtherFee.Enabled = true;
            btnDeleteOtherFee.Enabled = true;
            btnDeleteShipment.Enabled = true;

            btnGetData.Enabled = true;

            Shipments.Clear();
            Costs.Clear();

            using (var branchDm = new BranchDataManager())
            {
                var branch = branchDm.GetFirst<BranchModel>(WhereTerm.Default(BaseControl.BranchId, "id"));
                if (branch != null)
                {
                    txtRaFeePerPiece.Value = branch.RaFee;
                }
            }

            cmbTaxInvoice.SelectedIndex = -1;

            var model = new SalesInvoiceDataManager().GetFirst<SalesInvoiceModel>(WhereTerm.Default(_cancellationInvoice, "ref_number"));
            if (model == null)
            {
                MessageBox.Show(string.Format("Nomor kwitansi {0} tidak dikenali.", _cancellationInvoice));
                return;
            }

            lkpCustomer.Enabled = true;
            lkpCustomer.Properties.Buttons[0].Enabled = true;
            idExistsInvoice = null;

            var existsInvoice = new SalesInvoiceDataManager().GetFirst<SalesInvoiceModel>(WhereTerm.Default(RefNumber, "ref_number"));
            if (existsInvoice != null)
            {
                if (!existsInvoice.Printed && !existsInvoice.ReqTaxInvoice)
                {
                    DialogResult r = MessageBox.Show(@"Nomor Kwitansi sudah digunakan, apa anda akan menambahkan pod ke nomor kwitansi tsb?", "",
                    MessageBoxButtons.YesNo);

                    if (r == DialogResult.No) return;
                    lkpCustomer.DefaultValue = new IListParameter[] { WhereTerm.Default(existsInvoice.CompanyId, "id") };
                    lkpCustomer.Enabled = false;
                    lkpCustomer.Properties.Buttons[0].Enabled = false;
                    idExistsInvoice = existsInvoice.Id;

                    model.Description1 = existsInvoice.Description1;
                    model.Description2 = existsInvoice.Description2;
                    model.Description3 = existsInvoice.Description3;
                }
                else
                {
                    MessageBox.Show(string.Format("Nomor kwitansi {0} sudah digunakan.", RefNumber));
                    return;
                }
            }

            PopulateForm(model);
            NewInvoice = null;
        }

        private void PopulateForm(SalesInvoiceModel model)
        {
            var now = DateTime.Now;
            txtDate.DateTime = now;
            txtReceiptNo.Text = RefNumber;
            txtReceiptNo.Enabled = false;

            txtDescription1.Text = model.Description1;
            txtDescription2.Text = model.Description2;
            txtDescription3.Text = model.Description3;
        }

        private void FormLoad(object sender, EventArgs e)
        {
            try
            {
                using (var configDm = new ConfigDataManager())
                {
                    _fixedMateraiPrice = decimal.Parse(configDm.Get("FixedMateraiPrice"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"The materai price & RA fee setting must be correctly set in the config table (FixedMateraiPrice)", @"Error!");
                throw new Exception("The materai price & RA fee setting must be correctly set in the config table (FixedMateraiPrice)", ex);
            }

            lkpCustomer.LookupPopup = new CustomerPopup();
            lkpCustomer.AutoCompleteDataManager = new CustomerDataManager();
            lkpCustomer.AutoCompleteDisplayFormater =
                model => ((CustomerModel)model).Code + " - " + ((CustomerModel)model).Name;
            lkpCustomer.AutoCompleteWhereExpression = (s, param) => param.SetWhereExpression("(code = @0 or name.StartsWith(@0)) and branch_id = @1", s, BaseControl.BranchId);
            lkpCustomer.FieldLabel = "Customer";

            using (var salesInvoiceTypeDm = new SalesInvoiceTypeDataManager())
            {
                cmbFilterCustomerType.DataSource = salesInvoiceTypeDm.Get<SalesInvoiceTypeModel>();
            }
            cmbFilterCustomerType.DisplayMember = "Name";
            cmbFilterCustomerType.ValueMember = "Id";

            using (var taxInvoiceDm = new TaxInvoiceDataManager())
            {
                cmbTaxInvoice.DataSource = taxInvoiceDm.Get<TaxInvoiceModel>();
            }
            cmbTaxInvoice.DisplayMember = "Name";
            cmbTaxInvoice.ValueMember = "Id";

            TaxTypes = new BindingList<TaxTypeModel>(new TaxTypeDataManager().Get<TaxTypeModel>().ToList());
            cmbTaxType.DataSource = TaxTypes;
            cmbTaxType.DisplayMember = "Name";
            cmbTaxType.ValueMember = "Id";

            lkpCustomer.TextChanged += (o, args) =>
            {
                if (lkpCustomer.Value == null) return;

                using (var customerDm = new CustomerDataManager())
                {
                    var customer = customerDm.GetFirst<CustomerModel>(WhereTerm.Default((int)lkpCustomer.Value, "id"));
                    if (customer != null)
                    {
                        txtInvoicedTo.Text = customer.Name;
                        txtDueDate.DateTime = DateTime.Now.AddDays((int)customer.Credit);

                        txtDiscountPercent.Value = customer.Discount;
                        if (customer.TaxInvoiceId != null) cmbTaxInvoice.SelectedValue = customer.TaxInvoiceId;
                        else cmbTaxInvoice.SelectedIndex = -1;

                        Shipments.Clear();
                    }
                }
            };

            btnAddShipment.Click += (o, args) =>
            {
                if (txtAddShipmentNo.Text.Trim() == string.Empty)
                {
                    MessageBox.Show(@"Please enter a shipment number!");
                    return;
                }

                using (var shipmentDm = new ShipmentDataManager())
                {
                    if (lkpCustomer.Value == null)
                    {
                        MessageBox.Show(@"Please select a customer first!");
                        return;
                    }

                    var existing = from a in Shipments where a.ShipmentCode.Equals(txtAddShipmentNo.Text) select a;
                    if (existing.Any())
                    {
                        MessageBox.Show(@"Shipment already listed!");
                        return;
                    }

                    var shipment = shipmentDm.GetFirst<ShipmentModel>(WhereTerm.Default(txtAddShipmentNo.Text, "code"));

                    if (shipment == null)
                    {
                        MessageBox.Show(@"POD tidak ditemukan!");
                        return;
                    }
                    if (lkpCustomer.Value != shipment.CustomerId)
                    {
                        MessageBox.Show(@"Wrong customer!");
                        return;
                    }
                    if (shipment.Posted == false)
                    {
                        MessageBox.Show(@"POD belum divalidasi!");
                        return;
                    }
                    if (shipment.PaymentMethod != null && shipment.PaymentMethod.Equals("CASH"))
                    {
                        MessageBox.Show(@"POD Cash tidak bisa dibuat invoice!");
                        return;
                    }
                    if (shipment.Invoiced == 1)
                    {
                        var salesInvoice = new SalesInvoiceDataManager().GetFirst<SalesInvoiceModel>(WhereTerm.Default((int)shipment.InvoiceId, "id"));
                        if (salesInvoice != null)
                        {
                            if (salesInvoice.RefNumber != _cancellationInvoice)
                            {
                                MessageBox.Show(@"POD sudah dibuat invoice!");
                                return;
                            }
                        }
                    }
                    if (((int)cmbFilterCustomerType.SelectedValue) == SALES_INVOICE_TYPE_CORPORATE && shipment.Personal)
                    {
                        MessageBox.Show(@"POD pribadi tidak bisa dimasukan ke dalam invoice perusahaan!");
                        return;
                    }
                    if (((int)cmbFilterCustomerType.SelectedValue) == SALES_INVOICE_TYPE_PERSONAL && !shipment.Personal)
                    {
                        MessageBox.Show(@"POD perusahaan tidak bisa dimasukan ke dalam invoice pribadi!");
                        return;
                    }

                    var list = new List<SalesInvoiceListModel>
                    {
                        new SalesInvoiceListModel
                        {
                            SalesInvoiceId = 0,
                            ShipmentId = shipment.Id,
                            ShipmentCode = shipment.Code,
                            ShipmentProcessDate = shipment.DateProcess,
                            DestinationCity = shipment.DestCity,
                            TotalPiece = shipment.TtlPiece,
                            TotalChargeableWeight = shipment.TtlChargeableWeight,
                            ServiceTypeId = shipment.ServiceTypeId,
                            ServiceType =
                                new ServiceTypeDataManager().GetFirst<ServiceTypeModel>(
                                    WhereTerm.Default(shipment.ServiceTypeId, "id"))
                                    .Name,
                            PackageTypeId = shipment.ServiceTypeId,
                            PackageType =
                                new PackageTypeDataManager().GetFirst<PackageTypeModel>(
                                    WhereTerm.Default(shipment.PackageTypeId, "id"))
                                    .Name,
                            // ReSharper disable once PossibleInvalidOperationException
                            PricingPlanId = (int) shipment.PricingPlanId,
                            NeedRa = shipment.NeedRa,
                            TariffPerKg = shipment.Tariff,
                            HandlingFee = shipment.HandlingFeeTotal,
                            PackingFee = shipment.PackingFee,
                            TotalTariff = shipment.TariffTotal,
                            Discount = shipment.DiscountTotal,
                            NetTariff = shipment.TariffNet,
                            OtherFee = shipment.OtherFee,
                            InsuranceFee = shipment.InsuranceFee,
                            GrandTotal = shipment.Total,
                            GrandTotalInBaseCurrency = shipment.Total,
                            Currency = shipment.Currency,
                            CurrencyRate = shipment.CurrencyRate,
                            Invoiced = true,

                            Createddate = DateTime.Now,
                            Createdby = BaseControl.UserLogin,
                            Rowstatus = true,
                            Rowversion = DateTime.Now,
                            NewRow = true
                        }
                    };

                    PopulateShipmentList(list, true);

                    txtAddShipmentNo.Text = "";
                    txtAddShipmentNo.Focus();
                }
            };

            txtRaFeePerPiece.TextChanged += TxtRaFeePerPieceOnTextChanged;
            txtRaCwTotal.TextChanged += TxtRaFeePerPieceOnTextChanged;

            txtMateraiFee.TextChanged += (o, args) => RefreshGrandTotalsAfterMaterai();
            cmbTaxType.SelectedValueChanged += (o, args) => RefreshGrandTotals();

            btnAddOtherFee.Click += (o, args) =>
            {
                gridViewOtherFee.AddNewRow();

                gridViewOtherFee.FocusedRowHandle = Costs.Count - 1;
                gridOtherFee.Focus();
                gridViewOtherFee.FocusedColumn = gridColumn35;
            };

            Shipments = new ExtendedBindingList<SalesInvoiceListDataRow>();
            Costs = new BindingList<SalesInvoiceCostModel>();

            grid.DataSource = Shipments;
            gridOtherFee.DataSource = Costs;

            btnDeleteShipment.Click += (o, args) =>
            {
                gridView.DeleteSelectedRows();
                RefreshGrandTotals();
            };
            btnDeleteOtherFee.Click += (o, args) => gridViewOtherFee.DeleteSelectedRows();

            btnCancel.Click += (o, args) => Close();
            btnFinish.Click += Save;

            Shipments.ListChanged += (o, args) =>
            {
                for (var i = 0; i < Shipments.Count; i++)
                {
                    Shipments[i].Index = i + 1;
                }

                txtTotalCityCourier.Value =
                    (from a in Shipments where a.ServiceType.ToUpper().Equals("CITY COURIER") select a.TariffTotalInBaseCurrency).Sum();
                txtTotalDomestic.Value =
                    (from a in Shipments where !a.ServiceType.ToUpper().Equals("CITY COURIER") && a.PricingPlanId == PRICING_PLAN_DOMESTIC select a.TariffTotalInBaseCurrency).Sum();
                txtTotalInternational.Value =
                    (from a in Shipments where a.PricingPlanId != PRICING_PLAN_DOMESTIC select a.TariffTotalInBaseCurrency).Sum();
                txtTotalSales.Value =
                    (from a in Shipments select a.TariffTotalInBaseCurrency).Sum();
                txtRaCwTotal.Value =
                    (from a in Shipments where a.NeedRa select a.TotalChargeableWeight).Sum();

                RefreshGrandTotals();
            };

            gridViewOtherFee.CellValueChanged += (o, args) => RefreshGrandTotals();
        }

        private void Save(object sender, EventArgs e)
        {
            if (txtDate.DateTime == DateTime.MinValue)
            {
                MessageBox.Show("Please enter the invoice date!");
                txtDate.Focus();
                return;
            }
            if (txtReceiptNo.Text == "")
            {
                MessageBox.Show("Please enter the receipt number!");
                txtReceiptNo.Focus();
                return;
            }
            if (lkpCustomer.Value == null)
            {
                MessageBox.Show("Please select a customer!");
                lkpCustomer.Focus();
                return;
            }
            if (txtInvoicedTo.Text == "")
            {
                MessageBox.Show("Please enter the invoice recipient (Invoiced To)!");
                txtInvoicedTo.Focus();
                return;
            }
            if (txtDate.DateTime == DateTime.MinValue)
            {
                MessageBox.Show("Please enter the invoice due date!");
                txtDate.Focus();
                return;
            }

            if (cmbTaxInvoice.SelectedValue == null)
            {
                MessageBox.Show("Please selecte tax invoice");
                cmbTaxInvoice.Focus();
                return;
            }

            if (!Shipments.Any())
            {
                MessageBox.Show("Invoice harus berisi POD!");
                return;
            }

            var CurrentModel = PopulateModel(new SalesInvoiceModel());
            NewInvoice = new SalesInvoiceRevised();
            NewInvoice.SalesInvoice = CurrentModel;

            var ships = new List<SalesInvoiceListModel>();
            foreach (var s in Shipments)
            {
                ships.Add(s as SalesInvoiceListModel);
            }

            NewInvoice.SalesInvoiceList = ships;
            NewInvoice.SalesCosts = Costs.ToList();

            Close();
        }

        private SalesInvoiceModel PopulateModel(SalesInvoiceModel model)
        {
            model.BranchId = BaseControl.BranchId;

            model.Vdate = txtDate.DateTime;
            model.RefNumber = txtReceiptNo.Text;

            model.CompanyName = lkpCustomer.Text;
            if (lkpCustomer.Value != null) model.CompanyId = (int)lkpCustomer.Value;

            model.CompanyInvoicedTo = txtInvoicedTo.Text;
            model.DueDate = txtDueDate.DateTime;

            model.Description = txtDescription1.Text;
            model.Description1 = txtDescription1.Text;
            model.Description2 = txtDescription2.Text;
            model.Description3 = txtDescription3.Text;

            if (cmbFilterCustomerType.SelectedValue != null)
            {
                model.SalesInvoiceTypeId = (int)cmbFilterCustomerType.SelectedValue;
                model.FilterSalesInvoiceTypeId = (int)cmbFilterCustomerType.SelectedValue;
            }

            model.Period = Convert.ToInt32(txtPeriod.Text);
            model.DateFrom = DateTime.ParseExact(txtFilterDateFrom.Text, "dd/MM/yyyy", null);
            model.DateTo = DateTime.ParseExact(txtFilterDateTo.Text, "dd/MM/yyyy", null);

            model.TotalServiceTariff1 = (decimal)txtTotalDomestic.Value;
            model.TotalServiceTariff2 = (decimal)txtTotalDomestic.Value;
            model.TotalServiceTariff3 = (decimal)txtTotalInternational.Value;
            model.TotalRecord = Shipments.Count;
            model.TotalDiscount = (from a in Shipments select a.Discount).Sum();
            model.TotalPacking = (from a in Shipments select a.PackingFee).Sum();
            model.TotalOther = (from a in Shipments select a.OtherFee).Sum();

            model.RaChargeableWeight = txtRaCwTotal.Value;
            model.RaFee = txtRaFeePerPiece.Value;
            model.RaTotal = txtTotalRaFee.Value;
            model.CostMaterai = txtMateraiFee.Value;
            model.Discount = txtTotalDiscountTotal.Value;
            model.CurrencyRate = txtCurrencyRate.Value;

            model.Printed = false;
            model.Cancelled = false;

            model.InvoiceRevisionOf = _cancellationInvoice;
            if (idExistsInvoice != null)
            {
                var currentInvoice = new SalesInvoiceDataManager().GetFirst<SalesInvoiceModel>(WhereTerm.Default(txtReceiptNo.Text, "ref_number"));
                if (currentInvoice != null)
                {
                    if (!string.IsNullOrEmpty(currentInvoice.InvoiceRevisionOf))
                    {
                        var l = new List<string>();
                        l = currentInvoice.InvoiceRevisionOf.Split(',').ToList();
                        l.Add(txtReceiptNo.Text);
                        model.InvoiceRevisionOf = string.Join(",", l);
                    }
                }
            }
            
            model.Total = txtGrandTotal.Value;

            model.TaxTypeId = (int)cmbTaxType.SelectedValue;
            model.TaxRate = TaxTypes[cmbTaxType.SelectedIndex].Rate;
            model.TaxTotal = txtTaxTotal.Value;
            model.TaxInvoiceId = (int) cmbTaxInvoice.SelectedValue;

            using (var customerDm = new CustomerDataManager())
            {
                var customer = customerDm.GetFirst<CustomerModel>(WhereTerm.Default(model.CompanyId, "id"));
                if (customer != null && customer.MarketingEmployeeId != null)
                {
                    model.EmployeeId = (int)customer.MarketingEmployeeId;
                }
            }

            return model;
        }

        private void PopulateShipmentList(IEnumerable<SalesInvoiceListModel> shipmentModels, bool isAppend = false)
        {
            Shipments.RaiseListChangedEvents = false;

            if (!isAppend)
            {
                Shipments.Clear();
            }

            if (shipmentModels.Any())
            {
                UpdateCurrencyRate(shipmentModels.First().Currency);
            }

            var toBeAdded = shipmentModels
                .Select((row, i) => new SalesInvoiceListDataRow
                {
                    Index = i + 1,

                    Id = row.Id,
                    SalesInvoiceId = row.SalesInvoiceId,
                    ShipmentId = row.ShipmentId,
                    ShipmentCode = row.ShipmentCode,
                    ShipmentProcessDate = row.ShipmentProcessDate,
                    DeliveredDate = row.DeliveredDate,
                    Recipient = row.Recipient,
                    ConsigneeName = row.ConsigneeName,
                    TotalPiece = row.TotalPiece,
                    TotalChargeableWeight = row.TotalChargeableWeight,
                    ServiceTypeId = row.ServiceTypeId,
                    ServiceType = row.ServiceType,
                    PackageTypeId = row.PackageTypeId,
                    PackageType = row.PackageType,
                    TariffPerKg = row.TariffPerKg,
                    HandlingFee = row.HandlingFee,
                    PackingFee = row.PackingFee,
                    TotalTariff = row.TotalTariff,
                    Discount = row.Discount,
                    NetTariff = row.NetTariff,
                    OtherFee = row.OtherFee,
                    InsuranceFee = row.InsuranceFee,
                    GrandTotal = row.GrandTotalInBaseCurrency * txtCurrencyRate.Value,
                    GrandTotalInBaseCurrency = row.GrandTotalInBaseCurrency,
                    DestinationCity = row.DestinationCity,
                    Currency = row.Currency,
                    //CurrencyRate = row.CurrencyRate,
                    CurrencyRate = txtCurrencyRate.Value,
                    NeedRa = row.NeedRa,
                    Invoiced = row.Invoiced,
                    PricingPlanId = row.PricingPlanId,

                    Rowstatus = row.Rowstatus,
                    Rowversion = row.Rowversion,
                    Createddate = row.Createddate,
                    Createdby = row.Createdby,
                    Modifieddate = row.Modifieddate,
                    Modifiedby = row.Modifiedby,
                    NewRow = row.NewRow,
                    StateChange = row.StateChange
                });

            foreach (var row in toBeAdded)
            {
                if (Shipments.Any() && row.Currency != Shipments.First().Currency)
                {
                    MessageBox.Show(@"Satu invoice hanya bisa berisi POD dengan mata uang yang sama!");
                    break;
                }

                Shipments.Add(row);
            }

            var copied = new SalesInvoiceListDataRow[Shipments.Count];
            Shipments.CopyTo(copied, 0);

            Shipments.Clear();
            copied.OrderBy(r => r.ShipmentProcessDate.Date).ThenBy(r => r.ShipmentCode).ToList().ForEach(r => Shipments.Add(r));

            Shipments.RaiseListChangedEvents = true;
            Shipments.ResetBindings();

            int value = gridView.RowCount - 1;
            gridView.TopRowIndex = value;
            gridView.FocusedRowHandle = value;
        }

        private void UpdateCurrencyRate(string currencyCode = "IDR")
        {
            using (var currencyDm = new CurrencyDataManager())
            {
                CurrencyModel currency;
                currency = currencyDm.GetFirst<CurrencyModel>(WhereTerm.Default(currencyCode, "code"));

                if (currency == null)
                {
                    currency = new CurrencyModel
                    {
                        Id = 1,
                        Code = "IDR"
                    };
                }

                txtCurrencyRate.Value = currency.Rate;
            }
        }

        private void RefreshGrandTotals(bool inPopulateForm = false)
        {
            if (txtTotalSales.Text.Equals(string.Empty) || txtTotalRaFee.Text.Equals(string.Empty) || txtMateraiFee.Text.Equals(string.Empty)) return;

            var total = inPopulateForm
                ? (from a in Shipments select a.TariffTotalInBaseCurrency).Sum()
                : Convert.ToDecimal(txtTotalSales.Value);

            txtTotalDiscountTotal.Value = Shipments.Sum(r => r.Discount);
            total -= txtTotalDiscountTotal.Value;

            total += txtTotalRaFee.Value;

            total += (from a in Costs select a.Total).Sum();
            total += (from a in Shipments select a.PackingFee).Sum();
            total += (from a in Shipments select a.OtherFee).Sum();
            total += (from a in Shipments select a.InsuranceFee).Sum();
            //total *= Math.Max(Convert.ToDecimal(txtCurrencyRate.Value), 1);

            txtBeforeTax.Value = total;

            if (cmbTaxType.SelectedIndex >= 0)
            {
                var taxRate = TaxTypes[cmbTaxType.SelectedIndex].Rate;
                txtTaxTotal.Value = Math.Floor(total * taxRate);
                total += total * taxRate;
            }

            if (total > 1000000)
            {
                txtMateraiFee.Value = 6000;
            }
            else if (total > 250000)
            {
                txtMateraiFee.Value = 3000;
            }
            else
            {
                txtMateraiFee.Value = 0;
            }

            RefreshGrandTotalsAfterMaterai();
        }

        private void TxtRaFeePerPieceOnTextChanged(object sender, EventArgs eventArgs)
        {
            if (txtRaCwTotal.Text.Equals(string.Empty) || txtRaFeePerPiece.Text.Equals(string.Empty)) return;

            txtTotalRaFee.Value = txtRaCwTotal.Value * txtRaFeePerPiece.Value;
            RefreshGrandTotals();
        }

        private void RefreshGrandTotalsAfterMaterai()
        {
            var total = txtBeforeTax.Value + txtTaxTotal.Value + txtMateraiFee.Value;
            txtGrandTotal.Value = total;
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            var model = new SalesInvoiceDataManager().GetFirst<SalesInvoiceModel>(WhereTerm.Default(_cancellationInvoice, "ref_number"));
            if (lkpCustomer.Value == null)
            {
                MessageBox.Show(@"Please select a customer");
                return;
            }

            var excludeShipmentIds = (from a in Shipments select a.ShipmentId).ToArray();

            if (model != null)
            {
                using (var dialog = new SelectShipmentPopup(_cancellationInvoice, InvoiceRevisions, idExistsInvoice)
                {
                    StartPosition = FormStartPosition.CenterScreen,
                    ShowInTaskbar = false,

                    FilterPeriod = txtPeriod.Text,
                    FilterDateFrom = DateTime.ParseExact(txtFilterDateFrom.Text, "dd/MM/yyyy", null),
                    FilterDateTo = DateTime.ParseExact(txtFilterDateTo.Text, "dd/MM/yyyy", null),
                    FilterDestCityId = model.FilterDestCityId,
                    FilterPackageTypeId = model.FilterPackageTypeId,
                    FilterPaymentMethodId = model.FilterPaymentMethodId,
                    FilterIsPersonal = (int)cmbFilterCustomerType.SelectedValue == SALES_INVOICE_TYPE_PERSONAL ? 1 : 0,
                    FilterCustomerId = (int)lkpCustomer.Value,
                    FilterExcludeShipmentIds = excludeShipmentIds,
                })
                {
                    dialog.ShowDialog();

                    var serviceTypeDm = new ServiceTypeDataManager();

                    txtFilterDateFrom.Text = dialog.FilterDateFrom.ToString("dd/MM/yyyy");
                    txtFilterDateTo.Text = dialog.FilterDateTo.ToString("dd/MM/yyyy");
                    txtFilterDestinationCity.Text = dialog.FilterDestCityName;

                    //if (dialog.FilterDestCityId != null)
                    //    ((SalesInvoiceModel)CurrentModel).FilterDestCityId = dialog.FilterDestCityId;
                    //if (dialog.FilterPackageTypeId != null)
                    //    ((SalesInvoiceModel)CurrentModel).FilterPackageTypeId = dialog.FilterPackageTypeId;
                    //if (dialog.FilterPaymentMethodId != null)
                    //    ((SalesInvoiceModel)CurrentModel).FilterPaymentMethodId = dialog.FilterPaymentMethodId;

                    PopulateShipmentList(dialog.SelectedShipmentList.Select(i => new SalesInvoiceListModel
                    {
                        SalesInvoiceId = 0,
                        ShipmentId = i.Id,
                        ShipmentCode = i.Code,
                        ShipmentProcessDate = i.DateProcess,
                        DeliveredDate = null,
                        Recipient = null,
                        ConsigneeName = i.ConsigneeName,
                        DestinationCity = i.DestCity,
                        TotalPiece = i.TtlPiece,
                        TotalChargeableWeight = i.TtlChargeableWeight,
                        ServiceTypeId = i.ServiceTypeId,
                        ServiceType =
                            serviceTypeDm.GetFirst<ServiceTypeModel>(WhereTerm.Default(i.ServiceTypeId, "id")).Name,
                        PackageTypeId = i.PackageTypeId,
                        PackageType =
                            new PackageTypeDataManager().GetFirst<PackageTypeModel>(
                                WhereTerm.Default(i.PackageTypeId, "id"))
                                .Name,
                        // ReSharper disable once PossibleInvalidOperationException
                        PricingPlanId = (int)i.PricingPlanId,
                        NeedRa = i.NeedRa,
                        TariffPerKg = i.Tariff,
                        HandlingFee = i.HandlingFeeTotal,
                        PackingFee = i.PackingFee,
                        TotalTariff = i.TariffTotal,
                        Discount = i.DiscountTotal,
                        NetTariff = i.TariffNet,
                        OtherFee = i.OtherFee,
                        InsuranceFee = i.InsuranceFee,
                        GrandTotal = i.Total,
                        GrandTotalInBaseCurrency = i.TariffNet + i.PackingFee + i.OtherFee + i.InsuranceFee,
                        Currency = i.Currency,
                        CurrencyRate = i.CurrencyRate,
                        Invoiced = true,
                        Createddate = DateTime.Now,
                        Createdby = BaseControl.UserLogin,
                        Rowstatus = true,
                        Rowversion = DateTime.Now,
                        NewRow = true,
                        StateChange = i.StateChange
                    }), true);
                }
            }
        }
    }
}