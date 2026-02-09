using CRM.Domain.Commons;

namespace CRM.Domain.Entities
{
    public class Account : BaseEntity
    {
        public string Name { get; set; }
        public Guid OwnerId { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string? Website { get; set; }
        public string? Industry { get; set; }
        public int? NumberOfEmployees { get; set; }
        public decimal? AnnualRevenue { get; set; }
        public string? Description { get; set; }
        public string? BillingAddress { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? ZipCode { get; set; }

        public virtual User Owner { get; set; }
        public virtual ICollection<Contact>? Contacts { get; set; }
        public virtual ICollection<Deal>? Deals { get; set; }
        public virtual ICollection<Activity>? Activities { get; set; }

    }
}
