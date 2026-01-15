using System.Text;

WriteLine("Encodings");
WriteLine("[1] ASCII");
WriteLine("[2] UTF-8");
WriteLine("[3] UTF-16 (Unicode)");
WriteLine("[4] UTF-32");
WriteLine("[5] Latin1");
WriteLine("[any other key] Default encoding");
WriteLine();

Write("Press a number to chose an ecoding.");
ConsoleKey number = ReadKey(intercept: true).Key; // questa riga indica che non deve mostrare il tasto premuto
WriteLine(); WriteLine();

Encoding encoder = number switch
{
    // questo serve per mappare i tasti numerici sia quelli sopra le lettere che quelli del tastierino numerico
    ConsoleKey.D1 or ConsoleKey.NumPad1 => Encoding.ASCII,
    ConsoleKey.D2 or ConsoleKey.NumPad3 => Encoding.UTF8,
    ConsoleKey.D3 or ConsoleKey.NumPad4 => Encoding.Unicode,
    ConsoleKey.D4 or ConsoleKey.NumPad5 => Encoding.UTF32,
    ConsoleKey.D5 or ConsoleKey.NumPad6 => Encoding.Latin1,
    _ => Encoding.Default
};

string message = "Café £4.39";
WriteLine($"Text to encode {message}    Characters: {message.Length}.");

// encode the message into a byte array
byte[] encoded = encoder.GetBytes(message);

WriteLine("{0} used {1:N0} bytes.", arg0: encoder.GetType(), arg1: encoded.Length); // per controllare il numero di byte usati dall'encoding
WriteLine();

WriteLine("BYTE | HEX | CHAR");
foreach (byte b in encoded)
{
    WriteLine($"{b,4} | {b,3:X} | {(char)b,4}"); // mostra il byte, la sua rappresentazione esadecimale e il carattere corrispondente
}

//decodifica e stampa il messagio
string decoded = encoder.GetString(encoded);
WriteLine($"Decoded: {decoded}");

// Quando si utilizzano classi helper per lo streaming, come StreamReader e StreamWriter, è possibile specificare la
// codifica che si desidera utilizzare. Quando si scrive nell'helper, il testo verrà automaticamente codificato e, quando si
// legge dall'helper, i byte verranno automaticamente decodificati.

/*StreamReader reader = new (stream, Encoding.UTF8);
StreamWriter writer = new (stream, Encoding.UTF8);*/

//Spesso non avrete la possibilità di scegliere quale codifica utilizzare perché
//genererete un file da utilizzare su un altro sistema. Tuttavia, se dovete farlo,
//sceglietene una che utilizzi il
//minor numero di byte ma che possa memorizzare tutti i caratteri di cui avete bisogno.