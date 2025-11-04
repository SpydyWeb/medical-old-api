using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_ENTITY_ROLES")]
	public class SstEntityRoles : BaseModel
	{
		[Column("ENTITY_ID")]
		public long EntityId { get; set; }

		[Column("ENTITY_TYPE")]
		public long EntityType { get; set; }

		[Column("ROLE_ID")]
		public long? RoleId { get; set; }

		[Column("ACCOUNT_TYPE")]
		public long? AccountType { get; set; }

		[Column("ACCOUNT_ID")]
		public long? AccountId { get; set; }

		[Column("COST_CENTER")]
		public long? CostCenter { get; set; }

		[ForeignKey("EntityId")]
		[InverseProperty("SstEntityRoles")]
		public virtual SstEntities Entity { get; set; }
	}
}
