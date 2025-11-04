using System;

namespace Domain.Models.DTOs
{
	public class Code
	{
		public long? Id { get; set; }

		public string CamSysCode { get; set; }

		public string CreatedBy { get; set; }

		public DateTime? CreationDate { get; set; }

		public int? MajorCode { get; set; }

		public long? MinorCode { get; set; }

		public DateTime? ModificationData { get; set; }

		public string ModificationUser { get; set; }

		public string Name { get; set; }

		public string Name2 { get; set; }
	}
}
