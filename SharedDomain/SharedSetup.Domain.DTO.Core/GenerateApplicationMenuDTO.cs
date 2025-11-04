using System.Collections.Generic;

namespace SharedSetup.Domain.DTO.Core
{
	public class GenerateApplicationMenuDTO
	{
		public List<int> lstApplications { get; set; }

		public long CRG_COM_ID { get; set; }

		public string USERNAME { get; set; }
	}
}
