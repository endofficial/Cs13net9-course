using System.Diagnostics;
using System.Runtime.CompilerServices;

partial class Program
{
    private static void DeferredExecution(string[] names)
    {
        SectionTitle("Deferred execution");

        // define two queries
        // Question: Which names end with an M?
        // Using a LINQ extension method
        var query1 = names.Where(name => name.EndsWith("m"));

        // The same question but using LINQ query comprehension syntax
        var query2 = from name in names where name.EndsWith("m") select name;

        //To get answer
        string[] result1 = query1.ToArray(); // returns as an array

        List<string> result2 = query2.ToList();

        foreach (string name in query1)
        {
            WriteLine(name);
            names[2] = "Jimmy";
        }
    }

    private static void FilteringUsingWhere(string[] names)
    {
        SectionTitle("Filtering entities using Where");

        // Primary query
        /* var query = names.Where(new Func<string, bool>(NameLongerThanFour));

         foreach (string item in query)
         {
             WriteLine(item);
         }*/

        // Second query
        /*var query = names.Where(NameLongerThanFour);
        foreach (string item in query)
        {
            WriteLine(item);
        }*/

        // Third query with lambda expression
        IOrderedEnumerable<string> query = names
            .Where(name => name.Length > 4)
            .OrderBy(name => name.Length)
            .ThenBy(name => name); // It is only use after OrderBy
        foreach (string item in query)
        {
            WriteLine(item);
        }
    }

    static void FilterByType()
    {
        SectionTitle("Filtering by type");

        List<Exception> exceptions = new()
        {
            new ArgumentException(), new SystemException(),
            new IndexOutOfRangeException(), new InvalidOperationException(),
            new NullReferenceException(), new InvalidCastException(),
            new OverflowException(), new DivideByZeroException(),
            new ApplicationException()
        };

        IEnumerable<ArithmeticException> arithmeticExceptionsQuery = exceptions.OfType<ArithmeticException>(); // Filter only Arithmetic exceptions

        foreach (ArithmeticException exception in arithmeticExceptionsQuery)
        {
            WriteLine(exception);
        }
    }

    static void Output(IEnumerable<string> cohort, string description = "")
    {
        if (!string.IsNullOrEmpty(description))
        {
            WriteLine(description);
        }
        Write(" ");
        WriteLine(string.Join(", ", cohort.ToArray()));
        WriteLine();
    }

    static void WorkingWithSets()
    {
        string[] cohort1 =
        { "Rachel", "Gareth", "Jonathan", "George" };
        string[] cohort2 =
        { "Jack", "Stephen", "Daniel", "Jack", "Jared" };
        string[] cohort3 =
        { "Declan", "Jack", "Jack", "Jasmine", "Conor" };

        SectionTitle("The cohorts");

        Output(cohort1, "Cohort 1");
        Output(cohort2, "Cohort 2");
        Output(cohort3, "Cohort 3");

        SectionTitle("Set operations");

        Output(cohort2.Distinct(), "cohort2.Distinct()"); // Remove duplicates
        Output(cohort2.DistinctBy(name => name.Substring(0, 2)), "cohort2.DistinctBy(name => name.Substring(0, 2):"); // Remove duplicates by first two characters
        Output(cohort2.Union(cohort3), "cohort2.Union(cohort3)"); // All unique names from both cohorts and remove duplicates
        Output(cohort2.Concat(cohort3), "cohort2.Concat(cohort3)"); // All names from both cohorts but keep duplicates
        Output(cohort2.Intersect(cohort3), "cohort2.Intersect(cohort3)"); // Names that are in both cohorts
        Output(cohort2.Except(cohort3), "cohort2.Except(cohort3)"); // Names that are in cohort2 but not in cohort3
        Output(cohort1.Zip(cohort2, (c1, c2) => $"{c1} matched with {c2}"), "cohort1.Zip(cohort2)"); // Match names from both cohorts by position and combine them into a string
    }

    static void WorkingWithIndicies()
    {
        string[] theSeven = { "Homelander",
            "Black Noir", "The Deep", "A-Train",
            "Queen Maeve", "Starlight", "Stormfront" };

        SectionTitle("Working With Indicies (old)");

        foreach (var (item, index) in theSeven.Select((item, index) => (item, index)))
        {
            WriteLine($"{index}: {item}");
        }

        SectionTitle("Working With Indicies (new)");

        foreach (var (index, item) in theSeven.Index())
        {
            WriteLine($"{index}: {item}");
        }
    }

    static bool NameLongerThanFour(string name)
    {
        return name.Length > 4;
    }
}