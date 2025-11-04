using System;
using System.Linq;
using CORE.DTOs.Mapping;
using CORE.Interfaces;
using CORE.Services;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InfraStructure.Services
{
	public class Mapping : Svc, IMapping, ISvc
	{
		public Mapping(IUnitOfWork unitOfWork, IServiceScopeFactory factory)
			: base(unitOfWork)
		{
		}

		public YakeenNationalityMapping? YakeenNationality(int id)
		{
			YakeenNationalityMapping nAtionalityMAppings = new YakeenNationalityMapping();
			return Action(delegate(DataBaseContext context)
			{
				try
				{
					nAtionalityMAppings = (from p in ((DbContext)(object)context).Set<YakeenNationalityMapping>().AsQueryable()
						where p.TAMEENI_ID == id
						select p).FirstOrDefault();
					return nAtionalityMAppings;
				}
				catch (Exception)
				{
					return nAtionalityMAppings;
				}
			});
		}
	}
}
