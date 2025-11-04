using System;
using Domain.Common;

namespace Domain.Models
{
	public class MpdMembersCchiHist : BaseModel
	{
		public long? MpdMemCchiId { get; set; }

		public string TransactionType { get; set; }

		public string Status { get; set; }

		public string StatusDesc { get; set; }

		public DateTime? StatusDate { get; set; }

		public string Notes { get; set; }

		public virtual MpdMembersCchi MpdMemCchi { get; set; }
	}
}
