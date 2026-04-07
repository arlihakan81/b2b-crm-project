using CRM.Application.Requests.Contacts;
using CRM.Application.Responses.Contacts;

namespace CRM.Application.Interfaces
{
    public interface IContactService
    {
        Task<IEnumerable<ContactResponse>?> GetAllAsync();
        Task<ContactDetailResponse?> GetAsync(Guid id);
        Task CreateAsync(CreateContactRequest request);
        Task UpdateAsync(Guid id, UpdateContactRequest request);
        Task DeleteAsync(Guid id);


    }
}
