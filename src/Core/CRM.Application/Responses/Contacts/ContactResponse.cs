using CRM.Application.Responses.Accounts;

namespace CRM.Application.Responses.Contacts
{
    public class ContactResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string? Title { get; set; }
        public Guid AccountId { get; set; }

        public AccountResponse Account { get; set; }

    }
}
