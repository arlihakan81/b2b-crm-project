using CRM.Domain.Commons;

namespace CRM.Domain.Entities
{
    public class Attendee
    {
        public Guid Id { get; set; }
        public Guid ActivityId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public virtual Activity Activity { get; set; }
        public virtual User User { get; set; }

    }
}
