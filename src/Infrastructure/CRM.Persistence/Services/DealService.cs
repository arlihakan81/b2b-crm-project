using AutoMapper;
using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using CRM.Application.Requests.Deals;
using CRM.Application.Responses.Deals;
using CRM.Domain.Entities;

namespace CRM.Persistence.Services
{
    public class DealService(IDealRepository repository, IMapper mapper) : IDealService
    {
        readonly IDealRepository repository = repository;
        readonly IMapper mapper = mapper;

        public async Task CreateAsync(CreateDealRequest request)
        {
            await repository.AddAsync(mapper.Map<Deal>(request));
        }

        public async Task DeleteAsync(Guid id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<DealResponse>?> GetAllAsync()
        {
            var deals = await repository.GetAllAsync();
            return deals is null ? [] : mapper.Map<IEnumerable<DealResponse>>(deals);
        }

        public async Task<DealResponse?> GetByIdAsync(Guid id)
        {
            var deal = await repository.GetByIdAsync(id);
            return deal is null ? null : mapper.Map<DealResponse>(deal);
        }

        public async Task UpdateAsync(Guid id, UpdateDealRequest request)
        {
            var deal = await repository.GetByIdAsync(id);
            if(deal is null)
            {
                throw new Exception("Deal not found");
            }
            await repository.UpdateAsync(mapper.Map(request, deal)!);
        }
    }
}
