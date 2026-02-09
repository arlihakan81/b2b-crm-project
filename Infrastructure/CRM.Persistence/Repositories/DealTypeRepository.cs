using CRM.Application.Repositories;
using CRM.Domain.Entities;
using CRM.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRM.Persistence.Repositories
{
    public class DealTypeRepository(AppDbContext context) : GenericRepository<DealType>(context), IDealTypeRepository
    {
        readonly AppDbContext context = context;
        public DbSet<DealType> DealTypes => context.Set<DealType>();

        public override async Task<IEnumerable<DealType>?> GetAllAsync(Expression<Func<DealType, bool>>? expression = null)
        {
            return expression is null ? await DealTypes.Include(d => d.Deals).ToListAsync() : await DealTypes.Where(expression).Include(d => d.Deals).ToListAsync();
        }

        public override async Task<DealType?> GetAsync(Expression<Func<DealType, bool>> expression)
        {
            return await DealTypes.Include(d => d.Deals).FirstOrDefaultAsync(expression);
        }

        public override async Task<DealType?> GetAsync(Guid id)
        {
            return await DealTypes.Include(d => d.Deals).FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<bool> IsNameUniqueAsync(string name, Guid orgId, Guid? excludeId = null)
        {
            return excludeId is null ? !await DealTypes.AnyAsync(dt => dt.Name == name && dt.OrganizationId == orgId) : !await DealTypes.AnyAsync(dt => dt.Name == name && dt.OrganizationId == orgId && dt.Id != excludeId.Value);
        }
    }
}
