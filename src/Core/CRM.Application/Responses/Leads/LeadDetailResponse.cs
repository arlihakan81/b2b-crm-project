using CRM.Application.Responses.Contacts;
using CRM.Domain.Enums;

namespace CRM.Application.Responses.Leads
{
    public class LeadDetailResponse
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string Company { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public LeadSource Source { get; set; }
        public ContactResponse? Contact { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }


    }
}
