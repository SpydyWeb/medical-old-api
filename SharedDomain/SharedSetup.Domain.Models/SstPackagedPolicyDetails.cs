using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_PACKAGED_POLICY_DETAILS")]
	public class SstPackagedPolicyDetails : BaseModel
	{
		[NotMapped]
		public string InsuranceClassName { get; set; }

		[NotMapped]
		public string PolicyTypeName { get; set; }

		[NotMapped]
		public List<long> PolicyTypeList { get; set; }

		[Column("PACKAGED_ID")]
		public long? PackagedId { get; set; }

		[Column("CLASS_ID")]
		public long? ClassId { get; set; }

		[Column("POLICY_TYPE")]
		public long? PolicyType { get; set; }

		[ForeignKey("ClassId")]
		[InverseProperty("SstPackagedPolicyDetails")]
		public virtual SstClasses Class { get; set; }

		[ForeignKey("PackagedId")]
		[InverseProperty("SstPackagedPolicyDetails")]
		public virtual SstPackagedPolicy Packaged { get; set; }

		[ForeignKey("PolicyType")]
		[InverseProperty("SstPackagedPolicyDetails")]
		public virtual SstPolicyTypes PolicyTypeNavigation { get; set; }
	}
}
