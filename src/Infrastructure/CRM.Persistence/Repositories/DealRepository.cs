using CRM.Application.Repositories;
using CRM.Domain.Entities;
using CRM.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRM.Persistence.Repositories
{
    public class DealRepository(ApplicationDbContext context) : Repository<Deal>(context), IDealRepository
    {
        readonly ApplicationDbContext context = context;

        public override async Task<IEnumerable<Deal>?> GetAllAsync()
        {
            return await context.Deals
                .Include(_ => _.Account)
                .Include(_ => _.Category)
                .Include(_ => _.Contact)
                .Include(_ => _.Owner)
                .ToListAsync(); 
        }

        public override async Task<Deal?> GetAsync(Expression<Func<Deal, bool>> expression)
        {
            return await context.Deals
                .Include(_ => _.Account)
                .Include(_ => _.Contact)
                .Include(_ => _.Owner)
                .FirstOrDefaultAsync(expression);
        }

        public override async Task<Deal?> GetByIdAsync(Guid id)
        {
            return await context.Deals
                .Include(_ => _.Account)
                .Include(_ => _.Contact)
                .Include(_ => _.Owner)
                .FirstOrDefaultAsync(_ => _.Id == id);
        }
    }
}
