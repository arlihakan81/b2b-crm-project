using CRM.Application.Repositories;
using CRM.Domain.Entities;
using CRM.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRM.Persistence.Repositories
{
    public class QuoteRepository(ApplicationDbContext context) : Repository<Quote>(context), IQuoteRepository
    {
        readonly ApplicationDbContext context = context;

        public override async Task<IEnumerable<Quote>?> GetAllAsync()
        {
            return await context.Quotes
                .Include(q => q.Deal)
                .ThenInclude(d => d.Contact).ThenInclude(c => c!.Account)
                .Include(q => q.Items)!
                    .ThenInclude(i => i.Product).ToListAsync();
        }

        public override async Task<Quote?> GetAsync(Expression<Func<Quote, bool>> expression)
        {
            return await context.Quotes
                .Include(q => q.Deal)
                .ThenInclude(q => q.Contact).ThenInclude(c => c!.Account)
                .Include(q => q.Items)!
                    .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(expression);
        }

        public override async Task<Quote?> GetByIdAsync(Guid id)
        {
            return await context.Quotes
                .Include(q => q.Deal)
                .ThenInclude(q => q.Contact).ThenInclude(c => c!.Account)
                .Include(q => q.Items)!
                    .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(q => q.Id == id);
        }

    }
}
