using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Models
{
    [Table("tbl_relatorio_proposta")]
    public class ProposalReport : DomainEntity
    {
        [Key]
        [Column("cod_relat")]
        public long Code { get; set; }

        [Column("nom_relat")]
        [Required]
        public String NaneFile { get; set; }

        [Column("cam_relat")]
        [Required]
        public String Path { get; set; }

    }
}
