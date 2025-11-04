using System;

namespace SharedSetup.Domain.DTO.SharedSetup
{
	public class GenerateSerialDTO
	{
		public int SystemId { get; set; }

		public int SerialType { get; set; }

		public int? BranchId { get; set; }

		public int? ClassId { get; set; }

		public int? PolicyType { get; set; }

		public int? BusinessChannel { get; set; }

		public int? BusinessType { get; set; }

		public DateTime? IssueDate { get; set; }
	}
}
