using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SoftwareOne.BaseLine.Core.DataAccess;
using SoftwareOne.BaseLine.Core.RequestDto;
using SoftwareOne.BaseLine.Core.ExtensionMethods;
using System.Linq.Expressions;
using System.Reflection;

namespace SoftwareOne.BaseLine.Core.SqlServer
{
    public abstract partial class BaseRepositoryDataAccess<T> : IBaseRepositoryDataAccess<T>
         where T : class, new()
    {
        private const int defaultReturnNull = -1;
        /// <summary>
        /// Constant that contains the default records to paginate.
        /// </summary>
        private const int DEFAULT_RECORDS = 10;

        protected BaseRepositoryDataAccess(IMainDataAccessContext Contexto)
        {
            this.Contexto = Contexto;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectAdd"></param>
        /// <returns></returns>
        public int Add(T objectAdd)
        {
            int returnAddObject = defaultReturnNull;
            if (objectAdd.IsNotNull())
            {
                Contexto.Set<T>().Add(objectAdd);
                returnAddObject = Contexto.SaveChanges();
            }

            return returnAddObject;
        }

        public int Add(IEnumerable<T> listObjectsAdd)
        {
            int returnAddObject = defaultReturnNull;
            if (listObjectsAdd != null && listObjectsAdd.IsNotNull())
            {
                Contexto.Set<T>().AddRange(listObjectsAdd);
                returnAddObject = Contexto.SaveChanges();
            }

            return returnAddObject;
        }

        public Task<T?> AddAsync(T objectAdd)
        {
            if (objectAdd != null && objectAdd.IsNotNull())
            {
                EntityEntry<T> entity = Contexto.Set<T>().Add(objectAdd);
                int result = Contexto.SaveChanges();
                if (result >= 1) {
                    return Task.FromResult<T?>(entity.Entity);
                }
            }
            return Task.FromResult<T?>(null);
        }

        public Task<int> AddAsync(IEnumerable<T> listObjectsAdd)
        {
            if (listObjectsAdd != null && listObjectsAdd.IsNotNull())
            {
                Contexto.Set<T>().AddRange(listObjectsAdd);
                return Contexto.SaveChangesAsync();
            }
            return Task.FromResult(defaultReturnNull);
        }

        public int Count(Expression<Func<T, bool>> expression)
        {
            if (expression != null)
            {
                return Contexto.Set<T>().Where(expression).Count();
            }

            return defaultReturnNull;
        }

        public bool? Delete(T? objectDelete)
        {
            if (objectDelete != null && objectDelete.IsNotNull())
            {
                Contexto.Set<T>().Remove(objectDelete);
                return Contexto.SaveChanges() != 0;
            }

            return null;
        }

        public bool? Delete(Expression<Func<T, bool>>? expression)
        {
            if (expression != null)
            {
                var objectDelete = Contexto.Set<T>().FirstOrDefault(expression);
                return this.Delete(objectDelete);
            }

            return null;
        }

        public bool? DeleteRange(Expression<Func<T, bool>> expression)
        {
            if (expression != null)
            {
                Contexto.Set<T>().RemoveRange(Contexto.Set<T>().Where(expression));
                return Contexto.SaveChanges() != 0;
            }

            return null;
        }

        public bool? DeleteRange(ICollection<T> listObjectsDelete)
        {
            if (listObjectsDelete != null && listObjectsDelete.IsNotNull())
            {
                Contexto.Set<T>().RemoveRange(listObjectsDelete);
                return Contexto.SaveChanges() != 0;
            }

            return null;
        }

        public Task<int> DeleteAsync(T? objectDelete)
        {
            if (objectDelete != null && objectDelete.IsNotNull())
            {
                Contexto.Set<T>().Remove(objectDelete);
                return Contexto.SaveChangesAsync();
            }

            return Task.FromResult<int>(defaultReturnNull);
        }

        public Task<int> DeleteAsync(Expression<Func<T, bool>> expression)
        {
            if (expression != null)
            {
                return this.DeleteAsync(Contexto.Set<T>().FirstOrDefault(expression));
            }

            return Task.FromResult<int>(defaultReturnNull);
        }

        public Task<int> DeleteRangeAsync(ICollection<T> listObjectsDelete)
        {
            if (listObjectsDelete != null && listObjectsDelete.IsNotNull())
            {
                Contexto.Set<T>().RemoveRange(listObjectsDelete);
                return Contexto.SaveChangesAsync();
            }

            return Task.FromResult<int>(defaultReturnNull);
        }

        public Task<int> DeleteRangeAsync(Expression<Func<T, bool>> expression)
        {
            if (expression != null)
            {
                Contexto.Set<T>().RemoveRange(Contexto.Set<T>().Where(expression));
                return Contexto.SaveChangesAsync();
            }

            return Task.FromResult<int>(defaultReturnNull);
        }

        public T? Get(Expression<Func<T, bool>> expression)
        {
            return this.Get(expression, null, null);
        }

        public T? Get(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy)
        {
            return this.Get(expression, null, OrderBy);
        }

        public T? Get(Expression<Func<T, bool>> expression, Expression<Func<T, object>> include)
        {
            return this.Get(expression, include, null);
        }

        public T? Get(Expression<Func<T, bool>> expression, Expression<Func<T, object>>? include, Func<IQueryable<T>, IOrderedQueryable<T>>? OrderBy)
        {
            T? objectReturn = null;
            if (expression != null)
            {
                var query = (IQueryable<T>)Contexto.Set<T>();
                if (include != null && include.IsNotNull())
                {
                    query = query.Include(include);
                }

                if (OrderBy != null && OrderBy.IsNotNull())
                {
                    query = OrderBy(query);
                }

                objectReturn = query.FirstOrDefault(expression);
                if (objectReturn != null && objectReturn.IsNotNull() &&
                                    Contexto.Entry(objectReturn).IsNotNull())
                {
                    Contexto.Entry(objectReturn).State = EntityState.Detached;
                }
            }

            return objectReturn;
        }

        public Task<T?> GetAsync(Expression<Func<T, bool>> expression)
        {
            if (expression != null)
            {
                IQueryable<T> query = BaseRepositoryDataAccess<T>.ConfigParameters(Contexto.Set<T>(), null);
                Type _type = new T().GetType();
                System.Reflection.PropertyInfo[] propertyList = 
                    _type.GetProperties(BindingFlags.DeclaredOnly| BindingFlags.Instance | BindingFlags.Public )
                    .Where(x => x.PropertyType.FullName.Contains(typeof(T).Namespace)).ToArray();
                foreach (System.Reflection.PropertyInfo property in propertyList)
                {
                    query = query.Include(property.Name);
                    
                }
                return query.FirstOrDefaultAsync(expression);
            }

            return Task.FromResult<T?>(null);
        }

        public ICollection<T> ListAll()
        {
            return Contexto.Set<T>().ToList();
        }

        public ICollection<T> ListAll(SwoParameterOfQuery<T> parameterOfList)
        {
            return BaseRepositoryDataAccess<T>.ConfigParameters(Contexto.Set<T>(), parameterOfList).ToList();
        }

        public Task<List<T>> ListAllAsync()
        {
            return Contexto.Set<T>().ToListAsync();
        }

        public Task<List<T>> ListAllAsync(SwoParameterOfQuery<T> parameterOfList)
        {
            IQueryable<T> query = BaseRepositoryDataAccess<T>.ConfigParameters(Contexto.Set<T>(), parameterOfList);
            Type _type = new T().GetType();
            System.Reflection.PropertyInfo[] propertyList = 
                _type.GetProperties(BindingFlags.DeclaredOnly| BindingFlags.Instance | BindingFlags.Public )
                .Where(x => x.PropertyType.FullName.Contains(typeof(T).Namespace)).ToArray();
            foreach (System.Reflection.PropertyInfo property in propertyList)
            {
                query = query.Include(property.Name);
            }
            return query.ToListAsync();
        }

        public bool? Update(T objectUpdate)
        {
            if (objectUpdate != null && objectUpdate.IsNotNull())
            {
                Contexto.Set<T>().Update(objectUpdate);
                return Contexto.SaveChanges() != 0;
            }

            return null;
        }

        public bool? Update(ICollection<T> listObjectsUpdate)
        {
            if (listObjectsUpdate != null && listObjectsUpdate.IsNotNull())
            {
                Contexto.Set<T>().UpdateRange(listObjectsUpdate);
                return Contexto.SaveChanges() != 0;
            }

            return null;
        }

        public Task<T?> UpdateAsync(T objectUpdate)
        {
            if (objectUpdate != null && objectUpdate.IsNotNull())
            {
                EntityEntry<T> entity = Contexto.Set<T>().Update(objectUpdate);
                int result = Contexto.SaveChanges();
                if (result >= 1) {
                    return Task.FromResult<T?>(entity.Entity);
                }
            }
            return Task.FromResult<T?>(null);
        }

        public Task<int> UpdateAsync(ICollection<T> listObjectsUpdate)
        {
            if (listObjectsUpdate != null && listObjectsUpdate.IsNotNull())
            {
                Contexto.Set<T>().UpdateRange(listObjectsUpdate);
                return Contexto.SaveChangesAsync();
            }

            return Task.FromResult<int>(defaultReturnNull);
        }

        public SwoPaginatedList<T> ListAllPaged(SwoParameterOfQuery<T> parameterOfList)
        {
            var oToList = new SwoPaginatedList<T>(ConfigureParameterOfList(Contexto.Set<T>(), parameterOfList));
            if (parameterOfList.IsNotNull())
            {
                oToList.Paged = parameterOfList.TextPag;
            }
            return oToList;
        }

        /// <summary>
        /// Configure Object, <parameter name="parameterOfList"/> to generate the Query IQueryable
        /// </summary>
        /// <param name="IQuery">IQueryable of the Query</param>
        /// <param name="parameterOfList">Dynamic Query Configuration Object</param>
        /// <returns>Dynamic Queries <paramref name="IQuery"/> for database or persistence of all business entities <typeparamref name="T"/></returns>
        protected IQueryable<T> ConfigureParameterOfList(IQueryable<T> IQuery, SwoParameterOfQuery<T> parameterOfList)
        {
            IQuery = WheresTransversal(IQuery);
            if (parameterOfList.IsNotNull())
            {
                IQuery = ConfigureOrderBy(IQuery, parameterOfList);
                IQuery = ConfigureFilter(IQuery, parameterOfList);
                IQuery = ConfigureInclude(IQuery, parameterOfList);
                IQuery = ConfigureMaxCount(IQuery, parameterOfList);
                IQuery = ConfigurePaged(IQuery, parameterOfList);
            }
            return IQuery;
        }

        /// <summary>
        /// Inject Transversal Conditions on the Selects (Search/List)
        /// </summary>
        /// <param name="IQuery"></param>
        /// <returns></returns>
        protected IQueryable<T> WheresTransversal(IQueryable<T> IQuery)
        {
            return IQuery;
        }

        /// <summary>
        /// Configure Order By, <parameter name="parameterOfList"/> to generate the Query IQueryable
        /// </summary>
        /// <param name="IQuery">IQueryable of the Query</param>
        /// <param name="parameterOfList">Dynamic Query Configuration Object</param>
        /// <returns>Dynamic Queries <paramref name="IQuery"/> for database or persistence of all business entities <typeparamref name="T"/></returns>
        private static IQueryable<T> ConfigureOrderBy(IQueryable<T> IQuery, SwoParameterOfQuery<T> parameterOfList)
        {
            if (parameterOfList.OrderBy.IsNotNull())
            {
                IQuery = parameterOfList.OrderBy(IQuery);
            }
            if (parameterOfList.WhereDynamic.Sorts.IsNotNull())
            {
                IQuery = IQuery.OrderByDynamic(parameterOfList.WhereDynamic);
            }
            else
            {
                if (parameterOfList.OrderByDynamic.IsNotNull() && parameterOfList.OrderByDynamic.Item1.IsValid())
                {
                    IQuery = IQuery.OrderByDynamic(parameterOfList.OrderByDynamic.Item1, parameterOfList.OrderByDynamic.Item2);
                }
            }
            return IQuery;
        }

        /// <summary>
        /// Configure Filter, <parameter name="parameter fList"/> to generate the Query IQueryable
        /// </summary>
        /// <param name="IQuery">IQueryable of the Query</param>
        /// <param name="parameterOfList">Dynamic Query Configuration Object</param>
        /// <returns>Dynamic Queries <paramref name="IQuery"/> for database or persistence of all business entities <typeparamref name="T"/></returns>
        private static IQueryable<T> ConfigureFilter(IQueryable<T> IQuery, SwoParameterOfQuery<T> parameterOfList)
        {
            if (parameterOfList.Filter.IsNotNull())
            {
                IQuery = IQuery.Where(parameterOfList.Filter);
            }
            if (parameterOfList.WhereDynamic.Filters.IsNotNull())
            {
                IQuery = IQuery.WhereDynamic(parameterOfList.WhereDynamic);
            }
            return IQuery;
        }

        /// <summary>
        /// Configure Include, <parameter name="parameter fList"/> to generate the Query IQueryable
        /// </summary>
        /// <param name="IQuery">IQueryable of the Query</param>
        /// <param name="parameterOfList">Dynamic Query Configuration Object</param>
        /// <returns>Dynamic Queries <paramref name="IQuery"/> for database or persistence of all business entities <typeparamref name="T"/></returns>
        protected virtual IQueryable<T> ConfigureInclude(IQueryable<T> IQuery, SwoParameterOfQuery<T> parameterOfList)
        {
            Type _type = new T().GetType();
            System.Reflection.PropertyInfo[] propertyList = 
                _type.GetProperties(BindingFlags.DeclaredOnly| BindingFlags.Instance | BindingFlags.Public )
                .Where(x => x.PropertyType.FullName.Contains(typeof(T).Namespace)).ToArray();
            foreach (System.Reflection.PropertyInfo property in propertyList)
            {
                IQuery = IQuery.Include(property.Name);
            }
            return IQuery;
        }

        /// <summary>
        /// Set MaxCount, <parameter name="parameter fList"/> to generate the Query IQueryable
        /// </summary>
        /// <param name="IQuery">IQueryable of the Query</param>
        /// <param name="parameterOfList">Dynamic Query Configuration Object</param>
        /// <returns>Dynamic Queries <paramref name="IQuery"/> for database or persistence of all business entities <typeparamref name="T"/></returns>
        private static IQueryable<T> ConfigureMaxCount(IQueryable<T> IQuery, SwoParameterOfQuery<T> parameterOfList)
        {
            if (parameterOfList.Skip > -1)
            {
                parameterOfList.MaxCount = IQuery.LongCount();
            }
            return IQuery;
        }

        /// <summary>
        /// Configure Page, <parameter name="parameterOfList"/> to generate the Query IQueryable
        /// </summary>
        /// <param name="IQuery">IQueryable of the Query</param>
        /// <param name="parameterOfList">Dynamic Query Configuration Object</param>
        /// <returns>Dynamic Queries <paramref name="IQuery"/> for database or persistence of all business entities <typeparamref name="T"/></returns>
        private IQueryable<T> ConfigurePaged(IQueryable<T> IQuery, SwoParameterOfQuery<T> parameterOfList)
        {
            if (parameterOfList.Take > 0)
            {
                if (parameterOfList.Skip > -1)
                {
                    IQuery = IQuery.Skip(parameterOfList.Skip);
                }
                IQuery = IQuery.Take(parameterOfList.Take);
            }
            else
            {
                if (parameterOfList.Skip > -1)
                {
                    parameterOfList.Take = DEFAULT_RECORDS;
                    IQuery = IQuery
                        .Skip(parameterOfList.Skip)
                        .Take(parameterOfList.Take);
                }
            }
            return IQuery;
        }
    }
}