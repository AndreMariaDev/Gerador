using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace App.Domain.Models
{
    [Table("tbl_perfil_usuario")]
    public class UserProfile : DomainEntity
    {
        [Key]
        [Column("cod_usuar_inter")]
        public long Code { get; set; }

        [Column("nom_prof")]
        public String Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
