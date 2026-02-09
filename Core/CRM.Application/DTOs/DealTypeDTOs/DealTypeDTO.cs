using System.ComponentModel.DataAnnotations;

namespace CRM.Application.DTOs.DealTypeDTOs
{
    public class DealTypeDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class CreateDealTypeDTO
    {
        [Required]
        public string Name { get; set; }
    }

    public class UpdateDealTypeDTO : CreateDealTypeDTO
    {
    }






}
