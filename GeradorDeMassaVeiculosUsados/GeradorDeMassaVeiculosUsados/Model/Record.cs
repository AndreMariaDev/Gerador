using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace App.Domain.Models
{
    [Table("tbl_ficha")]
    public class Record : DomainEntity
    {
        [Key]
        [Column("cod_ficha")]
        public long Code { get; set; }
        [Column("cor_ficha")]
        public string Color { get; set; }
        [Column("cabine_ficha")]
        public string Cabin { get; set; }
        [Column("poten_ficha")]
        public string Wattage { get; set; }
        [Column("legis_emiss")]
        public string EmissionsLegislation { get; set; }
        [Column("carga_util")]
        public string UsefulLoad { get; set; }
        [Column("direc_ficha")]
        public string Direction { get; set; }
        [Column("dista_entre_eixos")]
        public string LengthBetweenAxis { get; set; }
        [Column("propr_anter")]
        public string PreviousOwners { get; set; }
        [Column("local__ficha")]
        public string Location { get; set; }
        [Column("dimen_ficha")]
        public string Dimensions { get; set; }
        [Column("peso_bruto")]
        public string GrossWeight { get; set; }
        [Column("tipo_suspen")]
        public string TypeSuspension { get; set; }
        [Column("cilin_ficha")]
        public string Cylinder { get; set; }
        [Column("trans_ficha")]
        public string Streaming { get; set; }
        [Column("peso_ficha")]
        public string Weight { get; set; }

        [Column("cod_veicu")]
        public long CodeVehicle { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
