using CRM.Application.Responses.Accounts;
using CRM.Application.Responses.Deals;
using CRM.Domain.Enums;

namespace CRM.Application.Responses.Activities
{
    public class ActivityResponse
    {
        public Guid Id { get; set; }
        public string? Type { get; set; }
        public string Subject { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? Account { get; set; }
        public string? Deal { get; set; }


    }
}
