using DgpaysProject.Core.Repository.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DgpaysProject.Core.Repository.Entity.Acquiring
{
    [Table("TerminalMaster", Schema = "Acquiring")]
    public class TerminalMaster:IEntity
    {
        public long Id { get; set; }
        public long MerchantId { get; set; }
        [StringLength(50)]
        public string TerminalNumber { get; set; }
        [StringLength(15)]
        public string MerchantNumber { get; set; }
        [StringLength(1)]
        public string TerminalStatus { get; set; }
        [StringLength(10)]
        public string TerminalType { get; set; }
        [StringLength(200)]
        public string TerminalName { get; set; }
        [StringLength(20)]
        public string IpAddress { get; set; }
        public DateTime LastTransactionDate { get; set; }
        [StringLength(50)]
        public string MacAddress { get; set; }
        public int StatusId { get; set; }
        
    }
}
