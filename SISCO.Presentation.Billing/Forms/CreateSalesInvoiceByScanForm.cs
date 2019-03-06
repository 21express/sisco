using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Transactions;
using System.Windows.Forms;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraReports.Parameters;
using SISCO.App.Billing;
using SISCO.App.Finance;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Billing.Popup;
using SISCO.Presentation.Billing.Reports;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Component;
using SISCO.Presentation.Common.ComponentRepositories;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;
using SISCO.Repositories.Context;
using Devenlab.Common.WinControl.MessageBox;
using SISCO.Presentation.Common.Reports;
using System.IO;
using System.Net;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;

namespace SISCO.Presentation.Billing.Forms
{
    public partial class CreateSalesInvoiceByScanForm : BaseCrudForm<SalesInvoiceModel, SalesInvoiceDataManager>//BaseToolbarForm//
    {
        private decimal _fixedMateraiPrice;

        public Dictionary<int, string> PackageTypes { get; set; }
        private const int PRICING_PLAN_DOMESTIC = 1;
        private const int SALES_INVOICE_TYPE_CORPORATE = 3;
        private const int SALES_INVOICE_TYPE_PERSONAL = 4;

        public bool IsPopulatingForm { get; set; }
        public int? SelectedCustomerFilterId { get; set; }
        public object SelectedCustomerTypeFilterId { get; set; }

        public string LastDescription1 { get; set; }
        public string LastDescription2 { get; set; }
        public string LastDescription3 { get; set; }
        private bool RelocationPOD { get; set; }

        private bool FocusBarcode { get; set; }

        /*
        public class SalesInvoiceListDataRow : SalesInvoiceListModel
        {
            public Int32 Index { get; set; }

            public decimal TariffTotalInBaseCurrency
            {
                get { return !string.IsNullOrEmpty(Currency) ? TotalTariff * CurrencyRate : TotalTariff; }
            }

            public string OtherLabel { get; set; }
        }
         */

        protected ExtendedBindingList<SalesInvoiceListDataRow> Shipments { get; set; }
        protected BindingList<SalesInvoiceCostModel> Costs { get; set; }
        protected BindingList<TaxTypeModel> TaxTypes { get; set; }
        protected List<SalesInvoiceListDataRow> DeletedShipments;

        public BranchDataManager BranchDataManager { get; set; }

        public bool IsPopulatingShipmentList { get; set; }

        public CreateSalesInvoiceByScanForm()
        {
            InitializeComponent();
            form = this;
        }

        protected override void BindDataSource<T>()
        {
            CurrentModel = LoadModel<T>(WhereTerm.Default(BaseControl.BranchId, "branch_id"));
        }

        protected override void LoadForm(object sender, EventArgs e)
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

            base.LoadForm(sender, e);

            EnableBtnSearch = true;
            SearchPopup = new SalesInvoicePopup();
            VisibleBtnPdf = true;
            EnableBtnPdf = false;

            txtPrintInvoiceFromNo.Value = 0;
            txtPrintInvoiceToNo.Value = 0;

