using Microsoft.EntityFrameworkCore;

namespace Northwind.EntityModels;

public class NorthwindDb : DbContext
{
    // These properties map to the tables in the database
    public DbSet<Category>? Categories { get; set; } 
    public DbSet<Product>? Products { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string databaseFile = "Northwind.db";
        string path = Path.Combine(Environment.CurrentDirectory, databaseFile);

        string connectionString = $"Data Source={path}";
        WriteLine($"Connection: {connectionString}");
        optionsBuilder.UseSqlite(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Example of using Fluent API instead of attributes to limit
        // the lenght of a category name to 15 characters.
        modelBuilder.Entity<Category>()
            .Property(category => category.CategoryName)
            .IsRequired() // Not null
            .HasMaxLength(15); // Max length of 15 characters
    }
}
