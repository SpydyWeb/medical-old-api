using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	public class SstPolicyDiscountsDetails : BaseModel
	{
		public long ClassId { get; set; }

		public long PolicyType { get; set; }

		public long? BusinessType { get; set; }

		public long? PolicyDiscountId { get; set; }

		public virtual SstClasses Class { get; set; }

		public virtual SstPolicyDiscounts PolicyDiscount { get; set; }

		public virtual SstPolicyTypes PolicyTypeNavigation { get; set; }
	}
}
