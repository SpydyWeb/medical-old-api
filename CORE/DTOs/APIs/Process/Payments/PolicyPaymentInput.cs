using System.Text.Json.Serialization;

namespace CORE.DTOs.APIs.Process.Payments
{
    public class PolicyPaymentInput
    {
        public string Key { get; set; }
        public string? PaymentBody { get; set; }
        public string? PaymentMethod { get; set; }
        public string? VatNumber { get; set; }
    }
    public class PolicyBankPaymentInput
    {
        public string Key { get; set; }
        public string? ReferenceNo { get; set; }
    }
    public class PaymentBankBody
    {
        public string amount { get; set; }
        public string order_description { get; set; }
        public string merchant_reference { get; set; }
        public string token_name { get; set; }
    }

    public class PayfortPaymentStatusResponse
    {
        public string transactionStatus { get; set; }
        public string transaction_code { get; set; }
        public string transaction_status { get; set; }
        public string response_code { get; set; }
        public string signature { get; set; }
        public string transaction_message { get; set; }
        public string language { get; set; }
        public string fort_id { get; set; }
        public string refunded_amount { get; set; }
        public string response_message { get; set; }
        public string merchant_reference { get; set; }
        public string query_command { get; set; }
        public string captured_amount { get; set; }
        public string authorized_amount { get; set; }
        public string status { get; set; }
    }

}
