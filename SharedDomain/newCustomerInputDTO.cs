using System.Collections.Generic;

public class newCustomerInputDTO
{
	public PersonalInfo PersonalInfo { get; set; }

	public ContactDetails ContactDetails { get; set; }

	public List<AddressList> AddressList { get; set; }

	public AccountInfo AccountInfo { get; set; }

	public List<BankList> BankList { get; set; }

	public List<CustomerRoleList> CustomerRoleList { get; set; }

	public List<TaxList> TaxList { get; set; }

	public List<RateList> RateList { get; set; }

	public List<ShareHolderList> ShareHolderList { get; set; }

	public List<DocumentList> DocumentList { get; set; }

	public List<AgentCustomer> AgentCustomer { get; set; }
}
