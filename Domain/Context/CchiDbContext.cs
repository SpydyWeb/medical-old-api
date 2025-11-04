using Domain.Common;
using Domain.Context;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oracle.EntityFrameworkCore.Infrastructure;

namespace Domain.Context
{
	public class CchiDbContext : DbContext
	{
		public virtual DbSet<MntNetCchi> MntNetCchis { get; set; }

		public virtual DbSet<MntNetCchiHist> MntNetCchiHists { get; set; }

		public virtual DbSet<MntPrvNetCchi> MntPrvNetCchis { get; set; }

		public virtual DbSet<MntPrvNetCchiHist> MntPrvNetCchiHists { get; set; }

		public virtual DbSet<MpdBenefitsCchi> MpdBenefitsCchis { get; set; }

		public virtual DbSet<MpdBenefitsCchiHist> MpdBenefitsCchiHists { get; set; }

		public virtual DbSet<MpdCchiBenefitsMapping> MpdCchiBenefitsMappings { get; set; }

		public virtual DbSet<MpdClassesCchiHist> MpdClassesCchiHists { get; set; }

		public virtual DbSet<MpdClassesCchi> MpdClassesCchis { get; set; }

		public virtual DbSet<MpdMembersCchi> MpdMembersCchis { get; set; }

		public virtual DbSet<MpdMembersCchiHist> MpdMembersCchiHists { get; set; }

		public virtual DbSet<MpdPoliciesCchi> MpdPoliciesCchis { get; set; }

		public virtual DbSet<MpdPoliciesCchiHist> MpdPoliciesCchiHists { get; set; }

		public virtual DbSet<MpdSponsorsCchi> MpdSponsorsCchis { get; set; }

		public CchiDbContext()
		{
		}

