using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Models
{
    [Table("tbl_proposta_veiculo")]
    public class VehicleProposal : DomainEntity
    {
        [Key]
        [Column("cod_propo")]
        public long Code { get; set; }

        [Column("cod_bem")]
        [Required]
        public long CodeAssets { get; set; }

        [Column("tip_bem")]
        [Required]
        public long TypeAssets { get; set; }

        [Column("nom_clien")]
        [Required]
        public String Name { get; set; }

        [Column("ema_clien")]
        [Required]
        public String Email { get; set; }

        [Column("tel_clien")]
        [Required]
        public String Phone { get; set; }

        [Column("cod_usuar_clien")]
        public String UserCodeClient { get; set; }

        [Column("pro_valor")]
        [Required]
        public String ProposalValue { get; set; }

        [Column("pro_valor_moed")]
        [Required]
        public decimal ProposalValueCoin { get; set; }

        [Column("outra_infor")]
        public String OtherInformation { get; set; }

        [Column("cod_veicu")]
        public long CodeVehicle { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
