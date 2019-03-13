using Devenlab.Common.Interfaces;
using System;
using System.Collections.Generic;

namespace SISCO.Models
{
    public class TransactionalAccountModel : IBaseModel
    {
        public int Id { get; set; }
        public bool Rowstatus { get; set; }
        public DateTime Rowversion { get; set; }
        public int BankAccountId { get; set; }
        public DateTime DateProcess { get; set; }
        public string Description { get; set; }
        public Decimal DebitTotalAmount { get; set; }
        public Decimal CreditTotalAmount { get; set; }
        public Decimal Balance { get; set; }
        public string ClosedBy { get; set; }
        public DateTime? ClosedDate { get; set; }
        public DateTime Createddate { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }
        public Devenlab.Common.EnumStateChange StateChange { get; set; }
    }

    public class BankTransactionModel
    {
        public int Id { get; set; }
        public int RowNum { get; set; }
        public DateTime DateProcess { get; set; }
        public string Description { get; set; }
        public Decimal DebitTotalAmount { get; set; }
        public Decimal CreditTotalAmount { get; set; }
        public Decimal Balance { get; set; }
        public bool IsModify { get; set; }
        public string StateChange { get; set; }
    }

    public class BankBalance
    {
        public decimal Balance { get; set; }
    }

    public class TransactionLookup
    {
        public int Id { get; set; }
        public DateTime DateProcess { get; set; }
        public string Description { get; set; }
        public Decimal Total { get; set; }
    }

    public class TransactionJournal
    {
        public int? Id { get; set; }
        public DateTime TransactionAccountDate { get; set; }
        public string Description { get; set; }
        public int? TransactionId { get; set; }
        public string TransactionCode { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string TransactionDescription { get; set; }
        public string TransactionType { get; set; }
        public Decimal Debit { get; set; }
        public Decimal Credit { get; set; }
        public Decimal Balance { get; set; }
        public decimal? TotalClaimed { get; set; }
        public string LetterNo { get; set; }
        public decimal? TotalPph { get; set; }
        public decimal? MateraiFee { get; set; }
        public DateTime? ClosedDate { get; set; }
    }

    public class TransactionJournalMaster
    {
        public int Id { get; set; }
        public DateTime TransactionAccountDate { get; set; }
        public string Description { get; set; }
        public Decimal Debit { get; set; }
        public Decimal Credit { get; set; }
        public Decimal Balance { get; set; }
        public DateTime? ClosedDate { get; set; }
        public List<TransactionJournalDetail> Details { get; set; }
    }

    public class TransactionJournalDetail
    {
        public string TransactionCode { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public Decimal Amount { get; set; }
        public decimal? Adjustment { get; set; }
        public decimal? TotalClaimed { get; set; }
        public string LetterNo { get; set; }
        public List<TransactionInvoiceList> Lists { get; set; }
    }

    public class TransactionInvoiceList
    {
        public string InvoiceNo { get; set; }
        public decimal? TotalPph { get; set; }
        public decimal? MateraiFee { get; set; }
        public decimal Total { get; set; }
    }

    public class TransactionJournalReport
    {
        public int Id { get; set; }
        public string AccountNo { get; set; }
        public DateTime TransactionAccountDate { get; set; }
        public string Description { get; set; }
        public string TransactionCode { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string TransactionDescription { get; set; }
        public Decimal Debit { get; set; }
        public Decimal Credit { get; set; }
        public Decimal Balance { get; set; }
        public DateTime? ClosedDate { get; set; }
    }

    public class TransactionalJournalUnposted
    {
        public string AccountNo { get; set; }
        public string BankName { get; set; }
        public string DateProcess { get; set; }
        public string Description { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal Balance { get; set; }
    }
}