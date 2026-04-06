using System.Globalization;

partial class Program
{
    private static void ConfigureConsole(string culture = "en-Us", bool useComputerCulture = false)
    {
        OutputEncoding = System.Text.Encoding.UTF8;

        if (!useComputerCulture) CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(culture);

        WriteLine($"Current culture: {CultureInfo.CurrentCulture.DisplayName}");
    }

    private static void SectionTitle(string title)
    {
        ConsoleColor previousColor = ForegroundColor;
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine($"*** {title} ***\n");
        ForegroundColor = previousColor;
    }
}
