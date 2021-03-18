using DgpaysProject.Core.Repository.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DgpaysProject.Core.Repository.Entity.Issuing
{
    [Table("Customer", Schema = "Issuing")]
    public class Customer:IEntity
    {
        public long Id { get; set; }
        [StringLength(50)]
        public string CustomerNumber { get; set; }
        [StringLength(1)]
        public string CustomerStatus { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Surname { get; set; }
        [StringLength(100)]
        public string FirmName { get; set; }
        public int TaxOffice { get; set; }
        [StringLength(11)]
        public string TaxNo { get; set; }
        [StringLength(20)]
        public string CitizenshipNumber { get; set; }
        public DateTime BirthDate { get; set; }
        [StringLength(50)]
        public string FatherName { get; set; }
        [StringLength(50)]
        public string MotherName { get; set; }
        public int StatusId { get; set; }

    }
}
