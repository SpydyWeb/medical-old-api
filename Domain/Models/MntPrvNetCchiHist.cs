using System;
using Domain.Common;

namespace Domain.Models
{
	public class MntPrvNetCchiHist : BaseModel
	{
		public long? MntPrvNetCchiId { get; set; }

		public string TransactionType { get; set; }

		public string Status { get; set; }

		public DateTime? StatusDate { get; set; }

		public byte? ErrorCode { get; set; }

		public string ErrorDesc { get; set; }

		public virtual MntPrvNetCchi MntPrvNetCchi { get; set; }
	}
}
