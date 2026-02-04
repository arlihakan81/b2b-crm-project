using AutoMapper;
using CRM.Application.DTOs.ContactDTOs;
using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using CRM.Domain.Entities;

namespace CRM.Persistence.Services
{
    public class ContactService(IContactRepository repository, IMapper mapper, IOrganizationService service) : IContactService
    {
        public async Task CreateAsync(CreateContactDTO dto)
        {
            var contact = mapper.Map<Contact>(dto);
            contact.OrganizationId = service.GetCurrentOrganizationId();
            await repository.CreateAsync(contact);
        }

        public async Task DeleteAsync(Guid id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ContactDTO>?> GetAllAsync()
        {
            var contacts = await repository.GetAllAsync(prop => prop.OrganizationId == service.GetCurrentOrganizationId());
            var result = mapper.Map<IEnumerable<ContactDTO>>(contacts);
            return result;
        }

        public async Task<ContactDTO?> GetAsync(Guid id)
        {
            var contact = await repository.GetAsync(id);
            var result = mapper.Map<ContactDTO>(contact);
            return result;
        }

        public async Task<bool> IsEmailUniqueAsync(string email, Guid? excludeId)
        {
            return await repository.IsEmailUniqueAsync(email, excludeId);
        }

        public async Task<bool> IsMobileUniqueAsync(string mobile, Guid? excludeId)
        {
            return await repository.IsMobileUniqueAsync(mobile, excludeId);
        }

        public async Task UpdateAsync(Guid id, UpdateContactDTO dto)
        {
            var contact = await repository.GetAsync(id);
            var updatedContact = mapper.Map(dto, contact);
            await repository.UpdateAsync(updatedContact!);
        }
    }
}
