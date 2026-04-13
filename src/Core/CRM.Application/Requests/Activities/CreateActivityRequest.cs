using CRM.Domain.Enums;

namespace CRM.Application.Requests.Activities
{
    public class CreateActivityRequest
    {
        public ActivityType Type { get; set; }
        public string Subject { get; set; }
        public string? Description { get; set; }
        public Guid RelatedEntityId { get; set; }
        public EntityType RelatedEntityType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsCompleted { get; set; }


    }

    public class UpdateActivityRequest : CreateActivityRequest
    {
    }


}
