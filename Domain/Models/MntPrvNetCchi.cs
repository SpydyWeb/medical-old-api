using System;
using System.Collections.Generic;
using Domain.Common;

namespace Domain.Models
{
	public class MntPrvNetCchi : BaseModel
	{
		public long? MntNetCchiId { get; set; }

		public long MntPrvNetId { get; set; }

		public string ReferenceNo { get; set; }

		public string Hoid { get; set; }

		public string Status { get; set; }

		public DateTime? StatusDate { get; set; }

		public short? ErrorCode { get; set; }

		public string ErrorDesc { get; set; }

		public DateTime? EndDate { get; set; }

		public virtual MntNetCchi MntNetCchi { get; set; }

		public virtual ICollection<MntPrvNetCchiHist> MntPrvNetCchiHists { get; set; }

		public MntPrvNetCchi()
		{
			MntPrvNetCchiHists = new HashSet<MntPrvNetCchiHist>();
		}
	}
}
