using CRM.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace CRM.Persistence.Services
{
    public class ApplicationUserService(IHttpContextAccessor httpContextAccessor) : IApplicationUserService
    {
        readonly IHttpContextAccessor httpContextAccessor = httpContextAccessor;

        public Guid GetCurrentUserId()
        {
            var userIdClaim = httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim != null && Guid.TryParse(userIdClaim.Value, out Guid userId))
            {
                return userId;
            }
            throw new Exception("User ID claim not found or invalid.");
        }

    }
}