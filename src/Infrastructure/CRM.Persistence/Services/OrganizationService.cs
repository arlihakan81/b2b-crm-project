using CRM.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace CRM.Persistence.Services
{
    public class OrganizationService(IHttpContextAccessor httpContextAccessor) : IOrganizationService
    {
        readonly IHttpContextAccessor httpContextAccessor = httpContextAccessor;

        public Guid GetCurrentOrganizationId()
        {
            var organizationIdClaim = httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "OrganizationId");
            if (organizationIdClaim != null && Guid.TryParse(organizationIdClaim.Value, out Guid organizationId))
            {
                return organizationId;
            }
            throw new Exception("Organization ID claim not found or invalid.");
        }

        public bool IsAuthenticated()
        {
            return httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated == true;           
        }
    }
}
