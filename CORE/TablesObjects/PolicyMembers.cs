using System;

namespace CORE.TablesObjects
{
	public class PolicyMembers
	{
		public long Id { get; set; }

		public long PolicyId { get; set; }

		public long EskaPolicyId { get; set; }

		public string Name { get; set; }

		public long? Princible { get; set; }

		public int Gender { get; set; }

		public int MartialId { get; set; }

		public DateTime? DateOfBirth { get; set; }

		public int ClassId { get; set; }

		public string Sponsor { get; set; }

		public int Occupation { get; set; }

		public int Age { get; set; }

		public int Relation { get; set; }

		public DateTime CreationDate { get; set; }

		public string? Nationality { get; set; }

		public string NationalId { get; set; }
	}
}
