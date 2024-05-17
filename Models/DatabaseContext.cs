
using Microsoft.EntityFrameworkCore;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DbContext> options) : base(options)
    {

    }
    public virtual DbSet<Customer> Customer { get;set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.Entity<Customer>(entity => {entity.HasKey(k =>k.Id);});
       OnModelCreating(modelBuilder);
    }



}

