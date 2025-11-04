using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_FORM_SYSTEMS")]
	public class SstFormSystems : BaseModel
	{
		[Column("SYSTEM_ID")]
		public long SystemId { get; set; }

		[Column("FORM_ID")]
		public long FormId { get; set; }

		[ForeignKey("FormId")]
		[InverseProperty("SstFormSystems")]
		public virtual SstForms Form { get; set; }

		[ForeignKey("SystemId")]
		[InverseProperty("SstFormSystems")]
		public virtual SstSystems System { get; set; }
	}
}
