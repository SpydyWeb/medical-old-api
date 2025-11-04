using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Common;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Domain.Common;
using Domain.Context;
using Domain.Enums;
using Domain.Extension;
using Domain.Interfaces.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using Oracle.ManagedDataAccess.Client;
using Repository.Interfaces;

namespace Repository.Common
{
	public class Repository<IEntity> : IRepository<IEntity> where IEntity : BaseModel, new()
	{
		protected CchiDbContext Context;

		public Repository(CchiDbContext context)
		{
			Context = context;
		}

		public IEntity Add(IEntity entity)
		{
			entity.CreationDate = DateTime.Now;
			Context.Set<IEntity>().Add(entity);
			SaveChanges();
			Context.Entry(entity).GetDatabaseValues();
			return entity;
		}

		public IEnumerable<IEntity> AddRange(IEnumerable<IEntity> entities)
		{
			foreach (IEntity entity in entities)
			{
				entity.CreationDate = DateTime.Now;
			}
			Context.ChangeTracker.Entries<IEntity>();
			Context.Set<IEntity>().AddRange(entities);
			SaveChanges();
			return entities;
		}

		public IEnumerable<IEntity> AddRange(IEnumerable<IEntity> entities, Expression<Action<IEnumerable<IEntity>>> action)
		{
			action.Compile()(entities);
			foreach (IEntity entity in entities)
			{
				entity.CreationDate = DateTime.Now;
				entity.Id = ((Context.Set<IEntity>().Count() > 0) ? (Context.Set<IEntity>().Max((IEntity z) => z.Id) + 1) : 1);
				IEntity result = Context.Set<IEntity>().Add(entity).Entity;
				SaveChanges();
			}
			return entities;
		}

		public IQueryable<IEntity> Find(Expression<Func<IEntity, bool>> predicate, params Expression<Func<IEntity, object>>[] navigationProperties)
		{
			IQueryable<IEntity> dbQuery = EntityFrameworkQueryableExtensions.AsNoTracking(Context.Set<IEntity>()).AsQueryable();
			foreach (Expression<Func<IEntity, object>> navigationProperty in navigationProperties)
			{
				dbQuery = EntityFrameworkQueryableExtensions.AsNoTracking(EntityFrameworkQueryableExtensions.Include(dbQuery, navigationProperty));
			}
			return EntityFrameworkQueryableExtensions.AsNoTracking(dbQuery.Where(predicate));
		}

		public IQueryable<TResult> FindMany<TResult>(Expression<Func<IEntity, TResult>> selector, Expression<Func<IEntity, bool>> predicate = null, Func<IQueryable<IEntity>, IOrderedQueryable<IEntity>> orderBy = null, Func<IQueryable<IEntity>, IIncludableQueryable<IEntity, object>> include = null, bool disableTracking = true)
		{
			IQueryable<IEntity> query = Context.Set<IEntity>();
			if (disableTracking)
			{
				query = EntityFrameworkQueryableExtensions.AsNoTracking(query);
			}
			if (include != null)
			{
				query = include(query);
			}
			if (predicate != null)
			{
				query = query.Where(predicate);
			}
			if (orderBy != null)
			{
				return orderBy(query).Select(selector);
			}
			return query.Select(selector);
		}

		public IEntity Get(long Id)
		{
			return (from entity in EntityFrameworkQueryableExtensions.AsNoTracking(Context.Set<IEntity>())
				where entity.Id == Id
				select entity).FirstOrDefault();
		}

		public IEntity Get(long Id, int companyId)
		{
			IEntity result = (from entity in EntityFrameworkQueryableExtensions.AsNoTracking(Context.Set<IEntity>())
				where entity.Id == Id
				select entity).FirstOrDefault();
			if (result != null && new IEntity() is ICloudEntity && (result as ICloudEntity).CompanyId != companyId)
			{
				result = null;
			}
			return result;
		}

		public IQueryable<IEntity> GetAll()
		{
			try
			{
				IQueryable<IEntity> dbQuery = Context.Set<IEntity>();
				return EntityFrameworkQueryableExtensions.AsNoTracking(dbQuery);
			}
			catch (Exception ex)
			{
				string mass = ex.Message;
				return null;
			}
		}

