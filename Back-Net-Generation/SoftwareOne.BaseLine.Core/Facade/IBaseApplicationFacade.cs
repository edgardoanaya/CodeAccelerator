using SoftwareOne.BaseLine.Core.DataAccess;
using SoftwareOne.BaseLine.Core.Entities;
using System.Linq.Expressions;
using SoftwareOne.BaseLine.Core.RequestDto;

namespace SoftwareOne.BaseLine.Core.Facade
{

    /// <summary>
    /// Base interface that will allow communication between all application entities.
    /// </summary>
    /// <typeparam name="TDto">Business Entity</typeparam>
    public interface IBaseApplicationFacade<T, TDto>
        where T : class, new()
        where TDto : class, new()
    {
        /// <summary>
        /// Property containing the project's Database Context
        /// </summary>
        IMainDataAccessContext Contexto { get; }

        /// <summary>
        /// Implementation List of Business Objects of the Entity <typeparamref name="T"/>
        /// </summary>
        /// <param name="parameterOfList">Composite object to build an advanced list on top of the entity <typeparamref name="T"/></param>
        /// <returns>Return Composite Object Listed according to the entity filters and defined pagination<typeparamref name="T"/></returns>
        SwoPaginatedList<TDto> ListAllPaged(SwoParameterOfQuery<T> parameterOfList);

        /// <summary>
        /// Implementation List of Business Objects of the Entity <typeparamref name="T"/>
        /// </summary>
        /// <returns>Returns the List according to the entity filters <typeparamref name="T"/></returns>
        ICollection<TDto> ListAll();

        /// <summary>
        /// Implementation List of Business Objects of the Entity <typeparamref name="T"/>
        /// </summary>
        /// <param name="parameterOfList">Composite object to build an advanced list on top of the entity <typeparamref name="T"/></param>
        /// <returns>Returns the List according to the entity filters <typeparamref name="T"/></returns>
        ICollection<TDto> ListAll(SwoParameterOfQuery<T> parameterOfList);

        /// <summary>
        /// Number of Records of the Entity <typeparamref name="T"/>
        /// </summary>
        /// <param name="expression">Filters on the entity <typeparamref name="T"/></param>
        /// <returns>Returns the number of records according to the entity filter <typeparamref name="T"/></returns>
        int Count(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Implementation Business Object of the Entity <typeparamref name="T"/>
        /// </summary>
        /// <param name="expression">Filters on the entity <typeparamref name="T"/></param>
        /// <returns>Returns the object according to the entity filter <typeparamref name="T"/></returns>
        TDto? Get(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Business Object of the Entity <typeparamref name="T"/>
        /// </summary>
        /// <param name="expression">Filters on the entity <typeparamref name="T"/></param>
        /// <param name="include">Child entity inclusions <typeparamref name="T"/></param>
        /// <returns>Returns the object according to the entity filter <typeparamref name="T"/></returns>
        TDto? Get(Expression<Func<T, bool>> expression, Expression<Func<T, object>> include);

        /// <summary>
        /// Implementation of the Entity Business Object Creation <typeparamref name="T"/>
        /// </summary>
        /// <param name="objectAdd">Specified entity <typeparamref name="T"/></param>
        /// <returns>Returns if Id Inserted or failing that number of altered records</returns>
        int? Add(TDto objectAdd);

        /// <summary>
        /// Implementation of the Entity Business Object Creation <typeparamref name="T"/>
        /// </summary>
        /// <param name="listObjectsAdd">Listo de Specified entity <typeparamref name="T"/></param>
        /// <returns>Returns if Id Inserted or failing that number of altered records</returns>
        int? Add(IEnumerable<TDto> listObjectsAdd);

        /// <summary>
        /// Implementation Modification of the Business Objects of the Entity <typeparamref name="T"/> 
        /// </summary>
        /// <param name="objectUpdate">Specified entity <typeparamref name="T"/></param>
        /// <returns>Returns if the operation was successful (altered the record)</returns>
        bool? Update(TDto objectUpdate);

        /// <summary>
        /// Implementation Modification of the Business Objects of the Entity <typeparamref name="T"/> 
        /// </summary>
        /// <param name="listObjectsUpdate">Specified entity <typeparamref name="T"/></param>
        /// <returns>Returns if the operation was successful (altered the record)</returns>
        bool? Update(ICollection<TDto> listObjectsUpdate);

        /// <summary>
        /// Implementation of the Deletion of the Entity's Business Objects <typeparamref name="T"/> 
        /// </summary>
        /// <param name="objectDelete">Specified entity <typeparamref name="T"/></param>
        /// <returns>Returns if the operation was successful (altered the record)</returns>
        bool? Delete(TDto objectDelete);

        /// <summary>
        /// Implementation of the Deletion of the Entity's Business Objects <typeparamref name="T"/> 
        /// </summary>
        /// <param name="expression">Filters on the entity <typeparamref name="T"/></param>
        /// <returns>Returns if the operation was successful (altered the record)</returns>
        bool? Delete(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Implementation of massive deletion of the Entity's Business Objects <typeparamref name="T"/> 
        /// </summary>
        /// <param name="expression">Filters on the entity <typeparamref name="T"/></param>
        /// <returns>Returns if the operation was successful (altered the register(s))</returns>
        bool? DeleteRange(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Implementation Maximum Async Deletion of Entity Business Objects <typeparamref name="T"/> 
        /// </summary>
        /// <param name="listObjectsDelete">Specified entity <typeparamref name="T"/></param>
        /// <returns>Returns if the operation was successful (altered the register(s))</returns>
        bool? DeleteRange(ICollection<TDto> listObjectsDelete);

        /// <summary>
        /// Entity Business Object Async Listing Implementation <typeparamref name="T"/> 
        /// </summary>
        /// <returns>Returns the List according to the entity filters <typeparamref name="T"/></returns>
        Task<List<TDto>> ListAllAsync();

        /// <summary>
        /// Entity Business Object Async Listing Implementation <typeparamref name="T"/> 
        /// </summary>
        /// <param name="parameterOfList">Composite object to build an advanced list on top of the entity <typeparamref name="T"/></param>
        /// <returns>Returns the List according to the entity filters <typeparamref name="T"/></returns>
        Task<List<TDto>> ListAllAsync(SwoParameterOfQuery<T> parameterOfList);

        /// <summary>
        /// Entity Business Async Object Implementation <typeparamref name="T"/>
        /// </summary>
        /// <param name="expression">Filters on the entity <typeparamref name="T"/></param>
        /// <returns>Returns the object according to the entity filter <typeparamref name="T"/></returns>
        Task<TDto> GetAsync(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Entity Business Object Async Creation Implementation <typeparamref name="T"/>
        /// </summary>
        /// <param name="objectAdd">Specified entity <typeparamref name="T"/></param>
        /// <returns>Returns if Id Inserted or failing that number of altered records</returns>
        Task<TDto> AddAsync(TDto objectAdd);

        /// <summary>
        /// Entity Business Object Async Creation Implementation <typeparamref name="T"/>
        /// </summary>
        /// <param name="listObjectsAdd">Specified entity List <typeparamref name="T"/></param>
        /// <returns>Returns if Id Inserted or failing that number of altered records</returns>
        Task<int> AddAsync(IEnumerable<TDto> listObjectsAdd);

        /// <summary>
        /// Implementation Async Modification of Entity Business Objects<typeparamref name="T"/> 
        /// </summary>
        /// <param name="objectUpdate">Specified entity <typeparamref name="T"/></param>
        /// <returns>Returns if the operation was successful (altered the record)</returns>
        Task<TDto?> UpdateAsync(TDto objectUpdate);

        /// <summary>
        /// Implementation Async Modification of Entity Business Objects<typeparamref name="T"/> 
        /// </summary>
        /// <param name="listObjectsUpdate">Specified entity <typeparamref name="T"/></param>
        /// <returns>Returns if the operation was successful (altered the record)</returns>
        Task<int> UpdateAsync(ICollection<TDto> listObjectsUpdate);

        /// <summary>
        /// Implementation Deletion Async of Entity Business Objects <typeparamref name="T"/> 
        /// </summary>
        /// <param name="objectDelete">Specified entity <typeparamref name="T"/></param>
        /// <returns>Returns if the operation was successful (altered the record)</returns>
        Task<int> DeleteAsync(TDto objectDelete);

        /// <summary>
        /// Implementation Deletion Async of Entity Business Objects <typeparamref name="T"/> 
        /// </summary>
        /// <param name="expression">Filters on the entity <typeparamref name="T"/></param>
        /// <returns>Returns if the operation was successful (altered the record)</returns>
        Task<BaseResponseDto> DeleteAsync(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Implementation Maximum Async Deletion of Entity Business Objects <typeparamref name="T"/> 
        /// </summary>
        /// <param name="expression">Filters on the entity <typeparamref name="T"/></param>
        /// <returns>Returns if the operation was successful (altered the register(s))</returns>
        Task<int> DeleteRangeAsync(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Implementation Maximum Async Deletion of Entity Business Objects <typeparamref name="T"/> 
        /// </summary>
        /// <param name="listObjectsDelete">Specified entity <typeparamref name="T"/></param>
        /// <returns>Returns if the operation was successful (altered the register(s))</returns>
        Task<int> DeleteRangeAsync(ICollection<TDto> listObjectsDelete);
    }
}