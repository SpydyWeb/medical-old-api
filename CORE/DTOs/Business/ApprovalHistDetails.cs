using System;

namespace CORE.DTOs.Business
{
    public class ApprovalHistDetails
    {
        public long Id { get; set; }

        public int Status { get; set; }

        public string? RejectionReason { get; set; }

        public bool? isSMSSent { get; set; }

        public bool? isEmail { get; set; }

        public string? Attachments { get; set; }

        public int? ApprovalUserId { get; set; }

        public int PolicyId { get; set; }

        public DateTime RecievedDate { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public long AppHistID { get; set; }
        public string? Comments { get; set; }
    }
}
