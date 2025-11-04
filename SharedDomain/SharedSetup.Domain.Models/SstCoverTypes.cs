using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_COVER_TYPES")]
	public class SstCoverTypes : BaseModel
	{
		[NotMapped]
		public string InsuranceClassName { get; set; }

		[NotMapped]
		public string InsuranceSystemName { get; set; }

		[NotMapped]
		public string PolicyTypeName { get; set; }

		[NotMapped]
		public SelectItem MinPremParentCoverName { get; set; }

		[Column("SYSTEM_ID")]
		public long SystemId { get; set; }

		[Column("CLASS_ID")]
		public long ClassId { get; set; }

		[Column("POLICY_TYPE")]
		public long? PolicyType { get; set; }

		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("COVER_ID")]
		public long? CoverId { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[Column("PREMIUM_AMOUNT")]
		public decimal? PremiumAmount { get; set; }

		[Column("PREMIUM_RATE")]
		public decimal? PremiumRate { get; set; }

		[Column("MIN_PREM_PARENT_COVER")]
		public long? MinPremParentCover { get; set; }

		[ForeignKey("ClassId")]
		[InverseProperty("SstCoverTypes")]
		public virtual SstClasses Class { get; set; }

		[ForeignKey("CoverId")]
		[InverseProperty("InverseCover")]
		public virtual SstCoverTypes Cover { get; set; }

		[ForeignKey("MinPremParentCover")]
		[InverseProperty("InverseMinPremParentCoverNavigation")]
		public virtual SstCoverTypes MinPremParentCoverNavigation { get; set; }

		[ForeignKey("PolicyType")]
		[InverseProperty("SstCoverTypes")]
		public virtual SstPolicyTypes PolicyTypeNavigation { get; set; }

		[ForeignKey("SystemId")]
		[InverseProperty("SstCoverTypes")]
		public virtual SstSystems System { get; set; }

		[InverseProperty("Cover")]
		public virtual ICollection<SstCoverTypes> InverseCover { get; set; }

		[InverseProperty("MinPremParentCoverNavigation")]
		public virtual ICollection<SstCoverTypes> InverseMinPremParentCoverNavigation { get; set; }

		[InverseProperty("Cover")]
		public virtual ICollection<SstAccounts> SstAccounts { get; set; }

		[InverseProperty("CoverTypeNavigation")]
		public virtual ICollection<SstAgentCommissionTiers> SstAgentCommissionTiers { get; set; }

		[InverseProperty("CoverTypeNavigation")]
		public virtual ICollection<SstCoverRatingTypes> SstCoverRatingTypes { get; set; }

		[InverseProperty("Cover")]
		public virtual ICollection<SstFeesTiersDetails> SstFeesTiersDetails { get; set; }

		[InverseProperty("CoverTypeNavigation")]
		public virtual ICollection<SstPackegedCovers> SstPackegedCovers { get; set; }

		[InverseProperty("CoverTypeNavigation")]
		public virtual ICollection<SstRatingMatrix> SstRatingMatrix { get; set; }

		public SstCoverTypes()
		{
			InverseCover = new HashSet<SstCoverTypes>();
			InverseMinPremParentCoverNavigation = new HashSet<SstCoverTypes>();
			SstAccounts = new HashSet<SstAccounts>();
			SstAgentCommissionTiers = new HashSet<SstAgentCommissionTiers>();
			SstCoverRatingTypes = new HashSet<SstCoverRatingTypes>();
			SstFeesTiersDetails = new HashSet<SstFeesTiersDetails>();
			SstPackegedCovers = new HashSet<SstPackegedCovers>();
			SstRatingMatrix = new HashSet<SstRatingMatrix>();
		}
	}
}
