using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_COMMISSION_STRUCTURE")]
	public class SstCommissionStructure : BaseModel
	{
		[NotMapped]
		public string CategoryName { get; set; }

		[NotMapped]
		public string CalculationBaseName { get; set; }

		[NotMapped]
		public string YearBasisName { get; set; }

		[NotMapped]
		public string InsuranceSystemName { get; set; }

		[NotMapped]
		public string ParentCommissionName { get; set; }

		[NotMapped]
		public decimal? CommPer { get; set; }

		[NotMapped]
		public decimal? CommAmount { get; set; }

		[NotMapped]
		public long? DefaultCustomer { get; set; }

		[NotMapped]
		public long? CustomerAccount { get; set; }

		[Column("SYSTEM_ID")]
		public long SystemId { get; set; }

		[Column("CATEGORY")]
		public short Category { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("CALCULATION_BASE")]
		public short CalculationBase { get; set; }

		[Column("YEAR_BASIS")]
		public short YearBasis { get; set; }

		[Column("TYPE")]
		public short? Type { get; set; }

		[Column("COMM_STRUCTURE_ID")]
		public long? CommStructureId { get; set; }

		[Column("AUTO_ADD")]
		public bool? AutoAdd { get; set; }

		[ForeignKey("CommStructureId")]
		[InverseProperty("InverseCommStructure")]
		public virtual SstCommissionStructure CommStructure { get; set; }

		[ForeignKey("SystemId")]
		[InverseProperty("SstCommissionStructure")]
		public virtual SstSystems System { get; set; }

		[InverseProperty("CommStructure")]
		public virtual ICollection<SstCommissionStructure> InverseCommStructure { get; set; }

		[InverseProperty("CommStructure")]
		public virtual ICollection<SstAgents> SstAgents { get; set; }

		[InverseProperty("CommStructure")]
		public virtual ICollection<SstCommStructureBusiness> SstCommStructureBusiness { get; set; }

		public SstCommissionStructure()
		{
			InverseCommStructure = new HashSet<SstCommissionStructure>();
			SstAgents = new HashSet<SstAgents>();
			SstCommStructureBusiness = new HashSet<SstCommStructureBusiness>();
		}
	}
}
