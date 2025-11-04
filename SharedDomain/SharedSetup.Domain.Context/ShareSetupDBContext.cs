using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oracle.EntityFrameworkCore.Infrastructure;
using SharedSetup.Domain.Common;
using SharedSetup.Domain.Enums;
using SharedSetup.Domain.Models;

namespace SharedSetup.Domain.Context
{
	public class ShareSetupDBContext : DbContext
	{
		public virtual DbSet<ApprovalMapping> ApprovalMapping { get; set; }

		public virtual DbSet<CpEpaymentTransactions> CpEpaymentTransactions { get; set; }

		public virtual DbSet<CpUserProperties> CpUserProperties { get; set; }

		public virtual DbSet<SpdComponents> SpdComponents { get; set; }

		public virtual DbSet<SpdContainers> SpdContainers { get; set; }

		public virtual DbSet<SpdControlValues> SpdControlValues { get; set; }

		public virtual DbSet<SpdFormControls> SpdFormControls { get; set; }

		public virtual DbSet<SpdProducts> SpdProducts { get; set; }

		public virtual DbSet<SpdProductsDetails> SpdProductsDetails { get; set; }

		public virtual DbSet<SpdProductsSteps> SpdProductsSteps { get; set; }

		public virtual DbSet<SpdSequences> SpdSequences { get; set; }

		public virtual DbSet<SpdSequencesDetails> SpdSequencesDetails { get; set; }

		public virtual DbSet<SpdStepsTransactions> SpdStepsTransactions { get; set; }

		public virtual DbSet<SstAccounts> SstAccounts { get; set; }

		public virtual DbSet<SstActions> SstActions { get; set; }

		public virtual DbSet<SstAgentBookDetails> SstAgentBookDetails { get; set; }

		public virtual DbSet<SstAgentBooks> SstAgentBooks { get; set; }

		public virtual DbSet<SstAgentCommissionTiers> SstAgentCommissionTiers { get; set; }

		public virtual DbSet<SstAgentOffices> SstAgentOffices { get; set; }

		public virtual DbSet<SstAgentStructures> SstAgentStructures { get; set; }

		public virtual DbSet<SstAlerts> SstAlerts { get; set; }

		public virtual DbSet<SstAnswers> SstAnswers { get; set; }

		public virtual DbSet<SstBusinessChannels> SstBusinessChannels { get; set; }

		public virtual DbSet<SstChannelPlans> SstChannelPlans { get; set; }

		public virtual DbSet<SstChannelTypes> SstChannelTypes { get; set; }

		public virtual DbSet<SstClaimDiscounts> SstClaimDiscounts { get; set; }

		public virtual DbSet<SstClasses> SstClasses { get; set; }

		public virtual DbSet<SstClauses> SstClauses { get; set; }

		public virtual DbSet<SstClausesDetails> SstClausesDetails { get; set; }

		public virtual DbSet<SstClosingPeriods> SstClosingPeriods { get; set; }

		public virtual DbSet<SstCodes> SstCodes { get; set; }

		public virtual DbSet<SstCommStructureBusiness> SstCommStructureBusiness { get; set; }

		public virtual DbSet<SstCommissionDetails> SstCommissionDetails { get; set; }

		public virtual DbSet<SstCommissionStructure> SstCommissionStructure { get; set; }

		public virtual DbSet<SstCommissionTiers> SstCommissionTiers { get; set; }

		public virtual DbSet<SstCommissionTypes> SstCommissionTypes { get; set; }

		public virtual DbSet<SstComponents> SstComponents { get; set; }

		public virtual DbSet<SstConditions> SstConditions { get; set; }

		public virtual DbSet<SstContainers> SstContainers { get; set; }

		public virtual DbSet<SstCoverTypes> SstCoverTypes { get; set; }

		public virtual DbSet<SstCustomerTypes> SstCustomerTypes { get; set; }

		public virtual DbSet<SstDataSecurity> SstDataSecurity { get; set; }

		public virtual DbSet<SstDiscounts> SstDiscounts { get; set; }

		public virtual DbSet<SstDiscountsBusinessFactors> SstDiscountsBusinessFactors { get; set; }

		public virtual DbSet<SstDiscountsFactors> SstDiscountsFactors { get; set; }

		public virtual DbSet<SstDiscountsFactorsQuery> SstDiscountsFactorsQuery { get; set; }

		public virtual DbSet<SstDocumentGroups> SstDocumentGroups { get; set; }

		public virtual DbSet<SstDocuments> SstDocuments { get; set; }

		public virtual DbSet<SstDomainValues> SstDomainValues { get; set; }

		public virtual DbSet<SstDomains> SstDomains { get; set; }

		public virtual DbSet<SstEndorsements> SstEndorsements { get; set; }

		public virtual DbSet<SstDynamicValues> SstDynamicValues { get; set; }

		public virtual DbSet<SstEntities> SstEntities { get; set; }

		public virtual DbSet<SstEntityDetails> SstEntityDetails { get; set; }

		public virtual DbSet<SstEntityMapping> SstEntityMapping { get; set; }

		public virtual DbSet<SstEntityRoles> SstEntityRoles { get; set; }

		public virtual DbSet<SstEpaymentAlerts> SstEpaymentAlerts { get; set; }

		public virtual DbSet<SstEpaymentDetails> SstEpaymentDetails { get; set; }

		public virtual DbSet<SstEpaymentMethods> SstEpaymentMethods { get; set; }

		public virtual DbSet<SstEpaymentTransaction> SstEpaymentTransaction { get; set; }

		public virtual DbSet<SstFees> SstFees { get; set; }

		public virtual DbSet<SstFeesDetails> SstFeesDetails { get; set; }

		public virtual DbSet<SstFeesTiers> SstFeesTiers { get; set; }

		public virtual DbSet<SstFeesTiersDetails> SstFeesTiersDetails { get; set; }

		public virtual DbSet<SstFinancialDetails> SstFinancialDetails { get; set; }

		public virtual DbSet<SstFinancialTransactions> SstFinancialTransactions { get; set; }

		public virtual DbSet<SstFormControls> SstFormControls { get; set; }

		public virtual DbSet<SstFormElements> SstFormElements { get; set; }

		public virtual DbSet<SstFormGrid> SstFormGrid { get; set; }

		public virtual DbSet<SstFormSystems> SstFormSystems { get; set; }

		public virtual DbSet<SstForms> SstForms { get; set; }

		public virtual DbSet<SstIndustrySectors> SstIndustrySectors { get; set; }

		public virtual DbSet<SstIntegrations> SstIntegrations { get; set; }

		public virtual DbSet<SstIntegrationsApiMapping> SstIntegrationsApiMapping { get; set; }

		public virtual DbSet<SstIntegrationsApiObject> SstIntegrationsApiObject { get; set; }

		public virtual DbSet<SstIntegrationsDbMapping> SstIntegrationsDbMapping { get; set; }

		public virtual DbSet<SstIntegrationsSettings> SstIntegrationsSettings { get; set; }

		public virtual DbSet<SstLogs> SstLogs { get; set; }

		public virtual DbSet<SstLogsDetails> SstLogsDetails { get; set; }

		public virtual DbSet<SstMailer> SstMailer { get; set; }

		public virtual DbSet<SstMappings> SstMappings { get; set; }

		public virtual DbSet<SstMatrixParamsMapping> SstMatrixParamsMapping { get; set; }

		public virtual DbSet<SstModules> SstModules { get; set; }

		public virtual DbSet<SstNotifications> SstNotifications { get; set; }

		public virtual DbSet<SstNotificationsAttachments> SstNotificationsAttachments { get; set; }

		public virtual DbSet<SstNotificationsContacts> SstNotificationsContacts { get; set; }

		public virtual DbSet<SstNotificationsLogs> SstNotificationsLogs { get; set; }

		public virtual DbSet<SstNotificationsParameters> SstNotificationsParameters { get; set; }

		public virtual DbSet<SstNotificationsTemplates> SstNotificationsTemplates { get; set; }

		public virtual DbSet<SstPages> SstPages { get; set; }

		public virtual DbSet<SstPagesControls> SstPagesControls { get; set; }

		public virtual DbSet<SstPagesControlsParams> SstPagesControlsParams { get; set; }

		public virtual DbSet<SstPaymentCycles> SstPaymentCycles { get; set; }

		public virtual DbSet<SstPaymentDetails> SstPaymentDetails { get; set; }

		public virtual DbSet<SstPolicyBusiness> SstPolicyBusiness { get; set; }

		public virtual DbSet<SstPolicyDiscounts> SstPolicyDiscounts { get; set; }

		public virtual DbSet<SstPolicyTypes> SstPolicyTypes { get; set; }

		public virtual DbSet<SstPreferences> SstPreferences { get; set; }

		public virtual DbSet<SstProcessActions> SstProcessActions { get; set; }

		public virtual DbSet<SstProcessConditions> SstProcessConditions { get; set; }

		public virtual DbSet<SstProcessParentSteps> SstProcessParentSteps { get; set; }

		public virtual DbSet<SstProcessRoles> SstProcessRoles { get; set; }

		public virtual DbSet<SstProcessRules> SstProcessRules { get; set; }

		public virtual DbSet<SstProcessSteps> SstProcessSteps { get; set; }

		public virtual DbSet<SstProcessStepsPages> SstProcessStepsPages { get; set; }

		public virtual DbSet<SstProcessSystems> SstProcessSystems { get; set; }

		public virtual DbSet<SstProcesses> SstProcesses { get; set; }

		public virtual DbSet<SstProducts> SstProducts { get; set; }

		public virtual DbSet<SstProductsDetails> SstProductsDetails { get; set; }

		public virtual DbSet<SstQuestControls> SstQuestControls { get; set; }

		public virtual DbSet<SstQuestSystems> SstQuestSystems { get; set; }

		public virtual DbSet<SstQuestionnaires> SstQuestionnaires { get; set; }

		public virtual DbSet<SstRelations> SstRelations { get; set; }

		public virtual DbSet<SstRatingMatrix> SstRatingMatrix { get; set; }

		public virtual DbSet<SstRatingMatrixParams> SstRatingMatrixParams { get; set; }

		public virtual DbSet<SstRatingMatrixValues> SstRatingMatrixValues { get; set; }

		public virtual DbSet<SstResources> SstResources { get; set; }

		public virtual DbSet<SstRules> SstRules { get; set; }

		public virtual DbSet<SstSegmentElement> SstSegmentElement { get; set; }

		public virtual DbSet<SstSegments> SstSegments { get; set; }

		public virtual DbSet<SstSegmentsStructures> SstSegmentsStructures { get; set; }

		public virtual DbSet<SstSerialLists> SstSerialLists { get; set; }

		public virtual DbSet<SstSerialRanges> SstSerialRanges { get; set; }

		public virtual DbSet<SstShortPeriods> SstShortPeriods { get; set; }

		public virtual DbSet<SstShortPeriodsDetails> SstShortPeriodsDetails { get; set; }

		public virtual DbSet<SstSmsProviders> SstSmsProviders { get; set; }

		public virtual DbSet<SstStatusRelation> SstStatusRelation { get; set; }

		public virtual DbSet<SstSystems> SstSystems { get; set; }

		public virtual DbSet<SstUserAlerts> SstUserAlerts { get; set; }

		public virtual DbSet<SstUsers> SstUsers { get; set; }

		public virtual DbSet<SstValuesRelation> SstValuesRelation { get; set; }

		public virtual DbSet<SstVouchersTypes> SstVouchersTypes { get; set; }

		public virtual DbSet<SstOffices> SstOffices { get; set; }

		public virtual DbSet<SstCoreQuestionnaires> SstCoreQuestionnaires { get; set; }

		public virtual DbSet<SstCoverRatingTypes> SstCoverRatingTypes { get; set; }

		public virtual DbSet<SstQuestDetails> SstQuestDetails { get; set; }

		public virtual DbSet<SstSubBranches> SstSubBranches { get; set; }

		public virtual DbSet<SstAgents> SstAgents { get; set; }

		public virtual DbSet<SstPackagedPolicy> SstPackagedPolicy { get; set; }

		public virtual DbSet<SstPackagedPolicyDetails> SstPackagedPolicyDetails { get; set; }

		public virtual DbSet<SstPackegedCovers> SstPackegedCovers { get; set; }

		public virtual DbSet<SstPackegedCoversMatrix> SstPackegedCoversMatrix { get; set; }

		public virtual DbSet<TempVouchers> TempVouchers { get; set; }

		public virtual DbSet<Mytesttable> Mytesttable { get; set; }

		public virtual DbSet<Training> Training { get; set; }

		public ShareSetupDBContext(DbContextOptions options)
			: base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				return;
			}
			switch ((DatabaseType)SharedSettings.DatabaseType)
			{
			case DatabaseType.MySql:
				optionsBuilder.UseMySQL(BaseConnection.MySqlConnectionString);
				break;
			case DatabaseType.Oracle:
				optionsBuilder.UseOracle(BaseConnection.OracleConnectionString, delegate(OracleDbContextOptionsBuilder option)
				{
					option.UseOracleSQLCompatibility("11");
				});
				break;
			case DatabaseType.MsSqlServer:
				optionsBuilder.UseSqlServer(BaseConnection.MsSqlServerConnectionString);
				break;
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			switch ((DatabaseType)SharedSettings.DatabaseType)
			{
			case DatabaseType.MsSqlServer:
				break;
			case DatabaseType.MySql:
				modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");
				modelBuilder.HasDefaultSchema(SharedSettings.SchemaName);
				modelBuilder.Entity(delegate(EntityTypeBuilder<CpEpaymentTransactions> entity)
				{
					entity.ToTable("cp_epayment_transactions");
					entity.Property((CpEpaymentTransactions e) => e.Id).HasColumnName("ID");
					entity.Property((CpEpaymentTransactions e) => e.AcquirerId).HasColumnName("ACQUIRER_ID");
					entity.Property((CpEpaymentTransactions e) => e.Amount).HasColumnName("AMOUNT").HasColumnType("decimal(9,3)");
					entity.Property((CpEpaymentTransactions e) => e.AutoLogId).HasColumnName("AUTO_LOG_ID");
					entity.Property((CpEpaymentTransactions e) => e.ConfirmationId).HasColumnName("CONFIRMATION_ID");
					entity.Property((CpEpaymentTransactions e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((CpEpaymentTransactions e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((CpEpaymentTransactions e) => e.CustomerId).HasColumnName("CUSTOMER_ID");
					entity.Property((CpEpaymentTransactions e) => e.CustomerType).HasColumnName("CUSTOMER_TYPE");
					entity.Property((CpEpaymentTransactions e) => e.LogId).HasColumnName("LOG_ID");
					entity.Property((CpEpaymentTransactions e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((CpEpaymentTransactions e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((CpEpaymentTransactions e) => e.Note).HasColumnName("NOTE").HasMaxLength(500)
						.IsUnicode(unicode: false);
					entity.Property((CpEpaymentTransactions e) => e.OrderId).HasColumnName("ORDER_ID");
					entity.Property((CpEpaymentTransactions e) => e.PaymentStore).HasColumnName("PAYMENT_STORE");
					entity.Property((CpEpaymentTransactions e) => e.RequestDate).HasColumnName("REQUEST_DATE");
					entity.Property((CpEpaymentTransactions e) => e.ResponseDate).HasColumnName("RESPONSE_DATE");
					entity.Property((CpEpaymentTransactions e) => e.ResponseId).HasColumnName("RESPONSE_ID");
					entity.Property((CpEpaymentTransactions e) => e.Source).HasColumnName("SOURCE");
					entity.Property((CpEpaymentTransactions e) => e.Status).HasColumnName("STATUS");
					entity.Property((CpEpaymentTransactions e) => e.StatusMessage).HasColumnName("STATUS_MESSAGE").HasMaxLength(300)
						.IsUnicode(unicode: false);
					entity.Property((CpEpaymentTransactions e) => e.Version).HasColumnName("VERSION").HasMaxLength(100)
						.IsUnicode(unicode: false);
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<CpUserProperties> entity)
				{
					entity.ToTable("cp_user_properties");
					entity.HasIndex((Expression<Func<CpUserProperties, object>>)((CpUserProperties e) => e.UserId)).HasName("CP_USER_PROPERTIES_FK01");
					entity.Property((CpUserProperties e) => e.Id).HasColumnName("ID");
					entity.Property((CpUserProperties e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((CpUserProperties e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((CpUserProperties e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE").HasMaxLength(20)
						.IsUnicode(unicode: false);
					entity.Property((CpUserProperties e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((CpUserProperties e) => e.Property).IsRequired().HasColumnName("PROPERTY")
						.HasMaxLength(256)
						.IsUnicode(unicode: false);
					entity.Property((CpUserProperties e) => e.PropertyValue).IsRequired().HasColumnName("PROPERTY_VALUE")
						.HasColumnType("longblob");
					entity.Property((CpUserProperties e) => e.UserId).HasColumnName("USER_ID");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<CpUserProperties, CpUserProperties>(entity.HasOne((CpUserProperties d) => d.User).WithMany((CpUserProperties p) => p.InverseUser).HasForeignKey((CpUserProperties d) => d.UserId), "CP_USER_PROPERTIES_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SpdComponents> entity)
				{
					entity.ToTable("spd_components");
					entity.HasIndex((Expression<Func<SpdComponents, object>>)((SpdComponents e) => e.StepId)).HasName("SPD_COMPONENTS_FK01");
					entity.Property((SpdComponents e) => e.Id).HasColumnName("ID");
					entity.Property((SpdComponents e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SpdComponents e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SpdComponents e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SpdComponents e) => e.FormType).HasColumnName("FORM_TYPE");
					entity.Property((SpdComponents e) => e.Icon).HasColumnName("ICON").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SpdComponents e) => e.LayoutType).HasColumnName("LAYOUT_TYPE");
					entity.Property((SpdComponents e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SpdComponents e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SpdComponents e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SpdComponents e) => e.Name2).HasColumnName("NAME2").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SpdComponents e) => e.Notes).HasColumnName("NOTES").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SpdComponents e) => e.Order).HasColumnName("ORDER");
					entity.Property((SpdComponents e) => e.RefComponentId).HasColumnName("REF_COMPONENT_ID");
					entity.Property((SpdComponents e) => e.StepId).HasColumnName("STEP_ID");
					entity.Property((SpdComponents e) => e.SystemId).HasColumnName("SYSTEM_ID");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SpdProductsSteps, SpdComponents>(entity.HasOne((SpdComponents d) => d.Step).WithMany((SpdProductsSteps p) => p.SpdComponents).HasForeignKey((SpdComponents d) => d.StepId), "SPD_COMPONENTS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SpdContainers> entity)
				{
					entity.ToTable("spd_containers");
					entity.HasIndex((Expression<Func<SpdContainers, object>>)((SpdContainers e) => e.ComponentId)).HasName("SPD_CONTAINERS_FK01");
					entity.HasIndex((Expression<Func<SpdContainers, object>>)((SpdContainers e) => e.RefContainerId)).HasName("SPD_CONTAINERS_FK02");
					entity.Property((SpdContainers e) => e.Id).HasColumnName("ID");
					entity.Property((SpdContainers e) => e.ComponentId).HasColumnName("COMPONENT_ID");
					entity.Property((SpdContainers e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SpdContainers e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SpdContainers e) => e.Key).HasColumnName("KEY").HasMaxLength(124)
						.IsUnicode(unicode: false);
					entity.Property((SpdContainers e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SpdContainers e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SpdContainers e) => e.Name).HasColumnName("NAME").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SpdContainers e) => e.Name2).HasColumnName("NAME2").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SpdContainers e) => e.Notes).HasColumnName("NOTES").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SpdContainers e) => e.Order).HasColumnName("ORDER");
					entity.Property((SpdContainers e) => e.RefContainerId).HasColumnName("REF_CONTAINER_ID");
					entity.Property((SpdContainers e) => e.Type).HasColumnName("TYPE");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SpdComponents, SpdContainers>(entity.HasOne((SpdContainers d) => d.Component).WithMany((SpdComponents p) => p.SpdContainers).HasForeignKey((SpdContainers d) => d.ComponentId), "SPD_CONTAINERS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SpdContainers, SpdContainers>(entity.HasOne((SpdContainers d) => d.RefContainer).WithMany((SpdContainers p) => p.InverseRefContainer).HasForeignKey((SpdContainers d) => d.RefContainerId), "SPD_CONTAINERS_FK02");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SpdControlValues> entity)
				{
					entity.ToTable("spd_control_values");
					entity.HasIndex((Expression<Func<SpdControlValues, object>>)((SpdControlValues e) => e.ComponentId)).HasName("SPD_CONTROL_VALUES_FK02");
					entity.HasIndex((Expression<Func<SpdControlValues, object>>)((SpdControlValues e) => e.ControlId)).HasName("SPD_CONTROL_VALUES_FK03");
					entity.HasIndex((Expression<Func<SpdControlValues, object>>)((SpdControlValues e) => e.ProductId)).HasName("SPD_CONTROL_VALUES_FK05");
					entity.HasIndex((Expression<Func<SpdControlValues, object>>)((SpdControlValues e) => e.StepId)).HasName("SPD_CONTROL_VALUES_FK01");
					entity.HasIndex((Expression<Func<SpdControlValues, object>>)((SpdControlValues e) => e.UserPropertyId)).HasName("SPD_CONTROL_VALUES_FK04");
					entity.Property((SpdControlValues e) => e.Id).HasColumnName("ID");
					entity.Property((SpdControlValues e) => e.ComponentId).HasColumnName("COMPONENT_ID");
					entity.Property((SpdControlValues e) => e.ControlId).HasColumnName("CONTROL_ID");
					entity.Property((SpdControlValues e) => e.ControlKey).HasColumnName("CONTROL_KEY").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SpdControlValues e) => e.ControlValue).HasColumnName("CONTROL_VALUE").HasColumnType("longblob");
					entity.Property((SpdControlValues e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SpdControlValues e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SpdControlValues e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SpdControlValues e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SpdControlValues e) => e.ProductId).HasColumnName("PRODUCT_ID");
					entity.Property((SpdControlValues e) => e.StepId).HasColumnName("STEP_ID");
					entity.Property((SpdControlValues e) => e.UserPropertyId).HasColumnName("USER_PROPERTY_ID");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SpdComponents, SpdControlValues>(entity.HasOne((SpdControlValues d) => d.Component).WithMany((SpdComponents p) => p.SpdControlValues).HasForeignKey((SpdControlValues d) => d.ComponentId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SPD_CONTROL_VALUES_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SpdFormControls, SpdControlValues>(entity.HasOne((SpdControlValues d) => d.Control).WithMany((SpdFormControls p) => p.SpdControlValues).HasForeignKey((SpdControlValues d) => d.ControlId), "SPD_CONTROL_VALUES_FK03");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SpdProducts, SpdControlValues>(entity.HasOne((SpdControlValues d) => d.Product).WithMany((SpdProducts p) => p.SpdControlValues).HasForeignKey((SpdControlValues d) => d.ProductId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SPD_CONTROL_VALUES_FK05");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SpdProductsSteps, SpdControlValues>(entity.HasOne((SpdControlValues d) => d.Step).WithMany((SpdProductsSteps p) => p.SpdControlValues).HasForeignKey((SpdControlValues d) => d.StepId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SPD_CONTROL_VALUES_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<CpUserProperties, SpdControlValues>(entity.HasOne((SpdControlValues d) => d.UserProperty).WithMany((CpUserProperties p) => p.SpdControlValues).HasForeignKey((SpdControlValues d) => d.UserPropertyId), "SPD_CONTROL_VALUES_FK04");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SpdFormControls> entity)
				{
					entity.ToTable("spd_form_controls");
					entity.HasIndex((Expression<Func<SpdFormControls, object>>)((SpdFormControls e) => e.ContainerId)).HasName("SPD_FORM_CONTROLS_FK01");
					entity.HasIndex((Expression<Func<SpdFormControls, object>>)((SpdFormControls e) => e.RefControlId)).HasName("SPD_FORM_CONTROLS_FK02");
					entity.Property((SpdFormControls e) => e.Id).HasColumnName("ID");
					entity.Property((SpdFormControls e) => e.ContainerId).HasColumnName("CONTAINER_ID");
					entity.Property((SpdFormControls e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SpdFormControls e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SpdFormControls e) => e.Disabled).HasColumnName("DISABLED").HasDefaultValueSql("1");
					entity.Property((SpdFormControls e) => e.HasSubformControls).HasColumnName("HAS_SUBFORM_CONTROLS");
					entity.Property((SpdFormControls e) => e.Icon).HasColumnName("ICON").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SpdFormControls e) => e.Key).HasColumnName("KEY").HasMaxLength(124)
						.IsUnicode(unicode: false);
					entity.Property((SpdFormControls e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SpdFormControls e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SpdFormControls e) => e.Name).HasColumnName("NAME").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SpdFormControls e) => e.Name2).HasColumnName("NAME2").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SpdFormControls e) => e.Notes).HasColumnName("NOTES").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SpdFormControls e) => e.Options).HasColumnName("OPTIONS").HasColumnType("longtext");
					entity.Property((SpdFormControls e) => e.Order).HasColumnName("ORDER");
					entity.Property((SpdFormControls e) => e.RefControlId).HasColumnName("REF_CONTROL_ID");
					entity.Property((SpdFormControls e) => e.Required).HasColumnName("REQUIRED").HasDefaultValueSql("0");
					entity.Property((SpdFormControls e) => e.Type).HasColumnName("TYPE");
					entity.Property((SpdFormControls e) => e.Value).HasColumnName("VALUE");
					entity.Property((SpdFormControls e) => e.Width).HasColumnName("WIDTH");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SpdContainers, SpdFormControls>(entity.HasOne((SpdFormControls d) => d.Container).WithMany((SpdContainers p) => p.SpdFormControls).HasForeignKey((SpdFormControls d) => d.ContainerId), "SPD_FORM_CONTROLS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SpdFormControls, SpdFormControls>(entity.HasOne((SpdFormControls d) => d.RefControl).WithMany((SpdFormControls p) => p.InverseRefControl).HasForeignKey((SpdFormControls d) => d.RefControlId), "SPD_FORM_CONTROLS_FK02");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SpdProducts> entity)
				{
					entity.ToTable("spd_products");
					entity.HasIndex((Expression<Func<SpdProducts, object>>)((SpdProducts e) => e.SystemId)).HasName("SPD_PRODUCTS_FK01");
					entity.Property((SpdProducts e) => e.Id).HasColumnName("ID");
					entity.Property((SpdProducts e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SpdProducts e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SpdProducts e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SpdProducts e) => e.LaunchDate).HasColumnName("LAUNCH_DATE");
					entity.Property((SpdProducts e) => e.Logo).HasColumnName("LOGO").HasColumnType("longblob");
					entity.Property((SpdProducts e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SpdProducts e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SpdProducts e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SpdProducts e) => e.Name2).HasColumnName("NAME2").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SpdProducts e) => e.Notes).HasColumnName("NOTES").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SpdProducts e) => e.SystemId).HasColumnName("SYSTEM_ID");
					entity.Property((SpdProducts e) => e.TerminationDate).HasColumnName("TERMINATION_DATE");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SpdProducts>(entity.HasOne((SpdProducts d) => d.System).WithMany((SstSystems p) => p.SpdProducts).HasForeignKey((SpdProducts d) => d.SystemId), "SPD_PRODUCTS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SpdProductsDetails> entity)
				{
					entity.ToTable("spd_products_details");
					entity.HasIndex((Expression<Func<SpdProductsDetails, object>>)((SpdProductsDetails e) => e.ProductId)).HasName("SPD_PRODUCTS_DETAILS_FK01");
					entity.Property((SpdProductsDetails e) => e.Id).HasColumnName("ID");
					entity.Property((SpdProductsDetails e) => e.ClassId).HasColumnName("CLASS_ID");
					entity.Property((SpdProductsDetails e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SpdProductsDetails e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SpdProductsDetails e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SpdProductsDetails e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SpdProductsDetails e) => e.PolicyType).HasColumnName("POLICY_TYPE");
					entity.Property((SpdProductsDetails e) => e.ProductId).HasColumnName("PRODUCT_ID");
					entity.Property((SpdProductsDetails e) => e.RiskCategory).HasColumnName("RISK_CATEGORY");
					entity.Property((SpdProductsDetails e) => e.SystemId).HasColumnName("SYSTEM_ID");
					entity.Property((SpdProductsDetails e) => e.ValidFrom).HasColumnName("VALID_FROM");
					entity.Property((SpdProductsDetails e) => e.ValidTo).HasColumnName("VALID_TO");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SpdProducts, SpdProductsDetails>(entity.HasOne((SpdProductsDetails d) => d.Product).WithMany((SpdProducts p) => p.SpdProductsDetails).HasForeignKey((SpdProductsDetails d) => d.ProductId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SPD_PRODUCTS_DETAILS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SpdProductsSteps> entity)
				{
					entity.ToTable("spd_products_steps");
					entity.Property((SpdProductsSteps e) => e.Id).HasColumnName("ID");
					entity.Property((SpdProductsSteps e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SpdProductsSteps e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SpdProductsSteps e) => e.Icon).HasColumnName("ICON").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SpdProductsSteps e) => e.Load).HasColumnName("LOAD").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SpdProductsSteps e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SpdProductsSteps e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SpdProductsSteps e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SpdProductsSteps e) => e.Name2).HasColumnName("NAME2").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SpdProductsSteps e) => e.Order).HasColumnName("ORDER");
					entity.Property((SpdProductsSteps e) => e.ProductId).HasColumnName("PRODUCT_ID");
					entity.Property((SpdProductsSteps e) => e.Submit).HasColumnName("SUBMIT").HasMaxLength(1024)
						.IsUnicode(unicode: false);
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SpdSequences> entity)
				{
					entity.ToTable("spd_sequences");
					entity.Property((SpdSequences e) => e.Id).HasColumnName("ID");
					entity.Property((SpdSequences e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SpdSequences e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SpdSequences e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SpdSequences e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SpdSequences e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SpdSequences e) => e.Name2).HasColumnName("NAME2").HasMaxLength(255)
						.IsUnicode(unicode: false);
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SpdSequencesDetails> entity)
				{
					entity.ToTable("spd_sequences_details");
					entity.HasIndex((Expression<Func<SpdSequencesDetails, object>>)((SpdSequencesDetails e) => e.IntegrationId)).HasName("SPD_SEQUENCES_DETAILS_FK02");
					entity.HasIndex((Expression<Func<SpdSequencesDetails, object>>)((SpdSequencesDetails e) => e.SequenceId)).HasName("SPD_SEQUENCES_DETAILS_FK01");
					entity.Property((SpdSequencesDetails e) => e.Id).HasColumnName("ID");
					entity.Property((SpdSequencesDetails e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SpdSequencesDetails e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SpdSequencesDetails e) => e.IntegrationId).HasColumnName("INTEGRATION_ID");
					entity.Property((SpdSequencesDetails e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SpdSequencesDetails e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SpdSequencesDetails e) => e.Order).HasColumnName("ORDER");
					entity.Property((SpdSequencesDetails e) => e.SequenceId).HasColumnName("SEQUENCE_ID");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstIntegrations, SpdSequencesDetails>(entity.HasOne((SpdSequencesDetails d) => d.Integration).WithMany((SstIntegrations p) => p.SpdSequencesDetails).HasForeignKey((SpdSequencesDetails d) => d.IntegrationId), "SPD_SEQUENCES_DETAILS_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SpdSequences, SpdSequencesDetails>(entity.HasOne((SpdSequencesDetails d) => d.Sequence).WithMany((SpdSequences p) => p.SpdSequencesDetails).HasForeignKey((SpdSequencesDetails d) => d.SequenceId), "SPD_SEQUENCES_DETAILS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SpdStepsTransactions> entity)
				{
					entity.ToTable("spd_steps_transactions");
					entity.HasIndex((Expression<Func<SpdStepsTransactions, object>>)((SpdStepsTransactions e) => e.IntegrationId)).HasName("SPD_STEPS_TRANSACTIONS_FK02");
					entity.HasIndex((Expression<Func<SpdStepsTransactions, object>>)((SpdStepsTransactions e) => e.StepId)).HasName("SPD_STEPS_TRANSACTIONS_FK01");
					entity.Property((SpdStepsTransactions e) => e.Id).HasColumnName("ID");
					entity.Property((SpdStepsTransactions e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SpdStepsTransactions e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SpdStepsTransactions e) => e.IntegrationId).HasColumnName("INTEGRATION_ID");
					entity.Property((SpdStepsTransactions e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SpdStepsTransactions e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SpdStepsTransactions e) => e.Order).HasColumnName("ORDER");
					entity.Property((SpdStepsTransactions e) => e.StepId).HasColumnName("STEP_ID");
					entity.Property((SpdStepsTransactions e) => e.TransactionType).HasColumnName("TRANSACTION_TYPE");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstIntegrations, SpdStepsTransactions>(entity.HasOne((SpdStepsTransactions d) => d.Integration).WithMany((SstIntegrations p) => p.SpdStepsTransactions).HasForeignKey((SpdStepsTransactions d) => d.IntegrationId), "SPD_STEPS_TRANSACTIONS_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SpdProductsSteps, SpdStepsTransactions>(entity.HasOne((SpdStepsTransactions d) => d.Step).WithMany((SpdProductsSteps p) => p.SpdStepsTransactions).HasForeignKey((SpdStepsTransactions d) => d.StepId), "SPD_STEPS_TRANSACTIONS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstAccounts> entity)
				{
					entity.ToTable("sst_accounts");
					entity.HasIndex((Expression<Func<SstAccounts, object>>)((SstAccounts e) => e.ClassId)).HasName("SST_ACCOUNTS_FK01");
					entity.HasIndex((Expression<Func<SstAccounts, object>>)((SstAccounts e) => e.CoverId)).HasName("SST_ACCOUNTS_FK03");
					entity.HasIndex((Expression<Func<SstAccounts, object>>)((SstAccounts e) => e.DiscountId)).HasName("SST_ACCOUNTS_FK05");
					entity.HasIndex((Expression<Func<SstAccounts, object>>)((SstAccounts e) => e.FeeId)).HasName("SST_ACCOUNTS_FK04");
					entity.HasIndex((Expression<Func<SstAccounts, object>>)((SstAccounts e) => e.ModuleCode)).HasName("SST_ACCOUNT_MPDULE_CODE_FK");
					entity.HasIndex((Expression<Func<SstAccounts, object>>)((SstAccounts e) => e.PolicyType)).HasName("SST_ACCOUNTS_FK02");
					entity.HasIndex((Expression<Func<SstAccounts, object>>)((SstAccounts e) => e.SystemId)).HasName("SST_ACCOUNT_SYSTEM_ID_FK");
					entity.Property((SstAccounts e) => e.Id).HasColumnName("ID");
					entity.Property((SstAccounts e) => e.Branch).HasColumnName("BRANCH");
					entity.Property((SstAccounts e) => e.BusinessType).HasColumnName("BUSINESS_TYPE");
					entity.Property((SstAccounts e) => e.ClassId).HasColumnName("CLASS_ID");
					entity.Property((SstAccounts e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstAccounts e) => e.CostCenter).HasColumnName("COST_CENTER");
					entity.Property((SstAccounts e) => e.CounterAccount).HasColumnName("COUNTER_ACCOUNT");
					entity.Property((SstAccounts e) => e.CoverId).HasColumnName("COVER_ID");
					entity.Property((SstAccounts e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstAccounts e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstAccounts e) => e.Currency).HasColumnName("CURRENCY").HasMaxLength(24)
						.IsUnicode(unicode: false);
					entity.Property((SstAccounts e) => e.DiscountId).HasColumnName("DISCOUNT_ID");
					entity.Property((SstAccounts e) => e.FeeId).HasColumnName("FEE_ID");
					entity.Property((SstAccounts e) => e.GlAccount).HasColumnName("GL_ACCOUNT");
					entity.Property((SstAccounts e) => e.GlRefundAccount).HasColumnName("GL_REFUND_ACCOUNT");
					entity.Property((SstAccounts e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstAccounts e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstAccounts e) => e.ModuleCode).HasColumnName("MODULE_CODE").HasMaxLength(15)
						.IsUnicode(unicode: false);
					entity.Property((SstAccounts e) => e.PolicyType).HasColumnName("POLICY_TYPE");
					entity.Property((SstAccounts e) => e.SystemId).HasColumnName("SYSTEM_ID");
					entity.Property((SstAccounts e) => e.TransactionType).HasColumnName("TRANSACTION_TYPE");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstAccounts>(entity.HasOne((SstAccounts d) => d.Class).WithMany((SstClasses p) => p.SstAccounts).HasForeignKey((SstAccounts d) => d.ClassId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_ACCOUNTS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstCoverTypes, SstAccounts>(entity.HasOne((SstAccounts d) => d.Cover).WithMany((SstCoverTypes p) => p.SstAccounts).HasForeignKey((SstAccounts d) => d.CoverId), "SST_ACCOUNTS_FK03");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyDiscounts, SstAccounts>(entity.HasOne((SstAccounts d) => d.Discount).WithMany((SstPolicyDiscounts p) => p.SstAccounts).HasForeignKey((SstAccounts d) => d.DiscountId), "SST_ACCOUNTS_FK05");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstFees, SstAccounts>(entity.HasOne((SstAccounts d) => d.Fee).WithMany((SstFees p) => p.SstAccounts).HasForeignKey((SstAccounts d) => d.FeeId), "SST_ACCOUNTS_FK04");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstModules, SstAccounts>(entity.HasOne((SstAccounts d) => d.ModuleCodeNavigation).WithMany((SstModules p) => p.SstAccounts).HasForeignKey((SstAccounts d) => d.ModuleCode), "SST_ACCOUNT_MPDULE_CODE_FK");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstAccounts>(entity.HasOne((SstAccounts d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstAccounts).HasForeignKey((SstAccounts d) => d.PolicyType), "SST_ACCOUNTS_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstAccounts>(entity.HasOne((SstAccounts d) => d.System).WithMany((SstSystems p) => p.SstAccounts).HasForeignKey((SstAccounts d) => d.SystemId), "SST_ACCOUNT_SYSTEM_ID_FK");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstActions> entity)
				{
					entity.ToTable("sst_actions");
					entity.HasIndex((Expression<Func<SstActions, object>>)((SstActions e) => e.RuleId)).HasName("SST_ACTIONS_FK01");
					entity.Property((SstActions e) => e.Id).HasColumnName("ID");
					entity.Property((SstActions e) => e.ActionType).HasColumnName("ACTION_TYPE");
					entity.Property((SstActions e) => e.ActionValue).HasColumnName("ACTION_VALUE").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstActions e) => e.AppliedOn).HasColumnName("APPLIED_ON");
					entity.Property((SstActions e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstActions e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstActions e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstActions e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstActions e) => e.NotificationId).HasColumnName("NOTIFICATION_ID");
					entity.Property((SstActions e) => e.Order).HasColumnName("ORDER");
					entity.Property((SstActions e) => e.RefComId).HasColumnName("REF_COM_ID");
					entity.Property((SstActions e) => e.RuleId).HasColumnName("RULE_ID");
					entity.Property((SstActions e) => e.StepId).HasColumnName("STEP_ID");
					entity.Property((SstActions e) => e.TargetAction).HasColumnName("TARGET_ACTION");
					entity.Property((SstActions e) => e.TargetId).HasColumnName("TARGET_ID");
					entity.Property((SstActions e) => e.TargetKey).HasColumnName("TARGET_KEY").HasMaxLength(500)
						.IsUnicode(unicode: false);
					entity.Property((SstActions e) => e.TargetParent).HasColumnName("TARGET_PARENT");
					entity.Property((SstActions e) => e.TargetType).HasColumnName("TARGET_TYPE").HasDefaultValueSql("0");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstRules, SstActions>(entity.HasOne((SstActions d) => d.Rule).WithMany((SstRules p) => p.SstActions).HasForeignKey((SstActions d) => d.RuleId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_ACTIONS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstAgentBookDetails> entity)
				{
					entity.ToTable("sst_agent_book_details");
					entity.HasIndex((Expression<Func<SstAgentBookDetails, object>>)((SstAgentBookDetails e) => e.ParentBookId)).HasName("SST_AGENT_BOOK_DETAILS_FK01");
					entity.Property((SstAgentBookDetails e) => e.Id).HasColumnName("ID");
					entity.Property((SstAgentBookDetails e) => e.AgentId).HasColumnName("AGENT_ID");
					entity.Property((SstAgentBookDetails e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstAgentBookDetails e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstAgentBookDetails e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstAgentBookDetails e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstAgentBookDetails e) => e.Notes).HasColumnName("NOTES").HasMaxLength(200)
						.IsUnicode(unicode: false);
					entity.Property((SstAgentBookDetails e) => e.PageDate).HasColumnName("PAGE_DATE");
					entity.Property((SstAgentBookDetails e) => e.PageNo).HasColumnName("PAGE_NO");
					entity.Property((SstAgentBookDetails e) => e.PageStatus).HasColumnName("PAGE_STATUS");
					entity.Property((SstAgentBookDetails e) => e.ParentBookId).HasColumnName("PARENT_BOOK_ID");
					entity.Property((SstAgentBookDetails e) => e.ReturnedDate).HasColumnName("RETURNED_DATE");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstAgentBooks, SstAgentBookDetails>(entity.HasOne((SstAgentBookDetails d) => d.ParentBook).WithMany((SstAgentBooks p) => p.SstAgentBookDetails).HasForeignKey((SstAgentBookDetails d) => d.ParentBookId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_AGENT_BOOK_DETAILS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstAgentBooks> entity)
				{
					entity.ToTable("sst_agent_books");
					entity.HasIndex((Expression<Func<SstAgentBooks, object>>)((SstAgentBooks e) => e.ClassId)).HasName("SST_AGENT_BOOKS_FK02");
					entity.HasIndex((Expression<Func<SstAgentBooks, object>>)((SstAgentBooks e) => e.PolicyType)).HasName("SST_AGENT_BOOKS_FK03");
					entity.HasIndex((Expression<Func<SstAgentBooks, object>>)((SstAgentBooks e) => e.SystemId)).HasName("SST_AGENT_BOOKS_FK01");
					entity.Property((SstAgentBooks e) => e.Id).HasColumnName("ID");
					entity.Property((SstAgentBooks e) => e.AgentBookStatus).HasColumnName("AGENT_BOOK_STATUS");
					entity.Property((SstAgentBooks e) => e.AgentId).HasColumnName("AGENT_ID");
					entity.Property((SstAgentBooks e) => e.AppliedTo).HasColumnName("APPLIED_TO");
					entity.Property((SstAgentBooks e) => e.BookDate).HasColumnName("BOOK_DATE");
					entity.Property((SstAgentBooks e) => e.BookNo).IsRequired().HasColumnName("BOOK_NO")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstAgentBooks e) => e.BranchId).HasColumnName("BRANCH_ID");
					entity.Property((SstAgentBooks e) => e.BusinessShare).HasColumnName("BUSINESS_SHARE");
					entity.Property((SstAgentBooks e) => e.CertificateType).HasColumnName("CERTIFICATE_TYPE");
					entity.Property((SstAgentBooks e) => e.ClassId).HasColumnName("CLASS_ID");
					entity.Property((SstAgentBooks e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstAgentBooks e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstAgentBooks e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstAgentBooks e) => e.DocumentType).HasColumnName("DOCUMENT_TYPE");
					entity.Property((SstAgentBooks e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstAgentBooks e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstAgentBooks e) => e.Notes).HasColumnName("NOTES").HasColumnType("longtext");
					entity.Property((SstAgentBooks e) => e.PageFrom).HasColumnName("PAGE_FROM");
					entity.Property((SstAgentBooks e) => e.PageTo).HasColumnName("PAGE_TO");
					entity.Property((SstAgentBooks e) => e.PolicyType).HasColumnName("POLICY_TYPE");
					entity.Property((SstAgentBooks e) => e.ReturnedDate).HasColumnName("RETURNED_DATE");
					entity.Property((SstAgentBooks e) => e.SystemId).HasColumnName("SYSTEM_ID");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstAgentBooks>(entity.HasOne((SstAgentBooks d) => d.Class).WithMany((SstClasses p) => p.SstAgentBooks).HasForeignKey((SstAgentBooks d) => d.ClassId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_AGENT_BOOKS_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstAgentBooks>(entity.HasOne((SstAgentBooks d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstAgentBooks).HasForeignKey((SstAgentBooks d) => d.PolicyType)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_AGENT_BOOKS_FK03");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstAgentBooks>(entity.HasOne((SstAgentBooks d) => d.System).WithMany((SstSystems p) => p.SstAgentBooks).HasForeignKey((SstAgentBooks d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_AGENT_BOOKS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstAgentCommissionTiers> entity)
				{
					entity.ToTable("sst_agent_commission_tiers");
					entity.HasIndex((Expression<Func<SstAgentCommissionTiers, object>>)((SstAgentCommissionTiers e) => e.AgentId)).HasName("SYS_C002285592");
					entity.HasIndex((Expression<Func<SstAgentCommissionTiers, object>>)((SstAgentCommissionTiers e) => e.ClassId)).HasName("SYS_C002285594");
					entity.HasIndex((Expression<Func<SstAgentCommissionTiers, object>>)((SstAgentCommissionTiers e) => e.CoverType)).HasName("SST_AGENT_COMMISSION_FK04");
					entity.HasIndex((Expression<Func<SstAgentCommissionTiers, object>>)((SstAgentCommissionTiers e) => e.LinkedAgentId)).HasName("SYS_C002285593");
					entity.HasIndex((Expression<Func<SstAgentCommissionTiers, object>>)((SstAgentCommissionTiers e) => e.PolicyType)).HasName("SYS_C002285595");
					entity.Property((SstAgentCommissionTiers e) => e.Id).HasColumnName("ID");
					entity.Property((SstAgentCommissionTiers e) => e.AgentId).HasColumnName("AGENT_ID");
					entity.Property((SstAgentCommissionTiers e) => e.ApplyOn).HasColumnName("APPLY_ON");
					entity.Property((SstAgentCommissionTiers e) => e.Branch).HasColumnName("BRANCH");
					entity.Property((SstAgentCommissionTiers e) => e.BusinessType).HasColumnName("BUSINESS_TYPE");
					entity.Property((SstAgentCommissionTiers e) => e.ClassId).HasColumnName("CLASS_ID");
					entity.Property((SstAgentCommissionTiers e) => e.CommAmount).HasColumnName("COMM_AMOUNT").HasColumnType("decimal(18,3)");
					entity.Property((SstAgentCommissionTiers e) => e.CommPer).HasColumnName("COMM_PER").HasColumnType("decimal(10,5)");
					entity.Property((SstAgentCommissionTiers e) => e.CoverType).HasColumnName("COVER_TYPE");
					entity.Property((SstAgentCommissionTiers e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstAgentCommissionTiers e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstAgentCommissionTiers e) => e.FinAgentId).HasColumnName("FIN_AGENT_ID");
					entity.Property((SstAgentCommissionTiers e) => e.FinAgentName).HasColumnName("FIN_AGENT_NAME").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstAgentCommissionTiers e) => e.IsEditable).HasColumnName("IS_EDITABLE").HasConversion<int>();
					entity.Property((SstAgentCommissionTiers e) => e.LapDurationFrom).HasColumnName("LAP_DURATION_FROM");
					entity.Property((SstAgentCommissionTiers e) => e.LapDurationTo).HasColumnName("LAP_DURATION_TO");
					entity.Property((SstAgentCommissionTiers e) => e.LinkedAgentId).HasColumnName("LINKED_AGENT_ID");
					entity.Property((SstAgentCommissionTiers e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstAgentCommissionTiers e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstAgentCommissionTiers e) => e.PolDurationFrom).HasColumnName("POL_DURATION_FROM");
					entity.Property((SstAgentCommissionTiers e) => e.PolDurationTo).HasColumnName("POL_DURATION_TO");
					entity.Property((SstAgentCommissionTiers e) => e.PolicyType).HasColumnName("POLICY_TYPE");
					entity.Property((SstAgentCommissionTiers e) => e.Position).HasColumnName("POSITION");
					entity.Property((SstAgentCommissionTiers e) => e.ProductType).HasColumnName("PRODUCT_TYPE");
					entity.Property((SstAgentCommissionTiers e) => e.SiFrom).HasColumnName("SI_FROM").HasColumnType("decimal(18,3)");
					entity.Property((SstAgentCommissionTiers e) => e.SiTo).HasColumnName("SI_TO").HasColumnType("decimal(18,3)");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstAgents, SstAgentCommissionTiers>(entity.HasOne((SstAgentCommissionTiers d) => d.Agent).WithMany((SstAgents p) => p.SstAgentCommissionTiersAgent).HasForeignKey((SstAgentCommissionTiers d) => d.AgentId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C002285592");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstAgentCommissionTiers>(entity.HasOne((SstAgentCommissionTiers d) => d.Class).WithMany((SstClasses p) => p.SstAgentCommissionTiers).HasForeignKey((SstAgentCommissionTiers d) => d.ClassId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C002285594");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstCoverTypes, SstAgentCommissionTiers>(entity.HasOne((SstAgentCommissionTiers d) => d.CoverTypeNavigation).WithMany((SstCoverTypes p) => p.SstAgentCommissionTiers).HasForeignKey((SstAgentCommissionTiers d) => d.CoverType), "SST_AGENT_COMMISSION_FK04");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstAgents, SstAgentCommissionTiers>(entity.HasOne((SstAgentCommissionTiers d) => d.LinkedAgent).WithMany((SstAgents p) => p.SstAgentCommissionTiersLinkedAgent).HasForeignKey((SstAgentCommissionTiers d) => d.LinkedAgentId), "SYS_C002285593");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstAgentCommissionTiers>(entity.HasOne((SstAgentCommissionTiers d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstAgentCommissionTiers).HasForeignKey((SstAgentCommissionTiers d) => d.PolicyType), "SYS_C002285595");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstAgentOffices> entity)
				{
					entity.ToTable("sst_agent_offices");
					entity.HasIndex((Expression<Func<SstAgentOffices, object>>)((SstAgentOffices e) => e.AgentId)).HasName("SYS_C002285578");
					entity.HasIndex((Expression<Func<SstAgentOffices, object>>)((SstAgentOffices e) => e.ClassId)).HasName("SYS_C002285580");
					entity.HasIndex((Expression<Func<SstAgentOffices, object>>)((SstAgentOffices e) => e.OfficeId)).HasName("SYS_C002285579");
					entity.HasIndex((Expression<Func<SstAgentOffices, object>>)((SstAgentOffices e) => e.PolicyType)).HasName("SYS_C002285581");
					entity.Property((SstAgentOffices e) => e.Id).HasColumnName("ID");
					entity.Property((SstAgentOffices e) => e.AgentId).HasColumnName("AGENT_ID");
					entity.Property((SstAgentOffices e) => e.BusinessType).HasColumnName("BUSINESS_TYPE");
					entity.Property((SstAgentOffices e) => e.ClassId).HasColumnName("CLASS_ID");
					entity.Property((SstAgentOffices e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstAgentOffices e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstAgentOffices e) => e.EffectiveDate).HasColumnName("EFFECTIVE_DATE");
					entity.Property((SstAgentOffices e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstAgentOffices e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstAgentOffices e) => e.OfficeId).HasColumnName("OFFICE_ID");
					entity.Property((SstAgentOffices e) => e.PolicyType).HasColumnName("POLICY_TYPE");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstAgents, SstAgentOffices>(entity.HasOne((SstAgentOffices d) => d.Agent).WithMany((SstAgents p) => p.SstAgentOffices).HasForeignKey((SstAgentOffices d) => d.AgentId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C002285578");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstAgentOffices>(entity.HasOne((SstAgentOffices d) => d.Class).WithMany((SstClasses p) => p.SstAgentOffices).HasForeignKey((SstAgentOffices d) => d.ClassId), "SYS_C002285580");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstOffices, SstAgentOffices>(entity.HasOne((SstAgentOffices d) => d.Office).WithMany((SstOffices p) => p.SstAgentOffices).HasForeignKey((SstAgentOffices d) => d.OfficeId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C002285579");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstAgentOffices>(entity.HasOne((SstAgentOffices d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstAgentOffices).HasForeignKey((SstAgentOffices d) => d.PolicyType), "SYS_C002285581");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstAgentStructures> entity)
				{
					entity.ToTable("sst_agent_structures");
					entity.HasIndex((Expression<Func<SstAgentStructures, object>>)((SstAgentStructures e) => e.BusinessChannel)).HasName("SST_AGENT_STRUCTURES_FK02");
					entity.HasIndex((Expression<Func<SstAgentStructures, object>>)((SstAgentStructures e) => e.ParentId)).HasName("SST_AGENT_STRUCTURES_FK01");
					entity.Property((SstAgentStructures e) => e.Id).HasColumnName("ID");
					entity.Property((SstAgentStructures e) => e.BusinessChannel).HasColumnName("BUSINESS_CHANNEL");
					entity.Property((SstAgentStructures e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstAgentStructures e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstAgentStructures e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstAgentStructures e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstAgentStructures e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstAgentStructures e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstAgentStructures e) => e.Name2).HasColumnName("NAME2").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstAgentStructures e) => e.ParentId).HasColumnName("PARENT_ID");
					entity.Property((SstAgentStructures e) => e.ValidFrom).HasColumnName("VALID_FROM");
					entity.Property((SstAgentStructures e) => e.ValidTo).HasColumnName("VALID_TO");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstBusinessChannels, SstAgentStructures>(entity.HasOne((SstAgentStructures d) => d.BusinessChannelNavigation).WithMany((SstBusinessChannels p) => p.SstAgentStructures).HasForeignKey((SstAgentStructures d) => d.BusinessChannel), "SST_AGENT_STRUCTURES_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstAgentStructures, SstAgentStructures>(entity.HasOne((SstAgentStructures d) => d.Parent).WithMany((SstAgentStructures p) => p.InverseParent).HasForeignKey((SstAgentStructures d) => d.ParentId), "SST_AGENT_STRUCTURES_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstAgents> entity)
				{
					entity.ToTable("sst_agents");
					entity.HasIndex((Expression<Func<SstAgents, object>>)((SstAgents e) => e.ChannelType)).HasName("SYS_C002285570");
					entity.HasIndex((Expression<Func<SstAgents, object>>)((SstAgents e) => e.CommStructureId)).HasName("SYS_C002285569");
					entity.HasIndex((Expression<Func<SstAgents, object>>)((SstAgents e) => e.ModificationUser)).HasName("MODIFICATION_USER_UNIQUE").IsUnique();
					entity.HasIndex((Expression<Func<SstAgents, object>>)((SstAgents e) => e.Position)).HasName("SYS_C002285571");
					entity.HasIndex((Expression<Func<SstAgents, object>>)((SstAgents e) => e.SystemId)).HasName("SYS_C002285568");
					entity.Property((SstAgents e) => e.Id).HasColumnName("ID");
					entity.Property((SstAgents e) => e.AchievementType).HasColumnName("ACHIEVEMENT_TYPE");
					entity.Property((SstAgents e) => e.AgentType).HasColumnName("AGENT_TYPE");
					entity.Property((SstAgents e) => e.BranchId).HasColumnName("BRANCH_ID");
					entity.Property((SstAgents e) => e.CalculationBase).HasColumnName("CALCULATION_BASE");
					entity.Property((SstAgents e) => e.ChannelType).HasColumnName("CHANNEL_TYPE");
					entity.Property((SstAgents e) => e.CommStructureId).HasColumnName("COMM_STRUCTURE_ID");
					entity.Property((SstAgents e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstAgents e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstAgents e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstAgents e) => e.DataAccordance).HasColumnName("DATA_ACCORDANCE");
					entity.Property((SstAgents e) => e.EffectiveDate).HasColumnName("EFFECTIVE_DATE");
					entity.Property((SstAgents e) => e.ExpiryDate).HasColumnName("EXPIRY_DATE");
					entity.Property((SstAgents e) => e.FinAgentId).HasColumnName("FIN_AGENT_ID");
					entity.Property((SstAgents e) => e.FinAgentName).HasColumnName("FIN_AGENT_NAME").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstAgents e) => e.FinDirectMngr).HasColumnName("FIN_DIRECT_MNGR");
					entity.Property((SstAgents e) => e.FinDirectMngrName).HasColumnName("FIN_DIRECT_MNGR_NAME").HasMaxLength(120)
						.IsUnicode(unicode: false);
					entity.Property((SstAgents e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstAgents e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstAgents e) => e.Position).HasColumnName("POSITION");
					entity.Property((SstAgents e) => e.RegularPayemntTerm).HasColumnName("REGULAR_PAYEMNT_TERM");
					entity.Property((SstAgents e) => e.Status).HasColumnName("STATUS").HasColumnType("tinyint(1)")
						.HasConversion<int>();
					entity.Property((SstAgents e) => e.SystemId).HasColumnName("SYSTEM_ID");
					entity.Property((SstAgents e) => e.Target).HasColumnName("TARGET").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstAgents e) => e.TargetInclusion).HasColumnName("TARGET_INCLUSION");
					entity.Property((SstAgents e) => e.TermBasis).HasColumnName("TERM_BASIS");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstBusinessChannels, SstAgents>(entity.HasOne((SstAgents d) => d.ChannelTypeNavigation).WithMany((SstBusinessChannels p) => p.SstAgents).HasForeignKey((SstAgents d) => d.ChannelType)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C002285570");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstCommissionStructure, SstAgents>(entity.HasOne((SstAgents d) => d.CommStructure).WithMany((SstCommissionStructure p) => p.SstAgents).HasForeignKey((SstAgents d) => d.CommStructureId), "SYS_C002285569");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstAgentStructures, SstAgents>(entity.HasOne((SstAgents d) => d.PositionNavigation).WithMany((SstAgentStructures p) => p.SstAgents).HasForeignKey((SstAgents d) => d.Position), "SYS_C002285571");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstAgents>(entity.HasOne((SstAgents d) => d.System).WithMany((SstSystems p) => p.SstAgents).HasForeignKey((SstAgents d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C002285568");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstAlerts> entity)
				{
					entity.ToTable("sst_alerts");
					entity.HasIndex((Expression<Func<SstAlerts, object>>)((SstAlerts e) => e.SystemId)).HasName("SST_ALERTS_FK01");
					entity.Property((SstAlerts e) => e.Id).HasColumnName("ID");
					entity.Property((SstAlerts e) => e.Color).HasColumnName("COLOR").HasMaxLength(58)
						.IsUnicode(unicode: false);
					entity.Property((SstAlerts e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstAlerts e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstAlerts e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstAlerts e) => e.Date).HasColumnName("DATE_");
					entity.Property((SstAlerts e) => e.Icon).HasColumnName("ICON").HasMaxLength(58)
						.IsUnicode(unicode: false);
					entity.Property((SstAlerts e) => e.Image).HasColumnName("IMAGE").HasMaxLength(124)
						.IsUnicode(unicode: false);
					entity.Property((SstAlerts e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstAlerts e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstAlerts e) => e.Name).HasColumnName("NAME").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstAlerts e) => e.Name2).HasColumnName("NAME2").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstAlerts e) => e.Notes).HasColumnName("NOTES").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstAlerts e) => e.SystemId).HasColumnName("SYSTEM_ID");
					entity.Property((SstAlerts e) => e.Type).HasColumnName("TYPE");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstAlerts>(entity.HasOne((SstAlerts d) => d.System).WithMany((SstSystems p) => p.SstAlerts).HasForeignKey((SstAlerts d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_ALERTS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstAnswers> entity)
				{
					entity.ToTable("sst_answers");
					entity.HasIndex((Expression<Func<SstAnswers, object>>)((SstAnswers e) => e.QuestDetailId)).HasName("SYS_C002285375");
					entity.Property((SstAnswers e) => e.Id).HasColumnName("ID");
					entity.Property((SstAnswers e) => e.Action).HasColumnName("ACTION");
					entity.Property((SstAnswers e) => e.AdjustmentRate).HasColumnName("ADJUSTMENT_RATE").HasColumnType("decimal(10,5)");
					entity.Property((SstAnswers e) => e.ComparisonValues).HasColumnName("COMPARISON_VALUES").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstAnswers e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstAnswers e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstAnswers e) => e.DiscountAmt).HasColumnName("DISCOUNT_AMT").HasColumnType("decimal(18,3)");
					entity.Property((SstAnswers e) => e.DiscountPer).HasColumnName("DISCOUNT_PER").HasColumnType("decimal(10,5)");
					entity.Property((SstAnswers e) => e.Editable).HasColumnName("EDITABLE");
					entity.Property((SstAnswers e) => e.ExcessPer).HasColumnName("EXCESS_PER").HasColumnType("decimal(10,5)");
					entity.Property((SstAnswers e) => e.LoadingAmt).HasColumnName("LOADING_AMT").HasColumnType("decimal(18,5)");
					entity.Property((SstAnswers e) => e.LoadingPer).HasColumnName("LOADING_PER").HasColumnType("decimal(10,5)");
					entity.Property((SstAnswers e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstAnswers e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstAnswers e) => e.NrpAmt).HasColumnName("NRP_AMT").HasColumnType("decimal(18,3)");
					entity.Property((SstAnswers e) => e.NrpPer).HasColumnName("NRP_PER").HasColumnType("decimal(10,5)");
					entity.Property((SstAnswers e) => e.Operator).HasColumnName("OPERATOR");
					entity.Property((SstAnswers e) => e.QuestDetailId).HasColumnName("QUEST_DETAIL_ID");
					entity.Property((SstAnswers e) => e.Target).HasColumnName("TARGET").HasMaxLength(500)
						.IsUnicode(unicode: false);
					entity.Property((SstAnswers e) => e.ToComparisonValues).HasColumnName("TO_COMPARISON_VALUES").HasMaxLength(255)
						.IsUnicode(unicode: false);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstQuestDetails, SstAnswers>(entity.HasOne((SstAnswers d) => d.QuestDetail).WithMany((SstQuestDetails p) => p.SstAnswers).HasForeignKey((SstAnswers d) => d.QuestDetailId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C002285375");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstBusinessChannels> entity)
				{
					entity.ToTable("sst_business_channels");
					entity.HasIndex((Expression<Func<SstBusinessChannels, object>>)((SstBusinessChannels e) => e.SystemId)).HasName("SST_BUSINESS_CHANNELS_FK01");
					entity.Property((SstBusinessChannels e) => e.Id).HasColumnName("ID");
					entity.Property((SstBusinessChannels e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstBusinessChannels e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstBusinessChannels e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstBusinessChannels e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstBusinessChannels e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstBusinessChannels e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstBusinessChannels e) => e.Name2).HasColumnName("NAME2").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstBusinessChannels e) => e.Order).HasColumnName("ORDER");
					entity.Property((SstBusinessChannels e) => e.SystemId).HasColumnName("SYSTEM_ID");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstBusinessChannels>(entity.HasOne((SstBusinessChannels d) => d.System).WithMany((SstSystems p) => p.SstBusinessChannels).HasForeignKey((SstBusinessChannels d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_BUSINESS_CHANNELS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstChannelPlans> entity)
				{
					entity.ToTable("sst_channel_plans");
					entity.HasIndex((Expression<Func<SstChannelPlans, object>>)((SstChannelPlans e) => e.BusinessChannel)).HasName("SST_CHANNEL_PLANS_FK01");
					entity.HasIndex((Expression<Func<SstChannelPlans, object>>)((SstChannelPlans e) => e.PolicyType)).HasName("SST_CHANNEL_PLANS_FK02");
					entity.Property((SstChannelPlans e) => e.Id).HasColumnName("ID");
					entity.Property((SstChannelPlans e) => e.BusinessChannel).HasColumnName("BUSINESS_CHANNEL");
					entity.Property((SstChannelPlans e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstChannelPlans e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstChannelPlans e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstChannelPlans e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstChannelPlans e) => e.PolicyType).HasColumnName("POLICY_TYPE");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstBusinessChannels, SstChannelPlans>(entity.HasOne((SstChannelPlans d) => d.BusinessChannelNavigation).WithMany((SstBusinessChannels p) => p.SstChannelPlans).HasForeignKey((SstChannelPlans d) => d.BusinessChannel)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_CHANNEL_PLANS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstChannelPlans>(entity.HasOne((SstChannelPlans d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstChannelPlans).HasForeignKey((SstChannelPlans d) => d.PolicyType)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_CHANNEL_PLANS_FK02");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstChannelTypes> entity)
				{
					entity.ToTable("sst_channel_types");
					entity.HasIndex((Expression<Func<SstChannelTypes, object>>)((SstChannelTypes e) => e.BusinessChannel)).HasName("SST_CHANNEL_TYPES_FK01");
					entity.HasIndex((Expression<Func<SstChannelTypes, object>>)((SstChannelTypes e) => e.CustomerType)).HasName("SST_CHANNEL_TYPES_FK02");
					entity.Property((SstChannelTypes e) => e.Id).HasColumnName("ID");
					entity.Property((SstChannelTypes e) => e.BusinessChannel).HasColumnName("BUSINESS_CHANNEL");
					entity.Property((SstChannelTypes e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstChannelTypes e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstChannelTypes e) => e.CustomerType).HasColumnName("CUSTOMER_TYPE");
					entity.Property((SstChannelTypes e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstChannelTypes e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstBusinessChannels, SstChannelTypes>(entity.HasOne((SstChannelTypes d) => d.BusinessChannelNavigation).WithMany((SstBusinessChannels p) => p.SstChannelTypes).HasForeignKey((SstChannelTypes d) => d.BusinessChannel)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_CHANNEL_TYPES_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstCustomerTypes, SstChannelTypes>(entity.HasOne((SstChannelTypes d) => d.CustomerTypeNavigation).WithMany((SstCustomerTypes p) => p.SstChannelTypes).HasForeignKey((SstChannelTypes d) => d.CustomerType)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_CHANNEL_TYPES_FK02");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstClaimDiscounts> entity)
				{
					entity.ToTable("sst_claim_discounts");
					entity.HasIndex((Expression<Func<SstClaimDiscounts, object>>)((SstClaimDiscounts e) => e.ClassId)).HasName("SST_CLAIM_DISCOUNTS_FK02");
					entity.HasIndex((Expression<Func<SstClaimDiscounts, object>>)((SstClaimDiscounts e) => e.DiscountId)).HasName("SST_CLAIM_DISCOUNTS_FK01");
					entity.HasIndex((Expression<Func<SstClaimDiscounts, object>>)((SstClaimDiscounts e) => e.PolicyType)).HasName("SST_CLAIM_DISCOUNTS_FK03");
					entity.Property((SstClaimDiscounts e) => e.Id).HasColumnName("ID");
					entity.Property((SstClaimDiscounts e) => e.AfterClaimPercent).HasColumnName("AFTER_CLAIM_PERCENT").HasColumnType("decimal(9,3)");
					entity.Property((SstClaimDiscounts e) => e.Amount).HasColumnName("AMOUNT").HasColumnType("decimal(9,3)");
					entity.Property((SstClaimDiscounts e) => e.ClaimYearsFrom).HasColumnName("CLAIM_YEARS_FROM");
					entity.Property((SstClaimDiscounts e) => e.ClaimYearsTo).HasColumnName("CLAIM_YEARS_TO");
					entity.Property((SstClaimDiscounts e) => e.ClassId).HasColumnName("CLASS_ID");
					entity.Property((SstClaimDiscounts e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstClaimDiscounts e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstClaimDiscounts e) => e.DiscountId).HasColumnName("DISCOUNT_ID");
					entity.Property((SstClaimDiscounts e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstClaimDiscounts e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstClaimDiscounts e) => e.Percent).HasColumnName("PERCENT").HasColumnType("decimal(9,3)");
					entity.Property((SstClaimDiscounts e) => e.PolicyType).HasColumnName("POLICY_TYPE");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstClaimDiscounts>(entity.HasOne((SstClaimDiscounts d) => d.Class).WithMany((SstClasses p) => p.SstClaimDiscounts).HasForeignKey((SstClaimDiscounts d) => d.ClassId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_CLAIM_DISCOUNTS_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstDiscounts, SstClaimDiscounts>(entity.HasOne((SstClaimDiscounts d) => d.Discount).WithMany((SstDiscounts p) => p.SstClaimDiscounts).HasForeignKey((SstClaimDiscounts d) => d.DiscountId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_CLAIM_DISCOUNTS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstClaimDiscounts>(entity.HasOne((SstClaimDiscounts d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstClaimDiscounts).HasForeignKey((SstClaimDiscounts d) => d.PolicyType), "SST_CLAIM_DISCOUNTS_FK03");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstClasses> entity)
				{
					entity.ToTable("sst_classes");
					entity.HasIndex((Expression<Func<SstClasses, object>>)((SstClasses e) => e.SystemId)).HasName("SST_CLASSES_FK01");
					entity.Property((SstClasses e) => e.Id).HasColumnName("ID");
					entity.Property((SstClasses e) => e.BusinessType).HasColumnName("BUSINESS_TYPE");
					entity.Property((SstClasses e) => e.Code).IsRequired().HasColumnName("CODE")
						.HasMaxLength(6)
						.IsUnicode(unicode: false);
					entity.Property((SstClasses e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstClasses e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstClasses e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstClasses e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstClasses e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstClasses e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstClasses e) => e.Name2).HasColumnName("NAME2").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstClasses e) => e.SystemId).HasColumnName("SYSTEM_ID");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstClasses>(entity.HasOne((SstClasses d) => d.System).WithMany((SstSystems p) => p.SstClasses).HasForeignKey((SstClasses d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_CLASSES_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstClauses> entity)
				{
					entity.ToTable("sst_clauses");
					entity.HasIndex((Expression<Func<SstClauses, object>>)((SstClauses e) => e.ClassId)).HasName("SST_CLAUSES_FK01");
					entity.HasIndex((Expression<Func<SstClauses, object>>)((SstClauses e) => e.PolicyType)).HasName("SST_CLAUSES_FK02");
					entity.HasIndex((Expression<Func<SstClauses, object>>)((SstClauses e) => e.SystemId)).HasName("SST_CLAUSES_FK03");
					entity.Property((SstClauses e) => e.Id).HasColumnName("ID");
					entity.Property((SstClauses e) => e.AutoAdd).HasColumnName("AUTO_ADD");
					entity.Property((SstClauses e) => e.ClassId).HasColumnName("CLASS_ID");
					entity.Property((SstClauses e) => e.Code).HasColumnName("CODE").HasMaxLength(10)
						.IsUnicode(unicode: false);
					entity.Property((SstClauses e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstClauses e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstClauses e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstClauses e) => e.MarineClause).HasColumnName("MARINE_CLAUSE");
					entity.Property((SstClauses e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstClauses e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstClauses e) => e.MrConveyanceType).HasColumnName("MR_CONVEYANCE_TYPE");
					entity.Property((SstClauses e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstClauses e) => e.Name2).HasColumnName("NAME2").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstClauses e) => e.PolicyType).HasColumnName("POLICY_TYPE");
					entity.Property((SstClauses e) => e.Status).HasColumnName("STATUS");
					entity.Property((SstClauses e) => e.SystemId).HasColumnName("SYSTEM_ID");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstClauses>(entity.HasOne((SstClauses d) => d.Class).WithMany((SstClasses p) => p.SstClauses).HasForeignKey((SstClauses d) => d.ClassId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_CLAUSES_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstClauses>(entity.HasOne((SstClauses d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstClauses).HasForeignKey((SstClauses d) => d.PolicyType), "SST_CLAUSES_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstClauses>(entity.HasOne((SstClauses d) => d.System).WithMany((SstSystems p) => p.SstClauses).HasForeignKey((SstClauses d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_CLAUSES_FK03");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstClausesDetails> entity)
				{
					entity.ToTable("sst_clauses_details");
					entity.HasIndex((Expression<Func<SstClausesDetails, object>>)((SstClausesDetails e) => e.ClauseId)).HasName("SST_CLAUSES_DETAILS_FK01");
					entity.Property((SstClausesDetails e) => e.Id).HasColumnName("ID");
					entity.Property((SstClausesDetails e) => e.AgentId).HasColumnName("AGENT_ID");
					entity.Property((SstClausesDetails e) => e.AgentName).HasColumnName("AGENT_NAME").HasMaxLength(2048)
						.IsUnicode(unicode: false);
					entity.Property((SstClausesDetails e) => e.ClauseId).HasColumnName("CLAUSE_ID");
					entity.Property((SstClausesDetails e) => e.ClauseType).HasColumnName("CLAUSE_TYPE");
					entity.Property((SstClausesDetails e) => e.CoverType).HasColumnName("COVER_TYPE");
					entity.Property((SstClausesDetails e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstClausesDetails e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstClausesDetails e) => e.Description).IsRequired().HasColumnName("DESCRIPTION")
						.HasColumnType("longtext");
					entity.Property((SstClausesDetails e) => e.Description2).HasColumnName("DESCRIPTION2").HasColumnType("longtext");
					entity.Property((SstClausesDetails e) => e.DiscountType).HasColumnName("DISCOUNT_TYPE");
					entity.Property((SstClausesDetails e) => e.EffectiveDate).HasColumnName("EFFECTIVE_DATE");
					entity.Property((SstClausesDetails e) => e.ExpiryDate).HasColumnName("EXPIRY_DATE");
					entity.Property((SstClausesDetails e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstClausesDetails e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstClausesDetails e) => e.Order).HasColumnName("ORDER");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClauses, SstClausesDetails>(entity.HasOne((SstClausesDetails d) => d.Clause).WithMany((SstClauses p) => p.SstClausesDetails).HasForeignKey((SstClausesDetails d) => d.ClauseId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_CLAUSES_DETAILS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstClosingPeriods> entity)
				{
					entity.ToTable("sst_closing_periods");
					entity.HasIndex((Expression<Func<SstClosingPeriods, object>>)((SstClosingPeriods e) => e.ClassId)).HasName("SST_CLOSING_PERIODS_FK02");
					entity.HasIndex((Expression<Func<SstClosingPeriods, object>>)((SstClosingPeriods e) => e.PolicyType)).HasName("SST_CLOSING_PERIODS_FK03");
					entity.HasIndex((Expression<Func<SstClosingPeriods, object>>)((SstClosingPeriods e) => e.SystemId)).HasName("SST_CLOSING_FK01");
					entity.Property((SstClosingPeriods e) => e.Id).HasColumnName("ID");
					entity.Property((SstClosingPeriods e) => e.BranchId).HasColumnName("BRANCH_ID");
					entity.Property((SstClosingPeriods e) => e.ClassId).HasColumnName("CLASS_ID");
					entity.Property((SstClosingPeriods e) => e.ClosingDate).HasColumnName("CLOSING_DATE");
					entity.Property((SstClosingPeriods e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstClosingPeriods e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstClosingPeriods e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstClosingPeriods e) => e.FromDate).HasColumnName("FROM_DATE");
					entity.Property((SstClosingPeriods e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstClosingPeriods e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstClosingPeriods e) => e.ModuleCode).HasColumnName("MODULE_CODE").HasMaxLength(15)
						.IsUnicode(unicode: false);
					entity.Property((SstClosingPeriods e) => e.PolicyType).HasColumnName("POLICY_TYPE");
					entity.Property((SstClosingPeriods e) => e.SystemId).HasColumnName("SYSTEM_ID");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstClosingPeriods>(entity.HasOne((SstClosingPeriods d) => d.Class).WithMany((SstClasses p) => p.SstClosingPeriods).HasForeignKey((SstClosingPeriods d) => d.ClassId), "SST_CLOSING_PERIODS_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstClosingPeriods>(entity.HasOne((SstClosingPeriods d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstClosingPeriods).HasForeignKey((SstClosingPeriods d) => d.PolicyType), "SST_CLOSING_PERIODS_FK03");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstClosingPeriods>(entity.HasOne((SstClosingPeriods d) => d.System).WithMany((SstSystems p) => p.SstClosingPeriods).HasForeignKey((SstClosingPeriods d) => d.SystemId), "SST_CLOSING_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstCodes> entity)
				{
					entity.ToTable("sst_codes");
					entity.HasIndex((Expression<Func<SstCodes, object>>)((SstCodes e) => e.CodeId)).HasName("SST_CODES_FK01");
					entity.HasIndex((Expression<Func<SstCodes, object>>)((SstCodes e) => e.ModuleCode)).HasName("SST_CODES_FK02");
					entity.HasIndex((Expression<Func<SstCodes, object>>)((SstCodes e) => e.SystemId)).HasName("SST_CODES_FK03");
					entity.Property((SstCodes e) => e.Id).HasColumnName("ID");
					entity.Property((SstCodes e) => e.CodeId).HasColumnName("CODE_ID");
					entity.Property((SstCodes e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstCodes e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstCodes e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstCodes e) => e.DomainId).HasColumnName("DOMAIN_ID");
					entity.Property((SstCodes e) => e.MajorCode).HasColumnName("MAJOR_CODE");
					entity.Property((SstCodes e) => e.MinorCode).HasColumnName("MINOR_CODE");
					entity.Property((SstCodes e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstCodes e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstCodes e) => e.ModuleCode).HasColumnName("MODULE_CODE").HasMaxLength(15)
						.IsUnicode(unicode: false);
					entity.Property((SstCodes e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstCodes e) => e.Name2).HasColumnName("NAME2").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstCodes e) => e.Notes).HasColumnName("NOTES").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstCodes e) => e.SystemId).HasColumnName("SYSTEM_ID");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstCodes, SstCodes>(entity.HasOne((SstCodes d) => d.Code).WithMany((SstCodes p) => p.InverseCode).HasForeignKey((SstCodes d) => d.CodeId), "SST_CODES_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstModules, SstCodes>(entity.HasOne((SstCodes d) => d.ModuleCodeNavigation).WithMany((SstModules p) => p.SstCodes).HasForeignKey((SstCodes d) => d.ModuleCode), "SST_CODES_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstCodes>(entity.HasOne((SstCodes d) => d.System).WithMany((SstSystems p) => p.SstCodes).HasForeignKey((SstCodes d) => d.SystemId), "SST_CODES_FK03");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstCommStructureBusiness> entity)
				{
					entity.ToTable("sst_comm_structure_business");
					entity.HasIndex((Expression<Func<SstCommStructureBusiness, object>>)((SstCommStructureBusiness e) => e.ClassId)).HasName("SYS_C002285555");
					entity.HasIndex((Expression<Func<SstCommStructureBusiness, object>>)((SstCommStructureBusiness e) => e.CommStructureId)).HasName("SYS_C002285554");
					entity.HasIndex((Expression<Func<SstCommStructureBusiness, object>>)((SstCommStructureBusiness e) => e.PolicyType)).HasName("SYS_C002285556");
					entity.Property((SstCommStructureBusiness e) => e.Id).HasColumnName("ID");
					entity.Property((SstCommStructureBusiness e) => e.AutoAdd).HasColumnName("AUTO_ADD").HasConversion<int>();
					entity.Property((SstCommStructureBusiness e) => e.BusinessType).HasColumnName("BUSINESS_TYPE");
					entity.Property((SstCommStructureBusiness e) => e.ClassId).HasColumnName("CLASS_ID");
					entity.Property((SstCommStructureBusiness e) => e.CommAmount).HasColumnName("COMM_AMOUNT").HasColumnType("decimal(18,3)");
					entity.Property((SstCommStructureBusiness e) => e.CommPer).HasColumnName("COMM_PER").HasColumnType("decimal(10,5)");
					entity.Property((SstCommStructureBusiness e) => e.CommStructureId).HasColumnName("COMM_STRUCTURE_ID");
					entity.Property((SstCommStructureBusiness e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstCommStructureBusiness e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstCommStructureBusiness e) => e.CustomerAccount).HasColumnName("CUSTOMER_ACCOUNT");
					entity.Property((SstCommStructureBusiness e) => e.DefaultCustomer).HasColumnName("DEFAULT_CUSTOMER");
					entity.Property((SstCommStructureBusiness e) => e.FinCustomerAccountName).HasColumnName("FIN_CUSTOMER_ACCOUNT_NAME").HasMaxLength(120)
						.IsUnicode(unicode: false);
					entity.Property((SstCommStructureBusiness e) => e.FinDefaultCustomerName).HasColumnName("FIN_DEFAULT_CUSTOMER_NAME").HasMaxLength(120)
						.IsUnicode(unicode: false);
					entity.Property((SstCommStructureBusiness e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstCommStructureBusiness e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstCommStructureBusiness e) => e.PolicyType).HasColumnName("POLICY_TYPE");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstCommStructureBusiness>(entity.HasOne((SstCommStructureBusiness d) => d.Class).WithMany((SstClasses p) => p.SstCommStructureBusiness).HasForeignKey((SstCommStructureBusiness d) => d.ClassId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C002285555");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstCommissionStructure, SstCommStructureBusiness>(entity.HasOne((SstCommStructureBusiness d) => d.CommStructure).WithMany((SstCommissionStructure p) => p.SstCommStructureBusiness).HasForeignKey((SstCommStructureBusiness d) => d.CommStructureId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C002285554");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstCommStructureBusiness>(entity.HasOne((SstCommStructureBusiness d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstCommStructureBusiness).HasForeignKey((SstCommStructureBusiness d) => d.PolicyType), "SYS_C002285556");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstCommissionDetails> entity)
				{
					entity.ToTable("sst_commission_details");
					entity.HasIndex((Expression<Func<SstCommissionDetails, object>>)((SstCommissionDetails e) => e.ClassId)).HasName("SST_COMMISSION_DETAILS_FK02");
					entity.HasIndex((Expression<Func<SstCommissionDetails, object>>)((SstCommissionDetails e) => e.CommissionId)).HasName("SST_COMMISSION_DETAILS_FK01");
					entity.HasIndex((Expression<Func<SstCommissionDetails, object>>)((SstCommissionDetails e) => e.PolicyType)).HasName("SST_COMMISSION_DETAILS_FK03");
					entity.Property((SstCommissionDetails e) => e.Id).HasColumnName("ID");
					entity.Property((SstCommissionDetails e) => e.Branch).HasColumnName("BRANCH");
					entity.Property((SstCommissionDetails e) => e.BusinesssChannel).HasColumnName("BUSINESSS_CHANNEL");
					entity.Property((SstCommissionDetails e) => e.CalculationBasis).HasColumnName("CALCULATION_BASIS");
					entity.Property((SstCommissionDetails e) => e.CalculationType).HasColumnName("CALCULATION_TYPE");
					entity.Property((SstCommissionDetails e) => e.ClassId).HasColumnName("CLASS_ID");
					entity.Property((SstCommissionDetails e) => e.CommissionId).HasColumnName("COMMISSION_ID");
					entity.Property((SstCommissionDetails e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstCommissionDetails e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstCommissionDetails e) => e.DataAccordance).HasColumnName("DATA_ACCORDANCE");
					entity.Property((SstCommissionDetails e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstCommissionDetails e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstCommissionDetails e) => e.PaymentTerms).HasColumnName("PAYMENT_TERMS");
					entity.Property((SstCommissionDetails e) => e.PolicyType).HasColumnName("POLICY_TYPE");
					entity.Property((SstCommissionDetails e) => e.Position).HasColumnName("POSITION");
					entity.Property((SstCommissionDetails e) => e.Target).HasColumnName("TARGET").HasColumnType("decimal(9,3)");
					entity.Property((SstCommissionDetails e) => e.TargetInclusion).HasColumnName("TARGET_INCLUSION");
					entity.Property((SstCommissionDetails e) => e.TargetType).HasColumnName("TARGET_TYPE");
					entity.Property((SstCommissionDetails e) => e.TermBasis).HasColumnName("TERM_BASIS");
					entity.Property((SstCommissionDetails e) => e.ValidFrom).HasColumnName("VALID_FROM");
					entity.Property((SstCommissionDetails e) => e.ValidTo).HasColumnName("VALID_TO");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstCommissionDetails>(entity.HasOne((SstCommissionDetails d) => d.Class).WithMany((SstClasses p) => p.SstCommissionDetails).HasForeignKey((SstCommissionDetails d) => d.ClassId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_COMMISSION_DETAILS_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstCommissionTypes, SstCommissionDetails>(entity.HasOne((SstCommissionDetails d) => d.Commission).WithMany((SstCommissionTypes p) => p.SstCommissionDetails).HasForeignKey((SstCommissionDetails d) => d.CommissionId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_COMMISSION_DETAILS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstCommissionDetails>(entity.HasOne((SstCommissionDetails d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstCommissionDetails).HasForeignKey((SstCommissionDetails d) => d.PolicyType), "SST_COMMISSION_DETAILS_FK03");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstCommissionStructure> entity)
				{
					entity.ToTable("sst_commission_structure");
					entity.HasIndex((Expression<Func<SstCommissionStructure, object>>)((SstCommissionStructure e) => e.CommStructureId)).HasName("SYS_C002285542");
					entity.HasIndex((Expression<Func<SstCommissionStructure, object>>)((SstCommissionStructure e) => e.SystemId)).HasName("SYS_C002285541");
					entity.Property((SstCommissionStructure e) => e.Id).HasColumnName("ID");
					entity.Property((SstCommissionStructure e) => e.AutoAdd).HasColumnName("AUTO_ADD").HasConversion<int>();
					entity.Property((SstCommissionStructure e) => e.CalculationBase).HasColumnName("CALCULATION_BASE");
					entity.Property((SstCommissionStructure e) => e.Category).HasColumnName("CATEGORY");
					entity.Property((SstCommissionStructure e) => e.CommStructureId).HasColumnName("COMM_STRUCTURE_ID");
					entity.Property((SstCommissionStructure e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstCommissionStructure e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstCommissionStructure e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstCommissionStructure e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstCommissionStructure e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstCommissionStructure e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstCommissionStructure e) => e.Name2).HasColumnName("NAME2").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstCommissionStructure e) => e.SystemId).HasColumnName("SYSTEM_ID");
					entity.Property((SstCommissionStructure e) => e.Type).HasColumnName("TYPE");
					entity.Property((SstCommissionStructure e) => e.YearBasis).HasColumnName("YEAR_BASIS");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstCommissionStructure, SstCommissionStructure>(entity.HasOne((SstCommissionStructure d) => d.CommStructure).WithMany((SstCommissionStructure p) => p.InverseCommStructure).HasForeignKey((SstCommissionStructure d) => d.CommStructureId), "SYS_C002285542");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstCommissionStructure>(entity.HasOne((SstCommissionStructure d) => d.System).WithMany((SstSystems p) => p.SstCommissionStructure).HasForeignKey((SstCommissionStructure d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C002285541");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstCommissionTiers> entity)
				{
					entity.ToTable("sst_commission_tiers");
					entity.HasIndex((Expression<Func<SstCommissionTiers, object>>)((SstCommissionTiers e) => e.CommissionDtlId)).HasName("SST_COMMISSION_TIERS_FK01");
					entity.Property((SstCommissionTiers e) => e.Id).HasColumnName("ID");
					entity.Property((SstCommissionTiers e) => e.AmountFrom).HasColumnName("AMOUNT_FROM").HasColumnType("decimal(9,3)");
					entity.Property((SstCommissionTiers e) => e.AmountTo).HasColumnName("AMOUNT_TO").HasColumnType("decimal(9,3)");
					entity.Property((SstCommissionTiers e) => e.CommAmount).HasColumnName("COMM_AMOUNT").HasColumnType("decimal(9,3)");
					entity.Property((SstCommissionTiers e) => e.CommPercent).HasColumnName("COMM_PERCENT").HasColumnType("decimal(9,3)");
					entity.Property((SstCommissionTiers e) => e.CommissionDtlId).HasColumnName("COMMISSION_DTL_ID");
					entity.Property((SstCommissionTiers e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstCommissionTiers e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstCommissionTiers e) => e.CustomerId).HasColumnName("CUSTOMER_ID");
					entity.Property((SstCommissionTiers e) => e.LapDurationFrom).HasColumnName("LAP_DURATION_FROM");
					entity.Property((SstCommissionTiers e) => e.LapDurationTo).HasColumnName("LAP_DURATION_TO");
					entity.Property((SstCommissionTiers e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstCommissionTiers e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstCommissionTiers e) => e.Notes).HasColumnName("NOTES").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstCommissionTiers e) => e.PolDurationFrom).HasColumnName("POL_DURATION_FROM");
					entity.Property((SstCommissionTiers e) => e.PolDurationTo).HasColumnName("POL_DURATION_TO");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstCommissionDetails, SstCommissionTiers>(entity.HasOne((SstCommissionTiers d) => d.CommissionDtl).WithMany((SstCommissionDetails p) => p.SstCommissionTiers).HasForeignKey((SstCommissionTiers d) => d.CommissionDtlId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_COMMISSION_TIERS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstCommissionTypes> entity)
				{
					entity.ToTable("sst_commission_types");
					entity.HasIndex((Expression<Func<SstCommissionTypes, object>>)((SstCommissionTypes e) => e.SystemId)).HasName("SST_COMMISSION_TYPES_FK01");
					entity.Property((SstCommissionTypes e) => e.Id).HasColumnName("ID");
					entity.Property((SstCommissionTypes e) => e.CommissionId).HasColumnName("COMMISSION_ID");
					entity.Property((SstCommissionTypes e) => e.CommissionType).HasColumnName("COMMISSION_TYPE");
					entity.Property((SstCommissionTypes e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstCommissionTypes e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstCommissionTypes e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstCommissionTypes e) => e.Impact).HasColumnName("IMPACT");
					entity.Property((SstCommissionTypes e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstCommissionTypes e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstCommissionTypes e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstCommissionTypes e) => e.Name2).HasColumnName("NAME2").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstCommissionTypes e) => e.Notes).HasColumnName("NOTES").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstCommissionTypes e) => e.SystemId).HasColumnName("SYSTEM_ID");
					entity.Property((SstCommissionTypes e) => e.YearBasis).HasColumnName("YEAR_BASIS");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstCommissionTypes>(entity.HasOne((SstCommissionTypes d) => d.System).WithMany((SstSystems p) => p.SstCommissionTypes).HasForeignKey((SstCommissionTypes d) => d.SystemId), "SST_COMMISSION_TYPES_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstComponents> entity)
				{
					entity.ToTable("sst_components");
					entity.Property((SstComponents e) => e.Id).HasColumnName("ID");
					entity.Property((SstComponents e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstComponents e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstComponents e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstComponents e) => e.FormType).HasColumnName("FORM_TYPE");
					entity.Property((SstComponents e) => e.Global).HasColumnName("GLOBAL");
					entity.Property((SstComponents e) => e.Icon).HasColumnName("ICON").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstComponents e) => e.LayoutType).HasColumnName("LAYOUT_TYPE");
					entity.Property((SstComponents e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstComponents e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstComponents e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstComponents e) => e.Name2).HasColumnName("NAME2").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstComponents e) => e.Notes).HasColumnName("NOTES").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstComponents e) => e.SystemId).HasColumnName("SYSTEM_ID");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstConditions> entity)
				{
					entity.ToTable("sst_conditions");
					entity.HasIndex((Expression<Func<SstConditions, object>>)((SstConditions e) => e.RuleId)).HasName("SST_CONDITIONS_FK01");
					entity.Property((SstConditions e) => e.Id).HasColumnName("ID");
					entity.Property((SstConditions e) => e.ConditionType).HasColumnName("CONDITION_TYPE").HasDefaultValueSql("1");
					entity.Property((SstConditions e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstConditions e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstConditions e) => e.Formula).HasColumnName("FORMULA").HasColumnType("longtext");
					entity.Property((SstConditions e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstConditions e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstConditions e) => e.Operator).HasColumnName("OPERATOR");
					entity.Property((SstConditions e) => e.OperatorType).HasColumnName("OPERATOR_TYPE");
					entity.Property((SstConditions e) => e.Order).HasColumnName("ORDER").HasDefaultValueSql("1");
					entity.Property((SstConditions e) => e.RefComId).HasColumnName("REF_COM_ID");
					entity.Property((SstConditions e) => e.ReferenceId).HasColumnName("REFERENCE_ID");
					entity.Property((SstConditions e) => e.ReferenceKey).HasColumnName("REFERENCE_KEY").HasMaxLength(500)
						.IsUnicode(unicode: false);
					entity.Property((SstConditions e) => e.ReferenceParent).HasColumnName("REFERENCE_PARENT");
					entity.Property((SstConditions e) => e.ReferenceType).HasColumnName("REFERENCE_TYPE");
					entity.Property((SstConditions e) => e.RuleId).HasColumnName("RULE_ID");
					entity.Property((SstConditions e) => e.StepId).HasColumnName("STEP_ID");
					entity.Property((SstConditions e) => e.Validator).HasColumnName("VALIDATOR");
					entity.Property((SstConditions e) => e.ValidatorValue).HasColumnName("VALIDATOR_VALUE").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstConditions e) => e.ValidatorValue2).HasColumnName("VALIDATOR_VALUE2").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstRules, SstConditions>(entity.HasOne((SstConditions d) => d.Rule).WithMany((SstRules p) => p.SstConditions).HasForeignKey((SstConditions d) => d.RuleId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_CONDITIONS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstContainers> entity)
				{
					entity.ToTable("sst_containers");
					entity.HasIndex((Expression<Func<SstContainers, object>>)((SstContainers e) => e.ComponentId)).HasName("SST_CONTAINERS_FK01");
					entity.Property((SstContainers e) => e.Id).HasColumnName("ID");
					entity.Property((SstContainers e) => e.ComponentId).HasColumnName("COMPONENT_ID");
					entity.Property((SstContainers e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstContainers e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstContainers e) => e.Key).HasColumnName("KEY").HasMaxLength(124)
						.IsUnicode(unicode: false);
					entity.Property((SstContainers e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstContainers e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstContainers e) => e.Name).HasColumnName("NAME").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstContainers e) => e.Name2).HasColumnName("NAME2").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstContainers e) => e.Notes).HasColumnName("NOTES").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstContainers e) => e.Order).HasColumnName("ORDER");
					entity.Property((SstContainers e) => e.RefContainerId).HasColumnName("REF_CONTAINER_ID");
					entity.Property((SstContainers e) => e.Type).HasColumnName("TYPE");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstComponents, SstContainers>(entity.HasOne((SstContainers d) => d.Component).WithMany((SstComponents p) => p.SstContainers).HasForeignKey((SstContainers d) => d.ComponentId), "SST_CONTAINERS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstCoreQuestionnaires> entity)
				{
					entity.ToTable("sst_core_questionnaires");
					entity.HasIndex((Expression<Func<SstCoreQuestionnaires, object>>)((SstCoreQuestionnaires e) => e.ClassId)).HasName("SST_CORE_QUESTIONNAIRES_FK02");
					entity.HasIndex((Expression<Func<SstCoreQuestionnaires, object>>)((SstCoreQuestionnaires e) => e.PolicyTypeId)).HasName("SST_CORE_QUESTIONNAIRES_FK03");
					entity.HasIndex((Expression<Func<SstCoreQuestionnaires, object>>)((SstCoreQuestionnaires e) => e.SystemId)).HasName("SST_CORE_QUESTIONNAIRES_FK01");
					entity.Property((SstCoreQuestionnaires e) => e.Id).HasColumnName("ID");
					entity.Property((SstCoreQuestionnaires e) => e.BusinessType).HasColumnName("BUSINESS_TYPE");
					entity.Property((SstCoreQuestionnaires e) => e.ClassId).HasColumnName("CLASS_ID");
					entity.Property((SstCoreQuestionnaires e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstCoreQuestionnaires e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstCoreQuestionnaires e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstCoreQuestionnaires e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstCoreQuestionnaires e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstCoreQuestionnaires e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(100)
						.IsUnicode(unicode: false);
					entity.Property((SstCoreQuestionnaires e) => e.Name2).HasColumnName("NAME2").HasMaxLength(100)
						.IsUnicode(unicode: false);
					entity.Property((SstCoreQuestionnaires e) => e.PolicyTypeId).HasColumnName("POLICY_TYPE_ID");
					entity.Property((SstCoreQuestionnaires e) => e.PostingAction).HasColumnName("POSTING_ACTION");
					entity.Property((SstCoreQuestionnaires e) => e.Status).HasColumnName("STATUS");
					entity.Property((SstCoreQuestionnaires e) => e.StatusDate).HasColumnName("STATUS_DATE");
					entity.Property((SstCoreQuestionnaires e) => e.SystemId).HasColumnName("SYSTEM_ID");
					entity.Property((SstCoreQuestionnaires e) => e.Usage).IsRequired().HasColumnName("USAGE")
						.HasMaxLength(100)
						.IsUnicode(unicode: false);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstCoreQuestionnaires>(entity.HasOne((SstCoreQuestionnaires d) => d.Class).WithMany((SstClasses p) => p.SstCoreQuestionnaires).HasForeignKey((SstCoreQuestionnaires d) => d.ClassId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_CORE_QUESTIONNAIRES_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstCoreQuestionnaires>(entity.HasOne((SstCoreQuestionnaires d) => d.PolicyType).WithMany((SstPolicyTypes p) => p.SstCoreQuestionnaires).HasForeignKey((SstCoreQuestionnaires d) => d.PolicyTypeId), "SST_CORE_QUESTIONNAIRES_FK03");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstCoreQuestionnaires>(entity.HasOne((SstCoreQuestionnaires d) => d.System).WithMany((SstSystems p) => p.SstCoreQuestionnaires).HasForeignKey((SstCoreQuestionnaires d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_CORE_QUESTIONNAIRES_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstCoverRatingTypes> entity)
				{
					entity.ToTable("sst_cover_rating_types");
					entity.HasIndex((Expression<Func<SstCoverRatingTypes, object>>)((SstCoverRatingTypes e) => e.CoverType)).HasName("SYS_C002285385");
					entity.Property((SstCoverRatingTypes e) => e.Id).HasColumnName("ID");
					entity.Property((SstCoverRatingTypes e) => e.ApplyAgentComm).HasColumnName("APPLY_AGENT_COMM").HasConversion<int>();
					entity.Property((SstCoverRatingTypes e) => e.ApplyPremium).HasColumnName("APPLY_PREMIUM").HasConversion<int>();
					entity.Property((SstCoverRatingTypes e) => e.CalcRef).HasColumnName("CALC_REF");
					entity.Property((SstCoverRatingTypes e) => e.ClassId).HasColumnName("CLASS_ID");
					entity.Property((SstCoverRatingTypes e) => e.CoverType).HasColumnName("COVER_TYPE");
					entity.Property((SstCoverRatingTypes e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstCoverRatingTypes e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstCoverRatingTypes e) => e.DedcutbleFrom).HasColumnName("DEDCUTBLE_FROM");
					entity.Property((SstCoverRatingTypes e) => e.EndorsemntRating).HasColumnName("ENDORSEMNT_RATING");
					entity.Property((SstCoverRatingTypes e) => e.IsActive).HasColumnName("IS_ACTIVE").HasConversion<int>();
					entity.Property((SstCoverRatingTypes e) => e.IsAutoAdd).HasColumnName("IS_AUTO_ADD").HasConversion<int>();
					entity.Property((SstCoverRatingTypes e) => e.IsBasicPremium).HasColumnName("IS_BASIC_PREMIUM").HasConversion<int>();
					entity.Property((SstCoverRatingTypes e) => e.IsDiscountable).HasColumnName("IS_DISCOUNTABLE").HasConversion<int>();
					entity.Property((SstCoverRatingTypes e) => e.IsEditable).HasColumnName("IS_EDITABLE").HasConversion<int>();
					entity.Property((SstCoverRatingTypes e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstCoverRatingTypes e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstCoverRatingTypes e) => e.PolicyType).HasColumnName("POLICY_TYPE");
					entity.Property((SstCoverRatingTypes e) => e.RateFraction).HasColumnName("RATE_FRACTION");
					entity.Property((SstCoverRatingTypes e) => e.RatingType).HasColumnName("RATING_TYPE");
					entity.Property((SstCoverRatingTypes e) => e.RoundTo).HasColumnName("ROUND_TO");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstCoverTypes, SstCoverRatingTypes>(entity.HasOne((SstCoverRatingTypes d) => d.CoverTypeNavigation).WithMany((SstCoverTypes p) => p.SstCoverRatingTypes).HasForeignKey((SstCoverRatingTypes d) => d.CoverType)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C002285385");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstCoverTypes> entity)
				{
					entity.ToTable("sst_cover_types");
					entity.HasIndex((Expression<Func<SstCoverTypes, object>>)((SstCoverTypes e) => e.ClassId)).HasName("SST_COVER_TYPES_FK02");
					entity.HasIndex((Expression<Func<SstCoverTypes, object>>)((SstCoverTypes e) => e.CoverId)).HasName("SST_COVER_TYPES_FK04");
					entity.HasIndex((Expression<Func<SstCoverTypes, object>>)((SstCoverTypes e) => e.PolicyType)).HasName("SST_COVER_TYPES_FK03");
					entity.HasIndex((Expression<Func<SstCoverTypes, object>>)((SstCoverTypes e) => e.SystemId)).HasName("SST_COVER_TYPES_FK01");
					entity.Property((SstCoverTypes e) => e.Id).HasColumnName("ID");
					entity.Property((SstCoverTypes e) => e.ClassId).HasColumnName("CLASS_ID");
					entity.Property((SstCoverTypes e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstCoverTypes e) => e.CoverId).HasColumnName("COVER_ID");
					entity.Property((SstCoverTypes e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstCoverTypes e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstCoverTypes e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstCoverTypes e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstCoverTypes e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstCoverTypes e) => e.Name2).HasColumnName("NAME2").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstCoverTypes e) => e.PolicyType).HasColumnName("POLICY_TYPE");
					entity.Property((SstCoverTypes e) => e.PremiumAmount).HasColumnName("PREMIUM_AMOUNT").HasColumnType("decimal(18,3)");
					entity.Property((SstCoverTypes e) => e.PremiumRate).HasColumnName("PREMIUM_RATE").HasColumnType("decimal(9,3)");
					entity.Property((SstCoverTypes e) => e.SystemId).HasColumnName("SYSTEM_ID");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstCoverTypes>(entity.HasOne((SstCoverTypes d) => d.Class).WithMany((SstClasses p) => p.SstCoverTypes).HasForeignKey((SstCoverTypes d) => d.ClassId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_COVER_TYPES_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstCoverTypes, SstCoverTypes>(entity.HasOne((SstCoverTypes d) => d.Cover).WithMany((SstCoverTypes p) => p.InverseCover).HasForeignKey((SstCoverTypes d) => d.CoverId), "SST_COVER_TYPES_FK04");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstCoverTypes>(entity.HasOne((SstCoverTypes d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstCoverTypes).HasForeignKey((SstCoverTypes d) => d.PolicyType), "SST_COVER_TYPES_FK03");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstCoverTypes>(entity.HasOne((SstCoverTypes d) => d.System).WithMany((SstSystems p) => p.SstCoverTypes).HasForeignKey((SstCoverTypes d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_COVER_TYPES_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstCustomerTypes> entity)
				{
					entity.ToTable("sst_customer_types");
					entity.Property((SstCustomerTypes e) => e.Id).HasColumnName("ID");
					entity.Property((SstCustomerTypes e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstCustomerTypes e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstCustomerTypes e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstCustomerTypes e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstCustomerTypes e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstCustomerTypes e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstCustomerTypes e) => e.Name2).HasColumnName("NAME2").HasMaxLength(255)
						.IsUnicode(unicode: false);
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstDataSecurity> entity)
				{
					entity.ToTable("sst_data_security");
					entity.HasIndex((Expression<Func<SstDataSecurity, object>>)((SstDataSecurity e) => e.ClassId)).HasName("SST_DATA_SECURITY_FK01");
					entity.HasIndex((Expression<Func<SstDataSecurity, object>>)((SstDataSecurity e) => e.PolicyType)).HasName("SST_DATA_SECURITY_FK02");
					entity.HasIndex((Expression<Func<SstDataSecurity, object>>)((SstDataSecurity e) => e.ProductId)).HasName("SST_DATA_SECURITY_FK03");
					entity.Property((SstDataSecurity e) => e.Id).HasColumnName("ID");
					entity.Property((SstDataSecurity e) => e.ClassId).HasColumnName("CLASS_ID");
					entity.Property((SstDataSecurity e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstDataSecurity e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstDataSecurity e) => e.CreationUser).HasColumnName("CREATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstDataSecurity e) => e.GroupId).HasColumnName("GROUP_ID");
					entity.Property((SstDataSecurity e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstDataSecurity e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstDataSecurity e) => e.PolicyType).HasColumnName("POLICY_TYPE");
					entity.Property((SstDataSecurity e) => e.ProductId).HasColumnName("PRODUCT_ID");
					entity.Property((SstDataSecurity e) => e.Username).HasColumnName("USERNAME").HasMaxLength(80)
						.IsUnicode(unicode: false);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstDataSecurity>(entity.HasOne((SstDataSecurity d) => d.Class).WithMany((SstClasses p) => p.SstDataSecurity).HasForeignKey((SstDataSecurity d) => d.ClassId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_DATA_SECURITY_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstDataSecurity>(entity.HasOne((SstDataSecurity d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstDataSecurity).HasForeignKey((SstDataSecurity d) => d.PolicyType)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_DATA_SECURITY_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPackagedPolicy, SstDataSecurity>(entity.HasOne((SstDataSecurity d) => d.Product).WithMany((SstPackagedPolicy p) => p.SstDataSecurity).HasForeignKey((SstDataSecurity d) => d.ProductId), "SST_DATA_SECURITY_FK03");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstDiscounts> entity)
				{
					entity.ToTable("sst_discounts");
					entity.HasIndex((Expression<Func<SstDiscounts, object>>)((SstDiscounts e) => e.SystemId)).HasName("SST_DISCOUNTS_FK01");
					entity.Property((SstDiscounts e) => e.Id).HasColumnName("ID");
					entity.Property((SstDiscounts e) => e.ApplyOn).HasColumnName("APPLY_ON");
					entity.Property((SstDiscounts e) => e.BranchId).HasColumnName("BRANCH_ID");
					entity.Property((SstDiscounts e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstDiscounts e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstDiscounts e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstDiscounts e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstDiscounts e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstDiscounts e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstDiscounts e) => e.Name2).HasColumnName("NAME2").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstDiscounts e) => e.Order).HasColumnName("ORDER");
					entity.Property((SstDiscounts e) => e.Source).HasColumnName("SOURCE");
					entity.Property((SstDiscounts e) => e.SystemId).HasColumnName("SYSTEM_ID");
					entity.Property((SstDiscounts e) => e.Type).HasColumnName("TYPE").HasDefaultValueSql("1");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstDiscounts>(entity.HasOne((SstDiscounts d) => d.System).WithMany((SstSystems p) => p.SstDiscounts).HasForeignKey((SstDiscounts d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_DISCOUNTS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstDiscountsBusinessFactors> entity)
				{
					entity.ToTable("sst_discounts_business_factors");
					entity.HasIndex((Expression<Func<SstDiscountsBusinessFactors, object>>)((SstDiscountsBusinessFactors e) => e.DiscountFactorId)).HasName("SST_DISCOUNTS_BUS_FACTORS_FK02");
					entity.HasIndex((Expression<Func<SstDiscountsBusinessFactors, object>>)((SstDiscountsBusinessFactors e) => e.PolicyDiscountId)).HasName("SST_DISCOUNTS_BUS_FACTORS_FK01");
					entity.Property((SstDiscountsBusinessFactors e) => e.Id).HasColumnName("ID");
					entity.Property((SstDiscountsBusinessFactors e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstDiscountsBusinessFactors e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstDiscountsBusinessFactors e) => e.DiscountFactorId).HasColumnName("DISCOUNT_FACTOR_ID");
					entity.Property((SstDiscountsBusinessFactors e) => e.FactorType).HasColumnName("FACTOR_TYPE");
					entity.Property((SstDiscountsBusinessFactors e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstDiscountsBusinessFactors e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstDiscountsBusinessFactors e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstDiscountsBusinessFactors e) => e.PolicyDiscountId).HasColumnName("POLICY_DISCOUNT_ID");
					entity.Property((SstDiscountsBusinessFactors e) => e.ReferenceId).HasColumnName("REFERENCE_ID");
					entity.Property((SstDiscountsBusinessFactors e) => e.ValueFrom).HasColumnName("VALUE_FROM");
					entity.Property((SstDiscountsBusinessFactors e) => e.ValueTo).HasColumnName("VALUE_TO");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstDiscountsFactors, SstDiscountsBusinessFactors>(entity.HasOne((SstDiscountsBusinessFactors d) => d.DiscountFactor).WithMany((SstDiscountsFactors p) => p.SstDiscountsBusinessFactors).HasForeignKey((SstDiscountsBusinessFactors d) => d.DiscountFactorId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_DISCOUNTS_BUS_FACTORS_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyDiscounts, SstDiscountsBusinessFactors>(entity.HasOne((SstDiscountsBusinessFactors d) => d.PolicyDiscount).WithMany((SstPolicyDiscounts p) => p.SstDiscountsBusinessFactors).HasForeignKey((SstDiscountsBusinessFactors d) => d.PolicyDiscountId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_DISCOUNTS_BUS_FACTORS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstDiscountsFactors> entity)
				{
					entity.ToTable("sst_discounts_factors");
					entity.HasIndex((Expression<Func<SstDiscountsFactors, object>>)((SstDiscountsFactors e) => e.SystemId)).HasName("SST_DISCOUNTS_FACTORS_FK01");
					entity.Property((SstDiscountsFactors e) => e.Id).HasColumnName("ID");
					entity.Property((SstDiscountsFactors e) => e.ColFormula).HasColumnName("COL_FORMULA").HasMaxLength(4000)
						.IsUnicode(unicode: false);
					entity.Property((SstDiscountsFactors e) => e.ColType).HasColumnName("COL_TYPE");
					entity.Property((SstDiscountsFactors e) => e.ColumnName).HasColumnName("COLUMN_NAME").HasMaxLength(4000)
						.IsUnicode(unicode: false);
					entity.Property((SstDiscountsFactors e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstDiscountsFactors e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstDiscountsFactors e) => e.FactorType).HasColumnName("FACTOR_TYPE");
					entity.Property((SstDiscountsFactors e) => e.IsFormula).HasColumnName("IS_FORMULA");
					entity.Property((SstDiscountsFactors e) => e.Lob).HasColumnName("LOB");
					entity.Property((SstDiscountsFactors e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstDiscountsFactors e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstDiscountsFactors e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstDiscountsFactors e) => e.ReferenceId).HasColumnName("REFERENCE_ID");
					entity.Property((SstDiscountsFactors e) => e.SystemId).HasColumnName("SYSTEM_ID");
					entity.Property((SstDiscountsFactors e) => e.TableName).HasColumnName("TABLE_NAME").HasMaxLength(4000)
						.IsUnicode(unicode: false);
					entity.Property((SstDiscountsFactors e) => e.ValueFrom).HasColumnName("VALUE_FROM");
					entity.Property((SstDiscountsFactors e) => e.ValueTo).HasColumnName("VALUE_TO");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstDiscountsFactors>(entity.HasOne((SstDiscountsFactors d) => d.System).WithMany((SstSystems p) => p.SstDiscountsFactors).HasForeignKey((SstDiscountsFactors d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_DISCOUNTS_FACTORS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstDiscountsFactorsQuery> entity)
				{
					entity.ToTable("sst_discounts_factors_query");
					entity.HasIndex((Expression<Func<SstDiscountsFactorsQuery, object>>)((SstDiscountsFactorsQuery e) => e.DiscountId)).HasName("SST_DISCOUNTS_FACTORS_QRY_FK01");
					entity.HasIndex((Expression<Func<SstDiscountsFactorsQuery, object>>)((SstDiscountsFactorsQuery e) => e.PolicyDiscId)).HasName("SST_DISCOUNTS_FACTORS_QRY_FK02");
					entity.Property((SstDiscountsFactorsQuery e) => e.Id).HasColumnName("ID");
					entity.Property((SstDiscountsFactorsQuery e) => e.DiscountId).HasColumnName("DISCOUNT_ID");
					entity.Property((SstDiscountsFactorsQuery e) => e.PolicyDiscId).HasColumnName("POLICY_DISC_ID");
					entity.Property((SstDiscountsFactorsQuery e) => e.SqlStatment).HasColumnName("SQL_STATMENT").HasColumnType("longtext");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstDiscounts, SstDiscountsFactorsQuery>(entity.HasOne((SstDiscountsFactorsQuery d) => d.Discount).WithMany((SstDiscounts p) => p.SstDiscountsFactorsQuery).HasForeignKey((SstDiscountsFactorsQuery d) => d.DiscountId)
					//	.OnDelete(DeleteBehavior.Cascade), "SST_DISCOUNTS_FACTORS_QRY_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyDiscounts, SstDiscountsFactorsQuery>(entity.HasOne((SstDiscountsFactorsQuery d) => d.PolicyDisc).WithMany((SstPolicyDiscounts p) => p.SstDiscountsFactorsQuery).HasForeignKey((SstDiscountsFactorsQuery d) => d.PolicyDiscId)
					//	.OnDelete(DeleteBehavior.Cascade), "SST_DISCOUNTS_FACTORS_QRY_FK02");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstDocumentGroups> entity)
				{
					entity.ToTable("sst_document_groups");
					entity.HasIndex((Expression<Func<SstDocumentGroups, object>>)((SstDocumentGroups e) => e.SystemId)).HasName("SST_DOCUMENT_GROUPS_FK01");
					entity.Property((SstDocumentGroups e) => e.Id).HasColumnName("ID");
					entity.Property((SstDocumentGroups e) => e.ClassId).HasColumnName("CLASS_ID");
					entity.Property((SstDocumentGroups e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstDocumentGroups e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstDocumentGroups e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstDocumentGroups e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstDocumentGroups e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstDocumentGroups e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstDocumentGroups e) => e.Name2).HasColumnName("NAME2").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstDocumentGroups e) => e.Notes).HasColumnName("NOTES").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstDocumentGroups e) => e.PolicyType).HasColumnName("POLICY_TYPE");
					entity.Property((SstDocumentGroups e) => e.SystemId).HasColumnName("SYSTEM_ID");
					entity.Property((SstDocumentGroups e) => e.Type).HasColumnName("TYPE");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstDocumentGroups>(entity.HasOne((SstDocumentGroups d) => d.System).WithMany((SstSystems p) => p.SstDocumentGroups).HasForeignKey((SstDocumentGroups d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_DOCUMENT_GROUPS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstDocuments> entity)
				{
					entity.ToTable("sst_documents");
					entity.HasIndex((Expression<Func<SstDocuments, object>>)((SstDocuments e) => e.GroupId)).HasName("SST_DOCUMENTS_FK01");
					entity.Property((SstDocuments e) => e.Id).HasColumnName("ID");
					entity.Property((SstDocuments e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstDocuments e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstDocuments e) => e.GroupId).HasColumnName("GROUP_ID");
					entity.Property((SstDocuments e) => e.IsAuto).HasColumnName("IS_AUTO");
					entity.Property((SstDocuments e) => e.IsRequired).HasColumnName("IS_REQUIRED");
					entity.Property((SstDocuments e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstDocuments e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstDocuments e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstDocuments e) => e.Name2).HasColumnName("NAME2").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstDocuments e) => e.Notes).HasColumnName("NOTES").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstDocumentGroups, SstDocuments>(entity.HasOne((SstDocuments d) => d.Group).WithMany((SstDocumentGroups p) => p.SstDocuments).HasForeignKey((SstDocuments d) => d.GroupId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_DOCUMENTS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstDomainValues> entity)
				{
					entity.ToTable("sst_domain_values");
					entity.HasIndex((Expression<Func<SstDomainValues, object>>)((SstDomainValues e) => e.DomainId)).HasName("SST_DOMAIN_VALUES_FK01");
					entity.Property((SstDomainValues e) => e.Id).HasColumnName("ID");
					entity.Property((SstDomainValues e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstDomainValues e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstDomainValues e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstDomainValues e) => e.DomainCode).HasColumnName("DOMAIN_CODE");
					entity.Property((SstDomainValues e) => e.DomainId).HasColumnName("DOMAIN_ID");
					entity.Property((SstDomainValues e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstDomainValues e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstDomainValues e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstDomainValues e) => e.Name2).HasColumnName("NAME2").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstDomainValues e) => e.Order).HasColumnName("ORDER").HasDefaultValueSql("1");
					entity.Property((SstDomainValues e) => e.ShortName).HasColumnName("SHORT_NAME").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstDomainValues e) => e.SystemId).HasColumnName("SYSTEM_ID");
					entity.Property((SstDomainValues e) => e.Value).HasColumnName("VALUE");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstDomains, SstDomainValues>(entity.HasOne((SstDomainValues d) => d.Domain).WithMany((SstDomains p) => p.SstDomainValues).HasForeignKey((SstDomainValues d) => d.DomainId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_DOMAIN_VALUES_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstDomains> entity)
				{
					entity.ToTable("sst_domains");
					entity.HasIndex((Expression<Func<SstDomains, object>>)((SstDomains e) => e.SystemId)).HasName("SST_DOMAINS_FK01");
					entity.Property((SstDomains e) => e.Id).HasColumnName("ID");
					entity.Property((SstDomains e) => e.Code).HasColumnName("CODE");
					entity.Property((SstDomains e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstDomains e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstDomains e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstDomains e) => e.DefaultValue).HasColumnName("DEFAULT_VALUE");
					entity.Property((SstDomains e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstDomains e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstDomains e) => e.ModuleCode).HasColumnName("MODULE_CODE").HasMaxLength(15)
						.IsUnicode(unicode: false);
					entity.Property((SstDomains e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstDomains e) => e.Name2).HasColumnName("NAME2").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstDomains e) => e.Notes).HasColumnName("NOTES").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstDomains e) => e.SystemId).HasColumnName("SYSTEM_ID");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstDomains>(entity.HasOne((SstDomains d) => d.System).WithMany((SstSystems p) => p.SstDomains).HasForeignKey((SstDomains d) => d.SystemId), "SST_DOMAINS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstDynamicValues> entity)
				{
					entity.ToTable("sst_dynamic_values");
					entity.HasIndex((Expression<Func<SstDynamicValues, object>>)((SstDynamicValues e) => e.QuestDetailId)).HasName("SYS_C002285530");
					entity.Property((SstDynamicValues e) => e.Id).HasColumnName("ID");
					entity.Property((SstDynamicValues e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstDynamicValues e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstDynamicValues e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstDynamicValues e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstDynamicValues e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(100)
						.IsUnicode(unicode: false);
					entity.Property((SstDynamicValues e) => e.Name2).HasColumnName("NAME2").HasMaxLength(100)
						.IsUnicode(unicode: false);
					entity.Property((SstDynamicValues e) => e.Order).HasColumnName("ORDER");
					entity.Property((SstDynamicValues e) => e.QuestDetailId).HasColumnName("QUEST_DETAIL_ID");
					entity.Property((SstDynamicValues e) => e.Value).HasColumnName("VALUE");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstQuestDetails, SstDynamicValues>(entity.HasOne((SstDynamicValues d) => d.QuestDetail).WithMany((SstQuestDetails p) => p.SstDynamicValues).HasForeignKey((SstDynamicValues d) => d.QuestDetailId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C002285530");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstEndorsements> entity)
				{
					entity.ToTable("sst_endorsements");
					entity.HasIndex((Expression<Func<SstEndorsements, object>>)((SstEndorsements e) => e.ClassId)).HasName("SST_ENDORSEMENTS_FK02");
					entity.HasIndex((Expression<Func<SstEndorsements, object>>)((SstEndorsements e) => e.SystemId)).HasName("SST_ENDORSEMENTS_FK01");
					entity.Property((SstEndorsements e) => e.Id).HasColumnName("ID");
					entity.Property((SstEndorsements e) => e.ClassId).HasColumnName("CLASS_ID");
					entity.Property((SstEndorsements e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstEndorsements e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstEndorsements e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstEndorsements e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstEndorsements e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstEndorsements e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstEndorsements e) => e.Name2).HasColumnName("NAME2").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstEndorsements e) => e.SystemId).HasColumnName("SYSTEM_ID");
					entity.Property((SstEndorsements e) => e.Type).HasColumnName("TYPE");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstEndorsements>(entity.HasOne((SstEndorsements d) => d.Class).WithMany((SstClasses p) => p.SstEndorsements).HasForeignKey((SstEndorsements d) => d.ClassId), "SST_ENDORSEMENTS_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstEndorsements>(entity.HasOne((SstEndorsements d) => d.System).WithMany((SstSystems p) => p.SstEndorsements).HasForeignKey((SstEndorsements d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_ENDORSEMENTS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstEntities> entity)
				{
					entity.ToTable("sst_entities");
					entity.Property((SstEntities e) => e.Id).HasColumnName("ID");
					entity.Property((SstEntities e) => e.Abbreviation).IsRequired().HasColumnName("ABBREVIATION")
						.HasMaxLength(5)
						.IsUnicode(unicode: false);
					entity.Property((SstEntities e) => e.Area).HasColumnName("AREA");
					entity.Property((SstEntities e) => e.BankType).HasColumnName("BANK_TYPE");
					entity.Property((SstEntities e) => e.BlacklistFlag).HasColumnName("BLACKLIST_FLAG").HasDefaultValueSql("0");
					entity.Property((SstEntities e) => e.BrokerArrDate).HasColumnName("BROKER_ARR_DATE");
					entity.Property((SstEntities e) => e.BrokerArrType).HasColumnName("BROKER_ARR_TYPE");
					entity.Property((SstEntities e) => e.BrokerExpFlag).HasColumnName("BROKER_EXP_FLAG");
					entity.Property((SstEntities e) => e.BrokerLicenseFlag).HasColumnName("BROKER_LICENSE_FLAG");
					entity.Property((SstEntities e) => e.BrokerRole).HasColumnName("BROKER_ROLE");
					entity.Property((SstEntities e) => e.BrokerRoleDesc).HasColumnName("BROKER_ROLE_DESC").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstEntities e) => e.BrokerYearsNo).HasColumnName("BROKER_YEARS_NO");
					entity.Property((SstEntities e) => e.BuildingNo).HasColumnName("BUILDING_NO").HasMaxLength(100)
						.IsUnicode(unicode: false);
					entity.Property((SstEntities e) => e.BusinessActivities).HasColumnName("BUSINESS_ACTIVITIES").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstEntities e) => e.BusinessSector).HasColumnName("BUSINESS_SECTOR");
					entity.Property((SstEntities e) => e.City).HasColumnName("CITY");
					entity.Property((SstEntities e) => e.CommencementDate).HasColumnName("COMMENCEMENT_DATE");
					entity.Property((SstEntities e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstEntities e) => e.CompanyType).HasColumnName("COMPANY_TYPE");
					entity.Property((SstEntities e) => e.Country).HasColumnName("COUNTRY").HasMaxLength(8)
						.IsUnicode(unicode: false);
					entity.Property((SstEntities e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstEntities e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstEntities e) => e.CreditLimit).HasColumnName("CREDIT_LIMIT").HasColumnType("decimal(9,3)")
						.HasDefaultValueSql("0.000");
					entity.Property((SstEntities e) => e.CustomerId).HasColumnName("CUSTOMER_ID");
					entity.Property((SstEntities e) => e.District).HasColumnName("DISTRICT").HasMaxLength(100)
						.IsUnicode(unicode: false);
					entity.Property((SstEntities e) => e.EmailCommunication).HasColumnName("EMAIL_COMMUNICATION").HasDefaultValueSql("0");
					entity.Property((SstEntities e) => e.EmployeesNo).HasColumnName("EMPLOYEES_NO");
					entity.Property((SstEntities e) => e.EntityNature).HasColumnName("ENTITY_NATURE");
					entity.Property((SstEntities e) => e.FaxNo).HasColumnName("FAX_NO").HasMaxLength(25)
						.IsUnicode(unicode: false);
					entity.Property((SstEntities e) => e.FreeZoneFlag).HasColumnName("FREE_ZONE_FLAG");
					entity.Property((SstEntities e) => e.Governorate).HasColumnName("GOVERNORATE");
					entity.Property((SstEntities e) => e.HoldBusCountry).HasColumnName("HOLD_BUS_COUNTRY").HasMaxLength(8)
						.IsUnicode(unicode: false);
					entity.Property((SstEntities e) => e.HoldCompanyName).HasColumnName("HOLD_COMPANY_NAME").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstEntities e) => e.HoldIncCountry).HasColumnName("HOLD_INC_COUNTRY").HasMaxLength(8)
						.IsUnicode(unicode: false);
					entity.Property((SstEntities e) => e.HoldMajority).HasColumnName("HOLD_MAJORITY").HasMaxLength(8)
						.IsUnicode(unicode: false);
					entity.Property((SstEntities e) => e.HomeCommunication).HasColumnName("HOME_COMMUNICATION").HasDefaultValueSql("0");
					entity.Property((SstEntities e) => e.IncorporationDate).HasColumnName("INCORPORATION_DATE");
					entity.Property((SstEntities e) => e.KycCleared).HasColumnName("KYC_CLEARED");
					entity.Property((SstEntities e) => e.Language).HasColumnName("LANGUAGE");
					entity.Property((SstEntities e) => e.LegalStatus).HasColumnName("LEGAL_STATUS");
					entity.Property((SstEntities e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstEntities e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstEntities e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstEntities e) => e.Name2).HasColumnName("NAME2").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstEntities e) => e.Notes).HasColumnName("NOTES").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstEntities e) => e.PaidUpCapital).HasColumnName("PAID_UP_CAPITAL").HasColumnType("decimal(9,3)")
						.HasDefaultValueSql("0.000");
					entity.Property((SstEntities e) => e.PhoneCommunication).HasColumnName("PHONE_COMMUNICATION").HasDefaultValueSql("0");
					entity.Property((SstEntities e) => e.PoBox).HasColumnName("PO_BOX").HasMaxLength(100)
						.IsUnicode(unicode: false);
					entity.Property((SstEntities e) => e.PostalCommunication).HasColumnName("POSTAL_COMMUNICATION").HasDefaultValueSql("0");
					entity.Property((SstEntities e) => e.PrimaryAddress).HasColumnName("PRIMARY_ADDRESS").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstEntities e) => e.PrimaryEmail).HasColumnName("PRIMARY_EMAIL").HasMaxLength(100)
						.IsUnicode(unicode: false);
					entity.Property((SstEntities e) => e.PrimaryMobile).HasColumnName("PRIMARY_MOBILE").HasMaxLength(25)
						.IsUnicode(unicode: false);
					entity.Property((SstEntities e) => e.PrimaryPhone).HasColumnName("PRIMARY_PHONE").HasMaxLength(25)
						.IsUnicode(unicode: false);
					entity.Property((SstEntities e) => e.RegisterNo).HasColumnName("REGISTER_NO").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstEntities e) => e.RegisterType).HasColumnName("REGISTER_TYPE");
					entity.Property((SstEntities e) => e.Regulator).HasColumnName("REGULATOR").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstEntities e) => e.SecondaryAddress).HasColumnName("SECONDARY_ADDRESS").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstEntities e) => e.SecondaryEmail).HasColumnName("SECONDARY_EMAIL").HasMaxLength(100)
						.IsUnicode(unicode: false);
					entity.Property((SstEntities e) => e.SecondaryMobile).HasColumnName("SECONDARY_MOBILE").HasMaxLength(25)
						.IsUnicode(unicode: false);
					entity.Property((SstEntities e) => e.SecondaryPhone).HasColumnName("SECONDARY_PHONE").HasMaxLength(25)
						.IsUnicode(unicode: false);
					entity.Property((SstEntities e) => e.SegmentCode).IsRequired().HasColumnName("SEGMENT_CODE")
						.HasMaxLength(24)
						.IsUnicode(unicode: false);
					entity.Property((SstEntities e) => e.SmsCommunication).HasColumnName("SMS_COMMUNICATION").HasDefaultValueSql("0");
					entity.Property((SstEntities e) => e.Stage).HasColumnName("STAGE");
					entity.Property((SstEntities e) => e.StageDate).HasColumnName("STAGE_DATE");
					entity.Property((SstEntities e) => e.Status).HasColumnName("STATUS");
					entity.Property((SstEntities e) => e.StatusDate).HasColumnName("STATUS_DATE");
					entity.Property((SstEntities e) => e.Street).HasColumnName("STREET").HasMaxLength(100)
						.IsUnicode(unicode: false);
					entity.Property((SstEntities e) => e.SubSector).HasColumnName("SUB_SECTOR");
					entity.Property((SstEntities e) => e.TaxableFlag).HasColumnName("TAXABLE_FLAG").HasDefaultValueSql("0");
					entity.Property((SstEntities e) => e.Title).HasColumnName("TITLE");
					entity.Property((SstEntities e) => e.UnitNo).HasColumnName("UNIT_NO").HasMaxLength(100)
						.IsUnicode(unicode: false);
					entity.Property((SstEntities e) => e.Website).HasColumnName("WEBSITE").HasMaxLength(100)
						.IsUnicode(unicode: false);
					entity.Property((SstEntities e) => e.ZipCode).HasColumnName("ZIP_CODE").HasMaxLength(100)
						.IsUnicode(unicode: false);
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstEntityDetails> entity)
				{
					entity.ToTable("sst_entity_details");
					entity.Property((SstEntityDetails e) => e.Id).HasColumnName("ID");
					entity.Property((SstEntityDetails e) => e.Address).HasColumnName("ADDRESS").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstEntityDetails e) => e.Country).HasColumnName("COUNTRY").HasMaxLength(8)
						.IsUnicode(unicode: false);
					entity.Property((SstEntityDetails e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstEntityDetails e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstEntityDetails e) => e.DetailDate).HasColumnName("DETAIL_DATE");
					entity.Property((SstEntityDetails e) => e.DetailType).HasColumnName("DETAIL_TYPE");
					entity.Property((SstEntityDetails e) => e.Email).HasColumnName("EMAIL").HasMaxLength(100)
						.IsUnicode(unicode: false);
					entity.Property((SstEntityDetails e) => e.EntityId).HasColumnName("ENTITY_ID");
					entity.Property((SstEntityDetails e) => e.ExperienceYears).HasColumnName("EXPERIENCE_YEARS");
					entity.Property((SstEntityDetails e) => e.MobileNo).HasColumnName("MOBILE_NO").HasMaxLength(25)
						.IsUnicode(unicode: false);
					entity.Property((SstEntityDetails e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstEntityDetails e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstEntityDetails e) => e.Name).HasColumnName("NAME").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstEntityDetails e) => e.Name2).HasColumnName("NAME2").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstEntityDetails e) => e.Notes).HasColumnName("NOTES").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstEntityDetails e) => e.PhoneNo).HasColumnName("PHONE_NO").HasMaxLength(25)
						.IsUnicode(unicode: false);
					entity.Property((SstEntityDetails e) => e.Position).HasColumnName("POSITION");
					entity.Property((SstEntityDetails e) => e.Priority).HasColumnName("PRIORITY");
					entity.Property((SstEntityDetails e) => e.SharePercent).HasColumnName("SHARE_PERCENT").HasColumnType("decimal(9,3)");
					entity.Property((SstEntityDetails e) => e.TotalPolicies).HasColumnName("TOTAL_POLICIES");
					entity.Property((SstEntityDetails e) => e.TotalPremium).HasColumnName("TOTAL_PREMIUM").HasColumnType("decimal(9,3)");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstEntityMapping> entity)
				{
					entity.ToTable("sst_entity_mapping");
					entity.Property((SstEntityMapping e) => e.Id).HasColumnName("ID");
					entity.Property((SstEntityMapping e) => e.AccountId).HasColumnName("ACCOUNT_ID");
					entity.Property((SstEntityMapping e) => e.AccountType).HasColumnName("ACCOUNT_TYPE");
					entity.Property((SstEntityMapping e) => e.CostCenter).HasColumnName("COST_CENTER");
					entity.Property((SstEntityMapping e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstEntityMapping e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstEntityMapping e) => e.EntityType).HasColumnName("ENTITY_TYPE");
					entity.Property((SstEntityMapping e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstEntityMapping e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstEntityMapping e) => e.RoleId).HasColumnName("ROLE_ID");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstEntityRoles> entity)
				{
					entity.ToTable("sst_entity_roles");
					entity.HasIndex((Expression<Func<SstEntityRoles, object>>)((SstEntityRoles e) => e.EntityId)).HasName("SST_ENTITY_ROLES_FK01");
					entity.Property((SstEntityRoles e) => e.Id).HasColumnName("ID");
					entity.Property((SstEntityRoles e) => e.AccountId).HasColumnName("ACCOUNT_ID");
					entity.Property((SstEntityRoles e) => e.AccountType).HasColumnName("ACCOUNT_TYPE");
					entity.Property((SstEntityRoles e) => e.CostCenter).HasColumnName("COST_CENTER");
					entity.Property((SstEntityRoles e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstEntityRoles e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstEntityRoles e) => e.EntityId).HasColumnName("ENTITY_ID");
					entity.Property((SstEntityRoles e) => e.EntityType).HasColumnName("ENTITY_TYPE");
					entity.Property((SstEntityRoles e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstEntityRoles e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstEntityRoles e) => e.RoleId).HasColumnName("ROLE_ID");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstEntities, SstEntityRoles>(entity.HasOne((SstEntityRoles d) => d.Entity).WithMany((SstEntities p) => p.SstEntityRoles).HasForeignKey((SstEntityRoles d) => d.EntityId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_ENTITY_ROLES_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstEpaymentAlerts> entity)
				{
					entity.ToTable("sst_epayment_alerts");
					entity.HasIndex((Expression<Func<SstEpaymentAlerts, object>>)((SstEpaymentAlerts e) => e.PaymentId)).HasName("SST_EPAYMENT_ALERTS_FK01");
					entity.Property((SstEpaymentAlerts e) => e.Id).HasColumnName("ID");
					entity.Property((SstEpaymentAlerts e) => e.CardExpiry).HasColumnName("CARD_EXPIRY");
					entity.Property((SstEpaymentAlerts e) => e.CardPreExpiry).HasColumnName("CARD_PRE_EXPIRY");
					entity.Property((SstEpaymentAlerts e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstEpaymentAlerts e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstEpaymentAlerts e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstEpaymentAlerts e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstEpaymentAlerts e) => e.PaymentExpiry).HasColumnName("PAYMENT_EXPIRY");
					entity.Property((SstEpaymentAlerts e) => e.PaymentFailure).HasColumnName("PAYMENT_FAILURE");
					entity.Property((SstEpaymentAlerts e) => e.PaymentId).HasColumnName("PAYMENT_ID");
					entity.Property((SstEpaymentAlerts e) => e.PaymentRecurring).HasColumnName("PAYMENT_RECURRING");
					entity.Property((SstEpaymentAlerts e) => e.PaymentRenewal).HasColumnName("PAYMENT_RENEWAL");
					entity.Property((SstEpaymentAlerts e) => e.PaymentSuccess).HasColumnName("PAYMENT_SUCCESS");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstEpaymentMethods, SstEpaymentAlerts>(entity.HasOne((SstEpaymentAlerts d) => d.Payment).WithMany((SstEpaymentMethods p) => p.SstEpaymentAlerts).HasForeignKey((SstEpaymentAlerts d) => d.PaymentId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_EPAYMENT_ALERTS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstEpaymentDetails> entity)
				{
					entity.ToTable("sst_epayment_details");
					entity.HasIndex((Expression<Func<SstEpaymentDetails, object>>)((SstEpaymentDetails e) => e.PaymentId)).HasName("SST_EPAYMENT_DETAILS_FK01");
					entity.Property((SstEpaymentDetails e) => e.Id).HasColumnName("ID");
					entity.Property((SstEpaymentDetails e) => e.AccessCode).HasColumnName("ACCESS_CODE").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstEpaymentDetails e) => e.Address).HasColumnName("ADDRESS").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstEpaymentDetails e) => e.Amount).HasColumnName("AMOUNT").HasColumnType("decimal(9,3)");
					entity.Property((SstEpaymentDetails e) => e.ApiId).HasColumnName("API_ID");
					entity.Property((SstEpaymentDetails e) => e.AuthenticationType).HasColumnName("AUTHENTICATION_TYPE");
					entity.Property((SstEpaymentDetails e) => e.CertificatePass).HasColumnName("CERTIFICATE_PASS").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstEpaymentDetails e) => e.CertificatePath).HasColumnName("CERTIFICATE_PATH").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstEpaymentDetails e) => e.Channel).HasColumnName("CHANNEL").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstEpaymentDetails e) => e.Command).HasColumnName("COMMAND").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstEpaymentDetails e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstEpaymentDetails e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstEpaymentDetails e) => e.Currency).HasColumnName("CURRENCY").HasMaxLength(24)
						.IsUnicode(unicode: false);
					entity.Property((SstEpaymentDetails e) => e.Customer).HasColumnName("CUSTOMER").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstEpaymentDetails e) => e.CustomerEmail).HasColumnName("CUSTOMER_EMAIL").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstEpaymentDetails e) => e.IsSecure).HasColumnName("IS_SECURE");
					entity.Property((SstEpaymentDetails e) => e.Language).HasColumnName("LANGUAGE").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstEpaymentDetails e) => e.MerchantId).HasColumnName("MERCHANT_ID");
					entity.Property((SstEpaymentDetails e) => e.MerchantReference).HasColumnName("MERCHANT_REFERENCE").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstEpaymentDetails e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstEpaymentDetails e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstEpaymentDetails e) => e.OrderDescription).HasColumnName("ORDER_DESCRIPTION").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstEpaymentDetails e) => e.OrderInfo).HasColumnName("ORDER_INFO").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstEpaymentDetails e) => e.PaymentId).HasColumnName("PAYMENT_ID");
					entity.Property((SstEpaymentDetails e) => e.PaymentOption).HasColumnName("PAYMENT_OPTION").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstEpaymentDetails e) => e.Port).HasColumnName("PORT");
					entity.Property((SstEpaymentDetails e) => e.Registration).HasColumnName("REGISTRATION").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstEpaymentDetails e) => e.ReturnPath).HasColumnName("RETURN_PATH").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstEpaymentDetails e) => e.Store).HasColumnName("STORE").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstEpaymentDetails e) => e.Terminal).HasColumnName("TERMINAL").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstEpaymentDetails e) => e.Timeout).HasColumnName("TIMEOUT");
					entity.Property((SstEpaymentDetails e) => e.TransactionId).HasColumnName("TRANSACTION_ID");
					entity.Property((SstEpaymentDetails e) => e.TransactionPassword).HasColumnName("TRANSACTION_PASSWORD").HasMaxLength(255)
						.IsUnicode(unicode: false);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstEpaymentMethods, SstEpaymentDetails>(entity.HasOne((SstEpaymentDetails d) => d.Payment).WithMany((SstEpaymentMethods p) => p.SstEpaymentDetails).HasForeignKey((SstEpaymentDetails d) => d.PaymentId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_EPAYMENT_DETAILS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstEpaymentMethods> entity)
				{
					entity.ToTable("sst_epayment_methods");
					entity.HasIndex((Expression<Func<SstEpaymentMethods, object>>)((SstEpaymentMethods e) => e.SystemId)).HasName("SST_EPAYMENT_METHODS_FK01");
					entity.Property((SstEpaymentMethods e) => e.Id).HasColumnName("ID");
					entity.Property((SstEpaymentMethods e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstEpaymentMethods e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstEpaymentMethods e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstEpaymentMethods e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstEpaymentMethods e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstEpaymentMethods e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstEpaymentMethods e) => e.Name2).HasColumnName("NAME2").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstEpaymentMethods e) => e.Notes).HasColumnName("NOTES").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstEpaymentMethods e) => e.SystemId).HasColumnName("SYSTEM_ID");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstEpaymentMethods>(entity.HasOne((SstEpaymentMethods d) => d.System).WithMany((SstSystems p) => p.SstEpaymentMethods).HasForeignKey((SstEpaymentMethods d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_EPAYMENT_METHODS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstEpaymentTransaction> entity)
				{
					entity.ToTable("sst_epayment_transaction");
					entity.Property((SstEpaymentTransaction e) => e.Id).HasColumnName("ID");
					entity.Property((SstEpaymentTransaction e) => e.AcquirerId).HasColumnName("ACQUIRER_ID");
					entity.Property((SstEpaymentTransaction e) => e.Amount).HasColumnName("AMOUNT").HasColumnType("decimal(9,3)");
					entity.Property((SstEpaymentTransaction e) => e.AutoNotifyLogId).HasColumnName("AUTO_NOTIFY_LOG_ID");
					entity.Property((SstEpaymentTransaction e) => e.ConfirmationId).HasColumnName("CONFIRMATION_ID");
					entity.Property((SstEpaymentTransaction e) => e.CustomerId).HasColumnName("CUSTOMER_ID");
					entity.Property((SstEpaymentTransaction e) => e.LanguageId).HasColumnName("LANGUAGE_ID");
					entity.Property((SstEpaymentTransaction e) => e.Note).HasColumnName("NOTE").HasMaxLength(500)
						.IsUnicode(unicode: false);
					entity.Property((SstEpaymentTransaction e) => e.OrderId).HasColumnName("ORDER_ID");
					entity.Property((SstEpaymentTransaction e) => e.PaymentStore).HasColumnName("PAYMENT_STORE");
					entity.Property((SstEpaymentTransaction e) => e.PortalId).HasColumnName("PORTAL_ID");
					entity.Property((SstEpaymentTransaction e) => e.RequestDate).HasColumnName("REQUEST_DATE").HasMaxLength(50)
						.IsUnicode(unicode: false);
					entity.Property((SstEpaymentTransaction e) => e.ResponseDate).HasColumnName("RESPONSE_DATE").HasMaxLength(50)
						.IsUnicode(unicode: false);
					entity.Property((SstEpaymentTransaction e) => e.ReturnedTransactionId).HasColumnName("RETURNED_TRANSACTION_ID");
					entity.Property((SstEpaymentTransaction e) => e.SourceOfTheTransaction).HasColumnName("SOURCE_OF_THE_TRANSACTION");
					entity.Property((SstEpaymentTransaction e) => e.TransactionLogId).HasColumnName("TRANSACTION_LOG_ID");
					entity.Property((SstEpaymentTransaction e) => e.TransactionStatus).HasColumnName("TRANSACTION_STATUS").HasMaxLength(300)
						.IsUnicode(unicode: false);
					entity.Property((SstEpaymentTransaction e) => e.TransactionStatusMessage).HasColumnName("TRANSACTION_STATUS_MESSAGE").HasMaxLength(300)
						.IsUnicode(unicode: false);
					entity.Property((SstEpaymentTransaction e) => e.Version).HasColumnName("VERSION").HasMaxLength(50)
						.IsUnicode(unicode: false);
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstFees> entity)
				{
					entity.ToTable("sst_fees");
					entity.HasIndex((Expression<Func<SstFees, object>>)((SstFees e) => e.SystemId)).HasName("SST_FEES_FK01");
					entity.Property((SstFees e) => e.Id).HasColumnName("ID");
					entity.Property((SstFees e) => e.Abbreviation).HasColumnName("ABBREVIATION").HasMaxLength(5)
						.IsUnicode(unicode: false);
					entity.Property((SstFees e) => e.ApplyClaims).HasColumnName("APPLY_CLAIMS");
					entity.Property((SstFees e) => e.ApplyInvestment).HasColumnName("APPLY_INVESTMENT");
					entity.Property((SstFees e) => e.ApplyOn).HasColumnName("APPLY_ON");
					entity.Property((SstFees e) => e.ApplyProduction).HasColumnName("APPLY_PRODUCTION");
					entity.Property((SstFees e) => e.ApplyReinsurance).HasColumnName("APPLY_REINSURANCE");
					entity.Property((SstFees e) => e.CalculateFrom).HasColumnName("CALCULATE_FROM");
					entity.Property((SstFees e) => e.CalculationLevel).HasColumnName("CALCULATION_LEVEL");
					entity.Property((SstFees e) => e.Category).HasColumnName("CATEGORY");
					entity.Property((SstFees e) => e.CommissionType).HasColumnName("COMMISSION_TYPE");
					entity.Property((SstFees e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstFees e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstFees e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstFees e) => e.DateType).HasColumnName("DATE_TYPE");
					entity.Property((SstFees e) => e.DocumentType).HasColumnName("DOCUMENT_TYPE").HasMaxLength(250)
						.IsUnicode(unicode: false);
					entity.Property((SstFees e) => e.EffectiveDate).HasColumnName("EFFECTIVE_DATE");
					entity.Property((SstFees e) => e.ExpiryDate).HasColumnName("EXPIRY_DATE");
					entity.Property((SstFees e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstFees e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstFees e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstFees e) => e.Name2).HasColumnName("NAME2").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstFees e) => e.SystemId).HasColumnName("SYSTEM_ID");
					entity.Property((SstFees e) => e.Type).HasColumnName("TYPE");
					entity.Property((SstFees e) => e.VoucherSide).HasColumnName("VOUCHER_SIDE");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstFees>(entity.HasOne((SstFees d) => d.System).WithMany((SstSystems p) => p.SstFees).HasForeignKey((SstFees d) => d.SystemId), "SST_FEES_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstFeesDetails> entity)
				{
					entity.ToTable("sst_fees_details");
					entity.HasIndex((Expression<Func<SstFeesDetails, object>>)((SstFeesDetails e) => e.FeeId)).HasName("SST_FEES_DETAILS_FK01");
					entity.Property((SstFeesDetails e) => e.Id).HasColumnName("ID");
					entity.Property((SstFeesDetails e) => e.BenefitType).HasColumnName("BENEFIT_TYPE");
					entity.Property((SstFeesDetails e) => e.ClaimTransaction).HasColumnName("CLAIM_TRANSACTION");
					entity.Property((SstFeesDetails e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstFeesDetails e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstFeesDetails e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstFeesDetails e) => e.EndorsementId).HasColumnName("ENDORSEMENT_ID");
					entity.Property((SstFeesDetails e) => e.FeeId).HasColumnName("FEE_ID");
					entity.Property((SstFeesDetails e) => e.InvestmentTransaction).HasColumnName("INVESTMENT_TRANSACTION");
					entity.Property((SstFeesDetails e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstFeesDetails e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstFeesDetails e) => e.ReinsuranceTransaction).HasColumnName("REINSURANCE_TRANSACTION");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstFees, SstFeesDetails>(entity.HasOne((SstFeesDetails d) => d.Fee).WithMany((SstFees p) => p.SstFeesDetails).HasForeignKey((SstFeesDetails d) => d.FeeId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_FEES_DETAILS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstFeesTiers> entity)
				{
					entity.ToTable("sst_fees_tiers");
					entity.HasIndex((Expression<Func<SstFeesTiers, object>>)((SstFeesTiers e) => e.ClassId)).HasName("SST_FEES_TIERS_FK03");
					entity.HasIndex((Expression<Func<SstFeesTiers, object>>)((SstFeesTiers e) => e.FeeId)).HasName("SST_FEES_TIERS_FK01");
					entity.HasIndex((Expression<Func<SstFeesTiers, object>>)((SstFeesTiers e) => e.PolicyType)).HasName("SST_FEES_TIERS_FK04");
					entity.HasIndex((Expression<Func<SstFeesTiers, object>>)((SstFeesTiers e) => e.SystemId)).HasName("SST_FEES_TIERS_FK02");
					entity.Property((SstFeesTiers e) => e.Id).HasColumnName("ID");
					entity.Property((SstFeesTiers e) => e.AmountFrom).HasColumnName("AMOUNT_FROM").HasColumnType("decimal(18,3)");
					entity.Property((SstFeesTiers e) => e.AmountTo).HasColumnName("AMOUNT_TO").HasColumnType("decimal(18,3)");
					entity.Property((SstFeesTiers e) => e.AutoAdd).HasColumnName("AUTO_ADD").HasDefaultValueSql("0");
					entity.Property((SstFeesTiers e) => e.CalculationMethod).HasColumnName("CALCULATION_METHOD").HasDefaultValueSql("0");
					entity.Property((SstFeesTiers e) => e.ClassId).HasColumnName("CLASS_ID");
					entity.Property((SstFeesTiers e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstFeesTiers e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstFeesTiers e) => e.Currency).HasColumnName("CURRENCY").HasMaxLength(24)
						.IsUnicode(unicode: false);
					entity.Property((SstFeesTiers e) => e.FeeAmount).HasColumnName("FEE_AMOUNT").HasColumnType("decimal(9,3)");
					entity.Property((SstFeesTiers e) => e.FeeId).HasColumnName("FEE_ID");
					entity.Property((SstFeesTiers e) => e.FeePercent).HasColumnName("FEE_PERCENT").HasColumnType("decimal(9,3)");
					entity.Property((SstFeesTiers e) => e.Location).HasColumnName("LOCATION");
					entity.Property((SstFeesTiers e) => e.MaxAmount).HasColumnName("MAX_AMOUNT").HasColumnType("decimal(9,3)");
					entity.Property((SstFeesTiers e) => e.MinAmount).HasColumnName("MIN_AMOUNT").HasColumnType("decimal(9,3)");
					entity.Property((SstFeesTiers e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstFeesTiers e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstFeesTiers e) => e.MultipleOf).HasColumnName("MULTIPLE_OF");
					entity.Property((SstFeesTiers e) => e.Origin).HasColumnName("ORIGIN");
					entity.Property((SstFeesTiers e) => e.PolicyType).HasColumnName("POLICY_TYPE");
					entity.Property((SstFeesTiers e) => e.RoundTo).HasColumnName("ROUND_TO");
					entity.Property((SstFeesTiers e) => e.SystemId).HasColumnName("SYSTEM_ID");
					entity.Property((SstFeesTiers e) => e.TaxCode).HasColumnName("TAX_CODE").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstFeesTiers e) => e.TermFrom).HasColumnName("TERM_FROM");
					entity.Property((SstFeesTiers e) => e.TermTo).HasColumnName("TERM_TO");
					entity.Property((SstFeesTiers e) => e.TierType).HasColumnName("TIER_TYPE");
					entity.Property((SstFeesTiers e) => e.VoucherSide).HasColumnName("VOUCHER_SIDE");
					entity.Property((SstFeesTiers e) => e.YearFrom).HasColumnName("YEAR_FROM");
					entity.Property((SstFeesTiers e) => e.YearTo).HasColumnName("YEAR_TO");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstFeesTiers>(entity.HasOne((SstFeesTiers d) => d.Class).WithMany((SstClasses p) => p.SstFeesTiers).HasForeignKey((SstFeesTiers d) => d.ClassId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_FEES_TIERS_FK03");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstFees, SstFeesTiers>(entity.HasOne((SstFeesTiers d) => d.Fee).WithMany((SstFees p) => p.SstFeesTiers).HasForeignKey((SstFeesTiers d) => d.FeeId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_FEES_TIERS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstFeesTiers>(entity.HasOne((SstFeesTiers d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstFeesTiers).HasForeignKey((SstFeesTiers d) => d.PolicyType), "SST_FEES_TIERS_FK04");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstFeesTiers>(entity.HasOne((SstFeesTiers d) => d.System).WithMany((SstSystems p) => p.SstFeesTiers).HasForeignKey((SstFeesTiers d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_FEES_TIERS_FK02");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstFeesTiersDetails> entity)
				{
					entity.ToTable("sst_fees_tiers_details");
					entity.HasIndex((Expression<Func<SstFeesTiersDetails, object>>)((SstFeesTiersDetails e) => e.CoverId)).HasName("SST_FEES_TIERS_DETAILS_FK02");
					entity.HasIndex((Expression<Func<SstFeesTiersDetails, object>>)((SstFeesTiersDetails e) => e.FeeTierId)).HasName("SST_FEES_TIERS_DETAILS_FK01");
					entity.Property((SstFeesTiersDetails e) => e.Id).HasColumnName("ID");
					entity.Property((SstFeesTiersDetails e) => e.Branch).HasColumnName("BRANCH");
					entity.Property((SstFeesTiersDetails e) => e.BusinessType).HasColumnName("BUSINESS_TYPE");
					entity.Property((SstFeesTiersDetails e) => e.CoverId).HasColumnName("COVER_ID");
					entity.Property((SstFeesTiersDetails e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstFeesTiersDetails e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstFeesTiersDetails e) => e.FeeTierId).HasColumnName("FEE_TIER_ID");
					entity.Property((SstFeesTiersDetails e) => e.Inclusion).HasColumnName("INCLUSION");
					entity.Property((SstFeesTiersDetails e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstFeesTiersDetails e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstFeesTiersDetails e) => e.Tpa).HasColumnName("TPA");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstCoverTypes, SstFeesTiersDetails>(entity.HasOne((SstFeesTiersDetails d) => d.Cover).WithMany((SstCoverTypes p) => p.SstFeesTiersDetails).HasForeignKey((SstFeesTiersDetails d) => d.CoverId), "SST_FEES_TIERS_DETAILS_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstFeesTiers, SstFeesTiersDetails>(entity.HasOne((SstFeesTiersDetails d) => d.FeeTier).WithMany((SstFeesTiers p) => p.SstFeesTiersDetails).HasForeignKey((SstFeesTiersDetails d) => d.FeeTierId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_FEES_TIERS_DETAILS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstFormControls> entity)
				{
					entity.ToTable("sst_form_controls");
					entity.HasIndex((Expression<Func<SstFormControls, object>>)((SstFormControls e) => e.ContainerId)).HasName("SST_FIELDS_FK01");
					entity.HasIndex((Expression<Func<SstFormControls, object>>)((SstFormControls e) => e.RefControlId)).HasName("SST_FIELDS_FK02");
					entity.Property((SstFormControls e) => e.Id).HasColumnName("ID");
					entity.Property((SstFormControls e) => e.ContainerId).HasColumnName("CONTAINER_ID");
					entity.Property((SstFormControls e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstFormControls e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstFormControls e) => e.Disabled).HasColumnName("DISABLED").HasDefaultValueSql("1");
					entity.Property((SstFormControls e) => e.HasSubformControls).HasColumnName("HAS_SUBFORM_CONTROLS");
					entity.Property((SstFormControls e) => e.Icon).HasColumnName("ICON").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstFormControls e) => e.Key).HasColumnName("KEY").HasMaxLength(124)
						.IsUnicode(unicode: false);
					entity.Property((SstFormControls e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstFormControls e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstFormControls e) => e.Name).HasColumnName("NAME").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstFormControls e) => e.Name2).HasColumnName("NAME2").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstFormControls e) => e.Notes).HasColumnName("NOTES").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstFormControls e) => e.Options).HasColumnName("OPTIONS").HasColumnType("longtext");
					entity.Property((SstFormControls e) => e.Order).HasColumnName("ORDER");
					entity.Property((SstFormControls e) => e.RefControlId).HasColumnName("REF_CONTROL_ID");
					entity.Property((SstFormControls e) => e.Required).HasColumnName("REQUIRED").HasDefaultValueSql("0");
					entity.Property((SstFormControls e) => e.Type).HasColumnName("TYPE");
					entity.Property((SstFormControls e) => e.Value).HasColumnName("VALUE");
					entity.Property((SstFormControls e) => e.Width).HasColumnName("WIDTH");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstContainers, SstFormControls>(entity.HasOne((SstFormControls d) => d.Container).WithMany((SstContainers p) => p.SstFormControls).HasForeignKey((SstFormControls d) => d.ContainerId), "SST_FIELDS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstFormControls, SstFormControls>(entity.HasOne((SstFormControls d) => d.RefControl).WithMany((SstFormControls p) => p.InverseRefControl).HasForeignKey((SstFormControls d) => d.RefControlId), "SST_FIELDS_FK02");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstFormElements> entity)
				{
					entity.ToTable("sst_form_elements");
					entity.HasIndex((Expression<Func<SstFormElements, object>>)((SstFormElements e) => e.FormId)).HasName("SST_FORM_ELEMENTS_FK01");
					entity.Property((SstFormElements e) => e.Id).HasColumnName("ID");
					entity.Property((SstFormElements e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstFormElements e) => e.CreationUser).HasColumnName("CREATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstFormElements e) => e.ElementControlname).IsRequired().HasColumnName("ELEMENT_CONTROLNAME")
						.HasMaxLength(500)
						.IsUnicode(unicode: false);
					entity.Property((SstFormElements e) => e.ElementIsdisable).HasColumnName("ELEMENT_ISDISABLE");
					entity.Property((SstFormElements e) => e.ElementIsrequeired).HasColumnName("ELEMENT_ISREQUEIRED");
					entity.Property((SstFormElements e) => e.ElementLabel).IsRequired().HasColumnName("ELEMENT_LABEL")
						.HasMaxLength(500)
						.IsUnicode(unicode: false);
					entity.Property((SstFormElements e) => e.ElementOption).HasColumnName("ELEMENT_OPTION").HasMaxLength(500)
						.IsUnicode(unicode: false);
					entity.Property((SstFormElements e) => e.ElementOrder).HasColumnName("ELEMENT_ORDER");
					entity.Property((SstFormElements e) => e.ElementSource).HasColumnName("ELEMENT_SOURCE").HasMaxLength(100)
						.IsUnicode(unicode: false);
					entity.Property((SstFormElements e) => e.ElementType).IsRequired().HasColumnName("ELEMENT_TYPE")
						.HasMaxLength(500)
						.IsUnicode(unicode: false);
					entity.Property((SstFormElements e) => e.FormId).HasColumnName("FORM_ID");
					entity.Property((SstFormElements e) => e.Language).HasColumnName("LANGUAGE");
					entity.Property((SstFormElements e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstFormElements e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstForms, SstFormElements>(entity.HasOne((SstFormElements d) => d.Form).WithMany((SstForms p) => p.SstFormElements).HasForeignKey((SstFormElements d) => d.FormId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_FORM_ELEMENTS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstFormGrid> entity)
				{
					entity.ToTable("sst_form_grid");
					entity.HasIndex((Expression<Func<SstFormGrid, object>>)((SstFormGrid e) => e.FormId)).HasName("SST_FORM_GRID_FK01");
					entity.Property((SstFormGrid e) => e.Id).HasColumnName("ID");
					entity.Property((SstFormGrid e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstFormGrid e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstFormGrid e) => e.FieldOrder).HasColumnName("FIELD_ORDER");
					entity.Property((SstFormGrid e) => e.FormId).HasColumnName("FORM_ID");
					entity.Property((SstFormGrid e) => e.GridField).IsRequired().HasColumnName("GRID_FIELD")
						.HasMaxLength(50)
						.IsUnicode(unicode: false);
					entity.Property((SstFormGrid e) => e.GridHeader).IsRequired().HasColumnName("GRID_HEADER")
						.HasMaxLength(100)
						.IsUnicode(unicode: false);
					entity.Property((SstFormGrid e) => e.Language).HasColumnName("LANGUAGE");
					entity.Property((SstFormGrid e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstFormGrid e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstForms, SstFormGrid>(entity.HasOne((SstFormGrid d) => d.Form).WithMany((SstForms p) => p.SstFormGrid).HasForeignKey((SstFormGrid d) => d.FormId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_FORM_GRID_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstFormSystems> entity)
				{
					entity.ToTable("sst_form_systems");
					entity.HasIndex((Expression<Func<SstFormSystems, object>>)((SstFormSystems e) => e.FormId)).HasName("SST_FORM_SYSTEMS_FK02");
					entity.HasIndex((Expression<Func<SstFormSystems, object>>)((SstFormSystems e) => e.SystemId)).HasName("SST_FORM_SYSTEMS_FK01");
					entity.Property((SstFormSystems e) => e.Id).HasColumnName("ID");
					entity.Property((SstFormSystems e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstFormSystems e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstFormSystems e) => e.FormId).HasColumnName("FORM_ID");
					entity.Property((SstFormSystems e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstFormSystems e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstFormSystems e) => e.SystemId).HasColumnName("SYSTEM_ID");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstForms, SstFormSystems>(entity.HasOne((SstFormSystems d) => d.Form).WithMany((SstForms p) => p.SstFormSystems).HasForeignKey((SstFormSystems d) => d.FormId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_FORM_SYSTEMS_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstFormSystems>(entity.HasOne((SstFormSystems d) => d.System).WithMany((SstSystems p) => p.SstFormSystems).HasForeignKey((SstFormSystems d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_FORM_SYSTEMS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstForms> entity)
				{
					entity.ToTable("sst_forms");
					entity.Property((SstForms e) => e.Id).HasColumnName("ID");
					entity.Property((SstForms e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstForms e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstForms e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstForms e) => e.FormActionLabel).HasColumnName("FORM_ACTION_LABEL").HasMaxLength(100)
						.IsUnicode(unicode: false);
					entity.Property((SstForms e) => e.FormActionType).IsRequired().HasColumnName("FORM_ACTION_TYPE")
						.HasMaxLength(50)
						.IsUnicode(unicode: false);
					entity.Property((SstForms e) => e.FormGroupName).HasColumnName("FORM_GROUP_NAME").HasMaxLength(100)
						.IsUnicode(unicode: false);
					entity.Property((SstForms e) => e.FormHeader).IsRequired().HasColumnName("FORM_HEADER")
						.HasMaxLength(50)
						.IsUnicode(unicode: false);
					entity.Property((SstForms e) => e.FromOrder).HasColumnName("FROM_ORDER");
					entity.Property((SstForms e) => e.Language).HasColumnName("LANGUAGE");
					entity.Property((SstForms e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstForms e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstForms e) => e.PageId).HasColumnName("PAGE_ID");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstIndustrySectors> entity)
				{
					entity.ToTable("sst_industry_sectors");
					entity.HasIndex((Expression<Func<SstIndustrySectors, object>>)((SstIndustrySectors e) => e.SectorId)).HasName("SST_INDUSTRY_SECTORS_FK01");
					entity.Property((SstIndustrySectors e) => e.Id).HasColumnName("ID");
					entity.Property((SstIndustrySectors e) => e.Abbreviation).HasColumnName("ABBREVIATION").HasMaxLength(6)
						.IsUnicode(unicode: false);
					entity.Property((SstIndustrySectors e) => e.Code).IsRequired().HasColumnName("CODE")
						.HasMaxLength(10)
						.IsUnicode(unicode: false);
					entity.Property((SstIndustrySectors e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstIndustrySectors e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstIndustrySectors e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstIndustrySectors e) => e.Industry).HasColumnName("INDUSTRY");
					entity.Property((SstIndustrySectors e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstIndustrySectors e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstIndustrySectors e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstIndustrySectors e) => e.Name2).HasColumnName("NAME2").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstIndustrySectors e) => e.Notes).HasColumnName("NOTES").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstIndustrySectors e) => e.SectorId).HasColumnName("SECTOR_ID");
					entity.Property((SstIndustrySectors e) => e.SegmentCode).IsRequired().HasColumnName("SEGMENT_CODE")
						.HasMaxLength(24)
						.IsUnicode(unicode: false);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstIndustrySectors, SstIndustrySectors>(entity.HasOne((SstIndustrySectors d) => d.Sector).WithMany((SstIndustrySectors p) => p.InverseSector).HasForeignKey((SstIndustrySectors d) => d.SectorId), "SST_INDUSTRY_SECTORS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstIntegrations> entity)
				{
					entity.ToTable("sst_integrations");
					entity.HasIndex((Expression<Func<SstIntegrations, object>>)((SstIntegrations e) => e.SystemId)).HasName("SST_INTEGRATIONS_FK01");
					entity.Property((SstIntegrations e) => e.Id).HasColumnName("ID");
					entity.Property((SstIntegrations e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstIntegrations e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstIntegrations e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstIntegrations e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstIntegrations e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstIntegrations e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstIntegrations e) => e.Name2).HasColumnName("NAME2").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstIntegrations e) => e.Notes).HasColumnName("NOTES").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstIntegrations e) => e.SourceType).HasColumnName("SOURCE_TYPE");
					entity.Property((SstIntegrations e) => e.SystemId).HasColumnName("SYSTEM_ID");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstIntegrations>(entity.HasOne((SstIntegrations d) => d.System).WithMany((SstSystems p) => p.SstIntegrations).HasForeignKey((SstIntegrations d) => d.SystemId), "SST_INTEGRATIONS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstIntegrationsApiMapping> entity)
				{
					entity.ToTable("sst_integrations_api_mapping");
					entity.Property((SstIntegrationsApiMapping e) => e.Id).HasColumnName("ID");
					entity.Property((SstIntegrationsApiMapping e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstIntegrationsApiMapping e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstIntegrationsApiMapping e) => e.DefaultValue).HasColumnName("DEFAULT_VALUE").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstIntegrationsApiMapping e) => e.ElementId).HasColumnName("ELEMENT_ID");
					entity.Property((SstIntegrationsApiMapping e) => e.ElementKey).HasColumnName("ELEMENT_KEY").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstIntegrationsApiMapping e) => e.ElementParent).HasColumnName("ELEMENT_PARENT");
					entity.Property((SstIntegrationsApiMapping e) => e.ElementType).HasColumnName("ELEMENT_TYPE");
					entity.Property((SstIntegrationsApiMapping e) => e.MappingType).HasColumnName("MAPPING_TYPE");
					entity.Property((SstIntegrationsApiMapping e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstIntegrationsApiMapping e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstIntegrationsApiMapping e) => e.Order).HasColumnName("ORDER");
					entity.Property((SstIntegrationsApiMapping e) => e.ParamName).HasColumnName("PARAM_NAME").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstIntegrationsApiMapping e) => e.ParamType).HasColumnName("PARAM_TYPE").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstIntegrationsApiMapping e) => e.SettingId).HasColumnName("SETTING_ID");
					entity.Property((SstIntegrationsApiMapping e) => e.StepId).HasColumnName("STEP_ID");
					entity.Property((SstIntegrationsApiMapping e) => e.TransactionType).HasColumnName("TRANSACTION_TYPE");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstIntegrationsApiObject> entity)
				{
					entity.ToTable("sst_integrations_api_object");
					entity.Property((SstIntegrationsApiObject e) => e.Id).HasColumnName("ID");
					entity.Property((SstIntegrationsApiObject e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstIntegrationsApiObject e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstIntegrationsApiObject e) => e.DefaultValue).HasColumnName("DEFAULT_VALUE").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstIntegrationsApiObject e) => e.ElementId).HasColumnName("ELEMENT_ID");
					entity.Property((SstIntegrationsApiObject e) => e.ElementKey).HasColumnName("ELEMENT_KEY").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstIntegrationsApiObject e) => e.ElementParent).HasColumnName("ELEMENT_PARENT");
					entity.Property((SstIntegrationsApiObject e) => e.ElementType).HasColumnName("ELEMENT_TYPE");
					entity.Property((SstIntegrationsApiObject e) => e.MappingId).HasColumnName("MAPPING_ID");
					entity.Property((SstIntegrationsApiObject e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstIntegrationsApiObject e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstIntegrationsApiObject e) => e.Order).HasColumnName("ORDER");
					entity.Property((SstIntegrationsApiObject e) => e.ParamName).HasColumnName("PARAM_NAME").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstIntegrationsApiObject e) => e.ParamType).HasColumnName("PARAM_TYPE").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstIntegrationsApiObject e) => e.StepId).HasColumnName("STEP_ID");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstIntegrationsDbMapping> entity)
				{
					entity.ToTable("sst_integrations_db_mapping");
					entity.Property((SstIntegrationsDbMapping e) => e.Id).HasColumnName("ID");
					entity.Property((SstIntegrationsDbMapping e) => e.ColumnName).HasColumnName("COLUMN_NAME").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstIntegrationsDbMapping e) => e.ColumnType).HasColumnName("COLUMN_TYPE").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstIntegrationsDbMapping e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstIntegrationsDbMapping e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstIntegrationsDbMapping e) => e.DefaultValue).HasColumnName("DEFAULT_VALUE").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstIntegrationsDbMapping e) => e.ElemenetParent).HasColumnName("ELEMENET_PARENT");
					entity.Property((SstIntegrationsDbMapping e) => e.ElementId).HasColumnName("ELEMENT_ID");
					entity.Property((SstIntegrationsDbMapping e) => e.ElementKey).HasColumnName("ELEMENT_KEY").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstIntegrationsDbMapping e) => e.ElementType).HasColumnName("ELEMENT_TYPE");
					entity.Property((SstIntegrationsDbMapping e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstIntegrationsDbMapping e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstIntegrationsDbMapping e) => e.SettingId).HasColumnName("SETTING_ID");
					entity.Property((SstIntegrationsDbMapping e) => e.TableName).HasColumnName("TABLE_NAME").HasMaxLength(255)
						.IsUnicode(unicode: false);
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstIntegrationsSettings> entity)
				{
					entity.ToTable("sst_integrations_settings");
					entity.HasIndex((Expression<Func<SstIntegrationsSettings, object>>)((SstIntegrationsSettings e) => e.IntegrationId)).HasName("SST_INTEGRATIONS_SETTINGS_FK01");
					entity.HasIndex((Expression<Func<SstIntegrationsSettings, object>>)((SstIntegrationsSettings e) => e.ProductId)).HasName("SST_INTEGRATIONS_SETTINGS_FK02");
					entity.Property((SstIntegrationsSettings e) => e.Id).HasColumnName("ID");
					entity.Property((SstIntegrationsSettings e) => e.ApiName).HasColumnName("API_NAME").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstIntegrationsSettings e) => e.ApiSourceType).HasColumnName("API_SOURCE_TYPE");
					entity.Property((SstIntegrationsSettings e) => e.ApiType).HasColumnName("API_TYPE");
					entity.Property((SstIntegrationsSettings e) => e.ApiUrl).HasColumnName("API_URL").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstIntegrationsSettings e) => e.AuthType).HasColumnName("AUTH_TYPE");
					entity.Property((SstIntegrationsSettings e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstIntegrationsSettings e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstIntegrationsSettings e) => e.DbHost).HasColumnName("DB_HOST").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstIntegrationsSettings e) => e.DbPassword).HasColumnName("DB_PASSWORD").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstIntegrationsSettings e) => e.DbPort).HasColumnName("DB_PORT");
					entity.Property((SstIntegrationsSettings e) => e.DbSchema).HasColumnName("DB_SCHEMA").HasMaxLength(225)
						.IsUnicode(unicode: false);
					entity.Property((SstIntegrationsSettings e) => e.DbService).HasColumnName("DB_SERVICE").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstIntegrationsSettings e) => e.DbType).HasColumnName("DB_TYPE");
					entity.Property((SstIntegrationsSettings e) => e.DbUser).HasColumnName("DB_USER").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstIntegrationsSettings e) => e.HttpType).HasColumnName("HTTP_TYPE");
					entity.Property((SstIntegrationsSettings e) => e.IntegrationId).HasColumnName("INTEGRATION_ID");
					entity.Property((SstIntegrationsSettings e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstIntegrationsSettings e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstIntegrationsSettings e) => e.ModuleCode).HasColumnName("MODULE_CODE");
					entity.Property((SstIntegrationsSettings e) => e.ProductId).HasColumnName("PRODUCT_ID");
					entity.Property((SstIntegrationsSettings e) => e.ServiceMethod).HasColumnName("SERVICE_METHOD").HasMaxLength(4000)
						.IsUnicode(unicode: false);
					entity.Property((SstIntegrationsSettings e) => e.UrlType).HasColumnName("URL_TYPE");
					entity.Property((SstIntegrationsSettings e) => e.XmlStructure).HasColumnName("XML_STRUCTURE").HasColumnType("longblob");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstIntegrations, SstIntegrationsSettings>(entity.HasOne((SstIntegrationsSettings d) => d.Integration).WithMany((SstIntegrations p) => p.SstIntegrationsSettings).HasForeignKey((SstIntegrationsSettings d) => d.IntegrationId), "SST_INTEGRATIONS_SETTINGS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SpdProducts, SstIntegrationsSettings>(entity.HasOne((SstIntegrationsSettings d) => d.Product).WithMany((SpdProducts p) => p.SstIntegrationsSettings).HasForeignKey((SstIntegrationsSettings d) => d.ProductId), "SST_INTEGRATIONS_SETTINGS_FK02");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstLogs> entity)
				{
					entity.ToTable("sst_logs");
					entity.Property((SstLogs e) => e.Id).HasColumnName("ID");
					entity.Property((SstLogs e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstLogs e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstLogs e) => e.Date).HasColumnName("DATE_");
					entity.Property((SstLogs e) => e.IoType).HasColumnName("IO_TYPE");
					entity.Property((SstLogs e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstLogs e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstLogs e) => e.Notes).HasColumnName("NOTES").HasMaxLength(2048)
						.IsUnicode(unicode: false);
					entity.Property((SstLogs e) => e.Status).HasColumnName("STATUS");
					entity.Property((SstLogs e) => e.StatusCode).HasColumnName("STATUS_CODE").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstLogs e) => e.TransactionType).HasColumnName("TRANSACTION_TYPE");
					entity.Property((SstLogs e) => e.Url).HasColumnName("URL").HasMaxLength(255)
						.IsUnicode(unicode: false);
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstLogsDetails> entity)
				{
					entity.ToTable("sst_logs_details");
					entity.HasIndex((Expression<Func<SstLogsDetails, object>>)((SstLogsDetails e) => e.LogId)).HasName("SST_LOGS_DETAILS_FK01");
					entity.Property((SstLogsDetails e) => e.Id).HasColumnName("ID");
					entity.Property((SstLogsDetails e) => e.Content).HasColumnName("CONTENT").HasColumnType("longtext");
					entity.Property((SstLogsDetails e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstLogsDetails e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstLogsDetails e) => e.LogId).HasColumnName("LOG_ID");
					entity.Property((SstLogsDetails e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstLogsDetails e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstLogsDetails e) => e.ProcessDate).HasColumnName("PROCESS_DATE");
					entity.Property((SstLogsDetails e) => e.Type).HasColumnName("TYPE");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstLogs, SstLogsDetails>(entity.HasOne((SstLogsDetails d) => d.Log).WithMany((SstLogs p) => p.SstLogsDetails).HasForeignKey((SstLogsDetails d) => d.LogId), "SST_LOGS_DETAILS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstMailer> entity)
				{
					entity.ToTable("sst_mailer");
					entity.HasIndex((Expression<Func<SstMailer, object>>)((SstMailer e) => e.SystemId)).HasName("SST_MAILER_FK01");
					entity.Property((SstMailer e) => e.Id).HasColumnName("ID");
					entity.Property((SstMailer e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstMailer e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstMailer e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstMailer e) => e.Host).HasColumnName("HOST").HasMaxLength(32)
						.IsUnicode(unicode: false);
					entity.Property((SstMailer e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstMailer e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstMailer e) => e.Password).HasColumnName("PASSWORD").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstMailer e) => e.Port).HasColumnName("PORT");
					entity.Property((SstMailer e) => e.Security).HasColumnName("SECURITY");
					entity.Property((SstMailer e) => e.SystemId).HasColumnName("SYSTEM_ID");
					entity.Property((SstMailer e) => e.Type).HasColumnName("TYPE");
					entity.Property((SstMailer e) => e.Username).HasColumnName("USERNAME").HasMaxLength(255)
						.IsUnicode(unicode: false);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstMailer>(entity.HasOne((SstMailer d) => d.System).WithMany((SstSystems p) => p.SstMailer).HasForeignKey((SstMailer d) => d.SystemId), "SST_MAILER_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstMappings> entity)
				{
					entity.ToTable("sst_mappings");
					entity.Property((SstMappings e) => e.Id).HasColumnName("ID");
					entity.Property((SstMappings e) => e.ApiType).HasColumnName("API_TYPE");
					entity.Property((SstMappings e) => e.ApiUrl).HasColumnName("API_URL").HasColumnType("longblob");
					entity.Property((SstMappings e) => e.AuthType).HasColumnName("AUTH_TYPE");
					entity.Property((SstMappings e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstMappings e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstMappings e) => e.DbHost).HasColumnName("DB_HOST").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstMappings e) => e.DbPassword).HasColumnName("DB_PASSWORD").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstMappings e) => e.DbPort).HasColumnName("DB_PORT");
					entity.Property((SstMappings e) => e.DbService).HasColumnName("DB_SERVICE").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstMappings e) => e.DbType).HasColumnName("DB_TYPE");
					entity.Property((SstMappings e) => e.DbUser).HasColumnName("DB_USER").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstMappings e) => e.IntegrationId).HasColumnName("INTEGRATION_ID");
					entity.Property((SstMappings e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstMappings e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstMappings e) => e.ModuleCode).HasColumnName("MODULE_CODE");
					entity.Property((SstMappings e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstMappings e) => e.Name2).HasColumnName("NAME2").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstMappings e) => e.Notes).HasColumnName("NOTES").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstMappings e) => e.SourceType).HasColumnName("SOURCE_TYPE");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstMatrixParamsMapping> entity)
				{
					entity.ToTable("sst_matrix_params_mapping");
					entity.HasIndex((Expression<Func<SstMatrixParamsMapping, object>>)((SstMatrixParamsMapping e) => e.SystemId)).HasName("SYS_C002285608");
					entity.Property((SstMatrixParamsMapping e) => e.Id).HasColumnName("ID");
					entity.Property((SstMatrixParamsMapping e) => e.ColumnName).IsRequired().HasColumnName("COLUMN_NAME")
						.HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstMatrixParamsMapping e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstMatrixParamsMapping e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstMatrixParamsMapping e) => e.DataType).HasColumnName("DATA_TYPE");
					entity.Property((SstMatrixParamsMapping e) => e.FormulaColumn).HasColumnName("FORMULA_COLUMN").HasMaxLength(4000)
						.IsUnicode(unicode: false);
					entity.Property((SstMatrixParamsMapping e) => e.Lob).HasColumnName("LOB");
					entity.Property((SstMatrixParamsMapping e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstMatrixParamsMapping e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstMatrixParamsMapping e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstMatrixParamsMapping e) => e.ParamType).HasColumnName("PARAM_TYPE");
					entity.Property((SstMatrixParamsMapping e) => e.ReferenceId).HasColumnName("REFERENCE_ID");
					entity.Property((SstMatrixParamsMapping e) => e.Source).HasColumnName("SOURCE");
					entity.Property((SstMatrixParamsMapping e) => e.SystemId).HasColumnName("SYSTEM_ID");
					entity.Property((SstMatrixParamsMapping e) => e.TableName).IsRequired().HasColumnName("TABLE_NAME")
						.HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstMatrixParamsMapping e) => e.ValueFrom).HasColumnName("VALUE_FROM").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstMatrixParamsMapping e) => e.ValueTo).HasColumnName("VALUE_TO").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstMatrixParamsMapping>(entity.HasOne((SstMatrixParamsMapping d) => d.System).WithMany((SstSystems p) => p.SstMatrixParamsMapping).HasForeignKey((SstMatrixParamsMapping d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C002285608");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstModules> entity)
				{
					entity.HasKey((SstModules e) => e.Code);
					entity.ToTable("sst_modules");
					entity.HasIndex((Expression<Func<SstModules, object>>)((SstModules e) => e.SystemId)).HasName("SST_MODULES_FK01");
					entity.Property((SstModules e) => e.Code).HasColumnName("CODE").HasMaxLength(15)
						.IsUnicode(unicode: false)
						.ValueGeneratedNever();
					entity.Property((SstModules e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstModules e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstModules e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstModules e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstModules e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstModules e) => e.Name2).HasColumnName("NAME2").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstModules e) => e.Notes).HasColumnName("NOTES").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstModules e) => e.SystemId).HasColumnName("SYSTEM_ID");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstModules>(entity.HasOne((SstModules d) => d.System).WithMany((SstSystems p) => p.SstModules).HasForeignKey((SstModules d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_MODULES_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstNotifications> entity)
				{
					entity.ToTable("sst_notifications");
					entity.HasIndex((Expression<Func<SstNotifications, object>>)((SstNotifications e) => e.SystemId)).HasName("SST_NOTIFICATIONS_FK01");
					entity.Property((SstNotifications e) => e.Id).HasColumnName("ID");
					entity.Property((SstNotifications e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstNotifications e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstNotifications e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstNotifications e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstNotifications e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstNotifications e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(225)
						.IsUnicode(unicode: false);
					entity.Property((SstNotifications e) => e.Name2).HasColumnName("NAME2").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstNotifications e) => e.Notes).HasColumnName("NOTES").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstNotifications e) => e.SessionKey).HasColumnName("SESSION_KEY").HasMaxLength(128)
						.IsUnicode(unicode: false);
					entity.Property((SstNotifications e) => e.Status).HasColumnName("STATUS");
					entity.Property((SstNotifications e) => e.SystemId).HasColumnName("SYSTEM_ID");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstNotifications>(entity.HasOne((SstNotifications d) => d.System).WithMany((SstSystems p) => p.SstNotifications).HasForeignKey((SstNotifications d) => d.SystemId), "SST_NOTIFICATIONS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstNotificationsAttachments> entity)
				{
					entity.ToTable("sst_notifications_attachments");
					entity.Property((SstNotificationsAttachments e) => e.Id).HasColumnName("ID");
					entity.Property((SstNotificationsAttachments e) => e.AttachPath).HasColumnName("ATTACH_PATH").HasMaxLength(256)
						.IsUnicode(unicode: false);
					entity.Property((SstNotificationsAttachments e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstNotificationsAttachments e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstNotificationsAttachments e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstNotificationsAttachments e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstNotificationsAttachments e) => e.NotificationId).HasColumnName("NOTIFICATION_ID");
					entity.Property((SstNotificationsAttachments e) => e.Order).HasColumnName("ORDER");
					entity.Property((SstNotificationsAttachments e) => e.ReportCode).HasColumnName("REPORT_CODE").HasMaxLength(40)
						.IsUnicode(unicode: false);
					entity.Property((SstNotificationsAttachments e) => e.Status).HasColumnName("STATUS");
					entity.Property((SstNotificationsAttachments e) => e.Type).HasColumnName("TYPE");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstNotificationsContacts> entity)
				{
					entity.ToTable("sst_notifications_contacts");
					entity.Property((SstNotificationsContacts e) => e.Id).HasColumnName("ID");
					entity.Property((SstNotificationsContacts e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstNotificationsContacts e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstNotificationsContacts e) => e.GroupId).HasColumnName("GROUP_ID");
					entity.Property((SstNotificationsContacts e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstNotificationsContacts e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstNotificationsContacts e) => e.TemplateId).HasColumnName("TEMPLATE_ID");
					entity.Property((SstNotificationsContacts e) => e.Type).HasColumnName("TYPE");
					entity.Property((SstNotificationsContacts e) => e.Username).HasColumnName("USERNAME").HasMaxLength(80)
						.IsUnicode(unicode: false);
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstNotificationsLogs> entity)
				{
					entity.ToTable("sst_notifications_logs");
					entity.Property((SstNotificationsLogs e) => e.Id).HasColumnName("ID");
					entity.Property((SstNotificationsLogs e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstNotificationsLogs e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstNotificationsLogs e) => e.KeyType).HasColumnName("KEY_TYPE");
					entity.Property((SstNotificationsLogs e) => e.KeyValue).HasColumnName("KEY_VALUE").HasMaxLength(256)
						.IsUnicode(unicode: false);
					entity.Property((SstNotificationsLogs e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstNotificationsLogs e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstNotificationsLogs e) => e.NotificationId).HasColumnName("NOTIFICATION_ID");
					entity.Property((SstNotificationsLogs e) => e.Request).HasColumnName("REQUEST").HasMaxLength(2048)
						.IsUnicode(unicode: false);
					entity.Property((SstNotificationsLogs e) => e.RequestDate).HasColumnName("REQUEST_DATE");
					entity.Property((SstNotificationsLogs e) => e.Response).HasColumnName("RESPONSE").HasMaxLength(2048)
						.IsUnicode(unicode: false);
					entity.Property((SstNotificationsLogs e) => e.ResponseDate).HasColumnName("RESPONSE_DATE");
					entity.Property((SstNotificationsLogs e) => e.Status).HasColumnName("STATUS");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstNotificationsParameters> entity)
				{
					entity.ToTable("sst_notifications_parameters");
					entity.Property((SstNotificationsParameters e) => e.Id).HasColumnName("ID");
					entity.Property((SstNotificationsParameters e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstNotificationsParameters e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstNotificationsParameters e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstNotificationsParameters e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstNotificationsParameters e) => e.NotificationId).HasColumnName("NOTIFICATION_ID");
					entity.Property((SstNotificationsParameters e) => e.ParameterRef).HasColumnName("PARAMETER_REF");
					entity.Property((SstNotificationsParameters e) => e.ParameterType).HasColumnName("PARAMETER_TYPE");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstNotificationsTemplates> entity)
				{
					entity.ToTable("sst_notifications_templates");
					entity.Property((SstNotificationsTemplates e) => e.Id).HasColumnName("ID");
					entity.Property((SstNotificationsTemplates e) => e.Body).HasColumnName("BODY").HasColumnType("longblob");
					entity.Property((SstNotificationsTemplates e) => e.Body2).HasColumnName("BODY2").HasColumnType("longblob");
					entity.Property((SstNotificationsTemplates e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstNotificationsTemplates e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstNotificationsTemplates e) => e.From).HasColumnName("FROM_").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstNotificationsTemplates e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstNotificationsTemplates e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstNotificationsTemplates e) => e.NotificationId).HasColumnName("NOTIFICATION_ID");
					entity.Property((SstNotificationsTemplates e) => e.Subject).HasColumnName("SUBJECT").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstNotificationsTemplates e) => e.Subject2).HasColumnName("SUBJECT2").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstNotificationsTemplates e) => e.Type).HasColumnName("TYPE");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstOffices> entity)
				{
					entity.ToTable("sst_offices");
					entity.HasIndex((Expression<Func<SstOffices, object>>)((SstOffices e) => e.SystemId)).HasName("SST_OFFICES_FK01");
					entity.Property((SstOffices e) => e.Id).HasColumnName("ID");
					entity.Property((SstOffices e) => e.Code).IsRequired().HasColumnName("CODE")
						.HasMaxLength(100)
						.IsUnicode(unicode: false);
					entity.Property((SstOffices e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstOffices e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstOffices e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstOffices e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstOffices e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstOffices e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(100)
						.IsUnicode(unicode: false);
					entity.Property((SstOffices e) => e.Name2).HasColumnName("NAME2").HasMaxLength(100)
						.IsUnicode(unicode: false);
					entity.Property((SstOffices e) => e.SystemId).HasColumnName("SYSTEM_ID");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstOffices>(entity.HasOne((SstOffices d) => d.System).WithMany((SstSystems p) => p.SstOffices).HasForeignKey((SstOffices d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_OFFICES_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstPackagedPolicy> entity)
				{
					entity.ToTable("sst_packaged_policy");
					entity.Property((SstPackagedPolicy e) => e.Id).HasColumnName("ID");
					entity.Property((SstPackagedPolicy e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstPackagedPolicy e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstPackagedPolicy e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstPackagedPolicy e) => e.EffectiveDate).HasColumnName("EFFECTIVE_DATE");
					entity.Property((SstPackagedPolicy e) => e.ExpiryDate).HasColumnName("EXPIRY_DATE");
					entity.Property((SstPackagedPolicy e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstPackagedPolicy e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstPackagedPolicy e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(100)
						.IsUnicode(unicode: false);
					entity.Property((SstPackagedPolicy e) => e.Name2).HasColumnName("NAME2").HasMaxLength(100)
						.IsUnicode(unicode: false);
					entity.Property((SstPackagedPolicy e) => e.ShortName).HasColumnName("SHORT_NAME").HasMaxLength(10)
						.IsUnicode(unicode: false);
					entity.Property((SstPackagedPolicy e) => e.Status).HasColumnName("STATUS");
					entity.Property((SstPackagedPolicy e) => e.StatusDate).HasColumnName("STATUS_DATE");
					entity.Property((SstPackagedPolicy e) => e.SystemId).HasColumnName("SYSTEM_ID");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstPackagedPolicyDetails> entity)
				{
					entity.ToTable("sst_packaged_policy_details");
					entity.HasIndex((Expression<Func<SstPackagedPolicyDetails, object>>)((SstPackagedPolicyDetails e) => e.ClassId)).HasName("SYS_C002285413");
					entity.HasIndex((Expression<Func<SstPackagedPolicyDetails, object>>)((SstPackagedPolicyDetails e) => e.PackagedId)).HasName("SYS_C002285412");
					entity.HasIndex((Expression<Func<SstPackagedPolicyDetails, object>>)((SstPackagedPolicyDetails e) => e.PolicyType)).HasName("SYS_C002285414");
					entity.Property((SstPackagedPolicyDetails e) => e.Id).HasColumnName("ID");
					entity.Property((SstPackagedPolicyDetails e) => e.ClassId).HasColumnName("CLASS_ID");
					entity.Property((SstPackagedPolicyDetails e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstPackagedPolicyDetails e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstPackagedPolicyDetails e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstPackagedPolicyDetails e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstPackagedPolicyDetails e) => e.PackagedId).HasColumnName("PACKAGED_ID");
					entity.Property((SstPackagedPolicyDetails e) => e.PolicyType).HasColumnName("POLICY_TYPE");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstPackagedPolicyDetails>(entity.HasOne((SstPackagedPolicyDetails d) => d.Class).WithMany((SstClasses p) => p.SstPackagedPolicyDetails).HasForeignKey((SstPackagedPolicyDetails d) => d.ClassId), "SYS_C002285413");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPackagedPolicy, SstPackagedPolicyDetails>(entity.HasOne((SstPackagedPolicyDetails d) => d.Packaged).WithMany((SstPackagedPolicy p) => p.SstPackagedPolicyDetails).HasForeignKey((SstPackagedPolicyDetails d) => d.PackagedId), "SYS_C002285412");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstPackagedPolicyDetails>(entity.HasOne((SstPackagedPolicyDetails d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstPackagedPolicyDetails).HasForeignKey((SstPackagedPolicyDetails d) => d.PolicyType), "SYS_C002285414");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstPackegedCovers> entity)
				{
					entity.ToTable("sst_packeged_covers");
					entity.HasIndex((Expression<Func<SstPackegedCovers, object>>)((SstPackegedCovers e) => e.ClassId)).HasName("SYS_C002312420");
					entity.HasIndex((Expression<Func<SstPackegedCovers, object>>)((SstPackegedCovers e) => e.CoverType)).HasName("SYS_C002312422");
					entity.HasIndex((Expression<Func<SstPackegedCovers, object>>)((SstPackegedCovers e) => e.MatrixId)).HasName("SYS_C002312423");
					entity.HasIndex((Expression<Func<SstPackegedCovers, object>>)((SstPackegedCovers e) => e.PackagedId)).HasName("SYS_C002312419");
					entity.HasIndex((Expression<Func<SstPackegedCovers, object>>)((SstPackegedCovers e) => e.PolicyType)).HasName("SYS_C002312421");
					entity.Property((SstPackegedCovers e) => e.Id).HasColumnName("ID");
					entity.Property((SstPackegedCovers e) => e.ClassId).HasColumnName("CLASS_ID");
					entity.Property((SstPackegedCovers e) => e.CoverType).HasColumnName("COVER_TYPE");
					entity.Property((SstPackegedCovers e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstPackegedCovers e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstPackegedCovers e) => e.FormulaRate).HasColumnName("FORMULA_RATE").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstPackegedCovers e) => e.MatrixId).HasColumnName("MATRIX_ID");
					entity.Property((SstPackegedCovers e) => e.MatrixName).HasColumnName("MATRIX_NAME").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstPackegedCovers e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstPackegedCovers e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstPackegedCovers e) => e.PackagedId).HasColumnName("PACKAGED_ID");
					entity.Property((SstPackegedCovers e) => e.PolicyType).HasColumnName("POLICY_TYPE");
					entity.Property((SstPackegedCovers e) => e.RatingType).HasColumnName("RATING_TYPE");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstPackegedCovers>(entity.HasOne((SstPackegedCovers d) => d.Class).WithMany((SstClasses p) => p.SstPackegedCovers).HasForeignKey((SstPackegedCovers d) => d.ClassId), "SYS_C002312420");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstCoverTypes, SstPackegedCovers>(entity.HasOne((SstPackegedCovers d) => d.CoverTypeNavigation).WithMany((SstCoverTypes p) => p.SstPackegedCovers).HasForeignKey((SstPackegedCovers d) => d.CoverType), "SYS_C002312422");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstRatingMatrix, SstPackegedCovers>(entity.HasOne((SstPackegedCovers d) => d.Matrix).WithMany((SstRatingMatrix p) => p.SstPackegedCovers).HasForeignKey((SstPackegedCovers d) => d.MatrixId), "SYS_C002312423");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPackagedPolicy, SstPackegedCovers>(entity.HasOne((SstPackegedCovers d) => d.Packaged).WithMany((SstPackagedPolicy p) => p.SstPackegedCovers).HasForeignKey((SstPackegedCovers d) => d.PackagedId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C002312419");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstPackegedCovers>(entity.HasOne((SstPackegedCovers d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstPackegedCovers).HasForeignKey((SstPackegedCovers d) => d.PolicyType), "SYS_C002312421");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstPackegedCoversMatrix> entity)
				{
					entity.ToTable("sst_packeged_covers_matrix");
					entity.HasIndex((Expression<Func<SstPackegedCoversMatrix, object>>)((SstPackegedCoversMatrix e) => e.PackagedCoverId)).HasName("SYS_C002312430");
					entity.Property((SstPackegedCoversMatrix e) => e.Id).HasColumnName("ID");
					entity.Property((SstPackegedCoversMatrix e) => e.ApplyAgentComm).HasColumnName("APPLY_AGENT_COMM");
					entity.Property((SstPackegedCoversMatrix e) => e.ApplyPremium).HasColumnName("APPLY_PREMIUM");
					entity.Property((SstPackegedCoversMatrix e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstPackegedCoversMatrix e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstPackegedCoversMatrix e) => e.DedAmount).HasColumnName("DED_AMOUNT").HasColumnType("decimal(18,3)");
					entity.Property((SstPackegedCoversMatrix e) => e.DedPercent).HasColumnName("DED_PERCENT").HasColumnType("decimal(9,3)");
					entity.Property((SstPackegedCoversMatrix e) => e.IsActive).HasColumnName("IS_ACTIVE");
					entity.Property((SstPackegedCoversMatrix e) => e.IsAutoAdd).HasColumnName("IS_AUTO_ADD");
					entity.Property((SstPackegedCoversMatrix e) => e.IsBasicPremium).HasColumnName("IS_BASIC_PREMIUM");
					entity.Property((SstPackegedCoversMatrix e) => e.IsDiscountable).HasColumnName("IS_DISCOUNTABLE");
					entity.Property((SstPackegedCoversMatrix e) => e.IsEditable).HasColumnName("IS_EDITABLE");
					entity.Property((SstPackegedCoversMatrix e) => e.MinPremium).HasColumnName("MIN_PREMIUM").HasColumnType("decimal(18,3)");
					entity.Property((SstPackegedCoversMatrix e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstPackegedCoversMatrix e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstPackegedCoversMatrix e) => e.PackagedCoverId).HasColumnName("PACKAGED_COVER_ID");
					entity.Property((SstPackegedCoversMatrix e) => e.PremiumAmount).HasColumnName("PREMIUM_AMOUNT").HasColumnType("decimal(18,3)");
					entity.Property((SstPackegedCoversMatrix e) => e.PremiumRate).HasColumnName("PREMIUM_RATE").HasColumnType("decimal(9,3)");
					entity.Property((SstPackegedCoversMatrix e) => e.Serial).HasColumnName("SERIAL");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPackegedCovers, SstPackegedCoversMatrix>(entity.HasOne((SstPackegedCoversMatrix d) => d.PackagedCover).WithMany((SstPackegedCovers p) => p.SstPackegedCoversMatrix).HasForeignKey((SstPackegedCoversMatrix d) => d.PackagedCoverId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C002312430");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstPages> entity)
				{
					entity.ToTable("sst_pages");
					entity.HasIndex((Expression<Func<SstPages, object>>)((SstPages e) => e.ModuleCode)).HasName("SST_PAGES_FK01");
					entity.HasIndex((Expression<Func<SstPages, object>>)((SstPages e) => e.SystemId)).HasName("SST_PAGES_FK02");
					entity.Property((SstPages e) => e.Id).HasColumnName("ID");
					entity.Property((SstPages e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstPages e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstPages e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstPages e) => e.Key).HasColumnName("KEY").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstPages e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstPages e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstPages e) => e.ModuleCode).HasColumnName("MODULE_CODE").HasMaxLength(10)
						.IsUnicode(unicode: false);
					entity.Property((SstPages e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstPages e) => e.Name2).HasColumnName("NAME2").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstPages e) => e.Notes).HasColumnName("NOTES").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstPages e) => e.Order).HasColumnName("ORDER").HasDefaultValueSql("1");
					entity.Property((SstPages e) => e.PageId).HasColumnName("PAGE_ID");
					entity.Property((SstPages e) => e.PageUrl).HasColumnName("PAGE_URL").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstPages e) => e.SystemId).HasColumnName("SYSTEM_ID");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstModules, SstPages>(entity.HasOne((SstPages d) => d.ModuleCodeNavigation).WithMany((SstModules p) => p.SstPages).HasForeignKey((SstPages d) => d.ModuleCode), "SST_PAGES_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstPages>(entity.HasOne((SstPages d) => d.System).WithMany((SstSystems p) => p.SstPages).HasForeignKey((SstPages d) => d.SystemId), "SST_PAGES_FK02");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstPagesControls> entity)
				{
					entity.ToTable("sst_pages_controls");
					entity.HasIndex((Expression<Func<SstPagesControls, object>>)((SstPagesControls e) => e.ControlId)).HasName("SST_PAGES_CONTROLS_FK02");
					entity.HasIndex((Expression<Func<SstPagesControls, object>>)((SstPagesControls e) => e.PageId)).HasName("SST_PAGES_CONTROLS_FK01");
					entity.Property((SstPagesControls e) => e.Id).HasColumnName("ID");
					entity.Property((SstPagesControls e) => e.AllowDisabled).HasColumnName("ALLOW_DISABLED");
					entity.Property((SstPagesControls e) => e.AllowEditLabel).HasColumnName("ALLOW_EDIT_LABEL");
					entity.Property((SstPagesControls e) => e.AllowHidden).HasColumnName("ALLOW_HIDDEN");
					entity.Property((SstPagesControls e) => e.AllowRequired).HasColumnName("ALLOW_REQUIRED");
					entity.Property((SstPagesControls e) => e.ClassName).HasColumnName("CLASS_NAME").HasMaxLength(20)
						.IsUnicode(unicode: false);
					entity.Property((SstPagesControls e) => e.ControlId).HasColumnName("CONTROL_ID");
					entity.Property((SstPagesControls e) => e.ControlType).HasColumnName("CONTROL_TYPE").HasMaxLength(20)
						.IsUnicode(unicode: false);
					entity.Property((SstPagesControls e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstPagesControls e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstPagesControls e) => e.Form).HasColumnName("FORM").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstPagesControls e) => e.FormType).HasColumnName("FORM_TYPE");
					entity.Property((SstPagesControls e) => e.IsDisabled).HasColumnName("IS_DISABLED");
					entity.Property((SstPagesControls e) => e.IsDynamic).HasColumnName("IS_DYNAMIC");
					entity.Property((SstPagesControls e) => e.IsHidden).HasColumnName("IS_HIDDEN");
					entity.Property((SstPagesControls e) => e.IsRequired).HasColumnName("IS_REQUIRED");
					entity.Property((SstPagesControls e) => e.Key).IsRequired().HasColumnName("KEY")
						.HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstPagesControls e) => e.LabelKey).HasColumnName("LABEL_KEY").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstPagesControls e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstPagesControls e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstPagesControls e) => e.Order).HasColumnName("ORDER");
					entity.Property((SstPagesControls e) => e.PageId).HasColumnName("PAGE_ID");
					entity.Property((SstPagesControls e) => e.ParamsType).HasColumnName("PARAMS_TYPE");
					entity.Property((SstPagesControls e) => e.ServiceUrl).HasColumnName("SERVICE_URL").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstPagesControls e) => e.TextType).HasColumnName("TEXT_TYPE").HasMaxLength(255)
						.IsUnicode(unicode: false);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPagesControls, SstPagesControls>(entity.HasOne((SstPagesControls d) => d.Control).WithMany((SstPagesControls p) => p.InverseControl).HasForeignKey((SstPagesControls d) => d.ControlId), "SST_PAGES_CONTROLS_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPages, SstPagesControls>(entity.HasOne((SstPagesControls d) => d.Page).WithMany((SstPages p) => p.SstPagesControls).HasForeignKey((SstPagesControls d) => d.PageId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_PAGES_CONTROLS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstPagesControlsParams> entity)
				{
					entity.ToTable("sst_pages_controls_params");
					entity.HasIndex((Expression<Func<SstPagesControlsParams, object>>)((SstPagesControlsParams e) => e.ControlId)).HasName("SST_PAGES_CONTROLS_PARAMS_FK01");
					entity.Property((SstPagesControlsParams e) => e.Id).HasColumnName("ID");
					entity.Property((SstPagesControlsParams e) => e.ControlId).HasColumnName("CONTROL_ID");
					entity.Property((SstPagesControlsParams e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstPagesControlsParams e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstPagesControlsParams e) => e.DependOnKey).HasColumnName("DEPEND_ON_KEY").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstPagesControlsParams e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstPagesControlsParams e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstPagesControlsParams e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstPagesControlsParams e) => e.Type).HasColumnName("TYPE");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPagesControls, SstPagesControlsParams>(entity.HasOne((SstPagesControlsParams d) => d.Control).WithMany((SstPagesControls p) => p.SstPagesControlsParams).HasForeignKey((SstPagesControlsParams d) => d.ControlId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_PAGES_CONTROLS_PARAMS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstPaymentCycles> entity)
				{
					entity.ToTable("sst_payment_cycles");
					entity.HasIndex((Expression<Func<SstPaymentCycles, object>>)((SstPaymentCycles e) => e.SystemId)).HasName("SST_PAYMENT_CYCLES_FK01");
					entity.Property((SstPaymentCycles e) => e.Id).HasColumnName("ID");
					entity.Property((SstPaymentCycles e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstPaymentCycles e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstPaymentCycles e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstPaymentCycles e) => e.Frequency).HasColumnName("FREQUENCY");
					entity.Property((SstPaymentCycles e) => e.IsEditable).HasColumnName("IS_EDITABLE");
					entity.Property((SstPaymentCycles e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstPaymentCycles e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstPaymentCycles e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstPaymentCycles e) => e.Name2).HasColumnName("NAME2").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstPaymentCycles e) => e.NoOfPayments).HasColumnName("NO_OF_PAYMENTS");
					entity.Property((SstPaymentCycles e) => e.Notes).HasColumnName("NOTES").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstPaymentCycles e) => e.Share).HasColumnName("SHARE_").HasColumnType("decimal(9,3)");
					entity.Property((SstPaymentCycles e) => e.SystemId).HasColumnName("SYSTEM_ID");
					entity.Property((SstPaymentCycles e) => e.Unit).HasColumnName("UNIT");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstPaymentCycles>(entity.HasOne((SstPaymentCycles d) => d.System).WithMany((SstSystems p) => p.SstPaymentCycles).HasForeignKey((SstPaymentCycles d) => d.SystemId), "SST_PAYMENT_CYCLES_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstPaymentDetails> entity)
				{
					entity.ToTable("sst_payment_details");
					entity.HasIndex((Expression<Func<SstPaymentDetails, object>>)((SstPaymentDetails e) => e.CycleId)).HasName("SST_PAYMENT_DETAILS_FK01");
					entity.Property((SstPaymentDetails e) => e.Id).HasColumnName("ID");
					entity.Property((SstPaymentDetails e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstPaymentDetails e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstPaymentDetails e) => e.CycleId).HasColumnName("CYCLE_ID");
					entity.Property((SstPaymentDetails e) => e.Method).HasColumnName("METHOD");
					entity.Property((SstPaymentDetails e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstPaymentDetails e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstPaymentDetails e) => e.Period).HasColumnName("PERIOD");
					entity.Property((SstPaymentDetails e) => e.Share).HasColumnName("SHARE_").HasColumnType("decimal(9,3)");
					entity.Property((SstPaymentDetails e) => e.Unit).HasColumnName("UNIT");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPaymentCycles, SstPaymentDetails>(entity.HasOne((SstPaymentDetails d) => d.Cycle).WithMany((SstPaymentCycles p) => p.SstPaymentDetails).HasForeignKey((SstPaymentDetails d) => d.CycleId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_PAYMENT_DETAILS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstPolicyBusiness> entity)
				{
					entity.ToTable("sst_policy_business");
					entity.HasIndex((Expression<Func<SstPolicyBusiness, object>>)((SstPolicyBusiness e) => e.ClassId)).HasName("SST_POLICY_BUSINESS_FK01");
					entity.HasIndex((Expression<Func<SstPolicyBusiness, object>>)((SstPolicyBusiness e) => e.PolicyType)).HasName("SST_POLICY_BUSINESS_FK02");
					entity.Property((SstPolicyBusiness e) => e.Id).HasColumnName("ID");
					entity.Property((SstPolicyBusiness e) => e.BusinessType).HasColumnName("BUSINESS_TYPE");
					entity.Property((SstPolicyBusiness e) => e.Category).HasColumnName("CATEGORY");
					entity.Property((SstPolicyBusiness e) => e.ClassId).HasColumnName("CLASS_ID");
					entity.Property((SstPolicyBusiness e) => e.CompanyId).HasColumnName("COMPANY_ID").HasDefaultValueSql("1");
					entity.Property((SstPolicyBusiness e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstPolicyBusiness e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstPolicyBusiness e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstPolicyBusiness e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstPolicyBusiness e) => e.PolicyType).HasColumnName("POLICY_TYPE");
					entity.Property((SstPolicyBusiness e) => e.ReportCode).HasColumnName("REPORT_CODE").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstPolicyBusiness e) => e.SystemId).HasColumnName("SYSTEM_ID");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstPolicyBusiness>(entity.HasOne((SstPolicyBusiness d) => d.Class).WithMany((SstClasses p) => p.SstPolicyBusiness).HasForeignKey((SstPolicyBusiness d) => d.ClassId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_POLICY_BUSINESS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstPolicyBusiness>(entity.HasOne((SstPolicyBusiness d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstPolicyBusiness).HasForeignKey((SstPolicyBusiness d) => d.PolicyType)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_POLICY_BUSINESS_FK02");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstPolicyDiscounts> entity)
				{
					entity.ToTable("sst_policy_discounts");
					entity.HasIndex((Expression<Func<SstPolicyDiscounts, object>>)((SstPolicyDiscounts e) => e.ClassId)).HasName("SST_POLICY_DISCOUNTS_FK02");
					entity.HasIndex((Expression<Func<SstPolicyDiscounts, object>>)((SstPolicyDiscounts e) => e.DiscountId)).HasName("SST_POLICY_DISCOUNTS_FK01");
					entity.HasIndex((Expression<Func<SstPolicyDiscounts, object>>)((SstPolicyDiscounts e) => e.PolicyType)).HasName("SST_POLICY_DISCOUNTS_FK03");
					entity.Property((SstPolicyDiscounts e) => e.Id).HasColumnName("ID");
					entity.Property((SstPolicyDiscounts e) => e.AutoAdd).HasColumnName("AUTO_ADD").HasDefaultValueSql("0");
					entity.Property((SstPolicyDiscounts e) => e.BusinessType).HasColumnName("BUSINESS_TYPE");
					entity.Property((SstPolicyDiscounts e) => e.ClassId).HasColumnName("CLASS_ID");
					entity.Property((SstPolicyDiscounts e) => e.CoverType).HasColumnName("COVER_TYPE");
					entity.Property((SstPolicyDiscounts e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstPolicyDiscounts e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstPolicyDiscounts e) => e.DiscountAmt).HasColumnName("DISCOUNT_AMT").HasColumnType("decimal(9,3)");
					entity.Property((SstPolicyDiscounts e) => e.DiscountId).HasColumnName("DISCOUNT_ID");
					entity.Property((SstPolicyDiscounts e) => e.DiscountPer).HasColumnName("DISCOUNT_PER").HasColumnType("decimal(9,3)");
					entity.Property((SstPolicyDiscounts e) => e.EffectiveDate).HasColumnName("EFFECTIVE_DATE");
					entity.Property((SstPolicyDiscounts e) => e.ExpiryDate).HasColumnName("EXPIRY_DATE");
					entity.Property((SstPolicyDiscounts e) => e.LoadingAmt).HasColumnName("LOADING_AMT").HasColumnType("decimal(18,3)");
					entity.Property((SstPolicyDiscounts e) => e.LoadingPer).HasColumnName("LOADING_PER").HasColumnType("decimal(10,5)");
					entity.Property((SstPolicyDiscounts e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstPolicyDiscounts e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstPolicyDiscounts e) => e.Order).HasColumnName("ORDER");
					entity.Property((SstPolicyDiscounts e) => e.PolicyType).HasColumnName("POLICY_TYPE");
					entity.Property((SstPolicyDiscounts e) => e.RenewalFrom).HasColumnName("RENEWAL_FROM");
					entity.Property((SstPolicyDiscounts e) => e.RenewalTo).HasColumnName("RENEWAL_TO");
					entity.Property((SstPolicyDiscounts e) => e.RiskType).HasColumnName("RISK_TYPE");
					entity.Property((SstPolicyDiscounts e) => e.RoundTo).HasColumnName("ROUND_TO");
					entity.Property((SstPolicyDiscounts e) => e.SeparateVoucher).HasColumnName("SEPARATE_VOUCHER").HasDefaultValueSql("0");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstPolicyDiscounts>(entity.HasOne((SstPolicyDiscounts d) => d.Class).WithMany((SstClasses p) => p.SstPolicyDiscounts).HasForeignKey((SstPolicyDiscounts d) => d.ClassId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_POLICY_DISCOUNTS_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstDiscounts, SstPolicyDiscounts>(entity.HasOne((SstPolicyDiscounts d) => d.Discount).WithMany((SstDiscounts p) => p.SstPolicyDiscounts).HasForeignKey((SstPolicyDiscounts d) => d.DiscountId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_POLICY_DISCOUNTS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstPolicyDiscounts>(entity.HasOne((SstPolicyDiscounts d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstPolicyDiscounts).HasForeignKey((SstPolicyDiscounts d) => d.PolicyType), "SST_POLICY_DISCOUNTS_FK03");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstPolicyTypes> entity)
				{
					entity.ToTable("sst_policy_types");
					entity.HasIndex((Expression<Func<SstPolicyTypes, object>>)((SstPolicyTypes e) => e.ClassId)).HasName("SST_POLICY_TYPES_FK01");
					entity.Property((SstPolicyTypes e) => e.Id).HasColumnName("ID");
					entity.Property((SstPolicyTypes e) => e.AgeDecrease).HasColumnName("AGE_DECREASE").HasDefaultValueSql("0");
					entity.Property((SstPolicyTypes e) => e.BasicCover).HasColumnName("BASIC_COVER");
					entity.Property((SstPolicyTypes e) => e.BusinessType).HasColumnName("BUSINESS_TYPE");
					entity.Property((SstPolicyTypes e) => e.ClaimCoverageType).HasColumnName("CLAIM_COVERAGE_TYPE");
					entity.Property((SstPolicyTypes e) => e.ClassId).HasColumnName("CLASS_ID");
					entity.Property((SstPolicyTypes e) => e.Code).IsRequired().HasColumnName("CODE")
						.HasMaxLength(6)
						.IsUnicode(unicode: false);
					entity.Property((SstPolicyTypes e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstPolicyTypes e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstPolicyTypes e) => e.EarnedPercent).HasColumnName("EARNED_PERCENT").HasColumnType("decimal(9,3)")
						.HasDefaultValueSql("0.000");
					entity.Property((SstPolicyTypes e) => e.EffectiveDate).HasColumnName("EFFECTIVE_DATE");
					entity.Property((SstPolicyTypes e) => e.ExpiryDate).HasColumnName("EXPIRY_DATE");
					entity.Property((SstPolicyTypes e) => e.LongTerm).HasColumnName("LONG_TERM").HasDefaultValueSql("0");
					entity.Property((SstPolicyTypes e) => e.MaturityAge).HasColumnName("MATURITY_AGE");
					entity.Property((SstPolicyTypes e) => e.MaxCustomerAge).HasColumnName("MAX_CUSTOMER_AGE");
					entity.Property((SstPolicyTypes e) => e.MaxMemberAge).HasColumnName("MAX_MEMBER_AGE");
					entity.Property((SstPolicyTypes e) => e.MaxTerm).HasColumnName("MAX_TERM");
					entity.Property((SstPolicyTypes e) => e.MinCustomerAge).HasColumnName("MIN_CUSTOMER_AGE");
					entity.Property((SstPolicyTypes e) => e.MinMemberAge).HasColumnName("MIN_MEMBER_AGE");
					entity.Property((SstPolicyTypes e) => e.MinTerm).HasColumnName("MIN_TERM");
					entity.Property((SstPolicyTypes e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstPolicyTypes e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstPolicyTypes e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstPolicyTypes e) => e.Name2).HasColumnName("NAME2").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstPolicyTypes e) => e.PolicyTerm).HasColumnName("POLICY_TERM");
					entity.Property((SstPolicyTypes e) => e.RateBasis).HasColumnName("RATE_BASIS");
					entity.Property((SstPolicyTypes e) => e.RatePer).HasColumnName("RATE_PER");
					entity.Property((SstPolicyTypes e) => e.RateType).HasColumnName("RATE_TYPE");
					entity.Property((SstPolicyTypes e) => e.ReinsuranceMethod).HasColumnName("REINSURANCE_METHOD");
					entity.Property((SstPolicyTypes e) => e.RequirePaynote).HasColumnName("REQUIRE_PAYNOTE");
					entity.Property((SstPolicyTypes e) => e.TargetGender).HasColumnName("TARGET_GENDER");
					entity.Property((SstPolicyTypes e) => e.TermBasis).HasColumnName("TERM_BASIS");
					entity.Property((SstPolicyTypes e) => e.TreatyType).HasColumnName("TREATY_TYPE").HasDefaultValueSql("1");
					entity.Property((SstPolicyTypes e) => e.UnearnedBasis).HasColumnName("UNEARNED_BASIS").HasDefaultValueSql("1");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstPolicyTypes>(entity.HasOne((SstPolicyTypes d) => d.Class).WithMany((SstClasses p) => p.SstPolicyTypes).HasForeignKey((SstPolicyTypes d) => d.ClassId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_POLICY_TYPES_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstPreferences> entity)
				{
					entity.ToTable("sst_preferences");
					entity.Property((SstPreferences e) => e.Id).HasColumnName("ID");
					entity.Property((SstPreferences e) => e.Code).IsRequired().HasColumnName("CODE")
						.HasMaxLength(10)
						.IsUnicode(unicode: false);
					entity.Property((SstPreferences e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstPreferences e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstPreferences e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstPreferences e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstPreferences e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstPreferences e) => e.PrefDescription).IsRequired().HasColumnName("PREF_DESCRIPTION")
						.HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstPreferences e) => e.PrefName).IsRequired().HasColumnName("PREF_NAME")
						.HasMaxLength(100)
						.IsUnicode(unicode: false);
					entity.Property((SstPreferences e) => e.PrefPage).IsRequired().HasColumnName("PREF_PAGE")
						.HasMaxLength(512)
						.IsUnicode(unicode: false);
					entity.Property((SstPreferences e) => e.PrefType).HasColumnName("PREF_TYPE");
					entity.Property((SstPreferences e) => e.PrefValue).IsRequired().HasColumnName("PREF_VALUE")
						.HasMaxLength(512)
						.IsUnicode(unicode: false);
					entity.Property((SstPreferences e) => e.SystemId).HasColumnName("SYSTEM_ID").HasDefaultValueSql("321");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstProcessActions> entity)
				{
					entity.ToTable("sst_process_actions");
					entity.Property((SstProcessActions e) => e.Id).HasColumnName("ID");
					entity.Property((SstProcessActions e) => e.ActionType).HasColumnName("ACTION_TYPE");
					entity.Property((SstProcessActions e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstProcessActions e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstProcessActions e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstProcessActions e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstProcessActions e) => e.RuleId).HasColumnName("RULE_ID");
					entity.Property((SstProcessActions e) => e.TargetAction).HasColumnName("TARGET_ACTION").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstProcessActions e) => e.TargetId).HasColumnName("TARGET_ID");
					entity.Property((SstProcessActions e) => e.TargetKey).HasColumnName("TARGET_KEY");
					entity.Property((SstProcessActions e) => e.TargetParent).HasColumnName("TARGET_PARENT");
					entity.Property((SstProcessActions e) => e.TargetType).HasColumnName("TARGET_TYPE").HasDefaultValueSql("0");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstProcessConditions> entity)
				{
					entity.ToTable("sst_process_conditions");
					entity.Property((SstProcessConditions e) => e.Id).HasColumnName("ID");
					entity.Property((SstProcessConditions e) => e.ConditionType).HasColumnName("CONDITION_TYPE").HasDefaultValueSql("1");
					entity.Property((SstProcessConditions e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstProcessConditions e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstProcessConditions e) => e.Formula).HasColumnName("FORMULA").HasColumnType("longtext");
					entity.Property((SstProcessConditions e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstProcessConditions e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstProcessConditions e) => e.Operator).HasColumnName("OPERATOR");
					entity.Property((SstProcessConditions e) => e.Order).HasColumnName("ORDER").HasDefaultValueSql("1");
					entity.Property((SstProcessConditions e) => e.ReferenceId).HasColumnName("REFERENCE_ID");
					entity.Property((SstProcessConditions e) => e.ReferenceKey).HasColumnName("REFERENCE_KEY");
					entity.Property((SstProcessConditions e) => e.ReferenceParent).HasColumnName("REFERENCE_PARENT");
					entity.Property((SstProcessConditions e) => e.ReferenceType).HasColumnName("REFERENCE_TYPE");
					entity.Property((SstProcessConditions e) => e.RuleId).HasColumnName("RULE_ID");
					entity.Property((SstProcessConditions e) => e.Validator).HasColumnName("VALIDATOR");
					entity.Property((SstProcessConditions e) => e.ValidatorValue).HasColumnName("VALIDATOR_VALUE").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstProcessConditions e) => e.ValidatorValue2).HasColumnName("VALIDATOR_VALUE2").HasMaxLength(1024)
						.IsUnicode(unicode: false);
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstProcessParentSteps> entity)
				{
					entity.ToTable("sst_process_parent_steps");
					entity.HasIndex((Expression<Func<SstProcessParentSteps, object>>)((SstProcessParentSteps e) => e.ProcessStepId)).HasName("SST_PROCESS_STEP_FK");
					entity.Property((SstProcessParentSteps e) => e.Id).HasColumnName("ID");
					entity.Property((SstProcessParentSteps e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstProcessParentSteps e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstProcessParentSteps e) => e.EdgeDescription).HasColumnName("EDGE_DESCRIPTION").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstProcessParentSteps e) => e.EdgeType).HasColumnName("EDGE_TYPE").HasDefaultValueSql("1");
					entity.Property((SstProcessParentSteps e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstProcessParentSteps e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstProcessParentSteps e) => e.ParentShapeId).HasColumnName("PARENT_SHAPE_ID");
					entity.Property((SstProcessParentSteps e) => e.ProcessId).HasColumnName("PROCESS_ID");
					entity.Property((SstProcessParentSteps e) => e.ProcessStepId).HasColumnName("PROCESS_STEP_ID");
					entity.Property((SstProcessParentSteps e) => e.ShapeId).HasColumnName("SHAPE_ID");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstProcessSteps, SstProcessParentSteps>(entity.HasOne((SstProcessParentSteps d) => d.ProcessStep).WithMany((SstProcessSteps p) => p.SstProcessParentSteps).HasForeignKey((SstProcessParentSteps d) => d.ProcessStepId), "SST_PROCESS_STEP_FK");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstProcessRoles> entity)
				{
					entity.ToTable("sst_process_roles");
					entity.Property((SstProcessRoles e) => e.Id).HasColumnName("ID");
					entity.Property((SstProcessRoles e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstProcessRoles e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstProcessRoles e) => e.GroupId).HasColumnName("GROUP_ID");
					entity.Property((SstProcessRoles e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstProcessRoles e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstProcessRoles e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstProcessRoles e) => e.Name2).HasColumnName("NAME2").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstProcessRoles e) => e.Notes).HasColumnName("NOTES").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstProcessRoles e) => e.ProcessStepId).HasColumnName("PROCESS_STEP_ID");
					entity.Property((SstProcessRoles e) => e.Username).HasColumnName("USERNAME").HasMaxLength(80)
						.IsUnicode(unicode: false);
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstProcessRules> entity)
				{
					entity.ToTable("sst_process_rules");
					entity.Property((SstProcessRules e) => e.Id).HasColumnName("ID");
					entity.Property((SstProcessRules e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstProcessRules e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstProcessRules e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstProcessRules e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstProcessRules e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstProcessRules e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstProcessRules e) => e.Name2).HasColumnName("NAME2").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstProcessRules e) => e.Notes).HasColumnName("NOTES").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstProcessRules e) => e.RuleTarget).HasColumnName("RULE_TARGET");
					entity.Property((SstProcessRules e) => e.RuleType).HasColumnName("RULE_TYPE").HasDefaultValueSql("1");
					entity.Property((SstProcessRules e) => e.SystemId).HasColumnName("SYSTEM_ID");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstProcessSteps> entity)
				{
					entity.ToTable("sst_process_steps");
					entity.Property((SstProcessSteps e) => e.Id).HasColumnName("ID");
					entity.Property((SstProcessSteps e) => e.BackColor).HasColumnName("BACK_COLOR").HasMaxLength(10)
						.IsUnicode(unicode: false);
					entity.Property((SstProcessSteps e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstProcessSteps e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstProcessSteps e) => e.FontColor).HasColumnName("FONT_COLOR").HasMaxLength(10)
						.IsUnicode(unicode: false);
					entity.Property((SstProcessSteps e) => e.FontSize).HasColumnName("FONT_SIZE").HasDefaultValueSql("11");
					entity.Property((SstProcessSteps e) => e.Height).HasColumnName("HEIGHT");
					entity.Property((SstProcessSteps e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstProcessSteps e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstProcessSteps e) => e.Name).HasColumnName("NAME").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstProcessSteps e) => e.ProcessId).HasColumnName("PROCESS_ID");
					entity.Property((SstProcessSteps e) => e.ProcessStepId).HasColumnName("PROCESS_STEP_ID");
					entity.Property((SstProcessSteps e) => e.ShapeType).HasColumnName("SHAPE_TYPE");
					entity.Property((SstProcessSteps e) => e.StepId).HasColumnName("STEP_ID");
					entity.Property((SstProcessSteps e) => e.Width).HasColumnName("WIDTH");
					entity.Property((SstProcessSteps e) => e.XPosition).HasColumnName("X_POSITION");
					entity.Property((SstProcessSteps e) => e.YPosition).HasColumnName("Y_POSITION");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstProcessStepsPages> entity)
				{
					entity.ToTable("sst_process_steps_pages");
					entity.HasIndex((Expression<Func<SstProcessStepsPages, object>>)((SstProcessStepsPages e) => e.PageId)).HasName("SST_PROCESS_STEPS_PAGES_FK01");
					entity.HasIndex((Expression<Func<SstProcessStepsPages, object>>)((SstProcessStepsPages e) => e.RuleId)).HasName("SST_PROCESS_STEPS_PAGES_FK03");
					entity.HasIndex((Expression<Func<SstProcessStepsPages, object>>)((SstProcessStepsPages e) => e.StepId)).HasName("SST_PROCESS_STEPS_PAGES_FK04");
					entity.Property((SstProcessStepsPages e) => e.Id).HasColumnName("ID");
					entity.Property((SstProcessStepsPages e) => e.ControlKey).IsRequired().HasColumnName("CONTROL_KEY")
						.HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstProcessStepsPages e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstProcessStepsPages e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstProcessStepsPages e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstProcessStepsPages e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstProcessStepsPages e) => e.Notes).HasColumnName("NOTES").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstProcessStepsPages e) => e.PageId).HasColumnName("PAGE_ID");
					entity.Property((SstProcessStepsPages e) => e.RuleId).HasColumnName("RULE_ID");
					entity.Property((SstProcessStepsPages e) => e.StepId).HasColumnName("STEP_ID");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPages, SstProcessStepsPages>(entity.HasOne((SstProcessStepsPages d) => d.Page).WithMany((SstPages p) => p.SstProcessStepsPages).HasForeignKey((SstProcessStepsPages d) => d.PageId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_PROCESS_STEPS_PAGES_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstRules, SstProcessStepsPages>(entity.HasOne((SstProcessStepsPages d) => d.Rule).WithMany((SstRules p) => p.SstProcessStepsPages).HasForeignKey((SstProcessStepsPages d) => d.RuleId), "SST_PROCESS_STEPS_PAGES_FK03");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstProcessSteps, SstProcessStepsPages>(entity.HasOne((SstProcessStepsPages d) => d.Step).WithMany((SstProcessSteps p) => p.SstProcessStepsPages).HasForeignKey((SstProcessStepsPages d) => d.StepId), "SST_PROCESS_STEPS_PAGES_FK04");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstProcessSystems> entity)
				{
					entity.ToTable("sst_process_systems");
					entity.HasIndex((Expression<Func<SstProcessSystems, object>>)((SstProcessSystems e) => e.ModuleCode)).HasName("SST_PROCESS_SYSTEMS_FK03");
					entity.HasIndex((Expression<Func<SstProcessSystems, object>>)((SstProcessSystems e) => e.SystemId)).HasName("SST_PROCESSES_SYSTEMS_FK02");
					entity.Property((SstProcessSystems e) => e.Id).HasColumnName("ID");
					entity.Property((SstProcessSystems e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstProcessSystems e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstProcessSystems e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstProcessSystems e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstProcessSystems e) => e.ModuleCode).HasColumnName("MODULE_CODE").HasMaxLength(15)
						.IsUnicode(unicode: false);
					entity.Property((SstProcessSystems e) => e.ProcessId).HasColumnName("PROCESS_ID");
					entity.Property((SstProcessSystems e) => e.SystemId).HasColumnName("SYSTEM_ID");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstModules, SstProcessSystems>(entity.HasOne((SstProcessSystems d) => d.ModuleCodeNavigation).WithMany((SstModules p) => p.SstProcessSystems).HasForeignKey((SstProcessSystems d) => d.ModuleCode), "SST_PROCESS_SYSTEMS_FK03");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstProcessSystems>(entity.HasOne((SstProcessSystems d) => d.System).WithMany((SstSystems p) => p.SstProcessSystems).HasForeignKey((SstProcessSystems d) => d.SystemId), "SST_PROCESSES_SYSTEMS_FK02");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstProcesses> entity)
				{
					entity.ToTable("sst_processes");
					entity.Property((SstProcesses e) => e.Id).HasColumnName("ID");
					entity.Property((SstProcesses e) => e.Active).HasColumnName("ACTIVE");
					entity.Property((SstProcesses e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstProcesses e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstProcesses e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstProcesses e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstProcesses e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstProcesses e) => e.Name2).HasColumnName("NAME2").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstProcesses e) => e.Notes).HasColumnName("NOTES").HasMaxLength(1024)
						.IsUnicode(unicode: false);
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstProducts> entity)
				{
					entity.ToTable("sst_products");
					entity.Property((SstProducts e) => e.Id).HasColumnName("ID");
					entity.Property((SstProducts e) => e.Abbreviation).IsRequired().HasColumnName("ABBREVIATION")
						.HasMaxLength(6)
						.IsUnicode(unicode: false);
					entity.Property((SstProducts e) => e.Code).IsRequired().HasColumnName("CODE")
						.HasMaxLength(10)
						.IsUnicode(unicode: false);
					entity.Property((SstProducts e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstProducts e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstProducts e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstProducts e) => e.EffectiveDate).HasColumnName("EFFECTIVE_DATE");
					entity.Property((SstProducts e) => e.ExpiryDate).HasColumnName("EXPIRY_DATE");
					entity.Property((SstProducts e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstProducts e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstProducts e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstProducts e) => e.Name2).HasColumnName("NAME2").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstProducts e) => e.Notes).HasColumnName("NOTES").HasMaxLength(1024)
						.IsUnicode(unicode: false);
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstProductsDetails> entity)
				{
					entity.ToTable("sst_products_details");
					entity.HasIndex((Expression<Func<SstProductsDetails, object>>)((SstProductsDetails e) => e.ClassId)).HasName("SST_PRODUCTS_DETAILS_FK02");
					entity.HasIndex((Expression<Func<SstProductsDetails, object>>)((SstProductsDetails e) => e.PolicyType)).HasName("SST_PRODUCTS_DETAILS_FK03");
					entity.HasIndex((Expression<Func<SstProductsDetails, object>>)((SstProductsDetails e) => e.ProductId)).HasName("SST_PRODUCTS_DETAILS_FK01");
					entity.Property((SstProductsDetails e) => e.Id).HasColumnName("ID");
					entity.Property((SstProductsDetails e) => e.ClassId).HasColumnName("CLASS_ID");
					entity.Property((SstProductsDetails e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstProductsDetails e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstProductsDetails e) => e.EffectiveDate).HasColumnName("EFFECTIVE_DATE");
					entity.Property((SstProductsDetails e) => e.ExpiryDate).HasColumnName("EXPIRY_DATE");
					entity.Property((SstProductsDetails e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstProductsDetails e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstProductsDetails e) => e.PolicyType).HasColumnName("POLICY_TYPE");
					entity.Property((SstProductsDetails e) => e.ProductId).HasColumnName("PRODUCT_ID");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstProductsDetails>(entity.HasOne((SstProductsDetails d) => d.Class).WithMany((SstClasses p) => p.SstProductsDetails).HasForeignKey((SstProductsDetails d) => d.ClassId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_PRODUCTS_DETAILS_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstProductsDetails>(entity.HasOne((SstProductsDetails d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstProductsDetails).HasForeignKey((SstProductsDetails d) => d.PolicyType)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_PRODUCTS_DETAILS_FK03");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstProducts, SstProductsDetails>(entity.HasOne((SstProductsDetails d) => d.Product).WithMany((SstProducts p) => p.SstProductsDetails).HasForeignKey((SstProductsDetails d) => d.ProductId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_PRODUCTS_DETAILS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstQuestControls> entity)
				{
					entity.ToTable("sst_quest_controls");
					entity.HasIndex((Expression<Func<SstQuestControls, object>>)((SstQuestControls e) => e.QuestionnaireId)).HasName("SST_QUEST_CONTROLS_FK01");
					entity.HasIndex((Expression<Func<SstQuestControls, object>>)((SstQuestControls e) => e.RefControlId)).HasName("SST_QUEST_CONTROLS_FK02");
					entity.Property((SstQuestControls e) => e.Id).HasColumnName("ID");
					entity.Property((SstQuestControls e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstQuestControls e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstQuestControls e) => e.Disabled).HasColumnName("DISABLED").HasDefaultValueSql("1");
					entity.Property((SstQuestControls e) => e.HasSubformControls).HasColumnName("HAS_SUBFORM_CONTROLS");
					entity.Property((SstQuestControls e) => e.Hint).HasColumnName("HINT").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstQuestControls e) => e.Icon).HasColumnName("ICON").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstQuestControls e) => e.Key).HasColumnName("KEY").HasMaxLength(124)
						.IsUnicode(unicode: false);
					entity.Property((SstQuestControls e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstQuestControls e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstQuestControls e) => e.Name).HasColumnName("NAME").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstQuestControls e) => e.Name2).HasColumnName("NAME2").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstQuestControls e) => e.Notes).HasColumnName("NOTES").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstQuestControls e) => e.Options).HasColumnName("OPTIONS").HasColumnType("longtext");
					entity.Property((SstQuestControls e) => e.Order).HasColumnName("ORDER");
					entity.Property((SstQuestControls e) => e.QuestionnaireId).HasColumnName("QUESTIONNAIRE_ID");
					entity.Property((SstQuestControls e) => e.RefControlId).HasColumnName("REF_CONTROL_ID");
					entity.Property((SstQuestControls e) => e.Required).HasColumnName("REQUIRED").HasDefaultValueSql("0");
					entity.Property((SstQuestControls e) => e.Type).HasColumnName("TYPE");
					entity.Property((SstQuestControls e) => e.Value).HasColumnName("VALUE");
					entity.Property((SstQuestControls e) => e.Width).HasColumnName("WIDTH");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstQuestionnaires, SstQuestControls>(entity.HasOne((SstQuestControls d) => d.Questionnaire).WithMany((SstQuestionnaires p) => p.SstQuestControls).HasForeignKey((SstQuestControls d) => d.QuestionnaireId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_QUEST_CONTROLS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstQuestControls, SstQuestControls>(entity.HasOne((SstQuestControls d) => d.RefControl).WithMany((SstQuestControls p) => p.InverseRefControl).HasForeignKey((SstQuestControls d) => d.RefControlId), "SST_QUEST_CONTROLS_FK02");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstQuestDetails> entity)
				{
					entity.ToTable("sst_quest_details");
					entity.HasIndex((Expression<Func<SstQuestDetails, object>>)((SstQuestDetails e) => e.PolicyTypeId)).HasName("SST_QUEST_DETAILS_FK01");
					entity.HasIndex((Expression<Func<SstQuestDetails, object>>)((SstQuestDetails e) => e.QuestionnaireId)).HasName("SYS_C002285366");
					entity.Property((SstQuestDetails e) => e.Id).HasColumnName("ID");
					entity.Property((SstQuestDetails e) => e.Abbreviation).HasColumnName("ABBREVIATION").HasMaxLength(5)
						.IsUnicode(unicode: false);
					entity.Property((SstQuestDetails e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstQuestDetails e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstQuestDetails e) => e.DataType).HasColumnName("DATA_TYPE");
					entity.Property((SstQuestDetails e) => e.DefaultValue).HasColumnName("DEFAULT_VALUE");
					entity.Property((SstQuestDetails e) => e.Description).HasColumnName("DESCRIPTION").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstQuestDetails e) => e.FromAge).HasColumnName("FROM_AGE");
					entity.Property((SstQuestDetails e) => e.Group).HasColumnName("GROUP");
					entity.Property((SstQuestDetails e) => e.Mandatory).HasColumnName("MANDATORY").HasConversion<int>();
					entity.Property((SstQuestDetails e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstQuestDetails e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstQuestDetails e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(100)
						.IsUnicode(unicode: false);
					entity.Property((SstQuestDetails e) => e.Name2).HasColumnName("NAME2").HasMaxLength(100)
						.IsUnicode(unicode: false);
					entity.Property((SstQuestDetails e) => e.Notes).HasColumnName("NOTES").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstQuestDetails e) => e.Order).HasColumnName("ORDER");
					entity.Property((SstQuestDetails e) => e.PolicyTypeId).HasColumnName("POLICY_TYPE_ID");
					entity.Property((SstQuestDetails e) => e.QuestionnaireId).HasColumnName("QUESTIONNAIRE_ID");
					entity.Property((SstQuestDetails e) => e.RepairCondition).HasColumnName("REPAIR_CONDITION");
					entity.Property((SstQuestDetails e) => e.Source).HasColumnName("SOURCE");
					entity.Property((SstQuestDetails e) => e.SourceType).HasColumnName("SOURCE_TYPE");
					entity.Property((SstQuestDetails e) => e.ToAge).HasColumnName("TO_AGE");
					entity.Property((SstQuestDetails e) => e.Visible).HasColumnName("VISIBLE").HasConversion<int>();
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstQuestDetails>(entity.HasOne((SstQuestDetails d) => d.PolicyType).WithMany((SstPolicyTypes p) => p.SstQuestDetails).HasForeignKey((SstQuestDetails d) => d.PolicyTypeId), "SST_QUEST_DETAILS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstCoreQuestionnaires, SstQuestDetails>(entity.HasOne((SstQuestDetails d) => d.Questionnaire).WithMany((SstCoreQuestionnaires p) => p.SstQuestDetails).HasForeignKey((SstQuestDetails d) => d.QuestionnaireId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C002285366");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstQuestSystems> entity)
				{
					entity.ToTable("sst_quest_systems");
					entity.HasIndex((Expression<Func<SstQuestSystems, object>>)((SstQuestSystems e) => e.QuiestionnaireId)).HasName("SST_QUEST_SYSTEMS_FK01");
					entity.HasIndex((Expression<Func<SstQuestSystems, object>>)((SstQuestSystems e) => e.SystemId)).HasName("SST_QUEST_SYSTEMS_FK02");
					entity.Property((SstQuestSystems e) => e.Id).HasColumnName("ID");
					entity.Property((SstQuestSystems e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstQuestSystems e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstQuestSystems e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstQuestSystems e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstQuestSystems e) => e.QuiestionnaireId).HasColumnName("QUIESTIONNAIRE_ID");
					entity.Property((SstQuestSystems e) => e.SystemId).HasColumnName("SYSTEM_ID");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstQuestionnaires, SstQuestSystems>(entity.HasOne((SstQuestSystems d) => d.Quiestionnaire).WithMany((SstQuestionnaires p) => p.SstQuestSystems).HasForeignKey((SstQuestSystems d) => d.QuiestionnaireId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_QUEST_SYSTEMS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstQuestSystems>(entity.HasOne((SstQuestSystems d) => d.System).WithMany((SstSystems p) => p.SstQuestSystems).HasForeignKey((SstQuestSystems d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_QUEST_SYSTEMS_FK02");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstQuestionnaires> entity)
				{
					entity.ToTable("sst_questionnaires");
					entity.Property((SstQuestionnaires e) => e.Id).HasColumnName("ID");
					entity.Property((SstQuestionnaires e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstQuestionnaires e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstQuestionnaires e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstQuestionnaires e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstQuestionnaires e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstQuestionnaires e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstQuestionnaires e) => e.Name2).HasColumnName("NAME2").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstQuestionnaires e) => e.Notes).HasColumnName("NOTES").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstQuestionnaires e) => e.Usage).HasColumnName("USAGE");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstRatingMatrix> entity)
				{
					entity.ToTable("sst_rating_matrix");
					entity.HasIndex((Expression<Func<SstRatingMatrix, object>>)((SstRatingMatrix e) => e.ClassId)).HasName("SYS_C002285398");
					entity.HasIndex((Expression<Func<SstRatingMatrix, object>>)((SstRatingMatrix e) => e.CoverType)).HasName("SYS_C002285400");
					entity.HasIndex((Expression<Func<SstRatingMatrix, object>>)((SstRatingMatrix e) => e.PolicyType)).HasName("SYS_C002285399");
					entity.HasIndex((Expression<Func<SstRatingMatrix, object>>)((SstRatingMatrix e) => e.SystemId)).HasName("SYS_C002285397");
					entity.Property((SstRatingMatrix e) => e.Id).HasColumnName("ID");
					entity.Property((SstRatingMatrix e) => e.ClassId).HasColumnName("CLASS_ID");
					entity.Property((SstRatingMatrix e) => e.CoverType).HasColumnName("COVER_TYPE");
					entity.Property((SstRatingMatrix e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstRatingMatrix e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstRatingMatrix e) => e.FinCustomerId).HasColumnName("FIN_CUSTOMER_ID");
					entity.Property((SstRatingMatrix e) => e.FinCustomerName).HasColumnName("FIN_CUSTOMER_NAME").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstRatingMatrix e) => e.FinCustomerRole).HasColumnName("FIN_CUSTOMER_ROLE");
					entity.Property((SstRatingMatrix e) => e.FinCustomerRoleName).HasColumnName("FIN_CUSTOMER_ROLE_NAME").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstRatingMatrix e) => e.IsBuilt).HasColumnName("IS_BUILT").HasConversion<int>();
					entity.Property((SstRatingMatrix e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstRatingMatrix e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstRatingMatrix e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstRatingMatrix e) => e.PolicyType).HasColumnName("POLICY_TYPE");
					entity.Property((SstRatingMatrix e) => e.Status).HasColumnName("STATUS").HasConversion<int>();
					entity.Property((SstRatingMatrix e) => e.StatusDate).HasColumnName("STATUS_DATE");
					entity.Property((SstRatingMatrix e) => e.SystemId).HasColumnName("SYSTEM_ID");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstRatingMatrix>(entity.HasOne((SstRatingMatrix d) => d.Class).WithMany((SstClasses p) => p.SstRatingMatrix).HasForeignKey((SstRatingMatrix d) => d.ClassId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C002285398");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstCoverTypes, SstRatingMatrix>(entity.HasOne((SstRatingMatrix d) => d.CoverTypeNavigation).WithMany((SstCoverTypes p) => p.SstRatingMatrix).HasForeignKey((SstRatingMatrix d) => d.CoverType)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C002285400");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstRatingMatrix>(entity.HasOne((SstRatingMatrix d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstRatingMatrix).HasForeignKey((SstRatingMatrix d) => d.PolicyType)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C002285399");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstRatingMatrix>(entity.HasOne((SstRatingMatrix d) => d.System).WithMany((SstSystems p) => p.SstRatingMatrix).HasForeignKey((SstRatingMatrix d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C002285397");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstRatingMatrixParams> entity)
				{
					entity.ToTable("sst_rating_matrix_params");
					entity.HasIndex((Expression<Func<SstRatingMatrixParams, object>>)((SstRatingMatrixParams e) => e.ParamMapId)).HasName("SYS_C002285622");
					entity.HasIndex((Expression<Func<SstRatingMatrixParams, object>>)((SstRatingMatrixParams e) => e.RatingMatrixId)).HasName("SYS_C002285621");
					entity.Property((SstRatingMatrixParams e) => e.Id).HasColumnName("ID");
					entity.Property((SstRatingMatrixParams e) => e.ColumnName).IsRequired().HasColumnName("COLUMN_NAME")
						.HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstRatingMatrixParams e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstRatingMatrixParams e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstRatingMatrixParams e) => e.DataType).HasColumnName("DATA_TYPE");
					entity.Property((SstRatingMatrixParams e) => e.Lob).HasColumnName("LOB");
					entity.Property((SstRatingMatrixParams e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstRatingMatrixParams e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstRatingMatrixParams e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstRatingMatrixParams e) => e.ParamMapId).HasColumnName("PARAM_MAP_ID");
					entity.Property((SstRatingMatrixParams e) => e.ParamType).HasColumnName("PARAM_TYPE");
					entity.Property((SstRatingMatrixParams e) => e.RatingMatrixId).HasColumnName("RATING_MATRIX_ID");
					entity.Property((SstRatingMatrixParams e) => e.ReferenceId).HasColumnName("REFERENCE_ID");
					entity.Property((SstRatingMatrixParams e) => e.Serial).HasColumnName("SERIAL");
					entity.Property((SstRatingMatrixParams e) => e.Source).HasColumnName("SOURCE");
					entity.Property((SstRatingMatrixParams e) => e.SystemId).HasColumnName("SYSTEM_ID");
					entity.Property((SstRatingMatrixParams e) => e.TableName).IsRequired().HasColumnName("TABLE_NAME")
						.HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstRatingMatrixParams e) => e.ValueFrom).HasColumnName("VALUE_FROM").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstRatingMatrixParams e) => e.ValueTo).HasColumnName("VALUE_TO").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstMatrixParamsMapping, SstRatingMatrixParams>(entity.HasOne((SstRatingMatrixParams d) => d.ParamMap).WithMany((SstMatrixParamsMapping p) => p.SstRatingMatrixParams).HasForeignKey((SstRatingMatrixParams d) => d.ParamMapId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C002285622");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstRatingMatrix, SstRatingMatrixParams>(entity.HasOne((SstRatingMatrixParams d) => d.RatingMatrix).WithMany((SstRatingMatrix p) => p.SstRatingMatrixParams).HasForeignKey((SstRatingMatrixParams d) => d.RatingMatrixId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C002285621");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstRatingMatrixValues> entity)
				{
					entity.ToTable("sst_rating_matrix_values");
					entity.HasIndex((Expression<Func<SstRatingMatrixValues, object>>)((SstRatingMatrixValues e) => e.RatingMatrixId)).HasName("SYS_C002285629");
					entity.Property((SstRatingMatrixValues e) => e.Id).HasColumnName("ID");
					entity.Property((SstRatingMatrixValues e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstRatingMatrixValues e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstRatingMatrixValues e) => e.DedAmount).HasColumnName("DED_AMOUNT").HasColumnType("decimal(18,3)");
					entity.Property((SstRatingMatrixValues e) => e.DedPercent).HasColumnName("DED_PERCENT").HasColumnType("decimal(9,3)");
					entity.Property((SstRatingMatrixValues e) => e.MinPremium).HasColumnName("MIN_PREMIUM").HasColumnType("decimal(18,3)");
					entity.Property((SstRatingMatrixValues e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstRatingMatrixValues e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstRatingMatrixValues e) => e.PremiumAmount).HasColumnName("PREMIUM_AMOUNT").HasColumnType("decimal(18,3)");
					entity.Property((SstRatingMatrixValues e) => e.PremiumRate).HasColumnName("PREMIUM_RATE").HasColumnType("decimal(9,3)");
					entity.Property((SstRatingMatrixValues e) => e.Query).HasColumnName("QUERY").HasColumnType("longtext");
					entity.Property((SstRatingMatrixValues e) => e.RatingMatrixId).HasColumnName("RATING_MATRIX_ID");
					entity.Property((SstRatingMatrixValues e) => e.Serial).HasColumnName("SERIAL");
					entity.Property((SstRatingMatrixValues e) => e.ValueAsJson).HasColumnName("VALUE_AS_JSON").HasColumnType("longtext");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstRatingMatrix, SstRatingMatrixValues>(entity.HasOne((SstRatingMatrixValues d) => d.RatingMatrix).WithMany((SstRatingMatrix p) => p.SstRatingMatrixValues).HasForeignKey((SstRatingMatrixValues d) => d.RatingMatrixId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C002285629");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstRelations> entity)
				{
					entity.ToTable("sst_relations");
					entity.HasIndex((Expression<Func<SstRelations, object>>)((SstRelations e) => e.ClassId)).HasName("SST_RELATIONS_FK01");
					entity.HasIndex((Expression<Func<SstRelations, object>>)((SstRelations e) => e.EndorsementType)).HasName("SST_RELATIONS_FK04");
					entity.HasIndex((Expression<Func<SstRelations, object>>)((SstRelations e) => e.PaymentCycle)).HasName("SST_RELATIONS_FK03");
					entity.HasIndex((Expression<Func<SstRelations, object>>)((SstRelations e) => e.PolicyType)).HasName("SST_RELATIONS_FK02");
					entity.Property((SstRelations e) => e.Id).HasColumnName("ID");
					entity.Property((SstRelations e) => e.BusinessType).HasColumnName("BUSINESS_TYPE");
					entity.Property((SstRelations e) => e.ClassId).HasColumnName("CLASS_ID");
					entity.Property((SstRelations e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstRelations e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstRelations e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstRelations e) => e.Currency).HasColumnName("CURRENCY").HasMaxLength(24)
						.IsUnicode(unicode: false);
					entity.Property((SstRelations e) => e.EndorsementType).HasColumnName("ENDORSEMENT_TYPE");
					entity.Property((SstRelations e) => e.MaxPremium).HasColumnName("MAX_PREMIUM").HasColumnType("decimal(9,3)");
					entity.Property((SstRelations e) => e.MaxSumInsured).HasColumnName("MAX_SUM_INSURED").HasColumnType("decimal(9,3)");
					entity.Property((SstRelations e) => e.MinPremium).HasColumnName("MIN_PREMIUM").HasColumnType("decimal(9,3)");
					entity.Property((SstRelations e) => e.MinSumInsured).HasColumnName("MIN_SUM_INSURED").HasColumnType("decimal(9,3)");
					entity.Property((SstRelations e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstRelations e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstRelations e) => e.PaymentCycle).HasColumnName("PAYMENT_CYCLE");
					entity.Property((SstRelations e) => e.PolicyType).HasColumnName("POLICY_TYPE");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstRelations>(entity.HasOne((SstRelations d) => d.Class).WithMany((SstClasses p) => p.SstRelations).HasForeignKey((SstRelations d) => d.ClassId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_RELATIONS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstEndorsements, SstRelations>(entity.HasOne((SstRelations d) => d.EndorsementTypeNavigation).WithMany((SstEndorsements p) => p.SstRelations).HasForeignKey((SstRelations d) => d.EndorsementType), "SST_RELATIONS_FK04");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPaymentCycles, SstRelations>(entity.HasOne((SstRelations d) => d.PaymentCycleNavigation).WithMany((SstPaymentCycles p) => p.SstRelations).HasForeignKey((SstRelations d) => d.PaymentCycle), "SST_RELATIONS_FK03");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstRelations>(entity.HasOne((SstRelations d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstRelations).HasForeignKey((SstRelations d) => d.PolicyType)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_RELATIONS_FK02");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstResources> entity)
				{
					entity.ToTable("sst_resources");
					entity.HasIndex((Expression<Func<SstResources, object>>)((SstResources e) => e.SystemId)).HasName("SST_RESOURCES_FK01");
					entity.Property((SstResources e) => e.Id).HasColumnName("ID");
					entity.Property((SstResources e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstResources e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstResources e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstResources e) => e.Language).IsRequired().HasColumnName("LANGUAGE")
						.HasMaxLength(8)
						.IsUnicode(unicode: false);
					entity.Property((SstResources e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstResources e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstResources e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstResources e) => e.Object).IsRequired().HasColumnName("OBJECT")
						.HasMaxLength(256)
						.IsUnicode(unicode: false);
					entity.Property((SstResources e) => e.SystemId).HasColumnName("SYSTEM_ID");
					entity.Property((SstResources e) => e.Value).IsRequired().HasColumnName("VALUE")
						.HasMaxLength(1024)
						.IsUnicode(unicode: false);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstResources>(entity.HasOne((SstResources d) => d.System).WithMany((SstSystems p) => p.SstResources).HasForeignKey((SstResources d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_RESOURCES_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstRules> entity)
				{
					entity.ToTable("sst_rules");
					entity.HasIndex((Expression<Func<SstRules, object>>)((SstRules e) => e.SystemId)).HasName("SST_RULES_FK01");
					entity.Property((SstRules e) => e.Id).HasColumnName("ID");
					entity.Property((SstRules e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstRules e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstRules e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstRules e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstRules e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstRules e) => e.ModuleCode).HasColumnName("MODULE_CODE").HasMaxLength(15)
						.IsUnicode(unicode: false);
					entity.Property((SstRules e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstRules e) => e.Name2).HasColumnName("NAME2").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstRules e) => e.Notes).HasColumnName("NOTES").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstRules e) => e.ProductId).HasColumnName("PRODUCT_ID");
					entity.Property((SstRules e) => e.RuleTarget).HasColumnName("RULE_TARGET");
					entity.Property((SstRules e) => e.RuleType).HasColumnName("RULE_TYPE").HasDefaultValueSql("1");
					entity.Property((SstRules e) => e.SystemId).HasColumnName("SYSTEM_ID");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstRules>(entity.HasOne((SstRules d) => d.System).WithMany((SstSystems p) => p.SstRules).HasForeignKey((SstRules d) => d.SystemId), "SST_RULES_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstSegmentElement> entity)
				{
					entity.ToTable("sst_segment_element");
					entity.Property((SstSegmentElement e) => e.Id).HasColumnName("ID");
					entity.Property((SstSegmentElement e) => e.CamAppId).HasColumnName("CAM_APP_ID");
					entity.Property((SstSegmentElement e) => e.ColumnName).HasColumnName("COLUMN_NAME").HasMaxLength(45)
						.IsUnicode(unicode: false);
					entity.Property((SstSegmentElement e) => e.ElementType).HasColumnName("ELEMENT_TYPE");
					entity.Property((SstSegmentElement e) => e.Name).HasColumnName("NAME").HasMaxLength(30)
						.IsUnicode(unicode: false);
					entity.Property((SstSegmentElement e) => e.SegmentType).HasColumnName("SEGMENT_TYPE");
					entity.Property((SstSegmentElement e) => e.TableName).HasColumnName("TABLE_NAME").HasMaxLength(2000)
						.IsUnicode(unicode: false);
					entity.Property((SstSegmentElement e) => e.WhereCondition).HasColumnName("WHERE_CONDITION").HasMaxLength(2000)
						.IsUnicode(unicode: false);
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstSegments> entity)
				{
					entity.ToTable("sst_segments");
					entity.HasIndex((Expression<Func<SstSegments, object>>)((SstSegments e) => e.BusinessChannel)).HasName("SST_SEGMENTS_FK04");
					entity.HasIndex((Expression<Func<SstSegments, object>>)((SstSegments e) => e.ClassId)).HasName("SST_SEGMENTS_FK01");
					entity.HasIndex((Expression<Func<SstSegments, object>>)((SstSegments e) => e.PolicyType)).HasName("SST_SEGMENTS_FK02");
					entity.HasIndex((Expression<Func<SstSegments, object>>)((SstSegments e) => e.SystemId)).HasName("SST_SEGMENTS_FK03");
					entity.Property((SstSegments e) => e.Id).HasColumnName("ID");
					entity.Property((SstSegments e) => e.Branch).HasColumnName("BRANCH");
					entity.Property((SstSegments e) => e.BusinessChannel).HasColumnName("BUSINESS_CHANNEL");
					entity.Property((SstSegments e) => e.BusinessType).HasColumnName("BUSINESS_TYPE");
					entity.Property((SstSegments e) => e.ClassId).HasColumnName("CLASS_ID");
					entity.Property((SstSegments e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstSegments e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstSegments e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstSegments e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstSegments e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstSegments e) => e.PolicyType).HasColumnName("POLICY_TYPE");
					entity.Property((SstSegments e) => e.SegmentType).HasColumnName("SEGMENT_TYPE");
					entity.Property((SstSegments e) => e.SystemId).HasColumnName("SYSTEM_ID");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstBusinessChannels, SstSegments>(entity.HasOne((SstSegments d) => d.BusinessChannelNavigation).WithMany((SstBusinessChannels p) => p.SstSegments).HasForeignKey((SstSegments d) => d.BusinessChannel), "SST_SEGMENTS_FK04");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstSegments>(entity.HasOne((SstSegments d) => d.Class).WithMany((SstClasses p) => p.SstSegments).HasForeignKey((SstSegments d) => d.ClassId), "SST_SEGMENTS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstSegments>(entity.HasOne((SstSegments d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstSegments).HasForeignKey((SstSegments d) => d.PolicyType), "SST_SEGMENTS_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstSegments>(entity.HasOne((SstSegments d) => d.System).WithMany((SstSystems p) => p.SstSegments).HasForeignKey((SstSegments d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_SEGMENTS_FK03");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstSegmentsStructures> entity)
				{
					entity.ToTable("sst_segments_structures");
					entity.HasIndex((Expression<Func<SstSegmentsStructures, object>>)((SstSegmentsStructures e) => e.SegmentId)).HasName("SST_SEGMENTS_STRUCTURES_FK01");
					entity.Property((SstSegmentsStructures e) => e.Id).HasColumnName("ID");
					entity.Property((SstSegmentsStructures e) => e.ConstantValue).HasColumnName("CONSTANT_VALUE").HasMaxLength(10)
						.IsUnicode(unicode: false);
					entity.Property((SstSegmentsStructures e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstSegmentsStructures e) => e.CreationUser).HasColumnName("CREATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstSegmentsStructures e) => e.ElementLength).HasColumnName("ELEMENT_LENGTH");
					entity.Property((SstSegmentsStructures e) => e.ElementOrder).HasColumnName("ELEMENT_ORDER");
					entity.Property((SstSegmentsStructures e) => e.ElementSeparator).HasColumnName("ELEMENT_SEPARATOR").HasMaxLength(5)
						.IsUnicode(unicode: false);
					entity.Property((SstSegmentsStructures e) => e.ElementType).HasColumnName("ELEMENT_TYPE");
					entity.Property((SstSegmentsStructures e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstSegmentsStructures e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstSegmentsStructures e) => e.PaddingString).HasColumnName("PADDING_STRING").HasMaxLength(5)
						.IsUnicode(unicode: false);
					entity.Property((SstSegmentsStructures e) => e.SegmentId).HasColumnName("SEGMENT_ID");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSegments, SstSegmentsStructures>(entity.HasOne((SstSegmentsStructures d) => d.Segment).WithMany((SstSegments p) => p.SstSegmentsStructures).HasForeignKey((SstSegmentsStructures d) => d.SegmentId)
					//	.OnDelete(DeleteBehavior.Cascade), "SST_SEGMENTS_STRUCTURES_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstSerialLists> entity)
				{
					entity.ToTable("sst_serial_lists");
					entity.HasIndex((Expression<Func<SstSerialLists, object>>)((SstSerialLists e) => e.BusinessChannel)).HasName("SST_SERIAL_LISTS_FK04");
					entity.HasIndex((Expression<Func<SstSerialLists, object>>)((SstSerialLists e) => e.ClassId)).HasName("SST_SERIAL_LISTS_FK01");
					entity.HasIndex((Expression<Func<SstSerialLists, object>>)((SstSerialLists e) => e.PackagedId)).HasName("SST_SERIAL_LISTS_PACKG_ID_FK");
					entity.HasIndex((Expression<Func<SstSerialLists, object>>)((SstSerialLists e) => e.PolicyType)).HasName("SST_SERIAL_LISTS_FK02");
					entity.HasIndex((Expression<Func<SstSerialLists, object>>)((SstSerialLists e) => e.SystemId)).HasName("SST_SERIAL_LISTS_FK03");
					entity.Property((SstSerialLists e) => e.Id).HasColumnName("ID");
					entity.Property((SstSerialLists e) => e.AutomaticFlag).HasColumnName("AUTOMATIC_FLAG");
					entity.Property((SstSerialLists e) => e.Branch).HasColumnName("BRANCH");
					entity.Property((SstSerialLists e) => e.BusinessChannel).HasColumnName("BUSINESS_CHANNEL");
					entity.Property((SstSerialLists e) => e.BusinessType).HasColumnName("BUSINESS_TYPE");
					entity.Property((SstSerialLists e) => e.ClassId).HasColumnName("CLASS_ID");
					entity.Property((SstSerialLists e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstSerialLists e) => e.Country).HasColumnName("COUNTRY").HasMaxLength(8)
						.IsUnicode(unicode: false);
					entity.Property((SstSerialLists e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstSerialLists e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstSerialLists e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstSerialLists e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstSerialLists e) => e.PackagedId).HasColumnName("PACKAGED_ID");
					entity.Property((SstSerialLists e) => e.PolicyType).HasColumnName("POLICY_TYPE");
					entity.Property((SstSerialLists e) => e.SerialType).HasColumnName("SERIAL_TYPE");
					entity.Property((SstSerialLists e) => e.SystemId).HasColumnName("SYSTEM_ID");
					entity.Property((SstSerialLists e) => e.TermType).HasColumnName("TERM_TYPE");
					entity.Property((SstSerialLists e) => e.ValidFromDate).HasColumnName("VALID_FROM_DATE");
					entity.Property((SstSerialLists e) => e.ValidToDate).HasColumnName("VALID_TO_DATE");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstBusinessChannels, SstSerialLists>(entity.HasOne((SstSerialLists d) => d.BusinessChannelNavigation).WithMany((SstBusinessChannels p) => p.SstSerialLists).HasForeignKey((SstSerialLists d) => d.BusinessChannel), "SST_SERIAL_LISTS_FK04");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstSerialLists>(entity.HasOne((SstSerialLists d) => d.Class).WithMany((SstClasses p) => p.SstSerialLists).HasForeignKey((SstSerialLists d) => d.ClassId), "SST_SERIAL_LISTS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPackagedPolicy, SstSerialLists>(entity.HasOne((SstSerialLists d) => d.Packaged).WithMany((SstPackagedPolicy p) => p.SstSerialLists).HasForeignKey((SstSerialLists d) => d.PackagedId), "SST_SERIAL_LISTS_PACKG_ID_FK");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstSerialLists>(entity.HasOne((SstSerialLists d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstSerialLists).HasForeignKey((SstSerialLists d) => d.PolicyType), "SST_SERIAL_LISTS_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstSerialLists>(entity.HasOne((SstSerialLists d) => d.System).WithMany((SstSystems p) => p.SstSerialLists).HasForeignKey((SstSerialLists d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_SERIAL_LISTS_FK03");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstSerialRanges> entity)
				{
					entity.ToTable("sst_serial_ranges");
					entity.HasIndex((Expression<Func<SstSerialRanges, object>>)((SstSerialRanges e) => e.SerialId)).HasName("SST_SERIAL_RANGES_FK01");
					entity.Property((SstSerialRanges e) => e.Id).HasColumnName("ID");
					entity.Property((SstSerialRanges e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstSerialRanges e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstSerialRanges e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstSerialRanges e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstSerialRanges e) => e.SerialCurrent).HasColumnName("SERIAL_CURRENT");
					entity.Property((SstSerialRanges e) => e.SerialDate).HasColumnName("SERIAL_DATE");
					entity.Property((SstSerialRanges e) => e.SerialFrom).HasColumnName("SERIAL_FROM");
					entity.Property((SstSerialRanges e) => e.SerialId).HasColumnName("SERIAL_ID");
					entity.Property((SstSerialRanges e) => e.SerialIncrement).HasColumnName("SERIAL_INCREMENT");
					entity.Property((SstSerialRanges e) => e.SerialTo).HasColumnName("SERIAL_TO");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSerialLists, SstSerialRanges>(entity.HasOne((SstSerialRanges d) => d.Serial).WithMany((SstSerialLists p) => p.SstSerialRanges).HasForeignKey((SstSerialRanges d) => d.SerialId), "SST_SERIAL_RANGES_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstShortPeriods> entity)
				{
					entity.ToTable("sst_short_periods");
					entity.HasIndex((Expression<Func<SstShortPeriods, object>>)((SstShortPeriods e) => e.ClassId)).HasName("SST_SHORT_PERIODS_FK02");
					entity.HasIndex((Expression<Func<SstShortPeriods, object>>)((SstShortPeriods e) => e.PolicyType)).HasName("SST_SHORT_PERIODS_FK03");
					entity.HasIndex((Expression<Func<SstShortPeriods, object>>)((SstShortPeriods e) => e.SystemId)).HasName("SST_SHORT_PERIODS_FK01");
					entity.Property((SstShortPeriods e) => e.Id).HasColumnName("ID");
					entity.Property((SstShortPeriods e) => e.AdjustPercent).HasColumnName("ADJUST_PERCENT").HasColumnType("decimal(9,3)");
					entity.Property((SstShortPeriods e) => e.ApplyOn).HasColumnName("APPLY_ON");
					entity.Property((SstShortPeriods e) => e.ClassId).HasColumnName("CLASS_ID");
					entity.Property((SstShortPeriods e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstShortPeriods e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstShortPeriods e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstShortPeriods e) => e.FrequencyFrom).HasColumnName("FREQUENCY_FROM");
					entity.Property((SstShortPeriods e) => e.FrequencyTo).HasColumnName("FREQUENCY_TO");
					entity.Property((SstShortPeriods e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstShortPeriods e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstShortPeriods e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstShortPeriods e) => e.Name2).HasColumnName("NAME2").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstShortPeriods e) => e.Notes).HasColumnName("NOTES").HasMaxLength(4000)
						.IsUnicode(unicode: false);
					entity.Property((SstShortPeriods e) => e.PolicyType).HasColumnName("POLICY_TYPE");
					entity.Property((SstShortPeriods e) => e.RateFraction).HasColumnName("RATE_FRACTION");
					entity.Property((SstShortPeriods e) => e.SystemId).HasColumnName("SYSTEM_ID");
					entity.Property((SstShortPeriods e) => e.Unit).HasColumnName("UNIT");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstShortPeriods>(entity.HasOne((SstShortPeriods d) => d.Class).WithMany((SstClasses p) => p.SstShortPeriods).HasForeignKey((SstShortPeriods d) => d.ClassId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_SHORT_PERIODS_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstShortPeriods>(entity.HasOne((SstShortPeriods d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstShortPeriods).HasForeignKey((SstShortPeriods d) => d.PolicyType)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_SHORT_PERIODS_FK03");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstShortPeriods>(entity.HasOne((SstShortPeriods d) => d.System).WithMany((SstSystems p) => p.SstShortPeriods).HasForeignKey((SstShortPeriods d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_SHORT_PERIODS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstShortPeriodsDetails> entity)
				{
					entity.ToTable("sst_short_periods_details");
					entity.HasIndex((Expression<Func<SstShortPeriodsDetails, object>>)((SstShortPeriodsDetails e) => e.ShortPeriodId)).HasName("SST_SHORT_PERIODS_DETAILS_FK01");
					entity.Property((SstShortPeriodsDetails e) => e.Id).HasColumnName("ID");
					entity.Property((SstShortPeriodsDetails e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstShortPeriodsDetails e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstShortPeriodsDetails e) => e.EndorsementType).HasColumnName("ENDORSEMENT_TYPE");
					entity.Property((SstShortPeriodsDetails e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstShortPeriodsDetails e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstShortPeriodsDetails e) => e.ShortPeriodId).HasColumnName("SHORT_PERIOD_ID");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstShortPeriods, SstShortPeriodsDetails>(entity.HasOne((SstShortPeriodsDetails d) => d.ShortPeriod).WithMany((SstShortPeriods p) => p.SstShortPeriodsDetails).HasForeignKey((SstShortPeriodsDetails d) => d.ShortPeriodId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_SHORT_PERIODS_DETAILS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstSmsProviders> entity)
				{
					entity.ToTable("sst_sms_providers");
					entity.HasIndex((Expression<Func<SstSmsProviders, object>>)((SstSmsProviders e) => e.SystemId)).HasName("SST_SMS_PROVIDERS_FK01");
					entity.Property((SstSmsProviders e) => e.Id).HasColumnName("ID");
					entity.Property((SstSmsProviders e) => e.Api).HasColumnName("API").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstSmsProviders e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstSmsProviders e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstSmsProviders e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstSmsProviders e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstSmsProviders e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstSmsProviders e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(225)
						.IsUnicode(unicode: false);
					entity.Property((SstSmsProviders e) => e.Name2).HasColumnName("NAME2").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstSmsProviders e) => e.Order).HasColumnName("ORDER");
					entity.Property((SstSmsProviders e) => e.Password).HasColumnName("PASSWORD").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstSmsProviders e) => e.Status).HasColumnName("STATUS");
					entity.Property((SstSmsProviders e) => e.SystemId).HasColumnName("SYSTEM_ID");
					entity.Property((SstSmsProviders e) => e.Unicode).HasColumnName("UNICODE");
					entity.Property((SstSmsProviders e) => e.Username).HasColumnName("USERNAME").HasMaxLength(255)
						.IsUnicode(unicode: false);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstSmsProviders>(entity.HasOne((SstSmsProviders d) => d.System).WithMany((SstSystems p) => p.SstSmsProviders).HasForeignKey((SstSmsProviders d) => d.SystemId), "SST_SMS_PROVIDERS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstStatusRelation> entity)
				{
					entity.ToTable("sst_status_relation");
					entity.HasIndex((Expression<Func<SstStatusRelation, object>>)((SstStatusRelation e) => e.ClassId)).HasName("SST_STATUS_RELATION_FK02");
					entity.HasIndex((Expression<Func<SstStatusRelation, object>>)((SstStatusRelation e) => e.PolicyType)).HasName("SST_STATUS_RELATION_FK03");
					entity.HasIndex((Expression<Func<SstStatusRelation, object>>)((SstStatusRelation e) => e.StageDomain)).HasName("SST_STATUS_RELATION_FK05");
					entity.HasIndex((Expression<Func<SstStatusRelation, object>>)((SstStatusRelation e) => e.StatusDomain)).HasName("SST_STATUS_RELATION_FK04");
					entity.HasIndex((Expression<Func<SstStatusRelation, object>>)((SstStatusRelation e) => e.SystemId)).HasName("SST_STATUS_RELATION_FK01");
					entity.Property((SstStatusRelation e) => e.Id).HasColumnName("ID");
					entity.Property((SstStatusRelation e) => e.ClassId).HasColumnName("CLASS_ID");
					entity.Property((SstStatusRelation e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstStatusRelation e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstStatusRelation e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstStatusRelation e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstStatusRelation e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstStatusRelation e) => e.PolicyType).HasColumnName("POLICY_TYPE");
					entity.Property((SstStatusRelation e) => e.RelationType).HasColumnName("RELATION_TYPE");
					entity.Property((SstStatusRelation e) => e.StageDomain).HasColumnName("STAGE_DOMAIN");
					entity.Property((SstStatusRelation e) => e.StageValue).IsRequired().HasColumnName("STAGE_VALUE")
						.HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstStatusRelation e) => e.StatusDomain).HasColumnName("STATUS_DOMAIN");
					entity.Property((SstStatusRelation e) => e.StatusValue).IsRequired().HasColumnName("STATUS_VALUE")
						.HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstStatusRelation e) => e.SystemId).HasColumnName("SYSTEM_ID");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstStatusRelation>(entity.HasOne((SstStatusRelation d) => d.Class).WithMany((SstClasses p) => p.SstStatusRelation).HasForeignKey((SstStatusRelation d) => d.ClassId), "SST_STATUS_RELATION_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstStatusRelation>(entity.HasOne((SstStatusRelation d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstStatusRelation).HasForeignKey((SstStatusRelation d) => d.PolicyType), "SST_STATUS_RELATION_FK03");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstDomains, SstStatusRelation>(entity.HasOne((SstStatusRelation d) => d.StageDomainNavigation).WithMany((SstDomains p) => p.SstStatusRelationStageDomainNavigation).HasForeignKey((SstStatusRelation d) => d.StageDomain)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_STATUS_RELATION_FK05");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstDomains, SstStatusRelation>(entity.HasOne((SstStatusRelation d) => d.StatusDomainNavigation).WithMany((SstDomains p) => p.SstStatusRelationStatusDomainNavigation).HasForeignKey((SstStatusRelation d) => d.StatusDomain)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_STATUS_RELATION_FK04");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstStatusRelation>(entity.HasOne((SstStatusRelation d) => d.System).WithMany((SstSystems p) => p.SstStatusRelation).HasForeignKey((SstStatusRelation d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_STATUS_RELATION_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstSubBranches> entity)
				{
					entity.ToTable("sst_sub_branches");
					entity.HasIndex((Expression<Func<SstSubBranches, object>>)((SstSubBranches e) => e.SubBranchId)).HasName("SST_SUB_BRANCHES_FK02");
					entity.HasIndex((Expression<Func<SstSubBranches, object>>)((SstSubBranches e) => e.SystemId)).HasName("SST_SUB_BRANCHES_FK01");
					entity.Property((SstSubBranches e) => e.Id).HasColumnName("ID");
					entity.Property((SstSubBranches e) => e.BranchId).HasColumnName("BRANCH_ID");
					entity.Property((SstSubBranches e) => e.Code).IsRequired().HasColumnName("CODE")
						.HasMaxLength(100)
						.IsUnicode(unicode: false);
					entity.Property((SstSubBranches e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstSubBranches e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstSubBranches e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstSubBranches e) => e.Level).HasColumnName("LEVEL");
					entity.Property((SstSubBranches e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstSubBranches e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstSubBranches e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(100)
						.IsUnicode(unicode: false);
					entity.Property((SstSubBranches e) => e.Name2).HasColumnName("NAME2").HasMaxLength(100)
						.IsUnicode(unicode: false);
					entity.Property((SstSubBranches e) => e.SubBranchId).HasColumnName("SUB_BRANCH_ID");
					entity.Property((SstSubBranches e) => e.SystemId).HasColumnName("SYSTEM_ID");
					entity.Property((SstSubBranches e) => e.TypeOfBusiness).HasColumnName("TYPE_OF_BUSINESS");
					entity.Property((SstSubBranches e) => e.TypeOfBusinessVal).HasColumnName("TYPE_OF_BUSINESS_VAL");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSubBranches, SstSubBranches>(entity.HasOne((SstSubBranches d) => d.SubBranch).WithMany((SstSubBranches p) => p.InverseSubBranch).HasForeignKey((SstSubBranches d) => d.SubBranchId), "SST_SUB_BRANCHES_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstSubBranches>(entity.HasOne((SstSubBranches d) => d.System).WithMany((SstSystems p) => p.SstSubBranches).HasForeignKey((SstSubBranches d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_SUB_BRANCHES_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstSystems> entity)
				{
					entity.ToTable("sst_systems");
					entity.Property((SstSystems e) => e.Id).HasColumnName("ID");
					entity.Property((SstSystems e) => e.Abbreviation).HasColumnName("ABBREVIATION").HasMaxLength(10)
						.IsUnicode(unicode: false);
					entity.Property((SstSystems e) => e.ApplicationId).HasColumnName("APPLICATION_ID");
					entity.Property((SstSystems e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstSystems e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstSystems e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstSystems e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstSystems e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstSystems e) => e.Name2).HasColumnName("NAME2").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstSystems e) => e.Notes).HasColumnName("NOTES").HasMaxLength(1024)
						.IsUnicode(unicode: false);
					entity.Property((SstSystems e) => e.VirtualPath).HasColumnName("VIRTUAL_PATH").HasMaxLength(4000)
						.IsUnicode(unicode: false);
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstUserAlerts> entity)
				{
					entity.ToTable("sst_user_alerts");
					entity.HasIndex((Expression<Func<SstUserAlerts, object>>)((SstUserAlerts e) => e.AlertId)).HasName("SST_USER_ALERTS_FK01");
					entity.HasIndex((Expression<Func<SstUserAlerts, object>>)((SstUserAlerts e) => e.UserId)).HasName("SST_USER_ALERTS_FK02");
					entity.Property((SstUserAlerts e) => e.Id).HasColumnName("ID");
					entity.Property((SstUserAlerts e) => e.AlertId).HasColumnName("ALERT_ID");
					entity.Property((SstUserAlerts e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstUserAlerts e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstUserAlerts e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstUserAlerts e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstUserAlerts e) => e.ReadDate).HasColumnName("READ_DATE");
					entity.Property((SstUserAlerts e) => e.ReadFlag).HasColumnName("READ_FLAG");
					entity.Property((SstUserAlerts e) => e.SystemId).HasColumnName("SYSTEM_ID");
					entity.Property((SstUserAlerts e) => e.UserId).HasColumnName("USER_ID");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstAlerts, SstUserAlerts>(entity.HasOne((SstUserAlerts d) => d.Alert).WithMany((SstAlerts p) => p.SstUserAlerts).HasForeignKey((SstUserAlerts d) => d.AlertId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_USER_ALERTS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstUsers, SstUserAlerts>(entity.HasOne((SstUserAlerts d) => d.User).WithMany((SstUsers p) => p.SstUserAlerts).HasForeignKey((SstUserAlerts d) => d.UserId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_USER_ALERTS_FK02");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstUsers> entity)
				{
					entity.ToTable("sst_users");
					entity.Property((SstUsers e) => e.Id).HasColumnName("ID");
					entity.Property((SstUsers e) => e.Address).HasColumnName("ADDRESS").HasMaxLength(2048)
						.IsUnicode(unicode: false);
					entity.Property((SstUsers e) => e.BirthDate).HasColumnName("BIRTH_DATE");
					entity.Property((SstUsers e) => e.City).HasColumnName("CITY");
					entity.Property((SstUsers e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstUsers e) => e.Country).HasColumnName("COUNTRY").HasMaxLength(8)
						.IsUnicode(unicode: false);
					entity.Property((SstUsers e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstUsers e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstUsers e) => e.Department).HasColumnName("DEPARTMENT");
					entity.Property((SstUsers e) => e.Email).HasColumnName("EMAIL").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstUsers e) => e.Image).HasColumnName("IMAGE").HasMaxLength(124)
						.IsUnicode(unicode: false);
					entity.Property((SstUsers e) => e.ImageStyle).HasColumnName("IMAGE_STYLE").HasMaxLength(64)
						.IsUnicode(unicode: false);
					entity.Property((SstUsers e) => e.MobileNo).HasColumnName("MOBILE_NO").HasMaxLength(25)
						.IsUnicode(unicode: false);
					entity.Property((SstUsers e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstUsers e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstUsers e) => e.Name).IsRequired().HasColumnName("NAME")
						.HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstUsers e) => e.Name2).HasColumnName("NAME2").HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstUsers e) => e.Occupation).HasColumnName("OCCUPATION");
					entity.Property((SstUsers e) => e.PhoneNo).HasColumnName("PHONE_NO").HasMaxLength(25)
						.IsUnicode(unicode: false);
					entity.Property((SstUsers e) => e.PoBox).HasColumnName("PO_BOX").HasMaxLength(25)
						.IsUnicode(unicode: false);
					entity.Property((SstUsers e) => e.Username).HasColumnName("USERNAME").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstUsers e) => e.ZipCode).HasColumnName("ZIP_CODE").HasMaxLength(25)
						.IsUnicode(unicode: false);
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstValuesRelation> entity)
				{
					entity.ToTable("sst_values_relation");
					entity.HasIndex((Expression<Func<SstValuesRelation, object>>)((SstValuesRelation e) => e.SystemId)).HasName("SST_VALUES_RELATION_FK01");
					entity.Property((SstValuesRelation e) => e.Id).HasColumnName("ID");
					entity.Property((SstValuesRelation e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstValuesRelation e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstValuesRelation e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstValuesRelation e) => e.MajorValue).IsRequired().HasColumnName("MAJOR_VALUE")
						.HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstValuesRelation e) => e.MinorValue).IsRequired().HasColumnName("MINOR_VALUE")
						.HasMaxLength(255)
						.IsUnicode(unicode: false);
					entity.Property((SstValuesRelation e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstValuesRelation e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstValuesRelation e) => e.RelationType).HasColumnName("RELATION_TYPE");
					entity.Property((SstValuesRelation e) => e.SystemId).HasColumnName("SYSTEM_ID");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstValuesRelation>(entity.HasOne((SstValuesRelation d) => d.System).WithMany((SstSystems p) => p.SstValuesRelation).HasForeignKey((SstValuesRelation d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_VALUES_RELATION_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstVouchersReferences> entity)
				{
					entity.ToTable("sst_vouchers_references");
					entity.Property((SstVouchersReferences e) => e.Id).HasColumnName("ID");
					entity.Property((SstVouchersReferences e) => e.ColumnName).IsRequired().HasColumnName("COLUMN_NAME")
						.HasMaxLength(1000)
						.IsUnicode(unicode: false);
					entity.Property((SstVouchersReferences e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstVouchersReferences e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstVouchersReferences e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstVouchersReferences e) => e.FcrTrtCode).IsRequired().HasColumnName("FCR_TRT_CODE")
						.HasMaxLength(15)
						.IsUnicode(unicode: false);
					entity.Property((SstVouchersReferences e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstVouchersReferences e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstVouchersReferences e) => e.ModuleCode).HasColumnName("MODULE_CODE").HasMaxLength(15)
						.IsUnicode(unicode: false);
					entity.Property((SstVouchersReferences e) => e.ReferenceName).IsRequired().HasColumnName("REFERENCE_NAME")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstVouchersReferences e) => e.ReferenceType).HasColumnName("REFERENCE_TYPE");
					entity.Property((SstVouchersReferences e) => e.Serial).HasColumnName("SERIAL");
					entity.Property((SstVouchersReferences e) => e.SystemId).HasColumnName("SYSTEM_ID");
					entity.Property((SstVouchersReferences e) => e.TableName).IsRequired().HasColumnName("TABLE_NAME")
						.HasMaxLength(1000)
						.IsUnicode(unicode: false);
					entity.Property((SstVouchersReferences e) => e.VoucherType).HasColumnName("VOUCHER_TYPE");
					entity.Property((SstVouchersReferences e) => e.WhereClause).IsRequired().HasColumnName("WHERE_CLAUSE")
						.HasMaxLength(4000)
						.IsUnicode(unicode: false);
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstVouchersTypes> entity)
				{
					entity.HasKey((SstVouchersTypes e) => e.Serial);
					entity.ToTable("sst_vouchers_types");
					entity.Property((SstVouchersTypes e) => e.Serial).HasColumnName("SERIAL");
					entity.Property((SstVouchersTypes e) => e.CompanyId).HasColumnName("COMPANY_ID");
					entity.Property((SstVouchersTypes e) => e.CreationDate).HasColumnName("CREATION_DATE");
					entity.Property((SstVouchersTypes e) => e.CreationUser).IsRequired().HasColumnName("CREATION_USER")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstVouchersTypes e) => e.FcrTrtCode).IsRequired().HasColumnName("FCR_TRT_CODE")
						.HasMaxLength(15)
						.IsUnicode(unicode: false);
					entity.Property((SstVouchersTypes e) => e.ModificationDate).HasColumnName("MODIFICATION_DATE");
					entity.Property((SstVouchersTypes e) => e.ModificationUser).HasColumnName("MODIFICATION_USER").HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstVouchersTypes e) => e.ModuleCode).IsRequired().HasColumnName("MODULE_CODE")
						.HasMaxLength(15)
						.IsUnicode(unicode: false);
					entity.Property((SstVouchersTypes e) => e.SystemId).HasColumnName("SYSTEM_ID");
					entity.Property((SstVouchersTypes e) => e.TableName).IsRequired().HasColumnName("TABLE_NAME")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
					entity.Property((SstVouchersTypes e) => e.VoucherName).IsRequired().HasColumnName("VOUCHER_NAME")
						.HasMaxLength(80)
						.IsUnicode(unicode: false);
				});
				break;
			case DatabaseType.Oracle:
				modelBuilder.Entity(delegate(EntityTypeBuilder<ApprovalMapping> entity)
				{
					entity.HasIndex((Expression<Func<ApprovalMapping, object>>)((ApprovalMapping e) => e.Id)).HasName("SYS_C0025428").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((ApprovalMapping e) => e.Id), "APPROVAL_MAPPING_SEQ", (string)null);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, ApprovalMapping>(entity.HasOne((ApprovalMapping d) => d.System).WithMany((SstSystems p) => p.ApprovalMapping).HasForeignKey((ApprovalMapping d) => d.SystemId), "APPROVAL_MAPPING_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<CpEpaymentTransactions> entity)
				{
					entity.HasIndex((Expression<Func<CpEpaymentTransactions, object>>)((CpEpaymentTransactions e) => e.Id)).HasName("PRIMARY").IsUnique();
					entity.Property((CpEpaymentTransactions e) => e.Id).ValueGeneratedNever();
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<CpUserProperties> entity)
				{
					entity.HasIndex((Expression<Func<CpUserProperties, object>>)((CpUserProperties e) => e.Id)).HasName("PRIMARY_1").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((CpUserProperties e) => e.Id), "CP_USER_PROPERTIES_SEQ", (string)null);
					entity.HasIndex((Expression<Func<CpUserProperties, object>>)((CpUserProperties e) => e.UserId)).HasName("CP_USER_PROPERTIES_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<CpUserProperties, CpUserProperties>(entity.HasOne((CpUserProperties d) => d.User).WithMany((CpUserProperties p) => p.InverseUser).HasForeignKey((CpUserProperties d) => d.UserId), "CP_USER_PROPERTIES_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<Mytesttable> entity)
				{
					entity.HasIndex((Expression<Func<Mytesttable, object>>)((Mytesttable e) => e.Id)).HasName("SYS_C0025770").IsUnique();
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SpdComponents> entity)
				{
					entity.HasIndex((Expression<Func<SpdComponents, object>>)((SpdComponents e) => e.CompanyId)).HasName("SPD_COMPONENTS_IDX03");
					entity.HasIndex((Expression<Func<SpdComponents, object>>)((SpdComponents e) => e.Id)).HasName("PRIMARY_2").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SpdComponents e) => e.Id), "SPD_COMPONENTS_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SpdComponents, object>>)((SpdComponents e) => e.RefComponentId)).HasName("SPD_COMPONENTS_FK02");
					entity.HasIndex((Expression<Func<SpdComponents, object>>)((SpdComponents e) => e.StepId)).HasName("SPD_COMPONENTS_FK01");
					entity.HasIndex((Expression<Func<SpdComponents, object>>)((SpdComponents e) => e.SystemId)).HasName("SPD_COMPONENTS_IDX02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SpdProductsSteps, SpdComponents>(entity.HasOne((SpdComponents d) => d.Step).WithMany((SpdProductsSteps p) => p.SpdComponents).HasForeignKey((SpdComponents d) => d.StepId), "SPD_COMPONENTS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SpdContainers> entity)
				{
					entity.HasIndex((Expression<Func<SpdContainers, object>>)((SpdContainers e) => e.ComponentId)).HasName("SPD_CONTAINERS_IDX02");
					entity.HasIndex((Expression<Func<SpdContainers, object>>)((SpdContainers e) => e.Id)).HasName("PRIMARY_3").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SpdContainers e) => e.Id), "SPD_CONTAINERS_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SpdContainers, object>>)((SpdContainers e) => e.RefContainerId)).HasName("SPD_CONTAINERS_IDX03");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SpdComponents, SpdContainers>(entity.HasOne((SpdContainers d) => d.Component).WithMany((SpdComponents p) => p.SpdContainers).HasForeignKey((SpdContainers d) => d.ComponentId), "SPD_CONTAINERS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SpdContainers, SpdContainers>(entity.HasOne((SpdContainers d) => d.RefContainer).WithMany((SpdContainers p) => p.InverseRefContainer).HasForeignKey((SpdContainers d) => d.RefContainerId), "SPD_CONTAINERS_FK02");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SpdControlValues> entity)
				{
					entity.HasIndex((Expression<Func<SpdControlValues, object>>)((SpdControlValues e) => e.ComponentId)).HasName("SPD_CONTROL_VALUES_FK02");
					entity.HasIndex((Expression<Func<SpdControlValues, object>>)((SpdControlValues e) => e.ControlId)).HasName("SPD_CONTROL_VALUES_FK03");
					entity.HasIndex((Expression<Func<SpdControlValues, object>>)((SpdControlValues e) => e.Id)).HasName("PRIMARY_4").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SpdControlValues e) => e.Id), "SPD_CONTROL_VALUES_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SpdControlValues, object>>)((SpdControlValues e) => e.ProductId)).HasName("SPD_CONTROL_VALUES_FK05");
					entity.HasIndex((Expression<Func<SpdControlValues, object>>)((SpdControlValues e) => e.StepId)).HasName("SPD_CONTROL_VALUES_FK01");
					entity.HasIndex((Expression<Func<SpdControlValues, object>>)((SpdControlValues e) => e.UserPropertyId)).HasName("SPD_CONTROL_VALUES_FK04");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SpdComponents, SpdControlValues>(entity.HasOne((SpdControlValues d) => d.Component).WithMany((SpdComponents p) => p.SpdControlValues).HasForeignKey((SpdControlValues d) => d.ComponentId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SPD_CONTROL_VALUES_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SpdFormControls, SpdControlValues>(entity.HasOne((SpdControlValues d) => d.Control).WithMany((SpdFormControls p) => p.SpdControlValues).HasForeignKey((SpdControlValues d) => d.ControlId), "SPD_CONTROL_VALUES_FK03");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SpdProducts, SpdControlValues>(entity.HasOne((SpdControlValues d) => d.Product).WithMany((SpdProducts p) => p.SpdControlValues).HasForeignKey((SpdControlValues d) => d.ProductId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SPD_CONTROL_VALUES_FK05");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SpdProductsSteps, SpdControlValues>(entity.HasOne((SpdControlValues d) => d.Step).WithMany((SpdProductsSteps p) => p.SpdControlValues).HasForeignKey((SpdControlValues d) => d.StepId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SPD_CONTROL_VALUES_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<CpUserProperties, SpdControlValues>(entity.HasOne((SpdControlValues d) => d.UserProperty).WithMany((CpUserProperties p) => p.SpdControlValues).HasForeignKey((SpdControlValues d) => d.UserPropertyId), "SPD_CONTROL_VALUES_FK04");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SpdFormControls> entity)
				{
					entity.HasIndex((Expression<Func<SpdFormControls, object>>)((SpdFormControls e) => e.ContainerId)).HasName("SPD_FORM_CONTROLS_IDX02");
					entity.HasIndex((Expression<Func<SpdFormControls, object>>)((SpdFormControls e) => e.Id)).HasName("PRIMARY_5").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SpdFormControls e) => e.Id), "SPD_FORM_CONTROLS_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SpdFormControls, object>>)((SpdFormControls e) => e.RefControlId)).HasName("SPD_FORM_CONTROLS_IDX03_113");
					entity.Property((SpdFormControls e) => e.Disabled).HasDefaultValueSql("'1'");
					entity.Property((SpdFormControls e) => e.Required).HasDefaultValueSql("'0'");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SpdContainers, SpdFormControls>(entity.HasOne((SpdFormControls d) => d.Container).WithMany((SpdContainers p) => p.SpdFormControls).HasForeignKey((SpdFormControls d) => d.ContainerId), "SPD_FORM_CONTROLS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SpdFormControls, SpdFormControls>(entity.HasOne((SpdFormControls d) => d.RefControl).WithMany((SpdFormControls p) => p.InverseRefControl).HasForeignKey((SpdFormControls d) => d.RefControlId), "SPD_FORM_CONTROLS_FK02");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SpdProducts> entity)
				{
					entity.HasIndex((Expression<Func<SpdProducts, object>>)((SpdProducts e) => e.CompanyId)).HasName("SPD_PRODUCTS_IDX03");
					entity.HasIndex((Expression<Func<SpdProducts, object>>)((SpdProducts e) => e.Id)).HasName("PRIMARY_6").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SpdProducts e) => e.Id), "SPD_PRODUCTS_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SpdProducts, object>>)((SpdProducts e) => e.SystemId)).HasName("SPD_PRODUCTS_IDX02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SpdProducts>(entity.HasOne((SpdProducts d) => d.System).WithMany((SstSystems p) => p.SpdProducts).HasForeignKey((SpdProducts d) => d.SystemId), "SPD_PRODUCTS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SpdProductsDetails> entity)
				{
					entity.HasIndex((Expression<Func<SpdProductsDetails, object>>)((SpdProductsDetails e) => e.Id)).HasName("PRIMARY_7").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SpdProductsDetails e) => e.Id), "SPD_PRODUCTS_DETAILS_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SpdProductsDetails, object>>)((SpdProductsDetails e) => e.ProductId)).HasName("SPD_PRODUCTS_DETAILS_IDX03");
					entity.HasIndex((Expression<Func<SpdProductsDetails, object>>)((SpdProductsDetails e) => e.SystemId)).HasName("SPD_PRODUCTS_DETAILS_IDX02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SpdProducts, SpdProductsDetails>(entity.HasOne((SpdProductsDetails d) => d.Product).WithMany((SpdProducts p) => p.SpdProductsDetails).HasForeignKey((SpdProductsDetails d) => d.ProductId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SPD_PRODUCTS_DETAILS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SpdProductsSteps> entity)
				{
					entity.HasIndex((Expression<Func<SpdProductsSteps, object>>)((SpdProductsSteps e) => e.Id)).HasName("PRIMARY_8").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SpdProductsSteps e) => e.Id), "SPD_PRODUCTS_STEPS_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SpdProductsSteps, object>>)((SpdProductsSteps e) => e.ProductId)).HasName("SPD_PRODUCTS_STEPS_IDX02");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SpdSequences> entity)
				{
					entity.HasIndex((Expression<Func<SpdSequences, object>>)((SpdSequences e) => e.Id)).HasName("PRIMARY_9").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SpdSequences e) => e.Id), "SPD_SEQUENCES_SEQ", (string)null);
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SpdSequencesDetails> entity)
				{
					entity.HasIndex((Expression<Func<SpdSequencesDetails, object>>)((SpdSequencesDetails e) => e.Id)).HasName("PRIMARY_10").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SpdSequencesDetails e) => e.Id), "SPD_SEQUENCES_DETAILS_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SpdSequencesDetails, object>>)((SpdSequencesDetails e) => e.IntegrationId)).HasName("SPD_SEQUENCES_DETAILS_FK02");
					entity.HasIndex((Expression<Func<SpdSequencesDetails, object>>)((SpdSequencesDetails e) => e.SequenceId)).HasName("SPD_SEQUENCES_DETAILS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstIntegrations, SpdSequencesDetails>(entity.HasOne((SpdSequencesDetails d) => d.Integration).WithMany((SstIntegrations p) => p.SpdSequencesDetails).HasForeignKey((SpdSequencesDetails d) => d.IntegrationId), "SPD_SEQUENCES_DETAILS_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SpdSequences, SpdSequencesDetails>(entity.HasOne((SpdSequencesDetails d) => d.Sequence).WithMany((SpdSequences p) => p.SpdSequencesDetails).HasForeignKey((SpdSequencesDetails d) => d.SequenceId), "SPD_SEQUENCES_DETAILS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SpdStepsTransactions> entity)
				{
					entity.HasIndex((Expression<Func<SpdStepsTransactions, object>>)((SpdStepsTransactions e) => e.Id)).HasName("PRIMARY_11").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SpdStepsTransactions e) => e.Id), "SPD_STEPS_TRANSACTIONS_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SpdStepsTransactions, object>>)((SpdStepsTransactions e) => e.IntegrationId)).HasName("SPD_STEPS_TRANSACTIONS_FK02");
					entity.HasIndex((Expression<Func<SpdStepsTransactions, object>>)((SpdStepsTransactions e) => e.StepId)).HasName("SPD_STEPS_TRANSACTIONS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstIntegrations, SpdStepsTransactions>(entity.HasOne((SpdStepsTransactions d) => d.Integration).WithMany((SstIntegrations p) => p.SpdStepsTransactions).HasForeignKey((SpdStepsTransactions d) => d.IntegrationId), "SPD_STEPS_TRANSACTIONS_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SpdProductsSteps, SpdStepsTransactions>(entity.HasOne((SpdStepsTransactions d) => d.Step).WithMany((SpdProductsSteps p) => p.SpdStepsTransactions).HasForeignKey((SpdStepsTransactions d) => d.StepId), "SPD_STEPS_TRANSACTIONS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstAccounts> entity)
				{
					entity.HasIndex((Expression<Func<SstAccounts, object>>)((SstAccounts e) => e.Branch)).HasName("SST_ACCOUNTS_IDX06");
					entity.HasIndex((Expression<Func<SstAccounts, object>>)((SstAccounts e) => e.ClassId)).HasName("SST_ACCOUNTS_IDX01");
					entity.HasIndex((Expression<Func<SstAccounts, object>>)((SstAccounts e) => e.CompanyId)).HasName("SST_ACCOUNTS_IDX08");
					entity.HasIndex((Expression<Func<SstAccounts, object>>)((SstAccounts e) => e.CoverId)).HasName("SST_ACCOUNTS_IDX03");
					entity.HasIndex((Expression<Func<SstAccounts, object>>)((SstAccounts e) => e.Currency)).HasName("SST_ACCOUNTS_IDX07");
					entity.HasIndex((Expression<Func<SstAccounts, object>>)((SstAccounts e) => e.DiscountId)).HasName("SST_ACCOUNTS_IDX05");
					entity.HasIndex((Expression<Func<SstAccounts, object>>)((SstAccounts e) => e.FeeId)).HasName("SST_ACCOUNTS_IDX04");
					entity.HasIndex((Expression<Func<SstAccounts, object>>)((SstAccounts e) => e.Id)).HasName("PRIMARY_12").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstAccounts e) => e.Id), "SST_ACCOUNTS_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstAccounts, object>>)((SstAccounts e) => e.ModuleCode)).HasName("SST_ACCOUNTS_IDX10");
					entity.HasIndex((Expression<Func<SstAccounts, object>>)((SstAccounts e) => e.PolicyType)).HasName("SST_ACCOUNTS_IDX02");
					entity.HasIndex((Expression<Func<SstAccounts, object>>)((SstAccounts e) => e.SystemId)).HasName("SST_ACCOUNTS_IDX09");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstAccounts>(entity.HasOne((SstAccounts d) => d.Class).WithMany((SstClasses p) => p.SstAccounts).HasForeignKey((SstAccounts d) => d.ClassId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_ACCOUNTS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstCoverTypes, SstAccounts>(entity.HasOne((SstAccounts d) => d.Cover).WithMany((SstCoverTypes p) => p.SstAccounts).HasForeignKey((SstAccounts d) => d.CoverId), "SST_ACCOUNTS_FK03");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyDiscounts, SstAccounts>(entity.HasOne((SstAccounts d) => d.Discount).WithMany((SstPolicyDiscounts p) => p.SstAccounts).HasForeignKey((SstAccounts d) => d.DiscountId), "SST_ACCOUNTS_FK05");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstFees, SstAccounts>(entity.HasOne((SstAccounts d) => d.Fee).WithMany((SstFees p) => p.SstAccounts).HasForeignKey((SstAccounts d) => d.FeeId), "SST_ACCOUNTS_FK04");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstModules, SstAccounts>(entity.HasOne((SstAccounts d) => d.ModuleCodeNavigation).WithMany((SstModules p) => p.SstAccounts).HasForeignKey((SstAccounts d) => d.ModuleCode), "SST_ACCOUNT_MPDULE_CODE_FK");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstAccounts>(entity.HasOne((SstAccounts d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstAccounts).HasForeignKey((SstAccounts d) => d.PolicyType), "SST_ACCOUNTS_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstAccounts>(entity.HasOne((SstAccounts d) => d.System).WithMany((SstSystems p) => p.SstAccounts).HasForeignKey((SstAccounts d) => d.SystemId), "SST_ACCOUNT_SYSTEM_ID_FK");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstActions> entity)
				{
					entity.HasIndex((Expression<Func<SstActions, object>>)((SstActions e) => e.Id)).HasName("PRIMARY_13").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstActions e) => e.Id), "SST_ACTIONS_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstActions, object>>)((SstActions e) => e.RuleId)).HasName("SST_ACTIONS_IDX01");
					entity.Property((SstActions e) => e.TargetType).HasDefaultValueSql("0 ");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstRules, SstActions>(entity.HasOne((SstActions d) => d.Rule).WithMany((SstRules p) => p.SstActions).HasForeignKey((SstActions d) => d.RuleId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_ACTIONS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstAgentBookDetails> entity)
				{
					entity.HasIndex((Expression<Func<SstAgentBookDetails, object>>)((SstAgentBookDetails e) => e.Id)).HasName("SST_AGENT_BOOK_DETAILS_PK").IsUnique();
					entity.HasIndex((Expression<Func<SstAgentBookDetails, object>>)((SstAgentBookDetails e) => e.ParentBookId)).HasName("SST_AGENT_BOOK_DETAILS_IND01");
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstAgentBookDetails e) => e.Id), "SST_AGENT_BOOK_DETAILS_SEQ", (string)null);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstAgentBooks, SstAgentBookDetails>(entity.HasOne((SstAgentBookDetails d) => d.ParentBook).WithMany((SstAgentBooks p) => p.SstAgentBookDetails).HasForeignKey((SstAgentBookDetails d) => d.ParentBookId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_AGENT_BOOK_DETAILS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstAgentBooks> entity)
				{
					entity.HasIndex((Expression<Func<SstAgentBooks, object>>)((SstAgentBooks e) => e.ClassId)).HasName("SST_AGENT_BOOKS_IND02");
					entity.HasIndex((Expression<Func<SstAgentBooks, object>>)((SstAgentBooks e) => e.Id)).HasName("SST_AGENT_BOOKS_PK").IsUnique();
					entity.HasIndex((Expression<Func<SstAgentBooks, object>>)((SstAgentBooks e) => e.PolicyType)).HasName("SST_AGENT_BOOKS_IND03");
					entity.HasIndex((Expression<Func<SstAgentBooks, object>>)((SstAgentBooks e) => e.SystemId)).HasName("SST_AGENT_BOOKS_IND01");
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstAgentBooks e) => e.Id), "SST_AGENT_BOOKS_SEQ", (string)null);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstAgentBooks>(entity.HasOne((SstAgentBooks d) => d.Class).WithMany((SstClasses p) => p.SstAgentBooks).HasForeignKey((SstAgentBooks d) => d.ClassId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_AGENT_BOOKS_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstAgentBooks>(entity.HasOne((SstAgentBooks d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstAgentBooks).HasForeignKey((SstAgentBooks d) => d.PolicyType)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_AGENT_BOOKS_FK03");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstAgentBooks>(entity.HasOne((SstAgentBooks d) => d.System).WithMany((SstSystems p) => p.SstAgentBooks).HasForeignKey((SstAgentBooks d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_AGENT_BOOKS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstAgentCommissionTiers> entity)
				{
					entity.HasIndex((Expression<Func<SstAgentCommissionTiers, object>>)((SstAgentCommissionTiers e) => e.Id)).HasName("SYS_C0026365").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstAgentCommissionTiers e) => e.Id), "SST_AGENT_COMM_TIERS_SEQ", (string)null);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstAgents, SstAgentCommissionTiers>(entity.HasOne((SstAgentCommissionTiers d) => d.Agent).WithMany((SstAgents p) => p.SstAgentCommissionTiersAgent).HasForeignKey((SstAgentCommissionTiers d) => d.AgentId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C0040087");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstAgentCommissionTiers>(entity.HasOne((SstAgentCommissionTiers d) => d.Class).WithMany((SstClasses p) => p.SstAgentCommissionTiers).HasForeignKey((SstAgentCommissionTiers d) => d.ClassId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C0040101");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstCoverTypes, SstAgentCommissionTiers>(entity.HasOne((SstAgentCommissionTiers d) => d.CoverTypeNavigation).WithMany((SstCoverTypes p) => p.SstAgentCommissionTiers).HasForeignKey((SstAgentCommissionTiers d) => d.CoverType), "SST_AGENT_COMMISSION_FK04");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstAgents, SstAgentCommissionTiers>(entity.HasOne((SstAgentCommissionTiers d) => d.LinkedAgent).WithMany((SstAgents p) => p.SstAgentCommissionTiersLinkedAgent).HasForeignKey((SstAgentCommissionTiers d) => d.LinkedAgentId), "SYS_C0040088");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstAgentCommissionTiers>(entity.HasOne((SstAgentCommissionTiers d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstAgentCommissionTiers).HasForeignKey((SstAgentCommissionTiers d) => d.PolicyType), "SYS_C0040178");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstAgentOffices> entity)
				{
					entity.HasIndex((Expression<Func<SstAgentOffices, object>>)((SstAgentOffices e) => e.Id)).HasName("SYS_C0026299").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstAgentOffices e) => e.Id), "SST_AGENT_OFFICES_SEQ", (string)null);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstAgents, SstAgentOffices>(entity.HasOne((SstAgentOffices d) => d.Agent).WithMany((SstAgents p) => p.SstAgentOffices).HasForeignKey((SstAgentOffices d) => d.AgentId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C0040089");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstAgentOffices>(entity.HasOne((SstAgentOffices d) => d.Class).WithMany((SstClasses p) => p.SstAgentOffices).HasForeignKey((SstAgentOffices d) => d.ClassId), "SYS_C002285580");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstOffices, SstAgentOffices>(entity.HasOne((SstAgentOffices d) => d.Office).WithMany((SstOffices p) => p.SstAgentOffices).HasForeignKey((SstAgentOffices d) => d.OfficeId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C0040163");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstAgentOffices>(entity.HasOne((SstAgentOffices d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstAgentOffices).HasForeignKey((SstAgentOffices d) => d.PolicyType), "SYS_C0040179");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstAgentStructures> entity)
				{
					entity.HasIndex((Expression<Func<SstAgentStructures, object>>)((SstAgentStructures e) => e.BusinessChannel)).HasName("SST_AGENT_STRUCTURES_IDX04");
					entity.HasIndex((Expression<Func<SstAgentStructures, object>>)((SstAgentStructures e) => e.CompanyId)).HasName("SST_AGENT_STRUCTURES_IDX02");
					entity.HasIndex((Expression<Func<SstAgentStructures, object>>)((SstAgentStructures e) => e.Id)).HasName("PRIMARY_14").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstAgentStructures e) => e.Id), "SST_AGENT_STRUCTURES_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstAgentStructures, object>>)((SstAgentStructures e) => e.ParentId)).HasName("SST_AGENT_STRUCTURES_IDX03");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstBusinessChannels, SstAgentStructures>(entity.HasOne((SstAgentStructures d) => d.BusinessChannelNavigation).WithMany((SstBusinessChannels p) => p.SstAgentStructures).HasForeignKey((SstAgentStructures d) => d.BusinessChannel), "SST_AGENT_STRUCTURES_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstAgentStructures, SstAgentStructures>(entity.HasOne((SstAgentStructures d) => d.Parent).WithMany((SstAgentStructures p) => p.InverseParent).HasForeignKey((SstAgentStructures d) => d.ParentId), "SST_AGENT_STRUCTURES_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstAgents> entity)
				{
					entity.HasIndex((Expression<Func<SstAgents, object>>)((SstAgents e) => e.Id)).HasName("SYS_C0025516").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstAgents e) => e.Id), "SST_AGENT_SEQ", (string)null);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstBusinessChannels, SstAgents>(entity.HasOne((SstAgents d) => d.ChannelTypeNavigation).WithMany((SstBusinessChannels p) => p.SstAgents).HasForeignKey((SstAgents d) => d.ChannelType)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C0040094");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstCommissionStructure, SstAgents>(entity.HasOne((SstAgents d) => d.CommStructure).WithMany((SstCommissionStructure p) => p.SstAgents).HasForeignKey((SstAgents d) => d.CommStructureId), "SYS_C0040125");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstAgentStructures, SstAgents>(entity.HasOne((SstAgents d) => d.PositionNavigation).WithMany((SstAgentStructures p) => p.SstAgents).HasForeignKey((SstAgents d) => d.Position), "SYS_C0040091");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstAgents>(entity.HasOne((SstAgents d) => d.System).WithMany((SstSystems p) => p.SstAgents).HasForeignKey((SstAgents d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C0040216");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstAlerts> entity)
				{
					entity.HasIndex((Expression<Func<SstAlerts, object>>)((SstAlerts e) => e.Id)).HasName("PRIMARY_15").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstAlerts e) => e.Id), "SST_ALERTS_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstAlerts, object>>)((SstAlerts e) => e.SystemId)).HasName("SST_ALERTS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstAlerts>(entity.HasOne((SstAlerts d) => d.System).WithMany((SstSystems p) => p.SstAlerts).HasForeignKey((SstAlerts d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_ALERTS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstAnswers> entity)
				{
					entity.HasIndex((Expression<Func<SstAnswers, object>>)((SstAnswers e) => e.Id)).HasName("SYS_C0026172").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstAnswers e) => e.Id), "SST_ANSWERS_SEQ", (string)null);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstQuestDetails, SstAnswers>(entity.HasOne((SstAnswers d) => d.QuestDetail).WithMany((SstQuestDetails p) => p.SstAnswers).HasForeignKey((SstAnswers d) => d.QuestDetailId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C0040204");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstBusinessChannels> entity)
				{
					entity.HasIndex((Expression<Func<SstBusinessChannels, object>>)((SstBusinessChannels e) => e.CompanyId)).HasName("SST_BUSINESS_CHANNELS_IDX02");
					entity.HasIndex((Expression<Func<SstBusinessChannels, object>>)((SstBusinessChannels e) => e.Id)).HasName("PRIMARY_16").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstBusinessChannels e) => e.Id), "SST_BUSINESS_CHANNELS_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstBusinessChannels, object>>)((SstBusinessChannels e) => e.SystemId)).HasName("SST_BUSINESS_CHANNELS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstBusinessChannels>(entity.HasOne((SstBusinessChannels d) => d.System).WithMany((SstSystems p) => p.SstBusinessChannels).HasForeignKey((SstBusinessChannels d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_BUSINESS_CHANNELS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstChannelPlans> entity)
				{
					entity.HasIndex((Expression<Func<SstChannelPlans, object>>)((SstChannelPlans e) => e.BusinessChannel)).HasName("SST_CHANNEL_PLANS_FK01");
					entity.HasIndex((Expression<Func<SstChannelPlans, object>>)((SstChannelPlans e) => e.Id)).HasName("PRIMARY_17").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstChannelPlans e) => e.Id), "SST_CHANNEL_PLANS_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstChannelPlans, object>>)((SstChannelPlans e) => e.PolicyType)).HasName("SST_CHANNEL_PLANS_IDX02V1");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstBusinessChannels, SstChannelPlans>(entity.HasOne((SstChannelPlans d) => d.BusinessChannelNavigation).WithMany((SstBusinessChannels p) => p.SstChannelPlans).HasForeignKey((SstChannelPlans d) => d.BusinessChannel)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_CHANNEL_PLANS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstChannelPlans>(entity.HasOne((SstChannelPlans d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstChannelPlans).HasForeignKey((SstChannelPlans d) => d.PolicyType)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_CHANNEL_PLANS_FK02");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstChannelTypes> entity)
				{
					entity.HasIndex((Expression<Func<SstChannelTypes, object>>)((SstChannelTypes e) => e.BusinessChannel)).HasName("SST_CHANNEL_TYPES_FK01");
					entity.HasIndex((Expression<Func<SstChannelTypes, object>>)((SstChannelTypes e) => e.CustomerType)).HasName("SST_CHANNEL_TYPES_FK02");
					entity.HasIndex((Expression<Func<SstChannelTypes, object>>)((SstChannelTypes e) => e.Id)).HasName("PRIMARY_18").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstChannelTypes e) => e.Id), "SST_CHANNEL_TYPES_SEQ", (string)null);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstBusinessChannels, SstChannelTypes>(entity.HasOne((SstChannelTypes d) => d.BusinessChannelNavigation).WithMany((SstBusinessChannels p) => p.SstChannelTypes).HasForeignKey((SstChannelTypes d) => d.BusinessChannel)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_CHANNEL_TYPES_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstCustomerTypes, SstChannelTypes>(entity.HasOne((SstChannelTypes d) => d.CustomerTypeNavigation).WithMany((SstCustomerTypes p) => p.SstChannelTypes).HasForeignKey((SstChannelTypes d) => d.CustomerType)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_CHANNEL_TYPES_FK02");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstClaimDiscounts> entity)
				{
					entity.HasIndex((Expression<Func<SstClaimDiscounts, object>>)((SstClaimDiscounts e) => e.ClassId)).HasName("SST_CLAIM_DISCOUNTS_FK02");
					entity.HasIndex((Expression<Func<SstClaimDiscounts, object>>)((SstClaimDiscounts e) => e.DiscountId)).HasName("SST_CLAIM_DISCOUNTS_FK01");
					entity.HasIndex((Expression<Func<SstClaimDiscounts, object>>)((SstClaimDiscounts e) => e.Id)).HasName("PRIMARY_19").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstClaimDiscounts e) => e.Id), "SST_CLAIM_DISCOUNTS_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstClaimDiscounts, object>>)((SstClaimDiscounts e) => e.PolicyType)).HasName("SST_CLAIM_DISCOUNTS_FK03");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstClaimDiscounts>(entity.HasOne((SstClaimDiscounts d) => d.Class).WithMany((SstClasses p) => p.SstClaimDiscounts).HasForeignKey((SstClaimDiscounts d) => d.ClassId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_CLAIM_DISCOUNTS_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstDiscounts, SstClaimDiscounts>(entity.HasOne((SstClaimDiscounts d) => d.Discount).WithMany((SstDiscounts p) => p.SstClaimDiscounts).HasForeignKey((SstClaimDiscounts d) => d.DiscountId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_CLAIM_DISCOUNTS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstClaimDiscounts>(entity.HasOne((SstClaimDiscounts d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstClaimDiscounts).HasForeignKey((SstClaimDiscounts d) => d.PolicyType), "SST_CLAIM_DISCOUNTS_FK03");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstClasses> entity)
				{
					entity.HasIndex((Expression<Func<SstClasses, object>>)((SstClasses e) => e.Id)).HasName("PRIMARY_20").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstClasses e) => e.Id), "SST_CLASSES_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstClasses, object>>)((SstClasses e) => e.SystemId)).HasName("SST_CLASSES_IDX01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstClasses>(entity.HasOne((SstClasses d) => d.System).WithMany((SstSystems p) => p.SstClasses).HasForeignKey((SstClasses d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_CLASSES_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstClauses> entity)
				{
					entity.HasIndex((Expression<Func<SstClauses, object>>)((SstClauses e) => e.ClassId)).HasName("SST_CLAUSES_IDX02");
					entity.HasIndex((Expression<Func<SstClauses, object>>)((SstClauses e) => e.CompanyId)).HasName("SST_CLAUSES_IDX05");
					entity.HasIndex((Expression<Func<SstClauses, object>>)((SstClauses e) => e.Id)).HasName("PRIMARY_21").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstClauses e) => e.Id), "SST_CLAUSES_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstClauses, object>>)((SstClauses e) => e.PolicyType)).HasName("SST_CLAUSES_IDX03");
					entity.HasIndex((Expression<Func<SstClauses, object>>)((SstClauses e) => e.SystemId)).HasName("SST_CLAUSES_IDX04");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstClauses>(entity.HasOne((SstClauses d) => d.Class).WithMany((SstClasses p) => p.SstClauses).HasForeignKey((SstClauses d) => d.ClassId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_CLAUSES_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstClauses>(entity.HasOne((SstClauses d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstClauses).HasForeignKey((SstClauses d) => d.PolicyType), "SST_CLAUSES_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstClauses>(entity.HasOne((SstClauses d) => d.System).WithMany((SstSystems p) => p.SstClauses).HasForeignKey((SstClauses d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_CLAUSES_FK03");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstClausesDetails> entity)
				{
					entity.HasIndex((Expression<Func<SstClausesDetails, object>>)((SstClausesDetails e) => e.ClauseId)).HasName("SST_CLAUSES_DETAILS_IDX02");
					entity.HasIndex((Expression<Func<SstClausesDetails, object>>)((SstClausesDetails e) => e.Id)).HasName("PRIMARY_22").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstClausesDetails e) => e.Id), "SST_CLAUSES_DETAILS_SEQ", (string)null);
					entity.Property((SstClausesDetails e) => e.DiscountType).HasDefaultValueSql("NULL\n");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClauses, SstClausesDetails>(entity.HasOne((SstClausesDetails d) => d.Clause).WithMany((SstClauses p) => p.SstClausesDetails).HasForeignKey((SstClausesDetails d) => d.ClauseId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_CLAUSES_DETAILS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstClosingPeriods> entity)
				{
					entity.HasIndex((Expression<Func<SstClosingPeriods, object>>)((SstClosingPeriods e) => e.ClassId)).HasName("SST_CLOSING_PERIODS_IDX02");
					entity.HasIndex((Expression<Func<SstClosingPeriods, object>>)((SstClosingPeriods e) => e.CompanyId)).HasName("SST_CLOSING_PERIODS_IDX01");
					entity.HasIndex((Expression<Func<SstClosingPeriods, object>>)((SstClosingPeriods e) => e.Id)).HasName("PRIMARY_23").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstClosingPeriods e) => e.Id), "SST_CLOSING_PERIODS_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstClosingPeriods, object>>)((SstClosingPeriods e) => e.PolicyType)).HasName("SST_CLOSING_PERIODS_IDX03");
					entity.HasIndex((Expression<Func<SstClosingPeriods, object>>)((SstClosingPeriods e) => e.SystemId)).HasName("SST_CLOSING_PERIODS_IDX04");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstClosingPeriods>(entity.HasOne((SstClosingPeriods d) => d.Class).WithMany((SstClasses p) => p.SstClosingPeriods).HasForeignKey((SstClosingPeriods d) => d.ClassId), "SST_CLOSING_PERIODS_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstClosingPeriods>(entity.HasOne((SstClosingPeriods d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstClosingPeriods).HasForeignKey((SstClosingPeriods d) => d.PolicyType), "SST_CLOSING_PERIODS_FK03");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstClosingPeriods>(entity.HasOne((SstClosingPeriods d) => d.System).WithMany((SstSystems p) => p.SstClosingPeriods).HasForeignKey((SstClosingPeriods d) => d.SystemId), "SST_CLOSING_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstCodes> entity)
				{
					entity.HasIndex((Expression<Func<SstCodes, object>>)((SstCodes e) => e.CodeId)).HasName("SST_CODES_FK01");
					entity.HasIndex((Expression<Func<SstCodes, object>>)((SstCodes e) => e.Id)).HasName("PRIMARY_24").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstCodes e) => e.Id), "SST_CODES_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstCodes, object>>)((SstCodes e) => e.ModuleCode)).HasName("SST_CODES_FK02");
					entity.HasIndex((Expression<Func<SstCodes, object>>)((SstCodes e) => new { e.SystemId, e.ModuleCode })).HasName("SST_CODES_IDX02");
					entity.HasIndex((Expression<Func<SstCodes, object>>)((SstCodes e) => new { e.MajorCode, e.MinorCode, e.SystemId })).HasName("SST_CODES_UN01").IsUnique();
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstCodes, SstCodes>(entity.HasOne((SstCodes d) => d.Code).WithMany((SstCodes p) => p.InverseCode).HasForeignKey((SstCodes d) => d.CodeId), "SST_CODES_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstModules, SstCodes>(entity.HasOne((SstCodes d) => d.ModuleCodeNavigation).WithMany((SstModules p) => p.SstCodes).HasForeignKey((SstCodes d) => d.ModuleCode), "SST_CODES_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstCodes>(entity.HasOne((SstCodes d) => d.System).WithMany((SstSystems p) => p.SstCodes).HasForeignKey((SstCodes d) => d.SystemId), "SST_CODES_FK03");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstCommStructureBusiness> entity)
				{
					entity.HasIndex((Expression<Func<SstCommStructureBusiness, object>>)((SstCommStructureBusiness e) => e.Id)).HasName("SYS_C0027173").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstCommStructureBusiness e) => e.Id), "SST_COMM_STRUCTURE_BUS_SEQ", (string)null);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstCommStructureBusiness>(entity.HasOne((SstCommStructureBusiness d) => d.Class).WithMany((SstClasses p) => p.SstCommStructureBusiness).HasForeignKey((SstCommStructureBusiness d) => d.ClassId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C0040107");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstCommissionStructure, SstCommStructureBusiness>(entity.HasOne((SstCommStructureBusiness d) => d.CommStructure).WithMany((SstCommissionStructure p) => p.SstCommStructureBusiness).HasForeignKey((SstCommStructureBusiness d) => d.CommStructureId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C0040127");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstCommStructureBusiness>(entity.HasOne((SstCommStructureBusiness d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstCommStructureBusiness).HasForeignKey((SstCommStructureBusiness d) => d.PolicyType), "SYS_C0040184");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstCommissionDetails> entity)
				{
					entity.HasIndex((Expression<Func<SstCommissionDetails, object>>)((SstCommissionDetails e) => e.ClassId)).HasName("SST_COMMISSION_DETAILS_IDX02");
					entity.HasIndex((Expression<Func<SstCommissionDetails, object>>)((SstCommissionDetails e) => e.CommissionId)).HasName("SST_COMMISSION_DETAILS_IDX01");
					entity.HasIndex((Expression<Func<SstCommissionDetails, object>>)((SstCommissionDetails e) => e.Id)).HasName("PRIMARY_25").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstCommissionDetails e) => e.Id), "SST_COMMISSION_DETAILS_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstCommissionDetails, object>>)((SstCommissionDetails e) => e.PolicyType)).HasName("SST_COMMISSION_DETAILS_IDX03");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstCommissionDetails>(entity.HasOne((SstCommissionDetails d) => d.Class).WithMany((SstClasses p) => p.SstCommissionDetails).HasForeignKey((SstCommissionDetails d) => d.ClassId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_COMMISSION_DETAILS_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstCommissionTypes, SstCommissionDetails>(entity.HasOne((SstCommissionDetails d) => d.Commission).WithMany((SstCommissionTypes p) => p.SstCommissionDetails).HasForeignKey((SstCommissionDetails d) => d.CommissionId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_COMMISSION_DETAILS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstCommissionDetails>(entity.HasOne((SstCommissionDetails d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstCommissionDetails).HasForeignKey((SstCommissionDetails d) => d.PolicyType), "SST_COMMISSION_DETAILS_FK03");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstCommissionStructure> entity)
				{
					entity.HasIndex((Expression<Func<SstCommissionStructure, object>>)((SstCommissionStructure e) => e.Id)).HasName("SYS_C0026762").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstCommissionStructure e) => e.Id), "SST_COMMISSION_STRUCTURE_SEQ", (string)null);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstCommissionStructure, SstCommissionStructure>(entity.HasOne((SstCommissionStructure d) => d.CommStructure).WithMany((SstCommissionStructure p) => p.InverseCommStructure).HasForeignKey((SstCommissionStructure d) => d.CommStructureId), "SYS_C0040126");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstCommissionStructure>(entity.HasOne((SstCommissionStructure d) => d.System).WithMany((SstSystems p) => p.SstCommissionStructure).HasForeignKey((SstCommissionStructure d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C0040224");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstCommissionTiers> entity)
				{
					entity.HasIndex((Expression<Func<SstCommissionTiers, object>>)((SstCommissionTiers e) => e.CommissionDtlId)).HasName("SST_COMMISSION_TIERS_IDX01");
					entity.HasIndex((Expression<Func<SstCommissionTiers, object>>)((SstCommissionTiers e) => e.CustomerId)).HasName("SST_COMMISSION_TIERS_IDX02");
					entity.HasIndex((Expression<Func<SstCommissionTiers, object>>)((SstCommissionTiers e) => e.Id)).HasName("PRIMARY_26").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstCommissionTiers e) => e.Id), "SST_COMMISSION_TIERS_SEQ", (string)null);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstCommissionDetails, SstCommissionTiers>(entity.HasOne((SstCommissionTiers d) => d.CommissionDtl).WithMany((SstCommissionDetails p) => p.SstCommissionTiers).HasForeignKey((SstCommissionTiers d) => d.CommissionDtlId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_COMMISSION_TIERS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstCommissionTypes> entity)
				{
					entity.HasIndex((Expression<Func<SstCommissionTypes, object>>)((SstCommissionTypes e) => e.CompanyId)).HasName("SST_COMMISSION_TYPES_IDX01");
					entity.HasIndex((Expression<Func<SstCommissionTypes, object>>)((SstCommissionTypes e) => e.Id)).HasName("PRIMARY_27").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstCommissionTypes e) => e.Id), "SST_COMMISSION_TYPES_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstCommissionTypes, object>>)((SstCommissionTypes e) => e.SystemId)).HasName("SST_COMMISSION_TYPES_IDX02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstCommissionTypes>(entity.HasOne((SstCommissionTypes d) => d.System).WithMany((SstSystems p) => p.SstCommissionTypes).HasForeignKey((SstCommissionTypes d) => d.SystemId), "SST_COMMISSION_TYPES_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstComponents> entity)
				{
					entity.HasIndex((Expression<Func<SstComponents, object>>)((SstComponents e) => e.CompanyId)).HasName("SST_COMPONENTS_IDX03");
					entity.HasIndex((Expression<Func<SstComponents, object>>)((SstComponents e) => e.Id)).HasName("PRIMARY_28").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstComponents e) => e.Id), "SST_COMPONENTS_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstComponents, object>>)((SstComponents e) => e.SystemId)).HasName("SST_COMPONENTS_IDX02");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstConditions> entity)
				{
					entity.HasIndex((Expression<Func<SstConditions, object>>)((SstConditions e) => e.Id)).HasName("PRIMARY_29").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstConditions e) => e.Id), "SST_CONDITIONS_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstConditions, object>>)((SstConditions e) => e.RuleId)).HasName("SST_CONDITIONS_IDX01");
					entity.Property((SstConditions e) => e.ConditionType).HasDefaultValueSql("'1' ");
					entity.Property((SstConditions e) => e.Order).HasDefaultValueSql("'1' ");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstRules, SstConditions>(entity.HasOne((SstConditions d) => d.Rule).WithMany((SstRules p) => p.SstConditions).HasForeignKey((SstConditions d) => d.RuleId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_CONDITIONS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstContainers> entity)
				{
					entity.HasIndex((Expression<Func<SstContainers, object>>)((SstContainers e) => e.ComponentId)).HasName("SST_CONTAINERS_IDX02");
					entity.HasIndex((Expression<Func<SstContainers, object>>)((SstContainers e) => e.Id)).HasName("PRIMARY_30").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstContainers e) => e.Id), "SST_CONTAINERS_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstContainers, object>>)((SstContainers e) => e.RefContainerId)).HasName("SST_CONTAINERS_IDX03");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstComponents, SstContainers>(entity.HasOne((SstContainers d) => d.Component).WithMany((SstComponents p) => p.SstContainers).HasForeignKey((SstContainers d) => d.ComponentId), "SST_CONTAINERS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstCoreQuestionnaires> entity)
				{
					entity.HasIndex((Expression<Func<SstCoreQuestionnaires, object>>)((SstCoreQuestionnaires e) => e.ClassId)).HasName("SST_CORE_QUESTIONNAIRES_IDX02");
					entity.HasIndex((Expression<Func<SstCoreQuestionnaires, object>>)((SstCoreQuestionnaires e) => e.Id)).HasName("SYS_C0025411").IsUnique();
					entity.HasIndex((Expression<Func<SstCoreQuestionnaires, object>>)((SstCoreQuestionnaires e) => e.PolicyTypeId)).HasName("SST_CORE_QUESTIONNAIRES_IDX03");
					entity.HasIndex((Expression<Func<SstCoreQuestionnaires, object>>)((SstCoreQuestionnaires e) => e.SystemId)).HasName("SST_CORE_QUESTIONNAIRES_IDX01");
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstCoreQuestionnaires e) => e.Id), "SST_CORE_QUESTIONNAIRES_SEQ", (string)null);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstCoreQuestionnaires>(entity.HasOne((SstCoreQuestionnaires d) => d.Class).WithMany((SstClasses p) => p.SstCoreQuestionnaires).HasForeignKey((SstCoreQuestionnaires d) => d.ClassId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_CORE_QUESTIONNAIRES_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstCoreQuestionnaires>(entity.HasOne((SstCoreQuestionnaires d) => d.PolicyType).WithMany((SstPolicyTypes p) => p.SstCoreQuestionnaires).HasForeignKey((SstCoreQuestionnaires d) => d.PolicyTypeId), "SST_CORE_QUESTIONNAIRES_FK03");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstCoreQuestionnaires>(entity.HasOne((SstCoreQuestionnaires d) => d.System).WithMany((SstSystems p) => p.SstCoreQuestionnaires).HasForeignKey((SstCoreQuestionnaires d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_CORE_QUESTIONNAIRES_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstCoverRatingTypes> entity)
				{
					entity.HasIndex((Expression<Func<SstCoverRatingTypes, object>>)((SstCoverRatingTypes e) => e.Id)).HasName("SYS_C0026615").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstCoverRatingTypes e) => e.Id), "SST_COVER_RATING_TYPES_SEQ", (string)null);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstCoverTypes, SstCoverRatingTypes>(entity.HasOne((SstCoverRatingTypes d) => d.CoverTypeNavigation).WithMany((SstCoverTypes p) => p.SstCoverRatingTypes).HasForeignKey((SstCoverRatingTypes d) => d.CoverType)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C0040133");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstCoverTypes> entity)
				{
					entity.HasIndex((Expression<Func<SstCoverTypes, object>>)((SstCoverTypes e) => e.ClassId)).HasName("SST_COVER_TYPES_FK02");
					entity.HasIndex((Expression<Func<SstCoverTypes, object>>)((SstCoverTypes e) => e.CoverId)).HasName("SST_COVER_TYPES_FK04");
					entity.HasIndex((Expression<Func<SstCoverTypes, object>>)((SstCoverTypes e) => e.Id)).HasName("PRIMARY_31").IsUnique();
					entity.HasIndex((Expression<Func<SstCoverTypes, object>>)((SstCoverTypes e) => e.MinPremParentCover)).HasName("SST_COVER_TYPES_IDX05");
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstCoverTypes e) => e.Id), "SST_COVER_TYPES_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstCoverTypes, object>>)((SstCoverTypes e) => e.PolicyType)).HasName("SST_COVER_TYPES_FK03");
					entity.HasIndex((Expression<Func<SstCoverTypes, object>>)((SstCoverTypes e) => e.SystemId)).HasName("SST_COVER_TYPES_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstCoverTypes>(entity.HasOne((SstCoverTypes d) => d.Class).WithMany((SstClasses p) => p.SstCoverTypes).HasForeignKey((SstCoverTypes d) => d.ClassId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_COVER_TYPES_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstCoverTypes, SstCoverTypes>(entity.HasOne((SstCoverTypes d) => d.Cover).WithMany((SstCoverTypes p) => p.InverseCover).HasForeignKey((SstCoverTypes d) => d.CoverId), "SST_COVER_TYPES_FK04");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstCoverTypes, SstCoverTypes>(entity.HasOne((SstCoverTypes d) => d.MinPremParentCoverNavigation).WithMany((SstCoverTypes p) => p.InverseMinPremParentCoverNavigation).HasForeignKey((SstCoverTypes d) => d.MinPremParentCover), "MIN_PREM_PARENT_COVER_FK");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstCoverTypes>(entity.HasOne((SstCoverTypes d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstCoverTypes).HasForeignKey((SstCoverTypes d) => d.PolicyType), "SST_COVER_TYPES_FK03");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstCoverTypes>(entity.HasOne((SstCoverTypes d) => d.System).WithMany((SstSystems p) => p.SstCoverTypes).HasForeignKey((SstCoverTypes d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_COVER_TYPES_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstCustomerTypes> entity)
				{
					entity.HasIndex((Expression<Func<SstCustomerTypes, object>>)((SstCustomerTypes e) => e.CompanyId)).HasName("SST_CUSTOMER_TYPES_IDX02");
					entity.HasIndex((Expression<Func<SstCustomerTypes, object>>)((SstCustomerTypes e) => e.Id)).HasName("PRIMARY_32").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstCustomerTypes e) => e.Id), "SST_CUSTOMER_TYPES_SEQ", (string)null);
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstDataSecurity> entity)
				{
					entity.HasIndex((Expression<Func<SstDataSecurity, object>>)((SstDataSecurity e) => e.ClassId)).HasName("SST_DATA_SECURITY_IDX01");
					entity.HasIndex((Expression<Func<SstDataSecurity, object>>)((SstDataSecurity e) => e.CompanyId)).HasName("SST_DATA_SECURITY_IDX06");
					entity.HasIndex((Expression<Func<SstDataSecurity, object>>)((SstDataSecurity e) => e.GroupId)).HasName("SST_DATA_SECURITY_IDX04");
					entity.HasIndex((Expression<Func<SstDataSecurity, object>>)((SstDataSecurity e) => e.Id)).HasName("PRIMARY_33").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstDataSecurity e) => e.Id), "SST_DATA_SECURITY_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstDataSecurity, object>>)((SstDataSecurity e) => e.PolicyType)).HasName("SST_DATA_SECURITY_IDX02");
					entity.HasIndex((Expression<Func<SstDataSecurity, object>>)((SstDataSecurity e) => e.ProductId)).HasName("SST_DATA_SECURITY_IDX03");
					entity.HasIndex((Expression<Func<SstDataSecurity, object>>)((SstDataSecurity e) => e.Username)).HasName("SST_DATA_SECURITY_IDX05");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstDataSecurity>(entity.HasOne((SstDataSecurity d) => d.Class).WithMany((SstClasses p) => p.SstDataSecurity).HasForeignKey((SstDataSecurity d) => d.ClassId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_DATA_SECURITY_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstDataSecurity>(entity.HasOne((SstDataSecurity d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstDataSecurity).HasForeignKey((SstDataSecurity d) => d.PolicyType)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_DATA_SECURITY_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPackagedPolicy, SstDataSecurity>(entity.HasOne((SstDataSecurity d) => d.Product).WithMany((SstPackagedPolicy p) => p.SstDataSecurity).HasForeignKey((SstDataSecurity d) => d.ProductId), "SST_DATA_SECURITY_FK03");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstDiscounts> entity)
				{
					entity.HasIndex((Expression<Func<SstDiscounts, object>>)((SstDiscounts e) => e.Id)).HasName("PRIMARY_34").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstDiscounts e) => e.Id), "SST_DISCOUNTS_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstDiscounts, object>>)((SstDiscounts e) => e.SystemId)).HasName("SST_DISCOUNTS_FK01");
					entity.Property((SstDiscounts e) => e.Type).HasDefaultValueSql("1\n");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstDiscounts>(entity.HasOne((SstDiscounts d) => d.System).WithMany((SstSystems p) => p.SstDiscounts).HasForeignKey((SstDiscounts d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_DISCOUNTS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstDiscountsBusinessFactors> entity)
				{
					entity.HasIndex((Expression<Func<SstDiscountsBusinessFactors, object>>)((SstDiscountsBusinessFactors e) => e.DiscountFactorId)).HasName("SST_DISCOUNTS_BUS_FACTORS_IDX2");
					entity.HasIndex((Expression<Func<SstDiscountsBusinessFactors, object>>)((SstDiscountsBusinessFactors e) => e.Id)).HasName("SYS_C0025704").IsUnique();
					entity.HasIndex((Expression<Func<SstDiscountsBusinessFactors, object>>)((SstDiscountsBusinessFactors e) => e.PolicyDiscountId)).HasName("SST_DISCOUNTS_BUS_FACTORS_IDX1");
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstDiscountsBusinessFactors e) => e.Id), "SST_DISCOUNTS_BUS_FACTORS_SEQ", (string)null);
					entity.Property((SstDiscountsBusinessFactors e) => e.ModificationDate).HasDefaultValueSql("NULL");
					entity.Property((SstDiscountsBusinessFactors e) => e.ModificationUser).HasDefaultValueSql("NULL");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstDiscountsFactors, SstDiscountsBusinessFactors>(entity.HasOne((SstDiscountsBusinessFactors d) => d.DiscountFactor).WithMany((SstDiscountsFactors p) => p.SstDiscountsBusinessFactors).HasForeignKey((SstDiscountsBusinessFactors d) => d.DiscountFactorId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_DISCOUNTS_BUS_FACTORS_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyDiscounts, SstDiscountsBusinessFactors>(entity.HasOne((SstDiscountsBusinessFactors d) => d.PolicyDiscount).WithMany((SstPolicyDiscounts p) => p.SstDiscountsBusinessFactors).HasForeignKey((SstDiscountsBusinessFactors d) => d.PolicyDiscountId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_DISCOUNTS_BUS_FACTORS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstDiscountsFactors> entity)
				{
					entity.HasIndex((Expression<Func<SstDiscountsFactors, object>>)((SstDiscountsFactors e) => e.Id)).HasName("SYS_C0025902").IsUnique();
					entity.HasIndex((Expression<Func<SstDiscountsFactors, object>>)((SstDiscountsFactors e) => e.SystemId)).HasName("SST_DISCOUNTS_FACTORS_IDX01");
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstDiscountsFactors e) => e.Id), "SST_DISCOUNTS_FACTORS_SEQ", (string)null);
					entity.Property((SstDiscountsFactors e) => e.ModificationDate).HasDefaultValueSql("NULL");
					entity.Property((SstDiscountsFactors e) => e.ModificationUser).HasDefaultValueSql("NULL");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstDiscountsFactors>(entity.HasOne((SstDiscountsFactors d) => d.System).WithMany((SstSystems p) => p.SstDiscountsFactors).HasForeignKey((SstDiscountsFactors d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_DISCOUNTS_FACTORS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstDiscountsFactorsQuery> entity)
				{
					entity.HasIndex((Expression<Func<SstDiscountsFactorsQuery, object>>)((SstDiscountsFactorsQuery e) => e.DiscountId)).HasName("SST_DISCOUNTS_FACTORS_QRY_IND1");
					entity.HasIndex((Expression<Func<SstDiscountsFactorsQuery, object>>)((SstDiscountsFactorsQuery e) => e.Id)).HasName("SST_DISCOUNTS_FACTORS_QUERY_PK").IsUnique();
					entity.HasIndex((Expression<Func<SstDiscountsFactorsQuery, object>>)((SstDiscountsFactorsQuery e) => e.PolicyDiscId)).HasName("SST_DISCOUNTS_FACTORS_QRY_IND2");
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstDiscountsFactorsQuery e) => e.Id), "SST_DISCOUNTS_FACTORS_QRY_SEQ", (string)null);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstDiscounts, SstDiscountsFactorsQuery>(entity.HasOne((SstDiscountsFactorsQuery d) => d.Discount).WithMany((SstDiscounts p) => p.SstDiscountsFactorsQuery).HasForeignKey((SstDiscountsFactorsQuery d) => d.DiscountId)
					//	.OnDelete(DeleteBehavior.Cascade), "SST_DISCOUNTS_FACTORS_QRY_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyDiscounts, SstDiscountsFactorsQuery>(entity.HasOne((SstDiscountsFactorsQuery d) => d.PolicyDisc).WithMany((SstPolicyDiscounts p) => p.SstDiscountsFactorsQuery).HasForeignKey((SstDiscountsFactorsQuery d) => d.PolicyDiscId)
					//	.OnDelete(DeleteBehavior.Cascade), "SST_DISCOUNTS_FACTORS_QRY_FK02");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstDocumentGroups> entity)
				{
					entity.HasIndex((Expression<Func<SstDocumentGroups, object>>)((SstDocumentGroups e) => e.Id)).HasName("PRIMARY_35").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstDocumentGroups e) => e.Id), "SST_DOCUMENT_GROUPS_SEQ", (string)null);
					//entity.HasIndex((Expression<Func<SstDocumentGroups, object>>)((SstDocumentGroups e) => e.SystemId)).HasName("SST_DOCUMENT_GROUPS_IDX02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstDocumentGroups>(entity.HasOne((SstDocumentGroups d) => d.System).WithMany((SstSystems p) => p.SstDocumentGroups).HasForeignKey((SstDocumentGroups d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_DOCUMENT_GROUPS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstDocuments> entity)
				{
					entity.HasIndex((Expression<Func<SstDocuments, object>>)((SstDocuments e) => e.GroupId)).HasName("SST_DOCUMENTS_IDX02");
					entity.HasIndex((Expression<Func<SstDocuments, object>>)((SstDocuments e) => e.Id)).HasName("PRIMARY_36").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstDocuments e) => e.Id), "SST_DOCUMENTS_SEQ", (string)null);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstDocumentGroups, SstDocuments>(entity.HasOne((SstDocuments d) => d.Group).WithMany((SstDocumentGroups p) => p.SstDocuments).HasForeignKey((SstDocuments d) => d.GroupId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_DOCUMENTS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstDomainValues> entity)
				{
					entity.HasIndex((Expression<Func<SstDomainValues, object>>)((SstDomainValues e) => e.DomainId)).HasName("SST_DOMAIN_VALUES_FK01");
					entity.HasIndex((Expression<Func<SstDomainValues, object>>)((SstDomainValues e) => e.Id)).HasName("PRIMARY_37").IsUnique();
					entity.HasIndex((Expression<Func<SstDomainValues, object>>)((SstDomainValues e) => new { e.DomainCode, e.Value, e.SystemId, e.CompanyId })).HasName("SST_DOMAIN_VALUES_IDX02");
					entity.HasIndex((Expression<Func<SstDomainValues, object>>)((SstDomainValues e) => new { e.Value, e.DomainCode, e.SystemId, e.CompanyId })).HasName("SST_DOMAIN_VALUES_UN01").IsUnique();
					entity.Property((SstDomainValues e) => e.Id).ValueGeneratedNever();
					entity.Property((SstDomainValues e) => e.Order).HasDefaultValueSql("'1' ");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstDomains, SstDomainValues>(entity.HasOne((SstDomainValues d) => d.Domain).WithMany((SstDomains p) => p.SstDomainValues).HasForeignKey((SstDomainValues d) => d.DomainId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_DOMAIN_VALUES_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstDomains> entity)
				{
					entity.HasIndex((Expression<Func<SstDomains, object>>)((SstDomains e) => e.Code)).HasName("SST_DOMAINS_IDX03");
					entity.HasIndex((Expression<Func<SstDomains, object>>)((SstDomains e) => e.Id)).HasName("PRIMARY_38").IsUnique();
					entity.HasIndex((Expression<Func<SstDomains, object>>)((SstDomains e) => new { e.Code, e.SystemId, e.CompanyId })).HasName("SST_DOMAINS_UN01").IsUnique();
					entity.HasIndex((Expression<Func<SstDomains, object>>)((SstDomains e) => new { e.SystemId, e.Code, e.CompanyId })).HasName("SST_DOMAINS_IDX02");
					entity.Property((SstDomains e) => e.Id).ValueGeneratedNever();
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstDomains>(entity.HasOne((SstDomains d) => d.System).WithMany((SstSystems p) => p.SstDomains).HasForeignKey((SstDomains d) => d.SystemId), "SST_DOMAINS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstDynamicValues> entity)
				{
					entity.HasIndex((Expression<Func<SstDynamicValues, object>>)((SstDynamicValues e) => e.Id)).HasName("SYS_C0025479").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstDynamicValues e) => e.Id), "SST_DYNAMIC_VALUES_SEQ", (string)null);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstQuestDetails, SstDynamicValues>(entity.HasOne((SstDynamicValues d) => d.QuestDetail).WithMany((SstQuestDetails p) => p.SstDynamicValues).HasForeignKey((SstDynamicValues d) => d.QuestDetailId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C0040488");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstEndorsements> entity)
				{
					entity.HasIndex((Expression<Func<SstEndorsements, object>>)((SstEndorsements e) => e.ClassId)).HasName("SST_ENDORSEMENTS_FK02");
					entity.HasIndex((Expression<Func<SstEndorsements, object>>)((SstEndorsements e) => e.Id)).HasName("PRIMARY_39").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstEndorsements e) => e.Id), "SST_ENDORSEMENTS_SEQ", (string)null);
					//entity.HasIndex((Expression<Func<SstEndorsements, object>>)((SstEndorsements e) => e.SystemId)).HasName("SST_ENDORSEMENTS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstEndorsements>(entity.HasOne((SstEndorsements d) => d.Class).WithMany((SstClasses p) => p.SstEndorsements).HasForeignKey((SstEndorsements d) => d.ClassId), "SST_ENDORSEMENTS_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstEndorsements>(entity.HasOne((SstEndorsements d) => d.System).WithMany((SstSystems p) => p.SstEndorsements).HasForeignKey((SstEndorsements d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_ENDORSEMENTS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstEntities> entity)
				{
					entity.HasIndex((Expression<Func<SstEntities, object>>)((SstEntities e) => e.Area)).HasName("SST_ENTITIES_IDX06");
					entity.HasIndex((Expression<Func<SstEntities, object>>)((SstEntities e) => e.BusinessSector)).HasName("SST_ENTITIES_IDX01");
					entity.HasIndex((Expression<Func<SstEntities, object>>)((SstEntities e) => e.City)).HasName("SST_ENTITIES_IDX05");
					entity.HasIndex((Expression<Func<SstEntities, object>>)((SstEntities e) => e.Country)).HasName("SST_ENTITIES_IDX03");
					entity.HasIndex((Expression<Func<SstEntities, object>>)((SstEntities e) => e.Governorate)).HasName("SST_ENTITIES_IDX04");
					entity.HasIndex((Expression<Func<SstEntities, object>>)((SstEntities e) => e.HoldBusCountry)).HasName("SST_ENTITIES_IDX08");
					entity.HasIndex((Expression<Func<SstEntities, object>>)((SstEntities e) => e.HoldIncCountry)).HasName("SST_ENTITIES_IDX07");
					entity.HasIndex((Expression<Func<SstEntities, object>>)((SstEntities e) => e.HoldMajority)).HasName("SST_ENTITIES_IDX09");
					entity.HasIndex((Expression<Func<SstEntities, object>>)((SstEntities e) => e.Id)).HasName("PRIMARY_40").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstEntities e) => e.Id), "SST_ENTITIES_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstEntities, object>>)((SstEntities e) => e.Name)).HasName("SST_ENTITIES_UK01").IsUnique();
					entity.HasIndex((Expression<Func<SstEntities, object>>)((SstEntities e) => e.SubSector)).HasName("SST_ENTITIES_IDX02");
					entity.Property((SstEntities e) => e.BlacklistFlag).HasDefaultValueSql("'0'");
					entity.Property((SstEntities e) => e.CreditLimit).HasDefaultValueSql("'0.000'");
					entity.Property((SstEntities e) => e.EmailCommunication).HasDefaultValueSql("'0'");
					entity.Property((SstEntities e) => e.HomeCommunication).HasDefaultValueSql("'0'");
					entity.Property((SstEntities e) => e.PaidUpCapital).HasDefaultValueSql("'0.00000'");
					entity.Property((SstEntities e) => e.PhoneCommunication).HasDefaultValueSql("'0'");
					entity.Property((SstEntities e) => e.PostalCommunication).HasDefaultValueSql("'0'");
					entity.Property((SstEntities e) => e.SmsCommunication).HasDefaultValueSql("'0'");
					entity.Property((SstEntities e) => e.TaxableFlag).HasDefaultValueSql("'0'");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstEntityDetails> entity)
				{
					entity.HasIndex((Expression<Func<SstEntityDetails, object>>)((SstEntityDetails e) => e.Country)).HasName("SST_ENTITY_DETAILS_IDX01");
					entity.HasIndex((Expression<Func<SstEntityDetails, object>>)((SstEntityDetails e) => e.EntityId)).HasName("SST_ENTITY_DETAILS_IDX02");
					entity.HasIndex((Expression<Func<SstEntityDetails, object>>)((SstEntityDetails e) => e.Id)).HasName("PRIMARY_41").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstEntityDetails e) => e.Id), "SST_ENTITY_DETAILS_SEQ", (string)null);
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstEntityMapping> entity)
				{
					entity.HasIndex((Expression<Func<SstEntityMapping, object>>)((SstEntityMapping e) => e.AccountId)).HasName("SST_ENTITY_MAPPING_IDX03");
					entity.HasIndex((Expression<Func<SstEntityMapping, object>>)((SstEntityMapping e) => e.AccountType)).HasName("SST_ENTITY_MAPPING_IDX02");
					entity.HasIndex((Expression<Func<SstEntityMapping, object>>)((SstEntityMapping e) => e.CostCenter)).HasName("SST_ENTITY_MAPPING_IDX04");
					entity.HasIndex((Expression<Func<SstEntityMapping, object>>)((SstEntityMapping e) => e.Id)).HasName("PRIMARY_42").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstEntityMapping e) => e.Id), "SST_ENTITY_MAPPING_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstEntityMapping, object>>)((SstEntityMapping e) => e.RoleId)).HasName("SST_ENTITY_MAPPING_IDX01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstEntityRoles> entity)
				{
					entity.HasIndex((Expression<Func<SstEntityRoles, object>>)((SstEntityRoles e) => e.AccountId)).HasName("SST_ENTITY_ROLES_IDX03");
					entity.HasIndex((Expression<Func<SstEntityRoles, object>>)((SstEntityRoles e) => e.CostCenter)).HasName("SST_ENTITY_ROLES_IDX04");
					entity.HasIndex((Expression<Func<SstEntityRoles, object>>)((SstEntityRoles e) => e.EntityId)).HasName("SST_ENTITY_ROLES_IDX01");
					entity.HasIndex((Expression<Func<SstEntityRoles, object>>)((SstEntityRoles e) => e.Id)).HasName("PRIMARY_43").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstEntityRoles e) => e.Id), "SST_ENTITY_ROLES_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstEntityRoles, object>>)((SstEntityRoles e) => e.RoleId)).HasName("SST_ENTITY_ROLES_IDX02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstEntities, SstEntityRoles>(entity.HasOne((SstEntityRoles d) => d.Entity).WithMany((SstEntities p) => p.SstEntityRoles).HasForeignKey((SstEntityRoles d) => d.EntityId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_ENTITY_ROLES_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstEpaymentAlerts> entity)
				{
					entity.HasIndex((Expression<Func<SstEpaymentAlerts, object>>)((SstEpaymentAlerts e) => e.Id)).HasName("PRIMARY_44").IsUnique();
					entity.HasIndex((Expression<Func<SstEpaymentAlerts, object>>)((SstEpaymentAlerts e) => e.PaymentId)).HasName("SST_EPAYMENT_ALERTS_FK01");
					entity.Property((SstEpaymentAlerts e) => e.Id).ValueGeneratedNever();
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstEpaymentMethods, SstEpaymentAlerts>(entity.HasOne((SstEpaymentAlerts d) => d.Payment).WithMany((SstEpaymentMethods p) => p.SstEpaymentAlerts).HasForeignKey((SstEpaymentAlerts d) => d.PaymentId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_EPAYMENT_ALERTS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstEpaymentDetails> entity)
				{
					entity.HasIndex((Expression<Func<SstEpaymentDetails, object>>)((SstEpaymentDetails e) => e.Id)).HasName("PRIMARY_45").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstEpaymentDetails e) => e.Id), "SST_EPAYMENT_DETAILS_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstEpaymentDetails, object>>)((SstEpaymentDetails e) => e.PaymentId)).HasName("SST_EPAYMENT_DETAILS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstEpaymentMethods, SstEpaymentDetails>(entity.HasOne((SstEpaymentDetails d) => d.Payment).WithMany((SstEpaymentMethods p) => p.SstEpaymentDetails).HasForeignKey((SstEpaymentDetails d) => d.PaymentId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_EPAYMENT_DETAILS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstEpaymentMethods> entity)
				{
					entity.HasIndex((Expression<Func<SstEpaymentMethods, object>>)((SstEpaymentMethods e) => e.Id)).HasName("PRIMARY_46").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstEpaymentMethods e) => e.Id), "SST_EPAYMENT_METHODS_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstEpaymentMethods, object>>)((SstEpaymentMethods e) => e.SystemId)).HasName("SST_EPAYMENT_METHODS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstEpaymentMethods>(entity.HasOne((SstEpaymentMethods d) => d.System).WithMany((SstSystems p) => p.SstEpaymentMethods).HasForeignKey((SstEpaymentMethods d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_EPAYMENT_METHODS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstEpaymentTransaction> entity)
				{
					entity.HasIndex((Expression<Func<SstEpaymentTransaction, object>>)((SstEpaymentTransaction e) => e.Id)).HasName("PRIMARY_47").IsUnique();
					entity.Property((SstEpaymentTransaction e) => e.Id).ValueGeneratedNever();
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstFees> entity)
				{
					entity.HasIndex((Expression<Func<SstFees, object>>)((SstFees e) => e.CompanyId)).HasName("SST_FEES_IDX02");
					entity.HasIndex((Expression<Func<SstFees, object>>)((SstFees e) => e.Id)).HasName("PRIMARY_48").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstFees e) => e.Id), "SST_FEES_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstFees, object>>)((SstFees e) => e.SystemId)).HasName("SST_FEES_IDX03");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstFees>(entity.HasOne((SstFees d) => d.System).WithMany((SstSystems p) => p.SstFees).HasForeignKey((SstFees d) => d.SystemId), "SST_FEES_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstFeesDetails> entity)
				{
					entity.HasIndex((Expression<Func<SstFeesDetails, object>>)((SstFeesDetails e) => e.FeeId)).HasName("SST_FEES_DETAILS_FK01");
					entity.HasIndex((Expression<Func<SstFeesDetails, object>>)((SstFeesDetails e) => e.Id)).HasName("PRIMARY_49").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstFeesDetails e) => e.Id), "SST_FEES_DETAILS_SEQ", (string)null);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstFees, SstFeesDetails>(entity.HasOne((SstFeesDetails d) => d.Fee).WithMany((SstFees p) => p.SstFeesDetails).HasForeignKey((SstFeesDetails d) => d.FeeId), "SST_FEES_DETAILS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstFeesTiers> entity)
				{
					entity.HasIndex((Expression<Func<SstFeesTiers, object>>)((SstFeesTiers e) => e.ClassId)).HasName("SST_FEES_TIERS_FK03");
					entity.HasIndex((Expression<Func<SstFeesTiers, object>>)((SstFeesTiers e) => e.FeeId)).HasName("SST_FEES_TIERS_IDX02");
					entity.HasIndex((Expression<Func<SstFeesTiers, object>>)((SstFeesTiers e) => e.Id)).HasName("PRIMARY_50").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstFeesTiers e) => e.Id), "SST_FEES_TIERS_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstFeesTiers, object>>)((SstFeesTiers e) => e.PolicyType)).HasName("SST_FEES_TIERS_FK04");
					entity.HasIndex((Expression<Func<SstFeesTiers, object>>)((SstFeesTiers e) => e.SystemId)).HasName("SST_FEES_TIERS_FK02");
					entity.Property((SstFeesTiers e) => e.AmountFrom).HasDefaultValueSql("0\n");
					entity.Property((SstFeesTiers e) => e.AmountTo).HasDefaultValueSql("0\n");
					entity.Property((SstFeesTiers e) => e.AutoAdd).HasDefaultValueSql("'0'");
					entity.Property((SstFeesTiers e) => e.CalculationMethod).HasDefaultValueSql("'0'");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstFeesTiers>(entity.HasOne((SstFeesTiers d) => d.Class).WithMany((SstClasses p) => p.SstFeesTiers).HasForeignKey((SstFeesTiers d) => d.ClassId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_FEES_TIERS_FK03");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstFees, SstFeesTiers>(entity.HasOne((SstFeesTiers d) => d.Fee).WithMany((SstFees p) => p.SstFeesTiers).HasForeignKey((SstFeesTiers d) => d.FeeId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_FEES_TIERS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstFeesTiers>(entity.HasOne((SstFeesTiers d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstFeesTiers).HasForeignKey((SstFeesTiers d) => d.PolicyType), "SST_FEES_TIERS_FK04");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstFeesTiers>(entity.HasOne((SstFeesTiers d) => d.System).WithMany((SstSystems p) => p.SstFeesTiers).HasForeignKey((SstFeesTiers d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_FEES_TIERS_FK02");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstFeesTiersDetails> entity)
				{
					entity.HasIndex((Expression<Func<SstFeesTiersDetails, object>>)((SstFeesTiersDetails e) => e.CoverId)).HasName("SST_FEES_TIERS_DETAILS_FK02");
					entity.HasIndex((Expression<Func<SstFeesTiersDetails, object>>)((SstFeesTiersDetails e) => e.FeeTierId)).HasName("SST_FEES_TYPES_IDX02");
					entity.HasIndex((Expression<Func<SstFeesTiersDetails, object>>)((SstFeesTiersDetails e) => e.Id)).HasName("PRIMARY_51").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstFeesTiersDetails e) => e.Id), "SST_FEES_TIERS_DETAILS_SEQ", (string)null);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstCoverTypes, SstFeesTiersDetails>(entity.HasOne((SstFeesTiersDetails d) => d.Cover).WithMany((SstCoverTypes p) => p.SstFeesTiersDetails).HasForeignKey((SstFeesTiersDetails d) => d.CoverId), "SST_FEES_TIERS_DETAILS_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstFeesTiers, SstFeesTiersDetails>(entity.HasOne((SstFeesTiersDetails d) => d.FeeTier).WithMany((SstFeesTiers p) => p.SstFeesTiersDetails).HasForeignKey((SstFeesTiersDetails d) => d.FeeTierId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_FEES_TIERS_DETAILS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstFinancialAgents> entity)
				{
					entity.HasIndex((Expression<Func<SstFinancialAgents, object>>)((SstFinancialAgents e) => e.Id)).HasName("SYS_C0027137").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstFinancialAgents e) => e.Id), "SST_FINANCIAL_AGENTS_SEQ", (string)null);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstFinancialDetails, SstFinancialAgents>(entity.HasOne((SstFinancialAgents d) => d.FinTrnDet).WithMany((SstFinancialDetails p) => p.SstFinancialAgents).HasForeignKey((SstFinancialAgents d) => d.FinTrnDetId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_FINANCIAL_INST_R01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstFinancialClaims> entity)
				{
					entity.HasIndex((Expression<Func<SstFinancialClaims, object>>)((SstFinancialClaims e) => e.Id)).HasName("SYS_C002493077").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstFinancialClaims e) => e.Id), "SST_FINANCIAL_CLAIMS_SEQ", (string)null);
					//entity.Property((SstFinancialClaims e) => e.ClaimantName).HasDefaultValueSql("NULL\n");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstFinancialTransactions, SstFinancialClaims>(entity.HasOne((SstFinancialClaims d) => d.FinTrn).WithMany((SstFinancialTransactions p) => p.SstFinancialClaims).HasForeignKey((SstFinancialClaims d) => d.FinTrnId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_FINANCIAL_DOC_FK03");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstFinancialDetails> entity)
				{
					entity.HasIndex((Expression<Func<SstFinancialDetails, object>>)((SstFinancialDetails e) => e.Id)).HasName("SYS_C002493048").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstFinancialDetails e) => e.Id), "SST_FINANCIAL_DETAILS_SEQ", (string)null);
					entity.Property((SstFinancialDetails e) => e.AccountId).HasDefaultValueSql("NULL\n");
					entity.Property((SstFinancialDetails e) => e.BankCode).HasDefaultValueSql("NULL\n");
					entity.Property((SstFinancialDetails e) => e.BankDate).HasDefaultValueSql("NULL\n");
					entity.Property((SstFinancialDetails e) => e.BankRef).HasDefaultValueSql("NULL\n");
					entity.Property((SstFinancialDetails e) => e.BranchId).HasDefaultValueSql("NULL\n");
					entity.Property((SstFinancialDetails e) => e.CompanyId).HasDefaultValueSql("NULL\n");
					entity.Property((SstFinancialDetails e) => e.CostCenterId).HasDefaultValueSql("NULL\n");
					entity.Property((SstFinancialDetails e) => e.Currency).HasDefaultValueSql("NULL\n");
					entity.Property((SstFinancialDetails e) => e.CustomerId).HasDefaultValueSql("NULL\n");
					entity.Property((SstFinancialDetails e) => e.DebitCreditId).HasDefaultValueSql("NULL\n");
					entity.Property((SstFinancialDetails e) => e.Exrate).HasDefaultValueSql("'1' ");
					entity.Property((SstFinancialDetails e) => e.FileName).HasDefaultValueSql("NULL\n");
					entity.Property((SstFinancialDetails e) => e.ItemId).HasDefaultValueSql("NULL\n");
					entity.Property((SstFinancialDetails e) => e.ItemPrice).HasDefaultValueSql("NULL\n");
					entity.Property((SstFinancialDetails e) => e.ItemQuantity).HasDefaultValueSql("NULL\n");
					entity.Property((SstFinancialDetails e) => e.ModificationDate).HasDefaultValueSql("NULL");
					entity.Property((SstFinancialDetails e) => e.ModificationUser).HasDefaultValueSql("NULL\n");
					entity.Property((SstFinancialDetails e) => e.Notes).HasDefaultValueSql("NULL\n");
					entity.Property((SstFinancialDetails e) => e.PaymentMethod).HasDefaultValueSql("NULL\n");
					entity.Property((SstFinancialDetails e) => e.ReferenceNo).HasDefaultValueSql("NULL\n");
					entity.Property((SstFinancialDetails e) => e.TransId).HasDefaultValueSql("NULL\n");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstFinancialTransactions, SstFinancialDetails>(entity.HasOne((SstFinancialDetails d) => d.Trans).WithMany((SstFinancialTransactions p) => p.SstFinancialDetails).HasForeignKey((SstFinancialDetails d) => d.TransId), "SST_FINANCIAL_TRANS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstFinancialInstallments> entity)
				{
					entity.HasIndex((Expression<Func<SstFinancialInstallments, object>>)((SstFinancialInstallments e) => e.Id)).HasName("SYS_C0027119").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstFinancialInstallments e) => e.Id), "SST_FINANCIAL_INSTALLMENTS_SEQ", (string)null);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstFinancialDetails, SstFinancialInstallments>(entity.HasOne((SstFinancialInstallments d) => d.FinTrnDet).WithMany((SstFinancialDetails p) => p.SstFinancialInstallments).HasForeignKey((SstFinancialInstallments d) => d.FinTrnDetId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_FINANCIAL_TRANS_DET_R01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstFinancialPolicies> entity)
				{
					entity.HasIndex((Expression<Func<SstFinancialPolicies, object>>)((SstFinancialPolicies e) => e.Id)).HasName("SYS_C002493027").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstFinancialPolicies e) => e.Id), "SST_FINANCIAL_POLICIES_SEQ", (string)null);
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstFinancialTransactions> entity)
				{
					entity.HasIndex((Expression<Func<SstFinancialTransactions, object>>)((SstFinancialTransactions e) => e.Id)).HasName("SYS_C0025228").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstFinancialTransactions e) => e.Id), "SST_FINANCIAL_TRANSACTIONS_SEQ", (string)null);
					entity.Property((SstFinancialTransactions e) => e.AppRefId).HasDefaultValueSql("NULL\n");
					entity.Property((SstFinancialTransactions e) => e.CustomerId).HasDefaultValueSql("NULL\n");
					entity.Property((SstFinancialTransactions e) => e.EndorsementNo).HasDefaultValueSql("NULL\n");
					entity.Property((SstFinancialTransactions e) => e.ModificationDate).HasDefaultValueSql("NULL");
					entity.Property((SstFinancialTransactions e) => e.ModificationUser).HasDefaultValueSql("NULL\n");
					entity.Property((SstFinancialTransactions e) => e.TransId).HasDefaultValueSql("NULL\n");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstFinancialPolicies, SstFinancialTransactions>(entity.HasOne((SstFinancialTransactions d) => d.FinPol).WithMany((SstFinancialPolicies p) => p.SstFinancialTransactions).HasForeignKey((SstFinancialTransactions d) => d.FinPolId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_FINANCIAL_POL_R01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstFormControls> entity)
				{
					entity.HasIndex((Expression<Func<SstFormControls, object>>)((SstFormControls e) => e.ContainerId)).HasName("SST_FIELDS_IDX02");
					entity.HasIndex((Expression<Func<SstFormControls, object>>)((SstFormControls e) => e.Id)).HasName("PRIMARY_54").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstFormControls e) => e.Id), "SST_FORM_CONTROLS_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstFormControls, object>>)((SstFormControls e) => e.RefControlId)).HasName("SST_FIELDS_IDX03");
					entity.Property((SstFormControls e) => e.Disabled).HasDefaultValueSql("'1'");
					entity.Property((SstFormControls e) => e.Required).HasDefaultValueSql("'0'");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstContainers, SstFormControls>(entity.HasOne((SstFormControls d) => d.Container).WithMany((SstContainers p) => p.SstFormControls).HasForeignKey((SstFormControls d) => d.ContainerId), "SST_FIELDS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstFormControls, SstFormControls>(entity.HasOne((SstFormControls d) => d.RefControl).WithMany((SstFormControls p) => p.InverseRefControl).HasForeignKey((SstFormControls d) => d.RefControlId), "SST_FIELDS_FK02");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstFormElements> entity)
				{
					entity.HasIndex((Expression<Func<SstFormElements, object>>)((SstFormElements e) => e.FormId)).HasName("SST_FORM_ELEMENTS_FK01");
					entity.HasIndex((Expression<Func<SstFormElements, object>>)((SstFormElements e) => e.Id)).HasName("PRIMARY_55").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstFormElements e) => e.Id), "SST_FORM_ELEMENTS_SEQ", (string)null);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstForms, SstFormElements>(entity.HasOne((SstFormElements d) => d.Form).WithMany((SstForms p) => p.SstFormElements).HasForeignKey((SstFormElements d) => d.FormId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_FORM_ELEMENTS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstFormGrid> entity)
				{
					entity.HasIndex((Expression<Func<SstFormGrid, object>>)((SstFormGrid e) => e.FormId)).HasName("SST_FORM_GRID_FK01");
					entity.HasIndex((Expression<Func<SstFormGrid, object>>)((SstFormGrid e) => e.Id)).HasName("PRIMARY_56").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstFormGrid e) => e.Id), "SST_FORM_GRID_SEQ", (string)null);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstForms, SstFormGrid>(entity.HasOne((SstFormGrid d) => d.Form).WithMany((SstForms p) => p.SstFormGrid).HasForeignKey((SstFormGrid d) => d.FormId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_FORM_GRID_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstFormSystems> entity)
				{
					entity.HasIndex((Expression<Func<SstFormSystems, object>>)((SstFormSystems e) => e.FormId)).HasName("SST_FORM_SYSTEMS_FK02");
					entity.HasIndex((Expression<Func<SstFormSystems, object>>)((SstFormSystems e) => e.Id)).HasName("PRIMARY_57").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstFormSystems e) => e.Id), "SST_FORM_SYSTEMS_SEQ", (string)null);
					//entity.HasIndex((Expression<Func<SstFormSystems, object>>)((SstFormSystems e) => e.SystemId)).HasName("SST_FORM_SYSTEMS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstForms, SstFormSystems>(entity.HasOne((SstFormSystems d) => d.Form).WithMany((SstForms p) => p.SstFormSystems).HasForeignKey((SstFormSystems d) => d.FormId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_FORM_SYSTEMS_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstFormSystems>(entity.HasOne((SstFormSystems d) => d.System).WithMany((SstSystems p) => p.SstFormSystems).HasForeignKey((SstFormSystems d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_FORM_SYSTEMS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstForms> entity)
				{
					entity.HasIndex((Expression<Func<SstForms, object>>)((SstForms e) => e.Id)).HasName("PRIMARY_58").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstForms e) => e.Id), "SST_FORMS_SEQ", (string)null);
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstIndustrySectors> entity)
				{
					entity.HasIndex((Expression<Func<SstIndustrySectors, object>>)((SstIndustrySectors e) => e.Id)).HasName("PRIMARY_59").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstIndustrySectors e) => e.Id), "SST_INDUSTRY_SECTORS_SEQ", (string)null);
					//entity.HasIndex((Expression<Func<SstIndustrySectors, object>>)((SstIndustrySectors e) => e.SectorId)).HasName("SST_INDUSTRY_SECTORS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstIndustrySectors, SstIndustrySectors>(entity.HasOne((SstIndustrySectors d) => d.Sector).WithMany((SstIndustrySectors p) => p.InverseSector).HasForeignKey((SstIndustrySectors d) => d.SectorId), "SST_INDUSTRY_SECTORS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstIntegrations> entity)
				{
					entity.HasIndex((Expression<Func<SstIntegrations, object>>)((SstIntegrations e) => e.Id)).HasName("PRIMARY_60").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstIntegrations e) => e.Id), "SST_INTEGRATIONS_SEQ", (string)null);
					//entity.HasIndex((Expression<Func<SstIntegrations, object>>)((SstIntegrations e) => e.SystemId)).HasName("SST_INTEGRATIONS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstIntegrations>(entity.HasOne((SstIntegrations d) => d.System).WithMany((SstSystems p) => p.SstIntegrations).HasForeignKey((SstIntegrations d) => d.SystemId), "SST_INTEGRATIONS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstIntegrationsApiMapping> entity)
				{
					entity.HasIndex((Expression<Func<SstIntegrationsApiMapping, object>>)((SstIntegrationsApiMapping e) => e.Id)).HasName("PRIMARY_61").IsUnique();
					entity.Property((SstIntegrationsApiMapping e) => e.Id).ValueGeneratedNever();
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstIntegrationsApiObject> entity)
				{
					entity.HasIndex((Expression<Func<SstIntegrationsApiObject, object>>)((SstIntegrationsApiObject e) => e.Id)).HasName("PRIMARY_62").IsUnique();
					entity.Property((SstIntegrationsApiObject e) => e.Id).ValueGeneratedNever();
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstIntegrationsDbMapping> entity)
				{
					entity.HasIndex((Expression<Func<SstIntegrationsDbMapping, object>>)((SstIntegrationsDbMapping e) => e.Id)).HasName("PRIMARY_63").IsUnique();
					entity.Property((SstIntegrationsDbMapping e) => e.Id).ValueGeneratedNever();
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstIntegrationsSettings> entity)
				{
					entity.HasIndex((Expression<Func<SstIntegrationsSettings, object>>)((SstIntegrationsSettings e) => e.Id)).HasName("PRIMARY_65").IsUnique();
					entity.HasIndex((Expression<Func<SstIntegrationsSettings, object>>)((SstIntegrationsSettings e) => e.IntegrationId)).HasName("SST_INTEGRATIONS_SETTINGS_FK01");
					entity.HasIndex((Expression<Func<SstIntegrationsSettings, object>>)((SstIntegrationsSettings e) => e.ProductId)).HasName("SST_INTEGRATIONS_SETTINGS_FK02");
					entity.Property((SstIntegrationsSettings e) => e.Id).ValueGeneratedNever();
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstIntegrations, SstIntegrationsSettings>(entity.HasOne((SstIntegrationsSettings d) => d.Integration).WithMany((SstIntegrations p) => p.SstIntegrationsSettings).HasForeignKey((SstIntegrationsSettings d) => d.IntegrationId), "SST_INTEGRATIONS_SETTINGS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SpdProducts, SstIntegrationsSettings>(entity.HasOne((SstIntegrationsSettings d) => d.Product).WithMany((SpdProducts p) => p.SstIntegrationsSettings).HasForeignKey((SstIntegrationsSettings d) => d.ProductId), "SST_INTEGRATIONS_SETTINGS_FK02");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstLogs> entity)
				{
					entity.HasIndex((Expression<Func<SstLogs, object>>)((SstLogs e) => e.Id)).HasName("PRIMARY_66").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstLogs e) => e.Id), "SST_LOGS_SEQ", (string)null);
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstLogsDetails> entity)
				{
					entity.HasIndex((Expression<Func<SstLogsDetails, object>>)((SstLogsDetails e) => e.Id)).HasName("PRIMARY_67").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstLogsDetails e) => e.Id), "SST_LOGS_DETAILS_SEQ", (string)null);
					//entity.HasIndex((Expression<Func<SstLogsDetails, object>>)((SstLogsDetails e) => e.LogId)).HasName("SST_LOGS_DETAILS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstLogs, SstLogsDetails>(entity.HasOne((SstLogsDetails d) => d.Log).WithMany((SstLogs p) => p.SstLogsDetails).HasForeignKey((SstLogsDetails d) => d.LogId), "SST_LOGS_DETAILS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstMailer> entity)
				{
					entity.HasIndex((Expression<Func<SstMailer, object>>)((SstMailer e) => e.Id)).HasName("PRIMARY_68").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstMailer e) => e.Id), "SST_MAILER_SEQ", (string)null);
					//entity.HasIndex((Expression<Func<SstMailer, object>>)((SstMailer e) => e.SystemId)).HasName("SST_MAILER_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstMailer>(entity.HasOne((SstMailer d) => d.System).WithMany((SstSystems p) => p.SstMailer).HasForeignKey((SstMailer d) => d.SystemId), "SST_MAILER_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstMappings> entity)
				{
					entity.HasIndex((Expression<Func<SstMappings, object>>)((SstMappings e) => e.Id)).HasName("PRIMARY_69").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstMappings e) => e.Id), "SST_MAPPINGS_SEQ", (string)null);
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstMatrixParamsMapping> entity)
				{
					entity.HasIndex((Expression<Func<SstMatrixParamsMapping, object>>)((SstMatrixParamsMapping e) => e.Id)).HasName("SYS_C0025794").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstMatrixParamsMapping e) => e.Id), "SST_MATRIX_PARAMS_MAPPING_SEQ", (string)null);
					entity.Property((SstMatrixParamsMapping e) => e.ModificationDate).HasDefaultValueSql("NULL");
					entity.Property((SstMatrixParamsMapping e) => e.ModificationUser).HasDefaultValueSql("NULL");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstMatrixParamsMapping>(entity.HasOne((SstMatrixParamsMapping d) => d.System).WithMany((SstSystems p) => p.SstMatrixParamsMapping).HasForeignKey((SstMatrixParamsMapping d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C0040239");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstModules> entity)
				{
					entity.HasKey((SstModules e) => e.Code).HasName("PRIMARY_70");
					entity.HasIndex((Expression<Func<SstModules, object>>)((SstModules e) => e.Code)).HasName("PRIMARY_70").IsUnique();
					entity.HasIndex((Expression<Func<SstModules, object>>)((SstModules e) => new { e.SystemId, e.Code })).HasName("SST_MODULES_IDX01");
					entity.Property((SstModules e) => e.Code).ValueGeneratedNever();
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstModules>(entity.HasOne((SstModules d) => d.System).WithMany((SstSystems p) => p.SstModules).HasForeignKey((SstModules d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_MODULES_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstNotifications> entity)
				{
					entity.HasIndex((Expression<Func<SstNotifications, object>>)((SstNotifications e) => e.Id)).HasName("PRIMARY_71").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstNotifications e) => e.Id), "SST_NOTIFICATIONS_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstNotifications, object>>)((SstNotifications e) => e.SystemId)).HasName("SST_NOTIFICATIONS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstNotifications>(entity.HasOne((SstNotifications d) => d.System).WithMany((SstSystems p) => p.SstNotifications).HasForeignKey((SstNotifications d) => d.SystemId), "SST_NOTIFICATIONS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstNotificationsAttachments> entity)
				{
					entity.HasIndex((Expression<Func<SstNotificationsAttachments, object>>)((SstNotificationsAttachments e) => e.Id)).HasName("PRIMARY_72").IsUnique();
					entity.Property((SstNotificationsAttachments e) => e.Id).ValueGeneratedNever();
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstNotificationsContacts> entity)
				{
					entity.HasIndex((Expression<Func<SstNotificationsContacts, object>>)((SstNotificationsContacts e) => e.Id)).HasName("PRIMARY_73").IsUnique();
					entity.Property((SstNotificationsContacts e) => e.Id).ValueGeneratedNever();
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstNotificationsLogs> entity)
				{
					entity.HasIndex((Expression<Func<SstNotificationsLogs, object>>)((SstNotificationsLogs e) => e.Id)).HasName("PRIMARY_74").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstNotificationsLogs e) => e.Id), "SST_NOTIFICATIONS_LOGS_SEQ", (string)null);
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstNotificationsParameters> entity)
				{
					entity.HasIndex((Expression<Func<SstNotificationsParameters, object>>)((SstNotificationsParameters e) => e.Id)).HasName("PRIMARY_75").IsUnique();
					entity.Property((SstNotificationsParameters e) => e.Id).ValueGeneratedNever();
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstNotificationsTemplates> entity)
				{
					entity.HasIndex((Expression<Func<SstNotificationsTemplates, object>>)((SstNotificationsTemplates e) => e.Id)).HasName("PRIMARY_76").IsUnique();
					entity.Property((SstNotificationsTemplates e) => e.Id).ValueGeneratedNever();
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstOffices> entity)
				{
					entity.HasIndex((Expression<Func<SstOffices, object>>)((SstOffices e) => e.Id)).HasName("SYS_C0025251").IsUnique();
					entity.HasIndex((Expression<Func<SstOffices, object>>)((SstOffices e) => e.SystemId)).HasName("SST_OFFICES_IDX01");
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstOffices e) => e.Id), "SST_OFFICES_SEQ", (string)null);
					entity.Property((SstOffices e) => e.ModificationDate).HasDefaultValueSql("NULL");
					entity.Property((SstOffices e) => e.ModificationUser).HasDefaultValueSql("NULL");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstOffices>(entity.HasOne((SstOffices d) => d.System).WithMany((SstSystems p) => p.SstOffices).HasForeignKey((SstOffices d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_OFFICES_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstPackagedPolicy> entity)
				{
					entity.HasIndex((Expression<Func<SstPackagedPolicy, object>>)((SstPackagedPolicy e) => e.Id)).HasName("SYS_C0025494").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstPackagedPolicy e) => e.Id), "SST_PACKAGED_POLICY_SEQ", (string)null);
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstPackagedPolicyDetails> entity)
				{
					entity.HasIndex((Expression<Func<SstPackagedPolicyDetails, object>>)((SstPackagedPolicyDetails e) => e.Id)).HasName("SYS_C0025963").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstPackagedPolicyDetails e) => e.Id), "SST_PCK_PLC_DETAILS_SEQ", (string)null);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstPackagedPolicyDetails>(entity.HasOne((SstPackagedPolicyDetails d) => d.Class).WithMany((SstClasses p) => p.SstPackagedPolicyDetails).HasForeignKey((SstPackagedPolicyDetails d) => d.ClassId), "SYS_C0027762");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPackagedPolicy, SstPackagedPolicyDetails>(entity.HasOne((SstPackagedPolicyDetails d) => d.Packaged).WithMany((SstPackagedPolicy p) => p.SstPackagedPolicyDetails).HasForeignKey((SstPackagedPolicyDetails d) => d.PackagedId), "SYS_C0027761");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstPackagedPolicyDetails>(entity.HasOne((SstPackagedPolicyDetails d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstPackagedPolicyDetails).HasForeignKey((SstPackagedPolicyDetails d) => d.PolicyType), "SYS_C0027763");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstPackegedCovers> entity)
				{
					entity.HasIndex((Expression<Func<SstPackegedCovers, object>>)((SstPackegedCovers e) => e.ClassId)).HasName("SST_PACKEGED_COVERS_IND2");
					entity.HasIndex((Expression<Func<SstPackegedCovers, object>>)((SstPackegedCovers e) => e.CoverType)).HasName("SST_PACKEGED_COVERS_IND4");
					entity.HasIndex((Expression<Func<SstPackegedCovers, object>>)((SstPackegedCovers e) => e.Id)).HasName("SYS_C0025703").IsUnique();
					entity.HasIndex((Expression<Func<SstPackegedCovers, object>>)((SstPackegedCovers e) => e.MatrixId)).HasName("SST_PACKEGED_COVERS_IND5");
					entity.HasIndex((Expression<Func<SstPackegedCovers, object>>)((SstPackegedCovers e) => e.PackagedId)).HasName("SST_PACKEGED_COVERS_IND1");
					entity.HasIndex((Expression<Func<SstPackegedCovers, object>>)((SstPackegedCovers e) => e.PolicyType)).HasName("SST_PACKEGED_COVERS_IND3");
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstPackegedCovers e) => e.Id), "SST_PACKEGED_COVERS_SEQ", (string)null);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstPackegedCovers>(entity.HasOne((SstPackegedCovers d) => d.Class).WithMany((SstClasses p) => p.SstPackegedCovers).HasForeignKey((SstPackegedCovers d) => d.ClassId), "SYS_C0040112");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstCoverTypes, SstPackegedCovers>(entity.HasOne((SstPackegedCovers d) => d.CoverTypeNavigation).WithMany((SstCoverTypes p) => p.SstPackegedCovers).HasForeignKey((SstPackegedCovers d) => d.CoverType), "SYS_C0040136");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstRatingMatrix, SstPackegedCovers>(entity.HasOne((SstPackegedCovers d) => d.Matrix).WithMany((SstRatingMatrix p) => p.SstPackegedCovers).HasForeignKey((SstPackegedCovers d) => d.MatrixId), "SYS_C0040205");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPackagedPolicy, SstPackegedCovers>(entity.HasOne((SstPackegedCovers d) => d.Packaged).WithMany((SstPackagedPolicy p) => p.SstPackegedCovers).HasForeignKey((SstPackegedCovers d) => d.PackagedId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C0040165");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstPackegedCovers>(entity.HasOne((SstPackegedCovers d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstPackegedCovers).HasForeignKey((SstPackegedCovers d) => d.PolicyType), "SYS_C0040188");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstPackegedCoversMatrix> entity)
				{
					entity.HasIndex((Expression<Func<SstPackegedCoversMatrix, object>>)((SstPackegedCoversMatrix e) => e.Id)).HasName("SYS_C0026013").IsUnique();
					entity.HasIndex((Expression<Func<SstPackegedCoversMatrix, object>>)((SstPackegedCoversMatrix e) => e.PackagedCoverId)).HasName("SST_PACKEGED_COVER_MATRIX_IND1");
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstPackegedCoversMatrix e) => e.Id), "SST_PACKEGED_COVERS_MATRIX_SEQ", (string)null);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPackegedCovers, SstPackegedCoversMatrix>(entity.HasOne((SstPackegedCoversMatrix d) => d.PackagedCover).WithMany((SstPackegedCovers p) => p.SstPackegedCoversMatrix).HasForeignKey((SstPackegedCoversMatrix d) => d.PackagedCoverId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C0040167");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstPages> entity)
				{
					entity.HasIndex((Expression<Func<SstPages, object>>)((SstPages e) => e.Id)).HasName("PRIMARY_77").IsUnique();
					entity.HasIndex((Expression<Func<SstPages, object>>)((SstPages e) => e.ModuleCode)).HasName("SST_PAGES_FK01");
					entity.HasIndex((Expression<Func<SstPages, object>>)((SstPages e) => new { e.SystemId, e.ModuleCode })).HasName("SST_PAGES_IDX01");
					entity.Property((SstPages e) => e.Id).ValueGeneratedNever();
					entity.Property((SstPages e) => e.Order).HasDefaultValueSql("'1' ");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstModules, SstPages>(entity.HasOne((SstPages d) => d.ModuleCodeNavigation).WithMany((SstModules p) => p.SstPages).HasForeignKey((SstPages d) => d.ModuleCode), "SST_PAGES_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstPages>(entity.HasOne((SstPages d) => d.System).WithMany((SstSystems p) => p.SstPages).HasForeignKey((SstPages d) => d.SystemId), "SST_PAGES_FK02");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstPagesControls> entity)
				{
					entity.HasIndex((Expression<Func<SstPagesControls, object>>)((SstPagesControls e) => e.ControlId)).HasName("SST_PAGES_CONTROLS_FK02");
					entity.HasIndex((Expression<Func<SstPagesControls, object>>)((SstPagesControls e) => e.Id)).HasName("PRIMARY_78").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstPagesControls e) => e.Id), "SST_PAGES_CONTROLS_SEQ", (string)null);
					//entity.HasIndex((Expression<Func<SstPagesControls, object>>)((SstPagesControls e) => e.PageId)).HasName("SST_PAGES_CONTROLS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPagesControls, SstPagesControls>(entity.HasOne((SstPagesControls d) => d.Control).WithMany((SstPagesControls p) => p.InverseControl).HasForeignKey((SstPagesControls d) => d.ControlId), "SST_PAGES_CONTROLS_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPages, SstPagesControls>(entity.HasOne((SstPagesControls d) => d.Page).WithMany((SstPages p) => p.SstPagesControls).HasForeignKey((SstPagesControls d) => d.PageId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_PAGES_CONTROLS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstPagesControlsParams> entity)
				{
					entity.HasIndex((Expression<Func<SstPagesControlsParams, object>>)((SstPagesControlsParams e) => e.ControlId)).HasName("SST_PAGES_CONTROLS_PARAMS_FK01");
					entity.HasIndex((Expression<Func<SstPagesControlsParams, object>>)((SstPagesControlsParams e) => e.Id)).HasName("PRIMARY_79").IsUnique();
					entity.Property((SstPagesControlsParams e) => e.Id).ValueGeneratedNever();
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPagesControls, SstPagesControlsParams>(entity.HasOne((SstPagesControlsParams d) => d.Control).WithMany((SstPagesControls p) => p.SstPagesControlsParams).HasForeignKey((SstPagesControlsParams d) => d.ControlId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_PAGES_CONTROLS_PARAMS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstPaymentCycles> entity)
				{
					entity.HasIndex((Expression<Func<SstPaymentCycles, object>>)((SstPaymentCycles e) => e.Id)).HasName("PRIMARY_80").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstPaymentCycles e) => e.Id), "SST_PAYMENT_CYCLES_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstPaymentCycles, object>>)((SstPaymentCycles e) => e.SystemId)).HasName("SST_PAYMENT_CYCLES_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstPaymentCycles>(entity.HasOne((SstPaymentCycles d) => d.System).WithMany((SstSystems p) => p.SstPaymentCycles).HasForeignKey((SstPaymentCycles d) => d.SystemId), "SST_PAYMENT_CYCLES_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstPaymentDetails> entity)
				{
					entity.HasIndex((Expression<Func<SstPaymentDetails, object>>)((SstPaymentDetails e) => e.CycleId)).HasName("SST_PAYMENT_DETAILS_IDX02");
					entity.HasIndex((Expression<Func<SstPaymentDetails, object>>)((SstPaymentDetails e) => e.Id)).HasName("PRIMARY_81").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstPaymentDetails e) => e.Id), "SST_PAYMENT_DETAILS_SEQ", (string)null);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPaymentCycles, SstPaymentDetails>(entity.HasOne((SstPaymentDetails d) => d.Cycle).WithMany((SstPaymentCycles p) => p.SstPaymentDetails).HasForeignKey((SstPaymentDetails d) => d.CycleId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_PAYMENT_DETAILS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstPolicyBusiness> entity)
				{
					entity.HasIndex((Expression<Func<SstPolicyBusiness, object>>)((SstPolicyBusiness e) => e.ClassId)).HasName("SST_POLICY_BUSINESS_IDX01");
					entity.HasIndex((Expression<Func<SstPolicyBusiness, object>>)((SstPolicyBusiness e) => e.Id)).HasName("SYS_C0026203").IsUnique();
					entity.HasIndex((Expression<Func<SstPolicyBusiness, object>>)((SstPolicyBusiness e) => e.PolicyType)).HasName("SST_POLICY_BUSINESS_IDX02");
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstPolicyBusiness e) => e.Id), "SST_POLICY_BUSINESS_SEQ", (string)null);
					entity.Property((SstPolicyBusiness e) => e.CompanyId).HasDefaultValueSql("1\n");
					entity.Property((SstPolicyBusiness e) => e.ModificationDate).HasDefaultValueSql("NULL");
					entity.Property((SstPolicyBusiness e) => e.ModificationUser).HasDefaultValueSql("NULL");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstPolicyBusiness>(entity.HasOne((SstPolicyBusiness d) => d.Class).WithMany((SstClasses p) => p.SstPolicyBusiness).HasForeignKey((SstPolicyBusiness d) => d.ClassId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_POLICY_BUSINESS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstPolicyBusiness>(entity.HasOne((SstPolicyBusiness d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstPolicyBusiness).HasForeignKey((SstPolicyBusiness d) => d.PolicyType)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_POLICY_BUSINESS_FK02");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstPolicyDiscounts> entity)
				{
					entity.HasIndex((Expression<Func<SstPolicyDiscounts, object>>)((SstPolicyDiscounts e) => e.ClassId)).HasName("SST_POLICY_DISCOUNTS_FK02");
					entity.HasIndex((Expression<Func<SstPolicyDiscounts, object>>)((SstPolicyDiscounts e) => e.DiscountId)).HasName("SST_POLICY_DISCOUNTS_FK01");
					entity.HasIndex((Expression<Func<SstPolicyDiscounts, object>>)((SstPolicyDiscounts e) => e.Id)).HasName("PRIMARY_82").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstPolicyDiscounts e) => e.Id), "SST_POLICY_DISCOUNTS_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstPolicyDiscounts, object>>)((SstPolicyDiscounts e) => e.PolicyType)).HasName("SST_POLICY_DISCOUNTS_FK03");
					entity.Property((SstPolicyDiscounts e) => e.AutoAdd).HasDefaultValueSql("'0' ");
					entity.Property((SstPolicyDiscounts e) => e.SeparateVoucher).HasDefaultValueSql("'0' ");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstPolicyDiscounts>(entity.HasOne((SstPolicyDiscounts d) => d.Class).WithMany((SstClasses p) => p.SstPolicyDiscounts).HasForeignKey((SstPolicyDiscounts d) => d.ClassId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_POLICY_DISCOUNTS_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstDiscounts, SstPolicyDiscounts>(entity.HasOne((SstPolicyDiscounts d) => d.Discount).WithMany((SstDiscounts p) => p.SstPolicyDiscounts).HasForeignKey((SstPolicyDiscounts d) => d.DiscountId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_POLICY_DISCOUNTS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstPolicyDiscounts>(entity.HasOne((SstPolicyDiscounts d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstPolicyDiscounts).HasForeignKey((SstPolicyDiscounts d) => d.PolicyType), "SST_POLICY_DISCOUNTS_FK03");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstPolicyTypes> entity)
				{
					entity.HasIndex((Expression<Func<SstPolicyTypes, object>>)((SstPolicyTypes e) => e.ClassId)).HasName("SST_POLICY_TYPES_IDX01");
					entity.HasIndex((Expression<Func<SstPolicyTypes, object>>)((SstPolicyTypes e) => e.Id)).HasName("PRIMARY_83").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstPolicyTypes e) => e.Id), "SST_POLICY_TYPES_SEQ", (string)null);
					entity.Property((SstPolicyTypes e) => e.AgeDecrease).HasDefaultValueSql("'0'");
					entity.Property((SstPolicyTypes e) => e.EarnedPercent).HasDefaultValueSql("'0.0000000000'");
					entity.Property((SstPolicyTypes e) => e.LongTerm).HasDefaultValueSql("'0'");
					entity.Property((SstPolicyTypes e) => e.TreatyType).HasDefaultValueSql("'1'");
					entity.Property((SstPolicyTypes e) => e.UnearnedBasis).HasDefaultValueSql("'1'");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstPolicyTypes>(entity.HasOne((SstPolicyTypes d) => d.Class).WithMany((SstClasses p) => p.SstPolicyTypes).HasForeignKey((SstPolicyTypes d) => d.ClassId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_POLICY_TYPES_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstPreferences> entity)
				{
					entity.HasIndex((Expression<Func<SstPreferences, object>>)((SstPreferences e) => e.CompanyId)).HasName("SST_PREFERENCES_IDX01");
					entity.HasIndex((Expression<Func<SstPreferences, object>>)((SstPreferences e) => e.Id)).HasName("SYS_C0025813").IsUnique();
					entity.HasIndex((Expression<Func<SstPreferences, object>>)((SstPreferences e) => new { e.Code, e.SystemId })).HasName("SST_PREF_UNIQ_001").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstPreferences e) => e.Id), "SST_PREFERENCES_SEQ", (string)null);
					entity.Property((SstPreferences e) => e.ModificationDate).HasDefaultValueSql("NULL");
					entity.Property((SstPreferences e) => e.ModificationUser).HasDefaultValueSql("NULL");
					entity.Property((SstPreferences e) => e.SystemId).HasDefaultValueSql("321 ");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstProcessActions> entity)
				{
					entity.HasIndex((Expression<Func<SstProcessActions, object>>)((SstProcessActions e) => e.Id)).HasName("PRIMARY_84").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstProcessActions e) => e.Id), "SST_PROCESS_ACTIONS_SEQ", (string)null);
					entity.Property((SstProcessActions e) => e.TargetType).HasDefaultValueSql("'0' ");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstProcessConditions> entity)
				{
					entity.HasIndex((Expression<Func<SstProcessConditions, object>>)((SstProcessConditions e) => e.Id)).HasName("PRIMARY_85").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstProcessConditions e) => e.Id), "SST_PROCESS_CONDITIONS_SEQ", (string)null);
					entity.Property((SstProcessConditions e) => e.ConditionType).HasDefaultValueSql("'1' ");
					entity.Property((SstProcessConditions e) => e.Order).HasDefaultValueSql("'1' ");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstProcessParentSteps> entity)
				{
					entity.HasIndex((Expression<Func<SstProcessParentSteps, object>>)((SstProcessParentSteps e) => e.Id)).HasName("PRIMARY_86").IsUnique();
					entity.HasIndex((Expression<Func<SstProcessParentSteps, object>>)((SstProcessParentSteps e) => e.ProcessId)).HasName("SST_PROCESS_PARENT_FK");
					entity.HasIndex((Expression<Func<SstProcessParentSteps, object>>)((SstProcessParentSteps e) => e.ProcessStepId)).HasName("SST_PROCESS_STEP_FK");
					entity.Property((SstProcessParentSteps e) => e.Id).ValueGeneratedNever();
					entity.Property((SstProcessParentSteps e) => e.EdgeType).HasDefaultValueSql("'1' ");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstProcessSteps, SstProcessParentSteps>(entity.HasOne((SstProcessParentSteps d) => d.ProcessStep).WithMany((SstProcessSteps p) => p.SstProcessParentSteps).HasForeignKey((SstProcessParentSteps d) => d.ProcessStepId), "SST_PROCESS_STEP_FK");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstProcessRoles> entity)
				{
					entity.HasIndex((Expression<Func<SstProcessRoles, object>>)((SstProcessRoles e) => e.Id)).HasName("PRIMARY_87").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstProcessRoles e) => e.Id), "SST_PROCESS_ROLES_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstProcessRoles, object>>)((SstProcessRoles e) => e.ProcessStepId)).HasName("SST_PROCESS_ROLES_FK");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstProcessRules> entity)
				{
					entity.HasIndex((Expression<Func<SstProcessRules, object>>)((SstProcessRules e) => e.Id)).HasName("PRIMARY_88").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstProcessRules e) => e.Id), "SST_PROCESS_RULES_SEQ", (string)null);
					entity.Property((SstProcessRules e) => e.RuleType).HasDefaultValueSql("'1'");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstProcessSteps> entity)
				{
					entity.HasIndex((Expression<Func<SstProcessSteps, object>>)((SstProcessSteps e) => e.Id)).HasName("PRIMARY_89").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstProcessSteps e) => e.Id), "SST_PROCESS_STEPS_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstProcessSteps, object>>)((SstProcessSteps e) => e.ProcessId)).HasName("SST_PROCESS_FK");
					entity.HasIndex((Expression<Func<SstProcessSteps, object>>)((SstProcessSteps e) => e.StepId)).HasName("SST_PROCESS_STEPS_IDX01");
					entity.HasIndex((Expression<Func<SstProcessSteps, object>>)((SstProcessSteps e) => new { e.StepId, e.ProcessId })).HasName("SST_PROCESS_STEPS_UQ").IsUnique();
					entity.Property((SstProcessSteps e) => e.FontSize).HasDefaultValueSql("'11'");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstProcessStepsPages> entity)
				{
					entity.HasIndex((Expression<Func<SstProcessStepsPages, object>>)((SstProcessStepsPages e) => e.ControlKey)).HasName("SST_PROCESS_STEPS_PAGES_IDX02");
					entity.HasIndex((Expression<Func<SstProcessStepsPages, object>>)((SstProcessStepsPages e) => e.Id)).HasName("PRIMARY_90").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstProcessStepsPages e) => e.Id), "SST_PROCESS_STEPS_PAGES_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstProcessStepsPages, object>>)((SstProcessStepsPages e) => e.PageId)).HasName("SST_PROCESS_STEPS_PAGES_IDX01");
					entity.HasIndex((Expression<Func<SstProcessStepsPages, object>>)((SstProcessStepsPages e) => e.RuleId)).HasName("SST_PROCESS_STEPS_PAGES_IDX03");
					entity.HasIndex((Expression<Func<SstProcessStepsPages, object>>)((SstProcessStepsPages e) => e.StepId)).HasName("SST_PROCESS_STEPS_PAGES_IDX04");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPages, SstProcessStepsPages>(entity.HasOne((SstProcessStepsPages d) => d.Page).WithMany((SstPages p) => p.SstProcessStepsPages).HasForeignKey((SstProcessStepsPages d) => d.PageId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_PROCESS_STEPS_PAGES_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstRules, SstProcessStepsPages>(entity.HasOne((SstProcessStepsPages d) => d.Rule).WithMany((SstRules p) => p.SstProcessStepsPages).HasForeignKey((SstProcessStepsPages d) => d.RuleId), "SST_PROCESS_STEPS_PAGES_FK03");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstProcessSteps, SstProcessStepsPages>(entity.HasOne((SstProcessStepsPages d) => d.Step).WithMany((SstProcessSteps p) => p.SstProcessStepsPages).HasForeignKey((SstProcessStepsPages d) => d.StepId), "SST_PROCESS_STEPS_PAGES_FK04");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstProcessSystems> entity)
				{
					entity.HasIndex((Expression<Func<SstProcessSystems, object>>)((SstProcessSystems e) => e.Id)).HasName("PRIMARY_91").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstProcessSystems e) => e.Id), "SST_PROCESS_SYSTEMS_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstProcessSystems, object>>)((SstProcessSystems e) => e.ModuleCode)).HasName("SST_PROCESS_SYSTEMS_FK03");
					entity.HasIndex((Expression<Func<SstProcessSystems, object>>)((SstProcessSystems e) => e.ProcessId)).HasName("SST_PROCESSES_SYSTEMS_FK01");
					entity.HasIndex((Expression<Func<SstProcessSystems, object>>)((SstProcessSystems e) => e.SystemId)).HasName("SST_PROCESSES_SYSTEMS_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstModules, SstProcessSystems>(entity.HasOne((SstProcessSystems d) => d.ModuleCodeNavigation).WithMany((SstModules p) => p.SstProcessSystems).HasForeignKey((SstProcessSystems d) => d.ModuleCode), "SST_PROCESS_SYSTEMS_FK03");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstProcessSystems>(entity.HasOne((SstProcessSystems d) => d.System).WithMany((SstSystems p) => p.SstProcessSystems).HasForeignKey((SstProcessSystems d) => d.SystemId), "SST_PROCESSES_SYSTEMS_FK02");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstProcesses> entity)
				{
					entity.HasIndex((Expression<Func<SstProcesses, object>>)((SstProcesses e) => e.Id)).HasName("PRIMARY_92").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstProcesses e) => e.Id), "SST_PROCESSES_SEQ", (string)null);
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstProducts> entity)
				{
					entity.HasIndex((Expression<Func<SstProducts, object>>)((SstProducts e) => e.CompanyId)).HasName("SST_PRODUCTS_IDX01");
					entity.HasIndex((Expression<Func<SstProducts, object>>)((SstProducts e) => e.Id)).HasName("PRIMARY_93").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstProducts e) => e.Id), "SST_PRODUCTS_SEQ", (string)null);
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstProductsDetails> entity)
				{
					entity.HasIndex((Expression<Func<SstProductsDetails, object>>)((SstProductsDetails e) => e.ClassId)).HasName("SST_PRODUCTS_DETAILS_IDX02");
					entity.HasIndex((Expression<Func<SstProductsDetails, object>>)((SstProductsDetails e) => e.Id)).HasName("PRIMARY_94").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstProductsDetails e) => e.Id), "SST_PRODUCTS_DETAILS_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstProductsDetails, object>>)((SstProductsDetails e) => e.PolicyType)).HasName("SST_PRODUCTS_DETAILS_IDX03");
					entity.HasIndex((Expression<Func<SstProductsDetails, object>>)((SstProductsDetails e) => e.ProductId)).HasName("SST_PRODUCTS_DETAILS_IDX01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstProductsDetails>(entity.HasOne((SstProductsDetails d) => d.Class).WithMany((SstClasses p) => p.SstProductsDetails).HasForeignKey((SstProductsDetails d) => d.ClassId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_PRODUCTS_DETAILS_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstProductsDetails>(entity.HasOne((SstProductsDetails d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstProductsDetails).HasForeignKey((SstProductsDetails d) => d.PolicyType)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_PRODUCTS_DETAILS_FK03");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstProducts, SstProductsDetails>(entity.HasOne((SstProductsDetails d) => d.Product).WithMany((SstProducts p) => p.SstProductsDetails).HasForeignKey((SstProductsDetails d) => d.ProductId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_PRODUCTS_DETAILS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstQuestControls> entity)
				{
					entity.HasIndex((Expression<Func<SstQuestControls, object>>)((SstQuestControls e) => e.Id)).HasName("PRIMARY_95").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstQuestControls e) => e.Id), "SST_QUEST_CONTROLS_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstQuestControls, object>>)((SstQuestControls e) => e.QuestionnaireId)).HasName("SST_QUEST_CONTROLS_FK01");
					entity.HasIndex((Expression<Func<SstQuestControls, object>>)((SstQuestControls e) => e.RefControlId)).HasName("SST_QUEST_CONTROLS_FK02");
					entity.Property((SstQuestControls e) => e.Disabled).HasDefaultValueSql("'1'");
					entity.Property((SstQuestControls e) => e.Required).HasDefaultValueSql("'0'");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstQuestionnaires, SstQuestControls>(entity.HasOne((SstQuestControls d) => d.Questionnaire).WithMany((SstQuestionnaires p) => p.SstQuestControls).HasForeignKey((SstQuestControls d) => d.QuestionnaireId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_QUEST_CONTROLS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstQuestControls, SstQuestControls>(entity.HasOne((SstQuestControls d) => d.RefControl).WithMany((SstQuestControls p) => p.InverseRefControl).HasForeignKey((SstQuestControls d) => d.RefControlId), "SST_QUEST_CONTROLS_FK02");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstQuestDetails> entity)
				{
					entity.HasIndex((Expression<Func<SstQuestDetails, object>>)((SstQuestDetails e) => e.Id)).HasName("SYS_C0027178").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstQuestDetails e) => e.Id), "SST_QUEST_DETAILS_SEQ", (string)null);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstQuestDetails>(entity.HasOne((SstQuestDetails d) => d.PolicyType).WithMany((SstPolicyTypes p) => p.SstQuestDetails).HasForeignKey((SstQuestDetails d) => d.PolicyTypeId), "SST_QUEST_DETAILS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstCoreQuestionnaires, SstQuestDetails>(entity.HasOne((SstQuestDetails d) => d.Questionnaire).WithMany((SstCoreQuestionnaires p) => p.SstQuestDetails).HasForeignKey((SstQuestDetails d) => d.QuestionnaireId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C0040480");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstQuestSystems> entity)
				{
					entity.HasIndex((Expression<Func<SstQuestSystems, object>>)((SstQuestSystems e) => e.Id)).HasName("PRIMARY_96").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstQuestSystems e) => e.Id), "SST_QUEST_SYSTEMS_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstQuestSystems, object>>)((SstQuestSystems e) => e.QuiestionnaireId)).HasName("SST_QUEST_SYSTEMS_IDX02");
					entity.HasIndex((Expression<Func<SstQuestSystems, object>>)((SstQuestSystems e) => e.SystemId)).HasName("SST_QUEST_SYSTEMS_IDX03");
					entity.HasIndex((Expression<Func<SstQuestSystems, object>>)((SstQuestSystems e) => new { e.SystemId, e.QuiestionnaireId })).HasName("SST_QUEST_SYSTEMS_UN01").IsUnique();
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstQuestionnaires, SstQuestSystems>(entity.HasOne((SstQuestSystems d) => d.Quiestionnaire).WithMany((SstQuestionnaires p) => p.SstQuestSystems).HasForeignKey((SstQuestSystems d) => d.QuiestionnaireId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_QUEST_SYSTEMS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstQuestSystems>(entity.HasOne((SstQuestSystems d) => d.System).WithMany((SstSystems p) => p.SstQuestSystems).HasForeignKey((SstQuestSystems d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_QUEST_SYSTEMS_FK02");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstQuestionnaires> entity)
				{
					entity.HasIndex((Expression<Func<SstQuestionnaires, object>>)((SstQuestionnaires e) => e.Id)).HasName("PRIMARY_97").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstQuestionnaires e) => e.Id), "SST_QUESTIONNAIRES_SEQ", (string)null);
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstRatingMatrix> entity)
				{
					entity.HasIndex((Expression<Func<SstRatingMatrix, object>>)((SstRatingMatrix e) => e.Id)).HasName("SYS_C0026747").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstRatingMatrix e) => e.Id), "SST_RATING_MATRIX_SEQ", (string)null);
					entity.Property((SstRatingMatrix e) => e.ModificationDate).HasDefaultValueSql("NULL");
					entity.Property((SstRatingMatrix e) => e.ModificationUser).HasDefaultValueSql("NULL");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstRatingMatrix>(entity.HasOne((SstRatingMatrix d) => d.Class).WithMany((SstClasses p) => p.SstRatingMatrix).HasForeignKey((SstRatingMatrix d) => d.ClassId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C0040116");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstCoverTypes, SstRatingMatrix>(entity.HasOne((SstRatingMatrix d) => d.CoverTypeNavigation).WithMany((SstCoverTypes p) => p.SstRatingMatrix).HasForeignKey((SstRatingMatrix d) => d.CoverType)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C0040137");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstRatingMatrix>(entity.HasOne((SstRatingMatrix d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstRatingMatrix).HasForeignKey((SstRatingMatrix d) => d.PolicyType)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C0040192");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstRatingMatrix>(entity.HasOne((SstRatingMatrix d) => d.System).WithMany((SstSystems p) => p.SstRatingMatrix).HasForeignKey((SstRatingMatrix d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C0040247");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstRatingMatrixParams> entity)
				{
					entity.HasIndex((Expression<Func<SstRatingMatrixParams, object>>)((SstRatingMatrixParams e) => e.Id)).HasName("SYS_C0027188").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstRatingMatrixParams e) => e.Id), "SST_RATING_MATRIX_PARAMS_SEQ", (string)null);
					entity.Property((SstRatingMatrixParams e) => e.ModificationDate).HasDefaultValueSql("NULL");
					entity.Property((SstRatingMatrixParams e) => e.ModificationUser).HasDefaultValueSql("NULL");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstMatrixParamsMapping, SstRatingMatrixParams>(entity.HasOne((SstRatingMatrixParams d) => d.ParamMap).WithMany((SstMatrixParamsMapping p) => p.SstRatingMatrixParams).HasForeignKey((SstRatingMatrixParams d) => d.ParamMapId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C0040160");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstRatingMatrix, SstRatingMatrixParams>(entity.HasOne((SstRatingMatrixParams d) => d.RatingMatrix).WithMany((SstRatingMatrix p) => p.SstRatingMatrixParams).HasForeignKey((SstRatingMatrixParams d) => d.RatingMatrixId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C0040206");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstRatingMatrixValues> entity)
				{
					entity.HasIndex((Expression<Func<SstRatingMatrixValues, object>>)((SstRatingMatrixValues e) => e.Id)).HasName("SYS_C0026997").IsUnique();
					///OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstRatingMatrixValues e) => e.Id), "SST_RATING_MATRIX_VALUES_SEQ", (string)null);
					entity.Property((SstRatingMatrixValues e) => e.ModificationDate).HasDefaultValueSql("NULL");
					entity.Property((SstRatingMatrixValues e) => e.ModificationUser).HasDefaultValueSql("NULL");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstRatingMatrix, SstRatingMatrixValues>(entity.HasOne((SstRatingMatrixValues d) => d.RatingMatrix).WithMany((SstRatingMatrix p) => p.SstRatingMatrixValues).HasForeignKey((SstRatingMatrixValues d) => d.RatingMatrixId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SYS_C0040207");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstReinsuranceAccounts> entity)
				{
					entity.HasIndex((Expression<Func<SstReinsuranceAccounts, object>>)((SstReinsuranceAccounts e) => e.ClassId)).HasName("SST_REINSURANCE_ACCOUNTS_IX1");
					entity.HasIndex((Expression<Func<SstReinsuranceAccounts, object>>)((SstReinsuranceAccounts e) => e.FeeType)).HasName("SST_REINSURANCE_ACCOUNTS_IX4");
					entity.HasIndex((Expression<Func<SstReinsuranceAccounts, object>>)((SstReinsuranceAccounts e) => e.Id)).HasName("SYS_C0040468").IsUnique();
					entity.HasIndex((Expression<Func<SstReinsuranceAccounts, object>>)((SstReinsuranceAccounts e) => e.PolicyType)).HasName("SST_REINSURANCE_ACCOUNTS_IX2");
					entity.HasIndex((Expression<Func<SstReinsuranceAccounts, object>>)((SstReinsuranceAccounts e) => e.SystemId)).HasName("SST_REINSURANCE_ACCOUNTS_IX3");
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstReinsuranceAccounts e) => e.Id), "SST_REINSURANCE_ACCOUNTS_SEQ", (string)null);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstReinsuranceAccounts>(entity.HasOne((SstReinsuranceAccounts d) => d.Class).WithMany((SstClasses p) => p.SstReinsuranceAccounts).HasForeignKey((SstReinsuranceAccounts d) => d.ClassId), "SST_REINSURANCE_ACCOUNTS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstFees, SstReinsuranceAccounts>(entity.HasOne((SstReinsuranceAccounts d) => d.FeeTypeNavigation).WithMany((SstFees p) => p.SstReinsuranceAccounts).HasForeignKey((SstReinsuranceAccounts d) => d.FeeType), "SST_REINSURANCE_ACCOUNTS_FK04");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstReinsuranceAccounts>(entity.HasOne((SstReinsuranceAccounts d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstReinsuranceAccounts).HasForeignKey((SstReinsuranceAccounts d) => d.PolicyType), "SST_REINSURANCE_ACCOUNTS_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstReinsuranceAccounts>(entity.HasOne((SstReinsuranceAccounts d) => d.System).WithMany((SstSystems p) => p.SstReinsuranceAccounts).HasForeignKey((SstReinsuranceAccounts d) => d.SystemId), "SST_REINSURANCE_ACCOUNTS_FK03");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstRelations> entity)
				{
					entity.HasIndex((Expression<Func<SstRelations, object>>)((SstRelations e) => e.ClassId)).HasName("SST_RELATIONS_IDX01");
					entity.HasIndex((Expression<Func<SstRelations, object>>)((SstRelations e) => e.CompanyId)).HasName("SST_RELATIONS_IDX05");
					entity.HasIndex((Expression<Func<SstRelations, object>>)((SstRelations e) => e.Currency)).HasName("SST_RELATIONS_IDX03");
					entity.HasIndex((Expression<Func<SstRelations, object>>)((SstRelations e) => e.EndorsementType)).HasName("SST_RELATIONS_FK04");
					entity.HasIndex((Expression<Func<SstRelations, object>>)((SstRelations e) => e.Id)).HasName("PRIMARY_98").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstRelations e) => e.Id), "SST_RELATIONS_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstRelations, object>>)((SstRelations e) => e.PaymentCycle)).HasName("SST_RELATIONS_IDX04");
					entity.HasIndex((Expression<Func<SstRelations, object>>)((SstRelations e) => e.PolicyType)).HasName("SST_RELATIONS_IDX02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstRelations>(entity.HasOne((SstRelations d) => d.Class).WithMany((SstClasses p) => p.SstRelations).HasForeignKey((SstRelations d) => d.ClassId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_RELATIONS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstEndorsements, SstRelations>(entity.HasOne((SstRelations d) => d.EndorsementTypeNavigation).WithMany((SstEndorsements p) => p.SstRelations).HasForeignKey((SstRelations d) => d.EndorsementType), "SST_RELATIONS_FK04");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPaymentCycles, SstRelations>(entity.HasOne((SstRelations d) => d.PaymentCycleNavigation).WithMany((SstPaymentCycles p) => p.SstRelations).HasForeignKey((SstRelations d) => d.PaymentCycle), "SST_RELATIONS_FK03");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstRelations>(entity.HasOne((SstRelations d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstRelations).HasForeignKey((SstRelations d) => d.PolicyType)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_RELATIONS_FK02");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstResources> entity)
				{
					entity.HasIndex((Expression<Func<SstResources, object>>)((SstResources e) => e.Id)).HasName("SST_RESOURCES_PK").IsUnique();
					entity.HasIndex((Expression<Func<SstResources, object>>)((SstResources e) => e.SystemId)).HasName("SST_RESOURCES_IDX01");
					entity.HasIndex((Expression<Func<SstResources, object>>)((SstResources e) => new { e.Object, e.Name, e.Language, e.SystemId, e.CompanyId })).HasName("SST_RESOURCES_UQ").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstResources e) => e.Id), "SST_RESOURCES_SEQ", (string)null);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstResources>(entity.HasOne((SstResources d) => d.System).WithMany((SstSystems p) => p.SstResources).HasForeignKey((SstResources d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_RESOURCES_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstRules> entity)
				{
					entity.HasIndex((Expression<Func<SstRules, object>>)((SstRules e) => e.Id)).HasName("PRIMARY_100").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstRules e) => e.Id), "SST_RULES_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstRules, object>>)((SstRules e) => e.SystemId)).HasName("SST_RULES_IDX01");
					entity.Property((SstRules e) => e.RuleType).HasDefaultValueSql("'1'");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstRules>(entity.HasOne((SstRules d) => d.System).WithMany((SstSystems p) => p.SstRules).HasForeignKey((SstRules d) => d.SystemId), "SST_RULES_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstSegmentElement> entity)
				{
					entity.HasIndex((Expression<Func<SstSegmentElement, object>>)((SstSegmentElement e) => e.Id)).HasName("SYS_C0027334").IsUnique();
					entity.Property((SstSegmentElement e) => e.Id).ValueGeneratedNever();
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstSegments> entity)
				{
					entity.HasIndex((Expression<Func<SstSegments, object>>)((SstSegments e) => e.Branch)).HasName("SST_SEGMENTS_IDX01");
					entity.HasIndex((Expression<Func<SstSegments, object>>)((SstSegments e) => e.BusinessChannel)).HasName("SST_SEGMENTS_IDX05");
					entity.HasIndex((Expression<Func<SstSegments, object>>)((SstSegments e) => e.ClassId)).HasName("SST_SEGMENTS_IDX03");
					entity.HasIndex((Expression<Func<SstSegments, object>>)((SstSegments e) => e.CompanyId)).HasName("SST_SEGMENTS_IDX06");
					entity.HasIndex((Expression<Func<SstSegments, object>>)((SstSegments e) => e.Id)).HasName("PRIMARY_101").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstSegments e) => e.Id), "SST_SEGMENTS_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstSegments, object>>)((SstSegments e) => e.PolicyType)).HasName("SST_SEGMENTS_IDX04");
					entity.HasIndex((Expression<Func<SstSegments, object>>)((SstSegments e) => e.SystemId)).HasName("SST_SEGMENTS_IDX02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstBusinessChannels, SstSegments>(entity.HasOne((SstSegments d) => d.BusinessChannelNavigation).WithMany((SstBusinessChannels p) => p.SstSegments).HasForeignKey((SstSegments d) => d.BusinessChannel), "SST_SEGMENTS_FK04");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstSegments>(entity.HasOne((SstSegments d) => d.Class).WithMany((SstClasses p) => p.SstSegments).HasForeignKey((SstSegments d) => d.ClassId), "SST_SEGMENTS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstSegments>(entity.HasOne((SstSegments d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstSegments).HasForeignKey((SstSegments d) => d.PolicyType), "SST_SEGMENTS_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstSegments>(entity.HasOne((SstSegments d) => d.System).WithMany((SstSystems p) => p.SstSegments).HasForeignKey((SstSegments d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_SEGMENTS_FK03");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstSegmentsStructures> entity)
				{
					entity.HasIndex((Expression<Func<SstSegmentsStructures, object>>)((SstSegmentsStructures e) => e.Id)).HasName("PRIMARY_102").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstSegmentsStructures e) => e.Id), "SST_SEGMENTS_STRUCTURES_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstSegmentsStructures, object>>)((SstSegmentsStructures e) => e.SegmentId)).HasName("SST_SEGMENTS_STRUCTURES_IDX01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSegments, SstSegmentsStructures>(entity.HasOne((SstSegmentsStructures d) => d.Segment).WithMany((SstSegments p) => p.SstSegmentsStructures).HasForeignKey((SstSegmentsStructures d) => d.SegmentId)
					//	.OnDelete(DeleteBehavior.Cascade), "SST_SEGMENTS_STRUCTURES_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstSerialLists> entity)
				{
					entity.HasIndex((Expression<Func<SstSerialLists, object>>)((SstSerialLists e) => e.Branch)).HasName("SST_SERIAL_LISTS_IDX01");
					entity.HasIndex((Expression<Func<SstSerialLists, object>>)((SstSerialLists e) => e.BusinessChannel)).HasName("SST_SERIAL_LISTS_FK04_IDX");
					entity.HasIndex((Expression<Func<SstSerialLists, object>>)((SstSerialLists e) => e.ClassId)).HasName("SST_SERIAL_LISTS_IDX03");
					entity.HasIndex((Expression<Func<SstSerialLists, object>>)((SstSerialLists e) => e.Id)).HasName("PRIMARY_103").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstSerialLists e) => e.Id), "SST_SERIAL_LISTS_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstSerialLists, object>>)((SstSerialLists e) => e.PolicyType)).HasName("SST_SERIAL_LISTS_IDX04");
					entity.HasIndex((Expression<Func<SstSerialLists, object>>)((SstSerialLists e) => e.SystemId)).HasName("SST_SERIAL_LISTS_IDX02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstBusinessChannels, SstSerialLists>(entity.HasOne((SstSerialLists d) => d.BusinessChannelNavigation).WithMany((SstBusinessChannels p) => p.SstSerialLists).HasForeignKey((SstSerialLists d) => d.BusinessChannel), "SST_SERIAL_LISTS_FK04");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstSerialLists>(entity.HasOne((SstSerialLists d) => d.Class).WithMany((SstClasses p) => p.SstSerialLists).HasForeignKey((SstSerialLists d) => d.ClassId), "SST_SERIAL_LISTS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPackagedPolicy, SstSerialLists>(entity.HasOne((SstSerialLists d) => d.Packaged).WithMany((SstPackagedPolicy p) => p.SstSerialLists).HasForeignKey((SstSerialLists d) => d.PackagedId), "SST_SERIAL_LISTS_PACKG_ID_FK");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstSerialLists>(entity.HasOne((SstSerialLists d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstSerialLists).HasForeignKey((SstSerialLists d) => d.PolicyType), "SST_SERIAL_LISTS_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstSerialLists>(entity.HasOne((SstSerialLists d) => d.System).WithMany((SstSystems p) => p.SstSerialLists).HasForeignKey((SstSerialLists d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_SERIAL_LISTS_FK03");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstSerialRanges> entity)
				{
					entity.HasIndex((Expression<Func<SstSerialRanges, object>>)((SstSerialRanges e) => e.Id)).HasName("PRIMARY_104").IsUnique();
					entity.HasIndex((Expression<Func<SstSerialRanges, object>>)((SstSerialRanges e) => e.SerialId)).HasName("SST_SERIAL_RANGES_IDX01");
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstSerialRanges e) => e.Id), "SST_SERIAL_RANGES_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstSerialRanges, object>>)((SstSerialRanges e) => new { e.SerialId, e.SerialDate })).HasName("SERIAL_ID").IsUnique();
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSerialLists, SstSerialRanges>(entity.HasOne((SstSerialRanges d) => d.Serial).WithMany((SstSerialLists p) => p.SstSerialRanges).HasForeignKey((SstSerialRanges d) => d.SerialId), "SST_SERIAL_RANGES_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstShortPeriods> entity)
				{
					entity.HasIndex((Expression<Func<SstShortPeriods, object>>)((SstShortPeriods e) => e.ClassId)).HasName("SST_SHORT_PERIODS_FK02");
					entity.HasIndex((Expression<Func<SstShortPeriods, object>>)((SstShortPeriods e) => e.CompanyId)).HasName("SST_SHORT_PERIODS_IDX02");
					entity.HasIndex((Expression<Func<SstShortPeriods, object>>)((SstShortPeriods e) => e.Id)).HasName("PRIMARY_105").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstShortPeriods e) => e.Id), "SST_SHORT_PERIODS_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstShortPeriods, object>>)((SstShortPeriods e) => e.PolicyType)).HasName("SST_SHORT_PERIODS_FK03");
					entity.HasIndex((Expression<Func<SstShortPeriods, object>>)((SstShortPeriods e) => e.SystemId)).HasName("SST_SHORT_PERIODS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstShortPeriods>(entity.HasOne((SstShortPeriods d) => d.Class).WithMany((SstClasses p) => p.SstShortPeriods).HasForeignKey((SstShortPeriods d) => d.ClassId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_SHORT_PERIODS_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstShortPeriods>(entity.HasOne((SstShortPeriods d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstShortPeriods).HasForeignKey((SstShortPeriods d) => d.PolicyType)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_SHORT_PERIODS_FK03");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstShortPeriods>(entity.HasOne((SstShortPeriods d) => d.System).WithMany((SstSystems p) => p.SstShortPeriods).HasForeignKey((SstShortPeriods d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_SHORT_PERIODS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstShortPeriodsDetails> entity)
				{
					entity.HasIndex((Expression<Func<SstShortPeriodsDetails, object>>)((SstShortPeriodsDetails e) => e.Id)).HasName("PRIMARY_106").IsUnique();
					entity.HasIndex((Expression<Func<SstShortPeriodsDetails, object>>)((SstShortPeriodsDetails e) => e.ShortPeriodId)).HasName("SST_SHORT_PERIODS_DETAILS_FK01");
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstShortPeriodsDetails e) => e.Id), "SST_SHORT_PERIODS_DETAILS_SEQ", (string)null);
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstShortPeriods, SstShortPeriodsDetails>(entity.HasOne((SstShortPeriodsDetails d) => d.ShortPeriod).WithMany((SstShortPeriods p) => p.SstShortPeriodsDetails).HasForeignKey((SstShortPeriodsDetails d) => d.ShortPeriodId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_SHORT_PERIODS_DETAILS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstSmsProviders> entity)
				{
					entity.HasIndex((Expression<Func<SstSmsProviders, object>>)((SstSmsProviders e) => e.Id)).HasName("PRIMARY_107").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstSmsProviders e) => e.Id), "SST_SMS_PROVIDERS_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstSmsProviders, object>>)((SstSmsProviders e) => e.SystemId)).HasName("SST_SMS_PROVIDERS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstSmsProviders>(entity.HasOne((SstSmsProviders d) => d.System).WithMany((SstSystems p) => p.SstSmsProviders).HasForeignKey((SstSmsProviders d) => d.SystemId), "SST_SMS_PROVIDERS_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstStatusRelation> entity)
				{
					entity.HasIndex((Expression<Func<SstStatusRelation, object>>)((SstStatusRelation e) => e.ClassId)).HasName("SST_STATUS_RELATION_IDX02");
					entity.HasIndex((Expression<Func<SstStatusRelation, object>>)((SstStatusRelation e) => e.Id)).HasName("PRIMARY_108").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstStatusRelation e) => e.Id), "SST_STATUS_RELATION_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstStatusRelation, object>>)((SstStatusRelation e) => e.PolicyType)).HasName("SST_STATUS_RELATION_IDX03");
					entity.HasIndex((Expression<Func<SstStatusRelation, object>>)((SstStatusRelation e) => e.StageDomain)).HasName("SST_STATUS_RELATION_IDX05");
					entity.HasIndex((Expression<Func<SstStatusRelation, object>>)((SstStatusRelation e) => e.StatusDomain)).HasName("SST_STATUS_RELATION_IDX04");
					entity.HasIndex((Expression<Func<SstStatusRelation, object>>)((SstStatusRelation e) => e.SystemId)).HasName("SST_STATUS_RELATION_IDX01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstClasses, SstStatusRelation>(entity.HasOne((SstStatusRelation d) => d.Class).WithMany((SstClasses p) => p.SstStatusRelation).HasForeignKey((SstStatusRelation d) => d.ClassId), "SST_STATUS_RELATION_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstPolicyTypes, SstStatusRelation>(entity.HasOne((SstStatusRelation d) => d.PolicyTypeNavigation).WithMany((SstPolicyTypes p) => p.SstStatusRelation).HasForeignKey((SstStatusRelation d) => d.PolicyType), "SST_STATUS_RELATION_FK03");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstDomains, SstStatusRelation>(entity.HasOne((SstStatusRelation d) => d.StageDomainNavigation).WithMany((SstDomains p) => p.SstStatusRelationStageDomainNavigation).HasForeignKey((SstStatusRelation d) => d.StageDomain)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_STATUS_RELATION_FK05");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstDomains, SstStatusRelation>(entity.HasOne((SstStatusRelation d) => d.StatusDomainNavigation).WithMany((SstDomains p) => p.SstStatusRelationStatusDomainNavigation).HasForeignKey((SstStatusRelation d) => d.StatusDomain)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_STATUS_RELATION_FK04");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstStatusRelation>(entity.HasOne((SstStatusRelation d) => d.System).WithMany((SstSystems p) => p.SstStatusRelation).HasForeignKey((SstStatusRelation d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_STATUS_RELATION_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstSubBranches> entity)
				{
					entity.HasIndex((Expression<Func<SstSubBranches, object>>)((SstSubBranches e) => e.Id)).HasName("SYS_C0026383").IsUnique();
					entity.HasIndex((Expression<Func<SstSubBranches, object>>)((SstSubBranches e) => e.SystemId)).HasName("SST_SUB_BRANCHES_IDX01");
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstSubBranches e) => e.Id), "SST_SUB_BRANCHES_SEQ", (string)null);
					entity.Property((SstSubBranches e) => e.ModificationDate).HasDefaultValueSql("NULL");
					entity.Property((SstSubBranches e) => e.ModificationUser).HasDefaultValueSql("NULL");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSubBranches, SstSubBranches>(entity.HasOne((SstSubBranches d) => d.SubBranch).WithMany((SstSubBranches p) => p.InverseSubBranch).HasForeignKey((SstSubBranches d) => d.SubBranchId), "SST_SUB_BRANCHES_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstSubBranches>(entity.HasOne((SstSubBranches d) => d.System).WithMany((SstSystems p) => p.SstSubBranches).HasForeignKey((SstSubBranches d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_SUB_BRANCHES_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstSystems> entity)
				{
					entity.HasIndex((Expression<Func<SstSystems, object>>)((SstSystems e) => e.Id)).HasName("PRIMARY_109").IsUnique();
					entity.Property((SstSystems e) => e.Id).ValueGeneratedNever();
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstUserAlerts> entity)
				{
					entity.HasIndex((Expression<Func<SstUserAlerts, object>>)((SstUserAlerts e) => e.AlertId)).HasName("SST_USER_ALERTS_FK01");
					entity.HasIndex((Expression<Func<SstUserAlerts, object>>)((SstUserAlerts e) => e.Id)).HasName("PRIMARY_110").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstUserAlerts e) => e.Id), "SST_USER_ALERTS_SEQ", (string)null);
					entity.HasIndex((Expression<Func<SstUserAlerts, object>>)((SstUserAlerts e) => e.UserId)).HasName("SST_USER_ALERTS_FK02");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstAlerts, SstUserAlerts>(entity.HasOne((SstUserAlerts d) => d.Alert).WithMany((SstAlerts p) => p.SstUserAlerts).HasForeignKey((SstUserAlerts d) => d.AlertId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_USER_ALERTS_FK01");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstUsers, SstUserAlerts>(entity.HasOne((SstUserAlerts d) => d.User).WithMany((SstUsers p) => p.SstUserAlerts).HasForeignKey((SstUserAlerts d) => d.UserId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_USER_ALERTS_FK02");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstUsers> entity)
				{
					entity.HasIndex((Expression<Func<SstUsers, object>>)((SstUsers e) => e.Id)).HasName("PRIMARY_111").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstUsers e) => e.Id), "SST_USERS_SEQ", (string)null);
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstValuesRelation> entity)
				{
					entity.HasIndex((Expression<Func<SstValuesRelation, object>>)((SstValuesRelation e) => e.Id)).HasName("SYS_C0026673").IsUnique();
					entity.HasIndex((Expression<Func<SstValuesRelation, object>>)((SstValuesRelation e) => e.SystemId)).HasName("SST_VALUES_RELATION_IDX01");
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((SstValuesRelation e) => e.Id), "SST_VALUES_RELATION_SEQ", (string)null);
					entity.Property((SstValuesRelation e) => e.ModificationDate).HasDefaultValueSql("NULL");
					entity.Property((SstValuesRelation e) => e.ModificationUser).HasDefaultValueSql("NULL");
					//RelationalReferenceCollectionBuilderExtensions.HasConstraintName<SstSystems, SstValuesRelation>(entity.HasOne((SstValuesRelation d) => d.System).WithMany((SstSystems p) => p.SstValuesRelation).HasForeignKey((SstValuesRelation d) => d.SystemId)
					//	.OnDelete(DeleteBehavior.ClientSetNull), "SST_VALUES_RELATION_FK01");
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstVouchersReferences> entity)
				{
					entity.HasIndex((Expression<Func<SstVouchersReferences, object>>)((SstVouchersReferences e) => e.CompanyId)).HasName("SST_VOUCHERS_TYPES_IDX04_1");
					entity.HasIndex((Expression<Func<SstVouchersReferences, object>>)((SstVouchersReferences e) => e.FcrTrtCode)).HasName("SST_VOUCHERS_TYPES_IDX03_1");
					entity.HasIndex((Expression<Func<SstVouchersReferences, object>>)((SstVouchersReferences e) => e.Id)).HasName("SYS_C0025347").IsUnique();
					entity.HasIndex((Expression<Func<SstVouchersReferences, object>>)((SstVouchersReferences e) => e.SystemId)).HasName("SST_VOUCHERS_TYPES_IDX01_1");
					entity.Property((SstVouchersReferences e) => e.Id).ValueGeneratedNever();
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<SstVouchersTypes> entity)
				{
					entity.HasKey((SstVouchersTypes e) => e.Serial).HasName("PRIMARY_112");
					entity.HasIndex((Expression<Func<SstVouchersTypes, object>>)((SstVouchersTypes e) => e.CompanyId)).HasName("SST_VOUCHERS_TYPES_IDX04");
					entity.HasIndex((Expression<Func<SstVouchersTypes, object>>)((SstVouchersTypes e) => e.FcrTrtCode)).HasName("SST_VOUCHERS_TYPES_IDX03");
					entity.HasIndex((Expression<Func<SstVouchersTypes, object>>)((SstVouchersTypes e) => e.ModuleCode)).HasName("SST_VOUCHERS_TYPES_IDX02");
					entity.HasIndex((Expression<Func<SstVouchersTypes, object>>)((SstVouchersTypes e) => e.Serial)).HasName("PRIMARY_112").IsUnique();
					entity.HasIndex((Expression<Func<SstVouchersTypes, object>>)((SstVouchersTypes e) => e.SystemId)).HasName("SST_VOUCHERS_TYPES_IDX01");
					entity.Property((SstVouchersTypes e) => e.Serial).ValueGeneratedNever();
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<TempVouchers> entity)
				{
					entity.HasIndex((Expression<Func<TempVouchers, object>>)((TempVouchers e) => e.Id)).HasName("SYS_C0025792").IsUnique();
					entity.Property((TempVouchers e) => e.Id).ValueGeneratedNever();
				});
				modelBuilder.Entity(delegate(EntityTypeBuilder<Training> entity)
				{
					entity.HasIndex((Expression<Func<Training, object>>)((Training e) => e.Id)).HasName("SYS_C0027181").IsUnique();
					//OraclePropertyBuilderExtensions.ForOracleUseSequenceHiLo<long>(entity.Property((Training e) => e.Id), "TRAINING_SEQ", (string)null);
					entity.Property((Training e) => e.ModificationDate).HasDefaultValueSql("NULL");
					entity.Property((Training e) => e.ModificationUser).HasDefaultValueSql("NULL");
				});
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "APPROVAL_MAPPING_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "CP_USER_PROPERTIES_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "CPD_IQTP_CLM_EXPERIENCE_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "CPD_IQTP_MAJOR_CLAIMS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "CPD_IQTP_OTHER_RETENTION_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "CPD_IQTP_SCTR_BUSINESS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "CPD_IQTP_TRT_EXCEPTIONS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "CPD_IQTP_YEARLY_PREMIUM_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "MST_FRM_PARAMS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SPD_COMPONENTS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SPD_CONTAINERS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "FIN_TRANS_DETAILS_SEQ", (string)null);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SPD_CONTROL_VALUES_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_REINSURANCE_ACCOUNTS_SEQ", (string)null);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SPD_FORM_CONTROLS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "TEMP_VOUCHERS_SEQ", (string)null);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SPD_PRODUCTS_DETAILS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SPD_PRODUCTS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SPD_PRODUCTS_STEPS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SPD_SEQUENCES_DETAILS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SPD_SEQUENCES_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SPD_STEPS_TRANSACTIONS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SRN_XL_REINSTAT_METHOD_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_ACCOUNTS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_ACTIONS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_AGENT_BOOK_DETAILS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_AGENT_BOOKS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_AGENT_COMM_TIERS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_AGENT_OFFICES_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_AGENT_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_AGENT_STRUCTURES_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_ALERTS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_ANSWERS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_BUSINESS_CHANNELS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_CHANNEL_PLANS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_CHANNEL_TYPES_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_CLAIM_DISCOUNTS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_CLASSES_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_CLAUSES_DETAILS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_CLAUSES_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_CLOSING_PERIODS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_CODES_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_COMM_STRUCTURE_BUS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_COMMISSION_DETAILS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_COMMISSION_STRUCTURE_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_COMMISSION_TIERS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_COMMISSION_TYPES_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_COMPONENTS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_CONDITIONS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_CONTAINERS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_CORE_QUESTIONNAIRES_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_COVER_RATING_TYPES_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_COVER_TYPES_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_CUSTOMER_TYPES_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_DATA_SECURITY_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_DISCOUNTS_BUS_FACTORS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_DISCOUNTS_FACTORS_QRY_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_DISCOUNTS_FACTORS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_DISCOUNTS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_DOCUMENT_GROUPS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_DOCUMENTS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_DYNAMIC_VALUES_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_ENDORSEMENTS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_ENTITIES_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_ENTITY_DETAILS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_ENTITY_MAPPING_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_ENTITY_ROLES_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_EPAYMENT_ALERTS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_EPAYMENT_DETAILS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_EPAYMENT_METHODS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_FEES_DETAILS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_FEES_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_FEES_TIERS_DETAILS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_FEES_TIERS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_FINANCIAL_AGENTS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_FINANCIAL_CLAIMS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_FINANCIAL_DETAILS_ID_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_FINANCIAL_DETAILS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_FINANCIAL_INSTALLMENTS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_FINANCIAL_POLICIES_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_FINANCIAL_TRANSACTIONS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_FORM_CONTROLS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_FORM_ELEMENTS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_FORM_GRID_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_FORM_SYSTEMS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_FORMS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_INDUSTRY_SECTORS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_INTEGRATIONS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_LOGS_DETAILS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_LOGS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_MAILER_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_MAPPINGS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_MATRIX_PARAMS_MAPPING_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_NOTIFICATIONS_LOGS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_NOTIFICATIONS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_OFFICES_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_PACKAGED_POLICY_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_PACKEGED_COVERS_MATRIX_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_PACKEGED_COVERS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_PAGES_CONTROLS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_PAYMENT_CYCLES_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_PAYMENT_DETAILS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_PCK_PLC_DETAILS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_POLICY_BUSINESS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_POLICY_DISCOUNTS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_POLICY_TYPES_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_PREFERENCES_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_PROCESS_ACTIONS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_PROCESS_CONDITIONS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_PROCESS_ROLES_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_PROCESS_RULES_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_PROCESS_STEPS_PAGES_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_PROCESS_STEPS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_PROCESS_SYSTEMS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_PROCESSES_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_PRODUCTS_DETAILS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_PRODUCTS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_QUEST_CONTROLS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_QUEST_DETAILS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_QUEST_SYSTEMS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_QUESTIONNAIRES_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_RATING_MATRIX_PARAMS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_RATING_MATRIX_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_RATING_MATRIX_VALUES_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_REINSURANCE_ACCOUNTS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_RELATIONS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_RESOURCES_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_RULES_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_SEGMENTS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_SEGMENTS_STRUCTURES_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_SERIAL_LISTS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_SERIAL_RANGES_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_SHORT_PERIODS_DETAILS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_SHORT_PERIODS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_SMS_PROVIDERS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_STATUS_RELATION_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_SUB_BRANCHES_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_USER_ALERTS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_USERS_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "SST_VALUES_RELATION_SEQ", (string)null).IncrementsBy(1);
				RelationalModelBuilderExtensions.HasSequence(modelBuilder, "TRAINING_SEQ", (string)null).IncrementsBy(1);
				break;
			}
		}
	}
}
