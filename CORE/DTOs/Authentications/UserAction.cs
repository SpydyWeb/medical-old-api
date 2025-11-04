using System;

namespace CORE.DTOs.Authentications
{
	public class UserAction
	{
		public long Id { get; set; }

		public string Username { get; set; }

		public int ActionId { get; set; }

		public DateTime DateOfAction { get; set; }

		public bool ResultOfAction { get; set; }
	}
}
