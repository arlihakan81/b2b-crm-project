using AutoMapper;
using CRM.Application.DTOs.LeadDTOs;
using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using CRM.Domain.Entities;
using System.Reflection.Metadata.Ecma335;

namespace CRM.Persistence.Services
{
    public class LeadService(ILeadRepository repository, IMapper mapper, IOrganizationService service) : ILeadService
    {
        public async Task CreateAsync(CreateLeadDTO dto)
        {
            var lead = mapper.Map<Lead>(dto);
            lead.OrganizationId = service.GetCurrentOrganizationId();
            await repository.CreateAsync(lead);
        }

        public async Task DeleteAsync(Guid id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<LeadDTO>?> GetAllAsync()
        {
            var leads = await repository.GetAllAsync(prop => prop.OrganizationId == service.GetCurrentOrganizationId());
            if(leads is null)
            {
                return [];
            }
            return mapper.Map<IEnumerable<LeadDTO>>(leads);
        }

        public async Task<LeadDTO?> GetAsync(Guid id)
        {
            var lead = await repository.GetAsync(l => l.Id == id);
            if (lead is null || lead.OrganizationId != service.GetCurrentOrganizationId())
            {
                return null;
            }
            return mapper.Map<LeadDTO>(lead);
        }

        public async Task<bool> IsEmailUniqueAsync(string email, Guid? excludeId)
        {
            return await repository.IsEmailUniqueAsync(email, excludeId);
        }

        public async Task<bool> IsMobileUniqueAsync(string mobile, Guid? excludeId)
        {
            return await repository.IsMobileUniqueAsync(mobile, excludeId);
        }

        public async Task<bool> IsPhoneUniqueAsync(string phone, Guid? excludeId)
        {
            return await repository.IsPhoneUniqueAsync(phone, excludeId);
        }

        public async Task UpdateAsync(Guid id, UpdateLeadDTO dto)
        {
            var lead = await repository.GetAsync(id);
            await repository.UpdateAsync(mapper.Map(dto, lead)!);
        }
    }
}
