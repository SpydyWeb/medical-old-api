using System;

public class CUSTOMERTAX
{
	public CUSTOMERS CUSTOMERS { get; set; }

	public int ID { get; set; }

	public int CUSTOMER_ID { get; set; }

	public int TAX_TYPE { get; set; }

	public double PERCENTAGE { get; set; }

	public string ACCOUNT_NO { get; set; }

	public string CREATED_BY { get; set; }

	public DateTime CREATION_DATE { get; set; }

	public string MODIFIED_BY { get; set; }

	public DateTime MODIFICATION_DATE { get; set; }

	public int INCOME_TAX_NO { get; set; }

	public object SALES_TAX_NO { get; set; }

	public int TAXABLE { get; set; }

	public object DEFAULT_FOR { get; set; }

	public int TAX_NO { get; set; }

	public object TAX_NAME { get; set; }
}
