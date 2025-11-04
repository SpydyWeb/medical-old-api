using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_RESOURCES")]
	public class SstResources : BaseModel
	{
		[Required]
		[Column("OBJECT")]
		public string Object { get; set; }

		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Required]
		[Column("VALUE")]
		public string Value { get; set; }

		[Required]
		[Column("LANGUAGE")]
		public string Language { get; set; }

		[Column("SYSTEM_ID")]
		public long SystemId { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[ForeignKey("SystemId")]
		[InverseProperty("SstResources")]
		public virtual SstSystems System { get; set; }
	}
}
