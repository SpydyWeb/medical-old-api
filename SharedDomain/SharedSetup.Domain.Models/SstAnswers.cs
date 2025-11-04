using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_ANSWERS")]
	public class SstAnswers : BaseModel
	{
		[NotMapped]
		public string OperatorName { get; set; }

		[NotMapped]
		public string ActionName { get; set; }

		[NotMapped]
		public string EditableName { get; set; }

		[NotMapped]
		public string LoadingAmtAndPer { get; set; }

		[NotMapped]
		public string DiscountAmtAndPer { get; set; }

		[NotMapped]
		public string NRPAmtAndPer { get; set; }

		[Column("QUEST_DETAIL_ID")]
		public long QuestDetailId { get; set; }

		[Column("OPERATOR")]
		public short Operator { get; set; }

		[Column("COMPARISON_VALUES")]
		public string ComparisonValues { get; set; }

		[Column("TO_COMPARISON_VALUES")]
		public string ToComparisonValues { get; set; }

		[Column("ACTION")]
		public short Action { get; set; }

		[Column("TARGET")]
		public string Target { get; set; }

		[Column("ADJUSTMENT_RATE")]
		public decimal? AdjustmentRate { get; set; }

		[Column("LOADING_PER")]
		public decimal? LoadingPer { get; set; }

		[Column("LOADING_AMT")]
		public decimal? LoadingAmt { get; set; }

		[Column("DISCOUNT_PER")]
		public decimal? DiscountPer { get; set; }

		[Column("DISCOUNT_AMT")]
		public decimal? DiscountAmt { get; set; }

		[Column("NRP_PER")]
		public decimal? NrpPer { get; set; }

		[Column("NRP_AMT")]
		public decimal? NrpAmt { get; set; }

		[Column("EXCESS_PER")]
		public decimal? ExcessPer { get; set; }

		[Column("EDITABLE")]
		public short? Editable { get; set; }

		[ForeignKey("QuestDetailId")]
		[InverseProperty("SstAnswers")]
		public virtual SstQuestDetails QuestDetail { get; set; }
	}
}
