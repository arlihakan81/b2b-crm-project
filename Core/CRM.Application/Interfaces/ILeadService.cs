using CRM.Application.DTOs.LeadDTOs;

namespace CRM.Application.Interfaces
{
    public interface ILeadService
    {
        Task<bool> IsEmailUniqueAsync(string email, Guid? excludeId);
        Task<bool> IsMobileUniqueAsync(string mobile, Guid? excludeId);
        Task<bool> IsPhoneUniqueAsync(string phone, Guid? excludeId);

        Task<IEnumerable<LeadDTO>?> GetAllAsync();
        Task<LeadDTO?> GetAsync(Guid id);
        Task CreateAsync(CreateLeadDTO dto);
        Task UpdateAsync(Guid id, UpdateLeadDTO dto);
        Task DeleteAsync(Guid id);
    }
}
