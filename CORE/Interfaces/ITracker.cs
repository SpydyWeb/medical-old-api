using CORE.DTOs.Authentications;
using CORE.Services;

namespace CORE.Interfaces
{
	public interface ITracker : ISvc
	{
		UserAction InsertTracker(UserAction action);
	}
}
