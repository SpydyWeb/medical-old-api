using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_POLICY_TYPES")]
	public class SstPolicyTypes : BaseModel
	{
		[NotMapped]
		public string InsuranceClassName { get; set; }

		[NotMapped]
		public string InsuranceSystemName { get; set; }

		[NotMapped]
		public string PolicyTypeName { get; set; }

		[NotMapped]
		public string ProductName { get; set; }

		[NotMapped]
		public long? ProductId { get; set; }

		[NotMapped]
		public long SystemId { get; set; }

		[Required]
		[Column("CODE")]
		public string Code { get; set; }

		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("BUSINESS_TYPE")]
		public byte? BusinessType { get; set; }

		[Column("UNEARNED_BASIS")]
		public byte? UnearnedBasis { get; set; }

		[Column("EARNED_PERCENT")]
		public decimal? EarnedPercent { get; set; }

		[Column("EFFECTIVE_DATE")]
		public DateTime? EffectiveDate { get; set; }

		[Column("EXPIRY_DATE")]
		public DateTime? ExpiryDate { get; set; }

		[Column("TREATY_TYPE")]
		public byte? TreatyType { get; set; }

		[Column("LONG_TERM")]
		public byte? LongTerm { get; set; }

		[Column("RATE_BASIS")]
		public byte? RateBasis { get; set; }

		[Column("RATE_TYPE")]
		public byte? RateType { get; set; }

		[Column("RATE_PER")]
		public byte? RatePer { get; set; }

		[Column("AGE_DECREASE")]
		public byte? AgeDecrease { get; set; }

		[Column("MIN_CUSTOMER_AGE")]
		public byte? MinCustomerAge { get; set; }

		[Column("MAX_CUSTOMER_AGE")]
		public byte? MaxCustomerAge { get; set; }

		[Column("MIN_MEMBER_AGE")]
		public byte? MinMemberAge { get; set; }

		[Column("MAX_MEMBER_AGE")]
		public byte? MaxMemberAge { get; set; }

		[Column("MIN_TERM")]
		public byte? MinTerm { get; set; }

		[Column("MAX_TERM")]
		public byte? MaxTerm { get; set; }

		[Column("BASIC_COVER")]
		public byte? BasicCover { get; set; }

		[Column("TARGET_GENDER")]
		public byte? TargetGender { get; set; }

		[Column("TERM_BASIS")]
		public byte? TermBasis { get; set; }

		[Column("CLASS_ID")]
		public long ClassId { get; set; }

		[Column("MATURITY_AGE")]
		public byte? MaturityAge { get; set; }

		[Column("REINSURANCE_METHOD")]
		public int? ReinsuranceMethod { get; set; }

		[Column("POLICY_TERM")]
		public byte? PolicyTerm { get; set; }

		[Column("REQUIRE_PAYNOTE")]
		public byte? RequirePaynote { get; set; }

		[Column("CLAIM_COVERAGE_TYPE")]
		public short? ClaimCoverageType { get; set; }

		[ForeignKey("ClassId")]
		[InverseProperty("SstPolicyTypes")]
		public virtual SstClasses Class { get; set; }

		[InverseProperty("PolicyTypeNavigation")]
		public virtual ICollection<SstAccounts> SstAccounts { get; set; }

		[InverseProperty("PolicyTypeNavigation")]
		public virtual ICollection<SstAgentBooks> SstAgentBooks { get; set; }

		[InverseProperty("PolicyTypeNavigation")]
		public virtual ICollection<SstAgentCommissionTiers> SstAgentCommissionTiers { get; set; }

		[InverseProperty("PolicyTypeNavigation")]
		public virtual ICollection<SstAgentOffices> SstAgentOffices { get; set; }

		[InverseProperty("PolicyTypeNavigation")]
		public virtual ICollection<SstChannelPlans> SstChannelPlans { get; set; }

		[InverseProperty("PolicyTypeNavigation")]
		public virtual ICollection<SstClaimDiscounts> SstClaimDiscounts { get; set; }

		[InverseProperty("PolicyTypeNavigation")]
		public virtual ICollection<SstClauses> SstClauses { get; set; }

		[InverseProperty("PolicyTypeNavigation")]
		public virtual ICollection<SstClosingPeriods> SstClosingPeriods { get; set; }

		[InverseProperty("PolicyTypeNavigation")]
		public virtual ICollection<SstCommStructureBusiness> SstCommStructureBusiness { get; set; }

		[InverseProperty("PolicyTypeNavigation")]
		public virtual ICollection<SstCommissionDetails> SstCommissionDetails { get; set; }

		[InverseProperty("PolicyType")]
		public virtual ICollection<SstCoreQuestionnaires> SstCoreQuestionnaires { get; set; }

		[InverseProperty("PolicyTypeNavigation")]
		public virtual ICollection<SstCoverTypes> SstCoverTypes { get; set; }

		[InverseProperty("PolicyTypeNavigation")]
		public virtual ICollection<SstDataSecurity> SstDataSecurity { get; set; }

		[InverseProperty("PolicyTypeNavigation")]
		public virtual ICollection<SstFeesTiers> SstFeesTiers { get; set; }

		[InverseProperty("PolicyTypeNavigation")]
		public virtual ICollection<SstPackagedPolicyDetails> SstPackagedPolicyDetails { get; set; }

		[InverseProperty("PolicyTypeNavigation")]
		public virtual ICollection<SstPackegedCovers> SstPackegedCovers { get; set; }

		[InverseProperty("PolicyTypeNavigation")]
		public virtual ICollection<SstPolicyBusiness> SstPolicyBusiness { get; set; }

		[InverseProperty("PolicyTypeNavigation")]
		public virtual ICollection<SstPolicyDiscounts> SstPolicyDiscounts { get; set; }

		[InverseProperty("PolicyTypeNavigation")]
		public virtual ICollection<SstProductsDetails> SstProductsDetails { get; set; }

		[InverseProperty("PolicyType")]
		public virtual ICollection<SstQuestDetails> SstQuestDetails { get; set; }

		[InverseProperty("PolicyTypeNavigation")]
		public virtual ICollection<SstRatingMatrix> SstRatingMatrix { get; set; }

		[InverseProperty("PolicyTypeNavigation")]
		public virtual ICollection<SstReinsuranceAccounts> SstReinsuranceAccounts { get; set; }

		[InverseProperty("PolicyTypeNavigation")]
		public virtual ICollection<SstRelations> SstRelations { get; set; }

		[InverseProperty("PolicyTypeNavigation")]
		public virtual ICollection<SstSegments> SstSegments { get; set; }

		[InverseProperty("PolicyTypeNavigation")]
		public virtual ICollection<SstSerialLists> SstSerialLists { get; set; }

		[InverseProperty("PolicyTypeNavigation")]
		public virtual ICollection<SstShortPeriods> SstShortPeriods { get; set; }

		[InverseProperty("PolicyTypeNavigation")]
		public virtual ICollection<SstStatusRelation> SstStatusRelation { get; set; }

		public SstPolicyTypes()
		{
			SstAccounts = new HashSet<SstAccounts>();
			SstAgentBooks = new HashSet<SstAgentBooks>();
			SstAgentCommissionTiers = new HashSet<SstAgentCommissionTiers>();
			SstAgentOffices = new HashSet<SstAgentOffices>();
			SstChannelPlans = new HashSet<SstChannelPlans>();
			SstClaimDiscounts = new HashSet<SstClaimDiscounts>();
			SstClauses = new HashSet<SstClauses>();
			SstClosingPeriods = new HashSet<SstClosingPeriods>();
			SstCommStructureBusiness = new HashSet<SstCommStructureBusiness>();
			SstCommissionDetails = new HashSet<SstCommissionDetails>();
			SstCoreQuestionnaires = new HashSet<SstCoreQuestionnaires>();
			SstCoverTypes = new HashSet<SstCoverTypes>();
			SstDataSecurity = new HashSet<SstDataSecurity>();
			SstFeesTiers = new HashSet<SstFeesTiers>();
			SstPackagedPolicyDetails = new HashSet<SstPackagedPolicyDetails>();
			SstPackegedCovers = new HashSet<SstPackegedCovers>();
			SstPolicyBusiness = new HashSet<SstPolicyBusiness>();
			SstPolicyDiscounts = new HashSet<SstPolicyDiscounts>();
			SstProductsDetails = new HashSet<SstProductsDetails>();
			SstQuestDetails = new HashSet<SstQuestDetails>();
			SstRatingMatrix = new HashSet<SstRatingMatrix>();
			SstReinsuranceAccounts = new HashSet<SstReinsuranceAccounts>();
			SstRelations = new HashSet<SstRelations>();
			SstSegments = new HashSet<SstSegments>();
			SstSerialLists = new HashSet<SstSerialLists>();
			SstShortPeriods = new HashSet<SstShortPeriods>();
			SstStatusRelation = new HashSet<SstStatusRelation>();
		}
	}
}
