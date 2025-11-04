using System;
using Domain.Common;

namespace Domain.Models
{
	public class MntNetCchiHist : BaseModel
	{
		public long? MntNetCchiId { get; set; }

		public string TransactionType { get; set; }

		public string Status { get; set; }

		public DateTime? StatusDate { get; set; }

		public byte? ErrorCode { get; set; }

		public string ErrorDesc { get; set; }

		public virtual MntNetCchi MntNetCchi { get; set; }
	}
}
