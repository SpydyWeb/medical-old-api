using System;
using System.Collections.Generic;

namespace SharedDomain.DTO.New_Financial_Model
{
	public class TransactionInput
	{
		public string Policy_No { get; set; }

		public DateTime EFFECTIVE_DATE { get; set; }

		public DateTime EXPIRY_DATE { get; set; }

		public long? APPLICATION_ID { get; set; }

		public long INSURANCE_Document_ID { get; set; }

		public string CLASS { get; set; }

		public string POLICY_TYPE { get; set; }

		public long? ASSURED_ID { get; set; }

		public string BUSINESS_CHANNEL { get; set; }

		public string CREATED_BY { get; set; }

		public List<Transaction> Transactions { get; set; }
	}
}
