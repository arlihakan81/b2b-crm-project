using System.ComponentModel.DataAnnotations;

namespace CRM.Application.DTOs.StageDTOs
{
    public class StageDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal? ForecastRevenue { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class CreateStageDTO
    {
        [Required]
        public string Name { get; set; }
        public decimal? ForecastRevenue { get; set; }

    }

    public class UpdateStageDTO : CreateStageDTO
    {
    }


}
