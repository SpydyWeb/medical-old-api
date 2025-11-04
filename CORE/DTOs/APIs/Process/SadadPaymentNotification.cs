using System.Collections.Generic;

namespace CORE.DTOs.APIs.Process
{
	public class SadadPaymentNotification
	{
		public List<SadadTransactions> sadadTransactions { get; set; }

		public SadadPaymentNotification()
		{
			sadadTransactions = new List<SadadTransactions>();
		}
	}
}
