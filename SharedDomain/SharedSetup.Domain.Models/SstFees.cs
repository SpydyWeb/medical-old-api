using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedSetup.Domain.Common;

namespace SharedSetup.Domain.Models
{
	[Table("SST_FEES")]
	public class SstFees : BaseModel
	{
		[NotMapped]
		public string FeeName { get; set; }

		[NotMapped]
		public string FeeType { get; set; }

		[NotMapped]
		public string CalculateFromName { get; set; }

		[NotMapped]
		public string FeeCategory { get; set; }

		[NotMapped]
		public string InsuranceSystemName { get; set; }

		[NotMapped]
		public string ApplyOnProductionCheck { get; set; }

		[NotMapped]
		public string ApplyOnClaimsCheck { get; set; }

		[NotMapped]
		public string ApplyOnRICheck { get; set; }

		[NotMapped]
		public string ApplyOnName { get; set; }

		[NotMapped]
		public string[] documentTypeMultiSelect { get; set; }

		[Required]
		[Column("NAME")]
		public string Name { get; set; }

		[Column("NAME2")]
		public string Name2 { get; set; }

		[Column("APPLY_PRODUCTION")]
		public byte? ApplyProduction { get; set; }

		[Column("APPLY_CLAIMS")]
		public byte? ApplyClaims { get; set; }

		[Column("APPLY_REINSURANCE")]
		public byte? ApplyReinsurance { get; set; }

		[Column("APPLY_INVESTMENT")]
		public byte? ApplyInvestment { get; set; }

		[Column("CATEGORY")]
		public byte Category { get; set; }

		[Column("TYPE")]
		public byte Type { get; set; }

		[Column("ABBREVIATION")]
		public string Abbreviation { get; set; }

		[Column("VOUCHER_SIDE")]
		public byte VoucherSide { get; set; }

		[Column("CALCULATE_FROM")]
		public byte CalculateFrom { get; set; }

		[Column("APPLY_ON")]
		public byte ApplyOn { get; set; }

		[Column("DATE_TYPE")]
		public byte? DateType { get; set; }

		[Column("EFFECTIVE_DATE")]
		public DateTime? EffectiveDate { get; set; }

		[Column("EXPIRY_DATE")]
		public DateTime? ExpiryDate { get; set; }

		[Column("COMMISSION_TYPE")]
		public byte? CommissionType { get; set; }

		[Column("CALCULATION_LEVEL")]
		public byte CalculationLevel { get; set; }

		[Column("DOCUMENT_TYPE")]
		public string DocumentType { get; set; }

		[Column("SYSTEM_ID")]
		public long? SystemId { get; set; }

		[Column("COMPANY_ID")]
		public long CompanyId { get; set; }

		[ForeignKey("SystemId")]
		[InverseProperty("SstFees")]
		public virtual SstSystems System { get; set; }

		[InverseProperty("Fee")]
		public virtual ICollection<SstAccounts> SstAccounts { get; set; }

		[InverseProperty("Fee")]
		public virtual ICollection<SstFeesDetails> SstFeesDetails { get; set; }

		[InverseProperty("Fee")]
		public virtual ICollection<SstFeesTiers> SstFeesTiers { get; set; }

		[InverseProperty("FeeTypeNavigation")]
		public virtual ICollection<SstReinsuranceAccounts> SstReinsuranceAccounts { get; set; }

		public SstFees()
		{
			SstAccounts = new HashSet<SstAccounts>();
			SstFeesDetails = new HashSet<SstFeesDetails>();
			SstFeesTiers = new HashSet<SstFeesTiers>();
			SstReinsuranceAccounts = new HashSet<SstReinsuranceAccounts>();
		}
	}
}
