using CleanCode.Application.RepositoryInterfaces.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CleanCode.Infrastructure.RepositoryImplementations.Common
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext _dbContext;

        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        private DbSet<T> _dbSet;
        protected DbSet<T> DbSet
        {
            get { return _dbSet = _dbContext.Set<T>(); }
        }

        public async Task<IList<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await DbSet.ToListAsync(cancellationToken);
        }

        public async Task<T?> GetByIdAsync(object id, CancellationToken cancellationToken = default)
        {
            return await DbSet.FindAsync(id, cancellationToken);
        }

        public async Task<IList<T>> FindAllAsync(Expression<Func<T, bool>> match, CancellationToken cancellationToken = default)
        {
            return await DbSet.Where(match).ToListAsync(cancellationToken);
        }

        public async Task<IList<T>> FindAllAsync(Expression<Func<T, bool>> match, params Expression<Func<T, object>>[] includeProperties)
        {
            var query = _dbContext.Set<T>().Where(match);
            if (includeProperties is not null)
                query = includeProperties.Aggregate(query, (current, includeProperty) =>
                current.Include(includeProperty));
            return await query.ToListAsync();
        }

        public async Task<T?> FindAsync(Expression<Func<T, bool>> match, CancellationToken cancellationToken = default)
        {
            return await DbSet.FirstOrDefaultAsync(match, cancellationToken);
        }

        public async Task<T?> FindAsync(Expression<Func<T, bool>> match, params Expression<Func<T, object>>[] includeProperties)
        {
            var query = _dbContext.Set<T>().Where(match);
            if (includeProperties is not null)
                query = includeProperties.Aggregate(query, (current, includeProperty) =>
                current.Include(includeProperty));
            return await query.FirstOrDefaultAsync();
        }

        public async Task<int> CountAsync(CancellationToken cancellationToken = default)
        {
            return await DbSet.CountAsync(cancellationToken);
        }

        public async Task<object> InsertAsync(T entity, bool saveChanges = false, CancellationToken cancellationToken = default)
        {
            var msg = DbSet.AddAsync(entity, cancellationToken);
            if (saveChanges)
                await _dbContext.SaveChangesAsync(cancellationToken);
            return msg;
        }

        public async Task InsertRangeAsync(IEnumerable<T> entities, bool saveChanges = false, CancellationToken cancellationToken = default)
        {
            await DbSet.AddRangeAsync(entities, cancellationToken);
            if (saveChanges)
                await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(T entity, bool saveChanges = false, CancellationToken cancellationToken = default)
        {
            var entry = _dbContext.Entry(entity);
            DbSet.Attach(entity);
            entry.State = EntityState.Modified;
            if (saveChanges)
                await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateRangeAsync(IEnumerable<T> entities, bool saveChanges = false, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                DbSet.UpdateRange(entities);
            });
            if (saveChanges)
            {
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default)
        {
            return await DbSet.AsNoTracking().AnyAsync(filter, cancellationToken);
        }
    }
}
