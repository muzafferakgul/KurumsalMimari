using DgpaysProject.Core.Repository.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DgpaysProject.Core.Repository.Entity.Issuing
{
    [Table("CustomerAddress",Schema ="Issuing")]
    public class CustomerAddress:IEntity
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        [StringLength(50)]
        public string CustomerNumber { get; set; }
        public short CountryCode { get; set; }
        public short CityCode { get; set; }
        [StringLength(30)]
        public string City { get; set; }
        public short TownCode { get; set; }
        [StringLength(50)]
        public string Town { get; set; }
        [StringLength(30)]
        public string District { get; set; }
        [StringLength(30)]
        public string Street { get; set; }
        [StringLength(30)]
        public string Number { get; set; }
        [StringLength(30)]
        public string Floor { get; set; }
        [StringLength(30)]
        public string Circle { get; set; }
        [StringLength(30)]
        public string PostalCode { get; set; }
        [StringLength(250)]
        public string AddressDetail { get; set; }
        public bool IsMainAddress { get; set; }
        public int StatusId { get; set; }
        public virtual Customer Customer { get; set; }
}
}
