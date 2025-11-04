using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Models
{
	public class MpdPoliciesCchi : BaseModel
	{
		[NotMapped]
		public string PolicyTypeName { get; set; }

		[NotMapped]
		public string BusinessTypeName { get; set; }

		[NotMapped]
		public string UploadStatus { get; set; }

		public short? MstNdtId { get; set; }

		public short? IsPosted { get; set; }

		public long? MpdPlcId { get; set; }

		public long? FcsCstId { get; set; }

		public string CustomerNationalId { get; set; }

		public string TransactionType { get; set; }

		public short? PolicyType { get; set; }

		public DateTime? EffectiveDate { get; set; }

		public DateTime? ExpiryDate { get; set; }

		public string CchiPolicyNo { get; set; }

		public short? Flag { get; set; }

		public string Status { get; set; }

		public string StatusDesc { get; set; }

		public DateTime? StatusDate { get; set; }

		public short? Priority { get; set; }

		public string SegmentCode { get; set; }

		public string PolicyHolder { get; set; }

		public long? CrgBrnId { get; set; }

		public string BranchName { get; set; }

		public string PlanName { get; set; }

		public DateTime? IssueDate { get; set; }

		public long? NoOfEndt { get; set; }

		public long? BusinessType { get; set; }

		public long? EndtNo { get; set; }

		public long? MpdPlnId { get; set; }

		public decimal? GrossPremium { get; set; }

		public string SalesmanCode { get; set; }

		public string SalesmanName { get; set; }

		public string CchiId { get; set; }

		public int? DocumentType { get; set; }

		public decimal? PolicyNo { get; set; }

		public long? MpdPlcIdOrigin { get; set; }

		public virtual ICollection<MpdClassesCchi> MpdClassesCchis { get; set; }

		public virtual ICollection<MpdMembersCchi> MpdMembersCchis { get; set; }

		public virtual ICollection<MpdPoliciesCchiHist> MpdPoliciesCchiHists { get; set; }

		public virtual ICollection<MpdSponsorsCchi> MpdSponsorsCchis { get; set; }

		public MpdPoliciesCchi()
		{
			MpdClassesCchis = new HashSet<MpdClassesCchi>();
			MpdMembersCchis = new HashSet<MpdMembersCchi>();
			MpdPoliciesCchiHists = new HashSet<MpdPoliciesCchiHist>();
			MpdSponsorsCchis = new HashSet<MpdSponsorsCchi>();
		}
	}
}
