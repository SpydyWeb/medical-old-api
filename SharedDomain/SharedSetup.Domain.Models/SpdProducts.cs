using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SPD_PRODUCTS")]
	public class SpdProducts : BaseModel
	{
		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("LAUNCH_DATE")]
		public DateTime LaunchDate { get; set; }

		[Column("TERMINATION_DATE")]
		public DateTime? TerminationDate { get; set; }

		[Column("LOGO")]
		public byte[] Logo { get; set; }

		[Column("NOTES")]
		public string Notes { get; set; }

		[Column("SYSTEM_ID")]
		public long? SystemId { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[ForeignKey("SystemId")]
		[InverseProperty("SpdProducts")]
		public virtual SstSystems System { get; set; }

		[InverseProperty("Product")]
		public virtual ICollection<SpdControlValues> SpdControlValues { get; set; }

		[InverseProperty("Product")]
		public virtual ICollection<SpdProductsDetails> SpdProductsDetails { get; set; }

		[InverseProperty("Product")]
		public virtual ICollection<SstIntegrationsSettings> SstIntegrationsSettings { get; set; }

		public SpdProducts()
		{
			SpdControlValues = new HashSet<SpdControlValues>();
			SpdProductsDetails = new HashSet<SpdProductsDetails>();
			SstIntegrationsSettings = new HashSet<SstIntegrationsSettings>();
		}
	}
}
