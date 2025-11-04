using System;
using System.Collections.Generic;

namespace SharedDomain.DTO.New_Financial_Model
{
	public class Transaction
	{
		public DateTime? JournalDate { get; set; }

		public string TransactionCode { get; set; }

		public string SegmentCode { get; set; }

		public string Source { get; set; }

		public string Notes { get; set; }

		public string ReferenceNo { get; set; }

		public long CompanyId { get; set; }

		public long BranchId { get; set; }

		public string CreatedBy { get; set; }

		public string Currency { get; set; }

		public decimal Exrate { get; set; }

		public string AppRefId { get; set; }

		public long? Endorsement_No { get; set; }

		public string CLAIM_NO { get; set; }

		public List<TRANSDETAIL> TRANS_DETAILS { get; set; }

		public ClaimInfo Claim_Info { get; set; }
	}
}
