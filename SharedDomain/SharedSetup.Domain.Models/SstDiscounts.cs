using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_DISCOUNTS")]
	public class SstDiscounts : BaseModel
	{
		[NotMapped]
		public string InsuranceSystemName { get; set; }

		[NotMapped]
		public string BranchName { get; set; }

		[NotMapped]
		public string TypeName { get; set; }

		[NotMapped]
		public string ApplyOnName { get; set; }

		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("ORDER")]
		public byte? Order { get; set; }

		[Column("SYSTEM_ID")]
		public long SystemId { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[Column("BRANCH_ID")]
		public long? BranchId { get; set; }

		[Column("SOURCE")]
		public byte? Source { get; set; }

		[Column("TYPE")]
		public byte? Type { get; set; }

		[Column("APPLY_ON")]
		public byte? ApplyOn { get; set; }

		[ForeignKey("SystemId")]
		[InverseProperty("SstDiscounts")]
		public virtual SstSystems System { get; set; }

		[InverseProperty("Discount")]
		public virtual ICollection<SstClaimDiscounts> SstClaimDiscounts { get; set; }

		[InverseProperty("Discount")]
		public virtual ICollection<SstDiscountsFactorsQuery> SstDiscountsFactorsQuery { get; set; }

		[InverseProperty("Discount")]
		public virtual ICollection<SstPolicyDiscounts> SstPolicyDiscounts { get; set; }

		public SstDiscounts()
		{
			SstClaimDiscounts = new HashSet<SstClaimDiscounts>();
			SstDiscountsFactorsQuery = new HashSet<SstDiscountsFactorsQuery>();
			SstPolicyDiscounts = new HashSet<SstPolicyDiscounts>();
		}
	}
}
