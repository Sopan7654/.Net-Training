// using Microsoft.Data.SqlClient;


// string query = "SELECT * FROM Employees WHERE Salary > 50000";
// SqlConnection connection = new SqlConnection("YourConnectionStringHere");
// SqlCommand cmd = new SqlCommand(query, connection);
// SqlDataReader reader = cmd.ExecuteReader();
// List<Employee> employees = new List<Employee>();
// while (reader.Read())
// {
//     employees.Add(new Employee { Name = (string)reader["Name"], Salary = (decimal)reader["Salary"] });
// }


// class Employee
// {
//     public string Name { get; set; }
//     public decimal Salary { get; set; }
// }

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

InventoryContext _context = new InventoryContext();

var products = _context.Products
    .Where(p => p.ListPrice > 0)
    .ToList();

// Without ToList()
// Console.WriteLine("products.GetType(): " + products.GetType());
// Console.WriteLine($"Query: {products.ToQueryString()}");

// With ToList()
// Console.WriteLine("products.GetType(): " + products.GetType());

// With AsEnumerable()
// Console.WriteLine("products.GetType(): " + products.GetType());

// products.Add(new Product { ProductId = "P007", ProductName = "CPU", ListPrice = 89000 });
// _context.SaveChanges();

Console.WriteLine($"Products Count: {products.Count()}");

products.Add(new Product { ProductId = "P004", ProductName = "Printer", ListPrice = 99000 });
_context.SaveChanges();

// Because DbSet is not IList, index operator will not work
// var first = _context.Products[0];

var printer = _context.Products.FirstOrDefault(p => p.ProductName == "Printer");
if (printer != null) printer.ListPrice = 100000;

_context.SaveChanges();

foreach (var product in products)
{
    Console.WriteLine($"Id: {product.ProductId} Product: {product.ProductName}, Price: {product.ListPrice}");
}

class InventoryContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    // public DbSet<Supplier> Suppliers { get; set; }
    // public DbSet<Warehouse> Warehouses { get; set; }
    // public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
    // public DbSet<ProductSupplier> ProductSuppliers { get; set; }
    // public DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }
    // public DbSet<StockLevel> StockLevels { get; set; }
    // public DbSet<StockTransaction> StockTransactions { get; set; }
    // public DbSet<Batch> Batches { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString =
            "Server=localhost;Database=InventoryManagementDB;User=root;Password=Sopan@123;";

        optionsBuilder.UseMySql(
            connectionString,
            ServerVersion.AutoDetect(connectionString));

        // optionsBuilder.UseSqlServer("YourConnectionStringHere");
        // optionsBuilder.UseNpgsql("YourConnectionStringHere");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasKey(p => p.ProductId);

        modelBuilder.Entity<Product>()
            .Property(p => p.ProductName)
            .IsRequired()
            .HasMaxLength(150);

        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany()
            .HasForeignKey(p => p.CategoryId);

        modelBuilder.Entity<ProductCategory>()
            .HasKey(c => c.CategoryId);

        modelBuilder.Entity<ProductCategory>()
            .HasOne(c => c.ParentCategory)
            .WithMany()
            .HasForeignKey(c => c.ParentCategoryId);

        // modelBuilder.Entity<Supplier>()
        //     .HasKey(s => s.SupplierId);

        // modelBuilder.Entity<Warehouse>()
        //     .HasKey(w => w.WarehouseId);

        // modelBuilder.Entity<PurchaseOrder>()
        //     .HasKey(po => po.PurchaseOrderId);

        // modelBuilder.Entity<PurchaseOrder>()
        //     .HasOne(po => po.Supplier)
        //     .WithMany()
        //     .HasForeignKey(po => po.SupplierId);

        // modelBuilder.Entity<ProductSupplier>()
        //     .HasKey(ps => ps.SupplierProductId);

        // modelBuilder.Entity<ProductSupplier>()
        //     .HasOne(ps => ps.Supplier)
        //     .WithMany()
        //     .HasForeignKey(ps => ps.SupplierId);

        // modelBuilder.Entity<ProductSupplier>()
        //     .HasOne(ps => ps.Product)
        //     .WithMany()
        //     .HasForeignKey(ps => ps.ProductId);

        // modelBuilder.Entity<PurchaseOrderItem>()
        //     .HasKey(poi => poi.POItemId);

        // modelBuilder.Entity<PurchaseOrderItem>()
        //     .HasOne(poi => poi.PurchaseOrder)
        //     .WithMany()
        //     .HasForeignKey(poi => poi.PurchaseOrderId);

        // modelBuilder.Entity<PurchaseOrderItem>()
        //     .HasOne(poi => poi.Product)
        //     .WithMany()
        //     .HasForeignKey(poi => poi.ProductId);

        // modelBuilder.Entity<StockLevel>()
        //     .HasKey(sl => sl.StockLevelId);

        // modelBuilder.Entity<StockLevel>()
        //     .HasOne(sl => sl.Product)
        //     .WithMany()
        //     .HasForeignKey(sl => sl.ProductId);

        // modelBuilder.Entity<StockLevel>()
        //     .HasOne(sl => sl.Warehouse)
        //     .WithMany()
        //     .HasForeignKey(sl => sl.WarehouseId);

        // modelBuilder.Entity<StockTransaction>()
        //     .HasKey(st => st.TransactionId);

        // modelBuilder.Entity<StockTransaction>()
        //     .HasOne(st => st.Product)
        //     .WithMany()
        //     .HasForeignKey(st => st.ProductId);

        // modelBuilder.Entity<StockTransaction>()
        //     .HasOne(st => st.Warehouse)
        //     .WithMany()
        //     .HasForeignKey(st => st.WarehouseId);

        // modelBuilder.Entity<Batch>()
        //     .HasKey(b => b.BatchId);

        // modelBuilder.Entity<Batch>()
        //     .HasOne(b => b.Product)
        //     .WithMany()
        //     .HasForeignKey(b => b.ProductId);

        // modelBuilder.Entity<Batch>()
        //     .HasOne(b => b.Warehouse)
        //     .WithMany()
        //     .HasForeignKey(b => b.WarehouseId);
    }
}

