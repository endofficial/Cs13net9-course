using System.Globalization;

partial class Program
{
    private static void ConfigureConsoole(string culture = "en-US", bool useComputerCulture = false)
    {
        // To enable Unicode characters in the console
        OutputEncoding = System.Text.Encoding.UTF8;

        if (!useComputerCulture)
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(culture); 
        }
        WriteLine($"CurrentCulture: {CultureInfo.CurrentCulture.DisplayName}");
    }

    private static void WriteLineColor(string text, ConsoleColor color)
    {
        ConsoleColor previousColor = ForegroundColor; // Save previous color
        ForegroundColor = color; // Set new color
        WriteLine(text);
        ForegroundColor = previousColor; // Restore previous color
    }

    private static void SectionTitle(string title)
    {
        WriteLineColor($"*** {title} ***", ConsoleColor.DarkYellow);
    }

    private static void Fail(string message)
    {
        WriteLineColor($"Fail > {message}", ConsoleColor.Red);
    }

    private static void Info(string message)
    {
        WriteLineColor($"Info > {message}", ConsoleColor.Cyan);
    }
}
