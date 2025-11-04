using System;
using System.Data;
using System.Threading.Tasks;
using Fluentx;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
	public static class With
	{
		public static TResult Transaction<TResult>(IUnitOfWork unitOfWork, Func<DataBaseContext, TResult> transactional)
		{
			unitOfWork.SetToBeCommitted();
			Guard.Against<ArgumentNullException>(transactional.IsNull());
			unitOfWork.DatabaseContext.ChangeTracker.AutoDetectChangesEnabled = true;
			if (unitOfWork.DatabaseContext.Database.CurrentTransaction == null)
			{
				unitOfWork.DatabaseContext.Database.BeginTransaction(IsolationLevel.ReadCommitted);
			}
			try
			{
				return transactional(unitOfWork.DatabaseContext);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public static void Transaction(IUnitOfWork unitOfWork, Action<DataBaseContext> transactional)
		{
			unitOfWork.SetToBeCommitted();
			Guard.Against<ArgumentNullException>(transactional.IsNull());
			unitOfWork.DatabaseContext.ChangeTracker.AutoDetectChangesEnabled = true;
			if (unitOfWork.DatabaseContext.Database.CurrentTransaction == null)
			{
				unitOfWork.DatabaseContext.Database.BeginTransaction(IsolationLevel.ReadCommitted);
			}
			try
			{
				transactional(unitOfWork.DatabaseContext);
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public static TResult Action<TResult>(IUnitOfWork unitOfWork, Func<DataBaseContext, TResult> actional)
		{
			Guard.Against<ArgumentNullException>(actional.IsNull());
			return actional(unitOfWork.DatabaseContext);
		}

		public static async Task<TResult> ActionAsync<TResult>(IUnitOfWork unitOfWork, Func<DataBaseContext, Task<TResult>> actional)
		{
			Guard.Against<ArgumentNullException>(actional.IsNull());
			TResult result = await actional(unitOfWork.DatabaseContext);
			unitOfWork.DatabaseContext.ChangeTracker.AutoDetectChangesEnabled = false;
			return result;
		}

		public static async Task<TResult> ActionAsyncParallel<TResult>(IUnitOfWork unitOfWork, Func<DataBaseContext, Task<TResult>> actional)
		{
			Guard.Against<ArgumentNullException>(actional.IsNull());
			TResult result = await actional(unitOfWork.DatabaseContext);
			unitOfWork.DatabaseContext.ChangeTracker.AutoDetectChangesEnabled = false;
			return result;
		}

		public static void Action(IUnitOfWork unitOfWork, Action<DataBaseContext> actional)
		{
			Guard.Against<ArgumentNullException>(actional.IsNull());
			unitOfWork.DatabaseContext.ChangeTracker.AutoDetectChangesEnabled = false;
			actional(unitOfWork.DatabaseContext);
		}

		public static async Task ActionAsync(IUnitOfWork unitOfWork, Func<DataBaseContext, Task> actional)
		{
			Guard.Against<ArgumentNullException>(actional.IsNull());
			unitOfWork.DatabaseContext.ChangeTracker.AutoDetectChangesEnabled = false;
			await actional(unitOfWork.DatabaseContext);
		}
	}
}
