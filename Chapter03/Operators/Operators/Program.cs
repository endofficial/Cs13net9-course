#region Exploring unary operators

ForegroundColor = (ConsoleColor)Enum.Parse(enumType: typeof(ConsoleColor), value: args[0], ignoreCase: true);
BackgroundColor = (ConsoleColor)Enum.Parse(enumType: typeof(ConsoleColor), value: args[1], ignoreCase: true);

int a = 5;
//int b = a++; //a = 6 e b = 5
int b = ++a; //a = 6 e b = 6
int c = 11;
int d = 3;
double e = 2.0;
WriteLine($"a: {a}, b: {b}");
WriteLine($"c is {c}, d is {d} and e is {e:N1}");
WriteLine($"c + d = {c + d}");
WriteLine($"c - d = {c - d}");
WriteLine($"c * d = {c * d}");
WriteLine($"c / d = {c / d}");
WriteLine($"c % d = {c % d}");
WriteLine($"c / e = {c / e}");

// To make your code more concise, you can use the following operators:
int f = 6;
//f += 3; // f = 9
//f -= 2; // f = 4
//f *= 2; // f = 12
//f /= 2; // f = 3

WriteLine($"f is now {f}");

/*string? authorName = GetAuthorName();

// fare in modo che la massima lunghezza variabile sarà la lunghezza di authorName se non è null, altrimenti 20
int maxLenght = authorName?.Length ?? 20;

// la variabile authorName è sconosciuta se è nulla
authorName ??= "Unknown";*/

// exploring logical operators
bool g = true;
bool h = false;
WriteLine($"AND | g     | h     ");
WriteLine($"g   | {g & g, -5} | {g & h, -5} ");
WriteLine($"h   | {h & g, -5} | {h & h, -5} ");
WriteLine();
WriteLine($"OR  | g     | h     ");
WriteLine($"g   | {g | g, -5} | {g | h, -5} ");
WriteLine($"h   | {h | g, -5} | {h | h, -5} ");
WriteLine();

/* L'operatore logico XOR (OR esclusivo) restituisce "vero" se e solo se uno dei due operandi è vero,
 ma non entrambi. Se entrambi gli operandi sono uguali (entrambi veri o entrambi falsi),
 il risultato è "falso".*/
WriteLine($"XOR | g     | h     ");
WriteLine($"g   | {g ^ g, -5} | {g ^ h, -5} ");
WriteLine($"h   | {h ^ g, -5} | {h ^ h, -5} ");

static bool DoStuff()
{
    WriteLine("I am doing some stuff.");
    return true;
}
WriteLine();
WriteLine($"g & DoStuff() = {g & DoStuff()}");
WriteLine($"h & DoStuff() = {h & DoStuff()}");

WriteLine();
WriteLine($"g & DoStuff() = {g && DoStuff()}");
// dostuff non è eseguita
WriteLine($"h & DoStuff() = {h && DoStuff()}");



// bitwise operators and binary shift operators
WriteLine();

int x = 10;
int y = 6;

WriteLine($"Expression | Decimal | Binary");
WriteLine($"-----------------------------");
WriteLine($"x          | {x,7} | {x:B8}");
WriteLine($"y          | {y,7} | {y:B8}");
WriteLine($"x & y      | {x & y,7} | {(x & y):B8}"); // AND bitwise operator
WriteLine($"x | y      | {x | y,7} | {(x | y):B8}"); // OR bitwise operator
WriteLine($"x ^ y      | {x ^ y,7} | {(x ^ y):B8}"); // XOR bitwise operator
WriteLine($"x << 3     | {x << 3,7} | {x << 3:B8}"); // spostamento a sinistra di 3 bit
WriteLine($"x >> 2     | {x >> 2,7} | {x >> 2:B8}"); // spostamento a destra di 2 bit

#endregion