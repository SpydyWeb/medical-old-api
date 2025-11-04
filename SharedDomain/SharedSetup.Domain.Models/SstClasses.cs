using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_CLASSES")]
	public class SstClasses : BaseModel
	{
		[Required]
		[Column("CODE")]
		public string Code { get; set; }

		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("BUSINESS_TYPE")]
		public byte BusinessType { get; set; }

		[Column("SYSTEM_ID")]
		public long SystemId { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[ForeignKey("SystemId")]
		[InverseProperty("SstClasses")]
		public virtual SstSystems System { get; set; }

		[InverseProperty("Class")]
		public virtual ICollection<SstAccounts> SstAccounts { get; set; }

		[InverseProperty("Class")]
		public virtual ICollection<SstAgentBooks> SstAgentBooks { get; set; }

		[InverseProperty("Class")]
		public virtual ICollection<SstAgentCommissionTiers> SstAgentCommissionTiers { get; set; }

		[InverseProperty("Class")]
		public virtual ICollection<SstAgentOffices> SstAgentOffices { get; set; }

		[InverseProperty("Class")]
		public virtual ICollection<SstClaimDiscounts> SstClaimDiscounts { get; set; }

		[InverseProperty("Class")]
		public virtual ICollection<SstClauses> SstClauses { get; set; }

		[InverseProperty("Class")]
		public virtual ICollection<SstClosingPeriods> SstClosingPeriods { get; set; }

		[InverseProperty("Class")]
		public virtual ICollection<SstCommStructureBusiness> SstCommStructureBusiness { get; set; }

		[InverseProperty("Class")]
		public virtual ICollection<SstCommissionDetails> SstCommissionDetails { get; set; }

		[InverseProperty("Class")]
		public virtual ICollection<SstCoreQuestionnaires> SstCoreQuestionnaires { get; set; }

		[InverseProperty("Class")]
		public virtual ICollection<SstCoverTypes> SstCoverTypes { get; set; }

		[InverseProperty("Class")]
		public virtual ICollection<SstDataSecurity> SstDataSecurity { get; set; }

		[InverseProperty("Class")]
		public virtual ICollection<SstEndorsements> SstEndorsements { get; set; }

		[InverseProperty("Class")]
		public virtual ICollection<SstFeesTiers> SstFeesTiers { get; set; }

		[InverseProperty("Class")]
		public virtual ICollection<SstPackagedPolicyDetails> SstPackagedPolicyDetails { get; set; }

		[InverseProperty("Class")]
		public virtual ICollection<SstPackegedCovers> SstPackegedCovers { get; set; }

		[InverseProperty("Class")]
		public virtual ICollection<SstPolicyBusiness> SstPolicyBusiness { get; set; }

		[InverseProperty("Class")]
		public virtual ICollection<SstPolicyDiscounts> SstPolicyDiscounts { get; set; }

		[InverseProperty("Class")]
		public virtual ICollection<SstPolicyTypes> SstPolicyTypes { get; set; }

		[InverseProperty("Class")]
		public virtual ICollection<SstProductsDetails> SstProductsDetails { get; set; }

		[InverseProperty("Class")]
		public virtual ICollection<SstRatingMatrix> SstRatingMatrix { get; set; }

		[InverseProperty("Class")]
		public virtual ICollection<SstReinsuranceAccounts> SstReinsuranceAccounts { get; set; }

		[InverseProperty("Class")]
		public virtual ICollection<SstRelations> SstRelations { get; set; }

		[InverseProperty("Class")]
		public virtual ICollection<SstSegments> SstSegments { get; set; }

		[InverseProperty("Class")]
		public virtual ICollection<SstSerialLists> SstSerialLists { get; set; }

		[InverseProperty("Class")]
		public virtual ICollection<SstShortPeriods> SstShortPeriods { get; set; }

		[InverseProperty("Class")]
		public virtual ICollection<SstStatusRelation> SstStatusRelation { get; set; }

		public SstClasses()
		{
			SstAccounts = new HashSet<SstAccounts>();
			SstAgentBooks = new HashSet<SstAgentBooks>();
			SstAgentCommissionTiers = new HashSet<SstAgentCommissionTiers>();
			SstAgentOffices = new HashSet<SstAgentOffices>();
			SstClaimDiscounts = new HashSet<SstClaimDiscounts>();
			SstClauses = new HashSet<SstClauses>();
			SstClosingPeriods = new HashSet<SstClosingPeriods>();
			SstCommStructureBusiness = new HashSet<SstCommStructureBusiness>();
			SstCommissionDetails = new HashSet<SstCommissionDetails>();
			SstCoreQuestionnaires = new HashSet<SstCoreQuestionnaires>();
			SstCoverTypes = new HashSet<SstCoverTypes>();
			SstDataSecurity = new HashSet<SstDataSecurity>();
			SstEndorsements = new HashSet<SstEndorsements>();
			SstFeesTiers = new HashSet<SstFeesTiers>();
			SstPackagedPolicyDetails = new HashSet<SstPackagedPolicyDetails>();
			SstPackegedCovers = new HashSet<SstPackegedCovers>();
			SstPolicyBusiness = new HashSet<SstPolicyBusiness>();
			SstPolicyDiscounts = new HashSet<SstPolicyDiscounts>();
			SstPolicyTypes = new HashSet<SstPolicyTypes>();
			SstProductsDetails = new HashSet<SstProductsDetails>();
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
