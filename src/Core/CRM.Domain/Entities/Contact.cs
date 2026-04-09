using CRM.Domain.Entities.Commons;

namespace CRM.Domain.Entities
{
    public class Contact : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string? Title { get; set; }
        public string? Mobile { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public Guid AccountId { get; set; }
        public bool IsPrimary { get; set; } = false;
        public Guid OwnerId { get; set; }

        public Account Account { get; set; }
        public ApplicationUser Owner { get; set; }



    }
}
