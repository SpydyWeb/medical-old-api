using System;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SPD_PRODUCTS_DETAILS")]
	public class SpdProductsDetails : BaseModel
	{
		[Column("SYSTEM_ID")]
		public long SystemId { get; set; }

		[Column("CLASS_ID")]
		public long ClassId { get; set; }

		[Column("POLICY_TYPE")]
		public long PolicyType { get; set; }

		[Column("RISK_CATEGORY")]
		public long? RiskCategory { get; set; }

		[Column("VALID_FROM")]
		public DateTime ValidFrom { get; set; }

		[Column("VALID_TO")]
		public DateTime? ValidTo { get; set; }

		[Column("PRODUCT_ID")]
		public long ProductId { get; set; }

		[ForeignKey("ProductId")]
		[InverseProperty("SpdProductsDetails")]
		public virtual SpdProducts Product { get; set; }
	}
}
