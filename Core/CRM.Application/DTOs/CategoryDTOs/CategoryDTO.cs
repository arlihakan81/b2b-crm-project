namespace CRM.Application.DTOs.CategoryDTOs
{
    public class CategoryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class CreateCategoryDTO
    {
        public string Name { get; set; }
    }

    public class UpdateCategoryDTO : CreateCategoryDTO
    {
    }

}
