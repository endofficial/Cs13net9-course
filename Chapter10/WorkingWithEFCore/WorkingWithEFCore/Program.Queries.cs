using Microsoft.EntityFrameworkCore;
using Northwind.EntityModels;

partial class Program
{
    private static void QueryingCategories()
    {
        using NorthwindDb db = new();

        SectionTitle("Categories and how many products they have");

        IQueryable<Category>? categories = db.Categories?
            .Include(c => c.Products);

        // You could call any of the following LINQ methods and nothing
        // will be executed against the database:
        // Where, GroupBy, Select, SelectMany, OfType, OrderBy, ThenBy,
        // Join, GroupJoin, Take, Skip, Reverse.
        // Usually, methods that return IEnumerable or IQueryable
        // support deferred execution.
        // Usually, methods that return a single value do not support
        // deferred execution.

        if (categories is null || !categories.Any())
        {
            Fail("No categories found.");
            return;
        }

        // Enumerating the query converts it to SQL and executes it
        // against the database.
        // Execute query and enumerate results.
        foreach (Category c in categories)
        {
            WriteLine($"{c.CategoryName} has {c.Products.Count} products.");
        }
    }
}