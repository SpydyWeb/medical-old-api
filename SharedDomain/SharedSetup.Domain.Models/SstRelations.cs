using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_RELATIONS")]
	public class SstRelations : BaseModel
	{
		[NotMapped]
		public string insSystem { get; set; }

		[NotMapped]
		public string insClass { get; set; }

		[NotMapped]
		public string policyTypeName { get; set; }

		[NotMapped]
		public long systemId { get; set; }

		[NotMapped]
		public string businessTypeName { get; set; }

		[NotMapped]
		public List<SelectItem> RelatedList { get; set; }

		[NotMapped]
		public List<SelectItem> NonRelatedList { get; set; }

		[Column("CLASS_ID")]
		public long ClassId { get; set; }

		[Column("POLICY_TYPE")]
		public long PolicyType { get; set; }

		[Column("CURRENCY")]
		public string Currency { get; set; }

		[Column("MIN_SUM_INSURED")]
		public decimal? MinSumInsured { get; set; }

		[Column("MAX_SUM_INSURED")]
		public decimal? MaxSumInsured { get; set; }

		[Column("MIN_PREMIUM")]
		public decimal? MinPremium { get; set; }

		[Column("MAX_PREMIUM")]
		public decimal? MaxPremium { get; set; }

		[Column("BUSINESS_TYPE")]
		public byte? BusinessType { get; set; }

		[Column("PAYMENT_CYCLE")]
		public long? PaymentCycle { get; set; }

		[Column("ENDORSEMENT_TYPE")]
		public long? EndorsementType { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[ForeignKey("ClassId")]
		[InverseProperty("SstRelations")]
		public virtual SstClasses Class { get; set; }

		[ForeignKey("EndorsementType")]
		[InverseProperty("SstRelations")]
		public virtual SstEndorsements EndorsementTypeNavigation { get; set; }

		[ForeignKey("PaymentCycle")]
		[InverseProperty("SstRelations")]
		public virtual SstPaymentCycles PaymentCycleNavigation { get; set; }

		[ForeignKey("PolicyType")]
		[InverseProperty("SstRelations")]
		public virtual SstPolicyTypes PolicyTypeNavigation { get; set; }
	}
}
