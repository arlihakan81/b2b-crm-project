using CRM.Application.Requests.Deals;
using CRM.Application.Responses.Deals;

namespace CRM.Application.Interfaces
{
    public interface IDealService
    {
        Task<IEnumerable<DealResponse>?> GetAllAsync();
        Task<DealResponse?> GetByIdAsync(Guid id);
        Task CreateAsync(CreateDealRequest request);
        Task UpdateAsync(Guid id, UpdateDealRequest request);
        Task DeleteAsync(Guid id);
    }
}
