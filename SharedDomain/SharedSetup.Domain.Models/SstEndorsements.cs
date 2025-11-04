using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_ENDORSEMENTS")]
	public class SstEndorsements : BaseModel
	{
		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("TYPE")]
		public byte? Type { get; set; }

		[Column("SYSTEM_ID")]
		public long SystemId { get; set; }

		[Column("CLASS_ID")]
		public long? ClassId { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[ForeignKey("ClassId")]
		[InverseProperty("SstEndorsements")]
		public virtual SstClasses Class { get; set; }

		[ForeignKey("SystemId")]
		[InverseProperty("SstEndorsements")]
		public virtual SstSystems System { get; set; }

		[InverseProperty("EndorsementTypeNavigation")]
		public virtual ICollection<SstRelations> SstRelations { get; set; }

		public SstEndorsements()
		{
			SstRelations = new HashSet<SstRelations>();
		}
	}
}
