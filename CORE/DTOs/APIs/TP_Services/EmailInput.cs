namespace CORE.DTOs.APIs.TP_Services
{
    public class EmailInput
    {
        public string ToEmail { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public bool isApproval { get; set; }

        public int? approvalID { get; set; }

        public List<EmailAttachments>? attachments { get; set; }
    }
    public class EmailAttachments
    {
        public string Name { get; set; }
        public string attachmentpath { get; set; }
        public string extName { get; set; }
    }
}
