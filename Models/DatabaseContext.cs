using Microsoft.EntityFrameworkCore;

public partial class DatabaseContext : DbContext {

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {


    }

    public virtual DbSet<Customer> Customer { get; set; }
    public virtual DbSet<Product> Product { get; set; }
    public virtual DbSet<ProductCategory> ProductCategory { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {

        modelBuilder.Entity<Customer>().HasKey(e => e.CustomerId);
        modelBuilder.Entity<Customer>().Property(p => p.Name).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<Customer>().Property(p => p.City).HasMaxLength(30).IsRequired();
        modelBuilder.Entity<Customer>().Property(p => p.State).HasMaxLength(30).IsRequired();
        modelBuilder.Entity<Customer>().Property(p => p.Latitude).HasPrecision(11, 3).IsRequired();
        modelBuilder.Entity<Customer>().Property(p => p.Longitude).HasPrecision(11, 3).IsRequired();

        modelBuilder.Entity<Product>().Property(p => p.Name).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<Product>().Property(p => p.UnitPrice).HasPrecision(11, 5).IsRequired();
        // modelBuilder.Entity<Customer>(entity => {entity.HasKey(k => k.Id);});
        OnModelCreating(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}