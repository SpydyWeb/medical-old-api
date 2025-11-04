using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_SEGMENTS")]
	public class SstSegments : BaseModel
	{
		[NotMapped]
		public string BranchName { get; set; }

		[NotMapped]
		public string InsuranceClassName { get; set; }

		[NotMapped]
		public string InsuranceSystemName { get; set; }

		[NotMapped]
		public string PolicyTypeName { get; set; }

		[NotMapped]
		public string SegmentTypeName { get; set; }

		[NotMapped]
		public string BusinessChannelName { get; set; }

		[NotMapped]
		public string BusinessTypeName { get; set; }

		[NotMapped]
		public string SegmentStructurePattern { get; set; }

		[Column("BRANCH")]
		public long? Branch { get; set; }

		[Column("SYSTEM_ID")]
		public long SystemId { get; set; }

		[Column("CLASS_ID")]
		public long? ClassId { get; set; }

		[Column("POLICY_TYPE")]
		public long? PolicyType { get; set; }

		[Column("BUSINESS_TYPE")]
		public byte? BusinessType { get; set; }

		[Column("BUSINESS_CHANNEL")]
		public long? BusinessChannel { get; set; }

		[Column("SEGMENT_TYPE")]
		public byte? SegmentType { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[ForeignKey("BusinessChannel")]
		[InverseProperty("SstSegments")]
		public virtual SstBusinessChannels BusinessChannelNavigation { get; set; }

		[ForeignKey("ClassId")]
		[InverseProperty("SstSegments")]
		public virtual SstClasses Class { get; set; }

		[ForeignKey("PolicyType")]
		[InverseProperty("SstSegments")]
		public virtual SstPolicyTypes PolicyTypeNavigation { get; set; }

		[ForeignKey("SystemId")]
		[InverseProperty("SstSegments")]
		public virtual SstSystems System { get; set; }

		[InverseProperty("Segment")]
		public virtual ICollection<SstSegmentsStructures> SstSegmentsStructures { get; set; }

		public SstSegments()
		{
			SstSegmentsStructures = new HashSet<SstSegmentsStructures>();
		}
	}
}
