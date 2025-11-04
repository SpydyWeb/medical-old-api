using CORE.TablesObjects;

namespace CORE.DTOs.APIs.Business
{
	public class MembersData
	{
		public Subjects MainMember { get; set; }

		public string OccupationName { get; set; }

		public string NationalityEn { get; set; }

		public string NationalityAr { get; set; }

		public decimal? GrossPremium { get; set; }

		public decimal? Vat { get; set; }

		public decimal? Discount { get; set; }

		public string? MsgPrice { get; set; }

		public MembersData()
		{
			MainMember = new Subjects();
		}
	}
}
