using System;

namespace SharedSetup.Domain.Common
{
	public class BaseModel2
	{
		public virtual long Id { get; }

		public virtual string TableName { get; }

		public string CreationUser { get; set; }

		public DateTime CreationDate { get; set; }

		public string ModificationUser { get; set; }

		public DateTime? ModificationDate { get; set; }
	}
}
