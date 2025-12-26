using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.TablesObjects
{
    [Table("PentaDetails", Schema = "dbo")]
    public class PentaDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        public string? QuoteId { get; set; }

        [StringLength(100)]
        public string? IdNumber { get; set; }

        [StringLength(100)]
        public string? MemIdNumber { get; set; }

        [StringLength(100)]
        public string? SegmentCode { get; set; }

        public string? CreateQuotationReq { get; set; }

        public string? CreateQuotationResp { get; set; }

        public string? IssuePolicyReq { get; set; }

        public string? IssuePolicyResp { get; set; }

        public string? CalPremiumReq { get; set; }

        public string? CalPremiumResp { get; set; }

        [StringLength(100)]
        public string? Status { get; set; }

        [StringLength(100)]
        public string? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string? QuotationNumber { get; set; }

        [StringLength(1)]
        public string? QuoteNo { get; set; }
    }

    public class IssuePolicyRequest
    {
        public string quotationNo { get; set; }
        public ReceiptDetails receiptDetails { get; set; }
    }
    public class ReceiptDetails
    {
        public string proposalNo { get; set; }
        public string instrumentType { get; set; }
        public string instrumentBank { get; set; }
        public string instrumentBankBranch { get; set; }
        public string instrumentNo { get; set; }
        public string creditCardType { get; set; }
        public string creditCardNo { get; set; }
        public string creditCardValidFrom { get; set; }
        public string creditCardValidTo { get; set; }
        public string receiptCode { get; set; }
    }
    public class IssuepolicyReturnValue
    {
        public string policyNo { get; set; }
        public string receiptNo { get; set; }
        public double receiptAmount { get; set; }
    }

    public class IssuePolicyResponse
    {
        public bool status { get; set; }
        public IssuepolicyReturnValue returnValue { get; set; }
        public object returnValues { get; set; }
        public object errors { get; set; }
    }
}
