using System;

namespace CORE.DTOs.MotorClaim.Integrations.Tables
{
	public class NajmAccidentinfo
	{
		public long Id { get; set; }

		public string caseNumber { get; set; }

		public string surveyorName { get; set; }

		public string callDate { get; set; }

		public string callTime { get; set; }

		public string landmark { get; set; }

		public string location { get; set; }

		public string LocationCoordinates { get; set; }

		public string AccidentDescription { get; set; }

		public string city { get; set; }

		public int? cityID { get; set; }

		public DateTime CreationDate { get; set; }
	}
}
