using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace Northwind.EntityModels;

public class  Northwind : DbContext
{
    public DbSet<Order> Orders { get; set; }

    // The connection string should be stored securely, e.g., in a configuration file or environment variable.
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string database = "Northwind.db";
        string dir = Environment.CurrentDirectory;
        string path = string.Empty;

        if (dir.EndsWith("net10.0"))
        {
            path = Path.Combine("..", "..", "..", database);
        }
        else 
        {
            path = database;
        }

        path = Path.GetFullPath(path); // Get the absolute path to the database file
        WriteLine($"Database path: {path}");

        if (!File.Exists(path))
        {
            throw new FileNotFoundException(
                message: $"{path} not found.", fileName: path);
        }

        optionsBuilder.UseSqlite($"Data source={path}");
    }

}