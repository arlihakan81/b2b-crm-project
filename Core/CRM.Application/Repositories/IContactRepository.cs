using CRM.Domain.Entities;

namespace CRM.Application.Repositories
{
    public interface IContactRepository : IGenericRepository<Contact>
    {
        Task<bool> IsEmailUniqueAsync(string email, Guid? excludeId);
        Task<bool> IsMobileUniqueAsync(string phone, Guid? excludeId);
    }
}
