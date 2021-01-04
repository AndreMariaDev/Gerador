using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace App.Domain.Models
{

	[Table("tbl_assunto_contato")]
	public class SubjectContact : DomainEntity
    {
		[Key]
		[Column("cod_assun_conta")]
		public long Code { get; set; }

		[Column("cod_conta")]
		public long ContactCode { get; set; }

		public Contact Contact { get; set; }

		[Column("ass_conta")]
		public string Subject { get; set; }

		[Column("non_assun")]
		public string Name { get; set; }

		[Column("ema_assun")]
		public string Email { get; set; }

		[Column("tel_assun")]
		public string Phone { get; set; }

		[Column("men_assun")]
		public string Message { get; set; }
	}
}
