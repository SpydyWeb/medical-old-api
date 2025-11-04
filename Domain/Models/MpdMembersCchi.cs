using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Models
{
	public class MpdMembersCchi : BaseModel
	{
		[NotMapped]
		public string RelationName { get; set; }

		[NotMapped]
		public string MaritalStatusName { get; set; }

		[NotMapped]
		public string UploadStatus { get; set; }

		public long? MpdPlmId { get; set; }

		public long? MpdPlcCchiId { get; set; }

		public short? ActionType { get; set; }

		public string SponserNo { get; set; }

		public string SponserName { get; set; }

		public int? CancellationReason { get; set; }

		public string CancellationReasonDesc { get; set; }

		public long? MpdMbrId { get; set; }

		public string Name { get; set; }

		public DateTime? BirthDate { get; set; }

		public DateTime? HijriBirthDate { get; set; }

		public short? Gender { get; set; }

		public decimal? GrossPremium { get; set; }

		public string NationalId { get; set; }

		public DateTime? IdentityExpiryDate { get; set; }

		public short? Relation { get; set; }

		public string SegmentCode { get; set; }

		public string ParentSegmentCode { get; set; }

		public int? NationalityId { get; set; }

		public int? MaritalStatus { get; set; }

		public string Mobile { get; set; }

		public string PhoneNo { get; set; }

		public string Email { get; set; }

		public long? MpdPclId { get; set; }

		public string Occupation { get; set; }

		public DateTime? EffectiveDate { get; set; }

		public decimal? CchiGrossPremium { get; set; }

		public string Status { get; set; }

		public string StatusDesc { get; set; }

		public DateTime? StatusDate { get; set; }

		public short? OnHold { get; set; }

		public string ClassName { get; set; }

		public string PrincipleName { get; set; }

		public string Nationality { get; set; }

		public long? MpdMbrIdRelation { get; set; }

		public short? Age { get; set; }

		public string StaffNo { get; set; }

		public long? MemberNo { get; set; }

		public long? FcsCstId { get; set; }

		public DateTime? ExpiryDate { get; set; }

		public string CrgCntCode { get; set; }

		public long? MpdPlcId { get; set; }

		public long? MpdPlcIdOrigin { get; set; }

		public short? IsUploaded { get; set; }

		public string CchiId { get; set; }

		public long? SeqNo { get; set; }

		public virtual MpdPoliciesCchi MpdPlcCchi { get; set; }

		public virtual ICollection<MpdMembersCchiHist> MpdMembersCchiHists { get; set; }

		public MpdMembersCchi()
		{
			MpdMembersCchiHists = new HashSet<MpdMembersCchiHist>();
		}
	}
}
