using CRM.Application.Repositories;
using CRM.Domain.Entities;
using CRM.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRM.Persistence.Repositories
{
    public class ActivityRepository(AppDbContext context) : GenericRepository<Activity>(context), IActivityRepository
    {
        readonly AppDbContext context = context;
        public DbSet<Activity> Activities => context.Set<Activity>();

        public override async Task<IEnumerable<Activity>?> GetAllAsync(Expression<Func<Activity, bool>>? expression = null)
        {
            return expression is null ? await Activities.Include(a => a.Account).Include(a => a.Contact).Include(a => a.Attendees).ToListAsync() : await Activities.Where(expression).Include(a => a.Account).Include(a => a.Contact).Include(a => a.Attendees).ToListAsync();
        }

        public override async Task<Activity?> GetAsync(Expression<Func<Activity, bool>> expression)
        {
            return await Activities.Include(a => a.Account).Include(a => a.Contact).Include(a => a.Attendees).FirstOrDefaultAsync(expression);
        }

        public override async Task<Activity?> GetAsync(Guid id)
        {
            return await Activities.Include(a => a.Account).Include(a => a.Contact).Include(a => a.Attendees).FirstOrDefaultAsync(a => a.Id == id);
        }

        public override async Task CreateAsync(Activity entity)
        {
            await base.CreateAsync(entity);
            foreach(var i in entity.Attendees!)
            {
                i.ActivityId = entity.Id;
            }
            context.Attendees.AddRange(entity.Attendees!);
            await context.SaveChangesAsync();            
        }

        public override async Task UpdateAsync(Activity entity)
        {
            await base.UpdateAsync(entity);
            foreach (var i in entity.Attendees!)
            {
                i.ActivityId = entity.Id;
            }
            context.Attendees.UpdateRange(entity.Attendees!);
            await context.SaveChangesAsync();
        }

    }
}
