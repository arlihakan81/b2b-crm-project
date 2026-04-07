using CRM.Domain.Entities.Commons;

namespace CRM.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid AccountId { get; set; }
        public Guid? ContactId { get; set; }
        public decimal Total => Items?.Sum(i => i.Total) ?? 0;
        public Account Account { get; set; }
        public Contact? Contact { get; set; }

        public ICollection<OrderItem>? Items { get; set; }

    }
}
