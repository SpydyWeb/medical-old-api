using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
	public interface IUnitOfWork : IDisposable
	{
		int Id { get; set; }

		DataBaseContext DatabaseContext { get; }

		DbSet<T> Repository<T>() where T : class;

		void Commit();

		void Commit(DataBaseContext dbContext);

		Task CommitAsync();

		void End();

		void Rollback();

		void SetToBeCommitted();
	}
}
