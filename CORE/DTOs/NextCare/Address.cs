using System;

namespace CORE.DTOs.NextCare
{
	public class Address
	{
		public int addressId { get; set; }

		public int countryId { get; set; }

		public int regionId { get; set; }

		public int subRegionId { get; set; }

		public int cityId { get; set; }

		public int sectionId { get; set; }

		public int streetId { get; set; }

		public string streetNbr { get; set; }

		public int landmarkId { get; set; }

		public string zipCode { get; set; }

		public string mailAddress { get; set; }

		public string bPhoneAreaCode { get; set; }

		public string bPhone { get; set; }

		public string bExtension { get; set; }

		public string bPrivateAreaCode { get; set; }

		public string bPrivate { get; set; }

		public string bFaxAreaCode { get; set; }

		public string bFax { get; set; }

		public string bEmail { get; set; }

		public string bWebPage { get; set; }

		public string hPhoneAreaCode { get; set; }

		public string hPhone { get; set; }

		public string hPagerAreaCode { get; set; }

		public string hPager { get; set; }

		public string hMobileAreaCode { get; set; }

		public string hMobile { get; set; }

		public string hFaxAreaCode { get; set; }

		public string hFax { get; set; }

		public string hEmail { get; set; }

		public string hWebPage { get; set; }

		public string bFaxOut { get; set; }

		public string bFaxOutAreaCode { get; set; }

		public string bFaxer { get; set; }

		public string bFaxerAreaCode { get; set; }

		public string emailInPatient { get; set; }

		public string emailOutPatient { get; set; }

		public string emailPharmacy { get; set; }

		public string faxPharmacy { get; set; }

		public string faxAreaCodePharmacy { get; set; }

		public int latitude { get; set; }

		public int longitude { get; set; }

		public string emailFinance { get; set; }

		public string profEmailFinance { get; set; }

		public DateTime lastEmailUpdateDate { get; set; }

		public int dcountryId { get; set; }

		public int dregionId { get; set; }

		public int dsubRegionId { get; set; }

		public int dcityId { get; set; }

		public int dsectionId { get; set; }

		public int dstreetId { get; set; }

		public string dstreetNbr { get; set; }

		public string dremark { get; set; }
	}
}
