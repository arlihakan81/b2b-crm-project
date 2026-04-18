using CRM.Domain.Entities.Commons;
using CRM.Domain.Enums;

namespace CRM.Domain.Entities
{
    public class Account : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? TaxNumber { get; set; }
        public string? TaxOffice { get; set; }
        public AccountType Type { get; set; }
        public string? Industry { get; set; }
        public string? BillingAddress { get; set; }
        public string? ShippingAddress { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Website { get; set; }
        public string? ZipCode { get; set; }
        public Guid OwnerId { get; set; }

        public ICollection<Contact>? Contacts { get; set; }
        public ApplicationUser Owner { get; set; }

    }
}
