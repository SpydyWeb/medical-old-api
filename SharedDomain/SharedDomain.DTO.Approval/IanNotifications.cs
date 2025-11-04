using System;

namespace SharedDomain.DTO.Approval
{
	public class IanNotifications
	{
		public long Id { get; set; }

		public string Name { get; set; }

		public string Name2 { get; set; }

		public byte? Status { get; set; }

		public string Notes { get; set; }

		public string SessionKey { get; set; }

		public long? SystemId { get; set; }

		public long CompanyId { get; set; }

		public string CreationUser { get; set; }

		public DateTime CreationDate { get; set; }

		public string ModificationUser { get; set; }

		public DateTime? ModificationDate { get; set; }
	}
}
