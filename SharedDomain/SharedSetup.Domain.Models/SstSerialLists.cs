using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_SERIAL_LISTS")]
	public class SstSerialLists : BaseModel
	{
		[NotMapped]
		public string InsuranceClassName { get; set; }

		[NotMapped]
		public string PolicyTypeName { get; set; }

		[NotMapped]
		public string SerialTypeName { get; set; }

		[NotMapped]
		public string TermName { get; set; }

		[NotMapped]
		public string BusinessChannelName { get; set; }

		[NotMapped]
		public string BusinessTypeName { get; set; }

		[NotMapped]
		public string AutomaticFlagName { get; set; }

		[NotMapped]
		public bool AutomaticFlagValue => getAutomaticFlagValue();

		[Column("BRANCH")]
		public long? Branch { get; set; }

		[Column("SYSTEM_ID")]
		public long SystemId { get; set; }

		[Column("CLASS_ID")]
		public long? ClassId { get; set; }

		[Column("POLICY_TYPE")]
		public long? PolicyType { get; set; }

		[Column("BUSINESS_TYPE")]
		public byte? BusinessType { get; set; }

		[Column("BUSINESS_CHANNEL")]
		public long? BusinessChannel { get; set; }

		[Column("SERIAL_TYPE")]
		public byte? SerialType { get; set; }

		[Column("VALID_FROM_DATE")]
		public DateTime? ValidFromDate { get; set; }

		[Column("VALID_TO_DATE")]
		public DateTime? ValidToDate { get; set; }

		[Column("TERM_TYPE")]
		public byte? TermType { get; set; }

		[Column("AUTOMATIC_FLAG")]
		public byte? AutomaticFlag { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[Column("COUNTRY")]
		public string Country { get; set; }

		[Column("PACKAGED_ID")]
		public long? PackagedId { get; set; }

		[ForeignKey("BusinessChannel")]
		[InverseProperty("SstSerialLists")]
		public virtual SstBusinessChannels BusinessChannelNavigation { get; set; }

		[ForeignKey("ClassId")]
		[InverseProperty("SstSerialLists")]
		public virtual SstClasses Class { get; set; }

		[ForeignKey("PackagedId")]
		[InverseProperty("SstSerialLists")]
		public virtual SstPackagedPolicy Packaged { get; set; }

		[ForeignKey("PolicyType")]
		[InverseProperty("SstSerialLists")]
		public virtual SstPolicyTypes PolicyTypeNavigation { get; set; }

		[ForeignKey("SystemId")]
		[InverseProperty("SstSerialLists")]
		public virtual SstSystems System { get; set; }

		[InverseProperty("Serial")]
		public virtual ICollection<SstSerialRanges> SstSerialRanges { get; set; }

		public bool getAutomaticFlagValue()
		{
			if (AutomaticFlag == 1)
			{
				return true;
			}
			return false;
		}

		public SstSerialLists()
		{
			SstSerialRanges = new HashSet<SstSerialRanges>();
		}
	}
}
