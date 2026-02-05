using CRM.Domain.Enums;

namespace CRM.Application.DTOs.LeadDTOs
{
    public class CreateLeadDTO
    {
        public string Name { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string? Title { get; set; }
        public string? Mobile { get; set; }
        public string? Phone { get; set; }
        public string? Website { get; set; }
        public string? Industry { get; set; }
        public int? NumberOfEmployees { get; set; }
        public decimal? AnnualRevenue { get; set; }
        public string? Description { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? ZipCode { get; set; }
        public LeadStatus Status { get; set; }
        public LeadSource Source { get; set; }
        public Guid OwnerId { get; set; }
        public Guid? AccountId { get; set; }
        public Guid? ContactId { get; set; }

    }

    public class UpdateLeadDTO : CreateLeadDTO { }
}
