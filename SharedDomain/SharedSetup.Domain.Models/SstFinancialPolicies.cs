using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_FINANCIAL_POLICIES")]
	public class SstFinancialPolicies : BaseModel
	{
		[Required]
		[Column("POLICY_NO")]
		public string PolicyNo { get; set; }

		[Column("EFFECTIVE_DATE")]
		public DateTime EffectiveDate { get; set; }

		[Column("EXPIRY_DATE")]
		public DateTime ExpiryDate { get; set; }

		[Column("APPLICATION_ID")]
		public long? ApplicationId { get; set; }

		[Column("DOCUMENT_ID")]
		public long DocumentId { get; set; }

		[Required]
		[Column("DOCUMENT_CLASS")]
		public string DocumentClass { get; set; }

		[Required]
		[Column("POLICY_TYPE")]
		public string PolicyType { get; set; }

		[Column("ASSURED_ID")]
		public long? AssuredId { get; set; }

		[Column("BUSINESS_CHANNEL")]
		public string BusinessChannel { get; set; }

		[InverseProperty("FinPol")]
		public virtual ICollection<SstFinancialTransactions> SstFinancialTransactions { get; set; }

		public SstFinancialPolicies()
		{
			SstFinancialTransactions = new HashSet<SstFinancialTransactions>();
		}
	}
}
