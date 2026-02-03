using CRM.Application.DTOs.AccountDTOs;
using System.Linq.Expressions;

namespace CRM.Application.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountDTO>?> GetAllAsync();
    }
}
