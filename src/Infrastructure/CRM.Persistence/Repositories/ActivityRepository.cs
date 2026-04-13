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

        public async Task<IEnumerable<Activity>?> GetByAccountIdAsync(Guid accountId)
        {
            return await context.Activities.Where(a => a.RelatedEntityType == EntityType.Account && a.RelatedEntityId == accountId).ToListAsync();
        }

        public async Task<IEnumerable<Activity>?> GetByContactIdAsync(Guid contactId)
        {
            return await context.Activities.Where(a => a.RelatedEntityType == EntityType.Contact && a.RelatedEntityId == contactId).ToListAsync();
        }

        public async Task<IEnumerable<Activity>?> GetByDealIdAsync(Guid opportunityId)
        {
            return await context.Activities.Where(a => a.RelatedEntityType == EntityType.Deal && a.RelatedEntityId == opportunityId).ToListAsync();
        }

        public async Task<IEnumerable<Activity>?> GetByLeadIdAsync(Guid leadId)
        {
            return await context.Activities.Where(a => a.RelatedEntityId == leadId && a.RelatedEntityType == EntityType.Lead).ToListAsync();
        }
    }
}
