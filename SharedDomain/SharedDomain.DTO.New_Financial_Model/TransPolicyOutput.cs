using System.Collections.Generic;

namespace SharedDomain.DTO.New_Financial_Model
{
	public class TransPolicyOutput
	{
		public int ID { get; set; }

		public string Policy_No { get; set; }

		public List<TransactionOutPut> Transactions { get; set; }
	}
}
