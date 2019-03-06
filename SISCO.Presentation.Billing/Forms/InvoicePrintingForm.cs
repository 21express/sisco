using Devenlab.Common;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.Parameters;
using SISCO.App.Billing;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Billing.Reports;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Net;
using System.Diagnostics;

namespace SISCO.Presentation.Billing.Forms
{
    public partial class InvoicePrintingForm : BaseForm
    {
        private const int PRICING_PLAN_DOMESTIC = 1;

        public InvoicePrintingForm()
        {
            InitializeComponent();
            form = this;

            Load += InvoicePrintingForm_Load;
            Shown += InvoicePrintingForm_Shown;
        }

        void InvoicePrintingForm_Shown(object sender, EventArgs e)
        {
            cbxMonth.Focus();

            tbxDetail.Text = BaseControl.PrinterSetting.DotMatrix;
            tbxInvoice.Text = BaseControl.PrinterSetting.DotMatrix;
            tbxDelivery.Text = BaseControl.PrinterSetting.InkJet;
            tbxFaktur.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            chkContinous1.Checked = true;
            chkContinous2.Checked = true;
        }

        void InvoicePrintingForm_Load(object sender, EventArgs e)
        {
            InvoiceView.CustomColumnDisplayText += NumberGrid;
            InvoiceView.RowCellStyle += InvoiceView_RowCellStyle;
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

            using (var taxInvoiceDm = new TaxInvoiceDataManager())
            {
                cmbTaxInvoice.DataSource = taxInvoiceDm.Get<TaxInvoiceModel>();
            }
            cmbTaxInvoice.DisplayMember = "Name";
            cmbTaxInvoice.ValueMember = "Id";
            cmbTaxInvoice.SelectedIndex = -1;

            btnFind.Click += btnFind_Click;

            tbxDetail.ButtonClick += ButtonClick;
            tbxInvoice.ButtonClick += ButtonClick;
            tbxDelivery.ButtonClick += ButtonClick;
            tbxFaktur.ButtonClick += tbxFaktur_ButtonClick;

            btnChkDetail.Click += btnChk_Click;
            btnChkInvoice.Click += btnChk_Click;
            btnChkDelivery.Click += btnChk_Click;
            btnChkFaktur.Click += btnChk_Click;

            btnPrint.Click += btnPrint_Click;
            
            GridInvoice.DoubleClick += (s, args) => OpenRelatedForm(InvoiceView, new CreateSalesInvoiceForm());
        }

