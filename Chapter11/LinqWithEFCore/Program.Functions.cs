using Northwind.EntityModels;
using Microsoft.EntityFrameworkCore;

partial class Program
{
    private static void FilterAndSort()
    {
        SectionTitle("Filter and sort");

        using NorthwindDb db = new(); // Create a new instance of the Northwind database context

        DbSet<Product> allProducts = db.Products; // Get the DbSet of products from the database context

        IQueryable<Product> filterdProducts =
            allProducts.Where(product => product.UnitPrice < 10M); // Filter the products to include only those with a unit price less than 10

        IOrderedQueryable<Product> sortedProducts =
            filterdProducts.OrderByDescending(product => product.UnitPrice); // Sort the filtered products by unit price in ascending order

        var projectedProducts = sortedProducts
            .Select(product => new
            {
                product.ProductId, // Select the ProductId property
                product.ProductName,
                product.UnitPrice,
            });

        WriteLine("Products that cost less than $10, sorted by price:");
        WriteLine(projectedProducts.ToQueryString());

        foreach (var p in projectedProducts)
        {
            WriteLine("{0}: {1} costs {2:$#,##0.00}",
                p.ProductId, p.ProductName, p.UnitPrice);
        }
        WriteLine();
    }

    private static void JoinCategoriesAndProducts()
    {
        SectionTitle("Join categories and products");

        using NorthwindDb db = new(); // Create a new instance of the Northwind database context

        var queryJoin = db.Categories.Join(
            inner: db.Products,
            outerKeySelector: category => category.CategoryId,
            innerKeySelector: product => product.CategoryId,
            resultSelector: (c, p) =>
                new { c.CategoryName, p.ProductName, p.ProductId });

        foreach (var p in queryJoin)
        {
            WriteLine($"{p.ProductId}: {p.ProductName} in {p.CategoryName}.");
        }
    }
}
