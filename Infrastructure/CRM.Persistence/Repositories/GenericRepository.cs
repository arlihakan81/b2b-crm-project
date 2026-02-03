using CRM.Application.Repositories;
using CRM.Domain.Commons;
using CRM.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRM.Persistence.Repositories
{
    public class GenericRepository<TEntity>(AppDbContext context) : IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        public DbSet<TEntity> Table => context.Set<TEntity>();

        public async Task CreateAsync(TEntity entity)
        {
            Table.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            TEntity entity = GetAsync(id).Result!;
            Table.Remove(entity);
            await context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<TEntity>?> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null)
        {
            return expression is null ? await Table.ToListAsync() : await Table.Where(expression).ToListAsync();
        }

        public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await Table.FirstOrDefaultAsync(expression);
        }

        public virtual async Task<TEntity?> GetAsync(Guid id)
        {
            return await Table.FindAsync(id);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            Table.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
