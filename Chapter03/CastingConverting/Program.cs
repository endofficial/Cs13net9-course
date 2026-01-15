#region

using static System.Convert;
using System.Globalization;

int a = 10;
double b = a;
WriteLine($"a: {a}, b: {b}");

double c = 3.14;
int d = (int)c;
WriteLine($"c: {c}, d: {d}");

long e = 10;
int f = (int)e;
WriteLine($"e: {e}, f: {f}");

e = 5000000000;
f = (int)e;
WriteLine($"e is {e:N0}, f is {f:N0}");
WriteLine();

WriteLine("{0,12} {1,34}", "Decimal", "Binary"); // Formatting for alignment
WriteLine("{0,12} {0,34:B32}", int.MaxValue);

for (int i = 8; i >= -8; i--)
{
    WriteLine("{0,12} {0,34:B32}", i); // B32 indica che il numero è mostrato in binario con 32 bit
}

WriteLine("{0,12} {0,34:B32}", int.MinValue);
WriteLine();

// verficare il troncamento dei numeri
long r = 0b_101000101010001100100111010100101010;
int s = (int)r;

WriteLine($"{r,38:B38} = {r}");
WriteLine($"{s,38:B32} = {s}");
WriteLine();

double g = 9.8;
int h = ToInt32(g);
WriteLine($"g is {g}, h is {h}");

WriteLine();

double[,] doubles =
    {
       { 9.49, 9.50, 9.51 },
       { 10.49, 10.5, 10.51 },
       { 11.49, 11.50, 11.51 },
       { 12.49, 12.50, 12.51 },
       { -12.49, -12.50, -12.51 },
       { -11.49, -11.50, -11.51 },
       { -10.49, -10.50, -10.51 },
       { -9.49, -9.50, -9.51 }
    };

WriteLine($" | double | ToInt32  | double | ToInt32  | double | ToInt32 |");
for (int x = 0; x < 8; x++)
{
    for (int y = 0; y < 3; y++)
    {
        Write($" | {doubles [x,y], 6} | {ToInt32(doubles [x,y]), 7} ");
    }
    WriteLine("|");
}
WriteLine();

foreach (double n in doubles)
{
    WriteLine(format: "Math.Round({0}, 0, MidPointRounding.AwayFromZero) is {1}", arg0: n, arg1: Math.Round(value: n, digits: 0, mode: MidpointRounding.AwayFromZero));
}

WriteLine();

// convert from any type to a string
// anche non usando tostring, il wirteline converte in una stringa
int number = 12;
WriteLine(number); // esempio: Writeline(number.ToString())
bool boolean = true;
WriteLine(boolean);
DateTime now = DateTime.Now;
WriteLine(now);
object me = new();
WriteLine(me);

WriteLine();

byte[] binaryObject = new byte[128]; // allochiamo un array di 128 bytes

// popoliamo l'array con valori binary a random
Random.Shared.NextBytes(binaryObject);

WriteLine("Binary object as bytes:");
for (int index = 0; index < binaryObject.Length; index++)
{
    Write($"{binaryObject[index]:X2} ");
} 
WriteLine();
WriteLine();

string encoded = ToBase64String(binaryObject);
WriteLine($"Binary object as Base64: {encoded}");
WriteLine();

#endregion

#region Parsing from strings to numbers or dates and times

CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("it-IT");

int friends = int.Parse("23");
DateOnly birthday = DateOnly.Parse("11 novembre 2025");

WriteLine($"Io ho {friends} amici da invitare al mio party");
WriteLine($"Il mio compleanno sarà l' {birthday}");
WriteLine($"Il mio compleanno sarà {birthday:D}");
WriteLine();

#endregion

#region Using TryParse

Write("Quante uova ci sono? ");
string? input = ReadLine();

if (int.TryParse(input, out int count))
{
    WriteLine($"Ci sono {count} uova.");
}
else
{
    WriteLine("ERRORE! Non riesco ad analizzare l'input.");
}

#endregion