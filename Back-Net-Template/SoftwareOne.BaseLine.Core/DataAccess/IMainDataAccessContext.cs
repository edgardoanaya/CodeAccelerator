using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace SoftwareOne.BaseLine.Core.DataAccess
{
    public interface IMainDataAccessContext
    {
        DatabaseFacade Database { get; }

        /// <summary>
        /// Representative method of DbContext to perform the Mock Test.
        /// </summary>
        /// <typeparam name="TEntity">Business Entity</typeparam>
        /// <returns></returns>
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        /// <summary>
        /// Representative method of DbContext to perform the Mock Test.
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        /// <summary>
        /// Representative method of DbContext to perform the Mock Test.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Representative method of DbContext to perform the Mock Test.
        /// </summary>
        /// <typeparam name="TEntity">Business Entity</typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}