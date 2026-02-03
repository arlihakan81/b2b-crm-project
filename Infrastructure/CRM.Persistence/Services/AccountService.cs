using AutoMapper;
using CRM.Application.DTOs.AccountDTOs;
using CRM.Application.Interfaces;
using CRM.Application.Repositories;
using System.Linq.Expressions;

namespace CRM.Persistence.Services
{
    public class AccountService(IAccountRepository repository, IMapper mapper, IOrganizationService service) : IAccountService
    {
        public async Task<IEnumerable<AccountDTO>?> GetAllAsync()
        {
            var accounts = await repository.GetAllAsync(prop => prop.OrganizationId == service.GetCurrentOrganizationId());
            var result = mapper.Map<IEnumerable<AccountDTO>>(accounts);
            return result;
        }
    }
}
