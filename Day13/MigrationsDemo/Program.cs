using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

var _context = new InventoryContext();

var products = _context.Products.ToList();

foreach (var product in products)
{
    Console.WriteLine($"Product ID: {product.ProductId}, Name: {product.ProductName}, Price: {product.ListPrice}");
}

class InventoryContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=localhost;Database=InventoryManagementDB;User=root;Password=Sopan@123;";
        optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 0)));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductCategory>()
            .HasKey(c => c.CategoryId);

        modelBuilder.Entity<Product>()
            .HasKey(o => o.ProductId);

        modelBuilder.Entity<Product>()
            .HasOne(o => o.ProductCategory)
            .WithMany()
            .HasForeignKey(o => o.CategoryId);
    }
}

[Table("Product")]
public class Product
{
    public string ProductId { get; set; } = "";
    public string SKU { get; set; } = "";
    public string ProductName { get; set; } = "";
    public string Description { get; set; } = "";
    public string? CategoryId { get; set; }
    public string UnitOfMeasure { get; set; } = "";
    public decimal Cost { get; set; }
    public decimal ListPrice { get; set; }
    public bool IsActive { get; set; }
    public ProductCategory? ProductCategory { get; set; }
}

[Table("ProductCategory")]
public class ProductCategory
{
    public string CategoryId { get; set; } = "";
    public string? ParentCategoryId { get; set; }
    public string CategoryName { get; set; } = "";
    public string Description { get; set; } = "";
}

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
}

public class Order
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }

    [ForeignKey("CustomerId")]
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
}