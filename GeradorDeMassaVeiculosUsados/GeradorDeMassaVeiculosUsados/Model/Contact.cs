using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace App.Domain.Models
{
    [Table("tbl_contato")]
    public class Contact : DomainEntity
    {
        [Key]
        [Column("cod_conta")]
        public long Code { get; set; }

        [Column("nom_conta")]
        public String Name { get; set; }

        public ICollection<SubjectContact> SubjectContacts { get; set; }
    }
}
