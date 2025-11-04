using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_AGENT_STRUCTURES")]
	public class SstAgentStructures : BaseModel
	{
		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("VALID_FROM")]
		public DateTime ValidFrom { get; set; }

		[Column("VALID_TO")]
		public DateTime? ValidTo { get; set; }

		[Column("PARENT_ID")]
		public long? ParentId { get; set; }

		[Column("BUSINESS_CHANNEL")]
		public long? BusinessChannel { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[ForeignKey("BusinessChannel")]
		[InverseProperty("SstAgentStructures")]
		public virtual SstBusinessChannels BusinessChannelNavigation { get; set; }

		[ForeignKey("ParentId")]
		[InverseProperty("InverseParent")]
		public virtual SstAgentStructures Parent { get; set; }

		[InverseProperty("Parent")]
		public virtual ICollection<SstAgentStructures> InverseParent { get; set; }

		[InverseProperty("PositionNavigation")]
		public virtual ICollection<SstAgents> SstAgents { get; set; }

		public SstAgentStructures()
		{
			InverseParent = new HashSet<SstAgentStructures>();
			SstAgents = new HashSet<SstAgents>();
		}
	}
}
