using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Models
{
	public class MpdClassesCchi : BaseModel
	{
		[NotMapped]
		public int? MedicalCCHICompanyId { get; set; }

		public long? MpdPclId { get; set; }

		public long? MpdPlcCchiId { get; set; }

		public decimal? IntMaxDeductable { get; set; }

		public decimal? MaxCoverLimit { get; set; }

		public string Name { get; set; }

		public string PlanClass { get; set; }

		public string CchiPlanClass { get; set; }

		public long? NetworkId { get; set; }

		public long? MpdPlcIdOrigin { get; set; }

		public short? IsStandard { get; set; }

		public string CchiClassId { get; set; }

		public string IsBenefit { get; set; }

		public string HasBenefit { get; set; }

		public short? RoomType { get; set; }

		public decimal? MpnDeductible { get; set; }

		public decimal? MpnCopayment { get; set; }

		public decimal? OcnDeductible { get; set; }

		public decimal? OcnCopayment { get; set; }

		public decimal? OhnDeductible { get; set; }

		public decimal? OhnCopayment { get; set; }

		public string ReferenceNo { get; set; }

		public string ClassStatus { get; set; }

		public string ClassStatusDesc { get; set; }

		public DateTime? ClassStatusDate { get; set; }

		public string StdStatus { get; set; }

		public string StdStatusDesc { get; set; }

		public DateTime? StdStatusDate { get; set; }

		public short? IsLocal { get; set; }

		public string CoveredCountries { get; set; }

		public string RoomTypeDesc { get; set; }

		public virtual MpdPoliciesCchi MpdPlcCchi { get; set; }

		public virtual ICollection<MpdBenefitsCchi> MpdBenefitsCchis { get; set; }

		public virtual ICollection<MpdClassesCchiHist> MpdClassesCchiHists { get; set; }

		public MpdClassesCchi()
		{
			MpdBenefitsCchis = new HashSet<MpdBenefitsCchi>();
			MpdClassesCchiHists = new HashSet<MpdClassesCchiHist>();
		}
	}
}
