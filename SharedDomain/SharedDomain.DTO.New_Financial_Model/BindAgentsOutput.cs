using System;

namespace SharedDomain.DTO.New_Financial_Model
{
	public class BindAgentsOutput
	{
		public long Agent_Id { get; set; }

		public long Customer_Id { get; set; }

		public string Created_By { get; set; }

		public DateTime Creation_Date { get; set; }

		public long? Status { get; set; }
	}
}
