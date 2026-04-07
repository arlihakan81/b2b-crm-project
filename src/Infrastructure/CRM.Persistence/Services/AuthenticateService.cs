using CRM.Application.Interfaces;
using CRM.Application.Requests.Authenticate;
using CRM.Domain.Entities;
using CRM.Persistence.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CRM.Persistence.Services
{
    public class AuthenticateService(ApplicationDbContext context, ITokenService tokenService) : IAuthenticateService
    {
        readonly ITokenService tokenService = tokenService;

        public async Task<string> AuthenticateAsync(string email, string password)
        {
            var user = await GetByEmailAsync(email);
            if (user is null)
            {
                return null!;
            }
            if(!user.IsEmailConfirmed)
            {
                throw new UnauthorizedAccessException("Email not confirmed");
            }
            if (new PasswordHasher<ApplicationUser>().VerifyHashedPassword(user, user.PasswordHash, password)
                is PasswordVerificationResult.Failed)
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }
            return tokenService.GenerateToken(user);
        }

        public async Task<ApplicationUser?> GetByEmailAsync(string email)
        {
            return await context.ApplicationUsers.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task RegisterAsync(RegisterRequest request)
        {
            var organization = new Organization
            {
                Name = request.Email.Split('@')[1],
                Domain = request.Email.Split('@')[1]
            };
            context.Organizations.Add(organization);
            context.SaveChanges();
            var user = new ApplicationUser
            {
                Avatar = null,
                Name = request.Name,
                Email = request.Email,
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null!, request.Password),
                RoleId = context.ApplicationRoles.FirstOrDefault(_ => _.Name == "Super Admin")!.Id,
                OrganizationId = organization.Id,
                IsDeleted = false
            };
            context.ApplicationUsers.Add(user);
            await context.SaveChangesAsync();
        }
    }
}
