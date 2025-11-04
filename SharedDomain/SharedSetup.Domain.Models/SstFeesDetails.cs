using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_FEES_DETAILS")]
	public class SstFeesDetails : BaseModel
	{
		[Column("FEE_ID")]
		public long FeeId { get; set; }

		[Column("ENDORSEMENT_ID")]
		public long? EndorsementId { get; set; }

		[Column("CLAIM_TRANSACTION")]
		public byte? ClaimTransaction { get; set; }

		[Column("REINSURANCE_TRANSACTION")]
		public byte? ReinsuranceTransaction { get; set; }

		[Column("INVESTMENT_TRANSACTION")]
		public long? InvestmentTransaction { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[Column("BENEFIT_TYPE")]
		public short? BenefitType { get; set; }

		[ForeignKey("FeeId")]
		[InverseProperty("SstFeesDetails")]
		public virtual SstFees Fee { get; set; }
	}
}
