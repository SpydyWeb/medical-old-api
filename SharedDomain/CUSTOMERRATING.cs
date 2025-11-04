using System;

public class CUSTOMERRATING
{
	public CUSTOMERS CUSTOMERS { get; set; }

	public int ID { get; set; }

	public int CUSTOMER_ID { get; set; }

	public DateTime EFFECTIVE_DATE { get; set; }

	public double RATE { get; set; }

	public string RATED_BY { get; set; }

	public string CREATED_BY { get; set; }

	public DateTime CREATION_DATE { get; set; }

	public string MODIFIED_BY { get; set; }

	public DateTime MODIFICATION_DATE { get; set; }
}
