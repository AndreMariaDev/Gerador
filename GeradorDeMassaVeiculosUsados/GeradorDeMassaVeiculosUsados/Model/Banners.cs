using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace App.Domain.Models
{
	[Table("tbl_cadastro_banners")]
	public class Banners : DomainEntity
	{
		[Key]
		[Column("cod_banne")]
		public long Code { get; set; }

		[Column("nom_banne")]
		public String Name { get; set; }

		[Column("nom_titul")]
		public String Title { get; set; }

		[Column("tex_banne")]
		public String Text { get; set; }

		[Column("url_banne")]
		public String URL { get; set; }

		[Column("cod_banne_image")]
		public Guid IDImageBanner { get; set; }

		[Column("jan_banne")]
		public String Window { get; set; }

		[Column("ord_banne")]
		public int Order { get; set; }

	}
}
