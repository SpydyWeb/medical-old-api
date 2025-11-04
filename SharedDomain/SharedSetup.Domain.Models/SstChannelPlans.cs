using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_CHANNEL_PLANS")]
	public class SstChannelPlans : BaseModel
	{
		[Column("BUSINESS_CHANNEL")]
		public long BusinessChannel { get; set; }

		[Column("POLICY_TYPE")]
		public long PolicyType { get; set; }

		[ForeignKey("BusinessChannel")]
		[InverseProperty("SstChannelPlans")]
		public virtual SstBusinessChannels BusinessChannelNavigation { get; set; }

		[ForeignKey("PolicyType")]
		[InverseProperty("SstChannelPlans")]
		public virtual SstPolicyTypes PolicyTypeNavigation { get; set; }
	}
}
