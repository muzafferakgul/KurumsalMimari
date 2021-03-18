using DgpaysProject.Core.Repository.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DgpaysProject.Core.Repository.Entity.Acquiring
{
    [Table("MerchantMaster",Schema ="Acquiring")]
    public class MerchantMaster:IEntity
    {
        public long Id { get; set; }
        [StringLength(15)]
        public string MerchantNumber { get; set; }
        [StringLength(50)]
        public string CustomerNumber { get; set; }
        public string MerchantName { get; set; }
        public string TradeName { get; set; }
        public string MerchantType { get; set; }
        public DateTime LastTxnDateTime { get; set; }
        public short CityCode { get; set; }
        public string DistrictCode { get; set; }
        public string MerchantStatus { get; set; }
        public string IpAddress { get; set; }
        public int StatusId { get; set; }
    }
}
