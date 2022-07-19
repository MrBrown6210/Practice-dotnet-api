using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace travel_api.Module.Stores;

public class StoreContext : DbContext
{
    public DbSet<Store> Stores { get; set; }
    public DbSet<StoreProduct> StoreProducts { get; set; }
    public DbSet<StoreProductItem> StoreProductItems { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=127.0.0.1:5432;Database=my_db;Username=my_user;Password=my_pw");
    }
}

public class Store
{
    public int StoreId { get; set; }
    public string Name { get; set; }
    public DateTime? Created { get; set; }
    public ICollection<StoreProductItem> ProductItems { get; set; }
}

public class StoreProductItem
{
    public int StoreProductItemId { get; set; }
    public int Quantity { get; set; }
    public virtual StoreProduct product { get; set; }
}

public class StoreProduct
{
    [Key]
    public int ProductId { get; set; }
    public double Price { get; set; }
    public string? Description { get; set; }
}