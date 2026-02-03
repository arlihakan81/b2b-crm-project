using CRM.Domain.Commons;

namespace CRM.Domain.Entities
{
    public class Contact : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Mobile { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? ZipCode { get; set; }
        public DateTime? LastContacted { get; set; }
        public string? Description { get; set; }
        public Guid OwnerId { get; set; }
        public Guid AccountId { get; set; }

        public virtual User Owner { get; set; }
        public virtual Account Account { get; set; }
    }
}
