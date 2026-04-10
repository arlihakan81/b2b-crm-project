using CRM.Application.Responses.Deals;
using CRM.Application.Responses.QuoteItems;
using CRM.Domain.Enums;

namespace CRM.Application.Responses.Quotes
{
    public class QuoteResponse
    {
        public Guid Id { get; set; }
        public decimal TotalAmount => Items?.Sum(i => i.TotalPrice) ?? 0;
        public Currency Currency { get; set; }
        public DateTime ValidUntil { get; set; }
        public string? Description { get; set; }

        public DealResponse Deal { get; set; }
        public ICollection<QuoteItemResponse>? Items { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
