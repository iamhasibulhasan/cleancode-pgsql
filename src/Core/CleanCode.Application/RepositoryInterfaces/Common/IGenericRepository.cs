using System.Linq.Expressions;

namespace CleanCode.Application.RepositoryInterfaces.Common
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IList<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<T?> GetByIdAsync(object id, CancellationToken cancellationToken = default);
        Task<IList<T>> FindAllAsync(Expression<Func<T, bool>> match, CancellationToken cancellationToken = default);
        Task<IList<T>> FindAllAsync(Expression<Func<T, bool>> match, params Expression<Func<T, object>>[] includeProperties);
        Task<T?> FindAsync(Expression<Func<T, bool>> match, CancellationToken cancellationToken = default);
        Task<T?> FindAsync(Expression<Func<T, bool>> match, params Expression<Func<T, object>>[] includeProperties);
        Task<int> CountAsync(CancellationToken cancellationToken = default);
        Task<object> InsertAsync(T entity, bool saveChanges = false, CancellationToken cancellationToken = default);
        Task InsertRangeAsync(IEnumerable<T> entities, bool saveChanges = false, CancellationToken cancellationToken = default);
        Task UpdateAsync(T entity, bool saveChanges = false, CancellationToken cancellationToken = default);
        Task UpdateRangeAsync(IEnumerable<T> entities, bool saveChanges = false, CancellationToken cancellationToken = default);
        Task<bool> AnyAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);
    }
}
