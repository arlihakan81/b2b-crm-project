using CRM.Application.Requests.QuoteItems;
using CRM.Domain.Enums;

namespace CRM.Application.Requests.Quotes
{
    public class CreateQuoteRequest
    {
        public Guid DealId { get; set; }
        public DateTime ValidUntil { get; set; }
        public string? Description { get; set; }
        public Currency Currency { get; set; }

        public ICollection<CreateQuoteItemRequest>? Items { get; set; }
    }

    public class UpdateQuoteRequest : CreateQuoteRequest
    { 
    }
}
