using CRM.Application.Interfaces;
using CRM.Application.Requests;
using CRM.Domain.Entities;
using CRM.Persistence.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CRM.Persistence.Services
{
    public class AuthenticateService(AppDbContext context, ITokenService tokenService) : IAuthenticateService
    {
        readonly AppDbContext _context = context;
        readonly ITokenService _tokenService = tokenService;

        public async Task<string> AuthenticateAsync(string email, string password)
        {
            var user = await GetByEmailAsync(email);
            if (user == null)
            {
                throw new Exception("Invalid credentials");
            }

            if(new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, password) == PasswordVerificationResult.Failed)
            {
                throw new Exception("Invalid credentials");
            }

            return _tokenService.CreateToken(user);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task RegisterAsync(RegisterRequest request)
        {
            var organization = new Organization
            {
                Name = request.OrganizationName,
                Phone = request.Phone,
                Address = request.Address,
                State = request.State,
                City = request.City,
                Country = request.Country
            };

            if(_context.Organizations.Any(t => t.Name == organization.Name))
            {
                throw new Exception("Organization with the same name already exists");
            }
            _context.Organizations.Add(organization);
            await _context.SaveChangesAsync();

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordHash = new PasswordHasher<User>().HashPassword(null!, request.Password),
                Role = request.Role,
                OrganizationId = organization.Id
            };

            if(_context.Users.Any(u => u.Email == user.Email))
            {
                throw new Exception("User with the same email already exists");
            }
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }



    }
}
