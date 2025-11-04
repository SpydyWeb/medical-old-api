using System;

namespace CORE.DTOs.Business
{
	public class CreditLimits
	{
		public int Id { get; set; }

		public long EskaId { get; set; }

		public decimal CreditLimit { get; set; }

		public decimal Balance { get; set; }

		public DateTime? LastPaymentDate { get; set; }

		public int FinanceUserId { get; set; }

		public decimal ExtendLimit { get; set; }

		public int? modifiedBy { get; set; }

		public DateTime CreationDate { get; set; }

		public DateTime? ModificationDate { get; set; }

		public int UserId { get; set; }
	}
}
