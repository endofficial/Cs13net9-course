using System.Collections;
using System.Collections.Generic;

namespace System.Linq; // To extend Microsoft's namespace

public static class LinqExtensions
{
    public static IEnumerable<T> ProcessSequence<T>(
        this IEnumerable<T> sequence)
    {
        return sequence;
    }

    public static IQueryable<T> ProcessSequence<T>(
        this IQueryable<T> sequence)
    {
        return sequence;
    }

    public static int? Median(
        this IEnumerable<int?> sequence)
    {
        var ordered = sequence.OrderBy(item => item); // Sort the sequence in ascending order
        int middlePosition = ordered.Count() / 2; // Calculate the middle position
        return ordered.ElementAt(middlePosition); // ElementAt is zero-based, so it will return the middle element
    }

    // Questo ritora la mediana di una sequenza di elementi proiettati a int? usando un selettore
    public static int? Median<T>(
        this IEnumerable<T> sequence, Func<T, int?> selector) // con il selector, seleziona di quel tipo generico i valori int? da cui calcolare la mediana
    {
        return sequence.Select(selector).Median(); // Use the selector to project the sequence to int? and then call Median on it
    }

    public static decimal? Median(
        this IEnumerable<decimal?> sequence)
    {
        var ordered = sequence.OrderBy(item => item);
        int middlePosition = ordered.Count() / 2;
        return ordered.ElementAt(middlePosition);
    }

    public static decimal? Median<T>(
        this IEnumerable<T> sequence, Func<T, decimal?> selector)
    {
        return sequence.Select(selector).Median();
    }

    public static int? Mode(
        this IEnumerable<int?> sequence)
    {
        var grouped = sequence.GroupBy(item => item);

        // Order the groups by their count in descending order to find the most frequent element
        var orderedGroups = grouped.OrderByDescending(group => group.Count());
        return orderedGroups.FirstOrDefault()?.Key; // Return the key of the first group, which is the mode
    }

    public static int? Mode<T>(
        this IEnumerable<T> sequence, Func<T, int?> selector)
    {
        return sequence.Select(selector).Mode();
    }

    public static decimal? Mode(
        this IEnumerable<decimal?> sequence)
    {
        var grouped = sequence.GroupBy(item => item);

        // Order the groups by their count in descending order to find the most frequent element
        var orderedGroups = grouped.OrderByDescending(group => group.Count());
        return orderedGroups.FirstOrDefault()?.Key; // Return the key of the first group, which is the mode
    }

    public static decimal? Mode<T>(
        this IEnumerable<T> sequence, Func<T, decimal?> selector)
    {
        return sequence.Select(selector).Mode();
    }
}
