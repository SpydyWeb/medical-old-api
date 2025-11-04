using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_FORMS")]
	public class SstForms : BaseModel
	{
		[Column("PAGE_ID")]
		public long PageId { get; set; }

		[Required]
		[Column("FORM_HEADER")]
		public string FormHeader { get; set; }

		[Column("FORM_GROUP_NAME")]
		public string FormGroupName { get; set; }

		[Required]
		[Column("FORM_ACTION_TYPE")]
		public string FormActionType { get; set; }

		[Column("FORM_ACTION_LABEL")]
		public string FormActionLabel { get; set; }

		[Column("FROM_ORDER")]
		public int FromOrder { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[Column("LANGUAGE")]
		public int Language { get; set; }

		[InverseProperty("Form")]
		public virtual ICollection<SstFormElements> SstFormElements { get; set; }

		[InverseProperty("Form")]
		public virtual ICollection<SstFormGrid> SstFormGrid { get; set; }

		[InverseProperty("Form")]
		public virtual ICollection<SstFormSystems> SstFormSystems { get; set; }

		public SstForms()
		{
			SstFormElements = new HashSet<SstFormElements>();
			SstFormGrid = new HashSet<SstFormGrid>();
			SstFormSystems = new HashSet<SstFormSystems>();
		}
	}
}
