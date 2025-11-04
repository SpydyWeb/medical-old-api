using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_PAYMENT_CYCLES")]
	public class SstPaymentCycles : BaseModel
	{
		[NotMapped]
		public string InsuranceSystemName { get; set; }

		[NotMapped]
		public string PeriodUnitName { get; set; }

		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("SHARE_")]
		public decimal? Share { get; set; }

		[Column("UNIT")]
		public byte Unit { get; set; }

		[Column("FREQUENCY")]
		public short Frequency { get; set; }

		[Column("NO_OF_PAYMENTS")]
		public short NoOfPayments { get; set; }

		[Column("IS_EDITABLE")]
		public byte IsEditable { get; set; }

		[Column("NOTES")]
		public string Notes { get; set; }

		[Column("SYSTEM_ID")]
		public long? SystemId { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[ForeignKey("SystemId")]
		[InverseProperty("SstPaymentCycles")]
		public virtual SstSystems System { get; set; }

		[InverseProperty("Cycle")]
		public virtual ICollection<SstPaymentDetails> SstPaymentDetails { get; set; }

		[InverseProperty("PaymentCycleNavigation")]
		public virtual ICollection<SstRelations> SstRelations { get; set; }

		public SstPaymentCycles()
		{
			SstPaymentDetails = new HashSet<SstPaymentDetails>();
			SstRelations = new HashSet<SstRelations>();
		}
	}
}
