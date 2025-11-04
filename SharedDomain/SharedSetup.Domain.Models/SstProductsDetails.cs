using System;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_PRODUCTS_DETAILS")]
	public class SstProductsDetails : BaseModel
	{
		[Column("PRODUCT_ID")]
		public long ProductId { get; set; }

		[Column("CLASS_ID")]
		public long ClassId { get; set; }

		[Column("POLICY_TYPE")]
		public long PolicyType { get; set; }

		[Column("EFFECTIVE_DATE")]
		public DateTime EffectiveDate { get; set; }

		[Column("EXPIRY_DATE")]
		public DateTime? ExpiryDate { get; set; }

		[ForeignKey("ClassId")]
		[InverseProperty("SstProductsDetails")]
		public virtual SstClasses Class { get; set; }

		[ForeignKey("PolicyType")]
		[InverseProperty("SstProductsDetails")]
		public virtual SstPolicyTypes PolicyTypeNavigation { get; set; }

		[ForeignKey("ProductId")]
		[InverseProperty("SstProductsDetails")]
		public virtual SstProducts Product { get; set; }
	}
}
