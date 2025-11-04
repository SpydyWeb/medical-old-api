using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_INTEGRATIONS")]
	public class SstIntegrations : BaseModel
	{
		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("SOURCE_TYPE")]
		public byte? SourceType { get; set; }

		[Column("NOTES")]
		public string Notes { get; set; }

		[Column("SYSTEM_ID")]
		public long? SystemId { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[ForeignKey("SystemId")]
		[InverseProperty("SstIntegrations")]
		public virtual SstSystems System { get; set; }

		[InverseProperty("Integration")]
		public virtual ICollection<SpdSequencesDetails> SpdSequencesDetails { get; set; }

		[InverseProperty("Integration")]
		public virtual ICollection<SpdStepsTransactions> SpdStepsTransactions { get; set; }

		[InverseProperty("Integration")]
		public virtual ICollection<SstIntegrationsSettings> SstIntegrationsSettings { get; set; }

		public SstIntegrations()
		{
			SpdSequencesDetails = new HashSet<SpdSequencesDetails>();
			SpdStepsTransactions = new HashSet<SpdStepsTransactions>();
			SstIntegrationsSettings = new HashSet<SstIntegrationsSettings>();
		}
	}
}
