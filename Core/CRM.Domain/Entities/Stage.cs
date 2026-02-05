using CRM.Domain.Commons;

namespace CRM.Domain.Entities
{
    public class Stage : BaseEntity
    {
        public string Name { get; set; }
        public decimal? ForecastRevenue { get; set; }

        public virtual ICollection<Deal>? Deals { get; set; }

    }
}
