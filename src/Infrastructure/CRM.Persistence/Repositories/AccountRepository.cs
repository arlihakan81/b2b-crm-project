using CRM.Application.Repositories;
using CRM.Domain.Entities;
using CRM.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRM.Persistence.Repositories
{
    public class AccountRepository(ApplicationDbContext context) : Repository<Account>(context), IAccountRepository
    {
        readonly ApplicationDbContext context = context;

        public override async Task<IEnumerable<Account>?> GetAllAsync()
        {
            return await context.Accounts
                .Include(a => a.Contacts)
                .ToListAsync();
        }

        public override async Task<Account?> GetAsync(Expression<Func<Account, bool>> expression)
        {
            return await context.Accounts
                .Include(a => a.Contacts)
                .FirstOrDefaultAsync(expression);
        }

        public override async Task<Account?> GetByIdAsync(Guid id)
        {
            return await context.Accounts
                .Include(a => a.Contacts)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<bool> IsEmailUniqueAsync(string email, Guid? excludeId = null)
        {
            return !await context.Accounts
                .Where(a => a.Email == email && (excludeId == null || a.Id != excludeId) && !a.IsDeleted)
                .AnyAsync();
        }

        public async Task<bool> IsPhoneUniqueAsync(string phone, Guid? excludeId = null)
        {
            return !await context.Accounts
                .Where(a => a.Phone == phone && (excludeId == null || a.Id != excludeId) && !a.IsDeleted)
                .AnyAsync();
        }
    }
}
