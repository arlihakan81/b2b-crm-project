using CRM.Application.Responses.Contacts;
using CRM.Domain.Enums;

namespace CRM.Application.Responses.Accounts
{
    public class AccountDetailResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public AccountType Type { get; set; }
        public string? Industry { get; set; }
        public string? BillingAddress { get; set; }
        public string? ShippingAddress { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Website { get; set; }
        public string? ZipCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public ICollection<ContactResponse>? Contacts { get; set; }
    }
}
