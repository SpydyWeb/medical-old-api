using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_PACKAGED_POLICY")]
	public class SstPackagedPolicy : BaseModel
	{
		[NotMapped]
		public string StatusName { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[Column("SHORT_NAME")]
		public string ShortName { get; set; }

		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("EFFECTIVE_DATE")]
		public DateTime EffectiveDate { get; set; }

		[Column("EXPIRY_DATE")]
		public DateTime? ExpiryDate { get; set; }

		[Column("STATUS")]
		public byte Status { get; set; }

		[Column("STATUS_DATE")]
		public DateTime? StatusDate { get; set; }

		[Column("SYSTEM_ID")]
		public long SystemId { get; set; }

		[InverseProperty("Product")]
		public virtual ICollection<SstDataSecurity> SstDataSecurity { get; set; }

		[InverseProperty("Packaged")]
		public virtual ICollection<SstPackagedPolicyDetails> SstPackagedPolicyDetails { get; set; }

		[InverseProperty("Packaged")]
		public virtual ICollection<SstPackegedCovers> SstPackegedCovers { get; set; }

		[InverseProperty("Packaged")]
		public virtual ICollection<SstSerialLists> SstSerialLists { get; set; }

		public SstPackagedPolicy()
		{
			SstDataSecurity = new HashSet<SstDataSecurity>();
			SstPackagedPolicyDetails = new HashSet<SstPackagedPolicyDetails>();
			SstPackegedCovers = new HashSet<SstPackegedCovers>();
			SstSerialLists = new HashSet<SstSerialLists>();
		}
	}
}
