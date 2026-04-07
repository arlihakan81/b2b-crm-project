using CRM.Application.Repositories;
using CRM.Domain.Entities;
using CRM.Persistence.Contexts;

namespace CRM.Persistence.Repositories
{
    public class ProductRepository(ApplicationDbContext context) : Repository<Product>(context), IProductRepository
    { 

    }
}
