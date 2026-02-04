using CRM.Application.Repositories;
using CRM.Domain.Entities;
using CRM.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRM.Persistence.Repositories
{
    public class ContactRepository(AppDbContext context) : GenericRepository<Contact>(context), IContactRepository
    {
        public DbSet<Contact> Contacts => context.Set<Contact>();

        public override async Task<IEnumerable<Contact>?> GetAllAsync(Expression<Func<Contact, bool>>? expression = null)
        {
            return expression is null ? await Contacts.Include(c => c.Account).Include(c => c.Owner).ToListAsync() : await Contacts.Where(expression).Include(c => c.Owner).Include(c => c.Account).ToListAsync();
        }

        public override async Task<Contact?> GetAsync(Expression<Func<Contact, bool>> expression)
        {
            return await Contacts.Include(c => c.Account).Include(c => c.Owner).FirstOrDefaultAsync(expression);
        }

        public override async Task<Contact?> GetAsync(Guid id)
        {
            return await Contacts.Include(c => c.Account).Include(c => c.Owner).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> IsEmailUniqueAsync(string email, Guid? excludeId)
        {
            return excludeId is null ? !await Contacts.AnyAsync(c => c.Email == email) : !await Contacts.AnyAsync(c => c.Email == email && c.Id != excludeId);
        }

        public async Task<bool> IsMobileUniqueAsync(string phone, Guid? excludeId)
        {
            return excludeId is null ? !await Contacts.AnyAsync(c => c.Mobile == phone) : !await Contacts.AnyAsync(c => c.Mobile == phone && c.Id != excludeId);
        }
    }
}
