int decimalNotation = 2_000_000;
int binaryNotation = 0b_0001_1110_1000_0100_1000_0000;
int hexadecimalNotation = 0x_001E_8480;

// Controlla che le tre variabili hanno simile valore
Console.WriteLine($"{decimalNotation == binaryNotation}");
Console.WriteLine($"{decimalNotation == hexadecimalNotation}");

// ottenere un'uscita in valore decimale
Console.WriteLine($"{decimalNotation:N0}");
Console.WriteLine($"{binaryNotation:N0}");
Console.WriteLine($"{hexadecimalNotation:N0}");

// ottenere un'uscita in valore esadecimale
Console.WriteLine($"{decimalNotation:X}");
Console.WriteLine($"{binaryNotation:X}");
Console.WriteLine($"{hexadecimalNotation:X}");


// dichiaro un numero unsigned (zero o numero positivo)
uint naturalNumber = 24;
uint naturalNumber2 = 23;

// dichiaro un numero positivo o negativo
int integerNumber = -23;

// dichiaro un numero float. Inserire come suffisso per la compilazione F o f
float realNumber = 2.3f;

// dichiaro un numero double
double anotherNumber = 2.3;

// stampa la serie di numeri
Console.WriteLine($"Il numero naturale è: {naturalNumber + naturalNumber2}");
Console.WriteLine($"Il numero intero è: {integerNumber}");
Console.WriteLine($"Il numero reale è: {realNumber}");
Console.WriteLine($"Il double è: {anotherNumber}");


