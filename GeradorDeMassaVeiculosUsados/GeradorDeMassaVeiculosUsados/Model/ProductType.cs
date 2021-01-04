using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Models
{
    [Table("tbl_tipo")]
    public class ProductType : DomainEntity
    {
        [Key]
        [Column("cod_tipo")]
        public long Code { get; set; }
        [Column("nom_tipo")]
        public String Name { get; set; }
    }
}
