using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_DATA_SECURITY")]
	public class SstDataSecurity : BaseModel
	{
		[NotMapped]
		public string InsuranceClassName { get; set; }

		[NotMapped]
		public string PolicyTypeName { get; set; }

		[NotMapped]
		public string ProductName { get; set; }

		[NotMapped]
		public string SecurityGroupName { get; set; }

		[NotMapped]
		public string SecurityUserName { get; set; }

		[Column("CLASS_ID")]
		public long ClassId { get; set; }

		[Column("POLICY_TYPE")]
		public long PolicyType { get; set; }

		[Column("PRODUCT_ID")]
		public long? ProductId { get; set; }

		[Column("GROUP_ID")]
		public long GroupId { get; set; }

		[Column("USERNAME")]
		public string Username { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[ForeignKey("ClassId")]
		[InverseProperty("SstDataSecurity")]
		public virtual SstClasses Class { get; set; }

		[ForeignKey("PolicyType")]
		[InverseProperty("SstDataSecurity")]
		public virtual SstPolicyTypes PolicyTypeNavigation { get; set; }

		[ForeignKey("ProductId")]
		[InverseProperty("SstDataSecurity")]
		public virtual SstPackagedPolicy Product { get; set; }
	}
}
