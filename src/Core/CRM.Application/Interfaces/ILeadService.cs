using CRM.Application.Requests.Leads;
using CRM.Application.Responses.Leads;

namespace CRM.Application.Interfaces
{
    public interface ILeadService
    {
        Task<IEnumerable<LeadResponse>?> GetAllAsync();
        Task<LeadDetailResponse?> GetAsync(Guid id);
        Task CreateAsync(CreateLeadRequest request);
        Task UpdateAsync(Guid id, UpdateLeadRequest request);
        Task DeleteAsync(Guid id);





    }
}
