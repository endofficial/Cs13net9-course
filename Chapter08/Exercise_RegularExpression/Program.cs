using System.Text.RegularExpressions;

WriteLine("The default regular expression checks for at least one digit.");

do
{
    Write($"Enter a regular expression (or press ENTER to use the default): ");
    string? regexPatt = ReadLine();

    if (string.IsNullOrWhiteSpace(regexPatt))
    {
        regexPatt = @"\d+"; 
    }

    Write("Enter some input: ");
    string? input = ReadLine();

    Regex r = new(regexPatt);
    WriteLine($"{input} matches {regexPatt}: {r.IsMatch(input)}\n");

    WriteLine("Press ESC to exit or any other key to continue...");
}
while (ReadKey(true).Key != ConsoleKey.Escape); // Keep running until ESC is pressed