using System;

namespace SharedDomain.DTO.Approval
{
	public class IanDictionaryDTO
	{
		public long Id { get; set; }

		public string Name { get; set; }

		public byte? DataType { get; set; }

		public string Query { get; set; }

		public string CreationUser { get; set; }

		public DateTime CreationDate { get; set; }

		public string ModificationUser { get; set; }

		public DateTime? ModificationDate { get; set; }
	}
}
