using System;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_ENTITY_DETAILS")]
	public class SstEntityDetails : BaseModel
	{
		[NotMapped]
		public long CompanyId { get; set; }

		[NotMapped]
		public string PriorityName { get; set; }

		[NotMapped]
		public string PositionName { get; set; }

		[Column("DETAIL_TYPE")]
		public byte DetailType { get; set; }

		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("POSITION")]
		public long? Position { get; set; }

		[Column("PRIORITY")]
		public byte? Priority { get; set; }

		[Column("PHONE_NO")]
		public string PhoneNo { get; set; }

		[Column("MOBILE_NO")]
		public string MobileNo { get; set; }

		[Column("EMAIL")]
		public string Email { get; set; }

		[Column("DETAIL_DATE")]
		public DateTime? DetailDate { get; set; }

		[Column("COUNTRY")]
		public string Country { get; set; }

		[Column("SHARE_PERCENT")]
		public decimal? SharePercent { get; set; }

		[Column("EXPERIENCE_YEARS")]
		public byte? ExperienceYears { get; set; }

		[Column("TOTAL_POLICIES")]
		public long? TotalPolicies { get; set; }

		[Column("TOTAL_PREMIUM")]
		public decimal? TotalPremium { get; set; }

		[Column("ADDRESS")]
		public string Address { get; set; }

		[Column("NOTES")]
		public string Notes { get; set; }

		[Column("ENTITY_ID")]
		public long EntityId { get; set; }
	}
}
