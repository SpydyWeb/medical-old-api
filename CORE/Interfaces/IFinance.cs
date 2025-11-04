using System.Collections.Generic;
using CORE.DTOs.Business;
using CORE.Services;

namespace CORE.Interfaces
{
	public interface IFinance : ISvc
	{
		CreditLimits InsertUpdateCreditLimit(CreditLimits creditLimit);

		CreditLimits LoadCreditLimit(long EskaUserId, int? Id = null, int? UserId = null);

		List<CreditLimits> LoadAllCreditLimit();

		List<CreditLimitHistory> LoadCreditLimitHistory(int CreditLimitId);

		CreditLimitHistory InsertCreditLimitHistory(CreditLimitHistory creditLimitHistory);
	}
}
