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

    // Table

    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Order> Orders{ get; set; }
    public virtual DbSet<Customer> Customers{ get; set; }
}
