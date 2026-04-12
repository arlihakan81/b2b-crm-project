using CRM.Domain.Entities;

namespace CRM.Application.Repositories
{
    public interface IQuoteItemRepository : IRepository<QuoteItem>
    {
        Task DeleteRangeAsync(List<QuoteItem> items);
        Task<IEnumerable<QuoteItem>?> GetByQuoteIdAsync(Guid quoteId);

    }
}
