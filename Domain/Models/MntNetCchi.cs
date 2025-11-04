using System;
using System.Collections.Generic;
using Domain.Common;

namespace Domain.Models
{
	public class MntNetCchi : BaseModel
	{
		public long MntNetId { get; set; }

		public string Name { get; set; }

		public string Status { get; set; }

		public DateTime? StatusDate { get; set; }

		public short? ErrorCode { get; set; }

		public string ErrorDesc { get; set; }

		public string ReferenceNo { get; set; }

		public virtual ICollection<MntNetCchiHist> MntNetCchiHists { get; set; }

		public virtual ICollection<MntPrvNetCchi> MntPrvNetCchis { get; set; }

		public MntNetCchi()
		{
			MntNetCchiHists = new HashSet<MntNetCchiHist>();
			MntPrvNetCchis = new HashSet<MntPrvNetCchi>();
		}
	}
}
