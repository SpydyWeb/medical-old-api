using System.Collections.Generic;
using CORE.DTOs.MotorClaim.Integrations.Tables;

namespace CORE.DTOs.MotorClaim.Integrations.APIs
{
	public class TaqdeerResponse
	{
		public TaqdeerCase TaqdeerCase { get; set; }

		public List<TaqdeerFeesDetail> Fees { get; set; }

		public List<TaqdeerSparePartsInfo> SpareParts { get; set; }

		public List<TaqdeerSparePartDetail> Parts { get; set; }

		public List<TaqdeerImageDetaila> taqdeerImageDetailas { get; set; }

		public TaqdeerResponse()
		{
			SpareParts = new List<TaqdeerSparePartsInfo>();
			Parts = new List<TaqdeerSparePartDetail>();
			Fees = new List<TaqdeerFeesDetail>();
			TaqdeerCase = new TaqdeerCase();
			taqdeerImageDetailas = new List<TaqdeerImageDetaila>();
		}
	}
}
