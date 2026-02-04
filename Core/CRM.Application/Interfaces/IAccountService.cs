using CRM.Application.DTOs.AccountDTOs;
using System.Linq.Expressions;

namespace CRM.Application.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountDTO>?> GetAllAsync();
        Task<AccountDTO?> GetAsync(Guid id);
        Task CreateAsync(CreateAccountDTO dto);
        Task UpdateAsync(Guid id, UpdateAccountDTO dto);
        Task DeleteAsync(Guid id);

        Task<bool> IsEmailUniqueAsync(string email, Guid? excludeId);
        Task<bool> IsPhoneUniqueAsync(string phone, Guid? excludeId);

    }
}
