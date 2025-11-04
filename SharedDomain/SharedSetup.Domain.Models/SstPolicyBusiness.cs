using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_POLICY_BUSINESS")]
	public class SstPolicyBusiness : BaseModel
	{
		[NotMapped]
		public string SystemName { get; set; }

		[NotMapped]
		public string CategoryName { get; set; }

		[NotMapped]
		public string ClassName { get; set; }

		[NotMapped]
		public string PolicyTypeName { get; set; }

		[NotMapped]
		public string BusinessTypeName { get; set; }

		[Column("SYSTEM_ID")]
		public long SystemId { get; set; }

		[Column("CLASS_ID")]
		public long ClassId { get; set; }

		[Column("POLICY_TYPE")]
		public long PolicyType { get; set; }

		[Column("BUSINESS_TYPE")]
		public long? BusinessType { get; set; }

		[Column("REPORT_CODE")]
		public string ReportCode { get; set; }

		[Column("CATEGORY")]
		public long? Category { get; set; }

		[Column("COMPANY_ID")]
		public long? CompanyId { get; set; }

		[ForeignKey("ClassId")]
		[InverseProperty("SstPolicyBusiness")]
		public virtual SstClasses Class { get; set; }

		[ForeignKey("PolicyType")]
		[InverseProperty("SstPolicyBusiness")]
		public virtual SstPolicyTypes PolicyTypeNavigation { get; set; }
	}
}
