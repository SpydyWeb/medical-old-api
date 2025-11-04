namespace CORE.DTOs.APIs.Business
{
	public class DeclarationsAnswers
	{
		public HealthDeclarations healthDeclarations { get; set; }

		public bool Answer { get; set; }

		public DeclarationsAnswers()
		{
			healthDeclarations = new HealthDeclarations();
		}
	}
}
