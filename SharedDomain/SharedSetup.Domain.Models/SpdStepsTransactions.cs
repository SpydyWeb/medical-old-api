using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SPD_STEPS_TRANSACTIONS")]
	public class SpdStepsTransactions : BaseModel
	{
		[Column("TRANSACTION_TYPE")]
		public byte? TransactionType { get; set; }

		[Column("ORDER")]
		public byte? Order { get; set; }

		[Column("INTEGRATION_ID")]
		public long? IntegrationId { get; set; }

		[Column("STEP_ID")]
		public long? StepId { get; set; }

		[ForeignKey("IntegrationId")]
		[InverseProperty("SpdStepsTransactions")]
		public virtual SstIntegrations Integration { get; set; }

		[ForeignKey("StepId")]
		[InverseProperty("SpdStepsTransactions")]
		public virtual SpdProductsSteps Step { get; set; }
	}
}
