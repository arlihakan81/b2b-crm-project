using CRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRM.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CRM;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasOne(a => a.Owner).WithMany(u => u.Accounts).HasForeignKey(a => a.OwnerId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Contact>().HasOne(c => c.Owner).WithMany(u => u.Contacts).HasForeignKey(c => c.OwnerId).OnDelete(DeleteBehavior.Restrict);
        }

    }
}
