using System;

namespace CORE.DTOs.MotorClaim.Integrations.Tables
{
	public class BasherAccidentinfo
	{
		public int Id { get; set; }

		public string? accidentNumber { get; set; }

		public string? accidentDate { get; set; }

		public string? accidentTime { get; set; }

		public string? trafficBranchName { get; set; }

		public string? accidentCause { get; set; }

		public string? accidentType { get; set; }

		public string? accidentCity { get; set; }

		public string? streetName { get; set; }

		public string? longitude { get; set; }

		public string? latitude { get; set; }

		public string? accidentDescription { get; set; }

		public string? trafficDirection { get; set; }

		public string? weatherCondition { get; set; }

		public string? residentialZone { get; set; }

		public string? lightingCondition { get; set; }

		public string? roadServiceCondition { get; set; }

		public string? roadType { get; set; }

		public string? privateDamages { get; set; }

		public string? publicDamages { get; set; }

		public string? officerName { get; set; }

		public string CreatedBy { get; set; }

		public int? numberOfPartiesInvolved { get; set; }

		public int? numberOfInjuredPersons { get; set; }

		public DateTime CreationDate { get; set; }
	}
}
