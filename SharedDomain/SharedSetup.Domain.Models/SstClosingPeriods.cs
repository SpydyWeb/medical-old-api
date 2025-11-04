using System;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_CLOSING_PERIODS")]
	public class SstClosingPeriods : BaseModel
	{
		[NotMapped]
		public string InsuranceSystemName { get; set; }

		[NotMapped]
		public string InsuranceClassName { get; set; }

		[NotMapped]
		public string PolicyTypeName { get; set; }

		[NotMapped]
		public string BranchName { get; set; }

		[NotMapped]
		public string ModuleName { get; set; }

		[Column("SYSTEM_ID")]
		public long? SystemId { get; set; }

		[Column("CLASS_ID")]
		public long? ClassId { get; set; }

		[Column("POLICY_TYPE")]
		public long? PolicyType { get; set; }

		[Column("MODULE_CODE")]
		public string ModuleCode { get; set; }

		[Column("BRANCH_ID")]
		public long? BranchId { get; set; }

		[Column("CLOSING_DATE")]
		public DateTime? ClosingDate { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[Column("FROM_DATE")]
		public DateTime? FromDate { get; set; }

		[ForeignKey("ClassId")]
		[InverseProperty("SstClosingPeriods")]
		public virtual SstClasses Class { get; set; }

		[ForeignKey("PolicyType")]
		[InverseProperty("SstClosingPeriods")]
		public virtual SstPolicyTypes PolicyTypeNavigation { get; set; }

		[ForeignKey("SystemId")]
		[InverseProperty("SstClosingPeriods")]
		public virtual SstSystems System { get; set; }
	}
}
