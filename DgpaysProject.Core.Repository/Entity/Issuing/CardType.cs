using DgpaysProject.Core.Repository.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DgpaysProject.Core.Repository.Entity.Issuing
{
    [Table("CardType", Schema = "Issuing")]
    public class CardType:IEntity
    {
        public long Id { get; set; }
        [StringLength(100)]
        public string TypeName { get; set; }
    }
}
