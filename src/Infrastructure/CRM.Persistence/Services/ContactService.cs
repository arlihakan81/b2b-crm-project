using AutoMapper;
using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using CRM.Application.Requests.Contacts;
using CRM.Application.Responses.Contacts;
using CRM.Domain.Entities;

namespace CRM.Persistence.Services
{
    public class ContactService(IContactRepository repository, IMapper mapper) : IContactService
    {
        readonly IContactRepository repository = repository;
        readonly IMapper mapper = mapper;

        public async Task CreateAsync(CreateContactRequest request)
        {
            var contact = mapper.Map<Contact>(request);
            if(request.Email is not null && !await repository.IsEmailUniqueAsync(request.Email))
                throw new Exception("Email must be unique.");
            if (request.Mobile is not null && !await repository.IsMobileUniqueAsync(request.Mobile))
                throw new Exception("Mobile must be unique.");
            await repository.AddAsync(contact);
        }

        public async Task DeleteAsync(Guid id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ContactResponse>?> GetAllAsync()
        {
            var contacts = await repository.GetAllAsync();
            return contacts == null ? [] : mapper.Map<IEnumerable<ContactResponse>>(contacts);
        }

        public async Task<ContactDetailResponse?> GetAsync(Guid id)
        {
            var contact = await repository.GetByIdAsync(id);
            return contact == null ? null : mapper.Map<ContactDetailResponse>(contact);
        }

        public async Task UpdateAsync(Guid id, UpdateContactRequest request)
        {
            var contact = await repository.GetByIdAsync(id);
            if (contact is null)
                throw new Exception("Contact not found");
            if (request.Email is not null && !await repository.IsEmailUniqueAsync(request.Email, id))
                throw new Exception("Email must be unique.");
            if (request.Mobile is not null && !await repository.IsMobileUniqueAsync(request.Mobile, id))
                throw new Exception("Mobile must be unique.");
            await repository.UpdateAsync(mapper.Map(request, contact)!);
        }
    }
}
