using CRM.Application.Repositories;
using CRM.Domain.Entities;
using CRM.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRM.Persistence.Repositories
{
    public class CategoryRepository(AppDbContext context) : GenericRepository<Category>(context), ICategoryRepository
    {
        readonly AppDbContext context = context;

        public override async Task<IEnumerable<Category>?> GetAllAsync(Expression<Func<Category, bool>>? expression = null)
        {
            return expression is null ? await context.Categories.Include(c => c.Deals).AsNoTracking().ToListAsync() :
                await context.Categories.Where(expression).Include(c => c.Deals).AsNoTracking().ToListAsync();
        }

        public override async Task<Category?> GetAsync(Expression<Func<Category, bool>> expression)
        {
            return await context.Categories.Include(c => c.Deals).AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public override async Task<Category?> GetAsync(Guid id)
        {
            return await context.Categories.Include(c => c.Deals).AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> IsCategoryNameUniqueAsync(string name, Guid orgId, Guid? excludeId)
        {
            return excludeId is null ? !await context.Categories.AnyAsync(c => c.Name == name && c.OrganizationId == orgId) :
                !await context.Categories.AnyAsync(c => c.Name == name && c.OrganizationId == orgId && c.Id != excludeId);
        }




    }
}
