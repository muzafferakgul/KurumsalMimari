using DgpaysProject.Core.Repository.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DgpaysProject.Core.Repository.Entity.Issuing
{
    [Table("Card", Schema = "Issuing")]
    public class Card:IEntity
    {
        public long Id { get; set; }
        public long CardTypeId { get; set; }
        [StringLength(10)]
        public string AccountNumber { get; set; }
        [StringLength(50)]
        public string CustomerNumber { get; set; }
        [StringLength(19)]
        public string CardNumber { get; set; }
        public DateTime ValidFromDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public long Balance { get; set; }
        [StringLength(100)]
        public string CardHolderName { get; set; }
        public DateTime LastTransactionDate { get; set; }
        public virtual  CardType CardType { get; set; }

    }
}
