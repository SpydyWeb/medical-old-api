using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_PAGES_CONTROLS")]
	public class SstPagesControls : BaseModel
	{
		[NotMapped]
		public string PageRoute { get; set; }

		[Required]
		[Column("KEY")]
		public string Key { get; set; }

		[Column("FORM")]
		public string Form { get; set; }

		[Column("LABEL_KEY")]
		public string LabelKey { get; set; }

		[Column("ALLOW_EDIT_LABEL")]
		public byte? AllowEditLabel { get; set; }

		[Column("ALLOW_REQUIRED")]
		public byte? AllowRequired { get; set; }

		[Column("IS_REQUIRED")]
		public byte? IsRequired { get; set; }

		[Column("ALLOW_HIDDEN")]
		public byte? AllowHidden { get; set; }

		[Column("IS_HIDDEN")]
		public byte? IsHidden { get; set; }

		[Column("ALLOW_DISABLED")]
		public byte? AllowDisabled { get; set; }

		[Column("IS_DISABLED")]
		public byte? IsDisabled { get; set; }

		[Column("ORDER")]
		public long? Order { get; set; }

		[Column("CONTROL_TYPE")]
		public string ControlType { get; set; }

		[Column("TEXT_TYPE")]
		public string TextType { get; set; }

		[Column("PARAMS_TYPE")]
		public long? ParamsType { get; set; }

		[Column("CLASS_NAME")]
		public string ClassName { get; set; }

		[Column("SERVICE_URL")]
		public string ServiceUrl { get; set; }

		[Column("IS_DYNAMIC")]
		public byte? IsDynamic { get; set; }

		[Column("FORM_TYPE")]
		public long? FormType { get; set; }

		[Column("PAGE_ID")]
		public long PageId { get; set; }

		[Column("CONTROL_ID")]
		public long? ControlId { get; set; }

		[ForeignKey("ControlId")]
		[InverseProperty("InverseControl")]
		public virtual SstPagesControls Control { get; set; }

		[ForeignKey("PageId")]
		[InverseProperty("SstPagesControls")]
		public virtual SstPages Page { get; set; }

		[InverseProperty("Control")]
		public virtual ICollection<SstPagesControls> InverseControl { get; set; }

		[InverseProperty("Control")]
		public virtual ICollection<SstPagesControlsParams> SstPagesControlsParams { get; set; }

		public SstPagesControls()
		{
			InverseControl = new HashSet<SstPagesControls>();
			SstPagesControlsParams = new HashSet<SstPagesControlsParams>();
		}
	}
}
