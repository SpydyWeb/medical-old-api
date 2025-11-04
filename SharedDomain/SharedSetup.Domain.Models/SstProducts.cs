using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_PRODUCTS")]
	public class SstProducts : BaseModel
	{
		[Required]
		[Column("CODE")]
		public string Code { get; set; }

		[Required]
		[Column("ABBREVIATION")]
		public string Abbreviation { get; set; }

		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("EFFECTIVE_DATE")]
		public DateTime EffectiveDate { get; set; }

		[Column("EXPIRY_DATE")]
		public DateTime? ExpiryDate { get; set; }

		[Column("NOTES")]
		public string Notes { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[InverseProperty("Product")]
		public virtual ICollection<SstProductsDetails> SstProductsDetails { get; set; }

		public SstProducts()
		{
			SstProductsDetails = new HashSet<SstProductsDetails>();
		}
	}
}
