using SharedSetup.Domain.Common;

namespace Domain.Models.DTOs
{
	public class ClassBenefitClassDeductibleResponse : BaseModel
	{
		public int MpbBnfCchiId { get; set; }

		public int? MpdPbnId { get; set; }

		public int? MpdPclId { get; set; }

		public string CchiBenefitName { get; set; }

		public string CchiBenefitName2 { get; set; }

		public string EskaBenefitName { get; set; }

		public string TerritoryScope { get; set; }

		public decimal? AnnualLimit { get; set; }

		public int? NumberOfUsage { get; set; }

		public decimal? NetCopayment { get; set; }

		public decimal? NetDeductible { get; set; }

		public decimal? NetMinDeductible { get; set; }

		public decimal? NetMaxDeductible { get; set; }

		public decimal? ReimbCopayment { get; set; }

		public decimal? ReimbDeductible { get; set; }

		public decimal? ReimbMaxDeductible { get; set; }

		public decimal? ReimbMinDeductible { get; set; }

		public decimal? MaxCoverLimit { get; set; }

		public int? RoomType { get; set; }

		public string RoomTypeDesc { get; set; }

		public decimal? MpnDeductible { get; set; }

		public decimal? MpnCopayment { get; set; }

		public decimal? MpbCopayment { get; set; }

		public decimal? OcnDeductible { get; set; }

		public decimal? OcnCopayment { get; set; }

		public decimal? OhnDeductible { get; set; }

		public decimal? OhnCopayment { get; set; }

		public int? RecordLevel { get; set; }
	}
}
