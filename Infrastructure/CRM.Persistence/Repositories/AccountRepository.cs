using CRM.Application.Repositories;
using CRM.Domain.Entities;
using CRM.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRM.Persistence.Repositories
{
    public class AccountRepository(AppDbContext context) : GenericRepository<Account>(context), IAccountRepository
    {
        public override async Task<IEnumerable<Account>?> GetAllAsync(Expression<Func<Account, bool>>? expression = null)
        {
            return expression is null ? await Table.Include(a => a.Contacts).Include(a => a.Owner).ToListAsync() : 
                await Table.Include(a => a.Contacts).Include(a => a.Owner)
                .Where(expression).ToListAsync();
        }

        public override Task<Account?> GetAsync(Expression<Func<Account, bool>> expression)
        {
            return Table.Include(a => a.Contacts).Include(a => a.Owner).FirstOrDefaultAsync(expression);
        }

        public override async Task<Account?> GetAsync(Guid id)
        {
            return await Table.Include(a => a.Contacts).Include(a => a.Owner).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<bool> IsEmailUniqueAsync(string email, Guid? excludeId = null)
        {
            return excludeId is null ?
                !await Table.AnyAsync(a => a.Email == email) :
                !await Table.AnyAsync(a => a.Email == email && a.Id != excludeId);
        }

        public async Task<bool> IsPhoneUniqueAsync(string phone, Guid? excludeId = null)
        {
            return excludeId is null ?
                !await Table.AnyAsync(a => a.Phone == phone) :
                !await Table.AnyAsync(a => a.Phone == phone && a.Id != excludeId);
        }
    }
}
