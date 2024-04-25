using Microsoft.EntityFrameworkCore;

public class UserContext : DbContext
{

    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {
    }

    public DbSet<Order> Order { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { 
         modelBuilder.Entity<Order>().HasKey(order=>order.ID);
    }
}