using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_EPAYMENT_METHODS")]
	public class SstEpaymentMethods : BaseModel
	{
		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("NOTES")]
		public string Notes { get; set; }

		[Column("SYSTEM_ID")]
		public long SystemId { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[ForeignKey("SystemId")]
		[InverseProperty("SstEpaymentMethods")]
		public virtual SstSystems System { get; set; }

		[InverseProperty("Payment")]
		public virtual ICollection<SstEpaymentAlerts> SstEpaymentAlerts { get; set; }

		[InverseProperty("Payment")]
		public virtual ICollection<SstEpaymentDetails> SstEpaymentDetails { get; set; }

		public SstEpaymentMethods()
		{
			SstEpaymentAlerts = new HashSet<SstEpaymentAlerts>();
			SstEpaymentDetails = new HashSet<SstEpaymentDetails>();
		}
	}
}
