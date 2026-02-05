using AutoMapper;
using CRM.Application.DTOs.CategoryDTOs;
using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using CRM.Domain.Entities;

namespace CRM.Persistence.Services
{
    public class CategoryService(ICategoryRepository repository, IMapper mapper, IOrganizationService service) : ICategoryService
    {
        public async Task CreateAsync(CreateCategoryDTO dto)
        {
            var category = mapper.Map<Category>(dto);
            category.OrganizationId = service.GetCurrentOrganizationId();
            await repository.CreateAsync(category);
        }

        public async Task DeleteAsync(Guid id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CategoryDTO>?> GetAllAsync()
        {
            var categories = await repository.GetAllAsync(prop => prop.OrganizationId == service.GetCurrentOrganizationId());
            if (categories is null)
                return [];
            return mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public async Task<CategoryDTO> GetAsync(Guid id)
        {
            var category = await repository.GetAsync(id);
            return mapper.Map<CategoryDTO>(category);
        }

        public async Task<bool> IsCategoryNameUniqueAsync(string categoryName, Guid? excludeId)
        {
            return await repository.IsCategoryNameUniqueAsync(categoryName, service.GetCurrentOrganizationId(), excludeId);
        }

        public async Task UpdateAsync(Guid id, UpdateCategoryDTO dto)
        {
            var category = await repository.GetAsync(id);
            await repository.UpdateAsync(mapper.Map(dto, category)!);
        }
    }
}
