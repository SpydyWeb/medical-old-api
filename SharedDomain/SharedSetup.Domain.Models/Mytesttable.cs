using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedSetup.Domain.Models
{
	[Table("MYTESTTABLE")]
	public class Mytesttable
	{
		[Column("ID")]
		public decimal Id { get; set; }

		[Column("NAME")]
		public string Name { get; set; }

		[Column("SSN")]
		public string Ssn { get; set; }

		[Column("GENDER")]
		public decimal? Gender { get; set; }

		[Column("STATUS")]
		public decimal? Status { get; set; }

		[Column("BIRTHDATE")]
		public DateTime? Birthdate { get; set; }
	}
}
