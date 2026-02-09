using CRM.Application.Repositories;
using CRM.Domain.Entities;
using CRM.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRM.Persistence.Repositories
{
    public class StageRepository(AppDbContext context) : GenericRepository<Stage>(context), IStageRepository
    {
        readonly AppDbContext context = context;
        public DbSet<Stage> Stages => context.Stages;

        public override async Task<IEnumerable<Stage>?> GetAllAsync(Expression<Func<Stage, bool>>? expression = null)
        {
            return expression is null ? await Stages.Include(s => s.Deals).ToListAsync() : await Stages.Where(expression).Include(s => s.Deals).ToListAsync();
        }

        public override async Task<Stage?> GetAsync(Expression<Func<Stage, bool>> expression)
        {
            return await Stages.Include(s => s.Deals).FirstOrDefaultAsync(expression);
        }

        public override async Task<Stage?> GetAsync(Guid id)
        {
            return await Stages.Include(s => s.Deals).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<bool> IsStageNameUniqueAsync(string name, Guid orgId, Guid? excludeId = null)
        {
            return excludeId is null ? !await Stages.AnyAsync(s => s.Name == name && s.OrganizationId == orgId) : !await Stages.AnyAsync(s => s.Name == name && s.OrganizationId == orgId && s.Id != excludeId.Value);
        }
    }
}
