using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Models.DTOs
{
	public class MessageBody
	{
		public Dictionary<string, string> Body { get; set; }

		public MessageBody()
		{
			Body = new Dictionary<string, string>();
		}

		public string CreateMessageBody()
		{
			StringBuilder stringBuilder = new StringBuilder();
			string Key = "";
			string Value = "";
			for (int i = 0; i < Body.Count; i++)
			{
				Key = Body.ElementAt(i).Key;
				Value = Body.ElementAt(i).Value;
				stringBuilder.AppendLine(Key + " : " + Value);
			}
			return stringBuilder.ToString();
		}

		public void AddMessageLine(string Key, string value)
		{
			Body[Key] = value;
		}
	}
}
