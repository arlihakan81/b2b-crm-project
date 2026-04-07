namespace CRM.Domain.Entities.Commons
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public Guid OrganizationId { get; set; }        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public Organization Organization { get; set; }

    }
}
