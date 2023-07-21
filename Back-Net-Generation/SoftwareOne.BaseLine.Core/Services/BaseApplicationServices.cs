using SoftwareOne.BaseLine.Core.DataAccess;
using SoftwareOne.BaseLine.Core.Validator;
using SoftwareOne.BaseLine.Core.ProcessServicesApplication;
using System.Linq.Expressions;
using static SoftwareOne.BaseLine.Core.Enumerations.SwoEnumApplication;
using SoftwareOne.BaseLine.Core.Exceptions;
using SoftwareOne.BaseLine.Core.RequestDto;
using SoftwareOne.BaseLine.Core.ExtensionMethods;

namespace SoftwareOne.BaseLine.Core.Services
{
    public abstract class BaseApplicationServices<T, IDataAccessEntity, SwoValidator> : IBaseRepositoryDataAccess<T>
        where T : class, Entities.IEntity, new()
        where IDataAccessEntity : IBaseRepositoryDataAccess<T>
        where SwoValidator : SwoValidator<T>
    {
        /// <summary>
        /// Entity containing the Dao context of the Entity <typeparamref name="T"/>
        /// </summary>
        protected readonly IDataAccessEntity _dataAccessEntity;

        /// <summary>
        /// 
        /// </summary>
        protected readonly IProcessServicesApplication _processServicesApplication;

        protected readonly SwoValidator _validator;

        /// <summary>
        /// Base Class Constructor Method
        /// </summary>
        /// <param name="dataAccessEntity">Entity Context <typeparamref name="T"/> containing the instance of the Infrastructure persistence layer.</param>
        protected BaseApplicationServices(IDataAccessEntity dataAccessEntity,
                                          IProcessServicesApplication processServicesApplication,
                                          SwoValidator validator)
        {
            _dataAccessEntity = dataAccessEntity;
            _processServicesApplication = processServicesApplication;
            _validator = validator;
        }

        /// <summary>
        /// 
        /// </summary>
        public IMainDataAccessContext Contexto => _dataAccessEntity.Contexto;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectAdd"></param>
        /// <returns></returns>
        public int Add(T objectAdd)
        {
            ValidationsAndInitializeToAdd(objectAdd);
            var create = _dataAccessEntity.Add(objectAdd);

            this._processServicesApplication.CreateAuditAppAsync(new T().GetType().Name, objectAdd, null, TypeAudit.Create);

            return create;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listObjectsAdd"></param>
        /// <returns></returns>
        public int Add(IEnumerable<T> listObjectsAdd)
        {
            if (listObjectsAdd != null)
            {
                foreach (var item in listObjectsAdd) 
                { 
                    ValidationsAndInitializeToAdd(item); 
                }
                return _dataAccessEntity.Add(listObjectsAdd);
            }

            return default;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectAdd"></param>
        /// <returns></returns>
        public Task<T> AddAsync(T objectAdd)
        {
            ValidationsAndInitializeToAdd(objectAdd);
            var create = _dataAccessEntity.AddAsync(objectAdd);

            this._processServicesApplication.CreateAuditAppAsync(new T().GetType().Name, objectAdd, null, TypeAudit.Create);

            return create;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listObjectsAdd"></param>
        /// <returns></returns>
        public Task<int> AddAsync(IEnumerable<T> listObjectsAdd)
        {
            if (listObjectsAdd != null)
            {
                foreach (var item in listObjectsAdd) 
                { 
                    ValidationsAndInitializeToAdd(item); 
                }
                return _dataAccessEntity.AddAsync(listObjectsAdd);
            }

            return Task.FromResult<int>(default);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public int Count(Expression<Func<T, bool>> expression)
        {
            return _dataAccessEntity.Count(expression);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectDelete"></param>
        /// <returns></returns>
        public bool? Delete(T objectDelete)
        {
            var delete = _dataAccessEntity.Delete(objectDelete);

            this._processServicesApplication.CreateAuditAppAsync(new T().GetType().Name, objectDelete, null, TypeAudit.Delete);

            return delete;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public bool? Delete(Expression<Func<T, bool>> expression)
        {
            return _dataAccessEntity.Delete(expression);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectDelete"></param>
        /// <returns></returns>
        public Task<int> DeleteAsync(T objectDelete)
        {
            var delete = _dataAccessEntity.DeleteAsync(objectDelete);

            this._processServicesApplication.CreateAuditAppAsync(new T().GetType().Name, objectDelete, null, TypeAudit.Delete);

            return delete;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public async Task<int> DeleteAsync(Expression<Func<T, bool>> expression)
        {
            T? objectDelete = Get(expression);
            if(objectDelete != null) {
                var delete = await _dataAccessEntity.DeleteAsync(expression);
                this._processServicesApplication.CreateAuditAppAsync(new T().GetType().Name, objectDelete, null, TypeAudit.Delete);
                return delete;
            } else {
                return 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public bool? DeleteRange(Expression<Func<T, bool>> expression)
        {
            return _dataAccessEntity.DeleteRange(expression);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listObjectsDelete"></param>
        /// <returns></returns>
        public bool? DeleteRange(ICollection<T> listObjectsDelete)
        {
            return _dataAccessEntity.DeleteRange(listObjectsDelete);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public Task<int> DeleteRangeAsync(Expression<Func<T, bool>> expression)
        {
            return _dataAccessEntity.DeleteRangeAsync(expression);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listObjectsDelete"></param>
        /// <returns></returns>
        public Task<int> DeleteRangeAsync(ICollection<T> listObjectsDelete)
        {
            return _dataAccessEntity.DeleteRangeAsync(listObjectsDelete);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public T? Get(Expression<Func<T, bool>> expression)
        {
            return _dataAccessEntity.Get(expression);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public T? Get(Expression<Func<T, bool>> expression, Expression<Func<T, object>> include)
        {
            return _dataAccessEntity.Get(expression, include);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="OrderBy"></param>
        /// <returns></returns>
        public T? Get(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy)
        {
            return _dataAccessEntity.Get(expression, OrderBy);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="include"></param>
        /// <param name="OrderBy"></param>
        /// <returns></returns>
        public T? Get(Expression<Func<T, bool>> expression, Expression<Func<T, object>> include, Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy)
        {
            return _dataAccessEntity.Get(expression, include, OrderBy);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public Task<T?> GetAsync(Expression<Func<T, bool>> expression)
        {
            return _dataAccessEntity.GetAsync(expression);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ICollection<T> ListAll()
        {
            return _dataAccessEntity.ListAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameterOfList"></param>
        /// <returns></returns>
        public ICollection<T> ListAll(SwoParameterOfQuery<T> parameterOfList)
        {
            return _dataAccessEntity.ListAll(parameterOfList);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<List<T>> ListAllAsync()
        {
            return _dataAccessEntity.ListAllAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameterOfList"></param>
        /// <returns></returns>
        public Task<List<T>> ListAllAsync(SwoParameterOfQuery<T> parameterOfList)
        {
            return _dataAccessEntity.ListAllAsync(parameterOfList);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameterOfList"></param>
        /// <returns></returns>
        public SwoPaginatedList<T> ListAllPaged(SwoParameterOfQuery<T> parameterOfList)
        {
            return _dataAccessEntity.ListAllPaged(parameterOfList);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectUpdate"></param>
        /// <returns></returns>
        public bool? Update(T objectUpdate)
        {
            ValidationsAndInitializeToUpdate(objectUpdate);

            T? objectUpdateAnterior = null;
            if (objectUpdate.Id > 0)
            {
                objectUpdateAnterior = Get(x => x.Id == objectUpdate.Id);
            }

            var update = _dataAccessEntity.Update(objectUpdate);

            this._processServicesApplication.CreateAuditAppAsync(new T().GetType().Name, objectUpdate, objectUpdateAnterior, TypeAudit.Update);

            return update;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listObjectsUpdate"></param>
        /// <returns></returns>
        public bool? Update(ICollection<T> listObjectsUpdate)
        {
            if (listObjectsUpdate != null)
            {
                foreach (var item in listObjectsUpdate) 
                { 
                    ValidationsAndInitializeToUpdate(item); 
                }
                return _dataAccessEntity.Update(listObjectsUpdate);
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectUpdate"></param>
        /// <returns></returns>
        public Task<T?> UpdateAsync(T objectUpdate)
        {
            ValidationsAndInitializeToUpdate(objectUpdate);

            T? objectUpdateAnterior = null;
            if (objectUpdate.Id > 0)
            {
                objectUpdateAnterior = Get(x => x.Id == objectUpdate.Id);
            }

            var update = _dataAccessEntity.UpdateAsync(objectUpdate);

            this._processServicesApplication.CreateAuditAppAsync(new T().GetType().Name, objectUpdate, objectUpdateAnterior, TypeAudit.Update);

            return update;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listObjectsUpdate"></param>
        /// <returns></returns>
        public Task<int> UpdateAsync(ICollection<T> listObjectsUpdate)
        {
            if (listObjectsUpdate != null)
            {
                foreach (var item in listObjectsUpdate) 
                { 
                    ValidationsAndInitializeToUpdate(item); 
                }
                return _dataAccessEntity.UpdateAsync(listObjectsUpdate);
            }

            return Task.FromResult<int>(default);
        }

        /// <summary>
        /// Exposed method to carry out business implementations that allow guaranteeing the Correct Creation of the Entity
        /// </summary>
        /// <param name="entity">Reference of the object to Create</param>
        protected virtual void ValidationsAndInitializeToAdd(T entity) {
            var validationResult = _validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                string validationErrors = string.Join(Environment.NewLine, validationResult.Errors);
                throw new SwoDomainValidationException(validationErrors);
            }
        }

        /// <summary>
        /// Exposed method to carry out business implementations that allow guaranteeing the Correct Edition of the Entity
        /// </summary>
        /// <param name="entity">Reference of the object to Edit</param>
        protected virtual void ValidationsAndInitializeToUpdate(T entity) { entity.TrimAll(); }

        /// <summary>
        /// Exposed method to carry out business implementations that allow to guarantee the Correct Elimination of the Entity
        /// </summary>
        /// <param name="entity">Reference of the object to Delete.</param>
        protected virtual void ValidationsToDelete(T entity) { }
    }
}