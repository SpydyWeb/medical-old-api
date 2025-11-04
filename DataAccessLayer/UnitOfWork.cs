using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
	public class UnitOfWork : IUnitOfWork, IDisposable
	{
		public int Id { get; set; }

		public bool IsToBeCommitted { get; private set; }

		public DataBaseContext DatabaseContext { get; private set; }

		public DbSet<T> Repository<T>() where T : class
		{
			return DatabaseContext.Set<T>();
		}

		public UnitOfWork(DataBaseContext databaseContext)
		{
			Id = new Random().Next(1, 20);
			try
			{
				DatabaseContext = databaseContext;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public void Commit()
		{
			DatabaseContext.SaveChanges();
			if (DatabaseContext.Database.CurrentTransaction != null)
			{
				DatabaseContext.Database.CurrentTransaction.Commit();
			}
		}

		public void Commit(DataBaseContext dbContext)
		{
			dbContext.SaveChanges();
		}

		public async Task CommitAsync()
		{
			await DatabaseContext.SaveChangesAsync();
		}

		public void SetToBeCommitted()
		{
			IsToBeCommitted = true;
		}

		public void SetToBeCommitted(bool var)
		{
			IsToBeCommitted = var;
		}

		public void End()
		{
			if (!IsToBeCommitted)
			{
				return;
			}
			try
			{
				Commit();
			}
			catch (Exception ex)
			{
				Rollback();
				throw ex;
			}
			finally
			{
			}
		}

		public void Rollback()
		{
			DatabaseContext.Database.CurrentTransaction?.Rollback();
			Dispose(disposning: true);
		}

		public void Dispose()
		{
			Dispose(disposning: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposning)
		{
			if (DatabaseContext != null)
			{
				if (DatabaseContext.Database.CurrentTransaction != null)
				{
					DatabaseContext.Database.CurrentTransaction.Dispose();
				}
				DatabaseContext.Dispose();
				DatabaseContext = null;
			}
			SetToBeCommitted(var: false);
		}

		~UnitOfWork()
		{
			Dispose(disposning: false);
		}
	}
}
