using System;

namespace CORE.DTOs.MotorClaim.Claims
{
	public class Collectors
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public int Commission { get; set; }

		public int CollectorType { get; set; }

		public int MaxNettingLevel { get; set; }

		public DateTime CreationDate { get; set; }

		public string CreatedBy { get; set; }
	}
}
