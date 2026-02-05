using CRM.Application.DTOs.CategoryDTOs;
using CRM.Domain.Entities;

namespace CRM.Application.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<bool> IsCategoryNameUniqueAsync(string name, Guid orgId, Guid? excludeId);        

    }
}
