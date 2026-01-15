var person = new { FirstName = "Jacqueline", Age = 40 };

string json = $$"""
               {
                    "First_name" : "{{person.FirstName}}",
                    "age" : "{{person.Age}}",
                    "calculation" : "{{1 + 4}}"
               }
               """;
Console.WriteLine(json);

// unsafe code
unsafe
{
    Console.WriteLine($"Half uses {sizeof(Half)} bytes and can store numbers in the range {Half.MinValue:N0} to {Half.MaxValue:N0}.");
    Console.WriteLine($"Int128 uses {sizeof(Int128)} bytes and can store numbers in the range {Int128.MinValue:N0} to {Int128.MaxValue:N0}.");

}