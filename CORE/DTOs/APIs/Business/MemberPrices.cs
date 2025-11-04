using CORE.TablesObjects;

namespace CORE.DTOs.APIs.Business
{
	public class MemberPrices
	{
		public Subjects Subjects { get; set; }

		public decimal NetPremium { get; set; }

		public decimal GrossPremium { get; set; }

		public decimal Loading { get; set; }
	}
}
