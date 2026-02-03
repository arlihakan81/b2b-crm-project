using CRM.Application.Interfaces;

namespace CRM.API.Services
{
    public class OrganizationService(IHttpContextAccessor context) : IOrganizationService
    {
        private readonly IHttpContextAccessor _context = context;

        public Guid GetCurrentOrganizationId()
        {
            var organizationId = _context.HttpContext?.User.Claims
                .FirstOrDefault(c => c.Type == "OrganizationId")?.Value;

            if (organizationId == null || !Guid.TryParse(organizationId, out var orgId))
            {
                throw new Exception("OrganizationId claim is missing or invalid.");
            }

            return orgId;
        }
    }
}
