using CRM.Application.Responses.Accounts;

namespace CRM.Application.Responses.Contacts
{
    public class ContactDetailResponse : ContactResponse
    {
        public string? Mobile { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public bool IsPrimary { get; set; } = false;
        public Guid OwnerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public AccountResponse Account { get; set; }
    }
}
