using System;

public class CUSTOMERADDRESS
{
	public CUSTOMERS CUSTOMERS { get; set; }

	public int ID { get; set; }

	public int CUSTOMER_ID { get; set; }

	public int COUNTRY_ID { get; set; }

	public int CITY_ID { get; set; }

	public int AREA_ID { get; set; }

	public string STREET { get; set; }

	public string BUILDING_NO { get; set; }

	public string FLOOR_NO { get; set; }

	public string ADDITIONAL_NO { get; set; }

	public string CREATED_BY { get; set; }

	public DateTime CREATION_DATE { get; set; }

	public object MODIFIED_BY { get; set; }

	public object MODIFICATION_DATE { get; set; }

	public int GOVERNATE { get; set; }

	public int CLUSTER_ADDRESS { get; set; }
}
