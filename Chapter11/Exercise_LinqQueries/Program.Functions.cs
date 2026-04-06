using Northwind.EntityModels;

partial class Program
{
    private static void CustomersAndOrders()
    {
        SectionTitle("Customers and orders");

        using NorthwindDb db = new();

        var cities = db.Customers
            .Select(c => c.City)
            .Distinct() // Get the distinct cities from the Customers table
            .OrderBy(c => c); // Order the cities alphabetically

        WriteLine(string.Join(", ", cities));

        Write("\nEnter a city: ");
        string? inputCity = ReadLine()?.ToLower();

        var customersInCity = db.Customers
            .Where(c => c.City.ToLower() == inputCity)
            .Select(c => c.CompanyName)
            .ToList();

        WriteLine($"\nThere are {customersInCity.Count()} customers in {inputCity}");
        foreach (var customer in customersInCity)
        {
            WriteLine($"    {customer}");
        }
    }
}