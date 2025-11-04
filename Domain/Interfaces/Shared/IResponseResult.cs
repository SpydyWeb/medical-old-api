using System.Collections.Generic;
using Domain.Enums;

namespace Domain.Interfaces.Shared
{
	public interface IResponseResult<T>
	{
		List<string> Errors { get; set; }

		ResultStatus Status { get; set; }

		T Data { get; set; }

		long TotalRecords { get; set; }
	}
}
