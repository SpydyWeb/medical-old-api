using System.Collections.Generic;
using CORE.DTOs.APIs.Unified_Response;

namespace CORE.DTOs.APIs.Business
{
	public class LoadDeclerationOutput : Results
	{
		public List<MembersDeclarations> MembersDeclarations { get; set; }

		public LoadDeclerationOutput()
		{
			MembersDeclarations = new List<MembersDeclarations>();
		}
	}
}
