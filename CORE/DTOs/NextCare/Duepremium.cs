using System;

namespace CORE.DTOs.NextCare
{
	public class Duepremium
	{
		public DateTime dueDate { get; set; }

		public int dueNetPremium { get; set; }

		public int dueProPrem { get; set; }

		public int dueIaf { get; set; }

		public int dueTpa { get; set; }

		public int dueAc { get; set; }

		public int dueGrossAmount { get; set; }

		public int dueTax1 { get; set; }

		public int dueTax2 { get; set; }

		public int dueTax3 { get; set; }

		public int dueTax4 { get; set; }

		public int dueTax5 { get; set; }

		public int dueTax6 { get; set; }
	}
}
