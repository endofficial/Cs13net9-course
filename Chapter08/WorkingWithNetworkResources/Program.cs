using System.Net;
using System.Net.NetworkInformation;

Write("Enter a valid web address (or press Enter): ");
string? url = ReadLine();

if (string.IsNullOrWhiteSpace(url))
{
    url = "https://stackoverflow.com/search?q=securestring";
}

Uri uri = new(url);
WriteLine($"URL: {url}");
WriteLine($"Scheme: {uri.Scheme}"); // indica lo schema (http, https, ftp, ecc.)
WriteLine($"Host: {uri.Host}");     // indica il dominio (www.example.com)
WriteLine($"Port: {uri.Port}");     // indica la porta (80, 443, ecc.)
WriteLine($"Path: {uri.AbsolutePath}"); // indica il percorso (/path/to/resource)
WriteLine($"Query: {uri.Query}");   // indica la query (?key=value&key2=value2)

//istruzioni per indirizzo IP 
IPHostEntry entry = Dns.GetHostEntry(uri.Host); // risolve il nome host in indirizzi IP, ovvero ottiene informazioni sugli indirizzi IP associati a un nome di dominio
WriteLine();
WriteLine($"{entry.HostName} has the following IP address:");

foreach (IPAddress address in entry.AddressList) // itera attraverso ogni indirizzo IP associato al nome host
{
    WriteLine($"  {address} ({address.AddressFamily})"); // stampa ogni indirizzo IP. AddressFamily indica il tipo di indirizzo (IPv4 o IPv6)
}

WriteLine();
try
{
    Ping ping = new(); // crea un'istanza della classe Ping per inviare richieste di ping

    WriteLine("Pinging server. Please wait...");
    PingReply reply = ping.Send(uri.Host); // invia una richiesta di ping al nome host specificato nell'URI
    WriteLine($"{uri.Host} was pinged and replied: {reply.Status}"); // stampa lo stato della risposta del ping (ad esempio, Success, TimedOut, ecc.)

    WriteLine("Reply from {0} took {1:N0}ms", arg0: reply.Address, arg1: reply.RoundtripTime); // stampa l'indirizzo IP del server che ha risposto e il tempo impiegato per il round trip in millisecondi
}
catch (Exception ex)
{
    WriteLine($"{ex.GetType().ToString()} says {ex.Message}");
}