        void tbxFaktur_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    ((DevExpress.XtraEditors.ButtonEdit)sender).Text = fbd.SelectedPath;
                }
            }
        }

        void btnPrint_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < InvoiceView.RowCount; i++)
            {
                var id = (int) InvoiceView.GetRowCellValue(i, InvoiceView.Columns["Id"]);
                var salesInvoice = new SalesInvoiceModel();

                salesInvoice = new SalesInvoiceDataManager().GetFirst<SalesInvoiceModel>(WhereTerm.Default(id, "id"));
                if ((bool)InvoiceView.GetRowCellValue(i, InvoiceView.Columns["PrintDetail"]))
                {
                    if (string.IsNullOrEmpty(tbxDetail.Text))
                    {
                        MessageBox.Show("Pilih jenis printer");
                        tbxDetail.Focus();
                        return;
                    }

                    PrintRincian(salesInvoice);
                    InvoiceView.SetRowCellValue(i, InvoiceView.Columns["PrintDetail"], false);
                }

                if ((bool)InvoiceView.GetRowCellValue(i, InvoiceView.Columns["PrintInvoice"]))
                {
                    if (string.IsNullOrEmpty(tbxInvoice.Text))
                    {
                        MessageBox.Show("Pilih jenis printer");
                        tbxInvoice.Focus();
                        return;
                    }

                    PrintKwitansi(salesInvoice);
                    InvoiceView.SetRowCellValue(i, InvoiceView.Columns["PrintInvoice"], false);

                    salesInvoice.Printed = true;
                    salesInvoice.Modifiedby = BaseControl.UserLogin;
                    salesInvoice.Modifieddate = DateTime.Now;
                    new SalesInvoiceDataManager().Update<SalesInvoiceModel>(salesInvoice);

                    InvoiceView.SetRowCellValue(i, InvoiceView.Columns["Printed"], true);
                }

                if ((bool)InvoiceView.GetRowCellValue(i, InvoiceView.Columns["PrintDelivery"]))
                {
                    if (string.IsNullOrEmpty(tbxDelivery.Text))
                    {
                        MessageBox.Show("Pilih jenis printer");
                        tbxDelivery.Focus();
                        return;
                    }

                    PrintDelivery(salesInvoice);
                    InvoiceView.SetRowCellValue(i, InvoiceView.Columns["PrintDelivery"], false);
                }

                if ((bool)InvoiceView.GetRowCellValue(i, InvoiceView.Columns["DownloadFaktur"]))
                {
                    if (string.IsNullOrEmpty(tbxFaktur.Text))
                    {
                        MessageBox.Show("Pilih directory download");
                        tbxFaktur.Focus();
                        return;
                    }

                    DownloadFaktur(salesInvoice);
                    InvoiceView.SetRowCellValue(i, InvoiceView.Columns["DownloadFaktur"], false);
                }
            }
        }

        private IEnumerable<SalesInvoiceModel.SalesInvoiceReportRow> GetReceiptPrintDataSource(SalesInvoiceModel salesInvoice)
        {
            return new List<SalesInvoiceModel.SalesInvoiceReportRow>
            {
                ConvertModel<SalesInvoiceModel, SalesInvoiceModel.SalesInvoiceReportRow>(salesInvoice)
            };
        }

        void PrintRincian(SalesInvoiceModel salesInvoice)
        {
            var shipments = new SalesInvoiceListDataManager().GetFuckingShipments(salesInvoice.Id);
            var customer = new CustomerDataManager().GetFirst<CustomerModel>(WhereTerm.Default(salesInvoice.CompanyId, "id"));

            var printout = new SalesInvoicePrintout(chkContinous1.Checked, salesInvoice.TaxTotal > 0)
            {
                DataSource = shipments,
                Parameters =
                    {
                        new Parameter
                        {
                            Name = "SalesInvoice",
                            Value = salesInvoice
                        },
                        new Parameter
                        {
                            Name = "Domestic",
                            Value = (from a in shipments where !a.ServiceType.ToUpper().Equals("CITY COURIER") && a.PricingPlanId == PRICING_PLAN_DOMESTIC select a.TariffTotalInBaseCurrency).Sum()
                        },
                        new Parameter
                        {
                            Name = "CityCourier",
                            Value = (from a in shipments where a.ServiceType.ToUpper().Equals("CITY COURIER") select a.TariffTotalInBaseCurrency).Sum()
                        },
                        new Parameter
                        {
                            Name = "International",
                            Value = (from a in shipments where a.PricingPlanId != PRICING_PLAN_DOMESTIC select a.TariffTotalInBaseCurrency).Sum()
                        },
                        new Parameter
                        {
                            Name = "OtherFee",
                            Value = (from a in shipments select a.OtherFee).Sum()
                        },
                        new Parameter
                        {
                            Name = "RaMateraiFee",
                            Value = salesInvoice.RaTotal + salesInvoice.CostMaterai
                        },
                        new Parameter
                        {
                            Name = "DiscountPercent",
                            Value = customer.Discount
                        },
                        new Parameter
                        {
                            Name = "Discount",
                            Value = shipments.Sum(r => r.Discount) * salesInvoice.CurrencyRate
                        },
                        new Parameter
                        {
                            Name = "PackingInsuranceFee",
                            Value = (from a in shipments select a.PackingFee + a.InsuranceFee).Sum()
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
                        },
                        new Parameter
                        {
                            Name = "StartPage",
                            Value = 0
                        },
                        new Parameter
                        {
                            Name = "EndPage",
                            Value = 0
                        }
                    }
            };
            printout.Print(tbxDetail.Text);
        }

        void PrintKwitansi(SalesInvoiceModel salesInvoice)
        {
            if (salesInvoice.SalesInvoiceType == "PERUSAHAAN")
            {
                var printout = new PaymentReceiptCorporatePrintout
                {
                    DataSource = GetReceiptPrintDataSource(salesInvoice)
                };
                printout.Print(tbxInvoice.Text);
            }
            else
            {
                var printout = new PaymentReceiptPrintout
                {
                    DataSource = GetReceiptPrintDataSource(salesInvoice)
                };
                printout.Print(tbxInvoice.Text);
            }
        }

        void PrintDelivery(SalesInvoiceModel salesInvoice)
        {
            var branch = new BranchDataManager().GetFirst<BranchModel>(WhereTerm.Default(salesInvoice.BranchId, "id"));
            var city = new CityDataManager().GetFirst<CityModel>(WhereTerm.Default(branch.CityId, "id"));

            var printout = new InvoiceDelivery2PrintOut
            {
                DataSource = GetReceiptPrintDataSource(salesInvoice),
                Parameters =
                {
                    new Parameter
                    {
                        Name = "CityName",
                        Value = city.Name
                    }
                }
            };
            printout.Print(tbxDelivery.Text);
            printout.Print(tbxDelivery.Text);
        }

        void DownloadFaktur(SalesInvoiceModel salesInvoice)
        {
            if (!string.IsNullOrEmpty(salesInvoice.TaxInvoice))
            {
                string url = string.Format("{0}api/v1/{1}/faktur", BaseControl.SiscoBaseAddressApi, (salesInvoice.TaxInvoice));
                Uri uri = new Uri(url);

                var filename = tbxFaktur.Text + "\\" + salesInvoice.TaxInvoice;

                using (var client = new WebClient())
                {
                    client.DownloadFile(url, filename);
                }
            }
            /*ProcessStartInfo printProcessInfo = new ProcessStartInfo()
            {
                Verb = "print",
                CreateNoWindow = true,
                FileName = @"C:\Program Files\Adobe\Acrobat 7.0\Reader\AcroRd32.exe",
                WindowStyle = ProcessWindowStyle.Hidden,
                Arguments = "/p /h"" + filename + "\""
            };

            Process printProcess = new Process();
            printProcess.StartInfo = printProcessInfo;
            printProcess.Start();

            printProcess.WaitForInputIdle();
            printProcess.Kill();*/
        }

        void btnChk_Click(object sender, EventArgs e)
        {
            if (((DevExpress.XtraEditors.SimpleButton)sender).Text == "Check Rincian")
            {
                ((DevExpress.XtraEditors.SimpleButton)sender).Text = "Uncheck Rincian";
                CheckListGrid(true, "PrintDetail");
            } else if (((DevExpress.XtraEditors.SimpleButton)sender).Text == "Uncheck Rincian")
            {
                ((DevExpress.XtraEditors.SimpleButton)sender).Text = "Check Rincian";
                CheckListGrid(false, "PrintDetail");
            }

            if (((DevExpress.XtraEditors.SimpleButton)sender).Text == "Check Kwitansi")
            {
                ((DevExpress.XtraEditors.SimpleButton)sender).Text = "Uncheck Kwitansi";
                CheckListGrid(true, "PrintInvoice");
            } else if (((DevExpress.XtraEditors.SimpleButton)sender).Text == "Uncheck Kwitansi")
            {
                ((DevExpress.XtraEditors.SimpleButton)sender).Text = "Check Kwitansi";
                CheckListGrid(false, "PrintInvoice");
            }

            if (((DevExpress.XtraEditors.SimpleButton)sender).Text == "Check Tanda Terima")
            {
                ((DevExpress.XtraEditors.SimpleButton)sender).Text = "Uncheck Tanda Terima";
                CheckListGrid(true, "PrintDelivery");
            } else if (((DevExpress.XtraEditors.SimpleButton)sender).Text == "Uncheck Tanda Terima")
            {
                ((DevExpress.XtraEditors.SimpleButton)sender).Text = "Check Tanda Terima";
                CheckListGrid(false, "PrintDelivery");
            }

            if (((DevExpress.XtraEditors.SimpleButton)sender).Text == "Check Faktur")
            {
                ((DevExpress.XtraEditors.SimpleButton)sender).Text = "Uncheck Faktur";
                CheckListGrid(true, "DownloadFaktur");
            } else if (((DevExpress.XtraEditors.SimpleButton)sender).Text == "Uncheck Faktur")
            {
                ((DevExpress.XtraEditors.SimpleButton)sender).Text = "Check Faktur";
                CheckListGrid(false, "DownloadFaktur");
            }
        }

        void CheckListGrid(bool check, string columnName)
        {
            for (int i = 0; i < InvoiceView.RowCount; i++)
            {
                InvoiceView.SetRowCellValue(i, InvoiceView.Columns[columnName], check);
            }

            InvoiceView.RefreshData();
        }

        void ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var printdialog = new PrintDialog();
            if (((DevExpress.XtraEditors.ButtonEdit)sender).Text != "") printdialog.PrinterSettings.PrinterName = ((DevExpress.XtraEditors.ButtonEdit)sender).Text;
            printdialog.ShowNetwork = true;
            printdialog.ShowDialog();

            ((DevExpress.XtraEditors.ButtonEdit)sender).Text = printdialog.PrinterSettings.PrinterName;
        }

        void btnFind_Click(object sender, EventArgs e)
        {
            if (cbxYear.SelectedIndex == -1)
            {
                cbxYear.Focus();
                return;
            }

            if (cbxMonth.SelectedIndex <= 0)
            {
                cbxMonth.Focus();
                return;
            }

            if (lkpBranch.Value == null)
            {
                lkpBranch.Focus();
                return;
            }

            if (cmbTaxInvoice.SelectedIndex == -1)
            {
                cmbTaxInvoice.Focus();
                return;
            }

            GridInvoice.DataSource = new SalesInvoiceDataManager().GetInvoiceToPrint((int)lkpBranch.Value, cbxYear.SelectedValue.ToString(), cbxMonth.SelectedValue.ToString().PadLeft(2, '0'), (int) cmbTaxInvoice.SelectedValue);
            InvoiceView.RefreshData();
        }

        void InvoiceView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var view = sender as GridView;
                if ((bool)view.GetRowCellValue(e.RowHandle, view.Columns["Printed"]))
                    e.Appearance.ForeColor = Color.Red;
                else
                    e.Appearance.ForeColor = Color.Black;
            }
        }
    }
}