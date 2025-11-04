using System;

namespace Domain.Models.SearchCriteria
{
	public class MpdMembersCchiSearchCriteria
	{
		public int? PolicyNo { get; set; }

		public int? MemberId { get; set; }

		public string Name { get; set; }

		public string MemberRefNumber { get; set; }

		public int? Gender { get; set; }

		public int? MaritalStatus { get; set; }

		public int? Relation { get; set; }

		public int? PrincipleId { get; set; }

		public DateTime? BirthDate { get; set; }

		public int? MemberNo { get; set; }

		public string SegmentCode { get; set; }

		public short? AgeFrom { get; set; }

		public short? AgeTo { get; set; }

		public string NationalId { get; set; }

		public long? ClassCchiId { get; set; }

		public string CchiStatus { get; set; }

		public long? CustomerId { get; set; }

		public string ReferenceNo { get; set; }

		public string GdrfaMemberId { get; set; }

		public string Query { get; set; }

		public int PageIndex { get; set; }

		public int PageSize { get; set; }

		public int CompanyId { get; set; }

		public int? MpdOldPolicyId { get; set; }
	}
}