		public CchiDbContext(DbContextOptions<CchiDbContext> options)
			: base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseOracle(SharedSettings.OracleConnectionString, delegate(OracleDbContextOptionsBuilder option)
				{
					option.UseOracleSQLCompatibility("11");
				});
			}
			optionsBuilder.EnableSensitiveDataLogging();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity(delegate(EntityTypeBuilder<MntNetCchi> entity)
			{
				entity.ToTable("MNT_NET_CCHI");
				entity.HasIndex((MntNetCchi e) => e.Id).IsUnique();
				entity.Property((MntNetCchi e) => e.Id).HasPrecision(15).HasColumnName("ID");//.UseHiLo("MNT_NET_CCHI_SEQ");					
				entity.Property((MntNetCchi e) => e.CreationDate).HasColumnType("DATE").HasColumnName("CREATION_DATE");
				entity.Property((MntNetCchi e) => e.CreationUser).HasMaxLength(25).IsUnicode(unicode: false)
					.HasColumnName("CREATION_USER");
				entity.Property((MntNetCchi e) => e.ErrorCode).HasPrecision(5).HasColumnName("ERROR_CODE");
				entity.Property((MntNetCchi e) => e.ErrorDesc).HasMaxLength(1024).IsUnicode(unicode: false)
					.HasColumnName("ERROR_DESC");
				entity.Property((MntNetCchi e) => e.MntNetId).HasPrecision(15).HasColumnName("MNT_NET_ID");
				entity.Property((MntNetCchi e) => e.ModificationDate).HasColumnType("DATE").HasColumnName("MODIFICATION_DATE");
				entity.Property((MntNetCchi e) => e.ModificationUser).HasMaxLength(25).IsUnicode(unicode: false)
					.HasColumnName("MODIFICATION_USER");
				entity.Property((MntNetCchi e) => e.Name).IsRequired().HasMaxLength(80)
					.IsUnicode(unicode: false)
					.HasColumnName("NAME");
				entity.Property((MntNetCchi e) => e.ReferenceNo).HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnName("REFERENCE_NO");
				entity.Property((MntNetCchi e) => e.Status).HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnName("STATUS");
				entity.Property((MntNetCchi e) => e.StatusDate).HasColumnType("DATE").HasColumnName("STATUS_DATE");
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<MntNetCchiHist> entity)
			{
				entity.ToTable("MNT_NET_CCHI_HIST");
				entity.HasIndex((MntNetCchiHist e) => e.Id).IsUnique();
				entity.Property((MntNetCchiHist e) => e.Id).HasPrecision(15).HasColumnName("ID");
					//.UseHiLo("MNT_NET_CCHI_HIST_SEQ");
				entity.Property((MntNetCchiHist e) => e.CreationDate).HasColumnType("DATE").HasColumnName("CREATION_DATE");
				entity.Property((MntNetCchiHist e) => e.CreationUser).HasMaxLength(25).IsUnicode(unicode: false)
					.HasColumnName("CREATION_USER");
				entity.Property((MntNetCchiHist e) => e.ErrorCode).HasPrecision(3).HasColumnName("ERROR_CODE");
				entity.Property((MntNetCchiHist e) => e.ErrorDesc).HasMaxLength(1024).IsUnicode(unicode: false)
					.HasColumnName("ERROR_DESC");
				entity.Property((MntNetCchiHist e) => e.MntNetCchiId).HasPrecision(15).HasColumnName("MNT_NET_CCHI_ID");
				entity.Property((MntNetCchiHist e) => e.ModificationDate).HasColumnType("DATE").HasColumnName("MODIFICATION_DATE");
				entity.Property((MntNetCchiHist e) => e.ModificationUser).HasMaxLength(25).IsUnicode(unicode: false)
					.HasColumnName("MODIFICATION_USER");
				entity.Property((MntNetCchiHist e) => e.Status).HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnName("STATUS");
				entity.Property((MntNetCchiHist e) => e.StatusDate).HasColumnType("DATE").HasColumnName("STATUS_DATE");
				entity.Property((MntNetCchiHist e) => e.TransactionType).HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnName("TRANSACTION_TYPE");
				entity.HasOne((MntNetCchiHist d) => d.MntNetCchi).WithMany((MntNetCchi p) => p.MntNetCchiHists).HasForeignKey((MntNetCchiHist d) => d.MntNetCchiId)
					.HasConstraintName("MNT_NET_CCHI_HIST_FK");
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<MntPrvNetCchi> entity)
			{
				entity.ToTable("MNT_PRV_NET_CCHI");
				entity.HasIndex((MntPrvNetCchi e) => e.Id).IsUnique();
				entity.Property((MntPrvNetCchi e) => e.Id).HasPrecision(15).HasColumnName("ID");
					//.UseHiLo("MNT_PRV_NET_CCHI_SEQ");
				entity.Property((MntPrvNetCchi e) => e.CreationDate).HasColumnType("DATE").HasColumnName("CREATION_DATE");
				entity.Property((MntPrvNetCchi e) => e.CreationUser).HasMaxLength(25).IsUnicode(unicode: false)
					.HasColumnName("CREATION_USER");
				entity.Property((MntPrvNetCchi e) => e.EndDate).HasColumnType("DATE").HasColumnName("END_DATE");
				entity.Property((MntPrvNetCchi e) => e.ErrorCode).HasPrecision(5).HasColumnName("ERROR_CODE");
				entity.Property((MntPrvNetCchi e) => e.ErrorDesc).HasMaxLength(1024).IsUnicode(unicode: false)
					.HasColumnName("ERROR_DESC");
				entity.Property((MntPrvNetCchi e) => e.Hoid).HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnName("HOID");
				entity.Property((MntPrvNetCchi e) => e.MntNetCchiId).HasPrecision(15).HasColumnName("MNT_NET_CCHI_ID");
				entity.Property((MntPrvNetCchi e) => e.MntPrvNetId).HasPrecision(15).HasColumnName("MNT_PRV_NET_ID");
				entity.Property((MntPrvNetCchi e) => e.ModificationDate).HasColumnType("DATE").HasColumnName("MODIFICATION_DATE");
				entity.Property((MntPrvNetCchi e) => e.ModificationUser).HasMaxLength(25).IsUnicode(unicode: false)
					.HasColumnName("MODIFICATION_USER");
				entity.Property((MntPrvNetCchi e) => e.ReferenceNo).HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnName("REFERENCE_NO");
				entity.Property((MntPrvNetCchi e) => e.Status).HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnName("STATUS");
				entity.Property((MntPrvNetCchi e) => e.StatusDate).HasColumnType("DATE").HasColumnName("STATUS_DATE");
				entity.HasOne((MntPrvNetCchi d) => d.MntNetCchi).WithMany((MntNetCchi p) => p.MntPrvNetCchis).HasForeignKey((MntPrvNetCchi d) => d.MntNetCchiId)
					.HasConstraintName("MNT_PRV_NET_CCHI_FK");
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<MntPrvNetCchiHist> entity)
			{
				entity.ToTable("MNT_PRV_NET_CCHI_HIST");
				entity.HasIndex((MntPrvNetCchiHist e) => e.Id).IsUnique();
				entity.Property((MntPrvNetCchiHist e) => e.Id).HasPrecision(15).HasColumnName("ID");
					//.UseHiLo("MNT_PRV_NET_CCHI_HIST_SEQ");
				entity.Property((MntPrvNetCchiHist e) => e.CreationDate).HasColumnType("DATE").HasColumnName("CREATION_DATE");
				entity.Property((MntPrvNetCchiHist e) => e.CreationUser).HasMaxLength(25).IsUnicode(unicode: false)
					.HasColumnName("CREATION_USER");
				entity.Property((MntPrvNetCchiHist e) => e.ErrorCode).HasPrecision(3).HasColumnName("ERROR_CODE");
				entity.Property((MntPrvNetCchiHist e) => e.ErrorDesc).HasMaxLength(1024).IsUnicode(unicode: false)
					.HasColumnName("ERROR_DESC");
				entity.Property((MntPrvNetCchiHist e) => e.MntPrvNetCchiId).HasPrecision(15).HasColumnName("MNT_PRV_NET_CCHI_ID");
				entity.Property((MntPrvNetCchiHist e) => e.ModificationDate).HasColumnType("DATE").HasColumnName("MODIFICATION_DATE");
				entity.Property((MntPrvNetCchiHist e) => e.ModificationUser).HasMaxLength(25).IsUnicode(unicode: false)
					.HasColumnName("MODIFICATION_USER");
				entity.Property((MntPrvNetCchiHist e) => e.Status).HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnName("STATUS");
				entity.Property((MntPrvNetCchiHist e) => e.StatusDate).HasColumnType("DATE").HasColumnName("STATUS_DATE");
				entity.Property((MntPrvNetCchiHist e) => e.TransactionType).HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnName("TRANSACTION_TYPE");
				entity.HasOne((MntPrvNetCchiHist d) => d.MntPrvNetCchi).WithMany((MntPrvNetCchi p) => p.MntPrvNetCchiHists).HasForeignKey((MntPrvNetCchiHist d) => d.MntPrvNetCchiId)
					.HasConstraintName("MNT_PRV_NET_CCHI_HIST_FK");
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<MpdBenefitsCchi> entity)
			{
				entity.ToTable("MPD_BENEFITS_CCHI");
				entity.HasIndex((MpdBenefitsCchi e) => e.Id).IsUnique();
				entity.Property((MpdBenefitsCchi e) => e.Id).HasPrecision(15).HasColumnName("ID");
					//.UseHiLo("MPD_BENEFITS_CCHI_SEQ");
				entity.Property((MpdBenefitsCchi e) => e.AnnualLimit).HasColumnType("NUMBER(18,3)").HasColumnName("ANNUAL_LIMIT");
				entity.Property((MpdBenefitsCchi e) => e.CchiBenefitId).HasPrecision(15).HasColumnName("CCHI_BENEFIT_ID");
				entity.Property((MpdBenefitsCchi e) => e.CreationDate).HasColumnType("DATE").HasColumnName("CREATION_DATE");
				entity.Property((MpdBenefitsCchi e) => e.CreationUser).HasMaxLength(25).IsUnicode(unicode: false)
					.HasColumnName("CREATION_USER");
				entity.Property((MpdBenefitsCchi e) => e.ModificationDate).HasColumnType("DATE").HasColumnName("MODIFICATION_DATE");
				entity.Property((MpdBenefitsCchi e) => e.ModificationUser).HasMaxLength(25).IsUnicode(unicode: false)
					.HasColumnName("MODIFICATION_USER");
				entity.Property((MpdBenefitsCchi e) => e.MpdPbnId).HasPrecision(15).HasColumnName("MPD_PBN_ID");
				entity.Property((MpdBenefitsCchi e) => e.MpdPclCchiId).HasPrecision(15).HasColumnName("MPD_PCL_CCHI_ID");
				entity.Property((MpdBenefitsCchi e) => e.Name).HasMaxLength(100).IsUnicode(unicode: false)
					.HasColumnName("NAME");
				entity.Property((MpdBenefitsCchi e) => e.NetCopayment).HasColumnType("NUMBER(18,3)").HasColumnName("NET_COPAYMENT");
				entity.Property((MpdBenefitsCchi e) => e.NetDeductible).HasColumnType("NUMBER(18,3)").HasColumnName("NET_DEDUCTIBLE");
				entity.Property((MpdBenefitsCchi e) => e.NetMaxDeductible).HasColumnType("NUMBER(20,5)").HasColumnName("NET_MAX_DEDUCTIBLE");
				entity.Property((MpdBenefitsCchi e) => e.NetMinDeductible).HasColumnType("NUMBER(20,5)").HasColumnName("NET_MIN_DEDUCTIBLE");
				entity.Property((MpdBenefitsCchi e) => e.NumberOfUsage).HasPrecision(5).HasColumnName("NUMBER_OF_USAGE");
				entity.Property((MpdBenefitsCchi e) => e.ReimbCopayment).HasColumnType("NUMBER(18,3)").HasColumnName("REIMB_COPAYMENT");
				entity.Property((MpdBenefitsCchi e) => e.ReimbDeductable).HasColumnType("NUMBER(18,3)").HasColumnName("REIMB_DEDUCTABLE");
				entity.Property((MpdBenefitsCchi e) => e.ReimbMaxDeductible).HasColumnType("NUMBER(20,5)").HasColumnName("REIMB_MAX_DEDUCTIBLE");
				entity.Property((MpdBenefitsCchi e) => e.ReimbMinDeductible).HasColumnType("NUMBER(20,5)").HasColumnName("REIMB_MIN_DEDUCTIBLE");
				entity.Property((MpdBenefitsCchi e) => e.Status).HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnName("STATUS");
				entity.Property((MpdBenefitsCchi e) => e.StatusDate).HasColumnType("DATE").HasColumnName("STATUS_DATE");
				entity.Property((MpdBenefitsCchi e) => e.StatusDesc).HasMaxLength(1024).IsUnicode(unicode: false)
					.HasColumnName("STATUS_DESC");
				entity.Property((MpdBenefitsCchi e) => e.TerritoryScope).HasMaxLength(100).IsUnicode(unicode: false)
					.HasColumnName("TERRITORY_SCOPE");
				entity.HasOne((MpdBenefitsCchi d) => d.CchiBenefit).WithMany((MpdCchiBenefitsMapping p) => p.MpdBenefitsCchis).HasForeignKey((MpdBenefitsCchi d) => d.CchiBenefitId)
					.HasConstraintName("SYS_C002555017");
				entity.HasOne((MpdBenefitsCchi d) => d.MpdPclCchi).WithMany((MpdClassesCchi p) => p.MpdBenefitsCchis).HasForeignKey((MpdBenefitsCchi d) => d.MpdPclCchiId)
					.HasConstraintName("SYS_C002549993");
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<MpdBenefitsCchiHist> entity)
			{
				entity.ToTable("MPD_BENEFITS_CCHI_HIST");
				entity.HasIndex((MpdBenefitsCchiHist e) => e.Id).IsUnique();
				entity.Property((MpdBenefitsCchiHist e) => e.Id).HasPrecision(15).HasColumnName("ID");
					//.UseHiLo("MPD_BENEFITS_CCHI_HIST_SEQ");
				entity.Property((MpdBenefitsCchiHist e) => e.CreationDate).HasColumnType("DATE").HasColumnName("CREATION_DATE");
				entity.Property((MpdBenefitsCchiHist e) => e.CreationUser).HasMaxLength(25).IsUnicode(unicode: false)
					.HasColumnName("CREATION_USER");
				entity.Property((MpdBenefitsCchiHist e) => e.ModificationDate).HasColumnType("DATE").HasColumnName("MODIFICATION_DATE");
				entity.Property((MpdBenefitsCchiHist e) => e.ModificationUser).HasMaxLength(25).IsUnicode(unicode: false)
					.HasColumnName("MODIFICATION_USER");
				entity.Property((MpdBenefitsCchiHist e) => e.MpdBnfCchiId).HasPrecision(15).HasColumnName("MPD_BNF_CCHI_ID");
				entity.Property((MpdBenefitsCchiHist e) => e.Status).HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnName("STATUS");
				entity.Property((MpdBenefitsCchiHist e) => e.StatusDate).HasColumnType("DATE").HasColumnName("STATUS_DATE");
				entity.Property((MpdBenefitsCchiHist e) => e.StatusDesc).HasMaxLength(2000).IsUnicode(unicode: false)
					.HasColumnName("STATUS_DESC");
				entity.Property((MpdBenefitsCchiHist e) => e.TransactionType).HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnName("TRANSACTION_TYPE");
				entity.HasOne((MpdBenefitsCchiHist d) => d.MpdBnfCchi).WithMany((MpdBenefitsCchi p) => p.MpdBenefitsCchiHists).HasForeignKey((MpdBenefitsCchiHist d) => d.MpdBnfCchiId)
					.HasConstraintName("SYS_C002549995");
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<MpdCchiBenefitsMapping> entity)
			{
				entity.HasKey((MpdCchiBenefitsMapping e) => e.CchiBenefitId).HasName("SYS_C002555016");
				entity.ToTable("MPD_CCHI_BENEFITS_MAPPING");
				entity.Property((MpdCchiBenefitsMapping e) => e.CchiBenefitId).HasPrecision(15).ValueGeneratedNever()
					.HasColumnName("CCHI_BENEFIT_ID");
				entity.Property((MpdCchiBenefitsMapping e) => e.CchiBenefitName).HasMaxLength(200).IsUnicode(unicode: false)
					.HasColumnName("CCHI_BENEFIT_NAME");
				entity.Property((MpdCchiBenefitsMapping e) => e.CchiBenefitName2).HasMaxLength(200).IsUnicode(unicode: false)
					.HasColumnName("CCHI_BENEFIT_NAME2");
				entity.Property((MpdCchiBenefitsMapping e) => e.CchiDefaultValue).HasMaxLength(100).IsUnicode(unicode: false)
					.HasColumnName("CCHI_DEFAULT_VALUE");
				entity.Property((MpdCchiBenefitsMapping e) => e.ColumnName).HasMaxLength(200).IsUnicode(unicode: false)
					.HasColumnName("COLUMN_NAME");
				entity.Property((MpdCchiBenefitsMapping e) => e.EskaBenefitId).HasMaxLength(250).IsUnicode(unicode: false)
					.HasColumnName("ESKA_BENEFIT_ID");
				entity.Property((MpdCchiBenefitsMapping e) => e.EskaBenefitName).HasMaxLength(100).IsUnicode(unicode: false)
					.HasColumnName("ESKA_BENEFIT_NAME");
				entity.Property((MpdCchiBenefitsMapping e) => e.RecordLevel).HasPrecision(5).HasColumnName("RECORD_LEVEL");
				entity.Property((MpdCchiBenefitsMapping e) => e.TableName).HasMaxLength(200).IsUnicode(unicode: false)
					.HasColumnName("TABLE_NAME");
				entity.Property((MpdCchiBenefitsMapping e) => e.WhereClause).HasMaxLength(1000).IsUnicode(unicode: false)
					.HasColumnName("WHERE_CLAUSE");
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<MpdClassesCchiHist> entity)
			{
				entity.ToTable("MPD_CLASSES_CCHI_HIST");
				entity.HasIndex((MpdClassesCchiHist e) => e.Id).IsUnique();
				entity.Property((MpdClassesCchiHist e) => e.Id).HasPrecision(15).HasColumnName("ID");
					//.UseHiLo("MPD_CLASSES_CCHI_HIST_SEQ");
				entity.Property((MpdClassesCchiHist e) => e.CreationDate).HasColumnType("DATE").HasColumnName("CREATION_DATE");
				entity.Property((MpdClassesCchiHist e) => e.CreationUser).HasMaxLength(25).IsUnicode(unicode: false)
					.HasColumnName("CREATION_USER");
				entity.Property((MpdClassesCchiHist e) => e.ModificationDate).HasColumnType("DATE").HasColumnName("MODIFICATION_DATE");
				entity.Property((MpdClassesCchiHist e) => e.ModificationUser).HasMaxLength(25).IsUnicode(unicode: false)
					.HasColumnName("MODIFICATION_USER");
				entity.Property((MpdClassesCchiHist e) => e.MpdClsCchiId).HasPrecision(15).HasColumnName("MPD_CLS_CCHI_ID");
				entity.Property((MpdClassesCchiHist e) => e.Notes).HasMaxLength(2000).IsUnicode(unicode: false)
					.HasColumnName("NOTES");
				entity.Property((MpdClassesCchiHist e) => e.Status).HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnName("STATUS");
				entity.Property((MpdClassesCchiHist e) => e.StatusDate).HasColumnType("DATE").HasColumnName("STATUS_DATE");
				entity.Property((MpdClassesCchiHist e) => e.StatusDesc).HasMaxLength(1024).IsUnicode(unicode: false)
					.HasColumnName("STATUS_DESC");
				entity.Property((MpdClassesCchiHist e) => e.TransactionType).HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnName("TRANSACTION_TYPE");
				entity.HasOne((MpdClassesCchiHist d) => d.MpdClsCchi).WithMany((MpdClassesCchi p) => p.MpdClassesCchiHists).HasForeignKey((MpdClassesCchiHist d) => d.MpdClsCchiId)
					.HasConstraintName("SYS_C002552369");
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<MpdClassesCchi> entity)
			{
				entity.ToTable("MPD_CLASSES_CCHI");
				entity.HasIndex((MpdClassesCchi e) => e.Id).IsUnique();
				entity.Property((MpdClassesCchi e) => e.Id).HasPrecision(15).HasColumnName("ID");
					//.UseHiLo("MPD_CLS_CCHI_SEQ");
				entity.Property((MpdClassesCchi e) => e.CchiClassId).HasMaxLength(100).IsUnicode(unicode: false)
					.HasColumnName("CCHI_CLASS_ID");
				entity.Property((MpdClassesCchi e) => e.CchiPlanClass).HasMaxLength(3).IsUnicode(unicode: false)
					.HasColumnName("CCHI_PLAN_CLASS");
				entity.Property((MpdClassesCchi e) => e.ClassStatus).HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnName("CLASS_STATUS");
				entity.Property((MpdClassesCchi e) => e.ClassStatusDate).HasColumnType("DATE").HasColumnName("CLASS_STATUS_DATE");
				entity.Property((MpdClassesCchi e) => e.ClassStatusDesc).HasMaxLength(1024).IsUnicode(unicode: false)
					.HasColumnName("CLASS_STATUS_DESC");
				entity.Property((MpdClassesCchi e) => e.CoveredCountries).HasMaxLength(1000).IsUnicode(unicode: false)
					.HasColumnName("COVERED_COUNTRIES");
				entity.Property((MpdClassesCchi e) => e.CreationDate).HasColumnType("DATE").HasColumnName("CREATION_DATE");
				entity.Property((MpdClassesCchi e) => e.CreationUser).HasMaxLength(25).IsUnicode(unicode: false)
					.HasColumnName("CREATION_USER");
				entity.Property((MpdClassesCchi e) => e.HasBenefit).HasMaxLength(5).IsUnicode(unicode: false)
					.HasColumnName("HAS_BENEFIT");
				entity.Property((MpdClassesCchi e) => e.IntMaxDeductable).HasColumnType("NUMBER(18,3)").HasColumnName("INT_MAX_DEDUCTABLE");
				entity.Property((MpdClassesCchi e) => e.IsBenefit).HasMaxLength(5).IsUnicode(unicode: false)
					.HasColumnName("IS_BENEFIT");
				entity.Property((MpdClassesCchi e) => e.IsLocal).HasPrecision(5).HasColumnName("IS_LOCAL");
				entity.Property((MpdClassesCchi e) => e.IsStandard).HasPrecision(5).HasColumnName("IS_STANDARD");
				entity.Property((MpdClassesCchi e) => e.MaxCoverLimit).HasColumnType("NUMBER(18,3)").HasColumnName("MAX_COVER_LIMIT");
				entity.Property((MpdClassesCchi e) => e.ModificationDate).HasColumnType("DATE").HasColumnName("MODIFICATION_DATE");
				entity.Property((MpdClassesCchi e) => e.ModificationUser).HasMaxLength(25).IsUnicode(unicode: false)
					.HasColumnName("MODIFICATION_USER");
				entity.Property((MpdClassesCchi e) => e.MpdPclId).HasPrecision(15).HasColumnName("MPD_PCL_ID");
				entity.Property((MpdClassesCchi e) => e.MpdPlcCchiId).HasPrecision(15).HasColumnName("MPD_PLC_CCHI_ID");
				entity.Property((MpdClassesCchi e) => e.MpdPlcIdOrigin).HasPrecision(15).HasColumnName("MPD_PLC_ID_ORIGIN");
				entity.Property((MpdClassesCchi e) => e.MpnCopayment).HasColumnType("NUMBER(18,3)").HasColumnName("MPN_COPAYMENT");
				entity.Property((MpdClassesCchi e) => e.MpnDeductible).HasColumnType("NUMBER(18,3)").HasColumnName("MPN_DEDUCTIBLE");
				entity.Property((MpdClassesCchi e) => e.Name).HasMaxLength(100).IsUnicode(unicode: false)
					.HasColumnName("NAME");
				entity.Property((MpdClassesCchi e) => e.NetworkId).HasPrecision(15).HasColumnName("NETWORK_ID");
				entity.Property((MpdClassesCchi e) => e.OcnCopayment).HasColumnType("NUMBER(18,3)").HasColumnName("OCN_COPAYMENT");
				entity.Property((MpdClassesCchi e) => e.OcnDeductible).HasColumnType("NUMBER(18,3)").HasColumnName("OCN_DEDUCTIBLE");
				entity.Property((MpdClassesCchi e) => e.OhnCopayment).HasColumnType("NUMBER(18,3)").HasColumnName("OHN_COPAYMENT");
				entity.Property((MpdClassesCchi e) => e.OhnDeductible).HasColumnType("NUMBER(18,3)").HasColumnName("OHN_DEDUCTIBLE");
				entity.Property((MpdClassesCchi e) => e.PlanClass).HasMaxLength(3).IsUnicode(unicode: false)
					.HasColumnName("PLAN_CLASS");
				entity.Property((MpdClassesCchi e) => e.ReferenceNo).HasMaxLength(100).IsUnicode(unicode: false)
					.HasColumnName("REFERENCE_NO");
				entity.Property((MpdClassesCchi e) => e.RoomType).HasPrecision(5).HasColumnName("ROOM_TYPE");
				entity.Property((MpdClassesCchi e) => e.RoomTypeDesc).HasMaxLength(100).IsUnicode(unicode: false)
					.HasColumnName("ROOM_TYPE_DESC");
				entity.Property((MpdClassesCchi e) => e.StdStatus).HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnName("STD_STATUS");
				entity.Property((MpdClassesCchi e) => e.StdStatusDate).HasColumnType("DATE").HasColumnName("STD_STATUS_DATE");
				entity.Property((MpdClassesCchi e) => e.StdStatusDesc).HasMaxLength(1024).IsUnicode(unicode: false)
					.HasColumnName("STD_STATUS_DESC");
				entity.HasOne((MpdClassesCchi d) => d.MpdPlcCchi).WithMany((MpdPoliciesCchi p) => p.MpdClassesCchis).HasForeignKey((MpdClassesCchi d) => d.MpdPlcCchiId)
					.HasConstraintName("FK_MPD_CCHI_PLC_CLS_ID_FK");
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<MpdMembersCchi> entity)
			{
				entity.ToTable("MPD_MEMBERS_CCHI");
				entity.HasIndex((MpdMembersCchi e) => e.Id).IsUnique();
				entity.Property((MpdMembersCchi e) => e.Id).HasPrecision(15).HasColumnName("ID");
					//.UseHiLo("MPD_MEM_CCHI_SEQ");
				entity.Property((MpdMembersCchi e) => e.ActionType).HasPrecision(5).HasColumnName("ACTION_TYPE");
				entity.Property((MpdMembersCchi e) => e.Age).HasPrecision(5).HasColumnName("AGE");
				entity.Property((MpdMembersCchi e) => e.BirthDate).HasColumnType("DATE").HasColumnName("BIRTH_DATE");
				entity.Property((MpdMembersCchi e) => e.CancellationReason).HasPrecision(6).HasColumnName("CANCELLATION_REASON");
				entity.Property((MpdMembersCchi e) => e.CancellationReasonDesc).HasMaxLength(400).IsUnicode(unicode: false)
					.HasColumnName("CANCELLATION_REASON_DESC");
				entity.Property((MpdMembersCchi e) => e.CchiGrossPremium).HasColumnType("NUMBER(18,3)").HasColumnName("CCHI_GROSS_PREMIUM");
				entity.Property((MpdMembersCchi e) => e.ClassName).HasMaxLength(100).IsUnicode(unicode: false)
					.HasColumnName("CLASS_NAME");
				entity.Property((MpdMembersCchi e) => e.CreationDate).HasColumnType("DATE").HasColumnName("CREATION_DATE");
				entity.Property((MpdMembersCchi e) => e.CreationUser).HasMaxLength(25).IsUnicode(unicode: false)
					.HasColumnName("CREATION_USER");
				entity.Property((MpdMembersCchi e) => e.CrgCntCode).HasMaxLength(10).IsUnicode(unicode: false)
					.HasColumnName("CRG_CNT_CODE");
				entity.Property((MpdMembersCchi e) => e.EffectiveDate).HasColumnType("DATE").HasColumnName("EFFECTIVE_DATE");
				entity.Property((MpdMembersCchi e) => e.Email).HasMaxLength(100).IsUnicode(unicode: false)
					.HasColumnName("EMAIL");
				entity.Property((MpdMembersCchi e) => e.ExpiryDate).HasColumnType("DATE").HasColumnName("EXPIRY_DATE");
				entity.Property((MpdMembersCchi e) => e.FcsCstId).HasPrecision(15).HasColumnName("FCS_CST_ID");
				entity.Property((MpdMembersCchi e) => e.Gender).HasPrecision(5).HasColumnName("GENDER");
				entity.Property((MpdMembersCchi e) => e.GrossPremium).HasColumnType("NUMBER(18,3)").HasColumnName("GROSS_PREMIUM");
				entity.Property((MpdMembersCchi e) => e.CchiId).HasMaxLength(250).IsUnicode(unicode: false)
					.HasColumnName("CCHI_ID");
				entity.Property((MpdMembersCchi e) => e.HijriBirthDate).HasColumnType("DATE").HasColumnName("HIJRI_BIRTH_DATE");
				entity.Property((MpdMembersCchi e) => e.IdentityExpiryDate).HasColumnType("DATE").HasColumnName("IDENTITY_EXPIRY_DATE");
				entity.Property((MpdMembersCchi e) => e.IsUploaded).HasPrecision(5).HasColumnName("IS_UPLOADED");
				entity.Property((MpdMembersCchi e) => e.MaritalStatus).HasPrecision(5).HasColumnName("MARITAL_STATUS");
				entity.Property((MpdMembersCchi e) => e.MemberNo).HasPrecision(15).HasColumnName("MEMBER_NO");
				entity.Property((MpdMembersCchi e) => e.Mobile).HasMaxLength(45).IsUnicode(unicode: false)
					.HasColumnName("MOBILE");
				entity.Property((MpdMembersCchi e) => e.ModificationDate).HasColumnType("DATE").HasColumnName("MODIFICATION_DATE");
				entity.Property((MpdMembersCchi e) => e.ModificationUser).HasMaxLength(25).IsUnicode(unicode: false)
					.HasColumnName("MODIFICATION_USER");
				entity.Property((MpdMembersCchi e) => e.MpdMbrId).HasPrecision(15).HasColumnName("MPD_MBR_ID");
				entity.Property((MpdMembersCchi e) => e.MpdMbrIdRelation).HasPrecision(15).HasColumnName("MPD_MBR_ID_RELATION");
				entity.Property((MpdMembersCchi e) => e.MpdPclId).HasPrecision(15).HasColumnName("MPD_PCL_ID");
				entity.Property((MpdMembersCchi e) => e.MpdPlcIdOrigin).HasPrecision(15).HasColumnName("MPD_PLC_ID_ORIGIN");
				entity.Property((MpdMembersCchi e) => e.MpdPlcCchiId).HasPrecision(15).HasColumnName("MPD_PLC_CCHI_ID");
				entity.Property((MpdMembersCchi e) => e.MpdPlcId).HasPrecision(15).HasColumnName("MPD_PLC_ID");
				entity.Property((MpdMembersCchi e) => e.MpdPlmId).HasPrecision(15).HasColumnName("MPD_PLM_ID");
				entity.Property((MpdMembersCchi e) => e.Name).HasMaxLength(200).IsUnicode(unicode: false)
					.HasColumnName("NAME");
				entity.Property((MpdMembersCchi e) => e.NationalId).HasMaxLength(25).IsUnicode(unicode: false)
					.HasColumnName("NATIONAL_ID");
				entity.Property((MpdMembersCchi e) => e.Nationality).HasMaxLength(100).IsUnicode(unicode: false)
					.HasColumnName("NATIONALITY");
				entity.Property((MpdMembersCchi e) => e.NationalityId).HasPrecision(8).HasColumnName("NATIONALITY_ID");
				entity.Property((MpdMembersCchi e) => e.Occupation).HasMaxLength(1000).IsUnicode(unicode: false)
					.HasColumnName("OCCUPATION");
				entity.Property((MpdMembersCchi e) => e.OnHold).HasPrecision(5).HasColumnName("ON_HOLD");
				entity.Property((MpdMembersCchi e) => e.ParentSegmentCode).HasMaxLength(25).IsUnicode(unicode: false)
					.HasColumnName("PARENT_SEGMENT_CODE");
				entity.Property((MpdMembersCchi e) => e.PhoneNo).HasMaxLength(45).IsUnicode(unicode: false)
					.HasColumnName("PHONE_NO");
				entity.Property((MpdMembersCchi e) => e.PrincipleName).HasMaxLength(100).IsUnicode(unicode: false)
					.HasColumnName("PRINCIPLE_NAME");
				entity.Property((MpdMembersCchi e) => e.Relation).HasPrecision(5).HasColumnName("RELATION");
				entity.Property((MpdMembersCchi e) => e.SegmentCode).HasMaxLength(25).IsUnicode(unicode: false)
					.HasColumnName("SEGMENT_CODE");
				entity.Property((MpdMembersCchi e) => e.SeqNo).HasPrecision(15).HasColumnName("SEQ_NO");
				entity.Property((MpdMembersCchi e) => e.SponserName).HasMaxLength(200).IsUnicode(unicode: false)
					.HasColumnName("SPONSER_NAME");
				entity.Property((MpdMembersCchi e) => e.SponserNo).HasMaxLength(100).IsUnicode(unicode: false)
					.HasColumnName("SPONSER_NO");
				entity.Property((MpdMembersCchi e) => e.StaffNo).HasMaxLength(60).IsUnicode(unicode: false)
					.HasColumnName("STAFF_NO");
				entity.Property((MpdMembersCchi e) => e.Status).HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnName("STATUS");
				entity.Property((MpdMembersCchi e) => e.StatusDate).HasColumnType("DATE").HasColumnName("STATUS_DATE");
				entity.Property((MpdMembersCchi e) => e.StatusDesc).HasMaxLength(1024).IsUnicode(unicode: false)
					.HasColumnName("STATUS_DESC");
				entity.HasOne((MpdMembersCchi d) => d.MpdPlcCchi).WithMany((MpdPoliciesCchi p) => p.MpdMembersCchis).HasForeignKey((MpdMembersCchi d) => d.MpdPlcCchiId)
					.HasConstraintName("SYS_C002533509");
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<MpdMembersCchiHist> entity)
			{
				entity.ToTable("MPD_MEMBERS_CCHI_HIST");
				entity.HasIndex((MpdMembersCchiHist e) => e.Id).IsUnique();
				entity.Property((MpdMembersCchiHist e) => e.Id).HasPrecision(15).HasColumnName("ID");
					//.UseHiLo("MPD_MEM_CCHI_HIST_SEQ");
				entity.Property((MpdMembersCchiHist e) => e.CreationDate).HasColumnType("DATE").HasColumnName("CREATION_DATE");
				entity.Property((MpdMembersCchiHist e) => e.CreationUser).HasMaxLength(25).IsUnicode(unicode: false)
					.HasColumnName("CREATION_USER");
				entity.Property((MpdMembersCchiHist e) => e.ModificationDate).HasColumnType("DATE").HasColumnName("MODIFICATION_DATE");
				entity.Property((MpdMembersCchiHist e) => e.ModificationUser).HasMaxLength(25).IsUnicode(unicode: false)
					.HasColumnName("MODIFICATION_USER");
				entity.Property((MpdMembersCchiHist e) => e.MpdMemCchiId).HasPrecision(15).HasColumnName("MPD_MEM_CCHI_ID");
				entity.Property((MpdMembersCchiHist e) => e.Notes).HasMaxLength(2000).IsUnicode(unicode: false)
					.HasColumnName("NOTES");
				entity.Property((MpdMembersCchiHist e) => e.Status).HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnName("STATUS");
				entity.Property((MpdMembersCchiHist e) => e.StatusDate).HasColumnType("DATE").HasColumnName("STATUS_DATE");
				entity.Property((MpdMembersCchiHist e) => e.StatusDesc).HasMaxLength(2000).IsUnicode(unicode: false)
					.HasColumnName("STATUS_DESC");
				entity.Property((MpdMembersCchiHist e) => e.TransactionType).HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnName("TRANSACTION_TYPE");
				entity.HasOne((MpdMembersCchiHist d) => d.MpdMemCchi).WithMany((MpdMembersCchi p) => p.MpdMembersCchiHists).HasForeignKey((MpdMembersCchiHist d) => d.MpdMemCchiId)
					.HasConstraintName("SYS_C002533513");
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<MpdPoliciesCchi> entity)
			{
				entity.ToTable("MPD_POLICIES_CCHI");
				entity.HasIndex((MpdPoliciesCchi e) => e.Id).IsUnique();
				entity.Property((MpdPoliciesCchi e) => e.Id).HasPrecision(15).HasColumnName("ID");
					//.UseHiLo("MPD_POL_CCHI_SEQ");
				entity.Property((MpdPoliciesCchi e) => e.BranchName).HasMaxLength(300).IsUnicode(unicode: false)
					.HasColumnName("BRANCH_NAME");
				entity.Property((MpdPoliciesCchi e) => e.BusinessType).HasPrecision(15).HasColumnName("BUSINESS_TYPE");
				entity.Property((MpdPoliciesCchi e) => e.CchiId).HasMaxLength(250).IsUnicode(unicode: false)
					.HasColumnName("CCHI_ID");
				entity.Property((MpdPoliciesCchi e) => e.CchiPolicyNo).HasMaxLength(250).IsUnicode(unicode: false)
					.HasColumnName("CCHI_POLICY_NO");
				entity.Property((MpdPoliciesCchi e) => e.CreationDate).HasColumnType("DATE").HasColumnName("CREATION_DATE");
				entity.Property((MpdPoliciesCchi e) => e.CreationUser).HasMaxLength(80).IsUnicode(unicode: false)
					.HasColumnName("CREATION_USER");
				entity.Property((MpdPoliciesCchi e) => e.CrgBrnId).HasPrecision(15).HasColumnName("CRG_BRN_ID");
				entity.Property((MpdPoliciesCchi e) => e.CustomerNationalId).HasMaxLength(250).IsUnicode(unicode: false)
					.HasColumnName("CUSTOMER_NATIONAL_ID");
				entity.Property((MpdPoliciesCchi e) => e.DocumentType).HasPrecision(5).HasColumnName("DOCUMENT_TYPE");
				entity.Property((MpdPoliciesCchi e) => e.EffectiveDate).HasColumnType("DATE").HasColumnName("EFFECTIVE_DATE");
				entity.Property((MpdPoliciesCchi e) => e.EndtNo).HasPrecision(15).HasColumnName("ENDT_NO");
				entity.Property((MpdPoliciesCchi e) => e.ExpiryDate).HasColumnType("DATE").HasColumnName("EXPIRY_DATE");
				entity.Property((MpdPoliciesCchi e) => e.FcsCstId).HasPrecision(15).HasColumnName("FCS_CST_ID");
				entity.Property((MpdPoliciesCchi e) => e.Flag).HasPrecision(5).HasColumnName("FLAG");
				entity.Property((MpdPoliciesCchi e) => e.GrossPremium).HasColumnType("NUMBER(18,5)").HasColumnName("GROSS_PREMIUM");
				entity.Property((MpdPoliciesCchi e) => e.IsPosted).HasPrecision(5).HasColumnName("IS_POSTED");
				entity.Property((MpdPoliciesCchi e) => e.IssueDate).HasColumnType("DATE").HasColumnName("ISSUE_DATE");
				entity.Property((MpdPoliciesCchi e) => e.ModificationDate).HasColumnType("DATE").HasColumnName("MODIFICATION_DATE");
				entity.Property((MpdPoliciesCchi e) => e.ModificationUser).HasMaxLength(80).IsUnicode(unicode: false)
					.HasColumnName("MODIFICATION_USER");
				entity.Property((MpdPoliciesCchi e) => e.MpdPlcId).HasPrecision(15).HasColumnName("MPD_PLC_ID");
				entity.Property((MpdPoliciesCchi e) => e.MpdPlcIdOrigin).HasPrecision(15).HasColumnName("MPD_PLC_ID_ORIGIN");
				entity.Property((MpdPoliciesCchi e) => e.MpdPlnId).HasPrecision(15).HasColumnName("MPD_PLN_ID");
				entity.Property((MpdPoliciesCchi e) => e.MstNdtId).HasPrecision(5).HasColumnName("MST_NDT_ID");
				entity.Property((MpdPoliciesCchi e) => e.NoOfEndt).HasPrecision(15).HasColumnName("NO_OF_ENDT");
				entity.Property((MpdPoliciesCchi e) => e.PlanName).HasMaxLength(300).IsUnicode(unicode: false)
					.HasColumnName("PLAN_NAME");
				entity.Property((MpdPoliciesCchi e) => e.PolicyHolder).HasMaxLength(300).IsUnicode(unicode: false)
					.HasColumnName("POLICY_HOLDER");
				entity.Property((MpdPoliciesCchi e) => e.PolicyNo).HasColumnType("NUMBER(20)").HasColumnName("POLICY_NO");
				entity.Property((MpdPoliciesCchi e) => e.PolicyType).HasPrecision(5).HasColumnName("POLICY_TYPE");
				entity.Property((MpdPoliciesCchi e) => e.Priority).HasPrecision(5).HasColumnName("PRIORITY");
				entity.Property((MpdPoliciesCchi e) => e.SalesmanCode).HasMaxLength(300).IsUnicode(unicode: false)
					.HasColumnName("SALESMAN_CODE");
				entity.Property((MpdPoliciesCchi e) => e.SalesmanName).HasMaxLength(300).IsUnicode(unicode: false)
					.HasColumnName("SALESMAN_NAME");
				entity.Property((MpdPoliciesCchi e) => e.SegmentCode).HasMaxLength(100).IsUnicode(unicode: false)
					.HasColumnName("SEGMENT_CODE");
				entity.Property((MpdPoliciesCchi e) => e.Status).HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnName("STATUS");
				entity.Property((MpdPoliciesCchi e) => e.StatusDate).HasColumnType("DATE").HasColumnName("STATUS_DATE");
				entity.Property((MpdPoliciesCchi e) => e.StatusDesc).HasMaxLength(1024).IsUnicode(unicode: false)
					.HasColumnName("STATUS_DESC");
				entity.Property((MpdPoliciesCchi e) => e.TransactionType).HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnName("TRANSACTION_TYPE");
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<MpdPoliciesCchiHist> entity)
			{
				entity.ToTable("MPD_POLICIES_CCHI_HIST");
				entity.HasIndex((MpdPoliciesCchiHist e) => e.Id).IsUnique();
				entity.Property((MpdPoliciesCchiHist e) => e.Id).HasPrecision(15).HasColumnName("ID");
					//.UseHiLo("MPD_POL_CCHI_HIST_SEQ");
				entity.Property((MpdPoliciesCchiHist e) => e.CreationDate).HasColumnType("DATE").HasColumnName("CREATION_DATE");
				entity.Property((MpdPoliciesCchiHist e) => e.CreationUser).HasMaxLength(25).IsUnicode(unicode: false)
					.HasColumnName("CREATION_USER");
				entity.Property((MpdPoliciesCchiHist e) => e.ModificationDate).HasColumnType("DATE").HasColumnName("MODIFICATION_DATE");
				entity.Property((MpdPoliciesCchiHist e) => e.ModificationUser).HasMaxLength(25).IsUnicode(unicode: false)
					.HasColumnName("MODIFICATION_USER");
				entity.Property((MpdPoliciesCchiHist e) => e.MpdPlcCchiId).HasPrecision(15).HasColumnName("MPD_PLC_CCHI_ID");
				entity.Property((MpdPoliciesCchiHist e) => e.Notes).HasMaxLength(2000).IsUnicode(unicode: false)
					.HasColumnName("NOTES");
				entity.Property((MpdPoliciesCchiHist e) => e.Status).HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnName("STATUS");
				entity.Property((MpdPoliciesCchiHist e) => e.StatusDate).HasColumnType("DATE").HasColumnName("STATUS_DATE");
				entity.Property((MpdPoliciesCchiHist e) => e.StatusDesc).HasMaxLength(1024).IsUnicode(unicode: false)
					.HasColumnName("STATUS_DESC");
				entity.Property((MpdPoliciesCchiHist e) => e.TransactionType).HasMaxLength(50).IsUnicode(unicode: false)
					.HasColumnName("TRANSACTION_TYPE");
				entity.HasOne((MpdPoliciesCchiHist d) => d.MpdPlcCchi).WithMany((MpdPoliciesCchi p) => p.MpdPoliciesCchiHists).HasForeignKey((MpdPoliciesCchiHist d) => d.MpdPlcCchiId)
					.HasConstraintName("SYS_C002533501");
			});
			modelBuilder.Entity(delegate(EntityTypeBuilder<MpdSponsorsCchi> entity)
			{
				entity.ToTable("MPD_SPONSORS_CCHI");
				entity.HasIndex((MpdSponsorsCchi e) => e.Id).IsUnique();
				entity.Property((MpdSponsorsCchi e) => e.Id).HasPrecision(15).HasColumnName("ID");
					//.UseHiLo("MPD_SPON_CCHI_SEQ");
				entity.Property((MpdSponsorsCchi e) => e.City).HasMaxLength(100).IsUnicode(unicode: false)
					.HasColumnName("CITY");
				entity.Property((MpdSponsorsCchi e) => e.CreationDate).HasColumnType("DATE").HasColumnName("CREATION_DATE");
				entity.Property((MpdSponsorsCchi e) => e.CreationUser).HasMaxLength(25).IsUnicode(unicode: false)
					.HasColumnName("CREATION_USER");
				entity.Property((MpdSponsorsCchi e) => e.Email).HasMaxLength(100).IsUnicode(unicode: false)
					.HasColumnName("EMAIL");
				entity.Property((MpdSponsorsCchi e) => e.IsDefault).HasPrecision(5).HasColumnName("IS_DEFAULT");
				entity.Property((MpdSponsorsCchi e) => e.MobileNo).HasMaxLength(45).IsUnicode(unicode: false)
					.HasColumnName("MOBILE_NO");
				entity.Property((MpdSponsorsCchi e) => e.ModificationDate).HasColumnType("DATE").HasColumnName("MODIFICATION_DATE");
				entity.Property((MpdSponsorsCchi e) => e.ModificationUser).HasMaxLength(25).IsUnicode(unicode: false)
					.HasColumnName("MODIFICATION_USER");
				entity.Property((MpdSponsorsCchi e) => e.MpdPlcCchiId).HasPrecision(15).HasColumnName("MPD_PLC_CCHI_ID");
				entity.Property((MpdSponsorsCchi e) => e.MpdPlcIdOrigin).HasPrecision(15).HasColumnName("MPD_PLC_ID_ORIGIN");
				entity.Property((MpdSponsorsCchi e) => e.Name).HasMaxLength(100).IsUnicode(unicode: false)
					.HasColumnName("NAME");
				entity.Property((MpdSponsorsCchi e) => e.PhoneNo).HasMaxLength(45).IsUnicode(unicode: false)
					.HasColumnName("PHONE_NO");
				entity.Property((MpdSponsorsCchi e) => e.RegistryNo).HasMaxLength(100).IsUnicode(unicode: false)
					.HasColumnName("REGISTRY_NO");
				entity.Property((MpdSponsorsCchi e) => e.RegistryType).HasPrecision(15).HasColumnName("REGISTRY_TYPE");
				entity.Property((MpdSponsorsCchi e) => e.SponsorNo).HasMaxLength(100).IsUnicode(unicode: false)
					.HasColumnName("SPONSOR_NO");
				entity.HasOne((MpdSponsorsCchi d) => d.MpdPlcCchi).WithMany((MpdPoliciesCchi p) => p.MpdSponsorsCchis).HasForeignKey((MpdSponsorsCchi d) => d.MpdPlcCchiId)
					.HasConstraintName("SYS_C002533511");
			});
			modelBuilder.HasSequence("MNT_NET_CCHI_HIST_SEQ").IncrementsBy(1);
			modelBuilder.HasSequence("MNT_NET_CCHI_SEQ").IncrementsBy(1);
			modelBuilder.HasSequence("MNT_PRV_NET_CCHI_HIST_SEQ").IncrementsBy(1);
			modelBuilder.HasSequence("MNT_PRV_NET_CCHI_SEQ").IncrementsBy(1);
			modelBuilder.HasSequence("MPD_BENEFITS_CCHI_HIST_SEQ").IncrementsBy(1);
			modelBuilder.HasSequence("MPD_BENEFITS_CCHI_SEQ").IncrementsBy(1);
			modelBuilder.HasSequence("MPD_CLASSES_CCHI_HIST_SEQ").IncrementsBy(1);
			modelBuilder.HasSequence("MPD_CLS_CCHI_SEQ").IncrementsBy(1);
			modelBuilder.HasSequence("MPD_MEM_CCHI_HIST_SEQ").IncrementsBy(1);
			modelBuilder.HasSequence("MPD_MEM_CCHI_SEQ").IncrementsBy(1);
			modelBuilder.HasSequence("MPD_POL_CCHI_HIST_SEQ").IncrementsBy(1);
			modelBuilder.HasSequence("MPD_POL_CCHI_SEQ").IncrementsBy(1);
			modelBuilder.HasSequence("MPD_SPON_CCHI_SEQ").IncrementsBy(1);
		}
	}
}
