namespace CRM.Domain.Entities
{
    public class Permission
    {
        public Guid Id { get; set; }
        public string Module { get; set; }
        public string Action { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }
}
