using CRM.Domain.Entities;

namespace CRM.Application.Repositories
{
    public interface IStageRepository : IGenericRepository<Stage>
    {
        Task<bool> IsStageNameUniqueAsync(string name, Guid orgId, Guid? excludeId = null);

    }
}
