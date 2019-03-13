using SISCO.App.Finance;
using SISCO.App.MasterData;
using SISCO.Models;
using SISCO.Presentation.Common;
using SISCO.Presentation.Common.Forms;
using SISCO.Presentation.MasterData.Popup;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Data;
using DevExpress.XtraGrid.Views.Grid;
using Devenlab.Common.WinControl.MessageBox;
using Devenlab.Common;

namespace SISCO.Presentation.Finance.Forms
{
    public partial class ClosingBankTransactionForm : BaseForm
    {
        public ClosingBankTransactionForm()
        {
            InitializeComponent();
            form = this;

            Load += ClosingBankTransactionForm_Load;
        }

        void ClosingBankTransactionForm_Load(object sender, EventArgs e)
        {
            lkpAccount.LookupPopup = new BankAccountPopup();
            lkpAccount.AutoCompleteDataManager = new BankAccountDataManager();
            lkpAccount.AutoCompleteDisplayFormater = model => ((BankAccountModel)model).AccountNo + " " + ((BankAccountModel)model).BankName;
            lkpAccount.AutoCompleteWhereExpression +=
                (s, param) => param.SetWhereExpression("account_no.StartsWith(@0) and branch_id = @1", s, BaseControl.BranchId);

            btnFilter.Click += btnFilter_Click;
            btnVerify.Click += btnVerify_Click;
            cbxVerified.CheckedChanged += cbxVerified_CheckedChanged;
        }

        void cbxVerified_CheckedChanged(object sender, EventArgs e)
        {
            GridJournals.DataSource = null;
        }

        void btnVerify_Click(object sender, EventArgs e)
        {
            var rowhandle = JournalView.FocusedRowHandle;
            if (!cbxVerified.Checked)
            {
                if ((decimal)JournalView.GetRowCellValue(rowhandle, JournalView.Columns["Balance"]) > 0)
                {
                    if (MessageForm.Ask(form, "Verifikasi", string.Format("Setelah verifikasi, transaksi ini tidak dapat digunakan kembali. Masih ada sisa Rp {0}. Apa anda yakin akan melakukan verifikasi dengan mengabaikan sisa transaksi yang ada?", (decimal)JournalView.GetRowCellValue(rowhandle, JournalView.Columns["Balance"]))) == DialogResult.Yes)
                        Verification(rowhandle);
                }
                else
                {
                    if (MessageForm.Ask(form, "Verifikasi", "Setelah verifikasi, transaksi ini tidak dapat digunakan kembali. Apa anda yakin akan melakukan verifikasi transaksi ini?") == DialogResult.Yes)
                        Verification(rowhandle);
                }
            }
            else
            {
                if (MessageForm.Ask(form, "Verifikasi", "Apa anda yakin akan melakukan pembatalan verifikasi?") == DialogResult.Yes)
                    Verification(rowhandle);
            }
        }

        void Verification(int rowHandle)
        {
            var id = (int)JournalView.GetRowCellValue(rowHandle, JournalView.Columns["Id"]);
            if (!cbxVerified.Checked)
                new TransactionalAccountDataManager().Closing(id, BaseControl.UserLogin);
            else
                new TransactionalAccountDataManager().Cancellation(id, BaseControl.UserLogin);

            JournalView.DeleteSelectedRows();
        }

        void btnFilter_Click(object sender, EventArgs e)
        {
            btnVerify.Buttons[0].Caption = cbxVerified.Checked ? "Cancel" : "Verify";
            RefreshGrid();
        }

        List<TransactionJournal> transactionJournals { get; set; }

