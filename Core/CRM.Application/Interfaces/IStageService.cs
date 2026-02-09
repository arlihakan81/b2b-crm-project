using CRM.Application.DTOs.StageDTOs;

namespace CRM.Application.Interfaces
{
    public interface IStageService
    {
        Task<bool> IsStageNameUniqueAsync(string name, Guid? excludeId = null);
        Task<IEnumerable<StageDTO>?> GetAllAsync();
        Task<StageDTO?> GetAsync(Guid id);
        Task CreateAsync(CreateStageDTO createStageDTO);
        Task UpdateAsync(Guid id, UpdateStageDTO updateStageDTO);
        Task DeleteAsync(Guid id);



    }
}
