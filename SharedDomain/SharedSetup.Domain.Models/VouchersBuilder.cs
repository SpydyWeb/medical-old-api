using System;

namespace SharedSetup.Domain.Models
{
	public class VouchersBuilder
	{
		public string Id { get; set; }

		public string TransactionId { get; set; }

		public string FglTransactionId { get; set; }

		public byte TransactionType { get; set; }

		public DateTime VoucherDate { get; set; }

		public string CreationBy { get; set; }

		public string ErorrMsg { get; set; }

		public byte? PortType { get; set; }

		public byte? DocumentID { get; set; }

		public byte? IsCustGroup { get; set; }

		public long SystemId { get; set; }

		public byte? PostLeadingShareOnly { get; set; }

		public byte? InwardCommSeperateVoucher { get; set; }

		public byte? LongTermSubTransaction { get; set; }

		public byte? IsPosted { get; set; }
	}
}
