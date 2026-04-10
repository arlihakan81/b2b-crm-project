using CRM.Domain.Entities.Commons;
using CRM.Domain.Enums;

namespace CRM.Domain.Entities
{
    public class Quote : BaseEntity
    {
        public Guid DealId { get; set; }
        public decimal TotalAmount => Items?.Sum(i => i.TotalPrice) ?? 0;
        public Currency Currency { get; set; }
        public DateTime ValidUntil { get; set; }
        public string? Description { get; set; }

        public Deal Deal { get; set; }
        public ICollection<QuoteItem>? Items { get; set; }
    }
}
