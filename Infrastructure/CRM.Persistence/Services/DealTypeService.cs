using AutoMapper;
using CRM.Application.DTOs.DealTypeDTOs;
using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using CRM.Domain.Entities;

namespace CRM.Persistence.Services
{
    public class DealTypeService(IDealTypeRepository repository, IMapper mapper, IOrganizationService service) : IDealTypeService
    {
        public async Task CreateAsync(CreateDealTypeDTO createDealTypeDTO)
        {
            var dealType = mapper.Map<DealType>(createDealTypeDTO);
            dealType.OrganizationId = service.GetCurrentOrganizationId();
            await repository.CreateAsync(dealType);
        }

        public async Task DeleteAsync(Guid id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<DealTypeDTO>?> GetAllAsync()
        {
            var dealTypes = await repository.GetAllAsync(prop => prop.OrganizationId == service.GetCurrentOrganizationId());
            return mapper.Map<IEnumerable<DealTypeDTO>>(dealTypes);
        }

        public async Task<DealTypeDTO?> GetAsync(Guid id)
        {
            var dealType = await repository.GetAsync(id);
            return mapper.Map<DealTypeDTO>(dealType);
        }

        public async Task<bool> IsNameUniqueAsync(string name, Guid? excludeId = null)
        {
            return await repository.IsNameUniqueAsync(name, service.GetCurrentOrganizationId(), excludeId);
        }

        public async Task UpdateAsync(Guid id, UpdateDealTypeDTO updateDealTypeDTO)
        {
            var dealType = await repository.GetAsync(id);
            await repository.UpdateAsync(mapper.Map(updateDealTypeDTO, dealType)!);
        }
    }
}