		public IQueryable<IEntity> GetAll(int companyId)
		{
			IQueryable<IEntity> dbQuery = Context.Set<IEntity>();
			if (new IEntity() is ICloudEntity)
			{
				dbQuery = dbQuery.Where((IEntity e) => ((ICloudEntity)e).CompanyId == companyId);
			}
			return EntityFrameworkQueryableExtensions.AsNoTracking(dbQuery);
		}

		public int GetSequance(string tableName)
		{
			throw new NotImplementedException();
		}

		public IEntity Remove(IEntity entity)
		{
			Context.Set<IEntity>().Remove(entity);
			SaveChanges();
			return entity;
		}

		public IEnumerable<IEntity> RemoveRange(IEnumerable<IEntity> entities)
		{
			Context.Set<IEntity>().RemoveRange(entities);
			SaveChanges();
			return entities;
		}

		public void SaveChanges()
		{
			Context.SaveChanges();
		}

		public IDbContextTransaction BeginTransaction()
		{
			return Context.Database.BeginTransaction();
		}

		public void CommitTransaction()
		{
			Context.Database.CommitTransaction();
		}

		public void RollbackTransaction()
		{
			Context.Database.RollbackTransaction();
		}

		public void UseTransaction(DbTransaction transaction)
		{
			Context.Database.UseTransaction(transaction);
		}

		public IEntity SingleOrDefault(Expression<Func<IEntity, bool>> predicate)
		{
			IQueryable<IEntity> dbQuery = Context.Set<IEntity>();
			return EntityFrameworkQueryableExtensions.AsNoTracking(dbQuery).SingleOrDefault(predicate);
		}

		public IEntity Update(IEntity entity, bool disableAttach = false)
		{
			entity.ModificationDate = DateTime.Now;
			if (!disableAttach)
			{
				Context.Set<IEntity>().Attach(entity);
			}
			Context.Entry(entity).State = EntityState.Modified;
			SaveChanges();
			return entity;
		}

		public IEnumerable<IEntity> UpdateRange(IEnumerable<IEntity> entities)
		{
			foreach (IEntity entity in entities)
			{
				entity.ModificationDate = DateTime.Now;
			}
			Context.Set<IEntity>().UpdateRange(entities);
			SaveChanges();
			return entities;
		}

		public IQueryable<IEntity> Find(int companyId, Expression<Func<IEntity, bool>> predicate, params Expression<Func<IEntity, object>>[] navigationProperties)
		{
			IQueryable<IEntity> dbQuery = Context.Set<IEntity>();
			foreach (Expression<Func<IEntity, object>> navigationProperty in navigationProperties)
			{
				dbQuery = EntityFrameworkQueryableExtensions.Include(dbQuery, navigationProperty);
			}
			return EntityFrameworkQueryableExtensions.AsNoTracking(dbQuery.Where(predicate));
		}

		public IResponseResult<long> GenerateSerial(long branchId, Application systemId, long? classId, long? policyType, SerialTypes serialType, long? businessChannel, long? businessType, DateTime issueDate)
		{
			try
			{
				using DbConnection connection = new OracleConnection(SharedSettings.OracleConnectionString);
				long _documentSerial = 0L;
				connection.Open();
				using (DbCommand command = connection.CreateCommand())
				{
					command.CommandType = CommandType.StoredProcedure;
					command.CommandText = "DBP_ELEMENT_SERIAL";
					command.Parameters.Add(new OracleParameter("P_BRANCH_ID", OracleDbType.Int64, branchId, ParameterDirection.Input));
					command.Parameters.Add(new OracleParameter("P_SYSTEM_ID", OracleDbType.Int64, (long)systemId, ParameterDirection.Input));
					command.Parameters.Add(new OracleParameter("P_CLASS_ID", OracleDbType.Int64, classId, ParameterDirection.Input));
					command.Parameters.Add(new OracleParameter("P_POLICY_TYPE", OracleDbType.Int64, policyType, ParameterDirection.Input));
					command.Parameters.Add(new OracleParameter("P_SERIAL_TYPE", OracleDbType.Int64, (long)serialType, ParameterDirection.Input));
					command.Parameters.Add(new OracleParameter("P_BUSINESS_CHANNEL", OracleDbType.Int64, businessChannel, ParameterDirection.Input));
					command.Parameters.Add(new OracleParameter("P_BUSINESS_TYPE", OracleDbType.Int64, businessType, ParameterDirection.Input));
					command.Parameters.Add(new OracleParameter("P_DATE", OracleDbType.Date, issueDate, ParameterDirection.Input));
					command.Parameters.Add(new OracleParameter("P_SERIAL", OracleDbType.Int64, 100, DBNull.Value, ParameterDirection.Output));
					command.Parameters.Add(new OracleParameter("P_ERROR_MSG", OracleDbType.Varchar2, 800, DBNull.Value, ParameterDirection.Output));
					command.ExecuteNonQuery();
					if (command.Parameters["P_ERROR_MSG"].Value != DBNull.Value && !(command.Parameters["P_ERROR_MSG"].Value.ToString() == "null"))
					{
						return new ResponseResult<long>
						{
							Status = ResultStatus.Failed,
							Data = 0L,
							Errors = new List<string> { command.Parameters["P_ERROR_MSG"].Value.ToString() }
						};
					}
					if (command.Parameters["P_SERIAL"].Value != DBNull.Value && command.Parameters["P_SERIAL"].Value != null)
					{
						_documentSerial = Convert.ToInt64(command.Parameters["P_SERIAL"].Value.ToString());
					}
				}
				return new ResponseResult<long>
				{
					Status = ResultStatus.Success,
					Data = _documentSerial
				};
			}
			catch (Exception ex)
			{
				return new ResponseResult<long>
				{
					Status = ResultStatus.Failed,
					Data = 0L,
					Errors = new List<string> { "Exception Message : " + ex.Message }
				};
			}
		}

