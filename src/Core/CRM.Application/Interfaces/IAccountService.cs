using CRM.Application.Requests.Accounts;
using CRM.Application.Responses.Accounts;

namespace CRM.Application.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountResponse>?> GetAllAsync();
        Task<AccountDetailResponse?> GetAsync(Guid id);
        Task CreateAsync(CreateAccountRequest request);
        Task UpdateAsync(Guid id, UpdateAccountRequest request);
        Task DeleteAsync(Guid id);
    }
}
