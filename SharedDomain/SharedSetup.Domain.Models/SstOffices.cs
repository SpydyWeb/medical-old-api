using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_OFFICES")]
	public class SstOffices : BaseModel
	{
		[NotMapped]
		public string InsuranceSystemName { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[Column("SYSTEM_ID")]
		public long SystemId { get; set; }

		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Required]
		[Column("CODE")]
		public string Code { get; set; }

		[ForeignKey("SystemId")]
		[InverseProperty("SstOffices")]
		public virtual SstSystems System { get; set; }

		[InverseProperty("Office")]
		public virtual ICollection<SstAgentOffices> SstAgentOffices { get; set; }

		public SstOffices()
		{
			SstAgentOffices = new HashSet<SstAgentOffices>();
		}
	}
}
