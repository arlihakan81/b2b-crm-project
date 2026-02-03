using CRM.Domain.Commons;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRM.Application.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        DbSet<TEntity> Table { get; }
        Task<IEnumerable<TEntity>?> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null);
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity?> GetAsync(Guid id);
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(Guid id);

    }
}
