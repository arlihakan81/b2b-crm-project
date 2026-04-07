using CRM.Application.Requests.Authenticate;
using CRM.Domain.Entities;

namespace CRM.Application.Interfaces
{
    public interface IAuthenticateService
    {
        Task<string> AuthenticateAsync(string email, string password);
        Task RegisterAsync(RegisterRequest request);
        Task<ApplicationUser?> GetByEmailAsync(string email);
    }
}
