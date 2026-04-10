namespace CRM.Application.Requests.QuoteItems
{
    public class CreateQuoteItemRequest
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }

    public class UpdateQuoteItemRequest : CreateQuoteItemRequest { }
}
