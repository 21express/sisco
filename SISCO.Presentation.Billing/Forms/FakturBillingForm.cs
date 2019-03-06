using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.WinControl.MessageBox;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.Parameters;
using SISCO.App.Billing;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Reports;
using SISCO.Presentation.MasterData.Popup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace SISCO.Presentation.Billing.Forms
{
    public partial class FakturBillingForm : BaseForm
    {
        private const int PRICING_PLAN_DOMESTIC = 1;

        protected ExtendedBindingList<SalesInvoiceListDataRow> Shipments { get; set; }

        public FakturBillingForm()
        {
            InitializeComponent();
            form = this;

            GridInvoice.DoubleClick += (sender, args) => OpenRelatedForm(InvoiceView, new InvoiceTrackingViewForm(), "RefNumber");
        }

        protected override void OnLoad(EventArgs e)
        {
            btnFilter.Click += Filter;
            rbBtnFaktur.Click += UploadFaktur;
            rpBtnPdf.Click += DownloadPdf;
            btnRevised.Click += Revisi;

            InvoiceView.RowCellStyle += ChangeColor;

            lkpBranch.LookupPopup = new BranchPopup();
            lkpBranch.AutoCompleteDataManager = new BranchDataManager();
            lkpBranch.AutoCompleteDisplayFormater = model => ((BranchModel)model).Code + " " + ((BranchModel)model).Name;
            lkpBranch.AutoCompleteWhereExpression +=
                (s, param) => param.SetWhereExpression("code = @0 or name.StartsWith(@0)", s);

            var yearMember = new List<ComboMember>();
            for (var y = 2013; y <= DateTime.Now.Year; y++)
                yearMember.Add(new ComboMember { Id = y, Name = y.ToString() });

            cbxYear.DataSource = yearMember;

            var monthMember = new List<ComboMember>
            {
                new ComboMember(),
                new ComboMember{Id = 1, Name = "Januari"},
                new ComboMember{Id = 2, Name = "Febuari"},
                new ComboMember{Id = 3, Name = "Maret"},
                new ComboMember{Id = 4, Name = "April"},
                new ComboMember{Id = 5, Name = "Mei"},
                new ComboMember{Id = 6, Name = "Juni"},
                new ComboMember{Id = 7, Name = "Juli"},
                new ComboMember{Id = 8, Name = "Agustus"},
                new ComboMember{Id = 9, Name = "September"},
                new ComboMember{Id = 10, Name = "Oktober"},
                new ComboMember{Id = 11, Name = "November"},
                new ComboMember{Id = 12, Name = "Desember"},
            };

            cbxMonth.DataSource = monthMember;

            cbxYear.SelectedValue = DateTime.Now.Year;
            GridInvoice.DataSource = new SalesInvoiceDataManager().GetTaxInvoice(cbxYear.SelectedValue.ToString(), cbxMonth.SelectedValue.ToString().PadLeft(2, '0'), lkpBranch.Value);
            InvoiceView.RefreshData();

            using (var taxInvoiceDm = new TaxInvoiceDataManager())
            {
                cmbTaxInvoice.DataSource = taxInvoiceDm.Get<TaxInvoiceModel>();
            }
            cmbTaxInvoice.DisplayMember = "Name";
            cmbTaxInvoice.ValueMember = "Id";
            cmbTaxInvoice.SelectedIndex = -1;
        }

        private void Revisi(object sender, EventArgs e)
        {
            var view = GridInvoice.FocusedView as GridView;
            var taxInvoice = view.GetRowCellValue(view.FocusedRowHandle, view.Columns["TaxInvoice"]) != null ? view.GetRowCellValue(view.FocusedRowHandle, view.Columns["TaxInvoice"]).ToString() : string.Empty;
            var refNumber = view.GetRowCellValue(view.FocusedRowHandle, view.Columns["RefNumber"]).ToString();
            var printed = Convert.ToBoolean(view.GetRowCellValue(view.FocusedRowHandle, view.Columns["Printed"]).ToString());

            if (printed)
            {
                MessageBox.Show("Tidak bisa merevisi invoice yang sudah di print.");
                return;
            }

            if (!string.IsNullOrEmpty(taxInvoice))
            {
                var d = MessageForm.Ask(form, "Request Revisi", "Invoice sudah memiliki faktur, anda yakin akan melanjutkan proses revisi invoice? Jika iya faktur pajak akan terhapus.");
                if (d == DialogResult.No) return;
            }

            var dialog = MessageForm.Ask(form, "Request Revisi", "Anda yakin akan mengembalikan invoice ini kepada billing untuk dilakukan revisi?");
            if (dialog == DialogResult.Yes)
            {
                var salesInvoice = new SalesInvoiceDataManager().GetFirst<SalesInvoiceModel>(WhereTerm.Default(refNumber, "ref_number"));
                if (salesInvoice == null)
                {
                    MessageBox.Show(string.Format("No invoice {0} tidak ditemukan, proses revisi tidak dapat dilakukan"));
                    return;
                }
                else
                {
                    salesInvoice.ReqTaxInvoice = false;
                    salesInvoice.TaxInvoice = null;

                    new SalesInvoiceDataManager().Update<SalesInvoiceModel>(salesInvoice);
                    Filter(sender, e);
                }
            }
        }

        private void DownloadPdf(object sender, EventArgs e)
        {
            var view = GridInvoice.FocusedView as GridView;
            var refNumber = view.GetRowCellValue(view.FocusedRowHandle, view.Columns["RefNumber"]).ToString();
            var salesInvoice = new SalesInvoiceDataManager().GetFirst<SalesInvoiceModel>(WhereTerm.Default(refNumber, "ref_number"));
            Shipments = PopulateShipmentList(salesInvoice, new SalesInvoiceListDataManager().GetJoinShipmentAndDelivery(salesInvoice.Id));
            var customer = new CustomerDataManager().GetFirst<CustomerModel>(WhereTerm.Default(salesInvoice.CompanyId, "id"));

            var totalRaaCw = salesInvoice.RaChargeableWeight;
            var totalRaaFeePerPrice = salesInvoice.RaFee;
            var totalRaaFee = totalRaaCw * totalRaaFeePerPrice;
            var totalCityCourier =
                    (from a in Shipments where a.ServiceType.ToUpper().Equals("CITY COURIER") select a.TariffTotalInBaseCurrency).Sum();
            var totalDomestic =
                (from a in Shipments where !a.ServiceType.ToUpper().Equals("CITY COURIER") && a.PricingPlanId == 1 select a.TariffTotalInBaseCurrency).Sum();
            var totalInternational =
                    (from a in Shipments where a.PricingPlanId != PRICING_PLAN_DOMESTIC select a.TariffTotalInBaseCurrency).Sum();

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
                                Value = totalDomestic
                            },
                            new Parameter
                            {
                                Name = "CityCourier",
                                Value = totalCityCourier
                            },
                            new Parameter
                            {
                                Name = "International",
                                Value = totalInternational
                            },
                            new Parameter
                            {
                                Name = "OtherFee",
                                Value = (from a in Shipments select a.OtherFee).Sum()
                            },
                            new Parameter
                            {
                                Name = "RaMateraiFee",
                                Value = totalRaaFee + salesInvoice.CostMaterai
                            },
                            new Parameter
                            {
                                Name = "DiscountPercent",
                                Value = salesInvoice.Discount
                            },
                            new Parameter
                            {
                                Name = "Discount",
                                Value = salesInvoice.TotalDiscount
                            },
                            new Parameter
                            {
                                Name = "PackingInsuranceFee",
                                Value = (from a in Shipments select a.PackingFee + a.InsuranceFee).Sum()
                            },
                            new Parameter
                            {
                                Name = "GrandTotal",
                                Value = salesInvoice.Total
                            },
                            new Parameter
                            {
                                Name = "TaxRate",
                                Value = salesInvoice.TaxRate,
                            },
                            new Parameter
                            {
                                Name = "TaxTotal",
                                Value = salesInvoice.TaxTotal
                            }
                        }
            };

            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + string.Format("invoice-{0}-{1}{2}", salesInvoice.RefNumber.Replace(" ", "_"), DateTime.Now.ToString("yyyyMMddHHmm"), ".pdf");
            printout.ExportToPdf(path);
            System.Diagnostics.Process.Start("explorer.exe", @"/select,""" + path + "\"");
        }

        private void Filter(object sender, EventArgs e)
        {
            GridInvoice.DataSource = new SalesInvoiceDataManager().GetTaxInvoice(cbxYear.SelectedValue.ToString(), (int)cbxMonth.SelectedValue > 0 ? cbxMonth.SelectedValue.ToString().PadLeft(2, '0') : null, lkpBranch.Value, cbxPrint.Checked, cmbTaxInvoice.SelectedIndex >= 0 ? (int?)cmbTaxInvoice.SelectedValue : null);
            InvoiceView.RefreshData();
        }

        private void UploadFaktur(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var view = GridInvoice.FocusedView as GridView;
                var refNumber = view.GetRowCellValue(view.FocusedRowHandle, view.Columns["RefNumber"]).ToString();

                var fileStream = File.Open(openFileDialog1.FileName, FileMode.Open);
                var fileInfo = new FileInfo(openFileDialog1.FileName);

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("ActorBy", BaseControl.UserLogin);
                client.DefaultRequestHeaders.Add("MachineName", "SISCOAPPMC");
                client.DefaultRequestHeaders.Add("BranchId", BaseControl.BranchId.ToString());
                client.DefaultRequestHeaders.Add("Token", BaseControl.SiscoTokenApi);
                client.BaseAddress = new Uri(BaseControl.SiscoBaseAddressApi);
                 
                var content = new MultipartFormDataContent();
                content.Add(new StreamContent(fileStream), "\"file\"", string.Format("\"{0}\"", fileInfo.Name)
                );

                FileUploadResult actionResult = null;
                bool _fileUploaded = false;

                Task taskUpload = client.PostAsync(string.Format("api/v1/faktur/{0}", refNumber), content).ContinueWith((s) =>
                {
                    if (s.Status == TaskStatus.RanToCompletion)
                    {
                        var response = s.Result;
                        var jsonResponse = response.Content.ReadAsStringAsync();
                        jsonResponse.Wait();

                        if (response.IsSuccessStatusCode)
                        {
                            var jsonConvert = new JavaScriptSerializer();
                            actionResult = jsonConvert.Deserialize<FileUploadResult>(jsonResponse.Result);
                            if (actionResult != null) _fileUploaded = true;
                        }
                        else
                        {
                            //Debug.WriteLine("Status Code: {0} - {1}", response.StatusCode, response.ReasonPhrase);
                            //Debug.WriteLine("Response Body: {0}", response.Content.ReadAsStringAsync().Result);
                        }
                    }

                    fileStream.Dispose();
                });

                taskUpload.Wait();
                if (_fileUploaded) view.SetRowCellValue(view.FocusedRowHandle, view.Columns["TaxInvoice"], actionResult.FileName);
                InvoiceView.RefreshData();

                client.Dispose();
            }
        }

        private ExtendedBindingList<SalesInvoiceListDataRow> PopulateShipmentList(SalesInvoiceModel salesInvoice, IEnumerable<SalesInvoiceListModel> shipmentModels)
        {
            decimal currencyRate = 0;
            Shipments = new ExtendedBindingList<SalesInvoiceListDataRow>();
            using (var currencyDm = new CurrencyDataManager())
            {
                CurrencyModel currency;

                if (salesInvoice.CurrencyId != 0)
                {
                    currency = currencyDm.GetFirst<CurrencyModel>(WhereTerm.Default(salesInvoice.CurrencyId, "id"));
                }
                else
                {
                    currency = currencyDm.GetFirst<CurrencyModel>(WhereTerm.Default(shipmentModels.First().Currency, "code"));
                }

                if (currency == null)
                {
                    currency = new CurrencyModel
                    {
                        Id = 1,
                        Code = "IDR"
                    };
                }

                currencyRate = currency.Rate;
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
                    GrandTotal = salesInvoice.Printed ? row.GrandTotal : row.GrandTotalInBaseCurrency * salesInvoice.CurrencyRate,
                    GrandTotalInBaseCurrency = row.GrandTotalInBaseCurrency,
                    DestinationCity = row.DestinationCity,
                    Currency = row.Currency,
                    //CurrencyRate = row.CurrencyRate,
                    CurrencyRate = currencyRate,
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
                Shipments.Add(row);
            }

            var copied = new SalesInvoiceListDataRow[Shipments.Count];
            Shipments.CopyTo(copied, 0);

            Shipments.Clear();
            copied.OrderBy(r => r.ShipmentProcessDate.Date).ThenBy(r => r.ShipmentCode).ToList().ForEach(r => Shipments.Add(r));

            return Shipments;
        }

        private void ChangeColor(object sender, RowCellStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var view = sender as GridView;
                if (view != null && view.GetRowCellValue(e.RowHandle, view.Columns["InvoiceRevisionOf"]) != null)
                    e.Appearance.ForeColor = Color.Red;
                else
                    e.Appearance.ForeColor = Color.Black;
            }
        }
    }

    public class ComboMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class FileUploadResult
    {
        public string LocalFilePath { get; set; }
        public string FileName { get; set; }
        public long FileLength { get; set; }
    }
}