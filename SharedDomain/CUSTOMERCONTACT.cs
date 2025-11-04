using System;

public class CUSTOMERCONTACT
{
	public CUSTOMERS CUSTOMERS { get; set; }

	public int ID { get; set; }

	public int CUSTOMER_ID { get; set; }

	public string PHONE_NO_PRIMARY { get; set; }

	public string PHONE_NO_SECONDARY { get; set; }

	public string MOBILE_NO_PRIMARY { get; set; }

	public string MOBILE_NO_SECONDARY { get; set; }

	public string FAX { get; set; }

	public string PO_BOX { get; set; }

	public string POSTAL_CODE { get; set; }

	public object PREFERRED_NOTIFICATION { get; set; }

	public string PRIMARY_EMAIL { get; set; }

	public string SECONDARY_EMAIL { get; set; }

	public string WEBSITE { get; set; }

	public object COMMUNICATION_LANGUAGE { get; set; }

	public string CREATED_BY { get; set; }

	public DateTime CREATION_DATE { get; set; }

	public string MODIFIED_BY { get; set; }

	public DateTime MODIFICATION_DATE { get; set; }
}
