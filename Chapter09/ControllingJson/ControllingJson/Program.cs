using Packt.Shared;
using System.Text.Json; // for JsonSerializer

Book csharpoBook = new(title: "C# 13 and .NET 9 - Modern Cross-Platform Development Fundamentals")
{
    Author = "Mark J. Price",
    PublishDate = new DateTime(year: 2024, month: 11, day: 12),
    Created = DateTimeOffset.UtcNow,
    Pages = 823
};

JsonSerializerOptions options = new()
{
    IncludeFields = true, // include public fields
    PropertyNameCaseInsensitive = true, // Permette di accoppiare una chiave JSON a una proprietà C# senza tener conto delle maiuscole/minuscole
    WriteIndented = true, // Invece di produrre una stringa compressa su una sola riga, aggiunge spazi e a capo
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase, // Trasforma le proprietà C# in camelCase all'interno del JSON
};

string path = Combine(CurrentDirectory, "book.json");

using (Stream fileStream = File.Create(path))
{
    JsonSerializer.Serialize(utf8Json: fileStream, value: csharpoBook, options);
}

WriteLine("*** File Info ***");
WriteLine($"File: {GetFileName(path)}");
WriteLine($"Path: {GetDirectoryName(path)}");
WriteLine($"Size: {new FileInfo(path).Length} bytes");
WriteLine("/----------------");
WriteLine(File.ReadAllText(path));
WriteLine("----------------/");