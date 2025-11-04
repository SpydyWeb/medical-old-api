using System;
using Domain.Common;

namespace Domain.Models
{
	public class MpdBenefitsCchiHist : BaseModel
	{
		public long? MpdBnfCchiId { get; set; }

		public string TransactionType { get; set; }

		public string Status { get; set; }

		public string StatusDesc { get; set; }

		public DateTime? StatusDate { get; set; }

		public virtual MpdBenefitsCchi MpdBnfCchi { get; set; }
	}
}
