using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_VALUES_RELATION")]
	public class SstValuesRelation : BaseModel
	{
		[Column("RELATION_TYPE")]
		public byte RelationType { get; set; }

		[Column("SYSTEM_ID")]
		public long SystemId { get; set; }

		[Required]
		[Column("MAJOR_VALUE")]
		public string MajorValue { get; set; }

		[Required]
		[Column("MINOR_VALUE")]
		public string MinorValue { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[ForeignKey("SystemId")]
		[InverseProperty("SstValuesRelation")]
		public virtual SstSystems System { get; set; }
	}
}
