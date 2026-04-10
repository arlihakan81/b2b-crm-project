using CRM.Application.Interfaces;
using CRM.Domain.Entities;
using CRM.Domain.Entities.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;

namespace CRM.Persistence.Contexts
{
    public class ApplicationDbContext(IOrganizationService organizationService = null!) : DbContext
    {
        readonly IOrganizationService organizationService = organizationService;

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<DealCategory> DealCategories { get; set; }
        public DbSet<Lead> Leads { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<QuoteItem> QuoteItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=B2BCRM;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasQueryFilter(_ => _.OrganizationId == organizationService.GetCurrentOrganizationId() && !_.IsDeleted);
            modelBuilder.Entity<Contact>().HasQueryFilter(_ => _.OrganizationId == organizationService.GetCurrentOrganizationId() && !_.IsDeleted);
            modelBuilder.Entity<Product>().HasQueryFilter(_ => _.OrganizationId == organizationService.GetCurrentOrganizationId() && !_.IsDeleted);
            modelBuilder.Entity<Order>().HasQueryFilter(_ => _.OrganizationId == organizationService.GetCurrentOrganizationId() && !_.IsDeleted);
            modelBuilder.Entity<OrderItem>().HasQueryFilter(_ => _.OrganizationId == organizationService.GetCurrentOrganizationId() && !_.IsDeleted);
            modelBuilder.Entity<Deal>().HasQueryFilter(_ => _.OrganizationId == organizationService.GetCurrentOrganizationId() && !_.IsDeleted);
            modelBuilder.Entity<DealCategory>().HasQueryFilter(_ => _.OrganizationId == organizationService.GetCurrentOrganizationId() && !_.IsDeleted);
            modelBuilder.Entity<Lead>().HasQueryFilter(_ => _.OrganizationId == organizationService.GetCurrentOrganizationId() && !_.IsDeleted);
            modelBuilder.Entity<Quote>().HasQueryFilter(_ => _.OrganizationId == organizationService.GetCurrentOrganizationId() && !_.IsDeleted);
            modelBuilder.Entity<QuoteItem>().HasQueryFilter(_ => _.OrganizationId == organizationService.GetCurrentOrganizationId() && !_.IsDeleted);

            modelBuilder.Entity<Deal>().HasOne(_ => _.Owner).WithMany(_ => _.Deals).HasForeignKey(_ => _.OwnerId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Account>().HasOne(_ => _.Owner).WithMany(_ => _.Accounts).HasForeignKey(_ => _.OwnerId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Contact>().HasOne(_ => _.Owner).WithMany(_ => _.Contacts).HasForeignKey(_ => _.OwnerId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Lead>().HasOne(_ => _.Owner).WithMany(_ => _.Leads).HasForeignKey(_ => _.OwnerId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Deal>().Property(_ => _.LeadSource).HasConversion<string>();
            modelBuilder.Entity<Deal>().Property(_ => _.Type).HasConversion<string>();
            modelBuilder.Entity<Deal>().Property(_ => _.Currency).HasConversion<string>();
            modelBuilder.Entity<Deal>().Property(_ => _.Stage).HasConversion<string>();
            modelBuilder.Entity<Deal>().Property(_ => _.Priority).HasConversion<string>();
            modelBuilder.Entity<Lead>().Property(_ => _.Source).HasConversion<string>();

            modelBuilder.Entity<Account>().Property(_ => _.Type).HasConversion<string>();


            //modelBuilder.Entity<ApplicationRole>().HasData(
            //    [
            //        new ApplicationRole
            //        {
            //            Id = Guid.NewGuid(),
            //            Name = "Super Admin",
            //            Description = null
            //        },
            //        new ApplicationRole
            //        {
            //            Id = Guid.NewGuid(),
            //            Name = "Admin",
            //            Description = null
            //        },
            //        new ApplicationRole
            //        {
            //            Id = Guid.NewGuid(),
            //            Name = "User",
            //            Description = null
            //        }
            //    ]

            //    );
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // Eklenen veya güncellenen tüm entity'leri bul
            var entries = ChangeTracker.Entries();

            foreach (var entry in entries)
            {
                // Eğer entity ITenantEntity ise
                if (entry.Entity is BaseEntity baseEntity)
                {
                    // Yeni eklenen entity'ler için
                    if (entry.State == EntityState.Added)
                    {
                        // Tenant ID'yi otomatik ata
                        if(!organizationService.IsAuthenticated())
                        {
                            return await base.SaveChangesAsync(cancellationToken);
                        }
                        baseEntity.OrganizationId = organizationService.GetCurrentOrganizationId();
                    }
                    // Güncellenen entity'lerde TenantId değişmesin
                    else if (entry.State == EntityState.Modified)
                    {
                        entry.Property("OrganizationId").IsModified = false;
                    }
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }



    }
}
