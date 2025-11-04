using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_BUSINESS_CHANNELS")]
	public class SstBusinessChannels : BaseModel
	{
		[NotMapped]
		public string InsuranceSystemName { get; set; }

		[NotMapped]
		public IEnumerable<long> RoleIds { get; set; }

		[NotMapped]
		public bool IsDirect { get; set; }

		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("ORDER")]
		public byte? Order { get; set; }

		[Column("SYSTEM_ID")]
		public long SystemId { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[ForeignKey("SystemId")]
		[InverseProperty("SstBusinessChannels")]
		public virtual SstSystems System { get; set; }

		[InverseProperty("BusinessChannelNavigation")]
		public virtual ICollection<SstAgentStructures> SstAgentStructures { get; set; }

		[InverseProperty("ChannelTypeNavigation")]
		public virtual ICollection<SstAgents> SstAgents { get; set; }

		[InverseProperty("BusinessChannelNavigation")]
		public virtual ICollection<SstChannelPlans> SstChannelPlans { get; set; }

		[InverseProperty("BusinessChannelNavigation")]
		public virtual ICollection<SstChannelTypes> SstChannelTypes { get; set; }

		[InverseProperty("BusinessChannelNavigation")]
		public virtual ICollection<SstSegments> SstSegments { get; set; }

		[InverseProperty("BusinessChannelNavigation")]
		public virtual ICollection<SstSerialLists> SstSerialLists { get; set; }

		public SstBusinessChannels()
		{
			SstAgentStructures = new HashSet<SstAgentStructures>();
			SstAgents = new HashSet<SstAgents>();
			SstChannelPlans = new HashSet<SstChannelPlans>();
			SstChannelTypes = new HashSet<SstChannelTypes>();
			SstSegments = new HashSet<SstSegments>();
			SstSerialLists = new HashSet<SstSerialLists>();
		}
	}
}
