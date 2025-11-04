using System;

public class CUSTOMERDOCUMENT
{
	public CUSTOMERS CUSTOMERS { get; set; }

	public int ID { get; set; }

	public int CUSTOMER_ID { get; set; }

	public int DOCUMENT_TYPE { get; set; }

	public string DOCUMENT_NO { get; set; }

	public string DESCRIPTION { get; set; }

	public DateTime ISSUANCE_DATE { get; set; }

	public DateTime EXPIRY_DATE { get; set; }

	public string ISSUANCE_PLACE { get; set; }

	public int YEAR { get; set; }

	public string FILE_PATH { get; set; }

	public string CREATED_BY { get; set; }

	public DateTime CREATION_DATE { get; set; }

	public string MODIFIED_BY { get; set; }

	public DateTime MODIFICATION_DATE { get; set; }
}
