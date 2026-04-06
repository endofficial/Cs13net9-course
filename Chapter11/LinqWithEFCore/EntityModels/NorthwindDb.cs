using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace Northwind.EntityModels;

public class  NorthwindDb : DbContext
{
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string database = "Northwind.db";  
        string dir = Environment.CurrentDirectory; // Get the current working directory
        string path = string.Empty; // Initialize an empty string for the path

        if (dir.EndsWith("net9.0"))
        {
            path = Path.Combine("..", "..", "..", database); 
        }
        else
        {
            path = database;
        }

        // convert to absolute path
        // la conversione serve per evitare problemi di path relativi a dove viene eseguito il programma
        path = Path.GetFullPath(path);
        WriteLine($"Database path: {path}");

        if (!File.Exists(path))
        {
            throw new FileNotFoundException(
                message: $"{path} not found.", fileName: path);
        }

        optionsBuilder.UseSqlite($"Data source={path}");
    }

    // SQLite does not support the 'money' data type, so we need to convert it to a compatible type (double) when using SQLite as the database provider.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (Database.ProviderName is not null && Database.ProviderName.Contains("Sqlite"))
        {
            modelBuilder.Entity<Product>()
                .Property(product => product.UnitPrice)
                .HasConversion<double>();
        }
    }
}