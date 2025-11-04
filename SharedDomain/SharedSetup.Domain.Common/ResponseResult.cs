using System.Collections.Generic;
using SharedSetup.Domain.Enums;
using SharedSetup.Domain.Interfaces.Shared;

namespace SharedSetup.Domain.Common
{
	public class ResponseResult<T> : IResponseResult<T>
	{
		public List<string> Errors { get; set; }

		public ResultStatus Status { get; set; }

		public T Data { get; set; }

		public long TotalRecords { get; set; }
	}
}
