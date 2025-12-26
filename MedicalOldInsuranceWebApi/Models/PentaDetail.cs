using System;
using System.Collections.Generic;

namespace InsuranceAPIs.Models
{
    public partial class PentaDetail
    {
        public int Id { get; set; }
        public string? QuoteId { get; set; }
        public string? IdNumber { get; set; }
        public string? MemIdNumber { get; set; }
        public string? SegmentCode { get; set; }
        public string? CreateQuotationReq { get; set; }
        public string? CreateQuotationResp { get; set; }
        public string? IssuePolicyReq { get; set; }
        public string? IssuePolicyResp { get; set; }
        public string? CalPremiumReq { get; set; }
        public string? CalPremiumResp { get; set; }
        public string? Status { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? QuotationNumber { get; set; }
        public string? QuoteNo { get; set; }
    }
}
