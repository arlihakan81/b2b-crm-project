using CRM.Domain.Entities;

namespace CRM.Application.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);


    }
}
