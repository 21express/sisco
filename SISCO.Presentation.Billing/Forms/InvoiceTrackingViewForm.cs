using Devenlab.Common;
using SISCO.App.Billing;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SISCO.Presentation.Common.ComponentRepositories;
using DevExpress.XtraEditors.Mask;
using System.Net;
using System.IO;

namespace SISCO.Presentation.Billing.Forms
{
    public partial class InvoiceTrackingViewForm : BaseCrudForm<SalesInvoiceModel, SalesInvoiceDataManager>//BaseToolbarForm//
    {
        public InvoiceTrackingViewForm()
        {
            InitializeComponent();
            form = this;
        }

        private const int PRICING_PLAN_DOMESTIC = 1;
        protected BindingList<SalesInvoiceCostModel> Costs { get; set; }
        public class SalesInvoiceListDataRow : SalesInvoiceListModel
        {
            public Int32 Index { get; set; }

            public decimal TariffTotalInBaseCurrency
            {
                get { return !string.IsNullOrEmpty(Currency) ? TotalTariff * CurrencyRate : TotalTariff; }
            }
        }

        protected ExtendedBindingList<SalesInvoiceListDataRow> Shipments { get; set; }

        protected override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);
            VisibleNavigation = false;

            btnFaktur.Click += DownloadTaxInvoice;

