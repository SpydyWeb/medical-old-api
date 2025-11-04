using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("APPROVAL_MAPPING")]
	public class ApprovalMapping : BaseModel
	{
		[Column("ID")]
		public new long Id { get; set; }

		[Column("SYSTEM_ID")]
		public long? SystemId { get; set; }

		[Column("PROCCES_ID")]
		public long ProccesId { get; set; }

		[Column("WORK_FLOW_ID")]
		public long WorkFlowId { get; set; }

		[Required]
		[Column("SESSION_KEY")]
		public string SessionKey { get; set; }

		[Required]
		[Column("SESSION_VALUE")]
		public string SessionValue { get; set; }

		[Required]
		[Column("PAGE_ID")]
		public string PageId { get; set; }

		[Column("COMPANY_ID")]
		public long? CompanyId { get; set; }

		[Required]
		[Column("CREATION_USER")]
		public new string CreationUser { get; set; }

		[Column("CREATION_DATE")]
		public new DateTime CreationDate { get; set; }

		[Column("MODIFICATION_USER")]
		public new string ModificationUser { get; set; }

		[Column("MODIFICATION_DATE")]
		public new DateTime? ModificationDate { get; set; }

		[ForeignKey("SystemId")]
		[InverseProperty("ApprovalMapping")]
		public virtual SstSystems System { get; set; }

		[NotMapped]
		public string ControlKey { get; set; }

		[NotMapped]
		public int ActionType { get; set; }
	}
}
