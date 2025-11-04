using System.Collections.Generic;
using SharedSetup.Domain.Enums;

namespace SharedSetup.Domain.Interfaces.Shared
{
	public interface IResponseResult<T>
	{
		List<string> Errors { get; set; }

		ResultStatus Status { get; set; }

		T Data { get; set; }
	}
}
