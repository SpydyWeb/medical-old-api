using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Models
{
	public class MpdBenefitsCchi : BaseModel
	{
		[NotMapped]
		public string CchiBenefitName { get; set; }

		[NotMapped]
		public short? RecodeLevel { get; set; }

		public long? MpdPclCchiId { get; set; }

		public long? MpdPbnId { get; set; }

		public long? CchiBenefitId { get; set; }

		public string Name { get; set; }

		public string TerritoryScope { get; set; }

		public decimal? AnnualLimit { get; set; }

		public short? NumberOfUsage { get; set; }

		public decimal? NetCopayment { get; set; }

		public decimal? NetDeductible { get; set; }

		public decimal? NetMaxDeductible { get; set; }

		public decimal? NetMinDeductible { get; set; }

		public decimal? ReimbCopayment { get; set; }

		public decimal? ReimbDeductable { get; set; }

		public decimal? ReimbMaxDeductible { get; set; }

		public decimal? ReimbMinDeductible { get; set; }

		public string Status { get; set; }

		public string StatusDesc { get; set; }

		public DateTime? StatusDate { get; set; }

		public virtual MpdCchiBenefitsMapping CchiBenefit { get; set; }

		public virtual MpdClassesCchi MpdPclCchi { get; set; }

		public virtual ICollection<MpdBenefitsCchiHist> MpdBenefitsCchiHists { get; set; }

		public MpdBenefitsCchi()
		{
			MpdBenefitsCchiHists = new HashSet<MpdBenefitsCchiHist>();
		}
	}
}
