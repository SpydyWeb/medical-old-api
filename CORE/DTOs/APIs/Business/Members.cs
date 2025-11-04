using System.Collections.Generic;

namespace CORE.DTOs.APIs.Business
{
    public class Members
    {
        public MembersData membersData { get; set; }

        public List<MembersData> dependMember { get; set; }

        public List<ErrorMembers> ErrDep { get; set; }
      
        public Members()
        {
            dependMember = new List<MembersData>();
            membersData = new MembersData();
            ErrDep = new List<ErrorMembers>();
        }
    }
}
