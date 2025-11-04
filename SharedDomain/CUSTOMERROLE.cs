using System.Collections.Generic;

public class CUSTOMERROLE
{
	public int ID { get; set; }

	public int CUSTOMER_ID { get; set; }

	public int ROLE_ID { get; set; }

	public int CATEGORY_ID { get; set; }

	public int IS_AGENT_ROLE { get; set; }

	public List<CATEGORYLIST> CATEGORY_LIST { get; set; }
}
