using CRM.Domain.Entities.Commons;
using System.Linq.Expressions;

namespace CRM.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>?> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task<T?> GetAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);


    }
}
