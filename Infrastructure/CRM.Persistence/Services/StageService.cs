using AutoMapper;
using CRM.Application.DTOs.StageDTOs;
using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using CRM.Domain.Entities;

namespace CRM.Persistence.Services
{
    public class StageService(IStageRepository repository, IMapper mapper, IOrganizationService service) : IStageService
    {
        public async Task CreateAsync(CreateStageDTO createStageDTO)
        {
            var stage = mapper.Map<Stage>(createStageDTO);
            stage.OrganizationId = service.GetCurrentOrganizationId();
            await repository.CreateAsync(stage);
        }

        public async Task DeleteAsync(Guid id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<StageDTO>?> GetAllAsync()
        {
            return await repository.GetAllAsync(prop => prop.OrganizationId == service.GetCurrentOrganizationId()) is IEnumerable<Stage> stages ? mapper.Map<IEnumerable<StageDTO>>(stages) : [];
        }

        public async Task<StageDTO?> GetAsync(Guid id)
        {
            var stage = await repository.GetAsync(id);
            return mapper.Map<StageDTO>(stage);
        }

        public async Task<bool> IsStageNameUniqueAsync(string name, Guid? excludeId = null)
        {
            return await repository.IsStageNameUniqueAsync(name, service.GetCurrentOrganizationId(), excludeId);
        }

        public async Task UpdateAsync(Guid id, UpdateStageDTO updateStageDTO)
        {
            var stage = await repository.GetAsync(id);
            await repository.UpdateAsync(mapper.Map(updateStageDTO, stage)!);
        }
    }
}
