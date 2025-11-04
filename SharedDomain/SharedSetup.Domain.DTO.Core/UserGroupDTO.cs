namespace SharedSetup.Domain.DTO.Core
{
	public class UserGroupDTO
	{
		public long iD { get; set; }

		public long cRG_COM_ID { get; set; }

		public string uSERNAME { get; set; }

		public long cSR_GRP_ID { get; set; }

		public string gROUP_NAME { get; set; }

		public long gROUPID { get; set; }

		public string gROUP_STATUS { get; set; }

		public string cOMPANY { get; set; }

		public string fULLNAME { get; set; }

		public UserGroupDTO(long Id, long CRG_COM_ID, long CSR_GRP_ID, string userName, long groupId, string groupName, string groupStatus, string company)
		{
			iD = Id;
			cRG_COM_ID = CRG_COM_ID;
			uSERNAME = userName;
			cSR_GRP_ID = CSR_GRP_ID;
			gROUP_NAME = groupName;
			gROUPID = groupId;
			gROUP_STATUS = groupStatus;
			cOMPANY = company;
		}
	}
}
