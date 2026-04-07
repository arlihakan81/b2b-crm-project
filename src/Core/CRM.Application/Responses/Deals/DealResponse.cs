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
        public Currency Currency { get; set; }
        public DealType Type { get; set; }
        public Guid CategoryId { get; set; }
        public decimal Amount { get; set; }
        public Guid AccountId { get; set; }
        public Guid? ContactId { get; set; }
        public DateTime? CloseDate { get; set; }
        public DealStage Stage { get; set; }
        public Guid OwnerId { get; set; }
        public decimal? Probability { get; set; }
        public decimal? ExpectedRevenue { get; set; }
        public Priority Priority { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public AccountResponse Account { get; set; }
        public ContactResponse? Contact { get; set; }
    }
}
