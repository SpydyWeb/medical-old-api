using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public class LoginDTO
	{
		public string userName { get; set; }

		public string password { get; set; }

		public int? companyId { get; set; }

		public int? branchId { get; set; }

		public string SessionId { get; set; }

		public int Timeout { get; set; }

		public string Token { get; set; }

		[JsonProperty("company_id")]
		private int? Company_id
		{
			set
			{
				companyId = value;
			}
		}

		[JsonProperty("session_id")]
		private string Session_id
		{
			set
			{
				SessionId = value;
			}
		}

		[JsonProperty("branch_id")]
		private int? Branch_id
		{
			set
			{
				branchId = value;
			}
		}

		public string language { get; set; }
	}

}
