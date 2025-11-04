using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SPD_PRODUCTS_STEPS")]
	public class SpdProductsSteps : BaseModel
	{
		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("ORDER")]
		public byte? Order { get; set; }

		[Column("ICON")]
		public string Icon { get; set; }

		[Column("LOAD")]
		public string Load { get; set; }

		[Column("SUBMIT")]
		public string Submit { get; set; }

		[Column("PRODUCT_ID")]
		public long ProductId { get; set; }

		[InverseProperty("Step")]
		public virtual ICollection<SpdComponents> SpdComponents { get; set; }

		[InverseProperty("Step")]
		public virtual ICollection<SpdControlValues> SpdControlValues { get; set; }

		[InverseProperty("Step")]
		public virtual ICollection<SpdStepsTransactions> SpdStepsTransactions { get; set; }

		public SpdProductsSteps()
		{
			SpdComponents = new HashSet<SpdComponents>();
			SpdControlValues = new HashSet<SpdControlValues>();
			SpdStepsTransactions = new HashSet<SpdStepsTransactions>();
		}
	}
}
