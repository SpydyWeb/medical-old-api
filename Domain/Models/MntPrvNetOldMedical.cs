using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
	public class MntPrvNetOldMedical
	{
		[NotMapped]
		public long ID { get; set; }

		[NotMapped]
		public string NAME { get; set; }

		[NotMapped]
		public string NAME2 { get; set; }

		[NotMapped]
		public string SEGMENT_CODE { get; set; }

		[NotMapped]
		public string MAIN_PROVIDER { get; set; }

		[NotMapped]
		public string PROVIDER_TYPE_NAME { get; set; }

		[NotMapped]
		public string SPECIALIST_NAME { get; set; }

		[NotMapped]
		public long? STATUS { get; set; }

		[NotMapped]
		public string HOID { get; set; }

		[NotMapped]
		public string STATUS_DESC { get; set; }

		[NotMapped]
		public long? PROVIDER_TYPE { get; set; }

		[NotMapped]
		public string BENEFITS { get; set; }

		[NotMapped]
		public string START_DATE { get; set; }

		[NotMapped]
		public string END_DATE { get; set; }

		[NotMapped]
		public long? PROVIDER_CLASSIFICATION { get; set; }

		[NotMapped]
		public string PROVIDER_CLASSIFICATION_NAME { get; set; }

		[NotMapped]
		public string CCHI_STATUS { get; set; }

		[NotMapped]
		public long CCHI_Prv_ID { get; set; }
	}
}
