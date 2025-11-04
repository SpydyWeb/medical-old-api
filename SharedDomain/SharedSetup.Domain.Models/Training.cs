using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedSetup.Domain.Models
{
	[Table("TRAINING")]
	public class Training
	{
		[Column("ID")]
		public long Id { get; set; }

		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("AGE")]
		public short Age { get; set; }

		[Column("GENDER")]
		public short? Gender { get; set; }

		[Column("BIRTH_DATE")]
		public DateTime BirthDate { get; set; }

		[Required]
		[Column("CREATION_USER")]
		public string CreationUser { get; set; }

		[Column("CREATION_DATE")]
		public DateTime CreationDate { get; set; }

		[Column("MODIFICATION_USER")]
		public string ModificationUser { get; set; }

		[Column("MODIFICATION_DATE")]
		public DateTime? ModificationDate { get; set; }
	}
}
