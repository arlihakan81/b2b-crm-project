using CRM.Domain.Enums;

namespace CRM.Application.Requests.Activities
{
    public class CreateActivityRequest
    {
        public ActivityType Type { get; set; }
        public string Subject { get; set; }
        public string? Description { get; set; }
        public Guid AccountId { get; set; }
        public Guid? DealId { get; set; }
        public Guid OwnerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? DueDate { get; set; }
    }

    public class UpdateActivityRequest : CreateActivityRequest
    {
    }


}
