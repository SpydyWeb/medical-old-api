using System.Collections.Generic;
using CORE.DTOs.APIs.Unified_Response;

namespace CORE.DTOs.APIs.Business
{
	public class ValidationMembers : Results
	{
		public List<Members> LsSuccessMembers { get; set; }

		public List<ErrorMembers> lsError { get; set; }

		public ValidationMembers()
		{
			LsSuccessMembers = new List<Members>();
			lsError = new List<ErrorMembers>();
		}
	}
}