// =========================
// 1. SUPPLIER
// =========================
public class Supplier
{
    public string SupplierId { get; set; } = "";
    public string SupplierName { get; set; } = "";
    public string Email { get; set; } = "";
    public string Phone { get; set; } = "";
    public string Website { get; set; } = "";
}

// =========================
// 2. PRODUCT CATEGORY
// =========================
public class ProductCategory
{
    public string CategoryId { get; set; } = "";
    public string? ParentCategoryId { get; set; }
    public string CategoryName { get; set; } = "";
    public string Description { get; set; } = "";

    // Self-referencing navigation property
    public ProductCategory? ParentCategory { get; set; }
}

// =========================
// 3. WAREHOUSE
// =========================
public class Warehouse
{
    public string WarehouseId { get; set; } = "";
    public string WarehouseName { get; set; } = "";
    public string Location { get; set; } = "";
    public int Capacity { get; set; }
}

// =========================
// 4. PRODUCT
// =========================
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

    // Navigation property
    public ProductCategory? Category { get; set; }
}

// =========================
// 5. PURCHASE ORDER
// =========================
public class PurchaseOrder
{
    public string PurchaseOrderId { get; set; } = "";
    public string SupplierId { get; set; } = "";
    public DateTime OrderDate { get; set; }
    public string Status { get; set; } = "";

    public Supplier Supplier { get; set; } = null!;
}

// =========================
// 6. PRODUCT SUPPLIER
// =========================
public class ProductSupplier
{
    public string SupplierProductId { get; set; } = "";
    public string SupplierSKU { get; set; } = "";
    public int LeadTime { get; set; }
    public string SupplierId { get; set; } = "";
    public string ProductId { get; set; } = "";

    public Supplier Supplier { get; set; } = null!;
    public Product Product { get; set; } = null!;
}

// =========================
// 7. PURCHASE ORDER ITEM
// =========================
public class PurchaseOrderItem
{
    public string POItemId { get; set; } = "";
    public string PurchaseOrderId { get; set; } = "";
    public string ProductId { get; set; } = "";
    public int QuantityOrdered { get; set; }
    public decimal UnitPrice { get; set; }

    public PurchaseOrder PurchaseOrder { get; set; } = null!;
    public Product Product { get; set; } = null!;
}

// =========================
// 8. STOCK LEVEL
// =========================
public class StockLevel
{
    public string StockLevelId { get; set; } = "";
    public string ProductId { get; set; } = "";
    public string WarehouseId { get; set; } = "";
    public int QuantityOnHand { get; set; }
    public int ReorderLevel { get; set; }
    public int SafetyStock { get; set; }
    public int ReservedQuantity { get; set; }

    public Product Product { get; set; } = null!;
    public Warehouse Warehouse { get; set; } = null!;
}

// =========================
// 9. STOCK TRANSACTION
// =========================
public class StockTransaction
{
    public string TransactionId { get; set; } = "";
    public string ProductId { get; set; } = "";
    public string WarehouseId { get; set; } = "";
    public string TransactionType { get; set; } = "";
    public int Quantity { get; set; }
    public DateTime TransactionDate { get; set; }
    public string Reference { get; set; } = "";

    public Product Product { get; set; } = null!;
    public Warehouse Warehouse { get; set; } = null!;
}

// =========================
// 10. BATCH
// =========================
public class Batch
{
    public string BatchId { get; set; } = "";
    public string ProductId { get; set; } = "";
    public string WarehouseId { get; set; } = "";
    public string BatchNumber { get; set; } = "";
    public DateTime ManufacturingDate { get; set; }
    public DateTime ExpiryDate { get; set; }
    public int Quantity { get; set; }

    public Product Product { get; set; } = null!;
    public Warehouse Warehouse { get; set; } = null!;
}
