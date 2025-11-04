using System.Collections.Generic;

public class newCustomerDTO
{
	public CUSTOMERBASICINFO CUSTOMER_BASIC_INFO { get; set; }

	public CUSTOMERCONTACT CUSTOMER_CONTACT { get; set; }

	public List<CUSTOMERADDRESS> CUSTOMER_ADDRESS { get; set; }

	public CUSTOMERACCOUNT CUSTOMER_ACCOUNT { get; set; }

	public List<CUSTOMERBANK> CUSTOMER_BANK { get; set; }

	public List<CUSTOMERTAX> CUSTOMER_TAXES { get; set; }

	public List<CUSTOMERRATING> CUSTOMER_RATING { get; set; }

	public List<CUSTOMERSHAREHOLDER> CUSTOMER_SHAREHOLDER { get; set; }

	public List<CUSTOMERHISTORY> CUSTOMER_HISTORY { get; set; }

	public List<CUSTOMERDOCUMENT> CUSTOMER_DOCUMENT { get; set; }

	public List<CUSTOMERROLE> CUSTOMER_ROLES { get; set; }

	public List<CUSTOMERAGENT> CUSTOMER_AGENTs { get; set; }

	public List<CUSTOMERACCOUNT> CUSTOMER_ACCOUNTS { get; set; }
}
