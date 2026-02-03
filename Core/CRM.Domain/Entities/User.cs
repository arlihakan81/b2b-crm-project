using CRM.Domain.Commons;
using CRM.Domain.Enums;

namespace CRM.Domain.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public Role Role { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public virtual ICollection<Account>? Accounts { get; set; }
        public virtual ICollection<Contact>? Contacts { get; set; }
    }
}
