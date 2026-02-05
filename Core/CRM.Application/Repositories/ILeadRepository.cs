using CRM.Domain.Entities;

namespace CRM.Application.Repositories
{
    public interface ILeadRepository : IGenericRepository<Lead>
    {
        Task<bool> IsEmailUniqueAsync(string email, Guid? excludeId);
        Task<bool> IsMobileUniqueAsync(string mobile, Guid? excludeId);
        Task<bool> IsPhoneUniqueAsync(string phone, Guid? excludeId);

    }
}
