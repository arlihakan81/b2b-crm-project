using AutoMapper;
using CRM.Application.DTOs.CategoryDTOs;
using CRM.Application.Repositories;

namespace CRM.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<bool> IsCategoryNameUniqueAsync(string categoryName, Guid? excludeId);
        Task<IEnumerable<CategoryDTO>?> GetAllAsync();
        Task<CategoryDTO> GetAsync(Guid id);
        Task CreateAsync(CreateCategoryDTO dto);
        Task UpdateAsync(Guid id, UpdateCategoryDTO dto);
        Task DeleteAsync(Guid id);
    }
}
