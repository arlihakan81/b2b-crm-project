using CRM.Domain.Entities;

namespace CRM.Application.Repositories
{
    public interface IActivityRepository : IRepository<Activity>
    {
        Task<IEnumerable<Activity>?> GetByAccountIdAsync(Guid accountId);
        Task<IEnumerable<Activity>?> GetByContactIdAsync(Guid contactId);
        Task<IEnumerable<Activity>?> GetByLeadIdAsync(Guid leadId);
        Task<IEnumerable<Activity>?> GetByDealIdAsync(Guid opportunityId);

    }
}
