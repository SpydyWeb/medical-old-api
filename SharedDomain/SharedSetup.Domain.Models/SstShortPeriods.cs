using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_SHORT_PERIODS")]
	public class SstShortPeriods : BaseModel
	{
		[NotMapped]
		public string InsuranceSystemName { get; set; }

		[NotMapped]
		public string InsuranceClassName { get; set; }

		[NotMapped]
		public string PolicyTypesName { get; set; }

		[NotMapped]
		public string PeriodUnitName { get; set; }

		[NotMapped]
		public string EndorsementTypeName { get; set; }

		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("UNIT")]
		public byte Unit { get; set; }

		[Column("FREQUENCY_FROM")]
		public short? FrequencyFrom { get; set; }

		[Column("FREQUENCY_TO")]
		public short? FrequencyTo { get; set; }

		[Column("RATE_FRACTION")]
		public byte RateFraction { get; set; }

		[Column("ADJUST_PERCENT")]
		public decimal AdjustPercent { get; set; }

		[Column("APPLY_ON")]
		public byte ApplyOn { get; set; }

		[Column("NOTES")]
		public string Notes { get; set; }

		[Column("SYSTEM_ID")]
		public long SystemId { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[Column("CLASS_ID")]
		public long ClassId { get; set; }

		[Column("POLICY_TYPE")]
		public long PolicyType { get; set; }

		[ForeignKey("ClassId")]
		[InverseProperty("SstShortPeriods")]
		public virtual SstClasses Class { get; set; }

		[ForeignKey("PolicyType")]
		[InverseProperty("SstShortPeriods")]
		public virtual SstPolicyTypes PolicyTypeNavigation { get; set; }

		[ForeignKey("SystemId")]
		[InverseProperty("SstShortPeriods")]
		public virtual SstSystems System { get; set; }

		[InverseProperty("ShortPeriod")]
		public virtual ICollection<SstShortPeriodsDetails> SstShortPeriodsDetails { get; set; }

		public SstShortPeriods()
		{
			SstShortPeriodsDetails = new HashSet<SstShortPeriodsDetails>();
		}
	}
}
