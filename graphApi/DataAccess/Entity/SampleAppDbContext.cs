using Microsoft.EntityFrameworkCore;

namespace graphApi.DataAccess.Entity
{
    public class SampleAppDbContext : DbContext
    {
        public SampleAppDbContext(DbContextOptions<SampleAppDbContext> options)
            : base(options) { }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<Department> Department { get; set; }

        public DbSet<Product> Product { get; set; }
        public DbSet<ProductVariant> ProductVariant { get; set; }

        public DbSet<Collection> Collection { get; set; }

        public DbSet<Page> Page { get; set; }

        public DbSet<Menu> Menu { get; set; }

        public DbSet<Cart> Cart { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Page>().Property(b => b.CreatedAt).HasDefaultValueSql("getdate()");
            modelBuilder
                .Entity<Product>()
                .HasMany(p => p.Variants)
                .WithOne(e => e.Product)
                .HasForeignKey(v => v.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
