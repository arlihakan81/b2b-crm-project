using AutoMapper;
using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using CRM.Application.Requests.Accounts;
using CRM.Application.Responses.Accounts;
using CRM.Domain.Entities;

namespace CRM.Persistence.Services
{
    public class AccountService(IAccountRepository repository, IMapper mapper) : IAccountService
    {
        readonly IAccountRepository repository = repository;
        readonly IMapper mapper = mapper;

        public async Task CreateAsync(CreateAccountRequest request)
        {
            if (request.Email is not null && !await repository.IsEmailUniqueAsync(request.Email))
                throw new Exception("Email must be unique.");
            if (request.Phone is not null && !await repository.IsPhoneUniqueAsync(request.Phone))
                throw new Exception("Phone must be unique.");
            var account = mapper.Map<Account>(request);
            await repository.AddAsync(account);
        }

        public async Task DeleteAsync(Guid id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<AccountResponse>?> GetAllAsync()
        {
            var accounts = await repository.GetAllAsync();
            return accounts is null ? [] : mapper.Map<IEnumerable<AccountResponse>>(accounts);
        }

        public async Task<AccountDetailResponse?> GetAsync(Guid id)
        {
            var account = await repository.GetByIdAsync(id);
            return account is null ? null : mapper.Map<AccountDetailResponse>(account);
        }

        public async Task UpdateAsync(Guid id, UpdateAccountRequest request)
        {
            await Task.Run(async () =>
            {
                var account = await repository.GetByIdAsync(id) ?? throw new KeyNotFoundException($"Account with id {id} not found.");
                if (request.Email is not null && !await repository.IsEmailUniqueAsync(request.Email, id))
                    throw new Exception("Email must be unique.");
                if (request.Phone is not null && !await repository.IsPhoneUniqueAsync(request.Phone, id))
                    throw new Exception("Phone must be unique.");
                mapper.Map(request, account);
                await repository.UpdateAsync(account);
            });
        }
    }
}
