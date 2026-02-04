using CRM.Application.DTOs.AccountDTOs;

namespace CRM.Application.DTOs.ContactDTOs
{
    public class ContactDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Title { get; set; }
        public string? Mobile { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? ZipCode { get; set; }
        public DateTime? LastContacted { get; set; }
        public string? Description { get; set; }
        public Guid OwnerId { get; set; }
        public Guid AccountId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual AccountDTO Account { get; set; }
    }
}
