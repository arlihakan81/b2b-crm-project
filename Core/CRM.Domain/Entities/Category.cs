using CRM.Domain.Commons;

namespace CRM.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Deal>? Deals { get; set; }
    }
}