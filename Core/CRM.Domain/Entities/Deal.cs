using CRM.Domain.Commons;
using CRM.Domain.Enums;

namespace CRM.Domain.Entities
{
    public class Deal : BaseEntity
    {
        public Guid OwnerId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public decimal? ExpectedRevenue { get; set; }
        public DateTime OpeningTime { get; set; } = DateTime.Now;
        public DateTime? ClosedTime { get; set; }
        public decimal? Probability { get; set; }
        public Guid AccountId { get; set; }
        public Guid ContactId { get; set; }
        public CampaignSource Source { get; set; }
        public Guid StageId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid TypeId { get; set; }

        // Navigation Properties
        public virtual User Owner { get; set; }
        public virtual Account Account { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual Stage Stage { get; set; }
        public virtual Category Category { get; set; }
        public virtual DealType Type { get; set; }
    }
}
