using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_USERS")]
	public class SstUsers : BaseModel
	{
		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("EMAIL")]
		public string Email { get; set; }

		[Column("BIRTH_DATE")]
		public DateTime? BirthDate { get; set; }

		[Column("USERNAME")]
		public string Username { get; set; }

		[Column("DEPARTMENT")]
		public int? Department { get; set; }

		[Column("COUNTRY")]
		public string Country { get; set; }

		[Column("CITY")]
		public short? City { get; set; }

		[Column("OCCUPATION")]
		public int? Occupation { get; set; }

		[Column("PHONE_NO")]
		public string PhoneNo { get; set; }

		[Column("MOBILE_NO")]
		public string MobileNo { get; set; }

		[Column("PO_BOX")]
		public string PoBox { get; set; }

		[Column("ZIP_CODE")]
		public string ZipCode { get; set; }

		[Column("ADDRESS")]
		public string Address { get; set; }

		[Column("IMAGE")]
		public string Image { get; set; }

		[Column("IMAGE_STYLE")]
		public string ImageStyle { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[InverseProperty("User")]
		public virtual ICollection<SstUserAlerts> SstUserAlerts { get; set; }

		public SstUsers()
		{
			SstUserAlerts = new HashSet<SstUserAlerts>();
		}
	}
}
