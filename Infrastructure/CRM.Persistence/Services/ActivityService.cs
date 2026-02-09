using AutoMapper;
using CRM.Application.DTOs.ActivityDTOs;
using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using CRM.Domain.Entities;

namespace CRM.Persistence.Services
{
    public class ActivityService(IActivityRepository repository, IMapper mapper, IOrganizationService service) : IActivityService
    {
        public async Task CreateAsync(CreateActivityDTO createActivityDTO)
        {
            var activity = mapper.Map<Activity>(createActivityDTO);
            activity.OrganizationId = service.GetCurrentOrganizationId();
            await repository.CreateAsync(activity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ActivityDTO>?> GetAllAsync()
        {
            var activities = await repository.GetAllAsync(prop => prop.OrganizationId == service.GetCurrentOrganizationId());
            return mapper.Map<IEnumerable<ActivityDTO>>(activities);
        }

        public async Task<ActivityDTO?> GetAsync(Guid id)
        {
            var activity = await repository.GetAsync(id);
            return mapper.Map<ActivityDTO>(activity);
        }

        public async Task UpdateAsync(Guid id, UpdateActivityDTO updateActivityDTO)
        {
            var activity = await repository.GetAsync(id);
            await repository.UpdateAsync(mapper.Map(updateActivityDTO, activity)!);
        }
    }
}
