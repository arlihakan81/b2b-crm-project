using CRM.Application.DTOs.AttendeeDTOs;
using CRM.Domain.Entities;
using CRM.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace CRM.Application.DTOs.ActivityDTOs
{
    public class ActivityDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public ActivityType Type { get; set; }
        public DateTime DueDate { get; set; }
        public Guid AccountId { get; set; }
        public Guid ContactId { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<AttendeeDTO>? Attendees { get; set; }
    }

    public class CreateActivityDTO
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public ActivityType Type { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public Guid AccountId { get; set; }
        [Required]
        public Guid ContactId { get; set; }

        public virtual ICollection<AttendeeDTO>? Attendees { get; set; }
    }

    public class UpdateActivityDTO : CreateActivityDTO
    {
    }


}