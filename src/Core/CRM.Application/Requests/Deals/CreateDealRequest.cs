using CRM.Domain.Enums;

namespace CRM.Application.Requests.Deals
{
    public class CreateDealRequest
    {
        public string Name { get; set; }
        public Currency Currency { get; set; }
        public DealType Type { get; set; }
        public Guid CategoryId { get; set; }
        public decimal Amount { get; set; }
        public Guid AccountId { get; set; }
        public Guid? ContactId { get; set; }
        public DateTime? CloseDate { get; set; }
        public DealStage Stage { get; set; }
        public LeadSource LeadSource { get; set; }
        public Guid OwnerId { get; set; }
        public decimal? Probability { get; set; }
        public decimal? ExpectedRevenue { get; set; }
        public Priority Priority { get; set; }
    }

    public class UpdateDealRequest : CreateDealRequest { }
}
