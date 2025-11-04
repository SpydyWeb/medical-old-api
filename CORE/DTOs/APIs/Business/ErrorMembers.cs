using System.Collections.Generic;

namespace CORE.DTOs.APIs.Business
{
	public class ErrorMembers
	{
		public Princible membersData { get; set; }

		public List<ErrorsDependent> dependMember { get; set; }

		public ErrorMembers()
		{
			dependMember = new List<ErrorsDependent>();
			membersData = new Princible();
		}
	}
}
