using CRM.Application.Requests.Products;
using CRM.Application.Responses.Products;

namespace CRM.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponse>?> GetAllAsync();
        Task<ProductResponse?> GetByIdAsync(Guid id);
        Task CreateAsync(CreateProductRequest request);
        Task UpdateAsync(Guid id, UpdateProductRequest request);
        Task DeleteAsync(Guid id);


    }
}
