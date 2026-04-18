using CRM.Application.Responses.Accounts;
using CRM.Application.Responses.Contacts;
using CRM.Domain.Enums;

namespace CRM.Application.Responses.Deals
{
    public class DealResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string? Currency { get; set; }
        public string? Type { get; set; }
        public string? Category { get; set; }
        public decimal Amount { get; set; }
        public DateTime? CloseDate { get; set; }
        public string? Stage { get; set; }
        public string? LeadSource { get; set; }
        public string? Owner { get; set; }
        public decimal? Probability { get; set; }
        public decimal? ExpectedRevenue { get; set; }
        public string? Priority { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public ContactResponse? Contact { get; set; }
    }
}
