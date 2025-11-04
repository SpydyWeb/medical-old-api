using System;

public class DocumentList
{
	public long ID { get; set; }

	public long CUSTOMER_ID { get; set; }

	public int DOCUMENT_TYPE { get; set; }

	public string DOCUMENT_NO { get; set; }

	public string DESCRIPTION { get; set; }

	public DateTime ISSUANCE_DATE { get; set; }

	public DateTime EXPIRY_DATE { get; set; }

	public string ISSUANCE_PLACE { get; set; }

	public int YEAR { get; set; }

	public string FILE_PATH { get; set; }
}
