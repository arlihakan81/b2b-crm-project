using CRM.Domain.Entities.Commons;

namespace CRM.Domain.Entities
{
    public class ApplicationUser : BaseEntity
    {
        public string? Avatar { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool IsEmailConfirmed { get; set; } = false;
        public Guid RoleId { get; set; }
        public ApplicationRole Role { get; set; }

        public ICollection<Deal>? Deals { get; set; }

    }
}
