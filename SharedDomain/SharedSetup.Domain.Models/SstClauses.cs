using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_CLAUSES")]
	public class SstClauses : BaseModel
	{
		[NotMapped]
		public string ClassName { get; set; }

		[NotMapped]
		public string SystemName { get; set; }

		[NotMapped]
		public string StatusName { get; set; }

		[Column("CODE")]
		public string Code { get; set; }

		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("CLASS_ID")]
		public long ClassId { get; set; }

		[Column("POLICY_TYPE")]
		public long? PolicyType { get; set; }

		[Column("MARINE_CLAUSE")]
		public long? MarineClause { get; set; }

		[Column("STATUS")]
		public byte? Status { get; set; }

		[Column("SYSTEM_ID")]
		public long SystemId { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[Column("MR_CONVEYANCE_TYPE")]
		public short? MrConveyanceType { get; set; }

		[Column("AUTO_ADD")]
		public byte? AutoAdd { get; set; }

		[ForeignKey("ClassId")]
		[InverseProperty("SstClauses")]
		public virtual SstClasses Class { get; set; }

		[ForeignKey("PolicyType")]
		[InverseProperty("SstClauses")]
		public virtual SstPolicyTypes PolicyTypeNavigation { get; set; }

		[ForeignKey("SystemId")]
		[InverseProperty("SstClauses")]
		public virtual SstSystems System { get; set; }

		[InverseProperty("Clause")]
		public virtual ICollection<SstClausesDetails> SstClausesDetails { get; set; }

		public SstClauses()
		{
			SstClausesDetails = new HashSet<SstClausesDetails>();
		}
	}
}
