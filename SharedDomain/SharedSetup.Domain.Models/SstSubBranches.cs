using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_SUB_BRANCHES")]
	public class SstSubBranches : BaseModel
	{
		[NotMapped]
		public string TypeOfBusinessName { get; set; }

		[NotMapped]
		public string LevelName { get; set; }

		[NotMapped]
		public string ParentLevelName { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[Column("SYSTEM_ID")]
		public long SystemId { get; set; }

		[Column("BRANCH_ID")]
		public long? BranchId { get; set; }

		[Column("LEVEL")]
		public short Level { get; set; }

		[Column("SUB_BRANCH_ID")]
		public long? SubBranchId { get; set; }

		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("TYPE_OF_BUSINESS")]
		public short TypeOfBusiness { get; set; }

		[Column("TYPE_OF_BUSINESS_VAL")]
		public short? TypeOfBusinessVal { get; set; }

		[Required]
		[Column("CODE")]
		public string Code { get; set; }

		[ForeignKey("SubBranchId")]
		[InverseProperty("InverseSubBranch")]
		public virtual SstSubBranches SubBranch { get; set; }

		[ForeignKey("SystemId")]
		[InverseProperty("SstSubBranches")]
		public virtual SstSystems System { get; set; }

		[InverseProperty("SubBranch")]
		public virtual ICollection<SstSubBranches> InverseSubBranch { get; set; }

		public SstSubBranches()
		{
			InverseSubBranch = new HashSet<SstSubBranches>();
		}
	}
}
