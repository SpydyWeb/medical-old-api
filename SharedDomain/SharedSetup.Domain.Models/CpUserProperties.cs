using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("CP_USER_PROPERTIES")]
	public class CpUserProperties : BaseModel
	{
		[Required]
		[Column("PROPERTY")]
		public string Property { get; set; }

		[Required]
		[Column("PROPERTY_VALUE")]
		public byte[] PropertyValue { get; set; }

		[Column("USER_ID")]
		public long? UserId { get; set; }

		[ForeignKey("UserId")]
		[InverseProperty("InverseUser")]
		public virtual CpUserProperties User { get; set; }

		[InverseProperty("User")]
		public virtual ICollection<CpUserProperties> InverseUser { get; set; }

		[InverseProperty("UserProperty")]
		public virtual ICollection<SpdControlValues> SpdControlValues { get; set; }

		public CpUserProperties()
		{
			InverseUser = new HashSet<CpUserProperties>();
			SpdControlValues = new HashSet<SpdControlValues>();
		}
	}
}
