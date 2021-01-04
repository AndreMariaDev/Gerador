using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Models
{
    [Table("tbl_faq")]
    public class Faq : DomainEntity
    {
        [Key]
        [Column("cod_faq")]
        public long Code { get; set; }

        [Column("per_faq")]
        public string Question { get; set; }

        [Column("res_faq")]
        public string Answer { get; set; }

        [Column("ord_faq")]
        public int Order { get; set; }
    }
}
