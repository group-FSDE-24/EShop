using EShop.Domain.Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace EShop.Persistence.Datas;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //modelBuilder.Entity<Product>()
        //    .HasOne(x => x.Category)
        //    .WithMany(x => x.Products)
        //    .HasForeignKey(x => x.CategoryId)
        //    .OnDelete(DeleteBehavior.Restrict);
    }


    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property("CreatedAt").CurrentValue = DateTime.Now;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Property("UpdatedAt").CurrentValue = DateTime.Now;

                entry.Property("CreatedAt").IsModified = false;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    // Table

    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Order> Orders{ get; set; }
    public virtual DbSet<Customer> Customers{ get; set; }
}
