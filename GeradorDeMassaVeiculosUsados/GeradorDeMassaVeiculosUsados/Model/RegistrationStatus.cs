using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace App.Domain.Models
{
    [Table("tbl_status_registro")]
    public class RegistrationStatus : DomainEntity
    {
        [Key]
        [Column("cod_status")]
        public long Code { get; set; }
        [Column("nom_statu")]
        public String Name { get; set; }
    }
}
