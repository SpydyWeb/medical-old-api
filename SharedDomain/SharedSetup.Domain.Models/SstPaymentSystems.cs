using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	public class SstPaymentSystems : BaseModel
	{
		public long SystemId { get; set; }

		public long CycleId { get; set; }

		public virtual SstPaymentCycles Cycle { get; set; }

		public virtual SstSystems System { get; set; }
	}
}
