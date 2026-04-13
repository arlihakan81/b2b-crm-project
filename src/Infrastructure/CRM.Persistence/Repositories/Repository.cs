using CRM.Application.Repositories;
using CRM.Domain.Entities.Commons;
using CRM.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRM.Persistence.Repositories
{
    public class Repository<T>(ApplicationDbContext context) : IRepository<T> where T : BaseEntity
    {
        readonly ApplicationDbContext context = context;

        public async Task AddAsync(T entity)
        {
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = context.Set<T>().Find(id);
            if (entity is null)
            {
                throw new KeyNotFoundException($"Entity with id {id} not found");
            }
            entity.IsDeleted = true;
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<T>?> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public virtual async Task<T?> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await context.Set<T>().FirstOrDefaultAsync(expression);
        }

        public virtual async Task<T?> GetByIdAsync(Guid id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            entity.ModifiedAt = DateTime.Now;
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
