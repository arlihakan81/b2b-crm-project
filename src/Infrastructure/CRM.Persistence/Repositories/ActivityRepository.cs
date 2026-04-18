using CRM.Application.Repositories;
using CRM.Domain.Entities;
using CRM.Domain.Enums;
using CRM.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CRM.Persistence.Repositories
{
    public class ActivityRepository(ApplicationDbContext context) : Repository<Activity>(context), IActivityRepository
    {
        private readonly ApplicationDbContext context = context;

        public override async Task<IEnumerable<Activity>?> GetAllAsync()
        {
            return await context.Activities.Include(a => a.Account).Include(a => a.Deal).ToListAsync();
        }

        public async Task<IEnumerable<Activity>?> GetByAccountIdAsync(Guid accountId)
        {
            return await context.Activities.Where(a => a.AccountId == accountId).ToListAsync();
        }

        public async Task<IEnumerable<Activity>?> GetByDealIdAsync(Guid opportunityId)
        {
            return await context.Activities.Where(a => a.DealId == opportunityId).ToListAsync();
        }

    }
}
