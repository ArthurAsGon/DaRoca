using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public partial class DatabaseContext : DbContext {

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}

    public virtual DbSet<Customer> Customer { get; set; }
    public virtual DbSet<Product> Product { get; set; }
    public virtual DbSet<ProductCategory> ProductCategory { get; set; }
    public virtual DbSet<SalesOrder> SalesOrders { get; set; }
    public virtual DbSet<SalesOrderItem> SalesOrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Customer>().HasKey(e => e.CustomerId);
        modelBuilder.Entity<Customer>().Property(p => p.Name).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<Customer>().Property(p => p.City).HasMaxLength(30).IsRequired();
        modelBuilder.Entity<Customer>().Property(p => p.State).HasMaxLength(30).IsRequired();
        modelBuilder.Entity<Customer>().Property(p => p.Latitude).HasPrecision(11, 3).IsRequired();
        modelBuilder.Entity<Customer>().Property(p => p.Longitude).HasPrecision(11, 3).IsRequired();

        modelBuilder.Entity<ProductCategory>().HasKey(e => e.ProductCategoryId);
        modelBuilder.Entity<ProductCategory>().Property(p => p.Name).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<ProductCategory>()
            .HasMany<Product>()
            .WithOne()
            .HasForeignKey(fk => fk.ProductCategoryId);

        modelBuilder.Entity<Product>().HasKey(e => e.ProductId);
        modelBuilder.Entity<Product>().Property(p => p.ProductCategoryId).IsRequired();
        modelBuilder.Entity<Product>().Property(p => p.Name).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<Product>().Property(p => p.UnitPrice).HasPrecision(11, 5).IsRequired();
        modelBuilder.Entity<Product>().HasMany<SalesOrderItem>().WithOne().HasForeignKey(fk => fk.ProductId);

        modelBuilder.Entity<SalesOrder>().HasKey(e => e.OrderId);
        modelBuilder.Entity<SalesOrder>().Property(p => p.OrderDate).IsRequired();
        modelBuilder.Entity<SalesOrder>().Property(p => p.EstimateDeliveryDate).IsRequired();
        modelBuilder.Entity<SalesOrder>().Property(p => p.Status).HasMaxLength(20).IsRequired();
        modelBuilder.Entity<SalesOrder>().HasMany<SalesOrderItem>().WithOne().HasForeignKey(fk => fk.OrderId);

        modelBuilder.Entity<SalesOrderItem>().HasKey(e => new { e.OrderId, e.ProductId });
        modelBuilder.Entity<SalesOrderItem>().Property(p => p.Quantity).IsRequired();
        modelBuilder.Entity<SalesOrderItem>().Property(p => p.UnitPrice).HasPrecision(11, 5).IsRequired();

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
