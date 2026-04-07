using AutoMapper;
using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using CRM.Application.Requests.Products;
using CRM.Application.Responses.Products;
using CRM.Domain.Entities;

namespace CRM.Persistence.Services
{
    public class ProductService(IProductRepository repository, IMapper mapper) : IProductService
    {
        private readonly IProductRepository repository = repository;
        private readonly IMapper mapper = mapper;

        public async Task CreateAsync(CreateProductRequest request)
        {
            var product = mapper.Map<Product>(request);
            await repository.AddAsync(product);
        }

        public async Task DeleteAsync(Guid id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductResponse>?> GetAllAsync()
        {
            var products = await repository.GetAllAsync();
            return products == null ? [] : mapper.Map<IEnumerable<ProductResponse>>(products);
        }

        public async Task<ProductResponse?> GetByIdAsync(Guid id)
        {
            var product = await repository.GetByIdAsync(id);
            return product == null ? null : mapper.Map<ProductResponse>(product);
        }

        public async Task UpdateAsync(Guid id, UpdateProductRequest request)
        {
            var product = await repository.GetByIdAsync(id);
            product = mapper.Map(request, product);
            await repository.UpdateAsync(product!);
        }
    }
}
