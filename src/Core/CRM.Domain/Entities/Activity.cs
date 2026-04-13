using CRM.Domain.Entities.Commons;
using CRM.Domain.Enums;

namespace CRM.Domain.Entities
{
    public class Activity : BaseEntity
    {
        public ActivityType Type { get; set; }
        public string Subject { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public EntityType RelatedEntityType { get; set; }
        public Guid RelatedEntityId { get; set; }
    }
}
