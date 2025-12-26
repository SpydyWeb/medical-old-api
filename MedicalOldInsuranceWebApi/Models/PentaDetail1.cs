using System;
using System.Collections.Generic;

namespace InsuranceAPIs.Models
{
    public partial class PentaDetail1
    {
        public string? ProposerQuoteId { get; set; }
        public string? ProposerIdNumber { get; set; }
        public string? MemQuoteId { get; set; }
        public string? MemIdNumber { get; set; }
        public string? SegmentCode { get; set; }
        public string? CreateQuotationReq { get; set; }
        public string? CreateQuotationResp { get; set; }
        public string? CreateProposalReq { get; set; }
        public string? CreateProposalResp { get; set; }
        public string? IssuePolicyReq { get; set; }
        public string? IssuePolicyResp { get; set; }
        public string? CalPremiumReq { get; set; }
        public string? CalPremiumResp { get; set; }
        public string? Status { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
