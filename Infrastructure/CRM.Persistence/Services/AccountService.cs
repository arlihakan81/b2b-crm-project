using AutoMapper;
using CRM.Application.DTOs.AccountDTOs;
using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using CRM.Domain.Entities;
using System.Linq.Expressions;

namespace CRM.Persistence.Services
{
    public class AccountService(IAccountRepository repository, IMapper mapper, IOrganizationService service) : IAccountService
    {
        public async Task CreateAsync(CreateAccountDTO dto)
        {            
            var account = mapper.Map<Account>(dto);
            account.OrganizationId = service.GetCurrentOrganizationId();                           
            await repository.CreateAsync(account);
        }

        public async Task DeleteAsync(Guid id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<AccountDTO>?> GetAllAsync()
        {
            var accounts = await repository.GetAllAsync(prop => prop.OrganizationId == service.GetCurrentOrganizationId());
            var result = mapper.Map<IEnumerable<AccountDTO>>(accounts);
            return result;
        }

        public async Task<AccountDTO?> GetAsync(Guid id)
        {
            var account = await repository.GetAsync(id);
            var result = mapper.Map<AccountDTO>(account);
            return result;
        }

        public async Task<bool> IsEmailUniqueAsync(string email, Guid? excludeId)
        {
            return await repository.IsEmailUniqueAsync(email, excludeId);
        }

        public async Task<bool> IsPhoneUniqueAsync(string phone, Guid? excludeId)
        {
            return await repository.IsPhoneUniqueAsync(phone, excludeId);
        }

        public async Task UpdateAsync(Guid id, UpdateAccountDTO dto)
        {
            var account = await repository.GetAsync(id);
            var updatedAccount = mapper.Map(dto, account);
            await repository.UpdateAsync(updatedAccount!);
        }
    }
}
