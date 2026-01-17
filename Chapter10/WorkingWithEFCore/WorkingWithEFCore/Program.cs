using Northwind.EntityModels;

using NorthwindDb db = new(); // Create the DbContext
WriteLine($"Provider: {db.Database.ProviderName}"); // Show the database provider

ConfigureConsoole();
QueryingCategories();
FilteredIncludes();
QueryingProducts();