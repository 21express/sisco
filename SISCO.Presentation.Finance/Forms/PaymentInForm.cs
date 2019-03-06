using System;
using System.Collections.Generic;
using System.Globalization;
using Devenlab.Common;
using Devenlab.Common.Interfaces;
using Devenlab.Common.WinControl.MessageBox;
using DevExpress.XtraGrid.Views.Base;
using SISCO.App.Billing;
using SISCO.App.Finance;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.Common.Properties;
using SISCO.Presentation.Finance.Popup;
using SISCO.Presentation.MasterData.Popup;
using System.Linq;
using SISCO.Presentation.Finance.Report;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Parameters;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using SISCO.Presentation.CustomerService.Popup;
using SISCO.App.CustomerService;

namespace SISCO.Presentation.Finance.Forms
{
    public partial class PaymentInForm : BaseCrudForm<PaymentInModel, PaymentInDataManager>//BaseToolbarForm//
    {
        private PaymentInDetailDataManager _detailDm = new PaymentInDetailDataManager();
        private TransactionalAccountPopup transactionPopup;
        private bool DeleteOld { get; set; }
        private string Code { get; set; }
        private decimal McPercent { get; set; }
        private decimal RcPercent { get; set; }
        private int? MarketingId { get; set; }
        private decimal MaxAmount { get; set; }
        private List<int> DeletedRows { get; set; }

        public PaymentInForm()
        {
            InitializeComponent();

            form = this;
            Load += PayamentInLoad;
            tbxCustomer.Leave += GetCustomerCommission;
            btnAdd.Click += GetInvoice;
            PaymentView.CustomColumnDisplayText += NumberGrid;
            ClaimView.CustomColumnDisplayText += NumberGrid;
            PaymentView.CellValueChanged += Changed;
            tbxAdjustment.Leave += CalculateTotal;
            tbxTtlClaim.EditValueChanged += CalculateTotal;

            ClaimView.CellValueChanged += PaidClaimed;
            ClaimView.CellValueChanging += PayClaimed;
            btnDelete.ButtonClick += btnDelete_ButtonClick;
            btnDownload.ButtonClick += btnDownload_ButtonClick;

            tbxRcFixed.Leave += (sender, args) =>
            {
                var total = tbxRcPercent.Value + tbxRcFixed.Value;
                tbxRcTotal.SetValue(total.ToString(CultureInfo.InvariantCulture));
            };

            tbxMcFixed.Leave += (sender, args) =>
            {
                var total = tbxMcPercent.Value + tbxMcFixed.Value;
                tbxMcTotal.SetValue(total.ToString(CultureInfo.InvariantCulture));
            };

            DataManager.DefaultParameters = new IListParameter[]
            {
                WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals)
            };
        }

