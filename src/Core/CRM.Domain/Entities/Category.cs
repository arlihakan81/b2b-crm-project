using CRM.Domain.Entities.Commons;

namespace CRM.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        public ICollection<Deal>? Deals { get; set; }
    }
}
