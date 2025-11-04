using System.Collections.Generic;
using Domain.Enums;
using Domain.Interfaces.Shared;

namespace Domain.Common
{
	public class ResponseResult<T> : IResponseResult<T>
	{
		public List<string> Errors { get; set; }

		public ResultStatus Status { get; set; }

		public T Data { get; set; }

		public long TotalRecords { get; set; }
	}
}
