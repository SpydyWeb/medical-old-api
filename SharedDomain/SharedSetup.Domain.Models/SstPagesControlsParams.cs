using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_PAGES_CONTROLS_PARAMS")]
	public class SstPagesControlsParams : BaseModel
	{
		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("TYPE")]
		public long Type { get; set; }

		[Column("DEPEND_ON_KEY")]
		public string DependOnKey { get; set; }

		[Column("CONTROL_ID")]
		public long ControlId { get; set; }

		[ForeignKey("ControlId")]
		[InverseProperty("SstPagesControlsParams")]
		public virtual SstPagesControls Control { get; set; }
	}
}
