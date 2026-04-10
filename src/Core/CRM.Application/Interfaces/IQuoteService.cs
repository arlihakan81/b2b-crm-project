using CRM.Application.Requests.Quotes;
using CRM.Application.Responses.Quotes;

namespace CRM.Application.Interfaces
{
    public interface IQuoteService
    {
        Task<IEnumerable<QuoteResponse>?> GetAllAsync();
        Task<QuoteResponse?> GetByIdAsync(Guid id);

        Task CreateAsync(CreateQuoteRequest request);
        Task UpdateAsync(Guid id, UpdateQuoteRequest request);
        Task DeleteAsync(Guid id);


    }
}
