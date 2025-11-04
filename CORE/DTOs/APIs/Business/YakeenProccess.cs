namespace CORE.DTOs.APIs.Business
{
	public class YakeenProccess
	{
		public ErrorMembers errorMembers { get; set; }

		public MembersData membersData { get; set; }

		public bool Status { get; set; }

		public YakeenProccess()
		{
			errorMembers = new ErrorMembers();
			membersData = new MembersData();
		}
	}
}
