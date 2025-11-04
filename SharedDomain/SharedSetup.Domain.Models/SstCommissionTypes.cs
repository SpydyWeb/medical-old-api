using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_COMMISSION_TYPES")]
	public class SstCommissionTypes : BaseModel
	{
		[NotMapped]
		public string InsuranceSystemName { get; set; }

		[NotMapped]
		public string PolicyCommissionTypeName { get; set; }

		[NotMapped]
		public string YearBasisName { get; set; }

		[NotMapped]
		public string ImpactName { get; set; }

		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("COMMISSION_TYPE")]
		public byte CommissionType { get; set; }

		[Column("YEAR_BASIS")]
		public byte YearBasis { get; set; }

		[Column("IMPACT")]
		public byte Impact { get; set; }

		[Column("NOTES")]
		public string Notes { get; set; }

		[Column("SYSTEM_ID")]
		public long? SystemId { get; set; }

		[Column("COMMISSION_ID")]
		public long? CommissionId { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[ForeignKey("SystemId")]
		[InverseProperty("SstCommissionTypes")]
		public virtual SstSystems System { get; set; }

		[InverseProperty("Commission")]
		public virtual ICollection<SstCommissionDetails> SstCommissionDetails { get; set; }

		public SstCommissionTypes()
		{
			SstCommissionDetails = new HashSet<SstCommissionDetails>();
		}
	}
}
