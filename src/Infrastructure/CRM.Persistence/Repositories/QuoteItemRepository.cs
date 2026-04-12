using CRM.Application.Repositories;
using CRM.Domain.Entities;
using CRM.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRM.Persistence.Repositories
{
    public class QuoteItemRepository(ApplicationDbContext context) : Repository<QuoteItem>(context), IQuoteItemRepository
    {
        readonly ApplicationDbContext context = context;

        public async Task DeleteRangeAsync(List<QuoteItem> items)
        {
            foreach(var item in items)
            {
                item.IsDeleted = true;
                context.QuoteItems.Update(item);
            }
            await context.SaveChangesAsync();
        }

        public override async Task<IEnumerable<QuoteItem>?> GetAllAsync()
        {
            return await context.QuoteItems.Include(_ => _.Quote).ThenInclude(_ => _.Deal).Include(_ => _.Product).ToListAsync();
        }

        public override async Task<QuoteItem?> GetAsync(Expression<Func<QuoteItem, bool>> expression)
        {
            return await context.QuoteItems.Include(_ => _.Quote).ThenInclude(_ => _.Deal).Include(_ => _.Product).FirstOrDefaultAsync(expression);
        }

        public override async Task<QuoteItem?> GetByIdAsync(Guid id)
        {
            return await context.QuoteItems.Include(_ => _.Quote).ThenInclude(_ => _.Deal).Include(_ => _.Product).FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<IEnumerable<QuoteItem>?> GetByQuoteIdAsync(Guid quoteId)
        {
            return await context.QuoteItems.Where(q => q.QuoteId == quoteId).Include(_ => _.Quote).ThenInclude(_ => _.Deal).Include(_ => _.Product).ToListAsync();
        }

    }
}