            txtDate.FieldLabel = "Date";
            txtDate.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };
            txtReceiptNo.FieldLabel = "Nomor Kwitansi";
            txtReceiptNo.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };
            txtInvoicedTo.FieldLabel = "Invoiced To";
            txtInvoicedTo.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };
            txtDueDate.FieldLabel = "Due Date";
            txtDueDate.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            txtReceiptNo.CharacterCasing = CharacterCasing.Upper;
            txtInvoicedTo.CharacterCasing = CharacterCasing.Upper;
            txtDescription1.CharacterCasing = CharacterCasing.Upper;
            txtDescription2.CharacterCasing = CharacterCasing.Upper;
            txtDescription3.CharacterCasing = CharacterCasing.Upper;

            lkpCustomer.LookupPopup = new CustomerPopup();
            lkpCustomer.AutoCompleteDataManager = new CustomerDataManager();
            lkpCustomer.AutoCompleteDisplayFormater =
                model => ((CustomerModel) model).Code + " - " + ((CustomerModel) model).Name;
            lkpCustomer.AutoCompleteWhereExpression = (s, param) => param.SetWhereExpression("(code = @0 or name.StartsWith(@0)) and branch_id = @1", s, BaseControl.BranchId);
            lkpCustomer.FieldLabel = "Customer";
            lkpCustomer.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            using (var salesInvoiceTypeDm = new SalesInvoiceTypeDataManager())
            {
                cmbFilterCustomerType.DataSource = salesInvoiceTypeDm.Get<SalesInvoiceTypeModel>();
            }
            cmbFilterCustomerType.DisplayMember = "Name";
            cmbFilterCustomerType.ValueMember = "Id";
            cmbFilterCustomerType.FieldLabel = "Customer Type";
            cmbFilterCustomerType.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            using (var taxInvoiceDm = new TaxInvoiceDataManager())
            {
                cmbTaxInvoice.DataSource = taxInvoiceDm.Get<TaxInvoiceModel>();
            }
            cmbTaxInvoice.DisplayMember = "Name";
            cmbTaxInvoice.ValueMember = "Id";
            cmbTaxInvoice.FieldLabel = "Tax Invoice";
            cmbTaxInvoice.ValidationRules = new[] { new ComponentValidationRule(EnumComponentValidationRule.Mandatory) };

            TaxTypes = new BindingList<TaxTypeModel>(new TaxTypeDataManager().Get<TaxTypeModel>().ToList());
            cmbTaxType.DataSource = TaxTypes;
            cmbTaxType.DisplayMember = "Name";
            cmbTaxType.ValueMember = "Id";

            txtRaCwTotal.EditMask = "###,##0";
            txtPrintInvoiceFromNo.EditMask = "###,##0";
            txtPrintInvoiceToNo.EditMask = "###,##0";

            //gridColumn13.ColumnEdit = new TextEditRepo();
            //((TextEditRepo)gridColumn13.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            //((TextEditRepo)gridColumn13.RealColumnEdit).Mask.EditMask = @"#,0";
            //((TextEditRepo)gridColumn13.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;
            gridColumn13.SummaryItem.DisplayFormat = @"{0:#,0}";

            //gridColumn5.ColumnEdit = new TextEditRepo();
            //((TextEditRepo)gridColumn5.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            //((TextEditRepo)gridColumn5.RealColumnEdit).Mask.EditMask = @"###,###,##0.0";
            //((TextEditRepo)gridColumn5.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;
            gridColumn5.SummaryItem.DisplayFormat = @"{0:#,0.0}";

            //gridColumn10.ColumnEdit = new TextEditRepo();
            //((TextEditRepo)gridColumn10.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            //((TextEditRepo)gridColumn10.RealColumnEdit).Mask.EditMask = @"###,###,##0";
            //((TextEditRepo)gridColumn10.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;

            //gridColumn3.ColumnEdit = new TextEditRepo();
            //((TextEditRepo)gridColumn3.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            //((TextEditRepo)gridColumn3.RealColumnEdit).Mask.EditMask = @"###,###,##0";
            //((TextEditRepo)gridColumn3.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;
            gridColumn3.SummaryItem.DisplayFormat = @"{0:#,0}";

            //gridColumn11.ColumnEdit = new TextEditRepo();
            //((TextEditRepo)gridColumn11.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            //((TextEditRepo)gridColumn11.RealColumnEdit).Mask.EditMask = @"###,###,##0";
            //((TextEditRepo)gridColumn11.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;
            gridColumn11.SummaryItem.DisplayFormat = @"{0:#,0}";

            //gridColumn7.ColumnEdit = new TextEditRepo();
            //((TextEditRepo)gridColumn7.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            //((TextEditRepo)gridColumn7.RealColumnEdit).Mask.EditMask = @"###,###,##0";
            //((TextEditRepo)gridColumn7.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;
            gridColumn7.SummaryItem.DisplayFormat = @"{0:#,0}";

            //gridColumn8.ColumnEdit = new TextEditRepo();
            //((TextEditRepo)gridColumn8.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            //((TextEditRepo)gridColumn8.RealColumnEdit).Mask.EditMask = @"###,###,##0";
            //((TextEditRepo)gridColumn8.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;
            gridColumn8.SummaryItem.DisplayFormat = @"{0:#,0}";

            //gridColumn12.ColumnEdit = new TextEditRepo();
            //((TextEditRepo)gridColumn12.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            //((TextEditRepo)gridColumn12.RealColumnEdit).Mask.EditMask = @"###,###,##0";
            //((TextEditRepo)gridColumn12.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;
            gridColumn12.SummaryItem.DisplayFormat = @"{0:#,0}";

            //gridColumn14.ColumnEdit = new TextEditRepo();
            //((TextEditRepo)gridColumn14.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            //((TextEditRepo)gridColumn14.RealColumnEdit).Mask.EditMask = @"###,###,##0";
            //((TextEditRepo)gridColumn14.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;
            gridColumn14.SummaryItem.DisplayFormat = @"{0:#,0}";

            //gridColumn16.ColumnEdit = new TextEditRepo();
            //((TextEditRepo)gridColumn16.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            //((TextEditRepo)gridColumn16.RealColumnEdit).Mask.EditMask = @"###,###,##0";
            //((TextEditRepo)gridColumn16.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;
            gridColumn16.SummaryItem.DisplayFormat = @"{0:#,0}";

            //gridColumn15.ColumnEdit = new TextEditRepo();
            //((TextEditRepo)gridColumn15.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            //((TextEditRepo)gridColumn15.RealColumnEdit).Mask.EditMask = @"###,###,##0";
            //((TextEditRepo)gridColumn15.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;
            gridColumn15.SummaryItem.DisplayFormat = @"{0:#,0}";

            //gridColumn18.ColumnEdit = new TextEditRepo();
            //((TextEditRepo)gridColumn18.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            //((TextEditRepo)gridColumn18.RealColumnEdit).Mask.EditMask = @"###,###,##0";
            //((TextEditRepo)gridColumn18.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;
            gridColumn15.SummaryItem.DisplayFormat = @"{0:#,0}";

            //gridColumn31.ColumnEdit = new TextEditRepo();
            //((TextEditRepo)gridColumn31.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            //((TextEditRepo)gridColumn31.RealColumnEdit).Mask.EditMask = @"###,###,##0";
            //((TextEditRepo)gridColumn31.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;
            gridColumn31.SummaryItem.DisplayFormat = @"{0:#,0}";

            //gridColumn36.ColumnEdit = new TextEditRepo();
            //((TextEditRepo)gridColumn36.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            //((TextEditRepo)gridColumn36.RealColumnEdit).Mask.EditMask = @"###,###,##0";
            //((TextEditRepo)gridColumn36.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;
            gridColumn36.SummaryItem.DisplayFormat = @"{0:#,0}";

            gridColumn35.ColumnEdit = new TextEditRepo();

            // --------

            Shipments = new ExtendedBindingList<SalesInvoiceListDataRow>();
            Costs = new BindingList<SalesInvoiceCostModel>();
            DeletedShipments = new List<SalesInvoiceListDataRow>();

            grid.DataSource = Shipments;
            gridOtherFee.DataSource = Costs;

            btnGetData.Click += btnGetData_Click;

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

            Shipments.BeforeRemove += (o, args) =>
            {
                var item = Shipments[args.NewIndex];
                DeletedShipments.Add(item);
            };

            gridViewOtherFee.CellValueChanged += (o, args) => RefreshGrandTotals();

            lkpCustomer.TextChanged += (o, args) =>
            {
                if (lkpCustomer.Value == null) return; 

                using (var customerDm = new CustomerDataManager())
                {
                    var customer = customerDm.GetFirst<CustomerModel>(WhereTerm.Default((int) lkpCustomer.Value, "id"));
                    if (customer != null)
                    {
                        txtInvoicedTo.Text = customer.Name;
                        txtDueDate.DateTime = DateTime.Now.AddDays((int) customer.Credit);

                        txtDiscountPercent.Value = customer.Discount;
                        if (customer.TaxInvoiceId != null) cmbTaxInvoice.SelectedValue = customer.TaxInvoiceId;
                        else cmbTaxInvoice.SelectedIndex = -1;
                    }
                }
            };

            lkpCustomer.Enter += (o, args) =>
            {
                SelectedCustomerFilterId = lkpCustomer.Value;
            };

            lkpCustomer.Leave += (o, args) =>
            {
                if (!IsPopulatingForm && ((dLookup)o).Value != null && SelectedCustomerFilterId != ((dLookup)o).Value && Shipments.Count > 0)
                {
                    MessageBox.Show(@"Harap menghapus daftar shipment sebelum mengganti customer");

                    ((dLookup)o).DefaultValue = new IListParameter[] { WhereTerm.Default(SelectedCustomerFilterId ?? 0, "id") };
                }
            };

            btnDeleteShipment.Click += (o, args) =>
            {
                gridView.DeleteSelectedRows();

                if (!Shipments.Any())
                {
                    ((SalesInvoiceModel)CurrentModel).CurrencyId = 0;
                }
            };
            btnDeleteOtherFee.Click += (o, args) => gridViewOtherFee.DeleteSelectedRows();
            btnAddOtherFee.Click += (o, args) =>
            {
                gridViewOtherFee.AddNewRow();

                gridViewOtherFee.FocusedRowHandle = Costs.Count - 1;
                gridOtherFee.Focus();
                gridViewOtherFee.FocusedColumn = gridColumn35;
            };

            btnCancelInvoice.Click += (o, args) =>
            {
                if (cmbTaxInvoice.SelectedValue == null) cmbTaxInvoice.SelectedIndex = 0;
                var dialog = MessageForm.Ask(form, "Cancel Invoice", "Anda yakin akan membatalkan invoice ini?");
                if (dialog == DialogResult.Yes)
                {
                    if (((SalesInvoiceModel)CurrentModel).Cancelled) return;

                    var cancelPopup = new CancellationPopup(txtReceiptNo.Text)
                    {
                        StartPosition = FormStartPosition.CenterScreen,
                        ShowInTaskbar = false
                    };
                    cancelPopup.ShowDialog();

                    if (string.IsNullOrEmpty(cancelPopup.RevisedInvoice)) return;
                    if (cancelPopup.InvoiceRevised.Count == 0) return;

                    var xx = new PaymentInDetailDataManager().GetFirst<PaymentInDetailModel>(WhereTerm.Default(((SalesInvoiceModel)CurrentModel).Id, "invoice_id", EnumSqlOperator.Equals));
                    using (var trans = new TransactionScope())
                    {
                        txtGrandTotal.Value = 0;
                        chkCancelled.Checked = true;
                        ((SalesInvoiceModel)CurrentModel).Cancelled = true;
                        ((SalesInvoiceModel)CurrentModel).Paid = false;
                        ((SalesInvoiceModel)CurrentModel).InvoiceRevised = cancelPopup.RevisedInvoice;

                        // delete kwitansi di payment in
                        if (xx != null)
                        {
                            new PaymentInDetailDataManager().DeActive(xx.Id, BaseControl.UserLogin, DateTime.Now);
                            var y =
                                new PaymentInDataManager().GetFirst<PaymentInModel>(WhereTerm.Default(xx.PaymentInId, "id",
                                    EnumSqlOperator.Equals));
                            var xxx = new PaymentInDetailDataManager().Get<PaymentInDetailModel>(WhereTerm.Default(xx.PaymentInId, "payment_in_id", EnumSqlOperator.Equals)).Sum(x => x.Payment);
                            y.TotalInvoice = xxx;
                            y.Total = y.TotalInvoice - y.Adjustment;
                            y.Amount = y.Total;
                            y.ModifiedPc = Environment.MachineName;
                            y.Modifieddate = DateTime.Now;
                            y.Modifiedby = BaseControl.UserLogin;

                            new PaymentInDataManager().Update<PaymentInModel>(y);
                        }
                        // delete

                        Save();

                        var canceledShipmentIds = (from a in Shipments select a.ShipmentId).ToList();

                        using (var shipmentDm = new ShipmentDataManager())
                        {
                            shipmentDm.CancelInvoice(canceledShipmentIds);
                        }

                        using (var invoiceListDm = new SalesInvoiceListDataManager())
                        {
                            invoiceListDm.CancelInvoice(canceledShipmentIds);
                        }

                        foreach (var i in cancelPopup.ShipmentRevised)
                        {
                            i.Modifiedby = BaseControl.UserLogin;
                            i.Modifieddate = DateTime.Now;
                            i.ModifiedPc = Environment.MachineName;

                            new ShipmentDataManager().Update<ShipmentModel>(i);
                        }

                        foreach (var i in cancelPopup.InvoiceRevised)
                        {
                            var c = new SalesInvoiceDataManager().GetFirst<SalesInvoiceModel>(WhereTerm.Default(i.SalesInvoice.RefNumber, "ref_number"));
                            var invoice = i.SalesInvoice;
                            var costs = i.SalesCosts;

                            if (c != null)
                            {
                                invoice.Id = c.Id;
                                invoice.Rowstatus = c.Rowstatus;
                                invoice.Rowversion = DateTime.Now;
                                invoice.Code = c.Code;
                                invoice.Createdby = c.Createdby;
                                invoice.Createddate = c.Createddate;
                                invoice.Modifiedby = BaseControl.UserLogin;
                                invoice.Modifieddate = DateTime.Now;

                                new SalesInvoiceDataManager().Update<SalesInvoiceModel>(invoice);
                                new SalesInvoiceListDataManager().Save(invoice, i.SalesInvoiceList.Where(p => p.StateChange == EnumStateChange.Insert).ToList());
                            }
                            else
                            {
                                invoice.Rowstatus = true;
                                invoice.Rowversion = DateTime.Now;
                                invoice.Createdby = BaseControl.UserLogin;
                                invoice.Createddate = DateTime.Now;

                                new SalesInvoiceDataManager().Save<SalesInvoiceModel>(invoice);
                                new SalesInvoiceListDataManager().Save(invoice, i.SalesInvoiceList);
                            }

                            

                            costs.ForEach(row =>
                            {
                                row.Rowstatus = true;
                                row.Rowversion = DateTime.Now;
                                row.Createdby = BaseControl.UserLogin;
                                row.Createddate = DateTime.Now;
                            });

                            new SalesInvoiceCostDataManager().Save(invoice.Id, costs);
                        }

                        trans.Complete();
                    }

                    btnCancelInvoice.Enabled = false;

                    btnPrintDelivery.Enabled = false;
                    btnPrintDelivery2.Enabled = false;
                    btnPrintInvoice.Enabled = false;
                    txtPrintInvoiceFromNo.Enabled = false;
                    txtPrintInvoiceToNo.Enabled = false;
                    btnPrintReceipt.Enabled = false;
                    btnPrintStatus.Enabled = false;

                    //pnlPrintInvoice.Enabled = false;

                    RefreshToolbarState();
                }
            };

            btnSaveToExcel.Click += (o, args) =>
            {
                var gv = new DevExpress.XtraGrid.Views.Grid.GridView
                {
                    Name = "gvExport"
                };
                var dg = new DevExpress.XtraGrid.GridControl
                {
                    Name = "dgExport"
                };
                gv.GridControl = dg;
                dg.MainView = gv;
                dg.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {gv});
                dg.BindingContext = new BindingContext();
                dg.ForceInitialize();

                var shipments = new ShipmentDataManager().GetInvoiceShipment(Shipments.Select(r => r.ShipmentCode))
                    .Join(Shipments, r => new { ShipmentId = r.Id }, r => new { r.ShipmentId }, (s, r) => new
                {
                    ShipmentNo = r.ShipmentCode,
                    Date = r.ShipmentProcessDate,
                    Destination = r.DestinationCity,
                    Pcs = r.TotalPiece,
                    GrossWeight = s.TtlGrossWeight,
                    ChargeableWeight = r.TotalChargeableWeight,
                    ServiceType = r.ServiceType,
                    Tariff = r.TariffPerKg,
                    Handling = r.HandlingFee,
                    Packing = r.PackingFee,
                    TariffTotal = r.TotalTariff,
                    Discount = r.Discount,
                    Net = r.NetTariff,
                    Other = r.OtherFee,
                    Insurance = r.InsuranceFee,
                    Total = r.GrandTotal,
                    TotalIDR = r.GrandTotalInBaseCurrency,
                    Currency = r.Currency,
                    Rate = r.CurrencyRate,
                    CodeInvoice = s.InvoiceRef,
                    Shipper = s.ShipperName,
                    Consignee = s.ConsigneeName,
                    ConsigneeAddress = s.ConsigneeAddress,
                    PackageType = r.PackageType,
                    Ref = s.RefNumber,
                    NatureOfGoods = s.NatureOfGoods,
                    DeliveryDate = s.DeliveryDate,
                    RecipientName = s.RecipientName
                });

                dg.DataSource = shipments;

                gv.RefreshData();
                ExportGridToExcel(gv, "Billing_InvoiceShipmentList", true, "xlsx", DevExpress.XtraPrinting.TextExportMode.Value);

                gv.Dispose();
                dg.Dispose();

                gv = null;
                dg = null;
            };

            txtRaFeePerPiece.TextChanged += TxtRaFeePerPieceOnTextChanged;
            txtRaCwTotal.TextChanged += TxtRaFeePerPieceOnTextChanged;

            chkPrintContinuous.Checked = true;

            txtMateraiFee.TextChanged += (o, args) => RefreshGrandTotalsAfterMaterai();
            cmbTaxType.SelectedValueChanged += (o, args) => RefreshGrandTotals();

            btnAddShipment.Click += (o, args) => AddRow();

            grid.DoubleClick += GridOnDoubleClick;
            grid.KeyPress += (o, args) =>
            {
                if (args.KeyChar == 13)
                if (args.KeyChar == 13)
                {
                    GridOnDoubleClick(o, args);
                }
            };

            gridView.FocusedRowObjectChanged += gridView_FocusedRowObjectChanged;

            btnPrintInvoice.Click += (o, args) =>
            {
                if (!ValidateFormWithAlert()) return;
                //Save();

                var printout = new SalesInvoicePrintout(chkPrintContinuous.Checked, txtTaxTotal.Value > 0)
                {
                    DataSource = Shipments,
                    Parameters =
                    {
                        new Parameter
                        {
                            Name = "SalesInvoice",
                            Value = CurrentModel as SalesInvoiceModel
                        },
                        new Parameter
                        {
                            Name = "Domestic",
                            Value = txtTotalDomestic.Value
                        },
                        new Parameter
                        {
                            Name = "CityCourier",
                            Value = txtTotalCityCourier.Value
                        },
                        new Parameter
                        {
                            Name = "International",
                            Value = txtTotalInternational.Value
                        },
                        new Parameter
                        {
                            Name = "OtherFee",
                            Value = (from a in Shipments select a.OtherFee).Sum()
                        },
                        new Parameter
                        {
                            Name = "RaMateraiFee",
                            Value = txtTotalRaFee.Value + txtMateraiFee.Value
                        },
                        new Parameter
                        {
                            Name = "DiscountPercent",
                            Value = txtDiscountPercent.Value
                        },
                        new Parameter
                        {
                            Name = "Discount",
                            Value = txtTotalDiscountTotal.Value
                        },
                        new Parameter
                        {
                            Name = "PackingInsuranceFee",
                            Value = (from a in Shipments select a.PackingFee + a.InsuranceFee).Sum()
                        },
                        new Parameter
                        {
                            Name = "GrandTotal",
                            Value = txtGrandTotal.Value
                        },
                        new Parameter
                        {
                            Name = "TaxRate",
                            Value = TaxTypes[cmbTaxType.SelectedIndex].Rate,
                        },
                        new Parameter
                        {
                            Name = "TaxTotal",
                            Value = txtTaxTotal.Value
                        },
                        new Parameter
                        {
                            Name = "StartPage",
                            Value = txtPrintInvoiceFromNo.Value
                        },
                        new Parameter
                        {
                            Name = "EndPage",
                            Value = txtPrintInvoiceToNo.Value
                        }
                    }
                };
                printout.Print();
            };
            btnPrintReceipt.Click += (o, args) =>
            {
                if (!ValidateFormWithAlert()) return;

                ((SalesInvoiceModel)CurrentModel).Printed = true;
                chkPrinted.Checked = true;
                var isCorporate = chkIsCorporateInvoice.Checked;

                Save();

                if (isCorporate)
                {
                    var printout = new PaymentReceiptCorporatePrintout
                    {
                        DataSource = GetReceiptPrintDataSource()
                    };
                    printout.Print();
                }
                else
                {
                    var printout = new PaymentReceiptPrintout
                    {
                        DataSource = GetReceiptPrintDataSource()
                    };
                    printout.Print();
                }

                EnabledForm(false);

                chkPrintContinuous.Enabled = true;

                btnCancelInvoice.Enabled = true;

                btnAddOtherFee.Enabled = false;
                btnAddShipment.Enabled = false;
                btnDeleteOtherFee.Enabled = false;
                btnDeleteShipment.Enabled = false;
                btnGetData.Enabled = false;

                RefreshToolbarState();
            };

            btnPrintDelivery.Click += (o, args) =>
            {
                if (!ValidateFormWithAlert()) return;
                Save();

                var printout = new InvoiceDeliveryPrintOut
                {
                    DataSource = GetReceiptPrintDataSource()
                };
                printout.Print();
            };

            btnPrintDelivery2.Click += (o, args) =>
            {
                if (!ValidateFormWithAlert()) return;
                Save();

                var printout = new InvoiceDelivery2PrintOut
                {
                    DataSource = GetReceiptPrintDataSource()
                };
                printout.Print();
                printout.Print();
            };

            btnPrintStatus.Click += (o, args) =>
            {
                if (!ValidateFormWithAlert()) return;
                //Save();

                var printout = new SalesInvoiceStatusPrintout
                {   
                    DataSource = Shipments,
                    Parameters =
                    {
                        new Parameter
                        {
                            Name = "SalesInvoice",
                            Value = CurrentModel as SalesInvoiceModel
                        },
                        new Parameter
                        {
                            Name = "OtherFee",
                            Value = (from a in Shipments select a.OtherFee).Sum()
                        },
                        new Parameter
                        {
                            Name = "RaMateraiFee",
                            Value = txtTotalRaFee.Value + txtMateraiFee.Value + Shipments.Sum(r => r.OtherFee + r.InsuranceFee)
                        },
                        new Parameter
                        {
                            Name = "DiscountPercent",
                            Value = txtDiscountPercent.Value
                        },
                        new Parameter
                        {
                            Name = "Discount",
                            Value = txtTotalDiscountTotal.Value
                        },
                        new Parameter
                        {
                            Name = "GrandTotal",
                            Value = txtGrandTotal.Value
                        },
                        new Parameter
                        {
                            Name = "TaxRate",
                            Value = TaxTypes[cmbTaxType.SelectedIndex].Rate,
                        },
                        new Parameter
                        {
                            Name = "TaxTotal",
                            Value = txtTaxTotal.Value
                        },
                        new Parameter
                        {
                            Name = "StartPage",
                            Value = txtPrintInvoiceFromNo.Value
                        },
                        new Parameter
                        {
                            Name = "EndPage",
                            Value = txtPrintInvoiceToNo.Value
                        }
                    }
                };
                printout.Print();
            };

            cmbFilterCustomerType.Enter += (o, args) =>
            {
                SelectedCustomerTypeFilterId = cmbFilterCustomerType.SelectedValue;
            };
            cmbFilterCustomerType.Leave += (o, args) =>
            {
                if (!IsPopulatingForm && SelectedCustomerTypeFilterId != ((dComboBox)o).SelectedValue && Shipments.Count > 0)
                {
                    MessageBox.Show(@"Harap menghapus daftar shipment sebelum mengganti jenis customer");

                    ((dComboBox)o).SelectedValue = SelectedCustomerTypeFilterId;
                }
            };

            btnPrintDelivery.Enabled = false;
            btnPrintDelivery2.Enabled = false;
            btnPrintInvoice.Enabled = false;
            txtPrintInvoiceFromNo.Enabled = false;
            txtPrintInvoiceToNo.Enabled = false;
            btnPrintReceipt.Enabled = false;
            btnPrintStatus.Enabled = false;
            btnCancelInvoice.Enabled = false;
            btnSaveToExcel.Enabled = false;
            btnDeleteOtherFee.Enabled = false;
            btnDeleteShipment.Enabled = false;
            btnAddOtherFee.Enabled = false;
            btnAddShipment.Enabled = false;

            tsBaseBtn_Pdf.Click += (s, o) =>
            {
                if (!ValidateFormWithAlert()) return;
                //Save();

                var salesInvoice = CurrentModel as SalesInvoiceModel;
                var customer = new CustomerDataManager().GetFirst<CustomerModel>(WhereTerm.Default(salesInvoice.CompanyId, "id"));
            
                var printout = new InvoicePDF
                {
                    DataSource = Shipments,
                    Parameters =
                        {
                            new Parameter
                            {
                                Name = "SalesInvoice",
                                Value = salesInvoice
                            },
                            new Parameter
                            {
                                Name = "Customer",
                                Value = customer
                            },
                            new Parameter
                            {
                                Name = "Domestic",
                                Value = txtTotalDomestic.Value
                            },
                            new Parameter
                            {
                                Name = "CityCourier",
                                Value = txtTotalCityCourier.Value
                            },
                            new Parameter
                            {
                                Name = "International",
                                Value = txtTotalInternational.Value
                            },
                            new Parameter
                            {
                                Name = "OtherFee",
                                Value = (from a in Shipments select a.OtherFee).Sum()
                            },
                            new Parameter
                            {
                                Name = "RaMateraiFee",
                                Value = txtTotalRaFee.Value + txtMateraiFee.Value
                            },
                            new Parameter
                            {
                                Name = "DiscountPercent",
                                Value = txtDiscountPercent.Value
                            },
                            new Parameter
                            {
                                Name = "Discount",
                                Value = txtTotalDiscountTotal.Value
                            },
                            new Parameter
                            {
                                Name = "PackingInsuranceFee",
                                Value = (from a in Shipments select a.PackingFee + a.InsuranceFee).Sum()
                            },
                            new Parameter
                            {
                                Name = "GrandTotal",
                                Value = txtGrandTotal.Value
                            },
                            new Parameter
                            {
                                Name = "TaxRate",
                                Value = TaxTypes[cmbTaxType.SelectedIndex].Rate,
                            },
                            new Parameter
                            {
                                Name = "TaxTotal",
                                Value = txtTaxTotal.Value
                            }
                        }
                };

                using (var dialog = new SaveFileDialog())
                {
                    dialog.FileName = string.Format("invoice-{0}-{1}{2}", salesInvoice.RefNumber.Replace(" ", "_"), DateTime.Now.ToString("yyyyMMddHHmm"), ".pdf");
                    dialog.Filter = @"PDF files |*.pdf|All files (*.*)|*.*";

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        printout.ExportToPdf(dialog.FileName);
                        if (File.Exists(dialog.FileName))
                        {
                            System.Diagnostics.Process.Start("explorer.exe", @"/select,""" + dialog.FileName + "\"");
                        }
                    }
                }
            };

            btnFaktur.Click += DownloadTaxInvoice;
            btnFaktur.Enabled = false;

            btnReqFaktur.Click += (o, a) =>
            {
                if (ValidateFormWithAlert())
                {
                    var dialog = MessageForm.Ask(form, "Request Tax Invoice", "Invoice tidak dapat diubah setelah anda melakukan permintaan faktur pajak. Anda yakin akan melakukan permintaan faktur pajak?");
                    if (dialog == DialogResult.Yes)
                    {
                        var currentModel = new SalesInvoiceDataManager().GetFirst<SalesInvoiceModel>(WhereTerm.Default(CurrentModel.Id, "id"));
                        if (currentModel != null)
                        {
                            currentModel.Modifiedby = BaseControl.UserLogin;
                            currentModel.Modifieddate = DateTime.Now;
                            currentModel.ReqTaxInvoice = true;

                            new SalesInvoiceDataManager().Update<SalesInvoiceModel>(currentModel);
                            DataManager = new SalesInvoiceDataManager();
                            PerformFind();
                        }
                    }
                }
            };

            //
            txtAddShipmentNo.KeyDown += (o, args) =>
            {
                FocusBarcode = false;
                if (args.KeyCode == Keys.Enter)
                {
                    FocusBarcode = true;
                }
            };

            btnAddShipment.GotFocus += (o, args) =>
            {
                if (FocusBarcode)
                {
                    FocusBarcode = false;
                    AddRow();
                }
            };

            btnRelocation.Click += btnRelocation_Click;
            gridView.RowCellStyle += gridView_RowCellStyle;   
        }

        void gridView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var view = sender as GridView;
                if (view != null && (bool)view.GetRowCellValue(e.RowHandle, view.Columns["Scanned"]))
                    e.Appearance.ForeColor = Color.Black;
                else
                    e.Appearance.ForeColor = Color.Red;
            }
        }

        private void btnRelocation_Click(object sender, EventArgs e)
        {
            var rowCur = gridView.FocusedRowHandle + 1;
            var toRow = Convert.ToInt16(tbxNumber.Text);

            if (toRow <= 0)
            {
                MessageBox.Show("Nomor urut harus di atas 0.");
                return;
            }

            if (rowCur == toRow) return;

            var list = Shipments.ToList();
            var curr = new List<SalesInvoiceListDataRow>();

            if (toRow == list.Count) toRow++;
            if (rowCur == 1) toRow++;

            if (rowCur > toRow)
            {
                curr.AddRange(list.Take(toRow - 1));
                curr.Add(list[rowCur - 1]);
                curr.AddRange(list.Skip(toRow - 1).Take(rowCur - toRow));
                curr.AddRange(list.Skip(rowCur).Take(list.Count - rowCur));
            }
            else
            {
                curr.AddRange(list.Take(rowCur - 1));
                curr.AddRange(list.Skip(rowCur).Take(toRow - rowCur - 1));
                curr.Add(list[rowCur - 1]);
                curr.AddRange(list.Skip(toRow - 1).Take(list.Count - toRow + 1));
            }

            Shipments.Clear();
            Shipments.RaiseListChangedEvents = false;

            curr.ForEach(p =>
            {
                p.NewRow = true;
                Shipments.Add(p);
            });
            Shipments.RaiseListChangedEvents = true;
            Shipments.ResetBindings();

            gridView.FocusedRowHandle = toRow - 1;

            RelocationPOD = CurrentModel.Id > 0;
        }

        void gridView_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            tbxNumber.Text = (gridView.FocusedRowHandle + 1).ToString();
        }

        int scan { get; set; }
        private void AddRow()
        {
                if (txtAddShipmentNo.Text.Trim() == string.Empty)
                {
                    MessageBox.Show(@"Please enter a shipment number!");
                    txtAddShipmentNo.Focus();
                    return;
                }

                using (var shipmentDm = new ShipmentDataManager())
                {
                    if (lkpCustomer.Value == null)
                    {
                        MessageBox.Show(@"Please select a customer first!");
                        txtAddShipmentNo.Focus();
                        return;
                    }

                    var existing = from a in Shipments where a.ShipmentCode.Equals(txtAddShipmentNo.Text) select a;
                    if (existing.Any())
                    {
                        if (existing.First().Scanned)
                        {
                            MessageBox.Show(@"Shipment already listed!");
                            txtAddShipmentNo.Focus();
                        }
                        else
                        {
                            gridView.FocusedRowHandle = Shipments.IndexOf(existing.First());
                            gridView.SetRowCellValue(gridView.FocusedRowHandle, gridView.Columns["Scanned"], true);

                            tbxNumber.Text = scan.ToString();
                            btnRelocation.PerformClick();

                            txtAddShipmentNo.Clear();
                            txtAddShipmentNo.Focus();
                            scan++;
                        }
                        return;
                    }

                    var shipment = shipmentDm.GetFirst<ShipmentModel>(WhereTerm.Default(txtAddShipmentNo.Text, "code"));

                    if (shipment == null)
                    {
                        MessageBox.Show(@"POD tidak ditemukan!");
                        txtAddShipmentNo.Focus();
                        return;
                    }
                    if (lkpCustomer.Value != shipment.CustomerId)
                    {
                        MessageBox.Show(@"Wrong customer!");
                        txtAddShipmentNo.Focus();
                        return;
                    }
                    if (shipment.Posted == false)
                    {
                        MessageBox.Show(@"POD belum divalidasi!");
                        txtAddShipmentNo.Focus();
                        return;
                    }
                    if (shipment.PaymentMethod != null && shipment.PaymentMethod.Equals("CASH"))
                    {
                        MessageBox.Show(@"POD Cash tidak bisa dibuat invoice!");
                        txtAddShipmentNo.Focus();
                        return;
                    }
                    if (shipment.Invoiced == 1)
                    {
                        MessageBox.Show(@"POD sudah dibuat invoice!");
                        txtAddShipmentNo.Focus();
                        return;
                    }
                    if (shipment.Invoiced == 1)
                    {
                        MessageBox.Show(@"POD sudah diinvoice!");
                        txtAddShipmentNo.Focus();
                        return;
                    }
                    if (((int)cmbFilterCustomerType.SelectedValue) == SALES_INVOICE_TYPE_CORPORATE && shipment.Personal)
                    {
                        MessageBox.Show(@"POD pribadi tidak bisa dimasukan ke dalam invoice perusahaan!");
                        txtAddShipmentNo.Focus();
                        return;
                    }
                    if (((int)cmbFilterCustomerType.SelectedValue) == SALES_INVOICE_TYPE_PERSONAL && !shipment.Personal)
                    {
                        MessageBox.Show(@"POD perusahaan tidak bisa dimasukan ke dalam invoice pribadi!");
                        txtAddShipmentNo.Focus();
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
                            NewRow = true,
                            Scanned = true
                        }
                    };

                    PopulateShipmentList(list, true);

                    txtAddShipmentNo.Text = "";
                    txtAddShipmentNo.Focus();
                }
           }
        
        private void DownloadTaxInvoice(object sender, EventArgs e)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            // Change the url by the value you want (a textbox or something else)
            string url = string.Format("{0}api/v1/{1}/faktur", BaseControl.SiscoBaseAddressApi, ((SalesInvoiceModel)CurrentModel).TaxInvoice);
            
            // Get filename from URL
            Uri uri = new Uri(url);

            using (var dialog = new SaveFileDialog())
            {
                dialog.FileName = ((SalesInvoiceModel)CurrentModel).TaxInvoice;
                dialog.Filter = @"PDF files |*.pdf|All files (*.*)|*.*";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    using (var client = new WebClient())
                    {
                        client.DownloadFile(url, dialog.FileName);
                    }

                    if (File.Exists(dialog.FileName))
                    {
                        System.Diagnostics.Process.Start("explorer.exe", @"/select,""" + dialog.FileName + "\"");
                    }
                }
            }
        }

        private void GridOnDoubleClick(object o, EventArgs args)
        {
            var rows = gridView.GetSelectedRows();

            if (rows.Count() > 0)
            {
                BaseControl.OpenRelatedForm(new ValidateShipmentOrderForm(), gridView.GetRowCellValue(rows[0], "ShipmentCode").ToString(), CallingCommand);
            }
        }

        private void TxtRaFeePerPieceOnTextChanged(object sender, EventArgs eventArgs)
        {
            if (txtRaCwTotal.Text.Equals(string.Empty) || txtRaFeePerPiece.Text.Equals(string.Empty)) return;

            txtTotalRaFee.Value = txtRaCwTotal.Value*txtRaFeePerPiece.Value;
            RefreshGrandTotals();
        }

        private IEnumerable<SalesInvoiceModel.SalesInvoiceReportRow> GetReceiptPrintDataSource()
        {
            return new List<SalesInvoiceModel.SalesInvoiceReportRow>
            {
                ConvertModel<SalesInvoiceModel, SalesInvoiceModel.SalesInvoiceReportRow>(CurrentModel)
            };
        }

        private void RefreshGrandTotals(bool inPopulateForm = false)
        {
            if (_isPopulatingForm && !inPopulateForm) return;
            if (txtTotalSales.Text.Equals(string.Empty) || txtTotalRaFee.Text.Equals(string.Empty) || txtMateraiFee.Text.Equals(string.Empty)) return;

            var total = inPopulateForm
                ? (from a in Shipments select a.TariffTotalInBaseCurrency).Sum()
                : Convert.ToDecimal(txtTotalSales.Value);

            txtTotalDiscountTotal.Value = Shipments.Sum(r => r.Discount) * txtCurrencyRate.Value;
            total -= txtTotalDiscountTotal.Value;

            total += txtTotalRaFee.Value;

            total += (from a in Costs select a.Total).Sum();
            total += (from a in Shipments select a.PackingFee).Sum() * txtCurrencyRate.Value;
            total += (from a in Shipments select a.OtherFee).Sum() * txtCurrencyRate.Value;
            total += (from a in Shipments select a.InsuranceFee).Sum() * txtCurrencyRate.Value;
            //total *= Math.Max(Convert.ToDecimal(txtCurrencyRate.Value), 1);

            txtBeforeTax.Value = total;

            if (cmbTaxType.SelectedIndex >= 0)
            {
                var taxRate = TaxTypes[cmbTaxType.SelectedIndex].Rate;
                txtTaxTotal.Value = Math.Truncate(total * taxRate);
                total += total * taxRate;
            }

            if (CurrentModel.Id == 0)
            {
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
            }

            RefreshGrandTotalsAfterMaterai();
        }

        private void RefreshGrandTotalsAfterMaterai()
        {
            if (_isPopulatingForm) return;

            var total = txtBeforeTax.Value + txtTaxTotal.Value + txtMateraiFee.Value;

            txtGrandTotal.Value = total;
        }

        void btnGetData_Click(object sender, EventArgs e)
        {
            var model = CurrentModel as SalesInvoiceModel;

            if (lkpCustomer.Value == null)
            {
                MessageBox.Show(@"Please select a customer");
                return;
            }

            if (Shipments.Count > 0)
            {
                if (MessageForm.Ask(form, "Konfirmasi Hapus", "Semua data POD yang sudah di scan akan dihapus. Apa anda yakin?") == System.Windows.Forms.DialogResult.Yes)
                {
                    Shipments.Clear();
                }
                else return;
            }

            scan = 1;

            var excludeShipmentIds = (from a in Shipments select a.ShipmentId).ToArray();

            if (model != null)
            {
                using (var dialog = new SelectShipmentForInvoiceForm
                {
                    StartPosition = FormStartPosition.CenterScreen,

                    FilterPeriod = txtPeriod.Text,
                    FilterDateFrom = DateTime.ParseExact(txtFilterDateFrom.Text, "dd/MM/yyyy", null),
                    FilterDateTo = DateTime.ParseExact(txtFilterDateTo.Text, "dd/MM/yyyy", null),
                    FilterDestCityId = model.FilterDestCityId,
                    FilterPackageTypeId = model.FilterPackageTypeId,
                    FilterPaymentMethodId = model.FilterPaymentMethodId,
                    FilterIsPersonal = (int) cmbFilterCustomerType.SelectedValue == SALES_INVOICE_TYPE_PERSONAL ? 1 : 0,
                    FilterCustomerId = (int) lkpCustomer.Value,
                    FilterExcludeShipmentIds = excludeShipmentIds,
                })
                {
                    dialog.ShowDialog();

                    var serviceTypeDm = new ServiceTypeDataManager();

                    txtFilterDateFrom.Text = dialog.FilterDateFrom.ToString("dd/MM/yyyy");
                    txtFilterDateTo.Text = dialog.FilterDateTo.ToString("dd/MM/yyyy");
                    txtFilterDestinationCity.Text = dialog.FilterDestCityName;

                    ((SalesInvoiceModel)CurrentModel).FilterDestCityId = dialog.FilterDestCityId;
                    ((SalesInvoiceModel)CurrentModel).FilterPackageTypeId = dialog.FilterPackageTypeId;
                    ((SalesInvoiceModel)CurrentModel).FilterPaymentMethodId = dialog.FilterPaymentMethodId;

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
                        PricingPlanId = (int) i.PricingPlanId,
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
                        Scanned = false
                    }), true);
                }
            }
        }

        protected override void PopulateForm(SalesInvoiceModel model)
        {
            IsPopulatingForm = true;

            btnGetData.Enabled = false;
            tsBaseTxt_Code.Text = model.Code;

            txtDate.DateTime = model.Vdate;
            txtReceiptNo.Text = model.RefNumber;

            chkIsCorporateInvoice.Checked = model.SalesInvoiceType == "PERUSAHAAN";

            lkpCustomer.DefaultValue = new IListParameter[] {WhereTerm.Default(model.CompanyId, "id")};
            
            txtInvoicedTo.Text = model.CompanyInvoicedTo;
            txtDueDate.DateTime = model.DueDate;

            txtDescription1.Text = model.Description1;
            txtDescription2.Text = model.Description2;
            txtDescription3.Text = model.Description3;

            LastDescription1 = model.Description1;
            LastDescription2 = model.Description2;
            LastDescription3 = model.Description3;

            if (model.SalesInvoiceTypeId > 0)
            {
                cmbFilterCustomerType.SelectedValue = model.SalesInvoiceTypeId;
                chkIsCorporateInvoice.Checked = false;
            }
            else
            {
                chkIsCorporateInvoice.Checked = true;
            }

            txtPeriod.Text = model.Period.ToString(CultureInfo.InvariantCulture);
            txtFilterDateFrom.Text = model.DateFrom.ToString("dd/MM/yyyy");
            txtFilterDateTo.Text = model.DateTo.ToString("dd/MM/yyyy");

            if (model.FilterDestCityId != null)
            {
                using (var dm = new CityDataManager())
                {
                    var fielterDestCity = dm.GetFirst<CityModel>(WhereTerm.Default((int) model.FilterDestCityId, "id"));
                    txtFilterDestinationCity.Text = (fielterDestCity != null) ? fielterDestCity.Name : "";
                }
            }

            UpdateCurrencyRate();

            PopulateShipmentList(new SalesInvoiceListDataManager().
                GetJoinShipmentAndDelivery(model.Id));

            Costs.RaiseListChangedEvents = false;

            Costs.Clear();

            new SalesInvoiceCostDataManager().
                Get<SalesInvoiceCostModel>(WhereTerm.Default(model.Id, "sales_invoice_id"))
                .ForEach(row => Costs.Add(row));

            Costs.RaiseListChangedEvents = true;
            Costs.ResetBindings();

            cmbTaxType.SelectedValue = model.TaxTypeId;
            if (model.TaxInvoiceId != null)
                cmbTaxInvoice.SelectedValue = model.TaxInvoiceId;
            else
                cmbTaxInvoice.SelectedIndex = -1;

            txtRaCwTotal.Value = model.RaChargeableWeight;
            txtRaFeePerPiece.Value = model.RaFee;
            txtTotalRaFee.Value = model.RaTotal;
            txtTotalDiscountTotal.Value = model.Discount;

            if (chkPrinted.Checked)
            {
                txtCurrencyRate.Value = model.CurrencyRate;
            }

            chkPrinted.Checked = model.Printed;
            chkCancelled.Checked = model.Cancelled;

            scan = Shipments.Count();

            RefreshGrandTotals(true);

            txtGrandTotal.Value = Math.Ceiling(model.Total);
            txtMateraiFee.Value = model.CostMaterai;
            EnableBtnPdf = true;

            lblRevised.Visible = false;
            tbxRevised.Visible = false;
            tbxRevised.Text = string.Empty;
            lblRevision.Visible = false;
            tbxRevision.Visible = false;
            tbxRevision.Text = string.Empty;

            if (chkCancelled.Checked)
            {
                lblRevised.Visible = true;
                tbxRevised.Visible = true;
                tbxRevised.Text = model.InvoiceRevised;
                EnabledForm(false);

                btnCancelInvoice.Enabled = false;

                btnPrintDelivery.Enabled = false;
                btnPrintDelivery2.Enabled = false;
                btnPrintInvoice.Enabled = false;
                txtPrintInvoiceFromNo.Enabled = false;
                txtPrintInvoiceToNo.Enabled = false;
                btnPrintReceipt.Enabled = false;
                btnPrintStatus.Enabled = false;

                btnSaveToExcel.Enabled = false;

                btnAddOtherFee.Enabled = false;
                btnAddShipment.Enabled = false;
                btnDeleteOtherFee.Enabled = false;
                btnDeleteShipment.Enabled = false;
            }
            else if (chkPrinted.Checked)
            {
                EnabledForm(false);

                btnCancelInvoice.Enabled = true;

                btnPrintReceipt.Enabled = true;

                btnPrintDelivery.Enabled = true;
                btnPrintDelivery2.Enabled = true;
                btnPrintInvoice.Enabled = true;
                txtPrintInvoiceFromNo.Enabled = true;
                txtPrintInvoiceToNo.Enabled = true;
                btnPrintStatus.Enabled = true;

                btnSaveToExcel.Enabled = true;

                btnAddOtherFee.Enabled = false;
                btnAddShipment.Enabled = false;
                btnDeleteOtherFee.Enabled = false;
                btnDeleteShipment.Enabled = false;

                chkPrintContinuous.Enabled = true;
            }
            else
            {
                btnCancelInvoice.Enabled = false;

                chkPrinted.Enabled = false;
                chkCancelled.Enabled = false;

                //txtDate.Enabled = false;
                txtGrandTotal.Enabled = false;

                txtRaCwTotal.Enabled = false;
                txtBeforeTax.Enabled = false;
                txtTaxTotal.Enabled = false;
                txtGrandTotal.Enabled = false;

                txtTotalRaFee.Enabled = false;
                txtDiscountPercent.Enabled = false;
                txtTotalDiscountTotal.Enabled = false;
                txtCurrencyRate.Enabled = false;

                btnAddOtherFee.Enabled = true;
                btnAddShipment.Enabled = true;
                btnDeleteOtherFee.Enabled = true;
                btnDeleteShipment.Enabled = true;

                btnPrintDelivery.Enabled = true;
                btnPrintDelivery2.Enabled = true;
                btnPrintInvoice.Enabled = true;
                txtPrintInvoiceFromNo.Enabled = true;
                txtPrintInvoiceToNo.Enabled = true;
                btnPrintReceipt.Enabled = true;
                    
                btnPrintStatus.Enabled = true;

                btnSaveToExcel.Enabled = true;
            }

            if (model.ReqTaxInvoice)
            {
                //txtDate.Enabled = false;
                txtGrandTotal.Enabled = false;

                txtRaCwTotal.Enabled = false;
                txtBeforeTax.Enabled = false;
                txtTaxTotal.Enabled = false;
                txtGrandTotal.Enabled = false;

                txtTotalRaFee.Enabled = false;
                txtDiscountPercent.Enabled = false;
                txtTotalDiscountTotal.Enabled = false;
                txtCurrencyRate.Enabled = false;

                if (string.IsNullOrEmpty(model.TaxInvoice))
                {
                    btnPrintDelivery.Enabled = false;
                    btnPrintDelivery2.Enabled = false;
                    btnPrintInvoice.Enabled = false;
                    txtPrintInvoiceFromNo.Enabled = false;
                    txtPrintInvoiceToNo.Enabled = false;
                    btnPrintReceipt.Enabled = false;
                    btnPrintStatus.Enabled = false;
                }

                btnSaveToExcel.Enabled = true;
                EnabledForm(false);
            }

            if (!string.IsNullOrEmpty(model.InvoiceRevisionOf))
            {
                lblRevision.Visible = true;
                tbxRevision.Visible = true;
                tbxRevision.Text = model.InvoiceRevisionOf;
            }

            txtPeriod.Enabled = false;
            txtFilterDateFrom.Enabled = false;
            txtFilterDateTo.Enabled = false;
            txtFilterDestinationCity.Enabled = false;

            txtTotalInternational.Enabled = false;
            txtTotalDomestic.Enabled = false;
            txtTotalCityCourier.Enabled = false;
            txtTotalSales.Enabled = false;

            IsPopulatingForm = false;

            btnFaktur.Enabled = !string.IsNullOrEmpty(model.TaxInvoice);
            RelocationPOD = false;
        }

        private void UpdateCurrencyRate(string currencyCode = "IDR")
        {
            using (var currencyDm = new CurrencyDataManager())
            {
                CurrencyModel currency;

                if (((SalesInvoiceModel) CurrentModel).CurrencyId != 0)
                {
                    currency =
                        currencyDm.GetFirst<CurrencyModel>(
                            WhereTerm.Default(((SalesInvoiceModel) CurrentModel).CurrencyId,
                                "id"));
                }
                else
                {
                    currency = currencyDm.GetFirst<CurrencyModel>(WhereTerm.Default(currencyCode, "code"));
                }

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

        private void PopulateShipmentList(IEnumerable<SalesInvoiceListModel> shipmentModels, bool isAppend = false)
        {
            Shipments.RaiseListChangedEvents = false;
            IsPopulatingShipmentList = true;

            if (!isAppend)
            {
                Shipments.Clear();
            }

            if (((SalesInvoiceModel)CurrentModel).CurrencyId == 0 && shipmentModels.Any())
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
                    GrandTotal = ((SalesInvoiceModel)CurrentModel).Printed ? row.GrandTotal : row.GrandTotalInBaseCurrency * txtCurrencyRate.Value,//((SalesInvoiceModel)CurrentModel).CurrencyRate,
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
                    Scanned = row.Scanned
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
            //copied.OrderBy(r => r.ShipmentProcessDate.Date).ThenBy(r => r.ShipmentCode).ForEach(r => Shipments.Add(r));
            copied.ForEach(r => Shipments.Add(r));

            Shipments.RaiseListChangedEvents = true;
            Shipments.ResetBindings();

            int value = gridView.RowCount - 1;
            gridView.TopRowIndex = value;
            gridView.FocusedRowHandle = value;

            IsPopulatingShipmentList = false;
        }

        protected override SalesInvoiceModel PopulateModel(SalesInvoiceModel model)
        {
            model.BranchId = BaseControl.BranchId;

            model.Code = tsBaseTxt_Code.Text;

            model.Vdate = txtDate.DateTime;
            model.RefNumber = txtReceiptNo.Text;

            model.CompanyName = lkpCustomer.Text;
            if (lkpCustomer.Value != null) model.CompanyId = (int) lkpCustomer.Value;

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

            model.TaxInvoiceId = (int) cmbTaxInvoice.SelectedValue;

            model.Period = Convert.ToInt32(txtPeriod.Text);
            model.DateFrom = DateTime.ParseExact(txtFilterDateFrom.Text, "dd/MM/yyyy", null);
            model.DateTo = DateTime.ParseExact(txtFilterDateTo.Text, "dd/MM/yyyy", null);

            model.TotalServiceTariff1 = (decimal) txtTotalDomestic.Value;
            model.TotalServiceTariff2 = (decimal) txtTotalDomestic.Value;
            model.TotalServiceTariff3 = (decimal) txtTotalInternational.Value;
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

            model.Printed = chkPrinted.Checked;
            model.Cancelled = chkCancelled.Checked;

            model.Total = txtGrandTotal.Value;

            model.TaxTypeId = (int)cmbTaxType.SelectedValue;
            model.TaxRate = TaxTypes[cmbTaxType.SelectedIndex].Rate;
            model.TaxTotal  = txtTaxTotal.Value;

            using (var customerDm = new CustomerDataManager())
            {
                var customer = customerDm.GetFirst<CustomerModel>(WhereTerm.Default(model.CompanyId, "id"));
                if (customer != null && customer.MarketingEmployeeId != null)
                {
                    model.EmployeeId = (int) customer.MarketingEmployeeId;
                }
            }

            return model;
        }

        protected override bool ValidateForm()
        {
            return true;
        }

        protected override bool ValidateFormWithAlert()
        {
            // ReSharper disable LocalizableElement
            if (txtDate.DateTime == DateTime.MinValue)
            {
                MessageBox.Show("Please enter the invoice date!");
                txtDate.Focus();
                return false;
            }
            if (txtReceiptNo.Text == "")
            {
                MessageBox.Show("Please enter the receipt number!");
                txtReceiptNo.Focus();
                return false;
            }
            if (lkpCustomer.Value == null)
            {
                MessageBox.Show("Please select a customer!");
                lkpCustomer.Focus();
                return false;
            }
            if (txtInvoicedTo.Text == "")
            {
                MessageBox.Show("Please enter the invoice recipient (Invoiced To)!");
                txtInvoicedTo.Focus();
                return false;
            }
            if (txtDate.DateTime == DateTime.MinValue)
            {
                MessageBox.Show("Please enter the invoice due date!");
                txtDate.Focus();
                return false;
            }

            var dupPaymentReceipt = DataManager.GetFirst<SalesInvoiceModel>(WhereTerm.Default(txtReceiptNo.Text, "ref_number"));
            if (dupPaymentReceipt != null && dupPaymentReceipt.Id != CurrentModel.Id)
            {
                MessageBox.Show("Nomor kwitansi sudah dipakai untuk invoice lain!");
                txtReceiptNo.Focus();
                return false;
            }

            if (cmbTaxInvoice.SelectedValue == null)
            {
                MessageBox.Show("Faktur pajak harus dipilih.");
                cmbTaxInvoice.Focus();
                return false;
            }

            if (!Shipments.Any())
            {
                MessageBox.Show("Invoice harus berisi POD!");
                txtAddShipmentNo.Focus();
                return false;
            }
            // ReSharper restore LocalizableElement

            return true;
        }

        protected override SalesInvoiceModel Find(string searchTerm)
        {
            return DataManager.GetFirst<SalesInvoiceModel>(WhereTerm.Default(searchTerm, "code"), WhereTerm.Default(BaseControl.BranchId, "branch_id"));
        }

        public override void Save()
        {
            if (!ValidateFormWithAlert()) return;

            CurrentModel = PopulateModel(CurrentModel as SalesInvoiceModel);

            if (Shipments.Where(p => !p.Scanned).ToList().Count > 0)
            {
                MessageBox.Show("Masih ada POD yang belum di scan.");
                return;
            }

            // resort the details
            Shipments.RaiseListChangedEvents = false;
            var copied = new SalesInvoiceListDataRow[Shipments.Count];
            Shipments.CopyTo(copied, 0);

            Shipments.Clear();
            //copied.OrderBy(r => r.ShipmentProcessDate.Date).ThenBy(r => r.ShipmentCode).ForEach(r => Shipments.Add(r));
            copied.ForEach(r => Shipments.Add(r));

            Shipments.RaiseListChangedEvents = true;
            Shipments.ResetBindings();

            using (var scope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(0, 10, 0)))
            {
                if (CurrentModel.Id == 0)
                {
                    CurrentModel.Rowstatus = true;
                    CurrentModel.Rowversion = DateTime.Now;
                    CurrentModel.Createddate = DateTime.Now;
                    CurrentModel.Createdby = BaseControl.UserLogin;

                    ((SalesInvoiceDataManager) DataManager).Save<SalesInvoiceModel>(CurrentModel);

                    tsBaseTxt_Code.Text = ((SalesInvoiceModel) CurrentModel).Code;
                }
                else
                {
                    ((SalesInvoiceDataManager) DataManager).Update<SalesInvoiceModel>(CurrentModel);
                }

                Costs.ForEach(row =>
                {
                    row.Rowstatus = true;
                    row.Rowversion = DateTime.Now;
                    row.Createddate = DateTime.Now;
                    row.Createdby = BaseControl.UserLogin;
                });

                if (RelocationPOD) new SalesInvoiceListDataManager().RemoveDetail(CurrentModel.Id);
                new SalesInvoiceListDataManager().Save(CurrentModel as SalesInvoiceModel, Shipments);
                new SalesInvoiceCostDataManager().Save(CurrentModel.Id, Costs);

                if (DeletedShipments.Count > 0)
                {
                    using (var shipmentDm = new ShipmentDataManager())
                    {
                        shipmentDm.CancelInvoice(DeletedShipments.Select(r => r.ShipmentId).ToList());
                    }

                    new SalesInvoiceListDataManager().DeleteRow(DeletedShipments.Select(r => r.ShipmentId).ToList(), CurrentModel.Id, BaseControl.UserLogin);
                }

                DeletedShipments.Clear();

                scope.Complete();
            }

            RefreshToolbarState();

            AfterSave();
            Buttons();
            
            StateChange = EnumStateChange.Update;
        }

        protected override void BeforeNew()
        {
            ClearForm();
            EnableBtnPdf = false;

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

            chkPrinted.Enabled = false;
            chkCancelled.Enabled = false;

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

            btnCancelInvoice.Enabled = false;
            btnPrintDelivery.Enabled = false;
            btnPrintDelivery2.Enabled = false;
            btnPrintInvoice.Enabled = false;
            txtPrintInvoiceFromNo.Enabled = false;
            txtPrintInvoiceToNo.Enabled = false;
            btnPrintReceipt.Enabled = false;
            btnPrintStatus.Enabled = false;

            btnAddShipment.Enabled = true;
            btnAddOtherFee.Enabled = true;
            btnDeleteOtherFee.Enabled = true;
            btnDeleteShipment.Enabled = true;

            btnGetData.Enabled = true;

            txtDescription1.Text = LastDescription1;
            txtDescription2.Text = LastDescription2;
            txtDescription3.Text = LastDescription3;

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

            btnFaktur.Enabled = false;
            cmbTaxInvoice.SelectedIndex = -1;

            lblRevised.Visible = false;
            tbxRevised.Visible = false;
            tbxRevised.Text = string.Empty;
            lblRevision.Visible = false;
            tbxRevision.Visible = false;
            tbxRevision.Text = string.Empty;

            RelocationPOD = false;
        }

        protected override void RefreshToolbarState()
        {
            base.RefreshToolbarState();

            btnReqFaktur.Enabled = false;
            if (CurrentModel != null && CurrentModel.Id != 0)
            {
                if (chkCancelled.Checked || chkPrinted.Checked)
                {
                    tsBaseBtn_Save.Enabled = false;
                    NavigationMenu.SaveStrip.Enabled = false;

                    //EnabledForm(false);

                    if (chkPrinted.Checked)
                    {
                        tsBaseBtn_Delete.Enabled = false;
                        NavigationMenu.DeleteStrip.Enabled = false;
                        NavigationMenu.DetailDeleteStrip.Enabled = false;
                    }
                    else
                    {
                        tsBaseBtn_Delete.Enabled = true;
                        NavigationMenu.DeleteStrip.Enabled = true;
                        NavigationMenu.DetailDeleteStrip.Enabled = true;
                    }
                }

                var currentModel = CurrentModel as SalesInvoiceModel;
                if (currentModel.Cancelled) btnReqFaktur.Enabled = false;
                if (!currentModel.Cancelled && !currentModel.ReqTaxInvoice) btnReqFaktur.Enabled = true;
                if (currentModel.Printed) btnReqFaktur.Enabled = false;
            }
            
            if (StateChange == EnumStateChange.Insert)
            {
                tsBaseBtn_Save.Enabled = true;
                NavigationMenu.SaveStrip.Enabled = true;
            }
        }

        protected override void AfterSave()
        {
            base.AfterSave();

            btnCancelInvoice.Enabled = false;
            btnPrintDelivery.Enabled = true;
            btnPrintDelivery2.Enabled = true;
            btnPrintInvoice.Enabled = true;
            txtPrintInvoiceFromNo.Enabled = true;
            txtPrintInvoiceToNo.Enabled = true;
            btnPrintReceipt.Enabled = true;
            btnPrintStatus.Enabled = true;

            LastDescription1 = ((SalesInvoiceModel)CurrentModel).Description1;
            LastDescription2 = ((SalesInvoiceModel)CurrentModel).Description2;
            LastDescription3 = ((SalesInvoiceModel)CurrentModel).Description3;

            DataManager = new SalesInvoiceDataManager();
            PerformFind();
        }

        public override void AfterDelete()
        {
            using (var shipmentDm = new ShipmentDataManager())
            {
                shipmentDm.CancelInvoice(Shipments.Select(r => r.ShipmentId).ToList());
            }

            base.AfterDelete();
        }
    }
}