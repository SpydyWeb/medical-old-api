using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DTOs.APIs.Process
{
    public class OnlineTransactions
    {
        public int? Id { get; set; }

        public string? InvoiceNo { get; set; }

        public string? InternalCode { get; set; }

        public int? PolicyId { get; set; }

        public int? Status { get; set; }

        public DateTime EffectiveDate { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public DateTime? PaymentDate { get; set; }

        public string? BillNo { get; set; }

        public string? EPTN { get; set; }

        public decimal? PaymentAmount { get; set; }
    }
}
