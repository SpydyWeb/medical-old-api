using System;

namespace SharedDomain.DTO.New_Financial_Model
{
	public class BanksBranchesOutput
	{
		public long iD { get; set; }

		public long bANK_ID { get; set; }

		public string cODE { get; set; }

		public string bANK_CODE { get; set; }

		public string nAME { get; set; }

		public string nAME2 { get; set; }

		public int total { get; set; }

		public string cREATED_BY { get; set; }

		public DateTime cREATION_DATE { get; set; }

		public string mODIFIED_BY { get; set; }

		public DateTime? mODIFICATION_DATE { get; set; }
	}
}
