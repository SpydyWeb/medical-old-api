using CORE.TablesObjects;

namespace CORE.DTOs.APIs.Business
{
	public class CorrectionInput
	{
		public string PolicyNo { get; set; }

		public string BorderNo { get; set; }

		public Subjects members { get; set; }

		public CorrectionInput()
		{
			members = new Subjects();
		}
	}
}
