using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SPD_SEQUENCES_DETAILS")]
	public class SpdSequencesDetails : BaseModel
	{
		[Column("ORDER")]
		public byte? Order { get; set; }

		[Column("INTEGRATION_ID")]
		public long? IntegrationId { get; set; }

		[Column("SEQUENCE_ID")]
		public long? SequenceId { get; set; }

		[ForeignKey("IntegrationId")]
		[InverseProperty("SpdSequencesDetails")]
		public virtual SstIntegrations Integration { get; set; }

		[ForeignKey("SequenceId")]
		[InverseProperty("SpdSequencesDetails")]
		public virtual SpdSequences Sequence { get; set; }
	}
}
