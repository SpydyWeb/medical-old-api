using CORE.DTOs.Mapping;
using CORE.Services;

namespace CORE.Interfaces
{
	public interface IMapping : ISvc
	{
		YakeenNationalityMapping? YakeenNationality(int id);
	}
}
