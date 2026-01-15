partial class Program
{
    private static void SectionTitle(string title)
    {
        WriteLine();
        ConsoleColor previousColor = ForegroundColor;
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine($"*** {title} ***");
        ForegroundColor = previousColor; 
    }

    private static void OutputFileInfo(string path)
    {
        WriteLine("*** File Info ***");
        WriteLine($"File: {GetFileName(path)}");
        WriteLine($"Path: {GetDirectoryName(path)}");
        WriteLine($"Size: {new FileInfo(path).Length} bytes");
        WriteLine("/----------------");
        WriteLine(File.ReadAllText(path)); // forniscce come output il contenuto del file
        WriteLine("----------------/");
    }
}