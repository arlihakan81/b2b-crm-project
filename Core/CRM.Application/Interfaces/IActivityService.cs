using CRM.Application.DTOs.ActivityDTOs;

namespace CRM.Application.Interfaces
{
    public interface IActivityService
    {
        Task<IEnumerable<ActivityDTO>?> GetAllAsync();
        Task<ActivityDTO?> GetAsync(Guid id);

        Task CreateAsync(CreateActivityDTO createActivityDTO);
        Task UpdateAsync(Guid id, UpdateActivityDTO updateActivityDTO);
        Task DeleteAsync(Guid id);
    }
}
