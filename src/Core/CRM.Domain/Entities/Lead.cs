using CRM.Domain.Entities.Commons;
using CRM.Domain.Enums;

namespace CRM.Domain.Entities
{
    public class Lead : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string Company { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public LeadSource Source { get; set; }
        public Guid? AccountId { get; set; }
        public Guid? ContactId { get; set; }
        public Guid OwnerId { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public Account? Account { get; set; }
        public Contact? Contact { get; set; }
        public ApplicationUser Owner { get; set; }













    }
}
