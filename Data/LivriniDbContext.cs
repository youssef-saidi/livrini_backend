using Microsoft.EntityFrameworkCore;
using Livrini.Models;

public class LivriniDbContext : DbContext
{
    public LivriniDbContext()
    {
    }

    public LivriniDbContext(DbContextOptions<LivriniDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql("Server=localhost; port=3306; Database=livrini; user=youssef; password=Said96232048@; Persist Security Info=False; Connect Timeout=300",ServerVersion.AutoDetect("Server=localhost; port=3306; Database=livrini; user=youssef; password=Said96232048@; Persist Security Info=False; Connect Timeout=300"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasKey(c => c.IdUser);
        modelBuilder.Entity<Dish>()
            .HasKey(c => c.IdDish);
        modelBuilder.Entity<Category>()
            .HasKey(c => c.IdCategory);
        modelBuilder.Entity<LigneOrder>()
            .HasKey(c => c.IdLigneOrder);
        modelBuilder.Entity<Order>()
            .HasKey(c => c.IdOrder);
        modelBuilder.Entity<Restaurant>()
            .HasKey(c => c.IdRestaurant);                                                
        // You can configure more aspects of the ConcertModel here.
    }

        public DbSet<User> User { get; set; }
        public DbSet<Dish> Dish { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<LigneOrder> LigneOrder { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Restaurant> Restaurent { get; set; }




}
