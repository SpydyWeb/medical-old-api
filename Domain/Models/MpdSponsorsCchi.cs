using Domain.Common;

namespace Domain.Models
{
	public class MpdSponsorsCchi : BaseModel
	{
		public long? MpdPlcIdOrigin { get; set; }

		public long? MpdPlcCchiId { get; set; }

		public string Name { get; set; }

		public string PhoneNo { get; set; }

		public string MobileNo { get; set; }

		public long? RegistryType { get; set; }

		public string RegistryNo { get; set; }

		public string SponsorNo { get; set; }

		public short? IsDefault { get; set; }

		public string Email { get; set; }

		public string City { get; set; }

		public virtual MpdPoliciesCchi MpdPlcCchi { get; set; }
	}
}
