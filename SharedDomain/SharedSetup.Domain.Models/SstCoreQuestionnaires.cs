using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_CORE_QUESTIONNAIRES")]
	public class SstCoreQuestionnaires : BaseModel
	{
		[NotMapped]
		public string SystemName { get; set; }

		[NotMapped]
		public string ClassName { get; set; }

		[NotMapped]
		public string PolicyTypeName { get; set; }

		[NotMapped]
		public string StatusName { get; set; }

		[NotMapped]
		public string UsageName { get; set; }

		[NotMapped]
		public long LobCode { get; set; }

		[Column("SYSTEM_ID")]
		public long SystemId { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[Column("CLASS_ID")]
		public long ClassId { get; set; }

		[Column("POLICY_TYPE_ID")]
		public long? PolicyTypeId { get; set; }

		[Column("BUSINESS_TYPE")]
		public long? BusinessType { get; set; }

		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Required]
		[Column("USAGE")]
		public string Usage { get; set; }

		[Column("POSTING_ACTION")]
		public short PostingAction { get; set; }

		[Column("STATUS")]
		public short Status { get; set; }

		[Column("STATUS_DATE")]
		public DateTime StatusDate { get; set; }

		[ForeignKey("ClassId")]
		[InverseProperty("SstCoreQuestionnaires")]
		public virtual SstClasses Class { get; set; }

		[ForeignKey("PolicyTypeId")]
		[InverseProperty("SstCoreQuestionnaires")]
		public virtual SstPolicyTypes PolicyType { get; set; }

		[ForeignKey("SystemId")]
		[InverseProperty("SstCoreQuestionnaires")]
		public virtual SstSystems System { get; set; }

		[InverseProperty("Questionnaire")]
		public virtual ICollection<SstQuestDetails> SstQuestDetails { get; set; }

		public SstCoreQuestionnaires()
		{
			SstQuestDetails = new HashSet<SstQuestDetails>();
		}
	}
}
