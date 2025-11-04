using System;

namespace Domain.Common
{
	public class BaseModel
	{
		public long Id { get; set; }

		public string CreationUser { get; set; }

		public DateTime CreationDate { get; set; }

		public string ModificationUser { get; set; }

		public DateTime? ModificationDate { get; set; }
	}
}