            gridColumn13.ColumnEdit = new TextEditRepo();
            ((TextEditRepo)gridColumn13.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            ((TextEditRepo)gridColumn13.RealColumnEdit).Mask.EditMask = @"#,0";
            ((TextEditRepo)gridColumn13.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;
            gridColumn13.SummaryItem.DisplayFormat = @"{0:#,0}";

            gridColumn5.ColumnEdit = new TextEditRepo();
            ((TextEditRepo)gridColumn5.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            ((TextEditRepo)gridColumn5.RealColumnEdit).Mask.EditMask = @"###,###,##0.0";
            ((TextEditRepo)gridColumn5.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;
            gridColumn5.SummaryItem.DisplayFormat = @"{0:#,0.0}";

            gridColumn10.ColumnEdit = new TextEditRepo();
            ((TextEditRepo)gridColumn10.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            ((TextEditRepo)gridColumn10.RealColumnEdit).Mask.EditMask = @"###,###,##0";
            ((TextEditRepo)gridColumn10.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;

            gridColumn3.ColumnEdit = new TextEditRepo();
            ((TextEditRepo)gridColumn3.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            ((TextEditRepo)gridColumn3.RealColumnEdit).Mask.EditMask = @"###,###,##0";
            ((TextEditRepo)gridColumn3.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;
            gridColumn3.SummaryItem.DisplayFormat = @"{0:#,0}";

            gridColumn11.ColumnEdit = new TextEditRepo();
            ((TextEditRepo)gridColumn11.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            ((TextEditRepo)gridColumn11.RealColumnEdit).Mask.EditMask = @"###,###,##0";
            ((TextEditRepo)gridColumn11.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;
            gridColumn11.SummaryItem.DisplayFormat = @"{0:#,0}";

            gridColumn7.ColumnEdit = new TextEditRepo();
            ((TextEditRepo)gridColumn7.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            ((TextEditRepo)gridColumn7.RealColumnEdit).Mask.EditMask = @"###,###,##0";
            ((TextEditRepo)gridColumn7.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;
            gridColumn7.SummaryItem.DisplayFormat = @"{0:#,0}";

            gridColumn8.ColumnEdit = new TextEditRepo();
            ((TextEditRepo)gridColumn8.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            ((TextEditRepo)gridColumn8.RealColumnEdit).Mask.EditMask = @"###,###,##0";
            ((TextEditRepo)gridColumn8.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;
            gridColumn8.SummaryItem.DisplayFormat = @"{0:#,0}";

            gridColumn12.ColumnEdit = new TextEditRepo();
            ((TextEditRepo)gridColumn12.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            ((TextEditRepo)gridColumn12.RealColumnEdit).Mask.EditMask = @"###,###,##0";
            ((TextEditRepo)gridColumn12.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;
            gridColumn12.SummaryItem.DisplayFormat = @"{0:#,0}";

            gridColumn14.ColumnEdit = new TextEditRepo();
            ((TextEditRepo)gridColumn14.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            ((TextEditRepo)gridColumn14.RealColumnEdit).Mask.EditMask = @"###,###,##0";
            ((TextEditRepo)gridColumn14.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;
            gridColumn14.SummaryItem.DisplayFormat = @"{0:#,0}";

            gridColumn16.ColumnEdit = new TextEditRepo();
            ((TextEditRepo)gridColumn16.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            ((TextEditRepo)gridColumn16.RealColumnEdit).Mask.EditMask = @"###,###,##0";
            ((TextEditRepo)gridColumn16.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;
            gridColumn16.SummaryItem.DisplayFormat = @"{0:#,0}";

            gridColumn15.ColumnEdit = new TextEditRepo();
            ((TextEditRepo)gridColumn15.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            ((TextEditRepo)gridColumn15.RealColumnEdit).Mask.EditMask = @"###,###,##0";
            ((TextEditRepo)gridColumn15.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;
            gridColumn15.SummaryItem.DisplayFormat = @"{0:#,0}";

            gridColumn18.ColumnEdit = new TextEditRepo();
            ((TextEditRepo)gridColumn18.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            ((TextEditRepo)gridColumn18.RealColumnEdit).Mask.EditMask = @"###,###,##0";
            ((TextEditRepo)gridColumn18.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;
            gridColumn15.SummaryItem.DisplayFormat = @"{0:#,0}";

            gridColumn31.ColumnEdit = new TextEditRepo();
            ((TextEditRepo)gridColumn31.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            ((TextEditRepo)gridColumn31.RealColumnEdit).Mask.EditMask = @"###,###,##0";
            ((TextEditRepo)gridColumn31.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;
            gridColumn31.SummaryItem.DisplayFormat = @"{0:#,0}";

            gridColumn36.ColumnEdit = new TextEditRepo();
            ((TextEditRepo)gridColumn36.RealColumnEdit).Mask.MaskType = MaskType.Numeric;
            ((TextEditRepo)gridColumn36.RealColumnEdit).Mask.EditMask = @"###,###,##0";
            ((TextEditRepo)gridColumn36.RealColumnEdit).Mask.UseMaskAsDisplayFormat = true;
            gridColumn36.SummaryItem.DisplayFormat = @"{0:#,0}";

            gridColumn35.ColumnEdit = new TextEditRepo();

            // --------

            Shipments = new ExtendedBindingList<SalesInvoiceListDataRow>();
            Costs = new BindingList<SalesInvoiceCostModel>();

            grid.DataSource = Shipments;
            gridOtherFee.DataSource = Costs;

            Shipments.ListChanged += (o, args) =>
            {
                for (var i = 0; i < Shipments.Count; i++)
                {
                    Shipments[i].Index = i + 1;
                }

                tbxCityCourier.Text =
                    (from a in Shipments where a.ServiceType.ToUpper().Equals("CITY COURIER") select a.TariffTotalInBaseCurrency).Sum().ToString("n2");
                tbxDomestic.Text =
                    (from a in Shipments where !a.ServiceType.ToUpper().Equals("CITY COURIER") && a.PricingPlanId == PRICING_PLAN_DOMESTIC select a.TariffTotalInBaseCurrency).Sum().ToString("n2");
                tbxInternational.Text =
                    (from a in Shipments where a.PricingPlanId != PRICING_PLAN_DOMESTIC select a.TariffTotalInBaseCurrency).Sum().ToString("n2");
                tbxTotalSales.Text =
                    (from a in Shipments select a.TariffTotalInBaseCurrency).Sum().ToString("n2");
                tbxRaCwTotal.Text =
                    (from a in Shipments where a.NeedRa select a.TotalChargeableWeight).Sum().ToString("n2");

                RefreshGrandTotals();
            };

            gridViewOtherFee.CellValueChanged += (o, args) => RefreshGrandTotals();
        }

        private void DownloadTaxInvoice(object sender, EventArgs e)
        {
            //string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            // Change the url by the value you want (a textbox or something else)
            string url = string.Format("{0}api/v1/{1}/faktur", BaseControl.SiscoBaseAddressApi, ((SalesInvoiceModel)CurrentModel).TaxInvoice);
            // Get filename from URL
            //Uri uri = new Uri(url);

            //using (var dialog = new SaveFileDialog())
            //{
            //    dialog.FileName = ((SalesInvoiceModel)CurrentModel).TaxInvoice;
            //    dialog.Filter = @"PDF files |*.pdf|All files (*.*)|*.*";

            //    if (dialog.ShowDialog() == DialogResult.OK)
            //    {
            //        using (var client = new WebClient())
            //        {
            //            client.DownloadFile(url, dialog.FileName);
            //        }

            //        if (File.Exists(dialog.FileName))
            //        {
            //            System.Diagnostics.Process.Start("explorer.exe", @"/select,""" + dialog.FileName + "\"");
            //        }
            //    }
            //}

            System.Diagnostics.Process.Start(url);
        }

        private void PopulateShipmentList(IEnumerable<SalesInvoiceListModel> shipmentModels, bool isAppend = false)
        {
            Shipments.RaiseListChangedEvents = false;

            if (!isAppend)
            {
                Shipments.Clear();
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
                    GrandTotal = ((SalesInvoiceModel)CurrentModel).Printed ? row.GrandTotal : row.GrandTotalInBaseCurrency * ((SalesInvoiceModel)CurrentModel).CurrencyRate,
                    GrandTotalInBaseCurrency = row.GrandTotalInBaseCurrency,
                    DestinationCity = row.DestinationCity,
                    Currency = row.Currency,
                    //CurrencyRate = row.CurrencyRate,
                    CurrencyRate = ((SalesInvoiceModel)CurrentModel).CurrencyRate,
                    NeedRa = row.NeedRa,
                    Invoiced = row.Invoiced,
                    PricingPlanId = row.PricingPlanId,

                    Rowstatus = row.Rowstatus,
                    Rowversion = row.Rowversion,
                    Createddate = row.Createddate,
                    Createdby = row.Createdby,
                    Modifieddate = row.Modifieddate,
                    Modifiedby = row.Modifiedby,
                    NewRow = row.NewRow
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

        protected override bool ValidateForm()
        {
            throw new NotImplementedException();
        }

        protected override void PopulateForm(SalesInvoiceModel model)
        {
            ClearForm();
            if (model ==null) return;

            tsBaseTxt_Code.Text = model.RefNumber;

            var branch = new BranchDataManager().GetFirst<BranchModel>(WhereTerm.Default(model.BranchId, "id"));
            tbxBranch.Text = string.Format("{0} - {1}", branch.Code, branch.Name);

            tbxDate.Text = model.Vdate.ToString("dd-MM-yyyy");
            tbxCode.Text = model.Code;

            var salesType = new SalesInvoiceTypeDataManager().GetFirst<SalesInvoiceTypeModel>(WhereTerm.Default(model.SalesInvoiceTypeId, "id"));
            if (salesType != null) tbxCustomerType.Text = salesType.Name;
            var customer = new CustomerDataManager().GetFirst<CustomerModel>(WhereTerm.Default(model.CompanyId, "id"));
            if (customer != null)
            {
                tbxCustomer.Text = string.Format("{0} - {1}", customer.Code, customer.Name);
                tbxDiscountPercent.Text = customer.Discount.ToString("n2");
            }

            tbxInvoicedTo.Text = model.CompanyInvoicedTo;
            tbxDueDate.Text = model.DueDate.ToString("dd-MM-yyyy");

            tbxDescription1.Text = model.Description1;
            tbxDescription2.Text = model.Description2;
            tbxDescription3.Text = model.Description3;

            UpdateCurrencyRate();

            tbxPeriod.Text = model.Period.ToString(CultureInfo.InvariantCulture);

            PopulateShipmentList(new SalesInvoiceListDataManager().
                GetJoinShipmentAndDelivery(model.Id));

            Costs.RaiseListChangedEvents = false;
            Costs.Clear();

            new SalesInvoiceCostDataManager().
                Get<SalesInvoiceCostModel>(WhereTerm.Default(model.Id, "sales_invoice_id")).ToList()
                .ForEach(row => Costs.Add(row));

            Costs.RaiseListChangedEvents = true;
            Costs.ResetBindings();

            var taxType = new TaxTypeDataManager().GetFirst<TaxTypeModel>(WhereTerm.Default(model.TaxTypeId, "id"));
            if (taxType != null) tbxTaxType.Text = taxType.Name;

            tbxRaCwTotal.Text = model.RaChargeableWeight.ToString("n2");
            tbxRaFeePerPiece.Text = model.RaFee.ToString("#,#0");
            tbxTotalRaFee.Text = model.RaTotal.ToString("n2");
            tbxTotalDiscountTotal.Text = Shipments.Sum(r => r.Discount).ToString("n2");

            tbxCurrencyRate.Text  = model.CurrencyRate.ToString("n2");

            ucPrinted.Icon = model.Printed;
            ucCancelled.Icon = model.Cancelled;

            tbxGrandTotal.Text = Math.Ceiling(model.Total).ToString("n2");
            tbxMateraiFee.Text = model.CostMaterai.ToString("n2");
            tbxTaxTotal.Text = model.TaxTotal.ToString("n2");

            tbxRevised.Text = model.InvoiceRevised;
            tbxRevision.Text = model.InvoiceRevisionOf;

            RefreshGrandTotals();

            EnabledForm(false);

            btnFaktur.Visible = !string.IsNullOrEmpty(model.TaxInvoice);
        }

        private void RefreshGrandTotals()
        {
            if (tbxTotalSales.Text.Equals(string.Empty) || tbxTotalRaFee.Text.Equals(string.Empty) || tbxMateraiFee.Text.Equals(string.Empty)) return;

            var total = Convert.ToDecimal((from a in Shipments select a.TariffTotalInBaseCurrency).Sum());
            total -= ((SalesInvoiceModel)CurrentModel).TotalDiscount;

            total += ((SalesInvoiceModel)CurrentModel).RaTotal;

            total += (from a in Costs select a.Total).Sum();
            total += (from a in Shipments select a.PackingFee).Sum();
            total += (from a in Shipments select a.OtherFee).Sum();
            total += (from a in Shipments select a.InsuranceFee).Sum();
            //total *= Math.Max(Convert.ToDecimal(txtCurrencyRate.Value), 1);

            tbxBeforeTax.Text = total.ToString("n2");
        }

        private void UpdateCurrencyRate(string currencyCode = "IDR")
        {
            using (var currencyDm = new CurrencyDataManager())
            {
                CurrencyModel currency;

                if (((SalesInvoiceModel)CurrentModel).CurrencyId != 0)
                {
                    currency =
                        currencyDm.GetFirst<CurrencyModel>(
                            WhereTerm.Default(((SalesInvoiceModel)CurrentModel).CurrencyId,
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

                ((SalesInvoiceModel)CurrentModel).CurrencyId = currency.Id;
                ((SalesInvoiceModel)CurrentModel).CurrencyRate = currency.Rate;
                tbxCurrencyRate.Value = currency.Rate;
            }
        }

        protected override SalesInvoiceModel PopulateModel(SalesInvoiceModel model)
        {
            throw new NotImplementedException();
        }

        protected override SalesInvoiceModel Find(string searchTerm)
        {
            return DataManager.GetFirst<SalesInvoiceModel>(WhereTerm.Default(searchTerm, "ref_number"));
        }
    }
}
