using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_AGENT_BOOKS")]
	public class SstAgentBooks : BaseModel
	{
		[NotMapped]
		public string AgentName { get; set; }

		[NotMapped]
		public string BusinessShareName { get; set; }

		[NotMapped]
		public string InsuranceClassName { get; set; }

		[NotMapped]
		public string PolicyTypeName { get; set; }

		[NotMapped]
		public string StatusName { get; set; }

		[NotMapped]
		public string FromToPage { get; set; }

		[Column("SYSTEM_ID")]
		public long SystemId { get; set; }

		[Column("BUSINESS_SHARE")]
		public long BusinessShare { get; set; }

		[Column("CLASS_ID")]
		public long ClassId { get; set; }

		[Column("POLICY_TYPE")]
		public long PolicyType { get; set; }

		[Column("APPLIED_TO")]
		public long AppliedTo { get; set; }

		[Required]
		[Column("BOOK_NO")]
		public string BookNo { get; set; }

		[Column("BOOK_DATE")]
		public DateTime BookDate { get; set; }

		[Column("AGENT_ID")]
		public long? AgentId { get; set; }

		[Column("PAGE_FROM")]
		public int PageFrom { get; set; }

		[Column("PAGE_TO")]
		public int PageTo { get; set; }

		[Column("AGENT_BOOK_STATUS")]
		public long AgentBookStatus { get; set; }

		[Column("BRANCH_ID")]
		public long? BranchId { get; set; }

		[Column("CERTIFICATE_TYPE")]
		public long? CertificateType { get; set; }

		[Column("DOCUMENT_TYPE")]
		public long? DocumentType { get; set; }

		[Column("RETURNED_DATE")]
		public DateTime? ReturnedDate { get; set; }

		[Column("NOTES")]
		public string Notes { get; set; }

		[Column("COMPANY_ID")]
		public long? CompanyId { get; set; }

		[ForeignKey("ClassId")]
		[InverseProperty("SstAgentBooks")]
		public virtual SstClasses Class { get; set; }

		[ForeignKey("PolicyType")]
		[InverseProperty("SstAgentBooks")]
		public virtual SstPolicyTypes PolicyTypeNavigation { get; set; }

		[ForeignKey("SystemId")]
		[InverseProperty("SstAgentBooks")]
		public virtual SstSystems System { get; set; }

		[InverseProperty("ParentBook")]
		public virtual ICollection<SstAgentBookDetails> SstAgentBookDetails { get; set; }

		public SstAgentBooks()
		{
			SstAgentBookDetails = new HashSet<SstAgentBookDetails>();
		}
	}
}
