using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_COMMISSION_DETAILS")]
	public class SstCommissionDetails : BaseModel
	{
		[NotMapped]
		public string CommissionTypeName { get; set; }

		[NotMapped]
		public string BranchName { get; set; }

		[NotMapped]
		public string InsuranceClassName { get; set; }

		[NotMapped]
		public string PolicyTypeName { get; set; }

		[NotMapped]
		public string PositionName { get; set; }

		[Column("BRANCH")]
		public long? Branch { get; set; }

		[Column("CLASS_ID")]
		public long ClassId { get; set; }

		[Column("POLICY_TYPE")]
		public long? PolicyType { get; set; }

		[Column("CALCULATION_BASIS")]
		public byte CalculationBasis { get; set; }

		[Column("POSITION")]
		public long Position { get; set; }

		[Column("BUSINESSS_CHANNEL")]
		public long? BusinesssChannel { get; set; }

		[Column("CALCULATION_TYPE")]
		public byte CalculationType { get; set; }

		[Column("VALID_FROM")]
		public DateTime ValidFrom { get; set; }

		[Column("VALID_TO")]
		public DateTime? ValidTo { get; set; }

		[Column("TARGET_TYPE")]
		public byte? TargetType { get; set; }

		[Column("TARGET")]
		public decimal? Target { get; set; }

		[Column("TARGET_INCLUSION")]
		public byte? TargetInclusion { get; set; }

		[Column("TERM_BASIS")]
		public byte? TermBasis { get; set; }

		[Column("PAYMENT_TERMS")]
		public byte PaymentTerms { get; set; }

		[Column("DATA_ACCORDANCE")]
		public byte DataAccordance { get; set; }

		[Column("COMMISSION_ID")]
		public long CommissionId { get; set; }

		[ForeignKey("ClassId")]
		[InverseProperty("SstCommissionDetails")]
		public virtual SstClasses Class { get; set; }

		[ForeignKey("CommissionId")]
		[InverseProperty("SstCommissionDetails")]
		public virtual SstCommissionTypes Commission { get; set; }

		[ForeignKey("PolicyType")]
		[InverseProperty("SstCommissionDetails")]
		public virtual SstPolicyTypes PolicyTypeNavigation { get; set; }

		[InverseProperty("CommissionDtl")]
		public virtual ICollection<SstCommissionTiers> SstCommissionTiers { get; set; }

		public SstCommissionDetails()
		{
			SstCommissionTiers = new HashSet<SstCommissionTiers>();
		}
	}
}
