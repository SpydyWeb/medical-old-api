using System;

namespace CORE.DTOs.Business
{
	public class CRDetails
	{
		public long ID { get; set; }

		public string? CRNUMBER { get; set; }

		public string? CRNAME { get; set; }

		public string? CRENTITYNO { get; set; }

		public string? ISSUEDATE { get; set; }

		public string? EXPIRYDATE { get; set; }

		public string? CRMAINNUMBER { get; set; }

		public string? BUSINESSTYPE_ID { get; set; }

		public string? BUSINESSTYP_NAME { get; set; }

		public string? FISCALYEAR_MONTH { get; set; }

		public string? FISCALYEAR_DAY { get; set; }

		public string? STATUS_ID { get; set; }

		public string? STATUS_NAME { get; set; }

		public string? STATUS_NAME_EN { get; set; }

		public string? LOCATION_ID { get; set; }

		public string? LOCATION_NAME { get; set; }

		public string? ACTIVITY_DESC { get; set; }

		public string? ACTIVITY_ISIC_ID { get; set; }

		public string? ACTIVITY_ISIC_NAME { get; set; }

		public string? ACTIVITY_ISIC_NAME_EN { get; set; }

		public string? ACTIVITY_ISIC_ID2 { get; set; }

		public string? ACTIVITY_ISIC_NAME2 { get; set; }

		public string? ACTIVITY_ISIC_NAME_EN2 { get; set; }

		public string? CREATEDBY { get; set; }

		public DateTime? CREATED_DATE { get; set; }

		public string? COMPANY_PERIOD { get; set; }

		public string? COMPANY_START_DATE { get; set; }

		public string? COMPANY_END_DATE { get; set; }

		public string? CANCELLATION_DATE { get; set; }

		public string? CONCELLATION_REASON { get; set; }

		public bool? IS_REUSED { get; set; }
	}
}
