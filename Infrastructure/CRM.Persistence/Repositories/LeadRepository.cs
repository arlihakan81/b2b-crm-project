using CRM.Application.Repositories;
using CRM.Domain.Entities;
using CRM.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRM.Persistence.Repositories
{
    public class LeadRepository(AppDbContext context) : GenericRepository<Lead>(context), ILeadRepository
    {
        readonly AppDbContext context = context;
        public DbSet<Lead> Leads => context.Set<Lead>();

        public override async Task<IEnumerable<Lead>?> GetAllAsync(Expression<Func<Lead, bool>>? expression = null)
        {
            return expression is null ? await Leads.Include(l => l.User).Include(l => l.Account).Include(l => l.Contact).ToListAsync() :
                await Leads.Where(expression).Include(l => l.User).Include(l => l.Account).Include(l => l.Contact).ToListAsync();
        }

        public override async Task<Lead?> GetAsync(Expression<Func<Lead, bool>> expression)
        {
            return await Leads.Include(l => l.User).Include(l => l.Account).Include(l => l.Contact).FirstOrDefaultAsync(expression);
        }

        public override async Task<Lead?> GetAsync(Guid id)
        {
            return await Leads.Include(l => l.User).Include(l => l.Account).Include(l => l.Contact).FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<bool> IsEmailUniqueAsync(string email, Guid? excludeId)
        {
             return excludeId is null ? !await Leads.AnyAsync(l => l.Email == email) :
                !await Leads.AnyAsync(l => l.Email == email && l.Id != excludeId);
        }

        public async Task<bool> IsMobileUniqueAsync(string mobile, Guid? excludeId)
        {
            return excludeId is null ? !await Leads.AnyAsync(l => l.Mobile == mobile) :
                !await Leads.AnyAsync(l => l.Mobile == mobile && l.Id != excludeId);
        }

        public async Task<bool> IsPhoneUniqueAsync(string phone, Guid? excludeId)
        {
            return excludeId is null ? !await Leads.AnyAsync(l => l.Phone == phone) :
                !await Leads.AnyAsync(l => l.Phone == phone && l.Id != excludeId);
        }
    }
}
