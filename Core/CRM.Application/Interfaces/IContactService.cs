using CRM.Application.DTOs.ContactDTOs;

namespace CRM.Application.Interfaces
{
    public interface IContactService
    {
        Task<bool> IsEmailUniqueAsync(string email, Guid? excludeId);
        Task<bool> IsMobileUniqueAsync(string mobile, Guid? excludeId);
        Task<IEnumerable<ContactDTO>?> GetAllAsync();
        Task<ContactDTO?> GetAsync(Guid id);
        Task CreateAsync(CreateContactDTO dto);
        Task UpdateAsync(Guid id, UpdateContactDTO dto);
        Task DeleteAsync(Guid id);

    }
}
