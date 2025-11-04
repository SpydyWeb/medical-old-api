using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_DOCUMENT_GROUPS")]
	public class SstDocumentGroups : BaseModel
	{
		[NotMapped]
		public string SystemName { get; set; }

		[NotMapped]
		public string InsuranceClassName { get; set; }

		[NotMapped]
		public string PolicyTypeName { get; set; }

		[NotMapped]
		public string DocumentTypeName { get; set; }

		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("SYSTEM_ID")]
		public long SystemId { get; set; }

		[Column("CLASS_ID")]
		public long? ClassId { get; set; }

		[Column("POLICY_TYPE")]
		public long? PolicyType { get; set; }

		[Column("TYPE")]
		public long? Type { get; set; }

		[Column("NOTES")]
		public string Notes { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[ForeignKey("SystemId")]
		[InverseProperty("SstDocumentGroups")]
		public virtual SstSystems System { get; set; }

		[InverseProperty("Group")]
		public virtual ICollection<SstDocuments> SstDocuments { get; set; }

		public SstDocumentGroups()
		{
			SstDocuments = new HashSet<SstDocuments>();
		}
	}
}