        void btnDownload_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var rows = ClaimView.GetSelectedRows();
            if (rows.Count() > 0)
            {
                if (!string.IsNullOrEmpty(ClaimView.GetRowCellValue(rows[0], "DocName").ToString()))
                {
                    string url = string.Format("{0}api/v1/claimed-doc?filename={1}", BaseControl.SiscoBaseAddressApi, ClaimView.GetRowCellValue(rows[0], "DocName").ToString());
                    System.Diagnostics.Process.Start(url);
                }
            }
        }

        void btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var dialog = MessageForm.Ask(form, Resources.delete_confirm, Resources.delete_confirm_msg);
            if (dialog == DialogResult.Yes)
            {
                var rowHandle = ClaimView.FocusedRowHandle;
                if ((int)ClaimView.GetRowCellValue(rowHandle, ClaimView.Columns["Id"]) > 0) DeletedRows.Add((int)ClaimView.GetRowCellValue(rowHandle, ClaimView.Columns["Id"]));
                ClaimView.DeleteSelectedRows();

                var detail = GridClaim.DataSource as List<PaymentClaim>;
                tbxTtlClaim.SetValue(detail.Sum(p => p.Payment));
            }
        }

        private void PayClaimed(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.Name == "clClaimPayment")
            {
                if (!ClaimView.GetRowCellValue(e.RowHandle, ClaimView.Columns["StateChange"]).ToString().Equals(EnumStateChange.Insert.ToString()))
                {
                    ClaimView.SetRowCellValue(e.RowHandle, ClaimView.Columns["StateChange"], EnumStateChange.Update.ToString());
                }
            }
        }

        private void PaidClaimed(object sender, CellValueChangedEventArgs e)
        {
            var detail = GridClaim.DataSource as List<PaymentClaim>;
            tbxTtlClaim.SetValue(detail.Sum(p => p.Payment));

            if ((decimal)ClaimView.GetRowCellValue(e.RowHandle, ClaimView.Columns["Payment"]) > (decimal)ClaimView.GetRowCellValue(e.RowHandle, ClaimView.Columns["Total"]))
            {
                ClaimView.SetRowCellValue(e.RowHandle, PaymentView.Columns["Payment"], (decimal)ClaimView.GetRowCellValue(e.RowHandle, ClaimView.Columns["Total"]));
            }
        }

        private void CalculateTotal(object sender, EventArgs e)
        {
            tbxTotal.SetValue(((Int64)tbxTotalInvoice.Value - (decimal)tbxTotalPph.Value - (decimal)tbxMaterai.Value - (decimal)tbxTtlClaim.Value - (Int64)tbxAdjustment.Value).ToString(CultureInfo.InvariantCulture));
        }

        private void Changed(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.Name != "clState" && e.Column.Name != "clBalance" && e.Column.Name != "clTotalPph23")
            {
                var due = Convert.ToInt32(PaymentView.GetRowCellValue(e.RowHandle, PaymentView.Columns["InvoiceBalance"]));
                var payment = Convert.ToInt32(PaymentView.GetRowCellValue(e.RowHandle, PaymentView.Columns["Payment"]));

                if (e.Column.Name == "clPayment")
                {
                    PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["Balance"], (due-payment));
                }
                
                var total = 0;
                for (var i = 0; i < PaymentView.RowCount; i++)
                {
                    total += Convert.ToInt32(PaymentView.GetRowCellValue(i, PaymentView.Columns["Payment"]));
                }

                if (McPercent > 0)
                {
                    var percent = Math.Round((McPercent*total)/100, MidpointRounding.AwayFromZero);
                    tbxMcPercent.SetValue(percent.ToString(CultureInfo.InvariantCulture));

                    var mctotal = percent + tbxMcFixed.Value;
                    tbxMcTotal.SetValue(mctotal.ToString(CultureInfo.InvariantCulture));
                }

                if (RcPercent > 0)
                {
                    var percent = Math.Round((RcPercent*total)/100, MidpointRounding.AwayFromZero);
                    tbxRcPercent.SetValue(percent.ToString("#,#0"));

                    var rctotal = percent + tbxRcFixed.Value;
                    tbxRcTotal.SetValue(rctotal.ToString("#,#0"));
                }

                decimal pph = 0;
                decimal materai = 0;
                var detail = GridPayment.DataSource as List<PaymentInDetailModel>;
                detail.ForEach(d => {
                    if (d.UsePph23) pph += (decimal)d.TotalPph23;
                    if (d.UseMaterai) materai += (decimal)d.MateraiFee;
                });

                tbxTotalInvoice.SetValue(total.ToString(CultureInfo.InvariantCulture));
                tbxTotalPph.SetValue(pph);
                tbxMaterai.SetValue(materai);
                tbxTotal.SetValue(((Int64)tbxTotalInvoice.Value - (decimal)tbxTotalPph.Value - materai - (Int64)tbxAdjustment.Value).ToString(CultureInfo.InvariantCulture));

                if (PaymentView.GetRowCellValue(e.RowHandle, PaymentView.Columns["StateChange2"]).ToString() ==
                    EnumStateChange.Idle.ToString())
                {
                    PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["StateChange2"], EnumStateChange.Insert);
                }

                if (PaymentView.GetRowCellValue(e.RowHandle, PaymentView.Columns["StateChange2"]).ToString() ==
                    EnumStateChange.Select.ToString())
                {
                    PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["StateChange2"], EnumStateChange.Update);
                }
            }

            if ((bool)PaymentView.GetRowCellValue(e.RowHandle, PaymentView.Columns["UsePph23"]) && !(bool)PaymentView.GetRowCellValue(e.RowHandle, PaymentView.Columns["Checked"]))
            {
                PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["Checked"], true);
            }

            if ((bool)PaymentView.GetRowCellValue(e.RowHandle, PaymentView.Columns["IsReturn"]) && !(bool)PaymentView.GetRowCellValue(e.RowHandle, PaymentView.Columns["UsePph23"]))
            {
                PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["UsePph23"], true);
            }
        }

        private void GetCustomerCommission(object sender, EventArgs e)
        {
            base.OnLeave(e);

            McPercent = 0;
            RcPercent = 0;

            if (tbxCustomer.Value != null)
            {
                var customer = new CustomerDataManager().GetFirst<CustomerModel>(WhereTerm.Default((int)tbxCustomer.Value, "id", EnumSqlOperator.Equals));
                if (customer.McPercent > 0) McPercent = customer.McPercent;
                if (customer.RcPercent > 0) RcPercent = customer.RcPercent;
                if (customer.MarketingEmployeeId != null) MarketingId = customer.MarketingEmployeeId;

                if (CurrentModel.Id > 0) PopulateForm((PaymentInModel)CurrentModel);
                else
                {
                    if (customer.McFixed > 0)
                    {
                        tbxMcFixed.SetValue(customer.McFixed.ToString(CultureInfo.InvariantCulture));
                        tbxMcTotal.SetValue(customer.McFixed.ToString(CultureInfo.InvariantCulture));
                    }

                    if (customer.RcFixed > 0)
                    {
                        tbxRcFixed.SetValue(customer.RcFixed.ToString(CultureInfo.InvariantCulture));
                        tbxRcTotal.SetValue(customer.RcFixed.ToString(CultureInfo.InvariantCulture));
                    }
                }
            }
            else
            {
                GridPayment.DataSource = null;
                PaymentView.RefreshData();
            }
        }

        private void GetInvoice(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxInvoice.Text))
            {
                tbxInvoice.Focus();
                return;
            }

            var ds = GridPayment.DataSource as List<PaymentInDetailModel>;
            if (ds == null) ds = new List<PaymentInDetailModel>();

            var invoices =
                new SalesInvoiceDataManager().Get<SalesInvoiceModel>(new IListParameter[]
                {
                    WhereTerm.Default((int) tbxCustomer.Value, "company_id", EnumSqlOperator.Equals),
                    WhereTerm.Default(true, "printed"),
                    WhereTerm.Default(false, "cancelled"),
                    WhereTerm.Default(tbxInvoice.Text, "ref_number")
                });

            if (invoices.Count() == 0)
            {
                MessageForm.Info(this, "Info", "No invoice tidak ditemukan.");
                tbxInvoice.Clear();
                tbxInvoice.Focus();
                return;
            }
            var salesRepo = new SalesInvoiceTypeDataManager();
            foreach (SalesInvoiceModel invoice in invoices)
            {
                var payment = _detailDm.GetPaymentInvoice(invoice.Id);
                var balance = invoice.Total - payment;

                if (balance > 0)
                {
                    var saleType = salesRepo.GetFirst<SalesInvoiceTypeModel>(WhereTerm.Default(invoice.SalesInvoiceTypeId, "id", EnumSqlOperator.Equals));
                    if (ds.Where(p => p.InvoiceRefNumber == invoice.RefNumber).ToList().Count == 0)
                    {
                        ds.Add(new PaymentInDetailModel
                        {
                            InvoiceId = invoice.Id,
                            InvoiceCode = invoice.Code,
                            InvoiceDate = invoice.Vdate,
                            InvoiceTotal = invoice.Total,
                            InvoiceBalance = balance,
                            //Payment = 0,
                            //Balance = balance,
                            Payment = balance,
                            Balance = 0,
                            //Checked = false,
                            Checked = false,
                            InvoiceType = saleType != null ? saleType.Name : "",
                            InvoiceRefNumber = invoice.RefNumber,
                            StateChange2 = EnumStateChange.Insert.ToString()
                            //StateChange2 = EnumStateChange.Idle.ToString()
                        });
                    }
                }
                else
                {
                    MessageForm.Info(form, "Informasi", "Sudah ada pembayaran untuk invoice tsb.");
                    tbxInvoice.Clear();
                    tbxInvoice.Focus();
                    return;
                }
            }

            GridPayment.DataSource = ds;
            PaymentView.RefreshData();

            PaymentView.SetRowCellValue(ds.Count - 1, PaymentView.Columns["Checked"], true);

            tbxInvoice.Clear();
            tbxInvoice.Focus();
        }

        private void PayamentInLoad(object sender, EventArgs e)
        {
            ClearForm();

            transactionPopup = new TransactionalAccountPopup(lkpAccount, true);

            MaxAmount = 0;

            EnableBtnPrint = false;
            EnableBtnPrintPreview = false;
            EnableBtnSearch = true;
            SearchPopup = new PaymentInFilterPopup();

            tbxCustomer.LookupPopup = new CustomerPopup(new IListParameter[] { WhereTerm.Default(BaseControl.BranchId, "branch_id", EnumSqlOperator.Equals) });
            tbxCustomer.AutoCompleteDataManager = new CustomerDataManager();
            tbxCustomer.AutoCompleteDisplayFormater = model => ((CustomerModel)model).Code + " - " + ((CustomerModel)model).Name;
            tbxCustomer.AutoCompleteWhereExpression = (s, p) =>
                p.SetWhereExpression("(code = @0 OR name.StartsWith(@0)) AND branch_id = @1", s, BaseControl.BranchId);

            tbxPayment.LookupPopup = new PaymentTypePopup();
            tbxPayment.AutoCompleteDataManager = new PaymentTypeDataManager();
            tbxPayment.AutoCompleteDisplayFormater = model => ((PaymentTypeModel)model).Name;
            tbxPayment.AutoCompleteWheretermFormater = s => new IListParameter[]
            {
                WhereTerm.Default(s, "name", EnumSqlOperator.BeginWith)
            };

            lkpAccount.LookupPopup = new BankAccountPopup();
            lkpAccount.AutoCompleteDataManager = new BankAccountDataManager();
            lkpAccount.AutoCompleteDisplayFormater = model => ((BankAccountModel)model).AccountNo + " " + ((BankAccountModel)model).BankName;
            lkpAccount.AutoCompleteWhereExpression +=
                (s, param) => param.SetWhereExpression("account_no.StartsWith(@0) and branch_id = @1", s, BaseControl.BranchId);

            lkpAccount.TextChanged += (s, ar) => {
                lkpTransactional.Value = null;
                lkpTransactional.Text = string.Empty;
                MaxAmount = 0;
            };

            lkpTransactional.LookupPopup = transactionPopup;
            lkpTransactional.AutoCompleteDataManager = new TransactionalAccountDataManager();
            lkpTransactional.AutoCompleteDisplayFormater = model => ((TransactionalAccountModel)model).Description + " Rp " + ((TransactionalAccountModel)model).CreditTotalAmount.ToString("#,#");
            lkpTransactional.AutoCompleteWhereExpression +=
                (s, param) => param.SetWhereExpression(string.Format("(description.StartsWith(@0){0}) and debit_total_amount = 0 and closed_date = null", Regex.IsMatch(s, "^[0-9]+$") ? " or credit_total_amount = " + s : ""), s);

            lkpTransactional.Leave += lkpTransactional_Leave;

            lkpClaim.LookupPopup = new ClaimPopup();
            lkpClaim.AutoCompleteDataManager = new ClaimedDataManager();
            lkpClaim.AutoCompleteDisplayFormater = model => ((ClaimedModel)model).LetterNo + " - " + ((ClaimedModel)model).CustomerName;
            lkpClaim.AutoCompleteWhereExpression +=
                (s, param) => param.SetWhereExpression("(letter_no = @letterNo or customer_name like @customerName) and customer_branch_id = @custBranchId", s, BaseControl.BranchId);

            PaymentView.CellValueChanging += Changing;

            tbxRcPercent.IsNumber = true;
            tbxMcPercent.IsNumber = true;
            tbxRcTotal.IsNumber = true;
            tbxMcTotal.IsNumber = true;
            tbxRcPayment.IsNumber = true;
            tbxMcPayment.IsNumber = true;
            tbxRcFixed.IsNumber = true;
            tbxMcFixed.IsNumber = true;

            tbxAmount.IsNumber = true;
            tbxTotal.IsNumber = true;
            tbxTotalInvoice.IsNumber = true;
            tbxAdjustment.IsNumber = true;
            tbxTtlClaim.IsNumber = true;

            tsBaseBtn_Print.Click += Print;
            tsBaseBtn_PrintPreview.Click += PrintPreview;

            tbxDate.EditValueChanged += tbxDate_EditValueChanged;
            btnAddClaim.Click += btnAddClaim_Click;
        }

        void btnAddClaim_Click(object sender, EventArgs e)
        {
            if (lkpClaim.Value != null)
            {
                var data = new ClaimedDataManager().GetClaim((int)lkpClaim.Value);
                if (data != null)
                {
                    var claims = GridClaim.DataSource as List<PaymentClaim>;
                    if (claims.Where(p => p.ClaimedId == data.ClaimedId).FirstOrDefault() == null)
                    {
                        data.Payment = data.Total;
                        data.StateChange = EnumStateChange.Insert.ToString();

                        claims.Add(data);
                        GridClaim.DataSource = claims;
                        ClaimView.RefreshData();

                        tbxTtlClaim.SetValue(claims.Sum(p => p.Payment));
                    }
                }
                else MessageBox.Show("Data claim tidak ditemukan.");
            }
            
            lkpClaim.Value = null;
            lkpClaim.Text = string.Empty;
            lkpClaim.Focus();
        }

        void tbxDate_EditValueChanged(object sender, EventArgs e)
        {
            transactionPopup.paymentDate = tbxDate.DateTime;
        }

        void lkpTransactional_Leave(object sender, EventArgs e)
        {
            if (lkpTransactional.Value != null)
            {
                //MaxAmount = new TransactionalAccountDataManager().GetTransactionBalanceAgaintsPayment((int)lkpTransactional.Value, CurrentModel.Id > 0 ? (int?)CurrentModel.Id : null);
            }
        }

        private void PrintPreview(object sender, EventArgs e)
        {
            var print = new PaymentInPrint();
            using (var printTool = new ReportPrintTool(print))
            {
                //print.DataSource = GridPayment.DataSource as List<PaymentInDetailModel>;
                var payment = print.Bands["DetailReport"] as DetailReportBand;
                payment.DataSource = GridPayment.DataSource;
                var claim = print.Bands["DetailReport1"] as DetailReportBand;
                claim.DataSource = GridClaim.DataSource;

                print.RequestParameters = false;
                print.Parameters.Add(new Parameter
                {
                    Name = "DateProcess",
                    Value = ((PaymentInModel)CurrentModel).DateProcess,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "CustomerName",
                    Value = ((PaymentInModel)CurrentModel).CustomerName,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Amount",
                    Value = ((PaymentInModel)CurrentModel).Amount,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "PaymentTypeName",
                    Value = new PaymentTypeDataManager().GetFirst<PaymentTypeModel>(WhereTerm.Default((int)((PaymentInModel)CurrentModel).PaymentTypeId, "id")).Name,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Description",
                    Value = ((PaymentInModel)CurrentModel).Description,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "TotalInvoice",
                    Value = ((PaymentInModel)CurrentModel).TotalInvoice,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "TotaClaim",
                    Value = tbxTtlClaim.Value,
                    Visible = false
                });

                var dataSource = GridPayment.DataSource as List<PaymentInDetailModel>;

                print.Parameters.Add(new Parameter
                {
                    Name = "TotalPPh",
                    Value = dataSource.Sum(p => p.TotalPph23),
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Adjustment",
                    Value = ((PaymentInModel)CurrentModel).Adjustment,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Total",
                    Value = ((PaymentInModel)CurrentModel).Total,
                    Visible = false
                });

                print.CreateDocument();
                printTool.PrintingSystem.StartPrint += (o, args) =>
                {
                    args.PrintDocument.PrinterSettings.PrinterName = BaseControl.PrinterSetting.InkJet;
                };
                printTool.ShowPreviewDialog();
            }
        }

        private void Print(object sender, EventArgs e)
        {
            var print = new PaymentInPrint();
            using (var printTool = new ReportPrintTool(print))
            {
                //print.DataSource = GridPayment.DataSource as List<PaymentInDetailModel>;
                var payment = print.Bands["DetailReport"] as DetailReportBand;
                payment.DataSource = GridPayment.DataSource;
                var claim = print.Bands["DetailReport1"] as DetailReportBand;
                claim.DataSource = GridClaim.DataSource;

                print.RequestParameters = false;
                print.Parameters.Add(new Parameter
                {
                    Name = "DateProcess",
                    Value = ((PaymentInModel)CurrentModel).DateProcess,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "CustomerName",
                    Value = ((PaymentInModel)CurrentModel).CustomerName,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Amount",
                    Value = ((PaymentInModel)CurrentModel).Amount,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "PaymentTypeName",
                    Value = new PaymentTypeDataManager().GetFirst<PaymentTypeModel>(WhereTerm.Default((int)((PaymentInModel)CurrentModel).PaymentTypeId, "id")).Name,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Description",
                    Value = ((PaymentInModel)CurrentModel).Description,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "TotalInvoice",
                    Value = ((PaymentInModel)CurrentModel).TotalInvoice,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "TotaClaim",
                    Value = tbxTtlClaim.Value,
                    Visible = false
                });

                var dataSource = GridPayment.DataSource as List<PaymentInDetailModel>;

                print.Parameters.Add(new Parameter
                {
                    Name = "TotalPPh",
                    Value = dataSource.Sum(p => p.TotalPph23),
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Adjustment",
                    Value = ((PaymentInModel)CurrentModel).Adjustment,
                    Visible = false
                });

                print.Parameters.Add(new Parameter
                {
                    Name = "Total",
                    Value = ((PaymentInModel)CurrentModel).Total,
                    Visible = false
                });

                print.CreateDocument();
                printTool.PrintingSystem.StartPrint += (o, args) =>
                {
                    args.PrintDocument.PrinterSettings.PrinterName = BaseControl.PrinterSetting.InkJet;
                };
                printTool.Print();
            }
        }

        private void Changing(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.Name == "clChecked")
            {
                var due = Convert.ToInt32(PaymentView.GetRowCellValue(e.RowHandle, PaymentView.Columns["InvoiceBalance"]));
                if (!(bool)PaymentView.GetRowCellValue(e.RowHandle, PaymentView.Columns["Checked"]))
                {
                    PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["Balance"], 0);
                    PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["Payment"], due);
                    PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["Checked"], true);
                }
                else
                {
                    if ((bool)PaymentView.GetRowCellValue(e.RowHandle, PaymentView.Columns["UsePph23"]))
                    {
                        MessageForm.Info(this, "Information", "Tidak bisa mengubah pembayaran jika invoice sudah menggunakan Pph23.");
                        PaymentView.CancelUpdateCurrentRow();
                        return;
                    }
                    PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["Balance"], due);
                    PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["Payment"], 0);
                    PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["Checked"], false);
                }
            }

            if (e.Column.Name == "clPayment")
            {
                if ((bool)PaymentView.GetRowCellValue(e.RowHandle, PaymentView.Columns["UsePph23"]))
                {
                    PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["Payment"], PaymentView.GetRowCellValue(e.RowHandle, PaymentView.Columns["Payment"]));
                    MessageForm.Info(this, "Information", "Tidak bisa mengubah pembayaran jika invoice sudah menggunakan Pph23.");
                    PaymentView.CancelUpdateCurrentRow();
                    return;
                }
            }

            if (e.Column.Name == "clUsePph23")
            {
                if (!(bool)PaymentView.GetRowCellValue(e.RowHandle, PaymentView.Columns["IsReturn"]) && (decimal) PaymentView.GetRowCellValue(e.RowHandle, PaymentView.Columns["Balance"]) == 0)
                {
                    if ((bool)PaymentView.GetRowCellValue(e.RowHandle, PaymentView.Columns["UsePph23"]))
                    {
                        PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["TotalPph23"], 0);
                        PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["UsePph23"], false);
                    }
                    else
                    {
                        var refNumber = PaymentView.GetRowCellValue(e.RowHandle, PaymentView.Columns["InvoiceRefNumber"]).ToString();
                        var invoice = new SalesInvoiceDataManager().GetFirst<SalesInvoiceModel>(WhereTerm.Default(refNumber, "ref_number", EnumSqlOperator.Equals));
                        decimal beforeTax = 0;
                        decimal totalPph = 0;
                        if (invoice != null)
                        {
                            var shipment = new SalesInvoiceListDataManager().Get<SalesInvoiceListModel>(WhereTerm.Default(invoice.Id, "sales_invoice_id", EnumSqlOperator.Equals));
                            if (shipment.Count() > 0)
                            {
                                beforeTax = (from a in shipment select (!string.IsNullOrEmpty(a.Currency) ? a.TotalTariff * a.CurrencyRate : a.TotalTariff)).Sum();
                                beforeTax -= (from a in shipment select a.Discount).Sum();
                                beforeTax += invoice.RaTotal;

                                var cost = new SalesInvoiceCostDataManager().Get<SalesInvoiceCostModel>(WhereTerm.Default(invoice.Id, "sales_invoice_id", EnumSqlOperator.Equals));
                                if (cost.Count() > 0) beforeTax += (from a in cost select a.Total).Sum();
                                
                                beforeTax += (from a in shipment select a.PackingFee).Sum();
                                beforeTax += (from a in shipment select a.OtherFee).Sum();
                                beforeTax += (from a in shipment select a.InsuranceFee).Sum();
                            }

                            if (invoice.TaxTotal > 0)
                            {
                                totalPph = beforeTax * (decimal)(0.02);
                            }
                            else
                            {
                                totalPph = (beforeTax / 101) * (decimal)(2);
                            }

                            PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["TotalPph23"], Math.Round(totalPph, MidpointRounding.AwayFromZero));
                            PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["UsePph23"], true);
                        }
                        else PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["TotalPph23"], 0);
                    }
                }
                else
                {
                    MessageForm.Info(this, "Information", "Sudah ada pengembalian Pph23 atau invoice belum lunas.");
                    PaymentView.CancelUpdateCurrentRow();
                    return;
                }
            }

            if (e.Column.Name == "clMaterai")
            {
                if (!(bool)PaymentView.GetRowCellValue(e.RowHandle, PaymentView.Columns["UseMaterai"]))
                {
                    if ((decimal)PaymentView.GetRowCellValue(e.RowHandle, PaymentView.Columns["InvoiceTotal"]) > 1000000)
                        PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["MateraiFee"], 6000);
                    else if ((decimal)PaymentView.GetRowCellValue(e.RowHandle, PaymentView.Columns["InvoiceTotal"]) > 250000)
                        PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["MateraiFee"], 3000);
                    else PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["MateraiFee"], 0);

                    PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["UseMaterai"], true);
                }
                else
                {
                    PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["MateraiFee"], 0);
                    PaymentView.SetRowCellValue(e.RowHandle, PaymentView.Columns["UseMaterai"], false);
                }
            }
        }

        public override void New()
        {
            base.New();

            ClearForm();
            ToolbarCode = string.Empty;
            tbxDate.Focus();
            GridPayment.DataSource = null;
            PaymentView.RefreshData();

            tbxRcPercent.ReadOnly = true;
            tbxMcPercent.ReadOnly = true;
            tbxRcTotal.ReadOnly = true;
            tbxMcTotal.ReadOnly = true;
            tbxRcPayment.ReadOnly = true;
            tbxMcPayment.ReadOnly = true;
            tbxTotal.ReadOnly = true;
            tbxTotalInvoice.ReadOnly = true;
            tbxTotalPph.ReadOnly = true;
            tbxMaterai.ReadOnly = true;
            tbxTtlClaim.ReadOnly = true;

            MaxAmount = 0;
            MarketingId = null;
            GridClaim.DataSource = new List<PaymentClaim>();
            DeletedRows = new List<int>();
        }

        public override void Save()
        {
            //if (tbxAmount.Value > MaxAmount)
            //{
            //    MessageBox.Show("Batas total transaksi buku bank adalah Rp " + MaxAmount.ToString("#,#"));
            //    tbxAmount.Focus();
            //    return;
            //}

            if (tbxAmount.Value != Math.Truncate(tbxTotal.Value))
            {
                MessageForm.Info(this, Resources.information, Resources.total_invoice);
                tbxAmount.Focus();
                return;
            }

            DeleteOld = false;

            if (CurrentModel.Id > 0)
            {
                if (((PaymentInModel) CurrentModel).CustomerId != tbxCustomer.Value) DeleteOld = true;
                Code = ((PaymentInModel) CurrentModel).Code;
            }
            else
            {
                if (tbxDate.Text != "") 
                    Code = GetCode("payment", tbxDate.Value);
            }

            base.Save();
        }

        protected override void  SaveDetail(bool isUpdate = false)
        {
            Enabled = false;
            if (DeleteOld)
            {
                new PaymentInDetailDataManager().DeActiveRows(new IListParameter[]
                {
                    WhereTerm.Default(CurrentModel.Id, "payment_id_id", EnumSqlOperator.Equals)
                }, BaseControl.UserLogin);
            }

            // ReSharper disable once InconsistentNaming
            var DetailRepo = new PaymentInDetailDataManager();
            var salesInvoiceRepo = new SalesInvoiceDataManager();
            for (int i = 0; i < PaymentView.RowCount; i++)
            {
                var state = PaymentView.GetRowCellValue(i, PaymentView.Columns["StateChange2"]);

                var detail = new PaymentInDetailModel();

                if (state.ToString().Equals(EnumStateChange.Insert.ToString()))
                {
                    detail.Rowstatus = true;
                    detail.Rowversion = DateTime.Now;
                    detail.PaymentInId = CurrentModel.Id;
                    detail.InvoiceId =
                            (int)PaymentView.GetRowCellValue(i, PaymentView.Columns["InvoiceId"]);
                    detail.InvoiceDate =
                            (DateTime)PaymentView.GetRowCellValue(i, PaymentView.Columns["InvoiceDate"]);
                    detail.InvoiceCode =
                            PaymentView.GetRowCellValue(i, PaymentView.Columns["InvoiceCode"]).ToString();
                    detail.InvoiceTotal =
                            (decimal)PaymentView.GetRowCellValue(i, PaymentView.Columns["InvoiceTotal"]);
                    detail.InvoiceBalance =
                            (decimal)PaymentView.GetRowCellValue(i, PaymentView.Columns["InvoiceBalance"]);
                    detail.Payment =
                            (decimal)PaymentView.GetRowCellValue(i, PaymentView.Columns["Payment"]);
                    detail.DateProcess = DateTime.Now;
                    detail.Balance =
                            (decimal)PaymentView.GetRowCellValue(i, PaymentView.Columns["Balance"]);
                    detail.Checked =
                            (bool)PaymentView.GetRowCellValue(i, PaymentView.Columns["Checked"]);

                    detail.UsePph23 = (bool)PaymentView.GetRowCellValue(i, PaymentView.Columns["UsePph23"]);
                    detail.TotalPph23 = (decimal)PaymentView.GetRowCellValue(i, PaymentView.Columns["TotalPph23"]);

                    if (PaymentView.GetRowCellValue(i, PaymentView.Columns["InvoiceType"]) != null)
                        detail.InvoiceType =
                            PaymentView.GetRowCellValue(i, PaymentView.Columns["InvoiceType"]).ToString();

                    if (PaymentView.GetRowCellValue(i, PaymentView.Columns["InvoiceRefNumber"]) != null)
                        detail.InvoiceRefNumber =
                            PaymentView.GetRowCellValue(i, PaymentView.Columns["InvoiceRefNumber"]).ToString();

                    detail.UseMaterai = (bool)PaymentView.GetRowCellValue(i, PaymentView.Columns["UseMaterai"]);
                    detail.MateraiFee = (decimal)PaymentView.GetRowCellValue(i, PaymentView.Columns["MateraiFee"]);
                    detail.Createdby = BaseControl.UserLogin;
                    detail.Createddate = DateTime.Now;

                    if (detail.Payment > 0) DetailRepo.Save<PaymentInDetailModel>(detail);

                    var salesInvoice = salesInvoiceRepo.GetFirst<SalesInvoiceModel>(WhereTerm.Default((int)detail.InvoiceId, "id", EnumSqlOperator.Equals));
                    salesInvoice.Paid = salesInvoice.TotalPayment >= salesInvoice.Total;
                    salesInvoice.TotalPayment += detail.Payment;
                    salesInvoice.Modifiedby = BaseControl.UserLogin;
                    salesInvoice.Modifieddate = DateTime.Now;
                    //salesInvoice.ModifiedPc = Environment.MachineName;

                    salesInvoiceRepo.Update<ShipmentModel>(salesInvoice);
                }

                if (state.ToString().Equals(EnumStateChange.Update.ToString()))
                {
                    detail = DetailRepo.GetFirst<PaymentInDetailModel>(WhereTerm.Default((int) PaymentView.GetRowCellValue(i, PaymentView.Columns["Id"]), "id", EnumSqlOperator.Equals));
                    detail.Payment =
                            (decimal)PaymentView.GetRowCellValue(i, PaymentView.Columns["Payment"]);
                    detail.DateProcess = DateTime.Now;
                    detail.Balance =
                            (decimal)PaymentView.GetRowCellValue(i, PaymentView.Columns["Balance"]);
                    detail.Checked =
                            (bool)PaymentView.GetRowCellValue(i, PaymentView.Columns["Checked"]);
                    detail.UsePph23 = (bool)PaymentView.GetRowCellValue(i, PaymentView.Columns["UsePph23"]);
                    detail.TotalPph23 = (decimal)PaymentView.GetRowCellValue(i, PaymentView.Columns["TotalPph23"]);

                    detail.UseMaterai = (bool)PaymentView.GetRowCellValue(i, PaymentView.Columns["UseMaterai"]);
                    detail.MateraiFee = (decimal)PaymentView.GetRowCellValue(i, PaymentView.Columns["MateraiFee"]);

                    detail.Modifiedby = BaseControl.UserLogin;
                    detail.Modifieddate = DateTime.Now;

                    if (detail.Payment == 0) detail.Rowstatus = false;

                    DetailRepo.Update<PaymentInDetailModel>(detail);

                    if (detail.InvoiceId != null)
                    {
                        var salesInvoice = salesInvoiceRepo.GetFirst<SalesInvoiceModel>(WhereTerm.Default((int)detail.InvoiceId, "id", EnumSqlOperator.Equals));
                        salesInvoice.Paid = salesInvoice.TotalPayment >= salesInvoice.Total;
                        salesInvoice.TotalPayment += detail.Payment;
                        salesInvoice.Modifiedby = BaseControl.UserLogin;
                        salesInvoice.Modifieddate = DateTime.Now;
                        //salesInvoice.ModifiedPc = Environment.MachineName;

                        salesInvoiceRepo.Update<SalesInvoiceModel>(salesInvoice);
                    }
                }
            }

            for (int i = 0; i < ClaimView.RowCount; i++)
            {
                var state = ClaimView.GetRowCellValue(i, ClaimView.Columns["StateChange"]).ToString();
                if (state.Equals(EnumStateChange.Insert.ToString()))
                {
                    var paymentClaim = new PaymentClaimAdditionalModel();
                    paymentClaim.Rowstatus = true;
                    paymentClaim.Rowversion = DateTime.Now;
                    paymentClaim.PaymentInId = CurrentModel.Id;
                    paymentClaim.ClaimedId = (int)ClaimView.GetRowCellValue(i, ClaimView.Columns["ClaimedId"]);
                    paymentClaim.Payment = (decimal)ClaimView.GetRowCellValue(i, ClaimView.Columns["Payment"]);
                    paymentClaim.Createdby = BaseControl.UserLogin;
                    paymentClaim.Createddate = DateTime.Now;

                    new PaymentClaimAdditionalDataManager().Save<PaymentClaimAdditionalModel>(paymentClaim);
                }

                if (state.Equals(EnumStateChange.Update.ToString()))
                {
                    var id = (int)ClaimView.GetRowCellValue(i, ClaimView.Columns["Id"]);
                    var paymentClaimed = new PaymentClaimAdditionalDataManager().GetFirst<PaymentClaimAdditionalModel>(WhereTerm.Default(id, "id"));
                    if (paymentClaimed != null)
                    {
                        paymentClaimed.Payment = (decimal)ClaimView.GetRowCellValue(i, ClaimView.Columns["Payment"]);
                        paymentClaimed.Modifiedby = BaseControl.UserLogin;
                        paymentClaimed.Modifieddate = DateTime.Now;

                        new PaymentClaimAdditionalDataManager().Update<PaymentClaimAdditionalModel>(paymentClaimed);
                    }
                }
            }

            if(DeletedRows.Count > 0)
            {
                foreach (var d in DeletedRows)
                    new PaymentClaimAdditionalDataManager().DeActive(d, BaseControl.UserLogin, DateTime.Now);
            }

            Enabled = true;
            ToolbarCode = ((PaymentInModel)CurrentModel).Code;
        }

        protected override void AfterSave()
        {
            OpenData(ToolbarCode);
        }

        public override void  AfterDelete()
        {
            var detail = new PaymentInDetailDataManager().Get<PaymentInDetailModel>(WhereTerm.Default(CurrentModel.Id, "payment_in_id", EnumSqlOperator.Equals));
            if (detail != null)
            {
                var repo = new PaymentInDetailDataManager();
                var salesInvoiceRepo = new SalesInvoiceDataManager();
                foreach (PaymentInDetailModel obj in detail)
                {
                    repo.DeActive(obj.Id, BaseControl.UserLogin, DateTime.Now);
                    if (obj.InvoiceId != null)
                    {
                        var salesInvoice = salesInvoiceRepo.GetFirst<SalesInvoiceModel>(WhereTerm.Default((int) obj.InvoiceId, "id", EnumSqlOperator.Equals));
                        if (salesInvoice != null)
                        {
                            salesInvoice.Paid = false;
                            salesInvoice.TotalPayment -= obj.Payment;
                            salesInvoice.Modifiedby = BaseControl.UserLogin;
                            salesInvoice.Modifieddate = DateTime.Now;
                            //salesInvoice.ModifiedPc = Environment.MachineName;

                            salesInvoiceRepo.Update<SalesInvoiceModel>(salesInvoice);
                        }
                    }
                }
            }

            ClearForm();
            GridPayment.DataSource = null;

 	        base.AfterDelete();
        }

        protected override bool ValidateForm()
        {
            if (tbxDate.Text == "")
            {
                tbxDate.Focus();
                return false;
            }

            if (tbxCustomer.Value == null)
            {
                tbxDate.Focus();
                return false;
            }

            if (tbxPayment.Value == null)
            {
                tbxPayment.Focus();
                return false;
            }

            if (tbxAmount.Value == 0)
            {
                tbxAmount.Focus();
                return false;
            }

            //if (lkpAccount.Value == null)
            //{
            //    lkpAccount.Focus();
            //    return false;
            //}

            //if (lkpTransactional.Value == null)
            //{
            //    lkpTransactional.Focus();
            //    return false;
            //}

            return true;
        }

        protected override void PopulateForm(PaymentInModel model)
        {
            ClearForm();

            if (model == null) return;
            MarketingId = null;
            GridClaim.DataSource = new List<PaymentClaim>();

            EnableBtnPrint = true;
            EnableBtnPrintPreview = true;

            MaxAmount = 0;
            DeletedRows = new List<int>();

            tbxDate.Text = model.DateProcess.ToString(CultureInfo.InvariantCulture);
            tbxCustomer.DefaultValue = new IListParameter[] { WhereTerm.Default(model.CustomerId, "id", EnumSqlOperator.Equals) };
            if (model.PaymentTypeId != null)
                tbxPayment.DefaultValue = new IListParameter[] { WhereTerm.Default((int) model.PaymentTypeId, "id", EnumSqlOperator.Equals) };
            
            if (model.TransactionalAccountId > 0)
            {
                var transactionanl = new TransactionalAccountDataManager().GetFirst<TransactionalAccountModel>(WhereTerm.Default(model.TransactionalAccountId, "id"));
                lkpAccount.DefaultValue = new IListParameter[] { WhereTerm.Default(transactionanl.BankAccountId, "id") };
                lkpTransactional.DefaultValue = new IListParameter[] { WhereTerm.Default(transactionanl.Id, "id") };

                MaxAmount = new TransactionalAccountDataManager().GetTransactionBalanceAgaintsPayment(transactionanl.Id, model.Id);
            }
            
            tbxAmount.SetValue(model.Amount.ToString(CultureInfo.InvariantCulture));
            tbxDescription.Text = model.Description;
            tbxRcPercent.SetValue(model.RcPercent.ToString(CultureInfo.InvariantCulture));
            tbxRcFixed.SetValue(model.RcFixed.ToString(CultureInfo.InvariantCulture));
            tbxRcTotal.SetValue(model.RcTotal.ToString(CultureInfo.InvariantCulture));
            tbxRcPayment.SetValue(model.TotalPaymentRc.ToString(CultureInfo.InvariantCulture));
            tbxMcPercent.SetValue(model.McPercent.ToString(CultureInfo.InvariantCulture));
            tbxMcFixed.SetValue(model.McFixed.ToString(CultureInfo.InvariantCulture));
            tbxMcTotal.SetValue(model.McTotal.ToString(CultureInfo.InvariantCulture));
            tbxMcPayment.SetValue(model.TotalPaymentMc.ToString(CultureInfo.InvariantCulture));
            tbxTotalInvoice.SetValue(model.TotalInvoice.ToString(CultureInfo.InvariantCulture));
            tbxAdjustment.SetValue(model.Adjustment.ToString(CultureInfo.InvariantCulture));

            tbxRcPercent.ReadOnly = true;
            tbxMcPercent.ReadOnly = true;
            tbxRcTotal.ReadOnly = true;
            tbxMcTotal.ReadOnly = true;
            tbxRcPayment.ReadOnly = true;
            tbxMcPayment.ReadOnly = true;
            tbxTotal.ReadOnly = true;
            tbxTotalInvoice.ReadOnly = true;
            tbxTotalPph.ReadOnly = true;
            tbxMaterai.ReadOnly = true;
            tbxTtlClaim.ReadOnly = true;

            ToolbarCode = model.Code;

            var detail = new PaymentInDetailDataManager().Get<PaymentInDetailModel>(WhereTerm.Default(model.Id, "payment_in_id", EnumSqlOperator.Equals));
            GridPayment.DataSource = detail;
            PaymentView.RefreshData();

            decimal pph = 0;
            detail.ToList().ForEach(d =>
            {
                d.StateChange2 = EnumStateChange.Select.ToString();
                if (d.UsePph23) pph += (decimal)d.TotalPph23;
            });

            var claims = new ClaimedDataManager().GetClaims(model.Id);
            GridClaim.DataSource = claims;
            ClaimView.RefreshData();

            MarketingId = model.MarketingId;
            tbxTotalPph.SetValue(pph);
            tbxTtlClaim.SetValue(claims.Sum(p => p.Payment));
            tbxMaterai.SetValue(detail.Sum(p => p.MateraiFee));

            tbxTotal.SetValue(model.Total.ToString(CultureInfo.InvariantCulture));
        }

        protected override PaymentInModel PopulateModel(PaymentInModel model)
        {
            model.Code = Code;
            model.DateProcess = tbxDate.Value;
            model.BranchId = BaseControl.BranchId;
            model.PaymentTypeId = tbxPayment.Value;
            model.Description = tbxDescription.Text;

            if (tbxCustomer.Value != null) model.CustomerId = (int) tbxCustomer.Value;
            model.CustomerName = tbxCustomer.Text.Split(new[] { " - " }, StringSplitOptions.None)[1];
            model.Amount = tbxAmount.Value;
            model.TotalInvoice = tbxTotalInvoice.Value;
            model.Total = tbxTotal.Value;
            model.Adjustment = tbxAdjustment.Value;
            model.RcPercent = tbxRcPercent.Value;
            model.RcFixed = tbxRcFixed.Value;
            model.RcTotal = tbxRcTotal.Value;
            model.TotalPaymentRc = tbxRcPayment.Value;
            model.McPercent = tbxMcPercent.Value;
            model.McFixed = tbxMcFixed.Value;
            model.McTotal = tbxMcTotal.Value;
            model.TotalPaymentMc = tbxMcPayment.Value;

            if (lkpTransactional.Value != null)
                model.TransactionalAccountId = (int)lkpTransactional.Value;
            else model.TransactionalAccountId = 0;

            if (MarketingId != null) model.MarketingId = MarketingId;
            if (model.Id == 0) model.CreatedPc = Environment.MachineName;
            else model.ModifiedPc = Environment.MachineName;

            return model;
        }

        protected override PaymentInModel Find(string searchTerm)
        {
            var param = new IListParameter[]
                {
                    WhereTerm.Default(tsBaseTxt_Code.Text, "code", EnumSqlOperator.Equals)
                };
            var obj = DataManager.GetFirst<PaymentInModel>(param);
            PopulateForm(obj);

            return obj;
        }

        public override void Info()
        {
            var model = CurrentModel as PaymentInModel;
            if (model == null) return;
            info.CreatedPc = model.CreatedPc;
            info.ModifiedPc = model.ModifiedPc;

            base.Info();
        }

        protected override void RefreshToolbarState()
        {
            base.RefreshToolbarState();

            var model = CurrentModel as PaymentInModel;
            if ((model != null && model.Id > 0 && (DateTime.Now - model.DateProcess).TotalDays > 3) && BaseControl.RoleId != 2)
            {
                EnabledForm(false);
                
                tsBaseBtn_Save.Enabled = false;
                NavigationMenu.SaveStrip.Enabled = false;
                tsBaseBtn_Delete.Enabled = false;
                NavigationMenu.DeleteStrip.Enabled = false;
            }

            if (model != null && model.Id > 0 && model.Verified)
            {
                EnabledForm(false);
                tsBaseBtn_Delete.Enabled = false;
                tsBaseBtn_Save.Enabled = false;

                AutoClosingMessageBox.Show("Pembayaran sudah di verifikasi Audit");
            }
        }

        private void tbxInvoice_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetInvoice(sender, e);
            }
        }
    }
}