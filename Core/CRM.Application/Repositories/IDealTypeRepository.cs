using CRM.Domain.Entities;

namespace CRM.Application.Repositories
{
    public interface IDealTypeRepository : IGenericRepository<DealType>
    {
        Task<bool> IsNameUniqueAsync(string name, Guid orgId, Guid? excludeId = null);
    }
}
