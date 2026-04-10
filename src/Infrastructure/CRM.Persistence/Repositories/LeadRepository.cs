using CRM.Application.Repositories;
using CRM.Domain.Entities;
using CRM.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CRM.Persistence.Repositories
{
    public class LeadRepository(ApplicationDbContext context) : Repository<Lead>(context), ILeadRepository
    {
        readonly ApplicationDbContext context = context;

        public override async Task<Lead?> GetByIdAsync(Guid id)
        {
            return await context.Leads
                .Include(l => l.Account)
                .Include(l => l.Contact)
                .Include(l => l.Owner)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<bool> IsEmailUniqueAsync(string email, Guid? excludeId = null)
        {
            return excludeId.HasValue
                ? !await context.Leads.AnyAsync(l => l.Email == email && l.Id != excludeId.Value)
                : !await context.Leads.AnyAsync(l => l.Email == email);
        }

        public async Task<bool> IsPhoneUniqueAsync(string phone, Guid? excludeId = null)
        {
            return excludeId.HasValue
                ? !await context.Leads.AnyAsync(l => l.Phone == phone && l.Id != excludeId.Value)
                : !await context.Leads.AnyAsync(l => l.Phone == phone);
        }
    }
}
