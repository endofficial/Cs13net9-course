partial class Program
{
    private static void SectionTitle(string title)
    {
        WriteLine();
        ConsoleColor previousColor = ForegroundColor;
        ForegroundColor = ConsoleColor.DarkYellow; // cambia il colore del testo
        WriteLine($"*** {title} ***");
        ForegroundColor = previousColor; // questo recupera il colore precedente. 
    }
}
