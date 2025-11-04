using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedSetup.Domain.Common
{
	public class BaseModel
	{
		[Column("ID")]
		public long Id { get; set; }

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
