using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_CUSTOMER_TYPES")]
	public class SstCustomerTypes : BaseModel
	{
		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[InverseProperty("CustomerTypeNavigation")]
		public virtual ICollection<SstChannelTypes> SstChannelTypes { get; set; }

		public SstCustomerTypes()
		{
			SstChannelTypes = new HashSet<SstChannelTypes>();
		}
	}
}
