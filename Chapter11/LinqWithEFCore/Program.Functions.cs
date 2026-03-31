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
            inner: db.Products, // Join the Categories DbSet with the Products DbSet
            outerKeySelector: category => category.CategoryId, // Specify the key selector for the outer sequence (categories)
            innerKeySelector: product => product.CategoryId, // Specify the key selector for the inner sequence (products)
            resultSelector: (c, p) =>
                new { c.CategoryName, p.ProductName, p.ProductId }) // Specify the result selector to create an anonymous type with the category name, product name, and product ID
        .OrderBy(cp => cp.CategoryName); // Order the results by category name

        foreach (var p in queryJoin)
        {
            WriteLine($"{p.ProductId}: {p.ProductName} in {p.CategoryName}.");
        }
    }

    private static void GroupJoinCategoriesAndProducts()
    {
        SectionTitle("Group join categories and products");

        using NorthwindDb db = new(); // Create a new instance of the Northwind database context

        // AsNumerable() is used to switch from IQueryable to IEnumerable,
        // which allows the GroupJoin to be performed in memory rather than in the database.
        // This is necessary because GroupJoin does not have a direct translation to SQL.
        var queryGroup = db.Categories.AsEnumerable().GroupJoin(
            inner: db.Products,
            outerKeySelector: category => category.CategoryId,
            innerKeySelector: product => product.CategoryId,
            resultSelector: (c, matchingProducts) => new
            {
                c.CategoryName, // The name of the category
                Products = matchingProducts.OrderBy(p => p.ProductName) // Get all products that match the category and order them by product name 
            });

        foreach (var c in queryGroup)
        {
            WriteLine($"\n{c.CategoryName} has {c.Products.Count()} products.");

            foreach (var p in c.Products)
            {
                WriteLine($" {p.ProductName}");
            }
        }
    }

    private static void ProductsLookup()
    {
        SectionTitle("Products lookup");

        using NorthwindDb db = new();

        var productQuery = db.Categories.Join(
            inner: db.Products,
            outerKeySelector: category => category.CategoryId,
            innerKeySelector: product => product.CategoryId,
            resultSelector: (c, p) => new { c.CategoryName, Product = p }); // Product = p because we want to create an anonymous type that includes the category name and the product object itself

        // ToLookup creates a lookup (a collection of keys and their associated values) from the productQuery.
        ILookup<string, Product> productLookup = productQuery.ToLookup(
            keySelector: cp => cp.CategoryName, // keySelector specifies that the keys in the lookup should be the category names
            elementSelector: cp => cp.Product); // elementSelector specifies that the elements in the lookup should be the Product objects

        // IGrouping<string, Product> represents a group of products that share the same category name (the key of the lookup).
        foreach (IGrouping<string, Product> group in productLookup)
        {
            WriteLine($"{group.Key} has {group.Count()} products.");

            foreach (Product p in group)
            {
                WriteLine($"    {p.ProductName}");
            }
        }

        Write("Enter a category name: ");
        string categoryName = ReadLine()!;
        WriteLine();
        WriteLine($"Products in {categoryName}:");

        IEnumerable<Product> productsInCategory = productLookup[categoryName]; // Retrieve the products for the specified category name from the lookup

        foreach (Product p in productsInCategory) 
        {
            WriteLine($"    {p.ProductName}");
        }
    }
}
