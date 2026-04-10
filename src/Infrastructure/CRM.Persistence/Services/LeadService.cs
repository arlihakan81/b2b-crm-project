using AutoMapper;
using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using CRM.Application.Requests.Leads;
using CRM.Application.Responses.Leads;
using CRM.Domain.Entities;

namespace CRM.Persistence.Services
{
    public class LeadService(ILeadRepository repository, IMapper mapper) : ILeadService
    {
        readonly ILeadRepository repository = repository;
        readonly IMapper mapper = mapper;

        public async Task CreateAsync(CreateLeadRequest request)
        {
            if(!await repository.IsEmailUniqueAsync(request.Email))
                throw new InvalidOperationException($"Email {request.Email} is already in use.");
            if(!string.IsNullOrEmpty(request.Phone))
            {
                if (!await repository.IsPhoneUniqueAsync(request.Phone))
                    throw new InvalidOperationException($"Phone {request.Phone} is already in use.");
            }            
            await repository.AddAsync(mapper.Map<Lead>(request));
        }

        public async Task DeleteAsync(Guid id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<LeadResponse>?> GetAllAsync()
        {
            return await repository.GetAllAsync() is IEnumerable<Lead> leads
                ? mapper.Map<IEnumerable<LeadResponse>>(leads)
                : [];
        }

        public async Task<LeadDetailResponse?> GetAsync(Guid id)
        {
            return await repository.GetByIdAsync(id) is Lead lead
                ? mapper.Map<LeadDetailResponse>(lead)
                : null;
        }

        public async Task UpdateAsync(Guid id, UpdateLeadRequest request)
        {
            var existingLead = await repository.GetByIdAsync(id) ?? throw new KeyNotFoundException($"Lead with ID {id} not found.");
            if (!await repository.IsEmailUniqueAsync(request.Email, id))
                throw new InvalidOperationException($"Email {request.Email} is already in use.");
            if (!string.IsNullOrEmpty(request.Phone))
            {
                if (!await repository.IsPhoneUniqueAsync(request.Phone, id))
                    throw new InvalidOperationException($"Phone {request.Phone} is already in use.");
            }
            await repository.UpdateAsync(mapper.Map(request, existingLead));
        }
    }
}
