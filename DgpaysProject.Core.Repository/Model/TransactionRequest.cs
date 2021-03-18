using DgpaysProject.Core.Repository.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace DgpaysProjectUI.Core.Repository.Model
{
    public class TransactionRequest : RequestBase
    {
        [Required(ErrorMessage ="TxnType not null")]
        public long TxnType { get; set; }
        public long MainTransactionId { get; set; }
        public long Amount { get; set; }
        [Required(ErrorMessage ="CardNumber not null")]
        public string CardNumber { get; set; }
        [StringLength(4)]
        public DateTime? ExpiryDate { get; set; }//string olmalı 4 karakter olmalı
        [Required(ErrorMessage = "TerminalId not null")]
        public string TerminalId { get; set; }
        [Required(ErrorMessage = "MerchantId not null")]
        public string MerchantId { get; set; }
    }
}
