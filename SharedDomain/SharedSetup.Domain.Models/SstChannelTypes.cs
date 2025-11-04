using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_CHANNEL_TYPES")]
	public class SstChannelTypes : BaseModel
	{
		[Column("BUSINESS_CHANNEL")]
		public long BusinessChannel { get; set; }

		[Column("CUSTOMER_TYPE")]
		public long CustomerType { get; set; }

		[ForeignKey("BusinessChannel")]
		[InverseProperty("SstChannelTypes")]
		public virtual SstBusinessChannels BusinessChannelNavigation { get; set; }

		[ForeignKey("CustomerType")]
		[InverseProperty("SstChannelTypes")]
		public virtual SstCustomerTypes CustomerTypeNavigation { get; set; }
	}
}