		public IResponseResult<string> GenerateSegmentCode(Application systemId, SegmentTypes segmentTypes, long id)
		{
			try
			{
				using DbConnection connection = new OracleConnection(SharedSettings.OracleConnectionString);
				string _segmentCode = string.Empty;
				connection.Open();
				using DbCommand command = connection.CreateCommand();
				command.CommandType = CommandType.StoredProcedure;
				command.CommandText = "DBF_BUILD_SEGMENT_CODE";
				command.Parameters.Add(new OracleParameter("V_SEGMENT_CODE", OracleDbType.Varchar2, 100, null, ParameterDirection.ReturnValue));
				command.Parameters.Add(new OracleParameter("P_SYSTEM_ID", OracleDbType.Int64, (long)systemId, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_SEGMENT_TYPE", OracleDbType.Int64, (long)segmentTypes, ParameterDirection.Input));
				command.Parameters.Add(new OracleParameter("P_ID", OracleDbType.Int64, id, ParameterDirection.Input));
				command.ExecuteNonQuery();
				if (command.Parameters["V_SEGMENT_CODE"].Value != DBNull.Value)
				{
					_segmentCode = command.Parameters["V_SEGMENT_CODE"].Value.ToString();
				}
				return new ResponseResult<string>
				{
					Status = ResultStatus.Success,
					Data = _segmentCode
				};
			}
			catch (Exception ex)
			{
				return new ResponseResult<string>
				{
					Status = ResultStatus.Failed,
					Data = null,
					Errors = new List<string> { "Exception Message : " + ex.Message }
				};
			}
		}

		protected virtual void Map(IDataRecord record, IEntity entity)
		{
			try
			{
				IEntityType entityType = Context.Model.FindEntityType(entity.GetType());
				List<PropertyInfo> properties = new List<PropertyInfo>(entity.GetType().GetProperties());
				foreach (PropertyInfo property in properties)
				{
					object[] notMapped = typeof(IEntity).GetProperty(property.Name).GetCustomAttributes(typeof(NotMappedAttribute), inherit: false);
					if (typeof(IEntity).GetProperty(property.Name).GetGetMethod().IsVirtual || notMapped.Length != 0)
					{
						continue;
					}
					IProperty databaseAttr = (from x in entityType.GetProperties()
						where x.Name == property.Name
						select x).FirstOrDefault();
					Type propertyType = property.PropertyType;
					string databaseNameAttr = databaseAttr.GetColumnBaseName();
					string strMappedName = property.Name;
					if (databaseNameAttr == null || !(databaseNameAttr != ""))
					{
						continue;
					}
					strMappedName = databaseNameAttr;
					if (HasName(record, strMappedName))
					{
						if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
						{
							propertyType = new NullableConverter(property.PropertyType).UnderlyingType;
						}
						if (record[strMappedName] == DBNull.Value)
						{
							property.SetValue(entity, null);
						}
						else if (propertyType.IsEnum)
						{
							property.SetValue(entity, Enum.ToObject(property.PropertyType, record[strMappedName]), null);
						}
						else
						{
							property.SetValue(entity, Convert.ChangeType(record[strMappedName], propertyType));
						}
					}
				}
			}
			catch (Exception e)
			{
				Exception ex = e;
			}
		}

		public static bool HasName(IDataRecord Record, string ColumnName)
		{
			for (int i = 0; i < Record.FieldCount; i++)
			{
				if (Record.GetName(i).ToLower().Equals(ColumnName.ToLower()))
				{
					return true;
				}
			}
			return false;
		}

		public IQueryable<TResult> FindManyWithPaginations<TResult>(Expression<Func<IEntity, TResult>> selector, Expression<Func<IEntity, bool>> predicate, Func<IQueryable<IEntity>, IIncludableQueryable<IEntity, object>> include, Func<IQueryable<IEntity>, IOrderedQueryable<IEntity>> orderBy, int pageNumber, int pageSize, ref long totalRecords)
		{
			IQueryable<IEntity> query = EntityFrameworkQueryableExtensions.AsNoTracking(include(EntityFrameworkQueryableExtensions.AsNoTracking(Context.Set<IEntity>())).Where(predicate).AsQueryable());
			totalRecords = query.Count();
			pageNumber = ((totalRecords == 1) ? 1 : pageNumber);
			return (orderBy != null) ? orderBy(query).Skip((pageNumber - 1) * pageSize).Take(pageSize).AsQueryable()
				.Select(selector) : query.Skip((pageNumber - 1) * pageSize).Take(pageSize).AsQueryable()
				.Select(selector);
		}

		public IQueryable<IEntity> Filter(Expression<Func<IEntity, bool>> where, Func<IQueryable<IEntity>, IIncludableQueryable<IEntity, object>> include = null)
		{
			return (include != null) ? EntityFrameworkQueryableExtensions.AsNoTracking(include(EntityFrameworkQueryableExtensions.AsNoTracking(Context.Set<IEntity>()).AsQueryable()).Where(where).AsQueryable()) : EntityFrameworkQueryableExtensions.AsNoTracking(EntityFrameworkQueryableExtensions.AsNoTracking(Context.Set<IEntity>()).AsQueryable().Where(where)
				.AsQueryable());
		}

		public IQueryable<IEntity> FilterWithPaginations(Expression<Func<IEntity, bool>> where, int pageNumber, int pageSize, ref long totalRecords, Func<IQueryable<IEntity>, IIncludableQueryable<IEntity, object>> include = null, Func<IQueryable<IEntity>, IOrderedQueryable<IEntity>> orderBy = null)
		{
			IQueryable<IEntity> query = ((include != null) ? EntityFrameworkQueryableExtensions.AsNoTracking(include(EntityFrameworkQueryableExtensions.AsNoTracking(Context.Set<IEntity>()).AsQueryable()).Where(where).AsQueryable()) : EntityFrameworkQueryableExtensions.AsNoTracking(EntityFrameworkQueryableExtensions.AsNoTracking(Context.Set<IEntity>()).AsQueryable().Where(where)
				.AsQueryable()));
			totalRecords = query.Count();
			pageNumber = ((totalRecords == 1) ? 1 : pageNumber);
			return (orderBy != null) ? orderBy(query).Skip((pageNumber - 1) * pageSize).Take(pageSize).AsQueryable() : query.Skip((pageNumber - 1) * pageSize).Take(pageSize).AsQueryable();
		}

		public ResponseResult<IEnumerable<string>> ExecuteAsJsonArray(string sqlQuery)
		{
			try
			{
				List<string> values = new List<string>();
				using (DbConnection connection = DataBaseExtensions.GetConnection())
				{
					connection.Open();
					using DbCommand command = connection.CreateCommand();
					command.CommandType = CommandType.Text;
					command.CommandText = sqlQuery;
					DbDataReader dr = command.ExecuteReader();
					string strToJson = "";
					while (dr.Read())
					{
						strToJson = "{ ";
						for (int i = 0; i < dr.FieldCount; i++)
						{
							string name = dr.GetName(i);
							strToJson = strToJson + "\"" + dr.GetName(i)?.ToString().ToUpper() + "\":\"" + dr.GetValue(i)?.ToString() + "\"";
							if (i != dr.FieldCount - 1)
							{
								strToJson += ",";
							}
						}
						strToJson += "}";
						values.Add(strToJson);
					}
				}
				return new ResponseResult<IEnumerable<string>>
				{
					Status = ResultStatus.Success,
					Data = values
				};
			}
			catch (Exception ex)
			{
				return new ResponseResult<IEnumerable<string>>
				{
					Errors = ((ex.Message != null) ? new List<string> { "Exception" + ex.Message } : new List<string> { "error in data" }),
					Status = ResultStatus.Failed,
					Data = null
				};
			}
		}

		public ResponseResult<DataTable> ExecuteDataTable(string sqlQuery)
		{
			try
			{
				try
				{
					List<string> values = new List<string>();
					DataTable table = new DataTable();
					using (DbConnection connection = DataBaseExtensions.GetConnection())
					{
						connection.Open();
						object obj = new ExpandoObject();
						using DbCommand command = connection.CreateCommand();
						command.CommandType = CommandType.Text;
						command.CommandText = sqlQuery;
						DbDataReader dr = command.ExecuteReader();
						table.Load(dr);
					}
					return new ResponseResult<DataTable>
					{
						Status = ResultStatus.Success,
						Data = table
					};
				}
				catch (Exception ex2)
				{
					return new ResponseResult<DataTable>
					{
						Errors = ((ex2.Message != null) ? new List<string> { "Exception" + ex2.Message } : new List<string> { "error in data" }),
						Status = ResultStatus.Failed,
						Data = null
					};
				}
			}
			catch (Exception ex)
			{
				return new ResponseResult<DataTable>
				{
					Errors = ((ex.Message != null) ? new List<string> { "Exception" + ex.Message } : new List<string> { "error in data" }),
					Status = ResultStatus.Failed,
					Data = null
				};
			}
		}

		public IQueryable<IEntity> WhereMany(List<Expression<Func<IEntity, bool>>> predicate, params Expression<Func<IEntity, object>>[] navigationProperties)
		{
			IQueryable<IEntity> dbQuery = Context.Set<IEntity>();
			IQueryable<IEntity> results = null;
			foreach (Expression<Func<IEntity, object>> navigationProperty in navigationProperties)
			{
				dbQuery = EntityFrameworkQueryableExtensions.Include(dbQuery, navigationProperty);
			}
			return EntityFrameworkQueryableExtensions.AsNoTracking(dbQuery.WhereMany(predicate));
		}

		public IQueryable<IEntity> GetByCriteria(List<Expression<Func<IEntity, bool>>> filterExpressions, int pageSize, out long totalRecords, int pageNumber = 1, bool orderByDescending = true, Expression<Func<IEntity, IComparable>>[] orderExpressions = null, Expression<Func<IEntity, IEntity>> selectEpressions = null, params Expression<Func<IEntity, object>>[] navigationProperties)
		{
			totalRecords = 0L;
			IQueryable<IEntity> dbQuery = Context.Set<IEntity>();
			IQueryable<IEntity> results = null;
			foreach (Expression<Func<IEntity, object>> navigationProperty in navigationProperties)
			{
				dbQuery = EntityFrameworkQueryableExtensions.Include(dbQuery, navigationProperty);
			}
			foreach (Expression<Func<IEntity, bool>> expression in filterExpressions)
			{
				dbQuery = EntityFrameworkQueryableExtensions.AsNoTracking(dbQuery.Where(expression));
			}
			if (orderExpressions != null)
			{
				IOrderedQueryable<IEntity> orderByResult = null;
				foreach (Expression<Func<IEntity, IComparable>> orderExpression in orderExpressions)
				{
					if (orderByResult == null)
					{
						orderByResult = ((!orderByDescending) ? dbQuery.OrderBy(orderExpression) : dbQuery.OrderByDescending(orderExpression));
					}
					else
					{
						dbQuery = ((!orderByDescending) ? orderByResult.ThenBy(orderExpression) : orderByResult.ThenByDescending(orderExpression));
					}
				}
				dbQuery = orderByResult;
			}
			totalRecords = dbQuery.Count();
			if (selectEpressions != null)
			{
				dbQuery = dbQuery.Select(selectEpressions);
			}
			return dbQuery.Skip((pageNumber - 1) * pageSize).Take(pageSize);
		}

		public ResponseResult<IEnumerable<SelectItem>> ExecuteQuerySuggest(string sqlQuery)
		{
			throw new NotImplementedException();
		}
	}
}
