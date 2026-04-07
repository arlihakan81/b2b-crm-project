using CRM.Domain.Entities;

namespace CRM.Application.Repositories
{
    public interface IContactRepository : IRepository<Contact>
    {
        Task<bool> IsEmailUniqueAsync(string email, Guid? contactId = null);
        Task<bool> IsMobileUniqueAsync(string mobile, Guid? contactId = null);
    }
}
