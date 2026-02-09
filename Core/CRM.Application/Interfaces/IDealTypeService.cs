using CRM.Application.DTOs.DealTypeDTOs;

namespace CRM.Application.Interfaces
{
    public interface IDealTypeService
    {
        Task<bool> IsNameUniqueAsync(string name, Guid? excludeId = null);
        Task<IEnumerable<DealTypeDTO>?> GetAllAsync();
        Task<DealTypeDTO?> GetAsync(Guid id);
        Task CreateAsync(CreateDealTypeDTO createDealTypeDTO);
        Task UpdateAsync(Guid id, UpdateDealTypeDTO updateDealTypeDTO);
        Task DeleteAsync(Guid id);

    }
}
