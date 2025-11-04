using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using Domain.Common;
using Domain.Enums;
using Domain.Interfaces.Shared;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;

namespace Repository.Interfaces
{
	public interface IRepository<IEntity> where IEntity : class
	{
		IEntity Get(long id);

		IEntity Get(long id, int companyId);

		IQueryable<IEntity> GetAll();

		IQueryable<IEntity> GetAll(int companyId);

		IQueryable<IEntity> Find(Expression<Func<IEntity, bool>> where, params Expression<Func<IEntity, object>>[] navigationProperties);

		IEntity SingleOrDefault(Expression<Func<IEntity, bool>> predicate);

		IEntity Add(IEntity entity);

		IEnumerable<IEntity> AddRange(IEnumerable<IEntity> entities);

		IEntity Remove(IEntity entity);

		IEnumerable<IEntity> RemoveRange(IEnumerable<IEntity> entities);

		IEntity Update(IEntity entity, bool disableAttach = false);

		IEnumerable<IEntity> UpdateRange(IEnumerable<IEntity> Entities);

		IEnumerable<IEntity> AddRange(IEnumerable<IEntity> entities, Expression<Action<IEnumerable<IEntity>>> action);

		int GetSequance(string tableName);

		void SaveChanges();

		IDbContextTransaction BeginTransaction();

		void CommitTransaction();

		void RollbackTransaction();

		void UseTransaction(DbTransaction transaction);

		IResponseResult<long> GenerateSerial(long branchId, Application systemId, long? classId, long? policyType, SerialTypes serialType, long? businessChannel, long? businessType, DateTime issueDate);

		IResponseResult<string> GenerateSegmentCode(Application systemId, SegmentTypes segmentTypes, long id);

		IQueryable<TResult> FindMany<TResult>(Expression<Func<IEntity, TResult>> selector, Expression<Func<IEntity, bool>> predicate = null, Func<IQueryable<IEntity>, IOrderedQueryable<IEntity>> orderBy = null, Func<IQueryable<IEntity>, IIncludableQueryable<IEntity, object>> include = null, bool disableTracking = false);

		IQueryable<TResult> FindManyWithPaginations<TResult>(Expression<Func<IEntity, TResult>> selector, Expression<Func<IEntity, bool>> predicate, Func<IQueryable<IEntity>, IIncludableQueryable<IEntity, object>> include, Func<IQueryable<IEntity>, IOrderedQueryable<IEntity>> orderBy, int pageNumber, int pageSize, ref long totalRecords);

		IQueryable<IEntity> Filter(Expression<Func<IEntity, bool>> where, Func<IQueryable<IEntity>, IIncludableQueryable<IEntity, object>> include = null);

		IQueryable<IEntity> FilterWithPaginations(Expression<Func<IEntity, bool>> where, int pageNumber, int pageSize, ref long totalRecords, Func<IQueryable<IEntity>, IIncludableQueryable<IEntity, object>> include = null, Func<IQueryable<IEntity>, IOrderedQueryable<IEntity>> orderBy = null);

		ResponseResult<IEnumerable<SelectItem>> ExecuteQuerySuggest(string sqlQuery);

		ResponseResult<IEnumerable<string>> ExecuteAsJsonArray(string sqlQuery);

		ResponseResult<DataTable> ExecuteDataTable(string sqlQuery);

		IQueryable<IEntity> WhereMany(List<Expression<Func<IEntity, bool>>> predicate, params Expression<Func<IEntity, object>>[] navigationProperties);

		IQueryable<IEntity> GetByCriteria(List<Expression<Func<IEntity, bool>>> filterExpressions, int pageSize, out long totalRecords, int pageNumber = 1, bool orderByDescending = true, Expression<Func<IEntity, IComparable>>[] orderExpressions = null, Expression<Func<IEntity, IEntity>> selectEpressions = null, params Expression<Func<IEntity, object>>[] includExpressions);
	}
}
