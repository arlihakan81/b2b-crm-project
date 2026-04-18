using CRM.Domain.Entities;

namespace CRM.Application.Repositories
{
    public interface IActivityRepository : IRepository<Activity>
    {
        Task<IEnumerable<Activity>?> GetByAccountIdAsync(Guid accountId);
        Task<IEnumerable<Activity>?> GetByDealIdAsync(Guid opportunityId);

    }
}
