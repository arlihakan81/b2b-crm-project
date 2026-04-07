using CRM.Application.Repositories;
using CRM.Domain.Entities;
using CRM.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CRM.Persistence.Repositories
{
    public class ContactRepository(ApplicationDbContext context) : Repository<Contact>(context), IContactRepository
    {
        readonly ApplicationDbContext context = context;

        public override async Task<IEnumerable<Contact>?> GetAllAsync()
        {
            return await context.Contacts
                .Include(c => c.Account)
                .ToListAsync();
        }

        public async Task<bool> IsEmailUniqueAsync(string email, Guid? contactId = null)
        {
            return contactId == null
                ? !await context.Contacts.AnyAsync(c => c.Email == email)
                : !await context.Contacts.AnyAsync(c => c.Email == email && c.Id != contactId);
        }

        public async Task<bool> IsMobileUniqueAsync(string mobile, Guid? contactId = null)
        {
            return contactId == null
                ? !await context.Contacts.AnyAsync(c => c.Mobile == mobile)
                : !await context.Contacts.AnyAsync(c => c.Mobile == mobile && c.Id != contactId);
        }
    }
}
