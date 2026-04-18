namespace CRM.Domain.Entities.Commons
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public Guid OrganizationId { get; set; }    
        public Guid CreatedById { get; set; }
        public Guid? UpdatedById { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? ModifiedAt { get; set; }

        public ApplicationUser CreatedBy { get; set; }
        public ApplicationUser UpdatedBy { get; set; }  

        public Organization Organization { get; set; }

    }
}
