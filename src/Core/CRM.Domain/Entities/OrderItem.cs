using CRM.Domain.Entities.Commons;

namespace CRM.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total => Quantity * Price;

        public Order Order { get; set; }
        public Product Product { get; set; }

    }
}
