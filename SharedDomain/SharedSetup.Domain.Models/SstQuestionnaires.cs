using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_QUESTIONNAIRES")]
	public class SstQuestionnaires : BaseModel
	{
		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("USAGE")]
		public byte? Usage { get; set; }

		[Column("NOTES")]
		public string Notes { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[InverseProperty("Questionnaire")]
		public virtual ICollection<SstQuestControls> SstQuestControls { get; set; }

		[InverseProperty("Quiestionnaire")]
		public virtual ICollection<SstQuestSystems> SstQuestSystems { get; set; }

		public SstQuestionnaires()
		{
			SstQuestControls = new HashSet<SstQuestControls>();
			SstQuestSystems = new HashSet<SstQuestSystems>();
		}
	}
}
