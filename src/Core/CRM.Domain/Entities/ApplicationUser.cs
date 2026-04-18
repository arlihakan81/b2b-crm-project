using CRM.Domain.Entities.Commons;

namespace CRM.Domain.Entities
{
    public class ApplicationUser
    {
        public Guid Id { get; set; }
        public string? Avatar { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool IsEmailConfirmed { get; set; } = false;
        public Guid RoleId { get; set; }
        public ApplicationRole Role { get; set; }
        public Guid OrganizationId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
        public Organization Organization { get; set; }
        public ICollection<Deal>? Deals { get; set; }
        public ICollection<Account>? Accounts { get; set; }
        public ICollection<Contact>? Contacts { get; set; }
        public ICollection<Lead>? Leads { get; set; }
        public ICollection<Activity>? Activities { get; set; }

    }
}
