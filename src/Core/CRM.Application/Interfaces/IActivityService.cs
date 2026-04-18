using CRM.Application.Requests.Activities;
using CRM.Application.Responses.Activities;

namespace CRM.Application.Interfaces
{
    public interface IActivityService
    {
        Task<IEnumerable<ActivityResponse>?> GetAllAsync();
        Task<IEnumerable<ActivityResponse>> GetByAccountIdAsync(Guid accountId);
        Task<IEnumerable<ActivityResponse>> GetByDealIdAsync(Guid dealId);

        Task<ActivityResponse?> GetByIdAsync(Guid id);
        Task CreateAsync(CreateActivityRequest request);
        Task UpdateAsync(Guid id, UpdateActivityRequest request);
        Task DeleteAsync(Guid id);
    }
}
