using CRM.Application.Responses.Accounts;

namespace CRM.Application.Responses.Contacts
{
    public class ContactDetailResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string? Title { get; set; }
        public string? Mobile { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public bool IsPrimary { get; set; } = false;
        public Guid OwnerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public AccountResponse Account { get; set; }
    }
}
