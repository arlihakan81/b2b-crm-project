using CRM.Application.Responses.Contacts;
using CRM.Domain.Enums;

namespace CRM.Application.Responses.Leads
{
    public class LeadDetailResponse : LeadResponse
    {
        public string? Description { get; set; }
        public ContactResponse? Contact { get; set; }
        public DateTime? ModifiedAt { get; set; }


    }
}
