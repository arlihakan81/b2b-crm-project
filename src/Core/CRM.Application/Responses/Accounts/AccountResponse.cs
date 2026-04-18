using CRM.Application.Responses.Contacts;
using CRM.Domain.Enums;

namespace CRM.Application.Responses.Accounts
{
    public class AccountResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Type { get; set; }
        public string? Industry { get; set; }
        
    }
}
