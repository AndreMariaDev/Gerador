using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Models
{
    [Table("tbl_usuario")]
    public class User : DomainEntity
    {
        [Key]
        [Column("cod_usuar_inter")]
        public long Code { get; set; }

        [Column("code_usuar_exter")]
        public String UserCodeExternal { get; set; }

        [Column("nom_usuar")]
        public String Name { get; set; }

        [Column("emai_usuar")]
        public String Email { get; set; }

        [Column("cod_perfi_usuar")]
        public long IDProfile { get; set; }

        public UserProfile UserProfile { get; set; }

    }
}
