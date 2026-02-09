using CRM.Domain.Commons;
using CRM.Domain.Enums;

namespace CRM.Domain.Entities
{

    public class Activity : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public ActivityType Type { get; set; }
        public DateTime DueDate { get; set; }
        public Guid AccountId { get; set; }
        public Guid ContactId { get; set; }

        // Navigation properties
        public virtual Account Account { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual ICollection<Attendee>? Attendees { get; set; }  

    }





}