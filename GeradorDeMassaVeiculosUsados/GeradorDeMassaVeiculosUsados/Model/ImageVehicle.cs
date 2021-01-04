using App.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace App.Domain.Models
{
    [Table("tbl_imagem_veiculo")]
    public class ImageVehicle : DomainEntity, IEntityImage
    {
        [Key]
        [Column("cod_image")]
        public long Code { get; set; }

        [Column("pat_image")]
        public String Path { get; set; }
    }
}
