using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_SYSTEMS")]
	public class SstSystems : BaseModel
	{
		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("ABBREVIATION")]
		public string Abbreviation { get; set; }

		[Column("NOTES")]
		public string Notes { get; set; }

		[Column("APPLICATION_ID")]
		public long? ApplicationId { get; set; }

		[Column("VIRTUAL_PATH")]
		public string VirtualPath { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<ApprovalMapping> ApprovalMapping { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<SpdProducts> SpdProducts { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<SstAccounts> SstAccounts { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<SstAgentBooks> SstAgentBooks { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<SstAgents> SstAgents { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<SstAlerts> SstAlerts { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<SstBusinessChannels> SstBusinessChannels { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<SstClasses> SstClasses { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<SstClauses> SstClauses { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<SstClosingPeriods> SstClosingPeriods { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<SstCodes> SstCodes { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<SstCommissionStructure> SstCommissionStructure { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<SstCommissionTypes> SstCommissionTypes { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<SstCoreQuestionnaires> SstCoreQuestionnaires { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<SstCoverTypes> SstCoverTypes { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<SstDiscounts> SstDiscounts { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<SstDiscountsFactors> SstDiscountsFactors { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<SstDocumentGroups> SstDocumentGroups { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<SstDomains> SstDomains { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<SstEndorsements> SstEndorsements { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<SstEpaymentMethods> SstEpaymentMethods { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<SstFees> SstFees { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<SstFeesTiers> SstFeesTiers { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<SstFormSystems> SstFormSystems { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<SstIntegrations> SstIntegrations { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<SstMailer> SstMailer { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<SstMatrixParamsMapping> SstMatrixParamsMapping { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<SstModules> SstModules { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<SstNotifications> SstNotifications { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<SstOffices> SstOffices { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<SstPages> SstPages { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<SstPaymentCycles> SstPaymentCycles { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<SstProcessSystems> SstProcessSystems { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<SstQuestSystems> SstQuestSystems { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<SstRatingMatrix> SstRatingMatrix { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<SstReinsuranceAccounts> SstReinsuranceAccounts { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<SstResources> SstResources { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<SstRules> SstRules { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<SstSegments> SstSegments { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<SstSerialLists> SstSerialLists { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<SstShortPeriods> SstShortPeriods { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<SstSmsProviders> SstSmsProviders { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<SstStatusRelation> SstStatusRelation { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<SstSubBranches> SstSubBranches { get; set; }

		[InverseProperty("System")]
		public virtual ICollection<SstValuesRelation> SstValuesRelation { get; set; }

		public SstSystems()
		{
			ApprovalMapping = new HashSet<ApprovalMapping>();
			SpdProducts = new HashSet<SpdProducts>();
			SstAccounts = new HashSet<SstAccounts>();
			SstAgentBooks = new HashSet<SstAgentBooks>();
			SstAgents = new HashSet<SstAgents>();
			SstAlerts = new HashSet<SstAlerts>();
			SstBusinessChannels = new HashSet<SstBusinessChannels>();
			SstClasses = new HashSet<SstClasses>();
			SstClauses = new HashSet<SstClauses>();
			SstClosingPeriods = new HashSet<SstClosingPeriods>();
			SstCodes = new HashSet<SstCodes>();
			SstCommissionStructure = new HashSet<SstCommissionStructure>();
			SstCommissionTypes = new HashSet<SstCommissionTypes>();
			SstCoreQuestionnaires = new HashSet<SstCoreQuestionnaires>();
			SstCoverTypes = new HashSet<SstCoverTypes>();
			SstDiscounts = new HashSet<SstDiscounts>();
			SstDiscountsFactors = new HashSet<SstDiscountsFactors>();
			SstDocumentGroups = new HashSet<SstDocumentGroups>();
			SstDomains = new HashSet<SstDomains>();
			SstEndorsements = new HashSet<SstEndorsements>();
			SstEpaymentMethods = new HashSet<SstEpaymentMethods>();
			SstFees = new HashSet<SstFees>();
			SstFeesTiers = new HashSet<SstFeesTiers>();
			SstFormSystems = new HashSet<SstFormSystems>();
			SstIntegrations = new HashSet<SstIntegrations>();
			SstMailer = new HashSet<SstMailer>();
			SstMatrixParamsMapping = new HashSet<SstMatrixParamsMapping>();
			SstModules = new HashSet<SstModules>();
			SstNotifications = new HashSet<SstNotifications>();
			SstOffices = new HashSet<SstOffices>();
			SstPages = new HashSet<SstPages>();
			SstPaymentCycles = new HashSet<SstPaymentCycles>();
			SstProcessSystems = new HashSet<SstProcessSystems>();
			SstQuestSystems = new HashSet<SstQuestSystems>();
			SstRatingMatrix = new HashSet<SstRatingMatrix>();
			SstReinsuranceAccounts = new HashSet<SstReinsuranceAccounts>();
			SstResources = new HashSet<SstResources>();
			SstRules = new HashSet<SstRules>();
			SstSegments = new HashSet<SstSegments>();
			SstSerialLists = new HashSet<SstSerialLists>();
			SstShortPeriods = new HashSet<SstShortPeriods>();
			SstSmsProviders = new HashSet<SstSmsProviders>();
			SstStatusRelation = new HashSet<SstStatusRelation>();
			SstSubBranches = new HashSet<SstSubBranches>();
			SstValuesRelation = new HashSet<SstValuesRelation>();
		}
	}
}
