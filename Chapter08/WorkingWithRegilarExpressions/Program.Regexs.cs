using System.Text.RegularExpressions; // Per utilizzare Regex

partial class Program
{
    [GeneratedRegex(DigitsOnlyText, RegexOptions.IgnoreCase)]
    private static partial Regex DigitsOnly { get; }

    [GeneratedRegex(CommaSeparatortext, RegexOptions.IgnoreCase)]
    private static partial Regex CommaSeparator { get; }
}
