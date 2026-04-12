using CRM.Domain.Entities.Commons;
using CRM.Domain.Enums;

namespace CRM.Domain.Entities
{
    public class Deal : BaseEntity
    {
        public string Name { get; set; }
        public string Code => $"DL-{Id.ToString()[..8].ToUpper()}";
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
        public decimal Probability {
            get
            {
                if(Stage == DealStage.New) return 10;
                if (Stage == DealStage.Qualification) return 30;
                if (Stage == DealStage.Proposal) return 60;
                if (Stage == DealStage.Negotiation) return 80;
                if (Stage == DealStage.ClosedWon) return 100;
                if (Stage == DealStage.ClosedLost) return 0;
                return Probability;
            }
            set => _ = Probability;
        }
        public decimal ExpectedRevenue => Amount * Probability / 100;
        public Priority Priority { get; set; }

        public DealCategory Category { get; set; }
        public Account Account { get; set; }
        public Contact? Contact { get; set; }
        public ApplicationUser Owner { get; set; }

        public ICollection<Quote>? Quotes { get; set; }


    }
}
