using AutoMapper;
using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using CRM.Application.Requests.Quotes;
using CRM.Application.Responses.QuoteItems;
using CRM.Application.Responses.Quotes;
using CRM.Domain.Entities;

namespace CRM.Persistence.Services
{
    public class QuoteService(IQuoteRepository repository, IQuoteItemRepository itemRepository, IMapper mapper) : IQuoteService
    {
        private readonly IQuoteRepository repository = repository;
        private readonly IMapper mapper = mapper;
        private readonly IQuoteItemRepository itemRepository = itemRepository;

        public async Task CreateAsync(CreateQuoteRequest request)
        {
            var quote = mapper.Map<Domain.Entities.Quote>(request);
            await repository.AddAsync(quote);

            var quoteItems = mapper.Map<List<Domain.Entities.QuoteItem>>(request.Items);
            quoteItems.ForEach(i => i.QuoteId = quote.Id);
        }

        public async Task DeleteAsync(Guid id)
        {
            await repository.DeleteAsync(id);
            var quoteItems = await itemRepository.GetByQuoteIdAsync(id);
            await itemRepository.DeleteRangeAsync(quoteItems!.ToList());
        }

        public async Task<IEnumerable<QuoteResponse>?> GetAllAsync()
        {
            return await repository.GetAllAsync() is IEnumerable<Domain.Entities.Quote> quotes
                ? mapper.Map<IEnumerable<QuoteResponse>>(quotes)
                : [];
        }

        public async Task<QuoteResponse?> GetByIdAsync(Guid id)
        {
            return await repository.GetByIdAsync(id) is Domain.Entities.Quote quote
                ? mapper.Map<QuoteResponse>(quote)
                : null;
        }

        public async Task UpdateAsync(Guid id, UpdateQuoteRequest request)
        {
            var quote = await repository.GetAsync(q => q.Id == id) ?? throw new KeyNotFoundException("Öğe bulunamadı");
            quote = mapper.Map(request, quote);
            await repository.UpdateAsync(quote);
        }
    }
}
