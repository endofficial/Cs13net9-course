using System.Numerics; //To use BigInteger

#region working with big integers
const int width = 40;

WriteLine("ulong.MaxValue vs a 30-digit BigInteger");
WriteLine(new string('-', width));

ulong big = ulong.MaxValue;
WriteLine($"{big,width:N0}");

BigInteger bigger = BigInteger.Parse("123456789012345678901234567890");
WriteLine($"{bigger,width:N0}");

#endregion

#region Multiplying big integers

WriteLine();
WriteLine("Multiplying big integers");
int number1 = 2_000_000_000;
int number2 = 2;
WriteLine($"number1: {number1:N0}");
WriteLine($"number2: {number2:N0}");
WriteLine($"number1 * number2: {number1 * number2:N0}"); // This overflows an int
WriteLine($"Math.BigMul(number1, number2): {Math.BigMul(number1, number2):N0}"); // This works correctly, because it returns a long
WriteLine($"int.BigMul(number1, number2): {int.BigMul(number1, number2):N0}"); // This works correctly, because it returns a long

#endregion

#region working with complex numbers

Complex c1 = new(real: 4, imaginary: 2);
Complex c2 = new(real: 3, imaginary: 7);
Complex c3 = c1 + c2;

WriteLine();
WriteLine($"{c1} added to {c2} is {c3}"); //using old method

// using new method
WriteLine("{0} + {1}i added to {2} + {3}i is {4} + {5}i", 
    c1.Real, c1.Imaginary,
    c2.Real, c2.Imaginary,
    c3.Real, c3.Imaginary);

#endregion

#region random numbers with the random class

Random r = Random.Shared; // static property to get a shared instance

WriteLine();
int dieRoll = r.Next(minValue: 1, maxValue: 7); // roll a 6-sided die
WriteLine($"Random die roll: {dieRoll}");

double randomReal = r.NextDouble(); // random real number between 0.0 and 1.0
WriteLine($"Random double: {randomReal}");

byte[] arrayOfBytes = new byte[256]; //serve per memorizzare 256 byte casuali
r.NextBytes(arrayOfBytes);
Write("Random bytes: ");
for (int i = 0; i < arrayOfBytes.Length; i++)
{
    Write($"{arrayOfBytes[i]:X2} "); //:XQ2 formats as hexadecimal with 2 digits
}
WriteLine();

#endregion

#region New random methods

WriteLine();
string[] beatles = r.GetItems(
    choices: new[] { "John", "Paul", "George", "Ringo" }, length: 4); //lenght indica il numero di scelte da effettuare

Write("Random ten beatles:");
foreach (string beatle in beatles)
{
    Write($" {beatle}");
}
WriteLine();

r.Shuffle(beatles); //in questo caso si va a mischiare l'array esistente creato da GetItems
Write("Shuffled beatles:");
foreach (string beatle in beatles)
{
    Write($" {beatle}");
}
WriteLine();

#endregion

#region Generating GUIDs

WriteLine();
WriteLine($"Empty GUID: {Guid.Empty}.");
Guid g = Guid.NewGuid();
WriteLine($"New GUID: {g}.");

byte[] guidasBytes = g.ToByteArray(); //convert GUID to byte array
WriteLine("GUID as byte array: ");
for (int i = 0; i < guidasBytes.Length; i++)
{
    Write($"{guidasBytes[i]:X2} ");
}
WriteLine();

// I tre GUID v7 generati in base alla data e ora corrente, per questo i primi 48 bit sono uguali poiché sono UUID basato sul tempo
WriteLine("Generating three v7 GUIDs:");
for (int i = 0; i < 3; i++)
{
    Guid g7 = Guid.CreateVersion7(DateTimeOffset.UtcNow); //create a v7 GUID based on current date and time
    WriteLine($" {g7}.");
}

#endregion