        void RefreshGrid()
        {
            if (lkpAccount.Value != null)
            {
                if (!cbxVerified.Checked)
                    transactionJournals = new TransactionalAccountDataManager().GetTransactionJournal((int)lkpAccount.Value, tbxFrom.DateTime, tbxTo.DateTime, true);
                else
                    transactionJournals = new TransactionalAccountDataManager().GetTransactionJournalVerified((int)lkpAccount.Value, tbxFrom.DateTime, tbxTo.DateTime);

                var master = new List<TransactionJournalMaster>();

                var rowhandle = 0;
                var listRows = new List<int>();
                foreach (var t in transactionJournals.Where(p => p.Id != null).OrderBy(p => p.TransactionAccountDate).ToList())
                {
                    var row = new TransactionJournalMaster
                    {
                        Id = (int)t.Id,
                        TransactionAccountDate = t.TransactionAccountDate,
                        Description = t.Description,
                        Debit = t.Debit,
                        Credit = t.Credit,
                        Balance = t.Balance,
                        Details = new List<TransactionJournalDetail>()
                    };

                    var details = transactionJournals.Where(p => p.TransactionId == t.Id).ToList();
                    if (details.Count() > 0)
                    {
                        var invoices = details.Where(p => p.TransactionType == "Invoice").ToList();
                        if (invoices.Count() > 0)
                        {
                            var transactionCode = string.Empty;
                            foreach (var i in invoices)
                            {
                                if (transactionCode != i.TransactionCode)
                                {
                                    var r = new TransactionJournalDetail
                                    {
                                        TransactionCode = i.TransactionCode,
                                        TransactionDate = (DateTime)i.TransactionDate,
                                        Description = i.Description,
                                        Amount = i.Credit,
                                        Adjustment = i.Debit,
                                        TotalClaimed = i.TotalClaimed,
                                        LetterNo = i.LetterNo,
                                        Lists = new List<TransactionInvoiceList>()
                                    };

                                    var invoiceDetails = invoices.Where(p => p.TransactionCode == i.TransactionCode).ToList();
                                    if (invoiceDetails.Count() > 0)
                                    {
                                        foreach (var id in invoiceDetails)
                                        {
                                            r.Lists.Add(new TransactionInvoiceList
                                            {
                                                InvoiceNo = id.TransactionDescription,
                                                Total = id.Balance,
                                                TotalPph = id.TotalPph,
                                                MateraiFee = id.MateraiFee
                                            });
                                        }
                                    }

                                    row.Details.Add(r);
                                    transactionCode = i.TransactionCode;
                                }
                            }
                        }

                        var others = details.Where(p => p.TransactionType == "Other").ToList();
                        if (others.Count() > 0)
                        {
                            var r = new TransactionJournalDetail
                            {
                                TransactionCode = others[0].TransactionCode,
                                TransactionDate = (DateTime)others[0].TransactionDate,
                                Description = others[0].Description,
                                Amount = others[0].Credit,
                                Adjustment = others[0].Debit,
                                TotalClaimed = others[0].TotalClaimed,
                                LetterNo = others[0].LetterNo,
                                Lists = new List<TransactionInvoiceList>()
                            };

                            foreach (var o in others)
                            {
                                r.Lists.Add(new TransactionInvoiceList
                                {
                                    InvoiceNo = o.TransactionDescription,
                                    Total = o.Balance,
                                    TotalPph = o.TotalPph,
                                    MateraiFee = o.MateraiFee
                                });
                            }

                            row.Details.Add(r);
                        }

                        foreach (var d in details.Where(p => p.TransactionType == "TA" || p.TransactionType == "Counter" || p.TransactionType == "Collect" || p.TransactionType == "Cost").ToList())
                        {
                            if (d.TransactionType == "Counter")
                            {
                                row.Details.Add(new TransactionJournalDetail
                                {
                                    TransactionCode = d.TransactionCode,
                                    TransactionDate = (DateTime)d.TransactionDate,
                                    Description = d.Description,
                                    Amount = d.Credit,
                                    Adjustment = d.Debit,
                                    TotalClaimed = d.TotalClaimed,
                                    LetterNo = d.LetterNo,
                                    Lists = new List<TransactionInvoiceList>()
                                });
                            } 
                            else
                            row.Details.Add(new TransactionJournalDetail
                            {
                                TransactionCode = d.TransactionCode,
                                TransactionDate = (DateTime)d.TransactionDate,
                                Amount = d.Credit,
                                Lists = new List<TransactionInvoiceList>()
                            });
                        }

                        listRows.Add(rowhandle);
                    }

                    row.Details = row.Details.OrderBy(p => p.TransactionDate).ToList();
                    rowhandle++;
                    master.Add(row);
                }

                GridJournals.DataSource = master;
                JournalView.RefreshData();

                foreach (var r in listRows)
                    JournalView.ExpandMasterRow(r);
            }
            else lkpAccount.Focus();
        }
    }
}