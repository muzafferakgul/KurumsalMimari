using DgpaysProject.Core.Repository.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DgpaysProject.Core.Repository.Entity.Transaction
{
    [Table("TransactionDecline", Schema = "txn")]
    public class TransactionDecline:IEntity
    {
        public long Id { get; set; }
        [StringLength(19)]
        public string CardNumber { get; set; }
        public long TxnId { get; set; }
        [StringLength(50)]
        public string TerminalNumber { get; set; }
        [StringLength(15)]
        public string MerchantNumber { get; set; }
        public long Amount { get; set; }
        public long TxnType { get; set; }
        public long BatchId { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseDesc { get; set; }
        public string Request { get; set; }
        public int StatusId { get; set; }

    }
}
