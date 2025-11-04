using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_CLAUSES_DETAILS")]
	public class SstClausesDetails : BaseModel
	{
		[NotMapped]
		public string ClauseTypeName { get; set; }

		[NotMapped]
		public string ClauseName { get; set; }

		[NotMapped]
		public string InsuranceClass { get; set; }

		[NotMapped]
		public string CoverTypeName { get; set; }

		[NotMapped]
		public string DiscountName { get; set; }

		[Column("CLAUSE_TYPE")]
		public byte ClauseType { get; set; }

		[Column("ORDER")]
		public byte Order { get; set; }

		[Column("COVER_TYPE")]
		public long? CoverType { get; set; }

		[Column("DISCOUNT_TYPE")]
		public long? DiscountType { get; set; }

		[Column("EFFECTIVE_DATE")]
		public DateTime EffectiveDate { get; set; }

		[Column("EXPIRY_DATE")]
		public DateTime? ExpiryDate { get; set; }

		[Required]
		[Column("DESCRIPTION")]
		public string Description { get; set; }

		[Column("DESCRIPTION2")]
		public string Description2 { get; set; }

		[Column("CLAUSE_ID")]
		public long ClauseId { get; set; }

		[Column("AGENT_ID")]
		public long? AgentId { get; set; }

		[Column("AGENT_NAME")]
		public string AgentName { get; set; }

		[ForeignKey("ClauseId")]
		[InverseProperty("SstClausesDetails")]
		public virtual SstClauses Clause { get; set; }
	}
}
