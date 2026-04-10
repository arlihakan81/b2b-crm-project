using CRM.Domain.Entities;

namespace CRM.Application.Repositories
{
    public interface ILeadRepository : IRepository<Lead>
    {
        Task<bool> IsEmailUniqueAsync(string email, Guid? excludeId = null);
        Task<bool> IsPhoneUniqueAsync(string phone, Guid? excludeId = null);
    }
}
