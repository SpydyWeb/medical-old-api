using CORE.DTOs.APIs.Unified_Response;
using CORE.TablesObjects;

namespace CORE.DTOs.APIs.Business
{
	public class MemberPremiums : Results
	{
		public Subjects? Member { get; set; }

		public decimal? GrossPremium { get; set; }

		public decimal? Vat { get; set; }

		public decimal? Discount { get; set; }

		public string MsgPrice { get; set; }
	}
}
