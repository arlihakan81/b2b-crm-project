using CRM.Domain.Entities;

namespace CRM.Application.Repositories
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        Task<bool> IsEmailUniqueAsync(string email, Guid? excludeId = null);
        Task<bool> IsPhoneUniqueAsync(string phone, Guid? excludeId = null);
    }
}
