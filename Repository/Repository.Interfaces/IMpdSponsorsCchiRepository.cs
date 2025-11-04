using System.Collections.Generic;
using Domain.Models;

namespace Repository.Interfaces
{
	public interface IMpdSponsorsCchiRepository : IRepository<MpdSponsorsCchi>
	{
		List<MpdSponsorsCchi> LoadSponsors(long PolicyCchiId);
	}
}
