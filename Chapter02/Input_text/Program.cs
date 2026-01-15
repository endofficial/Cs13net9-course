using static System.Console;

Console.Write("Type first name and press Enter: ");
string? firstName = Console.ReadLine();
Console.Write("Type last name and press Enter: ");
string? lastName = Console.ReadLine();
Console.Write("Type age and press Enter: ");
string age = Console.ReadLine()!;

Console.WriteLine("");

Console.Write($"Hello {firstName} {lastName}, you look good for {age}.");
