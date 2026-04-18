using AutoMapper;
using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using CRM.Application.Requests.Activities;
using CRM.Application.Responses.Activities;
using CRM.Domain.Entities;

namespace CRM.Persistence.Services
{
    public class ActivityService(IActivityRepository repository, IMapper mapper) : IActivityService
    {
        private readonly IActivityRepository repository = repository;
        private readonly IMapper mapper = mapper;

        public async Task CreateAsync(CreateActivityRequest request)
        {
            await repository.AddAsync(mapper.Map<Activity>(request));
        }

        public async Task DeleteAsync(Guid id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ActivityResponse>?> GetAllAsync()
        {
            return await repository.GetAllAsync() is IEnumerable<Activity> activities
                ? mapper.Map<IEnumerable<ActivityResponse>>(activities)
                : [];
        }

        public async Task<IEnumerable<ActivityResponse>> GetByAccountIdAsync(Guid accountId)
        {
            return await repository.GetByAccountIdAsync(accountId) is IEnumerable<Activity> activities
                ? mapper.Map<IEnumerable<ActivityResponse>>(activities)
                : [];
        }

        public async Task<IEnumerable<ActivityResponse>> GetByDealIdAsync(Guid dealId)
        {
            return await repository.GetByDealIdAsync(dealId) is IEnumerable<Activity> activities
                ? mapper.Map<IEnumerable<ActivityResponse>>(activities)
                : [];
        }

        public async Task<ActivityResponse?> GetByIdAsync(Guid id)
        {
            return await repository.GetByIdAsync(id) is Activity activity
                ? mapper.Map<ActivityResponse>(activity)
                : null;
        }

        public async Task UpdateAsync(Guid id, UpdateActivityRequest request)
        {
            await repository.UpdateAsync(mapper.Map(request, await repository.GetByIdAsync(id))!);
        }
    }
}
