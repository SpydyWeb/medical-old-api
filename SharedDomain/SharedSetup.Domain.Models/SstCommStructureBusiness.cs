using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_COMM_STRUCTURE_BUSINESS")]
	public class SstCommStructureBusiness : BaseModel
	{
		[NotMapped]
		public string BusinessTypeName { get; set; }

		[NotMapped]
		public string InsuranceClassName { get; set; }

		[NotMapped]
		public string PolicyTypeName { get; set; }

		[Column("COMM_STRUCTURE_ID")]
		public long CommStructureId { get; set; }

		[Column("BUSINESS_TYPE")]
		public short BusinessType { get; set; }

		[Column("CLASS_ID")]
		public long ClassId { get; set; }

		[Column("POLICY_TYPE")]
		public long? PolicyType { get; set; }

		[Column("COMM_PER")]
		public decimal CommPer { get; set; }

		[Column("COMM_AMOUNT")]
		public decimal CommAmount { get; set; }

		[Column("DEFAULT_CUSTOMER")]
		public long? DefaultCustomer { get; set; }

		[Column("CUSTOMER_ACCOUNT")]
		public long? CustomerAccount { get; set; }

		[Column("AUTO_ADD")]
		public bool? AutoAdd { get; set; }

		[Column("FIN_CUSTOMER_ACCOUNT_NAME")]
		public string FinCustomerAccountName { get; set; }

		[Column("FIN_DEFAULT_CUSTOMER_NAME")]
		public string FinDefaultCustomerName { get; set; }

		[ForeignKey("ClassId")]
		[InverseProperty("SstCommStructureBusiness")]
		public virtual SstClasses Class { get; set; }

		[ForeignKey("CommStructureId")]
		[InverseProperty("SstCommStructureBusiness")]
		public virtual SstCommissionStructure CommStructure { get; set; }

		[ForeignKey("PolicyType")]
		[InverseProperty("SstCommStructureBusiness")]
		public virtual SstPolicyTypes PolicyTypeNavigation { get; set; }
	}
}
