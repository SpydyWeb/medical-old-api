using System.Collections.Generic;
using CORE.DTOs.MotorClaim.Integrations.Tables;

namespace CORE.DTOs.MotorClaim.Integrations.APIs
{
	public class NajmResponse
	{
		public NajmAccidentinfo najmAccidentinfo { get; set; }

		public List<NajmPartiesInfo> lsNajmPartiesInfo { get; set; }

		public List<NajmDamageInfo> najmDamageInfos { get; set; }

		public List<NajmActs> najmActs { get; set; }

		public List<NajmImageInfo> najmImageInfos { get; set; }

		public List<PartyInsuranceInfo> partyInsuranceInfos { get; set; }

		public NajmResponse()
		{
			lsNajmPartiesInfo = new List<NajmPartiesInfo>();
			najmActs = new List<NajmActs>();
			najmAccidentinfo = new NajmAccidentinfo();
			najmDamageInfos = new List<NajmDamageInfo>();
			najmImageInfos = new List<NajmImageInfo>();
			partyInsuranceInfos = new List<PartyInsuranceInfo>();
		}
	}
}
