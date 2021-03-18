using DgpaysProject.Core.Repository.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DgpaysProject.Core.Repository.Entity.Issuing
{
    [Table("CustomerEmail", Schema = "Issuing")]
    public class CustomerEmail:IEntity
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        [StringLength(50)]
        public string CustomerNumber { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        public int StatusId { get; set; }
        public virtual Customer Customer { get; set; }

    }
}
