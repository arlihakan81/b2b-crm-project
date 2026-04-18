using CRM.Application.Responses.Contacts;
using CRM.Domain.Enums;

namespace CRM.Application.Responses.Accounts
{
    public class AccountDetailResponse : AccountResponse
    {
        public string? TaxNumber { get; set; }
        public string? TaxOffice { get; set; }
        public string? BillingAddress { get; set; }
        public string? ShippingAddress { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Website { get; set; }
        public string? ZipCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public ICollection<ContactResponse>? Contacts { get; set; }
    }
}
