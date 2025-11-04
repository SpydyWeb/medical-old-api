using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Models
{
	public class MpdCchiBenefitsMapping : BaseModel
	{
		[NotMapped]
		public new long Id { get; set; }

		[NotMapped]
		public new string CreationUser { get; set; }

		[NotMapped]
		public new DateTime CreationDate { get; set; }

		[NotMapped]
		public new string ModificationUser { get; set; }

		[NotMapped]
		public new DateTime? ModificationDate { get; set; }

		public long CchiBenefitId { get; set; }

		public string CchiBenefitName { get; set; }

		public string CchiBenefitName2 { get; set; }

		public string CchiDefaultValue { get; set; }

		public short? RecordLevel { get; set; }

		public string TableName { get; set; }

		public string ColumnName { get; set; }

		public string WhereClause { get; set; }

		public string EskaBenefitId { get; set; }

		public string EskaBenefitName { get; set; }

		public virtual ICollection<MpdBenefitsCchi> MpdBenefitsCchis { get; set; }

		public MpdCchiBenefitsMapping()
		{
			MpdBenefitsCchis = new HashSet<MpdBenefitsCchi>();
		}
	}
}
