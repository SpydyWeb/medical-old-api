using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_INDUSTRY_SECTORS")]
	public class SstIndustrySectors : BaseModel
	{
		[NotMapped]
		public string IndustryName { get; set; }

		[Required]
		[Column("CODE")]
		public string Code { get; set; }

		[Column("ABBREVIATION")]
		public string Abbreviation { get; set; }

		[Required]
		[Column("SEGMENT_CODE")]
		public string SegmentCode { get; set; }

		[Column("INDUSTRY")]
		public long Industry { get; set; }

		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("NOTES")]
		public string Notes { get; set; }

		[Column("SECTOR_ID")]
		public long? SectorId { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[ForeignKey("SectorId")]
		[InverseProperty("InverseSector")]
		public virtual SstIndustrySectors Sector { get; set; }

		[InverseProperty("Sector")]
		public virtual ICollection<SstIndustrySectors> InverseSector { get; set; }

		public SstIndustrySectors()
		{
			InverseSector = new HashSet<SstIndustrySectors>();
		}
	}
}
