using CRM.Domain.Entities.Commons;

namespace CRM.Domain.Entities
{
    public class QuoteItem : BaseEntity
    {
        public Guid QuoteId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice => Product?.Price ?? 0;
        public decimal TotalPrice => Quantity * UnitPrice;

        public Quote Quote { get; set; }
        public Product Product { get; set; }


    }
}
